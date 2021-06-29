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
    public partial class UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong : UserControl
    {
        
        public static int miID_NhapKhoDaiLy;
        public static bool mbThemMoi_nhapKhoDaiLy, mbCopy, mbSua;
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
            clsDaiLy_tbChiTietNhapKho_Temp cls2 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho_Temp();
            cls2.iID_NhapKhoDaiLy = xxID_nhapkho;
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();           
            gridControl2.DataSource = dtxxxx;
        }
        
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbNhapKho_Temp cls = new clsDaiLy_tbNhapKho_Temp();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);           
            gridControl1.DataSource = dt;
        }

        KhoNPL_frmNPL _frmKNPL;

        public UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
        }

        private void UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong_Load(object sender, EventArgs e)
        {
            mbThemMoi_nhapKhoDaiLy = mbCopy=mbSua = false;                
           
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString() != "")
            {
                mbCopy = false;
                mbSua = true;
                mbThemMoi_nhapKhoDaiLy = false;
                miID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                NPLChiTietNhapKho_DaiLy_ThemMoi ff = new NPLChiTietNhapKho_DaiLy_ThemMoi();
                _frmKNPL.Hide();
                ff.ShowDialog();
                _frmKNPL.Show();
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong_Load(sender, e);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_nhapKhoDaiLy = true;
            mbSua = false;
            mbCopy = false;
            NPLChiTietNhapKho_DaiLy_ThemMoi ff = new NPLChiTietNhapKho_DaiLy_ThemMoi();
            _frmKNPL.Hide();
            ff.ShowDialog();
            _frmKNPL.Show();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiXuatNhap_Kho_NPL"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                    
                }
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
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

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
          
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho_Temp cls1 = new clsDaiLy_tbNhapKho_Temp();
            cls1.iID_NhapKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
            DataTable dt1 = cls1.SelectOne();
            if (cls1.bTrangThaiXuatNhap_Kho_NPL.Value == true)
            {
                MessageBox.Show("Đã gửi dữ liệu, không thể xoá");
                return;

            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {

                    cls1.iID_NhapKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                    cls1.Delete();
                    clsDaiLy_tbChiTietNhapKho_Temp cls2 = new clsDaiLy_tbChiTietNhapKho_Temp();
                    cls2.iID_NhapKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                    cls2.Delete_W_ID_NhapKhoDaiLy();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    
                }
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString()!="")
            {
                mbCopy = true;
                mbThemMoi_nhapKhoDaiLy = false;
                mbSua = false;
                miID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                NPLChiTietNhapKho_DaiLy_ThemMoi ff = new NPLChiTietNhapKho_DaiLy_ThemMoi();
                ff.Show();
            }
           
        }
    }
}
