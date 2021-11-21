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
    public partial class UC_DongKien_NhapKho : UserControl
    {
        public UC_DongKien_NhapKho()
        {
            InitializeComponent();
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbNhapKho cls = new CtyTinLuong.clsDongKien_TbNhapKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
        private void UC_DongKien_NhapKho_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);

            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
            //catch
            //{

            //}
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
            //catch
            //{

            //}
        }
               
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
           
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }
    }
}
