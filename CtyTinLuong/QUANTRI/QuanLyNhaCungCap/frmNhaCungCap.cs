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
    public partial class frmNhaCungCap : Form
    {
       
        public static int miID_Sua_NCC;
        public static bool mbThemMoi, mbSua, mbCopy;
        private void HienThi()
        {
            clsTbNhaCungCap cls = new clsTbNhaCungCap();
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
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
          
            HienThi();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsTbNhaCungCap cls = new clsTbNhaCungCap();
                cls.iID_NhaCungCap = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
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
                    clsTbNhaCungCap cls1 = new clsTbNhaCungCap();
                    cls1.iID_NhaCungCap = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID).ToString());
                    cls1.Delete_W_TonTai();
                    MessageBox.Show("Đã xóa");
                    HienThi();
                }
            }
            catch
            {

            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            frmChiTietNhaCungCap ff = new frmChiTietNhaCungCap();
            ff.Show();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
            {
                miID_Sua_NCC = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                frmChiTietNhaCungCap ff = new frmChiTietNhaCungCap();
                ff.Show();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID).ToString() != "")
            {
                miID_Sua_NCC = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID).ToString());
                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                frmChiTietNhaCungCap ff = new frmChiTietNhaCungCap();
                ff.Show();
            }
               
           
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);
        }

       
    }
}
