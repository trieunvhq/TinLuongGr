﻿using System;
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
    public partial class KhoThanhPham_ChiTiet_NhapKho_DongKien : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai, msGhiChu;
        public static double mdbTongSotien;

        private string SoCHungTu_NhapKhoThanhPham()
        {
            string sochungtu;
            clsKhoThanhPham_tbNhapKho cls = new clsKhoThanhPham_tbNhapKho();
            DataTable dt1 = cls.SelectAll();

            int k2 = dt1.Rows.Count;
            if (k2 == 0)
                sochungtu = "NKTP 1";
            else
            {
                string xxx = dt1.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "NKTP 1";
                else sochungtu = "NKTP " + xxx2 + "";

            }
            cls.Dispose();
            dt1.Dispose();
            return sochungtu;
        }
        private void HienThi_Sua()
        {
            clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
            cls1.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
            DataTable dt = cls1.SelectOne();
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtGhiChu.Text = cls1.sGhiChu.Value;
          
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;
           

            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
            DataTable dtxx = cls2.Select_ALL_W_ID_NhapKho_ThanhPham();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuongNhap", typeof(float));
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
                _ravi3["SoLuongNhap"] = SoLuongxxx333;
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
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = SoCHungTu_NhapKhoThanhPham();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDongKien", typeof(string));
            dt2.Columns.Add("ID_VTHH_ThanhPham_QuyDoi", typeof(string));
            dt2.Columns.Add("SoLuongThanhPham_QuyDoi", typeof(string));
            dt2.Columns.Add("SoLuongTon_SauKhiNhapKhoThanhPham", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuongNhap", typeof(string));        
            dt2.Columns.Add("DonGia", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt2;
        }

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


                int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                cls.iID_VTHH = ID_VTHHxxx;
                cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
                if (dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString() != "")
                {
                    cls.fSoLuongNhap = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
                    cls.fSoLuongTon = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
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
                tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                
                clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
                cls1.iID_NhapKho_ThanhPham = UCThanhPham_DaNhapKho.miiID_NhapKho_ThanhPham;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = "";
                cls1.iID_DaiLy = 0;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaNhapKho = true;
                cls1.bBool_TonDauKy = false;
                cls1.iInt_Dongkien_1_GapDan_2_DaiLy_3_Khac_4_ConLai_0 = 1;
                cls1.sNguoiGiaoHang = txtNguoiGiaohang.Text.ToString();
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                int iiID_nhapkho;
                if (UCThanhPham_NhapKho_DongKien.mbSua == false)
                {
                    cls1.Insert();
                    iiID_nhapkho = cls1.iID_NhapKho_ThanhPham.Value;
                }
                else
                {
                    cls1.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
                    cls1.Update();
                    iiID_nhapkho = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
                }

                Luu_ChiTietNhapKho_thanhpham(iiID_nhapkho);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Đã lưu");
            }
        }

        private void KhoThanhPham_ChiTiet_NhapKho_DongKien_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = DateTime.Today.AddDays(-30);
            Load_LockUp();
            if (UCThanhPham_NhapKho_DongKien.mbThemMoi == true)
                HienThi_ThemMoi();
            else if (UCThanhPham_NhapKho_DongKien.mbSua == true)
                HienThi_Sua();
            else if (UCThanhPham_NhapKho_DongKien.mbCopy == true)
                HienThi_Sua();
            Cursor.Current = Cursors.Default;
        }

        private void Load_LockUp_ThamChieu(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbNhapKho cls = new clsDongKien_TbNhapKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridThamChieu.DataSource = dt;
            gridThamChieu.ValueMember = "ID_NhapKhoDongKien";
            gridThamChieu.DisplayMember = "SoChungTu";
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue !=null)
                Load_LockUp_ThamChieu(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double dongia = 0, soluong = 0, thanhtien = 0;
            if (e.Column == clID_NhapKhoDongKien1)
            {
                int xxIDkk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                clsDongKien_TbNhapKho cls = new clsDongKien_TbNhapKho();           
                DataTable dt = cls.SO_ID(xxIDkk);
                gridView4.SetRowCellValue(e.RowHandle, clID_VTHH1, dt.Rows[0]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH1, dt.Rows[0]["TenVTHH"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh1, dt.Rows[0]["DonViTinh"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clMaVT1, dt.Rows[0]["MaVT"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongThanhPhamQuyDoi1, dt.Rows[0]["SoLuongThanhPham_QuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongTon_SauKhiNhapKhoThanhPham, dt.Rows[0]["SoLuongTon_SauKhiNhapKhoThanhPham"].ToString());

                gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clDonGia1, 0);
                
            }
            try
            {
                dongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia1));
                soluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                thanhtien = soluong * dongia;
                if (e.Column == clDonGia1)
                {                   
                    gridView4.SetFocusedRowCellValue(clThanhTien1, thanhtien);
                }
                if (e.Column == clSoLuongNhap1)
                {
                    gridView4.SetFocusedRowCellValue(clThanhTien1, thanhtien);
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
            catch
            {

            }
           
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_NhapKho_ThanhPham();
        }

        private void Load_LockUp()
        {
           



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dt = clsNguoi.T_SelectAll(5);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";



        }
        public KhoThanhPham_ChiTiet_NhapKho_DongKien()
        {
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}