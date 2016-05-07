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
    class ToBoMonBLL
    {
        // lay co so du lieu 
        public DataTable getData()
        {
            DataTable dtResult = new DataTable();
            DataConfig config = new DataConfig();
            string strQuery = "select * from dbo.tobomon";
            dtResult = config.GetDataTable(strQuery);
            return dtResult;
        }

        // them co so du lieu
        public int Insert(ToBoMonEntities obj)
        {
            int result = 0;
            string strQuery = "insert into dbo.tobomon (MATOBOMON , TENBOMON) values ('" + obj.MaToBoMon + "', '" + obj.TenBoMon + "')";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuery);
            return result;
        }
        // check ID 
        public bool CheckID(string _maToBoMon)
        {
            DataConfig config = new DataConfig();
            string strQuery = "select * from dbo.tobomon where matobomon = '" + _maToBoMon + "'";
            DataTable dt = new DataTable();
            dt = config.GetDataTable(strQuery);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        // cau lenh update
        public int Update(ToBoMonEntities obj)
        {
            int result = 0;
            string strQuery = "update dbo.tobomon set matobomon = '" + obj.MaToBoMon + "', tenbomon = '" + obj.TenBoMon + "'";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuery);
            return result;
        }
        // cau lenh xoa 
        public int Delete(string _maToBoMon)
        {
            int result = 0;
            string strQuey = "delete from dbo.tobomon where matobomon = '" + _maToBoMon + "'";
            DataConfig config = new DataConfig();
            result = config.executeNoneQuery(strQuey);
            return result;
        }
    }
}
