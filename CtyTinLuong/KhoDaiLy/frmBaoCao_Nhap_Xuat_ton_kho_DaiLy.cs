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
    public partial class frmBaoCao_Nhap_Xuat_ton_kho_DaiLy : Form
    {
        public static bool mbPrint_ALL, mbPrint_One;      
        public static DataTable mdtPrint;
        public static int miiID_VTHH,miID_DaiLy;
        public static string msMaDaiLy, msTenDaiLy;
        public static DateTime mdatungay, mdadenngay;
        private void Load_lockup()
        {
            clsDaiLy_tbNhapKho clsxx = new CtyTinLuong.clsDaiLy_tbNhapKho();
            DataTable dtnhapkho = clsxx.SelectAll_DIStintc_LayDanhSachDaiLy_XuatKho();
           
            DataTable dtxx2 = new DataTable();
            dtxx2.Columns.Add("ID_DaiLy", typeof(int));
            dtxx2.Columns.Add("MaDaiLy", typeof(string));
            dtxx2.Columns.Add("TenDaiLy", typeof(string));
            DataRow _ravi = dtxx2.NewRow();
            _ravi["ID_DaiLy"] = 0;
            _ravi["MaDaiLy"] = "Tất cả";
            dtxx2.Rows.Add(_ravi);
            for (int i = 0; i < dtnhapkho.Rows.Count; i++)
            {
                int ID_DaiLyxx = Convert.ToInt16(dtnhapkho.Rows[i]["ID_DaiLy"].ToString());
                DataRow _ravi2 = dtxx2.NewRow();
                _ravi2["ID_DaiLy"] = ID_DaiLyxx;
                _ravi2["MaDaiLy"] = dtnhapkho.Rows[i]["MaDaiLy"].ToString();
                _ravi2["TenDaiLy"] = dtnhapkho.Rows[i]["TenDaiLy"].ToString();
                dtxx2.Rows.Add(_ravi2);
            }

            gridMaDaiLy.Properties.DataSource = dtxx2;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("ID_NhomVTHH", typeof(int));          
            dt3.Columns.Add("TenNhomVTHH", typeof(string));
            DataRow row0 = dt3.NewRow();
            DataRow row1 = dt3.NewRow();
            DataRow row2 = dt3.NewRow();
            DataRow row3 = dt3.NewRow();
            row0["ID_NhomVTHH"] = 0;
            row0["TenNhomVTHH"] = "Tất cả";
            row1["ID_NhomVTHH"] = 5;
            row1["TenNhomVTHH"] = "Thành phẩm";
            row2["ID_NhomVTHH"] = 7;
            row2["TenNhomVTHH"] = "Bán Thành phẩm";
            row3["ID_NhomVTHH"] = 8;
            row3["TenNhomVTHH"] = "Vật tư";
            dt3.Rows.Add(row0);
            dt3.Rows.Add(row1);
            dt3.Rows.Add(row2);
            dt3.Rows.Add(row3);
            gridNhomVTHH.Properties.DataSource = dt3;
            gridNhomVTHH.Properties.ValueMember = "ID_NhomVTHH";
            gridNhomVTHH.Properties.DisplayMember = "TenNhomVTHH";

        }
        private DataTable LoadDaTa_TonDauKy(int xxID_DaiLy, DateTime xxtungay )
        {          
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            if (xxID_DaiLy == 0)
            {
                dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(xxtungay);
                dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(xxtungay);
            }

            else
            {                
                 dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy_W_ID_DaiLy(xxID_DaiLy, xxtungay);              
                 dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy_W_ID_DaiLy(xxID_DaiLy, xxtungay);
            }
            

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("ID_NhomVTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));         
            for (int i = 0; i < dt_NhapTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTruoc.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_NhapTruocKy, GiaTri_NhapTruocKy, SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;
                
                SoLuong_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["SoLuong_NhapTruocKy"].ToString());
                GiaTri_NhapTruocKy = Convert.ToDouble(dt_NhapTruoc.Rows[i]["GiaTri_NhapTruocKy"].ToString());                
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = 0;
                    GiaTri_XuatTruocKy = 0;
                }
                else
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(rows[0]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(rows[0]["GiaTri_XuatTruocKy"].ToString());

                }
                SoLuong_TonDauKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;
                GiaTri_TonDauKy = GiaTri_NhapTruocKy  - GiaTri_XuatTruocKy;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_NhapTruoc.Rows[i]["ID_NhomVTHH"].ToString());
                _ravi["MaVT"] = dt_NhapTruoc.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTruoc.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTruoc.Rows[i]["DonViTinh"].ToString();
                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;             

                dt2.Rows.Add(_ravi);

            }

            for (int i = 0; i < dt_XuatTruoc.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTruoc.Rows[i]["ID_VTHH"].ToString());
                double SoLuong_XuatTruocKy, GiaTri_XuatTruocKy, SoLuong_TonDauKy, GiaTri_TonDauKy;             
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_XuatTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["SoLuong_XuatTruocKy"].ToString());
                    GiaTri_XuatTruocKy = Convert.ToDouble(dt_XuatTruoc.Rows[i]["GiaTri_XuatTruocKy"].ToString());
                    SoLuong_TonDauKy =  - SoLuong_XuatTruocKy;
                    GiaTri_TonDauKy =  - GiaTri_XuatTruocKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_XuatTruoc.Rows[i]["ID_NhomVTHH"].ToString());
                    _ravi["MaVT"] = dt_XuatTruoc.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTruoc.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTruoc.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;
                    dt2.Rows.Add(_ravi);
                }
                
            }

            return dt2;
        }
        private DataTable LoadDaTa_Nhap_Xuat_TrongKy(int ID_DaiLy_, DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            DataTable dt_NhapTrongKy = new DataTable();
            DataTable dt_XuatTrongKy = new DataTable();

            if (ID_DaiLy_==0)
            {
               
                 dt_NhapTrongKy = cls1.SA_distinct_NhapTrongKy(xxtungay, xxdenngay);              
                 dt_XuatTrongKy = cls2.SA_distinct_XuatTrongKy(xxtungay, xxdenngay);
            }
            else
            {
                dt_NhapTrongKy = cls1.SA_distinct_NhapTrongKy_W_ID_DaiLy(ID_DaiLy_, xxtungay, xxdenngay);
                dt_XuatTrongKy = cls2.SA_distinct_XuatTrongKy_W_ID_DaiLy(ID_DaiLy_, xxtungay, xxdenngay);
            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("ID_NhomVTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));           
            for (int i = 0; i < dt_NhapTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTrongKy.Rows[i]["ID_VTHH"].ToString());
                double  SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
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
               
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_NhapTrongKy.Rows[i]["ID_NhomVTHH"].ToString());
                _ravi["MaVT"] = dt_NhapTrongKy.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_NhapTrongKy.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_NhapTrongKy.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;
                dt2.Rows.Add(_ravi);

            }
            for (int i = 0; i < dt_XuatTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_XuatTrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_XuatTrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_NhapTrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_XuatTrongKy.Rows[i]["ID_NhomVTHH"].ToString());
                    _ravi["MaVT"] = dt_XuatTrongKy.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_XuatTrongKy.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_XuatTrongKy.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuongNhap_TrongKy"] = 0;
                    _ravi["GiaTriNhap_TrongKy"] = 0;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;
                    dt2.Rows.Add(_ravi);                 
                }
                

            }
            return dt2;
        }
        private DataTable LoadDaTa_Lan_1(int ID_DaiLy_,DateTime xxtungay, DateTime xxdenngay)
        {
            
            DataTable dt_TonDayKy = LoadDaTa_TonDauKy(ID_DaiLy_, xxtungay);
            DataTable dt_Nhap_Xuat_TrongKy = LoadDaTa_Nhap_Xuat_TrongKy(ID_DaiLy_, xxtungay, xxdenngay);
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("ID_NhomVTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

         
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2.Columns.Add("GiaTriTon_CuoiKy", typeof(double));
            for (int i = 0; i < dt_Nhap_Xuat_TrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_Nhap_Xuat_TrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_TonDauKy, GiaTri_TonDauKy, SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                SoLuongXuat_TrongKy, GiaTriXuat_TrongKy, SoLuongTon_CuoiKy, GiaTriTon_CuoiKy;

                SoLuongNhap_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                GiaTriNhap_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_Nhap_Xuat_TrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_TonDayKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = 0;
                    GiaTri_TonDauKy = 0;
                }
                else
                {
                    SoLuong_TonDauKy = Convert.ToDouble(rows[0]["SoLuong_TonDauKy"].ToString());
                    GiaTri_TonDauKy = Convert.ToDouble(rows[0]["GiaTri_TonDauKy"].ToString());

                }
                SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_Nhap_Xuat_TrongKy.Rows[i]["ID_NhomVTHH"].ToString());
                _ravi["MaVT"] = dt_Nhap_Xuat_TrongKy.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt_Nhap_Xuat_TrongKy.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt_Nhap_Xuat_TrongKy.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

                _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;

                dt2.Rows.Add(_ravi);

            }
            for (int i = 0; i < dt_TonDayKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy;                double GiaTri_TonDauKy;
           
                double SoLuongTon_CuoiKy;              double GiaTriTon_CuoiKy;
                

                iiiiiID_VTHH = Convert.ToInt16(dt_TonDayKy.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_Nhap_Xuat_TrongKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = Convert.ToDouble(dt_TonDayKy.Rows[i]["SoLuong_TonDauKy"].ToString());
                    GiaTri_TonDauKy = Convert.ToDouble(dt_TonDayKy.Rows[i]["GiaTri_TonDauKy"].ToString());
                   
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy ;
                    GiaTriTon_CuoiKy = GiaTri_TonDauKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    _ravi["ID_NhomVTHH"] = Convert.ToInt16(dt_TonDayKy.Rows[i]["ID_NhomVTHH"].ToString());
                    _ravi["MaVT"] = dt_TonDayKy.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt_TonDayKy.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt_TonDayKy.Rows[i]["DonViTinh"].ToString();

                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                    _ravi["SoLuongNhap_TrongKy"] = 0;
                    _ravi["GiaTriNhap_TrongKy"] = 0;

                    _ravi["SoLuongXuat_TrongKy"] = 0;
                    _ravi["GiaTriXuat_TrongKy"] = 0;

                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;
                    dt2.Rows.Add(_ravi);

                }
            }

            dt2.DefaultView.Sort = "ID_NhomVTHH ASC, TenVTHH ASC";
            dt2 = dt2.DefaultView.ToTable();
            return dt2;         

        }

        private void LoadDaTa(int ID_DaiLy_, int xxID_MaNhomvthh, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt = LoadDaTa_Lan_1(ID_DaiLy_, xxtungay, xxdenngay);
            DataTable dt2 = new DataTable();
            if (xxID_MaNhomvthh==0)
            {
                dt.DefaultView.RowFilter = "ID_NhomVTHH = 5";
                DataView dv = dt.DefaultView;
                dt2 = dv.ToTable();
            }
           else if (xxID_MaNhomvthh == 5)
            {
                dt.DefaultView.RowFilter = "ID_NhomVTHH = 5";
                DataView dv = dt.DefaultView;
                dt2 = dv.ToTable();
            }
            else if (xxID_MaNhomvthh == 7)
            {
                dt.DefaultView.RowFilter = "ID_NhomVTHH = 7";
                DataView dv = dt.DefaultView;
                dt2 = dv.ToTable();
            }
            else if (xxID_MaNhomvthh == 8)
            {
                dt.DefaultView.RowFilter = "ID_NhomVTHH = 8";
                DataView dv = dt.DefaultView;
                dt2 = dv.ToTable();
            }
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("STT", typeof(string));
            dt2xx.Columns.Add("Font", typeof(string));
            dt2xx.Columns.Add("ID_VTHH", typeof(int));
            dt2xx.Columns.Add("ID_NhomVTHH", typeof(int));
            dt2xx.Columns.Add("MaVT", typeof(string));
            dt2xx.Columns.Add("TenVTHH", typeof(string));
            dt2xx.Columns.Add("DonViTinh", typeof(string));
            dt2xx.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2xx.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2xx.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2xx.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2xx.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2xx.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2xx.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2xx.Columns.Add("GiaTriTon_CuoiKy", typeof(double));
            
            string expression1 = "ID_NhomVTHH = 5";
            DataRow[] foundRows1;
            foundRows1 = dt2.Select(expression1);
            if (foundRows1.Length > 0)
            {
                double TP_SoLuong_TonDauKy, TP_GiaTri_TonDauKy, TP_SoLuongNhap_TrongKy, TP_GiaTriNhap_TrongKy,
         TP_SoLuongXuat_TrongKy, TP_GiaTriXuat_TrongKy, TP_SoLuongTon_CuoiKy, TP_GiaTriTon_CuoiKy;

                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 5"));
                TP_GiaTri_TonDauKy = Convert.ToDouble(dt2.Compute("sum(GiaTri_TonDauKy)", "ID_NhomVTHH = 5"));
                TP_SoLuongNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongNhap_TrongKy)", "ID_NhomVTHH = 5"));
                TP_GiaTriNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriNhap_TrongKy)", "ID_NhomVTHH = 5"));
                TP_SoLuongXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongXuat_TrongKy)", "ID_NhomVTHH = 5"));
                TP_GiaTriXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriXuat_TrongKy)", "ID_NhomVTHH = 5"));
                TP_SoLuongTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(SoLuongTon_CuoiKy)", "ID_NhomVTHH = 5"));
                TP_GiaTriTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(GiaTriTon_CuoiKy)", "ID_NhomVTHH = 5"));

                DataRow _ravi_TP = dt2xx.NewRow();
                _ravi_TP["STT"] = "A";
                _ravi_TP["Font"] = "1";
                _ravi_TP["TenVTHH"] = "Nhóm Thành phẩm";
                _ravi_TP["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;
                _ravi_TP["GiaTri_TonDauKy"] = TP_GiaTri_TonDauKy;

                _ravi_TP["SoLuongNhap_TrongKy"] = TP_SoLuongNhap_TrongKy;
                _ravi_TP["GiaTriNhap_TrongKy"] = TP_GiaTriNhap_TrongKy;

                _ravi_TP["SoLuongXuat_TrongKy"] = TP_SoLuongXuat_TrongKy;
                _ravi_TP["GiaTriXuat_TrongKy"] = TP_GiaTriXuat_TrongKy;

                _ravi_TP["SoLuongTon_CuoiKy"] = TP_SoLuongTon_CuoiKy;
                _ravi_TP["GiaTriTon_CuoiKy"] = TP_GiaTriTon_CuoiKy;

                dt2xx.Rows.Add(_ravi_TP);
                for (int i = 0; i < foundRows1.Length; i++)
                {

                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows1[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows1[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows1[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows1[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows1[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows1[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows1[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows1[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows1[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows1[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows1[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows1[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows1[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            string expression2 = "ID_NhomVTHH = 7";
            DataRow[] foundRows_BTP;
            foundRows_BTP = dt2.Select(expression2);
            if (foundRows_BTP.Length > 0)
            {
                double TP_SoLuong_TonDauKy, TP_GiaTri_TonDauKy, TP_SoLuongNhap_TrongKy, TP_GiaTriNhap_TrongKy,
         TP_SoLuongXuat_TrongKy, TP_GiaTriXuat_TrongKy, TP_SoLuongTon_CuoiKy, TP_GiaTriTon_CuoiKy;

                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 7"));
                TP_GiaTri_TonDauKy = Convert.ToDouble(dt2.Compute("sum(GiaTri_TonDauKy)", "ID_NhomVTHH = 7"));
                TP_SoLuongNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongNhap_TrongKy)", "ID_NhomVTHH = 7"));
                TP_GiaTriNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriNhap_TrongKy)", "ID_NhomVTHH = 7"));
                TP_SoLuongXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongXuat_TrongKy)", "ID_NhomVTHH = 7"));
                TP_GiaTriXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriXuat_TrongKy)", "ID_NhomVTHH = 7"));
                TP_SoLuongTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(SoLuongTon_CuoiKy)", "ID_NhomVTHH = 7"));
                TP_GiaTriTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(GiaTriTon_CuoiKy)", "ID_NhomVTHH = 7"));
                
                DataRow _ravi_BTP = dt2xx.NewRow();
                _ravi_BTP["STT"] = "B";
                _ravi_BTP["Font"] = "1";
                _ravi_BTP["TenVTHH"] = "Nhóm Bán Thành phẩm";

                _ravi_BTP["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;
                _ravi_BTP["GiaTri_TonDauKy"] = TP_GiaTri_TonDauKy;

                _ravi_BTP["SoLuongNhap_TrongKy"] = TP_SoLuongNhap_TrongKy;
                _ravi_BTP["GiaTriNhap_TrongKy"] = TP_GiaTriNhap_TrongKy;

                _ravi_BTP["SoLuongXuat_TrongKy"] = TP_SoLuongXuat_TrongKy;
                _ravi_BTP["GiaTriXuat_TrongKy"] = TP_GiaTriXuat_TrongKy;

                _ravi_BTP["SoLuongTon_CuoiKy"] = TP_SoLuongTon_CuoiKy;
                _ravi_BTP["GiaTriTon_CuoiKy"] = TP_GiaTriTon_CuoiKy;
                dt2xx.Rows.Add(_ravi_BTP);

                for (int i = 0; i < foundRows_BTP.Length; i++)
                {
                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows_BTP[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows_BTP[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows_BTP[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows_BTP[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows_BTP[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows_BTP[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows_BTP[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows_BTP[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows_BTP[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows_BTP[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows_BTP[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows_BTP[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows_BTP[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }



            string expression3 = "ID_NhomVTHH = 8";
            DataRow[] foundRows_VT;
            foundRows_VT = dt2.Select(expression3);
            if (foundRows_VT.Length > 0)
            {
                double TP_SoLuong_TonDauKy, TP_GiaTri_TonDauKy, TP_SoLuongNhap_TrongKy, TP_GiaTriNhap_TrongKy,
         TP_SoLuongXuat_TrongKy, TP_GiaTriXuat_TrongKy, TP_SoLuongTon_CuoiKy, TP_GiaTriTon_CuoiKy;

                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 8"));
                TP_GiaTri_TonDauKy = Convert.ToDouble(dt2.Compute("sum(GiaTri_TonDauKy)", "ID_NhomVTHH = 8"));
                TP_SoLuongNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongNhap_TrongKy)", "ID_NhomVTHH = 8"));
                TP_GiaTriNhap_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriNhap_TrongKy)", "ID_NhomVTHH = 8"));
                TP_SoLuongXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(SoLuongXuat_TrongKy)", "ID_NhomVTHH = 8"));
                TP_GiaTriXuat_TrongKy = Convert.ToDouble(dt2.Compute("sum(GiaTriXuat_TrongKy)", "ID_NhomVTHH = 8"));
                TP_SoLuongTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(SoLuongTon_CuoiKy)", "ID_NhomVTHH = 8"));
                TP_GiaTriTon_CuoiKy = Convert.ToDouble(dt2.Compute("sum(GiaTriTon_CuoiKy)", "ID_NhomVTHH = 8"));


                DataRow _ravi_VT = dt2xx.NewRow();
                _ravi_VT["STT"] = "C";
                _ravi_VT["Font"] = "1";
                _ravi_VT["TenVTHH"] = "Nhóm Vật tư";
                _ravi_VT["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;
                _ravi_VT["GiaTri_TonDauKy"] = TP_GiaTri_TonDauKy;

                _ravi_VT["SoLuongNhap_TrongKy"] = TP_SoLuongNhap_TrongKy;
                _ravi_VT["GiaTriNhap_TrongKy"] = TP_GiaTriNhap_TrongKy;

                _ravi_VT["SoLuongXuat_TrongKy"] = TP_SoLuongXuat_TrongKy;
                _ravi_VT["GiaTriXuat_TrongKy"] = TP_GiaTriXuat_TrongKy;

                _ravi_VT["SoLuongTon_CuoiKy"] = TP_SoLuongTon_CuoiKy;
                _ravi_VT["GiaTriTon_CuoiKy"] = TP_GiaTriTon_CuoiKy;
                dt2xx.Rows.Add(_ravi_VT);
                for (int i = 0; i < foundRows_VT.Length; i++)
                {
                    DataRow _ravi1 = dt2xx.NewRow();
                    _ravi1["STT"] = (i + 1).ToString();
                    _ravi1["ID_VTHH"] = foundRows_VT[i]["ID_VTHH"];
                    _ravi1["ID_NhomVTHH"] = foundRows_VT[i]["ID_NhomVTHH"];
                    _ravi1["MaVT"] = foundRows_VT[i]["MaVT"];
                    _ravi1["TenVTHH"] = foundRows_VT[i]["TenVTHH"];
                    _ravi1["DonViTinh"] = foundRows_VT[i]["DonViTinh"];

                    _ravi1["SoLuong_TonDauKy"] = foundRows_VT[i]["SoLuong_TonDauKy"];
                    _ravi1["GiaTri_TonDauKy"] = foundRows_VT[i]["GiaTri_TonDauKy"];

                    _ravi1["SoLuongNhap_TrongKy"] = foundRows_VT[i]["SoLuongNhap_TrongKy"];
                    _ravi1["GiaTriNhap_TrongKy"] = foundRows_VT[i]["GiaTriNhap_TrongKy"];

                    _ravi1["SoLuongXuat_TrongKy"] = foundRows_VT[i]["SoLuongXuat_TrongKy"];
                    _ravi1["GiaTriXuat_TrongKy"] = foundRows_VT[i]["GiaTriXuat_TrongKy"];

                    _ravi1["SoLuongTon_CuoiKy"] = foundRows_VT[i]["SoLuongTon_CuoiKy"];
                    _ravi1["GiaTriTon_CuoiKy"] = foundRows_VT[i]["GiaTriTon_CuoiKy"];
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            gridControl1.DataSource = dt2xx;

        }
        public frmBaoCao_Nhap_Xuat_ton_kho_DaiLy()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsNgayThang cls = new clsNgayThang();
            dteDenNgay.EditValue = DateTime.Now;
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Load_lockup();
            gridNhomVTHH.EditValue = 0;
            if (DaiLy_Frm_TonKho_MotVatTu.isNXT==true)
            {
                frmQuanLyKhoDaiLy.isNXT = false;
                gridMaDaiLy.EditValue = DaiLy_Frm_TonKho_MotVatTu.miID_DaiLy;
            }
            else
            {
                DaiLy_Frm_TonKho_MotVatTu.isNXT = false;
                gridMaDaiLy.EditValue = 0;
            }
           
           

            Cursor.Current = Cursors.Default;
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column == clSTT)
            //    e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            int xidnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
            if (dteTuNgay.EditValue!=null & dteDenNgay.EditValue!=null)
            {
               
                LoadDaTa(xiddaily, xidnhom, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
           
            if (xiddaily == 0) txtTenDaiLy.Text = "";
            else
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = xiddaily;
                DataTable dt = cls.SelectOne();
                txtTenDaiLy.Text = cls.sTenDaiLy.Value;
            }
           
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            //if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null & gridMaDaiLy.EditValue!=null)
            //{
            //    int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            //    LoadDaTa(xiddaily, dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
                
          
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            //if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null & gridMaDaiLy.EditValue != null)
            //{
            //    int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            //    LoadDaTa(xiddaily, dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}

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
                btLayDuLieu_Click_1(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click_1(null, null);
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenDaiLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaDaiLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void bandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellValue(e.RowHandle, View.Columns["Font"]).ToString();
                if (category == "1")
                {
                    e.Appearance.BackColor = Color.Bisque;
                    FontStyle fs = e.Appearance.Font.Style;
                    fs |= FontStyle.Bold;
                    e.Appearance.Font = new Font(e.Appearance.Font, fs);
                }
            }
        }

        private void gridNhomVTHH_EditValueChanged(object sender, EventArgs e)
        {
            if(gridMaDaiLy.EditValue!=null)
            {
                Cursor.Current = Cursors.WaitCursor;
                int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                int xidnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
                LoadDaTa(xiddaily, xidnhom, dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
           

        }

        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            int xidnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
            LoadDaTa(xiddaily, xidnhom, dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                
                miiID_VTHH = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                if (gridMaDaiLy.EditValue == null)
                {
                    miID_DaiLy = 0;
                }
                else
                {
                    miID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                }
                //msoluongTonDauKy= Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuong_TonDauKy).ToString());
                //mGiaTriTonDauKy= Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clGiaTri_TonDauKy).ToString());

                Cursor.Current = Cursors.WaitCursor;

                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                T_DaiLy_ChiTietNhapXuatTon_MotVatTu_MotDaiLy ff 
                    = new T_DaiLy_ChiTietNhapXuatTon_MotVatTu_MotDaiLy(mdatungay, mdadenngay, miiID_VTHH, miID_DaiLy);
                //this.Hide();
                ff.Show();
                //this.Show();
                Cursor.Current = Cursors.Default;
            }
        }
        
        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
            if (mdtPrint.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {
                if (Convert.ToInt32(gridMaDaiLy.EditValue.ToString())==0)
                {
                    mbPrint_ALL = true;
                    mbPrint_One = false;
                }
                else
                {
                    mbPrint_ALL = false;
                    mbPrint_One = true;
                    msMaDaiLy = gridMaDaiLy.Text.ToString();
                    msTenDaiLy = txtTenDaiLy.Text;
                   
                }
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                
                frmPrint_Nhap_Xuat_Ton_TongHop ff = new frmPrint_Nhap_Xuat_Ton_TongHop();
                ff.Show();
            }
        }
    
    }
}
