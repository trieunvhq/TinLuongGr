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
    public partial class UCNPL_XuatKho_Khacccccccccccccc : UserControl
    {
        public static int miiD_XuatKho;
        public static bool mbThemMoi;
        private void HienThiGridControl_2(int xxiID_XuatKho)
        {
            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            cls2.iID_XuatKho = xxiID_XuatKho;
            DataTable dtxxxx = cls2.SA_ID_XuatKho(xxiID_XuatKho);
            gridControl2.DataSource = dtxxxx;
            cls2.Dispose();
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsKhoNPL_tbXuatKho cls = new CtyTinLuong.clsKhoNPL_tbXuatKho();
            DataTable dt2xx = cls.SA_NgayThang_XuatKho_Khac(xxtungay, xxdenngay);

            gridControl1.DataSource = dt2xx;
            cls.Dispose();

        }
        

        KhoNPL_frmNPL _frmKNPL;
        public UCNPL_XuatKho_Khacccccccccccccc(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
        }

        private void UCNPL_XuatKho_Khacccccccccccccc_Load(object sender, EventArgs e)
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
            UCNPL_XuatKho_Khacccccccccccccc_Load( sender,  e);
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                mbThemMoi = false;
                miiD_XuatKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                KhoNPL_ChiTiet_XuatKho_Khac ff = new KhoNPL_ChiTiet_XuatKho_Khac();
                //_frmKNPL.Hide();
                ff.Show();
                //_frmKNPL.Show();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
                    cls1.iID_XuatKhoNPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());


                    cls1.Delete();
                    clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                    cls2.iID_XuatKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                    cls2.Delete_W_ID_XuatKho();
                    MessageBox.Show("Đã xóa");
                    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                }


            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            KhoNPL_ChiTiet_XuatKho_Khac ff = new KhoNPL_ChiTiet_XuatKho_Khac();
            //_frmKNPL.Hide();
            ff.Show();
            //_frmKNPL.Show();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            btLayDuLieu.Focus();
        }
    }
}
