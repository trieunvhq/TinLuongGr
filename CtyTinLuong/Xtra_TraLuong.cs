using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong
{
    public partial class Xtra_TraLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_TraLuong()
        {
            InitializeComponent();
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //pSoChungTu.Value = frmChiTietMuaHang3333333333.mssochungtu;
            //pSoHoaDon.Value = frmChiTietMuaHang3333333333.mssohoadon;
            //pKeToanTruong.Value = frmMain.msKeToanTruong;
            //pGiamDoc.Value = frmMain.msGiamDoc;
            //DateTime ngaychungtu = frmChiTietMuaHang3333333333.mdangaythang;
            //string ngay = ngaychungtu.ToString("dd");
            //string thang = ngaychungtu.ToString("MM");
            //string nam = ngaychungtu.ToString("yyyy");
            //pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";
            //pNguoiGiao.Value = frmChiTietMuaHang3333333333.msNguoiGiaoHang;
            //pNguoiNhan.Value = frmChiTietMuaHang3333333333.msNguoiMuaHang;
            //pTKNo.Value = "Nợ: " + frmChiTietMuaHang3333333333.msTKNo + "";
            //pTKCo.Value = "Có: " + frmChiTietMuaHang3333333333.msTKCo + "";
            //pTKVAT.Value = "VAT: " + frmChiTietMuaHang3333333333.msTKVAT + "";
            //pSoTienNo.Value = frmChiTietMuaHang3333333333.mdcSoTienNo;
            //pSoTienCo.Value = frmChiTietMuaHang3333333333.mdcSoTienCo;
            //pSoTienVAT.Value = frmChiTietMuaHang3333333333.mdcSoTienVAT;
            //pTongTienCoVAT.Value = frmChiTietMuaHang3333333333.mdcTongTienCoVAT;
        }

    }
}
