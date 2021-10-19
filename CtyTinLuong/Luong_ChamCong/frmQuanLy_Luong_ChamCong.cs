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
        //frmMain _frmMain;
        public frmQuanLy_Luong_ChamCong()
        {
            InitializeComponent();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            UCBangLuong uccc_DaNhapKho = new UCBangLuong(this);
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            Cursor.Current = Cursors.Default;
        }

        private void navNhapKho_TuMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            UCLuong_ChieTiet_ALL uccc_DaNhapKho = new UCLuong_ChieTiet_ALL();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            Cursor.Current = Cursors.Default;
        }


        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            UCLuong_TamUng uccc_DaNhapKho = new UCLuong_TamUng();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            Cursor.Current = Cursors.Default;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            UCLuong_TraLuongNewwwwwwwwww uccc_DaNhapKho = new UCLuong_TraLuongNewwwwwwwwww();
            uccc_DaNhapKho.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(uccc_DaNhapKho);
            uccc_DaNhapKho.BringToFront();

            Cursor.Current = Cursors.Default;
        }
         
        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            frmCaiMacDinnhMaHangToGapDan ff = new frmCaiMacDinnhMaHangToGapDan();
            //this.Hide();
            ff.Show();
            //this.Show();
            Cursor.Current = Cursors.Default;
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            Cursor.Current = Cursors.Default;
        }

        private void frmQuanLy_Luong_ChamCong_Load(object sender, EventArgs e)
        {

        }


        private void navTTL_TGD_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmBTTL_TGD_CT frm = new frmBTTL_TGD_CT(this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, id_bophan_);

            Cursor.Current = Cursors.Default;
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
        private void navBTTL_TGD_TD_LinkClicked(object sender, NavBarLinkEventArgs e) //đã xóa
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            //Gấp dán tổng quan
            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmBTTL_TGD_TQ frm = new frmBTTL_TGD_TQ(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCom_TGD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            frmChamCom_TGD frm = new frmChamCom_TGD(this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, 0);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_TBX_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmChamCong_TBX frm = new frmChamCong_TBX(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_TBX_TD_LinkClicked(object sender, NavBarLinkEventArgs e) //bỏ
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            //Bốc xếp tổng quát
            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmBTTL_TBX_TQ frm = new frmBTTL_TBX_TQ(id_bophan_);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBarItem15_LinkClicked_1(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmBTTL_TBX_CT frm = new frmBTTL_TBX_CT(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_TDK_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ đóng kiện");
            if (id_bophan_ == 0) return;

            frmChamCong_TDK frm = new frmChamCong_TDK(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_TMC_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy cắt");
            if (id_bophan_ == 0) return;

            frmBTTL_TMC_CT frm = new frmBTTL_TMC_CT(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_TGD_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Gấp dán");
            if (id_bophan_ == 0) return;

            frmChamCong_TGD frm = new frmChamCong_TGD(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_TBX_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Bốc xếp");
            if (id_bophan_ == 0) return;

            frmChamCong_TBX frm = new frmChamCong_TBX(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_TrgCa_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Trưởng ca");
            if (id_bophan_ == 0) return;

            frmChamCong_TrgCa frm = new frmChamCong_TrgCa(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

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

        private void navBTTL_TrgCa_CT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Trưởng ca");
            if (id_bophan_ == 0) return;

            frmBTTL_TrgCa_CT frm = new frmBTTL_TrgCa_CT(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_PTH_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Phòng Tổng hợp");
            if (id_bophan_ == 0) return;

            frmChamCong_PTH frm = new frmChamCong_PTH(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_PTH_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Phòng Tổng hợp");
            if (id_bophan_ == 0) return;

            frmBTTL_PTH frm = new frmBTTL_PTH(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_PKT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Phòng Kế toán");
            if (id_bophan_ == 0) return;

            frmChamCong_PKT frm = new frmChamCong_PKT(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_PKT_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Phòng Kế toán");
            if (id_bophan_ == 0) return;

            frmBTTL_PKT frm = new frmBTTL_PKT(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_PMC_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("PMC");
            if (id_bophan_ == 0) return;

            frmChamCong_PMC frm = new frmChamCong_PMC(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_PMC_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("PMC"); //Trong db PMC = Phụ máy cắt
            if (id_bophan_ == 0) return;

            frmBTTL_PMC frm = new frmBTTL_PMC(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCong_ToIn_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy in");
            if (id_bophan_ == 0) return;

            frmChamCong_ToIn frm = new frmChamCong_ToIn(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_ToIn_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy in");
            if (id_bophan_ == 0) return;

            frmBTTL_ToIn frm = new frmBTTL_ToIn(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navChamCon_TDB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ đóng bao");
            if (id_bophan_ == 0) return;

            frmChamCong_TDB frm = new frmChamCong_TDB(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTL_TDB_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ Đóng Bao");
            if (id_bophan_ == 0) return;

            frmBTTL_TDB frm = new frmBTTL_TDB(this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, id_bophan_, true);

            Cursor.Current = Cursors.Default; 
        }

        private void navBTTL_TDK_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Tổ đóng kiện");
            if (id_bophan_ == 0) return;

            frmBTTL_TDK frm = new frmBTTL_TDK(this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, id_bophan_);

            Cursor.Current = Cursors.Default;
        }

        private void navToMayCat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy cắt");
            if (id_bophan_ == 0) return;

            frmChamCong_TMC frm = new frmChamCong_TMC(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, true);

            Cursor.Current = Cursors.Default;
        }

        private void navToDot_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy đột");
            if (id_bophan_ == 0) return;

            frmChamCong_ToDot frm = new frmChamCong_ToDot(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true, true);

            Cursor.Current = Cursors.Default;
        }

        private void navBTTLToDot_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Máy đột");
            if (id_bophan_ == 0) return;

            frmBTTL_ToDot frm = new frmBTTL_ToDot(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }

        private void navBarPhienDich_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doiMauTitle(sender, e);

            int id_bophan_ = KiemTraTenBoPhan("Phòng Tổng hợp");
            if (id_bophan_ == 0) return;

            frmChamCong_PhienDich frm = new frmChamCong_PhienDich(id_bophan_, this);
            frm.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(frm);
            frm.BringToFront();

            frm.LoadData(true);

            Cursor.Current = Cursors.Default;
        }
    }
}
