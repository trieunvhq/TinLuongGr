using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_XuatKho_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        private void DaiLy_FrmChiTie_XuatKho_In_o_Kho_ThanhPham()
        {

            pDienGiai.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msDienGiai;
            pSoChungTu.Value = "Số: " + KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msSoChungTu + "";
            DateTime ngaychungtu = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mdaNgayChungTu;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";
            
            pNguoiGiaoHang.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msTenDaiLy;
            pMaHang.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msMaThanhPham;
            pMaHang2.Value = "Thành phẩm: " + KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msTenThanhPham + "";
            pSoLuongThanhPham.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mfPrint_soluongtpqiuydoi;
            if (KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msGhiChu != "")
                pGhiChu.Value = "Chú ý: " + KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msGhiChu + "";
            pSDT.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msSoDienThoai;
            pDiaChi.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msDiaChi;
            pDVT.Value = KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msdvtthanhphamquydoi;
        }

        private void DaiLy_FrmChiTie_XuatKho_In_o_Kho_DaiLy()
        {

            pDienGiai.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msDienGiai;
            pSoChungTu.Value = "Số: " + frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msSoChungTu + "";
            DateTime ngaychungtu = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mdaNgayChungTu;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";

            pNguoiGiaoHang.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msTenDaiLy;
            pMaHang.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msMaThanhPham;
            pMaHang2.Value = "Thành phẩm: " + frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msTenThanhPham + "";
            pSoLuongThanhPham.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mfPrint_soluongtpqiuydoi;
            if (frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msGhiChu != "")
                pGhiChu.Value = "Chú ý: " + frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msGhiChu + "";
            pSDT.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msSoDienThoai;
            pDiaChi.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msDiaChi;
            pDVT.Value = frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.msdvtthanhphamquydoi;
        }
        public Xtra_XuatKho_DaiLy()
        {
            InitializeComponent();
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


            if (frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint == true)
            {
                DaiLy_FrmChiTie_XuatKho_In_o_Kho_DaiLy();
            }
            if (KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint == true)
            {
                DaiLy_FrmChiTie_XuatKho_In_o_Kho_ThanhPham();
            }
        }
    }
}
