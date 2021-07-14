using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace CtyTinLuong
{
    public partial class UCBanThanhPham_XuatKho_Khac : UserControl
    {

        public static int miID_XuatKho;
        public static bool mbThemMoi_XuatKho;
     
        private void HienThiGridControl_2(int xxxidxuatkho)
        {
           
                clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                DataTable dt3 = cls2.SA_ID_XuatKho(xxxidxuatkho);
                gridControl2.DataSource = dt3;
                cls2.Dispose();
           
        }
        private void Load_DaTa(bool xuatkhokhac, DateTime xxtungay, DateTime xxdenngay)
        {

            if (xuatkhokhac == true)
            {
                clsKhoBTP_tbXuatKho cls = new CtyTinLuong.clsKhoBTP_tbXuatKho();
                DataTable dt2 = cls.SA_NgayThang_XuatKho_Khac(xxtungay, xxdenngay);
                gridControl1.DataSource = dt2;
                cls.Dispose();
                dt2.Dispose();
            }
            else
            {
                clsKhoBTP_tbXuatKho cls = new CtyTinLuong.clsKhoBTP_tbXuatKho();
                DataTable dt2 = cls.SA_NgayThang_XuatKho_Khac(xxtungay, xxdenngay);
                gridControl1.DataSource = dt2;
                cls.Dispose();
                dt2.Dispose();
            }
           


        }
      
        frmQuanLyKhoBanThanhPham _frmKBTP;
        public UCBanThanhPham_XuatKho_Khac(frmQuanLyKhoBanThanhPham frmKBTP)
        {
            _frmKBTP = frmKBTP;
            InitializeComponent();
        }

        private void UCBanThanhPham_XuatKho_Khac_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;         
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            if (frmQuanLyKhoBanThanhPham.mbXuatkhoKhac == false)
                clXoa1.Visible = false;
            else clXoa1.Visible = true;
            Load_DaTa(frmQuanLyKhoBanThanhPham.mbXuatkhoKhac,dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCBanThanhPham_XuatKho_Khac_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_DaTa(frmQuanLyKhoBanThanhPham.mbXuatkhoKhac, dteTuNgay.DateTime, dteDenNgay.DateTime);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                mbThemMoi_XuatKho = false;
                miID_XuatKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                KhoBTP_ChiTiet_XuatKho_Khac ff = new KhoBTP_ChiTiet_XuatKho_Khac();
                //_frmKBTP.Hide();
                ff.Show();
                //_frmKBTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaXuatKho"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_XuatKho = true;
            KhoBTP_ChiTiet_XuatKho_Khac ff = new KhoBTP_ChiTiet_XuatKho_Khac();
            //_frmKBTP.Hide();
            ff.Show();
            //_frmKBTP.Show();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                    cls1.iID_XuatKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());


                    cls1.Delete();
                    clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                    cls2.iID_XuatKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                    cls2.Delete_ALL_W_ID_XuatKhoBTP();
                    MessageBox.Show("Đã xóa");
                    Load_DaTa(frmQuanLyKhoBanThanhPham.mbXuatkhoKhac,dteTuNgay.DateTime, dteDenNgay.DateTime);
                }


            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
