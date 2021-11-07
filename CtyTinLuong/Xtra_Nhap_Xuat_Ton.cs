using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_Nhap_Xuat_Ton : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_Nhap_Xuat_Ton()
        {
            InitializeComponent();
        }
        private void NXT_Kho_NPL()
        {
            pKho.Value = "Kho Nguyên Phụ liệu";
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
                //pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = frmBaoCaoNXT.mdadenngay;
            DateTime tungay = frmBaoCaoNXT.mdatungay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        private void NXT_Kho_BanThanhPham()
        {
            pKho.Value = "Kho Bán thành phẩm";
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
                //pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = frmBaoCaoNhapXuatTon_BanThanhPham.mdadenngay;
            DateTime tungay = frmBaoCaoNhapXuatTon_BanThanhPham.mdatungay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        private void NXT_Kho_ThanhPham()
        {
            pKho.Value = "Kho Thành phẩm";
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
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = frmBaoCaoNXT_KhoThanhPham.mdadenngay;
            DateTime tungay = frmBaoCaoNXT_KhoThanhPham.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        private void NXT_Kho_GapDan()
        {
            pKho.Value = "Kho Gấp dán";
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

            DateTime denngay = DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.mdadenngay;
            DateTime tungay = DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        private void PageHeader_AfterPrint(object sender, EventArgs e)
        {
            if (frmBaoCaoNXT.mbPrint_NXT_Kho_NPL == true)
            {
                NXT_Kho_NPL();
            }
            if (frmBaoCaoNhapXuatTon_BanThanhPham.mbPrint_NXT_Kho_BTP == true)
            {
                NXT_Kho_BanThanhPham();
            }
            if (frmBaoCaoNXT_KhoThanhPham.mbPrint_NXT_Kho_NPL == true)
            {
                NXT_Kho_ThanhPham();
            }
            if (DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.mbPrint == true)
            {
                NXT_Kho_GapDan();
            }
            //UCDaiLy_GapDan_baocao_NXT
           
        }

    }
}
