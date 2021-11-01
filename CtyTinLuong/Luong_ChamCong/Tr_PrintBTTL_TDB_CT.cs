using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;


namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_PrintBTTL_TDB_CT : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        private bool _isTo1;

        public Tr_PrintBTTL_TDB_CT(int thang, int nam, bool isTo1)
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
            if (_thang <= 9) lbThangNamTitle.Text = "Tháng 0" + _thang + " năm " + _nam;
            else lbThangNamTitle.Text = "Tháng " + _thang + " năm " + _nam;

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
