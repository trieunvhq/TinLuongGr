using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCLuong_TraLuongNewwwwwwwwww : UserControl
    {
        public static bool mbThemMoiTraLuong;
        public static int mID_TraLuong_Sua;
        
        private int _SoTrang = 1;
        private int _SoDong = 1;
        private bool isload = false;
        private void HienThiGridControl_2(int iiDI_tamung)
        {
            gridControl2.DataSource = null;

            clsTraLuong_ChiTietTraLuong_new cls2 = new clsTraLuong_ChiTietTraLuong_new();
            cls2.iID_TraLuong = iiDI_tamung;
            DataTable dtchitiet = new DataTable();
            if (checkDaiLy.Checked == true)
                dtchitiet = cls2.SA_W_ID_TraLuong_DaiLy();
            else dtchitiet = cls2.SA_W_ID_TraLuong_CongNhan();
            gridControl2.DataSource = dtchitiet;
        }
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            DataTable dt = new DataTable();
            isload = true;
            _SoTrang = sotrang;
            _SoDong = sodong;
            clsTraLuong_new cls = new clsTraLuong_new();
            if (checkCongNhanVien.Checked == true)
                dt = cls.SA_W_NgayThang_CongNhan(_SoTrang, sodong, xxtungay, xxdenngay);
            else dt = cls.SA_W_NgayThang_DaiLy(_SoTrang, sodong, xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
            isload = false;
        }
        private void Load_TamUng(bool islandau)
        {
            int sotrang_ = 1;
            int sodong_ = 10;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                sodong_ = Convert.ToInt32(txtSoDong.Text);
            }
            catch
            {
                sotrang_ = 1;
                sodong_ = 1;
                txtSoTrang.Text = "1";
                txtSoDong.Text = "10";
            }
            LoadData(sotrang_, sodong_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        public void ResetSoTrang(int sodong_, DateTime xxtungay, DateTime xxdenngay)
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsTraLuong_new cls = new clsTraLuong_new())
            {
                DataTable dt_ = new DataTable();
                if (checkCongNhanVien.Checked == true)
                    dt_ = cls.Dem_Dong_CongNhan(xxtungay, xxdenngay);
                else dt_ = cls.Dem_Dong_DaiLy(xxtungay, xxdenngay);

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)sodong_)).ToString();
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
        public UCLuong_TraLuongNewwwwwwwwww()
        {
            InitializeComponent();
        }

        private void UCLuong_TraLuongNewwwwwwwwww_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbThemMoiTraLuong = true;
          
            clsNgayThang cls = new clsNgayThang();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            checkCongNhanVien.Checked = true;
            Cursor.Current = Cursors.Default;

        }
        
        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCLuong_TraLuongNewwwwwwwwww_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_TraLuong222).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                mbThemMoiTraLuong = false;
                mID_TraLuong_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TraLuong222).ToString());
                frmLuong_ChiTietTraLuong ff = new CtyTinLuong.frmLuong_ChiTietTraLuong();
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbThemMoiTraLuong = true;
            frmLuong_ChiTietTraLuong ff = new CtyTinLuong.frmLuong_ChiTietTraLuong();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_TraLuong).ToString() != "")
            {
                int xxxmiiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TraLuong).ToString());
                HienThiGridControl_2(xxxmiiiiID_TamUng);
            }
        }

        private void checkCongNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCongNhanVien.Checked == true)
            {
                checkDaiLy.Checked = false;
               // LoadData(_SoTrang, _SoDong, isload, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            try
            {
                int sodong = 10;
                LoadData(1, sodong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                ResetSoTrang(sodong, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            { }
        }

        private void checkDaiLy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaiLy.Checked == true)
            {
                checkCongNhanVien.Checked = false;
              //  LoadData(_SoTrang, _SoDong, isload, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            try
            {
                int sodong = 10;
                LoadData(1, sodong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                ResetSoTrang(sodong, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            { }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int sodong = Convert.ToInt32(txtSoDong.Text);
                ResetSoTrang(sodong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, sodong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
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

                    Load_TamUng(false);
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
                    Load_TamUng(false);
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
            Load_TamUng(false);
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int sodong = Convert.ToInt32(txtSoDong.Text);
                ResetSoTrang(sodong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, sodong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }
    }
}
