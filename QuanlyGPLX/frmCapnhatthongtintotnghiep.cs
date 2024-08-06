using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DataAccess.Excel;
using Microsoft.Office.Interop.Excel;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

namespace QuanlyGPLX
{
    public partial class frmCapnhatthongtintotnghiep : DevExpress.XtraEditors.XtraForm
    {
        public frmCapnhatthongtintotnghiep()
        {
            InitializeComponent();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            string strFileName;

            openFD.Filter = "Select File |*.xls; *.xlsx; *.xlsm";
            openFD.ShowDialog();
            strFileName = openFD.FileName;

            if (!string.IsNullOrEmpty(strFileName))
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFileName);
                xlWorksheet = xlWorkbook.Worksheets[1]; 
                xlRange = xlWorksheet.UsedRange;

                int rowIndex = 0;

                dgvCapnhatTTTN.Rows.Clear(); // Clear existing rows

                for (int xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Value2 != null)
                    {
                        rowIndex++;
                        string maHocVien = xlRange.Cells[xlRow, 1].Value2.ToString();
                        string hoVaTen = xlRange.Cells[xlRow, 2].Value2.ToString();
                        string ngaySinh = xlRange.Cells[xlRow, 3].Value2.ToString();
                        string gioiTinh = xlRange.Cells[xlRow, 4].Value2.ToString();
                        string xepLoai = xlRange.Cells[xlRow, 5].Value2.ToString();

                        dgvCapnhatTTTN.Rows.Add(rowIndex, maHocVien, hoVaTen,ngaySinh, gioiTinh,xepLoai);
                    }
                }

                xlWorkbook.Close();
                xlApp.Quit();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string soCCN1 = txtSoCCN1.Text;
            string soCCN2 = txtSoCCN2.Text;
            // Số chứng nhận tốt nghiệp
            string soCNTN1 = txtSoCNTN1.Text;
            string soCNTN2 = txtSoCNTN2.Text;

            if (string.IsNullOrEmpty(soCCN1) || string.IsNullOrEmpty(soCCN2))
            {
                MessageBox.Show("Vui lòng nhập giá trị cho cả hai ô số CCN.");
                return;
            }

            if (string.IsNullOrEmpty(soCNTN1) || string.IsNullOrEmpty(soCNTN2))
            {
                MessageBox.Show("Vui lòng nhập giá trị cho cả hai ô số CNTN.");
                return;
            }

            // Chỉ lấy 3 ký tự đầu tiên từ soCCN1
            if (soCCN1.Length > 3)
            {
                soCCN1 = soCCN1.Substring(0, 3);
            }

            // Kết hợp hai chuỗi lại và chuyển đổi thành số
            long soCCNBase;
            if (!long.TryParse(soCCN1 + soCCN2, out soCCNBase))
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ. Vui lòng kiểm tra lại.");
                return;
            }

            // Kết hợp hai chuỗi lại và chuyển đổi thành số (Số CNTN)
            long soCCTNBase;
            if (!long.TryParse(soCNTN1 + soCNTN2, out soCCTNBase))
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ. Vui lòng kiểm tra lại.");
                return;
            }

            foreach (DataGridViewRow row in dgvCapnhatTTTN.Rows)
            {
             
                if (row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    // Chuyển đổi số cơ bản thành chuỗi 7 ký tự với định dạng "D7"
                    string soCCN = soCCNBase.ToString("D7");
                    string soCCTN = soCCTNBase.ToString("D7");

                    // Gán giá trị cho cột "Số CCN"
                    row.Cells["Column12"].Value = soCCN;
                    row.Cells["SoCNTN"].Value = soCCTN;
                    row.Cells["SoSoCNTN"].Value = txtSoSoCNTN.Text;
                    row.Cells["SoQD"].Value = txtSoQD.Text;
                    row.Cells["dateCNTN"].Value = DENgayVaoSoCNTN.Text;
                    row.Cells["DateQD"].Value = DENgayQD.Text;
                    row.Cells["date"].Value = DENgayThangNam.Text;
                    row.Cells["SoSoCCN"].Value = txtSoSoCCN.Text;
                    row.Cells["dateSoCCN"].Value = DENgayVaoSoCCN.Text;
                    row.Cells["dateCapCCN"].Value = DENgayCapCCN.Text;

                    // Tăng giá trị cơ bản thêm 1
                    soCCNBase++;
                    soCCTNBase++;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (var context = new DataClasses3DataContext())
            {
                int successCount = 0;
                int failureCount = 0;
                var failedRecords = new List<(string MaDK, string Message)>();

                foreach (DataGridViewRow row in dgvCapnhatTTTN.Rows)
                {
                    if (row.Cells["MaDK"].Value != null)
                    {
                        string madk = row.Cells["MaDK"].Value.ToString();

                        try
                        {
                            var nguoilx = context.NguoiLX_HoSos.FirstOrDefault(n => n.MaDK == madk);

                            if (nguoilx != null)
                            {
                                nguoilx.SoSoTN = row.Cells["SoSoCNTN"].Value?.ToString();
                                nguoilx.SoQuyetDinhTN = row.Cells["SoQD"].Value?.ToString();
                                string soCNTN = row.Cells["SoCNTN"].Value?.ToString();
                                if (!string.IsNullOrEmpty(soCNTN) && soCNTN.Length == 7)
                                {
                                    nguoilx.SoGiayCNTN = soCNTN.Substring(0, 3) + "|" + soCNTN.Substring(3, 4);
                                }
                                else
                                {
                                    throw new Exception("Định dạng số CNTN không hợp lệ.");
                                }
                                nguoilx.VaoSoCNNSo = row.Cells["SoSoCCN"].Value?.ToString();
                                string soCCN = row.Cells["Column12"].Value?.ToString();
                                if (!string.IsNullOrEmpty(soCCN) && soCCN.Length == 7)
                                {
                                    nguoilx.SoCCN = soCCN.Substring(0, 3) + "|" + soCCN.Substring(3, 4);
                                }
                                else
                                {
                                    throw new Exception("Định dạng số CCN không hợp lệ.");
                                }

                                nguoilx.XepLoaiTotNghiep = row.Cells["Column13"].Value?.ToString();
                                nguoilx.NgayVaoSoTN = DateTime.TryParse(row.Cells["dateCNTN"].Value?.ToString(), out DateTime ngayVaoSoTN) ? ngayVaoSoTN : (DateTime?)null;
                                nguoilx.NgayRaQDTN = DateTime.TryParse(row.Cells["DateQD"].Value?.ToString(), out DateTime ngayQD) ? ngayQD : (DateTime?)null;
                                nguoilx.NgayVaoSoCNN = DateTime.TryParse(row.Cells["dateSoCCN"].Value?.ToString(), out DateTime ngayVaoSoCNN) ? ngayVaoSoCNN : (DateTime?)null;
                                nguoilx.NgayCapCCN = DateTime.TryParse(row.Cells["dateCapCCN"].Value?.ToString(), out DateTime ngayCapCNN) ? ngayCapCNN : (DateTime?)null;
                                nguoilx.NgayInGiayTN = DateTime.TryParse(row.Cells["date"].Value?.ToString(), out DateTime date) ? date : (DateTime?)null;
                                nguoilx.TT_XuLy = "16";
                            }

                            successCount++;
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
                    MessageBox.Show($"Dữ liệu đã được cập nhật thành công!\nSố bản ghi thành công: {successCount}\nSố bản ghi thất bại: {failureCount}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void ExportFailedRecordsToExcel(List<(string MaDK, string Message)> failedRecords)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            excelApp.Workbooks.Add();
            _Worksheet workSheet = excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "MaDK";
            workSheet.Cells[1, "B"] = "Message";

            for (int i = 0; i < failedRecords.Count; i++)
            {
                workSheet.Cells[i + 2, "A"] = failedRecords[i].MaDK;
                workSheet.Cells[i + 2, "B"] = failedRecords[i].Message;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = "FailedRecords.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workSheet.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Danh sách bản ghi thất bại đã được xuất ra file Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            excelApp.Quit();
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(excelApp);
        }
    }
    }
