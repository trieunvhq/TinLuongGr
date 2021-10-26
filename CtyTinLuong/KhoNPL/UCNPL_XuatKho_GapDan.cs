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
    public partial class UCNPL_XuatKho_GapDan : UserControl
    {
        public static int miiID_NhapKhoGapDan;
        public static bool mbThemMoi,mbCopy,mbSua;

        private void HienThiGridControl_2(int xxID_XuatKho)
        {

            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            DataTable dtxxxx = cls2.SA_ID_XuatKho(xxID_XuatKho);
            cls2.Dispose();
            gridControl2.DataSource = dtxxxx;
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {

            clsKhoNPL_tbXuatKho cls = new CtyTinLuong.clsKhoNPL_tbXuatKho();
            DataTable dt2xx = cls.SA_NgayThang_XuatKho_GapDan(xxtungay, xxdenngay);

            gridControl1.DataSource = dt2xx;
            cls.Dispose();

        }
   

        KhoNPL_frmNPL _frmKNPL;
        public UCNPL_XuatKho_GapDan(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
        }

        private void UCNPL_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCNPL_XuatKho_GapDan_Load( sender,  e);
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
                mbCopy = false;
                mbSua = true;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan_Moi ff = new KhoNPL_frmChiTiet_XuatKho_gapDan_Moi();
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

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                mbThemMoi = false;
                mbCopy = true;
                mbSua = false;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan_Moi ff = new KhoNPL_frmChiTiet_XuatKho_gapDan_Moi();
                ff.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                btLayDuLieu.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            //if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            //{
            //    clsGapDan_tbNhapKho_Temp cls2xxxx = new clsGapDan_tbNhapKho_Temp();
            //    int xxid_= Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
            //    cls2xxxx.iID_NhapKho = xxid_;
            //    DataTable dt1 = cls2xxxx.SelectOne();
            //    if (cls2xxxx.bTrangThai_XuatKho_NPL.Value == true)
            //    {
            //        MessageBox.Show("Đã gửi dữ liệu, không thể xoá");
            //        return;

            //    }
            //    else
            //    {
            //        DialogResult traloi;
            //        traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (traloi == DialogResult.Yes)
            //        {
            //            clsGapDan_tbNhapKho_Temp cls1 = new clsGapDan_tbNhapKho_Temp();
            //            cls1.iID_NhapKho = xxid_;
            //            cls1.Delete();
            //            clsGapDan_ChiTiet_NhapKho_Temp cls2 = new clsGapDan_ChiTiet_NhapKho_Temp();                       
            //            cls2.Delete_ALL_W_ID(xxid_);
            //            MessageBox.Show("Đã xóa");
            //            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //        }
            //    }

            //}
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbCopy = false;
            mbSua = false;
            KhoNPL_frmChiTiet_XuatKho_gapDan_Moi ff = new KhoNPL_frmChiTiet_XuatKho_gapDan_Moi();
            //_frmKNPL.Hide();
            ff.Show();
            //_frmKNPL.Show();
        }
    }
}
