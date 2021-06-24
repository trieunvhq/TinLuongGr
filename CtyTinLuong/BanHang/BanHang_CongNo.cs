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
    public partial class BanHang_CongNo : Form
    {
        public static int miiiID_TaiKhoanKeToanCon;
        public static DateTime mdteTuNgay, mdteDenNgay;
        public static bool mbPrint;
        public static string msTieuDe, mssoTK_me, msTenTK_me;

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_CongNo_Load( sender,  e);
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

            gridControl1.DataSource = null;

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

            gridControl1.DataSource = dt2;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int xxid = 268; // // 131 Phải thu của khách hàng
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
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

                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdt_ChiTiet_Print = dv1212.ToTable();

                if (mdt_ChiTiet_Print.Rows.Count == 0)
                {

                    MessageBox.Show("Không có dữ liệu");
                }

                else
                {
                    mbPrint = true;
                    mdteTuNgay = dteTuNgay.DateTime;
                    mdteDenNgay = dteDenNgay.DateTime;
                    mssoTK_me = "331";
                    msTenTK_me = "Phải trả cho người bán";
                    msTieuDe = "ĐỐI CHIẾU CÔNG NỢ";
                    frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                    ff.ShowDialog();

                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString() != "")
            {
                mdteTuNgay = dteTuNgay.DateTime;
                mdteDenNgay = dteDenNgay.DateTime;
                miiiID_TaiKhoanKeToanCon = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
                BanHang_ChiTietCongNo ff = new BanHang_ChiTietCongNo();
                this.Hide();
                ff.ShowDialog();
                this.Show();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        public static DataTable mdt_ChiTiet_Print;
        public BanHang_CongNo()
        {
            InitializeComponent();
        }

        private void BanHang_CongNo_Load(object sender, EventArgs e)
        {
            clsNgayThang cls = new clsNgayThang();
            dteDenNgay.EditValue = DateTime.Today;
            DateTime ngaydauthang = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteTuNgay.EditValue = ngaydauthang;
            int xxid = 268; // 131 Phải thu của khách hàng
            LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
    }
}
