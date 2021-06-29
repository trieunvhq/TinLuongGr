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
    public partial class frmQuanLyKhoDaiLy : Form
    {
        private void TinhLuongDaiLy()
        {

        }
        private void HienThi_Caption()
        {
            clsDaiLy_tbNhapKho_Temp cls1 = new clsDaiLy_tbNhapKho_Temp();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = "TrangThaiXuatNhap_KhoDaiLy = False and TrangThaiXuatNhap_Kho_NPL = True";
            DataView dv1 = dt1.DefaultView;
            DataTable dxxxx1 = dv1.ToTable();            
            int k1 = dxxxx1.Rows.Count;
            if (k1 > 0)
            {
                navChoNhapKho.Caption = "Chờ Nhập kho (" + k1.ToString() + ")";
                
            }

            clsDaiLy_tbXuatKho cls2 = new clsDaiLy_tbXuatKho();
            DataTable dt2 = cls2.SelectAll_W_TenDaiLy();
            dt2.DefaultView.RowFilter = "TrangThai_XuatKho_DaiLy_GuiDuLieu = False and TrangThaiXuatNhap_ThanhPham_TuDaiLyVe = True";
            DataView dv2 = dt2.DefaultView;
            DataTable dxxxx2 = dv2.ToTable();   
            int k2 = dxxxx2.Rows.Count;
            if (k2 > 0)
            {
                navXuatKho.Caption = "Xuất kho (" + k2.ToString() + ")";
                navXuatKho.Appearance.Font = new Font(navXuatKho.Appearance.Font, FontStyle.Bold);
            }

            clsGapDan_tbNhapKho cls7 = new clsGapDan_tbNhapKho();
            DataTable dt7 = cls7.SelectAll_HienThi();
            dt7.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and TrangThai_XuatKho_NPL=True and TrangThai_XuatKho_BTP=True and TrangThai_NhapKho_GapDan=False";
            DataView dv7 = dt7.DefaultView;
            DataTable dxxxx7 = dv7.ToTable();
            int k7 = dxxxx7.Rows.Count;
            if (k7 > 0)
            {
                navNhapKhoGapDan.Caption = "Nhập kho (" + k7.ToString() + ")";
                navNhapKhoGapDan.Appearance.Font = new Font(navNhapKhoGapDan.Appearance.Font, FontStyle.Bold);
            }

            //clsGapDan_tbNhapKho cls8 = new clsGapDan_tbNhapKho();
            //DataTable dt8 = cls8.SelectAll_HienThi();
            //dt8.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and TrangThai_XuatKho_NPL=True and TrangThai_XuatKho_BTP=True and TrangThai_NhapKho_GapDan=False";
            //DataView dv8 = dt8.DefaultView;
            //DataTable dxxxx8 = dv8.ToTable();
            //int k8 = dxxxx8.Rows.Count;
            //if (k8 > 0)
            //{
            //    navXuatKhoGapDan.Caption = "Xuất kho (" + k8.ToString() + ")";
            //    navXuatKhoGapDan.Appearance.Font = new Font(navXuatKhoGapDan.Appearance.Font, FontStyle.Bold);
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
        public frmQuanLyKhoDaiLy()
        {
            InitializeComponent();
        }

       

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void navNhapKho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_DaiLy_NhapKho_ChoGhiSo uccc_NhapKho = new UC_DaiLy_NhapKho_ChoGhiSo(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navXuatKho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_XuatKho uccc_NhapKho = new UCDaiLy_XuatKho(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_ChiTietNHapKho_ALL uccc_NhapKho = new UCDaiLy_ChiTietNHapKho_ALL(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_ChiTiet_XuatKho_ALL uccc_NhapKho = new UCDaiLy_ChiTiet_XuatKho_ALL();
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmBaoCao_Nhap_Xuat_ton_kho_DaiLy ff = new CtyTinLuong.frmBaoCao_Nhap_Xuat_ton_kho_DaiLy();
            //this.Hide();
            ff.ShowDialog();
            //this.Show();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }


        private void frmQuanLyKhoDaiLy_Load(object sender, EventArgs e)
        {
            HienThi_Caption();
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmQuanLyKhoDaiLy_Load( sender,  e);
        }

     

        private void navTamUng_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
        }

        private void btGuiDuLieuLuong_Click(object sender, EventArgs e)
        {
           
        }

      

        private void navNhapKhoGapDan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_NhapKho_GapDan uccc_NhapKho = new UCDaiLy_NhapKho_GapDan(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navXuatKhoGapDan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            UCDaiLy_XuatKho_GapDan uccc_NhapKho = new UCDaiLy_XuatKho_GapDan(this);
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCDaiLy_NhapKho_Khac uccc_NhapKho = new UCDaiLy_NhapKho_Khac();
            //uccc_NhapKho.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(uccc_NhapKho);
            //uccc_NhapKho.BringToFront();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //UCDaiLy_XuatKho_Khac uccc_NhapKho = new UCDaiLy_XuatKho_Khac();
            //uccc_NhapKho.Dock = DockStyle.Fill;
            //panelControl1.Controls.Add(uccc_NhapKho);
            //uccc_NhapKho.BringToFront();
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton uccc_NhapKho = new DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton();
            //this.Hide();
            uccc_NhapKho.ShowDialog();
            //this.Show();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DaiLy_BaoCao_TonKho ff = new DaiLy_BaoCao_TonKho();
            //this.Hide();
            ff.ShowDialog();
            //this.Show();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPrint_NguoiKy ff = new CtyTinLuong.frmPrint_NguoiKy();
            ff.ShowDialog();
        }

        private void navBangLuongDaiLy_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DaiLy_BangLuong ff = new CtyTinLuong.DaiLy_BangLuong();
            //this.Hide();
            ff.ShowDialog();
            //this.Show();

            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
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

        private void navChoNhapKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCChoNhapKho_DaiLy_new uccc_NhapKho = new UCChoNhapKho_DaiLy_new();
            uccc_NhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_NhapKho);
            uccc_NhapKho.BringToFront();
            doiMauTitle(sender, e);
            Cursor.Current = Cursors.Default;
        }
    }
}
