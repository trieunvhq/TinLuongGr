﻿using DevExpress.XtraNavBar;
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
        //frmMain _frmMain;
        public frmQuanLy_Luong_ChamCong()
        {
            InitializeComponent();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBangLuong uccc_DaNhapKho = new UCBangLuong();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            doiMauTitle(sender, e);
        }

        private void navNhapKho_TuMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_ChieTiet_ALL uccc_DaNhapKho = new UCLuong_ChieTiet_ALL();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            doiMauTitle(sender, e);
        }


        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_TamUng uccc_DaNhapKho = new UCLuong_TamUng();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            doiMauTitle(sender, e);
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCLuong_TraLuongNewwwwwwwwww uccc_DaNhapKho = new UCLuong_TraLuongNewwwwwwwwww();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            doiMauTitle(sender, e);
        }
         
        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmCaiMacDinnhMaHangToGapDan ff = new frmCaiMacDinnhMaHangToGapDan();
            this.Hide();
            ff.ShowDialog();
            this.Show();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void frmQuanLy_Luong_ChamCong_Load(object sender, EventArgs e)
        {

        }


        private void navTTL_TGD_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmBTTL_TGD_CT frm = new frmBTTL_TGD_CT();
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, id_bophan_);

            doiMauTitle(sender, e);
        }

        //
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
        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                    
                }
            }
            return _id_bophan;
        }
        private void navBTTL_TGD_TD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmBTTL_TGD_TQ frm = new frmBTTL_TGD_TQ(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navChamCom_TGD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            frmChamCom_TGD frm = new frmChamCom_TGD();
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navBTTL_TBX_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmChamCong_TBX frm = new frmChamCong_TBX(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navBTTL_TBX_TD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmBTTL_TBX_TQ frm = new frmBTTL_TBX_TQ(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navBarItem15_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmBTTL_TBX_CT frm = new frmBTTL_TBX_CT(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navChamCong_TDK_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Đóng kiện");
            if (id_bophan_ == 0) return;

            frmChamCong_TDK frm = new frmChamCong_TDK(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navBTTL_TMC_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Máy cắt");
            if (id_bophan_ == 0) return;

            frmBTTL_TMC_CT frm = new frmBTTL_TMC_CT(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navChamCong_TGD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmChamCongToGapDan frm = new frmChamCongToGapDan(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navChamCong_TBX_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmChamCong_TBX frm = new frmChamCong_TBX(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }

        private void navChamCong_TrgCa_LinkClicked(object sender, NavBarLinkEventArgs e)
        { 
            int id_bophan_ = KiemTraTenBoPhan("Trưởng ca");
            if (id_bophan_ == 0) return;

            frmChamCong_TrgCa frm = new frmChamCong_TrgCa(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
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

        private void navBTTL_TrgCa_CT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            int id_bophan_ = KiemTraTenBoPhan("Trưởng ca");
            if (id_bophan_ == 0) return;

            frmBTTL_TrgCa_CT frm = new frmBTTL_TrgCa_CT(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            doiMauTitle(sender, e);
        }
    }
}
