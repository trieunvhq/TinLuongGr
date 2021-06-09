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
    public partial class frmBaoCaoSanLuong_Theo_CongNhan : Form
    {
        public static DataTable mdtPrint;
        public static bool mbPrint_ALL, mbPrint_RutGon;

        public static DateTime mdatungay, mdadenngay;
        public static int miID_CongNhan;

       
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public void HienThiGridcontrol2( int iiID_CongNhan,DateTime xxtungay, DateTime xxdenngay)
        {

            grid_ChiTiet.DataSource = null;
            
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();            

            DataTable dtxxxx = new DataTable();
            dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan_HUU(iiID_CongNhan, xxtungay, xxdenngay);
          
            grid_ChiTiet.DataSource = dtxxxx;

        }

        public void LoadData(DateTime xxtungay, DateTime xxdenngay)
        {

            grid_ChiTiet.DataSource = null;

            DataTable dt2 = new DataTable();
            dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(string));
            dt2.Columns.Add("ID_CongNhan", typeof(string));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("ID_DinhMuc_Luong", typeof(string));
            dt2.Columns.Add("SanLuong_Thuong", typeof(string));
            dt2.Columns.Add("SanLuong_TangCa", typeof(string));
            dt2.Columns.Add("DinhMuc_KhongTang", typeof(double));
            dt2.Columns.Add("DinhMuc_Tang", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));



            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            clsNhanSu_tbNhanSu clsnhansu = new clsNhanSu_tbNhanSu();
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dtxxxx = cls.SelectAll_distinct_W_ID_CongNhan_new(xxtungay, xxdenngay);
            DataRow _ravi_1 = dt2.NewRow();
            int id_congNhan_Cu_ = 0;
            for (int k = 0; k < dtxxxx.Rows.Count; k++)
            {
                double deTOngtien = 0;
                int xxxID_CongNhan_ = Convert.ToInt32(dtxxxx.Rows[k]["ID_CongNhan"].ToString());
                deTOngtien = Convert.ToDouble(dtxxxx.Compute("sum(ThanhTien)", "ID_CongNhan=" + xxxID_CongNhan_ + ""));
              
                int ID_CongNhan_ = 0;
               
                if (k < dtxxxx.Rows.Count - 1)
                {
                    ID_CongNhan_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_CongNhan"].ToString());                    
                   
                    if (dtxxxx.Rows[k]["ID_CongNhan"].ToString() != dtxxxx.Rows[k + 1]["ID_CongNhan"].ToString())
                    {
                        _ravi_1["ID_CongNhan"] = xxxID_CongNhan_;
                        _ravi_1["TenNhanVien"] = dtxxxx.Rows[k]["TenNhanVien"].ToString();
                        _ravi_1["ThanhTien"] = deTOngtien;
                        dt2.Rows.Add(_ravi_1);                     

                        _ravi_1 = dt2.NewRow();

                        id_congNhan_Cu_ = ID_CongNhan_;
                    }
                    else
                    { }
                }
                else
                {
                    _ravi_1["ID_CongNhan"] = xxxID_CongNhan_;
                    _ravi_1["TenNhanVien"] = dtxxxx.Rows[k]["TenNhanVien"].ToString();
                    _ravi_1["ThanhTien"] = deTOngtien;
                  
                    dt2.Rows.Add(_ravi_1);
                  
                    _ravi_1 = dt2.NewRow();
                  
                }

            }


          

            grid_TongLuong.DataSource = dt2;

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                
                LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
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

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)grid_ChiTiet.DataSource;
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

        private void btprint_ALL_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)grid_ChiTiet.DataSource;
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

        private void btRefesh_Click(object sender, EventArgs e)
        {
            frmBaoCaoSanLuong_Theo_CongNhan_Load( sender,  e);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int iiDcongnhan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
            HienThiGridcontrol2(iiDcongnhan, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString() != "")
            {
                miID_CongNhan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                SanLuong_ChiTiet_Luong ff = new SanLuong_ChiTiet_Luong();
                ff.Show();

            }
        }

        public frmBaoCaoSanLuong_Theo_CongNhan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoSanLuong_Theo_CongNhan_Load(object sender, EventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));

            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = GetFistDayInMonth(nam, thang);
            
            LoadData( dteTuNgay.DateTime, dteDenNgay.DateTime);
            gridView2.ExpandAllGroups();
        }

      
    }
}
