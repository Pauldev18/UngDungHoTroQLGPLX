
namespace QuanlyGPLX
{
    partial class frmChuyenKhoaHoc
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sothutu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hovaten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HangGPLX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HangDaoTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhanHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thaotac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(177, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Dữ liệu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(663, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng học viên:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(380, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(276, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn khoá học:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sothutu,
            this.MaDK,
            this.SoHoSo,
            this.Hovaten,
            this.Ngaysinh,
            this.HangGPLX,
            this.HangDaoTao,
            this.NgayNhanHoSo,
            this.Thaotac});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(942, 480);
            this.dataGridView1.TabIndex = 3;
            // 
            // Sothutu
            // 
            this.Sothutu.HeaderText = "STT";
            this.Sothutu.Name = "Sothutu";
            this.Sothutu.Width = 30;
            // 
            // MaDK
            // 
            this.MaDK.HeaderText = "Mã Đăng ký";
            this.MaDK.Name = "MaDK";
            this.MaDK.Width = 180;
            // 
            // SoHoSo
            // 
            this.SoHoSo.HeaderText = "Số Hồ sơ";
            this.SoHoSo.Name = "SoHoSo";
            this.SoHoSo.Width = 80;
            // 
            // Hovaten
            // 
            this.Hovaten.HeaderText = "Họ và tên";
            this.Hovaten.Name = "Hovaten";
            this.Hovaten.Width = 130;
            // 
            // Ngaysinh
            // 
            this.Ngaysinh.HeaderText = "Ngày sinh";
            this.Ngaysinh.Name = "Ngaysinh";
            // 
            // HangGPLX
            // 
            this.HangGPLX.HeaderText = "Hạng GPLX";
            this.HangGPLX.Name = "HangGPLX";
            // 
            // HangDaoTao
            // 
            this.HangDaoTao.HeaderText = "Hạng Đào tạo";
            this.HangDaoTao.Name = "HangDaoTao";
            // 
            // NgayNhanHoSo
            // 
            this.NgayNhanHoSo.HeaderText = "Ngày Nhận HS";
            this.NgayNhanHoSo.Name = "NgayNhanHoSo";
            // 
            // Thaotac
            // 
            this.Thaotac.HeaderText = "Thao tác";
            this.Thaotac.Name = "Thaotac";
            this.Thaotac.Width = 80;
            // 
            // frmChuyenKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmChuyenKhoaHoc";
            this.Text = "Chuyển khoá học";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sothutu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hovaten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HangGPLX;
        private System.Windows.Forms.DataGridViewTextBoxColumn HangDaoTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhanHoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thaotac;
    }
}