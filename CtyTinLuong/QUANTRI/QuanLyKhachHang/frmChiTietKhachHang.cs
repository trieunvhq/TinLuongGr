﻿using System;
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
    public partial class frmChiTietKhachHang : Form
    {
        private bool KiemTraLuu()
        {
            clsTbKhachHang cls = new CtyTinLuong.clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            string tenkhach = txtTen.Text;
            string MaKH = txtMaKH.Text;
            string expression;
            expression = "TenKH='" + tenkhach + "'";
            DataRow[] foundRows;
            foundRows = dt.Select(expression);

            string expression22;
            expression22 = "MaKH='" + MaKH + "'";
            DataRow[] foundRows222;
            foundRows222 = dt.Select(expression22);

            if (foundRows.Length > 0)
            {
                MessageBox.Show("Đã có tên khách hàng tồn tại trong hệ thống ");
                return false;
            }
           else if (foundRows222.Length > 0)
            {
                MessageBox.Show("Đã có mã khách hàng tồn tại trong hệ thống ");
                return false;
            }           
            else if (txtMaKH.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã Nhân viên ");
                return false;
            }
            else if (txtTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên ");
                return false;
            }
            else if (gridTKKeToan.EditValue == null)
            {
                MessageBox.Show("Chưa có tài khoản kế toán ");
                return false;
            }
            else return true;

        }
      
        private void Luu_Khoa_TaiKhoanNganHang(int xxID_TK____)
        {
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.Update_Khoa_True(xxID_TK____);
        }
        private void Load_lockUp(bool themmoi)
        {
            DataTable dt = new DataTable();
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            if (themmoi == true)
                dt = cls.SA_Khoa_False();
            else dt = cls.SelectAll();
            gridTKKeToan.Properties.DataSource = dt;
            gridTKKeToan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKKeToan.Properties.DisplayMember = "SoTaiKhoanCon";
        }

        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {

                Luu_Khoa_TaiKhoanNganHang(Convert.ToInt32(gridTKKeToan.EditValue.ToString()));

                clsTbKhachHang cls = new clsTbKhachHang();
               
                cls.sMaKH = txtMaKH.Text.ToString();
                cls.sMaSoThue = txtMaSoThue.Text.ToString();
                cls.sTenKH = txtTen.Text.ToString();
                cls.sDiaChi = txtDiaChi.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.sSoDienThoai = txtSDT.Text.ToString();
                cls.sEmail = txtEmail.Text.ToString();
                cls.sSoTaiKhoan = txtSoTaiKhoan.Text.ToString();
                cls.sTenNganHang = txtNganHang.Text.ToString();
                cls.sTinh_ThanhPho = txtTinh_ThanhPho.Text.ToString();
                cls.sChiNhanh = txtChiNhanh.Text.ToString();
                cls.bNgungTheoDoi = checNgungTheoDoi.Checked; ;
                cls.bTonTai = true;
                cls.sDaiDien = txtDaiDien.Text.ToString();
                cls.iID_TaiKhoanKeToan = Convert.ToInt16(gridTKKeToan.EditValue.ToString());
                if (frmKhachHang.mbSua==true)
                {
                    clsTbKhachHang clsxx = new clsTbKhachHang();
                    clsxx.iID_KhachHang = frmKhachHang.miID_Sua_KH;
                    DataTable dt = clsxx.SelectOne();
                    cls.bKhoa = clsxx.bKhoa.Value;
                    cls.iID_KhachHang = frmKhachHang.miID_Sua_KH;
                    
                    cls.Update();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtMaKH.Text))
                    {
                        if (cls.SelectOne_MaKH(txtMaKH.Text.Trim()))
                        {
                            MessageBox.Show("Mã khách hàng \"" + txtMaKH.Text.Trim() + "\" đã tồn tại", "Thông báo");
                            txtMaKH.Focus();
                            return;
                        }
                    }

                    if (!String.IsNullOrEmpty(txtTen.Text))
                    {
                        if (cls.SelectOne_TenKH(txtTen.Text.Trim()))
                        {
                            if (MessageBox.Show("Tên khách hàng \"" + txtTen.Text.Trim() + "\" đã tồn tại", "Thông báo",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                txtTen.Focus();
                                return;
                            }
                        }
                    }
                    cls.bKhoa = false;
                    cls.Insert();
                    MessageBox.Show("Đã thêm mới");
                    this.Close();
                }
               
            }

        }
        private void HienThi_SuaThongTin_KhachHang()
        {
            clsTbKhachHang cls = new clsTbKhachHang();
            cls.iID_KhachHang = frmKhachHang.miID_Sua_KH;
            DataTable dt = cls.SelectOne();
            //if (dt.Rows.Count > 0)
            //{
                txtMaKH.Text = dt.Rows[0]["MaKH"].ToString();
                txtMaSoThue.Text = dt.Rows[0]["MaSoThue"].ToString();
                txtTen.Text = dt.Rows[0]["TenKH"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                txtSDT.Text = dt.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSoTaiKhoan.Text = dt.Rows[0]["SoTaiKhoan"].ToString();
                txtNganHang.Text = dt.Rows[0]["TenNganHang"].ToString();
                txtTinh_ThanhPho.Text = dt.Rows[0]["Tinh_ThanhPho"].ToString();
                txtChiNhanh.Text = dt.Rows[0]["ChiNhanh"].ToString();
                txtDaiDien.Text = dt.Rows[0]["DaiDien"].ToString();
                checNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
                if (dt.Rows[0]["ID_TaiKhoanKeToan"].ToString() != "")
                    gridTKKeToan.EditValue = cls.iID_TaiKhoanKeToan.Value;
            //}

        }

        public frmChiTietKhachHang()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietKhachHang_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            
            if (frmKhachHang.mbSua == true)
            {
                Load_lockUp(false);
                HienThi_SuaThongTin_KhachHang();
            }
            else if (frmKhachHang.mbCopy == true)
            {
                Load_lockUp(true);
                HienThi_SuaThongTin_KhachHang();
            }
            else
            {
                Load_lockUp(true);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridTKKeToan_EditValueChanged(object sender, EventArgs e)
        {
            int xxid = Convert.ToInt32(gridTKKeToan.EditValue.ToString());
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.iID_TaiKhoanKeToanCon = xxid;
            DataTable dt = cls.SelectOne();
            txtTenTaiKhoan.Text = cls.sTenTaiKhoanCon.Value;
            if (frmKhachHang.mbSua == false)
            {
                
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoanKeToan.mbTheMoi = true;
            frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon();
            ff.Show();
        }
    }
}
