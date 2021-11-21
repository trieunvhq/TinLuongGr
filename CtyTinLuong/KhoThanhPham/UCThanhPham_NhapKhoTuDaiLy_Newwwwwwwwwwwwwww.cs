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
using DevExpress.Data.Filtering;

namespace CtyTinLuong
{
    public partial class UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww : UserControl
    {
        public static bool mbThemMoi_XuatKhohoDaiLy, mbCopy, mbSua;
        public static int miID_XuatKhoDaiLy;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayChungTu;
        public static string msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy, msSoChungTu;

     
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbXuatKho_Temp cls = new clsDaiLy_tbXuatKho_Temp();
            DataTable dtxx = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxx;
        }
        private void HienThiGridControl( int xxxxmiID_XuatKhoDaiLyxxxxx)
        {
            clsDaiLy_ThamChieu_TinhXuatKho_Temp cls2 = new clsDaiLy_ThamChieu_TinhXuatKho_Temp();           
            DataTable dt222 = cls2.SA_W_ID_XuatKhoDaiLy(xxxxmiID_XuatKhoDaiLyxxxxx);           
            gridControl2.DataSource = dt222;        
        }
       

        frmQuanLyKhoThanhPham _frmQLKTP;
        public UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww(frmQuanLyKhoThanhPham frmQLKTP)
        {
            _frmQLKTP = frmQLKTP;
            InitializeComponent();
        }

        private void UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);           
            mbThemMoi_XuatKhohoDaiLy = mbCopy = mbSua = false;
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
              int  xxxxmiID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                HienThiGridControl(xxxxmiID_XuatKhoDaiLy);
            }
        }

      

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView4_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString()!="")
            {
                clsDaiLy_tbXuatKho_Temp cls1 = new clsDaiLy_tbXuatKho_Temp();
                int iiID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                cls1.iID_XuatKhoDaiLy = iiID;
                DataTable dt1 = cls1.SelectOne();
                if (cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe.Value == true)
                {
                    MessageBox.Show("Đã nhập kho, không thể xoá");
                    return;
                }
                else
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        cls1.iID_XuatKhoDaiLy = iiID;
                        cls1.Delete();
                        clsDaiLy_tbChiTietXuatKho_Temp cls2 = new clsDaiLy_tbChiTietXuatKho_Temp();                       
                        cls2.Delete_ALL_W_ID_XuatKhoDaiLy(iiID);
                        clsDaiLy_ThamChieu_TinhXuatKho_Temp cls3 = new CtyTinLuong.clsDaiLy_ThamChieu_TinhXuatKho_Temp();
                        cls3.Delete_ALL_W_ID_XuatKhoDaiLy(iiID);
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                    }
                }
            }
           

        }

        private void gridControl2_Click_1(object sender, EventArgs e)
        {

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

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString()!="")
            {
               
                mbThemMoi_XuatKhohoDaiLy = false;
                mbCopy = false;
                mbSua = true;
                miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII(this);
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
           
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_XuatKhohoDaiLy = true;
            KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII(this);
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
        }

        public void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();           
            dttttt2.DefaultView.RowFilter = "Chon = True";
            DataView dv = dttttt2.DefaultView;
            mdtPrint = dv.ToTable();
            if(mdtPrint.Rows.Count>0)
            {
                int IID_DaiLy = Convert.ToInt32(mdtPrint.Rows[0]["ID_DaiLy"].ToString());
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = IID_DaiLy;
                DataTable dxckksd = cls.SelectOne();
                msDiaChi = cls.sDiaChi.Value;
                msSoDienThoai = cls.sSoDienThoai.Value;
                msTenDaiLy = cls.sTenDaiLy.Value;
                msDienGiai = mdtPrint.Rows[0]["DienGiai"].ToString();
                msSoChungTu = mdtPrint.Rows[0]["SoChungTu"].ToString();
                mdaNgayChungTu = Convert.ToDateTime(mdtPrint.Rows[0]["NgayChungTu"].ToString());
                //msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy;
                mbPrint = true;
                frmPrint_XuatKho_Nhieu_DaiLy ff = new frmPrint_XuatKho_Nhieu_DaiLy();
                ff.Show();
            }

            
            
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                    
                }
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {

                mbThemMoi_XuatKhohoDaiLy = false;
                mbCopy = true;
                mbSua = false;
                miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII(this);
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }
    }
}
