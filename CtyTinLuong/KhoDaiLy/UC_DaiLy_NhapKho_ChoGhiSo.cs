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

        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
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
        private bool isLoad = false;
        private void UC_DaiLy_NhapKho_Load(object sender, EventArgs e)
        {
            isLoad = true;
            Load_LockUp();            
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-60); 
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

            mbThemMoi_nhapKhoDaiLy = false;

            isLoad = false;
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
            DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww ff = new DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww(this);
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
        }


        public void btRefresh_Click(object sender, EventArgs e)
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
                btLayDuLieu_Click(null, null);
            }
        }
          
        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString());
                Hienthi_Lable_TonKho(xxID);
            }
        }

        private void cbNgay_DateTimeChanged(object sender, EventArgs e)
        {
            btLayDuLieu_Click(null, null);
        }

        private void cbNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoad)
                return;
            if (dteDenNgay.DateTime>=dteTuNgay.DateTime)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            else
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày", "Khoảng thời gian không hợp lệ!", MessageBoxButtons.OK);
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoad)
                return;
            if (dteDenNgay.DateTime >= dteTuNgay.DateTime)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            else
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày", "Khoảng thời gian không hợp lệ!", MessageBoxButtons.OK);
            }
        }
    }
}
