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
        public static int imay_in_1_Cat_2_dot_3;
        public SanXuat_frmQuanLySanXuat()
        {
            isload = true;
            InitializeComponent();
            isload = false;
            ucc = new UC_SanXuat_PhieuSanXuat(this);
        }
        public void ResetSoTrang()
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_TongPhieuSX(ucc._ngay_batdau, ucc._ngay_ketthuc, ucc._ma_phieu);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" +(Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }
       
        private void navBarItemPhieuSanXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucc.LoadData(1,true);

            ResetSoTrang();

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
            ff.Show();
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
            ff.Show();
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_+1).ToString();

                    Load_PhieuSX(false);
                }
                else
                { txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_-1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        { 
        }

        private void txtSoTrang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }
        private void Load_PhieuSX(bool islandau)
        { 
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            } 
            ucc.LoadData(sotrang_, islandau); 
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SanXuat_UC_BB_Ktra_DM_HH ucc = new SanXuat_UC_BB_Ktra_DM_HH();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navSanLuongMayDOT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 3;
            SanLuong_To_DOT_DAP ucc = new SanLuong_To_DOT_DAP();
            ucc.Show();
        }

        private void navSanLuongMayIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 1;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            ucc.Show();
        }

        private void navSanLuongMayCAT_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            imay_in_1_Cat_2_dot_3 = 2;
            SanLuong_To_May_IN ucc = new SanLuong_To_May_IN();
            ucc.Show();
        }

        private void navLuongSanLuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBaoCaoSanLuong_Theo_CongNhan ucc = new frmBaoCaoSanLuong_Theo_CongNhan();
            ucc.Show();
        }
    }
}
