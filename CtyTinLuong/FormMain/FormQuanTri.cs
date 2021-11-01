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
            Cursor.Current = Cursors.WaitCursor;

            frmQuanLyTaiKhoan ff = new CtyTinLuong.frmQuanLyTaiKhoan();
            ff.Show();

            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriNhanSu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmNhanSu ff = new frmNhanSu();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriKhachHang_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmKhachHang ff = new frmKhachHang();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriNhaCC_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmNhaCungCap ff = new frmNhaCungCap();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriVTHH_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmVatTuHangHoa ff = new frmVatTuHangHoa();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriDVT_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //frmQuanLyDonViTinh ff = new frmQuanLyDonViTinh();
            //ff.Show();
            Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_(DateTime.Now.Month, DateTime.Now.Year);
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriDaiLy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyDaiLy ff = new frmQuanLyDaiLy();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnQuanTriMaySX_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyMayMoc ff = new CtyTinLuong.frmQuanLyMayMoc();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnMucLuongCongNhat_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnMucLuongSanLuong_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyDinhMucLuongTheoSanLuong ff = new frmQuanLyDinhMucLuongTheoSanLuong();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnHTTKKeToan_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyTaiKhoanKeToan ff = new CtyTinLuong.frmQuanLyTaiKhoanKeToan();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btnMacDinhNguoiKy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyTaiKhoan.mb_TheMoi_TaiKhoan = true;
            frmPrint_NguoiKy ff = new frmPrint_NguoiKy();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
