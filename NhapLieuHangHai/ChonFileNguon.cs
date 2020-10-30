using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace NhapLieuHangHai
{
    public partial class ChonFileNguon : Form
    {
        private Form1 mdiParent;
        public DataTable datatemp;
        public int count = 0;
        DataTable dataTable;
        int typeform;

        public ChonFileNguon()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }


        public ChonFileNguon(int typeform)
        {
            InitializeComponent();
            this.typeform = typeform;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string imagepath = "";
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    imagepath = open.FileName;
                }
                DataGridViewImageCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewImageCell;
                if (imagepath != "")
                    cell.Value = Image.FromFile(imagepath);
            }
        }
        void threadOpen()
        {
            Common.gettable(dataGridView1);
           
        }

        public void dataload()
        {
            


        }
        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Đang đọc.....");
            //if (!backgroundWorker1.IsBusy)
            //    backgroundWorker1.RunWorkerAsync();
            //else
            //    MessageBox.Show("Không đọc đươc file!");
            // backgroundWorker1.RunWorkerAsync();
            dataTable = Common.createTable(dataGridView1, this);
            Common.fillData(dataGridView1, dataTable);
            if (dataGridView1.Rows.Count > 0)
            {
                if (typeform == 1)
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].DisplayIndex = 1;
                    dataGridView1.Columns[3].DisplayIndex = 2;
                    dataGridView1.Columns[5].DisplayIndex = 3;
                }
                if (typeform == 2)
                {
                    dataGridView1.Columns[4].DisplayIndex = 0;
                    dataGridView1.Columns[3].DisplayIndex = 2;
                    dataGridView1.Columns[5].DisplayIndex = 1;
                    dataGridView1.Columns[0].DisplayIndex = 3;
                    dataGridView1.Columns[1].DisplayIndex = 4;
                    // dataGridView1.Columns[2].DisplayIndex = 6;
                }
                if (typeform == 3)
                {
                    dataGridView1.Columns[4].DisplayIndex = 0;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[0].DisplayIndex = 1;
                    dataGridView1.Columns[1].DisplayIndex = 2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Cbbcolum.Clear();
            Form1.imagelist.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Form1.Cbbcolum.Add(row.Cells[4].Value.ToString());
                Form1.imagelist.Add((Bitmap)row.Cells[5].Value);
            }
            Form1.data = (DataTable)dataGridView1.DataSource;
            this.Visible = false;
            ////f.dataGridView1.DataSource = ((DataRowView)dataGridView1.Rows[0].DataBoundItem).DataView.Table;
            ////f.setDataTable(((DataRowView)dataGridView1.Rows[0].DataBoundItem).DataView.Table);
            //f.dataGridView1 = dataGridView1;
            //f.dataGridView1.Update();
            //f.dataGridView1.Refresh();
        }

        private void ChonFileNguon_Load(object sender, EventArgs e)
        {
            Cbbaction.SelectedIndex = 0;
            count++;
            Cbbaction.SelectedIndexChanged += Cbbaction_SelectedIndexChanged;
            this.WindowState = FormWindowState.Normal;
        }

       

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                button1.Enabled = true;
            }
        }

        private void Cbbaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //count++;
            //MessageBox.Show(count.ToString()+" " + Cbbaction.SelectedIndex.ToString());
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["action"]);
               // cell.DataSource = new string[] { "Sửa", "Chèn", "Xóa" };
                cell.Value = Cbbaction.SelectedItem.ToString();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dataTable = Common.createTable(dataGridView1, this);
            // System.Threading.Thread.Sleep(500);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Common.fillData(dataGridView1, dataTable);
            if (dataGridView1.Rows.Count > 0)
            {
                if (typeform == 1)
                {
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[4].DisplayIndex = 1;
                    dataGridView1.Columns[3].DisplayIndex = 2;
                    dataGridView1.Columns[5].DisplayIndex = 3;
                }
                if (typeform == 2)
                {
                    dataGridView1.Columns[4].DisplayIndex = 0;
                    dataGridView1.Columns[3].DisplayIndex = 2;
                    dataGridView1.Columns[5].DisplayIndex = 1;
                    dataGridView1.Columns[0].DisplayIndex = 3;
                    dataGridView1.Columns[1].DisplayIndex = 4;
                    // dataGridView1.Columns[2].DisplayIndex = 6;
                }
                if (typeform == 3)
                {
                    dataGridView1.Columns[4].DisplayIndex = 0;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[0].DisplayIndex = 1;
                    dataGridView1.Columns[1].DisplayIndex = 2;
                }
            }
            /*MessageBox.Show(
                   "Đã Đọc xong!",
                   "Thông Báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.ServiceNotification);*/
        }
    }
}
