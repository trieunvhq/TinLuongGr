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
    public partial class frmQuanLyTaiKhoanKeToan : Form
    {

        public static bool mbTheMoi;
        public static int miID_TaiKhoan;

        private void Load_DaTa(bool bMe_True_COn_False)
        {
            if(bMe_True_COn_False==true)
            {
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                DataTable dt = cls.SA_new();
                gridControl1.DataSource = dt;
            }
            else
            {
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                DataTable dt = cls.SA();              
                gridControl1.DataSource = dt;
            }
            

        }
        public frmQuanLyTaiKhoanKeToan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoanKeToan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbTheMoi = false;
            checkCon.Checked = true;
            Cursor.Current = Cursors.Default;
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
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                cls.iID_TaiKhoanKeToanCon = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btCHiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                bool bkhoa= Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clKhoa).ToString());
                if (bkhoa == true)
                {
                    MessageBox.Show("Dữ liệu đã khoá, không thể xoá");
                    return;
                }
                else
                {
                    if (checkMe.Checked == true)
                    {
                        clsNganHang_tbHeThongTaiKhoanKeToanMe cls1 = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                        cls1.iID_TaiKhoanKeToanMe = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                        cls1.Delete();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(true);
                    }
                    else
                    {
                        clsNganHang_TaiKhoanKeToanCon cls1 = new clsNganHang_TaiKhoanKeToanCon();
                        cls1.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                        cls1.Delete();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(false);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_TaiKhoan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());             
                mbTheMoi = false;
                if(checkCon.Checked==true)
                {
                    frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
                    ff.Show();
                }
                else
                {
                    frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
                    ff.Show();
                }
               
                Cursor.Current = Cursors.Default;
            }
            catch
            {

            }
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyTaiKhoanKeToan_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

     

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkMe_CheckedChanged(object sender, EventArgs e)
        {
            if(checkMe.Checked==true)
            {
                checkCon.Checked = false;
                Load_DaTa(true);
            }
            
        }

        private void checkCon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCon.Checked == true)
            {
                checkMe.Checked = false;
                Load_DaTa(false);
            }
           
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbTheMoi = true;
            if (checkCon.Checked == true)
            {
                frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
                ff.Show();
            }
            else
            {
                frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
                ff.Show();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
