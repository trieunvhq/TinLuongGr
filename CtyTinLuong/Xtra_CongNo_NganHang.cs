using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_CongNo_NganHang : DevExpress.XtraReports.UI.XtraReport
    {
        private void CongNoNganHang_1()
        {
          
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pKeToanTruong.Value = dt.Rows[5]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

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
                //pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = frmCongNho_NganHang.mdteDenNgay;
            DateTime tungay = frmCongNho_NganHang.mdteTuNgay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }

        private void CongNoNganHang_2()
        {

            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pKeToanTruong.Value = dt.Rows[5]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

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
                //pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = frmChiTietBienDongTaiKhoan.mdteDenNgay;
            DateTime tungay = frmChiTietBienDongTaiKhoan.mdteTuNgay;

            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        public Xtra_CongNo_NganHang()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            
        }

        private void xrTable1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (frmCongNho_NganHang.mPrtint_CongNo_NganHang == true)
            {
                CongNoNganHang_1();
            }
            if (frmChiTietBienDongTaiKhoan.mPrtint_CongNo_NganHang == true)
            {
                CongNoNganHang_2();
            }
            if (MuaHang_frmCongNo.mPrtint_CongNo_NganHang == true)
            {
                CongNoNganHang_1();
            }
        }
    }
}
