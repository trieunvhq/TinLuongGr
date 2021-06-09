using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_NhapKho_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_NhapKho_DaiLy()
        {
            InitializeComponent();
        }
        private void DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww_In_AN()
        {
            
            pDienGiai.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msDienGiaig;
            pSoChungTu.Value = "Số: " + DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msSoChungTu + "";
            DateTime ngaychungtu = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mdaNgayXuatKho;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";
            pNguoiLap.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msNguoiLap;
            pNguoiNhanhang.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msNguoiNhan;
            pMaHang.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msTenThanhPham;
            pMaHang2.Value = "Quy đổi: " + DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msTenThanhPham + "";
            pSoLuongThanhpham.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mfsoluongtpqiuydoi;
            if (DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msGhiChu != "")
                pGhiChu.Value = "Chú ý: " + DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msGhiChu + "";
            pSoDienThoai.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msSDTDaiLy;
            pDiaChi.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msDiaChiDaiLy;
            pDVTThanhPham.Value = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.msdvtthanhphamquydoi;
        }
        private void NPLChiTietNhapKho_DaiLy_ThemMoi_In_AN()
        {
         
            pDienGiai.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msDienGiaig;
            pSoChungTu.Value = "Số: " + NPLChiTietNhapKho_DaiLy_ThemMoi.msSoChungTu + "";
            DateTime ngaychungtu = NPLChiTietNhapKho_DaiLy_ThemMoi.mdaNgayXuatKho;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";
            pNguoiLap.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msNguoiLap;
            pNguoiNhanhang.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msNguoiNhan;
            pMaHang.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msTenThanhPham;
            pMaHang2.Value = "Quy đổi: " + NPLChiTietNhapKho_DaiLy_ThemMoi.msTenThanhPham + "";
            pSoLuongThanhpham.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.mfPrint_soluongtpqiuydoi;
            if (NPLChiTietNhapKho_DaiLy_ThemMoi.msGhiChu != "")
                pGhiChu.Value = "Chú ý: " + NPLChiTietNhapKho_DaiLy_ThemMoi.msGhiChu + "";
            pSoDienThoai.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msSDTDaiLy;
            pDiaChi.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msDiaChiDaiLy;
            pDVTThanhPham.Value = NPLChiTietNhapKho_DaiLy_ThemMoi.msdvtthanhphamquydoi;
        }
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                DataTable dt = cls.SelectAll_ID_DangNhap();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[1]["HoTen"].ToString() != "")
                        pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                    if (dt.Rows[3]["HoTen"].ToString() != "")
                        pThuKho.Value = dt.Rows[3]["HoTen"].ToString();
                    if (dt.Rows[6]["HoTen"].ToString() != "")
                        pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
                    if (dt.Rows[10]["HoTen"].ToString() != "")
                        pBaoVe.Value = dt.Rows[10]["HoTen"].ToString();
                }
            }
            catch
            {

            }


            if (NPLChiTietNhapKho_DaiLy_ThemMoi.mbPrint_Chitiet_XuatKho_DaiLyGiaCong == true)
            {
                NPLChiTietNhapKho_DaiLy_ThemMoi_In_AN();
            }
            if (DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mbPrint_Chitiet_XuatKho_DaiLyGiaCong == true)
            {
                DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww_In_AN();
            }
        }
    }
}
