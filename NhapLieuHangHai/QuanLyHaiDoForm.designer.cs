namespace NhapLieuHangHai
{
    partial class QuanLyHaiDoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cbTenHaiDo = new System.Windows.Forms.ComboBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this._tbMaHaiDo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstHaiDo = new System.Windows.Forms.DataGridView();
            this.cbbHaiDoeng = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHaiDo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbHaiDoeng);
            this.groupBox1.Controls.Add(this._cbTenHaiDo);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this._tbMaHaiDo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _cbTenHaiDo
            // 
            this._cbTenHaiDo.FormattingEnabled = true;
            this._cbTenHaiDo.Location = new System.Drawing.Point(158, 48);
            this._cbTenHaiDo.Name = "_cbTenHaiDo";
            this._cbTenHaiDo.Size = new System.Drawing.Size(173, 28);
            this._cbTenHaiDo.TabIndex = 7;
            this._cbTenHaiDo.SelectedIndexChanged += new System.EventHandler(this._cbTenHaiDo_SelectedIndexChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(237, 195);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 34);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(129, 195);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 34);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(29, 195);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 34);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // _tbMaHaiDo
            // 
            this._tbMaHaiDo.Location = new System.Drawing.Point(158, 131);
            this._tbMaHaiDo.Name = "_tbMaHaiDo";
            this._tbMaHaiDo.Size = new System.Drawing.Size(173, 26);
            this._tbMaHaiDo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Hải Đồ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Hải Đồ:";
            // 
            // lstHaiDo
            // 
            this.lstHaiDo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstHaiDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstHaiDo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstHaiDo.Location = new System.Drawing.Point(616, 0);
            this.lstHaiDo.Name = "lstHaiDo";
            this.lstHaiDo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.lstHaiDo.RowTemplate.Height = 28;
            this.lstHaiDo.Size = new System.Drawing.Size(602, 450);
            this.lstHaiDo.TabIndex = 1;
            this.lstHaiDo.SelectionChanged += new System.EventHandler(this.lstHaiDo_SelectionChanged);
            // 
            // cbbHaiDoeng
            // 
            this.cbbHaiDoeng.FormattingEnabled = true;
            this.cbbHaiDoeng.Location = new System.Drawing.Point(158, 90);
            this.cbbHaiDoeng.Name = "cbbHaiDoeng";
            this.cbbHaiDoeng.Size = new System.Drawing.Size(173, 28);
            this.cbbHaiDoeng.TabIndex = 7;
            this.cbbHaiDoeng.SelectedIndexChanged += new System.EventHandler(this.cbbHaiDoeng_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên TIếng Anh:";
            // 
            // QuanLyHaiDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1218, 450);
            this.Controls.Add(this.lstHaiDo);
            this.Controls.Add(this.groupBox1);
            this.Name = "QuanLyHaiDoForm";
            this.Text = "Quản Lý Hải Đồ Ảnh Hưởng";
            this.Load += new System.EventHandler(this.QuanLyHaiDoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstHaiDo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox _tbMaHaiDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView lstHaiDo;
        private System.Windows.Forms.ComboBox _cbTenHaiDo;
        private System.Windows.Forms.ComboBox cbbHaiDoeng;
        private System.Windows.Forms.Label label3;
    }
}