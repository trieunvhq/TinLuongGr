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
        public void LoadData(int iiID_TKKeToanMe, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon", typeof(string));
            dt2.Columns.Add("NoDauKy", typeof(double));
            dt2.Columns.Add("CoDauKy", typeof(double));
            dt2.Columns.Add("NoTrongKy", typeof(double));
            dt2.Columns.Add("CoTrongKy", typeof(double));
            dt2.Columns.Add("NoCuoiKy", typeof(double));
            dt2.Columns.Add("CoCuoiKy", typeof(double));

            gridControl2.DataSource = null;

            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dtnganhang = cls.Sum_Co_No_NgayThang_HUU(iiID_TKKeToanMe, xxtungay, xxdenngay);

            if (dtnganhang.Rows.Count > 0)
            {
                for (int i = 0; i < dtnganhang.Rows.Count; i++)
                {
                    int iiIDID_TaiKhoanKeToanCon;
                    string sTenTaiKhoanCon, sSoTaiKhoanCon;
                    double dNoDauKy, dCoDauKy, dNoTrongKy, dCoTrongKy, dNoCuoiKy, dCoCuoiKy;
                    double dNo_DauKy, dCo_DauKy, dNo_TrongKy, dCo_TrongKy, dNo_CuoiKy, dCo_CuoiKy;
                    iiIDID_TaiKhoanKeToanCon = Convert.ToInt32(dtnganhang.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());

                    dNo_DauKy = Convert.ToDouble(dtnganhang.Rows[i]["No_DauKy"].ToString());
                    dCo_DauKy = Convert.ToDouble(dtnganhang.Rows[i]["Co_DauKy"].ToString());

                    dNo_TrongKy = Convert.ToDouble(dtnganhang.Rows[i]["No_TrongKy"].ToString());
                    dCo_TrongKy = Convert.ToDouble(dtnganhang.Rows[i]["Co_TrongKy"].ToString());

                    dNo_CuoiKy = Convert.ToDouble(dtnganhang.Rows[i]["No_CuoiKy"].ToString());
                    dCo_CuoiKy = Convert.ToDouble(dtnganhang.Rows[i]["Co_CuoiKy"].ToString());

                    sTenTaiKhoanCon = dtnganhang.Rows[i]["TenTaiKhoanCon"].ToString();
                    sSoTaiKhoanCon = dtnganhang.Rows[i]["SoTaiKhoanCon"].ToString();
                    // đầu kỳ
                    if (dNo_DauKy <= dCo_DauKy)
                    {
                        dNoDauKy = 0;
                        dCoDauKy = dCo_DauKy - dNo_DauKy;
                    }
                    else
                    {
                        dNoDauKy = -dCo_DauKy + dNo_DauKy;
                        dCoDauKy = 0;
                    }
                    // trong kỳ
                    if (dNo_TrongKy <= dCo_TrongKy)
                    {
                        dNoTrongKy = 0;
                        dCoTrongKy = dCo_TrongKy - dNo_TrongKy;
                    }
                    else
                    {
                        dNoTrongKy = -dCo_TrongKy + dNo_TrongKy;
                        dCoTrongKy = 0;
                    }
                    // cuoi ky

                    if (dNo_CuoiKy <= dCo_CuoiKy)
                    {
                        dNoCuoiKy = 0;
                        dCoCuoiKy = dCo_CuoiKy - dNo_CuoiKy;
                    }
                    else
                    {
                        dNoCuoiKy = -dCo_CuoiKy + dNo_CuoiKy;
                        dCoCuoiKy = 0;
                    }

                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_TaiKhoanKeToanCon"] = iiIDID_TaiKhoanKeToanCon;

                    _ravi["TenTaiKhoanCon"] = sTenTaiKhoanCon; ;
                    _ravi["SoTaiKhoanCon"] = sSoTaiKhoanCon;
                    _ravi["NoDauKy"] = dNoDauKy;
                    _ravi["CoDauKy"] = dCoDauKy;
                    _ravi["NoTrongKy"] = dNoTrongKy;
                    _ravi["CoTrongKy"] = dCoTrongKy;
                    _ravi["NoCuoiKy"] = dNoCuoiKy;
                    _ravi["CoCuoiKy"] = dCoCuoiKy;
                    dt2.Rows.Add(_ravi);

                }
            }

            gridControl2.DataSource = dt2;
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
            LoadData(frmChiTietBienDongTaiKhoan.miiiID_TaiKhoanKeToanCon, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
