using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
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
    public partial class KhoNPL_ChiTiet_XuatKho_Khac : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiNhanHang, msDienGiai;
        public static double mdbTongSotien;
      
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;

            clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "XKNPL 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                txtSoChungTu.Text = "XKNPL " + xxx2.ToString() + "";
            }
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietXuatKho"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_XuatKho");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuongXuat", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));

            gridControl1.DataSource = dt2;
        }

        private void HienThi_Sua(int xxxmiiD_XuatKho)
        {
            clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
            cls1.iID_XuatKhoNPL = xxxmiiD_XuatKho;
            DataTable dt1 = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiXuatKho.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtTongTienHangCoVAT.Text = cls1.fTongTienHang.Value.ToString();
            cls1.Dispose();
            dt1.Dispose();
            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            DataTable dt2 = cls2.SA_ID_XuatKho(xxxmiiD_XuatKho);
            gridControl1.DataSource = dt2;
            cls2.Dispose();
            dt2.Dispose();
        }

        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dt = clsvthhh.T_SelectAll(); 


            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            dt = clsNguoi.T_SelectAll(5); 
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dt.Dispose();
            clsvthhh.Dispose();
            clsNguoi.Dispose();
        }
        private void Luu_ChiTiet_ChiTiet_XuatKho_NPL(int iiID_XUatKhoNPL)
        {

          
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dtkkk.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();

                clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                dt2_cu = cls2.SelectAll_W_ID_XuatKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_XuatKho = iiID_XUatKhoNPL;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_TonTai_W_ID_XuatKho();
                }

                // Nhap kho 
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    int ID_VTHHxxx = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_XuatKho = iiID_XUatKhoNPL;
                    cls2.iID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["SoLuongXuat"].ToString());
                    if (dtmoi.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["DonGia"].ToString());
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.sGhiChu = dtmoi.Rows[i]["GhiChu"].ToString();
                    cls2.bDaXuatKho = true;
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietXuatKho = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                    // updatesoluongton
                    try
                    {
                        clsKhoNPL_tbChiTietNhapKho clschitietnhapkho = new CtyTinLuong.clsKhoNPL_tbChiTietNhapKho();
                        int iiiID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                        double soluongxuat = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["SoLuongXuat"].ToString());
                        clschitietnhapkho.iID_VTHH = iiiID_VTHH;
                        DataTable dt2 = clschitietnhapkho.Select_W_ID_VTHH();
                        if (dt2.Rows.Count > 0)
                        {
                            Double douSoLuongTonCu;
                            douSoLuongTonCu = CheckString.ConvertToDouble_My(dt2.Rows[0]["SoLuongTon"].ToString());
                            clschitietnhapkho.iID_ChiTietNhapKho = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietNhapKho"].ToString());
                            clschitietnhapkho.fSoLuongTon = douSoLuongTonCu - soluongxuat;
                            clschitietnhapkho.Update_SoLuongTon();
                        }

                    }
                    catch
                    {

                    }
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                dt2_moi11111 = cls2.SelectAll_W_ID_XuatKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietXuatKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_ChiTietXuatKho = ID_ChiTietXuatKhoxxxx;
                    cls2.Delete();
                }

        
        }
        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }

            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                gridControl1.Focus();
                return false;
            }

           
            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                dteNgayChungTu.Focus();
                return false;
            }
            else if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số chứng từ ");
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }
        private void Luu_XuatKho_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    double tongtienhang;
                    tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();

                    cls1.sDienGiai = txtDienGiai.Text.ToString();
                    cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls1.fTongTienHang = tongtienhang;
                    cls1.iID_NguoiXuatKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls1.sThamChieu = txtThamChieu.Text.ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaXuatKho = true;
                    cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 2;
                    int xxiD_nhpakho;
                    if (UCNPL_XuatKho_Khacccccccccccccc.mbThemMoi == true)
                    {
                        cls1.Insert();
                        xxiD_nhpakho = cls1.iID_XuatKhoNPL.Value;
                    }
                    else
                    {
                        cls1.iID_XuatKhoNPL = UCNPL_XuatKho_Khacccccccccccccc.miiD_XuatKho;
                        cls1.Update();
                        xxiD_nhpakho = UCNPL_XuatKho_Khacccccccccccccc.miiD_XuatKho;
                    }
                    Luu_ChiTiet_ChiTiet_XuatKho_NPL(xxiD_nhpakho);
                    this.Close();
                    _ucXKK.btLayDuLieu_Click(null, null);
                    MessageBox.Show("Đã lưu", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        UCNPL_XuatKho_Khacccccccccccccc _ucXKK;
        public KhoNPL_ChiTiet_XuatKho_Khac(UCNPL_XuatKho_Khacccccccccccccc ucXKK)
        {
            _ucXKK = ucXKK;
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoNPL_ChiTiet_XuatKho_Khac_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            if (UCNPL_XuatKho_Khacccccccccccccc.mbThemMoi == true)
                HienThi_ThemMoi();
            else HienThi_Sua(UCNPL_XuatKho_Khacccccccccccccc.miiD_XuatKho);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clID_VTHH)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                   
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }

            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHangCoVAT.Text = deTOngtien.ToString();

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHangCoVAT.Text = deTOngtien.ToString();
            }
            catch
            { }
        }

        private void txtTongTienHangCoVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                DataTable dttttt2 = dv1212.ToTable();
                string shienthi = "1";
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                mdtPrint = dv.ToTable();
                if (mdtPrint.Rows.Count > 0)
                {
                    mbPrint = true;
                    mdaNgayChungTu = dteNgayChungTu.DateTime;
                    msSoChungTu = txtSoChungTu.Text.ToString();
                    msNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                    mdbTongSotien = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    msDienGiai = txtDienGiai.Text.ToString();
                    frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                    ff.Show();
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo");
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

        private void txtThamChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNguoiNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTongTienHangCoVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNguoiNhanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
            iID_VTHH = Convert.ToInt32(row["ID_VTHH"].ToString());
            sTenVTHH = row["TenVTHH"].ToString();
            sDonViTinh = row["DonViTinh"].ToString();
        }

        int iID_VTHH;
        string sMaVT, sTenVTHH, sDonViTinh;
        private void repositoryItemSearchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
            }
            catch { }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_XuatKho_NPL();
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
                    txtNguoiNhap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }
    }
}
