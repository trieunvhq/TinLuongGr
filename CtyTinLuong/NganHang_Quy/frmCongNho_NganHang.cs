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
    public partial class frmCongNho_NganHang : Form
    {
      
        public static int miiiID_TaiKhoanKeToanCon;
        public static DateTime mdteTuNgay, mdteDenNgay;
        public static double mdbNoDauKy, mdbCoDauKy;
        public static bool mPrtint_CongNo_NganHang;
        public static DataTable mdt_ChiTiet_Print;
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
        public static DateTime GetFirstDayInYear(int year)
        {
            DateTime aDateTime = new DateTime(year, 1, 1);
            return aDateTime;
        }

        public void HienThi(DateTime xxxxtungayxx, DateTime xxxdenngayxxx)
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

            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();           
            DataTable dt = cls.Select_DISTINCT_W_ID_TaiKhoanKeToanCon_COngNo_ALL_Newwwwwwwwww(); // có phát sinh mua hàng, bán hàng
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID_TaiKhoanKeToanConxxx = Convert.ToInt32(dt.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    double No_Khong, Co_Khong;
                    cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    cls.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanConxxx;
                    DataTable dt_khongBandau = cls.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_and_Bool_TonDauKy_True();
                    if (dt_khongBandau.Rows.Count > 0)
                    {
                        No_Khong = Convert.ToDouble(dt_khongBandau.Rows[0]["No"].ToString());
                        Co_Khong = Convert.ToDouble(dt_khongBandau.Rows[0]["Co"].ToString());
                    }
                    else
                    {
                        No_Khong = Co_Khong = 0;
                    }
                    cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    cls.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanConxxx;
                    cls.daNgayThang = xxxxtungayxx;
                   
                    DataTable dttong = cls.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_W_NhoHon_NgayThang_and_Bool_TonDauKy_False(ID_TaiKhoanKeToanConxxx, xxxxtungayxx);
                    double No_truocKy, Co_truocKy;
                   
                    if (dttong.Rows.Count > 0)
                    {
                        No_truocKy = Convert.ToDouble(dttong.Rows[0]["No"].ToString());
                        Co_truocKy = Convert.ToDouble(dttong.Rows[0]["Co"].ToString());
                    }
                    else
                    {
                        No_truocKy = Co_truocKy = 0;
                    }
                    cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    cls.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanConxxx;
                    double No_trongKy, Co_TrongKy;
                    No_trongKy = Co_TrongKy = 0;
                    DataTable dttrongky = cls.SelectAll_Sum_W_ID_NgayThang_tuNgay_DenNgay_and_TonDauKy_False(ID_TaiKhoanKeToanConxxx,xxxxtungayxx, xxxdenngayxxx);
                    try
                    {
                        if (dttrongky.Rows.Count > 0)
                        {
                            No_trongKy = Convert.ToDouble(dttrongky.Rows[0]["No"].ToString());
                            Co_TrongKy = Convert.ToDouble(dttrongky.Rows[0]["Co"].ToString());
                        }
                    }
                    catch
                    {
                      //  No_trongKy = Co_TrongKy = 0;
                    }
                    double No_CuoiKy, Co_CuoiKy;
                    No_CuoiKy = No_Khong + No_truocKy + No_trongKy;
                    Co_CuoiKy = Co_Khong + Co_truocKy + Co_TrongKy;

                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_TaiKhoanKeToanCon"] = ID_TaiKhoanKeToanConxxx;
                    clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanConxxx;
                    DataTable dtcon = clscon.SelectOne();


                    _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value; ;
                    _ravi["SoTaiKhoanCon"] = clscon.sSoTaiKhoanCon.Value;
                    _ravi["NoDauKy"] = No_Khong+ No_truocKy;
                    _ravi["CoDauKy"] = Co_Khong + Co_truocKy;
                    _ravi["NoTrongKy"] = No_trongKy;
                    _ravi["CoTrongKy"] = Co_TrongKy;
                    _ravi["NoCuoiKy"] = No_CuoiKy;
                    _ravi["CoCuoiKy"] = Co_CuoiKy;
                    dt2.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = dt2;



        }

    
        public frmCongNho_NganHang()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmCongNho_NganHang_Load( sender,  e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                mdbNoDauKy= Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clNoDauKy).ToString());
                mdbCoDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clCoDauKy).ToString());
                //miTrangThai_MuaHang1_BanHang2_VAT3 = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clTrangThai_MuaHang1_BanHang2_VAT3).ToString());
                miiiID_TaiKhoanKeToanCon = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToanCon).ToString());
                Quy_NganHang_ChiTiet_CongNho_Newwwwww ff = new Quy_NganHang_ChiTiet_CongNho_Newwwwww();
                ff.Show();
            }
        }

      

        private void frmCongNho_NganHang_Load(object sender, EventArgs e)
        {
           
            DateTime ngaydautien, ngaycuoicung;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            dteDenNgay.EditValue = ngaycuoicung;
            dteTuNgay.EditValue = ngaydautien;
            HienThi(ngaydautien, ngaycuoicung);
        }
    }
}
