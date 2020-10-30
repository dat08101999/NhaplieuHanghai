using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhapLieuHangHai
{
    public partial class MenuScreen : Form
    {
        String root = System.Windows.Forms.Application.StartupPath;
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void nhậpPhiếuSố1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 mf = new Form1();
            mf.Show();
            //hide this form
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNhapLieu mf = new FormNhapLieu(1);
            mf.Show();
            //hide this form
            //this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyHaiDoForm qlhd = new QuanLyHaiDoForm();
            qlhd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuanLyDoiTuong qldt = new QuanLyDoiTuong();
            qldt.Show();
        }

        private void btnQuanLyVungBien_Click(object sender, EventArgs e)
        {
            QuanLyChung quanLyChung = new QuanLyChung(btnQuanLyVungBien.Text, root +"\\"+ btnQuanLyVungBien.Text +".txt") ;
            quanLyChung.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyChung quanLyChung = new QuanLyChung(btnQuanlytinhthanh.Text, root + "\\" + btnQuanlytinhthanh.Text + ".txt");
            quanLyChung.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormNhapLieu mf = new FormNhapLieu(2);
            mf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormNhapLieu mf = new FormNhapLieu(3);
            mf.Show();
        }
        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
        private void MenuScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
