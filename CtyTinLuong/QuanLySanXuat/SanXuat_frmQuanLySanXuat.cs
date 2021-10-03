using DevExpress.XtraNavBar;
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
            //doiMauTitle(sender, e);

            //Cursor.Current = Cursors.WaitCursor;
            //ucc.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(ucc);
            //ucc.BringToFront();
            //Cursor.Current = Cursors.Default;

            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            //PhieuSanXuat_IN_CAT_New_thang8 ff = new PhieuSanXuat_IN_CAT_New_thang8();
            PhieuSanXuat_Thang9 ff = new PhieuSanXuat_Thang9();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void navBarItemLenhSanXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;

            UC_SanXuat_LenhSanXuat ucc = new UC_SanXuat_LenhSanXuat();         

            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void navBarItemDinhMucDOt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            UCDinhMucDot ucc = new UCDinhMucDot(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void navBarItemDinhMucNPL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            ucDinhMucNGuyenPhuLieu ucc = new ucDinhMucNGuyenPhuLieu(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            SanXuat_frmChiTietSoPhieu_RutGon ff = new SanXuat_frmChiTietSoPhieu_RutGon();
            //this.Hide();
            ff.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }
        
        private void SanXuat_frmQuanLySanXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

     

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //doiMauTitle(sender, e);

            //Cursor.Current = Cursors.WaitCursor;
            //UCSanXuat_CaiDatMacDinh ucc = new UCSanXuat_CaiDatMacDinh();
            //ucc.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(ucc);
            //ucc.BringToFront();
            //Cursor.Current = Cursors.Default;
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
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            UCSanXuat_DinhMuc_ToGapDan ucc = new UCSanXuat_DinhMuc_ToGapDan(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }
        

        private void navBarItem14_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            frmBaoCaoSanLuong_Theo_CongNhan ucc = new frmBaoCaoSanLuong_Theo_CongNhan();
            ucc.Show();
        }

        private void navBarItem16_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            UCDinhMucHangNhu ucc = new UCDinhMucHangNhu(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            //this.Hide();
            ff.Show();
            //this.Show();
        }

      
        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            //ucc1.LoadData(1, true);
            //ResetSoTrang_BB();
            Cursor.Current = Cursors.WaitCursor;

            ucc1.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc1);
            ucc1.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void navSanLuongMayDOT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            imay_in_1_Cat_2_dot_3 = 3;
            SanLuong_To_DOT_DAP ucc = new SanLuong_To_DOT_DAP();
            //this.Hide();
            ucc.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void navSanLuongMayIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            imay_in_1_Cat_2_dot_3 = 1;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            //this.Hide();
            ucc.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void navSanLuongMayCAT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            imay_in_1_Cat_2_dot_3 = 2;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            //this.Hide();
            ucc.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void navLuongSanLuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            frmBaoCaoSanLuong_Theo_CongNhan ucc = new frmBaoCaoSanLuong_Theo_CongNhan();
            //this.Hide();
            ucc.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void nbSL_CTL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.WaitCursor;
            SanLuong_ChiTiet_Luong ff = new SanLuong_ChiTiet_Luong();
            //this.Hide();
            ff.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void doiMauTitle(object sender, NavBarLinkEventArgs e)
        {
            foreach (NavBarItem navItem in navBarControl1.Items)
            {
                navItem.Appearance.ForeColor = Color.Black;
                navItem.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
            }

            ((NavBarItem)sender).Appearance.ForeColor = Color.Blue;
            ((NavBarItem)sender).Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }
    }
}
