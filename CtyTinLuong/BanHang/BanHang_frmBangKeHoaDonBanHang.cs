using DevExpress.Data.Filtering;
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
    public partial class BanHang_frmBangKeHoaDonBanHang : Form
    {
        public static bool isClick = false;
        public static DateTime mdatungay,mdadenngay;
        public static DataTable mdtPrint;
        public static bool mbPrint;
        private int _SoTrang = 1, _SoDong=20;
        private bool isload = false;
        public static int miiiID_BanHang;
        private void HienThi_Gridcontrol_2(int xxID_banHang)
        {
            grid_ChiTiet.DataSource = null;
            clsBanHang_ChiTietBanHang cls = new clsBanHang_ChiTietBanHang();
            cls.iID_BanHang = xxID_banHang;
            DataTable dt3 = cls.Select_HienThiSuaDonHang();         
                        grid_ChiTiet.DataSource = dt3;


        }
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            grid_banHang.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            _SoDong = sodong;
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.Load_DaTa_NgayThang_So_Dong_Trang(sotrang, sodong, xxtungay, xxdenngay);           
            grid_banHang.DataSource = dt;
            isload = false;
        }
        private void Load_banhang(bool islandau)
        {
            int sotrang_ = 1;
            int sodong_ = 20;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                sodong_ = Convert.ToInt32(txtSoDong.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
                sodong_ = 20;
                txtSoDong.Text = "20";
            }
            LoadData(sotrang_, sodong_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";
            int xxsodong = Convert.ToInt32(txtSoDong.Text);
            using (clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang())
            {
                DataTable dt_ = cls.Dem_tbBanHang(xxtungay, xxdenngay);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)xxsodong)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        public BanHang_frmBangKeHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void BanHang_frmBangKeHoaDonBanHang_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteDenNgay.EditValue = DateTime.Now;

            LoadData(1,20, true, dteTuNgay.DateTime, dteDenNgay.DateTime);

            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);

            dteTuNgay.Focus();

            Cursor.Current = Cursors.Default;
        }

        private void gridView_banhang_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView_banhang_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView_banhang.GetFocusedRowCellValue(clID_BanHang).ToString() != "")
            {
                int xxidbanhang = Convert.ToInt16(gridView_banhang.GetFocusedRowCellValue(clID_BanHang).ToString());
                HienThi_Gridcontrol_2(xxidbanhang);
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int sodongxxx = Convert.ToInt32(txtSoDong.Text);
                ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, sodongxxx, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_banhang(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_banhang(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_banhang(false);
        }

        private void grid_ChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btPrint_Click(object sender, EventArgs e)
        {

            clsBanHang_ChiTietBanHang cls = new clsBanHang_ChiTietBanHang();
            mdtPrint = cls.SelectAll_ngayThang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                ff.ShowDialog();
            }
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BanHang_frmBangKeHoaDonBanHang_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView_banhang_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (gridView_banhang.GetFocusedRowCellValue(clID_BanHang) != null)
                {
                    isClick = true;
                    miiiID_BanHang = Convert.ToInt16(gridView_banhang.GetFocusedRowCellValue(clID_BanHang).ToString());
                    BanHang_FrmChiTietBanHang_Newwwwwwww ff = new BanHang_FrmChiTietBanHang_Newwwwwwww(null, this);

                    ff.Show();

                }
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }

        private void grid_banHang_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridView_Chitiet_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_banhang(false);
        }
    }
}
