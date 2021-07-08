﻿using System;
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

        public static bool mb_TheMoi_TaiKhoan;
        public static int miID_Sua_TaiKhoan_Con, miID_Sua_TaiKhoan_Me;

        private void HienThi()
        {
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dt = cls.SelectAll_HienThiGridcontrol();
            DataView dv = dt.DefaultView;
            gridControl1.DataSource = dv;

        }
        public frmQuanLyTaiKhoanKeToan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoanKeToan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_TaiKhoan = false;
            
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            mb_TheMoi_TaiKhoan = false;
            HienThi();
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
                cls.iID_TaiKhoanKeToanCon = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
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
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    clsNganHang_TaiKhoanKeToanCon cls1 = new clsNganHang_TaiKhoanKeToanCon();
                    cls1.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
                    cls1.Delete_W_TonTai();
                    HienThi();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã xóa");
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_Sua_TaiKhoan_Con = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
                miID_Sua_TaiKhoan_Me = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanMe).ToString());
                mb_TheMoi_TaiKhoan = false;
                frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
            catch
            {

            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyTaiKhoanKeToan_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_TaiKhoan = true;
            frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btThemMoi_Con_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_TaiKhoan = true;
            frmChiTietTaiKhoanKeToanCon ff = new CtyTinLuong.frmChiTietTaiKhoanKeToanCon();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
