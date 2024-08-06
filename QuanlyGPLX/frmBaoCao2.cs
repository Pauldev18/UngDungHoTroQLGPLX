using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyGPLX
{
    public partial class frmBaoCao2 : DevExpress.XtraEditors.XtraForm
    {
        private CheckBox headerCheckBox = null;

        private BindingSource bindingSource = new BindingSource();
        public frmBaoCao2()
        {
            InitializeComponent();
          
            // Tắt tính năng tự động thêm hàng mới
            data_dangKy.AllowUserToAddRows = false;
          
        }
    

        

      

       
        private void btnImportDataBC2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            string strFileName;

            using (OpenFileDialog openFD = new OpenFileDialog())
            {
                openFD.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    strFileName = openFD.FileName;

                    if (!string.IsNullOrEmpty(strFileName))
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(strFileName);
                        xlWorksheet = xlWorkbook.Worksheets[1];
                        xlRange = xlWorksheet.UsedRange;

                        // Xóa tất cả các cột cũ
                        data_dangKy.DataSource = null;
                        data_dangKy.Columns.Clear();
                        RemoveHeaderCheckBox();
                        // Thêm các cột mới

                        data_dangKy.Columns.Add("MaDangKy", "Mã Đăng Ký");
                        data_dangKy.Columns.Add("HoVaTen", "Họ và Tên");

                       

                        for (int xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                        {
                            if (xlRange.Cells[xlRow, 1].Value2 != null)
                            {
                                string hoVaTen = xlRange.Cells[xlRow, 1].Value2.ToString();
                                string maDangKy = xlRange.Cells[xlRow, 2].Value2.ToString();

                                // Thêm hàng vào DataGridView
                                data_dangKy.Rows.Add(maDangKy, hoVaTen);
                            }
                        }

                        xlWorkbook.Close(false);
                        xlApp.Quit();

                        // Giải phóng các đối tượng COM
                        Marshal.ReleaseComObject(xlRange);
                        Marshal.ReleaseComObject(xlWorksheet);
                        Marshal.ReleaseComObject(xlWorkbook);
                        Marshal.ReleaseComObject(xlApp);
                    }
                }
            }
        }

        private void frmBaoCao2_Load(object sender, EventArgs e)
        {
            using(var context = new DataClasses3DataContext())
            {
                data_baocao2.DataSource = context.BaoCaoIIs.Where(b => b.TrangThai== false)
                 .Select(b => new { b.MaBCII, b.MaBCI, b.SoBaoCao, b.NgayBaoCao, b.TongSoThiSinh })
                .ToList();
            }
        }

        private void data_baocao2_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
                lblMaBaoCao2.Text = data_baocao2.CurrentRow.Cells["MaBCII"].Value.ToString();
        }

        private void btnAddInBC2_Click(object sender, EventArgs e)
        {
            int successCount = 0;
            int failureCount = 0;
            var failedRecords = new List<(string MaDangKy, string Message)>();

            using (var context = new DataClasses3DataContext())
            {
                foreach (DataGridViewRow row in data_dangKy.Rows)
                {
                    if (row.Cells["MaDangKy"].Value != null)
                    {
                        string madk = row.Cells["MaDangKy"].Value.ToString();

                        try
                        {
                            var nguoilx = context.NguoiLX_HoSos.FirstOrDefault(n => n.MaDK == madk);

                            if (nguoilx != null)
                            {
                                string makhoahoc = nguoilx.MaKhoaHoc;
                                if (makhoahoc != null)
                                {
                                    var check = context.BaoCaoIs.FirstOrDefault(b => b.MaKH == makhoahoc);
                                    if (check == null)
                                    {
                                        throw new Exception("Chưa kết xuất báo cáo 1");
                                    }
                                }
                                if (lblMaBaoCao2.Text.Equals("MCB2"))
                                {
                                    throw new Exception("Vui lòng chọn báo cáo cần thêm");
                                }
                                nguoilx.MaBC2 = lblMaBaoCao2.Text;
                                nguoilx.TT_XuLy = "11";
                                successCount++;
                            }
                            else
                            {
                                failureCount++;
                                failedRecords.Add((madk, "Không tìm thấy thông tin người lái xe"));
                            }
                        }
                        catch (Exception ex)
                        {
                            failureCount++;
                            failedRecords.Add((madk, ex.Message));
                        }
                    }
                }

                try
                {
                    context.SubmitChanges();
                    MessageBox.Show($"Đã cập nhật thành công {successCount} bản ghi, thất bại {failureCount} bản ghi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (failedRecords.Count > 0)
                    {
                        ExportFailedRecordsToExcel(failedRecords);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu thay đổi vào cơ sở dữ liệu. Chi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ExportFailedRecordsToExcel(List<(string MaDangKy, string Message)> failedRecords)
        {
            // Mở hộp thoại lưu tệp
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
            saveFileDialog.Title = "Lưu tệp Excel";
            saveFileDialog.FileName = "FailedRecords.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Mã Đăng Ký";
                xlWorkSheet.Cells[1, 2] = "Message";

                int rowIndex = 2;
                foreach (var record in failedRecords)
                {
                    xlWorkSheet.Cells[rowIndex, 1] = record.MaDangKy;
                    xlWorkSheet.Cells[rowIndex, 2] = record.Message;
                    rowIndex++;
                }

                xlWorkBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                MessageBox.Show($"Đã xuất các bản ghi thất bại vào tệp {filePath}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void data_baocao2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new DataClasses3DataContext())
            {
                // Set the label text
                lblMaBaoCao2.Text = data_baocao2.CurrentRow.Cells["MaBCII"].Value.ToString();

                // Clear existing columns
                data_dangKy.Columns.Clear();

                // Add checkbox column
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "",
                    Name = "SelectCheckBox",
                    Width = 50,
                    ReadOnly = false
                };
                data_dangKy.Columns.Add(checkBoxColumn);

                // Add header checkbox
                AddHeaderCheckBox();

                // Set DataSource
                var data = (from n in context.NguoiLX_HoSos
                            join l in context.KhoaHocs on n.MaKhoaHoc equals l.MaKH
                            join hs in context.NguoiLXes on n.MaDK equals hs.MaDK
                            where n.MaBC2 == data_baocao2.CurrentRow.Cells["MaBCII"].Value.ToString()
                            select new
                            {
                                n.SoHoSo,
                                l.TenKH,
                                hs.HoVaTen,
                                hs.NgaySinh,
                                hs.MaDK
                            }).ToList();

                data_dangKy.DataSource = data;
                bindingSource.DataSource = data;
                // Display record count
                txt_tongbanghi.Text = $"{data.Count} bản ghi";
            }
        }
        private void RemoveHeaderCheckBox()
        {
            if (headerCheckBox != null)
            {
                // Loại bỏ checkbox khỏi Controls của DataGridView
                data_dangKy.Controls.Remove(headerCheckBox);
                headerCheckBox.Dispose();
                headerCheckBox = null;
            }

            // Khôi phục tiêu đề cột "SelectCheckBox"
            if (data_dangKy.Columns["SelectCheckBox"] != null)
            {
                data_dangKy.Columns["SelectCheckBox"].HeaderText = "Chọn";
            }
        }

        private void AddHeaderCheckBox()
        {
            headerCheckBox = new CheckBox
            {
                Size = new Size(18, 18),
                AutoCheck = true,
                Text = string.Empty
            };

           
            Rectangle headerCellRectangle = data_dangKy.GetCellDisplayRectangle(0, -1, true);
            Point headerCellLocation = headerCellRectangle.Location;

           
            int offsetX = (headerCellRectangle.Width - headerCheckBox.Width) / 13; 
            int offsetY = (headerCellRectangle.Height - headerCheckBox.Height) / 13; 
            headerCheckBox.Location = new Point(headerCellLocation.X + offsetX, headerCellLocation.Y + offsetY);

            headerCheckBox.CheckedChanged += new EventHandler(HeaderCheckBox_CheckedChanged);

            
            data_dangKy.Controls.Add(headerCheckBox);

         
            data_dangKy.Columns["SelectCheckBox"].HeaderText = string.Empty;
        }


        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (CheckBox)sender;

            foreach (DataGridViewRow row in data_dangKy.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["SelectCheckBox"];
                checkBoxCell.Value = headerCheckBox.Checked;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var context = new DataClasses3DataContext())
            {
                // Lấy tất cả các hàng được chọn
                var selectedRows = data_dangKy.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => Convert.ToBoolean(row.Cells["SelectCheckBox"].Value))
                    .ToList();

                // Duyệt qua tất cả các hàng được chọn và lấy MaDK
                foreach (var row in selectedRows)
                {
                    var maDK = row.Cells["MaDK"].Value.ToString();

                    // Tìm đối tượng NguoiLX tương ứng với MaDK và cập nhật MaBC2
                    var nguoiLX = context.NguoiLX_HoSos.FirstOrDefault(n => n.MaDK == maDK);
                    if (nguoiLX != null)
                    {
                        nguoiLX.MaBC2 = string.Empty; 
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SubmitChanges();

                // Clear existing columns
                data_dangKy.Columns.Clear();

                // Add checkbox column
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "",
                    Name = "SelectCheckBox",
                    Width = 50,
                    ReadOnly = false
                };
                data_dangKy.Columns.Add(checkBoxColumn);

                // Add header checkbox
                AddHeaderCheckBox();

                // Set DataSource
                var data = (from n in context.NguoiLX_HoSos
                            join l in context.KhoaHocs on n.MaKhoaHoc equals l.MaKH
                            join hs in context.NguoiLXes on n.MaDK equals hs.MaDK
                            where n.MaBC2 == data_baocao2.CurrentRow.Cells["MaBCII"].Value.ToString()
                            select new
                            {
                                n.SoHoSo,
                                l.TenKH,
                                hs.HoVaTen,
                                hs.NgaySinh,
                                hs.MaDK
                            }).ToList();

                data_dangKy.DataSource = data;

                // Display record count
                txt_tongbanghi.Text = $"{data.Count} bản ghi";
            }

            MessageBox.Show("Xóa thành công!");


           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           using(var context = new DataClasses3DataContext())
            {
                string searchValue = txtSearch.Text;
                var data = (from n in context.NguoiLX_HoSos
                            join l in context.KhoaHocs on n.MaKhoaHoc equals l.MaKH
                            join hs in context.NguoiLXes on n.MaDK equals hs.MaDK
                            where n.MaBC2 == data_baocao2.CurrentRow.Cells["MaBCII"].Value.ToString() &&
                              (hs.MaDK.Contains(searchValue) || hs.HoVaTen.Contains(searchValue) || l.TenKH.Contains(searchValue)) // Lọc dữ liệu dựa trên txtSearch

                            select new
                            {
                                n.SoHoSo,
                                l.TenKH,
                                hs.HoVaTen,
                                hs.NgaySinh,
                                hs.MaDK
                            }).ToList();

                data_dangKy.DataSource = data;
            }
        }
    }
}
