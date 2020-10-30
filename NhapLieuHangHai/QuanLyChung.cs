using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace NhapLieuHangHai
{
    public partial class QuanLyChung : Form
    {
        DataTable table = new DataTable();
        String kieu, duongDan;
        
        public QuanLyChung(String tenForm,String path)
        {
            InitializeComponent();
            kieu = tenForm;    
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            duongDan = path;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thêm Dữ Liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (!checktenTrung(1))
                {
                    table.Rows.Add(txtTV.Text, txtEng.Text);
                    lstHienThi.DataSource = table;
                    Common.ToCSV(table, duongDan);
                    //bindingDataCombobox();
                    MessageBox.Show("Thêm Thành Công");
                    cleartxt();
                }
                else
                {
                    MessageBox.Show("Tên Trùng");
                }
        }

        bool checktenTrung(int type)
        {
            bool check = false;
            string strTheFile = File.ReadAllText(duongDan);
            //MessageBox.Show(strTheFile);
            if (type == 1)
            {
                for (int i = 0; i < lstHienThi.Rows.Count - 1; i++)
                {
                    if ((txtTV.Text == lstHienThi.Rows[i].Cells[0].Value.ToString()) ||(txtEng.Text == lstHienThi.Rows[i].Cells[1].Value.ToString()))
                    {
                        check = true;
                    }
                }
            }
            
            if (txtTV.Text =="" && txtEng.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ nội dung !");
                check = true;
            }
           return check;
        }

        private void QuanLyChung_Load(object sender, EventArgs e)
        {
            lbQuanLy.Text = kieu;
            loadData();
            if (lstHienThi.Rows.Count > 0)
                table = (DataTable)lstHienThi.DataSource;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc chắn muốn sửa không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (!checktenTrung(0)&&lstHienThi.SelectedRows.Count > 0)
                {
                    table.Rows[lstHienThi.SelectedRows[0].Index][0] = txtTV.Text;
                    table.Rows[lstHienThi.SelectedRows[0].Index][1] = txtEng.Text;
                    DataTable tempnew = table;
                    Common.ToCSV(tempnew, duongDan);
                    MessageBox.Show("Sửa thành công");
                    cleartxt();
                }
                else
                    MessageBox.Show("Chưa Chọn Bản Ghi Nào");
            }
        }
        void cleartxt()
        {
            txtTV.Clear();
            txtEng.Clear();
        }
        private void lstHienThi_SelectionChanged(object sender, EventArgs e)
        {
            if (lstHienThi.SelectedRows.Count > 0)
            {
                txtTV.Text = lstHienThi.SelectedRows[0].Cells[0].Value.ToString();
                txtEng.Text = lstHienThi.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc chắn muốn xóa không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lstHienThi.SelectedRows.Count > 0)
                {
                    table.Rows.RemoveAt(lstHienThi.SelectedRows[0].Index);
                    DataTable tempnew = table;
                    Common.ToCSV(tempnew, duongDan);
                    MessageBox.Show("Xóa thành công");
                    cleartxt();
                }
                else
                    MessageBox.Show("Chưa Chọn Bản Ghi Nào");
            }
        }

        public void loadData()
        {
            if (File.Exists(duongDan))
            {
                Common.BindData(duongDan, lstHienThi);
              //  MessageBox.Show(lstHienThi.Columns.Count.ToString());
                lstHienThi.Columns[0].HeaderText = "Tên Tiếng Việt";
                lstHienThi.Columns[1].HeaderText = "Tên Tiếng Anh";
            }
            table.Columns.Add("Tên Tiếng Việt", typeof(string));
            table.Columns.Add("Tên Tiếng Anh", typeof(string));
        }
    }
}
