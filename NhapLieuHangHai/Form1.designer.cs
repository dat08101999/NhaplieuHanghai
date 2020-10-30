namespace NhapLieuHangHai
{
    partial class Form1
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtMaHaiDo = new System.Windows.Forms.TextBox();
            this.cbbHaiDo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(621, 21);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(92, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Hải đồ ảnh hưởng";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button2.Location = new System.Drawing.Point(95, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "Chọn Tệp Nguồn";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(95, 79);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(655, 115);
            this.dataGridView1.TabIndex = 6;
            // 
            // txtMaHaiDo
            // 
            this.txtMaHaiDo.Location = new System.Drawing.Point(199, 20);
            this.txtMaHaiDo.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.txtMaHaiDo.Name = "txtMaHaiDo";
            this.txtMaHaiDo.Size = new System.Drawing.Size(188, 20);
            this.txtMaHaiDo.TabIndex = 24;
            // 
            // cbbHaiDo
            // 
            this.cbbHaiDo.FormattingEnabled = true;
            this.cbbHaiDo.Items.AddRange(new object[] {
            "Chọn hải đồ ảnh hưởng"});
            this.cbbHaiDo.Location = new System.Drawing.Point(392, 20);
            this.cbbHaiDo.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.cbbHaiDo.Name = "cbbHaiDo";
            this.cbbHaiDo.Size = new System.Drawing.Size(142, 21);
            this.cbbHaiDo.TabIndex = 25;
            this.cbbHaiDo.SelectedIndexChanged += new System.EventHandler(this.cbbHaiDo_SelectedIndexChanged);
            this.cbbHaiDo.TextChanged += new System.EventHandler(this.cbbHaiDo_TextChanged);
            this.cbbHaiDo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbHaiDo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label4.Location = new System.Drawing.Point(534, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày cập nhật: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(768, 250);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbbHaiDo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMaHaiDo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMaHaiDo;
        private System.Windows.Forms.ComboBox cbbHaiDo;
        private System.Windows.Forms.Label label4;
    }
}

