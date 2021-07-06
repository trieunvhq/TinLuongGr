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
    public partial class frmMuaHang2222 : Form
    {
        public static bool mbTraLaiHangMua;
        private void HienThi_Caption()
        {
            clsMH_tbMuaHang cls1 = new clsMH_tbMuaHang();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = "GuiDuLieu = False";
            DataView dv1 = dt1.DefaultView;
            DataTable dxxxx1 = dv1.ToTable();
            int k1 = dxxxx1.Rows.Count;
            if (k1 > 0)
            {
                navMuaHang.Caption = "Mua hàng (" + k1.ToString() + ")";
                navMuaHang.Appearance.Font = new Font(navMuaHang.Appearance.Font, FontStyle.Bold);
            }
           
        }

        public frmMuaHang2222()
        {
            InitializeComponent();
        }

        private void navBarItemMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            mbTraLaiHangMua = false;
            UCMuaHang ucc = new UCMuaHang(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
            Cursor.Current = Cursors.Default;
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            MuaHang_frmCongNo ucc = new MuaHang_frmCongNo(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void frmMuaHang2222_Load(object sender, EventArgs e)
        {
            HienThi_Caption();
        }

        private void navBarItem1_LinkClicked_2(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmMuaHang2222_Load( sender,  e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new frmPrint_NguoiKy();
            this.Hide();
            ff.ShowDialog();
            this.Show();
        }

        private void navBarItem1_LinkClicked_3(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            mbTraLaiHangMua = true;
            UCMuaHang ucc = new UCMuaHang(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navChiTiet_ALL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCMuaHang_ChiTietTatCa ucc = new UCMuaHang_ChiTietTatCa(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navPhaiTraNguoiBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navCongNo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            MuaHang_frmCongNo ucc = new MuaHang_frmCongNo(this);
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
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
