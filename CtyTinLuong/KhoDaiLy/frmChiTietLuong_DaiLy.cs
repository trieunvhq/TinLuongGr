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
    public partial class frmChiTietLuong_DaiLy : Form
    {
        public static int miID_XuatKhoDaiLy;
        public static DataTable mdtPrint_TraLuong_DaiLy;
        public static string msPrintThang ,ssPrintNam;
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
        private void HienThi_ALL()
        {
           
            clsDaiLy_ThamChieu_TinhXuatKho clsxuatkhodaily = new clsDaiLy_ThamChieu_TinhXuatKho();          
            DataTable dtxuatkho = clsxuatkhodaily.SelectAll_NgayChungTu_TenDaiLy_TenVT();
            dtxuatkho.DefaultView.RowFilter = " DaXuatKho=True";
            DataView dvxx = dtxuatkho.DefaultView;
            DataTable dt22xxx = dvxx.ToTable();
            gridControl1.DataSource = dt22xxx;
           
        }
        private void HienThi()
        {
            DateTime ngaydautien, ngaycuoicung;
            int thangxx = Convert.ToInt32(txtThang.Text.ToString());
            int namxx = Convert.ToInt32(txtNam.Text.ToString());
            ngaydautien = GetFistDayInMonth(namxx, thangxx);
            ngaycuoicung = GetLastDayInMonth(namxx, thangxx);

            clsDaiLy_ThamChieu_TinhXuatKho clsxuatkhodaily = new clsDaiLy_ThamChieu_TinhXuatKho();
            DataTable dtxuatkho = clsxuatkhodaily.SelectAll_NgayChungTu_TenDaiLy_TenVT();
            dtxuatkho.DefaultView.RowFilter = " DaXuatKho=True and NgayChungTu<='" + ngaycuoicung + "'";
            DataView dvxx = dtxuatkho.DefaultView;
            DataTable dt22xxx = dvxx.ToTable();
            dt22xxx.DefaultView.RowFilter = " NgayChungTu>='" + ngaydautien + "'";
            DataView dvxx3333 = dt22xxx.DefaultView;
            DataTable dt22xxx333 = dvxx3333.ToTable();
            gridControl1.DataSource = dt22xxx333;       
        }
        public frmChiTietLuong_DaiLy()
        {
            InitializeComponent();
        }

        private void frmChiTietLuong_DaiLy_Load(object sender, EventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM")) - 1;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            //txtThang.Text = thang.ToString();
            txtNam.Text = nam.ToString();
            HienThi_ALL();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmChiTietLuong_DaiLy_Load( sender,  e);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //    if(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString()!="")
            //    {
            //       // mbThemMoi_nhapKhoDaiLy = false;
            //        miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
            //        frmChiTietNhapKho_DaiLy_Sua ff = new frmChiTietNhapKho_DaiLy_Sua();
            //        ff.Show();
            //    }

        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            //{
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdtPrint_TraLuong_DaiLy = dv1212.ToTable();

                msPrintThang =txtThang.Text.ToString();
                ssPrintNam = txtNam.Text.ToString();
                frmPrint_LuongDaiLy_TrongThang ff = new frmPrint_LuongDaiLy_TrongThang();
                ff.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Chọn tháng để in");
            //    return;
            //}
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
                HienThi();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
                    HienThi();
            }
            catch
            {
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
