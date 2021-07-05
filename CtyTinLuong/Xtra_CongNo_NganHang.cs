using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_CongNo_NganHang : DevExpress.XtraReports.UI.XtraReport
    {

        private void Print_BanHang_CongNo()
        {
            DateTime denngay = BanHang_CongNo.mdteDenNgay;
            DateTime tungay = BanHang_CongNo.mdteTuNgay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            pTenTaiKhoan.Value = "Tài khoản: " + BanHang_CongNo.mssoTK_me + " - " + BanHang_CongNo.msTenTK_me + "";
            pTieuDe.Value = BanHang_CongNo.msTieuDe;
        }
        private void Print_MuaHang_frmCongNo()
        {
            DateTime denngay = MuaHang_frmCongNo.mdteDenNgay;
            DateTime tungay = MuaHang_frmCongNo.mdteTuNgay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            pTenTaiKhoan.Value = "Tài khoản: " + MuaHang_frmCongNo.mssoTK_me + " - " + MuaHang_frmCongNo.msTenTK_me + "";
            pTieuDe.Value = MuaHang_frmCongNo.msTieuDe;
        }
        private void Print_frmChiTietBienDongTaiKhoan()
        {
            DateTime denngay = frmChiTietBienDongTaiKhoan.mdteDenNgay;
            DateTime tungay = frmChiTietBienDongTaiKhoan.mdteTuNgay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            pTenTaiKhoan.Value = "Tài khoản: " + frmChiTietBienDongTaiKhoan.mssoTK_me + " - " + frmChiTietBienDongTaiKhoan.msTenTK_me + "";
            pTieuDe.Value = frmChiTietBienDongTaiKhoan.msTieuDe;
        }
        public Xtra_CongNo_NganHang()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            
        }

        private void xrTable1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
          
           
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pKeToan.Value = dt.Rows[6]["HoTen"].ToString();
                pPhoGiamDoc.Value = dt.Rows[8]["HoTen"].ToString();
            }
            else
            {

            }
            if (frmChiTietBienDongTaiKhoan.mbPrint == true)
                Print_frmChiTietBienDongTaiKhoan();
            if (MuaHang_frmCongNo.mbPrint == true)
                Print_MuaHang_frmCongNo();
            if (BanHang_CongNo.mbPrint == true)
                Print_BanHang_CongNo();
        }
    }
}
