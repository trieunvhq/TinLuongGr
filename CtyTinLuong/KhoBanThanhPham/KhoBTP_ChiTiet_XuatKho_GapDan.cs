﻿using DevExpress.XtraGrid.Views.Grid;
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
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiNhanHang, msDienGiai;
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
        private void HienThi_Copy(int iiIDXuatkho)
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
        private void HienThi_Sua(int iiIDXuatkho)
        {
            clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
            cls1.iID_XuatKhoBTP = iiIDXuatkho;
            DataTable dt = cls1.SelectOne();
            if (cls1.bGuiDuLieu == true)
                btLuu_Gui_Dong.Visible = false;
            else btLuu_Gui_Dong.Visible = true;
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
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dt = clsvthhh.T_SelectAll();


            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            dt = clsNguoi.T_SelectAll(5);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dt.Dispose();
            clsvthhh.Dispose();
            clsNguoi.Dispose();
        }

        private void Luu_ChiTietXuatKho_BTP(int iiiDXuatKho)
        {

            string shienthi = "1";

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
                    cls2.fSoLuongNhap = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongXuat"].ToString());
                    cls2.fSoLuongTon = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongXuat"].ToString());
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
        private void Luu_ChiLuu()
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
                cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 1;
                cls1.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                int xxiD_xuatkho;
                if (UCBanThanhPham_XuatKho_Khac.mbSua == false)
                {
                    cls1.bGuiDuLieu = false;
                    cls1.Insert();
                    xxiD_xuatkho = cls1.iID_XuatKhoBTP.Value;
                }
                else
                {
                    clsKhoBTP_tbXuatKho cls2 = new clsKhoBTP_tbXuatKho();
                    cls2.iID_XuatKhoBTP = UCBanThanhPham_XuatKho_Khac.miID_XuatKho;
                    DataTable dt2 = cls2.SelectOne();
                    cls1.iID_XuatKhoBTP = UCBanThanhPham_XuatKho_Khac.miID_XuatKho;
                    cls1.bGuiDuLieu = cls2.bGuiDuLieu.Value;
                    cls1.Update();
                    xxiD_xuatkho = UCBanThanhPham_XuatKho_Khac.miID_XuatKho;
                    cls2.Dispose();
                    dt2.Dispose();
                }
                cls1.Dispose();

                Luu_ChiTietXuatKho_BTP(xxiD_xuatkho);
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }

        private void Luu_GuiDuLieu()
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
                cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 1;
                cls1.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                int xxiD_nhpakho;
                if (UCBanThanhPham_XuatKho_Khac.mbSua == false)
                {
                    cls1.bGuiDuLieu = true;
                    cls1.Insert();
                    xxiD_nhpakho = cls1.iID_XuatKhoBTP.Value;
                }
                else
                {

                    cls1.iID_XuatKhoBTP = UCBanThanhPham_XuatKho_Khac.miID_XuatKho;
                    cls1.bGuiDuLieu = true;
                    cls1.Update();
                    xxiD_nhpakho = UCBanThanhPham_XuatKho_Khac.miID_XuatKho;
                }
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
                cls1xx.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                int iiID_Nhapkho_GapDan;
                cls1xx.Insert();
                iiID_Nhapkho_GapDan = cls1xx.iID_NhapKho.Value;
                Luu_ChiTiet_NhapKho_GapDan(iiID_Nhapkho_GapDan);
                cls1xx.Dispose();
                MessageBox.Show("Đã lưu và gửi dữ liệu");
                this.Close();
            }
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

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
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
