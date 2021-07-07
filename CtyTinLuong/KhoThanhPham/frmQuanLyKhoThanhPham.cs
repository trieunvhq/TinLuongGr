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
    public partial class frmQuanLyKhoThanhPham : Form
    {
        private void HienThi_Caption()
        {
           
            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
            DataTable dt1 = cls1.SelectAll_W_TenDaiLy_W_MaVT();
            //dt1.DefaultView.RowFilter = "TrangThaiXuatNhap_ThanhPham_TuDaiLyVe=0 and CheckNhapKho_ThanhPham_True_nhapKhoBTP_False=1";
            dt1.DefaultView.RowFilter = "DaXuatKho = True and TrangThai_XuatKho_DaiLy_GuiDuLieu=1 and CheckNhapKho_ThanhPham_True_nhapKhoBTP_False =1 and TrangThaiXuatNhap_ThanhPham_TuDaiLyVe=0";
            //dt1.DefaultView.RowFilter = "TrangThaiXuatNhap_KhoDaiLy = True and TrangThaiXuatNhap_Kho_ThanhPham=False";
            DataView dv1 = dt1.DefaultView;
            DataTable dxxxx1 = dv1.ToTable();
            int k1 = dxxxx1.Rows.Count;
            if (k1 > 0)
            {
                navChoNhapKho_tuDaiLy.Caption = "Nhập kho từ Đại lý (" + k1.ToString() + ")";
                navChoNhapKho_tuDaiLy.Appearance.Font = new Font(navChoNhapKho_tuDaiLy.Appearance.Font, FontStyle.Bold);
            }

            clsKhoThanhPham_tbXuatKho cls3 = new clsKhoThanhPham_tbXuatKho();
            DataTable dxxxx3xx = cls3.SelectAll();
            dxxxx3xx.DefaultView.RowFilter = "DaXuatKho=False and Check_XuatKho_Khac = False";
            DataView dv3 = dxxxx3xx.DefaultView;

            DataTable dxxxx3 = dv3.ToTable();
            int k3 = dxxxx3.Rows.Count;
            if (k3 > 0)
            {
                navXuatKhoBanHang.Caption = "Xuất kho bán hàng (" + k3.ToString() + ")";
                navXuatKhoBanHang.Appearance.Font = new Font(navXuatKhoBanHang.Appearance.Font, FontStyle.Bold);
            }

          

        }
        public frmQuanLyKhoThanhPham()
        {
            InitializeComponent();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navDaNhapKho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_DaNhapKho uccc_NhapKho = new UCThanhPham_DaNhapKho(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

        private void navChoNhapKho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww uccc_NhapKho = new UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_XuatKhoBanHang_Newwwwwwwwww uccc_NhapKho = new UCThanhPham_XuatKhoBanHang_Newwwwwwwwww(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_DaXuatKho uccc_NhapKho = new UCThanhPham_DaXuatKho(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

    
      

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            frmBaoCaoNXT_KhoThanhPham uccc_NhapKho = new frmBaoCaoNXT_KhoThanhPham();
            //this.Hide();
            uccc_NhapKho.Show();
            //this.Show();
        }


        private void frmQuanLyKhoThanhPham_Load(object sender, EventArgs e)
        {
            HienThi_Caption();
        }

      

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_NhapKho_Khac uccc_NhapKho = new UCThanhPham_NhapKho_Khac(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

        private void navBarItem13_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            UCThanhPham_XuatKho_Khac uccc_NhapKho = new UCThanhPham_XuatKho_Khac(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            //this.Hide();
            ff.Show();
            //this.Show();
        }

        private void navBarItem10_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            doiMauTitle(sender, e);

            frmCaiDatBangGia_BanHang ucc = new frmCaiDatBangGia_BanHang();
            //this.Hide();
            ucc.Show();
            //this.Show();
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
