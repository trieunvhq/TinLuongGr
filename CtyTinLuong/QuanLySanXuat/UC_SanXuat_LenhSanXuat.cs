using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace CtyTinLuong
{
    public partial class UC_SanXuat_LenhSanXuat : UserControl
    {
        private int _SoTrang = 1;
        private bool isload = false;
        public void LoadData(int sotrang, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                using (clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat())
                {
                    gridControl1.DataSource = null;
                    isload = true;
                    _SoTrang = sotrang;
                    
                    //DataTable dt = cls.SelectAll_Load_DaTa_W_NgayThang(_SoTrang, xxtungay, xxdenngay);
                    DataTable dt = cls.HUU_LenhSanXuat_SA_t111(_SoTrang, xxtungay, xxdenngay);

                    gridControl1.DataSource = dt;

                    isload = false;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            LoadData(sotrang_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                btnTrangSau.Visible = true;
                btnTrangTiep.Visible = true;
                lbTongSoTrang.Visible = true;
                txtSoTrang.Visible = true;
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Blue;
                txtSoTrang.Text = "1";

                using (clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat())
                {
                    DataTable dt_ = cls.SelectAll_Tinh_SoLenh_SX(xxtungay, xxdenngay);
                    if (dt_ != null && dt_.Rows.Count > 0)
                    {
                        lbTongSoTrang.Text = "/" + (Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int mID_iD_LenhSanXuat;
        private void HienThi_Gridcontrol_2(int iiiIDiD_LenhSanXuat)
        {
            try
            {
                gridControl2.DataSource = null;

                clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                DataTable dtxxxx = cls2.SA_new(iiiIDiD_LenhSanXuat);
                gridControl2.DataSource = dtxxxx;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        public UC_SanXuat_LenhSanXuat()
        {
            InitializeComponent();
        }
        
        private void UC_SanXuat_LenhSanXuat_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                clCaSanXuat.Caption = "Ca\n SX";
                clNhomMay.Caption = "Nhóm\nmáy";
                dteTuNgay.EditValue = DateTime.Now.AddDays(-20);
                dteDenNgay.EditValue = DateTime.Now;
                LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_SanXuat_LenhSanXuat_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clSTT)
                {
                    e.DisplayText = (e.RowHandle + 1).ToString();
                }
                if (e.Column == clNhomMay)
                {
                    //gridView4.GetRowCellValue(e.RowHandle, e.Column)
                    if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "1")
                        e.DisplayText = "IN";
                    else if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "2")
                        e.DisplayText = "CẮT";
                    else if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "3")
                        e.DisplayText = "ĐỘT";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mID_iD_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());                 
                    SanXuat_frmChiTietLenhSanXuat ff = new SanXuat_frmChiTietLenhSanXuat(this);
                    ff.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() == "")
                {
                    MessageBox.Show("Vui lòng chọn lại");
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    clsHUU_LenhSanXuat cls1 = new clsHUU_LenhSanXuat();
                    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                    cls1.iID_LenhSanXuat = xxID;
                    cls1.SelectOne();
                    if (cls1.bGuiDuLieu == true)
                    {
                        MessageBox.Show("đã gửi dữ liệu, không thể xoá");
                    }
                    else
                    {
                        DialogResult traloi;
                        traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (traloi == DialogResult.Yes)
                        {
                            cls1.Delete();
                            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                            cls2.iID_LenhSanXuat = xxID;
                            cls2.Delete_w_iID_LenhSanXuat();
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Đã xóa");
                            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
                            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.iID_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            try
            {
                using (clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat())
                {
                    if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
                    {
                        int xxxmclID_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());

                        cls.Update_W_GuiDuLieu(xxxmclID_LenhSanXuat, true);
                        MessageBox.Show("Đã gửi dữ liệu nhập xuất kho");
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
                {
                    int xxxmclID_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                    HienThi_Gridcontrol_2(xxxmclID_LenhSanXuat);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
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

                    Load_PhieuSX(false);
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
                    Load_PhieuSX(false);
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
            if(isload)
                return;
            Load_PhieuSX(false);
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }
    }
}
