using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmMain : Form
    {
        public void HideFormMain()
        {
            this.Hide();
        }
      //
        private void QuyenTruyCap()
        {
           // thiếtLậpBanĐầuToolStripMenuItem.Enabled = false;
            clsTbDangNhap cls = new CtyTinLuong.clsTbDangNhap();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectOne();
            
            if(dt.Rows.Count>0)
            {
               

                if (cls.bBMuaHang.Value == false)
                    btnMuaHang.Enabled = false;
                if (cls.bBBanHang.Value == false)
                    btnBanHang.Enabled = false;
                if (cls.bBNguyenPhuLieu.Value == false)
                    btnKhoNguyenPhuLieu.Enabled = false;
                if (cls.bBBanThanhPham.Value == false)
                    btnKhoBanThanhPham.Enabled = false;
                if (cls.bBDaiLy.Value == false)
                    btnDaiLy.Enabled = false;
                if (cls.bBThanhPham.Value == false)
                    btnKhoThanhPham.Enabled = false;
                if (cls.bBQuanLySanXuat.Value == false)
                    btnQLSX.Enabled = false;
                if (cls.bBLuongChamCong.Value == false)
                    btnLuongChamCong.Enabled = false;
                if (cls.bBQuyNganHang.Value == false)
                    btnQuyNganHang.Enabled = false;
                if (cls.bBQuanTri.Value == true)
                {
                    //stripQuanTri.Enabled = true;
                }

                else
                {
                    //stripQuanTri.Enabled = false;
                }
                    
            }
        }
        public frmMain()
        {
            InitializeComponent();
            random = new Random();
            Color colorStart = SelectThemeColor();
            ThemeColor.PrimaryColor = colorStart;
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Drag form:
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            QuyenTruyCap();
            
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
           
        }
        frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii _frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii;

        private void importDuLieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii = new CtyTinLuong.frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii(this);
            this.Hide();
            _frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii.Show();
        }

        private void btDinhMucDot_Click(object sender, EventArgs e)
        {
            
        }


        private void simpleButton6_Click(object sender, EventArgs e)
        {
            clsDelete_ALL_newwww cls = new clsDelete_ALL_newwww();
            cls.HUU_Delete_ALL();
            MessageBox.Show("Đã xoá ALLL");
        }

       
        private void simpleButton10_Click_1(object sender, EventArgs e)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
           
            MessageBox.Show("Đã xong");
        }


        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            clsMH_tbMuaHang cls1 = new clsMH_tbMuaHang();
            cls1.daNgayChungTu = DateTime.Today;
            cls1.sSoChungTu = "MH 1";
            cls1.sSoHoaDon = "";
            cls1.iIDNhaCungCap = 3;
            cls1.sDienGiai = "";
            cls1.fTongTienHangChuaVAT = 17000000;
            cls1.fTongTienHangCoVAT = 18700000;
            cls1.iID_NguoiMua = 12;
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            //cls1.iID_TKNo = 46;
            //cls1.iID_TKCo = 291;
            //cls1.iID_TKVAT = 79;
            cls1.bTienUSD = false;
            cls1.fPhanTramVAT = 10;
            cls1.fTienVAT = 1700000;
            cls1.bMuaHangNhapKho = true;
            cls1.bGuiDuLieu = true;
            cls1.bCheck_BaoVe = true;
            cls1.bCheck_LaiXe = true;
            cls1.bTrangThaiNhapKho = false;
            cls1.Insert();
            int iiDIMuahang = cls1.iID_MuaHang.Value;

            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 741;
            cls2.fSoLuong = 100;
            cls2.fDonGia = 100000;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 108;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 1116;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 938;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 440;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 104;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 43;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

            cls2.iID_MuaHang = iiDIMuahang;
            cls2.iID_VTHH = 471;
            cls2.fSoLuong = 10000;
            cls2.fDonGia = 100;
            cls2.bTonTai = true;
            cls2.bNgungTheoDoi = false;
            cls2.sGhiChu = "test";
            cls2.Insert();

           

            MessageBox.Show("Đã xong");
        }



        //=========================Themes===================
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMain.FormSystem(), sender);
        }

        private void btnQuanTri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMain.FormQuanTri(), sender);

        }

        private void btnCongCu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMain.FormCongCu(), sender);
        }

        private void btnKHSX_Click(object sender, EventArgs e)
        {
            frmKeHoachSanXuat ff = new frmKeHoachSanXuat();
            ff.Show();
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "              HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            frmMuaHang2222 ff = new frmMuaHang2222();
            ff.Show();
        }
         
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmQuanLyBanHang ff = new CtyTinLuong.frmQuanLyBanHang();
            ff.Show();
        }

        private void btnDaiLy_Click(object sender, EventArgs e)
        {
            frmQuanLyKhoDaiLy ff = new frmQuanLyKhoDaiLy();
            ff.Show();
        }

        private void btnQLSX_Click(object sender, EventArgs e)
        {
            SanXuat_frmQuanLySanXuat ff = new SanXuat_frmQuanLySanXuat();
            ff.Show();
        }

        frmQuanLy_Luong_ChamCong _frmQuanLy_Luong_ChamCong;
        private void btnLuongChamCong_Click(object sender, EventArgs e)
        {
            _frmQuanLy_Luong_ChamCong = new CtyTinLuong.frmQuanLy_Luong_ChamCong(this);
            //this.Hide();hide
            _frmQuanLy_Luong_ChamCong.Show();
        }

        private void btnQuyNganHang_Click(object sender, EventArgs e)
        {
            frmQuy_NganHang_Newwwwwwwwwwwwwwwww ff = new CtyTinLuong.frmQuy_NganHang_Newwwwwwwwwwwwwwwww();
            ff.Show();
        }

        private void btnKhoNguyenPhuLieu_Click(object sender, EventArgs e)
        {
            KhoNPL_frmNPL ff = new KhoNPL_frmNPL();
            ff.Show();
        }

        private void btnKhoBanThanhPham_Click(object sender, EventArgs e)
        {
            frmQuanLyKhoBanThanhPham ff = new CtyTinLuong.frmQuanLyKhoBanThanhPham();
            ff.Show();
        }

        private void btnKhoThanhPham_Click(object sender, EventArgs e)
        {
            frmQuanLyKhoThanhPham ff = new CtyTinLuong.frmQuanLyKhoThanhPham();
            ff.Show();
        }


        //Mousedown event tại paneltitleBar: cho phép kéo di chuyển Form
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPhieuSX_Click(object sender, EventArgs e)
        {
            frmImPortPhieuSanXuat_banDau ff = new frmImPortPhieuSanXuat_banDau();
            ff.Show();
        }

        private void btnNganHang_Click(object sender, EventArgs e)
        {
            frmImPortPhieuNganHang ff = new frmImPortPhieuNganHang();
            ff.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap ff = new frmDangNhap();
            ff.Show();
        }

        private void btnBaoCaoNXT_Click(object sender, EventArgs e)
        {
            frmBaoCaoNXT ff = new frmBaoCaoNXT();
            ff.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan ff = new CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan(6, 2021);
            //ff.Show();

            CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCongTGD ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCongTGD(6, 2021);
            ff.Show();

        }
    }
}
