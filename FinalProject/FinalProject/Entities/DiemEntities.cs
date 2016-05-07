﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    class DiemEntities
    {
        private string _maHocSinh;

        public string MaHocSinh
        {
            get { return _maHocSinh; }
            set { _maHocSinh = value; }
        }
        private string _maMonHoc;

        public string MaMonHoc
        {
            get { return _maMonHoc; }
            set { _maMonHoc = value; }
        }
        private string _HocKy;

        public string HocKy
        {
            get { return _HocKy; }
            set { _HocKy = value; }
        }
        private string _NamHoc;

        public string NamHoc
        {
            get { return _NamHoc; }
            set { _NamHoc = value; }
        }
        private int _diemMon;

        public int DiemMon
        {
            get { return _diemMon; }
            set { _diemMon = value; }
        }
        private int _heSoDiem;

        public int HeSoDiem
        {
            get { return _heSoDiem; }
            set { _heSoDiem = value; }
        }
    }
}
