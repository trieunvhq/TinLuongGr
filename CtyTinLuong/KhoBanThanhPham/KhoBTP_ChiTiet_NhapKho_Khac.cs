﻿using DevExpress.Data.Filtering;
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
    public partial class KhoBTP_ChiTiet_NhapKho_Khac : Form
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
        private void Luu_ChiTietNhapKho(int iiIDINhapKho)
        {

            string shienthi = "1";

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dvmoi.ToTable();

            clsKhoBTP_tbChiTietNhapKho cls = new clsKhoBTP_tbChiTietNhapKho();
            cls.iID_NhapKho = iiIDINhapKho;
            DataTable dt2_Cu = cls.SelectAll_W_ID_NhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_ToTai_W_ID_NhapKho();
                }
            }
            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {


                int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_NhapKho = iiIDINhapKho;
                if (dt_gridcontrol.Rows[i]["SoLuong"].ToString() != "")
                {
                    cls.fSoLuongNhap = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    cls.fSoLuongTon = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                }
                else
                {
                    cls.fSoLuongNhap = 0;
                    cls.fSoLuongTon = 0;
                }
                if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                    cls.fDonGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                else cls.fDonGia = 0;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                cls.bDaNhapKho = true;
                cls.bBoolTonDauKy = false;

                string expressionnhapkho;
                expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_Cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    cls.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                    cls.Update();
                }
                else
                {
                    cls.Insert();
                }

            }
            // xoa ton tai=false
            clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho = iiIDINhapKho;
            dt2_moi11111 = cls2.SelectAll_W_ID_NhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                cls2.iID_ChiTietNhapKho = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }



        }
        private void Luu_NhapKho_BanThanhPham()
        {
            double tongtienhang;
            tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());          
            clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();            
            cls1.sDienGiai = txtDienGiai.Text.ToString();
            cls1.daNgayChungTu = dteNgayChungTu.DateTime;
            cls1.sSoChungTu = txtSoChungTu.Text.ToString();
            cls1.fTongTienHang = tongtienhang;
            cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
            cls1.sThamChieu = txtThamChieu.Text.ToString();
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            cls1.bDaNhapKho = true;
            cls1.bBool_TonDauKy = false;
            cls1.bCheck_NhapKho_Khac = true;
            cls1.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
            int xxID_nhapkhobtp;
            if(UCBanThanhPham_NhapKho_Khac.mbThemMoi_NhapKho==true)
            {
                cls1.Insert();
                xxID_nhapkhobtp = cls1.iID_NhapKhoBTP.Value;
            }
            else
            {
                cls1.iID_NhapKhoBTP = UCBanThanhPham_NhapKho_Khac.miID_NhapKho;
                cls1.Update();
                xxID_nhapkhobtp= UCBanThanhPham_NhapKho_Khac.miID_NhapKho;
            }
           
            Luu_ChiTietNhapKho(xxID_nhapkhobtp);
            MessageBox.Show("Đã lưu");
        }
        private void HienThi_Sua()
        {
            clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();
            cls1.iID_NhapKhoBTP = UCBanThanhPham_NhapKho_Khac.miID_NhapKho;
            DataTable dt = cls1.SelectOne();
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value.ToString();
         
            clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
            cls2.iID_NhapKho = UCBanThanhPham_NhapKho_Khac.miID_NhapKho;
            DataTable dtxx = cls2.SelectAll_W_ID_NhapKho();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dtxx.Rows.Count; i++)
            {
                double dongiaxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["DonGia"].ToString());
                double SoLuongxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["SoLuongNhap"].ToString());
                int ID_VTHHxxx = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = ID_VTHHxxx;
                DataTable dtvt = clsvt.SelectOne();
                DataRow _ravi3 = dt2.NewRow();

                _ravi3["ID_VTHH"] = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                _ravi3["MaVT"] = ID_VTHHxxx;
                _ravi3["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clsvt.sDonViTinh.Value;
                _ravi3["SoLuong"] = SoLuongxxx333;
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtxx.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuongxxx333 * dongiaxxx333;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
            double deTOngtien;
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 12;
            dteNgayChungTu.EditValue = DateTime.Today;

            clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "NKBTP 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                txtSoChungTu.Text = "NKBTP " + xxx2.ToString() + "";
            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt2;
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
            DataTable dtNguoi = clsNguoi.T_SelectAll(4); 

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            dtNguoi.Dispose();
            clsNguoi.Dispose();
        }
        public KhoBTP_ChiTiet_NhapKho_Khac()
        {
            InitializeComponent();
        }

        private void KhoBTP_ChiTiet_NhapKho_Khac_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            if (UCBanThanhPham_NhapKho_Khac.mbThemMoi_NhapKho == true)
                HienThi_ThemMoi();
            else HienThi_Sua();
            Cursor.Current = Cursors.Default;
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

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_NhapKho_BanThanhPham();
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
                    msNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    mdbTongSotien = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                    msDienGiai = txtDienGiai.Text.ToString();
                    frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                    ff.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu để in", "Thông báo");
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
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch
            { }
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
                txtNguoiGiaoHang.Focus();
            }
        }

        private void txtTongTienHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridNguoiLap_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridNguoiLap.Properties.View.Columns[0].Visible = false;
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
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
               
    }
}
