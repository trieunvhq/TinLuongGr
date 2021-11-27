using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Tr_PrintPhieuKeToanVAT : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable _data;
        public Tr_PrintPhieuKeToanVAT(DataTable data)
        {
            _data = data;
            InitializeComponent();
            pNgay.Value = DateTime.Now;
            pLapBieu.Value = _data.Rows[0]["TenNhanVien"].ToString();
            pTongHop.Value = _data.Rows[0]["TenNhanVien"].ToString();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ////Load label ngay thang nam header:
            //if (_thang > 9)
            //{
            //    xrlbDateHead.Text = " Tháng " + _thang
            //                        + " năm " + _nam;
            //}
            //else
            //{
            //    xrlbDateHead.Text = " Tháng 0" + _thang
            //                        + " năm " + _nam;
            //}

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

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
