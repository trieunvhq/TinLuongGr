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
        List<XRTableCell> Ds_Ngay = new List<XRTableCell>();
        List<XRTableCell> Ds_Ngay_Header = new List<XRTableCell>();
        public T_PrintChamCongToGapDan()
        {
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

            if (DateTime.Now.Month <= 9) pMonth.Value = "0" + DateTime.Now.Month.ToString();
            else pMonth.Value = DateTime.Now.Month.ToString();
            pYear.Value = DateTime.Now.Year;
            //setThu();
           // setMauTableDetail();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            setThu();
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

        private string _flag_28 = "undelete";
        private string _flag_29 = "undelete";
        private string _flag_30 = "undelete";
        private string _flag_31 = "undelete";


        public void setThu()
        {
            //DateTime dtnow = DateTime.Now;
            // 
            int thang = Convert.ToInt32(pMonth.Value);
            int nam = Convert.ToInt32(pYear.Value);

            int ngaycuathang_ = (((new DateTime(nam, thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            //
            if (ngaycuathang_ == 28)
            {

            }
            else if (ngaycuathang_ == 29)
            {

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
                Ngay1.WidthF = (float)25.1;
                Ngay2.WidthF = (float)25.1;
                Ngay3.WidthF = (float)25.1;
                Ngay4.WidthF = (float)25.1;
                Ngay5.WidthF = (float)25.1;
                Ngay6.WidthF = (float)25.1;
                Ngay7.WidthF = (float)25.1;
                Ngay8.WidthF = (float)25.1;
                Ngay9.WidthF = (float)25.1;
                Ngay10.WidthF = (float)25.1;
                Ngay11.WidthF = (float)24.5;
                Ngay12.WidthF = (float)25.1;
                Ngay13.WidthF = (float)25.5;
                Ngay14.WidthF = (float)25.1;
                Ngay15.WidthF = (float)25.1;
                Ngay16.WidthF = (float)25.1;
                Ngay17.WidthF = (float)25.1;
                Ngay18.WidthF = (float)25.1;
                Ngay19.WidthF = (float)25.1;
                Ngay20.WidthF = (float)25.1;
                Ngay21.WidthF = (float)25.1;
                Ngay22.WidthF = (float)25.1;
                Ngay23.WidthF = (float)25.1;
                Ngay24.WidthF = (float)25.1;
                Ngay25.WidthF = (float)25.1;
                Ngay26.WidthF = (float)25.1;
                Ngay27.WidthF = (float)25.1;
                Ngay28.WidthF = (float)25.1;
                Ngay29.WidthF = (float)25.1;
                Ngay30.WidthF = (float)25.1;
                TongCel.WidthF = (float)42.89;

                //
                nameTong.WidthF = (float)140.98;
                nameCong.WidthF = (float)64.84;
                tg1.WidthF = (float)25.1;
                tg2.WidthF = (float)25.1;
                tg3.WidthF = (float)25.1;
                tg4.WidthF = (float)25.1;
                tg5.WidthF = (float)25.1;
                tg6.WidthF = (float)25.1;
                tg7.WidthF = (float)25.1;
                tg8.WidthF = (float)25.1;
                tg9.WidthF = (float)25.1;
                tg10.WidthF = (float)25.1;
                tg11.WidthF = (float)24.5;
                tg12.WidthF = (float)25.1;
                tg13.WidthF = (float)25.5;
                tg14.WidthF = (float)25.1;
                tg15.WidthF = (float)25.1;
                tg16.WidthF = (float)25.1;
                tg17.WidthF = (float)25.1;
                tg18.WidthF = (float)25.1;
                tg19.WidthF = (float)25.1;
                tg20.WidthF = (float)25.1;
                tg21.WidthF = (float)25.1;
                tg22.WidthF = (float)25.1;
                tg23.WidthF = (float)25.1;
                tg24.WidthF = (float)25.1;
                tg25.WidthF = (float)25.1;
                tg26.WidthF = (float)25.1;
                tg27.WidthF = (float)25.1;
                tg28.WidthF = (float)25.1;
                tg29.WidthF = (float)25.1;
                tg30.WidthF = (float)25.1;
                tgSum.WidthF = (float)42.89;

            }
            else if (ngaycuathang_ == 31)
            {
                if (_flag_31 == "deleted")
                {
                    _flag_31 = "undelete";
                }
            }

            //Tô màu Chủ nhật:
            for (int i = 0; i < ngaycuathang_; ++i)
            {
                Ds_Ngay_Header[i].Text = LayThu(new DateTime(nam, thang, (i + 1)));
                if (Ds_Ngay_Header[i].Text.Contains("CN"))
                {
                    Ds_Ngay_Header[i].BackColor = Color.LightGray;
                    Ds_Ngay_Header[i].BackColor = Color.LightGray;
                    Ds_Ngay_Header[i].ForeColor = Color.Red;
                    Ds_Ngay_Header[i].ForeColor = Color.Red;
                }
            }

            for (int i = 0; i < ngaycuathang_; ++i)
            {
                string thu_ = LayThu(new DateTime(nam, thang, (i + 1)));
                if (thu_.Contains("CN"))
                {
                    Ds_Ngay[i].BackColor = Color.LightGray;
                    Ds_Ngay[i].ForeColor = Color.Red;
                }
            }

            
            //TongCel.WidthF = (float)42.39;
            //KyNhan.WidthF = (float)54.22 + (float)24.28;

            if (ngaycuathang_ == 28)
            {
            }
            else if (ngaycuathang_ == 29)
            {
            }
            else if (ngaycuathang_ == 30)
            {
            }
            else if (ngaycuathang_ == 31)
            {
                //cong.WidthF = (float)64.84;
                //hoTen.WidthF = (float)140.98;
                //TongCel.WidthF = (float)42.39;
                //TongCel.WidthF = (float)54.22;
            }
            ////
            //DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
            //int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;
            //string thu_ = LayThu(date_);

            //ng1.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (1)));
            //if (ng1.Text.Contains("CN"))
            //{
            //    ng1.BackColor = Color.LightGray;
            //}

            //ng2.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (2)));
            //if (ng2.Text.Contains("CN"))
            //{
            //    ng2.BackColor = Color.LightGray;
            //}

            //ng3.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (3)));
            //if (ng3.Text.Contains("CN"))
            //{
            //    ng3.BackColor = Color.LightGray;
            //}


            //ng4.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (4)));
            //if (ng4.Text.Contains("CN"))
            //{
            //    ng4.BackColor = Color.LightGray;
            //}


            //ng5.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (5)));
            //if (ng5.Text.Contains("CN"))
            //{
            //    ng5.BackColor = Color.LightGray;
            //}


            //ng6.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (6)));
            //if (ng6.Text.Contains("CN"))
            //{
            //    ng6.BackColor = Color.LightGray;
            //}


            //ng7.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (7)));
            //if (ng7.Text.Contains("CN"))
            //{
            //    ng7.BackColor = Color.LightGray;
            //}


            //ng8.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (8)));
            //if (ng8.Text.Contains("CN"))
            //{
            //    ng8.BackColor = Color.LightGray;
            //}


            //ng9.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (9)));
            //if (ng9.Text.Contains("CN"))
            //{
            //    ng9.BackColor = Color.LightGray;
            //}

            //ng10.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (10)));
            //if (ng10.Text.Contains("CN"))
            //{
            //    ng10.BackColor = Color.LightGray;
            //}

            //ng11.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (11)));
            //if (ng11.Text.Contains("CN"))
            //{
            //    ng11.BackColor = Color.LightGray;
            //}

            //ng12.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (12)));
            //if (ng12.Text.Contains("CN"))
            //{
            //    ng12.BackColor = Color.LightGray;
            //}

            //ng13.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (13)));
            //if (ng13.Text.Contains("CN"))
            //{
            //    ng13.BackColor = Color.LightGray;
            //}


            //ng14.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (14)));
            //if (ng14.Text.Contains("CN"))
            //{
            //    ng14.BackColor = Color.LightGray;
            //}


            //ng15.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (15)));
            //if (ng15.Text.Contains("CN"))
            //{
            //    ng15.BackColor = Color.LightGray;
            //}


            //ng16.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (16)));
            //if (ng16.Text.Contains("CN"))
            //{
            //    ng16.BackColor = Color.LightGray;
            //}


            //ng17.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (17)));
            //if (ng17.Text.Contains("CN"))
            //{
            //    ng17.BackColor = Color.LightGray;
            //}


            //ng18.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (18)));
            //if (ng18.Text.Contains("CN"))
            //{
            //    ng18.BackColor = Color.LightGray;
            //}


            //ng19.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (19)));
            //if (ng19.Text.Contains("CN"))
            //{
            //    ng19.BackColor = Color.LightGray;
            //}

            //ng20.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (20)));
            //if (ng20.Text.Contains("CN"))
            //{
            //    ng20.BackColor = Color.LightGray;
            //}


            //ng21.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (21)));
            //if (ng21.Text.Contains("CN"))
            //{
            //    ng21.BackColor = Color.LightGray;
            //}

            //ng22.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (22)));
            //if (ng22.Text.Contains("CN"))
            //{
            //    ng22.BackColor = Color.LightGray;
            //}

            //ng23.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (23)));
            //if (ng23.Text.Contains("CN"))
            //{
            //    ng23.BackColor = Color.LightGray;
            //}


            //ng24.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (24)));
            //if (ng24.Text.Contains("CN"))
            //{
            //    ng24.BackColor = Color.LightGray;
            //}


            //ng25.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (25)));
            //if (ng25.Text.Contains("CN"))
            //{
            //    ng25.BackColor = Color.LightGray;
            //}


            //ng26.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (26)));
            //if (ng26.Text.Contains("CN"))
            //{
            //    ng26.BackColor = Color.LightGray;
            //}


            //ng27.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (27)));
            //if (ng27.Text.Contains("CN"))
            //{
            //    ng27.BackColor = Color.LightGray;
            //}


            //ng28.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (28)));
            //if (ng28.Text.Contains("CN"))
            //{
            //    ng28.BackColor = Color.LightGray;
            //}


            //ng29.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (29)));
            //if (ng29.Text.Contains("CN"))
            //{
            //    ng29.BackColor = Color.LightGray;
            //}

            //ng30.Text = LayThu(new DateTime(dtnow.Year, dtnow.Month, (30)));
            //if (ng30.Text.Contains("CN"))
            //{
            //    ng30.BackColor = Color.LightGray;
            //}

        }

        //set mau bang du lieu:
        public void setMauTableDetail2()
        {
            DateTime dtnow = DateTime.Now;
            DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
            int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;
            string thu_ = "";

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (1)));
            if (thu_.Contains("CN"))
            {
                Ngay1.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (2)));
            if (thu_.Contains("CN"))
            {
                Ngay2.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (3)));
            if (thu_.Contains("CN"))
            {
                Ngay3.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (4)));
            if (thu_.Contains("CN"))
            {
                Ngay4.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (5)));
            if (thu_.Contains("CN"))
            {
                Ngay5.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (6)));
            if (thu_.Contains("CN"))
            {
                Ngay6.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (7)));
            if (thu_.Contains("CN"))
            {
                Ngay7.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (8)));
            if (thu_.Contains("CN"))
            {
                Ngay8.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (9)));
            if (thu_.Contains("CN"))
            {
                Ngay9.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (10)));
            if (thu_.Contains("CN"))
            {
                Ngay10.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (11)));
            if (thu_.Contains("CN"))
            {
                Ngay11.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (12)));
            if (thu_.Contains("CN"))
            {
                Ngay12.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (13)));
            if (thu_.Contains("CN"))
            {
                Ngay13.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (14)));
            if (thu_.Contains("CN"))
            {
                Ngay14.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (15)));
            if (thu_.Contains("CN"))
            {
                Ngay15.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (16)));
            if (thu_.Contains("CN"))
            {
                Ngay16.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (17)));
            if (thu_.Contains("CN"))
            {
                Ngay17.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (18)));
            if (thu_.Contains("CN"))
            {
                Ngay18.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (19)));
            if (thu_.Contains("CN"))
            {
                Ngay19.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (20)));
            if (thu_.Contains("CN"))
            {
                Ngay20.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (21)));
            if (thu_.Contains("CN"))
            {
                Ngay21.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (22)));
            if (thu_.Contains("CN"))
            {
                Ngay22.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (23)));
            if (thu_.Contains("CN"))
            {
                Ngay23.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (24)));
            if (thu_.Contains("CN"))
            {
                Ngay24.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (25)));
            if (thu_.Contains("CN"))
            {
                Ngay25.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (26)));
            if (thu_.Contains("CN"))
            {
                Ngay26.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (27)));
            if (thu_.Contains("CN"))
            {
                Ngay27.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (28)));
            if (thu_.Contains("CN"))
            {
                Ngay28.BackColor = Color.LightGray;
            }


            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (29)));
            if (thu_.Contains("CN"))
            {
                Ngay29.BackColor = Color.LightGray;
            }

            thu_ = LayThu(new DateTime(dtnow.Year, dtnow.Month, (30)));
            if (thu_.Contains("CN"))
            {
                Ngay30.BackColor = Color.LightGray;
            }

        }
    }
}
