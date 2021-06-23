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
    public partial class SanXuat_frmQuanLySanXuat : Form
    {
        private bool isload = true;
        UC_SanXuat_PhieuSanXuat ucc;
        Tr_UC_BB_Ktra_DM_HHSX ucc1;
        public static int imay_in_1_Cat_2_dot_3;
        public SanXuat_frmQuanLySanXuat()
        {
            isload = true;
            InitializeComponent();
            isload = false;
            ucc = new UC_SanXuat_PhieuSanXuat(this);
            ucc1 = new Tr_UC_BB_Ktra_DM_HHSX(this);
        }
      

        private void navBarItemPhieuSanXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItemLenhSanXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UC_SanXuat_LenhSanXuat ucc = new UC_SanXuat_LenhSanXuat();         

            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void navBarItemDinhMucDOt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCDinhMucDot ucc = new UCDinhMucDot();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItemDinhMucNPL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucDinhMucNGuyenPhuLieu ucc = new ucDinhMucNGuyenPhuLieu();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
            SanXuat_frmChiTietSoPhieu_RutGon ff = new SanXuat_frmChiTietSoPhieu_RutGon();
            this.Hide();
            ff.ShowDialog();
            this.Show();
        }
        
        private void SanXuat_frmQuanLySanXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

     

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCSanXuat_CaiDatMacDinh ucc = new UCSanXuat_CaiDatMacDinh();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmGuiDuLieuLuongTheoSanLuong ucc = new frmGuiDuLieuLuongTheoSanLuong();
            ucc.Show();
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //frmBaoCaoSanLuongTheoMaHang_IN_CAT_DOT ucc = new frmBaoCaoSanLuongTheoMaHang_IN_CAT_DOT();
            //ucc.Show();
        }



    

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem13_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCSanXuat_DinhMuc_ToGapDan ucc = new UCSanXuat_DinhMuc_ToGapDan();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }
        

        private void navBarItem14_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBaoCaoSanLuong_Theo_CongNhan ucc = new frmBaoCaoSanLuong_Theo_CongNhan();
            ucc.Show();
        }

        private void navBarItem16_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCDinhMucHangNhu ucc = new UCDinhMucHangNhu();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            this.Hide();
            ff.ShowDialog();
            this.Show();
        }

      
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //ucc1.LoadData(1, true);
            //ResetSoTrang_BB();

            ucc1.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc1);
            ucc1.BringToFront();
        }

        private void navSanLuongMayDOT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 3;
            SanLuong_To_DOT_DAP ucc = new SanLuong_To_DOT_DAP();
            this.Hide();
            ucc.ShowDialog();
            this.Show();
        }

        private void navSanLuongMayIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 1;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            this.Hide();
            ucc.ShowDialog();
            this.Show();
        }

        private void navSanLuongMayCAT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 2;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            this.Hide();
            ucc.ShowDialog();
            this.Show();
        }

        private void navLuongSanLuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBaoCaoSanLuong_Theo_CongNhan ucc = new frmBaoCaoSanLuong_Theo_CongNhan();
            this.Hide();
            ucc.ShowDialog();
            this.Show();
        }

        private void nbSL_CTL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SanLuong_ChiTiet_Luong ff = new SanLuong_ChiTiet_Luong();
            this.Hide();
            ff.ShowDialog();
            this.Show();
        }
    }
}
