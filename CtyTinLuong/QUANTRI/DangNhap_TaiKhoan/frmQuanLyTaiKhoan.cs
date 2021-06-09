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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public static bool mb_TheMoi_TaiKhoan;
        public static string ms_Ten_TaiKhoan, ms_MatKhau_TaiKhoan;
        public static int miID_DangNhap;
        private void HienThi()
        {
            clsTbDangNhap cls = new clsTbDangNhap();
            DataTable dt = cls.SelectAll();
            if (checked_ALL.Checked == true)
            {
                //dt.DefaultView.RowFilter = "TonTai=True";
                //DataView dv = dt.DefaultView;
                gridControl1.DataSource = dt;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = "NgungTheoDoi=false";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    dt.DefaultView.RowFilter = "NgungTheoDoi=True";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;

                }


            }
        }
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           

            try
            {
                clsTbDangNhap cls = new clsTbDangNhap();
                cls.iID_DangNhap = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DangNhap).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsTbDangNhap cls1 = new clsTbDangNhap();
                cls1.iID_DangNhap = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DangNhap).ToString());
                cls1.Delete_W_TonTai();

                MessageBox.Show("Đã xóa");
                HienThi();
            }
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            HienThi();
        }

        private void checked_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_ALL.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checkTheoDoi.Checked = false;
            }
            HienThi();
        }

        private void checkTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTheoDoi.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void checkNgungTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNgungTheoDoi.Checked == true)
            {
                checkTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_DangNhap).ToString() != "")
                {
                    miID_DangNhap = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DangNhap).ToString());
                    mb_TheMoi_TaiKhoan = false;
                    ms_Ten_TaiKhoan = gridView1.GetFocusedRowCellValue(clTen).ToString();
                    ms_MatKhau_TaiKhoan = gridView1.GetFocusedRowCellValue(clMatKhau).ToString();
                    frmChiTietTaiKhoan ff = new frmChiTietTaiKhoan();
                    ff.Show();

                }
            }
            catch
            {

            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan_Load( sender,  e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mb_TheMoi_TaiKhoan = true;
            frmChiTietTaiKhoan ff = new frmChiTietTaiKhoan();
            ff.Show();
        }
    }
}
