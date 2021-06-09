using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CtyTinLuong
{
  
    public partial class frmDangNhap : Form
    {
        public static int miID_DangNhap;
        private void KiemTraDangNhap()
        {
            clsTbDangNhap cls = new clsTbDangNhap();
            DataTable dt = cls.SelectAll();
        }
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            miID_DangNhap = 1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;

            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;

            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsTbDangNhap cls = new clsTbDangNhap();
            cls.sTen = txtTen.Text.ToString();
            cls.sMatKhau = txtMatKhau.Text.ToString();
            DataTable dt = cls.pr_tbDangNhap_KiemTraDangNhap();
            if (dt.Rows.Count > 0)
            {
                miID_DangNhap = Convert.ToInt16(dt.Rows[0]["ID_DangNhap"].ToString());
                this.Hide();
                frmMain ff = new frmMain();
                ff.Show();
            }
            else
            {
             
                MessageBox.Show("Kiểm tra lại Tên đăng nhập hoặc mật khẩu");
                txtTen.ResetText();
                txtMatKhau.ResetText();
                txtTen.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        } 

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtMatKhau.Focus();
            }
            else
            {

            }


        }
    }
}
