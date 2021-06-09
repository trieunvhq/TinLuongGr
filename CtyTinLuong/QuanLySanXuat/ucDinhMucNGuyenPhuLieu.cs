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
    public partial class ucDinhMucNGuyenPhuLieu : UserControl
    {
        public static bool mb_TheMoi_DinhMuc_NPL;
  
        public static int miID_DinhMuc_NPL;
        private void HienThi()
        {
            clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
            DataTable dt = cls.SelectAll();
            if (checked_ALL.Checked == true)
            {

                dt.DefaultView.RowFilter = "TonTai=True";
                DataView dv = dt.DefaultView;
                gridControl1.DataSource = dv;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=True";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;

                }


            }
        }

        public ucDinhMucNGuyenPhuLieu()
        {
            InitializeComponent();
        }

        private void ucDinhMucNGuyenPhuLieu_Load(object sender, EventArgs e)
        {
            clBooL_NguyenPhuLieu.Caption = "Vật tư\nphụ";
      
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.VisibleIndex = 4;
            HienThi();
        }

        private void checked_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_ALL.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checkTheoDoi.Checked = false;
            }
            HienThi();
        }

        private void checkTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTheoDoi.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void checkNgungTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNgungTheoDoi.Checked == true)
            {
                checkTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls.iID_DinhMuc_NPL = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString() != "")
                {
                    miID_DinhMuc_NPL = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());                   
                    mb_TheMoi_DinhMuc_NPL = false;
                    frmChiTietDinhMucNPL ff = new frmChiTietDinhMucNPL();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls1.iID_DinhMuc_NPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                cls1.Delete();

                MessageBox.Show("Đã xóa");
                HienThi();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int iIiID_DinhMucNPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                clsDinhMuc_ChiTiet_DM_NPL cls = new clsDinhMuc_ChiTiet_DM_NPL();
                cls.iID_DinhMuc_NPL = iIiID_DinhMucNPL;
                DataTable dt = cls.SelectAll_HienThi_ChiTietDinhMuc();


                dt.DefaultView.RowFilter = "TonTai=True";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();

                gridControl2.DataSource = dt3;
            }
            catch
            {

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            ucDinhMucNGuyenPhuLieu_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mb_TheMoi_DinhMuc_NPL = true;
            frmChiTietDinhMucNPL ff = new frmChiTietDinhMucNPL();
            ff.Show();
        }
    }
}
