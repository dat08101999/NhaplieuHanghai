using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace NhapLieuHangHai
{
    public partial class FormNhapLieu : Form
    {

        public static System.Data.DataTable data;
        public static string soPhieu ="";
        List<Form1> listform = new List<Form1>();
        public static Microsoft.Office.Interop.Word.Application wordApp=new Microsoft.Office.Interop.Word.Application();
        public static Microsoft.Office.Interop.Word.Document myWordDoc=new Microsoft.Office.Interop.Word.Document();
        public int typeform;
        string filepath;

        public FormNhapLieu(int typeform)
        {
            InitializeComponent();
            // data = dataTable;
            this.typeform = typeform;
        }
        public FormNhapLieu()
        {
            InitializeComponent();
            //data = dataTable;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public void openAgainWOrd()
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object missing = Missing.Value;
            Microsoft.Office.Interop.Word.Document myWordDoc = null;
            object filepath = this.filepath;
            if (File.Exists((string)filepath))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;
                myWordDoc = wordApp.Documents.Open(ref filepath, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                FormNhapLieu.wordApp = wordApp;
                FormNhapLieu.myWordDoc = myWordDoc;
            }
        }
        public  void closeWord()
        {
            FormNhapLieu.myWordDoc.Close();
            FormNhapLieu.wordApp.Quit();
        }
        private void FormNhapLieu_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.WrapContents = false;
            Common.CenterHorizontally(groupBox1);
            Common.CenterHorizontally(flowLayoutPanel1);
            for (int i = 2000; i <= 2020; i++)
            {
                cb_nam.Items.Add(i);
            
            }
            cbbAdd(cbLuong,"luong.txt");
            cbbAdd(cb_loaivung, "Quản Lý Vùng Nước Cảng Biển.txt");
            cbbAdd(cbTinhThanh, "Quản Lý Tỉnh Thành.txt");
        }
        void cbbAdd(ComboBox cbb,string filename)
        {
            cb_nam.SelectedIndex = 0;
            //cbTinhThanh.SelectedIndex = 0;
            // cb_loaivung.SelectedIndex = 0;
            System.Data.DataTable dataLuongHd = Common.getData(System.Windows.Forms.Application.StartupPath + "\\"+ filename);
            //MessageBox.Show(dataLuongHd.Rows.Count.ToString());
            string inline = "";
            for (int i = 0; i < dataLuongHd.Rows.Count; i++)
            {
                if (filename == "luong.txt")
                {
                    if (!inline.Contains(dataLuongHd.Rows[i][0].ToString()))
                    {
                        cbb.Items.Add(dataLuongHd.Rows[i][0]);
                        cbbluongEng.Items.Add(dataLuongHd.Rows[i][1]);
                        inline += dataLuongHd.Rows[i][0].ToString();
                    }
                }
                if (filename == "Quản Lý Vùng Nước Cảng Biển.txt")
                {   
                    cbb.Items.Add(dataLuongHd.Rows[i][0].ToString());
                    cbbLoaiVungEng.Items.Add(dataLuongHd.Rows[i][1].ToString());
                }
                if (filename == "Quản Lý Tỉnh Thành.txt")
                {
                    cbb.Items.Add(dataLuongHd.Rows[i][0].ToString());
                    cbbTinhThanhEng.Items.Add(dataLuongHd.Rows[i][1].ToString());
                }
            }
            if(cbb.Items.Count>0)
            cbb.SelectedIndex = 0;
        }
        int i = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            Button buttonadd = new Button();
            buttonadd = btn_them;
            Panel panel = new Panel();
            panel.Size = new Size(1500, 205);
            Form1 myForm = new Form1() { Dock = DockStyle.Fill };
            myForm.typeform = this.typeform;
            myForm.TopLevel = false;
            myForm.AutoScroll = false;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Show();
           
            listform.Add(myForm);
            //listform.Add(listform[i]);
            //myForm.
            //panel.Parent.ControlAdded = myForm;
            panel.Controls.Add(listform[i]);
            myForm.Show();
            flowLayoutPanel1.Controls.Add(panel);
            flowLayoutPanel1.Controls.Add(panel1);
           // flowLayoutPanel1.Controls.Add(btnSave);
            Panel pane2 = new Panel();
            pane2.Size = new Size(1500, 30);
        //    this.Controls.Add(pane2);
            // pane2.Visible = false;
            flowLayoutPanel1.Controls.Add(pane2);
            i++;
        }
        void threadsave()
        {
            int counttable = 0;
                if (listform.Count > 0)
                {
                
                if (listform[0].dataGridView1.Rows.Count > 0)
                {
                    openAgainWOrd();
                    btnSave.Enabled = false;
                    btn_them.Enabled = false;
                    lbSavethread.Text = "Đang Lưu.......";
                    flowLayoutPanel1.Enabled = false;
                    listform[0].sophieu = txtSoPhieu.Text;
                    listform[0].nam = cb_nam.Text;
                    listform[0].thongbaoso = txtThongBaoSo.Text;
                    listform[0].luong = (cbLuong.Text+'/'+cbbluongEng.Text).Replace("\n", String.Empty).Replace("\r", String.Empty);
                    listform[0].provilcial = (cbTinhThanh.Text+'/'+cbbTinhThanhEng.Text).Replace("\n", String.Empty).Replace("\r", String.Empty);
                    listform[0].Dosau = txtDosau.Text.Replace("\n", String.Empty).Replace("\r", String.Empty);
                    listform[0].sophieu = txtSoPhieu.Text;
                    listform[0].TypePhieu = (cb_loaivung.Text+'/'+cbbLoaiVungEng.Text).Replace("\n", String.Empty).Replace("\r", String.Empty);
                    listform[0].click_tosave();
                    filepath = listform[0].filepath.ToString();
                   // myWordDoc = listform[0].myWordDoc;
                    //wordApp = listform[0].wordApp;
                    listform[0].closeWord();
                    counttable = listform[0].count;
                    for (int i = 1; i < listform.Count; i++)
                    {
                        if (listform[i].dataGridView1.Rows.Count > 0)
                        {
                            listform[i].Dosau = txtDosau.Text.Replace("\n", String.Empty).Replace("\r", String.Empty);
                            listform[i].count = listform[i - 1].count;
                            listform[i].filepath = filepath;
                          //  listform[i].openAgainWOrd();
                            listform[i].click_tosave();
                            //listform[i].closeWord();
                            counttable = listform[i].count;
                        }
                    }
                   //counttable++;
                    for (int i = 0; i < listform.Count; i++)
                    {
                        if (listform[i].dataGridView1.Rows.Count > 0)
                        {//MessageBox.Show(counttable.ToString());
                            listform[i].Dosau = txtDosau.Text.Replace("\n", String.Empty).Replace("\r", String.Empty);
                            listform[i].count =counttable;
                            listform[i].filepath = filepath;
                          //  listform[i].openAgainWOrd();
                            listform[i].appendEngligh(i);
                           // listform[i].closeWord();
                            counttable = listform[i].count;
                        }
                    }
                    lbSavethread.Text = "";
                    btn_them.Enabled = true;
                    btnSave.Enabled = true;
                    listform.Clear();
                    i = 0;
                    foreach (Control frm in flowLayoutPanel1.Controls)
                    {
                        if (frm.GetType() == typeof(Panel))
                            flowLayoutPanel1.Controls.Remove(frm);
                    }
                    closeWord();
                    var officeApp = new Microsoft.Office.Interop.Word.Application();
                    Document documentTest = officeApp.Documents.Open(filepath);
                    officeApp.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                    "Chưa Đủ Thông Tin",
                    "Thông Báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.ServiceNotification);
                }
                }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           //Thread.CurrentThread();
            ThreadStart str = new ThreadStart(threadsave);
            Thread thread = new Thread(str);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            //threadsave();   
        }
        private void FormNhapLieu_MinimumSizeChanged(object sender, EventArgs e)
        { 
            Common.CenterHorizontally(groupBox1);
            Common.CenterHorizontally(flowLayoutPanel1);
        }

        private void FormNhapLieu_SizeChanged(object sender, EventArgs e)
        {
            Common.CenterHorizontally(groupBox1);
            Common.CenterHorizontally(flowLayoutPanel1);
        }

        private void cb_loaivung_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbLoaiVungEng.SelectedIndex = cb_loaivung.SelectedIndex;
            //MessageBox.Show(cb_loaivung.Text + '/' + cbbLoaiVungEng.Text);
        }

        private void cbTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTinhThanhEng.SelectedIndex = cbTinhThanh.SelectedIndex;
        }

        private void cbLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbluongEng.SelectedIndex = cbLuong.SelectedIndex;
            //MessageBox.Show((cbLuong.Text + '/' + cbbluongEng.Text).Replace("\n", String.Empty).Replace("\r", String.Empty));
        }

        private void FormNhapLieu_FormClosed(object sender, FormClosedEventArgs e)
        {
          //Thread.CurrentThread.Abort();
        }
    }
}
