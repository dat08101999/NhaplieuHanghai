using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
//using System.Data;
using System.Threading;
using System.Globalization;

namespace NhapLieuHangHai
{
    public partial class Form1 : Form
    {
        public int typeform;
        public static System.Data.DataTable data;
        public static List<string> Cbbcolum=new List<string>();
        public static List<Image> imagelist = new List<Image>();

        public static string test = "";
        public string category = "";
        public string provilcial = "";
        // string type = "";
        public string luong = "";
        public string sophieu;
        public string nam = "";
        public string thongbaoso;
        public string Dosau;
        public int Tablerow;
        public object filepath = "";
        public string TypePhieu;
      //  public Microsoft.Office.Interop.Word.Application wordApp;
        //public Microsoft.Office.Interop.Word.Document myWordDoc;
        public int count = 0;
        System.Data.DataTable datatemp;
        System.Data.DataTable dataLuongHd;

        String pathluong = System.Windows.Forms.Application.StartupPath + "\\luong.txt";
       // System.Data.DataTable data;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public void setDataTable(System.Data.DataTable dataTable)
        {
            dataGridView1.AutoGenerateColumns = true;
            MessageBox.Show(dataTable.Rows[0]["Tên điểm"].ToString());
            dataGridView1.DataSource = dataTable;
            //dataGridView1.Databin
           // dataGridView1.Refresh();
        }

        public Form1(System.Data.DataTable dataTable)
        {
            InitializeComponent();
            dataGridView1.DataSource = dataTable;

        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }
        //Creeate the Doc Method
        private void CreateWordDocument(object filename, object SaveAs)
        {
            
           // Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object missing = Missing.Value;
          //  Microsoft.Office.Interop.Word.Document myWordDoc = null;
            if (File.Exists((string)filename))
            {
                FormNhapLieu.wordApp= new Microsoft.Office.Interop.Word.Application(); ;
                FormNhapLieu.myWordDoc= new Microsoft.Office.Interop.Word.Document();
                object readOnly = false;
                object isVisible = false;
                FormNhapLieu.wordApp.Visible = false;
                FormNhapLieu.myWordDoc = FormNhapLieu.wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                FormNhapLieu.myWordDoc.Activate();
                //MessageBox.Show(sophieu);
                //find and replace
                this.FindAndReplace(FormNhapLieu.wordApp, "<DATE>", DateTime.Now.ToString("dd/MM/yyyy"));
                this.FindAndReplace(FormNhapLieu.wordApp, "<LUONG>", luong.Split('/')[0]);
                this.FindAndReplace(FormNhapLieu.wordApp, "<NAM>", nam);
                this.FindAndReplace(FormNhapLieu.wordApp, "<OBJECT>", Dosau.Split('/')[0]);
                this.FindAndReplace(FormNhapLieu.wordApp, "<SOPHIEU>", sophieu);
                this.FindAndReplace(FormNhapLieu.wordApp, "<PROVILCIAL>", provilcial.Split('/')[0]);
                this.FindAndReplace(FormNhapLieu.wordApp, "<TYPE>", TypePhieu.Split('/')[0]);
                this.FindAndReplace(FormNhapLieu.wordApp, "<CATEGORY>", category);
                this.FindAndReplace(FormNhapLieu.wordApp, "<DAY>", dateTimePicker1.Value.Day.ToString());
                this.FindAndReplace(FormNhapLieu.wordApp, "<MONTH>", dateTimePicker1.Value.Month.ToString());
                this.FindAndReplace(FormNhapLieu.wordApp, "<YEAR>", dateTimePicker1.Value.Year.ToString());
                this.FindAndReplace(FormNhapLieu.wordApp, "<NUMBER>", thongbaoso);
                createTable(FormNhapLieu.myWordDoc, FormNhapLieu.wordApp,0);
            }
            else
            {
                MessageBox.Show("File not Found!");
            }
            //Save as
            FormNhapLieu.myWordDoc.SaveAs(ref SaveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
            //this.wordApp = wordApp;
            //this.myWordDoc = myWordDoc;

           // MessageBox.Show("File Created!");
        }
        void getTableNumBerFromDataGridViwe()
        {
            Tablerow = dataGridView1.Rows.Count;
        }
        string setIconColumWord(int index,bool vietnammesetype)
        {
            // string s = "";
            if(typeform==1)
            { 
               if(vietnammesetype)
                return "(ICON)" + Environment.NewLine + datatemp.Rows[index]["Tendoituong"].ToString().Split('/')[0];
               else
                return "(ICON)" + Environment.NewLine + datatemp.Rows[index]["Tendoituong"].ToString().Split('/')[1];
            }
            if(typeform==2|| typeform==3)
            {
                if(vietnammesetype)
                    return "(ICON)" + "   " + datatemp.Rows[index]["Tendoituong"].ToString().Split('/')[0]+"    "+ datatemp.Rows[index]["Tên điểm"].ToString();
                else
                    return "(ICON)" + "   " + datatemp.Rows[index]["Tendoituong"].ToString().Split('/')[1] +"    " + datatemp.Rows[index]["Tên điểm"].ToString();
            }
           // myWordDoc.Tables[count].Rows[index].Alignment = WdRowAlignment.wdAlignRowCenter;
            return "";
        }
        string Phuongthuctheotype(int index,int English)
        {
            if(typeform==3)
            {
                if (index == 0)
                    if(Dosau.Split('/').Length>1)
                    return datatemp.Rows[index]["phuong thuc"].ToString().Split('/')[English]+"  "+Dosau.Split('/')[English] ;
                    else
                        return datatemp.Rows[index]["phuong thuc"].ToString().Split('/')[English] + "  " + Dosau.Split('/')[0];
                else
                    return "";
            }
            else
            { 
                return datatemp.Rows[index]["phuong thuc"].ToString().Split('/')[English];
            }
           // return "";
        }
        void createTable(Microsoft.Office.Interop.Word.Document myWordDoc, Microsoft.Office.Interop.Word.Application wordApp,int type)
        {
            //MessageBox.Show(count.ToString());
            getTableNumBerFromDataGridViwe();
            wordApp.Selection.Find.Execute("<blocks>");
            object missing ="";
            object start = wordApp.Selection.Range.Start;
            object end = wordApp.Selection.Range.End;
            Microsoft.Office.Interop.Word.Range tableLocation = myWordDoc.Range(ref start, ref end);
            myWordDoc.Tables.Add(tableLocation, Tablerow, 4);
            myWordDoc.Tables[count].Range.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleNone;
            Object oMissing = System.Reflection.Missing.Value;
            for (int i = 1; i <= myWordDoc.Tables[count].Rows.Count; i++)
            {
                if (type == 0 || datatemp.Rows[i - 1]["Tendoituong"].ToString().Split('/').Length == 1)//vietnamese type
                {
                    //myWordDoc.Tables[count].Rows[i].Cells[2].Range.Text = "(ICON)" + Environment.NewLine + datatemp.Rows[i - 1]["Tendoituong"].ToString().Split('/')[0];
                    myWordDoc.Tables[count].Rows[i].Cells[2].Range.Text = setIconColumWord(i - 1, true);
                }
                else
                {
                    // myWordDoc.Tables[count].Rows[i].Cells[2].Range.Text = "(ICON)" + Environment.NewLine + datatemp.Rows[i - 1]["Tendoituong"].ToString().Split('/')[1];
                    myWordDoc.Tables[count].Rows[i].Cells[2].Range.Text = setIconColumWord(i - 1, false);
                }
                if (type == 0)//type vietnamese
                {
                    // myWordDoc.Tables[count].Rows[i].Cells[1].Range.Text = datatemp.Rows[i - 1]["phuong thuc"].ToString().Split('/')[0];
                    myWordDoc.Tables[count].Rows[i].Cells[1].Range.Text = Phuongthuctheotype(i - 1, 0);
                }
                else
                {
                    //myWordDoc.Tables[count].Rows[i].Cells[1].Range.Text = datatemp.Rows[i - 1]["phuong thuc"].ToString().Split('/')[1];
                    myWordDoc.Tables[count].Rows[i].Cells[1].Range.Text = Phuongthuctheotype(i - 1, 1);
                }
                wordApp.Selection.Find.Execute("(ICON)");
                object startimg = wordApp.Selection.Range.Start;
                object endimg = wordApp.Selection.Range.End;
                Microsoft.Office.Interop.Word.Range imgLocation = myWordDoc.Range(ref start, ref end);
                Image sparePicture = ByteArrayToImage(datatemp.Rows[i - 1]["image"] as byte[]);
                if (sparePicture.Size != Properties.Resources.icon.Size)
                {
                    if (typeform != 3)
                    {
                        Clipboard.SetDataObject(sparePicture);
                    }
                    else
                    {
                        Clipboard.SetDataObject("");
                    }
                    //wordApp.Selection.Range.Paragraphs.Add(imgLocation);
                    wordApp.Selection.Range.Paste();
                }
                else
                {
                    this.FindAndReplace(wordApp,"(ICON)","");
                }
                // wordApp.Selection.Range.InsertParagraphAfter();
                // wordApp.Selection.Text = "";
                myWordDoc.Tables[count].Rows[i].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                myWordDoc.Tables[count].Rows[i].Cells[3].Range.Text = datatemp.Rows[i - 1]["B_WGS84(° ' )"].ToString();
                myWordDoc.Tables[count].Rows[i].Cells[4].Range.Text = datatemp.Rows[i - 1]["L_WGS84(° ' )"].ToString();
                foreach (Microsoft.Office.Interop.Word.InlineShape item in wordApp.ActiveDocument.InlineShapes)
                {
                    if (item != null)
                    {
                        if (item.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                        {
                            item.Select();
                            Microsoft.Office.Interop.Word.Shape shape = item.ConvertToShape();
                            shape.WrapFormat.Type = WdWrapType.wdWrapFront;
                        }
                    }

                }
            }
        }
        void categoryset(String category)
        {
            // checkedListBox1.Items.Add(category);
        }
        void apendBlock()
        {
            string[] NewBlock = new string[3];
            NewBlock[0] = "Hải đồ ảnh hưởng – <category> (Phiên bản 1, cập nhật ngày  <day> tháng  <month> năm  <year>)";
            NewBlock[1] = "<blocks>";
            NewBlock[2] = "(Tất cả các vị trí được tham chiếu theo hệ tọa độ WGS 84)";
            //try
            //{
                Microsoft.Office.Interop.Word.Paragraph paragraph = FormNhapLieu.myWordDoc.Paragraphs.Add();
                paragraph.Range.Text = NewBlock[0] + Environment.NewLine + NewBlock[1] + Environment.NewLine + NewBlock[2];

                getTableNumBerFromDataGridViwe();
            FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[0]);
            FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;

                this.FindAndReplace(FormNhapLieu.wordApp, "<category>", category);
                this.FindAndReplace(FormNhapLieu.wordApp, "<day>", dateTimePicker1.Value.Day.ToString());
                this.FindAndReplace(FormNhapLieu.wordApp, "<month>", dateTimePicker1.Value.Month.ToString());
                this.FindAndReplace(FormNhapLieu.wordApp, "<year>", dateTimePicker1.Value.Year.ToString());
                createTable(FormNhapLieu.myWordDoc, FormNhapLieu.wordApp, 0);
          // }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
       public void appendEngligh(int index)
        {
            count++;
            string[] NewBlock = new string[5];
            NewBlock[0] = "<SOPHIEU>/<NAM> - VIET NAM –<PROVILCIAL>-<TYPE>–<LUONG>–<OBJECT>";
            NewBlock[1] = "Source: Southern Viet Nam Maritime Safety, Notice No.<NUMBER>/TBHH-TCTBĐATHHMN";
            NewBlock[2] = "Chart affected – <category>(Edition No. 1, updated on <month> <day> th, <year>)";
            NewBlock[3] = "<blocks>";
            NewBlock[4] = "(All positions are affected to WGS 84 Datum)";
            //try
            //{
            FormNhapLieu.wordApp.Selection.Find.Execute("<blocks>");
                object missing = "";
                object start = FormNhapLieu.wordApp.Selection.Range.Start;
                object end = FormNhapLieu.wordApp.Selection.Range.End;
                Microsoft.Office.Interop.Word.Paragraph paragraph = FormNhapLieu.myWordDoc.Paragraphs.Add();
                if (index == 0)
                {
                    paragraph.Range.Text = NewBlock[0] + Environment.NewLine + NewBlock[1] + Environment.NewLine + NewBlock[2]+ Environment.NewLine + NewBlock[3]+ Environment.NewLine + NewBlock[4];
                FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[0]);
                FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;
                FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[2]);
                FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;
                    this.FindAndReplace(FormNhapLieu.wordApp, "<DATE>", DateTime.Now.ToString("dd/MM/yyyy"));
                    if (luong.Split('/').Length > 1)
                    {
                        this.FindAndReplace(FormNhapLieu.wordApp, "<LUONG>", luong.Split('/')[1]);
                    }
                    else
                     this.FindAndReplace(FormNhapLieu.wordApp, "<LUONG>", luong.Split('/')[0]);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<NAM>", nam);
                    if (Dosau.Split('/').Length > 1)
                    {
                        this.FindAndReplace(FormNhapLieu.wordApp, "<OBJECT>", Dosau.Split('/')[1]);
                    }
                    else
                    this.FindAndReplace(FormNhapLieu.wordApp, "<OBJECT>", Dosau.Split('/')[0]);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<SOPHIEU>", sophieu);
                    if (provilcial.Split('/').Length > 1)
                    {
                        this.FindAndReplace(FormNhapLieu.wordApp, "<PROVILCIAL>", provilcial.Split('/')[1]);
                    }
                    else
                    this.FindAndReplace(FormNhapLieu.wordApp, "<PROVILCIAL>", provilcial.Split('/')[0]);
                    if (TypePhieu.Split('/').Length > 1)
                    {
                        this.FindAndReplace(FormNhapLieu.wordApp, "<TYPE>", TypePhieu.Split('/')[1]);
                    }
                    else
                    this.FindAndReplace(FormNhapLieu.wordApp, "<TYPE>", TypePhieu.Split('/')[0]);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<NUMBER>", thongbaoso);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<category>", category);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<day>", dateTimePicker1.Value.Day.ToString());
                    this.FindAndReplace(FormNhapLieu.wordApp, "<month>", dateTimePicker1.Value.ToString("MMMM",CultureInfo.InvariantCulture));
                    this.FindAndReplace(FormNhapLieu.wordApp, "<year>", dateTimePicker1.Value.Year.ToString());
                    createTable(FormNhapLieu.myWordDoc, FormNhapLieu.wordApp, 1);
                }
                else
                {
                    paragraph.Range.Text= Environment.NewLine + NewBlock[2] + Environment.NewLine + NewBlock[3] + Environment.NewLine + NewBlock[4];
                FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[0]);
                FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;
                FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[2]);
                FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;
                    getTableNumBerFromDataGridViwe();
                FormNhapLieu.wordApp.Selection.Find.Execute(NewBlock[0]);
                FormNhapLieu.wordApp.Selection.Range.Font.Bold = 1;
                    this.FindAndReplace(FormNhapLieu.wordApp, "<category>", category);
                    this.FindAndReplace(FormNhapLieu.wordApp, "<day>", dateTimePicker1.Value.Day.ToString());
                    this.FindAndReplace(FormNhapLieu.wordApp, "<month>", dateTimePicker1.Value.ToString("MMMM", CultureInfo.InvariantCulture));
                    this.FindAndReplace(FormNhapLieu.wordApp, "<year>", dateTimePicker1.Value.Year.ToString());
                    createTable(FormNhapLieu.myWordDoc, FormNhapLieu.wordApp, 1);
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
      public  void openAgainWOrd()
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object missing = Missing.Value;
            Microsoft.Office.Interop.Word.Document myWordDoc = null;
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
                //this.wordApp = wordApp;
                //this.myWordDoc = myWordDoc;
            }
        }
        void save()
        {
            count++;
            if (filepath == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "doc files|*.docx";
                if(save.ShowDialog() == DialogResult.OK)
                {
                    filepath = save.FileName;
                    CreateWordDocument(System.Windows.Forms.Application.StartupPath + "\\filecantao.docx", filepath);
                }
            }
            else
            {
                apendBlock();
                //openAgainWOrd();
            }
        }
        public void closeWord()
        {
            //this.myWordDoc.Close();
            //this.wordApp.Quit();
        }
        void getcatecory()
        {
            category = txtMaHaiDo.Text.Replace("\n", "").Replace("\r", "");
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                result = ms.ToArray();
            }
            return result;
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        void GetDatachose()
        {
            datatemp = new System.Data.DataTable();
            datatemp.Columns.Add("phuong thuc", typeof(string));
            datatemp.Columns.Add("Tên điểm", typeof(string));
            datatemp.Columns.Add("B_WGS84(° ' )", typeof(string));
            datatemp.Columns.Add("L_WGS84(° ' )", typeof(string));
            datatemp.Columns.Add("Tendoituong", typeof(string));
            datatemp.Columns.Add("image", typeof(byte[]));
            //MessageBox.Show(dataGridView1.Rows.Count.ToString());
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                  //MessageBox.Show(row.Cells[4].Value.ToString()+" "+row.Index.ToString());
                    System.Data.DataRow rowTB = datatemp.NewRow();
                    Image img = (Bitmap)row.Cells[5].Value;
                    rowTB["image"] = ImageToByteArray(img);
                    rowTB["phuong thuc"] = row.Cells[4].Value.ToString();
                    rowTB["Tendoituong"] = row.Cells[3].Value.ToString();
                    rowTB["B_WGS84(° ' )"] = row.Cells[2].Value.ToString();
                    rowTB["L_WGS84(° ' )"] = row.Cells[1].Value.ToString();
                    rowTB["Tên điểm"] = row.Cells[0].Value.ToString();
                    datatemp.Rows.Add(rowTB);
            }
        }
        void addChartToTable()
        {
            if (File.Exists(pathluong))
            {
                System.Data.DataTable temp = Common.getData(pathluong);
                foreach(DataRow row in temp.Rows)
                {
                    //MessageBox.Show(row[0][2]);
                    cbbHaiDo.Items.Add(row[2]);
                }
            }
            else
            {
                MessageBox.Show("Chưa có dữ liệu về luồng! Đề nghị nhập dữ liệu về luồng trước");
            }
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool Checkcategory = false;
            if (Checkcategory)
            {
                //groupBox3.Visible = true;
            }
            else
            {
              //  groupBox3.Visible = false;
            }
            //  dataGridView2.CurrentCell = null;
        }
        void thread_chonfilebt()
        {
           
            if(dataGridView1.Rows.Count>0)
            {
                dataGridView1.Columns.Remove("action");
                dataGridView1.Columns.Remove("Chọn Icon");
            }
                DataGridViewTextBoxColumn actioncl = new DataGridViewTextBoxColumn();
                actioncl.Name = "action";
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Chọn Icon";
                dataGridView1.DataSource = data;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns.Add(actioncl);
                dataGridView1.Columns.Add(img);
                for (int i = 0; i < Cbbcolum.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[4].Value = Cbbcolum[i];
                    dataGridView1.Rows[i].Cells[5].Value = imagelist[i];
                }
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
        private void button2_Click_1(object sender, EventArgs e)
        {
            data=new System.Data.DataTable();
            ChonFileNguon nl = new ChonFileNguon(typeform);
            nl.ShowDialog();
            thread_chonfilebt();
        }
        void threqad()
        {   
        }
        void loadFIle(object filepath)
        {
            if (filepath != "")
            {
                object readOnly = false;
                object visible = true;
                object save = false;
                object fileName = filepath;
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
                //richTextBox1.Rtf = data.GetData(DataFormats.Rtf).ToString();
            }
        }
        void clearForm()
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = false;
                row.Cells[4].Value = "";
            }
            //groupBox3.Visible = false;
        }  
        public void click_tosave()
        {
            getcatecory();
            GetDatachose();
            //getcatecory();
            save();
            Tablerow = 0;
        }
        public void button1_Click_1(object sender, EventArgs e)
        {
            // setVaLue(txtThongBaoSo.Text, txtThongBaoSo.Text, txtDosau.Text);
            click_tosave();
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (checkedListBox1.CheckedItems.Count > 0)
            //{
            //    groupBox3.Visible = true;
            //}
            //else
            //{
            //    groupBox3.Visible = false;
            //}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (filepath != "")
                loadFIle(filepath);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnLayCategory_Click(object sender, EventArgs e)
        {
            bool Checkcategory = false;

           
            if (Checkcategory)
            {
               // groupBox3.Visible = true;
            }
        }

        private void cbLuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void linkHd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //dataGridView2.Visible = true;
            //groupBox3.Text = "Chọn Hải Đồ";
            //btnThemHaiDo.Visible = true;
          //  addChartToTable();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            addChartToTable();
            cbbHaiDo.SelectedIndex = 0;
            cbbHaiDo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbHaiDo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            // AutoCompleteStringCollection 
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            dataLuongHd = Common.getData(System.Windows.Forms.Application.StartupPath + "\\luong.txt");
            //MessageBox.Show(dataLuongHd.Rows.Count.ToString());
            for (int i = 0; i < dataLuongHd.Rows.Count; i++)
            {
                data.Add(dataLuongHd.Rows[i][2].ToString());
            }
            cbbHaiDo.AutoCompleteCustomSource = data;
            // data = new DataGridView();
            //data = new DataGridView();
            //Common.gettable()
        }

        private void btnThemHaiDo_Click(object sender, EventArgs e)
        {
           // btnThemHaiDo.Visible = false;
        }

        private void cbbHaiDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHaiDo.SelectedIndex > 0)
            {
                txtMaHaiDo.Text += cbbHaiDo.Text + ", ";
            }
        }

        private void cbbHaiDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbbHaiDo.Text != "Chọn hải đồ ảnh hưởng" && e.KeyData == Keys.Enter)
            {
                txtMaHaiDo.Text += cbbHaiDo.Text + ", ";
            }
        }

        private void cbbHaiDo_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
