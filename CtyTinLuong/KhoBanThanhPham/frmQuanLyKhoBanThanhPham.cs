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
    public partial class frmQuanLyKhoBanThanhPham : Form
    {

        public static bool mbNhapKhoTuLenhSXICD;
        public frmQuanLyKhoBanThanhPham()
        {
            InitializeComponent();
        }

       

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBanThanhPham_DaNhapKho uccc_DaNhapKho = new UCBanThanhPham_DaNhapKho();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

     

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCbanThanhPham_DaXuatKho uccc_DaNhapKho = new UCbanThanhPham_DaXuatKho();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

    


        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBaoCaoNhapXuatTon_BanThanhPham uccc_DaNhapKho = new frmBaoCaoNhapXuatTon_BanThanhPham();
            uccc_DaNhapKho.Show();
        }

        private void frmQuanLyKhoBanThanhPham_Load(object sender, EventArgs e)
        {
           
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQuanLyKhoBanThanhPham_Load( sender,  e);
        }

      


        private void navBarItem2_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBanThanhPham_NhapKho_Khac uccc_DaNhapKho = new UCBanThanhPham_NhapKho_Khac();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navBarItem3_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBanThanhPham_XuatKho_Khac uccc_DaNhapKho = new UCBanThanhPham_XuatKho_Khac();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            ff.Show();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            mbNhapKhoTuLenhSXICD = false;
            UCBTP_XuatKho_LSX_I_C_D uccc_DaNhapKho = new UCBTP_XuatKho_LSX_I_C_D();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            mbNhapKhoTuLenhSXICD = true;
            UCBTP_NhapKho_LSX_I_C_D uccc_DaNhapKho = new UCBTP_NhapKho_LSX_I_C_D();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }
    }
}
