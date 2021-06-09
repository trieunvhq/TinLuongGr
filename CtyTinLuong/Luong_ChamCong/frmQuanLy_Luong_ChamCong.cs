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
    public partial class frmQuanLy_Luong_ChamCong : Form
    {
        frmMain _frmMain;
        public frmQuanLy_Luong_ChamCong(frmMain frm)
        {
            _frmMain = frm;
            InitializeComponent();

           
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBangLuong uccc_DaNhapKho = new UCBangLuong();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navNhapKho_TuMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_ChieTiet_ALL uccc_DaNhapKho = new UCLuong_ChieTiet_ALL();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            // _frmMain.Show();
            this.Close();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_TamUng uccc_DaNhapKho = new UCLuong_TamUng();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_TraLuongNewwwwwwwwww uccc_DaNhapKho = new UCLuong_TraLuongNewwwwwwwwww();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmChamCongToGapDan frm = new frmChamCongToGapDan() { TopLevel = false, TopMost = true };
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            this.panelControl1.Controls.Add(frm);
            frm.Show();
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmCaiMacDinnhMaHangToGapDan ff = new frmCaiMacDinnhMaHangToGapDan();
            ff.Show();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmChamCongToGapDan frm = new frmChamCongToGapDan() { TopLevel = false, TopMost = true };
            frm.LoadData(true);
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;

            ShowWinform(frm,  sender);
        }

        private void frmQuanLy_Luong_ChamCong_Load(object sender, EventArgs e)
        {

        }

        private void frmQuanLy_Luong_ChamCong_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  _frmMain.Show();
            this.Close();
        }

        private void navTTL_TGD_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        { 
            frmBTTL_TGD_CT frm = new frmBTTL_TGD_CT() { TopLevel = false, TopMost = true };
            frm.LoadData(true);
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            ShowWinform(frm, sender);
            ((NavBarItem)sender).Appearance.ForeColor = Color.Blue;
            ((NavBarItem)sender).Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }
        private void ShowWinform(Form frm, object sender)
        {

            foreach (NavBarItem navItem in navBarControl1.Items)
            {
                navItem.Appearance.ForeColor = Color.Black;
                navItem.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
            }

            ((NavBarItem)sender).Appearance.ForeColor = Color.Blue;
            ((NavBarItem)sender).Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);

            foreach (Control child in panelControl1.Controls)
            {
                Form form = child as Form;
                if (form == null)
                {

                }
                else
                {
                    form.Close(); 
                }
            }

            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex; 
            //frm.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left)));
             
            this.panelControl1.Controls.Add(frm);
            frm.Show();
        }

        private void navBTTL_TGD_TD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            frmBTTL_TGD_TQ frm = new frmBTTL_TGD_TQ() { TopLevel = false, TopMost = true };
            frm.LoadData(true);
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            ShowWinform(frm, sender);
            ((NavBarItem)sender).Appearance.ForeColor = Color.Blue;
            ((NavBarItem)sender).Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }

        private void navChamCom_TGD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            frmChamCom_TGD frm = new frmChamCom_TGD() { TopLevel = false, TopMost = true };
            frm.LoadData(true);
            //frm.FormBorderStyle = (FormBorderStyle)cboFormStyle.SelectedIndex;
            ShowWinform(frm, sender);
            ((NavBarItem)sender).Appearance.ForeColor = Color.Blue;
            ((NavBarItem)sender).Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        }
    }
}
