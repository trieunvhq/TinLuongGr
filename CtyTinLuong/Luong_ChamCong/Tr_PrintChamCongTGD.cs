using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_PrintChamCongTGD : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        List<XRTableCell> Ds_NgayTitle = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Header = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Footer = new List<XRTableCell>();

        public Tr_PrintChamCongTGD(int thang, int nam)
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

            //
            Ds_Ngay_Footer.Add(tg1);
            Ds_Ngay_Footer.Add(tg2);
            Ds_Ngay_Footer.Add(tg3);
            Ds_Ngay_Footer.Add(tg4);
            Ds_Ngay_Footer.Add(tg5);
            Ds_Ngay_Footer.Add(tg6);
            Ds_Ngay_Footer.Add(tg7);
            Ds_Ngay_Footer.Add(tg8);
            Ds_Ngay_Footer.Add(tg9);
            Ds_Ngay_Footer.Add(tg10);
            Ds_Ngay_Footer.Add(tg11);
            Ds_Ngay_Footer.Add(tg12);
            Ds_Ngay_Footer.Add(tg13);
            Ds_Ngay_Footer.Add(tg14);
            Ds_Ngay_Footer.Add(tg15);
            Ds_Ngay_Footer.Add(tg16);
            Ds_Ngay_Footer.Add(tg17);
            Ds_Ngay_Footer.Add(tg18);
            Ds_Ngay_Footer.Add(tg19);
            Ds_Ngay_Footer.Add(tg20);
            Ds_Ngay_Footer.Add(tg21);
            Ds_Ngay_Footer.Add(tg22);
            Ds_Ngay_Footer.Add(tg23);
            Ds_Ngay_Footer.Add(tg24);
            Ds_Ngay_Footer.Add(tg25);
            Ds_Ngay_Footer.Add(tg26);
            Ds_Ngay_Footer.Add(tg27);
            Ds_Ngay_Footer.Add(tg28);
            Ds_Ngay_Footer.Add(tg29);
            Ds_Ngay_Footer.Add(tg30);
            Ds_Ngay_Footer.Add(tg31);
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            setThu();

            //Load label ngay thang nam header:
            if (_thang <= 9) xrlbThang.Text = "0" + _thang.ToString();
            else xrlbThang.Text = _thang.ToString();
            xrlbNam.Text = _nam.ToString();

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
                    xrTable3.DeleteColumn(tg31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    xrTable2.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    xrTable3.DeleteColumn(tg30);
                    _flag_30 = "deleted";
                }

                //
                if (_flag_29 == "undelete")
                {
                    xrTable2.DeleteColumn(ng29);
                    xrTable1.DeleteColumn(Ngay29);
                    xrTable3.DeleteColumn(tg29);
                    _flag_29 = "deleted";
                }


                //
                hoTen.WidthF = (float)140.98;
                cong.WidthF = (float)64.84;
                Ngay1.WidthF = (float)26.97299;
                Ngay2.WidthF = ng2.WidthF;
                Ngay3.WidthF = ng3.WidthF;
                Ngay4.WidthF = ng4.WidthF;
                Ngay5.WidthF = ng5.WidthF;
                Ngay6.WidthF = ng6.WidthF;
                Ngay7.WidthF = ng7.WidthF;
                Ngay8.WidthF = ng8.WidthF;
                Ngay9.WidthF = ng9.WidthF;
                Ngay10.WidthF = ng10.WidthF;
                Ngay11.WidthF = ng11.WidthF;
                Ngay12.WidthF = ng12.WidthF;
                Ngay13.WidthF = ng13.WidthF;
                Ngay14.WidthF = ng14.WidthF;
                Ngay15.WidthF = ng15.WidthF;
                Ngay16.WidthF = ng16.WidthF;
                Ngay17.WidthF = ng17.WidthF;
                Ngay18.WidthF = ng18.WidthF;
                Ngay19.WidthF = ng19.WidthF;
                Ngay20.WidthF = ng20.WidthF;
                Ngay21.WidthF = ng21.WidthF;
                Ngay22.WidthF = ng22.WidthF;
                Ngay23.WidthF = ng23.WidthF;
                Ngay24.WidthF = ng24.WidthF;
                Ngay25.WidthF = ng25.WidthF;
                Ngay26.WidthF = ng26.WidthF;
                Ngay27.WidthF = ng27.WidthF;
                Ngay28.WidthF = ng28.WidthF;
                TongCel.WidthF = (float)42.89;

                //
                nameTong.WidthF = (float)140.98;
                congFooter.WidthF = (float)64.84;
                tg1.WidthF = Ngay1.WidthF;
                tg2.WidthF = Ngay2.WidthF;
                tg3.WidthF = Ngay3.WidthF;
                tg4.WidthF = Ngay4.WidthF;
                tg5.WidthF = Ngay5.WidthF;
                tg6.WidthF = Ngay6.WidthF;
                tg7.WidthF = Ngay7.WidthF;
                tg8.WidthF = Ngay8.WidthF;
                tg9.WidthF = Ngay9.WidthF;
                tg10.WidthF = Ngay10.WidthF;
                tg11.WidthF = Ngay11.WidthF;
                tg12.WidthF = Ngay12.WidthF;
                tg13.WidthF = Ngay13.WidthF;
                tg14.WidthF = Ngay14.WidthF;
                tg15.WidthF = Ngay15.WidthF;
                tg16.WidthF = Ngay16.WidthF;
                tg17.WidthF = Ngay17.WidthF;
                tg18.WidthF = Ngay18.WidthF;
                tg19.WidthF = Ngay19.WidthF;
                tg20.WidthF = Ngay20.WidthF;
                tg21.WidthF = Ngay21.WidthF;
                tg22.WidthF = Ngay22.WidthF;
                tg23.WidthF = Ngay23.WidthF;
                tg24.WidthF = Ngay24.WidthF;
                tg25.WidthF = Ngay25.WidthF;
                tg26.WidthF = Ngay26.WidthF;
                tg27.WidthF = Ngay27.WidthF;
                tg28.WidthF = Ngay28.WidthF;
                tgSum.WidthF = (float)42.89;
            }
            else if (ngaycuathang_ == 29)
            {
                if (_flag_31 == "undelete")
                {
                    xrTable2.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    xrTable3.DeleteColumn(tg31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    xrTable2.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    xrTable3.DeleteColumn(tg30);
                    _flag_30 = "deleted";
                }

                //
                hoTen.WidthF = (float)140.98;
                cong.WidthF = (float)64.84;
                Ngay1.WidthF = (float)26.0099;
                Ngay2.WidthF = ng2.WidthF;
                Ngay3.WidthF = ng3.WidthF;
                Ngay4.WidthF = ng4.WidthF;
                Ngay5.WidthF = ng5.WidthF;
                Ngay6.WidthF = ng6.WidthF;
                Ngay7.WidthF = ng7.WidthF;
                Ngay8.WidthF = ng8.WidthF;
                Ngay9.WidthF = ng9.WidthF;
                Ngay10.WidthF = ng10.WidthF;
                Ngay11.WidthF = ng11.WidthF;
                Ngay12.WidthF = ng12.WidthF;
                Ngay13.WidthF = ng13.WidthF;
                Ngay14.WidthF = ng14.WidthF;
                Ngay15.WidthF = ng15.WidthF;
                Ngay16.WidthF = ng16.WidthF;
                Ngay17.WidthF = ng17.WidthF;
                Ngay18.WidthF = ng18.WidthF;
                Ngay19.WidthF = ng19.WidthF;
                Ngay20.WidthF = ng20.WidthF;
                Ngay21.WidthF = ng21.WidthF;
                Ngay22.WidthF = ng22.WidthF;
                Ngay23.WidthF = ng23.WidthF;
                Ngay24.WidthF = ng24.WidthF;
                Ngay25.WidthF = ng25.WidthF;
                Ngay26.WidthF = ng26.WidthF;
                Ngay27.WidthF = ng27.WidthF;
                Ngay28.WidthF = ng28.WidthF;
                Ngay29.WidthF = ng29.WidthF;
                TongCel.WidthF = (float)42.89;

                //
                nameTong.WidthF = (float)140.98;
                congFooter.WidthF = (float)64.84;
                tg1.WidthF = Ngay1.WidthF;
                tg2.WidthF = Ngay2.WidthF;
                tg3.WidthF = Ngay3.WidthF;
                tg4.WidthF = Ngay4.WidthF;
                tg5.WidthF = Ngay5.WidthF;
                tg6.WidthF = Ngay6.WidthF;
                tg7.WidthF = Ngay7.WidthF;
                tg8.WidthF = Ngay8.WidthF;
                tg9.WidthF = Ngay9.WidthF;
                tg10.WidthF = Ngay10.WidthF;
                tg11.WidthF = Ngay11.WidthF;
                tg12.WidthF = Ngay12.WidthF;
                tg13.WidthF = Ngay13.WidthF;
                tg14.WidthF = Ngay14.WidthF;
                tg15.WidthF = Ngay15.WidthF;
                tg16.WidthF = Ngay16.WidthF;
                tg17.WidthF = Ngay17.WidthF;
                tg18.WidthF = Ngay18.WidthF;
                tg19.WidthF = Ngay19.WidthF;
                tg20.WidthF = Ngay20.WidthF;
                tg21.WidthF = Ngay21.WidthF;
                tg22.WidthF = Ngay22.WidthF;
                tg23.WidthF = Ngay23.WidthF;
                tg24.WidthF = Ngay24.WidthF;
                tg25.WidthF = Ngay25.WidthF;
                tg26.WidthF = Ngay26.WidthF;
                tg27.WidthF = Ngay27.WidthF;
                tg28.WidthF = Ngay28.WidthF;
                tg29.WidthF = Ngay29.WidthF;
                tgSum.WidthF = (float)42.89;
            }
            else if (ngaycuathang_ == 30)
            {
                if (_flag_31 == "undelete")
                {
                    xrTable2.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    xrTable3.DeleteColumn(tg31);

                    _flag_31 = "deleted";
                }

                //
                hoTen.WidthF = nameTong.WidthF = hoTenHeader.WidthF = xrTableCell35.WidthF = xrTableCell1.WidthF;
                congFooter.WidthF = cong.WidthF = congHeader.WidthF = xrTableCell36.WidthF = xrTableCell2.WidthF;
                //xrTableCell3.WidthF = xrTableCell3.WidthF - (float)0.828479;
                //
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    Ds_NgayTitle[i].WidthF = (float)25.247899;
                    Ds_Ngay_Header[i].WidthF = (float)25.247899;
                }
                //ng1.WidthF = ng2.WidthF = ng3.WidthF = ng4.WidthF = ng5.WidthF;
                //Ngay6.WidthF = ng6.WidthF;
                //Ngay7.WidthF = ng7.WidthF;
                //Ngay8.WidthF = ng8.WidthF;
                //Ngay9.WidthF = ng9.WidthF;
                //Ngay10.WidthF = ng10.WidthF;
                //Ngay11.WidthF = ng11.WidthF;
                //Ngay12.WidthF = ng12.WidthF;
                //Ngay13.WidthF = ng13.WidthF;
                //Ngay14.WidthF = ng14.WidthF;
                //Ngay15.WidthF = ng15.WidthF;
                //Ngay16.WidthF = ng16.WidthF;
                //Ngay17.WidthF = ng17.WidthF;
                //Ngay18.WidthF = ng18.WidthF;
                //Ngay19.WidthF = ng19.WidthF;
                //Ngay20.WidthF = ng20.WidthF;
                //Ngay21.WidthF = ng21.WidthF;
                //Ngay22.WidthF = ng22.WidthF;
                //Ngay23.WidthF = ng23.WidthF;
                //Ngay24.WidthF = ng24.WidthF;
                //Ngay25.WidthF = ng25.WidthF;
                //Ngay26.WidthF = ng26.WidthF;
                //Ngay27.WidthF = ng27.WidthF;
                //Ngay28.WidthF = ng28.WidthF;
                //Ngay29.WidthF = ng29.WidthF;
                //Ngay30.WidthF = ng30.WidthF;
                //
                Ngay1.WidthF = ng1.WidthF;
                Ngay2.WidthF = ng2.WidthF;
                Ngay3.WidthF = ng3.WidthF;
                Ngay4.WidthF = ng4.WidthF;
                Ngay5.WidthF = ng5.WidthF;
                Ngay6.WidthF = ng6.WidthF;
                Ngay7.WidthF = ng7.WidthF;
                Ngay8.WidthF = ng8.WidthF;
                Ngay9.WidthF = ng9.WidthF;
                Ngay10.WidthF = ng10.WidthF;
                Ngay11.WidthF = ng11.WidthF;
                Ngay12.WidthF = ng12.WidthF;
                Ngay13.WidthF = ng13.WidthF;
                Ngay14.WidthF = ng14.WidthF;
                Ngay15.WidthF = ng15.WidthF;
                Ngay16.WidthF = ng16.WidthF;
                Ngay17.WidthF = ng17.WidthF;
                Ngay18.WidthF = ng18.WidthF;
                Ngay19.WidthF = ng19.WidthF;
                Ngay20.WidthF = ng20.WidthF;
                Ngay21.WidthF = ng21.WidthF;
                Ngay22.WidthF = ng22.WidthF;
                Ngay23.WidthF = ng23.WidthF;
                Ngay24.WidthF = ng24.WidthF;
                Ngay25.WidthF = ng25.WidthF;
                Ngay26.WidthF = ng26.WidthF;
                Ngay27.WidthF = ng27.WidthF;
                Ngay28.WidthF = ng28.WidthF;
                Ngay29.WidthF = ng29.WidthF;
                Ngay30.WidthF = ng30.WidthF;

                //
                tg1.WidthF = Ngay1.WidthF;
                tg2.WidthF = Ngay2.WidthF;
                tg3.WidthF = Ngay3.WidthF;
                tg4.WidthF = Ngay4.WidthF;
                tg5.WidthF = Ngay5.WidthF;
                tg6.WidthF = Ngay6.WidthF;
                tg7.WidthF = Ngay7.WidthF;
                tg8.WidthF = Ngay8.WidthF;
                tg9.WidthF = Ngay9.WidthF;
                tg10.WidthF = Ngay10.WidthF;
                tg11.WidthF = Ngay11.WidthF;
                tg12.WidthF = Ngay12.WidthF;
                tg13.WidthF = Ngay13.WidthF;
                tg14.WidthF = Ngay14.WidthF;
                tg15.WidthF = Ngay15.WidthF;
                tg16.WidthF = Ngay16.WidthF;
                tg17.WidthF = Ngay17.WidthF;
                tg18.WidthF = Ngay18.WidthF;
                tg19.WidthF = Ngay19.WidthF;
                tg20.WidthF = Ngay20.WidthF;
                tg21.WidthF = Ngay21.WidthF;
                tg22.WidthF = Ngay22.WidthF;
                tg23.WidthF = Ngay23.WidthF;
                tg24.WidthF = Ngay24.WidthF;
                tg25.WidthF = Ngay25.WidthF;
                tg26.WidthF = Ngay26.WidthF;
                tg27.WidthF = Ngay27.WidthF;
                tg28.WidthF = Ngay28.WidthF;
                tg29.WidthF = Ngay29.WidthF;
                tg30.WidthF = Ngay30.WidthF;
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

                    //footer
                    Ds_Ngay_Footer[i].BackColor = Color.LightGray;
                    Ds_Ngay_Footer[i].ForeColor = Color.Red;
                }
            }
        }

    }
}
