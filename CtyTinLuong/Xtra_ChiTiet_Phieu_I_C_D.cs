using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_ChiTiet_Phieu_I_C_D : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_ChiTiet_Phieu_I_C_D()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //pNguoiLap.Value = SanXuat_frmChiTietSoPhieu_RutGon.ms
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pKeToanTruong.Value = dt.Rows[5]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[7]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
                //txtNguoiLap.Text = dt.Rows[1]["HoTen"].ToString();
                //txtNguoiNhan.Text = dt.Rows[2]["HoTen"].ToString();
                //txtthuKhonewww.Text = dt.Rows[3]["HoTen"].ToString();
                //txtTruongPhongKH.Text = dt.Rows[4]["HoTen"].ToString();
                //txtKeToanTruong.Text = dt.Rows[5]["HoTen"].ToString();
                //txtGiamDoc.Text = dt.Rows[6]["HoTen"].ToString();
                //txtCaTruong.Text = dt.Rows[7]["HoTen"].ToString();
                //txtNguoiGiao.Text = dt.Rows[0]["HoTen"].ToString();
            }
            else
            {
                //pKeToanTruong.Value = frmMain.msKeToanTruong;
                //pGiamDoc.Value = frmMain.msGiamDoc;
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
            }
            DateTime xxtungay, xxdenngay;
            xxtungay = SanXuat_frmChiTietSoPhieu_RutGon.mdatungay;
            xxdenngay = SanXuat_frmChiTietSoPhieu_RutGon.mdadenngay;
            pNgayThang.Value = "Từ ngày "+xxtungay.ToString("dd/MM/yyyy")+ " đến ngày " + xxdenngay.ToString("dd/MM/yyyy") + "";
            pSoTrang.Value = SanXuat_frmChiTietSoPhieu_RutGon.xxsotrang;
        }

    }
}
