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

    public partial class UCThanhPham_DaXuatKho : UserControl
    {

        public static int miID_XuatKho;
     
        private void HienThiGridControl_2(int xxidxuatkhp)
        {

            clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();            
            DataTable dt = cls2.SA_ID_Xuatkho(xxidxuatkhp);           
            gridControl2.DataSource = dt;
        }
        private void Load_Data(DateTime xxtungay, DateTime xxdenngay)
        {
            clsKhoThanhPham_tbXuatKho cls = new CtyTinLuong.clsKhoThanhPham_tbXuatKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);          
            gridControl1.DataSource = dt;            
        }
   

        frmQuanLyKhoThanhPham _frmQLKTP;
        public UCThanhPham_DaXuatKho(frmQuanLyKhoThanhPham frmQLKTP)
        {
            _frmQLKTP = frmQLKTP;
            InitializeComponent();
        }

        private void UCThanhPham_DaXuatKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }
        
        private void btRefresh_Click_2(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCThanhPham_DaXuatKho_Load(sender, e);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    clsKhoThanhPham_tbXuatKho cls1 = new clsKhoThanhPham_tbXuatKho();
                    cls1.iID_XuatKho_ThanhPham = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());


                    cls1.Delete();
                    clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();
                    cls2.iID_XuatKho_ThanhPham = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
                    cls2.Delete_ALL_ID_XuatKho_ThanhPham();
                    Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã xóa");
                }


            }
        }

        private void gridView1_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
                {
                    miID_XuatKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
                    KhoThanhPham_frmChiTiet_Da_XuatKho ff = new KhoThanhPham_frmChiTiet_Da_XuatKho();
                    //_frmQLKTP.Hide();
                    ff.Show();
                    //_frmQLKTP.Show();
                }
            }
            catch
            {

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
