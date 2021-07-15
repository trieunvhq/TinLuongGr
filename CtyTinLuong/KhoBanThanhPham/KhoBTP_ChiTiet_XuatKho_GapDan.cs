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
    public partial class KhoBTP_ChiTiet_XuatKho_GapDan : Form
    {
        public static bool mbPrint=false;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai;
        public static double mdbTongSotien;
        private string sochungtu_gapdan()
        {
            string sochungtu = "";
            clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
            DataTable dt1 = cls1.SelectAll();
            cls1.Dispose();
            dt1.Dispose();
            int k = dt1.Rows.Count;
            if (k == 0)
            {
                sochungtu = "NKGD 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "NKGD " + xxx2.ToString() + "";
            }
            return sochungtu;
        }
        private string sochungtu_BTP()
        {
            string sochungtu = "";
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
            return sochungtu;
        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 12;
            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = sochungtu_BTP();
            txtThamChieu.Text = sochungtu_gapdan();
          
        }
        private void HienThi_Copy(int iiIDXuatkho)
        {
            clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
            cls1.iID_XuatKhoBTP = iiIDXuatkho;
            DataTable dt = cls1.SelectOne();
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = sochungtu_BTP();
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = sochungtu_gapdan();

         
            clsGapDan_tbNhapKho cls3 = new CtyTinLuong.clsGapDan_tbNhapKho();
            DataTable dt3 = cls3.SO_W_SoChungTu(cls1.sThamChieu.Value);
            if(dt3.Rows.Count>0)
            {
                gridDinhMucGapDan.EditValue = Convert.ToInt32(dt3.Rows[0]["ID_DinhMuc_ToGapDan"].ToString());
            }
            clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
            DataTable dt2 = cls2.SA_ID_XuatKho(iiIDXuatkho);
            txtSoLuongXuat.Text = dt2.Rows[0]["SoLuongXuat"].ToString();
            txtDonGiaChinh.Text = dt2.Rows[0]["DonGia"].ToString();

            cls1.Dispose();
            dt.Dispose();
            cls2.Dispose();
            dt2.Dispose();
            cls3.Dispose();
            dt3.Dispose();
        }
        private void HienThi_Sua(int iiIDXuatkho)
        {
            clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
            cls1.iID_XuatKhoBTP = iiIDXuatkho;
            DataTable dt = cls1.SelectOne();
            if (cls1.bGuiDuLieu == true)
                btLuu_Gui_Dong.Enabled = false;
            else btLuu_Gui_Dong.Enabled = true;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;

            clsGapDan_tbNhapKho cls3 = new CtyTinLuong.clsGapDan_tbNhapKho();
            DataTable dt3 = cls3.SO_W_SoChungTu(cls1.sThamChieu.Value);
            if (dt3.Rows.Count > 0)
            {
                gridDinhMucGapDan.EditValue = Convert.ToInt32(dt3.Rows[0]["ID_DinhMuc_ToGapDan"].ToString());
            }
            clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
            DataTable dt2 = cls2.SA_ID_XuatKho(iiIDXuatkho);
            txtSoLuongXuat.Text = dt2.Rows[0]["SoLuongXuat"].ToString();
            txtDonGiaChinh.Text = dt2.Rows[0]["DonGia"].ToString();

            cls1.Dispose();
            dt.Dispose();
            cls2.Dispose();
            dt2.Dispose();
            cls3.Dispose();
            dt3.Dispose();
        }

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
            else if (gridDinhMucGapDan.EditValue == null)
            {
                MessageBox.Show("Chưa có có định mức ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }
            else if (txtSoLuongXuat.Text.ToString() == "0")
            {
                MessageBox.Show("Chưa chọn số lượng ");
                return false;
            }
            else return true;

        }
        private void Load_LockUp()
        {
            clsDinhMuc_DinhMuc_ToGapDan cls = new clsDinhMuc_DinhMuc_ToGapDan();
            DataTable dt2 = cls.SelectAll();
            gridDinhMucGapDan.Properties.DataSource = dt2;
            gridDinhMucGapDan.Properties.ValueMember = "ID_DinhMuc_ToGapDan";
            gridDinhMucGapDan.Properties.DisplayMember = "MaDinhMuc";
            
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dt = clsNguoi.T_SelectAll(4);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dt.Dispose();
            dt2.Dispose();
            cls.Dispose();
            clsNguoi.Dispose();
        }

        private void Luu_ChiTietXuatKho_BTP(int iiiDXuatKho)
        {

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

            int ID_VTHHxxx = Convert.ToInt32(txtID_Chinh.Text.ToString());
            cls.iID_VTHH = ID_VTHHxxx;
            cls.iID_XuatKhoBTP = iiiDXuatKho;
            cls.fSoLuongXuat = CheckString.ConvertToDouble_My(txtSoLuongXuat.Text.ToString());
            cls.fDonGia = CheckString.ConvertToDouble_My(txtDonGiaChinh.Text.ToString());

            cls.bTonTai = true;
            cls.bNgungTheoDoi = false;
            cls.sGhiChu = "";
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

        private void Luu_ChiTiet_NhapKho_GapDan(int iiiID_nhapkhogapgan)
        {
            if (!KiemTraLuu()) return;
            else
            {
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
                int ID_ThanhPham = Convert.ToInt32(txtID_ThanhPham.Text.ToString());
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                cls2.iID_VTHH = ID_ThanhPham;
                double soluongthanpham = Convert.ToDouble(txtSoLuongTP.Text.ToString());
                cls2.fSoLuongNhap = soluongthanpham;
                cls2.fSoLuongTon = soluongthanpham;
                cls2.fDonGia = 0;
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bBoolTonDauKy = false;
                cls2.bDaNhapKho = true;
                string expression1;
                expression1 = "ID_VTHH=" + ID_ThanhPham + "";
                DataRow[] foundRows1;
                foundRows1 = dt2_cu.Select(expression1);
                if (foundRows1.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows1[0]["ID_ChiTietNhapKho"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
                }
                int ID_Chinh = Convert.ToInt32(txtID_Chinh.Text.ToString());
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                cls2.iID_VTHH = ID_Chinh;
                double soluongchinh = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                cls2.fSoLuongNhap = soluongchinh;
                cls2.fSoLuongTon = soluongchinh;
                cls2.fDonGia = Convert.ToDouble(txtDonGiaChinh.Text.ToString());
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bBoolTonDauKy = false;
                cls2.bDaNhapKho = true;
                string expression2;
                expression2 = "ID_VTHH=" + ID_Chinh + "";
                DataRow[] foundRows2;
                foundRows2 = dt2_cu.Select(expression2);
                if (foundRows2.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows2[0]["ID_ChiTietNhapKho"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
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
        

        private void Luu_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                double tongtienhang, soluongxuat, dongia;
                soluongxuat = CheckString.ConvertToDouble_My(txtSoLuongXuat.Text.ToString());
                dongia = CheckString.ConvertToDouble_My(txtDonGiaChinh.Text.ToString());
                tongtienhang = soluongxuat * dongia;

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
                cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 1;
                cls1.sNguoiNhanHang = "";
                int xxiD_nhpakho;

                cls1.bGuiDuLieu = true;
                cls1.Insert();
                xxiD_nhpakho = cls1.iID_XuatKhoBTP.Value;

                cls1.Dispose();

                Luu_ChiTietXuatKho_BTP(xxiD_nhpakho);
                // Lưu nhập kho gấp dán
                clsGapDan_tbNhapKho cls1xx = new clsGapDan_tbNhapKho();
                cls1xx.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1xx.sSoChungTu = txtThamChieu.Text.ToString();
                cls1xx.sDienGiai = txtDienGiai.Text.ToString();
                cls1xx.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1xx.sThamChieu = txtSoChungTu.Text.ToString();
                cls1xx.fTongTienHang = 0;
                cls1xx.bBool_TonDauKy = false;
                cls1xx.bDaNhapKho = true;
                cls1xx.bTonTai = true;
                cls1xx.bNgungTheoDoi = false;
                cls1xx.sNguoiNhanHang = "";
                cls1xx.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1xx.iID_VTHH_ThanhPham_QuyDoi = Convert.ToInt32(txtID_ThanhPham.Text);
                cls1xx.fDonGia_ThanhPham_QuyDoi = 0;
                cls1xx.fSoLuongThanhPham_QuyDoi= Convert.ToDouble(txtSoLuongTP.Text.ToString());
                int iiID_Nhapkho_GapDan;
                cls1xx.Insert();
                iiID_Nhapkho_GapDan = cls1xx.iID_NhapKho.Value;
                Luu_ChiTiet_NhapKho_GapDan(iiID_Nhapkho_GapDan);
                cls1xx.Dispose();
                MessageBox.Show("Đã lưu và gửi dữ liệu");
                this.Close();
            }
        }



        private void TinhToanTHanhPham(int xxID_DMgapdan)
        {

            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();

            DataTable dt1 = cls.SA_ID_DinhMuc_VT_Chinh(xxID_DMgapdan);
            double xxsoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
            txtTenVT_Chinh.Text = dt1.Rows[0]["TenVTHH"].ToString();
            DVT_Chinh.Text = dt1.Rows[0]["DonViTinh"].ToString();
            txtID_Chinh.Text= dt1.Rows[0]["ID_VTHH"].ToString();

            cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            DataTable dt2 = cls.SA_ID_DinhMuc_ThanhPham(xxID_DMgapdan);
            txtTenVT_ThanhPham.Text = dt2.Rows[0]["TenVTHH"].ToString();
            DVT_ThanhPham.Text = dt2.Rows[0]["DonViTinh"].ToString();
            txtID_ThanhPham.Text = dt2.Rows[0]["ID_VTHH"].ToString();

            double dinhmuc = Convert.ToDouble(dt1.Rows[0]["SoLuong"].ToString());
            txtSoLuongTP.Text = (xxsoluongxuat / dinhmuc).ToString();

            cls.Dispose();
            dt1.Dispose();
            dt2.Dispose();
        }
        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Luu_GuiDuLieu();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //try
            //{
            ////    DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            //    CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
            //    string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            //    DataView dv1212 = new DataView(DatatableABC);
            //    dv1212.RowFilter = filterString;
            //    DataTable dttttt2 = dv1212.ToTable();
            //    string shienthi = "1";
            //    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            //    DataView dv = dttttt2.DefaultView;
            //    mdtPrint = dv.ToTable();
            //    if (mdtPrint.Rows.Count > 0)
            //    {
            //        mbPrint = true;
            //        mdaNgayChungTu = dteNgayChungTu.DateTime;
            //        msSoChungTu = txtSoChungTu.Text.ToString();
            //        msNguoiGiaoHang = txtNguoiNhanHang.Text.ToString();
            //        mdbTongSotien = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
            //        msDienGiai = txtDienGiai.Text.ToString();
            //        frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
            //        ff.Show();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Không có dữ liệu để in!", "Thông báo");
            //}
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
                gridDinhMucGapDan.Focus();
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

        private void txtSoLuongXuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xxxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                TinhToanTHanhPham(xxxID);
            }
            catch
            { }
           
        }

        private void gridDinhMucGapDan_EditValueChanged(object sender, EventArgs e)
        {
            int xxxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            clsDinhMuc_DinhMuc_ToGapDan cls2 = new clsDinhMuc_DinhMuc_ToGapDan();
            cls2.iID_DinhMuc_ToGapDan = xxxID;
            DataTable dt2 = cls2.SelectOne();
            txtDienGiaiDMNPL.Text = cls2.sDienGiai.Value;
            if (UCBanThanhPham_XuatKho_Khac.mbThemMoi == true)
                txtDienGiai.Text = cls2.sDienGiai.Value;
            cls2.Dispose();
            dt2.Dispose();
            TinhToanTHanhPham(xxxID);
        }

        private void txtDienGiaiDMNPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu cls = new CtyTinLuong.clsNhanSu_tbNhanSu();
                cls.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                txtNguoiNhap.Text = cls.sTenNhanVien.Value;
                cls.Dispose();
                dt.Dispose();
            }
            catch
            { }
           
        }

        public KhoBTP_ChiTiet_XuatKho_GapDan()
        {
            InitializeComponent();
        }

        private void KhoBTP_ChiTiet_XuatKho_GapDan_Load(object sender, EventArgs e)
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
    }
}
