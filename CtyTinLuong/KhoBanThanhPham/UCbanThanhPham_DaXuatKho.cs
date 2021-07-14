using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCbanThanhPham_DaXuatKho : UserControl
    {
        public static int miiID_XuatKhoBTP;

        private void HienThiGridControl_2(int xxxidxuatkho)
        {
            clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
            DataTable dt3 = cls2.SA_ID_XuatKho(xxxidxuatkho);
            gridControl2.DataSource = dt3;
            cls2.Dispose();

        }
        private void Load_DaTa( DateTime xxtungay, DateTime xxdenngay)
        {
           
                clsKhoBTP_tbXuatKho cls = new CtyTinLuong.clsKhoBTP_tbXuatKho();
                DataTable dt2 = cls.SA_NgayThang(xxtungay, xxdenngay);
                gridControl1.DataSource = dt2;
                cls.Dispose();
                dt2.Dispose();
          
        }
        frmQuanLyKhoBanThanhPham _frmQLKBTP;
        public UCbanThanhPham_DaXuatKho(frmQuanLyKhoBanThanhPham frmQLKBTP)
        {
            _frmQLKBTP = frmQLKBTP;
            InitializeComponent();
        }

        private void UCbanThanhPham_DaXuatKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCbanThanhPham_DaXuatKho_Load( sender,  e);
            Cursor.Current = Cursors.Default;
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
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
                {
                    miiID_XuatKhoBTP = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                    KhoBTP_ChiTietDaXuatKho ff = new KhoBTP_ChiTietDaXuatKho();
                    //_frmQLKBTP.Hide();
                    ff.Show();
                    //_frmQLKBTP.Show();
                }
            }
            catch
            {

            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
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
                    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
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

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
