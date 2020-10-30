namespace NhapLieuHangHai
{
    partial class QuanLyChung
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
            this.lbQuanLy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtE = new System.Windows.Forms.Label();
            this.txtTV = new System.Windows.Forms.TextBox();
            this.txtEng = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstHienThi = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // lbQuanLy
            // 
            this.lbQuanLy.AutoSize = true;
            this.lbQuanLy.Location = new System.Drawing.Point(373, 9);
            this.lbQuanLy.Name = "lbQuanLy";
            this.lbQuanLy.Size = new System.Drawing.Size(64, 20);
            this.lbQuanLy.TabIndex = 0;
            this.lbQuanLy.Text = "QuanLy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Tiếng Việt";
            // 
            // txtE
            // 
            this.txtE.AutoSize = true;
            this.txtE.Location = new System.Drawing.Point(22, 68);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(112, 20);
            this.txtE.TabIndex = 2;
            this.txtE.Text = "Tên Tiếng Anh";
            // 
            // txtTV
            // 
            this.txtTV.Location = new System.Drawing.Point(135, 25);
            this.txtTV.Name = "txtTV";
            this.txtTV.Size = new System.Drawing.Size(237, 26);
            this.txtTV.TabIndex = 3;
            // 
            // txtEng
            // 
            this.txtEng.Location = new System.Drawing.Point(135, 68);
            this.txtEng.Name = "txtEng";
            this.txtEng.Size = new System.Drawing.Size(237, 26);
            this.txtEng.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTV);
            this.groupBox1.Controls.Add(this.txtE);
            this.groupBox1.Controls.Add(this.txtEng);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(73, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 113);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(73, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(264, 26);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 47);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(151, 24);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 49);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(38, 25);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 48);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstHienThi);
            this.groupBox3.Location = new System.Drawing.Point(499, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 231);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // lstHienThi
            // 
            this.lstHienThi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstHienThi.Location = new System.Drawing.Point(0, 17);
            this.lstHienThi.Name = "lstHienThi";
            this.lstHienThi.RowHeadersWidth = 62;
            this.lstHienThi.RowTemplate.Height = 28;
            this.lstHienThi.Size = new System.Drawing.Size(496, 193);
            this.lstHienThi.TabIndex = 0;
            this.lstHienThi.SelectionChanged += new System.EventHandler(this.lstHienThi_SelectionChanged);
            // 
            // QuanLyChung
            // 
            this.ClientSize = new System.Drawing.Size(1007, 350);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbQuanLy);
            this.Name = "QuanLyChung";
            this.Load += new System.EventHandler(this.QuanLyChung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label lbQuanLy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtE;
        private System.Windows.Forms.TextBox txtTV;
        private System.Windows.Forms.TextBox txtEng;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView lstHienThi;
    }
}