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
    public partial class KhoNPL_frmNPL : Form
    {
        private void HienThi_Caption()
        {
            clsMH_tbMuaHang cls1 = new clsMH_tbMuaHang();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and MuaHangNhapKho=True and GuiDuLieu=True and TrangThaiNhapKho=False and check_BaoVe =True and check_LaiXe=True";
            DataView dv1 = dt1.DefaultView;           
            DataTable dxxxx1 = dv1.ToTable();
            int k1 = dxxxx1.Rows.Count;
            if (k1 > 0)
            {
                navNhapKho_TuMuaHang.Caption = "Chờ nhập kho từ MH (" + k1.ToString() + ")";
                navNhapKho_TuMuaHang.Appearance.Font = new Font(navNhapKho_TuMuaHang.Appearance.Font, FontStyle.Bold);
            }

          

            //clsHUU_LenhSanXuat cls3 = new clsHUU_LenhSanXuat();
            //DataTable dt3 = cls3.SelectAll_XuatkhoNPL();
            ////dt3.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and GuiDuLieu=True and TrangThai_XuatKho_VatTuPhu=False";
            //DataView dv3 = dt3.DefaultView;
            //DataTable dxxxx3 = dv3.ToTable();
            //int k3 = dxxxx3.Rows.Count;
            //if (k3 > 0)
            //{
            //    navXuatKhoLSX_ICD.Caption = "Xuất kho LSX I-C-Đ (" + k3.ToString() + ")";
            //    navXuatKhoLSX_ICD.Appearance.Font = new Font(navXuatKhoLSX_ICD.Appearance.Font, FontStyle.Bold);
            //}

           



        }
        public KhoNPL_frmNPL()
        {
            InitializeComponent();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UC_KhoNVL_frmDaNhapKho uccc_DaNhapKho = new UC_KhoNVL_frmDaNhapKho();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            UC_KhoNVL_frmChoNhapKho uccc_ChoNhapKho = new UC_KhoNVL_frmChoNhapKho();
            uccc_ChoNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_ChoNhapKho);
            uccc_ChoNhapKho.BringToFront();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
            
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoNPL_frmNPL_Load(object sender, EventArgs e)
        {
            HienThi_Caption();

        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCNPL_XuatKho_TheoLenhSanXuat_mayIN uccc_XuatKho= new UCNPL_XuatKho_TheoLenhSanXuat_mayIN();
            uccc_XuatKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_XuatKho);
            uccc_XuatKho.BringToFront();
        }

        private void navBarItem7_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCKhoNPL_DaXuatKho uccc_XuatKho = new UCKhoNPL_DaXuatKho();
            uccc_XuatKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_XuatKho);
            uccc_XuatKho.BringToFront();
        }

        

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBaoCaoNXT ff = new frmBaoCaoNXT();
            ff.Show();
            
        }

      

        private void navBarItem3_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong uccc_XuatKho = new UCNPL_XuatKhoPhuLieuRaDaiLyGiaCong();
            uccc_XuatKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_XuatKho);
            uccc_XuatKho.BringToFront();
        }

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            ff.Show();
        }

     
    

        private void navBarItem7_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCNPL_NhapKho_Khacccccccccccc ucc = new UCNPL_NhapKho_Khacccccccccccc();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCNPL_XuatKho_Khacccccccccccccc ucc = new UCNPL_XuatKho_Khacccccccccccccc();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem2_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCNPL_XuatKho_GapDan ucc = new UCNPL_XuatKho_GapDan();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }
    }
}
