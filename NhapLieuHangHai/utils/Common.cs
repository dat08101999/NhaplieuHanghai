using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace NhapLieuHangHai
{
    class Common
    {
        public static void gettable(DataGridView dataGridView1)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "file nguồn|*.rtf;*.doc;*.docx|";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns.Remove("action");
                    dataGridView1.Columns.Remove("Chọn Icon");
                }
                object readOnly = true;
                object visible = true;
                object save = false;
                object fileName = open.FileName;
                object missing = Type.Missing;
                object newTemplate = false;
                object docType = 0;
                Microsoft.Office.Interop.Word._Document oDoc = null;
                Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                oDoc = oWord.Documents.Open(
                        ref fileName, ref missing, ref readOnly, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref visible,
                        ref missing, ref missing, ref missing, ref missing);
                oDoc.ActiveWindow.Selection.WholeStory();
                oDoc.ActiveWindow.Selection.Copy();

                IDataObject data = Clipboard.GetDataObject();
                Microsoft.Office.Interop.Word.Table firstTable;
                firstTable = oDoc.Tables[1];
                System.Data.DataTable table = new System.Data.DataTable();
               
                //table.Columns.Add("Select", typeof(bool));
                
                table.Columns.Add("Tên điểm", typeof(string));
                table.Columns.Add("B_WGS84(° ' )", typeof(string));
                table.Columns.Add("L_WGS84(° ' )", typeof(string));
                table.Columns.Add("Tên Đối Tượng", typeof(string));
          
                for (int i = 2; i <= firstTable.Rows.Count; i++)
                {
                    System.Data.DataRow row = table.NewRow();
                    //MessageBox.Show(i + " " + j +" "+ firstTable.Rows[1].Cells[1].Range.Text);
                  //  row["Select"] = false;
                    row["Tên điểm"] = firstTable.Rows[i].Cells[2].Range.Text.Replace("", string.Empty);
                    row["B_WGS84(° ' )"] = firstTable.Rows[i].Cells[6].Range.Text.Replace("", string.Empty);
                    row["L_WGS84(° ' )"] = firstTable.Rows[i].Cells[7].Range.Text.Replace("", string.Empty);
                    row["Tên Đối Tượng"] = "";
                    table.Rows.Add(row);
                }
                dataGridView1.DataSource = table;
                addcbbcolumn(dataGridView1);
                dataGridView1.RowHeadersVisible = false;
                oWord.Quit(ref missing, ref missing, ref missing);
            }
        }



        public static void fillData(DataGridView dataGridView1,System.Data.DataTable dataTable)
        { 
            dataGridView1.DataSource = dataTable;
            addcbbcolumn(dataGridView1);
            dataGridView1.RowHeadersVisible = false;
        }
        public static System.Data.DataTable createTable(DataGridView dataGridView1,ChonFileNguon f)
        {

            Microsoft.Office.Interop.Word.Table firstTable;
            System.Data.DataTable table = new System.Data.DataTable();
            f.Invoke((MethodInvoker)delegate {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "file nguồn|*.rtf;*.doc;*.docx";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            dataGridView1.Columns.Remove("action");
                            dataGridView1.Columns.Remove("Chọn Icon");
                        }
                        object readOnly = true;
                        object visible = true;
                        object save = false;
                        object fileName = open.FileName;
                        object missing = Type.Missing;
                        object newTemplate = false;
                        object docType = 0;
                        Microsoft.Office.Interop.Word._Document oDoc = null;
                        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                        oDoc = oWord.Documents.Open(
                                ref fileName, ref missing, ref readOnly, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref visible,
                                ref missing, ref missing, ref missing, ref missing);
                        oDoc.ActiveWindow.Selection.WholeStory();
                        oDoc.ActiveWindow.Selection.Copy();

                        IDataObject data = Clipboard.GetDataObject();
                    
                        firstTable = oDoc.Tables[1];
                        table.Columns.Add("Tên điểm", typeof(string));
                        table.Columns.Add("B_WGS84(° ' )", typeof(string));
                        table.Columns.Add("L_WGS84(° ' )", typeof(string));
                        table.Columns.Add("Tên Đối Tượng", typeof(string));

                        for (int i = 2; i <= firstTable.Rows.Count; i++)
                        {
                            System.Data.DataRow row = table.NewRow();
                            //MessageBox.Show(i + " " + j +" "+ firstTable.Rows[1].Cells[1].Range.Text);
                            //  row["Select"] = false;
                            row["Tên điểm"] = firstTable.Rows[i].Cells[2].Range.Text;
                            row["B_WGS84(° ' )"] = firstTable.Rows[i].Cells[6].Range.Text;
                            row["L_WGS84(° ' )"] = firstTable.Rows[i].Cells[7].Range.Text;
                            row["Tên Đối Tượng"] = "";
                            table.Rows.Add(row);

                        }
                        oWord.Quit(ref missing, ref missing, ref missing);

                }

            });
            
                //table.Columns.Add("Select", typeof(bool));

                
   
            return table;
        }



        public static void CenterHorizontally(Control control)
        {
            Rectangle parentRect = control.Parent.ClientRectangle;
            control.Left = (parentRect.Width - control.Width) / 2;
        }
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                result = ms.ToArray();
            }
            return result;
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        public static void addcbbcolumn(DataGridView dataGridView1)
        {
            DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
            newColumn.Name = "action";
            dataGridView1.Columns.Add(newColumn);
            var bmp = new Bitmap(NhapLieuHangHai.Properties.Resources.icon);

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Chọn Icon";
            dataGridView1.Columns.Add(img);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["action"]);
                cell.DataSource = new string[] { "Sửa/Edit", "Chèn/Insert", "Xóa/Delete","Trống/None"};
                cell.Value = "Chèn/Insert";
                DataGridViewImageCell imgCell = (DataGridViewImageCell)(row.Cells["Chọn Icon"]);
                imgCell.Value = bmp;
            }
        }
        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public static void BindData(string filePath, DataGridView lstHaiDo)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                //return;
            }
            DataTable dt = new DataTable();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadToEnd();
                    string[] rows = text.Split('\n');
                    if (rows.Length > 0)
                    {
                        //Add columns
                        string[] columns = rows[0].Split(',');
                        for (int j = 0; j < columns.Count(); j++)
                            dt.Columns.Add(columns[j]);
                       
                        //Add rows
                        for (int i = 1; i < rows.Count() - 1; i++)
                        {
                            string[] data = rows[i].Split(',');
                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < data.Count(); k++)
                                dr[k] = data[k];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            lstHaiDo.DataSource = dt;
        }


        public static DataTable getData(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadToEnd();
                    string[] rows = text.Split('\n');
                    if (rows.Length > 0)
                    {
                        //Add columns
                        string[] columns = rows[0].Split(',');
                        for (int j = 0; j < columns.Count(); j++)
                            dt.Columns.Add(columns[j]);

                        //Add rows
                        for (int i = 1; i < rows.Count() - 1; i++)
                        {
                            string[] data = rows[i].Split(',');
                            DataRow dr = dt.NewRow();
                            for (int k = 0; k < data.Count(); k++)
                                dr[k] = data[k];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt;
        }

        //public static DataTable setContent;
    }

    

  
}
