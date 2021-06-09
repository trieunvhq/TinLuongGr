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
    public partial class frmDoiMatKhau : Form
    {
        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbDangNhap cls = new clsTbDangNhap();
                cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
                cls.sTen = txtTen.Text.ToString();
                cls.sMatKhau = txtXacNhanMK.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.Update();
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }
        private bool KiemTraLuu()
        {

            if (txtTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn tên đăng nhập ");
                return false;
            }

            if (txtMKMoi.Text.ToString() != txtXacNhanMK.Text.ToString())
            {
                MessageBox.Show("Mật khẩu mới chưa đúng. Vui lòng nhập lại ");
                return false;
            }
            clsTbDangNhap cls = new clsTbDangNhap();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectOne();
            if(dt.Rows[0]["MatKhau"].ToString().Trim() != txtMKCu.Text.ToString().Trim())
            {
                MessageBox.Show("Mật khẩu cũ không chính xác");
                return false;
            }
            return true;

        }
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMKCu.UseSystemPasswordChar = false;
                txtMKMoi.UseSystemPasswordChar = false;
                txtXacNhanMK.UseSystemPasswordChar = false;

            }
            else
            {
                txtMKCu.UseSystemPasswordChar = false;
                txtMKMoi.UseSystemPasswordChar = false;
                txtXacNhanMK.UseSystemPasswordChar = false;
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMKCu.UseSystemPasswordChar = true;
            txtMKMoi.UseSystemPasswordChar = true;
            txtXacNhanMK.UseSystemPasswordChar = true;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
