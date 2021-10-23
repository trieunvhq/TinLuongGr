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
    public partial class UC_DongKien_XuatKho_BenDaiLy : UserControl
    {
        public UC_DongKien_XuatKho_BenDaiLy()
        {
            InitializeComponent();
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbXuatKho cls = new CtyTinLuong.clsDongKien_TbXuatKho();
            DataTable dt = cls.H_DongKien_XK_SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
        private void HienThiGridControl_2(int xxID_xuatkho)
        {
            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxID_xuatkho);
            gridControl3.DataSource = dt;
            cls2.Dispose();
            dt.Dispose();

        }
        private void UC_DongKien_XuatKho_BenDaiLy_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_DongKien_XuatKho_BenDaiLy_Load( sender,  e);
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDongKien).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDongKien).ToString());
                //DateTime dte = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayChungTu).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDongKien).ToString() != "")
            {
                int iiidnhapkho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDongKien).ToString());
                clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
                cls1.iID_XuatKhoDongKien = iiidnhapkho;
                cls1.Delete();

                clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
                cls2.H_DongKien_XK_Delete_ID_XK(iiidnhapkho);
                MessageBox.Show("Đã xoá");
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }
    }
}
