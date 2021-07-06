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
    public partial class UCDaiLy_ChiTiet_XuatKho_ALL : UserControl
    {
        private void HienThi()
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                DateTime denngay = dteNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID_VTHH", typeof(int));
                dt2.Columns.Add("MaVT", typeof(string));
                dt2.Columns.Add("TenVTHH", typeof(string));
                dt2.Columns.Add("SoLuong", typeof(double));
                dt2.Columns.Add("DonViTinh", typeof(string));
                dt2.Columns.Add("DonGia", typeof(double));
                dt2.Columns.Add("ThanhTien", typeof(double));
                dt2.Columns.Add("NgayChungTu", typeof(DateTime));
                dt2.Columns.Add("TenDaiLy", typeof(string));
                //NgayThang

                clsDaiLy_tbChiTietXuatKho cls = new CtyTinLuong.clsDaiLy_tbChiTietXuatKho();
                DataTable dt = cls.SelectAll_HienThi_ALL_ChiTiet_XuatKho();
                dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = "NgayChungTu DESC, ID_XuatKhoDaiLy DESC";
                DataTable dxxxx = dv2.ToTable();
                for (int i = 0; i < dxxxx.Rows.Count; i++)
                {
                    double DonGia = Convert.ToDouble(dxxxx.Rows[i]["DonGia"].ToString());
                    double SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuongXuat"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH"].ToString());
                    _ravi["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                    _ravi["SoLuong"] = SoLuong;
                    _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                    _ravi["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();
                    _ravi["TenDaiLy"] = dxxxx.Rows[i]["TenDaiLy"].ToString();
                    _ravi["DonGia"] = DonGia;
                    _ravi["ThanhTien"] = SoLuong * DonGia;
                    dt2.Rows.Add(_ravi);
                }
                gridControl1.DataSource = dt2;
            }

        }
        private void HienThi_ALL()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            //NgayThang

            clsDaiLy_tbChiTietXuatKho cls = new CtyTinLuong.clsDaiLy_tbChiTietXuatKho();
            DataTable dt = cls.SelectAll_HienThi_ALL_ChiTiet_XuatKho();
            DataView dv2 = dt.DefaultView;
            dv2.Sort = "NgayChungTu DESC, ID_XuatKhoDaiLy DESC";
            DataTable dxxxx = dv2.ToTable();
            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                double DonGia = Convert.ToDouble(dxxxx.Rows[i]["DonGia"].ToString());
                double SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuongXuat"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                _ravi["SoLuong"] = SoLuong;
                _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                _ravi["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();
                _ravi["DonGia"] = DonGia;
                _ravi["ThanhTien"] = SoLuong * DonGia;
                _ravi["TenDaiLy"] = dxxxx.Rows[i]["TenDaiLy"].ToString();
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;


        }
        public UCDaiLy_ChiTiet_XuatKho_ALL()
        {
            InitializeComponent();
        }

        private void UCDaiLy_ChiTiet_XuatKho_ALL_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_ChiTiet_XuatKho_ALL_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                HienThi();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //gridControl1.ShowPrintPreview();
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteNgay.Focus();
            }
        }

        private void dteNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }
    }
}
