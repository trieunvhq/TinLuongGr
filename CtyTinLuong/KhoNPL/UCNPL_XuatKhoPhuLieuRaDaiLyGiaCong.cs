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

            gridControl2.DataSource = dt2;
        }

        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbNhapKho cls = new CtyTinLuong.clsDaiLy_tbNhapKho();
            DataTable dt2 = cls.SelectAll_W_TenDaiLy_W_DinhMuc();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv = dt2.DefaultView;            
            DataTable dt = dv.ToTable();


            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable dt22 = dvxxx.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "TrangThaiXuatNhap_Kho_NPL ASC, NgayChungTu DESC, ID_NhapKhoDaiLy DESC";
            DataTable dxxxx = dv2.ToTable();

            gridControl1.DataSource = dxxxx;

        }
        private void HienThi_ALL()
        {
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt = cls.SelectAll_W_TenDaiLy_W_DinhMuc();
            dt.DefaultView.RowFilter = "NgungTheoDoi=False and TonTai= True";
            DataView dv = dt.DefaultView;
            dv.Sort = "TrangThaiXuatNhap_Kho_NPL ASC, NgayChungTu DESC, ID_NhapKhoDaiLy DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }
      
        public UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong()
        {
            InitializeComponent();
        }

        private void UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong_Load(object sender, EventArgs e)
        {
            mbThemMoi_nhapKhoDaiLy = mbCopy=mbSua = false;
                   
           
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();

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
                ff.Show();
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
            ff.Show();
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
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
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
            
            if(e.Column==clHoanThanh)
            {
                try
                {
                    int iiDI_nhapkho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                    clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                    cls.iID_NhapKhoDaiLy = iiDI_nhapkho;
                    cls.bHoanThanh = Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                    cls.Update_W_HoanThanh();

                }
                catch
                {

                }
              
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
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
