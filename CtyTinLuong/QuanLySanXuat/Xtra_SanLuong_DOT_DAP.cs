using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_SanLuong_DOT_DAP : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_SanLuong_DOT_DAP()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                DataTable dt = cls.SelectAll_ID_DangNhap();
                if (dt.Rows.Count > 0)
                {
                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                    pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();

                }
            }
            catch
            { }
            DateTime xxtungay = SanLuong_To_May_IN.mdatungay;
            DateTime xxdenngay = SanLuong_To_May_IN.mdadenngay;           
            pNgayThang.Value = "Từ ngày " + xxtungay.ToString("dd/MM/yyyy") + " đến ngày " + xxdenngay.ToString("dd/MM/yyyy") + "";
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                DataTable dt = cls.SelectAll_ID_DangNhap();
                if (dt.Rows.Count > 0)
                {
                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                    pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();

                }
            }
            catch
            { }
            DateTime xxtungay = SanLuong_To_May_IN.mdatungay;
            DateTime xxdenngay = SanLuong_To_May_IN.mdadenngay;
          
            pNgayThang.Value = "Từ ngày " + xxtungay.ToString("dd/MM/yyyy") + " đến ngày " + xxdenngay.ToString("dd/MM/yyyy") + "";
        }
    }
}
