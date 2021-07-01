using DevExpress.Data.Filtering;
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
    public partial class Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww : Form
    {
        public static DataTable mdtCHiTietTaKhoan_print;
        public static bool mbPrint = false;
        public static bool mbTienUSD;
        public static DateTime mdaNgayThang;
        public static string msDiaChi, msLoaiChungTu, msSoChungTu, msNguoiNopTen, msTaiKhoan_No, ms_TaiKhoanCo, msDienGiai;
        public static double mdbSoTien, mdbTiGia;
        int DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 = 0;
        DataTable dtdoituong = new DataTable();

        private void Luu_BienDongTaiKhoanKeToan(int xxxID_ThuChi)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clsxx.iID_ChungTu = xxxID_ThuChi;
            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
            clsxx.daNgayThang = dteNgayChungTu.DateTime;

            DataTable dt2_cu = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
            if (dt2_cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_cu.Rows.Count; i++)
                {
                    clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    clsxx.bTonTai = false;
                    clsxx.Update_W_TonTai();
                }
            }

            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dv.ToTable();


            clsxx = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanConxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                double TiGia;
                if (dt_gridcontrol.Rows[i]["TiGia"].ToString() == "")
                    TiGia = 0;
                else TiGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["TiGia"].ToString());
                clsxx.iID_ChungTu = xxxID_ThuChi;
                clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                clsxx.daNgayThang = dteNgayChungTu.DateTime;
                clsxx.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                clsxx.fCo = Convert.ToDouble(dt_gridcontrol.Rows[i]["Co"].ToString());
                clsxx.fNo = Convert.ToDouble(dt_gridcontrol.Rows[i]["No"].ToString());
                clsxx.bTienUSD = Convert.ToBoolean(dt_gridcontrol.Rows[i]["TienUSD"].ToString());
                clsxx.fTiGia = TiGia;
                clsxx.bTonTai = true;
                clsxx.bNgungTheoDoi = false;
                clsxx.bDaGhiSo = true;
                clsxx.bBBool_TonDauKy = false;
                clsxx.sDienGiai = txtDienGiai.Text.ToString();
                clsxx.bCheck_PhanNganHang = true;
                if (checkKhac.Checked == true)
                    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 0;
                else if (checkKhachHang.Checked == true)
                    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 2;
                else if (checkNhaCungCap.Checked == true)
                    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 1;

                string expressionnhapkho;
                expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    clsxx.Update();
                }
                else
                {
                    clsxx.Insert();
                }
            
            }
            // xoá tồn tại = false
            DataTable dt2_moi11111 = new DataTable();
            clsxx = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clsxx.iID_ChungTu = xxxID_ThuChi;
            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
            clsxx.daNgayThang = dteNgayChungTu.DateTime;
            dt2_moi11111 = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();            
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int xxxID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                clsxx.iID_ChiTietBienDongTaiKhoan = xxxID_ChiTietBienDongTaiKhoan;
                clsxx.Delete();
            }
        }
        private void Luu_ChiTiet_ThuChi(int xxxID_ThuChi)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsNganHang_tbThuChi_ChiTietThuChi cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();
                DataTable dt2_cu = new DataTable();

                cls2.iID_ThuChi = xxxID_ThuChi;
                dt2_cu = cls2.SelectAll_W_ID_ThuChi();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        cls2.iID_ThuChi = xxxID_ThuChi;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai();
                    }
                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    int ID_TaiKhoanKeToanConxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                    double TiGia;
                    if (dt_gridcontrol.Rows[i]["TiGia"].ToString() == "")
                        TiGia = 0;
                    else TiGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["TiGia"].ToString());
                    cls2.iID_ThuChi = xxxID_ThuChi;
                    cls2.iID_TaiKhoanKeToanCon = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    cls2.fCo = Convert.ToDouble(dt_gridcontrol.Rows[i]["Co"].ToString());
                    cls2.fNo = Convert.ToDouble(dt_gridcontrol.Rows[i]["No"].ToString());
                    cls2.bTienUSD = Convert.ToBoolean(dt_gridcontrol.Rows[i]["TienUSD"].ToString());
                    cls2.fTiGia = TiGia;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaGhiSo = true;
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                 
                    string expressionnhapkho;
                    expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietThuChi = Convert.ToInt32(foundRows[0]["ID_ChiTietThuChi"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                cls2.iID_ThuChi = xxxID_ThuChi;
                dt2_moi11111 = cls2.SelectAll_W_ID_ThuChi();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietThuChixxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietThuChi"].ToString());
                    cls2.iID_ChiTietThuChi = ID_ChiTietThuChixxx;
                    cls2.Delete();
                }
                
            }
        }
        private void LuuDuLieu_Va_GhiSo(int bienthangthai)
        {
            if (!KiemTraLuu()) return ;
            else
            {
                int ID_ThuChixxx;
                clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.fSoTien = Convert.ToDouble(txtSoTien.Text.ToString());
                cls1.sThamChieu = txtThamChieu.Text; 
                cls1.sDoiTuong = txtDoiTuong.Text.ToString();
                cls1.bTonTai = true;
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = checkUSD.Checked;
                cls1.fTiGia = Convert.ToDouble(txtTiGia.Text.ToString());
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                cls1.bDaGhiSo = true;
                if (checkKhac.Checked == true)
                    cls1.iBienMuaHang1_BanHang2_ConLai_0 = 0;
                else if (checkKhachHang.Checked == true)
                    cls1.iBienMuaHang1_BanHang2_ConLai_0 = 2;
                else if (checkNhaCungCap.Checked == true)
                    cls1.iBienMuaHang1_BanHang2_ConLai_0 = 1;
                if (UCQuy_NganHang_BaoCo.mbThemMoi_ThuChi == true)
                {
                    cls1.Insert();
                    ID_ThuChixxx = cls1.iID_ThuChi.Value;

                }
                else
                {
                    ID_ThuChixxx = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
                    cls1.iID_ThuChi = ID_ThuChixxx;
                    cls1.Update();
                }
                Luu_ChiTiet_ThuChi(ID_ThuChixxx);
                Luu_BienDongTaiKhoanKeToan(ID_ThuChixxx);

                MessageBox.Show("Đã lưu");
            }
        }
        private bool KiemTraLuu()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;

            if (dttttt2.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu ghi tài khoản kế toán ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (txtSoTien.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số tiền ");
                return false;
            }           
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người mua hàng ");
                return false;
            }
            else if (gridDoiTuong.EditValue == null)
            {
                MessageBox.Show("Chưa chọn đối tượng ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }
            
            else return true;

        }
        public void HienThiSoChungTu(int xxbientrangthai)
        {
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SA_W_bientrangthai_(xxbientrangthai);
            int k = dt.Rows.Count;

            if (k == 0)
            {
                if (xxbientrangthai == 1)                
                    txtSoChungTu.Text = "BC 1";
                else if (xxbientrangthai == 2)
                    txtSoChungTu.Text = "BN 1";
                else if (xxbientrangthai == 3)
                    txtSoChungTu.Text = "PC 1";
                else if (xxbientrangthai == 4)
                    txtSoChungTu.Text = "PT 1";

            }
            else
            {
                string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                if (xxbientrangthai == 1)
                    txtSoChungTu.Text = "BC " + xxx2 + "";
                else if (xxbientrangthai == 2)
                    txtSoChungTu.Text = "BN " + xxx2 + "";
                else if (xxbientrangthai == 3)
                    txtSoChungTu.Text = "PC " + xxx2 + "";
                else if (xxbientrangthai == 4)
                    txtSoChungTu.Text = "PT " + xxx2 + "";
            }
            if (xxbientrangthai == 1)
                txtThamChieu.Text = "Báo Có";
            else if (xxbientrangthai == 2)
                txtThamChieu.Text = "Báo Nợ";
            else if (xxbientrangthai == 3)
                txtThamChieu.Text = "Phiếu Chi";
            else if (xxbientrangthai == 4)
                txtThamChieu.Text = "Phiếu Thu";

        }
        private void HienThi_ThemMoi(int bientrangthia)
        {
            checkVNĐ.Checked = true;

            gridNguoiLap.EditValue = 13;
            dteNgayChungTu.EditValue = DateTime.Today;
            HienThiSoChungTu(bientrangthia);
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_ChiTietThuChi", typeof(int));
            dt2.Columns.Add("ID_ThuChi", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));           
            dt2.Columns.Add("No", typeof(double));
            dt2.Columns.Add("Co", typeof(double));
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("TiGia", typeof(double));
            dt2.Columns.Add("DaGhiSo", typeof(bool));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon", typeof(string));
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));

            DataRow _ravi = dt2.NewRow();
            if (bientrangthia == 1) //báo nợ
            {
                _ravi["ID_TaiKhoanKeToanCon"] = 2;
                _ravi["SoTaiKhoanCon"] = "1121";
                _ravi["TenTaiKhoanCon"] = "Tiền gửi ngân hàng VNĐ";
            }
            if (bientrangthia == 2) //báo Có
            {
                _ravi["ID_TaiKhoanKeToanCon"] = 2;
                _ravi["SoTaiKhoanCon"] = "1121";
                _ravi["TenTaiKhoanCon"] = "Tiền gửi ngân hàng VNĐ";
            }
            if (bientrangthia == 3) //Phiếu chi
            {
                _ravi["ID_TaiKhoanKeToanCon"] = 294;
                _ravi["SoTaiKhoanCon"] = "1111";
                _ravi["TenTaiKhoanCon"] = "Tiền mặt VNĐ";
            }
            if (bientrangthia == 4) //Phiếu thu
            {
                _ravi["ID_TaiKhoanKeToanCon"] = 294;
                _ravi["SoTaiKhoanCon"] = "1111";
                _ravi["TenTaiKhoanCon"] = "Tiền mặt VNĐ";
            }
            _ravi["No"] =0;
            _ravi["Co"] = 0;
            _ravi["TienUSD"] = false;
            _ravi["TiGia"] = 1;
            _ravi["DaGhiSo"] = false;
            _ravi["GhiChu"] = "";           
            _ravi["HienThi"] = "1";
            dt2.Rows.Add(_ravi);
            gridControl1.DataSource = dt2;


        }
        private void HienThi_Sua()
        {

            clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
            cls1.iID_ThuChi = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
            DataTable dt = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiLap.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            
            if (cls1.bTienUSD.Value == true)
                checkUSD.Checked = true;
            else checkVNĐ.Checked = true;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtTiGia.Text = cls1.fTiGia.Value.ToString();


            if (cls1.iBienMuaHang1_BanHang2_ConLai_0 == 1)
                checkNhaCungCap.Checked = true;
            else if (cls1.iBienMuaHang1_BanHang2_ConLai_0 == 2)
                checkKhachHang.Checked = true;
            else checkKhac.Checked = true;

            if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
                gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;
          
            if (cls1.bDaGhiSo.Value == true)
            {
                //btLuu_Copy.Enabled = false;
                //btLuu_Dong.Enabled = false;
                //btLuu_Gui_Copy.Enabled = false;
                //btLuu_Gui_Dong.Enabled = false;
            }
            
            clsNganHang_tbThuChi_ChiTietThuChi cls2 = new clsNganHang_tbThuChi_ChiTietThuChi();
            cls2.iID_ThuChi = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
            DataTable dt3 = cls2.SelectAll_W_ID_ThuChi();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietThuChi", typeof(int));
            dt2.Columns.Add("ID_ThuChi", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));           
            dt2.Columns.Add("No", typeof(double));
            dt2.Columns.Add("Co", typeof(double));
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("TiGia", typeof(double));
            dt2.Columns.Add("DaGhiSo", typeof(bool));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon");
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanCon = Convert.ToInt32(dt3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                DataTable dtcon = clscon.SelectOne();
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ChiTietThuChi"].ToString());
                _ravi["ID_ThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ThuChi"].ToString());
                _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt32(ID_TaiKhoanKeToanCon.ToString());               
                _ravi["No"] = Convert.ToDouble(dt3.Rows[i]["No"].ToString());
                _ravi["Co"] = Convert.ToDouble(dt3.Rows[i]["Co"].ToString());
                _ravi["TienUSD"] = Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                _ravi["TiGia"] = Convert.ToDouble(dt3.Rows[i]["TiGia"].ToString());
                _ravi["DaGhiSo"] = Convert.ToBoolean(dt3.Rows[i]["DaGhiSo"].ToString());
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;

            if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
                gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;
        }
        private void Load_LockUp_DoiTuong( )
        {
            dtdoituong.Clear();

            if (DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 == 1) // Khác
            {
                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();                
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dtdoituong.NewRow();
                    _ravi["ID_DoiTuong"] =Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString());
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["MaNhanVien"].ToString();
                    _ravi["TenDoiTuong"] = dt3.Rows[i]["TenNhanVien"].ToString();
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            }
            if (DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 == 2) // NCC
            {
                clsTbNhaCungCap cls = new clsTbNhaCungCap();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dtdoituong.NewRow();
                    _ravi["ID_DoiTuong"] = Convert.ToInt32(dt3.Rows[i]["ID_NhaCungCap"].ToString());
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["MaNhaCungCap"].ToString();
                    _ravi["TenDoiTuong"] = dt3.Rows[i]["TenNhaCungCap"].ToString();
                    if (dt3.Rows[i]["ID_TaiKhoanKeToan"].ToString() != "")
                    {
                        int iiiID_TaiKhoanKeToan = Convert.ToInt32(dt3.Rows[i]["ID_TaiKhoanKeToan"].ToString());
                        _ravi["ID_TaiKhoanKeToan"] = iiiID_TaiKhoanKeToan;

                    }
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            }
            if (DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 == 3) //  Khách hàng
            {
                clsTbKhachHang cls = new clsTbKhachHang();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dtdoituong.NewRow();
                    _ravi["ID_DoiTuong"] = Convert.ToInt32(dt3.Rows[i]["ID_KhachHang"].ToString());
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["MaKH"].ToString();
                    _ravi["TenDoiTuong"] = dt3.Rows[i]["TenKH"].ToString();
                    if (dt3.Rows[i]["ID_TaiKhoanKeToan"].ToString() != "")
                    {
                        int iiiID_TaiKhoanKeToan = Convert.ToInt32(dt3.Rows[i]["ID_TaiKhoanKeToan"].ToString());
                        _ravi["ID_TaiKhoanKeToan"] = iiiID_TaiKhoanKeToan;

                    }
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            }
           
        }
        private void Load_LockUp()
        {
            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtcon = clscon.SelectAll();
            dtcon.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvcon = dtcon.DefaultView;
            DataTable newdtcon = dvcon.ToTable();

            repositoryItemGridLookUpEdit2.DataSource = newdtcon;
            repositoryItemGridLookUpEdit2.ValueMember = "ID_TaiKhoanKeToanCon";
            repositoryItemGridLookUpEdit2.DisplayMember = "SoTaiKhoanCon";

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

          
        }
        public Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww()
        {
            InitializeComponent();
        }

        private void Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww_Load(object sender, EventArgs e)
        {
            dtdoituong = new DataTable();
            dtdoituong.Columns.Add("ID_DoiTuong", typeof(int));
            dtdoituong.Columns.Add("MaDoiTuong", typeof(string));
            dtdoituong.Columns.Add("TenDoiTuong", typeof(string));
            dtdoituong.Columns.Add("ID_TaiKhoanKeToan", typeof(int));
            Load_LockUp();
          
            if (UCQuy_NganHang_BaoCo.mbThemMoi_ThuChi == true)
                HienThi_ThemMoi(frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4);
            else
                HienThi_Sua();
        }
        
        private void checkKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKhac.Checked == true)
            {
                checkKhachHang.Checked = false;
                checkNhaCungCap.Checked = false;               
                try
                {
                    DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 = 1;
                    Load_LockUp_DoiTuong();
                }
                catch
                { }
            }
        }

        private void checkNhaCungCap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhaCungCap.Checked == true)
            {
                checkKhachHang.Checked = false;
                checkKhac.Checked = false;
                try
                {
                    DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 = 2;
                    Load_LockUp_DoiTuong();
                }
                catch
                { }
            }
        }

        private void checkKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKhachHang.Checked == true)
            {
                checkNhaCungCap.Checked = false;
                checkKhac.Checked = false;
                try
                {
                    DoiTuong_Khac_1_NhaCungCap_2_KhachHang3 = 3;
                    Load_LockUp_DoiTuong();
                }
                catch
                { }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
                    txtNguoiMuaHang.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clSoTaiKhoanCon)
                {
                    double tigiaxx = Convert.ToDouble(txtTiGia.Text);
                    bool tienussd = checkUSD.Checked;
                    gridView4.SetRowCellValue(e.RowHandle, clNo, 0);
                    gridView4.SetRowCellValue(e.RowHandle, clCo, 0);

                    clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                    cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    DataTable dt = cls.SelectOne();
                    gridView4.SetRowCellValue(e.RowHandle, clID_TaiKhoanKeToanCon, kk);                 
                    gridView4.SetRowCellValue(e.RowHandle, clTenTaiKhoanCon, dt.Rows[0]["TenTaiKhoanCon"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView4.SetRowCellValue(e.RowHandle, clTienUSD, tienussd);
                    gridView4.SetFocusedRowCellValue(clTiGia, tigiaxx);

                }
              
            }
            catch
            {
            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sotienxxx = Convert.ToDouble(txtSoTien.Text.ToString());
                if (checkNhaCungCap.Checked==true) // mua hang
                {
                    gridView4.SetRowCellValue(0, clNo, sotienxxx);
                    gridView4.SetRowCellValue(0, clCo, 0);

                    gridView4.SetRowCellValue(1, clNo, 0);
                    gridView4.SetRowCellValue(1, clCo, sotienxxx);

                }
                else if (checkKhachHang.Checked==true)
                {
                    gridView4.SetRowCellValue(0, clNo, 0);
                    gridView4.SetRowCellValue(0, clCo, sotienxxx);

                    gridView4.SetRowCellValue(1, clNo, sotienxxx);
                    gridView4.SetRowCellValue(1, clCo, 0);
                }
                else 
                {
                    gridView4.SetRowCellValue(0, clNo, sotienxxx);
                    gridView4.SetRowCellValue(0, clCo, 0);

                    gridView4.SetRowCellValue(1, clNo, 0);
                    gridView4.SetRowCellValue(1, clCo, sotienxxx);
                }

            }
            catch
            {
            }
        }

        private void txtTiGia_TextChanged(object sender, EventArgs e)
        {
            if (txtTiGia.Text.ToString() != "1")
            {
                double tigiaxx = Convert.ToDouble(txtTiGia.Text.ToString());
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                try
                {
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TiGia"] = tigiaxx;
                        }
                        gridControl1.DataSource = dttttt2;
                    }
                }
                catch
                {
                }

            }
        }

        private void checkVNĐ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVNĐ.Checked == true)
            {
                checkUSD.Checked = false;
                txtTiGia.Text = "1";
                try
                {
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TienUSD"] = false;
                        }
                        gridControl1.DataSource = dttttt2;
                    }
                }
                catch
                {
                }

            }
        }

        private void checkUSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUSD.Checked == true)
            {
                checkVNĐ.Checked = false;
                try
                {
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TienUSD"] = true;
                        }
                        gridControl1.DataSource = dttttt2;
                    }
                }
                catch
                {
                }
            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            int kkkk = 0;
           
            if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 1)
            {
                kkkk = 1;
              

            }
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 2)
            {
                kkkk = 2;
               

            }
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 3)
            {
                kkkk = 3;
             

            }
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 4)
            {
                kkkk = 4;
                
            }
            LuuDuLieu_Va_GhiSo(kkkk);
           
        }

      
        private void gridDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_LockUp_DoiTuong();
                int ID_Doituongxxx = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                string filterExpression = "ID_DoiTuong=" + ID_Doituongxxx + "";
                DataRow[] rows = dtdoituong.Select(filterExpression);
                if (rows.Length > 0)
                {
                    txtDoiTuong.Text = rows[0]["TenDoiTuong"].ToString();
                   
                    if (rows[0]["ID_TaiKhoanKeToan"].ToString() != "")
                    {
                        int iiiiID_TaiKhoanKeToan = Convert.ToInt32(rows[0]["ID_TaiKhoanKeToan"].ToString());                       
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.iID_TaiKhoanKeToanCon = iiiiID_TaiKhoanKeToan;
                        DataTable dtcon = clscon.SelectOne();
                  

                        DataTable dt1 = new DataTable();
                        dt1 = (DataTable)gridControl1.DataSource;
                        gridControl1.DataSource = null;
                        DataTable dt2 = dt1.Copy();
                        DataRow _ravi = dt2.NewRow();
                   
                        _ravi["ID_TaiKhoanKeToanCon"] = iiiiID_TaiKhoanKeToan;
                        _ravi["ID_TaiKhoanKeToanMe"] = clscon.iID_TaiKhoanKeToanMe.Value;
                      
                        _ravi["TienUSD"] = checkUSD.Checked;
                        _ravi["TiGia"] = 0;
                        _ravi["No"] = 0;
                        _ravi["Co"] = 0;
                        _ravi["DaGhiSo"] = false;
                        _ravi["GhiChu"] = "";
                        _ravi["SoTaiKhoanCon"] = iiiiID_TaiKhoanKeToan.ToString();
                        _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                        _ravi["HienThi"] = "1";
                        dt2.Rows.Add(_ravi);
                        gridControl1.DataSource = dt2;
                    }
                }
            }
            catch
            { }

        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.SetFocusedRowCellValue(clHienThi,"0");
            gridView4.SetFocusedRowCellValue(clNo, 0);
            gridView4.SetFocusedRowCellValue(clCo, 0);
        }

        private void btXoa2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtSoTien.Text);
                txtSoTien.Text = String.Format("{0:#,##0.00}", value);
                double sotienxxx = Convert.ToDouble(txtSoTien.Text.ToString());
                if (checkNhaCungCap.Checked == true) // mua hang
                {
                    gridView4.SetRowCellValue(0, clNo, sotienxxx);
                    gridView4.SetRowCellValue(0, clCo, 0);

                    gridView4.SetRowCellValue(1, clNo, 0);
                    gridView4.SetRowCellValue(1, clCo, sotienxxx);

                }
                else if (checkKhachHang.Checked == true)
                {
                    gridView4.SetRowCellValue(0, clNo, 0);
                    gridView4.SetRowCellValue(0, clCo, sotienxxx);

                    gridView4.SetRowCellValue(1, clNo, sotienxxx);
                    gridView4.SetRowCellValue(1, clCo, 0);
                }
                else
                {
                    gridView4.SetRowCellValue(0, clNo, sotienxxx);
                    gridView4.SetRowCellValue(0, clCo, 0);

                    gridView4.SetRowCellValue(1, clNo, 0);
                    gridView4.SetRowCellValue(1, clCo, sotienxxx);
                }
            }
            catch
            {

            }
        }

        private void txtTiGia_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTiGia.Text);
                txtTiGia.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void txtTiGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    decimal value = decimal.Parse(txtTiGia.Text);
                    txtTiGia.Text = String.Format("{0:#,##0.00}", value);

                }
                catch
                {

                }
            }
        }

        private void txtSoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    decimal value = decimal.Parse(txtSoTien.Text);
                    txtSoTien.Text = String.Format("{0:#,##0.00}", value);
                    double sotienxxx = Convert.ToDouble(txtSoTien.Text.ToString());
                    if (checkNhaCungCap.Checked == true) // mua hang
                    {
                        gridView4.SetRowCellValue(0, clNo, sotienxxx);
                        gridView4.SetRowCellValue(0, clCo, 0);

                        gridView4.SetRowCellValue(1, clNo, 0);
                        gridView4.SetRowCellValue(1, clCo, sotienxxx);

                    }
                    else if (checkKhachHang.Checked == true)
                    {
                        gridView4.SetRowCellValue(0, clNo, 0);
                        gridView4.SetRowCellValue(0, clCo, sotienxxx);

                        gridView4.SetRowCellValue(1, clNo, sotienxxx);
                        gridView4.SetRowCellValue(1, clCo, 0);
                    }
                    else
                    {
                        gridView4.SetRowCellValue(0, clNo, sotienxxx);
                        gridView4.SetRowCellValue(0, clCo, 0);

                        gridView4.SetRowCellValue(1, clNo, 0);
                        gridView4.SetRowCellValue(1, clCo, sotienxxx);
                    }
                }
                catch
                {

                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                mbPrint = true;
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                DataTable dttttt2 = dv1212.ToTable();
                string shienthi = "1";
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                mdtCHiTietTaKhoan_print = dv.ToTable();

                mbTienUSD = checkUSD.Checked;
                mdaNgayThang = dteNgayChungTu.DateTime;
                msNguoiNopTen = txtDoiTuong.Text.ToString();
                msDiaChi = txtDoiTuong.Text.ToString();
                msDienGiai = txtDienGiai.Text.ToString();
                msSoChungTu = txtSoChungTu.Text.ToString();
                string Str1 = msSoChungTu.Substring(0, 2);//Cắt chuỗi từ vị trí đầu tiên(vị trí 0) đến vị trí số 2
                if (Str1 == "BC")
                    msLoaiChungTu = "BÁO CÓ";
                if (Str1 == "BN")
                    msLoaiChungTu = "BÁO NỢ";
                if (Str1 == "PT")
                    msLoaiChungTu = "PHIẾU THU";
                if (Str1 == "PC")
                    msLoaiChungTu = "PHIẾU CHI";

                mdbSoTien = Convert.ToDouble(txtSoTien.Text.ToString());
                mdbTiGia = Convert.ToDouble(txtTiGia.Text.ToString());
                for (int i = 0; i < mdtCHiTietTaKhoan_print.Rows.Count; i++)
                {
                    clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    if (Convert.ToDouble(mdtCHiTietTaKhoan_print.Rows[i]["No"].ToString()) == 0 & Convert.ToDouble(mdtCHiTietTaKhoan_print.Rows[i]["Co"].ToString()) > 0)
                    {
                        clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(mdtCHiTietTaKhoan_print.Rows[i]["SoTaiKhoanCon"].ToString());
                        DataTable dtcon = clscon.SelectOne();
                        ms_TaiKhoanCo = clscon.sSoTaiKhoanCon.Value;
                    }
                    if (Convert.ToDouble(mdtCHiTietTaKhoan_print.Rows[i]["No"].ToString()) > 0 & Convert.ToDouble(mdtCHiTietTaKhoan_print.Rows[i]["Co"].ToString()) == 0)
                    {
                        clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(mdtCHiTietTaKhoan_print.Rows[i]["SoTaiKhoanCon"].ToString());
                        DataTable dtcon = clscon.SelectOne();
                        msTaiKhoan_No = clscon.sSoTaiKhoanCon.Value;
                    }
                }

                frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No ff = new frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No();
                ff.ShowDialog();
            }
            catch { }
        }
    }
}
