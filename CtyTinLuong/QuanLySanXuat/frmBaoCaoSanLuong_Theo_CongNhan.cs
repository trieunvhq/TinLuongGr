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

        private void Load_lockup()
        {
           
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("ID_BoPhan", typeof(int));
            dt3.Columns.Add("TenBoPhan", typeof(string));
            DataRow row0 = dt3.NewRow();
            DataRow row1 = dt3.NewRow();
            DataRow row2 = dt3.NewRow();
            DataRow row3 = dt3.NewRow();
            row0["ID_BoPhan"] = 0;
            row0["TenBoPhan"] = "Tất cả";
            row1["ID_BoPhan"] = 1;
            row1["TenBoPhan"] = "Máy In";
            row2["ID_BoPhan"] = 2;
            row2["TenBoPhan"] = "Máy Cắt";
            row3["ID_BoPhan"] = 3;
            row3["TenBoPhan"] = "Máy Đột";
            dt3.Rows.Add(row0);
            dt3.Rows.Add(row1);
            dt3.Rows.Add(row2);
            dt3.Rows.Add(row3);
            gridBoPhan.Properties.DataSource = dt3;
            gridBoPhan.Properties.ValueMember = "ID_BoPhan";
            gridBoPhan.Properties.DisplayMember = "TenBoPhan";

        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public void HienThiGridcontrol2( int iiID_CongNhan,DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
                {
                    grid_ChiTiet.DataSource = null;
                    DataTable dtxxxx = new DataTable();
                    dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan_HUU(iiID_CongNhan, xxtungay, xxdenngay);

                    DataTable dt2xx = new DataTable();

                    dt2xx.Columns.Add("MaVT", typeof(string));
                    dt2xx.Columns.Add("TenVTHH", typeof(string));
                    dt2xx.Columns.Add("DonViTinh", typeof(string));
                    dt2xx.Columns.Add("SanLuong_Thuong", typeof(string));
                    dt2xx.Columns.Add("SanLuong_TangCa", typeof(string));
                    dt2xx.Columns.Add("DinhMuc_KhongTang", typeof(double));
                    dt2xx.Columns.Add("DinhMuc_Tang", typeof(double));
                    dt2xx.Columns.Add("ThanhTien", typeof(double));

                    DataRow _ravi_1 = dt2xx.NewRow();

                    int id_vthh_cu_ = 0;

                    for (int k = 0; k < dtxxxx.Rows.Count; k++)
                    {
                        int xxID_VTHH = Convert.ToInt32(dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString());
                        //double snluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                        //double snluong_tangca = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());
                        double xxsanluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_Thuong)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                        double xxsanluong_tang = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_TangCa)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                        double xxthanhtien = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(ThanhTien)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                        int id_vthh_ = 0;
                        if (k < dtxxxx.Rows.Count - 1)
                        {
                            id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString());
                            if (dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                            {
                                _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                                _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                                _ravi_1["DonViTinh"] = dtxxxx.Rows[k]["DonViTinh"].ToString();
                                _ravi_1["SanLuong_Thuong"] = xxsanluong_thuong;
                                _ravi_1["SanLuong_TangCa"] = xxsanluong_tang;
                                _ravi_1["DinhMuc_KhongTang"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                                _ravi_1["DinhMuc_Tang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                                _ravi_1["ThanhTien"] = xxthanhtien;
                                dt2xx.Rows.Add(_ravi_1);
                                _ravi_1 = dt2xx.NewRow();
                                id_vthh_cu_ = id_vthh_;
                            }
                        }
                        else
                        {
                            _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                            _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                            _ravi_1["DonViTinh"] = dtxxxx.Rows[k]["DonViTinh"].ToString();
                            _ravi_1["SanLuong_Thuong"] = xxsanluong_thuong;
                            _ravi_1["SanLuong_TangCa"] = xxsanluong_tang;
                            _ravi_1["DinhMuc_KhongTang"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                            _ravi_1["DinhMuc_Tang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                            _ravi_1["ThanhTien"] = xxthanhtien;

                            dt2xx.Rows.Add(_ravi_1);

                            _ravi_1 = dt2xx.NewRow();
                        }
                    }

                    grid_ChiTiet.DataSource = dt2xx;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadData(int iID_BoPhan_, DateTime xxtungay, DateTime xxdenngay)
        {
            try
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
                DataTable dtxxxx = new DataTable();
                if (iID_BoPhan_ == 0)
                    dtxxxx = cls.SelectAll_distinct_W_ID_CongNhan_new(xxtungay, xxdenngay);
                else if (iID_BoPhan_ == 1)
                    dtxxxx = cls.SelectAll_distinct_W_ID_CongNhan_new_May_IN(xxtungay, xxdenngay);
                else if (iID_BoPhan_ == 2)
                    dtxxxx = cls.SelectAll_distinct_W_ID_CongNhan_new_May_CAT(xxtungay, xxdenngay);
                else if (iID_BoPhan_ == 3)
                    dtxxxx = cls.SelectAll_distinct_W_ID_CongNhan_new_May_DOT(xxtungay, xxdenngay);
                DataRow _ravi_1 = dt2.NewRow();
                int id_congNhan_Cu_ = 0;
                for (int k = 0; k < dtxxxx.Rows.Count; k++)
                {
                    double deTOngtien = 0;
                    int xxxID_CongNhan_ = Convert.ToInt32(dtxxxx.Rows[k]["ID_CongNhan"].ToString());
                    deTOngtien = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(ThanhTien)", "ID_CongNhan=" + xxxID_CongNhan_ + ""));

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
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (gridBoPhan.EditValue.ToString()!="" & dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int iiD = Convert.ToInt32(gridBoPhan.EditValue.ToString());
                LoadData(iiD,dteTuNgay.DateTime, dteDenNgay.DateTime);
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
            try
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
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btprint_ALL_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    miID_CongNhan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;
                    SanLuong_ChiTiet_Luong ff = new SanLuong_ChiTiet_Luong();
                    //this.Hide();
                    ff.Show();
                    //this.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)13)
            {
                btprint_ALL.Focus();
            }
        }

        private void gridBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            int iiD = Convert.ToInt32(gridBoPhan.EditValue.ToString());
            LoadData(iiD, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        public frmBaoCaoSanLuong_Theo_CongNhan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoSanLuong_Theo_CongNhan_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DateTime ngayhomnay = DateTime.Today;
                int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
                int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
                Load_lockup();

                dteDenNgay.DateTime = DateTime.Today;
                dteTuNgay.DateTime = GetFistDayInMonth(nam, thang);
                gridBoPhan.EditValue = 0;
                //LoadData(0, dteTuNgay.DateTime, dteDenNgay.DateTime);
                gridView2.ExpandAllGroups();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
