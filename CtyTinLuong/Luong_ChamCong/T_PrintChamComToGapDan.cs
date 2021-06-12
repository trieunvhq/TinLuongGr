using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class T_PrintChamCongToGapDan : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        List<XRTableCell> Ds_Ngay = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Header = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Footer = new List<XRTableCell>();

        public T_PrintChamCongToGapDan(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;

            InitializeComponent();
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


            //setThu();
            // setMauTableDetail();
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

            //lbNgayThangNam.Text = ng2.WidthF.ToString();

        }

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
                    Tr_xrTbHeader.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    xrTable2.DeleteColumn(tg31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    Tr_xrTbHeader.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    xrTable2.DeleteColumn(tg30);
                    _flag_30 = "deleted";
                }

                //
                if (_flag_29 == "undelete")
                {
                    Tr_xrTbHeader.DeleteColumn(ng29);
                    xrTable1.DeleteColumn(Ngay29);
                    xrTable2.DeleteColumn(tg29);
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
                nameCong.WidthF = (float)64.84;
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
                    Tr_xrTbHeader.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    xrTable2.DeleteColumn(tg31);
                    _flag_31 = "deleted";
                }

                //
                if (_flag_30 == "undelete")
                {
                    Tr_xrTbHeader.DeleteColumn(ng30);
                    xrTable1.DeleteColumn(Ngay30);
                    xrTable2.DeleteColumn(tg30);
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
                nameCong.WidthF = (float)64.84;
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
                    Tr_xrTbHeader.DeleteColumn(ng31);
                    xrTable1.DeleteColumn(Ngay31);
                    xrTable2.DeleteColumn(tg31);

                    _flag_31 = "deleted";
                }

                //
                hoTen.WidthF = (float)140.98;
                cong.WidthF = (float)64.84;
                Ngay1.WidthF = (float)25.1299;
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
                TongCel.WidthF = (float)42.89;

                //
                nameTong.WidthF = (float)140.98;
                nameCong.WidthF = (float)64.84;
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
                tgSum.WidthF = (float)42.89;
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

        //set mau bang du lieu:
        public void setMauTableDetail2()
        {
            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;
            string thu_ = "";

            thu_ = LayThu(new DateTime(_nam, _thang, (1)));
            if (thu_.Contains("CN"))
            {
                Ngay1.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (2)));
            if (thu_.Contains("CN"))
            {
                Ngay2.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (3)));
            if (thu_.Contains("CN"))
            {
                Ngay3.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (4)));
            if (thu_.Contains("CN"))
            {
                Ngay4.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (5)));
            if (thu_.Contains("CN"))
            {
                Ngay5.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (6)));
            if (thu_.Contains("CN"))
            {
                Ngay6.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (7)));
            if (thu_.Contains("CN"))
            {
                Ngay7.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (8)));
            if (thu_.Contains("CN"))
            {
                Ngay8.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (9)));
            if (thu_.Contains("CN"))
            {
                Ngay9.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (10)));
            if (thu_.Contains("CN"))
            {
                Ngay10.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (11)));
            if (thu_.Contains("CN"))
            {
                Ngay11.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (12)));
            if (thu_.Contains("CN"))
            {
                Ngay12.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (13)));
            if (thu_.Contains("CN"))
            {
                Ngay13.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (14)));
            if (thu_.Contains("CN"))
            {
                Ngay14.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (15)));
            if (thu_.Contains("CN"))
            {
                Ngay15.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (16)));
            if (thu_.Contains("CN"))
            {
                Ngay16.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (17)));
            if (thu_.Contains("CN"))
            {
                Ngay17.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (18)));
            if (thu_.Contains("CN"))
            {
                Ngay18.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (19)));
            if (thu_.Contains("CN"))
            {
                Ngay19.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (20)));
            if (thu_.Contains("CN"))
            {
                Ngay20.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (21)));
            if (thu_.Contains("CN"))
            {
                Ngay21.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (22)));
            if (thu_.Contains("CN"))
            {
                Ngay22.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (23)));
            if (thu_.Contains("CN"))
            {
                Ngay23.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (24)));
            if (thu_.Contains("CN"))
            {
                Ngay24.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (25)));
            if (thu_.Contains("CN"))
            {
                Ngay25.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (26)));
            if (thu_.Contains("CN"))
            {
                Ngay26.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (27)));
            if (thu_.Contains("CN"))
            {
                Ngay27.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (28)));
            if (thu_.Contains("CN"))
            {
                Ngay28.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(_nam, _thang, (29)));
            if (thu_.Contains("CN"))
            {
                Ngay29.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(_nam, _thang, (30)));
            if (thu_.Contains("CN"))
            {
                Ngay30.BackColor = Color.LightGray;
            }

        }
    }
}
