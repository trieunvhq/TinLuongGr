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
    public partial class SanXuat_frmChiTietLenhSanXuat : Form
    {
        public static string msCaTruong, msCongNhan, msCaSanXuat,msTenMay, msNguoiLap;
         public static DataTable mdtLenhSanXuat;
          public static DateTime mdaNgayThang;
        //int iiiIDiID_CaTruong, iiiiID_CongNhan;
       
        //string sssssCa_May;
        //DateTime dadadaNgay_May;
        //int miID_LenhSX;
        private bool KiemTraLuu()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;

            if (txtLenhSX.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có mã lệnh");
                return false;
            }
            else if(cbCaSX.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn ca sản xuất");
                return false;
            }
            else if (dteNgaySX.EditValue==null)
            {
                MessageBox.Show("Chưa chọn ngày tháng");
                return false;
            }
            else if (gridMaCaTruong.EditValue==null)
            {
                MessageBox.Show("Chưa chọn ca trưởng");
                return false;
            }
            else if (gridMaCN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn công nhân");
                return false;
            }
            else if (gridMaNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa chọn người lập");
                return false;
            }
            else if(dttttt2.Rows.Count==0)
            {
                MessageBox.Show("Dữ liệu trống");
                return false;
            }
            else return true;

        }
    
        private void Luu_ChiLuu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                int iiiD_loaiMay = 0;
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();
                if (dv3.Rows[0]["LoaiMay"].ToString() == "1")
                    iiiD_loaiMay = 1;
                if (dv3.Rows[0]["LoaiMay"].ToString() == "2")
                    iiiD_loaiMay = 2;
                if (dv3.Rows[0]["LoaiMay"].ToString() == "3")
                    iiiD_loaiMay = 3;
                clsHUU_LenhSanXuat cls1 = new clsHUU_LenhSanXuat();
                cls1.sMaLenhSanXuat = txtLenhSX.Text.ToString();
                cls1.sCaSanXuat = cbCaSX.Text.ToString();
                cls1.daNgayThangSanXuat = dteNgaySX.DateTime;
                cls1.iID_CongNhan = Convert.ToInt32(gridMaCN.EditValue.ToString());
                cls1.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                cls1.iID_LoaiMay = iiiD_loaiMay;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridMaNguoiLap.EditValue.ToString());
                cls1.bTrangThai_NhapKho_May_CAT = false;
                cls1.bTrangThai_NhapKho_May_DOT = false;
                cls1.bTrangThai_NhapKho_May_IN = false;
                cls1.bTrangThai_XuatKho_May_CAT = false;
                cls1.bTrangThai_XuatKho_May_DOT = false;
                cls1.bTrangThai_XuatKho_May_IN = false;
                cls1.bGuiDuLieu = false;
                if (iiiD_loaiMay == 1)
                {
                    cls1.bBoolMayIn = true;
                    cls1.bBoolMayCat = false;
                    cls1.bBoolMayDot = false;
                }
                else if (iiiD_loaiMay == 2)
                {
                    cls1.bBoolMayIn = false;
                    cls1.bBoolMayCat = true;
                    cls1.bBoolMayDot = false;
                }
                else if (iiiD_loaiMay == 3)
                {
                    cls1.bBoolMayIn = false;
                    cls1.bBoolMayCat = false;
                    cls1.bBoolMayDot = true;
                }
                //if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat==true)
                //{
                //    cls1.Insert();
                //}
                //else
                //{
                    cls1.iID_LenhSanXuat = UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat;
                //}
             
               
               int  miID_LenhSX = cls1.iID_LenhSanXuat.Value;
                clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                // xoá trước
                cls.Delete_w_iID_LenhSanXuat();
                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    cls.iID_LenhSanXuat = miID_LenhSX;
                    cls.iID_ChiTietPhieu = Convert.ToInt32(dv3.Rows[i]["ID_ChiTietPhieu"].ToString());
                    cls.iID_SoPhieu = Convert.ToInt32(dv3.Rows[i]["ID_SoPhieu"].ToString());
                    cls.iID_VTHHVao = Convert.ToInt32(dv3.Rows[i]["ID_VTHH_Vao"].ToString());
                    cls.fSoLuongVao = Convert.ToDouble(dv3.Rows[i]["SoLuong_Vao"].ToString());
                    cls.iID_VTHHRa = Convert.ToInt32(dv3.Rows[i]["ID_VTHH_Ra"].ToString());
                    cls.fSanLuongThuong = Convert.ToDouble(dv3.Rows[i]["SanLuong_Thuong"].ToString());
                    cls.fSanLuongTangCa = Convert.ToDouble(dv3.Rows[i]["SanLuong_TangCa"].ToString());
                    cls.fPhePham = Convert.ToDouble(dv3.Rows[i]["PhePham"].ToString());
                    cls.fDonGiaVao = Convert.ToDouble(dv3.Rows[i]["DonGia_Vao"].ToString());
                    cls.fDonGiaRa = Convert.ToDouble(dv3.Rows[i]["DonGia_Xuat"].ToString());
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.Insert();
                   

                    //// update trang thai Phieu
                    //clsPhieu_ChiTietPhieu_New clsphieu = new clsPhieu_ChiTietPhieu_New();
                    //clsphieu.iID_ChiTietPhieu = Convert.ToInt32(dv3.Rows[i]["ID_ChiTietPhieu"].ToString());
                    //clsphieu.Update_TrangThaiTaoLenhSanXuat();
                }

            }
        }

        private void Luu_Va_Gui_DuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                int iiiD_loaiMay = 0;
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();
                if (dv3.Rows[0]["LoaiMay"].ToString() == "1")
                    iiiD_loaiMay = 1;
                if (dv3.Rows[0]["LoaiMay"].ToString() == "2")
                    iiiD_loaiMay = 2;
                if (dv3.Rows[0]["LoaiMay"].ToString() == "3")
                    iiiD_loaiMay = 3;

                clsHUU_LenhSanXuat cls1 = new clsHUU_LenhSanXuat();
                cls1.sMaLenhSanXuat = txtLenhSX.Text.ToString();
                cls1.sCaSanXuat = cbCaSX.Text.ToString();
                cls1.daNgayThangSanXuat = dteNgaySX.DateTime;
                cls1.iID_CongNhan = Convert.ToInt32(gridMaCN.EditValue.ToString());
                cls1.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                cls1.iID_LoaiMay = iiiD_loaiMay;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridMaNguoiLap.EditValue.ToString());
                cls1.bTrangThai_NhapKho_May_CAT = false;
                cls1.bTrangThai_NhapKho_May_DOT = false;
                cls1.bTrangThai_NhapKho_May_IN = false;
                cls1.bTrangThai_XuatKho_May_CAT = false;
                cls1.bTrangThai_XuatKho_May_DOT = false;
                cls1.bTrangThai_XuatKho_May_IN = false;
                cls1.bGuiDuLieu = true;
                if (iiiD_loaiMay == 1)
                {
                    cls1.bBoolMayIn = true;
                    cls1.bBoolMayCat = false;
                    cls1.bBoolMayDot = false;
                }
                else if (iiiD_loaiMay == 2)
                {
                    cls1.bBoolMayIn = false;
                    cls1.bBoolMayCat = true;
                    cls1.bBoolMayDot = false;
                }
                else if (iiiD_loaiMay == 3)
                {
                    cls1.bBoolMayIn = false;
                    cls1.bBoolMayCat = false;
                    cls1.bBoolMayDot = true;
                }
                cls1.Insert();
              int   miID_LenhSX = cls1.iID_LenhSanXuat.Value;
                clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                // xoá trước
                cls.Delete_w_iID_LenhSanXuat();
                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    cls.iID_LenhSanXuat = miID_LenhSX;
                    cls.iID_ChiTietPhieu = Convert.ToInt32(dv3.Rows[i]["ID_ChiTietPhieu"].ToString());
                    cls.iID_SoPhieu = Convert.ToInt32(dv3.Rows[i]["ID_SoPhieu"].ToString());
                    cls.iID_VTHHVao = Convert.ToInt32(dv3.Rows[i]["ID_VTHH_Vao"].ToString());
                    cls.fSoLuongVao = Convert.ToDouble(dv3.Rows[i]["SoLuong_Vao"].ToString());
                    cls.iID_VTHHRa = Convert.ToInt32(dv3.Rows[i]["ID_VTHH_Ra"].ToString());
                    cls.fSanLuongThuong = Convert.ToDouble(dv3.Rows[i]["SanLuong_Thuong"].ToString());
                    cls.fSanLuongTangCa = Convert.ToDouble(dv3.Rows[i]["SanLuong_TangCa"].ToString());
                    cls.fPhePham = Convert.ToDouble(dv3.Rows[i]["PhePham"].ToString());
                    cls.fDonGiaVao = Convert.ToDouble(dv3.Rows[i]["DonGia_Vao"].ToString());
                    cls.fDonGiaRa = Convert.ToDouble(dv3.Rows[i]["DonGia_Xuat"].ToString());
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.Insert();

                    // update trang thai Phieu
                    clsPhieu_ChiTietPhieu_New clsphieu = new clsPhieu_ChiTietPhieu_New();
                    clsphieu.iID_ChiTietPhieu = Convert.ToInt32(dv3.Rows[i]["ID_ChiTietPhieu"].ToString());
                    clsphieu.Update_TrangThaiTaoLenhSanXuat();
                }
                
            }
        }
        private void hienthiGridControl222222222()
        {
            //if (iiiIDiID_CaTruong.ToString() != "" & iiiiID_CongNhan.ToString() != "" & sssssCa_May.ToString() != "" & dadadaNgay_May != null)
            //{
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID_ChiTietPhieu", typeof(int));
                dt2.Columns.Add("ID_SoPhieu", typeof(int));
                dt2.Columns.Add("MaPhieu", typeof(string));
                dt2.Columns.Add("ID_VTHH_Vao", typeof(int));
                dt2.Columns.Add("ID_VTHH_Ra", typeof(int));
                dt2.Columns.Add("MaVT_Vao", typeof(string));
                dt2.Columns.Add("MaVT_Ra", typeof(string));
                dt2.Columns.Add("DonViTinh_Vao", typeof(string));
                dt2.Columns.Add("DonViTinh_Ra", typeof(string));
                dt2.Columns.Add("TenVatTu_Vao", typeof(string));
                dt2.Columns.Add("TenVatTu_Ra", typeof(string));
                dt2.Columns.Add("SoLuong_Vao", typeof(float));
                dt2.Columns.Add("SanLuong_Thuong", typeof(float));
                dt2.Columns.Add("SanLuong_TangCa", typeof(float));
                dt2.Columns.Add("PhePham", typeof(float));
                dt2.Columns.Add("DonGia_Vao", typeof(float));
                dt2.Columns.Add("DonGia_Xuat", typeof(float));
                dt2.Columns.Add("HienThi", typeof(string));
                dt2.Columns.Add("LoaiMay", typeof(string));
                clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();
                clsTbVatTuHangHoa clsVT_Ra = new clsTbVatTuHangHoa();
                DataTable dt3 = new DataTable();


                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                cls.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                cls.iID_CongNhan = Convert.ToInt32(gridMaCN.EditValue.ToString());
                cls.daNgaySanXuat = dteNgaySX.DateTime;
                cls.sCaSanXuat = cbCaSX.Text.ToString();
                DataTable dtxxsss = cls.Select_One_W_CongNhan_W_CaTruong_Ngay_CaSX();
                dtxxsss.DefaultView.RowFilter = "TrangThaiTaoLenhSanXuat=false";
                DataView dv = dtxxsss.DefaultView;               
                DataTable dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        

                        DataRow _ravi = dt2.NewRow();
                        _ravi["ID_ChiTietPhieu"] = Convert.ToInt32(dt.Rows[i]["ID_ChiTietPhieu"].ToString());
                        _ravi["ID_SoPhieu"] = Convert.ToInt32(dt.Rows[i]["ID_SoPhieu"].ToString());
                        _ravi["MaPhieu"] = dt.Rows[i]["MaPhieu"].ToString();
                        _ravi["ID_VTHH_Vao"] = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Vao"].ToString());
                        clsVT_Vao.iID_VTHH = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Vao"].ToString());
                        DataTable dtVT_vao = clsVT_Vao.SelectOne();
                        _ravi["MaVT_Vao"] = dtVT_vao.Rows[0]["MaVT"].ToString();
                        _ravi["DonViTinh_Vao"] = dtVT_vao.Rows[0]["DonViTinh"].ToString();
                        _ravi["TenVatTu_Vao"] = dtVT_vao.Rows[0]["TenVTHH"].ToString();

                        _ravi["ID_VTHH_Ra"] = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Ra"].ToString());
                        clsVT_Ra.iID_VTHH = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Ra"].ToString());
                        DataTable dtVT_Ra = clsVT_Ra.SelectOne();
                        _ravi["MaVT_Ra"] = dtVT_Ra.Rows[0]["MaVT"].ToString();
                        _ravi["DonViTinh_Ra"] = dtVT_Ra.Rows[0]["DonViTinh"].ToString();
                        _ravi["TenVatTu_Ra"] = dtVT_Ra.Rows[0]["TenVTHH"].ToString();

                        _ravi["SoLuong_Vao"] = Convert.ToDouble(dt.Rows[0]["SoLuong_Vao"].ToString());
                        _ravi["SanLuong_Thuong"] = Convert.ToDouble(dt.Rows[0]["SanLuong_Thuong"].ToString());
                        _ravi["SanLuong_TangCa"] = Convert.ToDouble(dt.Rows[0]["SanLuong_TangCa"].ToString());
                        _ravi["PhePham"] = Convert.ToDouble(dt.Rows[0]["PhePham"].ToString());
                        _ravi["DonGia_Vao"] = Convert.ToDouble(dt.Rows[0]["DonGia_Vao"].ToString());
                        _ravi["DonGia_Xuat"] = Convert.ToDouble(dt.Rows[0]["DonGia_Xuat"].ToString());
                        _ravi["HienThi"] = "1";
                        if (Convert.ToBoolean(dt.Rows[0]["bMay_IN"].ToString()) == true)
                            _ravi["LoaiMay"] = "1";
                        if (Convert.ToBoolean(dt.Rows[0]["bMay_CAT"].ToString()) == true)
                            _ravi["LoaiMay"] = "2";
                        if (Convert.ToBoolean(dt.Rows[0]["bMay_DOT"].ToString()) == true)
                            _ravi["LoaiMay"] = "3";
                        dt2.Rows.Add(_ravi);
                    }

                }
                
                gridControl1.DataSource = dt2;
            

        }
        private void HienThi_ThemMoi_LenhSanXuat()
        {
            gridMaNguoiLap.EditValue = 12;
            clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;

            if (dv3.Rows.Count == 0)
                txtLenhSX.Text = "LSX1";
            else
            {
                string xxx = dt1.Rows[k - 1]["MaLenhSanXuat"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(3).Trim()) + 1;
                if(xxx2>=10000)
                    txtLenhSX.Text = "LSX1";
                else
                txtLenhSX.Text = "LSX" + xxx2 + "";
            }
            dteNgaySX.EditValue = DateTime.Today;
            gridMaCaTruong.EditValue = null;
            gridMaCN.EditValue = null;
        }
        private void HienThi_SUa_LenhSanXuat()
        {
            DataTable dt2 = new DataTable();
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls2.iID_LenhSanXuat = UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat;
            DataTable dtxxxx = cls2.SelectAll_w_iID_LenhSanXuat();
           
            dt2.Columns.Add("ID_ChiTietPhieu", typeof(int));
            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("ID_VTHH_Vao", typeof(int));
            dt2.Columns.Add("ID_VTHH_Ra", typeof(int));
            dt2.Columns.Add("MaVT_Vao", typeof(string));
            dt2.Columns.Add("MaVT_Ra", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));
            dt2.Columns.Add("SoLuong_Vao", typeof(float));
            dt2.Columns.Add("SanLuong_Thuong", typeof(float));
            dt2.Columns.Add("SanLuong_TangCa", typeof(float));
            dt2.Columns.Add("PhePham", typeof(float));
            dt2.Columns.Add("DonGia_Vao", typeof(float));
            dt2.Columns.Add("DonGia_Xuat", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("LoaiMay", typeof(string));
            clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();
            clsTbVatTuHangHoa clsVT_Ra = new clsTbVatTuHangHoa();
            clsPhieu_tbPhieu clsphieu = new clsPhieu_tbPhieu();
            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietPhieu"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_ChiTietPhieu"].ToString());
                _ravi["ID_SoPhieu"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                clsphieu.iID_SoPhieu= Convert.ToInt32(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                DataTable dtphieu = clsphieu.SelectOne();
                _ravi["MaPhieu"] = dtphieu.Rows[0]["MaPhieu"].ToString();
                _ravi["ID_VTHH_Vao"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                clsVT_Vao.iID_VTHH = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                DataTable dtVT_vao = clsVT_Vao.SelectOne();
                _ravi["MaVT_Vao"] = dtVT_vao.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Vao"] = dtVT_vao.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Vao"] = dtVT_vao.Rows[0]["TenVTHH"].ToString();

                _ravi["ID_VTHH_Ra"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                clsVT_Ra.iID_VTHH = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                DataTable dtVT_Ra = clsVT_Ra.SelectOne();
                _ravi["MaVT_Ra"] = dtVT_Ra.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Ra"] = dtVT_Ra.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Ra"] = dtVT_Ra.Rows[0]["TenVTHH"].ToString();

                _ravi["SoLuong_Vao"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongVao"].ToString());
                _ravi["SanLuong_Thuong"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongThuong"].ToString());
                _ravi["SanLuong_TangCa"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongTangCa"].ToString());
                _ravi["PhePham"] = Convert.ToDouble(dtxxxx.Rows[i]["PhePham"].ToString());
                _ravi["DonGia_Vao"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaVao"].ToString());
                _ravi["DonGia_Xuat"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaRa"].ToString());

                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
                
            }
            gridControl1.DataSource = dt2;
            
            
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            cls.iID_LenhSanXuat = UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat;
            DataTable dt = cls.SelectOne();
            if (cls.bGuiDuLieu.Value == true)
            {
                //btLuu_ChiLuu.Enabled = false;
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
                //btLuu_Va_Gui_Copy.Enabled = false;
            }
            txtLenhSX.Text = cls.sMaLenhSanXuat.Value.ToString();
            dteNgaySX.EditValue = cls.daNgayThangSanXuat.Value;
            cbCaSX.Text = cls.sCaSanXuat.Value.ToString();
           // checkNgungTheoDoi.Checked = cls.bNgungTheoDoi.Value;
            gridMaCaTruong.EditValue = cls.iID_CaTruong.Value;
            gridMaCN.EditValue = cls.iID_CongNhan.Value;
            if (dt.Rows[0]["ID_NguoiLap"].ToString()!="")
                gridMaNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            txtGhiChu.Text = cls.sGhiChu.Value.ToString();           
        }
       
        private void Load_lockUP_EDIT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=8";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridMaCaTruong.Properties.DataSource = newdtCaTruong;
            gridMaCaTruong.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruong.Properties.DisplayMember = "MaNhanVien";

            
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvnguoilap = dtNguoi.DefaultView;
            DataTable newdtnguoilap = dvnguoilap.ToTable();

            gridMaNguoiLap.Properties.DataSource = newdtnguoilap;
            gridMaNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridMaNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dcvongnhan = dtNguoi.DefaultView;
            DataTable newdtcongnhan = dcvongnhan.ToTable();
            gridMaCN.Properties.DataSource = newdtcongnhan;
            gridMaCN.Properties.ValueMember = "ID_NhanSu";
            gridMaCN.Properties.DisplayMember = "MaNhanVien";

        }
        
        public SanXuat_frmChiTietLenhSanXuat()
        {
            InitializeComponent();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void SanXuat_frmChiTietLenhSanXuat_Load(object sender, EventArgs e)
        {
            // textBox4.Text = "" + UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat.ToString() + "; " + UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat.ToString() + "";
            clSanLuong_TangCa.Caption = "SL\n tăng ca";
            clSanLuong_Thuong.Caption = "Sản\n lượng";
            //LoadCombobox();
            Load_lockUP_EDIT();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("ID_VTHH_Vao", typeof(int));
            dt2.Columns.Add("ID_VTHH_Ra", typeof(int));
            dt2.Columns.Add("MaVT_Vao", typeof(string));
            dt2.Columns.Add("MaVT_Ra", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));
            dt2.Columns.Add("SoLuongNhap_May", typeof(float));
            dt2.Columns.Add("SanLuongThuong_May", typeof(float));
            dt2.Columns.Add("SanLuongTangCa_May", typeof(float));
            dt2.Columns.Add("PhePham_May", typeof(float));            //
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia_Vao", typeof(float));
            dt2.Columns.Add("DonGia_Ra", typeof(float));
            gridControl1.DataSource = dt2;
            HienThi_SUa_LenhSanXuat();




        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridMaCaTruong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                int iiiIDiID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                clsncc.iID_NhanSu = iiiIDiID_CaTruong;
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCaTruong.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                //if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
                //{
                //    if (gridMaCaTruong.EditValue != null & dteNgaySX.EditValue != null)
                //    {
                //        clsPhieu_ChiTietPhieu_New clsin = new clsPhieu_ChiTietPhieu_New();
                //        clsin.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                //        clsin.daNgaySanXuat = dteNgaySX.DateTime;
                //        clsin.sCaSanXuat = cbCaSX.Text.ToString();
                //        DataTable dtxx_DISTINCT = clsin.SelectAll_TaoLenhSX_W_CaTruong_CongNhan_Ngay_CaSX_DISTINCT();

                //        gridMaCN.Properties.DataSource = dtxx_DISTINCT;
                //        gridMaCN.Properties.ValueMember = "ID_NhanSu";
                //        gridMaCN.Properties.DisplayMember = "MaNhanVien";
                //    }
                //}



            }
            catch
            {

            }

        }

        private void gridMaCN_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCN.EditValue.ToString());
                int iiiiID_CongNhan= Convert.ToInt32(gridMaCN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCN.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
            try
            {
                //if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
                //{
                  
                //        hienthiGridControl222222222();
                //}

            }
            catch
            {

            }

        }

        private void gridMaNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaNguoiLap.EditValue.ToString());             
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenNguoilap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void btLuu_Va_Gui_Click(object sender, EventArgs e)
        {

            //UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat = true;
            Luu_Va_Gui_DuLieu();
            HienThi_ThemMoi_LenhSanXuat();
        }

        private void dteNgaySX_EditValueChanged(object sender, EventArgs e)
        {
          
            //dadadaNgay_May = dteNgaySX.DateTime;
            //try
            //{
            //    if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
            //    {
            //        if (gridMaCaTruong.EditValue != null & dteNgaySX.EditValue != null)
            //        {
            //            clsPhieu_ChiTietPhieu_New clsin = new clsPhieu_ChiTietPhieu_New();
            //            clsin.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
            //            clsin.daNgaySanXuat = dteNgaySX.DateTime;
            //            clsin.sCaSanXuat = cbCaSX.Text.ToString();
            //            DataTable dtin = clsin.SelectAll_TaoLenhSX_W_CaTruong_CongNhan_Ngay_CaSX_DISTINCT();
            //            gridMaCN.Properties.DataSource = dtin;
            //            gridMaCN.Properties.ValueMember = "ID_NhanSu";
            //            gridMaCN.Properties.DisplayMember = "MaNhanVien";
            //        }
            //    }

                
            //}
            //catch
            //{

            //}
           
           
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            //UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat = true;
            Luu_ChiLuu();
            this.Close();
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            //UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat = true;
            Luu_Va_Gui_DuLieu();
            this.Close();
        }

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cbCaSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sssssCa_May = cbCaSX.Text.ToString();
           
        }

       
        private void btPrint_Click(object sender, EventArgs e)        {
           
            if (!KiemTraLuu()) return;
            else
            {
              
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                mdtLenhSanXuat = dvmoi.ToTable();

               

                msCaTruong = txtTenCaTruong.Text.ToString();
                msCongNhan = txtTenCN.Text.ToString();
                msCaSanXuat = cbCaSX.Text.ToString();                
                msNguoiLap = txtTenNguoilap.Text.ToString();
                mdaNgayThang = dteNgaySX.DateTime;

                frmPrintLenhSanXuat_I_C_D ff = new frmPrintLenhSanXuat_I_C_D();
                ff.Show();
            }
        }

        private void btLuu_ChiLuu_Click(object sender, EventArgs e)
        {
            //UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat =true;
            Luu_ChiLuu();
            HienThi_ThemMoi_LenhSanXuat();
        }
      
    }
}
