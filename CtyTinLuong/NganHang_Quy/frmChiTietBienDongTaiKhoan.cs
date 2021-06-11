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
    public partial class frmChiTietBienDongTaiKhoan : Form
    {
        public static int miiiID_TaiKhoanKeToanCon;
        public static DateTime mdteTuNgay, mdteDenNgay;
        public static double mdbNoDauKy, mdbCoDauKy;
        public static bool mPrtint_CongNo_NganHang;
        public static DataTable mdt_ChiTiet_Print;
        private void Load_Lockup()
        {
            clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            gridNhomDoiTuong.Properties.DataSource = dt;
            gridNhomDoiTuong.Properties.DisplayMember = "SoTaiKhoanMe"; //
            gridNhomDoiTuong.Properties.ValueMember = "ID_TaiKhoanKeToanMe";
        }
        public void LoadData(int iiID_TKKeToanMe, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.Select_DISTINCT_W_ID_TaiKhoanKeToanCon_COngNo_ALL(); 
            gridControl1.DataSource = dt;


           
        }
     

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmChiTietBienDongTaiKhoan_Load( sender,  e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                //HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                    mPrtint_CongNo_NganHang = false;
                    MessageBox.Show("Không có dữ liệu");
                }

                else
                {
                    mPrtint_CongNo_NganHang = true;
                    mdteTuNgay = dteTuNgay.DateTime;
                    mdteDenNgay = dteDenNgay.DateTime;

                    frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                    ff.Show();

                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString() != "")
            {
                mdteTuNgay = dteTuNgay.DateTime;
                mdteDenNgay = dteDenNgay.DateTime;
                //mdbNoDauKy, mdbCoDauKy;
                mdbNoDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clNoDauKy).ToString());
                mdbCoDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clCoDauKy).ToString());
                //miTrangThai_MuaHang1_BanHang2_VAT3 = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clTrangThai_MuaHang1_BanHang2_VAT3).ToString());
                miiiID_TaiKhoanKeToanCon = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
                frmChiTietBienDongTaiKhoan_Mot_TaiKhoan ff = new frmChiTietBienDongTaiKhoan_Mot_TaiKhoan();
                ff.Show();
            }
        }

        private void layoutControlItem7_Click(object sender, EventArgs e)
        {

        }

        private void gridNhomDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            int xxid = Convert.ToInt32(gridNhomDoiTuong.EditValue.ToString());
            clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            cls.iID_TaiKhoanKeToanMe = xxid;
            DataTable dt = cls.SelectOne();
            txtTenTKMe.Text = cls.sTenTaiKhoanMe.Value;
        }

        public frmChiTietBienDongTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmChiTietBienDongTaiKhoan_Load(object sender, EventArgs e)
        {
            Load_Lockup();
            clsNgayThang cls = new clsNgayThang();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            gridNhomDoiTuong.EditValue = 287;
            LoadData(287,dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
    }
}
