using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;


namespace CtyTinLuong
{
    public partial class Tr_PrintBTTL_ToDot : DevExpress.XtraReports.UI.XtraReport
    {

        List<XRTableCell> _DsVthhTitle = new List<XRTableCell>();
        List<XRTableCell> _DsValue = new List<XRTableCell>();
        List<XRTableCell> _DsValue_Footer = new List<XRTableCell>();
        private int[] _colDelete;
        private int _nam, _thang;

        public Tr_PrintBTTL_ToDot(int thang, int nam, int[] colDelete)
        {
            _thang = thang;
            _nam = nam;
            _colDelete = colDelete;

            InitializeComponent();

            //
            _DsVthhTitle.Add(h1);
            _DsVthhTitle.Add(h2);
            _DsVthhTitle.Add(h3);
            _DsVthhTitle.Add(h4);
            _DsVthhTitle.Add(h5);
            _DsVthhTitle.Add(h6);
            _DsVthhTitle.Add(h7);
            _DsVthhTitle.Add(h8);
            _DsVthhTitle.Add(h9);
            _DsVthhTitle.Add(h10);
            _DsVthhTitle.Add(h11);
            _DsVthhTitle.Add(h12);
            _DsVthhTitle.Add(h13);
            _DsVthhTitle.Add(h14);
            _DsVthhTitle.Add(h15);
            _DsVthhTitle.Add(h16);
            _DsVthhTitle.Add(h17);
            _DsVthhTitle.Add(h18); 
            _DsVthhTitle.Add(h19); 
            _DsVthhTitle.Add(h20);
            _DsVthhTitle.Add(h21);
            _DsVthhTitle.Add(h22);
            _DsVthhTitle.Add(h23);
            _DsVthhTitle.Add(h24);
            _DsVthhTitle.Add(h25);
            _DsVthhTitle.Add(h26);
            _DsVthhTitle.Add(h27);
            _DsVthhTitle.Add(h28);
            _DsVthhTitle.Add(h29);
            _DsVthhTitle.Add(h30);
            _DsVthhTitle.Add(h31);
            _DsVthhTitle.Add(h32);

            //
            _DsValue.Add(c1);
            _DsValue.Add(c2);
            _DsValue.Add(c3);
            _DsValue.Add(c4);
            _DsValue.Add(c5);
            _DsValue.Add(c6);
            _DsValue.Add(c7);
            _DsValue.Add(c8);
            _DsValue.Add(c9);
            _DsValue.Add(c10);
            _DsValue.Add(c11);
            _DsValue.Add(c12);
            _DsValue.Add(c13);
            _DsValue.Add(c14);
            _DsValue.Add(c15);
            _DsValue.Add(c16);
            _DsValue.Add(c17);
            _DsValue.Add(c18);
            _DsValue.Add(c19);
            _DsValue.Add(c20);
            _DsValue.Add(c21);
            _DsValue.Add(c22);
            _DsValue.Add(c23);
            _DsValue.Add(c24);
            _DsValue.Add(c25);
            _DsValue.Add(c26);
            _DsValue.Add(c27);
            _DsValue.Add(c28);
            _DsValue.Add(c29);
            _DsValue.Add(c30);
            _DsValue.Add(c31);
            _DsValue.Add(c32);

            //
            _DsValue_Footer.Add(tg1);
            _DsValue_Footer.Add(tg2);
            _DsValue_Footer.Add(tg3);
            _DsValue_Footer.Add(tg4);
            _DsValue_Footer.Add(tg5);
            _DsValue_Footer.Add(tg6);
            _DsValue_Footer.Add(tg7);
            _DsValue_Footer.Add(tg8);
            _DsValue_Footer.Add(tg9);
            _DsValue_Footer.Add(tg10);
            _DsValue_Footer.Add(tg11);
            _DsValue_Footer.Add(tg12);
            _DsValue_Footer.Add(tg13);
            _DsValue_Footer.Add(tg14);
            _DsValue_Footer.Add(tg15);
            _DsValue_Footer.Add(tg16);
            _DsValue_Footer.Add(tg17);
            _DsValue_Footer.Add(tg18);
            _DsValue_Footer.Add(tg19);
            _DsValue_Footer.Add(tg20);
            _DsValue_Footer.Add(tg21);
            _DsValue_Footer.Add(tg22);
            _DsValue_Footer.Add(tg23);
            _DsValue_Footer.Add(tg24);
            _DsValue_Footer.Add(tg25);
            _DsValue_Footer.Add(tg26);
            _DsValue_Footer.Add(tg27);
            _DsValue_Footer.Add(tg28);
            _DsValue_Footer.Add(tg29);
            _DsValue_Footer.Add(tg30);
            _DsValue_Footer.Add(tg31);
            _DsValue_Footer.Add(tg32);
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            setThu();

            //
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


        //
        public void setThu()
        {
            //int[] colDelete = new int[32];
            //for (int i = 0; i < 32; i++)
            //{
            //    if (i%2 == 0)
            //        colDelete[i] = 0;
            //    else
            //        colDelete[i] = 1;
            //}

            int count = 0;
            for (int i = 31; i >=0; i--)
            {
                if (_colDelete[i] == 1)
                {
                    xrTable2.DeleteColumn(_DsVthhTitle[i]);
                    xrTable1.DeleteColumn(_DsValue[i]);
                    xrTable3.DeleteColumn(_DsValue_Footer[i]);
                }
                else
                    count++;
            }

            TongName.WidthF = Ngay.WidthF = hNgay.WidthF = xrTableCell4.WidthF = (float)42.84;
            congFooter.WidthF = DVT.WidthF = hDVT.WidthF = xrTableCell2.WidthF = (float)32.8;
            //
            float tmp = 0;
            float colw = (float)((52.88 + 30.82 * 32) / (count +1));
            for (int i = 0; i < 32; ++i)
            {
                if (_colDelete[i] == 0)
                {
                    _DsVthhTitle[i].WidthF = colw;
                    _DsValue[i].WidthF = colw;
                    _DsValue_Footer[i].WidthF = colw;
                    tmp += colw;
                }
            }
            hLoaiHang.WidthF = (float)tmp;
            ThanhTienSum.WidthF = ThanhTienRow.WidthF = htt.WidthF = xrTableCell34.WidthF = (float)colw;
        }
    }
}
