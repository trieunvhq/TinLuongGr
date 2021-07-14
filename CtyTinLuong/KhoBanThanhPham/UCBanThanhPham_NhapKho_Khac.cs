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
    public partial class UCBanThanhPham_NhapKho_Khac : UserControl
    {
        public static int miID_NhapKho;
        public static bool mbThemMoi_NhapKho;


  

        frmQuanLyKhoBanThanhPham _frmKBTP;
        public UCBanThanhPham_NhapKho_Khac(frmQuanLyKhoBanThanhPham frmKBTP)
        {
            _frmKBTP = frmKBTP;
            InitializeComponent();
        }
        private void HienThiGridControl_2(int xxxidxuatkho)
        {
            clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
            DataTable dt3 = cls2.SA_ID_NhapKho(xxxidxuatkho);
            gridControl2.DataSource = dt3;
            cls2.Dispose();
            dt3.Dispose();

        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {

            clsKhoBTP_tbNhapKho cls = new CtyTinLuong.clsKhoBTP_tbNhapKho();
            DataTable dt2 = cls.SA_NgayThang_Khac(xxtungay, xxdenngay);
            gridControl1.DataSource = dt2;
            cls.Dispose();
            dt2.Dispose();

        }
        private void UCBanThanhPham_NhapKho_Khac_Load(object sender, EventArgs e)
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
            UCBanThanhPham_NhapKho_Khac_Load(sender, e);
            Cursor.Current = Cursors.Default;
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                mbThemMoi_NhapKho = false;
                miID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                KhoBTP_ChiTiet_NhapKho_Khac ff = new KhoBTP_ChiTiet_NhapKho_Khac();
                //_frmKBTP.Hide();
                ff.Show();
                //_frmKBTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_NhapKho = true;
            KhoBTP_ChiTiet_NhapKho_Khac ff = new KhoBTP_ChiTiet_NhapKho_Khac();
            //_frmKBTP.Hide();
            ff.Show();
            //_frmKBTP.Show();
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();
                    cls1.iID_NhapKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());


                    cls1.Delete();
                    clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
                    cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                    cls2.Delete_ALL_W_ID_NhapKho();
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
