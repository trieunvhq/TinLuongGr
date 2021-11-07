using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        private void NXT_Mot_vatTu_tu_DaiLy_ALL()
        {          

            DateTime denngay = DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdadenngay;
            DateTime tungay = DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";          
            pMaVT.Value = "Mã vật tư: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msMaVT + "";
            pTenVT.Value = "Tên vật tư: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msTenVT + "";
            pDVT.Value = "ĐVT: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msDonViTinh + "";

        }
        private void NXT_Mot_vatTu_tu_DaiLy_One()
        {

            DateTime denngay = DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdadenngay;
            DateTime tungay = DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            pMaVT.Value = "Mã vật tư: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msMaVT + "";
            pTenVT.Value = "Tên vật tư: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msTenVT + "";
            pDVT.Value = "ĐVT: " + DaiLy_frmChiTietNhapXuatTon_MotVatTu.msDonViTinh + "";
            pDaiLy.Value = "Kho: "+ DaiLy_frmChiTietNhapXuatTon_MotVatTu.msTenDaiLy+ " ("+ DaiLy_frmChiTietNhapXuatTon_MotVatTu.msMaDaiLy+ ")";
        }
        public Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy clsxxx = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            clsxxx.iID_DangNhap = frmDangNhap._miID_DangNhap;
            DataTable dt = clsxxx.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
            }
            else
            {
                pNguoiLap.Value = "Phạm Thị Lành";
                pTruongPhong.Value = "Phạm Kim Diện";
                pGiamDoc.Value = "Bùi Ngọc Kiên";
            }

            if (DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_ALL == true)
                NXT_Mot_vatTu_tu_DaiLy_ALL();
            if (DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_one == true)
                NXT_Mot_vatTu_tu_DaiLy_One();
        }
    }
}
