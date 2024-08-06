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

namespace QuanlyGPLX
{
    public partial class frmInHinhAnh : DevExpress.XtraEditors.XtraForm
    {
        public frmInHinhAnh()
        {
            InitializeComponent();
            PopulateYearComboBox();
        }

        private void PopulateYearComboBox()
        {
            int startYear = 2000;
            int endYear = DateTime.Now.Year;

            // Thêm các năm vào ComboBox
            for (int year = startYear; year <= endYear; year++)
            {
                CboYear.Items.Add(year);
            }

            // Tùy chọn: Đặt giá trị mặc định cho ComboBox là năm hiện tại
            CboYear.SelectedItem = endYear;
        }
    }
}