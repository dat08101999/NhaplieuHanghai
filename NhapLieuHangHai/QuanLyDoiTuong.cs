using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.IO;
using NhapLieuHangHai.utils;

namespace NhapLieuHangHai
{
    public partial class QuanLyDoiTuong : Form
    {
        string appPath="";
        String path = System.Windows.Forms.Application.StartupPath+@"\object.txt";
        public QuanLyDoiTuong()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //loadData();
            appPath = System.Windows.Forms.Application.StartupPath + @"\"+lstTenDoiTuong.SelectedItem + @"\";
            OpenFileDialog opFile = new OpenFileDialog();
            opFile.Title = "Select a Image";
            opFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (opFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = opFile.SafeFileName;   // <---
                    string filepath = opFile.FileName;    // <---
                    File.Copy(filepath, appPath + iName); // <---
                    FileUtils.loadImagesFolder(appPath,lstImageObject,imageList1);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file " + exp.Message);
                }
            }
            else
            {
                opFile.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            loadData();
           
        }

        private void loadData()
        {
            readFile(path);
            if (lstTenDoiTuong.Items.Count > 0)
            {
                //MessageBox.Show("2");
                //readFile(path);
                lstTenDoiTuong.SelectedIndex = 0;

                lstImageObject.View = View.LargeIcon;
                lstImageObject.Columns.Add(lstTenDoiTuong.Text);
                lstImageObject.Columns[0].Width = 500;
                FileUtils.loadImagesFolder(appPath, lstImageObject, imageList1);

            }
            else
            {
               
                MessageBox.Show("Chưa có đối tượng nào.Hãy nhập tên đối tượng trước!");
                menu.SelectedTab = tabPage1;
               
                
            }
        
           
         }

        private void lstImageObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lstImageObject.Items[0].Text);
            
        }

        private void lstImageObject_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
           
        }

        private void lstImageObject_MouseClick(object sender, MouseEventArgs e)
        {
            Image preview = Image.FromFile(lstImageObject.SelectedItems[0].Text);
            pictureBox1.Image = new Bitmap(preview);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                                                                                        
            if (txtNhapTen.Text != "")
            {
                //menu.SelectedTab = tabPage2;
                try
                {
                    File.AppendAllText(path, txtNhapTen.Text + Environment.NewLine);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                
                }
    
            }
            else
            {
                MessageBox.Show("Hãy điền đủ tên!");
            }
                
            //readFile(path);// <---
              
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
           
            loadData();
        }

        private void readFile(String appPath)
        {
            lstTenDoiTuong.Items.Clear();
            string line = "";
            try
            {
                
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //MessageBox.Show(line);
                        lstTenDoiTuong.Items.Add(line);
                        lstTenDoiTuong.SelectedIndex = 0;
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //MessageBox.Show("1");


        }

        private void lstTenDoiTuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            appPath = System.Windows.Forms.Application.StartupPath + @"\" + lstTenDoiTuong.SelectedItem + @"\";
            FileUtils.loadImagesFolder(appPath, lstImageObject, imageList1); 
        }        
        
        }
    }

