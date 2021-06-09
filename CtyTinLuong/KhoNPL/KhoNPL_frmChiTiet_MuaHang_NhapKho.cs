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
    public partial class KhoNPL_frmChiTiet_MuaHang_NhapKho : Form
    {       
        
        //public static DateTime mdaNgayMuaHang, mdaNgayNhapKho;
        //public static DataTable mdt_ChiTietNhapKho;
        //public static double mdeTongTienHang_KhongVAT, mdeTienVAT, mdeTongTienHang_CoVAT;
        //public static string msSoChungTu_MuaHang, msSoChungTu_NhapKho, msNguoiMuaHang, msThuKho;
        private bool KiemTraLuu()
        {

           if (txtSoChungTuNhapKhoNPL.Text.ToString() == "")
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
        private void Luu_NhapKho_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
                cls1.sDienGiai = txtDienGiaiNhapKhoNPL.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTuNPL.DateTime;
                cls1.sSoChungTu = txtSoChungTuNhapKhoNPL.Text.ToString();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhapKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaNhapKho = true;
                cls1.bBool_TonDauKy = false;
                cls1.bCheck_NhapKho_Khac = false;
                cls1.Insert();
                // insert tbChiTietNhapKho
                string shienthi = "1";
                int iiiiIDID_NhapKhoNPL = cls1.iID_NhapKho.Value;
                clsKhoNPL_tbChiTietNhapKho clschitietNhapkho = new clsKhoNPL_tbChiTietNhapKho();
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    clschitietNhapkho.iID_NhapKho = iiiiIDID_NhapKhoNPL;
                    clschitietNhapkho.iID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());

                    if (dtmoi.Rows[i]["SoLuong"].ToString() != "")
                    {
                        clschitietNhapkho.fSoLuongNhap = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                        clschitietNhapkho.fSoLuongTon = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                    }
                    else
                    {
                        clschitietNhapkho.fSoLuongNhap = 0;
                        clschitietNhapkho.fSoLuongTon = 0;
                    }
                    if (dtmoi.Rows[i]["DonGia"].ToString() != "")
                        clschitietNhapkho.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia"].ToString());
                    clschitietNhapkho.bTonTai = true;
                    clschitietNhapkho.bNgungTheoDoi = false;
                    clschitietNhapkho.sGhiChu = dtmoi.Rows[i]["GhiChu"].ToString();
                    clschitietNhapkho.bDaNhapKho = true;
                    clschitietNhapkho.bBoolTonDauKy = false;
                    clschitietNhapkho.Insert();
                }

                /// Update trang thai nhap kho tbMuahang
                clsMH_tbMuaHang clsmuahang = new clsMH_tbMuaHang();
                clsmuahang.iID_MuaHang = UC_KhoNVL_frmChoNhapKho.miID_MuaHang_NhapKho;
                clsmuahang.Update_TrangThaiNhapKho();
                MessageBox.Show("Đã nhập kho");
                this.Close();
            }
        }
        private void HienThi_Gridcontrol()
        {
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = UC_KhoNVL_frmChoNhapKho.miID_MuaHang_NhapKho;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuong"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
                _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
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

            gridControl1.DataSource = dt2;
        }
           
        private void HienThi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTuNPL.EditValue = DateTime.Today;
            Load_LockUp();
            clsMH_tbMuaHang cls = new CtyTinLuong.clsMH_tbMuaHang();
            cls.iID_MuaHang = UC_KhoNVL_frmChoNhapKho.miID_MuaHang_NhapKho;
            DataTable dt = cls.SelectOne();
            txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();            
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            int idnguoimua = cls.iID_NguoiMua.Value;
            clsNhanSu_tbNhanSu clsnhansu = new clsNhanSu_tbNhanSu();
            clsnhansu.iID_NhanSu = idnguoimua;
            DataTable dtnhansu = clsnhansu.SelectOne();
            
            txtDienGiai.Text = cls.sDienGiai.Value.ToString();
            txtTongTienHangCoVAT.Text = cls.fTongTienHangCoVAT.Value.ToString();
            checkUSD.Checked = cls.bTienUSD.Value;           
            if (cls.bTienUSD.Value == false) checkVNĐ.Checked = true;

            clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
               txtSoChungTuNhapKhoNPL.Text = "NKNPL 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                if(xxx2>=10000)
                    txtSoChungTuNhapKhoNPL.Text = "NKNPL 1";
                else txtSoChungTuNhapKhoNPL.Text = "NKNPL " + xxx2.ToString() + "";
            }
            
            HienThi_Gridcontrol();
        }
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

          

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=5";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
           
        }
        public KhoNPL_frmChiTiet_MuaHang_NhapKho()
        {
            InitializeComponent();
        }
        private void KhoNPL_frmChiTiet_MuaHang_NhapKho_Load_1(object sender, EventArgs e)
        {
            
            HienThi();
           
        }
        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
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
        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView4.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }

            if (e.Column == clSoLuong)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            //double deTOngtien;
            //DataTable dataTable = (DataTable)gridControl1.DataSource;
            //string shienthi = "1";
            //object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            //if (xxxx.ToString() != "")
            //    deTOngtien = Convert.ToDouble(xxxx);
            //else deTOngtien = 0;
            //txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
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

        private void btNhapKho_Click(object sender, EventArgs e)
        {
            Luu_NhapKho_NPL();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //if (!KiemTraLuu()) return;
            //else
            //{
            //    KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang.mbPrint_Chitiet_Da_NhapKho_TuMuaHang = false;
            //    DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            //    CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
            //    string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            //    DataView dv1212 = new DataView(DatatableABC);
            //    dv1212.RowFilter = filterString;
            //    DataTable dttttt2 = dv1212.ToTable();
            //    string shienthi = "1";
            //    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            //    DataView dv = dttttt2.DefaultView;
            //    mdt_ChiTietNhapKho = dv.ToTable();
            //    mdaNgayMuaHang = dteNgayChungTu.DateTime;
            //    mdaNgayNhapKho = dteNgayChungTuNPL.DateTime;
            //    msSoChungTu_MuaHang = txtSoChungTu.Text.ToString();
            //    msSoChungTu_NhapKho = txtSoChungTuNhapKhoNPL.Text.ToString();
            //    msThuKho = txtNguoiNhap.Text.ToString();
            //    frmPrint_NhapKho_KhoNPL ff = new frmPrint_NhapKho_KhoNPL();
            //    ff.Show();
            //}
        }

        private void KhoNPL_frmChiTiet_MuaHang_NhapKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
