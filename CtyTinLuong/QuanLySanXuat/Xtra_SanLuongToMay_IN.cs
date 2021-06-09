using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_SanLuongToMay_IN : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_SanLuongToMay_IN()
        {
            InitializeComponent();
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
            if (SanLuong_To_May_IN.xxximay_in_1_Cat_2_dot_3 == 1)
                pTieuDe.Value = "BÁO CÁO SẢN LƯỢNG TỔ MÁY IN THÁNG " + xxtungay.ToString("MM/yyyy") + "";
            else if (SanLuong_To_May_IN.xxximay_in_1_Cat_2_dot_3 == 2)
                pTieuDe.Value = "BÁO CÁO SẢN LƯỢNG TỔ MÁY CẮT THÁNG " + xxtungay.ToString("MM/yyyy") + "";
            pNgayThang.Value = "Từ ngày "+xxtungay.ToString("dd/MM/yyyy")+ " đến ngày " + xxdenngay.ToString("dd/MM/yyyy") + "";
        }
    }
}
