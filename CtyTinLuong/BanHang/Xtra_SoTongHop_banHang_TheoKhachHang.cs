using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Xtra_SoTongHop_banHang_TheoKhachHang : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_SoTongHop_banHang_TheoKhachHang()
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
                        pNguoilap.Value = dt.Rows[1]["HoTen"].ToString();
                        pTruongPhong.Value = dt.Rows[5]["HoTen"].ToString();
                        pThuKho.Value = dt.Rows[3]["HoTen"].ToString();
                        pPhoGiamDoc.Value = dt.Rows[8]["HoTen"].ToString();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pNgayThang.Value = "Từ ngày " + BanHang_SoTongHopbanHang.mdatungay.ToString("dd/MM/yyyy") + " đến ngày " + BanHang_SoTongHopbanHang.mdadenngay.ToString("dd/MM/yyyy") + "";
        }
    }
}
