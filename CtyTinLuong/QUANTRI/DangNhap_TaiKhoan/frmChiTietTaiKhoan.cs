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
    public partial class frmChiTietTaiKhoan : Form
    {
        private void HienThi_SuaTaiKhoan()
        {
            txtTen.Text = frmQuanLyTaiKhoan.ms_Ten_TaiKhoan;
            txtMatKhau.Text = frmQuanLyTaiKhoan.ms_MatKhau_TaiKhoan;
            clsTbDangNhap cls = new clsTbDangNhap();
            cls.iID_DangNhap = frmQuanLyTaiKhoan.miID_DangNhap;
            DataTable dt = cls.SelectOne();
            if(cls.bBAdmin.Value==true)
            {
                txtTen.Enabled = false;
                groupBox1.Enabled = false;
                btLuu.Enabled = false;
            }
            checkBanHang.Checked = cls.bBBanHang.Value;
            checkMuaHang.Checked = cls.bBMuaHang.Value;
            checkNPL.Checked = cls.bBNguyenPhuLieu.Value;
            checkBanThanhPham.Checked = cls.bBBanThanhPham.Value;
            checkDaiLy.Checked = cls.bBDaiLy.Value;
            checkThanhPham.Checked = cls.bBThanhPham.Value;
            checkQuanLySanXuat.Checked = cls.bBQuanLySanXuat.Value;
            checkChamCong.Checked = cls.bBLuongChamCong.Value;
            checkQuyNganHang.Checked = cls.bBQuyNganHang.Value;
            checkQuanTri.Checked = cls.bBQuanTri.Value;
            checkCaTruong.Checked = cls.bBCaTruong.Value;
        }
        private void LuuDuLieu_ThemMoiTaiKhoan()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbDangNhap cls = new clsTbDangNhap();
                cls.sTen = txtTen.Text.ToString().Trim();
                cls.sMatKhau = txtMatKhau.Text.ToString().Trim();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bBBanHang = checkBanHang.Checked;
                cls.bBMuaHang = checkMuaHang.Checked;
                cls.bBNguyenPhuLieu = checkNPL.Checked;
                cls.bBBanThanhPham = checkBanThanhPham.Checked;
                cls.bBDaiLy = checkDaiLy.Checked;
                cls.bBThanhPham = checkThanhPham.Checked;
                cls.bBQuanLySanXuat = checkQuanLySanXuat.Checked;
                cls.bBLuongChamCong = checkChamCong.Checked;
                cls.bBQuyNganHang = checkQuyNganHang.Checked;
                cls.bBQuanTri = checkQuanTri.Checked;
                cls.bBCaTruong = checkCaTruong.Checked;
                cls.bBAdmin = false;
                cls.Insert();                
                MessageBox.Show("Đã thêm mới");
                btLuu.Enabled = false;
                //this.Close();
            }
        }
        private void LuuDuLieu_SuaTaiKhoan()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbDangNhap cls = new clsTbDangNhap();
                cls.iID_DangNhap = frmQuanLyTaiKhoan.miID_DangNhap;
                cls.sTen = txtTen.Text.ToString().Trim();
                cls.sMatKhau = txtMatKhau.Text.ToString().Trim();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bBBanHang = checkBanHang.Checked;
                cls.bBMuaHang = checkMuaHang.Checked;
                cls.bBNguyenPhuLieu = checkNPL.Checked;
                cls.bBBanThanhPham = checkBanThanhPham.Checked;
                cls.bBDaiLy = checkDaiLy.Checked;
                cls.bBThanhPham = checkThanhPham.Checked;
                cls.bBQuanLySanXuat = checkQuanLySanXuat.Checked;
                cls.bBLuongChamCong = checkChamCong.Checked;
                cls.bBQuyNganHang = checkQuyNganHang.Checked;
                cls.bBQuanTri = checkQuanTri.Checked;
                cls.bBCaTruong = checkCaTruong.Checked;
                cls.bBAdmin = false;
                cls.Update();
                MessageBox.Show("Đã lưu");
                btLuu.Enabled = false;
            }
        }
        private bool KiemTraLuu()
        {
           
            string smatkau = txtMatKhau.Text.ToString().Trim();
            string tendangnhap = txtTen.Text.ToString().Trim();
            clsTbDangNhap cls = new clsTbDangNhap();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;            
            DataTable dxxxx = dv.ToTable();
            string filterExpression = "";
            filterExpression = "Ten ='"+tendangnhap+"'";
            DataRow[] rows = dxxxx.Select(filterExpression);

            if (frmQuanLyTaiKhoan.mb_TheMoi_TaiKhoan == true)
            {
                if (rows.Length > 0)
                {
                    MessageBox.Show("Đã có tài khoản: " + tendangnhap + "\n Vui lòng chọn tên tài khoản khác");
                    return false;
                }
            }

            if (txtTen.Text==""||txtMatKhau.Text=="")
            {
                MessageBox.Show("Chưa có tên hoặc mật khẩu");
                return false;
            }            
            else if(smatkau.Length<4)
            {
                MessageBox.Show("Mật khẩu yếu, bao gồm ít nhất 4 ký tự trở lên\n Chọn lại mật khẩu");
                return false;
            }
            else return true;

        }
        public frmChiTietTaiKhoan()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietTaiKhoan_Load(object sender, EventArgs e)
        {
            if (frmQuanLyTaiKhoan.mb_TheMoi_TaiKhoan == false)
                HienThi_SuaTaiKhoan();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (frmQuanLyTaiKhoan.mb_TheMoi_TaiKhoan == true)
                LuuDuLieu_ThemMoiTaiKhoan();
            else LuuDuLieu_SuaTaiKhoan();
        }
    }
}
