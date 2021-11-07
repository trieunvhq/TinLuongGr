using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu : DevExpress.XtraReports.UI.XtraReport
    {

        private void NXT_Kho_NPL()
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
                //pNguoiLap.Value = "Phạm Thị Lành";
                pTruongPhong.Value = "Phạm Kim Diện";
                pGiamDoc.Value = "Bùi Ngọc Kiên";
            }
            pKho.Value = "Kho Nguyên phụ liệu";
            DateTime denngay = frmChiTietNhapXuatTon_MotVatTu.mdadenngay;
            DateTime tungay = frmChiTietNhapXuatTon_MotVatTu.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = frmChiTietNhapXuatTon_MotVatTu.miID_VTHH;
            DataTable dtxx = cls.SelectOne();    
            pTenVT.Value = "Mã: " + cls.sMaVT.Value + ":  " + cls.sTenVTHH.Value + "  (" + cls.sDonViTinh.Value + ")";
        }
        private void NXT_Kho_BanThanhPham()
        {
            pKho.Value = "Kho Bán Thành phẩm";
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
                //pNguoiLap.Value = "Phạm Thị Lành";
                pTruongPhong.Value = "Phạm Kim Diện";
                pGiamDoc.Value = "Bùi Ngọc Kiên";
            }

            DateTime denngay = frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mdadenngay;
            DateTime tungay = frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.miID_VTHH;
            DataTable dtxx = cls.SelectOne();
            pTenVT.Value = "Mã: " + cls.sMaVT.Value + ":  " + cls.sTenVTHH.Value + "  (" + cls.sDonViTinh.Value + ")";
           // pDauKy.Value = "Tồn đầu kỳ: " + frmBaoCaoNhapXuatTon_BanThanhPham.msoluongTonDauKy.ToString() + "       Giá trị: " + frmBaoCaoNhapXuatTon_BanThanhPham.mGiaTriTonDauKy.ToString() + "";
        }

        private void NXT_Kho_ThanhPham()
        {
            pKho.Value = "Kho Thành phẩm";
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
                pNguoiLap.Value = "";
                pTruongPhong.Value = "Phạm Kim Diện";
                pGiamDoc.Value = "Bùi Ngọc Kiên";
            }

            DateTime denngay = frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.mdadenngay;
            DateTime tungay = frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.miID_VTHH;
            DataTable dtxx = cls.SelectOne();
            pTenVT.Value = "Mã: " + cls.sMaVT.Value + ":  " + cls.sTenVTHH.Value + "  (" + cls.sDonViTinh.Value + ")";
            //pDauKy.Value = "Tồn đầu kỳ: " + frmBaoCaoNXT_KhoThanhPham.msoluongTonDauKy.ToString() + "       Giá trị: " + frmBaoCaoNXT_KhoThanhPham.mGiaTriTonDauKy.ToString() + "";
        }
        private void NXT_Kho_GapDan()
        {
            pKho.Value = "Kho Gấp dán";
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

            DateTime denngay = GapDan_frmChiTietNhapXuatTon_MotVatTu.mdadenngay;
            DateTime tungay = GapDan_frmChiTietNhapXuatTon_MotVatTu.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";           
            pTenVT.Value = "Mã: " + GapDan_frmChiTietNhapXuatTon_MotVatTu.msMaVT + ":  " + GapDan_frmChiTietNhapXuatTon_MotVatTu.msTenVTHH + "  (" + GapDan_frmChiTietNhapXuatTon_MotVatTu.msDonViTinh + ")";
            //pDauKy.Value = "Tồn đầu kỳ: " + GapDan_frmChiTietNhapXuatTon_MotVatTu.msoluongTonDauKy.ToString() + "       Giá trị: " + GapDan_frmChiTietNhapXuatTon_MotVatTu.mGiaTriTonDauKy.ToString() + "";
        }

        public Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            

            if (frmChiTietNhapXuatTon_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                NXT_Kho_NPL();
            if (frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                NXT_Kho_BanThanhPham();
            if (frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                NXT_Kho_ThanhPham();
            if (GapDan_frmChiTietNhapXuatTon_MotVatTu.mbPrint == true)
                NXT_Kho_GapDan();
        }

    }
}
