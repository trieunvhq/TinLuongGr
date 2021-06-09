using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.FormMain
{
    public partial class FormQuanTri : Form
    {
        public FormQuanTri()
        {
            InitializeComponent();
        }

        private void FormQuanTri_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            //label1.ForeColor = ThemeColor.SecondaryColor;

        }

        private void btnQuanTriTaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan ff = new CtyTinLuong.frmQuanLyTaiKhoan();
            ff.Show();
        }

        private void btnQuanTriNhanSu_Click(object sender, EventArgs e)
        {
            frmNhanSu ff = new frmNhanSu();
            ff.Show();
        }

        private void btnQuanTriKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang ff = new frmKhachHang();
            ff.Show();
        }

        private void btnQuanTriNhaCC_Click(object sender, EventArgs e)
        {
            frmNhaCungCap ff = new frmNhaCungCap();
            ff.Show();
        }

        private void btnQuanTriVTHH_Click(object sender, EventArgs e)
        {
            frmVatTuHangHoa ff = new frmVatTuHangHoa();
            ff.Show();
        }

        private void btnQuanTriDVT_Click(object sender, EventArgs e)
        {
            frmQuanLyDonViTinh ff = new frmQuanLyDonViTinh();
            ff.Show();
        }

        private void btnQuanTriDaiLy_Click(object sender, EventArgs e)
        {
            frmQuanLyDaiLy ff = new frmQuanLyDaiLy();
            ff.Show();
        }

        private void btnQuanTriMaySX_Click(object sender, EventArgs e)
        {
            frmQuanLyMayMoc ff = new CtyTinLuong.frmQuanLyMayMoc();
            ff.Show();
        }

        private void btnMucLuongCongNhat_Click(object sender, EventArgs e)
        {
            frmQuanLyDinhMucLuong ff = new frmQuanLyDinhMucLuong();
            ff.Show();
        }

        private void btnMucLuongSanLuong_Click(object sender, EventArgs e)
        {
            frmQuanLyDinhMucLuongTheoSanLuong ff = new frmQuanLyDinhMucLuongTheoSanLuong();
            ff.Show();
        }

        private void btnHTTKKeToan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoanKeToan ff = new CtyTinLuong.frmQuanLyTaiKhoanKeToan();
            ff.Show();
        }

        private void btnMacDinhNguoiKy_Click(object sender, EventArgs e)
        {
            frmPrint_NguoiKy ff = new frmPrint_NguoiKy();
            ff.Show();
        }
    }
}
