using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class QuyNganHang_Frm_PhieuKeToan : Form
    {
        DataTable dtdoituong = new DataTable();


        public static DataTable mdtPrint;
        public static bool mbPrint = false;
        public static bool mbTienUSD;
        public static DateTime mdaNgayThang;
        public static string msDiaChi, msLoaiChungTu, msSoChungTu, msNguoiNopTen, msTaiKhoan_No, ms_TaiKhoanCo, msDienGiai;
        public static double mdbSoTien_Co_USD, mdbSoTien_No_VND, mdbTiGia;
        private int _ID_ThuChixxx = 0;

        private void Luu_BienDongTaiKhoanKeToan(int xxxID_ThuChi)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clsxx.iID_ChungTu = xxxID_ThuChi;
            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
            clsxx.daNgayThang = dteNgayChungTu.DateTime;

            DataTable dt2_cu = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
            if (dt2_cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_cu.Rows.Count; i++)
                {
                    clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    clsxx.bTonTai = false;
                    clsxx.Update_W_TonTai();
                }
            }

            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dv.ToTable();


            clsxx = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanConxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                double TiGia;
                if (dt_gridcontrol.Rows[i]["TiGia"].ToString() == "")
                    TiGia = 0;
                else TiGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["TiGia"].ToString());
                clsxx.iID_ChungTu = xxxID_ThuChi;
                clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                clsxx.daNgayThang = dteNgayChungTu.DateTime;
                clsxx.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                clsxx.fCo = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["Co"].ToString());
                clsxx.fNo = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["No"].ToString());

                if (dt_gridcontrol.Rows[i]["TienUSD"].ToString() != "")
                    clsxx.bTienUSD = Convert.ToBoolean(dt_gridcontrol.Rows[i]["TienUSD"].ToString());
                else clsxx.bTienUSD = false;

                clsxx.fTiGia = TiGia;
                clsxx.bTonTai = true;
                clsxx.bNgungTheoDoi = false;
                clsxx.bDaGhiSo = true;
                clsxx.bBBool_TonDauKy = false;
                clsxx.sDienGiai = txtDienGiai.Text.ToString();
                clsxx.bCheck_PhanNganHang = true;
                clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 0;


                string expressionnhapkho;
                expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    clsxx.Update();
                }
                else
                {
                    clsxx.Insert();
                }

            }
            // xoá tồn tại = false
            DataTable dt2_moi11111 = new DataTable();
            clsxx = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clsxx.iID_ChungTu = xxxID_ThuChi;
            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
            clsxx.daNgayThang = dteNgayChungTu.DateTime;
            dt2_moi11111 = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int xxxID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                clsxx.iID_ChiTietBienDongTaiKhoan = xxxID_ChiTietBienDongTaiKhoan;
                clsxx.Delete();
            }
        }
        private void Luu_ChiTiet_ThuChi(int xxxID_ThuChi)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsNganHang_tbThuChi_ChiTietThuChi cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();
                DataTable dt2_cu = new DataTable();

                cls2.iID_ThuChi = xxxID_ThuChi;
                dt2_cu = cls2.SelectAll_W_ID_ThuChi();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        cls2.iID_ThuChi = xxxID_ThuChi;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai();
                    }
                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    int ID_TaiKhoanKeToanConxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                    double TiGia;
                    if (dt_gridcontrol.Rows[i]["TiGia"].ToString() == "")
                        TiGia = 0;
                    else TiGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["TiGia"].ToString());
                    cls2.iID_ThuChi = xxxID_ThuChi;
                    cls2.iID_TaiKhoanKeToanCon = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    cls2.fCo = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["Co"].ToString());
                    cls2.fNo = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["No"].ToString());

                    if (dt_gridcontrol.Rows[i]["TienUSD"].ToString() != "")
                        cls2.bTienUSD = Convert.ToBoolean(dt_gridcontrol.Rows[i]["TienUSD"].ToString());
                    else cls2.bTienUSD = false;

                    cls2.fTiGia = TiGia;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaGhiSo = true;
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();

                    string expressionnhapkho;
                    expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietThuChi = Convert.ToInt32(foundRows[0]["ID_ChiTietThuChi"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2 = new CtyTinLuong.clsNganHang_tbThuChi_ChiTietThuChi();
                cls2.iID_ThuChi = xxxID_ThuChi;
                dt2_moi11111 = cls2.SelectAll_W_ID_ThuChi();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietThuChixxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietThuChi"].ToString());
                    cls2.iID_ChiTietThuChi = ID_ChiTietThuChixxx;
                    cls2.Delete();
                }

            }
        }
        private void LuuDuLieu_Va_GhiSo(int bienthangthai)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.fSoTien = CheckString.ConvertToDouble_My(txtSoTien.Text.ToString());
                cls1.sThamChieu = "Phiếu kế toán"; 
                cls1.sDoiTuong = txtDoiTuong.Text.ToString();
                cls1.bTonTai = true;
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = checkUSD.Checked;
                cls1.fTiGia = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 = bienthangthai;
                cls1.bDaGhiSo = true;
                cls1.iBienMuaHang1_BanHang2_ConLai_0 = 0;

                if (UCQuy_NganHang_BaoCo.mbSua == false)
                {
                    cls1.Insert();
                    _ID_ThuChixxx = cls1.iID_ThuChi.Value;

                }
                else
                {
                    _ID_ThuChixxx = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
                    cls1.iID_ThuChi = _ID_ThuChixxx;
                    cls1.Update();
                }
                Luu_ChiTiet_ThuChi(_ID_ThuChixxx);
                Luu_BienDongTaiKhoanKeToan(_ID_ThuChixxx);

                MessageBox.Show("Đã lưu");
            }
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiMuaHang.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clSoTaiKhoanCon)
                {
                    double tigiaxx = CheckString.ConvertToDouble_My(txtTiGia.Text);

                    //gridView4.SetRowCellValue(e.RowHandle, clNo, 0);
                    //gridView4.SetRowCellValue(e.RowHandle, clCo, 0);

                    clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                    cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    DataTable dt = cls.SelectOne();
                    gridView4.SetRowCellValue(e.RowHandle, clID_TaiKhoanKeToanCon, kk);
                    gridView4.SetRowCellValue(e.RowHandle, clTenTaiKhoanCon, dt.Rows[0]["TenTaiKhoanCon"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView4.SetRowCellValue(e.RowHandle, clTienUSD, checkUSD.Checked);
                    gridView4.SetFocusedRowCellValue(clTiGia, tigiaxx);

                }

            }
            catch
            {
            }
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sotienxxx = CheckString.ConvertToDouble_My(txtSoTien.Text.ToString());
                double tigiaxxx = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
                gridView4.SetRowCellValue(0, clNo, sotienxxx);
                gridView4.SetRowCellValue(0, clCo, 0);

                gridView4.SetRowCellValue(1, clNo, 0);
                gridView4.SetRowCellValue(1, clCo, sotienxxx);
               
            }
            catch
            {
            }
        }

        private void txtTiGia_TextChanged(object sender, EventArgs e)
        {
            if (txtTiGia.Text.ToString() != "1")
            {
                double tigiaxx = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
              

               
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                try
                {
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TiGia"] = tigiaxx;
                        }
                        gridControl1.DataSource = dttttt2;
                    }
                    
                }
                catch
                {
                }

            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GhiSo(6);
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.SetFocusedRowCellValue(clHienThi, "0");
            gridView4.SetFocusedRowCellValue(clNo, 0);
            gridView4.SetFocusedRowCellValue(clCo, 0);
        }

        private void btthemmoi_Click(object sender, EventArgs e)
        {
            UCQuy_NganHang_BaoCo.mbTheMoi = true;
            HienThi_ThemMoi(6);
            txtSoTien.Text = "0";
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void txtSoTien_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtSoTien.Text);
                txtSoTien.Text = String.Format("{0:#,##0.00}", value);
                double sotienxxx = CheckString.ConvertToDouble_My(txtSoTien.Text.ToString());

            }
            catch
            {

            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();

        }

        private void txtSoTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    decimal value = decimal.Parse(txtSoTien.Text);
                    txtSoTien.Text = String.Format("{0:#,##0.00}", value);
                    double sotienxxx = CheckString.ConvertToDouble_My(txtSoTien.Text.ToString());

                }
                catch
                {

                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.isPrintPhieuKeToan)
                {
                    if (_ID_ThuChixxx == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Tr_frmPrintPhieuKeToanVAT ff = new Tr_frmPrintPhieuKeToanVAT(_ID_ThuChixxx);
                        ff.Show();
                    }
                }
                else
                {
                    mbPrint = true;
                    DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                    CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
                    string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                    DataView dv1212 = new DataView(DatatableABC);
                    dv1212.RowFilter = filterString;
                    DataTable dttttt2 = dv1212.ToTable();
                    string shienthi = "1";
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    mdtPrint = dv.ToTable();

                    //mbTienUSD = checkUSD.Checked;
                    mdaNgayThang = dteNgayChungTu.DateTime;
                    msNguoiNopTen = txtDoiTuong.Text.ToString();
                    msDiaChi = txtDoiTuong.Text.ToString();
                    msDienGiai = txtDienGiai.Text.ToString();
                    msSoChungTu = txtSoChungTu.Text.ToString();
                    string Str1 = msSoChungTu.Substring(0, 2);//Cắt chuỗi từ vị trí đầu tiên(vị trí 0) đến vị trí số 2
                    if (Str1 == "BC")
                        msLoaiChungTu = "BÁO CÓ";
                    if (Str1 == "BN")
                        msLoaiChungTu = "BÁO NỢ";
                    if (Str1 == "PT")
                        msLoaiChungTu = "PHIẾU THU";
                    if (Str1 == "PC")
                        msLoaiChungTu = "PHIẾU CHI";
                    if (Str1 == "DT")
                        msLoaiChungTu = "BÁO CÓ";
                    if (Str1 == "PKT")
                        msLoaiChungTu = "PHIẾU KẾ TOÁN";
                    mdbSoTien_Co_USD = CheckString.ConvertToDouble_My(txtSoTien.Text.ToString());
                    //mdbSoTien_No_VND = CheckString.ConvertToDouble_My(txtTienVND.Text.ToString());
                    mdbTiGia = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
                    for (int i = 0; i < mdtPrint.Rows.Count; i++)
                    {
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        if (CheckString.ConvertToDouble_My(mdtPrint.Rows[i]["No"].ToString()) == 0 & CheckString.ConvertToDouble_My(mdtPrint.Rows[i]["Co"].ToString()) > 0)
                        {
                            clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(mdtPrint.Rows[i]["SoTaiKhoanCon"].ToString());
                            DataTable dtcon = clscon.SelectOne();
                            ms_TaiKhoanCo = clscon.sSoTaiKhoanCon.Value;
                        }
                        if (CheckString.ConvertToDouble_My(mdtPrint.Rows[i]["No"].ToString()) > 0 & CheckString.ConvertToDouble_My(mdtPrint.Rows[i]["Co"].ToString()) == 0)
                        {
                            clscon.iID_TaiKhoanKeToanCon = Convert.ToInt32(mdtPrint.Rows[i]["SoTaiKhoanCon"].ToString());
                            DataTable dtcon = clscon.SelectOne();
                            msTaiKhoan_No = clscon.sSoTaiKhoanCon.Value;
                        }
                    }

                    frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No ff = new frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No();
                    ff.Show();
                }
            }
            catch { }
        }

        private void QuyNganHang_Frm_PhieuKeToan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dtdoituong = new DataTable();
            dtdoituong.Columns.Add("ID_DoiTuong", typeof(int));
            dtdoituong.Columns.Add("MaDoiTuong", typeof(string));
            dtdoituong.Columns.Add("TenDoiTuong", typeof(string));
            dtdoituong.Columns.Add("ID_TaiKhoanKeToan", typeof(int));
            Load_LockUp();

            if (UCQuy_NganHang_BaoCo.mbTheMoi == true)
                HienThi_ThemMoi(frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
            else if (UCQuy_NganHang_BaoCo.mbSua == true)
                HienThi_Sua();
            else if (UCQuy_NganHang_BaoCo.mbCoPy == true)
                HienThi_CoPy(frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
            Cursor.Current = Cursors.Default;
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteNgayChungTu.Focus();
            }
        }

        private void txtNguoiMuaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgayChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridDoiTuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDoiTuong.Focus();
            }
        }

        private void txtDoiTuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void checkVNĐ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void checkUSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTiGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbNhaCungCap cls = new clsTbNhaCungCap();
                cls.iID_NhaCungCap = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtDoiTuong.Text = dt.Rows[0]["TenNhaCungCap"].ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void checkVNĐ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVNĐ.Checked == true)
                checkUSD.Checked = false;
        }

        private void checkUSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUSD.Checked == true)
                checkVNĐ.Checked = false;
        }

        private bool KiemTraLuu()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;

            if (dttttt2.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu ghi tài khoản kế toán ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (txtSoTien.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số tiền ");
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người mua hàng ");
                return false;
            }
           
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }

            else return true;

        }

        private void HienThi_ThemMoi(int bientrangthia)
        {
            checkVNĐ.Checked = true;

            gridNguoiLap.EditValue = 13;
          
            dteNgayChungTu.EditValue = DateTime.Today;
            HienThiSoChungTu(bientrangthia);
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_ChiTietThuChi", typeof(int));
            dt2.Columns.Add("ID_ThuChi", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2.Columns.Add("No", typeof(double));
            dt2.Columns.Add("Co", typeof(double));
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("TiGia", typeof(double));
            dt2.Columns.Add("DaGhiSo", typeof(bool));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon", typeof(string));
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));

            //DataRow _ravi = dt2.NewRow();
            //_ravi["ID_TaiKhoanKeToanCon"] = 4;
            //_ravi["SoTaiKhoanCon"] = "1121.2";
            //_ravi["TenTaiKhoanCon"] = "VCB-VNĐ";
            //_ravi["No"] = 0;
            //_ravi["Co"] = 0;
            //_ravi["TienUSD"] = false;
            //_ravi["TiGia"] = 1;
            //_ravi["DaGhiSo"] = false;
            //_ravi["GhiChu"] = "";
            //_ravi["HienThi"] = "1";
            //dt2.Rows.Add(_ravi);

            //DataRow _ravi2 = dt2.NewRow();
            //_ravi2["ID_TaiKhoanKeToanCon"] = 10;
            //_ravi2["SoTaiKhoanCon"] = "1122.2";
            //_ravi2["TenTaiKhoanCon"] = "VCB USD";
            //_ravi2["No"] = 0;
            //_ravi2["Co"] = 0;
            //_ravi2["TienUSD"] = true;
            //_ravi2["TiGia"] = 1;
            //_ravi2["DaGhiSo"] = false;
            //_ravi2["GhiChu"] = "";
            //_ravi2["HienThi"] = "1";
            //dt2.Rows.Add(_ravi2);

            gridControl1.DataSource = dt2;

        }
        private void HienThi_Sua()
        {
            _ID_ThuChixxx = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
            clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
            cls1.iID_ThuChi = _ID_ThuChixxx;
            DataTable dt = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiLap.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            //txtThamChieu.Text = cls1.sThamChieu.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtTiGia.Text = cls1.fTiGia.Value.ToString();
            if (cls1.bTienUSD == true) checkUSD.Checked = true;
            else checkVNĐ.Checked = true;
            if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
                gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;

            clsNganHang_tbThuChi_ChiTietThuChi cls2 = new clsNganHang_tbThuChi_ChiTietThuChi();
            cls2.iID_ThuChi = _ID_ThuChixxx;
            DataTable dt3 = cls2.SelectAll_W_ID_ThuChi();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_ChiTietThuChi", typeof(int));
            dt2.Columns.Add("ID_ThuChi", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2.Columns.Add("No", typeof(double));
            dt2.Columns.Add("Co", typeof(double));
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("TiGia", typeof(double));
            dt2.Columns.Add("DaGhiSo", typeof(bool));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon");
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanCon = Convert.ToInt32(dt3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                DataTable dtcon = clscon.SelectOne();
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ChiTietThuChi"].ToString());
                _ravi["ID_ThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ThuChi"].ToString());
                _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt32(ID_TaiKhoanKeToanCon.ToString());
                _ravi["No"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["No"].ToString());
                _ravi["Co"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Co"].ToString());
                _ravi["TienUSD"] = Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                _ravi["TiGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TiGia"].ToString());
                _ravi["DaGhiSo"] = Convert.ToBoolean(dt3.Rows[i]["DaGhiSo"].ToString());
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;

            //if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
            //    gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;
        }

        private void HienThi_CoPy(int bientrangthia)
        {
            _ID_ThuChixxx = UCQuy_NganHang_BaoCo.miID_ThuChi_Sua;
            clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
            cls1.iID_ThuChi = _ID_ThuChixxx;
            DataTable dt = cls1.SelectOne();


            dteNgayChungTu.EditValue = DateTime.Today;
            HienThiSoChungTu(bientrangthia);

            gridNguoiLap.EditValue = cls1.iID_NguoiLap.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            //txtThamChieu.Text = cls1.sThamChieu.Value;
            txtSoTien.Text = cls1.fSoTien.Value.ToString();
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtTiGia.Text = cls1.fTiGia.Value.ToString();

            //if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
            //    gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;


            clsNganHang_tbThuChi_ChiTietThuChi cls2 = new clsNganHang_tbThuChi_ChiTietThuChi();
            cls2.iID_ThuChi = _ID_ThuChixxx;
            DataTable dt3 = cls2.SelectAll_W_ID_ThuChi();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_ChiTietThuChi", typeof(int));
            dt2.Columns.Add("ID_ThuChi", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2.Columns.Add("No", typeof(double));
            dt2.Columns.Add("Co", typeof(double));
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("TiGia", typeof(double));
            dt2.Columns.Add("DaGhiSo", typeof(bool));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("SoTaiKhoanCon");
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanCon = Convert.ToInt32(dt3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                DataTable dtcon = clscon.SelectOne();
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ChiTietThuChi"].ToString());
                _ravi["ID_ThuChi"] = Convert.ToInt32(dt3.Rows[i]["ID_ThuChi"].ToString());
                _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt32(ID_TaiKhoanKeToanCon.ToString());
                _ravi["No"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["No"].ToString());
                _ravi["Co"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Co"].ToString());
                _ravi["TienUSD"] = Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                _ravi["TiGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TiGia"].ToString());
                _ravi["DaGhiSo"] = Convert.ToBoolean(dt3.Rows[i]["DaGhiSo"].ToString());
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;

            //if (dt.Rows[0]["ID_DoiTuong"].ToString() != "")
            //    gridDoiTuong.EditValue = cls1.iID_DoiTuong.Value;
        }

        private void Load_LockUp()
        {
            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtcon = clscon.SelectAll();
            dtcon.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvcon = dtcon.DefaultView;
            DataTable newdtcon = dvcon.ToTable();

            repositoryItemSearchLookUpEdit1.DataSource = newdtcon;
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_TaiKhoanKeToanCon";
            repositoryItemSearchLookUpEdit1.DisplayMember = "SoTaiKhoanCon";

            //Thay caption:
            repositoryItemSearchLookUpEdit1.View.Columns.Clear();//xóa caption cũ
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("ID_TaiKhoanKeToanCon", "ID");
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("SoTaiKhoanCon", "Mã");
            repositoryItemSearchLookUpEdit1.View.Columns.AddVisible("TenTaiKhoanCon", "Tên");

            repositoryItemSearchLookUpEdit1.View.Columns["ID_TaiKhoanKeToanCon"].Visible = false;

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            DataTable dt3 = cls.SelectAll();         
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = dtdoituong.NewRow();
                _ravi["ID_DoiTuong"] = Convert.ToInt32(dt3.Rows[i]["ID_NhaCungCap"].ToString());
                _ravi["MaDoiTuong"] = dt3.Rows[i]["MaNhaCungCap"].ToString();
                _ravi["TenDoiTuong"] = dt3.Rows[i]["TenNhaCungCap"].ToString();
                dtdoituong.Rows.Add(_ravi);
            }

            gridDoiTuong.Properties.DataSource = dtdoituong;
            gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
            gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            //Thay caption:
            gridDoiTuong.Properties.View.Columns.Clear();//xóa caption cũ
            gridDoiTuong.Properties.View.Columns.AddVisible("ID_DoiTuong", "ID");
            gridDoiTuong.Properties.View.Columns.AddVisible("MaDoiTuong", "Mã");
            gridDoiTuong.Properties.View.Columns.AddVisible("TenDoiTuong", "Tên");

            gridDoiTuong.Properties.View.Columns["ID_DoiTuong"].Visible = false;
        }

        public void HienThiSoChungTu(int xxbientrangthai)
        {
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SA_W_bientrangthai_(xxbientrangthai);
            int k = dt.Rows.Count;

            if (k == 0)
            {
                if (xxbientrangthai == 6)
                    txtSoChungTu.Text = "PKT 1";

            }
            else
            {
                string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(3).Trim()) + 1;
                if (xxbientrangthai == 6)
                    txtSoChungTu.Text = "PKT " + xxx2 + "";

            }
            //if (xxbientrangthai == 5)
            //    txtThamChieu.Text = "Đổi tiền";

        }
        public QuyNganHang_Frm_PhieuKeToan()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
