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
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                cls.bTonTai = true;
                cls.sSoTaiKhoanMe = txtSoTKMe.Text.ToString();
                cls.sTenTaiKhoanMe = txtTenTKMe.Text.ToString();
                cls.sDienGiaiMe = txtDienGiai.Text.ToString();
                if (frmQuanLyTaiKhoanKeToan.mbTheMoi==true)
                {
                    string ssotkcon = txtSoTKMe.Text.ToString();
                    DataTable dt = cls.SelectAll();
                    dt.DefaultView.RowFilter = "TonTai=True and SoTaiKhoanMe ='" + ssotkcon + "'";
                    DataView dv = dt.DefaultView;
                    DataTable newdt = dv.ToTable();

                    if (newdt.Rows.Count > 0)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã có tài khoản: " + ssotkcon + ". Vui lòng chọn tài khoản khác ");
                        return;
                    }
                    else
                    {
                        cls.Insert();
                        Cursor.Current = Cursors.Default;                    
                        
                    }
                }
                else
                {
                    cls.iID_TaiKhoanKeToanMe = frmQuanLyTaiKhoanKeToan.miID_TaiKhoan;
                    cls.Update();
                }
                Cursor.Current = Cursors.WaitCursor;
                MessageBox.Show("Đã lưu");
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

        private void frmChiTietTaiKhoanKeToan_Load(object sender, EventArgs e)
        {
            if (frmQuanLyTaiKhoanKeToan.mbTheMoi == false)
            {               
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                cls.iID_TaiKhoanKeToanMe = frmQuanLyTaiKhoanKeToan.miID_TaiKhoan;
                DataTable dtcon = cls.SelectOne();
                txtSoTKMe.Text = cls.sSoTaiKhoanMe.Value.ToString();
                txtTenTKMe.Text = cls.sTenTaiKhoanMe.Value.ToString();
                txtDienGiai.Text = cls.sDienGiaiMe.Value.ToString();                
                checkNgungTheoDoi.Checked = cls.bNgungTheoDoi.Value;
            }
        }
    }
}
