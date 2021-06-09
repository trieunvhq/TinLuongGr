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
    public partial class UC_DaiLy_NhapKho_ChoGhiSo : UserControl
    {
        public static bool mbThemMoi_nhapKhoDaiLy;
        public static int miID_NhapKhoDaiLy;

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
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("GhiChu", typeof(string));
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();

            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                DataRow _ravi = dt2.NewRow();
                int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["ID_VTHH"] = iiDI_Vthh;
                cls.iID_VTHH = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                DataTable dtVT_vao = cls.SelectOne();
                _ravi["MaVT"] = iiDI_Vthh;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["SoLuong"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }

            gridControl3.DataSource = dt2;
        }

        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {

            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dtxx = cls.SelectAll_W_TenDaiLy_W_DinhMuc();
            dtxx.DefaultView.RowFilter = "TrangThaiXuatNhap_Kho_NPL = True";
            DataView dvxxx = dtxx.DefaultView;
            DataTable dt = dvxxx.ToTable();
            if (dtxx.Rows.Count > 0)
            {
             
                dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = "TrangThaiXuatNhap_KhoDaiLy ASC, NgayChungTu DESC, ID_NhapKhoDaiLy DESC";
                DataTable dxxxx = dv2.ToTable();
                gridControl1.DataSource = dxxxx;

            }
            
        }
        private void HienThi_ALL()
        {
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt = cls.SelectAll_W_TenDaiLy_W_DinhMuc();            
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = "TrangThaiXuatNhap_Kho_NPL = True";
                DataView dv = dt.DefaultView;
                dv.Sort = "TrangThaiXuatNhap_KhoDaiLy ASC, NgayChungTu DESC, ID_NhapKhoDaiLy DESC";
                DataTable dxxxx = dv.ToTable();
                gridControl1.DataSource = dxxxx;
            }
        }

        public UC_DaiLy_NhapKho_ChoGhiSo()
        {
            InitializeComponent();
        }

        private void UC_DaiLy_NhapKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();            
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
            
            mbThemMoi_nhapKhoDaiLy = false;
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
            mbThemMoi_nhapKhoDaiLy = false;
            miID_NhapKhoDaiLy= Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
            DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww ff = new DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww();
            ff.Show();
        }

 

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_DaiLy_NhapKho_Load(sender, e);
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
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
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
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
                else HienThi_ALL();
            }

        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
