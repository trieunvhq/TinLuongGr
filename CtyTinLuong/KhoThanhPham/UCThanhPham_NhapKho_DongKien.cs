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
    public partial class UCThanhPham_NhapKho_DongKien : UserControl
    {
        public static int miID_NhapKho;
        public static bool mbThemMoi, mbSua, mbCopy;

        private void HienThiGridControl_2(int xxIID_xuatKho)
        {

            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();          
            DataTable dt2 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxIID_xuatKho);
            gridControl2.DataSource = dt2;
        }
        private void Load_Data(DateTime xxtungay, DateTime xxdenngay)
        {

            clsDongKien_TbXuatKho cls = new CtyTinLuong.clsDongKien_TbXuatKho();
            DataTable dt2 = cls.H_DongKien_XK_SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt2;
        }

        public UCThanhPham_NhapKho_DongKien()
        {
            InitializeComponent();
        }

        private void UCThanhPham_NhapKho_DongKien_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCThanhPham_NhapKho_DongKien_Load( sender,  e);
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                miID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                KhoThanhPham_XuatKho_DongKien ff = new KhoThanhPham_XuatKho_DongKien();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            KhoThanhPham_XuatKho_DongKien ff = new KhoThanhPham_XuatKho_DongKien();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
           
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }
    }
}
