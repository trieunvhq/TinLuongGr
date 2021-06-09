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
    public partial class frmChiTietTamUng : Form
    {
        int bienthangthai =3; string sochungtu_tbThuChi;
        public void HienThiSoChungTu(int bientrangthaikkkkkkkkkk)
        {
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SelectAll();
            if (bientrangthaikkkkkkkkkk == 1)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BC 1";
                    else txtsochungtu_tbThuChi.Text = "BC " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 2)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BN 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BN 1";
                    else txtsochungtu_tbThuChi.Text = "BN " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 3)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PC 1";
                    else txtsochungtu_tbThuChi.Text = "PC " + xxx2 + "";
                }
            }
            else if (bientrangthaikkkkkkkkkk == 4)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PT 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PT 1";
                    else txtsochungtu_tbThuChi.Text = "PT " + xxx2 + "";
                }
            }
        }
        private void Luu__TbThuChi()
        {
            if (!KiemTraLuu()) return;
            else
            {
                HienThiSoChungTu(bienthangthai);
                sochungtu_tbThuChi = txtsochungtu_tbThuChi.Text.ToString();
                clsNganHang_tbThuChi clsxxx1 = new clsNganHang_tbThuChi();
                clsxxx1.daNgayChungTu = dteNgayChungTu.DateTime;
                clsxxx1.sSoChungTu = sochungtu_tbThuChi;
                clsxxx1.sDienGiai = txtDienGiai.Text.ToString();
                clsxxx1.fSoTien = Convert.ToDouble(txtSoTienTamUng.Text.ToString());
                clsxxx1.sThamChieu = txtSoChungTu.Text.ToString();
                clsxxx1.sDoiTuong = txtTenNguoiTamUng.Text.ToString();
                clsxxx1.bTonTai = true;
                clsxxx1.bNgungTheoDoi = false;
                clsxxx1.iID_NguoiLap = 13;
                clsxxx1.bTienUSD = false;
                clsxxx1.fTiGia = 1;
                clsxxx1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                clsxxx1.bDaGhiSo = false;
              ///  clsxxx1.bBitThuChiKhac = false;
                clsxxx1.iID_DoiTuong = Convert.ToInt32(gridNguoiTamUng.EditValue.ToString());
                clsxxx1.iBienMuaHang1_BanHang2_ConLai_0 = 0;
                clsxxx1.Insert();
                // không Lưu chi tiết biến động tài khoản ngân hàng
               
            }
        }

        private void Luu__VaobangLuong()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
                cls.iThang = Convert.ToInt32(txtKhauTruLuong.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                cls.iID_CongNhan= Convert.ToInt32(gridNguoiTamUng.EditValue.ToString());
                DataTable dt = cls.SelectOne_W_Thang_Nam_ID_Congnhan();
                if (dt.Rows.Count > 0)
                {
                    int ID_Chitietchamcong = Convert.ToInt32(dt.Rows[0]["ID_ChiTietChamCong"].ToString());
                    decimal sotientamungmoi = Convert.ToDecimal(txtSoTienTamUng.Text.ToString());
                    decimal sotientamungcu = Convert.ToDecimal(dt.Rows[0]["TamUng"].ToString());
                    cls.iID_ChiTietChamCong = ID_Chitietchamcong;
                    cls.dcTamUng = sotientamungcu + sotientamungmoi;
                    cls.Update_SoTienTamUng();
                }
            }
        }
        private bool LuuDuLieu_ChiLuu()
        {
            if (!KiemTraLuu()) return false;           
            else
            {
                clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.daNgayChungTu = dteNgayChungTu.DateTime;
                cls.iID_NguoiTamUng = Convert.ToInt32(gridNguoiTamUng.EditValue.ToString());
                cls.dcSoTien = Convert.ToDecimal(txtSoTienTamUng.Text.ToString());
                cls.sDienGiai= txtDienGiai.Text.ToString();
                cls.iKhauTruLuongThang = Convert.ToInt32(txtKhauTruLuong.Text.ToString());
                cls.iKhauTruLuongThang_Nam = Convert.ToInt32(txtNam.Text.ToString());
              
                cls.iID_NguoiLap= Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls.bDaKhauTru = false;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bGuiDuLieu = false;
                if (UCLuong_TamUng.mbThemMoiTamUng == true)
                {
                    cls.Insert();
                }
                else
                {
                    cls.iID_TamUng = UCLuong_TamUng.miiiiID_TamUng;
                    cls.Update();   
                }
                UCLuong_TamUng.mbThemMoiTamUng = true;
                return true;
            }
        }

        private bool LuuDuLieu_Va_gui()
        {
            if (!KiemTraLuu()) return false;
            else
            {
                clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.daNgayChungTu = dteNgayChungTu.DateTime;
                cls.iID_NguoiTamUng = Convert.ToInt32(gridNguoiTamUng.EditValue.ToString());
                cls.dcSoTien = Convert.ToDecimal(txtSoTienTamUng.Text.ToString());
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.iKhauTruLuongThang = Convert.ToInt32(txtKhauTruLuong.Text.ToString());
                cls.iKhauTruLuongThang_Nam = Convert.ToInt32(txtNam.Text.ToString());
              
                cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls.bDaKhauTru = false;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bGuiDuLieu = true;
                if (UCLuong_TamUng.mbThemMoiTamUng == true)
                {
                    cls.Insert();
                }
                else
                {
                    cls.iID_TamUng = UCLuong_TamUng.miiiiID_TamUng;
                    cls.Update();
                }
                UCLuong_TamUng.mbThemMoiTamUng = true;
                Luu__TbThuChi();
                Luu__VaobangLuong();
                return true;
            }
        }
        private bool KiemTraLuu()
        {
            if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (gridNguoiTamUng.EditValue == null)
            {
                MessageBox.Show("Chưa có nguoi tạm ứng ");
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người mua hàng ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }
            //else if (gridTKCo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa TK có ");
            //    return false;
            //}
            //else if (gridTKNo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa chọn TK nợ ");
            //    return false;
            //}

            else if (Convert.ToDouble(txtSoTienTamUng.Text.ToString()) == 0)
            {
                MessageBox.Show("Số tiền tạm ứng phải lớn hơn 0 ");
                return false;
            }
            else return true;

        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 11;

            clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
            DataTable dtthuchi = cls.SelectAll();
            dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvthuchi = dtthuchi.DefaultView;
            DataTable dvthuchi3 = dvthuchi.ToTable();
            int k = dvthuchi3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "TU 1";
            else
            {
                string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
                if (xxx2 >= 10000)
                    txtSoChungTu.Text = "TU 1";
                else txtSoChungTu.Text = "TU " + xxx2 + "";
            }

            string thang = DateTime.Today.ToString("MM");
            string nam = DateTime.Today.ToString("yyyy");
            dteNgayChungTu.DateTime = DateTime.Today;
            txtNam.Text = nam;
            txtKhauTruLuong.Text = thang;
            gridNguoiLap.EditValue = 11;        
        }
        private void HienThi_Sua()
        {
            clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
            cls.iID_TamUng = UCLuong_TamUng.miiiiID_TamUng;
            DataTable dt = cls.SelectOne();
            if(dt.Rows.Count>0)
            {
                if(cls.bGuiDuLieu.Value==true)
                {
                    btLuu_Copy.Enabled = false;
                    btLuu_Dong.Enabled = false;
                    btLuu_Gui_Copy.Enabled = false;
                    btLuu_Gui_Dong.Enabled = false;
                }
                txtSoChungTu.Text = cls.sSoChungTu.Value;
                dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
                gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
                txtKhauTruLuong.Text = cls.iKhauTruLuongThang.Value.ToString();
                txtNam.Text = cls.iKhauTruLuongThang_Nam.Value.ToString();
                gridNguoiTamUng.EditValue = cls.iID_NguoiTamUng.Value;
                txtDienGiai.Text = cls.sDienGiai.Value;
                txtSoTienTamUng.Text = cls.dcSoTien.Value.ToString();
               
            }
        }
        private void Load_LockUp()
        {
            clsNganHang_TaiKhoanKeToanCon clsme = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtme = clsme.SelectAll();
            dtme.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvme = dtme.DefaultView;
            DataTable newdtme = dvme.ToTable();

            //gridTKCo.Properties.DataSource = newdtme;
            //gridTKCo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            //gridTKCo.Properties.DisplayMember = "SoTaiKhoanCon";

            //gridTKNo.Properties.DataSource = newdtme;
            //gridTKNo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            //gridTKNo.Properties.DisplayMember = "SoTaiKhoanCon";



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi222 = clsNguoi.SelectAll();
            dtNguoi222.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong2222 = dtNguoi222.DefaultView;
            DataTable newdtCaTruong2222 = dvCaTruong2222.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong2222;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
        }
        public frmChiTietTamUng()
        {
            InitializeComponent();
        }

        private void frmChiTietTamUng_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            if (UCLuong_TamUng.mbThemMoiTamUng == true)
            {
               
                HienThi_ThemMoi();
            }
            else
            {
                HienThi_Sua();
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
                    txtNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void gridNguoiTamUng_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridNguoiTamUng.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenNguoiTamUng.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void txtSoTienTamUng_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtSoTienTamUng.Text, System.Globalization.NumberStyles.AllowThousands);
                txtSoTienTamUng.Text = String.Format(culture, "{0:N0}", value);
                txtSoTienTamUng.Select(txtSoTienTamUng.Text.Length, 0);
            }
            catch
            {
            }
        }

       

      

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            if (!LuuDuLieu_ChiLuu()) return;
            else
            {
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }

        private void btLuu_Copy_Click(object sender, EventArgs e)
        {
            if (!LuuDuLieu_ChiLuu()) return;
            else
            {
                MessageBox.Show("Đã lưu");
                clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                DataTable dtthuchi = cls.SelectAll();
                dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                DataView dvthuchi = dtthuchi.DefaultView;
                DataTable dvthuchi3 = dvthuchi.ToTable();
                int k = dvthuchi3.Rows.Count;
                if (k == 0)
                    txtSoChungTu.Text = "TU 1";
                else
                {
                    string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtSoChungTu.Text = "TU 1";
                    else txtSoChungTu.Text = "TU " + xxx2 + "";
                }

            }
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            if (!LuuDuLieu_Va_gui()) return;
            else
            {
                MessageBox.Show("Đã lưu và gưi dữ liệu");
                this.Close();
            }
        }

        private void btLuu_Gui_Copy_Click(object sender, EventArgs e)
        {
            if (!LuuDuLieu_Va_gui()) return;
            else
            {
                MessageBox.Show("Đã lưu và gưi dữ liệu");
                clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                DataTable dtthuchi = cls.SelectAll();
                dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                DataView dvthuchi = dtthuchi.DefaultView;
                DataTable dvthuchi3 = dvthuchi.ToTable();
                int k = dvthuchi3.Rows.Count;
                if (k == 0)
                    txtSoChungTu.Text = "TU 1";
                else
                {
                    string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtSoChungTu.Text = "TU 1";
                    else txtSoChungTu.Text = "TU " + xxx2 + "";
                }

            }
        }

     

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKhauTruLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
                cls.iThang = Convert.ToInt32(txtKhauTruLuong.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                DataTable dtNguoi = cls.SelectAll_HienThi_TamUng_TrongThang();
                dtNguoi.DefaultView.RowFilter = "DaTraLuong= False";
                DataView dvCaTruong = dtNguoi.DefaultView;
                DataTable newdtCaTruong = dvCaTruong.ToTable();

                gridNguoiTamUng.Properties.DataSource = newdtCaTruong;
                gridNguoiTamUng.Properties.ValueMember = "ID_NhanSu";
                gridNguoiTamUng.Properties.DisplayMember = "MaNhanVien";
            }
            catch
            {

            }

        }

        private void txtKhauTruLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
                cls.iThang = Convert.ToInt32(txtKhauTruLuong.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                DataTable dtNguoi = cls.SelectAll_HienThi_TamUng_TrongThang();
                dtNguoi.DefaultView.RowFilter = "DaTraLuong= False";
                DataView dvCaTruong = dtNguoi.DefaultView;
                DataTable newdtCaTruong = dvCaTruong.ToTable();

                gridNguoiTamUng.Properties.DataSource = newdtCaTruong;
                gridNguoiTamUng.Properties.ValueMember = "ID_NhanSu";
                gridNguoiTamUng.Properties.DisplayMember = "MaNhanVien";
            }
            catch
            {

            }
        }
    }
}
