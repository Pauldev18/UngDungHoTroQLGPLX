
namespace QuanlyGPLX
{
    partial class frmBaoCao2
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblMaBaoCao2 = new DevExpress.XtraEditors.LabelControl();
            this.btnImportDataBC2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddInBC2 = new DevExpress.XtraEditors.SimpleButton();
            this.data_baocao2 = new System.Windows.Forms.DataGridView();
            this.data_dangKy = new System.Windows.Forms.DataGridView();
            this.txt_tongbanghi = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_baocao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_dangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(76, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh sách mã báo cáo 2";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(579, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(117, 15);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mã báo cáo 2 đã chọn:";
            // 
            // lblMaBaoCao2
            // 
            this.lblMaBaoCao2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBaoCao2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMaBaoCao2.Appearance.Options.UseFont = true;
            this.lblMaBaoCao2.Appearance.Options.UseForeColor = true;
            this.lblMaBaoCao2.Location = new System.Drawing.Point(702, 26);
            this.lblMaBaoCao2.Name = "lblMaBaoCao2";
            this.lblMaBaoCao2.Size = new System.Drawing.Size(46, 19);
            this.lblMaBaoCao2.TabIndex = 0;
            this.lblMaBaoCao2.Text = "MBC2";
            // 
            // btnImportDataBC2
            // 
            this.btnImportDataBC2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDataBC2.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.btnImportDataBC2.Appearance.Options.UseFont = true;
            this.btnImportDataBC2.Appearance.Options.UseForeColor = true;
            this.btnImportDataBC2.Location = new System.Drawing.Point(115, 654);
            this.btnImportDataBC2.Name = "btnImportDataBC2";
            this.btnImportDataBC2.Size = new System.Drawing.Size(104, 23);
            this.btnImportDataBC2.TabIndex = 2;
            this.btnImportDataBC2.Text = "Import Data...";
            this.btnImportDataBC2.Click += new System.EventHandler(this.btnImportDataBC2_Click);
            // 
            // btnAddInBC2
            // 
            this.btnAddInBC2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInBC2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnAddInBC2.Appearance.Options.UseFont = true;
            this.btnAddInBC2.Appearance.Options.UseForeColor = true;
            this.btnAddInBC2.Location = new System.Drawing.Point(225, 654);
            this.btnAddInBC2.Name = "btnAddInBC2";
            this.btnAddInBC2.Size = new System.Drawing.Size(115, 23);
            this.btnAddInBC2.TabIndex = 2;
            this.btnAddInBC2.Text = "Thêm vào BC2";
            this.btnAddInBC2.Click += new System.EventHandler(this.btnAddInBC2_Click);
            // 
            // data_baocao2
            // 
            this.data_baocao2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_baocao2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_baocao2.Location = new System.Drawing.Point(76, 61);
            this.data_baocao2.Name = "data_baocao2";
            this.data_baocao2.Size = new System.Drawing.Size(439, 577);
            this.data_baocao2.TabIndex = 3;
            this.data_baocao2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_baocao2_CellClick);
            this.data_baocao2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_baocao2_CellDoubleClick);
            // 
            // data_dangKy
            // 
            this.data_dangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_dangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_dangKy.Location = new System.Drawing.Point(577, 61);
            this.data_dangKy.Name = "data_dangKy";
            this.data_dangKy.Size = new System.Drawing.Size(846, 577);
            this.data_dangKy.TabIndex = 4;
            // 
            // txt_tongbanghi
            // 
            this.txt_tongbanghi.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tongbanghi.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_tongbanghi.Appearance.Options.UseFont = true;
            this.txt_tongbanghi.Appearance.Options.UseForeColor = true;
            this.txt_tongbanghi.Location = new System.Drawing.Point(987, 28);
            this.txt_tongbanghi.Name = "txt_tongbanghi";
            this.txt_tongbanghi.Size = new System.Drawing.Size(8, 19);
            this.txt_tongbanghi.TabIndex = 5;
            this.txt_tongbanghi.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(891, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 15);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Tổng số bản ghi:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(1308, 654);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(115, 23);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Xóa học sinh";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(594, 654);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(690, 23);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmBaoCao2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 858);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txt_tongbanghi);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.data_dangKy);
            this.Controls.Add(this.data_baocao2);
            this.Controls.Add(this.btnAddInBC2);
            this.Controls.Add(this.btnImportDataBC2);
            this.Controls.Add(this.lblMaBaoCao2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmBaoCao2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo 2";
            this.Load += new System.EventHandler(this.frmBaoCao2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_baocao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_dangKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblMaBaoCao2;
        private DevExpress.XtraEditors.SimpleButton btnImportDataBC2;
        private DevExpress.XtraEditors.SimpleButton btnAddInBC2;
        private System.Windows.Forms.DataGridView data_baocao2;
        private System.Windows.Forms.DataGridView data_dangKy;
        private DevExpress.XtraEditors.LabelControl txt_tongbanghi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}