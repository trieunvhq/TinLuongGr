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
    public partial class SanLuong_To_DOT_DAP : Form
    {
        public static DataTable mdtPrint;
        public static bool mbPrint_ALL, mbPrint_RutGon;

        public static DateTime mdatungay, mdadenngay;
        public static int miID_VTHH_Ra;
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public void LoadData(DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
           
            DataTable dt2 = new DataTable();
            dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH_Ra", typeof(string));
            dt2.Columns.Add("MaVT_Ra", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));

            dt2.Columns.Add("TongSoBao_Sot", typeof(double));
            dt2.Columns.Add("TongSoKg", typeof(double));
            dt2.Columns.Add("TongSoThanh", typeof(double));
        

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();

            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();


            DataTable dtID_VTHH_Ra = cls.SelectAll_distinct_W_ID_VTHH_Ra();
            if (dtID_VTHH_Ra.Rows.Count > 0)
            {
                for (int i = 0; i < dtID_VTHH_Ra.Rows.Count; i++)
                {
                    int ID_VTHH_Raxx = Convert.ToInt32(dtID_VTHH_Ra.Rows[i]["ID_VTHH_Ra"].ToString());
                    cls.iID_VTHH_Ra = ID_VTHH_Raxx;
                    DataTable dtxxxx = new DataTable();                    
                    dtxxxx = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_DOT(ID_VTHH_Raxx, xxtungay, xxdenngay);
                    if (dtxxxx.Rows.Count > 0)
                    {
                        if (Convert.ToDouble(dtxxxx.Rows[0]["TongSoBao_Sot"].ToString()) > 0)
                        {
                            DataRow _ravi = dt2.NewRow();
                            clsvt.iID_VTHH = ID_VTHH_Raxx;
                            DataTable dtvt_Ra = clsvt.SelectOne();
                            string MaVT_Ra = clsvt.sMaVT.Value;
                            string DonViTinh_Ra = clsvt.sDonViTinh.Value;
                            string TenVatTu_Ra = clsvt.sTenVTHH.Value;

                            _ravi["ID_VTHH_Ra"] = ID_VTHH_Raxx;
                            _ravi["MaVT_Ra"] = MaVT_Ra;
                            _ravi["DonViTinh_Ra"] = DonViTinh_Ra;
                            _ravi["TenVatTu_Ra"] = TenVatTu_Ra;
                            _ravi["TongSoBao_Sot"] = Convert.ToDouble(dtxxxx.Rows[0]["TongSoBao_Sot"].ToString());
                            _ravi["TongSoKg"] = Convert.ToDouble(dtxxxx.Rows[0]["TongSoKg"].ToString());
                            _ravi["TongSoThanh"] = Convert.ToDouble(dtxxxx.Rows[0]["TongSoThanh"].ToString());
                            
                            dt2.Rows.Add(_ravi);
                        }

                    }

                }
                gridControl1.DataSource = dt2;
            }

           
        }
        public SanLuong_To_DOT_DAP()
        {
            InitializeComponent();
        }

        private void SanLuong_To_DOT_DAP_Load(object sender, EventArgs e)
        {
            clTongSoBao_Sot.Caption = "Số KG/\nBao_Sọt";
            clTongSoKg.Caption = "Tổng số\nKg";
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));

            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = GetFistDayInMonth(nam, thang);

            LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);

           
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_RutGon = true;
                mbPrint_ALL = false;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                ff.Show();

            }
        }

        private void btprint2_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();

            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_RutGon = false;
                mbPrint_ALL = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                ff.Show();

            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.GetFocusedRowCellValue(clID_VTHH_Ra).ToString() != "")
            {
                miID_VTHH_Ra = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_VTHH_Ra).ToString());
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                SanLuong_ChiTiet_SanLuong_Dot_Dap ff = new SanLuong_ChiTiet_SanLuong_Dot_Dap();
                ff.Show();

            }
        }
    }
}
