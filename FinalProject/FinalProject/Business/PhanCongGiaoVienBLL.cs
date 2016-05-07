﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FinalProject.DataAccess;
using FinalProject.Entities;

namespace FinalProject.Business
{
    class PhanCongGiaoVienBLL
    {
        // lay co so du lieu 
        public DataTable getData()
        {
            DataTable dtResult = new DataTable();
            DataConfig config = new DataConfig();
            string strQuery = "select * from dbo.phanconggiaovien";
            dtResult = config.GetDataTable(strQuery);
            return dtResult;
        }

        // them co so du lieu
        public int Insert(PhanCongGiaoVienEntities obj)
        {
            int result = 0;
            string strQuery = "insert into dbo.phanconggiaovien (MAGIAOVIEN , MAMON, MALOP, HOCKY, NAMHOC) values ('" + obj.MaGiaoVien + "', '" + obj.MaMon + "', '" + obj.MaLop + "', '" + obj.HocKy + "', '" + obj.NamHoc + "')";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuery);
            return result;
        }
        // check ID 
        public bool CheckID(string _maGiaoVien)
        {
            DataConfig config = new DataConfig();
            string strQuery = "select * from dbo.phanconggiaovien where magiaovien = '" + _maGiaoVien + "'";
            DataTable dt = new DataTable();
            dt = config.GetDataTable(strQuery);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        // cau lenh update
        public int Update(PhanCongGiaoVienEntities obj)
        {
            int result = 0;
            string strQuery = "update dbo.phanconggiaovien set magiaovien = '" + obj.MaGiaoVien + "', mamon = '" + obj.MaMon + "', malop = '" + obj.MaLop + "', hocky = '" + obj.HocKy + "', namhoc = '" + obj.NamHoc + "'";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuery);
            return result;
        }
        // cau lenh xoa 
        public int Delete(string _maGiaoVien)
        {
            int result = 0;
            string strQuey = "delete from dbo.phanconggiaovien where magiaovien = '" + _maGiaoVien + "'";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuey);
            return result;
        }
    }
}
