using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong
{
    public partial class Xtra_SoTongHop_banHang : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_SoTongHop_banHang()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                    pGiamDoc.Value = dt.Rows[7]["HoTen"].ToString();
                }
            }
            catch
            { }
        }
    }
}
