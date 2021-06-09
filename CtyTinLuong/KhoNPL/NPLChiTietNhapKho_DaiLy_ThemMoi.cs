using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class NPLChiTietNhapKho_DaiLy_ThemMoi : Form
    {
        int miID_DinhMucNPL_XXx;
        int iiiIDThanhPham_QuyDoi;
      
        public static bool mbPrint_Chitiet_XuatKho_DaiLyGiaCong;
        public static DateTime mdaNgayXuatKho;
        public static DataTable mdt_ChiTietXuatKho;     
        public static string msdvtthanhphamquydoi, msMaDaiLy, msDiaChiDaiLy, msSDTDaiLy, msGhiChu, msSoChungTu, msDienGiaig, msThuKho, msNguoiNhan, msNguoiLap, msMaThanhPham, msTenThanhPham;
        public static double mfPrint_soluongtpqiuydoi;
        private void TinhTongSoKg_TongSoKien()
        {
            try
            {
                double soluongbaoto, soluongbaobe, sokg1baoto, sokg1baobe, sokien1baoto, sokien1baobe;
                soluongbaoto = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
                soluongbaobe = Convert.ToDouble(txtSoLuong_BaoBe.Text.ToString());
                sokg1baoto = Convert.ToDouble(txtSoKG1Bao_To.Text.ToString());
                sokg1baobe = Convert.ToDouble(txtSoKG1Bao_Be.Text.ToString());
                sokien1baobe = Convert.ToDouble(txtSoKien_1_BaoBe.Text.ToString());
                sokien1baoto = Convert.ToDouble(txtSoKien_1_BaoTo.Text.ToString());

                txtQuyRaKien_BaoBe.Text = (soluongbaobe * sokien1baobe).ToString();
                txtQuyRaKien_BaoTo.Text= (soluongbaoto * sokien1baoto).ToString();
                txtSoLuongThanhPhamQuyDoi.Text = (soluongbaobe * sokien1baobe+ soluongbaoto * sokien1baoto).ToString();
                txtTongSoKG.Text= (soluongbaobe * sokg1baobe + soluongbaoto * sokg1baoto).ToString();
                if (checkHangNhu.Checked == true)
                    txtTongSoKG.Text = txtSoLuong_BaoTo.Text;
            }
            catch
            {

            }
        }
        private void HienThi_ThemMoi_XuatKho()
        {
            checkHangDot.Checked = true;
            //Load_LockUp_DinhMucDot();
        
            gridNguoiLap.EditValue = 14;
           
            dteNgayChungTu.EditValue = DateTime.Today;
            clsKhoNPL_tbXuatKho cls3 = new clsKhoNPL_tbXuatKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "XKNPL 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;

                txtSoChungTu.Text = "XKNPL " + xxx2 + "";

            }
            string sochungtuNhapKhoDaiLy;
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt1222 = cls.SelectAll();
            dt1222.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvxxx = dt1222.DefaultView;
            DataTable dv3xxx = dvxxx.ToTable();
            int k2 = dv3xxx.Rows.Count;
            if (k2 == 0)
                sochungtuNhapKhoDaiLy = "NKDL 1";
            else
            {
                string xxx = dv3xxx.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
               
                sochungtuNhapKhoDaiLy = "NKDL " + xxx2 + "";

            }
            txtSoChungTuKhoDaiLy.Text = sochungtuNhapKhoDaiLy;

            gridMaDinhMucDot_BaoTo.EditValue = 0;
            gridMaDinhMucDot_BaoBe.EditValue = 0;
        }
        private void HienThi_Sua_XuatKho()
        {
            if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbCopy == true)
            {
                HienThi_ThemMoi_XuatKho();
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                DataTable dt22222 = cls1.SelectOne();
                if (cls1.bHoanThanh.Value == true)
                    checkHoanThanh.Checked = true;
                else checkHoanThanh.Checked = false;
                if (cls1.iHangDoT_1_hangNhu_2_ConLai3 == 1)
                    checkHangDot.Checked = true;
                else checkHangNhu.Checked = true;

                txtSoLuong_BaoTo.Text = cls1.fSoLuongXuat_BaoTo.Value.ToString();
                txtSoLuong_BaoBe.Text = cls1.fSoLuongXuat_BaoBe.Value.ToString();
                gridMaDinhMucDot_BaoTo.EditValue = cls1.iID_DinhMucDot_BaoTo.Value;
                gridMaDinhMucDot_BaoBe.EditValue = cls1.iID_DinhMucDot_BaoBe.Value;
                gridMaDinhMucNPL.EditValue = cls1.iID_DinhMucNguenPhuLieu.Value;
                gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
              
                clsKhoNPL_tbXuatKho cls2 = new CtyTinLuong.clsKhoNPL_tbXuatKho();
                cls2.sThamChieu = cls1.sSoChungTu.Value;
                DataTable dt2 = cls2.SelectOne_W_ThamChieu_NhapKho_DaiLy();               
                txtDienGiai.Text = dt2.Rows[0]["DienGiai"].ToString();               
                gridNguoiLap.EditValue = Convert.ToInt32(dt2.Rows[0]["ID_NguoiXuatKho"].ToString());
                txtGhiChu.Text = cls1.sGhiChu.Value;
                

            }
            else if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == true)
            {
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                DataTable dt22222 = cls1.SelectOne();

                if (cls1.iHangDoT_1_hangNhu_2_ConLai3 == 1)
                    checkHangDot.Checked = true;
                else checkHangNhu.Checked = true;
                if(cls1.bTrangThaiXuatNhap_Kho_NPL.Value==true)
                {
                    btLuu_Dong.Enabled = false;
                    btLuu_Gui_Dong.Enabled = false;
                }
                txtSoLuong_BaoTo.Text = cls1.fSoLuongXuat_BaoTo.Value.ToString();
                txtSoLuong_BaoBe.Text = cls1.fSoLuongXuat_BaoBe.Value.ToString();
                gridMaDinhMucDot_BaoTo.EditValue = cls1.iID_DinhMucDot_BaoTo.Value;
                gridMaDinhMucDot_BaoBe.EditValue = cls1.iID_DinhMucDot_BaoBe.Value;
                gridMaDinhMucNPL.EditValue = cls1.iID_DinhMucNguenPhuLieu.Value;
                gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
                txtSoChungTuKhoDaiLy.Text = cls1.sSoChungTu.Value;
                clsKhoNPL_tbXuatKho cls2 = new CtyTinLuong.clsKhoNPL_tbXuatKho();
                cls2.sThamChieu = cls1.sSoChungTu.Value;
                DataTable dt2 = cls2.SelectOne_W_ThamChieu_NhapKho_DaiLy();
                if(dt2.Rows.Count>0)
                {
                    dteNgayChungTu.EditValue = Convert.ToDateTime(dt2.Rows[0]["NgayChungTu"].ToString());
                    txtDienGiai.Text = dt2.Rows[0]["DienGiai"].ToString();
                    txtSoChungTu.Text = dt2.Rows[0]["SoChungTu"].ToString();
                    gridNguoiLap.EditValue = Convert.ToInt32(dt2.Rows[0]["ID_NguoiXuatKho"].ToString());
                    txtGhiChu.Text = cls1.sGhiChu.Value;
                }
               
                
            }
                
            
            HienThi_GridControl_Sua();
        }
        private void HienThi_GridControl_ThemMoi_newwwwwww()
        {

            
            double soluongthanhphamquydoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
            double tongsokg = Convert.ToDouble(txtTongSoKG.Text.ToString());
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(double));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(double));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("SoLuongTon", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("BoolVTChinh", typeof(bool));
            dt2.Columns.Add("BoolNPL", typeof(bool));
            clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new CtyTinLuong.clsDinhMuc_tbDM_NguyenPhuLieu();
            cls1.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
            DataTable dt1 = cls1.SelectOne();
            int iiID_DinhMucNPL = Convert.ToInt32(dt1.Rows[0]["ID_DinhMuc_NPL"].ToString());
            int iiID_VatTuChinh1 = Convert.ToInt32(dt1.Rows[0]["ID_VTHH_Chinh"].ToString());
            clsKhoBTP_tbChiTietNhapKho clskhoBTP = new clsKhoBTP_tbChiTietNhapKho();
            clskhoBTP.iID_VTHH = iiID_VatTuChinh1;
            DataTable dtkhoBTPvtuchinh1 = clskhoBTP.Select_W_ID_VTHH_w_Ten_VTHH_KhoDaiLy();
            if(dtkhoBTPvtuchinh1.Rows.Count>0)
            {
                double dongiaxxx = Convert.ToDouble(dtkhoBTPvtuchinh1.Rows[0]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiID_VatTuChinh1;
                _ravi["MaVT"] = iiID_VatTuChinh1;
                _ravi["TenVTHH"] = dtkhoBTPvtuchinh1.Rows[0]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dtkhoBTPvtuchinh1.Rows[0]["DonViTinh"].ToString();
                _ravi["DinhMuc"] = 1;
                _ravi["SoLuongTon"] = Convert.ToDouble(dtkhoBTPvtuchinh1.Rows[0]["SoLuongTon"].ToString());
                _ravi["SoLuongTheoDinhMuc"] = tongsokg;
                _ravi["SoLuong"] = tongsokg;
                _ravi["DonGia"] = dongiaxxx;
                _ravi["GhiChu"] = "";
                _ravi["HienThi"] = "1";
                _ravi["ThanhTien"] = tongsokg * dongiaxxx;
                _ravi["BoolVTChinh"] = true;
                dt2.Rows.Add(_ravi);
            }
            else
            {
                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID_VTHH"] = iiID_VatTuChinh1;
                _ravi2["MaVT"] = iiID_VatTuChinh1;
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiID_VatTuChinh1;
                DataTable dtvt = clsvt.SelectOne();
                _ravi2["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi2["DonViTinh"] = clsvt.sDonViTinh.Value;
                _ravi2["DinhMuc"] = 1;
                _ravi2["SoLuongTon"] = 0;
                _ravi2["SoLuongTheoDinhMuc"] = tongsokg;
                _ravi2["SoLuong"] = tongsokg;
                _ravi2["DonGia"] = 0;
                _ravi2["GhiChu"] = "";
                _ravi2["HienThi"] = "1";
                _ravi2["ThanhTien"] = 0;
                _ravi2["BoolVTChinh"] = true;
                dt2.Rows.Add(_ravi2);
            }

            clsDinhMuc_ChiTiet_DM_NPL clschitietDMNPL = new clsDinhMuc_ChiTiet_DM_NPL();
            clschitietDMNPL.iID_DinhMuc_NPL = iiID_DinhMucNPL;
            DataTable dtchitietDMNPL = clschitietDMNPL.Select_W_ID_DinhMuc_NPL_HienThiKhoDaiLy_Newwwwwwwww();
            //gridControl2.DataSource = dtchitietDMNPL;
            for (int i = 0; i < dtchitietDMNPL.Rows.Count; i++)
            {
                double dongiaxxx333, SoLuongTonxxxx;
                int ID_VTHHxx = Convert.ToInt32(dtchitietDMNPL.Rows[i]["ID_VTHH"].ToString());
                clsKhoNPL_tbChiTietNhapKho clsnhapkhonpl = new clsKhoNPL_tbChiTietNhapKho();
                clsnhapkhonpl.iID_VTHH = ID_VTHHxx;
                DataTable dtnpl = clsnhapkhonpl.SelectOne_W_ID_VTHH_w_Ten_VTHH();
                if (dtnpl.Rows.Count > 0)
                {
                    dongiaxxx333 = Convert.ToDouble(dtnpl.Rows[0]["DonGia"].ToString());
                    SoLuongTonxxxx = Convert.ToDouble(dtnpl.Rows[0]["SoLuongTon"].ToString());
                }
                else dongiaxxx333 = SoLuongTonxxxx = 0;
                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_VTHH"] = ID_VTHHxx;
                //_ravi3["MaVT"] = dtchitietDMNPL.Rows[i]["MaVT"].ToString();
                _ravi3["MaVT"] = ID_VTHHxx;
                _ravi3["TenVTHH"] = dtchitietDMNPL.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dtchitietDMNPL.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuongTon"] = SoLuongTonxxxx;
                string xxsoluong = dtchitietDMNPL.Rows[i]["SoLuong"].ToString();
                var xxdinhmuc = Math.Round(double.Parse(xxsoluong), 3);
                _ravi3["DinhMuc"] = xxdinhmuc;
                _ravi3["SoLuongTheoDinhMuc"] = xxdinhmuc * soluongthanhphamquydoi;
                _ravi3["SoLuong"] = xxdinhmuc * soluongthanhphamquydoi;
                _ravi3["DonGia"] = dongiaxxx333;
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = xxdinhmuc * soluongthanhphamquydoi * dongiaxxx333;
                _ravi3["BoolVTChinh"] = false;
                dt2.Rows.Add(_ravi3);

            }


            gridControl1.DataSource = dt2;
            
            double deTOngtien;

            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        
        private void HienThi_GridControl_Sua()
        {
           

            double soluongthanhpham = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
            double TongsoKG = Convert.ToDouble(txtTongSoKG.Text.ToString());
           
            gridControl1.DataSource = null;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(float));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("BoolVTChinh", typeof(bool));
            dt2.Columns.Add("BoolNPL", typeof(bool));

            clsDaiLy_tbChiTietNhapKho cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            cls.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            DataTable dt_ChiTiet_nhapkho_DaiLy = cls.SelectAll_W_ID_NhapKhoDaiLy();

            clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new CtyTinLuong.clsDinhMuc_tbDM_NguyenPhuLieu();
            cls1.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
            DataTable dt1 = cls1.SelectOne();
            int iiID_DinhMucNPL = Convert.ToInt32(dt1.Rows[0]["ID_DinhMuc_NPL"].ToString());
            int iiID_VatTuChinh1 = Convert.ToInt32(dt1.Rows[0]["ID_VTHH_Chinh"].ToString());
            clsKhoBTP_tbChiTietNhapKho clskhoBTP = new clsKhoBTP_tbChiTietNhapKho();
            clskhoBTP.iID_VTHH = iiID_VatTuChinh1;
            DataTable dtkhoBTPvtuchinh1 = clskhoBTP.Select_W_ID_VTHH_w_Ten_VTHH_KhoDaiLy();
            DataRow _ravi = dt2.NewRow();
            if (dtkhoBTPvtuchinh1.Rows.Count>0)
            {
                _ravi["TenVTHH"] = dtkhoBTPvtuchinh1.Rows[0]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dtkhoBTPvtuchinh1.Rows[0]["DonViTinh"].ToString();
            }
            else
            {
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiID_VatTuChinh1;
                DataTable dtvt = clsvt.SelectOne();
                _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi["DonViTinh"] = clsvt.sMaVT.Value;
            }
            cls.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            double soluongxuat = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["SoLuongNhap"].ToString());
            double dongiaxxx = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["DonGia"].ToString());
           
            _ravi["ID_VTHH"] = iiID_VatTuChinh1;
            _ravi["MaVT"] = iiID_VatTuChinh1;
           
            _ravi["DinhMuc"] = 1;
           // _ravi["SoLuongTon"] = Convert.ToDouble(dtkhoBTPvtuchinh1.Rows[0]["SoLuongTon"].ToString());
            _ravi["SoLuongTheoDinhMuc"] = TongsoKG;
            _ravi["SoLuong"] = soluongxuat;
            _ravi["DonGia"] = dongiaxxx;
            _ravi["GhiChu"] = "";
            _ravi["HienThi"] = "1";
            _ravi["ThanhTien"] = soluongxuat * dongiaxxx;
            _ravi["BoolVTChinh"] = true;

            dt2.Rows.Add(_ravi);
            for (int i = 2; i < dt_ChiTiet_nhapkho_DaiLy.Rows.Count; i++)
            {
                double dongiaxxx333 = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["DonGia"].ToString());
                DataRow _ravi3 = dt2.NewRow();
                int ID_VTHH = Convert.ToInt32(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["ID_VTHH"].ToString());
                _ravi3["ID_VTHH"] = ID_VTHH;
                _ravi3["MaVT"] = ID_VTHH;
                clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
                clvthh.iID_VTHH = ID_VTHH;
                DataTable dtvth = clvthh.SelectOne();
                _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
                if (i == 1)
                {
                    clsKhoBTP_tbChiTietNhapKho xcls = new clsKhoBTP_tbChiTietNhapKho();
                    xcls.iID_VTHH = ID_VTHH;
                    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                    if (dtbtp.Rows.Count > 0)
                        _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                }
                else
                {
                    clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
                    xcls.iID_VTHH = ID_VTHH;
                    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                    if (dtbtp.Rows.Count > 0)
                        _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                }

                clsDinhMuc_ChiTiet_DM_NPL clsdm = new clsDinhMuc_ChiTiet_DM_NPL();
                clsdm.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                clsdm.iID_VTHH = ID_VTHH;
                DataTable dtctietdinhmuc = clsdm.SelectOne_W_ID_VTHH_W_ID_DinhMuc_NPL();
                double xxxxsoluongdmimucc=0;
                if (dtctietdinhmuc.Rows.Count>0)
                {
                    string xxsoluongdmimuc = dtctietdinhmuc.Rows[0]["SoLuong"].ToString();
                     xxxxsoluongdmimucc = Math.Round(double.Parse(xxsoluongdmimuc), 3);
                }
                else
                {
                    xxxxsoluongdmimucc = 0;
                }

                
                _ravi3["DinhMuc"] = xxxxsoluongdmimucc;
                _ravi3["SoLuongTheoDinhMuc"] = xxxxsoluongdmimucc * soluongthanhpham;
                double SoLuong = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuong"] = SoLuong;
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dt_ChiTiet_nhapkho_DaiLy.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
                _ravi3["BoolVTChinh"] = false;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;

            double deTOngtien;
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }

 
        private void Load_LockUp()
        {


           

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=5";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            repositoryItemLookUpEdit2.DataSource = dtxx2;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";

            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
            DataTable dtdaily = clsdaily.SelectAll();
            dtdaily.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dtdaily.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";


            clsDinhMuc_tbDM_NguyenPhuLieu clsdinhmucnpl = new clsDinhMuc_tbDM_NguyenPhuLieu();
            DataTable dt2 = clsdinhmucnpl.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvnpl = dt2.DefaultView;
            DataTable newdtnpl = dvnpl.ToTable();


            gridMaDinhMucNPL.Properties.DataSource = newdtnpl;
            gridMaDinhMucNPL.Properties.ValueMember = "ID_DinhMuc_NPL";
            gridMaDinhMucNPL.Properties.DisplayMember = "MaDinhMuc";

            clsDinhMuc_tbDinhMuc_DOT clsdinhmucdot = new clsDinhMuc_tbDinhMuc_DOT();
            DataTable dt3 = clsdinhmucdot.SelectAll_TenVTHH();
            dt3.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv3 = dt3.DefaultView;
            dv3.Sort = "NgayThang DESC";
            DataTable dtxx3 = dv3.ToTable();


            gridMaDinhMucDot_BaoTo.Properties.DataSource = dtxx3;
            gridMaDinhMucDot_BaoTo.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoTo.Properties.DisplayMember = "SoHieu";

            gridMaDinhMucDot_BaoBe.Properties.DataSource = dtxx3;
            gridMaDinhMucDot_BaoBe.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoBe.Properties.DisplayMember = "SoHieu";


        }
        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }

            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }

            else if (gridMaDaiLy.EditValue == null)
            {
                MessageBox.Show("chưa chọn đại lý");
                return false;
            }
            else if (gridMaDinhMucDot_BaoTo.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao to");
                return false;
            }
            else if (gridMaDinhMucDot_BaoBe.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao bé");
                return false;
            }
            else if (gridMaDinhMucNPL.EditValue == null)
            {
                MessageBox.Show("chưa chọn định mức nguyên phụ liệu");
                return false;
            }
            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                return false;
            }
            else if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số chứng từ ");
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }

        private void Khoa_bang_DinhMucDot_DinhMuc_NPL()
        {

            if (!KiemTraLuu()) return ;
            else
            {
                clsDinhMuc_tbDinhMuc_DOT cls1 = new clsDinhMuc_tbDinhMuc_DOT();
                clsDinhMuc_tbDinhMuc_DOT cls2 = new clsDinhMuc_tbDinhMuc_DOT();
                clsDinhMuc_tbDM_NguyenPhuLieu cls3 = new clsDinhMuc_tbDM_NguyenPhuLieu();

                cls1.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
                cls1.Update_W_Khoa_True();

                cls2.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
                cls2.Update_W_Khoa_True();

                cls3.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls3.Update_W_Khoa_True();
              
            }
        }

        private void Luu_ChiTiet_NhapKho_DaiLy(int iiiID_NhapKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                dt2_cu = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();
                if (dt2_cu.Rows.Count > 0)
                {
                        cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai_W_ID_NhapKhoDaiLy();                   
                }
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_VTHH = iiiIDThanhPham_QuyDoi;
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fDonGia = 0;
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.bBoolTonDauKy = false;
                // Nhap kho Thành pham quy doi
                int ID_VTHHxxx_TP = iiiIDThanhPham_QuyDoi;
                string expression_TP;
                expression_TP = "ID_VTHH=" + ID_VTHHxxx_TP + "";
                DataRow[] foundRows_TP;
                foundRows_TP = dt2_cu.Select(expression_TP);
                if (foundRows_TP.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho_DaiLy = Convert.ToInt32(foundRows_TP[0]["ID_ChiTietNhapKho_DaiLy"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
                }
               // nhap kho vạt tư khác

                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaNhapKho = false;
                    cls2.bBoolTonDauKy = false;                
                 
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietNhapKho_DaiLy = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho_DaiLy"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                dt2_moi11111 = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho_DaiLy"].ToString());
                    cls2.iID_ChiTietNhapKho_DaiLy = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }


            }
        }

        private void Luu_ChiTiet_ChiTiet_XuatKho_NPL(int iiID_XUatKhoNPL)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + " and BoolVTChinh=False";
                DataView dvmoi = dtkkk.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();

                clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                dt2_cu = cls2.SelectAll_W_ID_XuatKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_XuatKho = iiID_XUatKhoNPL;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_TonTai_W_ID_XuatKho();
                }

                // Nhap kho 
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    int ID_VTHHxxx= Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_XuatKho = iiID_XUatKhoNPL;
                    cls2.iID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                    if (dtmoi.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia"].ToString());                    
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.sGhiChu = dtmoi.Rows[i]["GhiChu"].ToString();
                    cls2.bDaXuatKho = true;
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietXuatKho = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                    // updatesoluongton
                    try
                    {
                        clsKhoNPL_tbChiTietNhapKho clschitietnhapkho = new CtyTinLuong.clsKhoNPL_tbChiTietNhapKho();
                        int iiiID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                        double soluongxuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                        clschitietnhapkho.iID_VTHH = iiiID_VTHH;
                        DataTable dt2 = clschitietnhapkho.Select_W_ID_VTHH();
                        if (dt2.Rows.Count > 0)
                        {
                            Double douSoLuongTonCu;
                            douSoLuongTonCu = Convert.ToDouble(dt2.Rows[0]["SoLuongTon"].ToString());
                            clschitietnhapkho.iID_ChiTietNhapKho = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietNhapKho"].ToString());
                            clschitietnhapkho.fSoLuongTon = douSoLuongTonCu - soluongxuat;
                            clschitietnhapkho.Update_SoLuongTon();
                        }

                    }
                    catch
                    {

                    }
                }
               
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                dt2_moi11111 = cls2.SelectAll_W_ID_XuatKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietXuatKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_ChiTietXuatKho = ID_ChiTietXuatKhoxxxx;
                    cls2.Delete();
                }
                
            }
        }
        private void Luu_ChiLuu()
        {

            if (!KiemTraLuu()) return ;
            else
            {
                // khoá đại lý không cho xoá
                clsTbDanhMuc_DaiLy clsdailyxx = new clsTbDanhMuc_DaiLy();
                clsdailyxx.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                clsdailyxx.Update_W_Khoa();

                Khoa_bang_DinhMucDot_DinhMuc_NPL();
                bool bTrangThaiXuatNhap_KhoDaiLyxx, bTrangThaiXuatNhap_Kho_BTPxx, bTrangThaiXuatNhap_Kho_NPLxx, bCheck_BaoVexx, bCheck_DaiLyxx, bCheck_LaiXe, bDaNhapKhoxx;
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == true)
                {
                    clsDaiLy_tbNhapKho cls2 = new clsDaiLy_tbNhapKho();
                    cls2.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                    cls2.SelectOne();
                    bTrangThaiXuatNhap_KhoDaiLyxx = cls2.bTrangThaiXuatNhap_KhoDaiLy.Value;
                    bTrangThaiXuatNhap_Kho_BTPxx = cls2.bTrangThaiXuatNhap_Kho_BTP.Value;
                    bTrangThaiXuatNhap_Kho_NPLxx = cls2.bTrangThaiXuatNhap_Kho_NPL.Value;
                    bCheck_BaoVexx = cls2.bCheck_BaoVe.Value;
                    bCheck_DaiLyxx = cls2.bCheck_DaiLy.Value;
                    bCheck_LaiXe = cls2.bCheck_LaiXe.Value;
                    bDaNhapKhoxx = cls2.bDaNhapKho.Value;
                }
                else
                {

                    bTrangThaiXuatNhap_KhoDaiLyxx = bTrangThaiXuatNhap_Kho_BTPxx = bTrangThaiXuatNhap_Kho_NPLxx = bCheck_BaoVexx = bCheck_DaiLyxx = bCheck_LaiXe = bDaNhapKhoxx = false;
                }
                 clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTuKhoDaiLy.Text.ToString();
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.fSoLuongXuat_BaoTo = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
                cls1.fSoLuongXuat_BaoBe = Convert.ToDouble(txtSoLuong_BaoBe.Text.ToString());
                cls1.iID_DinhMucDot_BaoTo = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
                cls1.iID_DinhMucDot_BaoBe = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongTonThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.bHoanThanh = checkHoanThanh.Checked;
               
                cls1.bTrangThaiXuatNhap_KhoDaiLy = bTrangThaiXuatNhap_KhoDaiLyxx;
                cls1.bTrangThaiXuatNhap_Kho_BTP = bTrangThaiXuatNhap_Kho_BTPxx;
                cls1.bTrangThaiXuatNhap_Kho_NPL = bTrangThaiXuatNhap_Kho_NPLxx;
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.bDaNhapKho = bDaNhapKhoxx;
                cls1.bCheck_BaoVe = bCheck_BaoVexx;
                cls1.bCheck_DaiLy = bCheck_DaiLyxx;
                cls1.bCheck_LaiXe = bCheck_LaiXe;
                cls1.bBool_TonDauKy = false;
                if (checkHangDot.Checked == true)
                    cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;
                else cls1.iHangDoT_1_hangNhu_2_ConLai3 = 2;
                int iiiiID_NHapKhoDaiLy;
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbThemMoi_nhapKhoDaiLy == true)
                {
                    cls1.Insert();
                    iiiiID_NHapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
                }
                else
                {
                    cls1.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                    cls1.Update();
                    iiiiID_NHapKhoDaiLy=UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                }
                // chi tiết nhập kho
                Luu_ChiTiet_NhapKho_DaiLy(iiiiID_NHapKhoDaiLy);

                double deTOngtien_NPL;
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + " and BoolVTChinh=False";
                DataView dvmoi = dtkkk.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                object xxxx = dtmoi.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien_NPL = Convert.ToDouble(xxxx);
                else deTOngtien_NPL = 0;
                clsKhoNPL_tbXuatKho clsnplxk = new clsKhoNPL_tbXuatKho();
                clsnplxk.sThamChieu = cls1.sSoChungTu.Value;
                DataTable dt2npl = clsnplxk.SelectOne_W_ThamChieu_NhapKho_DaiLy();
                int ixiiiID_XuatkhoNPL;

                clsnplxk.sDienGiai = txtDienGiai.Text.ToString();
                clsnplxk.daNgayChungTu = dteNgayChungTu.DateTime;
                clsnplxk.sSoChungTu = txtSoChungTu.Text.ToString();
                clsnplxk.fTongTienHang = deTOngtien_NPL;
                clsnplxk.iID_NguoiXuatKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                clsnplxk.sThamChieu = txtSoChungTuKhoDaiLy.Text.ToString();
                clsnplxk.bTonTai = true;
                clsnplxk.bNgungTheoDoi = false;
                clsnplxk.bDaXuatKho = true;
             
                if (dt2npl.Rows.Count == 0)
                {
                    clsnplxk.Insert();
                    ixiiiID_XuatkhoNPL = clsnplxk.iID_XuatKhoNPL.Value;

                }
                else
                {
                    ixiiiID_XuatkhoNPL = Convert.ToInt32(dt2npl.Rows[0]["ID_XuatKhoNPL"].ToString());
                    clsnplxk.iID_XuatKhoNPL = ixiiiID_XuatkhoNPL;
                    clsnplxk.Update();
                }
                // chi tiết nhập kho
                Luu_ChiTiet_ChiTiet_XuatKho_NPL(ixiiiID_XuatkhoNPL);
            }
        }

        private void Luu_Va_GuiDuLieu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                // khoá đại lý không cho xoá
                clsTbDanhMuc_DaiLy clsdailyxx = new clsTbDanhMuc_DaiLy();
                clsdailyxx.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                clsdailyxx.Update_W_Khoa();
                Khoa_bang_DinhMucDot_DinhMuc_NPL();


                bool bTrangThaiXuatNhap_KhoDaiLyxx, bTrangThaiXuatNhap_Kho_BTPxx, bCheck_BaoVexx, bCheck_DaiLyxx, bCheck_LaiXe, bDaNhapKhoxx;
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == true)
                {
                    clsDaiLy_tbNhapKho cls2 = new clsDaiLy_tbNhapKho();
                    cls2.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                    cls2.SelectOne();
                    bTrangThaiXuatNhap_KhoDaiLyxx = cls2.bTrangThaiXuatNhap_KhoDaiLy.Value;
                    bTrangThaiXuatNhap_Kho_BTPxx = cls2.bTrangThaiXuatNhap_Kho_BTP.Value;
                   
                    bCheck_BaoVexx = cls2.bCheck_BaoVe.Value;
                    bCheck_DaiLyxx = cls2.bCheck_DaiLy.Value;
                    bCheck_LaiXe = cls2.bCheck_LaiXe.Value;
                    bDaNhapKhoxx = cls2.bDaNhapKho.Value;
                }
                else
                {

                    bTrangThaiXuatNhap_KhoDaiLyxx = bTrangThaiXuatNhap_Kho_BTPxx = bCheck_BaoVexx = bCheck_DaiLyxx = bCheck_LaiXe = bDaNhapKhoxx = false;
                }


                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTuKhoDaiLy.Text.ToString();
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.fSoLuongXuat_BaoTo = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
                cls1.fSoLuongXuat_BaoBe = Convert.ToDouble(txtSoLuong_BaoBe.Text.ToString());
                cls1.iID_DinhMucDot_BaoTo = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
                cls1.iID_DinhMucDot_BaoBe = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongTonThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.bHoanThanh = checkHoanThanh.Checked;
                cls1.bTrangThaiXuatNhap_KhoDaiLy = bTrangThaiXuatNhap_KhoDaiLyxx;
                cls1.bTrangThaiXuatNhap_Kho_BTP = bTrangThaiXuatNhap_Kho_BTPxx;
                cls1.bTrangThaiXuatNhap_Kho_NPL = true;
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.bDaNhapKho = bDaNhapKhoxx;
                cls1.bCheck_BaoVe = bCheck_BaoVexx;
                cls1.bCheck_DaiLy = bCheck_DaiLyxx;
                cls1.bCheck_LaiXe = bCheck_LaiXe;
                cls1.bBool_TonDauKy = false;
                if (checkHangDot.Checked == true)
                    cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;
                else cls1.iHangDoT_1_hangNhu_2_ConLai3 = 2;
                int iiiiID_NHapKhoDaiLy;
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbThemMoi_nhapKhoDaiLy == true)
                {
                    cls1.Insert();
                    iiiiID_NHapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
                }
                else
                {
                    cls1.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                    cls1.Update();
                    iiiiID_NHapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                }
                // chi tiết nhập kho
                Luu_ChiTiet_NhapKho_DaiLy(iiiiID_NHapKhoDaiLy);

                double deTOngtien_NPL;
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + " and BoolVTChinh=False";
                DataView dvmoi = dtkkk.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                object xxxx = dtmoi.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien_NPL = Convert.ToDouble(xxxx);
                else deTOngtien_NPL = 0;
                clsKhoNPL_tbXuatKho clsnplxk = new clsKhoNPL_tbXuatKho();
                clsnplxk.sThamChieu = cls1.sSoChungTu.Value;
                DataTable dt2npl = clsnplxk.SelectOne_W_ThamChieu_NhapKho_DaiLy();
                int ixiiiID_XuatkhoNPL;

                clsnplxk.sDienGiai = txtDienGiai.Text.ToString();
                clsnplxk.daNgayChungTu = dteNgayChungTu.DateTime;
                clsnplxk.sSoChungTu = txtSoChungTu.Text.ToString();
                clsnplxk.fTongTienHang = deTOngtien_NPL;
                clsnplxk.iID_NguoiXuatKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                clsnplxk.sThamChieu = txtSoChungTuKhoDaiLy.Text.ToString();
                clsnplxk.bTonTai = true;
                clsnplxk.bNgungTheoDoi = false;
                clsnplxk.bDaXuatKho = true;
                clsnplxk.bCheckXuatKho_Khac = false;
                if (dt2npl.Rows.Count == 0)
                {
                    clsnplxk.Insert();
                    ixiiiID_XuatkhoNPL = clsnplxk.iID_XuatKhoNPL.Value;

                }
                else
                {
                    ixiiiID_XuatkhoNPL = Convert.ToInt32(dt2npl.Rows[0]["ID_XuatKhoNPL"].ToString());
                    clsnplxk.iID_XuatKhoNPL = ixiiiID_XuatkhoNPL;
                    clsnplxk.Update();
                }
                // chi tiết nhập kho
                Luu_ChiTiet_ChiTiet_XuatKho_NPL(ixiiiID_XuatkhoNPL);

            }
        }

        public NPLChiTietNhapKho_DaiLy_ThemMoi()
        {
            InitializeComponent();
        }

        private void NPLChiTietNhapKho_DaiLy_ThemMoi_Load(object sender, EventArgs e)
        {
            mbPrint_Chitiet_XuatKho_DaiLyGiaCong = false;
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemLookUpEdit2.DataSource = newdtvthh;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";

            //txtTienCo.Text = "0";
            //txtTienNo.Text = "0";

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietDinhMucNPL", typeof(int));
            dt2.Columns.Add("ID_DinhMuc_NPL", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("MaVT");// 
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt2;
            Load_LockUp();
            if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbThemMoi_nhapKhoDaiLy == true)
                HienThi_ThemMoi_XuatKho();
            else
            {
                //textBox1.Text = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy.ToString(); 
                HienThi_Sua_XuatKho();
                
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
                }
            }
            catch
            {

            }
        }

        private void txtSoLuongXuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TinhTongSoKg_TongSoKien();
                
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == false)
                    
                    HienThi_GridControl_ThemMoi_newwwwwww();


            }
            catch
            {

            }
        }

        private void gridMaDinhMucNPL_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            
                clsDinhMuc_tbDM_NguyenPhuLieu clsncc = new clsDinhMuc_tbDM_NguyenPhuLieu();

                clsncc.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                miID_DinhMucNPL_XXx = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {

                    txtDienGiaiDMNPL.Text = dt.Rows[0]["DienGiai"].ToString();
                    
                }

                iiiIDThanhPham_QuyDoi = clsncc.iID_VTHH_ThanhPham.Value;
                txtID_thanhPham.Text = iiiIDThanhPham_QuyDoi.ToString();
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = iiiIDThanhPham_QuyDoi;
                DataTable dt1 = cls1.SelectOne();
                if (dt1.Rows.Count > 0)
                {

                    txtMaTPQuyDoi.Text = dt1.Rows[0]["MaVT"].ToString();
                    txtDVTThanhPhamQuyDoi.Text = dt1.Rows[0]["DonViTinh"].ToString();
                    txtTenThanhPhamQuyDoi.Text = dt1.Rows[0]["TenVTHH"].ToString();

                }

            try
            {
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == false)
                    ////HienThi_GridControl_Moiiiiiiiiiiii();
                    HienThi_GridControl_ThemMoi_newwwwwww();
            }
            catch
            {

            }

            //}
            //catch
            //{

            //}
        }

        private void gridMaDinhMucDot_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_tbDinhMuc_DOT clsncc = new clsDinhMuc_tbDinhMuc_DOT();
           
            clsncc.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();           
            try
            {
               
                double SoKG_1BaoTo = Convert.ToDouble(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_To = Convert.ToDouble(dt.Rows[0]["SoKienMotBao"].ToString());
                txtSoKG1Bao_To.Text = SoKG_1BaoTo.ToString();
                txtSoKien_1_BaoTo.Text = SoKienMotBao_To.ToString();
                TinhTongSoKg_TongSoKien();
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == false)
                    HienThi_GridControl_ThemMoi_newwwwwww();
            }
            catch
            {

            }
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void txtSoKien1Bao_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtSoLuong_BaoTo.Text.ToString() != "" & txtSoKien1Bao.Text.ToString() != "")
            //    {
            //        double soluongxuat = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
            //        double sokien1baoxxx = Convert.ToDouble(txtSoKien1Bao.Text.ToString());
            //        txtSoLuongThanhPhamQuyDoi.Text = (soluongxuat * sokien1baoxxx).ToString();

            //    }
            //}
            //catch
            //{

            //}
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuongTheoDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clBoolVTChinh, false);

                    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }
            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

                double deTOngtien;

                string shienthi = "1";
                DataTable dt2 = (DataTable)gridControl1.DataSource;
                object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHang.Text = deTOngtien.ToString();
            }

        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);
                //txtTienCo.Text = txtTongTienHang.Text;
                //txtTienNo.Text = txtTongTienHang.Text;

            }
            catch
            {

            }
        }
           

        private void txtDonGiaThanhPhamQuyDoi_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{

            //    if (Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clBoolVTChinh).ToString()) == true)
            //        e.Appearance.BackColor = Color.AntiqueWhite;


            //}
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_ChiLuu();
            MessageBox.Show("Đã lưu");
         
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Luu_Va_GuiDuLieu();
            MessageBox.Show("Đã lưu và gửi");           
           
        }

        private void checkHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                cls.iID_NhapKhoDaiLy = UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.miID_NhapKhoDaiLy;
                cls.bHoanThanh = checkHoanThanh.Checked;
                cls.Update_W_HoanThanh();

            }
            catch
            {

            }
        }

        private void checkHangDot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangDot.Checked == true)
            {
                //Load_LockUp_DinhMucDot();
                checkHangNhu.Checked = false;

                layoutControlItem1.Visibility = LayoutVisibility.Always;
                layoutControlItem22.Visibility = LayoutVisibility.Always;
                layoutControlItem20.Visibility = LayoutVisibility.Always;
                layoutControlItem27.Visibility = LayoutVisibility.Always;
                layoutControlItem25.Visibility = LayoutVisibility.Always;
                layoutControlItem16.Text = "Kg/ 1bao";
                layoutControlItem15.Text = "SL Bao To";
                layoutControlItem21.Text = "Tổng số Kg";
            }
        }

        private void checkHangNhu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangNhu.Checked == true)
            {
                //Load_LockUp_DinhMucDot();
                checkHangDot.Checked = false;
                layoutControlItem1.Visibility = LayoutVisibility.Never;
                layoutControlItem22.Visibility = LayoutVisibility.Never;
                layoutControlItem20.Visibility = LayoutVisibility.Never;
                layoutControlItem27.Visibility = LayoutVisibility.Never;
                layoutControlItem25.Visibility = LayoutVisibility.Never;
                layoutControlItem16.Text = "Cục/ 1bao";
                layoutControlItem15.Text = "Số lượng xuất";
                layoutControlItem21.Text = "Tổng số cục";
                txtSoLuong_BaoBe.Text = "0";
            }
        }
        
        private void txtDienGiaiDMNPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMaDinhMucDot_BaoBe_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_tbDinhMuc_DOT clsncc = new clsDinhMuc_tbDinhMuc_DOT();           
            clsncc.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();
            try
            {
               
                double SoKG_1BaoBe = Convert.ToDouble(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_Be = Convert.ToDouble(dt.Rows[0]["SoKienMotBao"].ToString());
                txtSoKG1Bao_Be.Text = SoKG_1BaoBe.ToString();               
                txtSoKien_1_BaoBe.Text = SoKienMotBao_Be.ToString();
                TinhTongSoKg_TongSoKien();
                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == false)
                    HienThi_GridControl_ThemMoi_newwwwwww();
            }
            catch
            {

            }
        }

        private void txtSoLuong_BaoBe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TinhTongSoKg_TongSoKien();

                if (UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong.mbSua == false)

                    HienThi_GridControl_ThemMoi_newwwwwww();


            }
            catch
            {

            }
        }

        private void txtSoChungTu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HienThi_GridControl_Sua();
        }
        
        private void btPrint_Click(object sender, EventArgs e)
        {
            
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();
            string shienthi = "1";
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            mdt_ChiTietXuatKho = dv.ToTable();
            if (mdt_ChiTietXuatKho.Rows.Count > 0)
            {
                mbPrint_Chitiet_XuatKho_DaiLyGiaCong = true;
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                msDiaChiDaiLy = clsncc.sDiaChi.Value;
                msSDTDaiLy = clsncc.sSoDienThoai.Value;
                msMaDaiLy = clsncc.sMaDaiLy.Value;
                msTenThanhPham = txtTenThanhPhamQuyDoi.Text.ToString();
                msdvtthanhphamquydoi = txtDVTThanhPhamQuyDoi.Text.ToString();
                msMaThanhPham = txtMaTPQuyDoi.Text.ToString();
                mfPrint_soluongtpqiuydoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                mdaNgayXuatKho = dteNgayChungTu.DateTime;
                msSoChungTu = txtSoChungTu.Text.ToString();
                msDienGiaig = txtDienGiai.Text.ToString();
                msThuKho = txtTenNguoiLap.Text.ToString();
                msNguoiNhan = txtTenDaiLy.Text.ToString();              
                msGhiChu = txtGhiChu.Text.ToString();
                frmPrint_nhapKho_DaiLy ff = new frmPrint_nhapKho_DaiLy();
                ff.Show();
            }



        }

        private void NPLChiTietNhapKho_DaiLy_ThemMoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            mbPrint_Chitiet_XuatKho_DaiLyGiaCong = false;
        }
    }
}
