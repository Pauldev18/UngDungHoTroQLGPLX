using DevExpress.XtraBars;
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
    public partial class frmQuanlyGPLX : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmQuanlyGPLX()
        {
            InitializeComponent();
        }
        void OpenForm(Type typeForm)
        {
            foreach(Form frm in MdiChildren)
            {
                if(frm.GetType()==typeForm)
                {
                    frm.Activate();
                    return;
                }    
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        void frmQuanlyGPLX_Load(object sender, EventArgs e)
        {

        }
        private void btnBaocao2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBaoCao2));
        }

        private void btnCapnhatthongtinTN_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmCapnhatthongtintotnghiep));
        }

        private void btnInChungChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmInChungChi));
        }

        private void btnChuyenKhoaHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmChuyenKhoaHoc));
        }
        private void btnInHinhAnh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmInHinhAnh));
        }

        private void btnSoQLHS_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmSoQuanlyHSSV));
        }

        private void btnTheHocVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmInTheHocVien));
        }

        private void btbPhieuTheoDoiLX_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPhieuThoiDoiLX));
        }
    }
}