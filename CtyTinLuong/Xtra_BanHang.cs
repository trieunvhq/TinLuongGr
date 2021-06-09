using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_BanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_BanHang()
        {
            InitializeComponent();
        }
        public void print_KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii()
        {
            pSoChungTu.Value = "Số: " + KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msSoChungTu + "";

            DateTime ngaychungtu = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdaNgayChungTu;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";

            pDiaChi.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msDiaChi;
            pDienGiai.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msDienGiai;
            pNguoiNhanHang.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msNguoiNhanHang;

            pSoTKNo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msSoTKNo;
            pSoTKCo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msSoTKCo;
            pSoTienNo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbSoTienNo;
            pSoTienCo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbSoTienCo;


            pTienChuaVAT.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbTienChuaVAT;
            pTienVAT.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbTienVAT;
            pTongTienCoVAT.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbTongTienVAT;
            //  pSoTienCo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbSoTienCo;
            pNoCu.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbNoCu;
            pNoMoi.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbNoMoi;
            pTongNo.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdbTongNo;

            pSoTienBangChu.Value = KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.msSoTienBangChu;
        }
        public void print_BanHang_FrmChiTietBanHang_Newwwwwwww()
        {
            pSoChungTu.Value = "Số: " + BanHang_FrmChiTietBanHang_Newwwwwwww.msSoChungTu + "";

            DateTime ngaychungtu = BanHang_FrmChiTietBanHang_Newwwwwwww.mdaNgayChungTu;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";

          pDiaChi.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msDiaChi;
           pDienGiai.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msDienGiai;
            pNguoiNhanHang.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msNguoiNhanHang;

            pSoTKNo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msSoTKNo;
            pSoTKCo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msSoTKCo;
            pSoTienNo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbSoTienNo;
            pSoTienCo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbSoTienCo;


            pTienChuaVAT.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbTienChuaVAT;
            pTienVAT.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbTienVAT;
            pTongTienCoVAT.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbTongTienVAT;
            //  pSoTienCo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbSoTienCo;
            pNoCu.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbNoCu;
            pNoMoi.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbNoMoi;
            pTongNo.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbTongNo;

            pSoTienBangChu.Value = BanHang_FrmChiTietBanHang_Newwwwwwww.msSoTienBangChu;
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

            if (BanHang_FrmChiTietBanHang_Newwwwwwww.mbPrint_HoaDon == true)
                print_BanHang_FrmChiTietBanHang_Newwwwwwww();
            if (KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mbPrint_HoaDon == true)
                print_KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii();
        }
    }
}
