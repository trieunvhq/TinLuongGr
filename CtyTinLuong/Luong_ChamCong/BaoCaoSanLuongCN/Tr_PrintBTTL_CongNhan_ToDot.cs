using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong
{
    public partial class Tr_PrintBTTL_CongNhan_ToDot : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        private bool _isTo1;
        public Tr_PrintBTTL_CongNhan_ToDot(int thang, int nam, bool isTo1)
        {
            _isTo1 = isTo1;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
            pNgay.Value = DateTime.Now;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_isTo1)
            {
                lbHeaderTitle.Text = "BẢNG THANH TOÁN TIỀN LƯƠNG TỔ ĐỘT 1";
            }
            else
            {
                lbHeaderTitle.Text = "BẢNG THANH TOÁN TIỀN LƯƠNG TỔ ĐỘT 2";
            }

            //Load label ngay thang nam header:
            if (_thang > 9)
            {
                xrlbDateHead.Text = " Tháng " + _thang
                                    + " năm " + _nam;
            }
            else
            {
                xrlbDateHead.Text = " Tháng 0" + _thang
                                    + " năm " + _nam;
            }

            // //Load label ngay ky footer:
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
