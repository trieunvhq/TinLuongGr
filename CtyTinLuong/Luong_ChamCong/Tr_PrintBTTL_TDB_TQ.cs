using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;


namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_PrintBTTL_TDB_TQ : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        private bool _isTo1;

        public Tr_PrintBTTL_TDB_TQ(int thang, int nam, bool isTo1)
        {
            _isTo1 = isTo1;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
            pNgay.Value = DateTime.Now;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_isTo1) lbTitle.Text = "BẢNG THANH TOÁN LƯƠNG TỔ 1 ĐÓNG BAO";
            else lbTitle.Text = "BẢNG THANH TOÁN LƯƠNG TỔ 2 ĐÓNG BAO";

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

       
    }
}
