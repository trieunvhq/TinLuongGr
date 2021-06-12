using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_CongNo_ChiTiet_Mot_taiKhoan : DevExpress.XtraReports.UI.XtraReport

    {
        private void ChiTiet_CongNoNganHang()
        {

            DateTime denngay = Quy_NganHang_ChiTiet_CongNho_Newwwwww.mdadenngay;
            DateTime tungay = Quy_NganHang_ChiTiet_CongNho_Newwwwww.mdatungay;
            pSoTaiKhoan.Value = "Số TK: "+ Quy_NganHang_ChiTiet_CongNho_Newwwwww.msSoTaiKhoan + "";
            pTenTaiKhoan.Value = Quy_NganHang_ChiTiet_CongNho_Newwwwww.msTenTaiKhoan;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }

        private void Print_frmChiTietBienDongTaiKhoan_Mot_TaiKhoan_CongNo()
        {

           

            DateTime denngay = frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mdadenngay;
            DateTime tungay = frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mdatungay;
            pSoTaiKhoan.Value = "Số TK: " + frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.msSoTaiKhoan + "";
            pTenTaiKhoan.Value = frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.msTenTaiKhoan;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }

        private void ChiTiet_CongNoNganHang_MotTaiKhoan_muaHang()
        {
            DateTime denngay = MuaHang_frmChiTietCongNo_MuaHang.mdadenngay;
            DateTime tungay = MuaHang_frmChiTietCongNo_MuaHang.mdatungay;
            pSoTaiKhoan.Value = "Số TK: " + MuaHang_frmChiTietCongNo_MuaHang.msSoTaiKhoan + "";
            pTenTaiKhoan.Value = MuaHang_frmChiTietCongNo_MuaHang.msTenTaiKhoan;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        public Xtra_CongNo_ChiTiet_Mot_taiKhoan()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pKeToanTruong.Value = dt.Rows[5]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
            }
            else
            {

            }

            if (Quy_NganHang_ChiTiet_CongNho_Newwwwww.mbPrint == true)
            {
                ChiTiet_CongNoNganHang();
            }
            if (frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mbPrint_Congno == true)
            {
                Print_frmChiTietBienDongTaiKhoan_Mot_TaiKhoan_CongNo();
            }
            if (MuaHang_frmChiTietCongNo_MuaHang.mbPrint == true)
            {
                ChiTiet_CongNoNganHang_MotTaiKhoan_muaHang();
            }

        }
    }
}
