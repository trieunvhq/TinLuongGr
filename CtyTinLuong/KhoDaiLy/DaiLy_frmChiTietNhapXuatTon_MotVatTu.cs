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
    public partial class DaiLy_frmChiTietNhapXuatTon_MotVatTu : Form
    {
        public static bool mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
        public static int miID_VTHH;
        public static string msNguoiLap_Prtint;
        public static DataTable mdt_ChiTiet_MotVatTu_N_X_T_Print;
        public static DateTime mdatungay, mdadenngay;
        private void Load_Lockup(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbChiTietNhapKho cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();         
            DataTable dt2 = cls.SA_distinct_NhapTrongKy(xxtungay, xxdenngay);        

            gridMaVT.Properties.DataSource = dt2;
            gridMaVT.Properties.ValueMember = "ID_VTHH";
            gridMaVT.Properties.DisplayMember = "MaVT";

            clsTbDanhMuc_DaiLy cls2 = new clsTbDanhMuc_DaiLy();
            DataTable dt2222 = cls2.SelectAll();
            gridMaDaiLy.Properties.DataSource = dt2222;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";
        }
       
        private DataTable LoadDaTa_Nhap_Xuat_TrongKy(int xxID_VTHH, DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            DataTable dt_NhapTrongKy = cls1.SA_NhapTrongKy_ID_VTHH(xxID_VTHH,xxtungay, xxdenngay);

            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            DataTable dt_XuatTrongKy = cls2.SA_XuatTrongKy_ID_VTHH(xxID_VTHH,xxtungay, xxdenngay);


            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2xxxx.Columns.Add("Nhap", typeof(string));
            dt2xxxx.Columns.Add("Xuat", typeof(string));
            dt2xxxx.Columns.Add("Ton", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));
            dt2xxxx.Columns.Add("MaDaiLy", typeof(string));
            dt2xxxx.Columns.Add("TenDaiLy", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            for (int i = 0; i < dt_NhapTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTrongKy.Rows[i]["ID_VTHH"].ToString());
                double SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;
                SoLuongNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                GiaTriNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuongXuat_TrongKy = 0;
                    GiaTriXuat_TrongKy = 0;
                }
                else
                {
                    SoLuongXuat_TrongKy = Convert.ToDouble(rows[0]["SoLuongXuat_TrongKy"].ToString());
                    GiaTriXuat_TrongKy = Convert.ToDouble(rows[0]["GiaTriXuat_TrongKy"].ToString());

                }

                DataRow _ravi = dt2xxxx.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;

                _ravi["MaVT"] = dt_NhapTrongKy.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTrongKy.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTrongKy.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;
                dt2xxxx.Rows.Add(_ravi);

            }
            for (int i = 0; i < dt_XuatTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;

                //SoLuongNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                //GiaTriNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_NhapTrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    DataRow _ravi = dt2xxxx.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["MaVT"] = dt_XuatTrongKy.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTrongKy.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTrongKy.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuongNhap_TrongKy"] = 0;
                    _ravi["GiaTriNhap_TrongKy"] = 0;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;
                    dt2xxxx.Rows.Add(_ravi);
                }


            }
            return dt2xxxx;
        }

        private void LoadDaTa(int xxID_VTHH___, DateTime xxtungay, DateTime xxdenngay)
        {

            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            DataTable dt_NhapTruoc = cls1.SA_NhapTruocKy_ID_VTHH(xxID_VTHH___, xxtungay);

            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            DataTable dt_XuatTruoc = cls2.SA_XuatTruocKy_ID_VTHH(xxID_VTHH___, xxtungay);

            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2xxxx.Columns.Add("Nhap", typeof(string));
            dt2xxxx.Columns.Add("Xuat", typeof(string));
            dt2xxxx.Columns.Add("Ton", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));
            dt2xxxx.Columns.Add("MaDaiLy", typeof(string));
            dt2xxxx.Columns.Add("TenDaiLy", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));

            double SoLuong_NhapTruocKy, SoLuong_XuatTruocKy, SoLuong_TonDauKy;
            if (dt_NhapTruoc.Rows.Count > 0)
            {
                DataRow _ravi = dt2xxxx.NewRow();
                SoLuong_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[0]["SoLuong_NhapTruocKy"].ToString());
                if (dt_XuatTruoc.Rows.Count > 0)
                    SoLuong_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                else
                    SoLuong_XuatTruocKy = 0;
                SoLuong_TonDauKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;
                _ravi["DienGiai"] = "Tồn đầu kỳ";
                _ravi["Nhap"] = SoLuong_NhapTruocKy;
                _ravi["Xuat"] = SoLuong_XuatTruocKy;
                _ravi["Ton"] = SoLuong_TonDauKy;
                dt2xxxx.Rows.Add(_ravi);
            }
            else
            {
                if (dt_XuatTruoc.Rows.Count > 0)
                {
                    DataRow _ravi = dt2xxxx.NewRow();
                    SoLuong_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                    SoLuong_TonDauKy = -SoLuong_XuatTruocKy;
                    _ravi["DienGiai"] = "Tồn đầu kỳ";
                    _ravi["DienGiai"] = "Tồn đầu kỳ";
                    _ravi["Xuat"] = SoLuong_XuatTruocKy;
                    _ravi["Ton"] = SoLuong_TonDauKy;
                    dt2xxxx.Rows.Add(_ravi);
                }
            }
            DataTable dt2 = LoadDaTa_Nhap_Xuat_TrongKy(xxID_VTHH___, xxtungay, xxdenngay);
        }

        private void HienThi()
        {
            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2xxxx.Columns.Add("Nhap", typeof(string));           
            dt2xxxx.Columns.Add("Xuat", typeof(string));
            dt2xxxx.Columns.Add("Ton", typeof(string));           
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));
            dt2xxxx.Columns.Add("MaDaiLy", typeof(string));
            dt2xxxx.Columns.Add("TenDaiLy", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            DateTime dteDenNgayxx = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdadenngay;
            DateTime dteTuNgayxxx = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdatungay;

            DateTime ngaydautien;
            ngaydautien = dteTuNgayxxx;

            TimeSpan timespsanxxxx = dteDenNgayxx - dteTuNgayxxx;
            int songay = timespsanxxxx.Days;
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            _ravi_Khong["DienGiai"] = "Tồn đầu kỳ";
            _ravi_Khong["Ton"] = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.msoluongTonDauKy;
            dt2xxxx.Rows.Add(_ravi_Khong);
            double soluongton=0, Tong_SoLuongNhap=0, Tong_SoluongXuat=0;
            soluongton= frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.msoluongTonDauKy;
            for (int i = 0; i <= songay; i++)
            {

                clsDaiLy_tbChiTietNhapKho cls1 = new clsDaiLy_tbChiTietNhapKho();
                cls1.iID_VTHH = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miiID_VTHH;
                DataTable dt1 = cls1.Select_One_NXT_TinhToan_newwwwww();
                dt1.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaNhapKho=True";
                DataView dv1 = dt1.DefaultView;
                DataTable dt11new = dv1.ToTable();
               
                if (dt11new.Rows.Count > 0) // có nhập
                {
                    double soluongnhap, soluongxuat ;
                    for (int k1 = 0; k1 < dt11new.Rows.Count; k1++)
                    {
                        DataRow _ravi = dt2xxxx.NewRow();
                        soluongnhap = Convert.ToDouble(dt11new.Rows[k1]["SoLuongNhap"].ToString());                        
                        _ravi["NgayChungTu"] = ngaydautien;
                        _ravi["DienGiai"] = dt11new.Rows[k1]["DienGiai"].ToString();
                        _ravi["SoChungTu_NhapKho"] = dt11new.Rows[k1]["SoChungTu"].ToString();
                        _ravi["MaDaiLy"] = dt11new.Rows[k1]["MaDaiLy"].ToString();
                        _ravi["TenDaiLy"] = dt11new.Rows[k1]["TenDaiLy"].ToString();
                        _ravi["Nhap"] = soluongnhap;                      
                        _ravi["Ton"] = soluongton+ soluongnhap;                       
                        soluongton= soluongton + soluongnhap;
                        Tong_SoLuongNhap = Tong_SoLuongNhap + soluongnhap;
                        dt2xxxx.Rows.Add(_ravi);
                    }
                  
                    clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                    cls2.iID_VTHH = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miiID_VTHH;
                    DataTable dt2 = cls2.SelectAll_W_ID_VTHH_TinhToan_TenDaiLy_NXT();
                    dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaXuatKho=True";
                    DataView dv2 = dt2.DefaultView;
                    DataTable dt22new = dv2.ToTable();
                    if (dt22new.Rows.Count > 0) // có xuất
                    {
                        for (int k2 = 0; k2 < dt22new.Rows.Count; k2++)
                        {
                            DataRow _ravi2 = dt2xxxx.NewRow();
                            _ravi2["NgayChungTu"] = ngaydautien;
                            soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                            _ravi2["Xuat"] = soluongxuat;
                            _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();
                            _ravi2["MaDaiLy"] = dt22new.Rows[k2]["MaDaiLy"].ToString();
                            _ravi2["TenDaiLy"] = dt22new.Rows[k2]["TenDaiLy"].ToString();
                            _ravi2["DienGiai"] = dt22new.Rows[k2]["DienGiai"].ToString();
                            _ravi2["Ton"] = soluongton - soluongxuat;
                            dt2xxxx.Rows.Add(_ravi2);
                            soluongton = soluongton - soluongxuat;
                            Tong_SoluongXuat = Tong_SoluongXuat + soluongxuat;
                        }
                       
                    }
                    ngaydautien = ngaydautien.AddDays(1);
                }
                else // ko có nhập, kiểm tra xem có xuất không. nếu có thì thêm row
                {
                    clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                    cls2.iID_VTHH = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miiID_VTHH;
                    DataTable dt2 = cls2.SelectAll_W_ID_VTHH_TinhToan_TenDaiLy_NXT();
                    dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaXuatKho=True";
                    DataView dv2 = dt2.DefaultView;
                    DataTable dt22new = dv2.ToTable();
                    if (dt22new.Rows.Count > 0) // có xuất
                    {
                        for (int k2 = 0; k2 < dt22new.Rows.Count; k2++)
                        {
                            double soluongxuat;
                            DataRow _ravi2 = dt2xxxx.NewRow();
                            _ravi2["NgayChungTu"] = ngaydautien;
                            soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                            _ravi2["Xuat"] = soluongxuat;
                            _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();
                            _ravi2["MaDaiLy"] = dt22new.Rows[k2]["MaDaiLy"].ToString();
                            _ravi2["TenDaiLy"] = dt22new.Rows[k2]["TenDaiLy"].ToString();
                            _ravi2["DienGiai"] = dt22new.Rows[k2]["DienGiai"].ToString();
                            _ravi2["Ton"] = soluongton - soluongxuat;
                            dt2xxxx.Rows.Add(_ravi2);
                            soluongton = soluongton - soluongxuat;
                        }
                    }
                    ngaydautien = ngaydautien.AddDays(1);
                }                
            }
            DataRow _ravi_Cuoi = dt2xxxx.NewRow();
            _ravi_Cuoi["DienGiai"] = "NXT trong kỳ";
            _ravi_Cuoi["Ton"] = soluongton;
            _ravi_Cuoi["Nhap"] = Tong_SoLuongNhap;
            _ravi_Cuoi["Xuat"] = Tong_SoluongXuat;
            dt2xxxx.Rows.Add(_ravi_Cuoi);
            gridControl1.DataSource = dt2xxxx;

        }
        public DaiLy_frmChiTietNhapXuatTon_MotVatTu()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
            miID_VTHH = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miiID_VTHH;
            mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = true;
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdt_ChiTiet_MotVatTu_N_X_T_Print = dv1212.ToTable();
            mdatungay = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdatungay;
            mdadenngay = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdadenngay;
            msNguoiLap_Prtint = "";
            frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww();
            ff.Show();
        }

        private void txtGiaTriTonDauKy_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DaiLy_frmChiTietNhapXuatTon_MotVatTu_Load(object sender, EventArgs e)
        {
            dteTuNgay.EditValue = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdatungay;
            dteDenNgay.EditValue = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.mdadenngay;
            if (frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miID_DaiLy == 0)
                gridMaDaiLy.EditValue = null;
            else gridMaDaiLy.EditValue = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miID_DaiLy;

            gridMaVT.EditValue = frmBaoCao_Nhap_Xuat_ton_kho_DaiLy.miiID_VTHH;

            HienThi();
        }
    }
}
