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
    public partial class frmKhachHang : Form
    {
        public static bool mbThemMoi, mbSua, mbCopy;
        public static int miID_Sua_KH;

        private void HienThi()
        {
            clsTbKhachHang cls = new clsTbKhachHang();
            DataTable dt = cls.SelectAll_W_SoTaiKhoanKeToan();

            if (checked_ALL.Checked == true)
            {
                dt.DefaultView.RowFilter = " TonTai= True";
                DataView dv = dt.DefaultView;
                gridControl1.DataSource = dv;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    dt.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=true";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }

            }
        }
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void checkTheoDoi_EditValueChanged(object sender, EventArgs e)
        {
            if (checkTheoDoi.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void checked_ALL_EditValueChanged(object sender, EventArgs e)
        {
            if (checked_ALL.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checkTheoDoi.Checked = false;
            }
            HienThi();
        }

        private void checkNgungTheoDoi_EditValueChanged(object sender, EventArgs e)
        {
            if (checkNgungTheoDoi.Checked == true)
            {
                checkTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;           
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";           
           
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsTbKhachHang cls = new clsTbKhachHang();
                cls.iID_KhachHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    clsTbKhachHang cls1 = new clsTbKhachHang();
                    cls1.iID_KhachHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID).ToString());
                    cls1.Delete_W_TonTai();
                    MessageBox.Show("Đã xóa");
                    HienThi();
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
            {
                miID_Sua_KH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                frmChiTietKhachHang ff = new frmChiTietKhachHang();
                ff.Show();
            }
            
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            frmChiTietKhachHang ff = new frmChiTietKhachHang();
            ff.Show();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
            {
                miID_Sua_KH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                frmChiTietKhachHang ff = new frmChiTietKhachHang();
                ff.Show();
            }
        }
    }
}
