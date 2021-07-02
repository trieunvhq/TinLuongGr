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
    public partial class frmQuanLyDaiLy : Form
    {
        public static bool mbThemMoi, mbSua, mbCopy;
        public static int miID_Sua_DaiLy;
        private void HienThi()
        {
            clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
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
        public frmQuanLyDaiLy()
        {
            InitializeComponent();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            frmChiTietDaiLy ff = new frmChiTietDaiLy();
            ff.Show();
            Cursor.Current = Cursors.Default;
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

        private void frmQuanLyDaiLy_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            
            HienThi();
            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clKhoa).ToString())==true)
                {
                    MessageBox.Show("Dữ liệu đã khoá không thể xoá");
                    return;
                }
                else
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.OK)
                    {
                        clsTbDanhMuc_DaiLy cls1 = new clsTbDanhMuc_DaiLy();
                        cls1.iID_DaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());
                        cls1.Delete_W_TonTai();
                        MessageBox.Show("Đã xóa");
                        HienThi();
                    }
                }
                
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_Sua_DaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());

                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                frmChiTietDaiLy ff = new frmChiTietDaiLy();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyDaiLy_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btCooy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_Sua_DaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());

                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                frmChiTietDaiLy ff = new frmChiTietDaiLy();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
