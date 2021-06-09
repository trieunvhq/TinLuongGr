using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_baoGia_BanHang : DevExpress.XtraReports.UI.XtraReport
    {
        private void Print_baoGia_banHangxxx()
        {

            pNguoiNhan.Value = frmCaiDatBangGia_BanHang.msTenKhachHang;
            pDienThoai.Value = frmCaiDatBangGia_BanHang.msDienThoai;
            DateTime ngaychungtu = DateTime.Today;
            string ngay = ngaychungtu.ToString("dd");
            string thang = ngaychungtu.ToString("MM");
            string nam = ngaychungtu.ToString("yyyy");
            pNgayThang.Value = "Ngày " + ngay.ToString() + " tháng " + thang.ToString() + " năm " + nam.ToString() + "";
            
            pDiaChi.Value = frmCaiDatBangGia_BanHang.msDiaChi;
          
        }
        public Xtra_baoGia_BanHang()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //try
            //{
                clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                DataTable dt = cls.SelectAll_ID_DangNhap();
                if (dt.Rows.Count > 0)
                {

                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();

                    pKeToan.Value = dt.Rows[6]["HoTen"].ToString();

                    pGiamDoc.Value = dt.Rows[7]["HoTen"].ToString();

                }
            //}
            //catch
            //{

            //}
            if (frmCaiDatBangGia_BanHang.mbPrint == true)
                Print_baoGia_banHangxxx();
        }
    }
}
