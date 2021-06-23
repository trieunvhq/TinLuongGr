using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Data;

namespace CtyTinLuong
{
    public partial class Tr_PrintBB_Ktra_DM_HHSX : DevExpress.XtraReports.UI.XtraReport
    {
        private DateTime _tuNgay, _denNgay;

        public Tr_PrintBB_Ktra_DM_HHSX(DateTime tuNgay, DateTime denNgay)
        {
            _tuNgay = tuNgay;
            _denNgay = denNgay;

            InitializeComponent();
            //
           
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            pNgay.Value = DateTime.Now.ToString("yyyy/MM/dd");

            //
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
