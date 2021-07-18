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
    public partial class UCThanhPham_NhapKho_Khac : UserControl
    {
        public static int miID_NhapKho;
        public static bool mbThemMoi_NhapKho;
       
        private void HienThiGridControl_2(int xxIID_NhapKho)
        {

            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = xxIID_NhapKho;
            DataTable dt2 = cls2.SA_ID_Nhapkho(xxIID_NhapKho);
          
            gridControl2.DataSource = dt2;
        }
        private void Load_Data(DateTime xxtungay, DateTime xxdenngay)
        {

            clsKhoThanhPham_tbNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbNhapKho();
            DataTable dt2 = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt2;


        }
      

        frmQuanLyKhoThanhPham _frmQLKTP;
        public UCThanhPham_NhapKho_Khac(frmQuanLyKhoThanhPham frmQLKTP)
        {
            _frmQLKTP = frmQLKTP;
            InitializeComponent();
        }

        private void UCThanhPham_NhapKho_Khac_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCThanhPham_NhapKho_Khac_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                mbThemMoi_NhapKho = false;
                miID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                KhoThanhPham_ChiTiet_NhapKho_Khac ff = new KhoThanhPham_ChiTiet_NhapKho_Khac();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaNhapKho"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_NhapKho = true;
            KhoThanhPham_ChiTiet_NhapKho_Khac ff = new KhoThanhPham_ChiTiet_NhapKho_Khac();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
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
    }
}
