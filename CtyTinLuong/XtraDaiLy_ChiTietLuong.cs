using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class XtraDaiLy_ChiTietLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraDaiLy_ChiTietLuong()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pThangNam.Value = "Tháng " + frmChiTietLuong_DaiLy.msPrintThang + " năm " + frmChiTietLuong_DaiLy.ssPrintNam + "";
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();
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
                //pNguoiLap.Value = frmMain.msKhoDaiLy;
                //pGiamDoc.Value = frmMain.msGiamDoc;
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
            }
        }

    }
}
