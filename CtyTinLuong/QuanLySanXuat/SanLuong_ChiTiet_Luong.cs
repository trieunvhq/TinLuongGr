using DevExpress.XtraGrid.Columns;
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
    public partial class SanLuong_ChiTiet_Luong : Form
    {
        private List<GridColumn> ds_grid = new List<GridColumn>();
        DateTime ngaydauthang, ngaycuoithang;
        private void Load_LockUp()
        {

            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataTable dt = cls.SelectAll_distinct_ID_CongNhan_W_NgayThang(ngaydauthang, ngaycuoithang);
          

            gridCongNhan.Properties.DataSource = dt;
            gridCongNhan.Properties.ValueMember = "ID_CongNhan";
            gridCongNhan.Properties.DisplayMember = "MaNhanVien";

          
        }
        private string LayThu(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                case DayOfWeek.Sunday:
                    return "CN";
            }
            return "";
        }

        DataTable dt2;

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
        public void LoadData(int xxID_CongNhan)
        {
                DateTime date_ = new DateTime(ngaydauthang.Year, ngaydauthang.Month, 1);
                int ngaycuathang_ = (((new DateTime(ngaydauthang.Year, ngaydauthang.Month, 1)).AddMonths(1)).AddDays(-1)).Day;
                if (ngaycuathang_ == 28)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = false;
                }
                else if (ngaycuathang_ == 29)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 30)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 31)
                {
                    Ngay31.Visible = true;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                string thu_ = LayThu(date_);
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    ds_grid[i].Caption = (i + 1) + "\n" + LayThu(new DateTime(ngaydauthang.Year, ngaydauthang.Month, (i + 1)));
                    if (ds_grid[i].Caption.Contains("CN"))
                    {
                        ds_grid[i].AppearanceCell.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.ForeColor = Color.Red;
                        ds_grid[i].AppearanceCell.ForeColor = Color.Red;
                    }
                }

             dt2 = new DataTable();

           
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("NoiDung", typeof(string));

            dt2.Columns.Add("Ngay1", typeof(string));
            dt2.Columns.Add("Ngay2", typeof(string));
            dt2.Columns.Add("Ngay3", typeof(string));
            dt2.Columns.Add("Ngay4", typeof(string));
            dt2.Columns.Add("Ngay5", typeof(string));
            dt2.Columns.Add("Ngay6", typeof(string));
            dt2.Columns.Add("Ngay7", typeof(string));
            dt2.Columns.Add("Ngay8", typeof(string));
            dt2.Columns.Add("Ngay9", typeof(string));
            dt2.Columns.Add("Ngay10", typeof(string));
            dt2.Columns.Add("Ngay11", typeof(string));
            dt2.Columns.Add("Ngay12", typeof(string));
            dt2.Columns.Add("Ngay13", typeof(string));
            dt2.Columns.Add("Ngay14", typeof(string));
            dt2.Columns.Add("Ngay15", typeof(string));
            dt2.Columns.Add("Ngay16", typeof(string));
            dt2.Columns.Add("Ngay17", typeof(string));
            dt2.Columns.Add("Ngay18", typeof(string));
            dt2.Columns.Add("Ngay19", typeof(string));
            dt2.Columns.Add("Ngay20", typeof(string));

            dt2.Columns.Add("Ngay21", typeof(string));
            dt2.Columns.Add("Ngay22", typeof(string));
            dt2.Columns.Add("Ngay23", typeof(string));
            dt2.Columns.Add("Ngay24", typeof(string));
            dt2.Columns.Add("Ngay25", typeof(string));
            dt2.Columns.Add("Ngay26", typeof(string));
            dt2.Columns.Add("Ngay27", typeof(string));
            dt2.Columns.Add("Ngay28", typeof(string));
            dt2.Columns.Add("Ngay29", typeof(string));
            dt2.Columns.Add("Ngay30", typeof(string));

            dt2.Columns.Add("Ngay31", typeof(string));

            dt2.Columns.Add("Tong", typeof(string));

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataTable dtxxxx = new DataTable();
            dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan(xxID_CongNhan, ngaydauthang, ngaycuoithang);
            int days = DateTime.DaysInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));

            DataRow _ravi_1 = dt2.NewRow();
            DataRow _ravi_2 = dt2.NewRow();
           
            int id_vthh_cu_ = 0;
            double tong1 = 0, tong2 = 0;
            for (int k = 0; k < dtxxxx.Rows.Count; k++)
            {
                double snluong_thuong = Convert.ToDouble(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                double snluong_tangca = Convert.ToDouble(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());
                //int xxid_vthh= Convert.ToInt32(dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString());
                //tong1 = Convert.ToDouble(dtxxxx.Compute("sum(SanLuong_Thuong)", "ID_VTHH_Ra=" + xxid_vthh + ""));
           
                int ngay_ = (Convert.ToDateTime(dtxxxx.Rows[k]["NgaySanXuat"].ToString()).Day);
                _ravi_1["Ngay" + (ngay_)] = snluong_thuong.ToString();
                _ravi_2["Ngay" + (ngay_)] = snluong_tangca.ToString();
                tong1 += snluong_thuong;
                tong2 += snluong_tangca;
                _ravi_1["Tong"]  = tong1.ToString();
                _ravi_2["Tong"] = tong2;
                //
                int id_vthh_ = 0;
                if (k < dtxxxx.Rows.Count - 1)
                {
                    id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k+1]["ID_VTHH_Ra"].ToString());

                    if (dtxxxx.Rows[k ]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                    { 
                        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["NoiDung"] = "Thường";
                        
                        _ravi_2["TenVTHH"] = "";
                        _ravi_2["NoiDung"] = "Tăng ca";
                      

                        dt2.Rows.Add(_ravi_1);
                        dt2.Rows.Add(_ravi_2);
                        tong1 = 0;
                        tong2 = 0;
                        _ravi_1 = dt2.NewRow();
                        _ravi_2 = dt2.NewRow();
                        id_vthh_cu_ = id_vthh_;
                    }
                    else
                    { }
                }
                else
                {
                    _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                    _ravi_1["NoiDung"] = "Thường";

                    _ravi_2["TenVTHH"] = "";
                    _ravi_2["NoiDung"] = "Tăng ca";
                  

                    dt2.Rows.Add(_ravi_1);
                    dt2.Rows.Add(_ravi_2);

                    tong1 = 0;
                    tong2 = 0;
                    _ravi_1 = dt2.NewRow();
                    _ravi_2 = dt2.NewRow();
                }                 
            } 
         
            gridControl2.DataSource = dt2;
            
        }

        public void HienThiGridcontrol2(int iiID_CongNhan)
        {

            gridControl1.DataSource = null;

            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

            DataTable dtxxxx = new DataTable();
            dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan_HUU(iiID_CongNhan, ngaydauthang, ngaycuoithang);

            gridControl1.DataSource = dtxxxx;

        }

        public SanLuong_ChiTiet_Luong()
        {
            InitializeComponent();
            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridCongNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();

                txtHoTen.Text = clsncc.sTenNhanVien.Value;
                int xxID = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                LoadData(xxID);

            }
            catch
            {

            }
        }

        private void SanLuong_ChiTiet_Luong_Load(object sender, EventArgs e)
        {
            
            DateTime dtnow = DateTime.Now;
            txtNam.Text = frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Year.ToString();
            txtThang.Text = frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Month.ToString();
            ngaydauthang = GetFistDayInMonth(frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Year, frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Month);
            ngaycuoithang=GetLastDayInMonth(frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Year, frmBaoCaoSanLuong_Theo_CongNhan.mdatungay.Month);
            
            LoadData(frmBaoCaoSanLuong_Theo_CongNhan.miID_CongNhan);
            HienThiGridcontrol2(frmBaoCaoSanLuong_Theo_CongNhan.miID_CongNhan);
            Load_LockUp();
            gridCongNhan.EditValue = frmBaoCaoSanLuong_Theo_CongNhan.miID_CongNhan;

        }


        private void btRefesh_Click(object sender, EventArgs e)
        {
            SanLuong_ChiTiet_Luong_Load( sender,  e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                if(e.RowHandle%2==0)
                e.DisplayText = (e.RowHandle/2 + 1).ToString();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNam.Text.ToString()) > 0 & Convert.ToInt32(txtThang.Text.ToString()) > 0)
            {
                ngaydauthang = GetFistDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                ngaycuoithang = GetLastDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                int xxID = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                LoadData(xxID);
                HienThiGridcontrol2(xxID);
                Load_LockUp();
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNam.Text.ToString()) > 0 & Convert.ToInt32(txtThang.Text.ToString()) > 0)
            {
                ngaydauthang = GetFistDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                ngaycuoithang = GetLastDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                int xxID = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                LoadData(xxID);
                HienThiGridcontrol2(xxID);
                Load_LockUp();
            }
        }

        private void txtThang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ngaydauthang = GetFistDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                ngaycuoithang = GetLastDayInMonth(Convert.ToInt32(txtNam.Text.ToString()), Convert.ToInt32(txtThang.Text.ToString()));
                int xxID = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                LoadData(xxID);
                HienThiGridcontrol2(xxID);
                Load_LockUp();
            }
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
           
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            //CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            //string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            //DataView dv1212 = new DataView(DatatableABC);
            //dv1212.RowFilter = filterString;
            //mdtPrint = dv1212.ToTable();

            //if (mdtPrint.Rows.Count > 0)
            //{
            //    mbPrint = true;
            //    mdatungay = dteTuNgay.DateTime;
            //    mdadenngay = dteDenNgay.DateTime;
            //    miID_VThh = Convert.ToInt32(GridMaVT.EditValue.ToString());
            //    msMaVT = GridMaVT.Text.ToString();
            //    msTenVT = txtTenVTHH.Text;
            //    msDVT = txtDVT.Text;
            //    clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            //    DataTable dt3 = new DataTable();
                //if (xxximay_in_1_Cat_2_dot_3 == 1)
                //    dt3 = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_IN(miID_VThh, mdatungay, mdadenngay);
                //else if (xxximay_in_1_Cat_2_dot_3 == 2)
                //    dt3 = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_CAT(miID_VThh, mdatungay, mdadenngay);

                //sanluongthuowng = Convert.ToDouble(dt3.Rows[0]["SanLuong_Thuong"].ToString());
                //sanluongtangca = Convert.ToDouble(dt3.Rows[0]["SanLuong_TangCa"].ToString());
                //sanluongtong = Convert.ToDouble(dt3.Rows[0]["SanLuong_Tong"].ToString());
                //phepham = Convert.ToDouble(dt3.Rows[0]["PhePham"].ToString());
                //frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                //ff.Show();

            //}
        }
    }
}
