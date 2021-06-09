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
    public partial class SanLuong_To_May_IN : Form
    {
        public static DataTable mdtPrint;
        public static bool mbPrint_ALL, mbPrint_RutGon;

        public static int xxximay_in_1_Cat_2_dot_3=0;
        public static string xxsotrang;
        public static DateTime mdatungay, mdadenngay;
        public static int miID_VTHH_Ra;
        private int _SoTrang = 1;
        private bool isload = false;
        public void LoadData(int sotrang, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            DataTable dt2 = new DataTable();
            dt2 = new DataTable();
         
            dt2.Columns.Add("ID_VTHH_Ra", typeof(string));         
            dt2.Columns.Add("MaVT_Ra", typeof(string));           
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));         
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));           
             
            dt2.Columns.Add("SanLuong_Tong", typeof(double));
            dt2.Columns.Add("SanLuong_Thuong", typeof(double));
            dt2.Columns.Add("SanLuong_TangCa", typeof(double));
            dt2.Columns.Add("PhePham", typeof(double));

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();           
            
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();            
           

            DataTable dtID_VTHH_Ra = cls.SelectAll_distinct_W_ID_VTHH_Ra();
            if (dtID_VTHH_Ra.Rows.Count > 0)
            {
                for (int i = 0; i < dtID_VTHH_Ra.Rows.Count; i++)
                {
                    int ID_VTHH_Raxx = Convert.ToInt32(dtID_VTHH_Ra.Rows[i]["ID_VTHH_Ra"].ToString());
                    cls.iID_VTHH_Ra = ID_VTHH_Raxx;
                    DataTable dtxxxx = new DataTable();
                    if(xxximay_in_1_Cat_2_dot_3==1)
                    dtxxxx = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_IN(ID_VTHH_Raxx, xxtungay, xxdenngay);
                    else if (xxximay_in_1_Cat_2_dot_3 == 2)
                        dtxxxx = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_CAT(ID_VTHH_Raxx, xxtungay, xxdenngay);
                    if (dtxxxx.Rows.Count>0)
                    {
                        if(Convert.ToDouble(dtxxxx.Rows[0]["SanLuong_Tong"].ToString())>0)
                        {
                            DataRow _ravi = dt2.NewRow();
                            clsvt.iID_VTHH = ID_VTHH_Raxx;
                            DataTable dtvt_Ra = clsvt.SelectOne();
                            string MaVT_Ra = clsvt.sMaVT.Value;
                            string DonViTinh_Ra = clsvt.sDonViTinh.Value;
                            string TenVatTu_Ra = clsvt.sTenVTHH.Value;

                            _ravi["ID_VTHH_Ra"] = ID_VTHH_Raxx;
                            _ravi["MaVT_Ra"] = MaVT_Ra;
                            _ravi["DonViTinh_Ra"] = DonViTinh_Ra;
                            _ravi["TenVatTu_Ra"] = TenVatTu_Ra;
                            _ravi["SanLuong_Tong"] = Convert.ToDouble(dtxxxx.Rows[0]["SanLuong_Tong"].ToString());
                            _ravi["SanLuong_Thuong"] = Convert.ToDouble(dtxxxx.Rows[0]["SanLuong_Thuong"].ToString());
                            _ravi["SanLuong_TangCa"] = Convert.ToDouble(dtxxxx.Rows[0]["SanLuong_TangCa"].ToString());
                            _ravi["PhePham"] = Convert.ToDouble(dtxxxx.Rows[0]["PhePham"].ToString());
                            dt2.Rows.Add(_ravi);
                        }
                        
                    }
                   
                }
                gridControl1.DataSource = dt2;
            }

            isload = false;
        }
        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            LoadData(sotrang_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {

            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu())
            {
                DataTable dt_ = cls.SelectAll_Tinh_SoPhieu_new(xxtungay, xxdenngay);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public SanLuong_To_May_IN()
        {
            InitializeComponent();
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_PhieuSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if(gridView2.GetFocusedRowCellValue(clID_VTHH_Ra).ToString()!="")
            {
                miID_VTHH_Ra = Convert.ToInt32(gridView2.GetFocusedRowCellValue(clID_VTHH_Ra).ToString());
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                SanLuong_ToMay_ChiTiet ff = new SanLuong_ToMay_ChiTiet();
                ff.Show();

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();          
            if (mdtPrint.Rows.Count > 0)
            {              
                mbPrint_RutGon = true;
                mbPrint_ALL = false;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;               
                frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                ff.Show();

            }
        }

        private void btprint2_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
           
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_RutGon = false;
                mbPrint_ALL = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;               
                frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                ff.Show();

            }
           
        }

        private void SanLuong_To_May_IN_Load(object sender, EventArgs e)
        {
            xxximay_in_1_Cat_2_dot_3 = SanXuat_frmQuanLySanXuat.imay_in_1_Cat_2_dot_3;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));

            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime= GetFistDayInMonth(nam, thang);
            
            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
         
            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
    }
}
