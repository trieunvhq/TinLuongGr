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
    public partial class UCThanhPham_NhapKhoTu_GapDan : UserControl
    {
        public static bool mbThemMoi, mbCopy, mbSua;
        public static int miID_XuatKho;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayChungTu;
        public static string msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy, msSoChungTu;

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_tbXuatKho_Temp cls = new clsGapDan_tbXuatKho_Temp();
            DataTable dtxx = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxx;
        }
        private void HienThiGridControl(int xxxxmiID_XuatKhoDaiLyxxxxx)
        {
            //clsGapDan_ThamChieuTinhXuatKho_Temp cls2 = new clsGapDan_ThamChieuTinhXuatKho_Temp();
            //DataTable dt222 = cls2.SA_W_ID_XuatKhoDaiLy(xxxxmiID_XuatKhoDaiLyxxxxx);
            //gridControl2.DataSource = dt222;
        }
        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
                clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
                int iiID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                cls1.iID_XuatKho = iiID;
                DataTable dt1 = cls1.SelectOne();
                if (cls1.bGuiDuLieu.Value == true)
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
                        cls1.iID_XuatKho = iiID;
                        cls1.Delete();
                        clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();
                        cls2.Delete_ALL_W_ID(iiID);
                        clsGapDan_ThamChieuTinhXuatKho_Temp cls3 = new CtyTinLuong.clsGapDan_ThamChieuTinhXuatKho_Temp();
                        cls3.Delete_ALL_W_ID_XuatKhoDaiLy(iiID);
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                    }
                }
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {

                mbThemMoi = false;
                mbCopy = false;
                mbSua = true;
                miID_XuatKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                KhoThanhPham_NhapKho_TuGapDan ff = new KhoThanhPham_NhapKho_TuGapDan();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            KhoThanhPham_NhapKho_TuGapDan ff = new KhoThanhPham_NhapKho_TuGapDan();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
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

                mbThemMoi = false;
                mbCopy = true;
                mbSua = false;
                miID_XuatKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
                int xxxxmiID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                HienThiGridControl(xxxxmiID_XuatKhoDaiLy);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCThanhPham_NhapKhoTu_GapDan_Load( sender,  e);
        }

   
        public UCThanhPham_NhapKhoTu_GapDan()
        {
            InitializeComponent();
        }

        private void UCThanhPham_NhapKhoTu_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            mbThemMoi = mbCopy = mbSua = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
