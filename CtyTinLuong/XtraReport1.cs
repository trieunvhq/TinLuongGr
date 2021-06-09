using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
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
                    pnguoilap.Value = dt.Rows[1]["HoTen"].ToString();
                   
                }
            }
            catch
            { }

            //pTieuDeNguoiNhap_Giao.Value = "Người giao hàng";
            //pTieuDe.Value = "PHIẾU NHẬP KHO";
            //pKho.Value = "Nhập tại kho: Kho Nguyên Phụ Liệu";
            //pNguoiGiao_Nhan_TieuDe.Value = "Họ tên người giao hàng: " + KhoNPL_ChiTiet_NhapKho_Khac.msNguoiGiaoHang + "";
            //pDienGiai.Value = "Lý do nhập kho: " + KhoNPL_ChiTiet_NhapKho_Khac.msDienGiai + "";
            //pNguoiNhan_Giao.Value = KhoNPL_ChiTiet_NhapKho_Khac.msNguoiGiaoHang;
            //clsSoTienBangChu cls = new clsSoTienBangChu();
            //pSoTienBangChu.Value = cls.DocTienBangChu(Convert.ToDouble(KhoNPL_ChiTiet_NhapKho_Khac.mdbTongSotien), " đồng");

            //DateTime ngay = KhoNPL_ChiTiet_NhapKho_Khac.mdaNgayChungTu;
            //pNgayThang.Value = "Ngày " + ngay.ToString("dd") + " tháng " + ngay.ToString("MM") + " năm " + ngay.ToString("yyyy") + "";
            //pSoChungTu.Value = "Số: " + KhoNPL_ChiTiet_NhapKho_Khac.msSoChungTu + "";
        }
    }
}
