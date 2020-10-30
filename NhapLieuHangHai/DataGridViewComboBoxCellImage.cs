using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapLieuHangHai
{
    class DataGridViewComboBoxCellImage
    {
        private object _value;
        private Image _image;


        /// <summary>
        /// ComobBox Item.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }


        /// <summary>
        /// Item image.
        /// </summary>
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public DataGridViewComboBoxCellImage()
        {
            _value = String.Empty;
            _image = new Bitmap(1, 1);
        }
        /// <summary>
        /// Constructor item without image.
        /// </summary>
        /// <param name="value">Item value.</param>
        public DataGridViewComboBoxCellImage(object value)
        {
            _value = value;
            _image = new Bitmap(1, 1);
        }


        /// <summary>
        ///  Constructor item with image.
        /// </summary>
        /// <param name="value">Item value.</param>
        /// <param name="image">Item image.</param>
        public DataGridViewComboBoxCellImage(object value, Image image)
        {
            _value = value;
            _image = image;
        }


        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
