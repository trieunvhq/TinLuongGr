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
    public partial class KhoBTP_ChiTiet_XuatKho_Khac : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai;
        public static double mdbTongSotien;
        private bool KiemTraLuu()
        {

            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();
            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }

            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người nhập kho ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }

            else return true;

        }

        private string sochungtu_BTP()
        {
            string sochungtu = "";
            try
            {
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                DataTable dt1 = cls1.SelectAll();

                int k = dt1.Rows.Count;
                if (k == 0)
                {
                    sochungtu = "XKBTP 1";
                }
                else
                {
                    string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                    sochungtu = "XKBTP " + xxx2.ToString() + "";
                }
                cls1.Dispose();
                dt1.Dispose();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return sochungtu;
        }


        private void HienThi_Copy(int iiIDXuatkho)
        {
            try
            {
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                cls1.iID_XuatKhoBTP = iiIDXuatkho;
                DataTable dt = cls1.SelectOne();
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
                txtSoChungTu.Text = sochungtu_BTP();
                txtDienGiai.Text = cls1.sDienGiai.Value;
                txtThamChieu.Text = cls1.sThamChieu.Value;
                if (dt.Rows[0]["NguoiNhanHang"].ToString() != "")
                    txtNguoiNhanHang.Text = cls1.sNguoiNhanHang.Value;
                cls1.Dispose();

                dt.Dispose();
                clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                cls2.iID_XuatKhoBTP = iiIDXuatkho;
                DataTable dtxx = cls2.SA_ID_XuatKho(iiIDXuatkho);
                cls2.Dispose();
                dtxx.Dispose();

                gridControl1.DataSource = dtxx;
                double deTOngtien;
                string shienthi = "1";
                object xxxx = dtxx.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HienThi_Sua(int iiIDXuatkho)
        {
            try
            {
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                cls1.iID_XuatKhoBTP = iiIDXuatkho;
                DataTable dt = cls1.SelectOne();
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
                txtSoChungTu.Text = cls1.sSoChungTu.Value;
                txtDienGiai.Text = cls1.sDienGiai.Value;
                txtThamChieu.Text = cls1.sThamChieu.Value;
                if (dt.Rows[0]["NguoiNhanHang"].ToString() != "")
                    txtNguoiNhanHang.Text = cls1.sNguoiNhanHang.Value;
                cls1.Dispose();

                dt.Dispose();
                clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                cls2.iID_XuatKhoBTP = iiIDXuatkho;
                DataTable dtxx = cls2.SA_ID_XuatKho(iiIDXuatkho);
                cls2.Dispose();
                dtxx.Dispose();

                gridControl1.DataSource = dtxx;
                double deTOngtien;
                string shienthi = "1";
                object xxxx = dtxx.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HienThi_ThemMoi()
        {
            try
            {
                gridNguoiLap.EditValue = 12;
                dteNgayChungTu.EditValue = DateTime.Today;
                txtSoChungTu.Text = sochungtu_BTP();

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID_VTHH");
                dt2.Columns.Add("SoLuongXuat", typeof(float));
                dt2.Columns.Add("DonGia", typeof(double));
                dt2.Columns.Add("MaVT");// tb VTHH
                dt2.Columns.Add("TenVTHH");
                dt2.Columns.Add("DonViTinh");
                dt2.Columns.Add("ThanhTien", typeof(double));
                dt2.Columns.Add("HienThi", typeof(string));
                dt2.Columns.Add("GhiChu", typeof(string));
                gridControl1.DataSource = dt2;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Load_LockUp()
        {
            try
            {
                clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
                DataTable dtvthh = clsvthhh.SelectAll();


                repositoryItemGridLookUpEdit1.DataSource = dtvthh;
                repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
                repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

                clsvthhh.Dispose();
                dtvthh.Dispose();

                clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
                DataTable dtNguoi = clsNguoi.SelectAll();


                gridNguoiLap.Properties.DataSource = dtNguoi;
                gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
                gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
                clsNguoi.Dispose();
                dtNguoi.Dispose();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Luu_ChiTietXuatKho(int iiiDXuatKho)
        {
            string shienthi = "1";
            try
            {
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dt_gridcontrol = dvmoi.ToTable();

                clsKhoBTP_ChiTietXuatKho cls = new clsKhoBTP_ChiTietXuatKho();
                cls.iID_XuatKhoBTP = iiiDXuatKho;
                DataTable dt2_Cu = cls.SelectOne_W_ID_XuatKhoBTP();
                if (dt2_Cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                    {

                        cls.iID_XuatKhoBTP = iiiDXuatKho;
                        cls.bTonTai = false;
                        cls.Update_ALL_ToTai_W_ID_XuatKho();
                    }
                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {


                    int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_XuatKhoBTP = iiiDXuatKho;
                    if (dt_gridcontrol.Rows[i]["SoLuongXuat"].ToString() != "")
                    {
                        cls.fSoLuongXuat = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuongXuat"].ToString());
                        //cls.fSoLuongTon = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    }
                    else
                    {
                        cls.fSoLuongXuat = 0;

                    }
                    if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                        cls.fDonGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                    else cls.fDonGia = 0;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                    cls.bDaXuatKho = true;


                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_Cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls.iID_ChiTietXuatKhoBTP = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKhoBTP"].ToString());
                        cls.Update();
                    }
                    else
                    {
                        cls.Insert();
                    }
                }
                // xoa ton tai=false
                clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKhoBTP = iiiDXuatKho;
                dt2_moi11111 = cls2.SelectOne_W_ID_XuatKhoBTP();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKhoBTP"].ToString());
                    cls2.iID_ChiTietXuatKhoBTP = ID_ChiTietNhapKhoxxxx;
                    cls2.Delete();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Luu_XuatKho_BanThanhPham()
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {
                    double tongtienhang;
                    tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                    clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                    cls1.sDienGiai = txtDienGiai.Text.ToString();
                    cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls1.fTongTienHang = tongtienhang;
                    cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls1.sThamChieu = txtThamChieu.Text.ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaXuatKho = true;
                    cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 2;
                    cls1.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                    int xxID_nhapkhobtp;
                    if (UCBanThanhPham_XuatKho_Khac.mbSua == false)
                    {
                        cls1.Insert();
                        xxID_nhapkhobtp = cls1.iID_XuatKhoBTP.Value;
                    }
                    else
                    {
                        cls1.iID_XuatKhoBTP = UCbanThanhPham_DaXuatKho.miiID_XuatKhoBTP;
                        cls1.Update();
                        xxID_nhapkhobtp = UCbanThanhPham_DaXuatKho.miiID_XuatKhoBTP;

                    }

                    Luu_ChiTietXuatKho(xxID_nhapkhobtp);
                    MessageBox.Show("Đã lưu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public KhoBTP_ChiTiet_XuatKho_Khac()
        {
            InitializeComponent();
        }

        private void KhoBTP_ChiTiet_XuatKho_Khac_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_LockUp();
                if (UCBanThanhPham_XuatKho_Khac.mbThemMoi == true)
                    HienThi_ThemMoi();
                else if (UCBanThanhPham_XuatKho_Khac.mbCopy == true)
                    HienThi_Copy(UCBanThanhPham_XuatKho_Khac.miID_XuatKho);
                else if (UCBanThanhPham_XuatKho_Khac.mbSua == true)
                    HienThi_Sua(UCBanThanhPham_XuatKho_Khac.miID_XuatKho);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clSTT)
                {
                    e.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clID_VTHH)
                {
                    clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                    cls.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    DataTable dt = cls.SelectOne();
                    if (dt != null)
                    {

                        gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                        gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                        gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                        gridView4.SetRowCellValue(e.RowHandle, clSoLuong, 1);
                        gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

                        if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                            ffdongia = 0;
                        else
                            ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                        if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                            fffsoluong = 0;
                        else
                            fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                        fffthanhtien = fffsoluong * ffdongia;
                        gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                    }
                }

                if (e.Column == clSoLuong)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                if (e.Column == clDonGia)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                DataView dv = view.DataSource as DataView;
                if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
                {
                    e.Visible = false;
                    e.Handled = true;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtDienGiai.Focus();
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
                txtNguoiNhanHang.Focus();
            }
        }

        private void txtTongTienHang_KeyPress(object sender, KeyPressEventArgs e)
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


        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Luu_XuatKho_BanThanhPham();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    msNguoiGiaoHang = txtNguoiNhanHang.Text.ToString();
                    mdbTongSotien = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                    msDienGiai = txtDienGiai.Text.ToString();
                    frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                    ff.Show();
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
