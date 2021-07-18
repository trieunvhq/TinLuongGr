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
    public partial class UCDaiLy_XuatKho_GapDan : UserControl
    {
        public static int miID_XuatKho_GapDan;
        public static bool mbthemmoi, mbsua, mbcopy;
     
        private void HienThiGridControl_2(int xxID_xuatkho)
        {

            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
           
            DataTable dt = cls2.SA_ID_XuatKho(xxID_xuatkho);
            gridControl3.DataSource = dt;
            cls2.Dispose();
            dt.Dispose();

        }

        private void Load_DaTa( DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_tbXuatKho cls = new CtyTinLuong.clsGapDan_tbXuatKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
            cls.Dispose();
            dt.Dispose();
        }
       
     

        frmQuanLyKhoDaiLy _frmQLKDL;
        public UCDaiLy_XuatKho_GapDan(frmQuanLyKhoDaiLy frmQLKDL)
        {
            _frmQLKDL = frmQLKDL;
            InitializeComponent();
        }

        public void UCDaiLy_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            

            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa( dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_XuatKho_GapDan_Load( sender,  e);
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
            if(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString()!="")
            {
                Cursor.Current = Cursors.WaitCursor;
                mbthemmoi = false;
                mbsua = true;
                mbcopy = false;
                miID_XuatKho_GapDan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
                DaiLy_FrmChiTiet_XuatKho_GapDan ff = new DaiLy_FrmChiTiet_XuatKho_GapDan(this);
                //_frmQLKDL.Hide();
                ff.Show();
                //_frmQLKDL.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
                HienThiGridControl_2( iiIDnhapKhp);
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
            Cursor.Current = Cursors.WaitCursor;
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                Load_DaTa( dteTuNgay.DateTime, dteDenNgay.DateTime);

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
        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            double soluongxuat, soluongnhap;
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(DateTime.Now);
            string filterExpression = "ID_VTHH=" + xxID_VTHH + "";
            DataRow[] rows_Xuat = dt_XuatTruoc.Select(filterExpression);
            DataRow[] rows_Nhap = dt_NhapTruoc.Select(filterExpression);
            if (rows_Xuat.Length == 0)
                soluongxuat = 0;
            else
                soluongxuat = CheckString.ConvertToDouble_My(rows_Xuat[0]["SoLuong_XuatTruocKy"].ToString());
            if (rows_Nhap.Length == 0)
                soluongnhap = 0;
            else
                soluongnhap = CheckString.ConvertToDouble_My(rows_Nhap[0]["SoLuong_NhapTruocKy"].ToString());
            soluongton = soluongnhap - soluongxuat;

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";

            cls.Dispose();
            dt.Dispose();
            dt_NhapTruoc.Dispose();
            dt_XuatTruoc.Dispose();

        }
        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {

            if (gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString());
                Hienthi_Lable_TonKho(xxID);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
                cls1.Delete();
                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
                cls2.Delete_ALL_W_ID_NhapKho();
                MessageBox.Show("Đã xóa");
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

                Cursor.Current = Cursors.Default;
            }
        }

        private void btThemMoi_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbthemmoi = true;
            mbsua = false;
            mbcopy = false;          
            DaiLy_FrmChiTiet_XuatKho_GapDan ff = new DaiLy_FrmChiTiet_XuatKho_GapDan(this);
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
            Cursor.Current = Cursors.Default;
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
            Cursor.Current = Cursors.WaitCursor;
            mbthemmoi = true;
            mbsua = false;
            mbcopy = false;
            DaiLy_FrmChiTiet_XuatKho_GapDan ff = new DaiLy_FrmChiTiet_XuatKho_GapDan(this);
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
