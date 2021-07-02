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
    public partial class frmQuanLyMayMoc : Form
    {
        public static bool mb_TheMoi_MayMoc;
        public static int miID_Sua_MayMoc;
        private void HienThi()
        {
            clsT_MayMoc cls = new clsT_MayMoc();
            DataTable dt = cls.SelectAll();

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
        public frmQuanLyMayMoc()
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

        private void frmQuanLyMayMoc_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            mb_TheMoi_MayMoc = false;
            HienThi();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsT_MayMoc cls = new clsT_MayMoc();
                cls.iId = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clid).ToString());
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
                    clsT_MayMoc cls1 = new clsT_MayMoc();
                    cls1.iId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clid).ToString());
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_Sua_MayMoc = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clid).ToString());
                mb_TheMoi_MayMoc = false;
                frmChiTietMayMoc ff = new frmChiTietMayMoc();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
            catch
            {

            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_MayMoc = true;
            frmChiTietMayMoc ff = new CtyTinLuong.frmChiTietMayMoc();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
