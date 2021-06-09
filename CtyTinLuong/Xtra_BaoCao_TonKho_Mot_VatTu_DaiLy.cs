using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace CtyTinLuong
{
    public partial class Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy : DevExpress.XtraReports.UI.XtraReport
    {
        private void BaoCao_TonKho_Mot_VatTu_DaiLy()
        {
            //DaiLy_Frm_TonKho_MotVatTu
            clsAaatbMacDinhNguoiKy clsxxx = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            clsxxx.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = clsxxx.SelectAll_ID_DangNhap();
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

            DateTime denngay = DaiLy_Frm_TonKho_MotVatTu.mdadenngay;
          
            pNgayThang.Value = "Đến ngày " + denngay.ToString("dd/MM/yyyy") + "  ";
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = DaiLy_Frm_TonKho_MotVatTu.miID_VTHH;
            DataTable dtxx = cls.SelectOne();
            // pTenVT.Value = " Mã vật tư: " + cls.sMaVT.Value + ",   Tên vật tư: " + cls.sTenVTHH.Value + ",   ĐVT: " + cls.sDonViTinh.Value + "";
            pMaVT.Value = "Mã vật tư: " + cls.sMaVT.Value + "";
            pTenVT.Value = "Tên vật tư: " + cls.sTenVTHH.Value + "";
            pDVT.Value = "ĐVT: " + cls.sDonViTinh.Value + "";

        }
        public Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DaiLy_Frm_TonKho_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                BaoCao_TonKho_Mot_VatTu_DaiLy();
        }
    }
}
