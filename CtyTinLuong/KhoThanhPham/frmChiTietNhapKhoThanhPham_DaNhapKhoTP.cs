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
    public partial class frmChiTietNhapKhoThanhPham_DaNhapKhoTP : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai,msGhiChu;
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
            else if (dteNgayChungTuNPL.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }

            else return true;

        }
        private void Load_lockUP_EDIT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvnguoilap = dtNguoi.DefaultView;
            DataTable newdtnguoilap = dvnguoilap.ToTable();
           
            gridNguoiLap.Properties.DataSource = newdtnguoilap;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";

            clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";
        }

        private void HienThi_GridConTrolt()
        {
            DataTable dt2 = new DataTable();
            clsKhoThanhPham_tbChiTietNhapKho cls2 = new CtyTinLuong.clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham;
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            dt2.Columns.Add("ID_VTHH", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(float));
            dt2.Columns.Add("DonGia", typeof(float));
            //dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                DataRow _ravi = dt2.NewRow();

                int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["ID_VTHH"] = iiDI_Vthh;
                _ravi["SoLuongNhap"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                _ravi["MaVT"] = dtxxxx.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dtxxxx.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dtxxxx.Rows[i]["DonViTinh"].ToString();
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;


        }
        private void HienThi()
        {
            clsKhoThanhPham_tbNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbNhapKho();
            cls.iID_NhapKho_ThanhPham = UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham;
            DataTable dt = cls.SelectOne();
            txtDienGiai.Text = cls.sDienGiai.Value.ToString();
            txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();
            txtTongTienHang.Text = cls.fTongTienHang.Value.ToString();
            dteNgayChungTuNPL.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiNhap.Value;            
            if (dt.Rows[0]["ID_DaiLy"].ToString() != "")
                gridMaDaiLy.EditValue = cls.iID_DaiLy.Value;
            txtThamChieu.Text = cls.sThamChieu.Value.ToString();
            txtNguoiGiaohang.Text = cls.sNguoiGiaoHang.Value;
            txtGhiChu.Text = cls.sGhiChu.Value;
        }
        private void Luu_ChiTietNhapKho_thanhpham(int iiIDINhapKho)
        {

            string shienthi = "1";

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dvmoi.ToTable();

            clsKhoThanhPham_tbChiTietNhapKho cls = new clsKhoThanhPham_tbChiTietNhapKho();
            cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
            DataTable dt2_Cu = cls.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_tontai_W_ID_NhapKhoTP();
                }
            }
            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {


                int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
                if (dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString() != "")
                {
                    cls.fSoLuongNhap = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
                    cls.fSoLuongTon = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
                }
                else
                {
                    cls.fSoLuongNhap = 0;
                    cls.fSoLuongTon = 0;
                }
                if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                    cls.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                else cls.fDonGia = 0;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                cls.bDaNhapKho = true;
                cls.bBool_TonDauKy = false;

                string expressionnhapkho;
                expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_Cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    cls.iID_ChiTietNhapKho_ThanhPham = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho_ThanhPham"].ToString());
                    cls.Update();
                }
                else
                {
                    cls.Insert();
                }

            }
            // xoa ton tai=false
            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho_ThanhPham = iiIDINhapKho;
            dt2_moi11111 = cls2.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho_ThanhPham"].ToString());
                cls2.iID_ChiTietNhapKho_ThanhPham = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }



        }
        private void Luu_NhapKho_ThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {

                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                clsKhoThanhPham_tbNhapKho cls = new clsKhoThanhPham_tbNhapKho();
                cls.iID_NhapKho_ThanhPham = UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham;
                DataTable dt1 = cls.SelectOne();
                bool NhapKho_Khac = cls.bCheck_NhapKho_Khac.Value;


                clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
                cls1.iID_NhapKho_ThanhPham = UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTuNPL.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                if (gridMaDaiLy.EditValue != null)
                    cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaNhapKho = true;
                cls1.bBool_TonDauKy = false;
                cls1.bCheck_NhapKho_Khac = NhapKho_Khac;
                cls1.sNguoiGiaoHang = txtNguoiGiaohang.Text.ToString();
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.Update();
                Luu_ChiTietNhapKho_thanhpham(UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham);
                MessageBox.Show("Đã lưu");
            }
        }
        public frmChiTietNhapKhoThanhPham_DaNhapKhoTP()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietNhapKhoThanhPham_DaNhapKhoTP_Load(object sender, EventArgs e)
        {
            Load_lockUP_EDIT();
            HienThi();
            HienThi_GridConTrolt();
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiXuatKho.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {
            }
        }

  

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt16(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
                  
                }

             
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuongNhap, 0);
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
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuongNhap, 1);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuongNhap).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongNhap));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }

            if (e.Column == clSoLuongNhap)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuongNhap).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongNhap));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuongNhap).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuongNhap));
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
            txtTongTienHang.Text = deTOngtien.ToString();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_NhapKho_ThanhPham();
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
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch
            { }
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
                msGhiChu = txtGhiChu.Text.ToString();
                mdaNgayChungTu = dteNgayChungTuNPL.DateTime;
                msSoChungTu = txtSoChungTu.Text.ToString();
                if(txtNguoiGiaohang.Text.ToString()!="")
                    msNguoiGiaoHang = txtNguoiGiaohang.Text.ToString();
                else msNguoiGiaoHang = txtTenDaiLy.Text.ToString();
                mdbTongSotien = Convert.ToDouble(txtTongTienHang.Text.ToString());
                msDienGiai = txtDienGiai.Text.ToString();
                frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                ff.Show();

            }
        }
    }
}
