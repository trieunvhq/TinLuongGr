﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmBaoCao_Nhap_Xuat_ton_kho_DaiLy : Form
    {
        private void Load_lockup()
        {
            clsTbDanhMuc_DaiLy cls = new CtyTinLuong.clsTbDanhMuc_DaiLy();
            DataTable dt = cls.SelectAll();
            gridMaDaiLy.Properties.DataSource = dt;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";
        }
        private void LoadDaTa(DateTime xxtungay, DateTime xxdenngay)
        {

        }
        public frmBaoCao_Nhap_Xuat_ton_kho_DaiLy()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load(object sender, EventArgs e)
        {
            Load_lockup();
          
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load( sender,  e);
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
            }
            catch
            {

            }
        }
    }
}
