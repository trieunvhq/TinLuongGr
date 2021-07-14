using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class BanHang_ChiTietCongNo : Form
    {
        public static bool mbPrint;

        public static DataTable mdtPrint;
        public static string msTieuDe, msSoTaiKhoan, msTenTaiKhoan;
        public static DateTime mdatungay, mdadenngay;

        private void Load_lockUp()
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.SA_BanHang_Select_DISTINCT_Lockup();
            GridSoTaiKhoan.Properties.DataSource = dt;
            GridSoTaiKhoan.Properties.DisplayMember = "SoTaiKhoanCon";
            GridSoTaiKhoan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
        }
        public void LoadData(int iiID_Con, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2xxxx = new DataTable();
            dt2xxxx.Columns.Add("HienThi", typeof(bool));
            dt2xxxx.Columns.Add("ID_MuaHang", typeof(string));
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
                dNoDauKy_0 = CheckString.ConvertToDouble_My(dtdudau.Rows[0]["NoDauKy"].ToString());
                dCoDauKy_0 = CheckString.ConvertToDouble_My(dtdudau.Rows[0]["CoDauKy"].ToString());
            }
            else
            {
                dNoDauKy_0 = dCoDauKy_0 = 0;
            }

            double No_Co_Khong = Math.Abs(dCoDauKy_0 - dNoDauKy_0);
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            _ravi_Khong["DienGiai"] = "Dư đầu kỳ";
            _ravi_Khong["HienThi"] = false;
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
                    _ravi["ID_MuaHang"] = dtphatsinh.Rows[i]["ID_ChungTu"].ToString();
                    if (dtphatsinh.Rows[i]["ID_ChungTu"].ToString() != "" & Convert.ToBoolean(dtphatsinh.Rows[i]["Check_PhanNganHang"].ToString()) == false)
                        _ravi["HienThi"] = true;
                    else _ravi["HienThi"] = false;
                    _ravi["NgayThang"] = Convert.ToDateTime(dtphatsinh.Rows[i]["NgayThang"].ToString());
                    _ravi["DienGiai"] = dtphatsinh.Rows[i]["DienGiai"].ToString();
                    _ravi["SoChungTu"] = dtphatsinh.Rows[i]["SoChungTu"].ToString();
                    double Noxx_hang = CheckString.ConvertToDouble_My(dtphatsinh.Rows[i]["No"].ToString());
                    double Coxx_hang = CheckString.ConvertToDouble_My(dtphatsinh.Rows[i]["Co"].ToString());

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
            _ravi_2["HienThi"] = false;
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
            _ravi_cuoi["HienThi"] = false;
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

        private void HienThiGridControl_2(int xxiDmuahang)
        {
            gridControl1.DataSource = null;
            clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
            cls2.iID_BanHang = xxiDmuahang;
            DataTable dt3 = cls2.Select_HienThiSuaDonHang();
            DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_ChiTietBanHang"); // ID của tbChi tiet don hàng
            //dt2.Columns.Add("ID_BanHang");
            //dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuong"].ToString());
                Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                //_ravi["ID_ChiTietBanHang"] = dt3.Rows[i]["ID_ChiTietBanHang"].ToString();
                //_ravi["ID_BanHang"] = dt3.Rows[i]["ID_BanHang"].ToString();
                //_ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;
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

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bandedGridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
            {
                int iDImuahang = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                HienThiGridControl_2(iDImuahang);
            }
            else gridControl1.DataSource = null;
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["HienThi"]));
                if (category == true)
                {
                    e.Appearance.BackColor = Color.GreenYellow;

                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
           

            DataTable DatatableABC = (DataTable)gridControl2.DataSource;

            if (DatatableABC.Rows.Count == 0)
            {

                MessageBox.Show("Không có dữ liệu");
            }

            else
            {
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                DataTable dt3 = dv1212.ToTable();
                mdtPrint = new DataTable();


                mdtPrint.Columns.Add("NgayThang", typeof(string));
                mdtPrint.Columns.Add("SoChungTu", typeof(string));
                mdtPrint.Columns.Add("DienGiai", typeof(string));

                mdtPrint.Columns.Add("MaVT", typeof(string));
                mdtPrint.Columns.Add("TenVTHH", typeof(string));

                mdtPrint.Columns.Add("NoTrongKy", typeof(string));
                mdtPrint.Columns.Add("CoTrongKy", typeof(string));
                mdtPrint.Columns.Add("NoCuoiKy", typeof(string));
                mdtPrint.Columns.Add("CoCuoiKy", typeof(string));

                mdtPrint.Columns.Add("SoLuong", typeof(string));
                mdtPrint.Columns.Add("DonGia", typeof(string));
                mdtPrint.Columns.Add("ThanhTien", typeof(string));
                mdtPrint.Columns.Add("STT", typeof(string));

                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(dt3.Rows[i]["HienThi"].ToString()) == false)
                    {
                        DataRow _ravi = mdtPrint.NewRow();
                        _ravi["STT"] = (i + 1).ToString();
                        _ravi["NgayThang"] = dt3.Rows[i]["NgayThang"].ToString();
                        _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                        _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                        _ravi["NoTrongKy"] = dt3.Rows[i]["NoTrongKy"].ToString();
                        _ravi["CoTrongKy"] = dt3.Rows[i]["CoTrongKy"].ToString();
                        _ravi["NoCuoiKy"] = dt3.Rows[i]["NoCuoiKy"].ToString();
                        _ravi["CoCuoiKy"] = dt3.Rows[i]["CoCuoiKy"].ToString();
                        mdtPrint.Rows.Add(_ravi);
                    }
                    else
                    {


                        int iDImuahang = Convert.ToInt32(dt3.Rows[i]["ID_MuaHang"].ToString());
                        clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                        cls2.iID_BanHang = iDImuahang;
                        DataTable dtxxx = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();

                        for (int j = 0; j < dtxxx.Rows.Count; j++)
                        {
                            DataRow _ravi2 = mdtPrint.NewRow();
                            _ravi2["STT"] = (i + 1).ToString();
                            _ravi2["SoLuong"] = CheckString.ConvertToDouble_My(dtxxx.Rows[j]["SoLuong"].ToString());
                            _ravi2["DonGia"] = CheckString.ConvertToDouble_My(dtxxx.Rows[j]["DonGia"].ToString());
                            _ravi2["ThanhTien"] = CheckString.ConvertToDouble_My(dtxxx.Rows[j]["SoLuong"].ToString()) * CheckString.ConvertToDouble_My(dtxxx.Rows[j]["DonGia"].ToString());
                            _ravi2["MaVT"] = dtxxx.Rows[j]["MaVT"].ToString();
                            _ravi2["TenVTHH"] = dtxxx.Rows[j]["TenVTHH"].ToString();
                            _ravi2["NgayThang"] = dt3.Rows[i]["NgayThang"].ToString();
                            _ravi2["NoTrongKy"] = dt3.Rows[i]["NoTrongKy"].ToString();
                            _ravi2["CoTrongKy"] = dt3.Rows[i]["CoTrongKy"].ToString();
                            _ravi2["NoCuoiKy"] = dt3.Rows[i]["NoCuoiKy"].ToString();
                            _ravi2["CoCuoiKy"] = dt3.Rows[i]["CoCuoiKy"].ToString();
                            _ravi2["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                            _ravi2["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                            mdtPrint.Rows.Add(_ravi2);
                        }
                    }


                }

                int iiDi = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                msTieuDe = "ĐỐI CHIẾU CÔNG NỢ";
                msSoTaiKhoan = GridSoTaiKhoan.Text.ToString();
                msTenTaiKhoan = txtTenTK.Text;
                mbPrint = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;               
                frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                ff.ShowDialog();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                btLayDuLieu_Click(null, null);
                btPrint.Focus();
            }
        }

        private void GridSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenTK.Focus();
            }
        }

        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btPrint.Focus();
            }
        }

        private void bandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        public BanHang_ChiTietCongNo()
        {
            InitializeComponent();
        }

        private void BanHang_ChiTietCongNo_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_lockUp();
            dteTuNgay.EditValue = BanHang_CongNo.mdteTuNgay;
            dteDenNgay.EditValue = BanHang_CongNo.mdteDenNgay;
            GridSoTaiKhoan.EditValue = BanHang_CongNo.miiiID_TaiKhoanKeToanCon;
            dteTuNgay.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BanHang_ChiTietCongNo_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }
    }
}
