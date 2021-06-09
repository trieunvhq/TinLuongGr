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
    public partial class frmQuanLyDonViTinh : Form
    {
        private void HienThi()
        {
            clsTbDonViTinh cls = new clsTbDonViTinh();
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
        public frmQuanLyDonViTinh()
        {
            InitializeComponent();
        }

        private void frmQuanLyDonViTinh_Load(object sender, EventArgs e)
        {
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            checkTheoDoi.Checked = true;
            HienThi();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsTbDonViTinh cls1 = new clsTbDonViTinh();
                cls1.iID_DonViTinh = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DonViTinh).ToString());
                cls1.Delete_W_TonTai();
                MessageBox.Show("Đã xóa");
                HienThi();
            }
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

       
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //try
            //{

            clsTbDonViTinh cls = new clsTbDonViTinh();
           
            cls.sDonViTinh = gridView1.GetFocusedRowCellValue(clDonViTinh).ToString().Trim();
            cls.bTonTai = true;
            //if (gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString() == "")
            //    cls.bNgungTheoDoi = false;
            //else
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
            if (gridView1.GetFocusedRowCellValue(clID_DonViTinh).ToString() == "")
                cls.Insert();
            else
            {
                cls.iID_DonViTinh = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DonViTinh).ToString());
                cls.Update();
            }
            //}
            //catch
            //{

            //}

        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clDonViTinh)
            {
                if (gridView1.GetFocusedRowCellValue(clID_DonViTinh).ToString() == "")
                    gridView1.SetRowCellValue(e.RowHandle, clNgungTheoDoi, false);
                   
                
            }
        }
    }
}
