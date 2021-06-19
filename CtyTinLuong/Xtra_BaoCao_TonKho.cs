using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_BaoCao_TonKho : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_BaoCao_TonKho()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            clsAaatbMacDinhNguoiKy clsxxx = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            clsxxx.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = clsxxx.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();

                pKeToan.Value = dt.Rows[6]["HoTen"].ToString();
            }
            else
            {
                pNguoiLap.Value = "Phạm Thị Lành";
                pKeToan.Value = "Lê Thị Thuỷ";
            }
        }
    }
}
