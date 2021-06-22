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
        public static int mi_ID_BB_Ktra = -1;
        public static bool mbAdd_BB_Ktra = false;
        public static bool mb_Sua_BB_Ktra = false;
        public static bool mbCopy_BB_Ktra = false;
        public static DateTime mbNgayThang;
        public static string mbSoHieu;
        public static int mbID_BienBan;
        public static int mbCaSanXuat;
        public static string mbLoaiHang;
        public static string mbLoaiGiay;
        public static Double mbSoLuongKiemTra;
        public static string mbDonVi;
        public static Double mbTrongLuong;
        public static Double mbSoLuong;
        public static string mbDonVi_;
        public static Double mbQuyRaKien;
        public static Double mbPhePham;
        public static Double mbDoCao;
        public static Double mbMotBao_kg;
        public static Double mbMotBao_SoKien;
        public static Double mbSauMuoi_BaoKien;
        public static string mbGhiChu;
       
        public static DateTime madaNgayPhieu;
        

        public  DateTime _ngay_batdau;
        public  DateTime _ngay_ketthuc;
        public string _idBienBan;
        private int _SoTrang = 1;
        private bool isload = false;

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
            _idBienBan = txtTimKiem.Text;
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
                DataTable dt_ = cls_.SelectPage_BB_Ktra_DMHHSX(_SoTrang, _ngay_batdau, _ngay_ketthuc, _idBienBan);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_.Rows.Count; i++)
                    {
                        /*
                         * 	[Id_BB],
	[NgayThang],
	[SoHieu],
	[Ca],
	[LoaiHang],
	[LoaiGiay],
	[SoLuongKtra],
	[DonVi_first],
	[TrongLuong],
	[SoLuong],
	[DonVi_Second],
	[QuyRaKien],
	[PhePham],
	[DoCao],
	[MotBao_kg],
	[MotBao_SoKien],
	[SauMuoi_BaoKien],
	[GhiChu]*/
                        DataRow _ravi = dt2.NewRow();

                        _ravi["STT"] = (i+1).ToString();
                        _ravi["NgayThang"] = Convert.ToDateTime(dt_.Rows[i]["NgayThang"].ToString());
                        _ravi["SoHieu"] = dt_.Rows[i]["SoHieu"].ToString(); 
                        _ravi["ID_BienBan"] = Convert.ToInt32(dt_.Rows[i]["Id_BB"].ToString());
                        _ravi["CaSanXuat"] = Convert.ToInt32(dt_.Rows[i]["Ca"].ToString());
                        _ravi["LoaiHang"] = dt_.Rows[i]["LoaiHang"].ToString();
                        _ravi["LoaiGiay"] = dt_.Rows[i]["LoaiGiay"].ToString();
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

       
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_SoPhieu", typeof(int));
            //dt2.Columns.Add("MaPhieu", typeof(string));
            //dt2.Columns.Add("NgayLapPhieu", typeof(DateTime));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //dt2.Columns.Add("GuiDuLieu", typeof(bool));
            //dt2.Columns.Add("ID_CaTruong", typeof(int));
            //dt2.Columns.Add("DaKetThuc", typeof(bool));
            //dt2.Columns.Add("TenNhanVien", typeof(string));
            //dt2.Columns.Add("MaHang", typeof(string));
            //dt2.Columns.Add("CaSanXuat", typeof(string));
            //clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
            //DataTable dt = cls.SelectAll_W_TenCaTruong();           
            //dt.DefaultView.RowFilter = " NgayLapPhieu<='" + xxdenngay + "'";
            //DataView dv = dt.DefaultView;
            //DataTable dt22 = dv.ToTable();
            //dt22.DefaultView.RowFilter = " NgayLapPhieu>='" + xxtungay + "'";
            //DataView dv2 = dt22.DefaultView;
            //dv2.Sort = "GuiDuLieu ASC, NgayLapPhieu DESC, ID_SoPhieu DESC, CaSanXuat DESC";
            //DataTable dxxxx = dv2.ToTable();

            //if (dxxxx.Rows.Count > 0)
            //{

            //    for (int i = 0; i < dxxxx.Rows.Count; i++)
            //    {
            //        int ID_SoPhieu = Convert.ToInt32(dxxxx.Rows[i]["ID_SoPhieu"].ToString());
            //        DataRow _ravi = dt2.NewRow();
            //        _ravi["ID_SoPhieu"] = ID_SoPhieu;
            //        _ravi["MaPhieu"] = dxxxx.Rows[i]["MaPhieu"].ToString();
            //        _ravi["NgayLapPhieu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayLapPhieu"].ToString());
            //        _ravi["GhiChu"] = dxxxx.Rows[i]["GhiChu"].ToString();

            //        _ravi["GuiDuLieu"] = Convert.ToBoolean(dxxxx.Rows[i]["GuiDuLieu"].ToString());
            //        _ravi["ID_CaTruong"] = Convert.ToInt32(dxxxx.Rows[i]["ID_CaTruong"].ToString());
            //        _ravi["DaKetThuc"] = Convert.ToBoolean(dxxxx.Rows[i]["DaKetThuc"].ToString());
            //        _ravi["TenNhanVien"] = dxxxx.Rows[i]["TenNhanVien"].ToString();
            //        _ravi["CaSanXuat"] = dxxxx.Rows[i]["CaSanXuat"].ToString();
            //        clsPhieu_ChiTietPhieu_New clsphieu = new clsPhieu_ChiTietPhieu_New();
            //        clsphieu.iID_SoPhieu = ID_SoPhieu;
            //        DataTable dtphieu = clsphieu.SelectAll_W_iID_SoPhieu();
            //        if (dtphieu.Rows.Count > 0)
            //        {
            //            dtphieu.DefaultView.RowFilter = "bMay_IN= True";
            //            DataView dvphieu = dtphieu.DefaultView;
            //            DataTable dxxxxphieu = dvphieu.ToTable();
            //            if (dxxxxphieu.Rows.Count > 0)
            //            {
            //                int ID_VTHH_Ra = Convert.ToInt32(dxxxxphieu.Rows[0]["ID_VTHH_Ra"].ToString());
            //                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            //                clsvt.iID_VTHH = ID_VTHH_Ra;
            //                DataTable dtvt = clsvt.SelectOne();
            //                _ravi["MaHang"] = clsvt.sTenVTHH.Value;
            //            }

            //        }

            //        dt2.Rows.Add(_ravi);
            //    }
            //}
            //gridControl1.DataSource = dt2;
           
        }
        SanXuat_frmQuanLySanXuat _frmQLSX;
        public Tr_UC_BB_Ktra_DM_HHSX(SanXuat_frmQuanLySanXuat frmQLSX)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();
        }

        private void Tr_UC_BB_Ktra_DM_HHSX_Load(object sender, EventArgs e)
        {
            //clCaLamViec.Caption = "Ca\n làm việc";
          //  HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
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
            //try
            //{
            //    if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
            //    {
            //        mb_ThemMoi_SoPhieu = false;
            //        mb_Sua_SoPhieu = true;
            //        mbCopy_Phieu = false;
            //        msTenSoPhieu = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString();
            //        mID_iD_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //        SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222 ff = new CtyTinLuong.SanXuat_frmChiTietSoPhieu_IN_CAT_DOT_NEW2222();
            //        ff.Show();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();
            //DialogResult traloi;
            //traloi = MessageBox.Show("Xóa dữ liệu này. Lưu ý sẽ mất hế dữ liệu?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (traloi == DialogResult.Yes)
            //{
            //    int xxiID_SoPhieu= Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
            //    cls1.iID_SoPhieu = xxiID_SoPhieu;
            //    cls1.Delete();
            //    clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
            //    cls2.iID_SoPhieu = xxiID_SoPhieu;
            //    cls2.Delete_All_W_ID_SoPhieu();
            //    // xoá chi tiet lenh sản xuất
            //    clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls3 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            //    cls3.iID_SoPhieu = xxiID_SoPhieu;
            //    cls3.Delete_ALL_W_ID_SoPhieu();
            //    // xoá lenh san xuat
            //    cls3.iID_SoPhieu = xxiID_SoPhieu;
            //    DataTable dt4 = cls3.SelectAll_W_ID_SoPhieu();
            //    if(dt4.Rows.Count>0)
            //    {
            //        for(int i=0; i<=dt4.Rows.Count; i++)
            //        {
            //            int ID_LenhSanXuatxx = Convert.ToInt32(dt4.Rows[i]["ID_LenhSanXuat"].ToString());
            //            clsHUU_LenhSanXuat cls4 = new clsHUU_LenhSanXuat();
            //            cls4.iID_LenhSanXuat = ID_LenhSanXuatxx;
            //            cls4.Delete();
            //        }
            //    }
            //    MessageBox.Show("Đã xóa");
            //    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            //    {
            //        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //    }
            //    else
            //    {
            //        //  HienThi_ALL();ien
            //        LoadData(_SoTrang, false);
            //    }

            //}

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
            mbAdd_BB_Ktra = true;
            mbCopy_BB_Ktra = false;
            mb_Sua_BB_Ktra = false;

            //
            Tr_frmChiTietBB_Ktra_DMHH ff = new Tr_frmChiTietBB_Ktra_DMHH();
            _frmQLSX.Hide();
            ff.ShowDialog();
            _frmQLSX.Show();
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;

            try
            {
                _ngay_batdau = Convert.ToDateTime(dteTuNgay.DateTime);
                _frmQLSX.ResetSoTrang();
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
                _frmQLSX.ResetSoTrang();
                LoadData(1, false);
            }
            catch
            { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            _idBienBan = txtTimKiem.Text;
            _frmQLSX.ResetSoTrang_BB();
            LoadData(1, false);
        }    

        private void btCopY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_BienBan).ToString() != "")
                {
                    mbAdd_BB_Ktra = true;
                    mb_Sua_BB_Ktra = false;
                    mbCopy_BB_Ktra = true;

                    mbNgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayThang).ToString());
                    mbSoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString().Trim();
                    mbID_BienBan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BienBan).ToString());
                    mbCaSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clCaLamViec).ToString());
                    mbLoaiHang = gridView1.GetFocusedRowCellValue(clLoaiHang).ToString().Trim();
                    mbLoaiGiay = gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString().Trim();
                    mbSoLuongKiemTra = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongKiemTra).ToString());
                    mbDonVi = gridView1.GetFocusedRowCellValue(clDonVi).ToString().Trim();
                    mbTrongLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clTrongLuong).ToString());
                    mbSoLuong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong).ToString());
                    mbDonVi_ = gridView1.GetFocusedRowCellValue(clDonVi_).ToString().Trim();
                    mbQuyRaKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clQuyRaKien).ToString());
                    mbPhePham = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clPhePham).ToString());
                    mbDoCao = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDoCao).ToString());
                    mbMotBao_kg = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_kg).ToString());
                    mbMotBao_SoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clMotBao_SoKien).ToString());
                    mbSauMuoi_BaoKien = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSauMuoi_BaoKien).ToString());
                    mbGhiChu = gridView1.GetFocusedRowCellValue(clGhiChu).ToString().Trim();

                    Tr_frmChiTietBB_Ktra_DMHH ff = new Tr_frmChiTietBB_Ktra_DMHH();
                    _frmQLSX.Hide();
                    ff.ShowDialog();
                    _frmQLSX.Show();
                }
            }
            catch
            {

            }

        }
    }
}
