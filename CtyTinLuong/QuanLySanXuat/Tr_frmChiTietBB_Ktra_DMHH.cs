﻿using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Tr_frmChiTietBB_Ktra_DMHH : Form
    {
        bool mbThemMoi_DOT;
        private void LuuDuLieu_BoSungCongNhan(int xxID_sophieu)
        {

            ////DataTable dv3 = (DataTable)gridControl1.DataSource;
            //clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls1 = new CtyTinLuong.clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot();
            //cls1.iID_SoPhieu = xxID_sophieu;
            //cls1.bGuiDuLieu = false;
            //cls1.Update_ALL_GuiDuLieu_W_ID_SoPhieu();
            //DataTable dt2_cu = cls1.SelectAll_W_ID_SoPhieu();
            //if (dv3.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dv3.Rows.Count; i++)
            //    {
            //        cls1.iID_SoPhieu = xxID_sophieu;
            //        cls1.iID_CongNhan = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
            //        int iID_CongNhanxxxx = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
            //        cls1.iID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_DOT.EditValue.ToString());
            //        cls1.daNgaySanXuat = dateNgayThang.DateTime;
            //        cls1.sCaSanXuat = cbCa.Text.ToString();
            //        cls1.bGuiDuLieu = true;
            //        cls1.bCheck_MayDot_True_May_Cat_False = true;

            //        string expressionnhapkho;
            //        expressionnhapkho = "ID_CongNhan=" + iID_CongNhanxxxx + "";
            //        DataRow[] foundRows;
            //        foundRows = dt2_cu.Select(expressionnhapkho);
            //        if (foundRows.Length > 0)
            //        {
            //            cls1.iID_ChiTietPhieu_BoSungMayDot = Convert.ToInt32(foundRows[0]["ID_ChiTietPhieu_BoSungMayDot"].ToString());
            //            cls1.Update();
            //        }
            //        else
            //        {
            //            cls1.Insert();
            //        }

            //    }

            //}
            //// xoa ton tai=false
            //clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls2 = new clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot();
            //DataTable dt2_moi11111 = new DataTable();
            //cls2.iID_SoPhieu = xxID_sophieu;
            //dt2_moi11111 = cls2.SelectAll_W_ID_SoPhieu();
            //dt2_moi11111.DefaultView.RowFilter = "GuiDuLieu = False";
            //DataView dvdt2_moi = dt2_moi11111.DefaultView;
            //DataTable dt2_moi = dvdt2_moi.ToTable();
            //for (int i = 0; i < dt2_moi.Rows.Count; i++)
            //{
            //    int ID_ChiTietPhieu_BoSungMayDotcccxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietPhieu_BoSungMayDot"].ToString());
            //    cls2.iID_ChiTietPhieu_BoSungMayDot = ID_ChiTietPhieu_BoSungMayDotcccxxx;
            //    cls2.Delete();
            //}
        }

      
        private void Luu_Va_GuiDuLieu_May_DOT()
        {
            //if (!KiemTraLuu_May_DOT()) return;
            //else
            //{
            //    clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
            //    cls2.iID_SoPhieu = SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu;
            //    cls2.sCaSanXuat = cbCa.Text.ToString();
            //    cls2.daNgaySanXuat = dateNgayThang.DateTime;
            //    DataTable dt3 = cls2.SelectAll_W_iID_SoPhieu_W_NgayThangSX_W_Ca_SX_Chon_May_DOT();
            //    int ID_ChiTietPhieuxxxx;
            //    bool bbbbbTrangThaiXuatNhap, bbbbbTrangThaiTaoLenhSanXuat;
            //    if (dt3.Rows.Count > 0)
            //    {                   
            //        bbbbbTrangThaiXuatNhap = Convert.ToBoolean(dt3.Rows[0]["TrangThaiXuatNhap"].ToString());
            //        bbbbbTrangThaiTaoLenhSanXuat = Convert.ToBoolean(dt3.Rows[0]["TrangThaiTaoLenhSanXuat"].ToString());
            //    }
            //    else
            //    {
                    
            //        bbbbbTrangThaiXuatNhap = bbbbbTrangThaiTaoLenhSanXuat = false;
            //    }
            //    clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
              
            //    int ID_May = Convert.ToInt32(gridMaMay_DOT.EditValue.ToString());
            //    int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_DOT.EditValue.ToString());
            //    int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_DOT.EditValue.ToString());
            //    DateTime NgaySanXuat = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            //    string CaSanXuat = cbCa.Text.ToString();

            //    int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_DOT.EditValue.ToString());
            //    double SoLuong_Vao = Convert.ToDouble(txtDonVi_first.Text.ToString());
            //    double DonGia_Vao = Convert.ToDouble(txtTrongLuong.Text.ToString());
            //    int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_DOT.EditValue.ToString());
            //    double SanLuong_Thuong = Convert.ToDouble(txtSoLuong.Text.ToString());                
            //    double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_DOT.Text.ToString());
            //    double PhePham = Convert.ToDouble(txtPhePham_May_DOT.Text.ToString());
            //    double SOKGMOTBAO=Convert.ToDouble(txtSoHieu.Text.ToString());
            //    double docaodot= Convert.ToDouble(txtDoCao.Text.ToString());
            //    int ID_DinhMuc_Luong = Convert.ToInt32(gridDinhMucSLMay_DOT.EditValue.ToString());
            //    cls.iID_SoPhieu = SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu; 
            //    cls.iID_May = ID_May;
            //    cls.iID_CongNhan = ID_CongNhan;
            //    cls.iID_CaTruong = ID_CaTruong;
            //    cls.daNgaySanXuat = NgaySanXuat;
            //    cls.sGhiChu = txtGhiChu_May_DOT.Text.ToString();
            //    cls.sCaSanXuat = CaSanXuat;
            //    cls.iID_DinhMuc_Luong = ID_DinhMuc_Luong;
            //    cls.iID_VTHH_Vao = ID_VTHH_Vao;
            //    cls.fSoLuong_Vao = SoLuong_Vao;
            //    cls.fDonGia_Vao = DonGia_Vao;
            //    cls.iID_VTHH_Ra = ID_VTHH_Ra;
            //    cls.fSanLuong_Thuong = SanLuong_Thuong;
            //    cls.fSanLuong_TangCa = 0;
            //    cls.fSanLuong_Tong = SanLuong_Thuong;
            //    cls.fDonGia_Xuat = DonGia_Xuat;
            //    cls.fPhePham = PhePham;
            //    cls.bBMay_IN = false;
            //    cls.bBMay_CAT = false;
            //    cls.bBMay_DOT = true;
            //    cls.bTrangThaiXuatNhap = bbbbbTrangThaiXuatNhap;
            //    cls.bGuiDuLieu = true;
            //    cls.bTrangThaiTaoLenhSanXuat = bbbbbTrangThaiTaoLenhSanXuat;
            //    cls.fSoKG_MotBao_May_Dot = SOKGMOTBAO;
            //    cls.fDoCao_Dot = docaodot;
            //    if (mbThemMoi_DOT == true)
            //    {
            //        cls.Insert();
            //        ID_ChiTietPhieuxxxx = cls.iID_ChiTietPhieu.Value;
            //    }
            //    else
            //    {
            //        ID_ChiTietPhieuxxxx = Convert.ToInt32(dt3.Rows[0]["ID_ChiTietPhieu"].ToString());
            //        cls.iID_ChiTietPhieu = ID_ChiTietPhieuxxxx;
            //        cls.Update();
            //    }
            //    TaoLenhSanXuat_DOT(SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu, ID_ChiTietPhieuxxxx);

            //    clsPhieu_tbPhieu cls22222 = new clsPhieu_tbPhieu();
            //    cls22222.iID_SoPhieu = SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu;
            //    cls22222.Update_Gui_DuLieu();
            //}

        }
        private void TaoLenhSanXuat_DOT(int xxIDSoPhieu, int iiiDID_ChiTietPhieu)
        {
            //clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

            //int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_DOT.EditValue.ToString());
            //int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_DOT.EditValue.ToString());
            //DateTime NgaySanXuat = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            //string CaSanXuat = cbCa.Text.ToString();

            //clsHUU_LenhSanXuat clsLSX = new clsHUU_LenhSanXuat();
            //clsLSX.iID_CaTruong = ID_CaTruong;
            //clsLSX.iID_LoaiMay = 3;
            //clsLSX.iID_CongNhan = ID_CongNhan;
            //clsLSX.daNgayThangSanXuat = NgaySanXuat;
            //clsLSX.sCaSanXuat = CaSanXuat;
            //DataTable dxLSX1 = clsLSX.SelectAll_TaoLenhSX_May_CaTruong_CongNhan_Ngay_CaSX_May_DOT();
            //int ID_LenhSanXuatxx;
            //if (dxLSX1.Rows.Count > 0)
            //{
            //    ID_LenhSanXuatxx = Convert.ToInt32(dxLSX1.Rows[0]["ID_LenhSanXuat"].ToString());

            //}
            //else
            //{
            //    clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
            //    DataTable xxdt1 = cls1.SelectAll();
            //    xxdt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            //    DataView xxxdv = xxdt1.DefaultView;
            //    DataTable xxxdv3 = xxxdv.ToTable();
            //    int k = xxxdv3.Rows.Count;
            //    string MaLenhSanXuat;
            //    if (xxxdv3.Rows.Count == 0)
            //        MaLenhSanXuat = "LSX1";
            //    else
            //    {
            //        string xxx = xxxdv3.Rows[k - 1]["MaLenhSanXuat"].ToString();
            //        int xxx2 = Convert.ToInt16(xxx.Substring(3).Trim()) + 1;
            //        MaLenhSanXuat = "LSX" + xxx2 + "";
            //    }

            //    // them moi lenh SX 
            //    clsLSX.iID_CaTruong = ID_CaTruong;
            //    clsLSX.iID_LoaiMay = 3;
            //    clsLSX.iID_CongNhan = ID_CongNhan;
            //    clsLSX.iID_NguoiLap = 12;
            //    clsLSX.daNgayThangSanXuat = NgaySanXuat;
            //    clsLSX.sCaSanXuat = CaSanXuat;
            //    clsLSX.sGhiChu = "";
            //    clsLSX.bTonTai = true;
            //    clsLSX.bNgungTheoDoi = false;
            //    clsLSX.sMaLenhSanXuat = MaLenhSanXuat;
            //    clsLSX.bGuiDuLieu = false;
            //    clsLSX.bBoolMayIn = false;
            //    clsLSX.bBoolMayCat = false;
            //    clsLSX.bBoolMayDot = true;
            //    clsLSX.bTrangThai_NhapKho_May_IN = false;
            //    clsLSX.bTrangThai_XuatKho_May_IN = false;
            //    clsLSX.bTrangThai_NhapKho_May_CAT = false;
            //    clsLSX.bTrangThai_XuatKho_May_CAT = false;
            //    clsLSX.bTrangThai_NhapKho_May_DOT = false;
            //    clsLSX.bTrangThai_XuatKho_May_DOT = false;
            //    clsLSX.Insert();
            //    ID_LenhSanXuatxx = clsLSX.iID_LenhSanXuat.Value;

            //}
            //LuuChiTietLenhSanXuat_DOT(xxIDSoPhieu, iiiDID_ChiTietPhieu, ID_LenhSanXuatxx);

            //cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            //cls.Update_TrangThaiTaoLenhSanXuat();

        }
        private void LuuChiTietLenhSanXuat_DOT(int xxIDSoPhieu, int iiiDID_ChiTietPhieu, int iiID_LenhnhanXuat)
        {
            //int ID_May = Convert.ToInt32(gridMaMay_DOT.EditValue.ToString());
            //int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_DOT.EditValue.ToString());
            //int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_DOT.EditValue.ToString());
            //DateTime NgaySanXuat = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            //string CaSanXuat = cbCa.Text.ToString();

            //int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_DOT.EditValue.ToString());
            //double SoLuong_Vao = Convert.ToDouble(txtDonVi_first.Text.ToString());
            //double DonGia_Vao = Convert.ToDouble(txtTrongLuong.Text.ToString());
            //int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_DOT.EditValue.ToString());
            //double SanLuong_Thuong = Convert.ToDouble(txtQuyDoiRaKG.Text.ToString());          
            //double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_DOT.Text.ToString());
            //double PhePham = Convert.ToDouble(txtPhePham_May_DOT.Text.ToString());
            //clsHUU_LenhSanXuat_ChiTietLenhSanXuat clsLSX_chitiet = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            //clsLSX_chitiet.iID_LenhSanXuat = iiID_LenhnhanXuat;
            //clsLSX_chitiet.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            //clsLSX_chitiet.iID_SoPhieu = xxIDSoPhieu;
            //clsLSX_chitiet.iID_VTHHVao = ID_VTHH_Vao;
            //clsLSX_chitiet.fSoLuongVao = SoLuong_Vao;
            //clsLSX_chitiet.iID_VTHHRa = ID_VTHH_Ra;
            //clsLSX_chitiet.fSanLuongThuong = SanLuong_Thuong;
            //clsLSX_chitiet.fSanLuongTangCa = 0;
            //clsLSX_chitiet.fPhePham = PhePham;
            //clsLSX_chitiet.fDonGiaVao = DonGia_Vao;
            //clsLSX_chitiet.fDonGiaRa = DonGia_Xuat;
            //clsLSX_chitiet.bNgungTheoDoi = false;
            //clsLSX_chitiet.bTonTai = true;
            //clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            //cls2.iID_LenhSanXuat = iiID_LenhnhanXuat;
            //cls2.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            //cls2.iID_SoPhieu = xxIDSoPhieu;
            //DataTable dt2 = cls2.SelectAll_ID_LenhSanXuat_ID_ChiTietPhieu_ID_SoPhieu();
            //if (dt2.Rows.Count > 0)
            //{
            //    clsLSX_chitiet.iID_ChiTietLenhSanXuat = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietLenhSanXuat"].ToString());
            //    clsLSX_chitiet.Update();
            //}
            //else
            //{
            //    clsLSX_chitiet.Insert();
            //}


        }
   
        private void Load_lockUP_EDIT_May_DOT()
        {
            //clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            //DataTable dtNguoi = clsNguoi.SelectAll();
            //dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=11";
            //DataView dvCongNhan = dtNguoi.DefaultView;
            //DataTable newdtCongNhan = dvCongNhan.ToTable();

            //gridMaCongNhan_May_DOT.Properties.DataSource = newdtCongNhan;
            //gridMaCongNhan_May_DOT.Properties.ValueMember = "ID_NhanSu";
            //gridMaCongNhan_May_DOT.Properties.DisplayMember = "MaNhanVien";

            //dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=8";
            //DataView dvCaTruong = dtNguoi.DefaultView;
            //DataTable newdtCaTruong = dvCaTruong.ToTable();

            //gridMaCaTruong_May_DOT.Properties.DataSource = newdtCaTruong;
            //gridMaCaTruong_May_DOT.Properties.ValueMember = "ID_NhanSu";
            //gridMaCaTruong_May_DOT.Properties.DisplayMember = "MaNhanVien";

            //clsTbVatTuHangHoa clsVTxxxx = new clsTbVatTuHangHoa();
            //DataTable dtVTxxx = clsVTxxxx.SelectAll();
            //dtVTxxx.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            //DataView dvVTxxx = dtVTxxx.DefaultView;
            //DataTable xxxxnewdtVT = dvVTxxx.ToTable();
            //gridHangHoaVao_may_DOT.Properties.DataSource = xxxxnewdtVT;
            //gridHangHoaVao_may_DOT.Properties.ValueMember = "ID_VTHH";
            //gridHangHoaVao_may_DOT.Properties.DisplayMember = "MaVT";

            //clsTbVatTuHangHoa clsxx = new clsTbVatTuHangHoa();
            //DataTable dtkksss = clsxx.SelectAll();
            //dtkksss.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            //DataView dvcxxx = dtkksss.DefaultView;
            //DataTable vdtrhh = dvcxxx.ToTable();
            //gridHangHoaXuat_May_DOT.Properties.DataSource = vdtrhh;
            //gridHangHoaXuat_May_DOT.Properties.ValueMember = "ID_VTHH";
            //gridHangHoaXuat_May_DOT.Properties.DisplayMember = "MaVT";


            //clsT_MayMoc clsMayMoc = new clsT_MayMoc();
            //DataTable dtMayIN = clsMayMoc.SelectAll();
            //dtMayIN.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and id_loai=3";
            //DataView dvMayIn = dtMayIN.DefaultView;
            //DataTable newdtMayIn = dvMayIn.ToTable();

            //gridMaMay_DOT.Properties.DataSource = newdtMayIn;
            //gridMaMay_DOT.Properties.ValueMember = "id";
            //gridMaMay_DOT.Properties.DisplayMember = "MaMay";


            //clsDinhMuc_DinhMuc_Luong_TheoSanLuong clssanluong = new CtyTinLuong.clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            //DataTable dtDinhMucSanLuong = clssanluong.SelectAll();
            //dtDinhMucSanLuong.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            //DataView dvsanluiong = dtDinhMucSanLuong.DefaultView;
            //DataTable newdtsanluong = dvsanluiong.ToTable();

            //gridDinhMucSLMay_DOT.Properties.DataSource = newdtsanluong;
            //gridDinhMucSLMay_DOT.Properties.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            //gridDinhMucSLMay_DOT.Properties.DisplayMember = "MaDinhMuc";


        }
      
        public Tr_frmChiTietBB_Ktra_DMHH()
        {
            InitializeComponent();
        }

        private void Tr_frmChiTietBB_Ktra_DMHH_Load(object sender, EventArgs e)
        {
            ////txtmidsohieu.Text = SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu.ToString();
            //HienThi_CongNhan();
            //Load_lockUP_EDIT_May_DOT();
            //HienThi_May_DOT();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void btChiLuu_Click(object sender, EventArgs e)
        {
            //Luu_Va_GuiDuLieu_May_DOT();
            //LuuDuLieu_BoSungCongNhan(SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222.MIiiiid_SoPhieu);
            //MessageBox.Show("Đã lưu");

        }
    }
}