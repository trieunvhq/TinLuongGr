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
    public partial class DaiLy_BangLuong : Form
    {
        DateTime ngaybatdau, ngayketthuc;
        public static bool mbPrint_ALL, mbPrint_RutGon;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayThang;
        public static int miThang, miNam;
        public static double mdbSumTongTien, mdbSumTamUng, mdbSumThucNhan;
        public DaiLy_BangLuong()
        {
            InitializeComponent();
        }
        private void HienThi_GridConTrol_2(int xxID_DaiLy, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl2.DataSource = null;
            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            //DataTable dt_luong = cls1.SA_ID_DaiLy_TinhLuong(xxID_DaiLy, xxtungay, xxdenngay);
            DataTable dt_luong = cls1.SA_ID_DaiLy_TinhLuong_SUM(xxID_DaiLy, xxtungay, xxdenngay);
            gridControl2.DataSource = dt_luong;
        }
        private void LoadDaTa(int thang, int nam, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;

            DataTable dt2 = new DataTable();
         
            dt2.Columns.Add("ID_DaiLy", typeof(string));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("TongTien", typeof(double));
            dt2.Columns.Add("SoTien_TamUng", typeof(double));          
            dt2.Columns.Add("ThucNhan", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));

            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt3 = cls1.SD_w_TU(thang, nam, xxtungay, xxdenngay);
            if(dt3.Rows.Count>0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    double tongtienxx = Convert.ToDouble(dt3.Rows[i]["TongTien"].ToString());
                    double SoTien_TamUngxxx = Convert.ToDouble(dt3.Rows[i]["SoTien_TamUng"].ToString());
                    DataRow _ravi = dt2.NewRow();

                    _ravi["ID_DaiLy"] = dt3.Rows[i]["ID_DaiLy"].ToString();
                    _ravi["TongTien"] = tongtienxx;
                    _ravi["SoTien_TamUng"] = SoTien_TamUngxxx;
                    _ravi["ThucNhan"] = tongtienxx- SoTien_TamUngxxx;                 
                    _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                    _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                    _ravi["HienThi"] = "1";
                    dt2.Rows.Add(_ravi);
                }
            }
            gridControl1.DataSource = dt2;
        }
        private void DaiLy_BangLuong_Load(object sender, EventArgs e)
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();  
            txtThang.Text = (DateTime.Now.Month).ToString();
            Cursor.Current = Cursors.Default;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
           
            if (txtNam.Text!="" & txtThang.Text != "" )
            {
                int xxthang = Convert.ToInt32(txtThang.Text.ToString());
                int xxnam = Convert.ToInt32(txtNam.Text.ToString());
                clsNgayThang cls = new CtyTinLuong.clsNgayThang();
                ngaybatdau = cls.GetFistDayInMonth(xxnam, xxthang);
                ngayketthuc = cls.GetLastDayInMonth(xxnam, xxthang);
                LoadDaTa(xxthang, xxnam,ngaybatdau, ngayketthuc);
            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void btPrint_RutGon_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();
            if (mdtPrint.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {
                mbPrint_ALL = false;
                mbPrint_RutGon = true;
                mdaNgayThang = DateTime.Now;
                miThang = Convert.ToInt32(txtThang.Text);
                miNam = Convert.ToInt32(txtNam.Text);
                frmPrint_LuongDaiLy_TrongThang ff = new frmPrint_LuongDaiLy_TrongThang();
                ff.ShowDialog();
            }
        }

        private void btPrint_ALL_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dt27hhhdshjj = dv1212.ToTable();

          
           
            string shienthi = "1";
            
            mdbSumTongTien = Convert.ToDouble(dt27hhhdshjj.Compute("sum(TongTien)", "HienThi=" + shienthi + ""));
            mdbSumTamUng = Convert.ToDouble(dt27hhhdshjj.Compute("sum(SoTien_TamUng)", "HienThi=" + shienthi + ""));
            mdbSumThucNhan = Convert.ToDouble(dt27hhhdshjj.Compute("sum(ThucNhan)", "HienThi=" + shienthi + ""));
           
            if (DatatableABC.Rows.Count == 0)
                MessageBox.Show("Không có dữ liệu");
            else
            {
                mbPrint_ALL = true;
                mbPrint_RutGon = false;

           
               

                int xxthang = Convert.ToInt32(txtThang.Text.ToString());
                int xxnam = Convert.ToInt32(txtNam.Text.ToString());
                clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
                mdtPrint = cls.SA_TinhLuong_print_ALL(xxthang, xxnam, ngaybatdau, ngayketthuc);            
                mdaNgayThang = DateTime.Now;
                miThang = Convert.ToInt32(txtThang.Text);
                miNam = Convert.ToInt32(txtNam.Text);
                frmPrint_LuongDaiLy_TrongThang ff = new frmPrint_LuongDaiLy_TrongThang();
                ff.ShowDialog();

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString()!="")
            {
                int xxID_ = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());               
                HienThi_GridConTrol_2(xxID_, ngaybatdau, ngayketthuc);
            }
        }
    }
}
