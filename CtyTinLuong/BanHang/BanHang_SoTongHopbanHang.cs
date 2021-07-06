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
        public static bool mbPrint_KhachHang = false;
        private void Load_Lockup(DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt = new DataTable();
            clsBanHang_tbBanHang clsxx = new CtyTinLuong.clsBanHang_tbBanHang();
            dt = clsxx.SA_Time_DS_KH(xxtungay, xxdenngay);           
            DataTable dtxx2 = new DataTable();
            dtxx2.Columns.Add("ID_KhachHang", typeof(int));
            dtxx2.Columns.Add("MaKH", typeof(string));
            dtxx2.Columns.Add("TenKH", typeof(string));
            DataRow _ravi = dtxx2.NewRow();
            _ravi["ID_KhachHang"] = 0;
            _ravi["MaKH"] = "Tất cả";
            dtxx2.Rows.Add(_ravi);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ID_KhachHangxxx = Convert.ToInt16(dt.Rows[i]["ID_KhachHang"].ToString());
                DataRow _ravi2 = dtxx2.NewRow();
                _ravi2["ID_KhachHang"] = ID_KhachHangxxx;
                _ravi2["MaKH"] = dt.Rows[i]["MaKH"].ToString();
                _ravi2["TenKH"] = dt.Rows[i]["TenKH"].ToString();
                dtxx2.Rows.Add(_ravi2);
            }

            gridKH.Properties.DataSource = dtxx2;
            gridKH.Properties.ValueMember = "ID_KhachHang";
            gridKH.Properties.DisplayMember = "MaKH";

          
        }
        private void Hienthigridcontrol2(int xxID_VTHH, DateTime xxtungay, DateTime xxdenngay)
        {
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            
            gridControl2.DataSource= cls.SelectAll_ID_VTHH_NgayThang(xxID_VTHH, xxtungay, xxdenngay);
        }
        public void LoadData(int iiIID_KhachHang, DateTime xxtungay, DateTime xxdenngay)
        {
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            gridControl1.DataSource = null;
            DataTable dtxxxx = new DataTable();
            if (iiIID_KhachHang == 0)
                dtxxxx = cls.SelectAll_distinct_ID_VTHH_HUU(xxtungay, xxdenngay);
            else dtxxxx = cls.SA_distinct_ID_VTHH_ID_KhachHang(iiIID_KhachHang, xxtungay, xxdenngay);
            gridControl1.DataSource = dtxxxx;          

        }

        public BanHang_SoTongHopbanHang()
        {
            InitializeComponent();
        }
        

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BanHang_SoTongHopbanHang_Load( sender,  e);
            Cursor.Current = Cursors.Default;
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
            mdtPrint = new DataTable();
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
                mbPrint_KhachHang = false;
                mbPrint_RutGon = false;
                mbPrint_ALL = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                ff.ShowDialog();

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

        private void btPrint_Click(object sender, EventArgs e)
        {
            mdtPrint = new DataTable();
             DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
                      
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_KhachHang = false;
                mbPrint_RutGon = true;
                mbPrint_ALL = false;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                ff.ShowDialog();

            }
            else
            {
                MessageBox.Show("không có dữ liệu");
            }

        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btPrint_ALL.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int kkk = Convert.ToInt32(gridKH.EditValue.ToString());
            LoadData(kkk, dteTuNgay.DateTime, dteDenNgay.DateTime);
            btPrint_ALL.Focus();

            Cursor.Current = Cursors.Default;
        }

        private void gridKH_EditValueChanged(object sender, EventArgs e)
        {
            int kkk = Convert.ToInt32(gridKH.EditValue.ToString());
            LoadData(kkk, dteTuNgay.DateTime, dteDenNgay.DateTime);

          
            if (kkk == 0) txtTenKH.Text = "";
            else
            {
                clsTbKhachHang cls = new clsTbKhachHang();
                cls.iID_KhachHang = kkk;
                DataTable dt = cls.SelectOne();
                txtTenKH.Text = cls.sTenKH.Value;
            }
        }

        private void btPrint_KH_Click(object sender, EventArgs e)
        {

            mbPrint_KhachHang = true;
            mbPrint_RutGon = false;
            mbPrint_ALL = false;
            mdatungay = dteTuNgay.DateTime;
            mdadenngay = dteDenNgay.DateTime;
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt1 = new DataTable();
            int iiIID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
            if (iiIID_KhachHang == 0)
                dt1 = cls.SA_Time_DS_KH(mdatungay, mdadenngay);
            else
            {
               
                DataRow _ravi2 = dt1.NewRow();
                _ravi2["ID_KhachHang"] = iiIID_KhachHang;
                _ravi2["MaKH"] = gridKH.Text.ToString();
                _ravi2["TenKH"] = txtTenKH.Text.ToString();
                dt1.Rows.Add(_ravi2);
            }
            mdtPrint = new DataTable();
            mdtPrint.Columns.Add("MaVT", typeof(string));
            mdtPrint.Columns.Add("TenVTHH", typeof(string));
            mdtPrint.Columns.Add("DonViTinh", typeof(string));
           
            mdtPrint.Columns.Add("SoLuong", typeof(string));     
            mdtPrint.Columns.Add("TongTienUSD", typeof(string));
            mdtPrint.Columns.Add("MaKH", typeof(string));
            mdtPrint.Columns.Add("TenKH", typeof(string));
            for (int i = 0; i < dt1.Rows.Count; i++)
            {

                int xxID_Khachhang_ = Convert.ToInt32(dt1.Rows[i]["ID_KhachHang"].ToString());
                cls = new clsBanHang_tbBanHang();
                DataTable dt2 = cls.SA_distinct_ID_VTHH_ID_KhachHang(xxID_Khachhang_, dteTuNgay.DateTime, dteDenNgay.DateTime);
                if (dt2.Rows.Count > 0)
                {
                    string hienthi = "1";
                    double TongTienUSDxx = Convert.ToDouble(dt2.Compute("sum(ThanhTien)", "HienThi="+ hienthi + ""));
                   
                    for (int k = 0; k < dt2.Rows.Count; k++)
                    {
                        DataRow _ravi = mdtPrint.NewRow();
                        _ravi["MaKH"] = dt1.Rows[i]["MaKH"].ToString();
                        _ravi["TenKH"] = dt1.Rows[i]["TenKH"].ToString();
                        _ravi["MaVT"] = dt2.Rows[k]["MaVT"].ToString();
                        _ravi["TenVTHH"] = dt2.Rows[k]["TenVTHH"].ToString();
                        _ravi["DonViTinh"] = dt2.Rows[k]["DonViTinh"].ToString();                        
                        _ravi["SoLuong"] = dt2.Rows[k]["SoLuong_Tong"].ToString();                   
                        _ravi["TongTienUSD"] = TongTienUSDxx;
                        mdtPrint.Rows.Add(_ravi);
                    }
                }


                if (mdtPrint.Rows.Count > 0)
                {
                    mbPrint_KhachHang = true;
                    mbPrint_RutGon = false;
                    mbPrint_ALL = false;
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;
                    frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                    ff.ShowDialog();

                }

            }



            //else
            //{
            //    MessageBox.Show("không có dữ liệu");
            //}


        }

        private void BanHang_SoTongHopbanHang_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteDenNgay.EditValue = DateTime.Now;
           
            Load_Lockup(dteTuNgay.DateTime, dteDenNgay.DateTime);
            gridKH.EditValue = 0;
            dteTuNgay.Focus();
            Cursor.Current = Cursors.Default;
        }
    }
}
