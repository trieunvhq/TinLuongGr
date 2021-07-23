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
    public partial class frmChiTietBienDongTaiKhoan_Mot_TaiKhoan : Form
    {
        public static bool mbPrint;
        public static bool isChiTiet_thuchi=false;
        public static DataTable mdt_ChiTiet_Print;
        public static string msTieuDe, msSoTaiKhoan, msTenTaiKhoan;
        public static DateTime mdatungay, mdadenngay;
        public static int miID_ChungTu, mibientrangthai;
        private void Load_lockUp()
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.Select_DISTINCT_W_ID_TaiKhoanKeToanCon_COngNo_ALL();
            GridSoTaiKhoan.Properties.DataSource = dt;
            GridSoTaiKhoan.Properties.DisplayMember = "SoTaiKhoanCon";
            GridSoTaiKhoan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
        }
        public void LoadData(int iiID_Con, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2xxxx = new DataTable();
            dt2xxxx.Columns.Add("HienThi", typeof(bool));
            dt2xxxx.Columns.Add("NgayThang", typeof(DateTime));
            dt2xxxx.Columns.Add("SoChungTu", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            dt2xxxx.Columns.Add("NoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("CoTrongKy", typeof(double));
            dt2xxxx.Columns.Add("NoCuoiKy", typeof(double));
            dt2xxxx.Columns.Add("CoCuoiKy", typeof(double));
            dt2xxxx.Columns.Add("ID_ChungTu", typeof(string));
            dt2xxxx.Columns.Add("MuaHang_1_BanHang_2", typeof(string));
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
                    _ravi["ID_ChungTu"] = dtphatsinh.Rows[i]["ID_ChungTu"].ToString();
                    if (dtphatsinh.Rows[i]["ID_ChungTu"].ToString() != "" & Convert.ToBoolean(dtphatsinh.Rows[i]["Check_PhanNganHang"].ToString()) == false)
                    {
                        _ravi["HienThi"] = true;
                        if (dtphatsinh.Rows[i]["TrangThai_MuaHang1_BanHang2_VAT3"].ToString() == "1")
                            _ravi["MuaHang_1_BanHang_2"] = "1";
                        else if (dtphatsinh.Rows[i]["TrangThai_MuaHang1_BanHang2_VAT3"].ToString() == "2")
                            _ravi["MuaHang_1_BanHang_2"] = "2";

                    }
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
                _ravi_2["NoTrongKy"] = Noxx- dNoDauKy_0;
                _ravi_2["CoTrongKy"] = Coxx - dCoDauKy_0;
            }
            else
            {
                _ravi_2["NoTrongKy"] = Noxx - dNoDauKy_0;
                _ravi_2["CoTrongKy"] = Coxx- dCoDauKy_0;
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

        private void HienThiGridControl_MuaHang(int xxiDmuahang)
        {
            gridControl1.DataSource = null;
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = xxiDmuahang;
            DataTable dt2 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            //DataTable dt2 = new DataTable();

            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("MaVT");
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("ThanhTien", typeof(double));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuong"].ToString());
            //    Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();

            //    _ravi["SoLuong"] = xxsoluong;
            //    _ravi["DonGia"] = xxdongia;
            //    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
            //    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
            //    _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
            //    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
            //    _ravi["HienThi"] = "1";
            //    dt2.Rows.Add(_ravi);
            //}

            gridControl1.DataSource = dt2;
        }
        private void HienThiGridControl_BanHang(int xxiDmuahang)
        {
            gridControl1.DataSource = null;
            clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
            cls2.iID_BanHang = xxiDmuahang;
            DataTable dt2 = cls2.Select_HienThiSuaDonHang();
            //DataTable dt2 = new DataTable();
         
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("MaVT");// tb VTHH
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("ThanhTien", typeof(double));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuong"].ToString());
            //    Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();
            
            //    _ravi["SoLuong"] = xxsoluong;
            //    _ravi["DonGia"] = xxdongia;
            //    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
            //    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
            //    _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
            //    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
            //    _ravi["HienThi"] = "1";
            //    dt2.Rows.Add(_ravi);
            //}
            gridControl1.DataSource = dt2;
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

      

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmChiTietBienDongTaiKhoan_Mot_TaiKhoan_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null)
            {
                int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

     
        private void btPrint_PhaiTraNguoiBan_Click(object sender, EventArgs e)
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
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                cls.iID_TaiKhoanKeToanCon = iiDi;
                DataTable dt = cls.SelectOne();
                if (cls.iID_TaiKhoanKeToanMe == 287)
                    msTieuDe = "SỔ CHI TIẾT PHẢI TRẢ CHO NGƯỜI BÁN";
                else if (cls.iID_TaiKhoanKeToanMe == 268)
                    msTieuDe = "SỔ CHI TIẾT PHẢI THU CỦA KHÁCH HÀNG";
                else msTieuDe = "SỔ CHI TIẾT TÀI KHOẢN";
                msSoTaiKhoan = GridSoTaiKhoan.Text.ToString();
                msTenTaiKhoan = txtTenTK.Text;
                mbPrint = true;               
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;               

                frmPrintCongNoNganHang ff = new frmPrintCongNoNganHang();
                ff.Show();

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
                    e.Appearance.BackColor = Color.Beige;

                }
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(bandedGridView1.GetFocusedRowCellValue(clHienThi).ToString())==false)
            {
               
                miID_ChungTu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_ChungTu).ToString());
                clsNganHang_tbThuChi cls = new clsNganHang_tbThuChi();
                cls.iID_ThuChi = miID_ChungTu;
                DataTable dt = cls.SelectOne();
                if(dt.Rows.Count>0)
                {
                    isChiTiet_thuchi = true;                    
                    UCQuy_NganHang_BaoCo.isChiTiet_thuchi = false;
                    BanHang_DoiChieu_CongNo_new.isChiTiet_thuchi = false;
                    MuaHang_DoiChieuCongNo_New.isChiTiet_thuchi = false;
                    mibientrangthai = cls.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5.Value;
                    Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
                    ff.Show();
                }
                

            }
         
        }

        private void bandedGridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_ChungTu).ToString() != "")
            {
                miID_ChungTu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_ChungTu).ToString());
                if (bandedGridView1.GetFocusedRowCellValue(clMuaHang_1_BanHang_2).ToString() == "1")
                    HienThiGridControl_MuaHang(miID_ChungTu);
                else if (bandedGridView1.GetFocusedRowCellValue(clMuaHang_1_BanHang_2).ToString() == "2")
                    HienThiGridControl_BanHang(miID_ChungTu);

            }
            else gridControl1.DataSource = null;
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            ///dsdsdsds
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void GridSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
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

        private void frmChiTietBienDongTaiKhoan_Mot_TaiKhoan_Load(object sender, EventArgs e)
        {
          
          
            Load_lockUp();
            dteTuNgay.EditValue = frmChiTietBienDongTaiKhoan.mdteTuNgay;
            dteDenNgay.EditValue = frmChiTietBienDongTaiKhoan.mdteDenNgay;
            GridSoTaiKhoan.EditValue = frmChiTietBienDongTaiKhoan.miiiID_TaiKhoanKeToanCon;

            //LoadData(frmChiTietBienDongTaiKhoan.miiiID_TaiKhoanKeToanCon, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
