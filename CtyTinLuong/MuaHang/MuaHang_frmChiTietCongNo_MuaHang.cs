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
    public partial class MuaHang_frmChiTietCongNo_MuaHang : Form
    {
        public static bool mbPrint;

        public static DataTable mdt_ChiTiet_Print;
        public static string msTieuDe, msSoTaiKhoan, msTenTaiKhoan;
        public static DateTime mdatungay, mdadenngay;

        private void Load_lockUp()
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.Select_DISTINCT_W_ID_TaiKhoanKeToanCon_COngNo_MuaHang_Select_DISTINCT();          
            GridSoTaiKhoan.Properties.DataSource = dt;
            GridSoTaiKhoan.Properties.DisplayMember = "SoTaiKhoanCon";
            GridSoTaiKhoan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
        }
        public void LoadData(int iiID_Con, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayThang", typeof(DateTime));
            dt2xxxx.Columns.Add("SoChungTu", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            dt2xxxx.Columns.Add("NoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("CoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("NoCuoiKy", typeof(double));
            dt2xxxx.Columns.Add("CoCuoiKy", typeof(double));
            dt2xxxx.Columns.Add("TK_DoiUng", typeof(string));
            dt2xxxx.Columns.Add("SoLuong", typeof(double));
            dt2xxxx.Columns.Add("DonGia", typeof(double));
            dt2xxxx.Columns.Add("ThanhTien", typeof(double));
            //TK_DoiUng
            gridControl2.DataSource = null;

            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dtdudau = cls.Sum_Co_No_W_ID_Con_NgayThang_Du_Dau_HUU(iiID_Con, xxtungay);
            DataTable dtphatsinh = cls.Sum_Co_No_W_ID_Con_NgayThang_PhatSinh_HUU(iiID_Con, xxtungay, xxdenngay);
            double dNoDauKy_0, dCoDauKy_0;
            if (dtdudau.Rows.Count > 0)
            {
                dNoDauKy_0 = Convert.ToDouble(dtdudau.Rows[0]["NoDauKy"].ToString());
                dCoDauKy_0 = Convert.ToDouble(dtdudau.Rows[0]["CoDauKy"].ToString());
            }
            else
            {
                dNoDauKy_0 = dCoDauKy_0 = 0;
            }

            double No_Co_Khong = Math.Abs(dCoDauKy_0 - dNoDauKy_0);
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            _ravi_Khong["DienGiai"] = "Dư đầu kỳ";
            if (dNoDauKy_0 <= dCoDauKy_0)
            {
                _ravi_Khong["NoCuoiKy"] = 0;
                _ravi_Khong["CoCuoiKy"] = No_Co_Khong;
            }
            else
            {
                _ravi_Khong["NoCuoiKy"] = No_Co_Khong;
                _ravi_Khong["CoCuoiKy"] = 0;
            }
            dt2xxxx.Rows.Add(_ravi_Khong);
            double Noxx = dNoDauKy_0, Coxx = dCoDauKy_0;
            if (dtphatsinh.Rows.Count > 0)
            {

                for (int i = 0; i < dtphatsinh.Rows.Count; i++)
                {
                    DataRow _ravi = dt2xxxx.NewRow();
                    _ravi["NgayThang"] = Convert.ToDateTime(dtphatsinh.Rows[i]["NgayThang"].ToString());
                    _ravi["DienGiai"] = dtphatsinh.Rows[i]["DienGiai"].ToString();
                    _ravi["SoChungTu"] = dtphatsinh.Rows[i]["SoChungTu"].ToString();
                    double Noxx_hang = Convert.ToDouble(dtphatsinh.Rows[i]["No"].ToString());
                    double Coxx_hang = Convert.ToDouble(dtphatsinh.Rows[i]["Co"].ToString());

                    if (Noxx_hang <= Coxx_hang)
                    {
                        _ravi["NoTrongKy"] = 0;
                        _ravi["CoTrongKy"] = Math.Abs(Noxx_hang - Coxx_hang);
                    }
                    else
                    {
                        _ravi["NoTrongKy"] = Math.Abs(Noxx_hang - Coxx_hang);
                        _ravi["CoTrongKy"] = 0;
                    }

                    Noxx = Noxx + Noxx_hang;
                    Coxx = Coxx + Coxx_hang;
                    if (Noxx <= Coxx)
                    {
                        _ravi["NoCuoiKy"] = 0;
                        _ravi["CoCuoiKy"] = Math.Abs(Noxx - Coxx);
                    }
                    else
                    {
                        _ravi["NoCuoiKy"] = Math.Abs(Noxx - Coxx);
                        _ravi["CoCuoiKy"] = 0;
                    }

                    dt2xxxx.Rows.Add(_ravi);
                }
            }

            DataRow _ravi_2 = dt2xxxx.NewRow();
            _ravi_2["DienGiai"] = "Cộng phát sinh trong kỳ";
            if (Noxx <= Coxx)
            {
                _ravi_2["NoTrongKy"] = Noxx - dNoDauKy_0;
                _ravi_2["CoTrongKy"] = Coxx - dCoDauKy_0;
            }
            else
            {
                _ravi_2["NoTrongKy"] = Noxx - dNoDauKy_0;
                _ravi_2["CoTrongKy"] = Coxx - dCoDauKy_0;
            }
            dt2xxxx.Rows.Add(_ravi_2);
            gridControl2.DataSource = dt2xxxx;

            DataRow _ravi_cuoi = dt2xxxx.NewRow();
            _ravi_cuoi["DienGiai"] = "Dư cuối kỳ";
            if (Noxx <= Coxx)
            {
                _ravi_cuoi["NoCuoiKy"] = 0;
                _ravi_cuoi["CoCuoiKy"] = Math.Abs(Noxx - Coxx);
            }
            else
            {
                _ravi_cuoi["NoCuoiKy"] = Math.Abs(Noxx - Coxx);
                _ravi_cuoi["CoCuoiKy"] = 0;
            }
            dt2xxxx.Rows.Add(_ravi_cuoi);
            gridControl2.DataSource = dt2xxxx;
        }
        public MuaHang_frmChiTietCongNo_MuaHang()
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

        private void btRefresh_Click(object sender, EventArgs e)
        {
            MuaHang_frmChiTietCongNo_MuaHang_Load( sender,  e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null)
            {
                int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void GridSoTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.iID_TaiKhoanKeToanCon = xxid;
            DataTable dt = cls.SelectOne();
            txtTenTK.Text = cls.sTenTaiKhoanCon.Value;
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null)
            {
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl2.DataSource;
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
                int iiDi = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                msTieuDe = "ĐỐI CHIẾU CÔNG NỢ";
                msSoTaiKhoan = GridSoTaiKhoan.Text.ToString();
                msTenTaiKhoan = txtTenTK.Text;
                mbPrint = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                ff.Show();

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MuaHang_frmChiTietCongNo_MuaHang_Load(object sender, EventArgs e)
        {
            Load_lockUp();
            dteTuNgay.EditValue = MuaHang_frmCongNo.mdteTuNgay;
            dteDenNgay.EditValue = MuaHang_frmCongNo.mdteDenNgay;
            GridSoTaiKhoan.EditValue = MuaHang_frmCongNo.miiiID_TaiKhoanKeToanCon;
        }
    }
}
