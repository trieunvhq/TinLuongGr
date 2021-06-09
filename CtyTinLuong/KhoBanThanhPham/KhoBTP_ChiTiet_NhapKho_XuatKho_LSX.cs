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
    public partial class KhoBTP_ChiTiet_NhapKho_XuatKho_LSX : Form
    {
        private bool KiemTraLuu()
        {

            if (txtSoChungTu.Text.ToString() == "")
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
            //else if (gridTKCo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa chọn TK có");
            //    return false;
            //}
            //else if (gridTKNo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa chọn TK nợ");
            //    return false;
            //}

            else return true;

        }
        private void Luu_NhapKho_banThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {
                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();
                cls1.sDienGiai = txtDienGiaiNPL.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTuNPL.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaNhapKho = true;
                cls1.bCheck_NhapKho_Khac = false;
                cls1.sNguoiGiaoHang = txtNguoiGiao_Nhan.Text.ToString();
                cls1.bBool_TonDauKy = false;
                cls1.Insert();
                // insert tbChiTietNhapKho
                string shienthi = "1";
                int iiiiIDID_XuatKhoNPL = cls1.iID_NhapKhoBTP.Value;
                clsKhoBTP_tbChiTietNhapKho clschitiet = new clsKhoBTP_tbChiTietNhapKho();
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    double sanluongthuong= Convert.ToDouble(dtmoi.Rows[i]["SanLuongThuong_May"].ToString());
                    double sanluongtangca = Convert.ToDouble(dtmoi.Rows[i]["SanLuongTangCa_May"].ToString());
                    clschitiet.iID_NhapKho = iiiiIDID_XuatKhoNPL;
                    clschitiet.iID_VTHH = Convert.ToInt16(dtmoi.Rows[i]["ID_VTHH_Ra"].ToString());
                    clschitiet.fSoLuongNhap = sanluongthuong+ sanluongtangca;
                    clschitiet.fSoLuongTon = sanluongthuong + sanluongtangca;
                    clschitiet.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia_Ra"].ToString());
                    clschitiet.bTonTai = true;
                    clschitiet.bNgungTheoDoi = false;
                    clschitiet.bDaNhapKho = true;
                    clschitiet.bBoolTonDauKy = false;
                    clschitiet.sGhiChu = "";
                    clschitiet.Insert();

                }
                /// Update trang thai nhap lenh san xuất

                clsHUU_LenhSanXuat clsxxx = new CtyTinLuong.clsHUU_LenhSanXuat();
                clsxxx.iID_LenhSanXuat = UCBTP_NhapKho_LSX_I_C_D.mID_iD_LenhSanXuat;
                if (UCBTP_NhapKho_LSX_I_C_D.miID_loaiMay == 1)
                    clsxxx.Update_TrangThai_NHap_KHO_KhoBTP_may_IN();
                if (UCBTP_NhapKho_LSX_I_C_D.miID_loaiMay == 2)
                    clsxxx.Update_TrangThai_NHap_KHO_KhoBTP_may_CAT();
                else if (UCBTP_NhapKho_LSX_I_C_D.miID_loaiMay == 3)
                    clsxxx.Update_TrangThai_NHap_KHO_KhoBTP_may_DOT();
               
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }

        private void Luu_XuatKho_banThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {
                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                cls1.sDienGiai = txtDienGiaiNPL.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTuNPL.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaXuatKho = true;
                cls1.bCheck_XuatKho_Khac = false;
                cls1.sNguoiNhanHang = txtNguoiGiao_Nhan.Text.ToString();
                cls1.Insert();
                // insert tbChiTietNhapKho
                string shienthi = "1";
                int iiiiIDID_XuatKhoNPL = cls1.iID_XuatKhoBTP.Value;
                clsKhoBTP_ChiTietXuatKho clschitiet = new clsKhoBTP_ChiTietXuatKho();
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    clschitiet.iID_XuatKhoBTP = iiiiIDID_XuatKhoNPL;
                    clschitiet.iID_VTHH = Convert.ToInt16(dtmoi.Rows[i]["ID_VTHH_Vao"].ToString());
                    clschitiet.fSoLuongXuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuongNhap_May"].ToString());
                    clschitiet.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia_Vao"].ToString());
                    clschitiet.bTonTai = true;
                    clschitiet.bNgungTheoDoi = false;
                    clschitiet.bDaXuatKho = true;
                    clschitiet.sGhiChu = "";
                    clschitiet.Insert();

                    try
                    {
                        // update soluong ton tbnhapkho
                        clsKhoBTP_tbChiTietNhapKho clschitietnhapkho = new CtyTinLuong.clsKhoBTP_tbChiTietNhapKho();
                        int iiiID_VTHH = Convert.ToInt16(dtmoi.Rows[i]["ID_VTHH_Vao"].ToString());
                        double soluongxuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuongNhap_May"].ToString());
                        clschitietnhapkho.iID_VTHH = iiiID_VTHH;
                        DataTable dt2 = clschitietnhapkho.Select_W_ID_VTHH();
                        Double douSoLuongTonCu;
                        douSoLuongTonCu = Convert.ToDouble(dt2.Rows[0]["SoLuongTon"].ToString());
                        clschitietnhapkho.iID_ChiTietNhapKho = Convert.ToInt16(dt2.Rows[0]["ID_ChiTietNhapKho"].ToString());
                        clschitietnhapkho.fSoLuongTon = douSoLuongTonCu - soluongxuat;
                        clschitietnhapkho.Update_SoLuongTon();
                    }
                    catch
                    {

                    }

                }
                /// Update trang thai nhap lenh san xuất

                clsHUU_LenhSanXuat clsxxx = new CtyTinLuong.clsHUU_LenhSanXuat();
                clsxxx.iID_LenhSanXuat = UCBTP_XuatKho_LSX_I_C_D.mID_iD_LenhSanXuat;
                if (UCBTP_XuatKho_LSX_I_C_D.miID_loaiMay == 2)
                    clsxxx.Update_TrangThai_XuatKHO_KhoBTP_may_CAT();
                else if (UCBTP_XuatKho_LSX_I_C_D.miID_loaiMay == 3)
                    clsxxx.Update_TrangThai_XuatKHO_KhoBTP_may_DOT();

                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }
        private void Load_lockUP_EDIT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
           
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvnguoilap = dtNguoi.DefaultView;
            DataTable newdtnguoilap = dvnguoilap.ToTable();

            gridNguoiLap.Properties.DataSource = newdtnguoilap;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            
        }
        private void Load_SoChungTu_BTP(bool nhapkho)
        {
            if(nhapkho==true)
            {
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
                    int xxx2 = Convert.ToInt16(xxx.Substring(5).Trim()) + 1;
                    txtSoChungTu.Text = "NKBTP " + xxx2.ToString() + "";
                }
            }
            else
            {
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                DataTable dt1 = cls1.SelectAll();
                dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                DataView dv = dt1.DefaultView;
                DataTable dv3 = dv.ToTable();
                int k = dv3.Rows.Count;
                if (k == 0)
                {
                    txtSoChungTu.Text = "XKBTP 1";
                }
                else
                {
                    string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt16(xxx.Substring(5).Trim()) + 1;
                    txtSoChungTu.Text = "XKBTP " + xxx2.ToString() + "";
                }
            }
            
        }
        private void HienThi_SUa_LenhSanXuat(int iiID_lenhSanXuat, string smalenhsanxuat)
        {
            gridNguoiLap.EditValue = 12;
            txtThamChieu.Text = smalenhsanxuat;
            DataTable dt2 = new DataTable();
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls2.iID_LenhSanXuat = iiID_lenhSanXuat;
            DataTable dtxxxx = cls2.SelectAll_w_iID_LenhSanXuat();

            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("ID_VTHH_Vao", typeof(int));
            dt2.Columns.Add("ID_VTHH_Ra", typeof(int));
            dt2.Columns.Add("MaVT_Vao", typeof(string));
            dt2.Columns.Add("MaVT_Ra", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));
            dt2.Columns.Add("SoLuongNhap_May", typeof(float));
            dt2.Columns.Add("SanLuongThuong_May", typeof(float));
            dt2.Columns.Add("SanLuongTangCa_May", typeof(float));
            dt2.Columns.Add("PhePham_May", typeof(float));            //
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia_Vao", typeof(float));
            dt2.Columns.Add("DonGia_Ra", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            //SoLuongTon
            clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();
            clsTbVatTuHangHoa clsVT_Ra = new clsTbVatTuHangHoa();
            clsPhieu_tbPhieu clsphieu = new clsPhieu_tbPhieu();
            clsKhoNPL_tbChiTietNhapKho clsnhapkho = new clsKhoNPL_tbChiTietNhapKho();
            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_SoPhieu"] = Convert.ToInt16(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                clsphieu.iID_SoPhieu = Convert.ToInt16(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                DataTable dtphieu = clsphieu.SelectOne();
                _ravi["MaPhieu"] = dtphieu.Rows[0]["MaPhieu"].ToString();
                //_ravi["ID_VTHH_Vao"] = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                int iiDI_Vthh_vao = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                _ravi["ID_VTHH_Vao"] = iiDI_Vthh_vao;
                clsVT_Vao.iID_VTHH = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                DataTable dtVT_vao = clsVT_Vao.SelectOne();
                _ravi["MaVT_Vao"] = dtVT_vao.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Vao"] = dtVT_vao.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Vao"] = dtVT_vao.Rows[0]["TenVTHH"].ToString();

                _ravi["ID_VTHH_Ra"] = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                clsVT_Ra.iID_VTHH = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                DataTable dtVT_Ra = clsVT_Ra.SelectOne();
                _ravi["MaVT_Ra"] = dtVT_Ra.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Ra"] = dtVT_Ra.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Ra"] = dtVT_Ra.Rows[0]["TenVTHH"].ToString();

                _ravi["SoLuongNhap_May"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongVao"].ToString());

                _ravi["SanLuongThuong_May"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongThuong"].ToString());
                _ravi["SanLuongTangCa_May"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongTangCa"].ToString());
                _ravi["PhePham_May"] = Convert.ToDouble(dtxxxx.Rows[i]["PhePham"].ToString());
                _ravi["DonGia_Vao"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaVao"].ToString());
                _ravi["DonGia_Ra"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaRa"].ToString());
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongVao"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaVao"].ToString());
                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                // clsnhapkho.iID_VTHH = iiDI_Vthh_vao;
                // DataTable dtnhapkho = new DataTable();
                // dtnhapkho= clsnhapkho.Select_W_ID_VTHH();
                //// _ravi["SoLuongTon"] = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongTon"].ToString());
                dt2.Rows.Add(_ravi);

            }
            gridControl1.DataSource = dt2;

            double deTOngtien;

            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();
            dteNgayChungTuNPL.DateTime = DateTime.Today;
        }
        public KhoBTP_ChiTiet_NhapKho_XuatKho_LSX()
        {
            InitializeComponent();
        }

        private void KhoBTP_ChiTiet_NhapKho_XuatKho_LSX_Load(object sender, EventArgs e)
        {
            Load_lockUP_EDIT();
            if (frmQuanLyKhoBanThanhPham.mbNhapKhoTuLenhSXICD == true)
            {
                layoutnguoigianhan.Text = "Người giao hàng";
                Load_SoChungTu_BTP(true);
                HienThi_SUa_LenhSanXuat(UCBTP_NhapKho_LSX_I_C_D.mID_iD_LenhSanXuat, UCBTP_NhapKho_LSX_I_C_D.msMaLenhSanxuat);
            }
            else
            {
                layoutnguoigianhan.Text = "Người nhận hàng";
                Load_SoChungTu_BTP(false);
                HienThi_SUa_LenhSanXuat(UCBTP_XuatKho_LSX_I_C_D.mID_iD_LenhSanXuat, UCBTP_XuatKho_LSX_I_C_D.msMaLenhSanxuat);
            }
            

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

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;

            if (e.Column == clSoLuongNhap_May)
            {
                if (bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao));
                if (bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May));
                fffthanhtien = fffsoluong * ffdongia;
                bandedGridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia_Vao)
            {
                if (bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao));
                if (bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May));
                fffthanhtien = fffsoluong * ffdongia;
                bandedGridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
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

        private void btNhapXuatKho_Click(object sender, EventArgs e)
        {
            if (frmQuanLyKhoBanThanhPham.mbNhapKhoTuLenhSXICD==true)
                Luu_NhapKho_banThanhPham();
            else
                Luu_XuatKho_banThanhPham();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            

        }
    }
}
