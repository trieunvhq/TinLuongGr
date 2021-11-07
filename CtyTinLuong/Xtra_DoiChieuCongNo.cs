using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_DoiChieuCongNo : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_DoiChieuCongNo()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap._miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pPhoGiamDoc.Value = dt.Rows[8]["HoTen"].ToString();
            }
            if(MuaHang_frmChiTietCongNo_MuaHang.mbPrint==true)
            {
                DateTime denngay = MuaHang_frmChiTietCongNo_MuaHang.mdadenngay;
                DateTime tungay = MuaHang_frmChiTietCongNo_MuaHang.mdatungay;
                pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";

                pTieuDeKH_NCC.Value = "Nhà cung cấp";
                pKhachHang_NCC.Value = MuaHang_frmChiTietCongNo_MuaHang.msTenKhachHang;
                //PtaiKhoanMe.Value = "331: Phải trả cho người bán";
                pTenTaiKhoan_Con.Value = ""+ MuaHang_frmChiTietCongNo_MuaHang.msSoTaiKhoan+ ": "+ MuaHang_frmChiTietCongNo_MuaHang.msTenTaiKhoan+ "";
            }

            if (BanHang_ChiTietCongNo.mbPrint == true)
            {
                DateTime denngay = BanHang_ChiTietCongNo.mdadenngay;
                DateTime tungay = BanHang_ChiTietCongNo.mdatungay;
                pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";

                pTieuDeKH_NCC.Value = "Khách hàng";
                pKhachHang_NCC.Value = BanHang_ChiTietCongNo.msTenTaiKhoan;
                //PtaiKhoanMe.Value = "331: Phải trả cho người bán";
                pTenTaiKhoan_Con.Value = "" + BanHang_ChiTietCongNo.msSoTaiKhoan + ": " + BanHang_ChiTietCongNo.msTenTaiKhoan + "";
            }
        }
    }
}
