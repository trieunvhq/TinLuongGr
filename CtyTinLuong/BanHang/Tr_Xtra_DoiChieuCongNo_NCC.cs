using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Tr_Xtra_DoiChieuCongNo_NCC : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime _tuNgay, _denNgay;
        public Tr_Xtra_DoiChieuCongNo_NCC(DateTime tuNgay, DateTime denNgay)
        {
            _tuNgay = tuNgay;
            _denNgay = denNgay;
            InitializeComponent();
            pNgayThang.Value = DateTime.Now;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTongHop.Value = dt.Rows[4]["HoTen"].ToString();
                pPhoGiamDoc.Value = dt.Rows[8]["HoTen"].ToString();
            }

            lbTitleNgay.Text = "Từ ngày " + _tuNgay.ToString("dd/MM/yyyy") + " đến ngày " + _denNgay.ToString("dd/MM/yyyy") + "  ";

            //Load label ngay ky footer:
            DateTime d = Convert.ToDateTime(pNgayThang.Value);
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
