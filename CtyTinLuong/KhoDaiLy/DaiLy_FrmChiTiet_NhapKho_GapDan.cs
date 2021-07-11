using DevExpress.Data.Filtering;
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

        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiNhanHang, msDienGiai;
        public static double mdbTongSotien;
        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            double soluongxuat, soluongnhap;
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(DateTime.Now);
            string filterExpression = "ID_VTHH=" + xxID_VTHH + "";
            DataRow[] rows_Xuat = dt_XuatTruoc.Select(filterExpression);
            DataRow[] rows_Nhap = dt_NhapTruoc.Select(filterExpression);
            if (rows_Xuat.Length == 0)
                soluongxuat = 0;
            else
                soluongxuat = Convert.ToDouble(rows_Xuat[0]["SoLuong_XuatTruocKy"].ToString());
            if (rows_Nhap.Length == 0)
                soluongnhap = 0;
            else
                soluongnhap = Convert.ToDouble(rows_Nhap[0]["SoLuong_NhapTruocKy"].ToString());
            soluongton = soluongnhap - soluongxuat;

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }

        private void HienThi_GridControl_Moiiiiiiiiiiii(double soluongxuatxxx, int iiiID_Dinhmuc)
        {
            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls1 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();

            DataTable dt2 = cls1.SA_IDDM_W_SoLuong(soluongxuatxxx, iiiID_Dinhmuc);
            gridControl1.DataSource = dt2;

        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            repositoryItemLookUpEdit2.DataSource = dtxx2;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";



            clsDinhMuc_DinhMuc_ToGapDan clsdinhmucnpl = new clsDinhMuc_DinhMuc_ToGapDan();
            DataTable dt2 = clsdinhmucnpl.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvnpl = dt2.DefaultView;
            DataTable newdtnpl = dvnpl.ToTable();


            gridDinhMucGapDan.Properties.DataSource = newdtnpl;
            gridDinhMucGapDan.Properties.ValueMember = "ID_DinhMuc_ToGapDan";
            gridDinhMucGapDan.Properties.DisplayMember = "MaDinhMuc";
            
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


            else if (gridDinhMucGapDan.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa chọn định mức nguyên phụ liệu");
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
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }
        private void Luu_NhapKho_GapDan(bool isChoNhapKho,int iiID_nhapKho)
        {
            if (!KiemTraLuu()) return;
            else
            {
                DataTable dtkkk = (DataTable)gridControl1.DataSource;

                string expression;
                expression = "int_TP_1_Chinh_2_Phu_3=1";
                DataRow[] foundRows;
                foundRows = dtkkk.Select(expression);
                int iiID_VT_Chinh;
                if (foundRows.Length > 0)
                    iiID_VT_Chinh = Convert.ToInt32(foundRows[0]["ID_VTHH"].ToString());
                else
                    iiID_VT_Chinh = 0;


                clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_VTHH_ThanhPham_QuyDoi = iiID_VT_Chinh;
                cls1.fDonGia_ThanhPham_QuyDoi = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongThanhPham_QuyDoi = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1.bBool_TonDauKy = false;
                cls1.bTrangThai_XuatKho_NPL = true;
                cls1.bTrangThai_XuatKho_BTP = true;
                cls1.bTrangThai_NhapKho_GapDan = true;
                cls1.bDaNhapKho = true;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();               
                if (isChoNhapKho==true)
                {
                    int iiID_Nhapkho_GapDan;
                    cls1.Insert();
                    iiID_Nhapkho_GapDan = cls1.iID_NhapKho.Value;
                    Luu_ChiTiet_NhapKho_GapDan(iiID_Nhapkho_GapDan);
                    clsGapDan_tbNhapKho_Temp cls2 = new clsGapDan_tbNhapKho_Temp();                   
                    cls2.Update_trangthainhapkho_daiLy(iiID_nhapKho);
                }
                else
                {
                    int iiID_Nhapkho_GapDan;
                    cls1.iID_NhapKho = iiID_nhapKho;
                    iiID_Nhapkho_GapDan = iiID_nhapKho;
                    cls1.Update();
                    Luu_ChiTiet_NhapKho_GapDan(iiID_Nhapkho_GapDan);
                }
               
                MessageBox.Show("Đã lưu");
                this.Close();
            }

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
                
                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bBoolTonDauKy = false;
                    cls2.iInt_TP_1_Chinh_2_Phu_3 = Convert.ToInt32(dttttt2.Rows[i]["Int_TP_1_Chinh_2_Phu_3"].ToString());

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

            }
        }

        private void HienThi_GridControl_Sua(bool isChoNhapKho, int xid_nhapkho, int iii_dinhmuc, double soluongxuatxxx)
        {
            if (isChoNhapKho == false)
            {
                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                DataTable dt2 = cls2.SA_W_ID_NK_HienThi_(xid_nhapkho, iii_dinhmuc, soluongxuatxxx);
                gridControl1.DataSource = dt2;
                txtTongTienHang.Text = dt2.Rows[0][0].ToString();
            }
            else
            {
                clsGapDan_ChiTiet_NhapKho_Temp cls2 = new clsGapDan_ChiTiet_NhapKho_Temp();
                DataTable dt2 = cls2.SA_W_ID_NK_HienThi_(xid_nhapkho, iii_dinhmuc, soluongxuatxxx);
                gridControl1.DataSource = dt2;
                txtTongTienHang.Text = dt2.Rows[0][0].ToString();
            }
                

        }

        private string SoCHungTu_GapDan()
        {
            string sochungtu;
            clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
            DataTable dt1222 = cls.SelectAll();
            dt1222.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvxxx = dt1222.DefaultView;
            DataTable dv3xxx = dvxxx.ToTable();
            int k2 = dv3xxx.Rows.Count;
            if (k2 == 0)
                sochungtu = "NKGD 1";
            else
            {
                string xxx = dv3xxx.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "NKGD 1";
                else sochungtu = "NKGD " + xxx2 + "";

            }
            return sochungtu;
        }
        private void HienThi_Sua_XuatKho(bool isChoNhapKho, int iiID_nhapkho_)
        {
            if(isChoNhapKho==true)
            {
                btLuu_Gui_Dong.Text = "Nhập kho";
                clsGapDan_tbNhapKho_Temp cls1 = new clsGapDan_tbNhapKho_Temp();
                cls1.iID_NhapKho = iiID_nhapkho_;
                DataTable dt22222 = cls1.SelectOne();
                txtSoLuongXuat.Text = cls1.fSoLuongThanhPham_QuyDoi.Value.ToString();
                gridDinhMucGapDan.EditValue = cls1.iID_DinhMuc_ToGapDan.Value;
                txtSoChungTu.Text = SoCHungTu_GapDan();
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                dteNgayChungTu.EditValue = DateTime.Today;
                txtNguoiNhanHang.Text = cls1.sNguoiNhanHang.Value;
                txtThamChieu.Text = cls1.sThamChieu.Value;
                txtDienGiai.Text = cls1.sDienGiai.Value;
                double iisoluongxuat = cls1.fSoLuongThanhPham_QuyDoi.Value;
                int iiID_dinhmuc = cls1.iID_DinhMuc_ToGapDan.Value;
                HienThi_GridControl_Sua(isChoNhapKho, iiID_nhapkho_, iiID_dinhmuc, iisoluongxuat);
            }
            else
            {
                btLuu_Gui_Dong.Text = "Lưu";
                clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
                cls1.iID_NhapKho = iiID_nhapkho_;
                DataTable dt22222 = cls1.SelectOne();
                txtSoLuongXuat.Text = cls1.fSoLuongThanhPham_QuyDoi.Value.ToString();
                gridDinhMucGapDan.EditValue = cls1.iID_DinhMuc_ToGapDan.Value;
                txtSoChungTu.Text = cls1.sSoChungTu.Value;
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                dteNgayChungTu.EditValue = DateTime.Today;
                txtNguoiNhanHang.Text = cls1.sNguoiNhanHang.Value;
                txtThamChieu.Text = cls1.sThamChieu.Value;
                txtDienGiai.Text = cls1.sDienGiai.Value;
                double iisoluongxuat = cls1.fSoLuongThanhPham_QuyDoi.Value;
                int iiID_dinhmuc = cls1.iID_DinhMuc_ToGapDan.Value;
                HienThi_GridControl_Sua(isChoNhapKho, iiID_nhapkho_, iiID_dinhmuc, iisoluongxuat);
            }
           
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
                    txtTenNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridDinhMucGapDan_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_DinhMuc_ToGapDan();
            cls.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            DataTable dt = cls.SelectOne();
            txtDienGiaiDMNPL.Text = cls.sDienGiai.Value;

            double xxsoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
            int xxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            HienThi_GridControl_Moiiiiiiiiiiii(xxsoluongxuat, xxID);
            
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double ffdongia, fffsoluong, fffthanhtien;
            if (e.Column == clID_VTHH)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuongTheoDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clCheck_VatTu_Phu, true);

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
            txtTongTienHang.Text = deTOngtien.ToString();
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Luu_NhapKho_GapDan(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan,UCDaiLy_NhapKho_GapDan.miID_NhapKho_GapDan);
            Cursor.Current = Cursors.Default;
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
                msNguoiNhanHang = txtTenNguoiLap.Text.ToString();
                mdbTongSotien = Convert.ToDouble(txtTongTienHang.Text.ToString());
                msDienGiai = txtDienGiai.Text.ToString();
                frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                ff.Show();
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

        private void txtDonGiaThanhPhamQuyDoi_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaThanhPhamQuyDoi.Text);
                txtDonGiaThanhPhamQuyDoi.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void txtSoChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteNgayChungTu.Focus();
            }
        }

        private void dteNgayChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridNguoiLap.Focus();
            }
        }

        private void txtThamChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridNguoiLap.Focus();
            }
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtTenNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
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
                gridDinhMucGapDan.Focus();
            }
        }

        private void gridDinhMucGapDan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoLuongXuat.Focus();
            }
        }

        private void txtDienGiaiDMNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
             

        private void txtSoLuongXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDonGiaThanhPhamQuyDoi.Focus();
            }
        }

        private void txtDonGiaThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
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
                txtNguoiNhanHang.Focus();
            }
        }

        private void txtNguoiNhanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLuu_Gui_Dong.Focus();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                Hienthi_Lable_TonKho(xxID);
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoLuongXuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuongXuat.Text.ToString() != "" & gridDinhMucGapDan.EditValue.ToString() != "")
                {
                    int xxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                    double xxsoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                    HienThi_GridControl_Moiiiiiiiiiiii(xxsoluongxuat, xxID);                  
                }

            }
            catch
            {

            }
        }

        private void DaiLy_FrmChiTiet_NhapKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            HienThi_Sua_XuatKho(frmQuanLyKhoDaiLy.isChoNhapKho_GapDan,UCDaiLy_NhapKho_GapDan.miID_NhapKho_GapDan);
            Cursor.Current = Cursors.Default;
        }

     
        public DaiLy_FrmChiTiet_NhapKho_GapDan()
        {
            InitializeComponent();
        }
    }
}
