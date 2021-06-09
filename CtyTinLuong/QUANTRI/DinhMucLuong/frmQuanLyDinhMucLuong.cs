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
    public partial class frmQuanLyDinhMucLuong : Form
    {
        public static bool mb_TheMoi_DinhMucLuongCongNhat;
        public static string msTenDinhMucLuongCongNhat;
        public static int miID_Sua_DinhMucLuongCongNhat;
        private void HienThi()
        {
            clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
            DataTable dt = cls.SelectAll();

            if (checked_ALL.Checked == true)
            {
                dt.DefaultView.RowFilter = " TonTai= True";
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";

                }
                else
                {
                    dt.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=true";

                }

            }
            DataView dv = dt.DefaultView;           
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }
        public frmQuanLyDinhMucLuong()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmQuanLyDinhMucLuong_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            mb_TheMoi_DinhMucLuongCongNhat = false;
            HienThi();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if(Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString())!=7)
                {
                    clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
                    cls.iID_DinhMucLuong_CongNhat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
                    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                    cls.Update_NgungTheoDoi();
                }
               
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    clsHUU_DinhMucLuong_CongNhat cls1 = new clsHUU_DinhMucLuong_CongNhat();
                    cls1.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
                    cls1.Delete_W_TonTai();
                    MessageBox.Show("Đã xóa");
                    HienThi();
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString()) != 7)
                {
                    miID_Sua_DinhMucLuongCongNhat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
                    msTenDinhMucLuongCongNhat = gridView1.GetFocusedRowCellValue(clMaDinhMucLuongCongNhat).ToString();
                    mb_TheMoi_DinhMucLuongCongNhat = false;
                    frmChiTietDinhMucLuongCongNhat_Newwwwww ff = new frmChiTietDinhMucLuongCongNhat_Newwwwww();
                    ff.Show();
                }
                else
                {
                    MessageBox.Show("Định mức 0\n không cho sửa");
                }
                   
            }
            catch
            {

            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mb_TheMoi_DinhMucLuongCongNhat = true;
            frmChiTietDinhMucLuongCongNhat_Newwwwww ff = new frmChiTietDinhMucLuongCongNhat_Newwwwww();
            ff.Show();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmQuanLyDinhMucLuong_Load(sender, e);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    decimal category = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["LuongCoDinh"]));
            //    if (category != 0)
            //    {
            //        e.Appearance.BackColor = Color.Orange;
            //        //e.Appearance.BackColor = Color.Salmon;
            //        //e.Appearance.BackColor2 = Color.SeaShell;

            //    }
            //}
        }
    }
}
