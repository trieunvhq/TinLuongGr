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
    public partial class Tr_UC_BB_Ktra_DM_HHSX : UserControl
    {
        public static bool mbAdd_BB_Ktra = false;
        public static bool mb_Sua_BB_Ktra = false;
        public static bool mbCopy_BB_Ktra = false;
        public static DateTime mdNgayThang;
        public static string msSoHieu;
        public static int miID_BienBan;
        public static int miCaSanXuat;
        public static string msLoaiHang;
        public static string msLoaiGiay;
        public static Double mfSoLuongKiemTra;
        public static string msDonVi;
        public static Double mfTrongLuong;
        public static Double mfSoLuong;
        public static string msDonVi_;
        public static Double mfQuyRaKien;
        public static Double mfPhePham;
        public static Double mfDoCao;
        public static Double mfMotBao_kg;
        public static Double mfMotBao_SoKien;
        public static Double mfSauMuoi_BaoKien;
        public static string msGhiChu;
       

        public  DateTime _ngay_batdau;
        public  DateTime _ngay_ketthuc;
        public string _sSearch;
        private int _SoTrang = 1;
        private bool isload = false;
        private int _STT = 1;
        private int _RowPage_curent = 0;
        private int _TongSoTrang = 0;


        SanXuat_frmQuanLySanXuat _frmQLSX;


        public void LoadData(int sotrang, bool isLoadLanDau)
        {
            isload = true;
            if (isLoadLanDau)
            {
                dteTuNgay.EditValue = DateTime.Now.AddDays(-30);
                dteDenNgay.EditValue = DateTime.Now;
                txtTimKiem.Text = "";
            }
            else { }
            _sSearch = txtTimKiem.Text;
            _ngay_batdau = (DateTime)dteTuNgay.EditValue;
            _ngay_ketthuc = dteDenNgay.DateTime;
            _SoTrang = sotrang;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("STT", typeof(int));
            dt2.Columns.Add("NgayThang", typeof(DateTime));
            dt2.Columns.Add("SoHieu", typeof(string));
            dt2.Columns.Add("ID_BienBan", typeof(int));
            dt2.Columns.Add("CaSanXuat", typeof(int));
            dt2.Columns.Add("LoaiHang", typeof(string));
            dt2.Columns.Add("LoaiGiay", typeof(string));
            dt2.Columns.Add("SoLuongKiemTra", typeof(Double));
            dt2.Columns.Add("DonVi", typeof(string));
            dt2.Columns.Add("TrongLuong", typeof(Double));
            dt2.Columns.Add("SoLuong", typeof(Double));
            dt2.Columns.Add("DonVi_", typeof(string));
            dt2.Columns.Add("QuyRaKien", typeof(Double));
            dt2.Columns.Add("PhePham", typeof(Double));
            dt2.Columns.Add("DoCao", typeof(Double));
            dt2.Columns.Add("MotBao_kg", typeof(Double));
            dt2.Columns.Add("MotBao_SoKien", typeof(Double));
            dt2.Columns.Add("SauMuoi_BaoKien", typeof(Double));
            dt2.Columns.Add("GhiChu", typeof(string));

            using (clsTr_BB_KtraDinhMuc_HHSX cls_ = new clsTr_BB_KtraDinhMuc_HHSX())
            {
                DataTable dt_ = cls_.SelectPage_BB_Ktra_DMHHSX(_SoTrang, _ngay_batdau, _ngay_ketthuc, _sSearch);

                _RowPage_curent = dt_.Rows.Count;

                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_.Rows.Count; i++)
                    {
                        DataRow _ravi = dt2.NewRow();

                        _ravi["STT"] = _STT.ToString(); _STT++;
                        _ravi["NgayThang"] = Convert.ToDateTime(dt_.Rows[i]["NgayThang"].ToString());
                        _ravi["SoHieu"] = dt_.Rows[i]["SoHieu"].ToString(); 
                        _ravi["ID_BienBan"] = Convert.ToInt32(dt_.Rows[i]["Id_BB"].ToString());
                        _ravi["CaSanXuat"] = Convert.ToInt32(dt_.Rows[i]["Ca"].ToString());
                        _ravi["LoaiHang"] = dt_.Rows[i]["LoaiHang"].ToString().Trim();
                        _ravi["LoaiGiay"] = dt_.Rows[i]["LoaiGiay"].ToString().Trim();
                        _ravi["SoLuongKiemTra"] = Convert.ToDouble(dt_.Rows[i]["SoLuongKtra"].ToString());
                        _ravi["DonVi"] = dt_.Rows[i]["DonVi_first"].ToString();
                        _ravi["TrongLuong"] = Convert.ToDouble(dt_.Rows[i]["TrongLuong"].ToString());
                        _ravi["SoLuong"] = Convert.ToDouble(dt_.Rows[i]["SoLuong"].ToString());
                        _ravi["DonVi_"] = dt_.Rows[i]["DonVi_Second"].ToString();
                        _ravi["QuyRaKien"] = Convert.ToDouble(dt_.Rows[i]["QuyRaKien"].ToString());
                        _ravi["PhePham"] = Convert.ToDouble(dt_.Rows[i]["PhePham"].ToString());
                        _ravi["DoCao"] = Convert.ToDouble(dt_.Rows[i]["DoCao"].ToString());
                        _ravi["MotBao_kg"] = Convert.ToDouble(dt_.Rows[i]["MotBao_kg"].ToString());
                        _ravi["MotBao_SoKien"] = Convert.ToDouble(dt_.Rows[i]["MotBao_SoKien"].ToString());
                        _ravi["SauMuoi_BaoKien"] = Convert.ToDouble(dt_.Rows[i]["SauMuoi_BaoKien"].ToString());
                        _ravi["GhiChu"] = dt_.Rows[i]["GhiChu"].ToString();

                        dt2.Rows.Add(_ravi);
                    }
                }
            }
            gridControl1.DataSource = dt2;

            isload = false;
        }

       

        public Tr_UC_BB_Ktra_DM_HHSX(SanXuat_frmQuanLySanXuat frmQLSX)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();

            clSoLuongKiemTra.Caption = "Số lượng\nkiểm tra";
            clTrongLuong.Caption = "Trọng\nlượng";
        }

        private void Tr_UC_BB_Ktra_DM_HHSX_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _STT = 1;
            LoadData(1, true);
            ResetSoTrang_BB();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_UC_BB_Ktra_DM_HHSX_Load(sender, e);
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
                if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAdd_BB_Ktra = false;
                    mb_Sua_BB_Ktra = true;
                    mbCopy_BB_Ktra = true;

                    //
                    mdNgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayThang).ToString());
                    msSoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString().Trim();
                    miID_BienBan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
                    miCaSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clCaLamViec).ToString());
                    msLoaiHang = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString().Trim();
                    msLoaiGiay = gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString().Trim();
                    mfSoLuongKiemTra = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongKiemTra).ToString());
                    msDonVi = gridView1.GetFocusedRowCellValue(clDonVi).ToString().Trim();
                    mfTrongLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clTrongLuong).ToString());
                    mfSoLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong).ToString());
                    msDonVi_ = gridView1.GetFocusedRowCellValue(clDonVi_).ToString().Trim();
                    mfQuyRaKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clQuyRaKien).ToString());
                    mfPhePham = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clPhePham).ToString());
                    mfDoCao = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDoCao).ToString());
                    mfMotBao_kg = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_kg).ToString());
                    mfMotBao_SoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_SoKien).ToString());
                    mfSauMuoi_BaoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSauMuoi_BaoKien).ToString());
                    msGhiChu = gridView1.GetFocusedRowCellValue(clGhiChu).ToString().Trim();

                    Tr_frmChiTietBB_Ktra_DMHH ff = new Tr_frmChiTietBB_Ktra_DMHH();
                    //_frmQLSX.Hide();
                    ff.ShowDialog();
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
            Cursor.Current = Cursors.WaitCursor;

            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();
            cls.iId_BB = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu tại dòng: \n"
                + "STT: " + gridView1.GetFocusedRowCellValue(clSTT).ToString() + " | "
                + "Ngày: " + Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayThang).ToString()).ToString("dd/MM/yyyy") + " | "
                + "Ca: " + gridView1.GetFocusedRowCellValue(clCaLamViec).ToString() + " | "
                + "Loại Hàng: " + gridView1.GetFocusedRowCellValue(clLoaiHang).ToString()
                + "...", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                if (cls.Delete())
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _STT -= _RowPage_curent;
                    LoadData(_SoTrang, false);
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại. Kiểm tra lại kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            Cursor.Current = Cursors.Default;
        }


        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{

            //    clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
            //    cls.iID_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString());
            //    cls.Update_NgungTheoDoi();
            //}
            //catch
            //{

            //}
        }

     
        private void btChiTiet_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
            //    {
            //        msTenSoPhieu = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString();
            //        mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //        SanXuat_frmChiTietSoPhieu_RutGon ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_RutGon();
            //        ff.Show();
            //    }
            //}
            //catch
            //{

            //}
        }


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
            //    if (category == false)
            //    {
            //        e.Appearance.BackColor = Color.Bisque;
                  
            //    }
            //}
        }

        private void btThemMoi_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            mbAdd_BB_Ktra = true;
            mbCopy_BB_Ktra = false;
            mb_Sua_BB_Ktra = false;

            //
            Tr_frmChiTietBB_Ktra_DMHH ff = new Tr_frmChiTietBB_Ktra_DMHH();
            //_frmQLSX.Hide();
            ff.ShowDialog();
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
                ResetSoTrang_BB();
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
            try
            {
                _ngay_ketthuc = Convert.ToDateTime(dteDenNgay.DateTime);
                ResetSoTrang_BB();
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
            _sSearch = txtTimKiem.Text;
            ResetSoTrang_BB();
            _STT = 1;
            LoadData(1, false);
        }    

        private void btCopY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;

                    mbAdd_BB_Ktra = true;
                    mb_Sua_BB_Ktra = false;
                    mbCopy_BB_Ktra = true;

                    mdNgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayThang).ToString());
                    msSoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString().Trim();
                    miID_BienBan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
                    miCaSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clCaLamViec).ToString());
                    msLoaiHang = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString().Trim();
                    msLoaiGiay = gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString().Trim();
                    mfSoLuongKiemTra = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongKiemTra).ToString());
                    msDonVi = gridView1.GetFocusedRowCellValue(clDonVi).ToString().Trim();
                    mfTrongLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clTrongLuong).ToString());
                    mfSoLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong).ToString());
                    msDonVi_ = gridView1.GetFocusedRowCellValue(clDonVi_).ToString().Trim();
                    mfQuyRaKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clQuyRaKien).ToString());
                    mfPhePham = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clPhePham).ToString());
                    mfDoCao = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDoCao).ToString());
                    mfMotBao_kg = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_kg).ToString());
                    mfMotBao_SoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_SoKien).ToString());
                    mfSauMuoi_BaoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSauMuoi_BaoKien).ToString());
                    msGhiChu = gridView1.GetFocusedRowCellValue(clGhiChu).ToString().Trim();

                    Tr_frmChiTietBB_Ktra_DMHH ff = new Tr_frmChiTietBB_Ktra_DMHH();
                    //_frmQLSX.Hide();
                    ff.ShowDialog();
                    //_frmQLSX.Show();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }

        }

        //
        public void ResetSoTrang_BB()
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX())
            {
                DataTable dt_ = cls.T_TongSoBB(_ngay_batdau, _ngay_ketthuc, _sSearch);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
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

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

                    Load_BBKtraHHSX(false);
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

                    Load_BBKtraHHSX(false);
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

        private void Load_BBKtraHHSX(bool islandau)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Tr_frmPrintBB_Ktra_DM_HHSX ff = new Tr_frmPrintBB_Ktra_DM_HHSX(_ngay_batdau, _ngay_ketthuc);
            ff.ShowDialog();
        }
    }
}
