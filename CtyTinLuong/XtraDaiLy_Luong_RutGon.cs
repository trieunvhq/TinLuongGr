using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class XtraDaiLy_Luong_RutGon : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraDaiLy_Luong_RutGon()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime ngayx = DateTime.Today;
            pNgay.Value = "Ngày " + ngayx.ToString("dd") + " tháng " + ngayx.ToString("MM") + " năm " + ngayx.ToString("yyyy") + "";
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pPhoGiamDoc.Value= dt.Rows[8]["HoTen"].ToString();
            }
            else
            {
                {
                    pNguoiLap.Value = "Phạm Thị Lành";
                    pTruongPhong.Value = "Phạm Kim Diện";
                    pPhoGiamDoc.Value = "Phạm Thị Đông";
                }
            }
            if (DaiLy_BangLuong.mbPrint_RutGon == true)
                pThangNam.Value = "Tháng " + DaiLy_BangLuong.miThang.ToString() + " năm " + DaiLy_BangLuong.miNam.ToString() + "";
        }
    }
}
