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
    public partial class UCDaiLy_NhapKho_GapDan : UserControl
    {
        public static int miID_NhapKho_GapDan;
       
     
        private void HienThiGridControl_2(bool ischonhakho,int xxidnhapkhogapdan)
        {
            
                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                cls2.iID_NhapKho = xxidnhapkhogapdan;
                DataTable dtxxxx = cls2.SA_W_ID_NhapKho();
                gridControl2.DataSource = dtxxxx;
            
            

        }
        private void Load_DaTa(bool ischonhapkho, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt = new DataTable();
          
              clsGapDan_tbNhapKho cls = new CtyTinLuong.clsGapDan_tbNhapKho();
                dt = cls.SA_NgayThang(xxtungay, xxdenngay);
          
            gridControl1.DataSource = dt;

        }
      
    
        frmQuanLyKhoDaiLy _frmQLKDL;
        public UCDaiLy_NhapKho_GapDan(frmQuanLyKhoDaiLy frmQLKDL)
        {
            _frmQLKDL = frmQLKDL;
            InitializeComponent();
        }

        private void UCDaiLy_NhapKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (frmQuanLyKhoDaiLy.isChoNhapKho_GapDan == true)
                clXoa.Visible = false;
            else clXoa.Visible = true;

            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan, dteTuNgay.DateTime, dteDenNgay.DateTime);
          
            Cursor.Current = Cursors.Default;
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            UCDaiLy_NhapKho_GapDan_Load( sender,  e);

            Cursor.Current = Cursors.Default;

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                //Cursor.Current = Cursors.WaitCursor;
                //miID_NhapKho_GapDan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                //DaiLy_FrmChiTiet_NhapKho_GapDan ff = new DaiLy_FrmChiTiet_NhapKho_GapDan(this);
                ////_frmQLKDL.Hide();
                //ff.Show();
                ////_frmQLKDL.Show();
                //Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThai_NhapKho_GapDan"]));
            //    if (category == false)
            //    {
            //        e.Appearance.BackColor = Color.Bisque;

            //    }
            //}
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
                cls.iID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                Load_DaTa(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan, dteTuNgay.DateTime, dteDenNgay.DateTime);

            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                HienThiGridControl_2(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan,iiIDnhapKhp);
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
                cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                cls1.Delete();
                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                cls2.Delete_ALL_W_ID_NhapKho();
                MessageBox.Show("Đã xóa");
                Load_DaTa(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan, dteTuNgay.DateTime, dteDenNgay.DateTime);

                Cursor.Current = Cursors.Default;
            }
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

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }
        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString());
                Hienthi_Lable_TonKho(xxID);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT233)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
