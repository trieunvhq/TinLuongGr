using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Xtra_SanLuong_DOT_DAP_RutGon : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_SanLuong_DOT_DAP_RutGon()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                using (clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy())
                {
                    cls.iID_DangNhap = frmDangNhap._miID_DangNhap;
                    DataTable dt = cls.SelectAll_ID_DangNhap();
                    if (dt.Rows.Count > 0)
                    {
                        pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                        pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();

                    }
                    DateTime xxtungay = SanLuong_To_DOT_DAP.mdatungay;
                    DateTime xxdenngay = SanLuong_To_DOT_DAP.mdadenngay;
                    pNgayThang.Value = "Từ ngày " + xxtungay.ToString("dd/MM/yyyy") + " đến ngày " + xxdenngay.ToString("dd/MM/yyyy") + "";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
