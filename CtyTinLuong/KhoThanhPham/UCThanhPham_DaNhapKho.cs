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
    public partial class UCThanhPham_DaNhapKho : UserControl
    {
        public static int miiID_NhapKho_ThanhPham;

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
     
        frmQuanLyKhoThanhPham _frmQLKBTP;
        public UCThanhPham_DaNhapKho(frmQuanLyKhoThanhPham frmQLKBTP)
        {
            _frmQLKBTP = frmQLKBTP;
            InitializeComponent();
        }

      

        private void UCThanhPham_DaNhapKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString() != "")
                {
                    miiID_NhapKho_ThanhPham = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString());
                    frmChiTietNhapKhoThanhPham_DaNhapKhoTP ff = new frmChiTietNhapKhoThanhPham_DaNhapKhoTP();
                    //_frmQLKBTP.Hide();
                    ff.Show();
                    //_frmQLKBTP.Show();
                }
            }
            catch
            {

            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCThanhPham_DaNhapKho_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString());
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int xxID_nhapkhothanhpham= Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoThanhPham).ToString());
                    clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
                    cls1.iID_NhapKho_ThanhPham = xxID_nhapkhothanhpham;

                    cls1.Delete();
                    clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
                    cls2.iID_NhapKho_ThanhPham = xxID_nhapkhothanhpham;
                    cls2.Delete_ALL_W_ID_NhapKho_ThanhPham();

                    clsDongKien_ThamChieu_TinhNhapKho cls3 = new clsDongKien_ThamChieu_TinhNhapKho();
                    cls3.Delete_ALL_ID_NhapKhoTP(xxID_nhapkhothanhpham);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã xóa");
                    Load_Data(dteTuNgay.DateTime, dteDenNgay.DateTime);
                }


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
