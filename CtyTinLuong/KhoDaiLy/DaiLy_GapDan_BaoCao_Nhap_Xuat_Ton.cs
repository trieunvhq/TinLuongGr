﻿using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using System;
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
    public partial class DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton : Form
    {
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static int miiID_VTHH;    
        public static DateTime mdatungay, mdadenngay;
   
        private DataTable LoadDaTa_TonDauKy( DateTime xxtungay)
        {
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(xxtungay);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(xxtungay);
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));
            dt2.Columns.Add("TenNhomVTHH", typeof(string));
            dt2.Columns.Add("ID_NhomVTHH", typeof(string));
            for (int i = 0; i < dt_NhapTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTruoc.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_NhapTruocKy, GiaTri_NhapTruocKy, SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;

                SoLuong_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["SoLuong_NhapTruocKy"].ToString());
                GiaTri_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["GiaTri_NhapTruocKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = 0;
                    GiaTri_XuatTruocKy = 0;
                }
                else
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(rows[0]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(rows[0]["GiaTri_XuatTruocKy"].ToString());

                }
                SoLuong_TonDauKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;
                GiaTri_TonDauKy = GiaTri_NhapTruocKy - GiaTri_XuatTruocKy;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["MaVT"] = dt_NhapTruoc.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTruoc.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTruoc.Rows[i]["DonViTinh"].ToString();
                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                _ravi["TenNhomVTHH"] = dt_NhapTruoc.Rows[i]["TenNhomVTHH"].ToString();
                _ravi["ID_NhomVTHH"] = dt_NhapTruoc.Rows[i]["ID_NhomVTHH"].ToString();

                dt2.Rows.Add(_ravi);

            }

            for (int i = 0; i < dt_XuatTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTruoc.Rows[i]["ID_VTHH"].ToString());
                double SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["GiaTri_XuatTruocKy"].ToString());
                    SoLuong_TonDauKy = -SoLuong_XuatTruocKy;
                    GiaTri_TonDauKy = -GiaTri_XuatTruocKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["MaVT"] = dt_XuatTruoc.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTruoc.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTruoc.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;
                    _ravi["TenNhomVTHH"] = dt_XuatTruoc.Rows[i]["TenNhomVTHH"].ToString();
                    _ravi["ID_NhomVTHH"] = dt_XuatTruoc.Rows[i]["ID_NhomVTHH"].ToString();
                    dt2.Rows.Add(_ravi);
                }

            }

            return dt2;
        }
        private DataTable LoadDaTa_Nhap_Xuat_TrongKy(DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            DataTable dt_NhapTrongKy = new DataTable();
            DataTable dt_XuatTrongKy = new DataTable();

            dt_NhapTrongKy = cls1.SA_distinct_NhapTrongKy(xxtungay, xxdenngay);
            dt_XuatTrongKy = cls2.SA_distinct_XuatTrongKy(xxtungay, xxdenngay);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
            dt2.Columns.Add("TenNhomVTHH", typeof(string));
            dt2.Columns.Add("ID_NhomVTHH", typeof(string));

            for (int i = 0; i < dt_NhapTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTrongKy.Rows[i]["ID_VTHH"].ToString());
                double SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;
                SoLuongNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                GiaTriNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuongXuat_TrongKy = 0;
                    GiaTriXuat_TrongKy = 0;
                }
                else
                {
                    SoLuongXuat_TrongKy = Convert.ToDouble(rows[0]["SoLuongXuat_TrongKy"].ToString());
                    GiaTriXuat_TrongKy = Convert.ToDouble(rows[0]["GiaTriXuat_TrongKy"].ToString());

                }

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;

                _ravi["MaVT"] = dt_NhapTrongKy.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTrongKy.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTrongKy.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

                _ravi["TenNhomVTHH"] = dt_NhapTrongKy.Rows[i]["TenNhomVTHH"].ToString();
                _ravi["ID_NhomVTHH"] = dt_NhapTrongKy.Rows[i]["ID_NhomVTHH"].ToString();
                dt2.Rows.Add(_ravi);

            }
            for (int i = 0; i < dt_XuatTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_NhapTrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["MaVT"] = dt_XuatTrongKy.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTrongKy.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTrongKy.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuongNhap_TrongKy"] = 0;
                    _ravi["GiaTriNhap_TrongKy"] = 0;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

                    _ravi["TenNhomVTHH"] = dt_XuatTrongKy.Rows[i]["TenNhomVTHH"].ToString();
                    _ravi["ID_NhomVTHH"] = dt_XuatTrongKy.Rows[i]["ID_NhomVTHH"].ToString();
                    dt2.Rows.Add(_ravi);
                }


            }
            return dt2;
        }
        private void LoadDaTa(DateTime xxtungay, DateTime xxdenngay)
        {

            DataTable dt_TonDayKy = LoadDaTa_TonDauKy(xxtungay);
            DataTable dt_Nhap_Xuat_TrongKy = LoadDaTa_Nhap_Xuat_TrongKy(xxtungay, xxdenngay);
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("TenNhomVTHH", typeof(string));
            dt2.Columns.Add("ID_NhomVTHH", typeof(string));

            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));


            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2.Columns.Add("GiaTriTon_CuoiKy", typeof(double));
            for (int i = 0; i < dt_Nhap_Xuat_TrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_Nhap_Xuat_TrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_TonDauKy, GiaTri_TonDauKy, SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                SoLuongXuat_TrongKy, GiaTriXuat_TrongKy, SoLuongTon_CuoiKy, GiaTriTon_CuoiKy;

                SoLuongNhap_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                GiaTriNhap_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_TonDayKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = 0;
                    GiaTri_TonDauKy = 0;
                }
                else
                {
                    SoLuong_TonDauKy = Convert.ToDouble(rows[0]["SoLuong_TonDauKy"].ToString());
                    GiaTri_TonDauKy = Convert.ToDouble(rows[0]["GiaTri_TonDauKy"].ToString());

                }
                SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;
                DataRow _ravi = dt2.NewRow();

                _ravi["TenNhomVTHH"] = dt_Nhap_Xuat_TrongKy.Rows[i]["TenNhomVTHH"].ToString();
                _ravi["ID_NhomVTHH"] = dt_Nhap_Xuat_TrongKy.Rows[i]["ID_NhomVTHH"].ToString();

                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["MaVT"] = dt_Nhap_Xuat_TrongKy.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_Nhap_Xuat_TrongKy.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_Nhap_Xuat_TrongKy.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

                _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;

                dt2.Rows.Add(_ravi);

            }
            for (int i = 0; i < dt_TonDayKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy; double GiaTri_TonDauKy;

                double SoLuongTon_CuoiKy; double GiaTriTon_CuoiKy;


                iiiiiID_VTHH = Convert.ToInt16(dt_TonDayKy.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_Nhap_Xuat_TrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = Convert.ToDouble(dt_TonDayKy.Rows[i]["SoLuong_TonDauKy"].ToString());
                    GiaTri_TonDauKy = Convert.ToDouble(dt_TonDayKy.Rows[i]["GiaTri_TonDauKy"].ToString());

                    SoLuongTon_CuoiKy = SoLuong_TonDauKy;
                    GiaTriTon_CuoiKy = GiaTri_TonDauKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;

                    _ravi["TenNhomVTHH"] = dt_TonDayKy.Rows[i]["TenNhomVTHH"].ToString();
                    _ravi["ID_NhomVTHH"] = dt_TonDayKy.Rows[i]["ID_NhomVTHH"].ToString();

                    _ravi["MaVT"] = dt_TonDayKy.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_TonDayKy.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_TonDayKy.Rows[i]["DonViTinh"].ToString();

                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                    _ravi["SoLuongNhap_TrongKy"] = 0;
                    _ravi["GiaTriNhap_TrongKy"] = 0;

                    _ravi["SoLuongXuat_TrongKy"] = 0;
                    _ravi["GiaTriXuat_TrongKy"] = 0;

                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;
                    dt2.Rows.Add(_ravi);

                }
            }
            dt2.DefaultView.Sort = "ID_NhomVTHH ASC, TenVTHH ASC";
            dt2 = dt2.DefaultView.ToTable();

            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("STT", typeof(string));
            dt2xx.Columns.Add("Font", typeof(string));
            dt2xx.Columns.Add("ID_VTHH", typeof(int));
            dt2xx.Columns.Add("ID_NhomVTHH", typeof(int));
            dt2xx.Columns.Add("MaVT", typeof(string));
            dt2xx.Columns.Add("TenVTHH", typeof(string));
            dt2xx.Columns.Add("DonViTinh", typeof(string));
            dt2xx.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2xx.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2xx.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2xx.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2xx.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2xx.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2xx.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2xx.Columns.Add("GiaTriTon_CuoiKy", typeof(double));



            string expression1 = "ID_NhomVTHH = 5";
            DataRow[] foundRows1;
            foundRows1 = dt2.Select(expression1);
            if (foundRows1.Length > 0)
            {
                DataRow _ravi_TP = dt2xx.NewRow();
                _ravi_TP["STT"] = "A";
                _ravi_TP["Font"] = "1";
                _ravi_TP["TenVTHH"] = "Nhóm Thành phẩm";
                dt2xx.Rows.Add(_ravi_TP);
                for (int i = 0; i < foundRows1.Length; i++)
                {

                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows1[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows1[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows1[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows1[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows1[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows1[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows1[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows1[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows1[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows1[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows1[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows1[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows1[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            string expression2 = "ID_NhomVTHH = 7";
            DataRow[] foundRows_BTP;
            foundRows_BTP = dt2.Select(expression2);
            if (foundRows_BTP.Length > 0)
            {
                DataRow _ravi_BTP = dt2xx.NewRow();
                _ravi_BTP["STT"] = "B";
                _ravi_BTP["Font"] = "1";
                _ravi_BTP["TenVTHH"] = "Nhóm Bán Thành phẩm";
                dt2xx.Rows.Add(_ravi_BTP);

                for (int i = 0; i < foundRows_BTP.Length; i++)
                {
                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows_BTP[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows_BTP[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows_BTP[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows_BTP[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows_BTP[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows_BTP[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows_BTP[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows_BTP[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows_BTP[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows_BTP[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows_BTP[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows_BTP[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows_BTP[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }



            string expression3 = "ID_NhomVTHH = 8";
            DataRow[] foundRows_VT;
            foundRows_VT = dt2.Select(expression3);
            if (foundRows_VT.Length > 0)
            {
                DataRow _ravi_VT = dt2xx.NewRow();
                _ravi_VT["STT"] = "C";
                _ravi_VT["Font"] = "1";
                _ravi_VT["TenVTHH"] = "Nhóm Vật tư";
                dt2xx.Rows.Add(_ravi_VT);
                for (int i = 0; i < foundRows_VT.Length; i++)
                {
                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows_VT[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows_VT[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows_VT[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows_VT[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows_VT[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows_VT[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows_VT[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows_VT[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows_VT[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows_VT[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows_VT[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows_VT[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows_VT[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            gridControl1.DataSource = dt2xx;

        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
          
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
          
            LoadDaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                miiID_VTHH = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString());                
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                GapDan_frmChiTietNhapXuatTon_MotVatTu ff = new GapDan_frmChiTietNhapXuatTon_MotVatTu();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btPrint_ALL_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
            if (mdtPrint.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {

                
                mbPrint= true;



                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;

                frmPrint_Nhap_Xuat_Ton_TongHop ff = new frmPrint_Nhap_Xuat_Ton_TongHop();
                ff.Show();
            }
        }

        public DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton()
        {
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellValue(e.RowHandle, View.Columns["Font"]).ToString();
                if (category == "1")
                {
                    e.Appearance.BackColor = Color.Bisque;
                    FontStyle fs = e.Appearance.Font.Style;
                    fs |= FontStyle.Bold;
                    e.Appearance.Font = new Font(e.Appearance.Font, fs);
                }
            }
        }

        private void DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsNgayThang cls = new clsNgayThang();
            dteDenNgay.EditValue = DateTime.Now;
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);          
            LoadDaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }
    }
}
