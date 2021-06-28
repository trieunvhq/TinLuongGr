using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class DaiLy_BaoCao_TonKho : Form
    {
        public static int miID_VTHHH;
        public static DateTime mdadenngay;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public DaiLy_BaoCao_TonKho()
        {
            InitializeComponent();
        }

        private void HienThi_GridConTrol_2(int xxID_VTHH, DateTime xxdenngaya)
        {
            gridControl2.DataSource = null;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Ton", typeof(double));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("ID_DaiLy", typeof(int));

            DataTable dtnhap = new DataTable();
            DataTable dtXuat = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            dtnhap = cls1.SA_TonKho_W_ID_VTHH(xxID_VTHH,xxdenngaya);
            dtXuat = cls2.SA_TonKho_W_ID_VTHH(xxID_VTHH,xxdenngaya);
            if(dtnhap.Rows.Count>0)
            {
                for (int i = 0; i < dtnhap.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtnhap.Rows[i]["ID_DaiLy"].ToString());
                    double soluongnhap = Convert.ToDouble(dtnhap.Rows[i]["SoLuongNhap"].ToString());
                    double soluongxuat;
                    string expression = "ID_DaiLy='" + iiID_DaiLy + "'";
                    DataRow[] foundRows;
                    foundRows = dtXuat.Select(expression);
                    if (foundRows.Length > 0)
                        soluongxuat = Convert.ToDouble(foundRows[0]["SoLuongXuat"].ToString());
                    else
                        soluongxuat = 0;
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = soluongnhap - soluongxuat;
                    _ravi2["MaDaiLy"] = dtnhap.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtnhap.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            else if (dtXuat.Rows.Count > 0)
            {
                for (int i = 0; i < dtXuat.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtXuat.Rows[i]["ID_DaiLy"].ToString());
                    double soluongxuat = Convert.ToDouble(dtXuat.Rows[i]["SoLuongXuat"].ToString());
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = - soluongxuat;
                    _ravi2["MaDaiLy"] = dtXuat.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtXuat.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            gridControl2.DataSource = dt2;
        }
        private void Load_Lockup()
        {           
            clsDaiLy_tbNhapKho clsxx = new CtyTinLuong.clsDaiLy_tbNhapKho();
            DataTable dtnhapkho = clsxx.SelectAll_DIStintc_LayDanhSachDaiLy_XuatKho();

            DataTable dtxx2 = new DataTable();
            dtxx2.Columns.Add("ID_DaiLy", typeof(int));
            dtxx2.Columns.Add("MaDaiLy", typeof(string));
            dtxx2.Columns.Add("TenDaiLy", typeof(string));
            DataRow _ravi = dtxx2.NewRow();
            _ravi["ID_DaiLy"] = 0;
            _ravi["MaDaiLy"] = "Tất cả";
            dtxx2.Rows.Add(_ravi);
            for (int i = 0; i < dtnhapkho.Rows.Count; i++)
            {
                int ID_DaiLyxx = Convert.ToInt16(dtnhapkho.Rows[i]["ID_DaiLy"].ToString());
                DataRow _ravi2 = dtxx2.NewRow();
                _ravi2["ID_DaiLy"] = ID_DaiLyxx;
                _ravi2["MaDaiLy"] = dtnhapkho.Rows[i]["MaDaiLy"].ToString();
                _ravi2["TenDaiLy"] = dtnhapkho.Rows[i]["TenDaiLy"].ToString();
                dtxx2.Rows.Add(_ravi2);
            }

            gridMaDaiLy.Properties.DataSource = dtxx2;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

        }
        private void LoadDaTa(int xxID_DaiLy, DateTime xxdenngaya)
        {
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            if (xxID_DaiLy == 0)
            {
                dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(xxdenngaya);
                dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(xxdenngaya);
            }

            else
            {
                dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy_W_ID_DaiLy(xxID_DaiLy, xxdenngaya);
                dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy_W_ID_DaiLy(xxID_DaiLy, xxdenngaya);
            }


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));
            for (int i = 0; i < dt_NhapTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTruoc.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_NhapTruocKy, GiaTri_NhapTruocKy, SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;

                SoLuong_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["SoLuong_NhapTruocKy"].ToString());
                GiaTri_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["GiaTri_NhapTruocKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = 0;
                    GiaTri_XuatTruocKy = 0;
                }
                else
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(rows[0]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(rows[0]["GiaTri_XuatTruocKy"].ToString());

                }
                SoLuong_TonDauKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;
                GiaTri_TonDauKy = GiaTri_NhapTruocKy - GiaTri_XuatTruocKy;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["MaVT"] = dt_NhapTruoc.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTruoc.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTruoc.Rows[i]["DonViTinh"].ToString();
                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                dt2.Rows.Add(_ravi);

            }

            for (int i = 0; i < dt_XuatTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTruoc.Rows[i]["ID_VTHH"].ToString());
                double SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["GiaTri_XuatTruocKy"].ToString());
                    SoLuong_TonDauKy = -SoLuong_XuatTruocKy;
                    GiaTri_TonDauKy = -GiaTri_XuatTruocKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["MaVT"] = dt_XuatTruoc.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTruoc.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTruoc.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;
                    dt2.Rows.Add(_ravi);
                }

            }

            gridControl1.DataSource= dt2;
        }
  
        private void DaiLy_BaoCao_TonKho_Load(object sender, EventArgs e)
        {
            Load_Lockup();     
          
            gridMaDaiLy.EditValue = 0;
            dteDenNgay.DateTime = DateTime.Now;
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            if(dteDenNgay.EditValue!=null)
            {
                int kkk = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                LoadDaTa(kkk, dteDenNgay.DateTime);
            }
            int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            if (xiddaily == 0) txtTenDaiLy.Text = "";
            else
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = xiddaily;
                DataTable dt = cls.SelectOne();
                txtTenDaiLy.Text = cls.sTenDaiLy.Value;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                int xxID =Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                HienThi_GridConTrol_2(xxID, dteDenNgay.DateTime);

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (gridMaDaiLy.EditValue != null)
            {
                int kkk = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                LoadDaTa(kkk, dteDenNgay.DateTime);
            }
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_VTHHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                mdadenngay = dteDenNgay.DateTime;
                DaiLy_Frm_TonKho_MotVatTu ff = new DaiLy_Frm_TonKho_MotVatTu();
                //this.Hide();
                ff.ShowDialog();
                //this.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
          
          
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
            if (mdtPrint.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {
                mbPrint = true;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_BaoCao_TonKho ff = new CtyTinLuong.frmPrint_BaoCao_TonKho();
                ff.ShowDialog();
            }
         
        }
    }
}
