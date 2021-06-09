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
    public partial class frmQuy_NganHang_Newwwwwwwwwwwwwwwww : Form
    {
        public static int miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4;
        private void HienThi_Caption()
        {
            clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = "DaGhiSo = False and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1";
            DataView dv1 = dt1.DefaultView;
            DataTable dxxxx1 = dv1.ToTable();
            int k1 = dxxxx1.Rows.Count;
            if (k1 > 0)
            {
                navBaoCo.Caption = "Báo Có (" + k1.ToString() + ")";
                navBaoCo.Appearance.Font = new Font(navBaoCo.Appearance.Font, FontStyle.Bold);
            }

            DataTable dt2 = cls1.SelectAll();
            dt2.DefaultView.RowFilter = "DaGhiSo = False and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2";
            DataView dv2 = dt2.DefaultView;
            DataTable dxxxx2 = dv2.ToTable();
            int k2 = dxxxx2.Rows.Count;
            if (k2 > 0)
            {
                navBaoNo.Caption = "Báo Nợ (" + k2.ToString() + ")";
                navBaoNo.Appearance.Font = new Font(navBaoNo.Appearance.Font, FontStyle.Bold);
            }

            DataTable dt3 = cls1.SelectAll();
            dt3.DefaultView.RowFilter = "DaGhiSo = False and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3";
            DataView dv3 = dt3.DefaultView;
            DataTable dxxxx3 = dv3.ToTable();
            int k3 = dxxxx3.Rows.Count;
            if (k3 > 0)
            {
                navPhieuChi.Caption = "Phiếu chi (" + k3.ToString() + ")";
                navPhieuChi.Appearance.Font = new Font(navPhieuChi.Appearance.Font, FontStyle.Bold);
            }

            DataTable dt4 = cls1.SelectAll();
            dt4.DefaultView.RowFilter = "DaGhiSo = False and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4";
            DataView dv4 = dt4.DefaultView;
            DataTable dxxxx4 = dv4.ToTable();
            int k4 = dxxxx4.Rows.Count;
            if (k4 > 0)
            {
                navPhieuThu.Caption = "Phiếu thu (" + k3.ToString() + ")";
                navPhieuThu.Appearance.Font = new Font(navPhieuThu.Appearance.Font, FontStyle.Bold);
            }
        }
        public frmQuy_NganHang_Newwwwwwwwwwwwwwwww()
        {
            InitializeComponent();
        }

        private void navBaoCo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = 1;
            UCQuy_NganHang_BaoCo ucc = new UCQuy_NganHang_BaoCo();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void frmQuy_NganHang_Newwwwwwwwwwwwwwwww_Load(object sender, EventArgs e)
        {
            HienThi_Caption();
        }

        private void navBaoNo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = 2;
            UCQuy_NganHang_BaoCo ucc = new UCQuy_NganHang_BaoCo();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navPhieuThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = 4;
            UCQuy_NganHang_BaoCo ucc = new UCQuy_NganHang_BaoCo();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navPhieuChi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = 3;
            UCQuy_NganHang_BaoCo ucc = new UCQuy_NganHang_BaoCo();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navCongNo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCQuy_NganHang_CongNo_MoiiiiiIIIIIIIIIIIIIIIIIIIIIIIIIIII ucc = new UCQuy_NganHang_CongNo_MoiiiiiIIIIIIIIIIIIIIIIIIIIIIIIIIII();
            //ucc.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(ucc);
            //ucc.BringToFront();
            frmCongNho_NganHang ff = new frmCongNho_NganHang();
            ff.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            ff.Show();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmChiTietBienDongTaiKhoan ff = new CtyTinLuong.frmChiTietBienDongTaiKhoan();
            ff.Show();
        }
    }
}
