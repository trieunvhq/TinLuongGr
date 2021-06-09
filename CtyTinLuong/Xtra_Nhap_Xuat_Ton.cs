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
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
                //txtNguoiLap.Text = dt.Rows[1]["HoTen"].ToString();
                //txtNguoiNhan.Text = dt.Rows[2]["HoTen"].ToString();
                //txtthuKhonewww.Text = dt.Rows[3]["HoTen"].ToString();
                //txtTruongPhongKH.Text = dt.Rows[4]["HoTen"].ToString();
                //txtKeToanTruong.Text = dt.Rows[5]["HoTen"].ToString();
                //txtGiamDoc.Text = dt.Rows[6]["HoTen"].ToString();
                //txtCaTruong.Text = dt.Rows[7]["HoTen"].ToString();
                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
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
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
                //txtNguoiLap.Text = dt.Rows[1]["HoTen"].ToString();
                //txtNguoiNhan.Text = dt.Rows[2]["HoTen"].ToString();
                //txtthuKhonewww.Text = dt.Rows[3]["HoTen"].ToString();
                //txtTruongPhongKH.Text = dt.Rows[4]["HoTen"].ToString();
                //txtKeToanTruong.Text = dt.Rows[5]["HoTen"].ToString();
                //txtGiamDoc.Text = dt.Rows[6]["HoTen"].ToString();
                //txtCaTruong.Text = dt.Rows[7]["HoTen"].ToString();
                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
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
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = UCDaiLy_GapDan_baocao_NXT.mdadenngay;
            DateTime tungay = UCDaiLy_GapDan_baocao_NXT.mdatungay;
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
            if (UCDaiLy_GapDan_baocao_NXT.mbPrint_NXT_Kho == true)
            {
                NXT_Kho_GapDan();
            }
            //UCDaiLy_GapDan_baocao_NXT
           
        }

    }
}
