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
    public partial class frmChiTietTaiKhoanKeToan : Form
    {
        private bool KiemTraLuu()
        {
            if (txtSoTKMe.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số tk con ");
                return false;
            }
            else if (txtTenTKMe.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên TK con ");
                return false;
            }
            else return true;
        }
    
        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string ssotkcon = txtSoTKMe.Text.ToString();
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and SoTaiKhoanMe ='" + ssotkcon + "'";
                DataView dv = dt.DefaultView;
                DataTable newdt = dv.ToTable();

                if (newdt.Rows.Count > 0)
                {
                    MessageBox.Show("Đã có tài khoản: " + ssotkcon + ". Vui lòng chọn tài khoản khác ");
                    return;
                }
                else
                {
                   
                    cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls.bTonTai = true;
                    cls.sSoTaiKhoanMe = txtSoTKMe.Text.ToString();
                    cls.sTenTaiKhoanMe = txtTenTKMe.Text.ToString();
                    cls.sDienGiaiMe = txtDienGiai.Text.ToString();                   
                    cls.Insert();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
            }

        }
        public frmChiTietTaiKhoanKeToan()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }
    }
}
