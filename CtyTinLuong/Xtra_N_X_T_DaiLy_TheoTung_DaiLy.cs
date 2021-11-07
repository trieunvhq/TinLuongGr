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
            cls.iID_DangNhap = frmDangNhap._miID_DangNhap;
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

            DateTime denngay = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdadenngay;
            DateTime tungay = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdatungay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            pDaiLy.Value = "Kho: " + frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.msTenDaiLy + " (" + frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.msMaDaiLy + ")";
        }
        public Xtra_N_X_T_DaiLy_TheoTung_DaiLy()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mbPrint_One == true)
                Print_N_X_T_DaiLy_TheoTung_DaiLy();
        }
    }
}
