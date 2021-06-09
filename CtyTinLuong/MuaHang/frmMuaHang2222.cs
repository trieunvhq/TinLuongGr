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
            mbTraLaiHangMua = false;
            UCMuaHang ucc = new UCMuaHang();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MuaHang_frmCongNo ff = new MuaHang_frmCongNo();
            ff.Show();
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
            ff.Show();
        }

        private void navBarItem1_LinkClicked_3(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            mbTraLaiHangMua = true;
            UCMuaHang ucc = new UCMuaHang();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navChiTiet_ALL_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCMuaHang_ChiTietTatCa ucc = new UCMuaHang_ChiTietTatCa();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }
    }
}
