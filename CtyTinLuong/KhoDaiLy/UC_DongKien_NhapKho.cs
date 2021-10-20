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
            int thang = Convert.ToInt32(DateTime.Today.ToString("MM"));
            int nam = Convert.ToInt32(DateTime.Today.ToString("yyyy"));
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(nam, thang);
           
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void HienThiGridControl_2(int xxIID_NhapKho)
        {
            clsDongKien_TbNhapKho_ChiTietNhapKho cls2 = new clsDongKien_TbNhapKho_ChiTietNhapKho();
            cls2.iID_NhapKho_DongKien = xxIID_NhapKho;
            DataTable dt2 = cls2.H_DongKien_ChiTiet_SO_ID(xxIID_NhapKho);
            gridControl3.DataSource = dt2;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoDongKien).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDongKien).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }
    }
}
