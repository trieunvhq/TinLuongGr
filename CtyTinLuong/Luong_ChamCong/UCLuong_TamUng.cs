using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCLuong_TamUng : UserControl
    {
        public static int miiiiID_TamUng;
        public static bool mbThemMoiTamUng;

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
        private void HienThi()
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                DateTime ngaydautien, ngaycuoicung;
                // DateTime ngayhomnay = 
                int thang = Convert.ToInt16(txtThang.Text.ToString());
                int nam = Convert.ToInt16(txtNam.Text.ToString());
                ngaydautien = GetFistDayInMonth(nam, thang);
                ngaycuoicung = GetLastDayInMonth(nam, thang);
                clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                DataTable dt = cls.SelectAll_W_tenNhanVien();
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                DataView dv = dt.DefaultView;
                dv.Sort = "NgayChungTu DESC";
                DataTable dxxxx = dv.ToTable();
                dxxxx.DefaultView.RowFilter = " NgayChungTu<='" + ngaycuoicung + "'";
                DataView dvxx = dxxxx.DefaultView;
                DataTable dt22xxx = dvxx.ToTable();
                dt22xxx.DefaultView.RowFilter = " NgayChungTu>='" + ngaydautien + "'";
                gridControl1.DataSource = dt22xxx;
            }


        }
        private void HienThi_ALL()
        {
            clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
            DataTable dt = cls.SelectAll_W_tenNhanVien();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            dv.Sort = "NgayChungTu DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }
        public UCLuong_TamUng()
        {
            InitializeComponent();
        }

        private void UCLuong_TamUng_Load(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;           
            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
           
            txtNam.Text = nam.ToString();
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCLuong_TamUng_Load( sender,  e);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_TamUng).ToString() != "")
            {
                mbThemMoiTamUng = false;
                miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
                frmChiTietTamUng ff = new CtyTinLuong.frmChiTietTamUng();
                ff.Show();
            }
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                HienThi();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;
            //miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
            frmChiTietTamUng ff = new CtyTinLuong.frmChiTietTamUng();
            ff.Show();
        }
    }
}
