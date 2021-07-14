﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Data;

namespace CtyTinLuong
{
    public partial class Tr_PrintSanLuong_CT_Luong : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang, _nam, _iiID_CongNhan;
        private string _hoTenNhanVien;
        List<XRTableCell> Ds_NgayTitle = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Header = new List<XRTableCell>();

        public Tr_PrintSanLuong_CT_Luong(int thang, int nam, int iiID_CongNhan, string hoTenNhanVien)
        {
            _thang = thang;
            _nam = nam;
            _iiID_CongNhan = iiID_CongNhan;
            _hoTenNhanVien = hoTenNhanVien;

            InitializeComponent();
            //
            Ds_NgayTitle.Add(xrTableCell37);
            Ds_NgayTitle.Add(xrTableCell38);
            Ds_NgayTitle.Add(xrTableCell39);
            Ds_NgayTitle.Add(xrTableCell40);
            Ds_NgayTitle.Add(xrTableCell41);
            Ds_NgayTitle.Add(xrTableCell42);
            Ds_NgayTitle.Add(xrTableCell43);
            Ds_NgayTitle.Add(xrTableCell44);
            Ds_NgayTitle.Add(xrTableCell45);
            Ds_NgayTitle.Add(xrTableCell46);
            Ds_NgayTitle.Add(xrTableCell47);
            Ds_NgayTitle.Add(xrTableCell48);
            Ds_NgayTitle.Add(xrTableCell49);
            Ds_NgayTitle.Add(xrTableCell50);
            Ds_NgayTitle.Add(xrTableCell51);
            Ds_NgayTitle.Add(xrTableCell52);
            Ds_NgayTitle.Add(xrTableCell53);
            Ds_NgayTitle.Add(xrTableCell54);
            Ds_NgayTitle.Add(xrTableCell55);
            Ds_NgayTitle.Add(xrTableCell56);
            Ds_NgayTitle.Add(xrTableCell57);
            Ds_NgayTitle.Add(xrTableCell58);
            Ds_NgayTitle.Add(xrTableCell59);
            Ds_NgayTitle.Add(xrTableCell60);
            Ds_NgayTitle.Add(xrTableCell61);
            Ds_NgayTitle.Add(xrTableCell62);
            Ds_NgayTitle.Add(xrTableCell63);
            Ds_NgayTitle.Add(xrTableCell64);
            Ds_NgayTitle.Add(xrTableCell65);
            Ds_NgayTitle.Add(xrTableCell66);
            Ds_NgayTitle.Add(xrTableCell67);

            //
            Ds_Ngay.Add(Ngay1);
            Ds_Ngay.Add(Ngay2);
            Ds_Ngay.Add(Ngay3);
            Ds_Ngay.Add(Ngay4);
            Ds_Ngay.Add(Ngay5);
            Ds_Ngay.Add(Ngay6);
            Ds_Ngay.Add(Ngay7);
            Ds_Ngay.Add(Ngay8);
            Ds_Ngay.Add(Ngay9);
            Ds_Ngay.Add(Ngay10);
            Ds_Ngay.Add(Ngay11);
            Ds_Ngay.Add(Ngay12);
            Ds_Ngay.Add(Ngay13);
            Ds_Ngay.Add(Ngay14);
            Ds_Ngay.Add(Ngay15);
            Ds_Ngay.Add(Ngay16);
            Ds_Ngay.Add(Ngay17);
            Ds_Ngay.Add(Ngay18);
            Ds_Ngay.Add(Ngay19);
            Ds_Ngay.Add(Ngay20);
            Ds_Ngay.Add(Ngay21);
            Ds_Ngay.Add(Ngay22);
            Ds_Ngay.Add(Ngay23);
            Ds_Ngay.Add(Ngay24);
            Ds_Ngay.Add(Ngay25);
            Ds_Ngay.Add(Ngay26);
            Ds_Ngay.Add(Ngay27);
            Ds_Ngay.Add(Ngay28);
            Ds_Ngay.Add(Ngay29);
            Ds_Ngay.Add(Ngay30);
            Ds_Ngay.Add(Ngay31);
            //
            Ds_Ngay_Header.Add(ng1);
            Ds_Ngay_Header.Add(ng2);
            Ds_Ngay_Header.Add(ng3);
            Ds_Ngay_Header.Add(ng4);
            Ds_Ngay_Header.Add(ng5);
            Ds_Ngay_Header.Add(ng6);
            Ds_Ngay_Header.Add(ng7);
            Ds_Ngay_Header.Add(ng8);
            Ds_Ngay_Header.Add(ng9);
            Ds_Ngay_Header.Add(ng10);
            Ds_Ngay_Header.Add(ng11);
            Ds_Ngay_Header.Add(ng12);
            Ds_Ngay_Header.Add(ng13);
            Ds_Ngay_Header.Add(ng14);
            Ds_Ngay_Header.Add(ng15);
            Ds_Ngay_Header.Add(ng16);
            Ds_Ngay_Header.Add(ng17);
            Ds_Ngay_Header.Add(ng18);
            Ds_Ngay_Header.Add(ng19);
            Ds_Ngay_Header.Add(ng20);
            Ds_Ngay_Header.Add(ng21);
            Ds_Ngay_Header.Add(ng22);
            Ds_Ngay_Header.Add(ng23);
            Ds_Ngay_Header.Add(ng24);
            Ds_Ngay_Header.Add(ng25);
            Ds_Ngay_Header.Add(ng26);
            Ds_Ngay_Header.Add(ng27);
            Ds_Ngay_Header.Add(ng28);
            Ds_Ngay_Header.Add(ng29);
            Ds_Ngay_Header.Add(ng30);
            Ds_Ngay_Header.Add(ng31);
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            setThu();

            pNgay.Value = DateTime.Now.ToString("yyyy/MM/dd");

            //
            clsNhanSu_tbNhanSu cls = new CtyTinLuong.clsNhanSu_tbNhanSu();
            DataTable dt = cls.SO_W_ID_CongNhan(_iiID_CongNhan);

            xrlbBoPhan.Text = "(Họ tên: " + toTitle(_hoTenNhanVien) 
                                + "    -    Bộ phận: " + toTitle(dt.Rows[0]["TenBoPhan"].ToString())+")";

            //Load label ngay thang nam header:
            if (_thang <= 9) xrLabel2.Text = "BẢNG KẾT QUẢ THÁNG 0" + _thang.ToString() + " NĂM " + _nam.ToString();
            else xrLabel2.Text = "BẢNG KẾT QUẢ THÁNG " + _thang.ToString() + " NĂM " + _nam.ToString();

            //Load label ngay ky footer:
            DateTime d = Convert.ToDateTime(pNgay.Value);
            if (d.Day > 9)
            {
                if (d.Month > 9)
                {
                    lbNgayThangNam.Text = "Ngày " + d.Day
                                        + " tháng " + d.Month
                                        + " năm " + d.Year;
                }
                else
                {
                    lbNgayThangNam.Text = "Ngày " + d.Day
                                        + " tháng 0" + d.Month
                                        + " năm " + d.Year;
                }

            }
            else
            {
                if (d.Month > 9)
                {
                    lbNgayThangNam.Text = "Ngày 0" + d.Day
                                        + " tháng " + d.Month
                                        + " năm " + d.Year;
                }
                else
                {
                    lbNgayThangNam.Text = "Ngày 0" + d.Day
                                        + " tháng 0" + d.Month
                                        + " năm " + d.Year;
                }
            }
        }

        //
        private string LayThu(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                case DayOfWeek.Sunday:
                    return "CN";
            }
            return "";
        }

        private string _flag_29 = "undelete";
        private string _flag_30 = "undelete";
        private string _flag_31 = "undelete";

        public void setThu()
        {
            //DateTime dtnow = DateTime.Now;
            //

            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            //
            if (ngaycuathang_ == 28)
            {
                if (_flag_31 == "undelete")
                {
                    xrTable2.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    xrTable2.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    _flag_30 = "deleted";
                }

                //
                if (_flag_29 == "undelete")
                {
                    xrTable2.DeleteColumn(ng29);
                    xrTable1.DeleteColumn(Ngay29);
                    _flag_29 = "deleted";
                }

                //
                //
                xrTableCell6.WidthF = xrTableCell5.WidthF = xrTableCell4.WidthF = xrTableCell2.WidthF = (float)155;
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)52.16;
                //
                float tmp = 0;
                float W_thu = (float)(1083 - 155 - 52.16 - 44.12) / 28;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = W_thu;
                    Ds_Ngay_Header[i].WidthF = W_thu;
                    Ds_Ngay[i].WidthF = W_thu;
                    tmp += W_thu;
                }
                xrTableCell3.WidthF = tmp;
            }
            else if (ngaycuathang_ == 29)
            {
                if (_flag_31 == "undelete")
                {
                    xrTable2.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    xrTable2.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    _flag_30 = "deleted";
                }

                //
                xrTableCell6.WidthF = xrTableCell5.WidthF = xrTableCell4.WidthF = xrTableCell2.WidthF = (float)155;
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)52.16;
                //
                float tmp = 0;
                float W_thu = (float)(1083 - 155 - 52.16 - 44.12) / 29;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = W_thu;
                    Ds_Ngay_Header[i].WidthF = W_thu;
                    Ds_Ngay[i].WidthF = W_thu;
                    tmp += W_thu;
                }
                xrTableCell3.WidthF = tmp;
            }
            else if (ngaycuathang_ == 30)
            {
                if (_flag_31 == "undelete")
                {
                    xrTable2.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);

                    _flag_31 = "deleted";
                }

                //
                xrTableCell6.WidthF = xrTableCell5.WidthF = xrTableCell4.WidthF = xrTableCell2.WidthF = (float)155;
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)52.16;
                //
                float tmp = 0;
                float W_thu = (float)(1083 - 155 - 52.16 - 44.12) / 30;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = W_thu;
                    Ds_Ngay_Header[i].WidthF = W_thu;
                    Ds_Ngay[i].WidthF = W_thu;
                    tmp += W_thu;
                }
                xrTableCell3.WidthF = tmp;
            }
            else if (ngaycuathang_ == 31)
            {
                xrTableCell6.WidthF = xrTableCell5.WidthF = xrTableCell4.WidthF = xrTableCell2.WidthF = (float)155;
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)52.16;
                //
                float tmp = 0;
                float W_thu = (float)(1083 - 155 - 52.16 - 44.12) / 31;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = W_thu;
                    Ds_Ngay_Header[i].WidthF = W_thu;
                    Ds_Ngay[i].WidthF = W_thu;
                    tmp += W_thu;
                }
                xrTableCell3.WidthF = tmp;
            }

            //Tô màu Chủ nhật:
            for (int i = 0; i < ngaycuathang_; ++i)
            {
                Ds_Ngay_Header[i].Text = LayThu(new DateTime(_nam, _thang, (i + 1)));
                if (Ds_Ngay_Header[i].Text.Contains("CN"))
                {
                    Ds_Ngay_Header[i].BackColor = Color.LightGray;
                    Ds_Ngay_Header[i].ForeColor = Color.Red;

                    //detail
                    Ds_Ngay[i].BackColor = Color.LightGray;
                    Ds_Ngay[i].ForeColor = Color.Red;
                }
            }
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            DataSet_TinLuong ds = new DataSet_TinLuong();

            //
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

            DataTable dtxxxx = new DataTable();
            dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan_HUU(_iiID_CongNhan, GetFistDayInMonth(_nam, _thang), GetLastDayInMonth(_nam, _thang));

            int id_vthh_cu_ = 0;
            int STT = 0;

            Tr_clsChiTietTamUng cls_TU = new Tr_clsChiTietTamUng();
            DataTable dt_TU = cls_TU.ReturnTotalTamUng(_iiID_CongNhan, _thang, _nam);

            for (int k = 0; k < dtxxxx.Rows.Count; k++)
            {

                int xxID_VTHH = Convert.ToInt32(dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString());
                //double snluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                //double snluong_tangca = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());
                double xxsanluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_Thuong)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                double xxsanluong_tang = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_TangCa)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                double xxthanhtien = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(ThanhTien)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                int id_vthh_ = 0;
                if (k < dtxxxx.Rows.Count - 1)
                {
                    id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString());
                    if (dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                    {
                        DataRow _ravi_1 = ds.tbChiTiet_LuongSL_sub.NewRow();

                        //_ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        //_ravi_1["DonViTinh"] = dtxxxx.Rows[k]["DonViTinh"].ToString();

                        _ravi_1["TenNhanVien"] = _hoTenNhanVien;

                        if (STT == 0) _ravi_1["TamUng"] = dt_TU.Rows[0]["TamUng"].ToString();
                        else _ravi_1["TamUng"] = 0; 

                        _ravi_1["STT"] = (STT + 1).ToString(); STT++;
                        _ravi_1["MaHang"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        _ravi_1["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["SanLuongThuong"] = xxsanluong_thuong;
                        _ravi_1["SanLuongTang"] = xxsanluong_tang;
                        _ravi_1["DonGia"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                        _ravi_1["DonGiaTang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                        _ravi_1["ThanhTien"] = xxthanhtien;
                        _ravi_1["BaoHiem"] = 0;
                        _ravi_1["AnCa"] = 0;
                        _ravi_1["ThucNhan"] = xxthanhtien;

                        id_vthh_cu_ = id_vthh_;

                        //
                        ds.tbChiTiet_LuongSL_sub.Rows.Add(_ravi_1);
                    }
                    else
                    { }
                }
                else
                {
                    DataRow _ravi_1 = ds.tbChiTiet_LuongSL_sub.NewRow();

                    _ravi_1["TenNhanVien"] = _hoTenNhanVien;

                    if (STT == 0) _ravi_1["TamUng"] = dt_TU.Rows[0]["TamUng"].ToString();
                    else _ravi_1["TamUng"] = 0;

                    _ravi_1["STT"] = (STT + 1).ToString(); STT++;
                    _ravi_1["MaHang"] = dtxxxx.Rows[k]["MaVT"].ToString();
                    _ravi_1["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                    _ravi_1["SanLuongThuong"] = xxsanluong_thuong;
                    _ravi_1["SanLuongTang"] = xxsanluong_tang;
                    _ravi_1["DonGia"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                    _ravi_1["DonGiaTang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                    _ravi_1["ThanhTien"] = xxthanhtien;
                    _ravi_1["BaoHiem"] = 0;
                    _ravi_1["AnCa"] = 0;
                    _ravi_1["ThucNhan"] = xxthanhtien;

                    //
                    ds.tbChiTiet_LuongSL_sub.Rows.Add(_ravi_1);
                }
            }

            //show
            Tr_PrintSanLuong_CT_Luong_Sub xtr112 = (Tr_PrintSanLuong_CT_Luong_Sub)xrSubreport1.ReportSource;
            xtr112.DataSource = ds.tbChiTiet_LuongSL_sub;
            xtr112.DataMember = "tbChiTiet_LuongSL_sub";
        }

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        //
        public string toTitle(string str)
        {
            str = str.Trim();
            while (str.IndexOf("\t") >= 0)
            {
                str = str.Replace("\t", " ");
            }
            while (str.IndexOf("  ") >= 0)
            {
                str = str.Replace("  ", " ");
            }
            string[] arrStr = str.Split(' ');
            string s = "";
            foreach (string item in arrStr)
            {
                s += item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower() + " ";
            }
            return s;
        }
    }
}
