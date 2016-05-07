﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinalProject.Business;
using FinalProject.Entities;

namespace FinalProject.UI
{
    public partial class QLHocLuc : DevExpress.XtraEditors.XtraForm
    {
        string Query = "";

        public QLHocLuc()
        {
            InitializeComponent();
        }

        private void QLHocLuc_Load(object sender, EventArgs e)
        {
            Load_data();
            ControlButton(true);
        }

        private void Load_data()
        {
            HocLucBLL _HocLuc = new HocLucBLL();
            data_view.DataSource = _HocLuc.getData();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            Query = "add";

            cb_mahocsinh.Text = "";
            cb_hocluc.Text = "";
            cb_hocky.Text = "";
            cb_namhoc.Text = "";

            cb_mahocsinh.Enabled = true;
            cb_mahocsinh.Focus();
            ControlButton(false);


        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            Query = "edit";
            cb_mahocsinh.Enabled = false;
            ControlButton(false);
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            Query = "delete";
            Excute(Query);
        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            Excute(Query);
            ControlButton(true);
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            ControlButton(true);
        }

        private void data_view_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            /*
            cb_mahocsinh.Text = data_view["Column1", index].Value.ToString();
            cb_hocluc.Text = data_view["Column2", index].Value.ToString();
            cb_hocky.Text = data_view["Column3", index].Value.ToString();
            cb_namhoc.Text = data_view["Column4", index].Value.ToString();
             */
        }

        private void Excute(string strQuery)
        {
            if (strQuery == "add")
            {
                try
                {
                    HocLucEntities obj_HocLuc = new HocLucEntities();
                    obj_HocLuc.MaHocSinh = cb_mahocsinh.Text.Trim();
                    obj_HocLuc.XepLoaiHocLuc = cb_hocluc.Text.Trim();
                    obj_HocLuc.HocKy = cb_hocky.Text.Trim();
                    obj_HocLuc.NamHoc = cb_namhoc.Text.Trim();

                    HocLucBLL _HocLuc = new HocLucBLL();
                    _HocLuc.Insert(obj_HocLuc);
                    Load_data();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Them bi loi: " + ex.Message.ToString(), "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (strQuery =="edit")
            {
                try
                {
                    HocLucEntities obj_HocLuc = new HocLucEntities();
                    obj_HocLuc.MaHocSinh = cb_mahocsinh.Text.Trim();
                    obj_HocLuc.XepLoaiHocLuc = cb_hocluc.Text.Trim();
                    obj_HocLuc.HocKy = cb_hocky.Text.Trim();
                    obj_HocLuc.NamHoc = cb_namhoc.Text.Trim();

                    HocLucBLL _HocLuc = new HocLucBLL();
                    _HocLuc.Update(obj_HocLuc);
                    Load_data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sua bi loi: " + ex.Message.ToString(), "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (strQuery =="delete")
            {
                try
                {
                    string _maHocSinh = cb_mahocsinh.Text.Trim();
                    HocLucBLL _HocLuc = new HocLucBLL();
                    _HocLuc.Delete(_maHocSinh);
                    Load_data();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa bị lỗi: " + ex.Message.ToString(), "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ControlButton(bool type)
        {
            this.button_them.Enabled = button_sua.Enabled = button_xoa.Enabled = type;
            button_luu.Enabled = button_huy.Enabled = !type;
        }
    }
}