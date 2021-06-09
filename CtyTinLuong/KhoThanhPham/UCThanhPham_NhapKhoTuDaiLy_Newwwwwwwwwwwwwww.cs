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

        private void Load_LockUp()
        {

            clsDaiLy_tbNhapKho clsvattu = new clsDaiLy_tbNhapKho();
            //clsvattu.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            DataTable dtvattu = clsvattu.SelectAll();
            //dtvattu.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False ";
            dtvattu.DefaultView.RowFilter = " HoanThanh = False";
            DataView dvvattu = dtvattu.DefaultView;
            DataTable newdtvattu = dvvattu.ToTable();
            gridMaHang.DataSource = newdtvattu;
            gridMaHang.ValueMember = "ID_NhapKhoDaiLy";
            gridMaHang.DisplayMember = "SoChungTu";


        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {

            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_DaiLy", typeof(int));
            dt2.Columns.Add("ID_XuatKhoDaiLy", typeof(int));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("TongTienHang", typeof(double));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("Chon", typeof(bool));
            dt2.Columns.Add("TrangThaiXuatNhap_ThanhPham_TuDaiLyVe", typeof(bool));
            //TenDaiLy MaVT
            clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
            DataTable dtxx = cls.SelectAll_W_TenDaiLy_W_MaVT();
            dtxx.DefaultView.RowFilter = "TonTai = True and NgungTheoDoi = False";
            DataView dvxxx = dtxx.DefaultView;
            DataTable dt = dvxxx.ToTable();
            if (dtxx.Rows.Count > 0)
            {
               
                dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                DataView dv2 = dt22.DefaultView;
                DataTable dxxxx = dv2.ToTable();
                for (int i = 0; i < dxxxx.Rows.Count; i++)
                {
                    DataRow _ravi3 = dt2.NewRow();
                    _ravi3["ID_DaiLy"] = dxxxx.Rows[i]["ID_DaiLy"].ToString();
                    _ravi3["ID_XuatKhoDaiLy"] = dxxxx.Rows[i]["ID_XuatKhoDaiLy"].ToString();
                    _ravi3["NgayChungTu"] = dxxxx.Rows[i]["NgayChungTu"].ToString();
                    _ravi3["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                    _ravi3["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();
                    _ravi3["SoLuongThanhPhamQuyDoi"] = dxxxx.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString();
                    _ravi3["DonGia"] = dxxxx.Rows[i]["DonGia"].ToString();
                    _ravi3["TongTienHang"] = dxxxx.Rows[i]["TongTienHang"].ToString();
                    _ravi3["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                    _ravi3["TenDaiLy"] = dxxxx.Rows[i]["TenDaiLy"].ToString();
                    _ravi3["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                    _ravi3["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                    _ravi3["Chon"] = false;
                    _ravi3["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"] = dxxxx.Rows[i]["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"].ToString();
                    dt2.Rows.Add(_ravi3);

                }

                gridControl1.DataSource = dt2;


            }

        }
        private void HienThi_ChiTiet_XuatKho( int xxxxmiID_XuatKhoDaiLyxxxxx)
        {
           
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            dt2.Columns.Add("ID_ThamChieu", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(double));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("TiLe", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));

            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            clsDaiLy_ThamChieu_TinhXuatKho cls2 = new clsDaiLy_ThamChieu_TinhXuatKho();
            cls2.iID_XuatKhoDaiLy = xxxxmiID_XuatKhoDaiLyxxxxx;
            DataTable dt222 = cls2.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
            for (int i = 0; i < dt222.Rows.Count; i++)
            {

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_ThamChieu"] = Convert.ToInt32(dt222.Rows[i]["ID_ThamChieu"].ToString());
                _ravi3["ID_NhapKhoDaiLy"] = Convert.ToInt32(dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                _ravi3["ID_VTHH"] = Convert.ToInt32(dt222.Rows[i]["ID_VTHH"].ToString());
                _ravi3["SoChungTu"] = dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString();
                _ravi3["MaVT"] = dt222.Rows[i]["MaVT"].ToString();
                _ravi3["TenVTHH"] = dt222.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dt222.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuongNhap"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuongThanhPhamQuyDoi"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["DonGia"] = Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";
                _ravi3["TiLe"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString()) / Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["ThanhTien"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString()) * Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());

                dt2.Rows.Add(_ravi3);

            }
            gridControl2.DataSource = dt2;
        
        }
        private void HienThi_ALL()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_DaiLy", typeof(int));
            dt2.Columns.Add("ID_XuatKhoDaiLy", typeof(int));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("TongTienHang", typeof(double));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("Chon", typeof(bool));
            dt2.Columns.Add("TrangThaiXuatNhap_ThanhPham_TuDaiLyVe", typeof(bool));
            clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
            DataTable dt = cls.SelectAll();
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = "TonTai = True and NgungTheoDoi = False";
                DataView dv = dt.DefaultView;
                dv.Sort = "TrangThaiXuatNhap_ThanhPham_TuDaiLyVe ASC, NgayChungTu DESC, ID_XuatKhoDaiLy DESC";
                DataTable dxxxx = dv.ToTable();
                for (int i = 0; i < dxxxx.Rows.Count; i++)
                {
                    DataRow _ravi3 = dt2.NewRow();
                    _ravi3["ID_XuatKhoDaiLy"] = dxxxx.Rows[i]["ID_XuatKhoDaiLy"].ToString();
                    int ID_DaiLyxxxx =Convert.ToInt32(dxxxx.Rows[i]["ID_DaiLy"].ToString());
                    clsTbDanhMuc_DaiLy clsdaly = new clsTbDanhMuc_DaiLy();
                    clsdaly.iID_DaiLy = ID_DaiLyxxxx;
                    DataTable dtdaily = clsdaly.SelectOne();
                    _ravi3["ID_DaiLy"] = dxxxx.Rows[i]["ID_DaiLy"].ToString();
                    _ravi3["NgayChungTu"] = dxxxx.Rows[i]["NgayChungTu"].ToString();
                    _ravi3["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                    //_ravi3["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();
                    //_ravi3["SoLuongThanhPhamQuyDoi"] = dxxxx.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString();
                    //_ravi3["DonGia"] = dxxxx.Rows[i]["DonGia"].ToString();
                    //_ravi3["TongTienHang"] = dxxxx.Rows[i]["TongTienHang"].ToString();
                    _ravi3["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                    _ravi3["TenDaiLy"] = clsdaly.sTenDaiLy.Value;
                    //_ravi3["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                    //_ravi3["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                    _ravi3["Chon"] = false;
                    _ravi3["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"] = dxxxx.Rows[i]["TrangThaiXuatNhap_ThanhPham_TuDaiLyVe"].ToString();
                    dt2.Rows.Add(_ravi3);

                }

                //gridControl1.DataSource = dt2;
               
                gridControl1.DataSource = dt2;

            }
        }
        public UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww()
        {
            InitializeComponent();
        }

        private void UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            dteDenNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
           
            mbThemMoi_XuatKhohoDaiLy = mbCopy = mbSua = false;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww_Load(sender, e);
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
                HienThi_ChiTiet_XuatKho(xxxxmiID_XuatKhoDaiLy);
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
            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
            cls1.iID_XuatKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
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
                    cls1.iID_XuatKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                    cls1.Delete();
                    clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                    cls2.iID_XuatKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                    cls2.Delete_ALL_W_ID_XuatKhoDaiLy();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    else HienThi_ALL();
                }
            }

        }

        private void gridControl2_Click_1(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString()!="")
            {
               
                mbThemMoi_XuatKhohoDaiLy = false;
                mbCopy = false;
                mbSua = true;
                miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII();
                ff.Show();
            }
           
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_XuatKhohoDaiLy = true;
            KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII();
            ff.Show();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
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
                KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII();
                ff.Show();
            }
        }
    }
}
