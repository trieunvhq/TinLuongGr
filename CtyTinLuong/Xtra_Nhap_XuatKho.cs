using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_Nhap_XuatKho : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_Nhap_XuatKho()
        {
            InitializeComponent();
        }

        private void Print_KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiiio()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbTongTienVAT), " đồng");
            DateTime ngay = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msSoChungTu + "";
        }
        private void Print_BanHang_FrmChiTietBanHang_Newwwwwwwwo()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + BanHang_FrmChiTietBanHang_Newwwwwwww.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + BanHang_FrmChiTietBanHang_Newwwwwwww.msDienGiai + "";
            pNguoiNhan_Giao.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(BanHang_FrmChiTietBanHang_Newwwwwwww.mdbTongTienVAT), " đồng");
            DateTime ngay = BanHang_FrmChiTietBanHang_Newwwwwwww.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + BanHang_FrmChiTietBanHang_Newwwwwwww.msSoChungTu + "";
        }
        private void Print_KhoThanhPham_frmChiTiet_Da_XuatKho()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoThanhPham_frmChiTiet_Da_XuatKho.msNguoinhanhang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoThanhPham_frmChiTiet_Da_XuatKho.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoThanhPham_frmChiTiet_Da_XuatKho.msNguoinhanhang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoThanhPham_frmChiTiet_Da_XuatKho.mdbTongSotien), " đồng");
            DateTime ngay = KhoThanhPham_frmChiTiet_Da_XuatKho.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoThanhPham_frmChiTiet_Da_XuatKho.msSoChungTu + "";
        }
        private void Print_KhoThanhPham_ChiTiet_XuatKho_Khac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoThanhPham_ChiTiet_XuatKho_Khac.msNguoinhanhang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoThanhPham_ChiTiet_XuatKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoThanhPham_ChiTiet_XuatKho_Khac.msNguoinhanhang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoThanhPham_ChiTiet_XuatKho_Khac.mdbTongSotien), " đồng");
            DateTime ngay = KhoThanhPham_ChiTiet_XuatKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoThanhPham_ChiTiet_XuatKho_Khac.msSoChungTu + "";
        }

        private void Print_KhoThanhPham_ChiTiet_NhapKho_Khac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + KhoThanhPham_ChiTiet_NhapKho_Khac.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do nhập kho: " + KhoThanhPham_ChiTiet_NhapKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoThanhPham_ChiTiet_NhapKho_Khac.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoThanhPham_ChiTiet_NhapKho_Khac.mdbTongSotien), " đồng");
            DateTime ngay = KhoThanhPham_ChiTiet_NhapKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoThanhPham_ChiTiet_NhapKho_Khac.msSoChungTu + "";
            if (KhoThanhPham_ChiTiet_NhapKho_Khac.msGhiChu.ToString() != "")
                pGhiChu.Value = "Ghi chú: " + KhoThanhPham_ChiTiet_NhapKho_Khac.msGhiChu + "";
        }
        private void Print_frmChiTietNhapKhoThanhPham_DaNhapKhoTP()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do nhập kho: " + frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msDienGiai + "";
            pNguoiNhan_Giao.Value = frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(frmChiTietNhapKhoThanhPham_DaNhapKhoTP.mdbTongSotien), " đồng");
            DateTime ngay = frmChiTietNhapKhoThanhPham_DaNhapKhoTP.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msSoChungTu + "";
            if (frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msGhiChu.ToString() != "")
                pGhiChu.Value = "Ghi chú: " + frmChiTietNhapKhoThanhPham_DaNhapKhoTP.msGhiChu + "";
        }
        private void Print_KhoBTP_ChiTiet_XuatKho_Khac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Bán Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoBTP_ChiTiet_XuatKho_Khac.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoBTP_ChiTiet_XuatKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoBTP_ChiTiet_XuatKho_Khac.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoBTP_ChiTiet_XuatKho_Khac.mdbTongSotien), " đồng");
            DateTime ngay = KhoBTP_ChiTiet_XuatKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoBTP_ChiTiet_XuatKho_Khac.msSoChungTu + "";
        }
        private void Print_KhoBTP_ChiTietDaXuatKho()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Bán Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoBTP_ChiTietDaXuatKho.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoBTP_ChiTietDaXuatKho.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoBTP_ChiTietDaXuatKho.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoBTP_ChiTietDaXuatKho.mdbTongSotien), " đồng");
            DateTime ngay = KhoBTP_ChiTiet_DaNhapKho.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoBTP_ChiTietDaXuatKho.msSoChungTu + "";
        }
        private void Print_KhoBTP_ChiTiet_DaNhapKho()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Bán Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + KhoBTP_ChiTiet_DaNhapKho.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do nhập kho: " + KhoBTP_ChiTiet_DaNhapKho.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoBTP_ChiTiet_DaNhapKho.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoBTP_ChiTiet_DaNhapKho.mdbTongSotien), " đồng");
            DateTime ngay = KhoBTP_ChiTiet_DaNhapKho.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoBTP_ChiTiet_DaNhapKho.msSoChungTu + "";
        }
        private void Print_KhoBTP_ChiTiet_NhapKho_Khac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Bán Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + KhoBTP_ChiTiet_NhapKho_Khac.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do nhập kho: " + KhoBTP_ChiTiet_NhapKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoBTP_ChiTiet_NhapKho_Khac.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoBTP_ChiTiet_NhapKho_Khac.mdbTongSotien), " đồng");
            DateTime ngay = KhoBTP_ChiTiet_NhapKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoBTP_ChiTiet_NhapKho_Khac.msSoChungTu + "";
        }
        private void Print_KhoNPL_ChiTiet_XuatKho_Khac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Nguyên Phụ Liệu";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoNPL_ChiTiet_XuatKho_Khac.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoNPL_ChiTiet_XuatKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoNPL_ChiTiet_XuatKho_Khac.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoNPL_ChiTiet_XuatKho_Khac.mdbTongSotien), " đồng");
            DateTime ngay = KhoNPL_ChiTiet_XuatKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoNPL_ChiTiet_XuatKho_Khac.msSoChungTu + "";
        }
        private void Print_frmKhoNPL_DaXuatKho()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Nguyên Phụ Liệu";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + frmKhoNPL_DaXuatKho.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: "+ frmKhoNPL_DaXuatKho.msDienGiai+ "";
            pNguoiNhan_Giao.Value = frmKhoNPL_DaXuatKho.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(frmKhoNPL_DaXuatKho.mdbTongSotien), " đồng");
            DateTime ngay = frmKhoNPL_DaXuatKho.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + frmKhoNPL_DaXuatKho.msSoChungTu + "";
        }
        private void Print_NhapKho_NPL()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Nguyên Phụ Liệu";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: "+ KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.msNguoiGiaoHang+ "";
            pDienGiai.Value = "Lý do nhập kho: "+ KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.mdbTongSotien), " đồng");
            DateTime ngay = KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.msSoChungTu;
            pSoChungTu.Value = "Số: " + KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.msSoChungTu + "";
        }
        private void Print_NhapKho_NPL_NhapKhoKhac()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            pTieuDe.Value = "PHIẾU NHẬP KHO";
            pKho.Value = "Nhập tại kho: Kho Nguyên Phụ Liệu";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + KhoNPL_ChiTiet_NhapKho_Khac.msNguoiGiaoHang + "";
            pDienGiai.Value = "Lý do nhập kho: " + KhoNPL_ChiTiet_NhapKho_Khac.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoNPL_ChiTiet_NhapKho_Khac.msNguoiGiaoHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoNPL_ChiTiet_NhapKho_Khac.mdbTongSotien), " đồng");

            DateTime ngay = KhoNPL_ChiTiet_NhapKho_Khac.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: "+ KhoNPL_ChiTiet_NhapKho_Khac.msSoChungTu + "";
        }

        private void Print_KhoNPL_frmChiTiet_XuatKho_gapDan()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + KhoNPL_frmChiTiet_XuatKho_gapDan.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + KhoNPL_frmChiTiet_XuatKho_gapDan.msDienGiai + "";
            pNguoiNhan_Giao.Value = KhoNPL_frmChiTiet_XuatKho_gapDan.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoNPL_frmChiTiet_XuatKho_gapDan.mdbTongSotien), " đồng");
            DateTime ngay = KhoNPL_frmChiTiet_XuatKho_gapDan.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + KhoNPL_frmChiTiet_XuatKho_gapDan.msSoChungTu + "";
        }

        private void Print_DaiLy_FrmChiTiet_NhapKho_GapDan()
        {
            pTieuDeNguoiNhap_Giao.Value = "Người nhận hàng";
            pTieuDe.Value = "PHIẾU XUẤT KHO";
            pKho.Value = "Xuất tại kho: Kho Thành Phẩm";
            pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người nhận hàng: " + DaiLy_FrmChiTiet_NhapKho_GapDan.msNguoiNhanHang + "";
            pDienGiai.Value = "Lý do xuất kho: " + DaiLy_FrmChiTiet_NhapKho_GapDan.msDienGiai + "";
            pNguoiNhan_Giao.Value = DaiLy_FrmChiTiet_NhapKho_GapDan.msNguoiNhanHang;
            clsSoTienBangChu cls = new clsSoTienBangChu();
            pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(DaiLy_FrmChiTiet_NhapKho_GapDan.mdbTongSotien), " đồng");
            DateTime ngay = DaiLy_FrmChiTiet_NhapKho_GapDan.mdaNgayChungTu;
            pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            pSoChungTu.Value = "Số: " + DaiLy_FrmChiTiet_NhapKho_GapDan.msSoChungTu + "";
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
                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                    pKeToan.Value = dt.Rows[6]["HoTen"].ToString();
                    pThuKho.Value = dt.Rows[3]["HoTen"].ToString();
                    pGiamDoc.Value= dt.Rows[7]["HoTen"].ToString();
                }
            }
            catch
            { }

            if (KhoNPL_frmChiTiet_XuatKho_gapDan.mbPrint == true)
                Print_KhoNPL_frmChiTiet_XuatKho_gapDan();

            if (DaiLy_FrmChiTiet_NhapKho_GapDan.mbPrint == true)
                Print_DaiLy_FrmChiTiet_NhapKho_GapDan();

            if (KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.mbPrint==true)
                Print_NhapKho_NPL();
            if (KhoNPL_ChiTiet_NhapKho_Khac.mbPrint == true)
                Print_NhapKho_NPL_NhapKhoKhac();
            if (frmKhoNPL_DaXuatKho.mbPrint == true)
                Print_frmKhoNPL_DaXuatKho();

            if (KhoNPL_ChiTiet_XuatKho_Khac.mbPrint == true)
                Print_KhoNPL_ChiTiet_XuatKho_Khac();

            if (KhoBTP_ChiTiet_DaNhapKho.mbPrint == true)
                Print_KhoBTP_ChiTiet_DaNhapKho();
            if (KhoBTP_ChiTiet_NhapKho_Khac.mbPrint == true)
                Print_KhoBTP_ChiTiet_NhapKho_Khac();

            if (KhoBTP_ChiTietDaXuatKho.mbPrint == true)
                Print_KhoBTP_ChiTietDaXuatKho();

            if (KhoBTP_ChiTiet_XuatKho_Khac.mbPrint == true)
                Print_KhoBTP_ChiTiet_XuatKho_Khac();

            if (frmChiTietNhapKhoThanhPham_DaNhapKhoTP.mbPrint == true)
                Print_frmChiTietNhapKhoThanhPham_DaNhapKhoTP();

            if (KhoThanhPham_ChiTiet_NhapKho_Khac.mbPrint == true)
                Print_KhoThanhPham_ChiTiet_NhapKho_Khac();

            if (KhoThanhPham_ChiTiet_XuatKho_Khac.mbPrint == true)
                Print_KhoThanhPham_ChiTiet_XuatKho_Khac();

            if (KhoThanhPham_frmChiTiet_Da_XuatKho.mbPrint == true)
                Print_KhoThanhPham_frmChiTiet_Da_XuatKho();
            //
            if (BanHang_FrmChiTietBanHang_Newwwwwwww.mbPrint_XuatKho == true)
                Print_BanHang_FrmChiTietBanHang_Newwwwwwwwo();

            if (KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mbPrint_XuatKho == true)
                Print_KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiiio();
        }
    }
}
