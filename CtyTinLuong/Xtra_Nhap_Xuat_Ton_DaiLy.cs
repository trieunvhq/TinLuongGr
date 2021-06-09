using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_Nhap_Xuat_Ton_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        private void NXT_Kho_DaiLy()
        {
            pKho.Value = "Kho Bán thành phẩm";
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                pNguoiLap.Value = dt.Rows[1]["HoTen"].ToString();
                pTruongPhong.Value = dt.Rows[4]["HoTen"].ToString();
                pGiamDoc.Value = dt.Rows[6]["HoTen"].ToString();

            }
            else
            {
                //pTruongPhong.Value = frmMain.msTruongPhongTH;
                //pGiamDoc.Value = frmMain.msGiamDoc;
            }

            DateTime denngay = UCDaiLy_BaoCao_NhapXuatTon.mdadenngay;
            DateTime tungay = UCDaiLy_BaoCao_NhapXuatTon.mdatungay;
            pNgayThang.Value = "Từ ngày " + tungay.ToString("dd/MM/yyyy") + " đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
        }
        public Xtra_Nhap_Xuat_Ton_DaiLy()
        {
            InitializeComponent();
        }

        private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (UCDaiLy_BaoCao_NhapXuatTon.mbPrint_NXT_Kho == true)
            //{
            //    NXT_Kho_DaiLy();
            //}
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (UCDaiLy_BaoCao_NhapXuatTon.mbPrint_NXT_Kho == true)
            {
                NXT_Kho_DaiLy();
            }
        }
    }
}
