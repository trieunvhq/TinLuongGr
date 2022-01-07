using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Xtra_banKeHoaDonBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_banKeHoaDonBanHang()
        {
            InitializeComponent();
            pNgay.Value = DateTime.Now;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                //Load label ngay ky footer:
                DateTime d = Convert.ToDateTime(pNgay.Value);
                if (d.Day > 9)
                {
                    if (d.Month > 9)
                    {
                        lbNgayThangNam.Text = "Ngày " + d.Day
                                            + " tháng " + d.Month
                                            + " năm " + d.Year;
                    }
                    else
                    {
                        lbNgayThangNam.Text = "Ngày " + d.Day
                                            + " tháng 0" + d.Month
                                            + " năm " + d.Year;
                    }

                }
                else
                {
                    if (d.Month > 9)
                    {
                        lbNgayThangNam.Text = "Ngày 0" + d.Day
                                            + " tháng " + d.Month
                                            + " năm " + d.Year;
                    }
                    else
                    {
                        lbNgayThangNam.Text = "Ngày 0" + d.Day
                                            + " tháng 0" + d.Month
                                            + " năm " + d.Year;
                    }
                }
                using (clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy())
                {
                    cls.iID_DangNhap = frmDangNhap._miID_DangNhap;
                    DataTable dt = cls.SelectAll_ID_DangNhap();
                    if (dt.Rows.Count > 0)
                    {
                        pNguoilap.Value = dt.Rows[1]["HoTen"].ToString();
                        pGiamDoc.Value = dt.Rows[7]["HoTen"].ToString();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pNgayThang.Value = "Từ ngày " + BanHang_frmBangKeHoaDonBanHang.mdatungay.ToString("dd/MM/yyyy") + " đến ngày " + BanHang_frmBangKeHoaDonBanHang.mdadenngay.ToString("dd/MM/yyyy") + "";
        }
    }
}
