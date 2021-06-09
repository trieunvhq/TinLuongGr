using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_keHoachSanXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_keHoachSanXuat()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            pNgayThang.Value="Ngày "+ngayhomnay.ToString("dd")+" tháng "+ ngayhomnay.ToString("MM") + " năm "+ ngayhomnay.ToString("yyyy") + "";
            //try
            //{

                clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                DataTable dt = cls.SelectAll_ID_DangNhap();
                if (dt.Rows.Count > 0)
                {
                    pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();                    
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
            //}
            //catch
            //{ }
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            pNgayHomnay.Value = "Ngày " + ngayhomnay.ToString("dd") + " tháng " + ngayhomnay.ToString("MM") + " năm " + ngayhomnay.ToString("yyyy") + "";
            DateTime denngay = frmKeHoachSanXuat.mdaDenNgay;
            DateTime tungay = frmKeHoachSanXuat.mdaTuNgay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";

            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

             
            }
        }
    }
}
