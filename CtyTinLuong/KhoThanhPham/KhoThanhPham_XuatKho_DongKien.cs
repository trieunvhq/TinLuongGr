﻿using DevExpress.XtraEditors;
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
    public partial class KhoThanhPham_XuatKho_DongKien : Form
    {
        public KhoThanhPham_XuatKho_DongKien()
        {
            InitializeComponent();
        }

        private void Hienthi_Lable_TonKho(int xxID_VTHH, int id_daily_, double soluongxuat_moi)
        {
            
            //clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            //cls.iID_VTHH = xxID_VTHH;
            //DataTable dt = cls.SelectOne();
            //double soluongton = 0;
            //clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            //clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            //double soluongnhap;
            //DataTable dt_NhapTruoc = new DataTable();

            //dt_NhapTruoc = cls1.SA_NhapTruocKy_ID_VTHH_ID_DaiLy(xxID_VTHH, id_daily_, DateTime.Today);


            //soluongnhap = CheckString.ConvertToDouble_My(dt_NhapTruoc.Rows[0]["SoLuong_NhapTruocKy"].ToString());
            //soluongton = soluongnhap - soluongxuat_moi;
            //if (soluongton < 0)
            //    MessageBox.Show("" + madaily + "-" + stendaily + " || " + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "");
            ////label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";


        }
        private string Load_soChungTu_KhoThanhPham()
        {
            string sochungtu = "";
            clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {              
                sochungtu = "NKTP 1";
            }
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;               
                sochungtu = "NKTP " + xxx2 + "";

            }

            return sochungtu;
        }

        private string Load_soChungTu_XuatKhoDongKien()
        {
            string sochungtu = "";
            clsDongKien_TbXuatKho cls3 = new clsDongKien_TbXuatKho();
            DataTable dt1 = cls3.SelectAll();           
            int k = dt1.Rows.Count;
            if (k == 0)
            {
                sochungtu = "XKDK 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "XKDK " + xxx2 + "";
            }

            return sochungtu;
        }
        private void HienThi_ThemMoi_XuatKho()
        {
            gridNguoiLap.EditValue = 14;           
            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = Load_soChungTu_XuatKhoDongKien();
            txtThamChieu.Text = Load_soChungTu_KhoThanhPham();
        }
        private void HienThi_Sua_XuatKho(int xxid_Xuatkho_)
        {
            clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            cls1.iID_XuatKhoDongKien = xxid_Xuatkho_;
            DataTable dt = cls1.SelectOne();          
            if (cls1.bNhapDaiLy_True == true)
            {
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;            
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;

            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt2 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_Xuatkho_);
            gridControl1.DataSource = dt;

        }
        private void HienThi_Copy_XuatKho(int xxid_Xuatkho_)
        {
            clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            cls1.iID_XuatKhoDongKien = xxid_Xuatkho_;
            DataTable dt = cls1.SelectOne();
            if (cls1.bNhapDaiLy_True == true)
            {
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = Load_soChungTu_XuatKhoDongKien();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtThamChieu.Text = Load_soChungTu_KhoThanhPham();
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;

            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt2 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_Xuatkho_);
            gridControl1.DataSource = dt;

        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();        

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            

            clsDongKien_TbNhapKho_ChiTietNhapKho cls = new clsDongKien_TbNhapKho_ChiTietNhapKho();
            DataTable dt = cls.H_DongKien_S_D_IDVTHH_XKDK();      
            Search_MaVT.DataSource = dt;
            Search_MaVT.ValueMember = "ID_VTHH";
            Search_MaVT.DisplayMember = "MaVT";


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
            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }                       

            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                dteNgayChungTu.Focus();
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
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }

        private void Luu_ChiLuu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                  
                    MessageBox.Show("Đã lưu", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Luu_Va_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    
                    MessageBox.Show("Đã lưu và gửi dữ liệu");
                }
                catch
                {

                }
            }
        }
        private void KhoThanhPham_XuatKho_DongKien_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            if (UCThanhPham_NhapKho_DongKien.mbThemMoi == true)
                HienThi_ThemMoi_XuatKho();
            else if (UCThanhPham_NhapKho_DongKien.mbSua == true)
                HienThi_Sua_XuatKho(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
            else HienThi_Copy_XuatKho(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
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
                    txtNguoiNhap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_VTHH)
            {
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, tenvthh);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, donvitinhvthh);
                //gridView4.SetRowCellValue(e.RowHandle, clChange_IN, "1");
            }
        }

        int id_vthh; string tenvthh, donvitinhvthh;

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.DeleteRow(gridView4.FocusedRowHandle);
        }

        private void Search_MaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                id_vthh = Convert.ToInt32(row["ID_VTHH"].ToString());
                tenvthh = row["TenVTHH"].ToString();
                donvitinhvthh = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
