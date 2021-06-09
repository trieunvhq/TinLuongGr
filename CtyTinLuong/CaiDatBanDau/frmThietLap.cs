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
    public partial class frmThietLap : Form
    {
        public frmThietLap()
        {
            InitializeComponent();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCThietLap_TaiKhoanNganHang uccc_DaNhapKho = new UCThietLap_TaiKhoanNganHang();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            KhoNPL_CaiDatBanDau ucc = new KhoNPL_CaiDatBanDau();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCCaiDatBanDau_Kho_BTP ucc = new UCCaiDatBanDau_Kho_BTP();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCCaiDatBanDau_Kho_DaiLy ucc = new UCCaiDatBanDau_Kho_DaiLy();
            //ucc.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(ucc);
            //ucc.BringToFront();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCCaiDatBanDau_Kho_ThanhPham ucc = new UCCaiDatBanDau_Kho_ThanhPham();
            //ucc.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(ucc);
            //ucc.BringToFront();
        }
    }
}
