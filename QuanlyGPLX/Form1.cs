using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace QuanlyGPLX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Hiển thị OpenFileDialog để người dùng chọn tệp báo cáo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Report Files (*.repx)|*.repx|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp báo cáo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    OpenReportDesigner(selectedFilePath);
                }
            }
        }

        private void OpenReportDesigner(string reportPath)
        {
            // Tạo một instance của report từ file
            XtraReport report = new XtraReport();
            if (File.Exists(reportPath))
            {
                report.LoadLayout(reportPath);
            }
            else
            {
                // Nếu file không tồn tại, tạo report mới
                report = new rptChungChi();
            }

          

            // Tạo một instance của XRDesignFormEx
            XRDesignFormEx designForm = new XRDesignFormEx();

            // Gán report vào thiết kế form
            designForm.OpenReport(report);

            // Đăng ký sự kiện khi đóng thiết kế form
            designForm.FormClosing += (s, e) => DesignForm_FormClosing(s, e, reportPath);

            // Hiển thị thiết kế form
            designForm.ShowDialog();
        }

        private void SetReportParameters(XtraReport report)
        {
            // Thiết lập giá trị cho các tham số của report
            report.Parameters["p_hanglx_en"].Value = "Category 1";
            report.Parameters["p1"].Value = "Value 1";
            report.Parameters["p2"].Value = "Value 2";
            report.Parameters["p3"].Value = "Value 3";
            report.Parameters["p4"].Value = "Value 4";
            report.Parameters["p5"].Value = "Value 5";
            report.Parameters["p6"].Value = "Value 6";
            report.Parameters["ngay_ta"].Value = DateTime.Now.ToString("dd-MM-yyyy");
            // Thêm các tham số khác tương tự...
        }

        private void DesignForm_FormClosing(object sender, FormClosingEventArgs e, string reportPath)
        {
            // Lấy thiết kế form hiện tại
            XRDesignFormEx designForm = (XRDesignFormEx)sender;

            // Kiểm tra xem người dùng có lưu các thay đổi không
            if (designForm.DesignPanel.ReportState == ReportState.Changed)
            {
                // Lưu report vào tệp
                designForm.DesignPanel.Report.SaveLayoutToXml(reportPath);

                // Hiển thị thông báo xác nhận
                MessageBox.Show("Report đã được cập nhật và lưu thành công!");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Hiển thị OpenFileDialog để người dùng chọn tệp báo cáo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Report Files (*.repx)|*.repx|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp báo cáo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    ShowReportPreview(selectedFilePath);
                }
            }
        }

        private void ShowReportPreview(string reportPath)
        {
            // Tạo một instance của report từ file
            XtraReport report = new XtraReport();
            if (File.Exists(reportPath))
            {
                report.LoadLayout(reportPath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file report.");
                return;
            }

            // Truyền dữ liệu vào report
            SetReportParameters(report);

            // Hiển thị report trong ReportPrintTool
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Hiển thị OpenFileDialog để người dùng chọn tệp báo cáo
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Report Files (*.repx)|*.repx|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn tệp báo cáo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

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

                    // Truyền dữ liệu vào report
                    SetReportParameters(report);

                    // Xuất report
                    ShowReportPreview(report);
                }
            }
        }
        private void ExportReport(XtraReport report)
        {
            // Hiển thị SaveFileDialog để người dùng chọn nơi lưu tệp PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                saveFileDialog.Title = "Lưu tệp báo cáo";
                saveFileDialog.FileName = "Report.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveFileDialog.FileName;

                    // Xuất report ra tệp PDF
                    report.ExportToPdf(exportFilePath);

                    // Hiển thị thông báo xác nhận
                    MessageBox.Show("Report đã được xuất thành công!");
                }
            }
        }
        private void ShowReportPreview(XtraReport report)
        {
            // Hiển thị report trong ReportPrintTool
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}