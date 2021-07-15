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
    public partial class DaiLy_FrmChiTiet_NhapKho_GapDan : Form
    {
        private void HienThi_Sua(int miID_nhapkho)
        {
            clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
            cls1.iID_NhapKho = miID_nhapkho;
            DataTable dt1 = cls1.SelectOne();
           
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtTongTienHangCoVAT.Text = cls1.fTongTienHang.Value.ToString();
            gridDinhMucGapDan.EditValue = cls1.iID_DinhMuc_ToGapDan.Value;
            txtSoLuongTP.Text = cls1.fSoLuongThanhPham_QuyDoi.Value.ToString();
            cls1.Dispose();
            dt1.Dispose();
            clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
            cls2.iID_NhapKho = miID_nhapkho;
            DataTable dt2 = cls2.SA_W_ID_NhapKho();
            gridControl1.DataSource = dt2;
            cls2.Dispose();
            dt2.Dispose();
        }
        public DaiLy_FrmChiTiet_NhapKho_GapDan()
        {
            InitializeComponent();
        }
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dt = clsvthhh.T_SelectAll();


            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";


            clsDinhMuc_DinhMuc_ToGapDan cls = new clsDinhMuc_DinhMuc_ToGapDan();
            DataTable dt2 = cls.SelectAll();
            gridDinhMucGapDan.Properties.DataSource = dt2;
            gridDinhMucGapDan.Properties.ValueMember = "ID_DinhMuc_ToGapDan";
            gridDinhMucGapDan.Properties.DisplayMember = "MaDinhMuc";

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            dt = clsNguoi.T_SelectAll(5);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";


            dt2.Dispose();
            cls.Dispose();
            dt.Dispose();
            clsvthhh.Dispose();
            clsNguoi.Dispose();
        }

        private void Luu_ChiTiet_NhapKho_GapDan(int iiiID_nhapkhogapgan)
        {
            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dttttt2 = dv2232xx.ToTable();

                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                dt2_cu = cls2.SA_W_ID_NhapKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_tonTai_W_ID_NhapKho();
                }


                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongNhap"].ToString());
                    cls2.fSoLuongTon = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongNhap"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bBoolTonDauKy = false;
                    cls2.bDaNhapKho = true;
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                dt2_moi11111 = cls2.SA_W_ID_NhapKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                    cls2.iID_ChiTietNhapKho = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }
                cls2.Dispose();
            }
        }
        private void Luu_DuLieu(int xxID_nhapkho)
        {
            if (!KiemTraLuu()) return;
            else
            {
                
                clsGapDan_tbNhapKho cls1xx = new clsGapDan_tbNhapKho();
                cls1xx.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1xx.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1xx.sDienGiai = txtDienGiai.Text.ToString();
                cls1xx.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1xx.sThamChieu = txtThamChieu.Text.ToString();
                cls1xx.fTongTienHang = 0;
                cls1xx.bBool_TonDauKy = false;
                cls1xx.bDaNhapKho = true;
                cls1xx.bTonTai = true;
                cls1xx.bNgungTheoDoi = false;
                cls1xx.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                cls1xx.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1xx.iID_VTHH_ThanhPham_QuyDoi = Convert.ToInt32(txtID_ThanhPham.Text);
                cls1xx.fDonGia_ThanhPham_QuyDoi = 0;
                cls1xx.fSoLuongThanhPham_QuyDoi = Convert.ToInt32(txtSoLuongTP.Text);
                cls1xx.iID_NhapKho = xxID_nhapkho; 
                cls1xx.Update();               
                Luu_ChiTiet_NhapKho_GapDan(xxID_nhapkho);
                cls1xx.Dispose();
                MessageBox.Show("Đã lưu");
                this.Close();
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
                return false;
            }


            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
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
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }
        private void DaiLy_FrmChiTiet_NhapKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            HienThi_Sua(UCDaiLy_NhapKho_GapDan.miID_NhapKho_GapDan);
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
                clsncc.Dispose();
                dt.Dispose();
            }
            catch
            {

            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_DuLieu(UCDaiLy_NhapKho_GapDan.miID_NhapKho_GapDan);
        }

        private void gridDinhMucGapDan_EditValueChanged(object sender, EventArgs e)
        {
            int xxxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            clsDinhMuc_DinhMuc_ToGapDan cls = new clsDinhMuc_DinhMuc_ToGapDan();
            cls.iID_DinhMuc_ToGapDan = xxxID;
            DataTable dt = cls.SelectOne();
            txtDienGiaiDMNPL.Text = cls.sDienGiai.Value;
            

            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            DataTable dt2 = cls2.SA_ID_DinhMuc_ThanhPham(xxxID);
            txtID_ThanhPham.Text = dt2.Rows[0]["ID_VTHH"].ToString();
            txtTenVT_ThanhPham.Text = dt2.Rows[0]["TenVTHH"].ToString();
            DVT_ThanhPham.Text = dt2.Rows[0]["DonViTinh"].ToString();

            cls.Dispose();
            dt.Dispose();
            cls2.Dispose();
            dt2.Dispose();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
