using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_N_X_T_DaiLy_TheoTung_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        private void Print_N_X_T_DaiLy_TheoTung_DaiLy()
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

              
            }
            else
            {
              
            }

            DateTime denngay = UCDaiLy_NhapXuatTon_theoDaiLy.mdadenngay;
            DateTime tungay = UCDaiLy_NhapXuatTon_theoDaiLy.mdatungay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        public Xtra_N_X_T_DaiLy_TheoTung_DaiLy()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (UCDaiLy_NhapXuatTon_theoDaiLy.mbPrint_NXT_Kho == true)
            {
                Print_N_X_T_DaiLy_TheoTung_DaiLy();
            }
        }
    }
}
