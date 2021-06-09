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
    public partial class UCSanXuat_DinhMuc_ToGapDan : UserControl
    {
         
        public static bool mb_TheMoi_DinhMuc_ToGapDan;

        public static int miID_DinhMuc_ToGapDan;
        private void HienThi()
        {
            clsDinhMuc_DinhMuc_ToGapDan cls = new clsDinhMuc_DinhMuc_ToGapDan();
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

        public UCSanXuat_DinhMuc_ToGapDan()
        {
            InitializeComponent();
        }

        private void UCSanXuat_DinhMuc_ToGapDan_Load(object sender, EventArgs e)
        {
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

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCSanXuat_DinhMuc_ToGapDan_Load( sender,  e);
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
                clsDinhMuc_DinhMuc_ToGapDan cls = new clsDinhMuc_DinhMuc_ToGapDan();               

                cls.iID_DinhMuc_ToGapDan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_ToGapDan).ToString());
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
                if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_ToGapDan).ToString() != "")
                {
                    miID_DinhMuc_ToGapDan= Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_ToGapDan).ToString());
                    mb_TheMoi_DinhMuc_ToGapDan = false;
                    frmDinhMuc_ChiTietDinhMucToGapDan ff = new frmDinhMuc_ChiTietDinhMucToGapDan();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int iIiID_DinhMucNPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_ToGapDan).ToString());
                clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                cls.iID_DinhMuc_ToGapDan = iIiID_DinhMucNPL;
                DataTable dt = cls.SelectAll_W_ID_DinhMuc_ToGapDan();
                
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

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mb_TheMoi_DinhMuc_ToGapDan = true;
            frmDinhMuc_ChiTietDinhMucToGapDan ff = new frmDinhMuc_ChiTietDinhMucToGapDan();
            ff.Show();
        }
    }
}
