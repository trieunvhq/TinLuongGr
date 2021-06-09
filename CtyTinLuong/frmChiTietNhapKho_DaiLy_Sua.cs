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
    public partial class frmChiTietNhapKho_DaiLy_Sua : Form
    {
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        int miID_DinhMucNPL_XXx;
        int iiiIDThanhPham_QuyDoi;
        bool Check_BaoVe, Check_LaiXe, Check_DaiLy, DaNhapKho;
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
            else if (gridMaDinhMucDot.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột");
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
        private bool Luu_ChiLuu()
        {
            if (!KiemTraLuu()) return false;
            else
            {
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                DataTable dt = cls1.SelectOne();              
                Check_BaoVe = cls1.bCheck_BaoVe.Value;
                Check_LaiXe = cls1.bCheck_LaiXe.Value;
                Check_DaiLy = cls1.bCheck_DaiLy.Value;
                DaNhapKho = cls1.bCheck_BaoVe.Value;

                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                //cls1.fSoLuongXuatTheoBao = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                //cls1.iID_DinhMucDot = Convert.ToInt32(gridMaDinhMucDot.EditValue.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
               // cls1.fSoLuongTonhanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                if (gridTKCo.EditValue.ToString() != "" & gridTKNo.EditValue.ToString() != "" & Convert.ToDouble(txtTienCo.Text.ToString()) != 0 & Convert.ToDouble(txtTienNo.Text.ToString()) != 0)
                {
                    cls1.iID_TKCo = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    cls1.iID_TKNo = Convert.ToInt32(gridTKNo.EditValue.ToString());
                }
               
                cls1.bTrangThaiXuatNhap_KhoDaiLy = false;
                cls1.bTrangThaiXuatNhap_Kho_BTP = true;
                cls1.bTrangThaiXuatNhap_Kho_NPL = true;
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bCheck_BaoVe = Check_BaoVe;
                cls1.bCheck_DaiLy = Check_DaiLy;
                cls1.bCheck_LaiXe = Check_LaiXe;
                cls1.bDaNhapKho = false;
                cls1.Update();

                int iiID_Nhapkho;
                iiID_Nhapkho = cls1.iID_NhapKhoDaiLy.Value;

                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                cls2.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                cls2.Delete_W_ID_NhapKhoDaiLy();

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dttttt2 = dv2232xx.ToTable();

                // Nhap kho Thành pham quy doi
                cls2.iID_NhapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_VTHH = iiiIDThanhPham_QuyDoi;
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                if (txtDonGiaThanhPhamQuyDoi.Text.ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.Insert();

                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
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
                    cls2.Insert();
                }
                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                cls.iID_ChungTu = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.daNgayThang = dteNgayChungTu.DateTime;
                cls.Delete_W_iID_ChungTu_sSoChungTu_daNgayThan();

                if (gridTKCo.EditValue.ToString() != "" & gridTKNo.EditValue.ToString() != "" & Convert.ToDouble(txtTienCo.Text.ToString()) != 0 & Convert.ToDouble(txtTienNo.Text.ToString()) != 0)
                {

                    cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKNo.EditValue.ToString());
                    clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKNo.EditValue.ToString());
                    DataTable dtcon = clscon.SelectOne();
                  
                    cls.iID_ChungTu = iiID_Nhapkho;
                    cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls.daNgayThang = dteNgayChungTu.DateTime;
                    cls.fCo = 0;
                    cls.fNo = Convert.ToDouble(txtTienNo.Text.ToString());
                    cls.bNgungTheoDoi = false;
                    cls.bTonTai = true;
                    cls.fTiGia = 1;
                    cls.bTienUSD = false;
                  
                    cls.bDaGhiSo = false;
                    cls.Insert();
                    // Có
                    cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    clsNganHang_TaiKhoanKeToanCon clscon2 = new clsNganHang_TaiKhoanKeToanCon();
                    clscon2.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    DataTable dtcon2 = clscon2.SelectOne();
                  
                    cls.iID_ChungTu = iiID_Nhapkho;
                    cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls.daNgayThang = dteNgayChungTu.DateTime;
                    cls.fCo = Convert.ToDouble(txtTienCo.Text.ToString());
                    cls.fNo = 0;
                    cls.bNgungTheoDoi = false;
                    cls.bTonTai = true;
                    cls.fTiGia = 1;
                    cls.bTienUSD = false;
                  
                    cls.bDaGhiSo = false;
                    cls.Insert();
                }                
                return true;
            }
        }

        private bool Luu_themMoi_DuLieubangLuong()
        {

            if (!KiemTraLuu()) return false;
            else
            {
                int ID_DaiLyxx = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                int thangx =Convert.ToInt32(dteNgayChungTu.DateTime.ToString("MM"));
                int namxx = Convert.ToInt32(dteNgayChungTu.DateTime.ToString("yyyy"));
                DateTime tungay = GetFistDayInMonth(namxx, thangx);
                DateTime denngay = GetLastDayInMonth(namxx, thangx);

                clsDaiLy_BangLuong clsxx = new clsDaiLy_BangLuong();
                clsxx.iThang = thangx;
                clsxx.iNam = namxx;
                clsxx.iID_DaiLy = ID_DaiLyxx;
                DataTable dt = clsxx.SelectOne__W_Thang_Nam_ID_DaiLy();
                if (dt.Rows.Count==0)
                {                   
                    clsxx.iID_DaiLy = ID_DaiLyxx;
                    clsxx.iThang = thangx;
                    clsxx.iNam = namxx;
                    clsxx.dcLuongDaiLy = 0;
                    clsxx.dcTamUng = 0;
                    clsxx.dcSoTienDaTra = 0;
                    clsxx.sDienGiai = "";
                    clsxx.bTonTai = true;
                    clsxx.bNgungTheoDoi = false;
                    clsxx.bDaTraLuong = false;
                    clsxx.Insert();
                }

                return true;
            }

        }
        private bool Luu_NhapKhoDaiLy_XuatKho_NPL()
        {

            if (!KiemTraLuu()) return false;
            else
            {
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                DataTable dt = cls1.SelectOne();
                Check_BaoVe = cls1.bCheck_BaoVe.Value;
                Check_LaiXe = cls1.bCheck_LaiXe.Value;
                Check_DaiLy = cls1.bCheck_DaiLy.Value;
                DaNhapKho = cls1.bDaNhapKho.Value;

                
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                //cls1.fSoLuongXuatTheoBao = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                //cls1.iID_DinhMucDot = Convert.ToInt32(gridMaDinhMucDot.EditValue.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                //cls1.fSoLuongTonhanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                //if (gridTKCo.EditValue.ToString()!= "")
                //     cls1.iID_TKCo = Convert.ToInt32(gridTKCo.EditValue.ToString());
                //if (gridTKNo.EditValue.ToString() != "")
                //      cls1.iID_TKNo = Convert.ToInt32(gridTKNo.EditValue.ToString());
                if (gridTKCo.EditValue.ToString() != "" & gridTKNo.EditValue.ToString() != "" & Convert.ToDouble(txtTienCo.Text.ToString()) != 0 & Convert.ToDouble(txtTienNo.Text.ToString()) != 0)
                {
                    cls1.iID_TKCo = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    cls1.iID_TKNo = Convert.ToInt32(gridTKNo.EditValue.ToString());
                }
                cls1.bTrangThaiXuatNhap_KhoDaiLy = true;
                cls1.bTrangThaiXuatNhap_Kho_BTP = true;
                cls1.bTrangThaiXuatNhap_Kho_NPL = true;
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bCheck_BaoVe = Check_BaoVe;
                cls1.bCheck_DaiLy = Check_DaiLy;
                cls1.bCheck_LaiXe = Check_LaiXe;
                cls1.bDaNhapKho = DaNhapKho;
                cls1.Update();
                // update danhapkho neu có check bao ve check lai xe check dai ly
                int iiID_Nhapkho;
                iiID_Nhapkho = cls1.iID_NhapKhoDaiLy.Value;
                if (Convert.ToBoolean(dt.Rows[0]["Check_BaoVe"].ToString()) == true & (Convert.ToBoolean(dt.Rows[0]["Check_LaiXe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_DaiLy"].ToString()) == true))
                {
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
                }
                
                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                cls2.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                cls2.Delete_W_ID_NhapKhoDaiLy();

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dttttt2 = dv2232xx.ToTable();

                // Nhap kho Thành pham quy doi
                cls2.iID_NhapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_VTHH = iiiIDThanhPham_QuyDoi;
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                if (txtDonGiaThanhPhamQuyDoi.Text.ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.Insert();

                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKhoDaiLy = cls1.iID_NhapKhoDaiLy.Value;
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
                    cls2.Insert();
                }
                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                cls.iID_ChungTu = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.daNgayThang = dteNgayChungTu.DateTime;
                cls.Delete_W_iID_ChungTu_sSoChungTu_daNgayThan();

                if (gridTKCo.EditValue != null & gridTKNo.EditValue != null & Convert.ToDouble(txtTienCo.Text.ToString()) != 0 & Convert.ToDouble(txtTienNo.Text.ToString()) != 0)
                {

                    //cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKNo.EditValue.ToString());
                    //clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    //clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKNo.EditValue.ToString());
                    //DataTable dtcon = clscon.SelectOne();
                    //cls.iID_TaiKhoanKeToanMe = clscon.iID_TaiKhoanKeToanMe.Value;
                    //cls.iID_ChungTu = iiID_Nhapkho;
                    //cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    //cls.daNgayThang = dteNgayChungTu.DateTime;
                    //cls.fCo = 0;
                    //cls.fNo = Convert.ToDouble(txtTienNo.Text.ToString());
                    //cls.bNgungTheoDoi = false;
                    //cls.bTonTai = true;
                    //cls.fTiGia = 1;
                    //cls.bTienUSD = false;
                    //cls.bBoolTK_No = true;
                    //cls.bBoolTK_Co = false;
                    //cls.bBoolTKVAT = false;
                    //cls.bDaGhiSo = true;
                    //cls.Insert();
                    //// Có
                    //cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    //clsNganHang_TaiKhoanKeToanCon clscon2 = new clsNganHang_TaiKhoanKeToanCon();
                    //clscon2.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridTKCo.EditValue.ToString());
                    //DataTable dtcon2 = clscon2.SelectOne();
                    //cls.iID_TaiKhoanKeToanMe = clscon2.iID_TaiKhoanKeToanMe.Value;
                    //cls.iID_ChungTu = iiID_Nhapkho;
                    //cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    //cls.daNgayThang = dteNgayChungTu.DateTime;
                    //cls.fCo = Convert.ToDouble(txtTienCo.Text.ToString());
                    //cls.fNo = 0;
                    //cls.bNgungTheoDoi = false;
                    //cls.bTonTai = true;
                    //cls.fTiGia = 1;
                    //cls.bTienUSD = false;
                    //cls.bBoolTK_No = false;
                    //cls.bBoolTK_Co = true;
                    //cls.bBoolTKVAT = false;
                    //cls.bDaGhiSo = true;
                    //cls.Insert();
                }
                return true;                
            }

        }
        private void HienThi_GridControl_Sua()
        {
            double iisoluongxuat = 1;
            if (txtSoLuongXuat.Text.ToString() != "")
                iisoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
            double soKg1baoxxx = Convert.ToDouble(txtSoKG1Bao.Text.ToString());

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
            cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
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
            cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            double soluongxuat = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["SoLuongNhap"].ToString());
            double dongiaxxx = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["DonGia"].ToString());
            DataRow _ravi = dt2.NewRow();
            _ravi["ID_VTHH"] = iiID_VatTuChinh1;
            _ravi["MaVT"] = iiID_VatTuChinh1;
            _ravi["TenVTHH"] = dtkhoBTPvtuchinh1.Rows[0]["TenVTHH"].ToString();
            _ravi["DonViTinh"] = dtkhoBTPvtuchinh1.Rows[0]["DonViTinh"].ToString();
            _ravi["DinhMuc"] = 1;
            _ravi["SoLuongTon"] = Convert.ToDouble(dtkhoBTPvtuchinh1.Rows[0]["SoLuongTon"].ToString());
            _ravi["SoLuongTheoDinhMuc"] = soKg1baoxxx * iisoluongxuat;
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
                string xxsoluongdmimuc = dtctietdinhmuc.Rows[0]["SoLuong"].ToString();
                var xxxxsoluongdmimucc = Math.Round(double.Parse(xxsoluongdmimuc), 3);
                _ravi3["DinhMuc"] = xxxxsoluongdmimucc;
                _ravi3["SoLuongTheoDinhMuc"] = xxxxsoluongdmimucc * iisoluongxuat;
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
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        private void HienThi_Sua_XuatKho2222222222222()
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            cls1.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            DataTable dt = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            //txtSoLuongXuat.Text = cls1.fSoLuongXuatTheoBao.Value.ToString();
            //gridMaDinhMucDot.EditValue = cls1.iID_DinhMucDot.Value;
                 
            txtThamChieu.Text = cls1.sThamChieu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            if (cls1.bTrangThaiXuatNhap_KhoDaiLy == true)
            {
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
            double iisoluongxuat = 1;
            if (txtSoLuongXuat.Text.ToString() != "")
                iisoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
            double soKg1baoxxx = Convert.ToDouble(txtSoKG1Bao.Text.ToString());
            gridMaDinhMucNPL.EditValue = cls1.iID_DinhMucNguenPhuLieu.Value;       
            HienThi_GridControl_Sua();
            //gridControl1.DataSource = null;

            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_VTHH", typeof(int));
            //dt2.Columns.Add("MaVT", typeof(string));
            //dt2.Columns.Add("TenVTHH", typeof(string));
            //dt2.Columns.Add("DonViTinh", typeof(string));
            //dt2.Columns.Add("DinhMuc", typeof(float));
            //dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("SoLuongTon", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("ThanhTien", typeof(double));
            //dt2.Columns.Add("BoolVTChinh", typeof(bool));
            //dt2.Columns.Add("BoolNPL", typeof(bool));

            //clsDaiLy_tbChiTietNhapKho cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            //cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            //cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            //DataTable dtchitietDMNPL = cls.SelectAll_W_ID_NhapKhoDaiLy();
            //for (int i = 1; i < dtchitietDMNPL.Rows.Count; i++)
            //{
            //    double dongiaxxx333 = Convert.ToDouble(dtchitietDMNPL.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi3 = dt2.NewRow();
            //    int ID_VTHH = Convert.ToInt32(dtchitietDMNPL.Rows[i]["ID_VTHH"].ToString());
            //    _ravi3["ID_VTHH"] = ID_VTHH;
            //    _ravi3["MaVT"] = ID_VTHH;
            //    clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
            //    clvthh.iID_VTHH = ID_VTHH;
            //    DataTable dtvth = clvthh.SelectOne();
            //    _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
            //    _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
            //    if (i == 1)
            //    {
            //        clsKhoBTP_tbChiTietNhapKho xcls = new clsKhoBTP_tbChiTietNhapKho();
            //        xcls.iID_VTHH = ID_VTHH;
            //        DataTable dtbtp = xcls.Select_W_ID_VTHH();
            //        if (dtbtp.Rows.Count > 0)
            //            _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
            //    }
            //    else
            //    {
            //        clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
            //        xcls.iID_VTHH = ID_VTHH;
            //        DataTable dtbtp = xcls.Select_W_ID_VTHH();
            //        if (dtbtp.Rows.Count > 0)
            //            _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
            //    }

            //    string xxsoluong = dtchitietDMNPL.Rows[i]["SoLuongNhap"].ToString();
            //    var xxdinhmuc = Math.Round(double.Parse(xxsoluong), 3);
            //    _ravi3["DinhMuc"] = xxdinhmuc;
            //    _ravi3["SoLuongTheoDinhMuc"] = xxdinhmuc * iisoluongxuat;
            //    double SoLuong = Convert.ToDouble(dtchitietDMNPL.Rows[i]["SoLuongNhap"].ToString());
            //    _ravi3["SoLuong"] = SoLuong;
            //    _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
            //    _ravi3["GhiChu"] = dtchitietDMNPL.Rows[i]["GhiChu"].ToString();
            //    _ravi3["HienThi"] = "1";
            //    _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
            //    _ravi3["BoolVTChinh"] = false;

            //    dt2.Rows.Add(_ravi3);

            //}
            //gridControl1.DataSource = dt2;

            //double deTOngtien;
            //string shienthi = "1";
            //object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            //if (xxxx.ToString() != "")
            //    deTOngtien = Convert.ToDouble(xxxx);
            //else deTOngtien = 0;
            //txtTongTienHang.Text = deTOngtien.ToString();
        }
        
        private void HienThi_taiKhoanKeToan()
        {
            clsDaiLy_tbNhapKho cls = new CtyTinLuong.clsDaiLy_tbNhapKho();
            cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            DataTable dt = cls.SelectOne();
            if (dt.Rows[0]["ID_TKNo"].ToString() != "" & dt.Rows[0]["ID_TKCo"].ToString() != "")
            {
                gridTKNo.EditValue = cls.iID_TKNo.Value;
                gridTKCo.EditValue = cls.iID_TKCo.Value;
                clsNganHang_ChiTietBienDongTaiKhoanKeToan clstaikhoan = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clstaikhoan.iID_ChungTu = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
                clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
                DataTable dttaikhoanm = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();

                if (dttaikhoanm.Rows.Count > 0)
                {
                    for (int i = 0; i < dttaikhoanm.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dttaikhoanm.Rows[i]["BoolTK_No"].ToString()) == true)
                            txtTienNo.Text = dttaikhoanm.Rows[i]["No"].ToString();
                        if (Convert.ToBoolean(dttaikhoanm.Rows[i]["BoolTK_Co"].ToString()) == true)
                            txtTienCo.Text = dttaikhoanm.Rows[i]["Co"].ToString();
                    }
                }

            }


        }
        private void Load_LockUp()
        {


            clsNganHang_TaiKhoanKeToanCon clsme = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtme = clsme.SelectAll();
            dtme.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvme = dtme.DefaultView;
            DataTable newdtme = dvme.ToTable();

            gridTKCo.Properties.DataSource = newdtme;
            gridTKCo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKCo.Properties.DisplayMember = "SoTaiKhoanCon";


            gridTKNo.Properties.DataSource = newdtme;
            gridTKNo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKNo.Properties.DisplayMember = "SoTaiKhoanCon";

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
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
            DataTable dt3 = clsdinhmucdot.SelectAll();
            dt3.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv3 = dt3.DefaultView;
            dv3.Sort = "NgayThang DESC";
            DataTable dtxx3 = dv3.ToTable();


            gridMaDinhMucDot.Properties.DataSource = dtxx3;
            gridMaDinhMucDot.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot.Properties.DisplayMember = "SoHieu";


        }
        public frmChiTietNhapKho_DaiLy_Sua()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietNhapKho_DaiLy_Sua_Load(object sender, EventArgs e)
        {
           

            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemLookUpEdit2.DataSource = newdtvthh;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";
            Load_LockUp();
            HienThi_taiKhoanKeToan();
            HienThi_Sua_XuatKho2222222222222();
           

        }

        private void gridMaDinhMucNPL_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu clsncc = new clsDinhMuc_tbDM_NguyenPhuLieu();

                clsncc.iID_DinhMuc_NPL = Convert.ToInt16(gridMaDinhMucNPL.EditValue.ToString());
                miID_DinhMucNPL_XXx = Convert.ToInt16(gridMaDinhMucNPL.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtDienGiaiDMNPL.Text = dt.Rows[0]["DienGiai"].ToString();
                   
                }

                iiiIDThanhPham_QuyDoi = Convert.ToInt16(dt.Rows[0]["ID_VTHH_ThanhPham"].ToString());
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = iiiIDThanhPham_QuyDoi;
                DataTable dt1 = cls1.SelectOne();
                if (dt1.Rows.Count > 0)
                {

                    txtMaTPQuyDoi.Text = dt1.Rows[0]["MaVT"].ToString();
                    txtDVTThanhPhamQuyDoi.Text = dt1.Rows[0]["DonViTinh"].ToString();
                    txtTenThanhPhamQuyDoi.Text = dt1.Rows[0]["TenVTHH"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridMaDinhMucDot_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_tbDinhMuc_DOT clsncc = new clsDinhMuc_tbDinhMuc_DOT();
            string manccc = gridMaDinhMucDot.SelectedText.ToString();
            clsncc.iID_DinhMuc_Dot = Convert.ToInt16(gridMaDinhMucDot.EditValue.ToString());

            DataTable dt = clsncc.SelectOne();
            if (dt.Rows.Count > 0)
            {

                DateTime sngay2 = Convert.ToDateTime(dt.Rows[0]["NgayThang"].ToString());
                string sngay = sngay2.ToString("dd/MM/yyyy");
                string sca = dt.Rows[0]["Ca"].ToString();

                //string sokg1bao = dt.Rows[0]["SoKG_MotBao"].ToString();
                //string soKien1bao2 = dt.Rows[0]["SoKienMotBao"].ToString();
                //var soKien1bao = Math.Round(decimal.Parse(soKien1bao2), 3);
                txtSoKG1Bao.Text = dt.Rows[0]["SoKG_MotBao"].ToString();
                txtSoKien1Bao.Text = dt.Rows[0]["SoKienMotBao"].ToString();

            }
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
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
            try
            {
                if (txtSoLuongXuat.Text.ToString() != "" & txtSoKien1Bao.Text.ToString() != "")
                {
                    double soluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                    double sokien1baoxxx = Convert.ToDouble(txtSoKien1Bao.Text.ToString());
                    txtSoLuongThanhPhamQuyDoi.Text = (soluongxuat * sokien1baoxxx).ToString();

                }
            }
            catch
            {

            }

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
                object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
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

            }
            catch
            {

            }
        }

        private void txtTienNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNo.Text.ToString() != "" & txtTongTienHang.Text.ToString() != "")
            {
                double tienno = Convert.ToDouble(txtTienNo.Text.ToString());
                double tongtienhang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                txtTienCo.Text = (tongtienhang - tienno).ToString();
            }
        }

        private void txtTienCo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTienCo.Text);
                txtTienCo.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void checkTienNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTienNo.Checked == true)
            {
                txtTienNo.Text = txtTongTienHang.Text;
                txtTienCo.Text = txtTongTienHang.Text;
            }

            if (checkTienNo.Checked == false)
            {
                txtTienNo.Text = "0";
                txtTienCo.Text = "0";
            }
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt16(gridMaDaiLy.EditValue.ToString());
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else if (!Luu_ChiLuu()) return;
            else
            {
                MessageBox.Show("Đã lưu");
                this.Close();
            }

        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else if (!Luu_NhapKhoDaiLy_XuatKho_NPL()) return;
            else if (!Luu_themMoi_DuLieubangLuong()) return;
            else
            {
                MessageBox.Show("Đã lưu");
                this.Close();
            }
            
        }

        private void btBaoVe_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_BaoVe();
            
            
                cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
         

            MessageBox.Show("Đã qua cửa bảo vệ");
                
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

        }

        private void btLaiXe_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_LaiXe();
            
                cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
            
            MessageBox.Show("Đã qua cửa lái xe");
        }

        private void btDaiLy_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_DaiLy_Duoc_GiaoHang();
            //if (Convert.ToBoolean(dt.Rows[0]["Check_BaoVe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_LaiXe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_DaiLy"].ToString()) == true)
            //{
                cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
            //}

            MessageBox.Show("Đại lý đã nhận hàng");
        }

       

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                    txtDonGiaThanhPhamQuyDoi.Text = txtTongTienHang.Text;
                if (checkBox1.Checked == false)
                    txtDonGiaThanhPhamQuyDoi.Text = "0";
            }
            catch
            {
            }
        }

      
    }
}
