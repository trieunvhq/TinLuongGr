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
    public partial class UC_SanXuat_PhieuSanXuat : UserControl
    {
        public static int mID_iD_SoPhieu;
        public static bool mb_ThemMoi_SoPhieu, mb_Sua_SoPhieu, mbCopy_Phieu;
        public static string msTenSoPhieu;
       
        public static DateTime madaNgayPhieu;
        

        public  DateTime _ngay_batdau;
        public  DateTime _ngay_ketthuc;
        public string _ma_phieu;
        private int _SoTrang = 1;
        private bool isload = false;

        //
        public string _sSearch;
        private int _STT = 1;
        private int _RowPage_curent = 0;
        private int _TongSoTrang = 0;

        public void LoadData(int sotrang, bool isLoadLanDau)
        {
            isload = true;
            if (isLoadLanDau)
            {
                dteTuNgay.EditValue = DateTime.Now.AddDays(-90);
                dteDenNgay.EditValue = DateTime.Now;
                txtTimKiem.Text = "";
            }
            else { }
            _ma_phieu = txtTimKiem.Text;
            _ngay_batdau = (DateTime)dteTuNgay.EditValue;
            _ngay_ketthuc = dteDenNgay.DateTime;
            _SoTrang = sotrang;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(int));
            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("NgayLapPhieu", typeof(DateTime));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("GuiDuLieu", typeof(bool));
            dt2.Columns.Add("ID_CaTruong", typeof(int));
            dt2.Columns.Add("DaKetThuc", typeof(bool));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("MaHang", typeof(string));
            dt2.Columns.Add("CaSanXuat", typeof(string));
            using (clsThin cls_ = new clsThin())
            {
                DataTable dt_ = cls_.T_PhieuSX_SF(_SoTrang,_ngay_batdau,_ngay_ketthuc,_ma_phieu);

                _RowPage_curent = dt_.Rows.Count;

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_.Rows.Count; i++)
                    {
                        int ID_SoPhieu = Convert.ToInt32(dt_.Rows[i]["ID_SoPhieu"].ToString());
                        DataRow _ravi = dt2.NewRow();
                        _ravi["STT"] = _STT.ToString(); _STT++;
                        _ravi["ID_SoPhieu"] = ID_SoPhieu;
                        _ravi["MaPhieu"] = dt_.Rows[i]["MaPhieu"].ToString();
                        _ravi["NgayLapPhieu"] = Convert.ToDateTime(dt_.Rows[i]["NgayLapPhieu"].ToString());
                        _ravi["GhiChu"] = dt_.Rows[i]["GhiChu"].ToString();
                        _ravi["CaSanXuat"] = dt_.Rows[i]["CaSanXuat"].ToString();
                        _ravi["GuiDuLieu"] = Convert.ToBoolean(dt_.Rows[i]["GuiDuLieu"].ToString());
                        _ravi["ID_CaTruong"] = Convert.ToInt32(dt_.Rows[i]["ID_CaTruong"].ToString());
                        _ravi["DaKetThuc"] = Convert.ToBoolean(dt_.Rows[i]["DaKetThuc"].ToString());
                        _ravi["TenNhanVien"] = dt_.Rows[i]["TenNhanVien"].ToString();
                        _ravi["MaHang"] = dt_.Rows[i]["TenVTHH"].ToString();
                         
                        dt2.Rows.Add(_ravi);
                    }
                }
            } 
            gridControl1.DataSource = dt2;

            isload = false;
        }

       
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("NgayLapPhieu", typeof(DateTime));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("GuiDuLieu", typeof(bool));
            dt2.Columns.Add("ID_CaTruong", typeof(int));
            dt2.Columns.Add("DaKetThuc", typeof(bool));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("MaHang", typeof(string));
            dt2.Columns.Add("CaSanXuat", typeof(string));
            clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
            DataTable dt = cls.SelectAll_W_TenCaTruong();           
            dt.DefaultView.RowFilter = " NgayLapPhieu<='" + xxdenngay + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayLapPhieu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "GuiDuLieu ASC, NgayLapPhieu DESC, ID_SoPhieu DESC, CaSanXuat DESC";
            DataTable dxxxx = dv2.ToTable();

            if (dxxxx.Rows.Count > 0)
            {

                for (int i = 0; i < dxxxx.Rows.Count; i++)
                {
                    int ID_SoPhieu = Convert.ToInt32(dxxxx.Rows[i]["ID_SoPhieu"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_SoPhieu"] = ID_SoPhieu;
                    _ravi["MaPhieu"] = dxxxx.Rows[i]["MaPhieu"].ToString();
                    _ravi["NgayLapPhieu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayLapPhieu"].ToString());
                    _ravi["GhiChu"] = dxxxx.Rows[i]["GhiChu"].ToString();

                    _ravi["GuiDuLieu"] = Convert.ToBoolean(dxxxx.Rows[i]["GuiDuLieu"].ToString());
                    _ravi["ID_CaTruong"] = Convert.ToInt32(dxxxx.Rows[i]["ID_CaTruong"].ToString());
                    _ravi["DaKetThuc"] = Convert.ToBoolean(dxxxx.Rows[i]["DaKetThuc"].ToString());
                    _ravi["TenNhanVien"] = dxxxx.Rows[i]["TenNhanVien"].ToString();
                    _ravi["CaSanXuat"] = dxxxx.Rows[i]["CaSanXuat"].ToString();
                    clsPhieu_ChiTietPhieu_New clsphieu = new clsPhieu_ChiTietPhieu_New();
                    clsphieu.iID_SoPhieu = ID_SoPhieu;
                    DataTable dtphieu = clsphieu.SelectAll_W_iID_SoPhieu();
                    if (dtphieu.Rows.Count > 0)
                    {
                        dtphieu.DefaultView.RowFilter = "bMay_IN= True";
                        DataView dvphieu = dtphieu.DefaultView;
                        DataTable dxxxxphieu = dvphieu.ToTable();
                        if (dxxxxphieu.Rows.Count > 0)
                        {
                            int ID_VTHH_Ra = Convert.ToInt32(dxxxxphieu.Rows[0]["ID_VTHH_Ra"].ToString());
                            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                            clsvt.iID_VTHH = ID_VTHH_Ra;
                            DataTable dtvt = clsvt.SelectOne();
                            _ravi["MaHang"] = clsvt.sTenVTHH.Value;
                        }

                    }

                    dt2.Rows.Add(_ravi);
                }
            }
            gridControl1.DataSource = dt2;
           
        }
        SanXuat_frmQuanLySanXuat _frmQLSX;
        public UC_SanXuat_PhieuSanXuat(SanXuat_frmQuanLySanXuat frmQLSX)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();
        }

        private void UC_SanXuat_PhieuSanXuat_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _STT = 1;
            clCaLamViec.Caption = "Ca\n làm việc";
            LoadData(1, true);
            ResetSoTrang();
            //  HienThi_ALL();
            Cursor.Current = Cursors.Default;
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_SanXuat_PhieuSanXuat_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

     

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column == clSTT)
            //{
            //    e.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mb_ThemMoi_SoPhieu = false;
                    mb_Sua_SoPhieu = true;
                    mbCopy_Phieu = false;
                    msTenSoPhieu = gridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                    mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                    SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222 ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222(this);
                    //_frmQLSX.Hide();
                    ff.Show();
                    //Cursor.Current = Cursors.WaitCursor;
                    //LoadData(_SoTrang, false);
                    //_frmQLSX.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int xxiID_SoPhieu = Convert.ToInt32(gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
            string maPhieu = gridView1.GetFocusedRowCellValue(clMaPhieu).ToString();

            clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu có mã phiếu \"" + maPhieu + "\". Lưu ý sẽ mất hế dữ liệu?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                cls1.iID_SoPhieu = xxiID_SoPhieu;
                if (cls1.Delete())
                {
                    _STT -= _RowPage_curent;
                    clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
                    cls2.iID_SoPhieu = xxiID_SoPhieu;
                    cls2.Delete_All_W_ID_SoPhieu();
                    // xoá chi tiet lenh sản xuất
                    clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls3 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                    cls3.iID_SoPhieu = xxiID_SoPhieu;
                    cls3.Delete_ALL_W_ID_SoPhieu();
                    // xoá lenh san xuat
                    cls3.iID_SoPhieu = xxiID_SoPhieu;
                    DataTable dt4 = cls3.SelectAll_W_ID_SoPhieu();
                    if (dt4.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt4.Rows.Count; i++)
                        {
                            int ID_LenhSanXuatxx = Convert.ToInt32(dt4.Rows[i]["ID_LenhSanXuat"].ToString());
                            clsHUU_LenhSanXuat cls4 = new clsHUU_LenhSanXuat();
                            cls4.iID_LenhSanXuat = ID_LenhSanXuatxx;
                            cls4.Delete();
                        }
                    }
                    //if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    //{
                    //    HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
                    //}
                    //else
                    //{
                    //    //  HienThi_ALL();ien
                    LoadData(_SoTrang, false);
                    Cursor.Current = Cursors.Default;
                    //}
                    MessageBox.Show("Đã xóa");
                }

                Cursor.Current = Cursors.Default;
            }
        }


        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.iID_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

     
        private void btChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString() != "")
                {
                    msTenSoPhieu = gridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                    mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                    SanXuat_frmChiTietSoPhieu_RutGon ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_RutGon();
                    ff.Show();
                }
            }
            catch
            {

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

        private void btThemMoi_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_ThemMoi_SoPhieu = true;
            mb_Sua_SoPhieu = false;
            mbCopy_Phieu = false;
            SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222 ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222(this);
            //_frmQLSX.Hide();
            ff.Show();
            //btRefresh_Click(sender, e);
            //Cursor.Current = Cursors.WaitCursor;
            //UC_SanXuat_PhieuSanXuat_Load(sender, e);
            //Cursor.Current = Cursors.Default;
            //_frmQLSX.Show();
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;

            try
            {
                _ngay_batdau = Convert.ToDateTime(dteTuNgay.DateTime);
                ResetSoTrang();
                _STT = 1;
                LoadData(1, false);
            }
            catch
            { } 
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            try {
                _ngay_ketthuc = Convert.ToDateTime(dteDenNgay.DateTime);
                ResetSoTrang();
                _STT = 1;
                LoadData(1, false);
            }
            catch
            { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            _ma_phieu = txtTimKiem.Text;
            ResetSoTrang();
            _STT = 1;
            LoadData(1, false);
        }    

        private void btCopY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mb_ThemMoi_SoPhieu = true;
                    mb_Sua_SoPhieu = false;
                    mbCopy_Phieu = true;
                    msTenSoPhieu = gridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                    mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                    SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222 ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222(this);
                    ff.Show();
                    //btRefresh_Click(null, null);
                    //Cursor.Current = Cursors.WaitCursor;
                    //UC_SanXuat_PhieuSanXuat_Load(sender, e);
                    //Cursor.Current = Cursors.Default;
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
            
        }

        //
        public void ResetSoTrang()
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_TongPhieuSX(_ngay_batdau, _ngay_ketthuc, _ma_phieu);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    //lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                    _TongSoTrang = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20));
                    lbTongSoTrang.Text = "/" + _TongSoTrang.ToString();
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

        //
        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (isload)
            //    return;
            //if (btnTrangTiep.LinkColor == Color.Black)
            //    return;
            //if (btnTrangSau.LinkColor == Color.Black)
            //    btnTrangSau.LinkColor = Color.Blue;

            //int sotrang_;
            //try
            //{
            //    sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            //    int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
            //    if (sotrang_ < max_)
            //    {
            //        txtSoTrang.Text = (sotrang_ + 1).ToString();

            //        Load_PhieuSX(false);
            //    }
            //    else
            //    {
            //        txtSoTrang.Text = (max_).ToString();
            //        btnTrangTiep.LinkColor = Color.Black;
            //    }
            //}
            //catch
            //{
            //    btnTrangTiep.LinkColor = Color.Black;
            //    sotrang_ = 1;
            //    txtSoTrang.Text = "1";
            //}

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
                    if (sotrang_ + 1 == _TongSoTrang)
                    {
                        btnTrangTiep.LinkColor = Color.Black;
                    }

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
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (isload)
            //    return;
            //if (btnTrangSau.LinkColor == Color.Black)
            //    return;
            //if (btnTrangTiep.LinkColor == Color.Black)
            //    btnTrangTiep.LinkColor = Color.Blue;

            //int sotrang_;
            //try
            //{
            //    sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            //    if (sotrang_ <= 1)
            //    {
            //        txtSoTrang.Text = "1";
            //        btnTrangSau.LinkColor = Color.Black;

            //    }
            //    else
            //    {
            //        txtSoTrang.Text = (sotrang_ - 1).ToString();
            //        Load_PhieuSX(false);
            //    }
            //}
            //catch
            //{
            //    btnTrangSau.LinkColor = Color.Black;
            //    sotrang_ = 1;
            //    txtSoTrang.Text = "1";
            //}
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
                    _STT = 1;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();

                    _STT -= (20 + _RowPage_curent);

                    if (sotrang_ - 1 == 1)
                    {
                        btnTrangSau.LinkColor = Color.Black;
                    }

                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
                _STT = 1;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteTuNgay.Focus();
            }
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
                gridControl1.Focus();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        //
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
            LoadData(sotrang_, islandau);
        }

        //
        private void txtSoTrang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }


    }
}
