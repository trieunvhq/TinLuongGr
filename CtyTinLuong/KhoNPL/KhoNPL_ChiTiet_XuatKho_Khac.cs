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
    public partial class KhoNPL_ChiTiet_XuatKho_Khac : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiNhanHang, msDienGiai;
        public static double mdbTongSotien;
        private void HienThi_Gridcontrol()
        {
            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            cls2.iID_XuatKho = UCNPL_XuatKho_Khacccccccccccccc.miiD_XuatKho;
            DataTable dt3 = cls2.SelectAll_HienThiSuaChiTietXuatKHo();
            DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_ChiTietXuatKho"); // ID của tbChi tiet don hàng
            //dt2.Columns.Add("ID_XuatKho");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongXuat"].ToString());
                    Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    //_ravi["ID_ChiTietXuatKho"] = dt3.Rows[i]["ID_ChiTietXuatKho"].ToString();
                    //_ravi["ID_XuatKho"] = dt3.Rows[i]["ID_XuatKho"].ToString();
                    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();

                    _ravi["SoLuong"] = xxsoluong;
                    _ravi["DonGia"] = xxdongia;
                    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                    _ravi["HienThi"] = "1";
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    dt2.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = dt2;
        }
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
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));

            gridControl1.DataSource = dt2;
        }

        private void HienThi_Sua()
        {
            clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
            cls1.iID_XuatKhoNPL = UCNPL_XuatKho_Khacccccccccccccc.miiD_XuatKho;
            DataTable dt1 = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiXuatKho.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtTongTienHangCoVAT.Text = cls1.fTongTienHang.Value.ToString();
            HienThi_Gridcontrol();

        }

        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=5";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

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
                    cls2.fSoLuongXuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                    if (dtmoi.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia"].ToString());
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
                        double soluongxuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                        clschitietnhapkho.iID_VTHH = iiiID_VTHH;
                        DataTable dt2 = clschitietnhapkho.Select_W_ID_VTHH();
                        if (dt2.Rows.Count > 0)
                        {
                            Double douSoLuongTonCu;
                            douSoLuongTonCu = Convert.ToDouble(dt2.Rows[0]["SoLuongTon"].ToString());
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
        private void Luu_XuatKho_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
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
                cls1.bCheckXuatKho_Khac = true;
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
                MessageBox.Show("Đã lưu");
            }
        }
        public KhoNPL_ChiTiet_XuatKho_Khac()
        {
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoNPL_ChiTiet_XuatKho_Khac_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            if (UCNPL_XuatKho_Khacccccccccccccc.mbThemMoi == true)
                HienThi_ThemMoi();
            else HienThi_Sua();
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
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }

            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
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
                    deTOngtien = Convert.ToDouble(xxxx);
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
                mdbTongSotien = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                msDienGiai = txtDienGiai.Text.ToString();
                frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                ff.Show();

            }
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
