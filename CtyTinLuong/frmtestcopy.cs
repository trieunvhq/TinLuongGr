using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmtestcopy : Form
    {
        public frmtestcopy()
        {
            InitializeComponent();
        }
        private void load_locup()
        {
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataSet dtset = cls.H_LockUp_PhieuSanXuat_thang8();

            gridMaNhanVien.DataSource = dtset.Tables[2];
            gridMaNhanVien.ValueMember = "ID_NhanSu";
            gridMaNhanVien.DisplayMember = "MaNhanVien";

            gridControl1.DataSource = dtset.Tables[2]; ;       
        }
        private void frmtestcopy_Load(object sender, EventArgs e)
        {
            load_locup();           
        }

        

        private void bandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 4)
            //    e.Handled = true;
            //if (e.KeyData == (Keys.C | Keys.Control))
            //    e.Handled = true;
        }
        int iID_nhanvien;
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            //bool handled = false;
            GridView gridView = gridControl1.FocusedView as GridView;
            DataRow row = gridView.GetDataRow(bandedGridView1.FocusedRowHandle);
            

            if (bandedGridView1.FocusedRowHandle == bandedGridView1.RowCount - 1)
                return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                iID_nhanvien = Convert.ToInt32(row["ID_NhanSu"].ToString());
                tenNhanvie_ = row["TenNhanVien"].ToString();
                e.Handled = true;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_NhanSu, iID_nhanvien);
                bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenNhanVien, tenNhanvie_);                             
                e.Handled = true;
            }

           
        }
       

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_NhanSu)
            {
                bandedGridView1.SetRowCellValue(e.RowHandle, clTenNhanVien, tenNhanvie_);

            }
        }
        string tenNhanvie_ = "";
        private void gridMaNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                tenNhanvie_ = row["TenNhanVien"].ToString();
                
            }
            catch
            { }
        }

        private void bandedGridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            bandedGridView1.SetRowCellValue(e.RowHandle, clID_NhanSu, iID_nhanvien);
            bandedGridView1.SetRowCellValue(e.RowHandle, clTenNhanVien, tenNhanvie_);           
        }
    }
}
