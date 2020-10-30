using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace NhapLieuHangHai.utils
{
    class FileUtils
    {
        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            try
            {
                foreach (var filter in filters)
                {

                    filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return filesFound.ToArray();
        }

        public static void loadImagesFolder(String appPath, ListView lstImageObject, ImageList imageList1)
        {
            //MessageBox.Show(appPath);
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = FileUtils.GetFilesFrom(appPath, filters, false);
            //int count = 0;
            lstImageObject.Items.Clear();

            for (int i = 0; i < files.Length; i++)
            {
                //MessageBox.Show(files[i].ToString());
                ListViewItem lstviewItem = new ListViewItem(files[i].ToString());
                imageList1.ImageSize = new Size(50, 50);
                lstImageObject.LargeImageList = imageList1;
                lstviewItem.ImageIndex = imageList1.Images.Add(Image.FromFile(lstviewItem.Text), Color.Transparent);
                lstImageObject.Items.Add(lstviewItem);

            }


        }

    }
}
