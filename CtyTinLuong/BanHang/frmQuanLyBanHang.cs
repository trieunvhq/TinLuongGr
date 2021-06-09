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
    public partial class frmQuanLyBanHang : Form
    {
        private void HienThi_Caption()
        {

            //clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();
            //DataTable dt1 = cls1.SelectAll();
            //dt1.DefaultView.RowFilter = "TrangThai_KhoThanhPham=True";
            //DataView dv1 = dt1.DefaultView;
            //DataTable dxxxx1 = dv1.ToTable();
            //int k1 = dxxxx1.Rows.Count;
            //if (k1 > 0)
            //{
            //    navBanHang.Caption = "Bán hàng (" + k1.ToString() + ")";
            //    navBanHang.Appearance.Font = new Font(navBanHang.Appearance.Font, FontStyle.Bold);
            //}

            //clsKhoThanhPham_tbXuatKho cls3 = new clsKhoThanhPham_tbXuatKho();
            //DataTable dxxxx3xx = cls3.SelectAll();
            //dxxxx3xx.DefaultView.RowFilter = "DaXuatKho=False";
            //DataView dv3 = dxxxx3xx.DefaultView;

            //DataTable dxxxx3 = dv3.ToTable();
            //int k3 = dxxxx3.Rows.Count;
            //if (k3 > 0)
            //{
            //    navXuatKhoBanHang.Caption = "Xuất kho bán hàng (" + k3.ToString() + ")";
            //    navXuatKhoBanHang.Appearance.Font = new Font(navXuatKhoBanHang.Appearance.Font, FontStyle.Bold);
            //}

            //clsKhoBTP_tbNhapKho cls4 = new CtyTinLuong.clsKhoBTP_tbNhapKho();
            //DataTable dxxxx3xx4 = cls4.SelectAll();
            //dxxxx3xx4.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            //DataView dvdxxxx3xx4 = dxxxx3xx4.DefaultView;

            //DataTable dxxxx4 = dvdxxxx3xx4.ToTable();
            //int k4 = dxxxx4.Rows.Count;
            //if (k4 > 0)
            //{
            //    navDaNhapKho.Caption = "Đã nhập kho (" + k4.ToString() + ")";
            //}
            //clsKhoBTP_tbNhapKho cls5 = new CtyTinLuong.clsKhoBTP_tbNhapKho();
            //DataTable dxxxx3xx5 = cls5.SelectAll();
            //dxxxx3xx5.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            //DataView dvdxxxx3xx5 = dxxxx3xx5.DefaultView;

            //DataTable dxxxx5 = dvdxxxx3xx5.ToTable();
            //int k5 = dxxxx5.Rows.Count;
            //if (k5 > 0)
            //{
            //    navDaXuatKho.Caption = "Đã xuất kho (" + k5.ToString() + ")";
            //}

        }
        public frmQuanLyBanHang()
        {
            InitializeComponent();
        }

        private void navBanHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCBanHang_BanHang
            UCBanHang_BanHang ucc = new UCBanHang_BanHang();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            UCBanHang_CongNo ucc = new UCBanHang_CongNo();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCBanHang_ChiTiet_ALL ucc = new UCBanHang_ChiTiet_ALL();
            ucc.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(ucc);
            ucc.BringToFront();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQuanLyBanHang_Load( sender,  e);
        }

        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            HienThi_Caption();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmCaiDatBangGia_BanHang ucc = new frmCaiDatBangGia_BanHang();
            ucc.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new frmPrint_NguoiKy();
            ff.Show();
        }
    }
}
