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
    public partial class frmVatTuHangHoa : Form
    {
       
        public static int miID_Sua_VTHH;
        int i = 0;
        public static bool mbThemMoi, mbSua, mbCopy;
        private void HienThi()
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            if (checked_ALL.Checked == true)
            {
                if (i == 0)
                    dt.DefaultView.RowFilter = "TonTai=True";
                if (i == 1) // 
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='5'";
                if (i == 2) // 
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='7'";
                if (i == 3) //
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='8'";
                if (i == 4) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='1'";
                if (i == 5) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='9'";
                if (i == 6) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='10'";
                if (i == 7) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='3'";
                if (i == 8) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='4'";
                if (i == 9) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='11'";
                if (i == 10) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='12'";
                if (i == 11) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='2'";
                if (i == 12) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='13'";


                DataView dv = dt.DefaultView;
                gridControl1.DataSource = dv;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    if (i == 0)
                        dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";

                    if (i == 1) // 
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='5' and NgungTheoDoi=false";
                    if (i == 2) // 
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='7' and NgungTheoDoi=false";
                    if (i == 3) //
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='8' and NgungTheoDoi=false";
                    if (i == 4) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='1' and NgungTheoDoi=false";
                    if (i == 5) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='9' and NgungTheoDoi=false";
                    if (i == 6) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='10' and NgungTheoDoi=false";
                    if (i == 7) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='3' and NgungTheoDoi=false";
                    if (i == 8) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='4' and NgungTheoDoi=false";
                    if (i == 9) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='11' and NgungTheoDoi=false";
                    if (i == 10) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='12' and NgungTheoDoi=false";
                    if (i == 11) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='2' and NgungTheoDoi=false";
                    if (i == 12) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='13' and NgungTheoDoi=false";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    if (i == 0)
                        dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=true";
                    if (i == 1) // 
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='5' and NgungTheoDoi=true";
                    if (i == 2) // 
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='7' and NgungTheoDoi=true";
                    if (i == 3) //
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='8' and NgungTheoDoi=true";
                    if (i == 4) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='1' and NgungTheoDoi=true";
                    if (i == 5) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='9' and NgungTheoDoi=true";
                    if (i == 6) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='10' and NgungTheoDoi=true";
                    if (i == 7) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='3' and NgungTheoDoi=true";
                    if (i == 8) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='4' and NgungTheoDoi=true";
                    if (i == 9) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='11' and NgungTheoDoi=true";
                    if (i == 10) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='12' and NgungTheoDoi=true";
                    if (i == 11) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='2' and NgungTheoDoi=true";
                    if (i == 12) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_MaNhom='13' and NgungTheoDoi=true";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }

            }

        }
        public frmVatTuHangHoa()
        {
            InitializeComponent();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVatTuHangHoa_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                miID_Sua_VTHH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                frmChiTietVTHH ff = new frmChiTietVTHH();
                ff.Show();

            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                cls1.Delete_W_TonTai();

                MessageBox.Show("Đã xóa");
                //HienThi();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbCopy = false;
            mbSua = false;
            frmChiTietVTHH ff = new frmChiTietVTHH();
            ff.Show();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 1;
            HienThi();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 2;
            HienThi();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 3;
            HienThi();
        }

        private void navBarItem26_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 4;
            HienThi();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 5;
            HienThi();
        }

        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 6;
            HienThi();
        }

        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 7;
            HienThi();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 8;
            HienThi();
        }

        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 9;
            HienThi();
        }

        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 10;
            HienThi();
        }

        private void navBarItem31_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 11;
            HienThi();
        }

        private void navBarItem32_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 0;
            HienThi();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmVatTuHangHoa_Load(sender, e);
        }

        private void btCoPy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                miID_Sua_VTHH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                frmChiTietVTHH ff = new frmChiTietVTHH();
                ff.Show();

            }
        }
    }
}
