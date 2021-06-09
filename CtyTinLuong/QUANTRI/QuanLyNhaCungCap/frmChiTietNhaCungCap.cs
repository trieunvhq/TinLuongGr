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
    public partial class frmChiTietNhaCungCap : Form
    {

        private bool KiemTraLuu()
        {
            if (txtMaNCC.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã Nhân viên ");
                return false;
            }
            else if (txtTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên ");
                return false;
            }

            else return true;

        }
        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbNhaCungCap cls = new clsTbNhaCungCap();
                cls.sMaNhaCungCap = txtMaNCC.Text.ToString();
                cls.sMaSoThue = txtMaSoThue.Text.ToString();
                cls.sTenNhaCungCap = txtTen.Text.ToString();
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
                cls.sNguoiLienHe = txtDaiDien.Text.ToString();
                if (gridTKKeToan.EditValue != null)
                    cls.iID_TaiKhoanKeToan = Convert.ToInt16(gridTKKeToan.EditValue.ToString());
                if(frmNhaCungCap.mbSua==true)
                {
                    cls.iID_NhaCungCap = frmNhaCungCap.miID_Sua_NCC;
                    cls.Update();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                else
                {
                    cls.Insert();
                    MessageBox.Show("Đã thêm mới"); 
                    this.Close();
                }
                
                
            }
        }

      
        private void HienThi_SuaThongTin_NCC()
        {
            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            cls.iID_NhaCungCap = frmNhaCungCap.miID_Sua_NCC;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtMaNCC.Text = dt.Rows[0]["MaNhaCungCap"].ToString();
                txtMaSoThue.Text = dt.Rows[0]["MaSoThue"].ToString();
                txtTen.Text = dt.Rows[0]["TenNhaCungCap"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                txtSDT.Text = dt.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSoTaiKhoan.Text = dt.Rows[0]["SoTaiKhoan"].ToString();
                txtNganHang.Text = dt.Rows[0]["TenNganHang"].ToString();
                txtTinh_ThanhPho.Text = dt.Rows[0]["Tinh_ThanhPho"].ToString();
                txtChiNhanh.Text = dt.Rows[0]["ChiNhanh"].ToString();
                txtDaiDien.Text = dt.Rows[0]["NguoiLienHe"].ToString();
                checNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
                if (dt.Rows[0]["ID_TaiKhoanKeToan"].ToString() != "")
                    gridTKKeToan.EditValue = cls.iID_TaiKhoanKeToan.Value;
            }

        }
        public frmChiTietNhaCungCap()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThoat_Click_1(object sender, EventArgs e)
        {

        }

        private void btThoat_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietNhaCungCap_Load(object sender, EventArgs e)
        {
            clsNganHang_TaiKhoanKeToanCon clsme = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtme = clsme.SelectAll();
            dtme.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvme = dtme.DefaultView;
            DataTable newdtme = dvme.ToTable();

            gridTKKeToan.Properties.DataSource = newdtme;
            gridTKKeToan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKKeToan.Properties.DisplayMember = "SoTaiKhoanCon";

            if (frmNhaCungCap.mbSua == true)
                HienThi_SuaThongTin_NCC();
           else if (frmNhaCungCap.mbCopy == true)
                HienThi_SuaThongTin_NCC();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }
    }
}
