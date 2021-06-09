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
    public partial class frmNhanSu : Form
    {
        public static bool mbThemMoi,mbSua, mbCopy;
        public static int miID_Sua_NhanVien;
        int i = 0;
        private void HienThi()
        {
            string shocviec = "Học việc";
            string sthuviec = "Thử việc";
            string schinhthuc = "Chính thức";
            clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
            DataTable dt = cls.SelectAll_hienThi_Gridcontrol();
            if (checked_ALL.Checked == true)
            {
               

                if (i == 0)
                    dt.DefaultView.RowFilter = "TonTai=True";
                if (i == 1) // ban giam doc
                    dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='1'";
                if (i == 2) // hành chính
                    dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='2'";
                if (i == 3) // cong nhan
                    dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='3'";
                if (i == 4) //  
                    dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='"+shocviec+"'";
                if (i == 5) //  
                    dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='"+sthuviec+"'";
                if (i == 6) //  
                    dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='"+schinhthuc+"'";
                if (i == 7) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='8'";
                if (i == 8) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='22'";
                if (i == 9) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='4'";
                if (i == 10) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='5'";
                if (i == 11) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='13'";
                if (i == 12) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='6'";
                if (i == 13) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='14'";
                if (i == 14) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='16'";
                if (i == 15) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='12'";
                if (i == 16) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='9'";
                if (i == 17) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='10'";
                if (i == 18) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='21'";
                if (i == 19) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='11'";
                if (i == 20) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='20'";
                if (i == 21) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='17'";
                if (i == 22) //  
                    dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='18'";

                DataView dv = dt.DefaultView;
                gridControl1.DataSource = dv;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    if (i == 0)
                        dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
                    if (i == 1) // ban giam doc
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='1' and NgungTheoDoi=false";
                    if (i == 2) // hành chính
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='2' and NgungTheoDoi=false";
                     
                
                    if (i == 3) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='3' and NgungTheoDoi=false";
                    if (i == 4) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='" + shocviec + "' and NgungTheoDoi=false";
                    if (i == 5) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong = '" + sthuviec + "' and NgungTheoDoi=false";
                    if (i == 6) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='" + schinhthuc + "' and NgungTheoDoi=false";
                    if (i == 7) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='8' and NgungTheoDoi=false";
                    if (i == 8) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='22' and NgungTheoDoi=false";
                    if (i == 9) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='4' and NgungTheoDoi=false";
                    if (i == 10) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='5' and NgungTheoDoi=false";
                    if (i == 11) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='13' and NgungTheoDoi=false";
                    if (i == 12) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='6' and NgungTheoDoi=false";
                    if (i == 13) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='14' and NgungTheoDoi=false";
                    if (i == 14) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='16' and NgungTheoDoi=false";
                    if (i == 15) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='12' and NgungTheoDoi=false";
                    if (i == 16) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='9' and NgungTheoDoi=false";
                    if (i == 17) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='10' and NgungTheoDoi=false";
                    if (i == 18) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='21' and NgungTheoDoi=false";
                    if (i == 19) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='11' and NgungTheoDoi=false";
                    if (i == 20) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='20' and NgungTheoDoi=false";
                    if (i == 21) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='17' and NgungTheoDoi=false";
                    if (i == 22) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='18' and NgungTheoDoi=false";


                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    if (i == 0)
                        dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=true";
                    if (i == 1) // ban giam doc
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='1' and NgungTheoDoi=true";
                    if (i == 2) // hành chính
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='2' and NgungTheoDoi=true";
                    if (i == 3) // cong nhan
                        dt.DefaultView.RowFilter = "TonTai=True and ID_ChucVu='3' and NgungTheoDoi=true";
                    //LoaiHopDongLaoDong='" + shocviec + "'
                    // LoaiHopDongLaoDong = '" + sthuviec + "'
                    //LoaiHopDongLaoDong='" + schinhthuc + "'

                    if (i == 4) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='" + shocviec + "' and NgungTheoDoi=true";
                    if (i == 5) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong = '" + sthuviec + "' and NgungTheoDoi=true";
                    if (i == 6) //  
                        dt.DefaultView.RowFilter = "TonTai=True and LoaiHopDongLaoDong='" + schinhthuc + "' and NgungTheoDoi=true";
                    if (i == 7) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='8' and NgungTheoDoi=true";
                    if (i == 8) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='22' and NgungTheoDoi=true";
                    if (i == 9) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='4' and NgungTheoDoi=true";
                    if (i == 10) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='5' and NgungTheoDoi=true";
                    if (i == 11) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='13' and NgungTheoDoi=true";
                    if (i == 12) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='6' and NgungTheoDoi=true";
                    if (i == 13) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='14' and NgungTheoDoi=true";
                    if (i == 14) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='16' and NgungTheoDoi=true";
                    if (i == 15) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='12' and NgungTheoDoi=true";
                    if (i == 16) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='9' and NgungTheoDoi=true";
                    if (i == 17) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='10' and NgungTheoDoi=true";
                    if (i == 18) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='21' and NgungTheoDoi=true";
                    if (i == 19) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='11' and NgungTheoDoi=true";
                    if (i == 20) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='20' and NgungTheoDoi=true";
                    if (i == 21) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='17' and NgungTheoDoi=true";
                    if (i == 22) //  
                        dt.DefaultView.RowFilter = "TonTai=True and ID_BoPhan='18' and NgungTheoDoi=true";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }

            }

        }

        public frmNhanSu()
        {
            InitializeComponent();
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            HienThi();
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
            i = 0;
            HienThi();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 4;
            HienThi();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 5;
            HienThi();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 6;
            HienThi();
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 0;
            HienThi();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 7;
            HienThi();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i =8;
            HienThi();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 9;
            HienThi();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 10;
            HienThi();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 11;
            HienThi();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 12;
            HienThi();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 13;
            HienThi();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 14;
            HienThi();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 15;
            HienThi();
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i =16;
            HienThi();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i =17;
            HienThi();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 18;
            HienThi();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 19;
            HienThi();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 20;
            HienThi();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 21;
            HienThi();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 22;
            HienThi();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            i = 0;
            HienThi();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString() != "")
                {
                    miID_Sua_NhanVien = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString());
                    mbThemMoi = false;
                    mbSua = true;
                    mbCopy = false;
                    frmChiTietNhanSu ff = new frmChiTietNhanSu();
                    ff.Show();

                }
            }
            catch
            {

            }
        }

        private void btXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            frmChiTietNhanSu ff = new frmChiTietNhanSu();
            ff.Show();
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
            if(e.Column==clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsNhanSu_tbNhanSu cls1 = new clsNhanSu_tbNhanSu();
                cls1.iID_NhanSu = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString());
                cls1.Delete_W_TonTai();
                MessageBox.Show("Đã xóa");
                HienThi();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                cls.iID_NhanSu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btCoPy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString() != "")
            {
                miID_Sua_NhanVien = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhanSu).ToString());
                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                frmChiTietNhanSu ff = new frmChiTietNhanSu();
                ff.Show();

            }
        }
    }
}
