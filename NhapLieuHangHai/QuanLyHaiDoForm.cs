using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace NhapLieuHangHai
{
    public partial class QuanLyHaiDoForm : Form
    {
        DataTable table = new DataTable();
        String path = System.Windows.Forms.Application.StartupPath + "\\luong.txt";
        public QuanLyHaiDoForm()
        {
            InitializeComponent();
        }
        private void QuanLyHaiDoForm_Load(object sender, EventArgs e)
        {
            loadData();
            if (lstHaiDo.Rows.Count > 0)
                table = (DataTable)lstHaiDo.DataSource;
            lstHaiDo.Columns[0].HeaderText = "Tên Hải Đồ";
            lstHaiDo.Columns[1].HeaderText = "Tên Tiếng Anh";
            lstHaiDo.Columns[2].HeaderText = "Mã Hải Đồ";
        }
        bool checkavaiablecbb(int index)
        {
            bool check = false;

            foreach (string item in _cbTenHaiDo.Items)
            {
                if (lstHaiDo.Rows[index].Cells[0].Value.ToString() == item)
                    check = true;
            }
            return check;
        }
        bool checkMaTrung()
        {
            bool check = false;
            for (int i = 0; i < lstHaiDo.Rows.Count - 1; i++)
            {
                if (_tbMaHaiDo.Text == lstHaiDo.Rows[i].Cells[2].Value.ToString())
                {
                    check = true;
                }
            }
            return check;
        }
        private void bindingDataCombobox()
        {
            DataTable tb= Common.getData(System.Windows.Forms.Application.StartupPath + "\\Quản Lý Luồng Hàng Hải.txt");
            tb.Columns[1].ColumnName = "Tên Tiếng Anh";
            _cbTenHaiDo.DataSource =tb;
            cbbHaiDoeng.DataSource = tb;
          //  _cbTenHaiDo.Items.Add(lstHaiDo.Rows[i].Cells[0].Value.ToString());
            //cbbHaiDoeng.Items.Add(lstHaiDo.Rows[i].Cells[1].Value.ToString());
            _cbTenHaiDo.DisplayMember = "Tên Tiếng Việt";
            cbbHaiDoeng.DisplayMember = "Tên Tiếng Anh";
            //_cbTenHaiDo.SelectedIndex = 0;
              //     cbbHaiDoeng.SelectedIndex = 0;
         
        }
        void cleartext()
        {
            cbbHaiDoeng.Text="";
            _cbTenHaiDo.Text="";
            _tbMaHaiDo.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thêm Luồng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (!checkMaTrung())
                {
                    table.Rows.Add(_cbTenHaiDo.Text,cbbHaiDoeng.Text, _tbMaHaiDo.Text);
                    lstHaiDo.DataSource = table;
                    Common.ToCSV(table, path);
                    bindingDataCombobox();
                    cleartext();
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Mã Trùng");
                }
        }
        public void loadData()
        {
            Common.BindData(path, lstHaiDo);
            bindingDataCombobox();
            table.Columns.Add("Tên Hải Đồ", typeof(string));
            table.Columns.Add("Tên Tiếng Anh", typeof(string));
            table.Columns.Add("Mã Hải Đồ", typeof(string));
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc chắn muốn sửa không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lstHaiDo.SelectedRows.Count > 0)
                {
                    table.Rows[lstHaiDo.SelectedRows[0].Index][0] = _cbTenHaiDo.Text;
                    table.Rows[lstHaiDo.SelectedRows[0].Index][1] = cbbHaiDoeng.Text;
                    table.Rows[lstHaiDo.SelectedRows[0].Index][2] = _tbMaHaiDo.Text;
                    DataTable tempnew = table;
                    Common.ToCSV(tempnew, path);
                    MessageBox.Show("Sửa thành công");
                 //   bindingDataCombobox();
                   // cleartext();
                }
                else
                    MessageBox.Show("Chưa Chọn Bản Ghi Nào");
            }

        }
        private void lstHaiDo_SelectionChanged(object sender, EventArgs e)
        {
            if (lstHaiDo.SelectedRows.Count > 0)
            {
                _cbTenHaiDo.Text = lstHaiDo.SelectedRows[0].Cells[0].Value.ToString();
                cbbHaiDoeng.Text = lstHaiDo.SelectedRows[0].Cells[1].Value.ToString();
                _tbMaHaiDo.Text = lstHaiDo.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Chắc chắn muốn xóa không? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lstHaiDo.SelectedRows.Count > 0)
                {
                    table.Rows.RemoveAt(lstHaiDo.SelectedRows[0].Index);
                    DataTable tempnew = table;
                    Common.ToCSV(tempnew, path);
                    MessageBox.Show("Xóa thành công");
                 //   bindingDataCombobox();
                   // cleartext();
                }
                else
                    MessageBox.Show("Chưa Chọn Bản Ghi Nào");
            }
        }

        private void _cbTenHaiDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cbbHaiDoeng.SelectedValue = _cbTenHaiDo.SelectedIndex;
            if(cbbHaiDoeng.SelectedValue!=null)
            cbbHaiDoeng.SelectedIndex =_cbTenHaiDo.Items.IndexOf(_cbTenHaiDo.SelectedValue);
        }

        private void cbbHaiDoeng_SelectedIndexChanged(object sender, EventArgs e)
        {
            // _cbTenHaiDo.SelectedIndex = cbbHaiDoeng.SelectedIndex;
            if (_cbTenHaiDo.SelectedValue != null)
                _cbTenHaiDo.SelectedIndex = _cbTenHaiDo.Items.IndexOf(cbbHaiDoeng.SelectedValue);
        }
    }
}
