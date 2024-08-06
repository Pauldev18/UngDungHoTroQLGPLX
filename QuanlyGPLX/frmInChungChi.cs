using DevExpress.CodeParser.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using ImageMagick;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DevExpress.XtraPrinting.Drawing;
using System.IO;
using FreeImageAPI;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting;
using System.Drawing.Imaging;
namespace QuanlyGPLX
{
    public partial class frmInChungChi : DevExpress.XtraEditors.XtraForm
    {
        public frmInChungChi()
        {
            InitializeComponent();
            LoadYearsIntoComboBox();
            dgvThongTinHocVien.AutoGenerateColumns = false;
            cbx_ngayin.EditValue = DateTime.Now;
        }
        private void LoadYearsIntoComboBox()
        {
            using (DataClasses3DataContext db = new DataClasses3DataContext())
            {
                var years = db.KhoaHocs
                              .Where(k => k.NgayKG.HasValue)
                              .Select(k => k.NgayKG.Value.Year)
                              .Distinct()
                              .OrderBy(year => year)
                              .ToList();

                cbx_nam.DataSource = years;
            }
        }

        private void cbx_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = (int)cbx_nam.SelectedItem;

            using (DataClasses3DataContext db = new DataClasses3DataContext())
            {
                var courses = db.KhoaHocs
                                .Where(k => k.NgayKG.HasValue && k.NgayKG.Value.Year == selectedYear)
                                .Select(k => new
                                {
                                    MaKH = k.MaKH,
                                    TenKH = k.TenKH
                                })
                                .ToList();

                dgvDanhSachKhoaHoc.DataSource = courses;
            }
        }
        Image LoadImageFromPath(string path)
        {
            try
            {
                // Tải ảnh từ đường dẫn
                FIBITMAP dib = FreeImage.LoadEx(path);

                if (dib.IsNull)
                {
                    throw new Exception("Failed to load image.");
                }

                // Chuyển đổi FIBITMAP thành System.Drawing.Image
                Bitmap bitmap = FreeImage.GetBitmap(dib);

                // Giải phóng tài nguyên của FreeImage
                FreeImage.Unload(dib);

                return bitmap;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu không thể tải ảnh
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }
        
        private void dgvDanhSachKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var selectedRow = dgvDanhSachKhoaHoc.Rows[e.RowIndex];

                    // Kiểm tra xem ô cột có giá trị không và lấy giá trị
                    var maKhoaHocCellValue = selectedRow.Cells["MaKH"]?.Value;

                    if (maKhoaHocCellValue != null)
                    {
                        var maKhoaHoc = maKhoaHocCellValue.ToString();

                        using (DataClasses3DataContext db = new DataClasses3DataContext())
                        {
                            var drivers = from hs in db.NguoiLX_HoSos
                                          join nx in db.NguoiLXes on hs.MaDK equals nx.MaDK
                                          join lop in db.KhoaHocs on hs.MaKhoaHoc equals lop.MaKH
                                          where hs.MaKhoaHoc == maKhoaHoc
                                          select new
                                          {
                                              MaDangKy = hs.MaDK,
                                              Anh = hs.DuongDanAnh,
                                              Hovaten = nx.HoVaTenIn,
                                              Ngaysinh = Translate.ConvertDateVN(nx.NgaySinh),
                                              GioiTinh = nx.GioiTinh.ToString() == "M" ? "Nam" : nx.GioiTinh.ToString() == "F" ? "Nữ" : "Chưa xác định",
                                              XepLoai = hs.XepLoaiTotNghiep,
                                              SoHieu = hs.SoGiayCNTN,
                                              SoSoTN = hs.SoSoTN.Replace("|", ""), // Xóa ký tự phân cách và giữ định dạng chuỗi
                                              NgayKhaiGiang = lop.NgayKG,
                                              NgayBeGiang = lop.NgayBG,
                                              SoNgayDaoTao = lop.ThoiGianDT,
                                              Hang_GPLX = hs.HangGPLX,
                                              ImageView = LoadImageFromPath(hs.DuongDanAnh)
                                          };

                            // Chuyển dữ liệu thành danh sách và xử lý sắp xếp
                            var driverList = drivers.ToList();

                            // Kiểm tra danh sách có dữ liệu không
                            if (driverList != null && driverList.Any())
                            {
                                // Sắp xếp danh sách theo cột SoHieu, loại bỏ ký tự phân cách và chuyển đổi thành số nguyên cho việc sắp xếp
                                var sortedDrivers = driverList
                                                    .Select(d => new
                                                    {
                                                        d.MaDangKy,
                                                        d.Anh,
                                                        d.Hovaten,
                                                        d.Ngaysinh,
                                                        d.GioiTinh,
                                                        d.XepLoai,
                                                        OriginalSoHieu = d.SoHieu?.Replace("|", "") ?? "",
                                                        // Chuyển đổi thành số nguyên để sắp xếp
                                                        SoHieuInt = int.TryParse(d.SoHieu?.Replace("|", "").TrimStart('0'), out int num) ? num : int.MaxValue,
                                                        d.SoSoTN,
                                                        d.NgayKhaiGiang,
                                                        d.NgayBeGiang,
                                                        d.SoNgayDaoTao,
                                                        d.Hang_GPLX,
                                                        ImageView = LoadImageFromPath(d.Anh)
                                                    })
                                                    .OrderBy(d => d.SoHieuInt) // Sắp xếp theo số
                                                    .Select(d => new
                                                    {
                                                        d.MaDangKy,
                                                        d.Anh,
                                                        d.Hovaten,
                                                        d.Ngaysinh,
                                                        d.GioiTinh,
                                                        d.XepLoai,
                                                        // Giữ định dạng chuỗi đã loại bỏ ký tự phân cách
                                                        SoHieu = d.OriginalSoHieu,
                                                        d.SoSoTN,
                                                        d.NgayKhaiGiang,
                                                        d.NgayBeGiang,
                                                        d.SoNgayDaoTao,
                                                        d.Hang_GPLX,
                                                        ImageView = LoadImageFromPath(d.Anh)
                                                    })
                                                    .ToList();

                                // Gán dữ liệu đã sắp xếp vào DataGridView
                                dgvThongTinHocVien.DataSource = sortedDrivers;
                                dgvThongTinHocVien.Columns["Anh"].Visible = false;

                                lbl_sohocvien.Text = $"Danh sách có {sortedDrivers.Count} học viên";
                                if (dgvThongTinHocVien.Columns.Contains("ImageView"))
                                {
                                    DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dgvThongTinHocVien.Columns["ImageView"];
                                    imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Đảm bảo ảnh được hiển thị đầy đủ
                                    imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Tự động điều chỉnh kích thước cột để phù hợp với ảnh
                                }

                                // Điều chỉnh kích thước hàng để hình ảnh hiển thị đầy đủ
                                foreach (DataGridViewRow row in dgvThongTinHocVien.Rows)
                                {
                                    row.Height = 100; // Điều chỉnh chiều cao hàng theo kích thước ảnh mong muốn
                                }

                                MessageBox.Show("Đã load thành công");
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu cho mã khóa học này.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã khóa học không hợp lệ hoặc không có giá trị.");
                    }
                }
                else
                {
                    MessageBox.Show("Hàng không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dgvThongTinHocVien == null)
            {
                MessageBox.Show("DataGridView chưa được khởi tạo.");
                return;
            }

            foreach (DataGridViewRow row in dgvThongTinHocVien.Rows)
            {
                // Đảm bảo ô tồn tại và là DataGridViewCheckBoxCell
                if (row.Cells["Checkbox"] != null && row.Cells["Checkbox"] is DataGridViewCheckBoxCell checkBoxCell)
                {
                    // Kiểm tra xem giá trị có phải là null và thay đổi trạng thái
                    bool isChecked = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                    checkBoxCell.Value = !isChecked;
                }
                else
                {
                    // Xử lý các trường hợp ô không phải checkbox hoặc không tồn tại
                    MessageBox.Show("Ô không phải là checkbox hoặc không tồn tại.");
                }
            }
        }
        public void SetReportParameters(XtraReport report, string maDangKy, string anhPath, string hoTen, string gioiTinh, string ngaySinh, string xeploai, string soHieu, string soSoN, string hang_GPLX)
        {
            // Set report parameters
            if (gioiTinh.Equals("M"))
            {
                report.Parameters["p1"].Value = $"Upon: Mr.{Translate.CapitalizeFirstLetter(Translate.RemoveDiacritics(hoTen))}";
                report.Parameters["p_gt"].Value = "Giới tính: Nam";
            }
            else
            {
                report.Parameters["p1"].Value = $"Upon: {Translate.CapitalizeFirstLetter(Translate.RemoveDiacritics(hoTen))}";
                report.Parameters["p_gt"].Value = "Giới tính: Nữ";
            }

           
            report.Parameters["p4"].Value = $"Cho: {Translate.CapitalizeFirstLetter(hoTen)}";

            report.Parameters["p2"].Value = $"Date of birth: {Translate.ConvertDateToEng(ngaySinh)}";
            report.Parameters["p5"].Value = $"Ngày sinh: {Translate.ConvertDateVN(ngaySinh)}";

            report.Parameters["p3"].Value = $"Graduation grade: {Translate.XepLoaiEng(xeploai)}";
            report.Parameters["p6"].Value = $"Xếp loại tốt nghiệp: {Translate.formatChuDauTienVietHoa(xeploai)}";

            // lấy ngày hiện tại
            DateTime selectedDate = cbx_ngayin.DateTime; 
            string currentDate = selectedDate.ToString("yyyyMMdd");

            report.Parameters["ngay_ta"].Value = Translate.ConvertDateToEng(currentDate);
            report.Parameters["n_vi"].Value = $"  ngày {selectedDate.Day:D2}";
            string monthValue = selectedDate.Month <= 2 ? selectedDate.Month.ToString("D2") : selectedDate.Month.ToString();
            report.Parameters["t_vi"].Value = $" tháng {monthValue}";
            report.Parameters["na_vi"].Value = $" năm {selectedDate.Year}";

            // Tách phần trước dấu "-"
            string prefix = soSoN.Split('-')[0];

            // Loại bỏ tất cả các số 0 trong phần trước dấu "-"
            string sohieubo0 = soHieu.Replace("0", "");

            // Ghép kết quả với soHieu
            string result = $"{prefix}-{sohieubo0}";

            // Đặt giá trị cho parameter của báo cáo
            report.Parameters["sh_vi"].Value = $"Số vào sổ cấp chứng chỉ: {result}";

            report.Parameters["sh"].Value = $"Reg. No: {result}";
           
            report.Parameters["sh_ta"].Value = $"Số hiệu: {soHieu}";

            report.Parameters["p_hanglx_en"].Value = $"Driving a car of {hang_GPLX} class";
            report.Parameters["p_hanglx_vi"].Value = $"Lái xe ô tô hạng {hang_GPLX}";



            // Convert image to byte array and set it to report parameter
            if (!string.IsNullOrEmpty(anhPath) && File.Exists(anhPath))
            {
                try
                {
                    byte[] imageBytes = LoadJP2ImageAsByteArray(anhPath);

                    // Set the image byte array to the report parameter
                    report.Parameters["p_anh"].Value = imageBytes;
                    report.Parameters["p_anh"].Type = typeof(byte[]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                    report.Parameters["p_anh"].Value = null;
                }
            }
            else
            {
                MessageBox.Show($"Image path is invalid or file does not exist: {anhPath}");
                report.Parameters["p_anh"].Value = null;
            }
        }

        private byte[] LoadJP2ImageAsByteArray(string jp2Path)
        {
            // Khởi tạo FIBITMAP bằng cách gán giá trị mặc định (thường là không hợp lệ)
            FIBITMAP dib = new FIBITMAP();

            try
            {
                dib = FreeImage.LoadEx(jp2Path);

                // Kiểm tra nếu dib không hợp lệ
                if (dib.IsNull)
                {
                    throw new Exception("Failed to load image.");
                }

                using (Bitmap bitmap = FreeImage.GetBitmap(dib))
                {
                    if (bitmap == null)
                    {
                        throw new Exception("Failed to convert FIBITMAP to Bitmap.");
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Save as PNG
                        return ms.ToArray();
                    }
                }
            }
            finally
            {
                // Đảm bảo FreeImage resources được giải phóng
                if (!dib.IsNull)
                {
                    FreeImage.Unload(dib);
                }
            }
        }
        // Biến toàn cục để lưu tên máy in được chọn
        private string selectedPrinterName;
        private void ShowReportPreview(XtraReport report)
        {
            // Tắt yêu cầu tham số
            report.RequestParameters = false;
            ReportPrintTool printTool = new ReportPrintTool(report);
            if (check_print.Checked)
            {
                // Hiển thị hộp thoại xem trước báo cáo
                printTool.ShowPreviewDialog();
            }
            else
            {
                if (string.IsNullOrEmpty(selectedPrinterName))
                {
                    // Hiển thị hộp thoại chọn máy in nếu máy in chưa được chọn
                    bool? printDialogResult = printTool.PrintDialog() as bool?;

                    if (printDialogResult == true) // Kiểm tra nếu kết quả hộp thoại in là true
                    {
                        selectedPrinterName = printTool.PrinterSettings.PrinterName;
                    }
                }
                if (!string.IsNullOrEmpty(selectedPrinterName))
                {
                    // In trực tiếp mà không hiển thị hộp thoại chọn máy in lần nữa
                    printTool.Print(selectedPrinterName);
                }
            }
        }



        private void btnInCCSC_Click(object sender, EventArgs e)
        {
            selectedPrinterName = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Report Files (*.repx)|*.repx|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp báo cáo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // Lấy danh sách các hàng được chọn
                    var selectedRows = dgvThongTinHocVien.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => row.Cells["Checkbox"] is DataGridViewCheckBoxCell checkBoxCell &&
                                      checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                        .ToList();

                    if (selectedRows.Count == 0)
                    {
                        MessageBox.Show("Không có hàng nào được chọn.");
                        return;
                    }

                    foreach (var row in selectedRows)
                    {
                        // Tạo một instance của report từ file
                        XtraReport report = new XtraReport();
                        if (File.Exists(selectedFilePath))
                        {
                            report.LoadLayout(selectedFilePath);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy file report.");
                            return;
                        }

                        // Lấy dữ liệu từ hàng
                        var maDangKy = row.Cells["MaDangKy"]?.Value?.ToString();
                        var anhPath = row.Cells["Anh"]?.Value?.ToString();
                        var hoTen = row.Cells["Hovaten"]?.Value?.ToString();
                        var gioiTinh = row.Cells["GioiTinh"]?.Value?.ToString();
                        var ngaySinh = row.Cells["Ngaysinh"]?.Value?.ToString();
                        var xeploai = row.Cells["XepLoai"]?.Value?.ToString();
                        var soHieu = row.Cells["SoHieu"]?.Value?.ToString();
                        var soSoN = row.Cells["SoSoTN"]?.Value?.ToString();
                        var hang_GPLX = row.Cells["Hang_GPLX"]?.Value?.ToString();
                        // Thiết lập tham số cho báo cáo
                        SetReportParameters(report, maDangKy, anhPath, hoTen, gioiTinh, ngaySinh, xeploai, soHieu, soSoN, hang_GPLX);

                        ShowReportPreview(report);
                    }
                }
               
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (DataClasses3DataContext db = new DataClasses3DataContext())
            {
                var drivers = from hs in db.NguoiLX_HoSos
                              join nx in db.NguoiLXes on hs.MaDK equals nx.MaDK
                              join lop in db.KhoaHocs on hs.MaKhoaHoc equals lop.MaKH
                              where hs.NgayRaQDTN == date_ngayQD.DateTime 
                              select new
                              {
                                  MaDangKy = hs.MaDK,
                                  Anh = hs.DuongDanAnh,
                                  Hovaten = nx.HoVaTenIn,
                                  Ngaysinh = nx.NgaySinh,
                                  GioiTinh = nx.GioiTinh,
                                  XepLoai = hs.XepLoaiTotNghiep,
                                  SoHieu = hs.SoGiayCNTN,
                                  SoSoTN = hs.SoSoTN.Replace("|", ""), // Xóa ký tự phân cách và giữ định dạng chuỗi
                                  NgayKhaiGiang = lop.NgayKG,
                                  NgayBeGiang = lop.NgayBG,
                                  SoNgayDaoTao = lop.ThoiGianDT,
                                  Hang_GPLX = hs.HangGPLX,
                                  ImageView = LoadImageFromPath(hs.DuongDanAnh)
                              };

                // Chuyển dữ liệu thành danh sách và xử lý sắp xếp
                var driverList = drivers.ToList();

                // Kiểm tra danh sách có dữ liệu không
                if (driverList != null && driverList.Any())
                {
                    // Sắp xếp danh sách theo cột SoHieu, loại bỏ ký tự phân cách và chuyển đổi thành số nguyên cho việc sắp xếp
                    var sortedDrivers = driverList
                                        .Select(d => new
                                        {
                                            d.MaDangKy,
                                            d.Anh,
                                            d.Hovaten,
                                            d.Ngaysinh,
                                            d.GioiTinh,
                                            d.XepLoai,
                                            OriginalSoHieu = d.SoHieu?.Replace("|", "") ?? "",
                                            SoHieuInt = int.TryParse(d.SoHieu?.Replace("|", "").TrimStart('0'), out int num) ? num : int.MaxValue,
                                            d.SoSoTN,
                                            d.NgayKhaiGiang,
                                            d.NgayBeGiang,
                                            d.SoNgayDaoTao,
                                            d.Hang_GPLX,
                                            ImageView = LoadImageFromPath(d.Anh)
                                        })
                                        .OrderBy(d => d.SoHieuInt) // Sắp xếp theo số
                                        .Select(d => new
                                        {
                                            d.MaDangKy,
                                            d.Anh,
                                            d.Hovaten,
                                            d.Ngaysinh,
                                            d.GioiTinh,
                                            d.XepLoai,
                                            // Giữ định dạng chuỗi đã loại bỏ ký tự phân cách
                                            SoHieu = d.OriginalSoHieu,
                                            d.SoSoTN,
                                            d.NgayKhaiGiang,
                                            d.NgayBeGiang,
                                            d.SoNgayDaoTao,
                                            d.Hang_GPLX,
                                            ImageView = LoadImageFromPath(d.Anh)
                                        })
                                        .ToList();

                    // Gán dữ liệu đã sắp xếp vào DataGridView
                    dgvThongTinHocVien.DataSource = sortedDrivers;
                    dgvThongTinHocVien.Columns["Anh"].Visible = false;
                    lbl_sohocvien.Text = $"Danh sách có {sortedDrivers.Count} học viên";
                    lbl_sohocvien.Text = $"Danh sách có {sortedDrivers.Count} học viên";
                    if (dgvThongTinHocVien.Columns.Contains("ImageView"))
                    {
                        DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dgvThongTinHocVien.Columns["ImageView"];
                        imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Đảm bảo ảnh được hiển thị đầy đủ
                        imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Tự động điều chỉnh kích thước cột để phù hợp với ảnh
                    }

                    // Điều chỉnh kích thước hàng để hình ảnh hiển thị đầy đủ
                    foreach (DataGridViewRow row in dgvThongTinHocVien.Rows)
                    {
                        row.Height = 100; // Điều chỉnh chiều cao hàng theo kích thước ảnh mong muốn
                    }

                    MessageBox.Show("Đã load thành công");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu.");
                }
            }
        }

        private void textEdit6_TextChanged(object sender, EventArgs e)
        {
            using (DataClasses3DataContext db = new DataClasses3DataContext())
            {
                var drivers = from hs in db.NguoiLX_HoSos
                              join nx in db.NguoiLXes on hs.MaDK equals nx.MaDK
                              join lop in db.KhoaHocs on hs.MaKhoaHoc equals lop.MaKH
                              where (hs.MaDK.Contains(txt_search.Text) || nx.HoVaTen.Contains(txt_search.Text))
                              select new
                              {
                                  MaDangKy = hs.MaDK,
                                  Anh = hs.DuongDanAnh,
                                  Hovaten = nx.HoVaTenIn,
                                  Ngaysinh = nx.NgaySinh,
                                  GioiTinh = nx.GioiTinh,
                                  XepLoai = hs.XepLoaiTotNghiep,
                                  SoHieu = hs.SoGiayCNTN,
                                  SoSoTN = hs.SoSoTN.Replace("|", ""), // Xóa ký tự phân cách và giữ định dạng chuỗi
                                  NgayKhaiGiang = lop.NgayKG,
                                  NgayBeGiang = lop.NgayBG,
                                  SoNgayDaoTao = lop.ThoiGianDT,
                                  Hang_GPLX = hs.HangGPLX
                              };

                // Chuyển dữ liệu thành danh sách và xử lý sắp xếp
                var driverList = drivers.ToList();

                // Kiểm tra danh sách có dữ liệu không
                if (driverList != null && driverList.Any())
                {
                    // Sắp xếp danh sách theo cột SoHieu, loại bỏ ký tự phân cách và chuyển đổi thành số nguyên cho việc sắp xếp
                    var sortedDrivers = driverList
                                        .Select(d => new
                                        {
                                            d.MaDangKy,
                                            d.Anh,
                                            d.Hovaten,
                                            d.Ngaysinh,
                                            d.GioiTinh,
                                            d.XepLoai,
                                            OriginalSoHieu = d.SoHieu?.Replace("|", "") ?? "",
                                            // Chuyển đổi thành số nguyên để sắp xếp
                                            SoHieuInt = int.TryParse(d.SoHieu?.Replace("|", "").TrimStart('0'), out int num) ? num : int.MaxValue,
                                            d.SoSoTN,
                                            d.NgayKhaiGiang,
                                            d.NgayBeGiang,
                                            d.SoNgayDaoTao,
                                            d.Hang_GPLX
                                        })
                                        .OrderBy(d => d.SoHieuInt) // Sắp xếp theo số
                                        .Select(d => new
                                        {
                                            d.MaDangKy,
                                            d.Anh,
                                            d.Hovaten,
                                            d.Ngaysinh,
                                            d.GioiTinh,
                                            d.XepLoai,
                                            // Giữ định dạng chuỗi đã loại bỏ ký tự phân cách
                                            SoHieu = d.OriginalSoHieu,
                                            d.SoSoTN,
                                            d.NgayKhaiGiang,
                                            d.NgayBeGiang,
                                            d.SoNgayDaoTao,
                                            d.Hang_GPLX
                                        })
                                        .ToList();

                    // Gán dữ liệu đã sắp xếp vào DataGridView
                    dgvThongTinHocVien.DataSource = sortedDrivers;
                    dgvThongTinHocVien.Columns["Anh"].Visible = false;
                    lbl_sohocvien.Text = $"Danh sách có {sortedDrivers.Count} học viên";
                    lbl_sohocvien.Text = $"Danh sách có {sortedDrivers.Count} học viên";
                    if (dgvThongTinHocVien.Columns.Contains("ImageView"))
                    {
                        DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dgvThongTinHocVien.Columns["ImageView"];
                        imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Đảm bảo ảnh được hiển thị đầy đủ
                        imgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Tự động điều chỉnh kích thước cột để phù hợp với ảnh
                    }

                    // Điều chỉnh kích thước hàng để hình ảnh hiển thị đầy đủ
                    foreach (DataGridViewRow row in dgvThongTinHocVien.Rows)
                    {
                        row.Height = 100; // Điều chỉnh chiều cao hàng theo kích thước ảnh mong muốn
                    }

                    MessageBox.Show("Đã load thành công");
                }
               
            }
        }
        private Bitmap LoadJp2Image(string filePath)
        {
            // Load the JP2 image using FreeImage
            FREE_IMAGE_FORMAT format = FreeImage.GetFileType(filePath, 0);
            FIBITMAP bitmap = FreeImage.Load(format, filePath, FREE_IMAGE_LOAD_FLAGS.DEFAULT);

            if (bitmap.IsNull)
            {
                MessageBox.Show("Failed to load the image.");
                return null;
            }

            // Convert the FIBITMAP to a 24-bit bitmap
            FIBITMAP bitmap24 = FreeImage.ConvertTo24Bits(bitmap);

            // Convert the FIBITMAP to a .NET Bitmap
            Bitmap netBitmap = FreeImage.GetBitmap(bitmap24);

            // Clean up
            FreeImage.UnloadEx(ref bitmap);
            FreeImage.UnloadEx(ref bitmap24);

            return netBitmap;
        }

        private void dgvThongTinHocVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string filePath = dgvThongTinHocVien.CurrentRow?.Cells["Anh"]?.Value?.ToString();

            if (!string.IsNullOrEmpty(filePath))
            {
                Bitmap image = LoadJp2Image(filePath);

                if (image != null)
                {
                    // Set the image and adjust the size mode
                    pictureEdit1.Image = image;
                    pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                }
            }
            else
            {
                MessageBox.Show("No image path selected or the path is invalid.");
            }

             txt_madk.Text = dgvThongTinHocVien.CurrentRow?.Cells["MaDangKy"]?.Value?.ToString();
             txt_hoten.Text = dgvThongTinHocVien.CurrentRow?.Cells["Hovaten"]?.Value?.ToString();
            using (DataClasses3DataContext db = new DataClasses3DataContext())
            {
                try
                {
                    var query = from hs in db.NguoiLX_HoSos
                                where hs.MaDK.Contains(txt_madk.Text)
                                select new
                                {
                                    SoHieu = hs.SoGiayCNTN
                                };

                    // Lấy kết quả đầu tiên từ truy vấn
                    var result = query.FirstOrDefault();

                    if (result != null)
                    {
                        // Tách chuỗi dựa trên dấu '|'
                        string[] parts = result.SoHieu.Split('|');

                        // Kiểm tra nếu chuỗi có ít nhất hai phần
                        if (parts.Length >= 2)
                        {
                            // Gán phần trước dấu '|' vào txt_sh1
                            txt_sh1.Text = parts[0];

                            // Gán phần sau dấu '|' vào txt_sh2
                            txt_sh2.Text = parts[1];
                        }
                        else
                        {
                            // Nếu không có dấu phân cách '|', gán toàn bộ vào txt_sh1
                            txt_sh1.Text = result.SoHieu;
                            txt_sh2.Text = string.Empty;
                        }
                    }
                    else
                    {
                        // Nếu không có kết quả nào, bạn có thể xóa các giá trị hoặc thông báo
                        txt_sh1.Text = string.Empty;
                        txt_sh2.Text = string.Empty;
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
