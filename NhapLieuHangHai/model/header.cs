using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhapLieuHangHai.model
{
    class header
    {
        public String laPhieu;
        public String nam;
        public String loaiVung;
        public String tinhThanh;

        public header() { }

        public String LaPhieu
        {
            get
            { return laPhieu; }
            set
            { laPhieu = value; }
        }

        public String Nam
        {
            get
            { return nam; }
            set
            { nam = value; }
        }


        public String LoaiVung
        {
            get
            { return loaiVung; }
            set
            { loaiVung = value; }
        }

        public String TinhThanh
        {
            get
            { return tinhThanh; }
            set
            { tinhThanh = value; }
        }


    }


}
