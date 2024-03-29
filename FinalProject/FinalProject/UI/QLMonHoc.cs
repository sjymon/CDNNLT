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
    public partial class QLMonHoc : DevExpress.XtraEditors.XtraForm
    {
        string Query = "";

        public QLMonHoc()
        {
            InitializeComponent();
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            Load_data();
            ControlButton(true);
        }

        private void Load_data()
        {
            MonHocBLL _MonHoc = new MonHocBLL();
            data_view.DataSource = _MonHoc.getData();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            ControlButton(false);
            Query = "add";

            text_mamon.Text = "";
            text_tenmon.Text = "";
            text_sotiet.Text = "0";
            text_hesomon.Text = "0";

            text_mamon.Enabled = true;
            text_mamon.Focus();
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            Query = "edit";
            text_mamon.Enabled = false;
            ControlButton(false);
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có chắc chắn muốn xóa? Bạn sẽ không thể phục hồi dữ liệu đã bị xóa!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Query = "delete";
                Excute(Query);
                text_mamon.Text = "";
                text_tenmon.Text = "";
                text_sotiet.Text = "0";
                text_hesomon.Text = "0";
                Load_data();
            }

        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            Excute(Query);
            ControlButton(true);
        }

        private void button_huy_Click(object sender, EventArgs e)
        {
            Load_data();
            ControlButton(true);
        }

        private void data_view_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            text_mamon.Text = data_view["Column1", index].Value.ToString();
            text_tenmon.Text = data_view["Column2", index].Value.ToString();
            text_sotiet.Text = data_view["Column3", index].Value.ToString();
            text_hesomon.Text = data_view["Column4", index].Value.ToString();

        }

        private void Excute(string strQuery)
        {
            if (strQuery == "add")
            {
                try
                {
                    MonHocEntities obj_MonHoc = new MonHocEntities();
                    obj_MonHoc.MaMon = text_mamon.Text.Trim();
                    obj_MonHoc.TenMon = text_tenmon.Text.Trim();
                    obj_MonHoc.SoTiet = Convert.ToInt32(text_sotiet.Text);
                    obj_MonHoc.HeSo = Convert.ToInt32(text_hesomon.Text);

                    MonHocBLL _MonHoc = new MonHocBLL();
                    string _maMon = text_mamon.Text.Trim();

                    if (text_mamon.Text.Length == 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Mã môn không được để trống!", "Thông báo!", MessageBoxButtons.OK);
                    }
                    else if (!(_MonHoc.CheckID(_maMon)))
                    {
                        _MonHoc.Insert(obj_MonHoc);
                        Load_data();
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Mã môn đã tồn tại!", "Thông báo!", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm bị lỗi: " + ex.Message.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (strQuery == "edit")
            {
                try
                {
                    MonHocEntities obj_MonHoc = new MonHocEntities();
                    obj_MonHoc.MaMon = text_mamon.Text.Trim();
                    obj_MonHoc.TenMon = text_tenmon.Text.Trim();
                    obj_MonHoc.SoTiet = Convert.ToInt32(text_sotiet.Text);
                    obj_MonHoc.HeSo = Convert.ToInt32(text_hesomon.Text);

                    MonHocBLL _MonHoc = new MonHocBLL();
                    _MonHoc.Update(obj_MonHoc);
                    Load_data();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Sửa bị lỗi: " + ex.Message.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (strQuery == "delete")
            {
                try
                {
                    string _maMon = text_mamon.Text.Trim();
                    MonHocBLL _MonHoc = new MonHocBLL();
                    _MonHoc.Delete(_maMon);
                    Load_data();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Xóa bị lỗi: " + ex.Message.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ControlButton(bool type)
        {
            this.button_them.Enabled = button_sua.Enabled = button_xoa.Enabled = type;
            button_luu.Enabled = button_huy.Enabled = group_thongtin.Enabled = !type;
        }
    }
}