using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_DoiChieuCongNo : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_DoiChieuCongNo()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pThuQuy.Value = dt.Rows[10]["HoTen"].ToString();
                pKeToan.Value = dt.Rows[6]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[7]["HoTen"].ToString();
            }
        }
    }
}
