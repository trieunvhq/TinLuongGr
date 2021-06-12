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
    public partial class BanHang_SoTongHopbanHang : Form
    {
        public static DateTime mdatungay, mdadenngay;
        public static DataTable mdtPrint;
        public static bool mbPrint_RutGon = false;
        public static bool mbPrint_ALL = false;
       
        private void Hienthigridcontrol2(int xxID_VTHH, DateTime xxtungay, DateTime xxdenngay)
        {
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            
            gridControl2.DataSource= cls.SelectAll_ID_VTHH_NgayThang(xxID_VTHH, xxtungay, xxdenngay);
        }
        public void LoadData( DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            //DataTable dt2 = new DataTable();

            //dt2.Columns.Add("MaVT", typeof(string));
            //dt2.Columns.Add("TenVTHH", typeof(string));
            //dt2.Columns.Add("TenKH", typeof(string));
            //dt2.Columns.Add("MaKH", typeof(string));
            //dt2.Columns.Add("SoLuong_Tong", typeof(double));
         

            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dtxxxx = cls.SelectAll_distinct_ID_VTHH_HUU(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxxxx;

            //int id_vthh_cu_ = 0;

            //for (int k = 0; k < dtxxxx.Rows.Count; k++)
            //{
            //    double SoLuong_Tong = Convert.ToDouble(dtxxxx.Rows[k]["SoLuong_Tong"].ToString());

            //    int id_vthh_ = 0;
            //    if (k < dtxxxx.Rows.Count - 1)
            //    {
            //        id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH"].ToString());

            //        if (dtxxxx.Rows[k]["ID_VTHH"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH"].ToString())
            //        {
            //            DataRow _ravi_1 = dt2.NewRow();
            //            DataRow _ravi_2 = dt2.NewRow();
            //            DataRow _ravi_3 = dt2.NewRow();
            //            _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
            //            _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
            //            _ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
            //            _ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
            //            _ravi_1["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();
            //            dt2.Rows.Add(_ravi_1);

            //            id_vthh_cu_ = id_vthh_;
            //        }
            //        else
            //        {
            //            DataRow _ravi_1 = dt2.NewRow();
            //            DataRow _ravi_2 = dt2.NewRow();
            //            DataRow _ravi_3 = dt2.NewRow();
            //            _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
            //            _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
            //            _ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
            //            _ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
            //            _ravi_1["SoLuong_Tong"] = Convert.ToDouble(dtxxxx.Rows[k]["SoLuong_Tong"].ToString()) + Convert.ToDouble(dtxxxx.Rows[k + 1]["SoLuong_Tong"].ToString());
            //            dt2.Rows.Add(_ravi_1);
            //            _ravi_2["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
            //            _ravi_2["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
            //            _ravi_2["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
            //            _ravi_2["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
            //            _ravi_2["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();
            //            dt2.Rows.Add(_ravi_2);
            //            _ravi_3["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
            //            _ravi_3["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
            //            _ravi_3["TenKH"] = dtxxxx.Rows[k + 1]["TenKH"].ToString();
            //            _ravi_3["MaKH"] = dtxxxx.Rows[k + 1]["MaKH"].ToString();
            //            _ravi_3["SoLuong_Tong"] = dtxxxx.Rows[k + 1]["SoLuong_Tong"].ToString();
            //            dt2.Rows.Add(_ravi_3);
            //            _ravi_3 = dt2.NewRow();
            //            id_vthh_cu_ = id_vthh_;

            //        }
            //    }
            //    else
            //    {
            //        DataRow _ravi_1 = dt2.NewRow();
            //        _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
            //        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
            //        _ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
            //        _ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
            //        _ravi_1["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();

            //        dt2.Rows.Add(_ravi_1);
            //        _ravi_1 = dt2.NewRow();

            //    }
            //}

            //gridControl1.DataSource = dt2;

        }

        public BanHang_SoTongHopbanHang()
        {
            InitializeComponent();
        }
        

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_SoTongHopbanHang_Load( sender,  e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                int iiDI = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                Hienthigridcontrol2(iiDI, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            
        }

        private void btPrint_ALL_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dt1= dv1212.ToTable();
            
            mdtPrint = new DataTable();
            mdtPrint.Columns.Add("MaVT", typeof(string));
            mdtPrint.Columns.Add("TenVTHH", typeof(string));
            mdtPrint.Columns.Add("DonViTinh", typeof(string));
            mdtPrint.Columns.Add("TenKH", typeof(string));
            mdtPrint.Columns.Add("SoLuong", typeof(string));
            mdtPrint.Columns.Add("DonGia", typeof(string));
            mdtPrint.Columns.Add("ThanhTien", typeof(string));
            mdtPrint.Columns.Add("TiGia", typeof(string));
            mdtPrint.Columns.Add("TongTienUSD", typeof(string));
            mdtPrint.Columns.Add("TongTienVND");
            mdtPrint.Columns.Add("QuyDoiVND", typeof(string));
            mdtPrint.Columns.Add("SoChungTu", typeof(string));
            mdtPrint.Columns.Add("NgayChungTu", typeof(string));
            for(int i=0; i<dt1.Rows.Count;i++)
            {
              
                int xxID_VTHH = Convert.ToInt32(dt1.Rows[i]["ID_VTHH"].ToString());
              
                clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
                DataTable dt2= cls.SelectAll_ID_VTHH_NgayThang(xxID_VTHH, dteTuNgay.DateTime, dteDenNgay.DateTime);
                if(dt2.Rows.Count>0)
                {
                    double TongTienUSDxx=Convert.ToDouble(dt2.Compute("sum(ThanhTien)", "ID_VTHH=" + xxID_VTHH + ""));
                    double TongTienVNDxxx = Convert.ToDouble(dt2.Compute("sum(QuyDoiVND)", "ID_VTHH=" + xxID_VTHH + ""));
                    for (int k = 0; k < dt2.Rows.Count;k++)
                    {
                        DataRow _ravi = mdtPrint.NewRow();
                        _ravi["MaVT"] = dt1.Rows[i]["MaVT"].ToString();
                        _ravi["TenVTHH"] = dt1.Rows[i]["TenVTHH"].ToString();
                        _ravi["DonViTinh"] = dt1.Rows[i]["DonViTinh"].ToString();
                        _ravi["TenKH"] = dt2.Rows[k]["TenKH"].ToString();
                        _ravi["SoLuong"] = dt2.Rows[k]["SoLuong"].ToString();
                        _ravi["DonGia"] = dt2.Rows[k]["DonGia"].ToString();
                        _ravi["ThanhTien"] = dt2.Rows[k]["ThanhTien"].ToString();
                        _ravi["TiGia"] = dt2.Rows[k]["TiGia"].ToString();
                        _ravi["TongTienUSD"] = TongTienUSDxx;
                        _ravi["TongTienVND"] = TongTienVNDxxx;
                        _ravi["QuyDoiVND"] = dt2.Rows[k]["QuyDoiVND"].ToString();
                        _ravi["SoChungTu"] = dt2.Rows[k]["SoChungTu"].ToString();
                        _ravi["NgayChungTu"] = dt2.Rows[k]["NgayChungTu"].ToString();
                        mdtPrint.Rows.Add(_ravi);
                    }
                }
               
            }
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_RutGon = false;
                mbPrint_ALL = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                ff.Show();

            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void BanHang_SoTongHopbanHang_Load(object sender, EventArgs e)
        {
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteDenNgay.EditValue = DateTime.Now;
            LoadData( dteTuNgay.DateTime, dteDenNgay.DateTime);

        }
    }
}
