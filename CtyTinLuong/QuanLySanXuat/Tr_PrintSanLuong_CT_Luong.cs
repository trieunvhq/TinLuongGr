using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace CtyTinLuong
{
    public partial class Tr_PrintSanLuong_CT_Luong : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        List<XRTableCell> Ds_NgayTitle = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Header = new List<XRTableCell>();

        public Tr_PrintSanLuong_CT_Luong(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
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
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)150;
                //
                float tmp = 0;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = (float)30.80399;
                    Ds_Ngay_Header[i].WidthF = (float)30.80399;
                    Ds_Ngay[i].WidthF = (float)30.80399;
                    tmp += (float)30.80399;
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
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)150;
                //
                float tmp = 0;
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = (float)29.80399;
                    Ds_Ngay_Header[i].WidthF = (float)29.80399;
                    Ds_Ngay[i].WidthF = (float)29.80399;
                    tmp += (float)29.80399;
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
                hoTen.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF = (float)150;
                //
                float tmp = 0;
                for (int i = 0; i < ngaycuathang_; ++i)
                {

                    Ds_NgayTitle[i].WidthF = (float)29.20399;
                    Ds_Ngay_Header[i].WidthF = (float)29.20399;
                    Ds_Ngay[i].WidthF = (float)29.20399;
                    tmp += (float)29.20399;
                }
                xrTableCell3.WidthF = tmp;
            }
            else if (ngaycuathang_ == 31)
            {
                //nothing
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

    }
}
