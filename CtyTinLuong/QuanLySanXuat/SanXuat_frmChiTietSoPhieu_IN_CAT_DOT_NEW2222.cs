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
    public partial class SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222 : Form
    {
        public static int MIiiiid_SoPhieu;
     
        bool mbThemMoi_IN, mbThemMoi_CAT;
     
        private void Load_khoiDong()
        {
            mbThemMoi_IN = mbThemMoi_CAT = true;
            Load_lockUP_Phieu();
            HienThi_Phieu();
            Load_lockUP_EDIT_may_IN();
            HienThi_May_IN();
            Load_lockUP_EDIT_May_CAT();
            HienThi_May_CAT();
            
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == true)
            {
                btChuyen.Visible = false;
                try
                {
                   
                    clsHUU_CaiMacDinh_DinhMuc_SanXuat clsmd = new clsHUU_CaiMacDinh_DinhMuc_SanXuat();
                    DataTable dtmdc = clsmd.SelectAll();
                    gridDinhMucSLMay_IN.EditValue = Convert.ToInt32(dtmdc.Rows[1]["ID_DinhMucLuong_TheoSanLuong"].ToString());
                    gridDinhMucSLMay_CAT.EditValue = Convert.ToInt32(dtmdc.Rows[0]["ID_DinhMucLuong_TheoSanLuong"].ToString());
                    
                }
                catch
                {

                }
                
            }
            if (UC_SanXuat_PhieuSanXuat.mb_Sua_SoPhieu == true)
            {
                MIiiiid_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                btChuyen.Visible = true;
            }


        }
         
    
        private void HienThi_Phieu()
        {
            if(UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu==true)
            {
                dteNgayLap.DateTime = DateTime.Today;
            }
            else if (UC_SanXuat_PhieuSanXuat.mbCopy_Phieu == true)
            {
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                DataTable dxxxx = cls.SelectOne();
                //txtMaPhieu.Text = cls.sMaPhieu.Value;
                dteNgayLap.EditValue = cls.daNgayLapPhieu.Value;
                cbCaSanXuatPhieu.Text = cls.sCaSanXuat.Value;
                gridMaCaTruongPhieu.EditValue = cls.iID_CaTruong.Value;
                txtGhiChuPhieu.Text = cls.sGhiChu.Value;
                checkHoanThanh.Checked = cls.bDaKetThuc.Value;
            }
            else if (UC_SanXuat_PhieuSanXuat.mb_Sua_SoPhieu == true)
            {
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                DataTable dxxxx = cls.SelectOne();
                txtMaPhieu.Text = cls.sMaPhieu.Value;
                dteNgayLap.EditValue = cls.daNgayLapPhieu.Value;
                cbCaSanXuatPhieu.Text = cls.sCaSanXuat.Value;
                gridMaCaTruongPhieu.EditValue = cls.iID_CaTruong.Value;
                txtGhiChuPhieu.Text = cls.sGhiChu.Value;
                checkHoanThanh.Checked = cls.bDaKetThuc.Value;
            }
            
            
        }
        private bool KiemTraLuu_Phieu()
        {
           
            if (txtMaPhieu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã phiếu ");
                return false;
            }
            else if (gridMaCaTruongPhieu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ca trưởng ");
                return false;
            }
            else if (cbCaSanXuatPhieu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn ca làm việc ");
                return false;
            }
            else if (dteNgayLap.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày lập ");
                return false;
            }

            else return true;

        }
      
        private void Luu_Va_Gui_DuLieu()
        {
            if (!KiemTraLuu_Phieu()) return;
            else
            {
                btChuyen.Visible = true;
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.sMaPhieu = txtMaPhieu.Text.ToString();
                cls.daNgayLapPhieu = dteNgayLap.DateTime;
                cls.sCaSanXuat = cbCaSanXuatPhieu.Text.ToString();
                cls.iID_CaTruong = Convert.ToInt16(gridMaCaTruongPhieu.EditValue.ToString());
                cls.sGhiChu = txtGhiChuPhieu.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bGuiDuLieu = false;
                cls.bCheck_In = false;
                cls.bCheck_Cat = false;
                cls.bCheck_Dot = false;
                cls.iBienTrangThai = 0;
                cls.bDaKetThuc = checkHoanThanh.Checked;
                int iiiiID_SoPhieu;
                if (UC_SanXuat_PhieuSanXuat.mb_Sua_SoPhieu == false)
                {
                    cls.Insert();
                    iiiiID_SoPhieu = cls.iID_SoPhieu.Value;
                }
                else
                {
                    cls.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                    cls.Update();
                    iiiiID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                }
                MIiiiid_SoPhieu = iiiiID_SoPhieu;
                cls.iID_SoPhieu = iiiiID_SoPhieu;
                cls.Update_Gui_DuLieu();
                
                Luu_Va_GuiDuLieu_May_IN(iiiiID_SoPhieu);
              
                Luu_Va_GuiDuLieu_May_CAT(iiiiID_SoPhieu);
               
                MessageBox.Show("Đã lưu + và gửi dữ liệu");
            }
        }
        private void Load_lockUP_Phieu()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();           

            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=8";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();
            gridMaCaTruongPhieu.Properties.DataSource = newdtCaTruong;
            gridMaCaTruongPhieu.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruongPhieu.Properties.DisplayMember = "MaNhanVien";
            

        }
      
   
        private void HienThi_May_IN()
        {
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == false)
            {
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                cls.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                DataTable dxxxx = cls.SelectAll_W_iID_SoPhieu();
                dxxxx.DefaultView.RowFilter = "bMay_IN = True";
                DataView dv = dxxxx.DefaultView;
                DataTable dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    mbThemMoi_IN = false;
                    int ID_ChiTietPhieu = Convert.ToInt32(dt.Rows[0]["ID_ChiTietPhieu"].ToString());
                    int ID_SoPhieu = Convert.ToInt32(dt.Rows[0]["ID_SoPhieu"].ToString());
                    int ID_May = Convert.ToInt32(dt.Rows[0]["ID_May"].ToString());
                    int ID_CongNhan = Convert.ToInt32(dt.Rows[0]["ID_CongNhan"].ToString());
                    int ID_CaTruong = Convert.ToInt32(dt.Rows[0]["ID_CaTruong"].ToString());
                    DateTime NgaySanXuat = Convert.ToDateTime(dt.Rows[0]["NgaySanXuat"].ToString());
                    string GhiChu = dt.Rows[0]["GhiChu"].ToString();
                    string CaSanXuat = dt.Rows[0]["CaSanXuat"].ToString();
                    int ID_DinhMuc_Luong = Convert.ToInt32(dt.Rows[0]["ID_DinhMuc_Luong"].ToString());
                    int ID_VTHH_Vao = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Vao"].ToString());
                    double SoLuong_Vao = Convert.ToDouble(dt.Rows[0]["SoLuong_Vao"].ToString());
                    double DonGia_Vao = Convert.ToDouble(dt.Rows[0]["DonGia_Vao"].ToString());
                    int ID_VTHH_Ra = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Ra"].ToString());

                    double SanLuong_Thuong = Convert.ToDouble(dt.Rows[0]["SanLuong_Thuong"].ToString());
                    double SanLuong_TangCa = Convert.ToDouble(dt.Rows[0]["SanLuong_TangCa"].ToString());
                    double SanLuong_Tong = Convert.ToDouble(dt.Rows[0]["SanLuong_Tong"].ToString());
                    double DonGia_Xuat = Convert.ToDouble(dt.Rows[0]["DonGia_Xuat"].ToString());
                    double PhePham = Convert.ToDouble(dt.Rows[0]["PhePham"].ToString());

                    gridMaCaTruong_May_IN.EditValue = ID_CaTruong;
                    dteNgaySanXuat_May_IN.EditValue = NgaySanXuat;
                    cbCaSanXuat_May_IN.Text = CaSanXuat;
                    gridHangHoaVao_may_IN.EditValue = ID_VTHH_Vao;
                    gridMaMay_IN.EditValue = ID_May;

                    gridDinhMucSLMay_IN.EditValue = ID_DinhMuc_Luong;
                    txtSoLuongNhap_May_IN.Text = SoLuong_Vao.ToString();
                    txtDonGiaXuat_May_IN.Text = DonGia_Vao.ToString();
                    txtDonGiaNhap_May_IN.Text = DonGia_Vao.ToString();
                    txtSanLuong_Thuong_may_IN.Text = SanLuong_Thuong.ToString();
                    txtSanLuong_tangca_May_IN.Text = SanLuong_TangCa.ToString();
                    txtSanLuongTong_May_IN.Text = SanLuong_Tong.ToString();
                    gridHangHoaXuat_May_IN.EditValue = ID_VTHH_Ra;
                    txtPhePham_May_IN.Text = PhePham.ToString();
                    txtGhiChu_May_IN.Text = GhiChu.ToString();
                    gridMaCongNhan_May_IN.EditValue = ID_CongNhan;
                }

                else mbThemMoi_IN = true;


            }
        }
        private bool KiemTraLuu_MayIn()
        {
            if (txtSanLuongTong_May_IN.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có sản lượng ");
                return false;
            }
            else if (gridHangHoaVao_may_IN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn vật tư vào  ");
                return false;
            }
            else if (gridHangHoaXuat_May_IN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn vật tư ra  ");
                return false;
            }
            else if (gridMaMay_IN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn máy gia công  ");
                return false;
            }

            else if (gridMaCongNhan_May_IN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn công nhân  ");
                return false;
            }
            else if (gridDinhMucSLMay_IN.EditValue == null)
            {
                MessageBox.Show("Chưa định mức lương sản lượng  ");
                return false;
            }
            else return true;

        }
      
        private void Luu_Va_GuiDuLieu_May_IN(int xxIDSoPhieu)
        {
            if (!KiemTraLuu_MayIn()) return;
            else
            {
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                int ID_May = Convert.ToInt32(gridMaMay_IN.EditValue.ToString());
                int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
                int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_IN.EditValue.ToString());
                DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_IN.EditValue.ToString());
                string GhiChu = txtGhiChu_May_IN.Text.ToString();
                string CaSanXuat = cbCaSanXuat_May_IN.Text.ToString();
                int ID_DinhMuc_Luong = Convert.ToInt32(gridDinhMucSLMay_IN.EditValue.ToString());
                int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());
                double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_IN.Text.ToString());
                double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_IN.Text.ToString());
                int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
                double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_IN.Text.ToString());
                double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_IN.Text.ToString());
                double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_IN.Text.ToString());
                double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_IN.Text.ToString());
                double PhePham = Convert.ToDouble(txtPhePham_May_IN.Text.ToString());

                cls.iID_SoPhieu = xxIDSoPhieu;
                cls.iID_May = ID_May;
                cls.iID_CongNhan = ID_CongNhan;
                cls.iID_CaTruong = ID_CaTruong;
                cls.daNgaySanXuat = NgaySanXuat;
                cls.sGhiChu = GhiChu;
                cls.sCaSanXuat = CaSanXuat;
                cls.iID_DinhMuc_Luong = ID_DinhMuc_Luong;
                cls.iID_VTHH_Vao = ID_VTHH_Vao;
                cls.fSoLuong_Vao = SoLuong_Vao;
                cls.fDonGia_Vao = DonGia_Vao;
                cls.iID_VTHH_Ra = ID_VTHH_Ra;
                cls.fSanLuong_Thuong = SanLuong_Thuong;
                cls.fSanLuong_TangCa = SanLuong_TangCa;
                cls.fSanLuong_Tong = SanLuong_Tong;
                cls.fDonGia_Xuat = DonGia_Xuat;
                cls.fPhePham = PhePham;
                cls.bBMay_IN = true;
                cls.bBMay_CAT = false;
                cls.bBMay_DOT = false;
                cls.bTrangThaiXuatNhap = false;
                cls.bGuiDuLieu = true;
                cls.bTrangThaiTaoLenhSanXuat = false;
                cls.fSoKG_MotBao_May_Dot = 0;
                cls.fDoCao_Dot = 0;
                int iiiDID_ChiTietPhieuxxx;
                if (mbThemMoi_IN == true) // them moi
                {
                    cls.Insert();
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                }
                else
                {
                    clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
                    cls2.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                    cls2.sCaSanXuat = cbCaSanXuat_May_IN.Text.ToString();
                    cls2.daNgaySanXuat = dteNgaySanXuat_May_IN.DateTime;
                    DataTable dt1 = cls2.SelectAll_W_iID_SoPhieu_W_NgayThangSX_W_Ca_SX_Chon_May_IN();
                    iiiDID_ChiTietPhieuxxx = Convert.ToInt32(dt1.Rows[0]["ID_ChiTietPhieu"].ToString());
                    cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieuxxx;
                    cls.Update();
                }

                TaoLenhSanXuat_IN(xxIDSoPhieu, iiiDID_ChiTietPhieuxxx);
            }
        }

        private void TaoLenhSanXuat_IN(int xxIDSoPhieu, int iiiDID_ChiTietPhieu)
        {
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            if (cbCaSanXuat_May_IN.Text.ToString() != "" & dteNgaySanXuat_May_IN.Text.ToString() != "")
            {
                
                int ID_May = Convert.ToInt32(gridMaMay_IN.EditValue.ToString());
                int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
                int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_IN.EditValue.ToString());
                DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_IN.EditValue.ToString());
                string CaSanXuat = cbCaSanXuat_May_IN.Text.ToString();

                int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());
                double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_IN.Text.ToString());
                double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_IN.Text.ToString());
                int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
                double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_IN.Text.ToString());
                double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_IN.Text.ToString());
                double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_IN.Text.ToString());
                double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_IN.Text.ToString());
                double PhePham = Convert.ToDouble(txtPhePham_May_IN.Text.ToString());

                clsHUU_LenhSanXuat clsLSX = new clsHUU_LenhSanXuat();
                clsLSX.iID_CaTruong = ID_CaTruong;
                clsLSX.iID_LoaiMay = 1;
                clsLSX.iID_CongNhan = ID_CongNhan;
                clsLSX.daNgayThangSanXuat = NgaySanXuat;
                clsLSX.sCaSanXuat = CaSanXuat;
                DataTable dxLSX1 = clsLSX.SelectAll_TaoLenhSX_May_CaTruong_CongNhan_Ngay_CaSX_May_IN();
                int ID_LenhSanXuatxx;
                if (dxLSX1.Rows.Count > 0)
                {
                    ID_LenhSanXuatxx = Convert.ToInt32(dxLSX1.Rows[0]["ID_LenhSanXuat"].ToString());
                   
                }
                else
                {
                    clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
                    DataTable xxdt1 = cls1.SelectAll();
                    xxdt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                    DataView xxxdv = xxdt1.DefaultView;
                    DataTable xxxdv3 = xxxdv.ToTable();
                    int k = xxxdv3.Rows.Count;
                    string MaLenhSanXuat;
                    if (xxxdv3.Rows.Count == 0)
                        MaLenhSanXuat = "LSX1";
                    else
                    {
                        string xxx = xxxdv3.Rows[k - 1]["MaLenhSanXuat"].ToString();
                        int xxx2 = Convert.ToInt16(xxx.Substring(3).Trim()) + 1;
                        MaLenhSanXuat = "LSX" + xxx2 + "";
                    }

                    // them moi lenh SX 
                    clsLSX.iID_CaTruong = ID_CaTruong;
                    clsLSX.iID_LoaiMay = 1;
                    clsLSX.iID_CongNhan = ID_CongNhan;
                    clsLSX.iID_NguoiLap = 12;
                    clsLSX.daNgayThangSanXuat = NgaySanXuat;
                    clsLSX.sCaSanXuat = CaSanXuat;
                    clsLSX.sGhiChu = "";
                    clsLSX.bTonTai = true;
                    clsLSX.bNgungTheoDoi = false;
                    clsLSX.sMaLenhSanXuat = MaLenhSanXuat;
                    clsLSX.bGuiDuLieu = false;
                    clsLSX.bBoolMayIn = true;
                    clsLSX.bBoolMayCat = false;
                    clsLSX.bBoolMayDot = false;
                    clsLSX.bTrangThai_NhapKho_May_IN = false;
                    clsLSX.bTrangThai_XuatKho_May_IN = false;
                    clsLSX.bTrangThai_NhapKho_May_CAT = false;
                    clsLSX.bTrangThai_XuatKho_May_CAT = false;
                    clsLSX.bTrangThai_NhapKho_May_DOT = false;
                    clsLSX.bTrangThai_XuatKho_May_DOT = false;
                    clsLSX.Insert();
                    ID_LenhSanXuatxx = clsLSX.iID_LenhSanXuat.Value;
                   
                }
                LuuChiTietLenhSanXuat_IN(xxIDSoPhieu, iiiDID_ChiTietPhieu, ID_LenhSanXuatxx);

                cls.iID_ChiTietPhieu =iiiDID_ChiTietPhieu;
                cls.Update_TrangThaiTaoLenhSanXuat();


            }


        }

        private void TaoLenhSanXuat_CAT(int xxIDSoPhieu, int iiiDID_ChiTietPhieu)
        {
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            if (cbCaSanXuat_May_CAT.Text.ToString() != "" & dteNgaySanXuat_May_CAT.Text.ToString() != "")
            {
                int ID_May = Convert.ToInt32(gridMaMay_CAT.EditValue.ToString());
                int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_CAT.EditValue.ToString());
                int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_CAT.EditValue.ToString());
                DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_CAT.EditValue.ToString());
                string CaSanXuat = cbCaSanXuat_May_CAT.Text.ToString();

                int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_CAT.EditValue.ToString());
                double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_CAT.Text.ToString());
                double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_CAT.Text.ToString());
                int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_CAT.EditValue.ToString());
                double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_CAT.Text.ToString());
                double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_CAT.Text.ToString());
                double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_CAT.Text.ToString());
                double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_CAT.Text.ToString());
                double PhePham = Convert.ToDouble(txtPhePham_May_CAT.Text.ToString());


                clsHUU_LenhSanXuat clsLSX = new clsHUU_LenhSanXuat();
                clsLSX.iID_CaTruong = ID_CaTruong;
                clsLSX.iID_LoaiMay = 2;
                clsLSX.iID_CongNhan = ID_CongNhan;
                clsLSX.daNgayThangSanXuat = NgaySanXuat;
                clsLSX.sCaSanXuat = CaSanXuat;
                DataTable dxLSX1 = clsLSX.SelectAll_TaoLenhSX_May_CaTruong_CongNhan_Ngay_CaSX_May_CAT();
                int ID_LenhSanXuatxx;
                if (dxLSX1.Rows.Count > 0)
                {
                    ID_LenhSanXuatxx = Convert.ToInt32(dxLSX1.Rows[0]["ID_LenhSanXuat"].ToString());

                }
                else
                {
                    clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
                    DataTable xxdt1 = cls1.SelectAll();
                    xxdt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                    DataView xxxdv = xxdt1.DefaultView;
                    DataTable xxxdv3 = xxxdv.ToTable();
                    int k = xxxdv3.Rows.Count;
                    string MaLenhSanXuat;
                    if (xxxdv3.Rows.Count == 0)
                        MaLenhSanXuat = "LSX1";
                    else
                    {
                        string xxx = xxxdv3.Rows[k - 1]["MaLenhSanXuat"].ToString();
                        int xxx2 = Convert.ToInt16(xxx.Substring(3).Trim()) + 1;
                        MaLenhSanXuat = "LSX" + xxx2 + "";
                    }

                    // them moi lenh SX 
                    clsLSX.iID_CaTruong = ID_CaTruong;
                    clsLSX.iID_LoaiMay = 2;
                    clsLSX.iID_CongNhan = ID_CongNhan;
                    clsLSX.iID_NguoiLap = 12;
                    clsLSX.daNgayThangSanXuat = NgaySanXuat;
                    clsLSX.sCaSanXuat = CaSanXuat;
                    clsLSX.sGhiChu = "";
                    clsLSX.bTonTai = true;
                    clsLSX.bNgungTheoDoi = false;
                    clsLSX.sMaLenhSanXuat = MaLenhSanXuat;
                    clsLSX.bGuiDuLieu = false;
                    clsLSX.bBoolMayIn = false;
                    clsLSX.bBoolMayCat = true;
                    clsLSX.bBoolMayDot = false;
                    clsLSX.bTrangThai_NhapKho_May_IN = false;
                    clsLSX.bTrangThai_XuatKho_May_IN = false;
                    clsLSX.bTrangThai_NhapKho_May_CAT = false;
                    clsLSX.bTrangThai_XuatKho_May_CAT = false;
                    clsLSX.bTrangThai_NhapKho_May_DOT = false;
                    clsLSX.bTrangThai_XuatKho_May_DOT = false;
                    clsLSX.Insert();
                    ID_LenhSanXuatxx = clsLSX.iID_LenhSanXuat.Value;

                }
                LuuChiTietLenhSanXuat_CAT(xxIDSoPhieu, iiiDID_ChiTietPhieu, ID_LenhSanXuatxx);

                cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
                cls.Update_TrangThaiTaoLenhSanXuat();


            }
            
        }
        
        private void LuuChiTietLenhSanXuat_IN(int xxIDSoPhieu, int iiiDID_ChiTietPhieu, int iiID_LenhnhanXuat)
        {
            int ID_May = Convert.ToInt32(gridMaMay_IN.EditValue.ToString());
            int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
            int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_IN.EditValue.ToString());
            DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_IN.EditValue.ToString());
            string CaSanXuat = cbCaSanXuat_May_IN.Text.ToString();
            int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());
            double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_IN.Text.ToString());
            double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_IN.Text.ToString());
            int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
            double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_IN.Text.ToString());
            double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_IN.Text.ToString());
            double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_IN.Text.ToString());
            double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_IN.Text.ToString());
            double PhePham = Convert.ToDouble(txtPhePham_May_IN.Text.ToString());
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat clsLSX_chitiet = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            clsLSX_chitiet.iID_LenhSanXuat = iiID_LenhnhanXuat;
            clsLSX_chitiet.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            clsLSX_chitiet.iID_SoPhieu = xxIDSoPhieu;
            clsLSX_chitiet.iID_VTHHVao = ID_VTHH_Vao;
            clsLSX_chitiet.fSoLuongVao = SoLuong_Vao;
            clsLSX_chitiet.iID_VTHHRa = ID_VTHH_Ra;
            clsLSX_chitiet.fSanLuongThuong = SanLuong_Thuong;
            clsLSX_chitiet.fSanLuongTangCa = SanLuong_TangCa;
            clsLSX_chitiet.fPhePham = PhePham;
            clsLSX_chitiet.fDonGiaVao = DonGia_Vao;
            clsLSX_chitiet.fDonGiaRa = DonGia_Xuat;
            clsLSX_chitiet.bNgungTheoDoi = false;
            clsLSX_chitiet.bTonTai = true;
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls2.iID_LenhSanXuat = iiID_LenhnhanXuat;
            cls2.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            cls2.iID_SoPhieu = xxIDSoPhieu;
            DataTable dt2 = cls2.SelectAll_ID_LenhSanXuat_ID_ChiTietPhieu_ID_SoPhieu();
            if(dt2.Rows.Count>0)
            {
                clsLSX_chitiet.iID_ChiTietLenhSanXuat = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietLenhSanXuat"].ToString());
                clsLSX_chitiet.Update();
            }
            else
            {
                clsLSX_chitiet.Insert();
            }
           

        }
        private void LuuChiTietLenhSanXuat_CAT(int xxIDSoPhieu, int iiiDID_ChiTietPhieu, int iiID_LenhnhanXuat)
        {
            int ID_May = Convert.ToInt32(gridMaMay_CAT.EditValue.ToString());
            int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_CAT.EditValue.ToString());
            int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_CAT.EditValue.ToString());
            DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_CAT.EditValue.ToString());
            string CaSanXuat = cbCaSanXuat_May_CAT.Text.ToString();
            int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_CAT.EditValue.ToString());
            double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_CAT.Text.ToString());
            double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_CAT.Text.ToString());
            int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_CAT.EditValue.ToString());
            double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_CAT.Text.ToString());
            double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_CAT.Text.ToString());
            double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_CAT.Text.ToString());
            double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_CAT.Text.ToString());
            double PhePham = Convert.ToDouble(txtPhePham_May_CAT.Text.ToString());
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat clsLSX_chitiet = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            clsLSX_chitiet.iID_LenhSanXuat = iiID_LenhnhanXuat;
            clsLSX_chitiet.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            clsLSX_chitiet.iID_SoPhieu = xxIDSoPhieu;
            clsLSX_chitiet.iID_VTHHVao = ID_VTHH_Vao;
            clsLSX_chitiet.fSoLuongVao = SoLuong_Vao;
            clsLSX_chitiet.iID_VTHHRa = ID_VTHH_Ra;
            clsLSX_chitiet.fSanLuongThuong = SanLuong_Thuong;
            clsLSX_chitiet.fSanLuongTangCa = SanLuong_TangCa;
            clsLSX_chitiet.fPhePham = PhePham;
            clsLSX_chitiet.fDonGiaVao = DonGia_Vao;
            clsLSX_chitiet.fDonGiaRa = DonGia_Xuat;
            clsLSX_chitiet.bNgungTheoDoi = false;
            clsLSX_chitiet.bTonTai = true;
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls2.iID_LenhSanXuat = iiID_LenhnhanXuat;
            cls2.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            cls2.iID_SoPhieu = xxIDSoPhieu;
            DataTable dt2 = cls2.SelectAll_ID_LenhSanXuat_ID_ChiTietPhieu_ID_SoPhieu();
            if (dt2.Rows.Count > 0)
            {
                clsLSX_chitiet.iID_ChiTietLenhSanXuat = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietLenhSanXuat"].ToString());
                clsLSX_chitiet.Update();
            }
            else
            {
                clsLSX_chitiet.Insert();
            }


        }
        private void Load_lockUP_EDIT_may_IN()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=9";
            DataView dvCongNhan = dtNguoi.DefaultView;
            DataTable newdtCongNhan = dvCongNhan.ToTable();

            gridMaCongNhan_May_IN.Properties.DataSource = newdtCongNhan;
            gridMaCongNhan_May_IN.Properties.ValueMember = "ID_NhanSu";
            gridMaCongNhan_May_IN.Properties.DisplayMember = "MaNhanVien";

         
            

            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=8";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridMaCaTruong_May_IN.Properties.DataSource = newdtCaTruong;
            gridMaCaTruong_May_IN.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruong_May_IN.Properties.DisplayMember = "MaNhanVien";


            clsKhoNPL_tbChiTietNhapKho clsVT = new clsKhoNPL_tbChiTietNhapKho();
            DataTable dtVT = clsVT.Select_distinct_HienThiLockUpEdit();
            DataView dvVT = dtVT.DefaultView;
            DataTable newdtVT = dvVT.ToTable();

            gridHangHoaVao_may_IN.Properties.DataSource = newdtVT;
            gridHangHoaVao_may_IN.Properties.ValueMember = "ID_VTHH";
            gridHangHoaVao_may_IN.Properties.DisplayMember = "MaVT";

            clsTbVatTuHangHoa clsxx = new clsTbVatTuHangHoa();
            DataTable dtkksss = clsxx.SelectAll();
            dtkksss.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvcxxx = dtkksss.DefaultView;
            DataTable vdtrhh = dvcxxx.ToTable();

            gridHangHoaXuat_May_IN.Properties.DataSource = vdtrhh;
            gridHangHoaXuat_May_IN.Properties.ValueMember = "ID_VTHH";
            gridHangHoaXuat_May_IN.Properties.DisplayMember = "MaVT";


            clsT_MayMoc clsMayMoc = new clsT_MayMoc();
            DataTable dtMayIN = clsMayMoc.SelectAll();
            dtMayIN.DefaultView.RowFilter = "id_loai=1";
            DataView dvMayIn = dtMayIN.DefaultView;
            DataTable newdtMayIn = dvMayIn.ToTable();

            gridMaMay_IN.Properties.DataSource = newdtMayIn;
            gridMaMay_IN.Properties.ValueMember = "id";
            gridMaMay_IN.Properties.DisplayMember = "MaMay";


            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clssanluong = new CtyTinLuong.clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dtDinhMucSanLuong = clssanluong.SelectAll();
            dtDinhMucSanLuong.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvsanluiong = dtDinhMucSanLuong.DefaultView;
            DataTable newdtsanluong = dvsanluiong.ToTable();

            gridDinhMucSLMay_IN.Properties.DataSource = newdtsanluong;
            gridDinhMucSLMay_IN.Properties.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            gridDinhMucSLMay_IN.Properties.DisplayMember = "MaDinhMuc";


        }     
    
        private void Luu_CongNhan_phuMayCat( )
        {
            //clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls1 = new CtyTinLuong.clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot();
            //cls1.iID_SoPhieu = iiiiID_SoPhieu;
            //DataTable dt = cls1.SelectAll_W_ID_SoPhieu();
            //dt.DefaultView.RowFilter = "Check_MayDot_True_May_Cat_False=False";
            //DataView dv = dt.DefaultView;
            //DataTable newdt = dv.ToTable();
         
            //cls1.iID_SoPhieu = iiiiID_SoPhieu;
            ////cls1.iID_CongNhan = Convert.ToInt32(gridCNPhuMayCat.EditValue.ToString());
            //cls1.iID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_CAT.EditValue.ToString());
            //cls1.daNgaySanXuat = dteNgaySanXuat_May_CAT.DateTime;
            //cls1.sCaSanXuat = cbCaSanXuat_May_CAT.Text.ToString();
            //cls1.bGuiDuLieu = true;
            //cls1.bCheck_MayDot_True_May_Cat_False = false;
            //if (newdt.Rows.Count == 0)
            //    cls1.Insert();
            //else
            //{
            //    cls1.iID_ChiTietPhieu_BoSungMayDot= Convert.ToInt32(newdt.Rows[0]["ID_ChiTietPhieu_BoSungMayDot"].ToString());
            //    cls1.Update();
            //}
        }
        private void HienThi_May_CAT()
        {
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == false)
            {
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                cls.iID_SoPhieu = UC_SanXuat_PhieuSanXuat.mID_iD_SoPhieu;
                DataTable dxxxx = cls.SelectAll_W_iID_SoPhieu();
                dxxxx.DefaultView.RowFilter = "bMay_CAT = True";
                DataView dv = dxxxx.DefaultView;
                DataTable dt = dv.ToTable();

                if (dt.Rows.Count > 0)
                {
                    mbThemMoi_CAT = false;
                    int ID_ChiTietPhieu = Convert.ToInt32(dt.Rows[0]["ID_ChiTietPhieu"].ToString());
                    int ID_SoPhieu = Convert.ToInt32(dt.Rows[0]["ID_SoPhieu"].ToString());
                    int ID_May = Convert.ToInt32(dt.Rows[0]["ID_May"].ToString());
                    int ID_CongNhan = Convert.ToInt32(dt.Rows[0]["ID_CongNhan"].ToString());
                    int ID_CaTruong = Convert.ToInt32(dt.Rows[0]["ID_CaTruong"].ToString());
                    DateTime NgaySanXuat = Convert.ToDateTime(dt.Rows[0]["NgaySanXuat"].ToString());
                    string GhiChu = dt.Rows[0]["GhiChu"].ToString();
                    string CaSanXuat = dt.Rows[0]["CaSanXuat"].ToString();
                    int ID_DinhMuc_Luong = Convert.ToInt32(dt.Rows[0]["ID_DinhMuc_Luong"].ToString());
                    int ID_VTHH_Vao = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Vao"].ToString());
                    double SoLuong_Vao = Convert.ToDouble(dt.Rows[0]["SoLuong_Vao"].ToString());
                    double DonGia_Vao = Convert.ToDouble(dt.Rows[0]["DonGia_Vao"].ToString());
                    int ID_VTHH_Ra = Convert.ToInt32(dt.Rows[0]["ID_VTHH_Ra"].ToString());

                    double SanLuong_Thuong = Convert.ToDouble(dt.Rows[0]["SanLuong_Thuong"].ToString());
                    double SanLuong_TangCa = Convert.ToDouble(dt.Rows[0]["SanLuong_TangCa"].ToString());
                    double SanLuong_Tong = Convert.ToDouble(dt.Rows[0]["SanLuong_Tong"].ToString());
                    double DonGia_Xuat = Convert.ToDouble(dt.Rows[0]["DonGia_Xuat"].ToString());
                    double PhePham = Convert.ToDouble(dt.Rows[0]["PhePham"].ToString());

                    gridMaCaTruong_May_CAT.EditValue = ID_CaTruong;
                    dteNgaySanXuat_May_CAT.EditValue = NgaySanXuat;
                    cbCaSanXuat_May_CAT.Text = CaSanXuat;
                    gridHangHoaVao_may_CAT.EditValue = ID_VTHH_Vao;
                    gridMaMay_CAT.EditValue = ID_May;
                  
                    gridDinhMucSLMay_CAT.EditValue = ID_DinhMuc_Luong;
                    txtSoLuongNhap_May_CAT.Text = SoLuong_Vao.ToString();
                    txtDonGiaXuat_May_CAT.Text = DonGia_Vao.ToString();
                    txtDonGiaNhap_May_CAT.Text = DonGia_Vao.ToString();
                    txtSanLuong_Thuong_may_CAT.Text = SanLuong_Thuong.ToString();
                    txtSanLuong_tangca_May_CAT.Text = SanLuong_TangCa.ToString();
                    txtSanLuongTong_May_CAT.Text = SanLuong_Tong.ToString();
                    gridHangHoaXuat_May_CAT.EditValue = ID_VTHH_Ra;
                    txtPhePham_May_CAT.Text = PhePham.ToString();
                    txtGhiChu_May_CAT.Text = GhiChu.ToString();
                    gridMaCongNhan_May_CAT.EditValue = ID_CongNhan;
                }
                
            }
        }
        private bool KiemTraLuu_May_CAT()
        {
            if (txtSanLuongTong_May_CAT.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có sản lượng ");
                return false;
            }
            else if (gridHangHoaVao_may_CAT.EditValue == null)
            {
                MessageBox.Show("Chưa chọn vật tư vào  ");
                return false;
            }
            else if (gridHangHoaXuat_May_CAT.EditValue == null)
            {
                MessageBox.Show("Chưa chọn vật tư ra  ");
                return false;
            }
            else if (gridMaMay_CAT.EditValue == null)
            {
                MessageBox.Show("Chưa chọn máy gia công  ");
                return false;
            }

            else if (gridMaCongNhan_May_CAT.EditValue == null)
            {
                MessageBox.Show("Chưa chọn công nhân  ");
                return false;
            }
            else if (gridDinhMucSLMay_CAT.EditValue == null)
            {
                MessageBox.Show("Chưa định mức lương sản lượng  ");
                return false;
            }
            else return true;

        }
     
        private void Luu_Va_GuiDuLieu_May_CAT(int xxIDSoPhieu)
        {
            if (!KiemTraLuu_May_CAT()) return;
            else
            {

                clsPhieu_ChiTietPhieu_New cls = new CtyTinLuong.clsPhieu_ChiTietPhieu_New();
                int ID_May = Convert.ToInt32(gridMaMay_CAT.EditValue.ToString());
                int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_CAT.EditValue.ToString());
                int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_CAT.EditValue.ToString());
                DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_CAT.EditValue.ToString());
                string GhiChu = txtGhiChu_May_CAT.Text.ToString();
                string CaSanXuat = cbCaSanXuat_May_CAT.Text.ToString();
                int ID_DinhMuc_Luong = Convert.ToInt32(gridDinhMucSLMay_CAT.EditValue.ToString());
                int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_CAT.EditValue.ToString());
                double SoLuong_Vao = Convert.ToDouble(txtSoLuongNhap_May_CAT.Text.ToString());
                double DonGia_Vao = Convert.ToDouble(txtDonGiaNhap_May_CAT.Text.ToString());
                int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_CAT.EditValue.ToString());
                double SanLuong_Thuong = Convert.ToDouble(txtSanLuong_Thuong_may_CAT.Text.ToString());
                double SanLuong_TangCa = Convert.ToDouble(txtSanLuong_tangca_May_CAT.Text.ToString());
                double SanLuong_Tong = Convert.ToDouble(txtSanLuongTong_May_CAT.Text.ToString());
                double DonGia_Xuat = Convert.ToDouble(txtDonGiaXuat_May_CAT.Text.ToString());
                double PhePham = Convert.ToDouble(txtPhePham_May_CAT.Text.ToString());

                cls.iID_SoPhieu = xxIDSoPhieu;
                cls.iID_May = ID_May;
                cls.iID_CongNhan = ID_CongNhan;
                cls.iID_CaTruong = ID_CaTruong;
                cls.daNgaySanXuat = NgaySanXuat;
                cls.sGhiChu = GhiChu;
                cls.sCaSanXuat = CaSanXuat;
                cls.iID_DinhMuc_Luong = ID_DinhMuc_Luong;
                cls.iID_VTHH_Vao = ID_VTHH_Vao;
                cls.fSoLuong_Vao = SoLuong_Vao;
                cls.fDonGia_Vao = DonGia_Vao;
                cls.iID_VTHH_Ra = ID_VTHH_Ra;
                cls.fSanLuong_Thuong = SanLuong_Thuong;
                cls.fSanLuong_TangCa = SanLuong_TangCa;
                cls.fSanLuong_Tong = SanLuong_Tong;
                cls.fDonGia_Xuat = DonGia_Xuat;
                cls.fPhePham = PhePham;
                cls.bBMay_IN = false;
                cls.bBMay_CAT = true;
                cls.bBMay_DOT = false;
                cls.bTrangThaiXuatNhap = false;
                cls.bGuiDuLieu = true;
                cls.fSoKG_MotBao_May_Dot = 0;
                cls.fDoCao_Dot = 0;
                cls.bTrangThaiTaoLenhSanXuat = false;
                int iiiDID_ChiTietPhieuxxx;
                if (mbThemMoi_CAT == true) // them moi
                {
                    cls.Insert();
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                }
                else
                {
                    clsPhieu_ChiTietPhieu_New cls2 = new CtyTinLuong.clsPhieu_ChiTietPhieu_New();
                    cls2.iID_SoPhieu = xxIDSoPhieu;
                    cls2.sCaSanXuat = cbCaSanXuat_May_CAT.Text.ToString();
                    cls2.daNgaySanXuat = dteNgaySanXuat_May_CAT.DateTime;
                    DataTable dt2 = cls2.SelectAll_W_iID_SoPhieu_W_NgayThangSX_W_Ca_SX_Chon_May_CAT();
                    iiiDID_ChiTietPhieuxxx = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietPhieu"].ToString());
                    cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieuxxx;
                    cls.Update();
                }
                TaoLenhSanXuat_CAT(xxIDSoPhieu, iiiDID_ChiTietPhieuxxx);

            }
        }

     
        private void Load_lockUP_EDIT_May_CAT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();           

            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=8";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();
            gridMaCaTruong_May_CAT.Properties.DataSource = newdtCaTruong;
            gridMaCaTruong_May_CAT.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruong_May_CAT.Properties.DisplayMember = "MaNhanVien";

            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=10";
            DataView dvCongNhan = dtNguoi.DefaultView;
            DataTable newdtCongNhan = dvCongNhan.ToTable();

            gridMaCongNhan_May_CAT.Properties.DataSource = newdtCongNhan;
            gridMaCongNhan_May_CAT.Properties.ValueMember = "ID_NhanSu";
            gridMaCongNhan_May_CAT.Properties.DisplayMember = "MaNhanVien";

            //gridCNPhuMayCat.Properties.DataSource = newdtCongNhan;
            //gridCNPhuMayCat.Properties.ValueMember = "ID_NhanSu";
            //gridCNPhuMayCat.Properties.DisplayMember = "MaNhanVien";

            clsTbVatTuHangHoa clsVTxxxx = new clsTbVatTuHangHoa();
            DataTable dtVTxxx = clsVTxxxx.SelectAll();
            dtVTxxx.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvVTxxx = dtVTxxx.DefaultView;
            DataTable xxxxnewdtVT = dvVTxxx.ToTable();
            gridHangHoaVao_may_CAT.Properties.DataSource = xxxxnewdtVT;
            gridHangHoaVao_may_CAT.Properties.ValueMember = "ID_VTHH";
            gridHangHoaVao_may_CAT.Properties.DisplayMember = "MaVT";

            clsTbVatTuHangHoa clsxx = new clsTbVatTuHangHoa();
            DataTable dtkksss = clsxx.SelectAll();
            dtkksss.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvcxxx = dtkksss.DefaultView;
            DataTable vdtrhh = dvcxxx.ToTable();

            gridHangHoaXuat_May_CAT.Properties.DataSource = vdtrhh;
            gridHangHoaXuat_May_CAT.Properties.ValueMember = "ID_VTHH";
            gridHangHoaXuat_May_CAT.Properties.DisplayMember = "MaVT";


            clsT_MayMoc clsMayMoc = new clsT_MayMoc();
            DataTable dtMayIN = clsMayMoc.SelectAll();
            dtMayIN.DefaultView.RowFilter = "id_loai=2";
            DataView dvMayIn = dtMayIN.DefaultView;
            DataTable newdtMayIn = dvMayIn.ToTable();

            gridMaMay_CAT.Properties.DataSource = newdtMayIn;
            gridMaMay_CAT.Properties.ValueMember = "id";
            gridMaMay_CAT.Properties.DisplayMember = "MaMay";


            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clssanluong = new CtyTinLuong.clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dtDinhMucSanLuong = clssanluong.SelectAll();
            dtDinhMucSanLuong.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvsanluiong = dtDinhMucSanLuong.DefaultView;
            DataTable newdtsanluong = dvsanluiong.ToTable();

            gridDinhMucSLMay_CAT.Properties.DataSource = newdtsanluong;
            gridDinhMucSLMay_CAT.Properties.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            gridDinhMucSLMay_CAT.Properties.DisplayMember = "MaDinhMuc";
            
        }
      
        public SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222()
        {
            InitializeComponent();
        }

        private void gridHangHoaVao_may_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                int kk = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());

                clsncc.iID_VTHH = kk;
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenHangHoaVao_May_IN.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT_HangVao_MayIN.Text = dt.Rows[0]["DonViTinh"].ToString();
                }

                clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();

                cls2.iID_VTHH = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());
                DataTable dt2 = cls2.Select_W_ID_VTHH();
                if (dt2.Rows.Count > 0)
                {

                    
                    txtDonGiaNhap_May_IN.Text = dt2.Rows[0]["DonGia"].ToString();

                }
                else
                {
                    //txtSoLuongTon_May_IN.Text = "0";
                    txtDonGiaNhap_May_IN.Text = "0";
                }

            }
            catch
            {

            }
        }

        private void txtSoLuongNhap_May_IN_TextChanged(object sender, EventArgs e)
        {
            //if (Convert.ToDouble(txtSoLuongNhap_May_IN.Text.ToString()) > Convert.ToDouble(txtSoLuongTon_May_IN.Text.ToString()))
            //{
            //    MessageBox.Show("Số lượng xuất không vượt quá số lượng tồn kho NPL");
            //    txtSoLuongNhap_May_IN.Text = "0";
            //    return;
            //}
        }

        private void gridHangHoaXuat_May_IN_DragOver(object sender, DragEventArgs e)
        {

        }

        private void gridHangHoaXuat_May_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                clsncc.iID_VTHH = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
                gridHangHoaVao_may_CAT.EditValue = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenHangHoaRa_May_IN.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT_HangRa_MayIN.Text = dt.Rows[0]["DonViTinh"].ToString();
                }
            }
            catch
            {

            }
        }

        private void gridMaMay_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsT_MayMoc clsncc = new clsT_MayMoc();
                clsncc.iId = Convert.ToInt32(gridMaMay_IN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenMay_IN.Text = dt.Rows[0]["TenMay"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridMaCongNhan_May_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCongNhan_may_IN.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                txtSanLuong_TrongNgay_IN.ResetText();
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                int iiID_Congnnhan = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
                int iiID_ID_VTHH_Ran = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
                DateTime daNgaySanXuatxxxxxxn = dteNgaySanXuat_May_IN.DateTime;
                DataTable dtin = new DataTable();
                dtin = cls.SUM_TinhSanLuong_W_ID_CongNHan_NgayThang_ID_VTHH_Ra(iiID_Congnnhan, daNgaySanXuatxxxxxxn, iiID_ID_VTHH_Ran);

                txtSanLuong_TrongNgay_IN.Text = dtin.Rows[0]["SanLuong_Thuong"].ToString();

            }
            catch
            {

            }
           
              
       
        }

        private void gridDinhMucSLMay_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsncc = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsncc.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridDinhMucSLMay_IN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtDinhMucKhongTang_May_IN.Text = dt.Rows[0]["DinhMuc_KhongTang"].ToString();
                    txtDinhMucTang_May_IN.Text = dt.Rows[0]["DinhMuc_Tang"].ToString();

                }
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                cls.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridDinhMucSLMay_IN.EditValue.ToString());
                DataTable dt2222 = cls.SelectOne();
                txtMax_DM_IN.Text = cls.fMaxSanLuongThuong.Value.ToString();
            }
            catch
            {

            }
        }

        private void txtSanLuong_may_IN_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtSanLuong_tangca_May_IN_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDonGiaNhap_May_IN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaNhap_May_IN.Text);
                txtDonGiaNhap_May_IN.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDonGiaXuat_May_IN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaXuat_May_IN.Text);
                txtDonGiaXuat_May_IN.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDinhMucKhongTang_May_IN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDinhMucKhongTang_May_IN.Text);
                txtDinhMucKhongTang_May_IN.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDinhMucTang_May_IN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDinhMucTang_May_IN.Text);
                txtDinhMucTang_May_IN.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void gridHangHoaVao_may_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                int kk = Convert.ToInt32(gridHangHoaVao_may_CAT.EditValue.ToString());

                clsncc.iID_VTHH = kk;
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenHangHoaVao_May_CAT.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT_HangVao_MayCAT.Text = dt.Rows[0]["DonViTinh"].ToString();
                }

                clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();

                cls2.iID_VTHH = Convert.ToInt32(gridHangHoaVao_may_CAT.EditValue.ToString());
                DataTable dt2 = cls2.Select_W_ID_VTHH();
                if (dt2.Rows.Count > 0)
                {

                    //txtSoLuongTon_May_CAT.Text = dt2.Rows[0]["SoLuongTon"].ToString();
                    txtDonGiaNhap_May_CAT.Text = dt2.Rows[0]["DonGia"].ToString();

                }
                else
                {
                    //txtSoLuongTon_May_CAT.Text = "0";
                    txtDonGiaNhap_May_CAT.Text = "0";
                }

            }
            catch
            {

            }
        }

        private void gridMaCongNhan_May_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCongNhan_May_CAT.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCongNhan_may_CAT.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                txtSanLuong_TrongNgay_CAT.ResetText();
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                int iiID_Congnnhan = Convert.ToInt32(gridMaCongNhan_May_CAT.EditValue.ToString());
                int iiID_ID_VTHH_Ran = Convert.ToInt32(gridHangHoaXuat_May_CAT.EditValue.ToString());
                DateTime daNgaySanXuatxxxxxxn = dteNgaySanXuat_May_CAT.DateTime;
                DataTable dtin = new DataTable();
                dtin = cls.SUM_TinhSanLuong_W_ID_CongNHan_NgayThang_ID_VTHH_Ra(iiID_Congnnhan, daNgaySanXuatxxxxxxn, iiID_ID_VTHH_Ran);

                txtSanLuong_TrongNgay_CAT.Text = dtin.Rows[0]["SanLuong_Thuong"].ToString();

              
            }
            catch
            {

            }
        }

        private void gridDinhMucSLMay_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsncc = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsncc.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridDinhMucSLMay_CAT.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtDinhMucKhongTang_May_CAT.Text = dt.Rows[0]["DinhMuc_KhongTang"].ToString();
                    txtDinhMucTang_May_CAT.Text = dt.Rows[0]["DinhMuc_Tang"].ToString();

                }
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                cls.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridDinhMucSLMay_CAT.EditValue.ToString());
                DataTable dt2222 = cls.SelectOne();
                txtMax_DM_CAT.Text = cls.fMaxSanLuongThuong.Value.ToString();
            }
            catch
            {

            }
        }

        private void txtSanLuong_may_CAT_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtSanLuong_tangca_May_CAT_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDonGiaNhap_May_CAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaNhap_May_CAT.Text);
                txtDonGiaNhap_May_CAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDonGiaXuat_May_CAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaXuat_May_CAT.Text);
                txtDonGiaXuat_May_CAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDinhMucKhongTang_May_CAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDinhMucKhongTang_May_CAT.Text);
                txtDinhMucKhongTang_May_CAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtDinhMucTang_May_CAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDinhMucTang_May_CAT.Text);
                txtDinhMucTang_May_CAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void gridHangHoaXuat_May_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();

                clsncc.iID_VTHH = Convert.ToInt32(gridHangHoaXuat_May_CAT.EditValue.ToString());
                
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenHangHoaRa_May_CAT.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT_HangRa_MayCAT.Text = dt.Rows[0]["DonViTinh"].ToString();

                }
            }
            catch
            {

            }
        }
        
        private void gridMaMay_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsT_MayMoc clsncc = new clsT_MayMoc();
                clsncc.iId = Convert.ToInt32(gridMaMay_CAT.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenMay_CAT.Text = dt.Rows[0]["TenMay"].ToString();
                }
            }
            catch
            {

            }
        }

        private void SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222_Load(object sender, EventArgs e)
        {
          
            Load_khoiDong();

        }

        private void gridMaCaTruong_May_IN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCaTruong_May_IN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCaTruong_May_IN.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridMaCaTruong_May_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCaTruong_May_CAT.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCaTruong_May_CAT.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }    

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChiLuu_Click(object sender, EventArgs e)
        {
            Luu_Va_Gui_DuLieu();
        }     
        
        private void gridMaCaTruongPhieu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridMaCaTruongPhieu.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCatruongPhieu.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                if(UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu==true)
                {
                    gridMaCaTruong_May_IN.EditValue = Convert.ToInt16(gridMaCaTruongPhieu.EditValue.ToString());
                    gridMaCaTruong_May_CAT.EditValue = Convert.ToInt16(gridMaCaTruongPhieu.EditValue.ToString());
                  //  gridMaCaTruong_May_DOT.EditValue= Convert.ToInt16(gridMaCaTruongPhieu.EditValue.ToString());
                }


            }
            catch
            {

            }
        }

        private void cbCaSanXuatPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == true)
            {
                cbCaSanXuat_May_IN.Text = cbCaSanXuatPhieu.Text;
                cbCaSanXuat_May_CAT.Text = cbCaSanXuatPhieu.Text;
                
            }
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            if(dteNgayLap.EditValue!=null)
            {
                DateTime ngaylapphieu = dteNgayLap.DateTime;
                DateTime tungay = ngaylapphieu.AddDays(-90);

                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=False and NgayLapPhieu<='" + ngaylapphieu + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=False and NgayLapPhieu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                DataTable dxxxx = dv2.ToTable();
                string maphieu = txtMaPhieu.Text.ToString();
                string filterExpression = "";
                filterExpression = "MaPhieu ='" + maphieu + "'";
                DataRow[] rows = dxxxx.Select(filterExpression);
                if (rows.Length > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Đã có Mã phiếu: " + maphieu + "\n Có chắc chắn vẫn lưu", "Kiểm tra", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        return;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        txtMaPhieu.ResetText();
                    }


                }
            }
           
        }

        private void dteNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == true)
            {
                dteNgaySanXuat_May_IN.EditValue = dteNgayLap.EditValue;
                dteNgaySanXuat_May_CAT.EditValue = dteNgayLap.EditValue;
                
            }
        }

        private void txtSanLuongTong_May_IN_TextChanged(object sender, EventArgs e)
        {
            if (UC_SanXuat_PhieuSanXuat.mb_ThemMoi_SoPhieu == true)
            {
                txtSoLuongNhap_May_CAT.Text = txtSanLuongTong_May_IN.Text;
            }
            double SanluongHienCo, SanLuongPhieu;
            SanLuongPhieu = Convert.ToDouble(txtSanLuongTong_May_IN.Text.ToString());
            if (mbThemMoi_IN==true)
            {
                SanluongHienCo = Convert.ToDouble(txtSanLuong_TrongNgay_IN.Text.ToString());
               
            }
            else
            {
                double SanluongHienCo_DaCong = Convert.ToDouble(txtSanLuong_TrongNgay_IN.Text.ToString());
                SanluongHienCo = SanluongHienCo_DaCong - SanLuongPhieu;
            }
             
            double SanLuongDinhMuc;
            SanLuongDinhMuc = Convert.ToDouble(txtMax_DM_IN.Text.ToString());
            if (SanLuongDinhMuc == 0)
            {
                txtSanLuong_Thuong_may_IN.Text = SanLuongPhieu.ToString();
                txtSanLuong_tangca_May_IN.Text = "0";
            }
            else
            {
                if (SanluongHienCo >= SanLuongDinhMuc)
                {
                    txtSanLuong_Thuong_may_IN.Text = "0";
                    txtSanLuong_tangca_May_IN.Text = SanLuongPhieu.ToString();
                }
                else
                {
                    double TongSanLuongMoi = SanluongHienCo + SanLuongPhieu;
                    if (TongSanLuongMoi <= SanLuongDinhMuc)
                    {
                        txtSanLuong_tangca_May_IN.Text = "0";
                        txtSanLuong_Thuong_may_IN.Text = SanLuongPhieu.ToString();
                    }
                    else
                    {
                        txtSanLuong_tangca_May_IN.Text = (TongSanLuongMoi - SanLuongDinhMuc).ToString();
                        txtSanLuong_Thuong_may_IN.Text = (SanLuongDinhMuc - SanluongHienCo).ToString();
                    }
                }
            }

        }

        private void txtMax_DM_CAT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSanLuong_TrongNgay_IN_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkGiongNhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkGiongNhau.Checked == true)
            {
                try
                {
                    cbCaSanXuat_May_IN.Text = cbCaSanXuat_May_CAT.Text = cbCaSanXuatPhieu.Text;
                    gridMaCaTruong_May_CAT.EditValue  = gridMaCaTruong_May_IN.EditValue = gridMaCaTruongPhieu.EditValue;
                    dteNgaySanXuat_May_IN.EditValue = dteNgaySanXuat_May_CAT.EditValue = dteNgayLap.EditValue;

                }
                catch
                { }
            }

        }

        private void btChuyen_Click(object sender, EventArgs e)
        {
            SanXuat_frmChiTietPhieu_MayDot ff = new SanXuat_frmChiTietPhieu_MayDot();
            ff.Show();
        }

        private void txtSanLuongTong_May_CAT_TextChanged(object sender, EventArgs e)
        {
            double SanluongHienCo, SanLuongPhieu;
            SanLuongPhieu = Convert.ToDouble(txtSanLuongTong_May_CAT.Text.ToString());
            if (mbThemMoi_IN == true)
            {
                SanluongHienCo = Convert.ToDouble(txtSanLuong_TrongNgay_CAT.Text.ToString());

            }
            else
            {
                double SanluongHienCo_DaCong = Convert.ToDouble(txtSanLuong_TrongNgay_CAT.Text.ToString());
                SanluongHienCo = SanluongHienCo_DaCong - SanLuongPhieu;
            }
            double SanLuongDinhMuc;
            SanLuongDinhMuc = Convert.ToDouble(txtMax_DM_CAT.Text.ToString());
            if (SanLuongDinhMuc == 0)
            {
                txtSanLuong_Thuong_may_CAT.Text = SanLuongPhieu.ToString();
                txtSanLuong_tangca_May_CAT.Text = "0";
            }
            else
            {
                if (SanluongHienCo >= SanLuongDinhMuc)
                {
                    txtSanLuong_Thuong_may_CAT.Text = "0";
                    txtSanLuong_tangca_May_CAT.Text = SanLuongPhieu.ToString();
                }
                else
                {
                    double TongSanLuongMoi = SanluongHienCo + SanLuongPhieu;
                    if (TongSanLuongMoi <= SanLuongDinhMuc)
                    {
                        txtSanLuong_tangca_May_CAT.Text = "0";
                        txtSanLuong_Thuong_may_CAT.Text = SanLuongPhieu.ToString();
                    }
                    else
                    {
                        txtSanLuong_tangca_May_CAT.Text = (TongSanLuongMoi - SanLuongDinhMuc).ToString();
                        txtSanLuong_Thuong_may_CAT.Text = (SanLuongDinhMuc - SanluongHienCo).ToString();
                    }
                }
            }

        }

    }
}
