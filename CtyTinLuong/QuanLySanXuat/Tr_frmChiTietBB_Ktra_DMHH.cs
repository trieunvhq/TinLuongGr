using DevExpress.XtraGrid.Views.Grid;
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

      
        private bool Insert_BB_Ktra_DMHHSX()
        {
            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();
            cls.daNgayThang = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
            cls.iCa = Convert.ToInt32(txtCa.Text.ToString());
            cls.sLoaiHang = txtLoaiHang.Text.ToString().Trim();
            cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
            cls.fSoLuongKtra = Convert.ToDouble(txtSoLuongKtra.Text.ToString());
            cls.sDonVi_first = txtDonVi_in.Text.ToString().Trim();
            cls.fTrongLuong = Convert.ToDouble(txtTrongLuong.Text.ToString());
            cls.fSoLuong = Convert.ToDouble(txtSoLuong.Text.ToString());
            cls.sDonVi_Second = txtDonVi_Out.Text.ToString().Trim();
            cls.fQuyRaKien = Convert.ToDouble(txtQuyRaKien.Text.ToString());
            cls.fPhePham = Convert.ToDouble(txtPhePham.Text.ToString());
            cls.fDoCao = Convert.ToDouble(txtDoCao.Text.ToString());
            cls.fMotBao_kg = Convert.ToDouble(txt1Bao_kg.Text.ToString());
            cls.fMotBao_SoKien = Convert.ToDouble(txt1Bao_SoKien.Text.ToString());
            cls.fSauMuoi_BaoKien = Convert.ToDouble(txt60Bao_Kien.Text.ToString());
            cls.sGhiChu = txtGhiChu.Text.ToString().Trim();

            if (cls.Insert()) return true;
            else return false;
        }


        // 
        private bool Update_BB_Ktra_DMHHSX()
        {
            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();
            cls.daNgayThang = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
            cls.iCa = Convert.ToInt32(txtCa.Text.ToString());
            cls.sLoaiHang = txtLoaiHang.Text.ToString().Trim();
            cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
            cls.fSoLuongKtra = Convert.ToDouble(txtSoLuongKtra.Text.ToString());
            cls.sDonVi_first = txtDonVi_in.Text.ToString().Trim();
            cls.fTrongLuong = Convert.ToDouble(txtTrongLuong.Text.ToString());
            cls.fSoLuong = Convert.ToDouble(txtSoLuong.Text.ToString());
            cls.sDonVi_Second = txtDonVi_Out.Text.ToString().Trim();
            cls.fQuyRaKien = Convert.ToDouble(txtQuyRaKien.Text.ToString());
            cls.fPhePham = Convert.ToDouble(txtPhePham.Text.ToString());
            cls.fDoCao = Convert.ToDouble(txtDoCao.Text.ToString());
            cls.fMotBao_kg = Convert.ToDouble(txt1Bao_kg.Text.ToString());
            cls.fMotBao_SoKien = Convert.ToDouble(txt1Bao_SoKien.Text.ToString());
            cls.fSauMuoi_BaoKien = Convert.ToDouble(txt60Bao_Kien.Text.ToString());
            cls.sGhiChu = txtGhiChu.Text.ToString().Trim();

            if (cls.Insert()) return true;
            else return false;
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
   
        private void Load_frmEdit()
        {
            dateNgayThang.EditValue = Tr_UC_BB_Ktra_DM_HHSX.mbNgayThang;
            txtSoHieu.Text = Tr_UC_BB_Ktra_DM_HHSX.mbSoHieu;
            txtCa.Text = Tr_UC_BB_Ktra_DM_HHSX.mbCaSanXuat.ToString();
            txtLoaiHang.Text = Tr_UC_BB_Ktra_DM_HHSX.mbLoaiHang.ToString();
            txtLoaiGiay.Text = Tr_UC_BB_Ktra_DM_HHSX.mbLoaiGiay.ToString();
            txtSoLuongKtra.Text = Tr_UC_BB_Ktra_DM_HHSX.mbSoLuongKiemTra.ToString();
            txtTrongLuong.Text = Tr_UC_BB_Ktra_DM_HHSX.mbTrongLuong.ToString();
            txtSoLuong.Text = Tr_UC_BB_Ktra_DM_HHSX.mbSoLuong.ToString();
            txtDonVi_Out.Text = Tr_UC_BB_Ktra_DM_HHSX.mbDonVi;
            txtQuyRaKien.Text = Tr_UC_BB_Ktra_DM_HHSX.mbQuyRaKien.ToString();
            txtPhePham.Text = Tr_UC_BB_Ktra_DM_HHSX.mbPhePham.ToString();
            txtDoCao.Text = Tr_UC_BB_Ktra_DM_HHSX.mbDoCao.ToString();
            txt1Bao_kg.Text = Tr_UC_BB_Ktra_DM_HHSX.mbMotBao_kg.ToString();
            txt1Bao_SoKien.Text = Tr_UC_BB_Ktra_DM_HHSX.mbMotBao_SoKien.ToString();
            txt60Bao_Kien.Text = Tr_UC_BB_Ktra_DM_HHSX.mbSauMuoi_BaoKien.ToString();
            txtGhiChu.Text = Tr_UC_BB_Ktra_DM_HHSX.mbGhiChu;
        }

        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoHieu.Text))
            {
                MessageBox.Show("Kiểm tra lại Số hiệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHieu.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoHieu.Text))
            {
                MessageBox.Show("Kiểm tra lại Số hiệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHieu.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCa.Text))
            {
                MessageBox.Show("Kiểm tra lại Ca sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCa.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtCa.Text))
            {
                MessageBox.Show("Kiểm tra lại Ca sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCa.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLoaiHang.Text))
            {
                MessageBox.Show("Kiểm tra lại Loại hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiHang.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLoaiGiay.Text))
            {
                MessageBox.Show("Kiểm tra lại Loại giấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiGiay.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoLuongKtra.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongKtra.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoLuongKtra.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongKtra.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDonVi_in.Text))
            {
                MessageBox.Show("Kiểm tra lại Đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonVi_in.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTrongLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Trọng lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrongLuong.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtTrongLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Trọng lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrongLuong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDonVi_Out.Text))
            {
                MessageBox.Show("Kiểm tra lại Đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonVi_Out.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtQuyRaKien.Text))
            {
                MessageBox.Show("Kiểm tra lại Quy ra kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuyRaKien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtQuyRaKien.Text))
            {
                MessageBox.Show("Kiểm tra lại Quy ra kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuyRaKien.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhePham.Text))
            {
                MessageBox.Show("Kiểm tra lại Phế phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhePham.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtPhePham.Text))
            {
                MessageBox.Show("Kiểm tra lại Phế phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhePham.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDoCao.Text))
            {
                MessageBox.Show("Kiểm tra lại Độ cao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoCao.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtDoCao.Text))
            {
                MessageBox.Show("Kiểm tra lại Độ cao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoCao.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt1Bao_kg.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao (kg)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_kg.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt1Bao_kg.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao (kg)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_kg.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt1Bao_SoKien.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao giao số kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_SoKien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt1Bao_SoKien.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao giao số kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_SoKien.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt60Bao_Kien.Text))
            {
                MessageBox.Show("Kiểm tra lại 60 Bao/kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt60Bao_Kien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt60Bao_Kien.Text))
            {
                MessageBox.Show("Kiểm tra lại 60 Bao/kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt60Bao_Kien.Focus();
                return false;
            }
            else return true;
        }

        //
        public static bool CheckIsNumber(string Value)
        {
            double OutVal;
            if (Double.TryParse(Value, out OutVal))
            {
                // it is a number
                return true;
            }
            else
            {
                // it is not a number
                return false;
            }
        }

        public Tr_frmChiTietBB_Ktra_DMHH()
        {
            InitializeComponent();
            dateNgayThang.EditValue = DateTime.Now;

            if (Tr_UC_BB_Ktra_DM_HHSX.mbCopy_BB_Ktra)
            {
                Load_frmEdit();
            }
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


        private void btSave_Click(object sender, EventArgs e)
        {
            if  (Tr_UC_BB_Ktra_DM_HHSX.mbAdd_BB_Ktra == true 
                && Tr_UC_BB_Ktra_DM_HHSX.mb_Sua_BB_Ktra == false)
            {
                if (CheckDataInput())
                {
                    if (Insert_BB_Ktra_DMHHSX())
                    {
                        MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (Tr_UC_BB_Ktra_DM_HHSX.mbAdd_BB_Ktra == false
                && Tr_UC_BB_Ktra_DM_HHSX.mb_Sua_BB_Ktra == true)
            {
                if (Update_BB_Ktra_DMHHSX())
                {
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
