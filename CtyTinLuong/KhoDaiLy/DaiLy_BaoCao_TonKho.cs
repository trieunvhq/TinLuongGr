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
    public partial class DaiLy_BaoCao_TonKho : Form
    {
        public static int miID_VTHHH;
        public static DateTime mdadenngay;
        public static bool mbPrint_ALL, mbPrint_One;
        public static DataTable mdtPrint_ALL, mdtPrint_One;
        public DaiLy_BaoCao_TonKho()
        {
            InitializeComponent();
        }

        private void HienThi_GridConTrol_2(int xxID_VTHH, DateTime xxdenngaya)
        {
            gridControl2.DataSource = null;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Ton", typeof(double));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("ID_DaiLy", typeof(int));

            DataTable dtnhap = new DataTable();
            DataTable dtXuat = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            dtnhap = cls1.SA_TonKho_W_ID_VTHH(xxID_VTHH,xxdenngaya);
            dtXuat = cls2.SA_TonKho_W_ID_VTHH(xxID_VTHH,xxdenngaya);
            if(dtnhap.Rows.Count>0)
            {
                for (int i = 0; i < dtnhap.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtnhap.Rows[i]["ID_DaiLy"].ToString());
                    double soluongnhap = Convert.ToDouble(dtnhap.Rows[i]["SoLuongNhap"].ToString());
                    double soluongxuat;
                    string expression = "ID_DaiLy='" + iiID_DaiLy + "'";
                    DataRow[] foundRows;
                    foundRows = dtXuat.Select(expression);
                    if (foundRows.Length > 0)
                        soluongxuat = Convert.ToDouble(foundRows[0]["SoLuongXuat"].ToString());
                    else
                        soluongxuat = 0;
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = soluongnhap - soluongxuat;
                    _ravi2["MaDaiLy"] = dtnhap.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtnhap.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            else if (dtXuat.Rows.Count > 0)
            {
                for (int i = 0; i < dtXuat.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtXuat.Rows[i]["ID_DaiLy"].ToString());
                    double soluongxuat = Convert.ToDouble(dtXuat.Rows[i]["SoLuongXuat"].ToString());
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = - soluongxuat;
                    _ravi2["MaDaiLy"] = dtXuat.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtXuat.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            gridControl2.DataSource = dt2;
        }
        private void Load_Lockup()
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
        private DataTable LoadDaTa_lan1(int xxID_DaiLy, DateTime xxdenngaya)
        {
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            if (xxID_DaiLy == 0)
            {
                dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(xxdenngaya);
                dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(xxdenngaya);
            }

            else
            {
                dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy_W_ID_DaiLy(xxID_DaiLy, xxdenngaya);
                dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy_W_ID_DaiLy(xxID_DaiLy, xxdenngaya);
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
                GiaTri_TonDauKy = GiaTri_NhapTruocKy - GiaTri_XuatTruocKy;
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
                    SoLuong_TonDauKy = -SoLuong_XuatTruocKy;
                    GiaTri_TonDauKy = -GiaTri_XuatTruocKy;
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
            dt2.DefaultView.Sort = "ID_NhomVTHH ASC, TenVTHH ASC";
            dt2 = dt2.DefaultView.ToTable();
            return dt2;
           
        }

        private void LoadDaTa(int xxID_DaiLy, int xxID_MaNhomvthh, DateTime xxdenngaya)
        {
            DataTable dt = LoadDaTa_lan1(xxID_DaiLy, xxdenngaya);
            DataTable dt2 = new DataTable();
            if (xxID_MaNhomvthh == 0)
            {
                //dt.DefaultView.RowFilter = "ID_NhomVTHH = 5";
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
            //dt2xx.Columns.Add("GiaTri_TonDauKy", typeof(double));
            string expression1 = "ID_NhomVTHH = 5";
            DataRow[] foundRows1;
            foundRows1 = dt2.Select(expression1);
            if (foundRows1.Length > 0)
            {
                double TP_SoLuong_TonDauKy;
                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 5"));                          

                DataRow _ravi_TP = dt2xx.NewRow();
                _ravi_TP["STT"] = "A";
                _ravi_TP["Font"] = "1";
                _ravi_TP["TenVTHH"] = "Nhóm Thành phẩm";
                _ravi_TP["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;
                        

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
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            string expression2 = "ID_NhomVTHH = 7";
            DataRow[] foundRows_BTP;
            foundRows_BTP = dt2.Select(expression2);
            if (foundRows_BTP.Length > 0)
            {
                double TP_SoLuong_TonDauKy;

                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 7"));
               

                DataRow _ravi_BTP = dt2xx.NewRow();
                _ravi_BTP["STT"] = "B";
                _ravi_BTP["Font"] = "1";
                _ravi_BTP["TenVTHH"] = "Nhóm Bán Thành phẩm";
                _ravi_BTP["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;              
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
                    dt2xx.Rows.Add(_ravi1);

                }
            }
            string expression3 = "ID_NhomVTHH = 8";
            DataRow[] foundRows_VT;
            foundRows_VT = dt2.Select(expression3);
            if (foundRows_VT.Length > 0)
            {
                double TP_SoLuong_TonDauKy;
                TP_SoLuong_TonDauKy = Convert.ToDouble(dt2.Compute("sum(SoLuong_TonDauKy)", "ID_NhomVTHH = 8"));               
                DataRow _ravi_VT = dt2xx.NewRow();
                _ravi_VT["STT"] = "C";
                _ravi_VT["Font"] = "1";
                _ravi_VT["TenVTHH"] = "Nhóm Vật tư";
                _ravi_VT["SoLuong_TonDauKy"] = TP_SoLuong_TonDauKy;
              
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
                    dt2xx.Rows.Add(_ravi1);

                }
            }


            gridControl1.DataSource = dt2xx;

        }
        private void DaiLy_BaoCao_TonKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_Lockup();
            gridNhomVTHH.EditValue = 0;
            gridMaDaiLy.EditValue = 0;
            dteDenNgay.DateTime = DateTime.Now;
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column == clSTT)
            //{
            //    e.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            if(dteDenNgay.EditValue!=null)
            {
                int kkk = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                int idnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
                LoadDaTa(kkk, idnhom, dteDenNgay.DateTime);
            }
            int xiddaily = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            if (xiddaily == 0) txtTenDaiLy.Text = "";
            else
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = xiddaily;
                DataTable dt = cls.SelectOne();
                txtTenDaiLy.Text = cls.sTenDaiLy.Value;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                int xxID =Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                HienThi_GridConTrol_2(xxID, dteDenNgay.DateTime);

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (gridMaDaiLy.EditValue.ToString() != ""& gridNhomVTHH.EditValue.ToString() != "")
            {
                int kkk = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                int idnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
                LoadDaTa(kkk, idnhom, dteDenNgay.DateTime);
            }
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_VTHHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                mdadenngay = dteDenNgay.DateTime;
                DaiLy_Frm_TonKho_MotVatTu ff = new DaiLy_Frm_TonKho_MotVatTu();
                //this.Hide();
                ff.Show();
                //this.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaDaiLy.Focus();
            }
        }

        private void gridMaDaiLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenDaiLy.Focus();
            }
        }

        private void txtTenDaiLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btPrint_One.Focus();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
        //    if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        miID_VTHHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
        //        int miID_DaiLy = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_DaiLy2).ToString());
        //        mdadenngay = dteDenNgay.DateTime;
             

        //        DateTime  mdatungay = dteDenNgay.DateTime.AddDays(-30);
        //        mdadenngay = dteDenNgay.DateTime;
        //        //T_DaiLy_ChiTietNhapXuatTon_MotVatTu_MotDaiLy ff = new T_DaiLy_ChiTietNhapXuatTon_MotVatTu_MotDaiLy(mdatungay, mdadenngay, miID_VTHHH, miID_DaiLy);
        //        DaiLy_frmChiTietNhapXuatTon_MotVatTu ff = new DaiLy_frmChiTietNhapXuatTon_MotVatTu();

        //        //this.Hide();
        //        ff.Show();
        //        //this.Show();
        //        Cursor.Current = Cursors.Default;
        //    }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridNhomVTHH_EditValueChanged(object sender, EventArgs e)
        {
            if (gridMaDaiLy.EditValue.ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;               
                int xidnhom = Convert.ToInt32(gridNhomVTHH.EditValue.ToString());
                int kkk = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                LoadDaTa(kkk, xidnhom, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint_ALL = dv1212.ToTable();
            if (mdtPrint_ALL.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {
                mbPrint_ALL = true;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_BaoCao_TonKho ff = new CtyTinLuong.frmPrint_BaoCao_TonKho();
                ff.Show();
            }

        }

        private void btPrint_One_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                miID_VTHHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                mbPrint_One = true;
                DataTable DatatableABC = (DataTable)gridControl2.DataSource;
                CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdtPrint_One = dv1212.ToTable();
                if (mdtPrint_One.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu");
                else
                {
                    mdadenngay = dteDenNgay.DateTime;
                    frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww();
                    ff.Show();
                }
               
            }
            else
            {
                MessageBox.Show("Không có dữ liệu");
            }
           
        }
    }
}
