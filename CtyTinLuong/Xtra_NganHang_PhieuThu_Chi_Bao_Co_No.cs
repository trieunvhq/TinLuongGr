using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
//using System.arr
namespace CtyTinLuong
{
    public partial class Xtra_NganHang_PhieuThu_Chi_Bao_Co_No : DevExpress.XtraReports.UI.XtraReport
    {

        private void Pritnxxxx_Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww()
        {

            clsAaatbMacDinhNguoiKy clsxxx = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            clsxxx.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = clsxxx.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
                pThuQuy.Value = dt.Rows[8]["HoTen"].ToString();
                pNguoiNopTien.Value = dt.Rows[9]["HoTen"].ToString();
            }
            else
            {

                //pGiamDoc.Value = frmMain.msGiamDoc;
            }
            pSoTien.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdbSoTien;


            DateTime ngaythang = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdaNgayThang;
            pDiaChi.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msDiaChi;
            pDienGiai.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msDienGiai;
            pLoaiChungTu.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msLoaiChungTu;
            if (Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mbTienUSD == true)
            {
                pTienUSD.Value = true;
                pTienVND.Value = false;
                clsSoTienBangChu cls = new clsSoTienBangChu();
                pSoTienBangChu.Value = cls.DocTienBangChu(Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdbSoTien, " USD");
            }
            else
            {
                pTienUSD.Value = false;
                pTienVND.Value = true;
                clsSoTienBangChu cls = new clsSoTienBangChu();
                pSoTienBangChu.Value = cls.DocTienBangChu(Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdbSoTien, " VNĐ");
            }

            pNgayThang.Value = "Ngày " + ngaythang.ToString("dd") + " tháng  " + ngaythang.ToString("MM") + " năm  " + ngaythang.ToString("yyyy") + "";
            pNguoiNopTien.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msNguoiNopTen;
            pSoChungTu.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msSoChungTu;
            pTiGia.Value = Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdbTiGia;
            pTK_Co.Value = "Có   " + Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.ms_TaiKhoanCo + "";
            pTK_No.Value = "Nợ  " + Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.msTaiKhoan_No + "";
        }

       
        public Xtra_NganHang_PhieuThu_Chi_Bao_Co_No()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (Quy_nganHang_ChiTiet_thuChi_TuMuaHang_BanHang_VanVan.mbPrint == true)
            //{
            //    Pritnxxxx_Quy_nganHang_ChiTiet_thuChi_TuMuaHang_BanHang_VanVan();
            //}
            if (Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mbPrint == true)
            {
                Pritnxxxx_Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
            }
        }

    }
}
