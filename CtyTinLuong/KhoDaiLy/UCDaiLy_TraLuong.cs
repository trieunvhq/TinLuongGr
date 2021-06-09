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
    public partial class UCDaiLy_TraLuong : UserControl
    {
        public static bool mbThemMoiTraLuong;
        public static int mID_TraLuong_Sua;
        private void HienThi()
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                DateTime denngay = dteNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;
                clsDaiLy_TraLuong cls = new CtyTinLuong.clsDaiLy_TraLuong();
                DataTable dt = cls.SelectAll_W_TenDaiLy();
                dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = "NgayChungTu DESC";
                DataTable dxxxx = dv2.ToTable();
                gridControl1.DataSource = dxxxx;
            }

        }
        private void HienThi_ALL()
        {
            DateTime denngay = dteNgay.DateTime;
            DateTime tungay = dteTuNgay.DateTime;
            clsDaiLy_TraLuong cls = new CtyTinLuong.clsDaiLy_TraLuong();
            DataTable dt = cls.SelectAll_W_TenDaiLy();
            DataView dv2 = dt.DefaultView;
            dv2.Sort = "NgayChungTu DESC";
            DataTable dxxxx = dv2.ToTable();
            gridControl1.DataSource = dxxxx;

        }
        public UCDaiLy_TraLuong()
        {
            InitializeComponent();
        }

        private void UCDaiLy_TraLuong_Load(object sender, EventArgs e)
        {
            mbThemMoiTraLuong = true;
            dteNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCDaiLy_TraLuong_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoiTraLuong = true;
            frmLuong_ChiTietTraLuong_DaiLy ff = new frmLuong_ChiTietTraLuong_DaiLy();
            ff.Show();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_TraLuong).ToString() != "")
            {
                mbThemMoiTraLuong = false;
                mID_TraLuong_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TraLuong).ToString());
                frmLuong_ChiTietTraLuong_DaiLy ff = new CtyTinLuong.frmLuong_ChiTietTraLuong_DaiLy();
                ff.Show();
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
