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
using System.Threading;
using DevExpress.XtraWaitForm;

namespace CtyTinLuong
{
    public partial class UC_DaiLy_NhapKho_ChoGhiSo : UserControl
    {
        public static bool mbThemMoi_nhapKhoDaiLy;
        public static int miID_NhapKhoDaiLy;

        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }
        private void HienThiGridControl_2(int xxID_nhapkho)
        {

            DataTable dt2 = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls2 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            cls2.iID_NhapKhoDaiLy = xxID_nhapkho;
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();
            gridControl3.DataSource = dtxxxx;
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dtxx = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxx;

        }
        frmQuanLyKhoDaiLy _frmQLKDL;
        public UC_DaiLy_NhapKho_ChoGhiSo(frmQuanLyKhoDaiLy frmQLKDL)
        {
            _frmQLKDL = frmQLKDL;
            InitializeComponent();
            
        }

        private void UC_DaiLy_NhapKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();            
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-60);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime); 
            
            mbThemMoi_nhapKhoDaiLy = false;
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
            Cursor.Current = Cursors.WaitCursor;
            mbThemMoi_nhapKhoDaiLy = false;
            miID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
            DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww ff = new DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww();
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
        }


        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_DaiLy_NhapKho_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                cls.iID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiXuatNhap_KhoDaiLy"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                   
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();


            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {

                cls1.iID_NhapKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                cls1.Delete();
                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                cls2.iID_NhapKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                cls2.Delete_W_ID_NhapKhoDaiLy();
                MessageBox.Show("Đã xóa");
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }

        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
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
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }
    }
}
