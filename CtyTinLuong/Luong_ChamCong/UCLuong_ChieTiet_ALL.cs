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
    public partial class UCLuong_ChieTiet_ALL : UserControl
    {
        private void HienThi_ALL()
        {
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            DataTable dt = cls.SelectAll_W_TenNhanVien();
            gridControl1.DataSource = dt;
        }
        private void HienThi()
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
                int ssxxthang = Convert.ToInt32(txtThang.Text.ToString());
                int ssxxnam = Convert.ToInt32(txtNam.Text.ToString());               
                DataTable dt = cls.SelectAll_W_TenNhanVien();
                dt.DefaultView.RowFilter = "Thang=" + ssxxthang + " and Nam=" + ssxxnam + "";
                DataView dv = dt.DefaultView;
                DataTable dxxxx = dv.ToTable();
                if (dxxxx.Rows.Count > 0)
                {
                    gridControl1.DataSource = dxxxx;
                }
                else gridControl1.DataSource = null;
            }
        }
        public UCLuong_ChieTiet_ALL()
        {
            InitializeComponent();
        }

        private void UCLuong_ChieTiet_ALL_Load(object sender, EventArgs e)
        {
            txtThang.ResetText();
            DateTime ngayhomnay = DateTime.Today;
            txtNam.Text = ngayhomnay.ToString("yyyy");
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCLuong_ChieTiet_ALL_Load( sender,  e);
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
           
        }
    }
}
