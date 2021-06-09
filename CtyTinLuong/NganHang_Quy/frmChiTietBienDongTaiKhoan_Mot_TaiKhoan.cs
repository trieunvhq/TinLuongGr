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
    public partial class frmChiTietBienDongTaiKhoan_Mot_TaiKhoan : Form
    {
        public static bool mbPrint = false;

        public static DataTable mdt_ChiTiet_Print;
        public static string msSoTaiKhoan, msTenTaiKhoan;
        public static DateTime mdatungay, mdadenngay;
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

        private void HienThi()
        {
            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayThang", typeof(DateTime));
            dt2xxxx.Columns.Add("SoChungTu", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));

            //dt2xxxx.Columns.Add("NoDauKy", typeof(double));
            //dt2xxxx.Columns.Add("CoDauKy", typeof(double));
            dt2xxxx.Columns.Add("NoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("CoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("NoCuoiKy", typeof(double));
            dt2xxxx.Columns.Add("CoCuoiKy", typeof(double));


            DateTime dteDenNgayxx = frmChiTietBienDongTaiKhoan.mdteDenNgay;
            DateTime dteTuNgayxxx = frmChiTietBienDongTaiKhoan.mdteTuNgay;

            DateTime ngaydautien;
            ngaydautien = dteTuNgayxxx;

            TimeSpan timespsanxxxx = dteDenNgayxx - dteTuNgayxxx;
            int songay = timespsanxxxx.Days;
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            _ravi_Khong["DienGiai"] = "Dư đầu kỳ";
            _ravi_Khong["NoCuoiKy"] = frmChiTietBienDongTaiKhoan.mdbNoDauKy;
            _ravi_Khong["CoCuoiKy"] = frmChiTietBienDongTaiKhoan.mdbCoDauKy;

            dt2xxxx.Rows.Add(_ravi_Khong);
            double sotien_No = 0, sotien_Co = 0, Tong_Soluong_No_phatsinh = 0, Tong_Soluong_Co_phatsinh = 0;
            sotien_No = frmChiTietBienDongTaiKhoan.mdbNoDauKy;
            sotien_Co = frmChiTietBienDongTaiKhoan.mdbCoDauKy;
            for (int i = 0; i <= songay; i++)
            {

                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls1 = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

                cls1.iID_TaiKhoanKeToanCon = frmChiTietBienDongTaiKhoan.miiiID_TaiKhoanKeToanCon;
                cls1.daNgayThang = ngaydautien;
                DataTable dt11new = cls1.SelectAll_W_ID_Bang_NgayThang_TonDauKy_False();


                if (dt11new.Rows.Count > 0) // Có 
                {
                    double sotien_No_Phatsinh, sotien_Co_phatsinh;
                    for (int k1 = 0; k1 < dt11new.Rows.Count; k1++)
                    {
                        DataRow _ravi = dt2xxxx.NewRow();
                        sotien_No_Phatsinh = Convert.ToDouble(dt11new.Rows[k1]["No"].ToString());
                        sotien_Co_phatsinh = Convert.ToDouble(dt11new.Rows[k1]["Co"].ToString());
                        _ravi["NgayThang"] = ngaydautien;
                        _ravi["DienGiai"] = dt11new.Rows[k1]["DienGiai"].ToString();
                        _ravi["SoChungTu"] = dt11new.Rows[k1]["SoChungTu"].ToString();

                        _ravi["NoTrongKy"] = sotien_No_Phatsinh;
                        _ravi["CoTrongKy"] = sotien_Co_phatsinh;

                        _ravi["NoCuoiKy"] = sotien_No + sotien_No_Phatsinh;
                        _ravi["CoCuoiKy"] = sotien_Co + sotien_Co_phatsinh;


                        sotien_No = sotien_No + sotien_No_Phatsinh;
                        sotien_Co = sotien_Co + sotien_Co_phatsinh;
                        Tong_Soluong_No_phatsinh = Tong_Soluong_No_phatsinh + sotien_No_Phatsinh;
                        Tong_Soluong_Co_phatsinh = Tong_Soluong_Co_phatsinh + sotien_Co_phatsinh;
                        dt2xxxx.Rows.Add(_ravi);
                    }
                }
                ngaydautien = ngaydautien.AddDays(1);
            }

            DataRow _ravi_Cuoi = dt2xxxx.NewRow();
            _ravi_Cuoi["DienGiai"] = "NXT trong kỳ";
            _ravi_Cuoi["NoTrongKy"] = Tong_Soluong_No_phatsinh;
            _ravi_Cuoi["CoTrongKy"] = Tong_Soluong_Co_phatsinh;
            _ravi_Cuoi["NoCuoiKy"] = sotien_No;
            _ravi_Cuoi["CoCuoiKy"] = sotien_Co;
            _ravi_Cuoi["DienGiai"] = "Phát sinh trong kỳ";
            dt2xxxx.Rows.Add(_ravi_Cuoi);
            gridControl2.DataSource = dt2xxxx;
        }

        public frmChiTietBienDongTaiKhoan_Mot_TaiKhoan()
        {
            InitializeComponent();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {

                DataTable DatatableABC = (DataTable)gridControl2.DataSource;
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdt_ChiTiet_Print = dv1212.ToTable();

                if (mdt_ChiTiet_Print.Rows.Count == 0)
                {
                    mbPrint = false;
                    MessageBox.Show("Không có dữ liệu");
                }

                else
                {

                    mbPrint = true;
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;

                    frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                    ff.Show();

                }
            }
        }

        private void frmChiTietBienDongTaiKhoan_Mot_TaiKhoan_Load(object sender, EventArgs e)
        {
            clsNganHang_TaiKhoanKeToanCon cls1 = new clsNganHang_TaiKhoanKeToanCon();

            cls1.iID_TaiKhoanKeToanCon = frmChiTietBienDongTaiKhoan.miiiID_TaiKhoanKeToanCon;
            DataTable dt = cls1.SelectOne();
            msSoTaiKhoan = cls1.sSoTaiKhoanCon.Value;
            msTenTaiKhoan = cls1.sTenTaiKhoanCon.Value;
            txtSoTK.Text = cls1.sSoTaiKhoanCon.Value.ToString();
            txtTenTK.Text = cls1.sTenTaiKhoanCon.Value.ToString();
            dteDenNgay.EditValue = frmChiTietBienDongTaiKhoan.mdteDenNgay;
            dteTuNgay.EditValue = frmChiTietBienDongTaiKhoan.mdteTuNgay;
            HienThi();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
