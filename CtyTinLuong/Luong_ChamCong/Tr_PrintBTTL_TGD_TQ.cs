using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_PrintBTTL_TGD_TQ : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        public Tr_PrintBTTL_TGD_TQ(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
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

            //


        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
