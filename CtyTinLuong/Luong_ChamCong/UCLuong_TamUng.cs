﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCLuong_TamUng : UserControl
    {
        public static int miiiiID_TamUng;
        public static bool mbThemMoiTamUng;

        private int _SoTrang = 1;
        private int _SoDong = 1;
        private bool isload = false;
        private void HienThiGridControl_2(int iiDI_tamung)
        {
            gridControl2.DataSource = null;

            clsTamUng_ChiTietTamUng cls2 = new clsTamUng_ChiTietTamUng();
            cls2.iID_TamUng = iiDI_tamung;
            DataTable dtchitiet = new DataTable();
            if (checkDaiLy.Checked == true)
                dtchitiet = cls2.SA_W_ID_TamUng_DaiLy();
            else dtchitiet = cls2.SA_W_ID_TamUng_CongNhan();         
            gridControl2.DataSource = dtchitiet;
        }
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            DataTable dt = cls.SelectAll_Load_DaTa_W_NgayThang(_SoTrang, xxtungay, xxdenngay);

            gridControl1.DataSource = dt;


            isload = false;
        }
        private void Load_TamUng(bool islandau)
        {
            int sotrang_ = 1;
            int sodong_ = 10;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                sodong_ = Convert.ToInt32(txtSoDong.Text);
            }
            catch
            {
                sotrang_ = 1;
                sodong_ = 1;
                txtSoTrang.Text = "1";
                txtSoDong.Text = "10";
            }
            LoadData(sotrang_, sodong_,true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsTamUng_New cls = new clsTamUng_New())
            {
                DataTable dt_ = new DataTable();
                if (checkCongNhanVien.Checked == true)
                    dt_ = cls.Dem_Dong_CongNhan(xxtungay, xxdenngay);
                else dt_ = cls.Dem_Dong_DaiLy(xxtungay, xxdenngay);

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }
        public UCLuong_TamUng()
        {
            InitializeComponent();
        }

        private void UCLuong_TamUng_Load(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;
            checkCongNhanVien.Checked = true;
            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCLuong_TamUng_Load( sender,  e);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_TamUng).ToString() != "")
            {
                mbThemMoiTamUng = false;
                miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
                TamUng_new ff = new CtyTinLuong.TamUng_new();
                ff.Show();
            }
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                HienThi();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;
            miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
            TamUng_new ff = new CtyTinLuong.TamUng_new();
            ff.Show();
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_TamUng).ToString() != "")
            {
                int xxxmiiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
                HienThiGridControl_2(xxxmiiiiID_TamUng);
            }
        }

        private void checkCongNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaiLy.Checked == true)
            {
                checkCongNhanVien.Checked = false;
                //Load_LockUp_DoiTuong();
            }
        }

        private void checkDaiLy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCongNhanVien.Checked == true)
            {
                checkDaiLy.Checked = false;
                //Load_LockUp_DoiTuong();
            }
        }
    }
}
