
namespace QuanlyGPLX
{
    partial class frmInHinhAnh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnChonAnh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.CboYear = new System.Windows.Forms.ComboBox();
            this.dgvDanhSachKhoahoc = new System.Windows.Forms.DataGridView();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDanhSachAnh = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoVaTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuongDanAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
      
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel2)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhoahoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
          
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 15);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Năm học:";
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.Appearance.Options.UseFont = true;
            this.btnChonAnh.Location = new System.Drawing.Point(251, 10);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(74, 26);
            this.btnChonAnh.TabIndex = 7;
            this.btnChonAnh.Text = "Chọn ảnh";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(330, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 25);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "In ảnh";
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Grid = null;
            this.gridSplitContainer1.Location = new System.Drawing.Point(329, 33);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Size = new System.Drawing.Size(814, 683);
            this.gridSplitContainer1.TabIndex = 9;
            // 
            // CboYear
            // 
            this.CboYear.FormattingEnabled = true;
            this.CboYear.Location = new System.Drawing.Point(68, 10);
            this.CboYear.Name = "CboYear";
            this.CboYear.Size = new System.Drawing.Size(91, 21);
            this.CboYear.TabIndex = 10;
            // 
            // dgvDanhSachKhoahoc
            // 
            this.dgvDanhSachKhoahoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachKhoahoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH});
            this.dgvDanhSachKhoahoc.Location = new System.Drawing.Point(3, 37);
            this.dgvDanhSachKhoahoc.Name = "dgvDanhSachKhoahoc";
            this.dgvDanhSachKhoahoc.Size = new System.Drawing.Size(242, 596);
            this.dgvDanhSachKhoahoc.TabIndex = 11;
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "Mã Khoá học";
            this.MaKH.Name = "MaKH";
            // 
            // TenKH
            // 
            this.TenKH.HeaderText = "Tên Khoá học";
            this.TenKH.Name = "TenKH";
            // 
            // dgvDanhSachAnh
            // 
            this.dgvDanhSachAnh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachAnh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checkbox,
            this.STT,
            this.MaDK,
            this.Anh,
            this.HoVaTen,
            this.NgaySinh});
            this.dgvDanhSachAnh.Location = new System.Drawing.Point(251, 37);
            this.dgvDanhSachAnh.Name = "dgvDanhSachAnh";
            this.dgvDanhSachAnh.Size = new System.Drawing.Size(657, 596);
            this.dgvDanhSachAnh.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaAnh,
            this.HoTen,
            this.DuongDanAnh});
            this.dataGridView1.Location = new System.Drawing.Point(914, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(445, 596);
            this.dataGridView1.TabIndex = 13;
            // 
            // Checkbox
            // 
            this.Checkbox.HeaderText = "Check";
            this.Checkbox.Name = "Checkbox";
            this.Checkbox.Width = 50;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 30;
            // 
            // MaDK
            // 
            this.MaDK.HeaderText = "Mã đăng ký";
            this.MaDK.Name = "MaDK";
            this.MaDK.Width = 200;
            // 
            // Anh
            // 
            this.Anh.HeaderText = "Ảnh";
            this.Anh.Name = "Anh";
            // 
            // HoVaTen
            // 
            this.HoVaTen.HeaderText = "Họ và Tên";
            this.HoVaTen.Name = "HoVaTen";
            this.HoVaTen.Width = 150;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            // 
            // MaAnh
            // 
            this.MaAnh.HeaderText = "Mã ảnh";
            this.MaAnh.Name = "MaAnh";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ và Tên";
            this.HoTen.Name = "HoTen";
            // 
            // DuongDanAnh
            // 
            this.DuongDanAnh.HeaderText = "Đường dẫn ảnh";
            this.DuongDanAnh.Name = "DuongDanAnh";
            this.DuongDanAnh.Width = 250;
            // 
            // frmInHinhAnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 728);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvDanhSachAnh);
            this.Controls.Add(this.dgvDanhSachKhoahoc);
            this.Controls.Add(this.CboYear);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmInHinhAnh";
            this.Text = "In Hình ảnh";
           
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhoahoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnChonAnh;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private System.Windows.Forms.ComboBox CboYear;
      
        private System.Windows.Forms.DataGridView dgvDanhSachKhoahoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridView dgvDanhSachAnh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoVaTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuongDanAnh;
    }
}