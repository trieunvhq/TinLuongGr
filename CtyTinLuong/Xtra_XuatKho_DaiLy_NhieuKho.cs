using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_XuatKho_DaiLy_NhieuKho : DevExpress.XtraReports.UI.XtraReport
    {
        private void UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_In_AN()
        {
          //  msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy;
            pDienGiai.Value = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.msDienGiai;
            pSoChungTu.Value = "Số: " + UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.msSoChungTu + "";
            DateTime ngaychungtu = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mdaNgayChungTu;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";           
            pNguoiGiaoHang.Value = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.msTenDaiLy;
            pSDT.Value = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.msSoDienThoai;
            pDiaChi.Value = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.msDiaChi;
          
        }
        public Xtra_XuatKho_DaiLy_NhieuKho()
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
                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                    pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
                    pBaoVe.Value = dt.Rows[10]["HoTen"].ToString();
                    pThuKho.Value = dt.Rows[3]["HoTen"].ToString();
                
                }
            }
           catch
            { }
            if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbPrint == true)
                UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_In_AN();
        }
    }
}
