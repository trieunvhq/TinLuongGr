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
    public partial class KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII : Form
    {
        public static bool mbThemMoi_XuatKhohoDaiLy, mbCopy, mbSua;
        public static int miID_XuatKhoDaiLy;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayChungTu;
        public static string msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy, msSoChungTu, msGhiChu;
        public static string msdvtthanhphamquydoi, msMaThanhPham, msTenThanhPham;
        public static double mfPrint_soluongtpqiuydoi;
        private string Load_soChungTu_KhoThanhPham()
        {
            string sochungtu = "";
            clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu_KhoThanhPham.Text = "NKTP 1";
                sochungtu= "NKTP 1";
            }
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                txtSoChungTu_KhoThanhPham.Text = "NKTP " + xxx2 + "";
                sochungtu = "NKTP " + xxx2 + "";

            }
           
            return sochungtu;
        }

        private string Load_soChungTu_KhoBanThanhPham()
        {
            string sochungtu = "";
            clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "NKBTP 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                sochungtu = "NKBTP " + xxx2 + "";

            }
            return sochungtu;
        }

        private string Load_soChungTu_Kho_NguyenPhuLieu()
        {
            string sochungtu = "";
            clsKhoNPL_tbNhapKho cls3 = new clsKhoNPL_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "NKNPL 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                sochungtu = "NKNPL " + xxx2 + "";

            }
            return sochungtu;
        }
        private void HienThi_ThemMoi_XuatKho()
        {
            gridNguoiLap.EditValue = 14;
            checkNhapKhoThanhPham.Checked = true;
            dteNgayChungTu.EditValue = DateTime.Today;
            clsDaiLy_tbXuatKho cls3 = new clsDaiLy_tbXuatKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "XKDL 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                txtSoChungTu.Text = "XKDL " + xxx2 + "";

            }
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt = cls.SelectAll_DIStintc_LayDanhSachDaiLy_XuatKho();
            gridMaDaiLy.Properties.DataSource = dt;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

           
        }
        private void HienThi_Sua_XuatKho()
        {
            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
            cls1.iID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
            DataTable dt = cls1.SelectOne();
            if (cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False == true)
                checkNhapKhoThanhPham.Checked = true;
            else checkNhapKhoBTP.Checked = true;

            if (cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe == true)
            {
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();         
            txtGhiChu.Text = cls1.sGhiChu.Value;

            
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            dt2.Columns.Add("ID_ThamChieu", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(double));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));         
            dt2.Columns.Add("TiLe", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
           
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            clsDaiLy_ThamChieu_TinhXuatKho cls2 = new clsDaiLy_ThamChieu_TinhXuatKho();
            cls2.iID_XuatKhoDaiLy= UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
            DataTable dt222 = cls2.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
            for (int i = 0; i < dt222.Rows.Count; i++)
            {

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_ThamChieu"] = Convert.ToInt32(dt222.Rows[i]["ID_ThamChieu"].ToString());
                _ravi3["ID_NhapKhoDaiLy"] = Convert.ToInt32(dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                _ravi3["ID_VTHH"] = Convert.ToInt32(dt222.Rows[i]["ID_VTHH"].ToString());
                _ravi3["SoChungTu"] = dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString();
                _ravi3["MaVT"] = dt222.Rows[i]["MaVT"].ToString();
                _ravi3["TenVTHH"] = dt222.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dt222.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuongNhap"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuongThanhPhamQuyDoi"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["DonGia"] = Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";
                _ravi3["TiLe"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString())/ Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["ThanhTien"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString()) * Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());
             
                dt2.Rows.Add(_ravi3);

            }

            gridControl1.DataSource = dt2;
            clsDaiLy_tbChiTietXuatKho cls = new clsDaiLy_tbChiTietXuatKho();
            cls.iID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
            DataTable dtxx = cls.SelectAll_W_ID_XuatKhoDaiLy();

            DataTable dt3 = new DataTable();
            //ID_ChiTietXuatKho_DaiLy
            dt3.Columns.Add("ID_ChiTietXuatKho_DaiLy", typeof(int));
            dt3.Columns.Add("ID_VTHH", typeof(int));
            dt3.Columns.Add("MaVT", typeof(string));
            dt3.Columns.Add("TenVTHH", typeof(string));
            dt3.Columns.Add("DonViTinh", typeof(string));
            dt3.Columns.Add("SoLuong", typeof(double));
            dt3.Columns.Add("DonGia", typeof(double));
            dt3.Columns.Add("GhiChu", typeof(string));
            dt3.Columns.Add("HienThi", typeof(string));
            dt3.Columns.Add("ThanhTien", typeof(double));
            dt3.Columns.Add("NhapKho_TP_1_BTP_2_NPL_3", typeof(string));
            dt3.Columns.Add("HienThi2", typeof(string));
            dt3.Columns.Add("MaKho", typeof(string));
            for (int i = 0; i < dtxx.Rows.Count; i++)
            {               
                DataRow _ravi3 = dt3.NewRow();
                _ravi3["ID_ChiTietXuatKho_DaiLy"] = Convert.ToInt32(dtxx.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                _ravi3["ID_VTHH"] = Convert.ToInt32(dtxx.Rows[i]["ID_VTHH"].ToString());
                _ravi3["MaVT"] = dtxx.Rows[i]["ID_VTHH"].ToString();
                _ravi3["TenVTHH"] = dtxx.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dtxx.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuong"] = Convert.ToDouble(dtxx.Rows[i]["SoLuongXuat"].ToString());
                _ravi3["DonGia"] = Convert.ToDouble(dtxx.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";
               
                _ravi3["ThanhTien"] = Convert.ToDouble(dtxx.Rows[i]["SoLuongXuat"].ToString())*Convert.ToDouble(dtxx.Rows[i]["DonGia"].ToString());               
                _ravi3["GhiChu"] = dtxx.Rows[i]["GhiChu"].ToString();
                if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "1")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho TP";
                    _ravi3["HienThi2"] = "1";
                    _ravi3["MaKho"] = "1";
                }
                else if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "2")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho BTP";
                    _ravi3["HienThi2"] = "1";
                    _ravi3["MaKho"] = "2";
                }
                else if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "3")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho NPL";
                    _ravi3["HienThi2"] = "1";
                    _ravi3["MaKho"] = "3";
                }
                else
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "";
                    _ravi3["HienThi2"] = "0";
                    _ravi3["MaKho"] = "";
                }
                dt3.Rows.Add(_ravi3);

            }
            gridControl2.DataSource = dt3;
          
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
     
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=5";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

        

            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
            DataTable dtdaily = clsdaily.SelectAll();
            dtdaily.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dtdaily.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            gridMaVT.DataSource = dtxx2;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }

        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            DataTable dv4 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }
            if (gridControl2.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv4 = dv.ToTable();
            }
            if (dv3.Rows.Count==0|| dv4.Rows.Count==0)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }

            else if (gridMaDaiLy.EditValue == null)
            {
                MessageBox.Show("chưa chọn đại lý");
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
        
        private void Luu_ChiTiet_XuatKho_DaiLy(int iiiiID_XuatKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt2_cu = cls2.SelectAll_W_ID_XuatKhoDaiLy();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        int ID_ChiTietXuatKho_DaiLyxxxx = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                        cls2.iID_ChiTietXuatKho_DaiLy = ID_ChiTietXuatKho_DaiLyxxxx;
                        cls2.bTonTai = false;
                        cls2.Update_W_TonTai();
                    }

                }
                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                    cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaXuatKho = false;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho TP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 1;
                    else if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 2;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 3;
                    else cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 0;
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietXuatKho_DaiLy = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho_DaiLy"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt2_moi11111 = cls2.SelectAll_W_ID_XuatKhoDaiLy();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietXuatKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                    cls2.iID_ChiTietXuatKho_DaiLy = ID_ChiTietXuatKho_DaiLyxxxx;
                    cls2.Delete();
                }

                
            }
        }
        private void Luu_ThamCHieuTinhXuatKho(int iiiiID_XuatKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dtthamchieu = dv2232xx.ToTable();

                clsDaiLy_ThamChieu_TinhXuatKho cls3 = new clsDaiLy_ThamChieu_TinhXuatKho();
                cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                DataTable dt3_cu = new DataTable();
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt3_cu = cls3.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
                if (dt3_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3_cu.Rows.Count; i++)
                    {

                        cls3.iID_ThamChieu = Convert.ToInt32(dt3_cu.Rows[i]["ID_ThamChieu"].ToString());
                        cls3.bTonTai = false;
                        cls3.Update_W_TonTai();
                    }
                }

                for (int i = 0; i < dtthamchieu.Rows.Count; i++)
                {
                    int xxiID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls3.iID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                    cls3.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH"].ToString());
                    cls3.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                    cls3.fSoLuongNhap = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongNhap"].ToString());
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    if (dtthamchieu.Rows[i]["DonGia"].ToString() == "")
                        cls3.fDonGia = 0;
                    else cls3.fDonGia = Convert.ToDouble(dtthamchieu.Rows[i]["DonGia"].ToString());


                    string expression;
                    expression = "ID_NhapKhoDaiLy=" + xxiID_NhapKhoDaiLy + "";
                    DataRow[] foundRows;
                    foundRows = dt3_cu.Select(expression);
                    if (foundRows.Length > 0)
                    {
                        cls3.iID_ThamChieu = Convert.ToInt32(foundRows[0]["ID_ThamChieu"].ToString());
                        cls3.Update();
                    }
                    else
                    {
                        cls3.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt3moi = new DataTable();
                cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                DataTable dt3hhshss = cls3.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
                dt3hhshss.DefaultView.RowFilter = "TonTai=False";
                DataView dvdt3jjs = dt3hhshss.DefaultView;
                dt3moi = dvdt3jjs.ToTable();
                for (int i = 0; i < dt3moi.Rows.Count; i++)
                {
                    int IiID_ThamChieuyxxxx = Convert.ToInt32(dt3moi.Rows[i]["ID_ThamChieu"].ToString());
                    cls3.iID_ThamChieu = IiID_ThamChieuyxxxx;
                    cls3.Delete();
                }
            }
        }

        private void Luu_NhapKhoThanhPham()
        {

            if (!KiemTraLuu()) return;
            else
            {
             
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl1.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongNhap)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                Load_soChungTu_KhoThanhPham();
                clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = txtSoChungTu_KhoThanhPham.Text.ToString();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = dexxTongtienhang;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();
                cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.bCheck_NhapKho_Khac = false;
                cls3.sGhiChu = txtGhiChu.Text.ToString();
                cls3.sNguoiGiaoHang = txtTenDaiLy.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkhothanhpham = cls3.iID_NhapKho_ThanhPham.Value;
                clsKhoThanhPham_tbChiTietNhapKho cls5 = new clsKhoThanhPham_tbChiTietNhapKho();
                for (int i = 0; i < dtaaaaa.Rows.Count; i++)
                {
                    cls5.iID_NhapKho_ThanhPham = iiDI_nhapkhothanhpham;
                    cls5.iID_VTHH = Convert.ToInt32(dtaaaaa.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongNhap"].ToString());
                    cls5.fSoLuongTon = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongNhap"].ToString());
                    cls5.fDonGia = Convert.ToDouble(dtaaaaa.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;
                    cls5.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls5.bDaNhapKho = true;
                    cls5.bBool_TonDauKy = false;
                    cls5.sGhiChu = "";
                    cls5.Insert();
                }
              

            }
        }

        private void Luu_NhapKhoThanhPham_khauTru()
        {

            if (!KiemTraLuu()) return;
            else
            {
                DataTable DatatableABC222 = (DataTable)gridControl2.DataSource;
                CriteriaOperator op222 = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
                DataView dv222 = new DataView(DatatableABC222);
                dv222.RowFilter = filterString222;
                DataTable dt222 = dv222.ToTable();
                //NhapKho_TP_1_BTP_2_NPL_3
                string xx = "1";
                dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
                DataView dvxxx222 = dt222.DefaultView;
                DataTable mdtKhauTru = dvxxx222.ToTable();
                if (mdtKhauTru.Rows.Count > 0)
                {
                    clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
                    cls3.sDienGiai = txtDienGiai.Text.ToString();
                    cls3.sSoChungTu = Load_soChungTu_KhoThanhPham();
                    cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls3.fTongTienHang = 0;
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls3.sThamChieu = txtSoChungTu.Text.ToString();
                    cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = false;
                    cls3.sGhiChu = txtGhiChu.Text.ToString();
                    cls3.sNguoiGiaoHang = txtTenDaiLy.Text.ToString();
                    cls3.Insert();
                    int iiDI_nhapkhothanhpham = cls3.iID_NhapKho_ThanhPham.Value;
                    clsKhoThanhPham_tbChiTietNhapKho cls5 = new clsKhoThanhPham_tbChiTietNhapKho();

                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        cls5.iID_NhapKho_ThanhPham = iiDI_nhapkhothanhpham;
                        cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                        cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        cls5.bTonTai = true;
                        cls5.bNgungTheoDoi = false;
                        cls5.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                        cls5.bDaNhapKho = true;
                        cls5.bBool_TonDauKy = false;
                        cls5.sGhiChu = "";
                        cls5.Insert();
                    }
                }

            }
        }
        private void Luu_NhapKho_NguyenPhuLieu_KhauTru()
        {

            if (!KiemTraLuu()) return;
            else
            {

               
                DataTable DatatableABC222 = (DataTable)gridControl2.DataSource;
                CriteriaOperator op222 = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
                DataView dv222 = new DataView(DatatableABC222);
                dv222.RowFilter = filterString222;
                DataTable dt222 = dv222.ToTable();
                //NhapKho_TP_1_BTP_2_NPL_3
                string xx = "3";
                dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
                DataView dvxxx222 = dt222.DefaultView;
                DataTable mdtKhauTru = dvxxx222.ToTable();
                if (mdtKhauTru.Rows.Count > 0)
                {


                    double dexxTongtienhang;
                    object xxtongtienhang = mdtKhauTru.Compute("sum(ThanhTien)", "MaKho=" + xx + "");
                    if (xxtongtienhang.ToString() != "")
                        dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                    else dexxTongtienhang = 0;
                    
                    clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
                    cls1.sDienGiai = txtDienGiai.Text.ToString();
                    cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls1.sSoChungTu = Load_soChungTu_Kho_NguyenPhuLieu();
                    cls1.fTongTienHang = dexxTongtienhang;
                    cls1.iID_NguoiNhapKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls1.sThamChieu = txtSoChungTu.Text.ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaNhapKho = true;
                    cls1.bBool_TonDauKy = false;
                    cls1.bCheck_NhapKho_Khac = false;
                    cls1.Insert();
                    int iiiIDNhapKho = cls1.iID_NhapKho.Value;

                    clsKhoNPL_tbChiTietNhapKho cls5 = new clsKhoNPL_tbChiTietNhapKho();
                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        cls5.iID_NhapKho = iiiIDNhapKho;
                        cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                        cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        cls5.bTonTai = true;
                        cls5.bNgungTheoDoi = false;
                      //  cls5.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                        cls5.bDaNhapKho = true;
                        cls5.bBoolTonDauKy = false;
                        cls5.sGhiChu = "";
                        cls5.Insert();
                    }
                }

            }
        }

        private void Luu_NhapKho_Ban___________ThanhPham_KhauTru()
        {
            if (!KiemTraLuu()) return;
            else
            {
               

              
                clsKhoBTP_tbChiTietNhapKho cls5 = new clsKhoBTP_tbChiTietNhapKho();               

                DataTable DatatableABC222 = (DataTable)gridControl2.DataSource;
                CriteriaOperator op222 = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
                DataView dv222 = new DataView(DatatableABC222);
                dv222.RowFilter = filterString222;
                DataTable dt222 = dv222.ToTable();
                //NhapKho_TP_1_BTP_2_NPL_3
                string xx = "2";
                dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
                DataView dvxxx222 = dt222.DefaultView;
                DataTable mdtKhauTru = dvxxx222.ToTable();
                if (mdtKhauTru.Rows.Count > 0)
                {
                    clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
                    cls3.sDienGiai = txtDienGiai.Text.ToString();
                    cls3.sSoChungTu = Load_soChungTu_KhoThanhPham();
                    cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls3.fTongTienHang = 0;
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls3.sThamChieu = txtSoChungTu.Text.ToString();
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = false;

                    cls3.sNguoiGiaoHang = txtTenDaiLy.Text.ToString();
                    cls3.Insert();
                    int iiDI_nhapkho = cls3.iID_NhapKhoBTP.Value;

                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        cls5.iID_NhapKho = iiDI_nhapkho;
                        cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                        cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        cls5.bTonTai = true;
                        cls5.bNgungTheoDoi = false;
                        cls5.bDaNhapKho = true;
                        cls5.bBoolTonDauKy = false;
                        cls5.sGhiChu = "";
                        cls5.Insert();
                    }
                }
            }

        }

        private void Luu_NhapKho_Ban___________ThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl2.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongXuat)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = Load_soChungTu_KhoThanhPham();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = 0;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();             
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.bCheck_NhapKho_Khac = false;
               
                cls3.sNguoiGiaoHang = txtTenDaiLy.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkho = cls3.iID_NhapKhoBTP.Value;
                clsKhoBTP_tbChiTietNhapKho cls5 = new clsKhoBTP_tbChiTietNhapKho();
                for (int i = 0; i < dtaaaaa.Rows.Count; i++)
                {
                    cls5.iID_NhapKho = iiDI_nhapkho;
                    cls5.iID_VTHH = Convert.ToInt32(dtaaaaa.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fSoLuongTon = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fDonGia = Convert.ToDouble(dtaaaaa.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;                  
                    cls5.bDaNhapKho = true;
                    cls5.bBoolTonDauKy = false;
                    cls5.sGhiChu = "";
                    cls5.Insert();
                }

               
            }
       
        }
        private void Luu_ChiLuu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                string ahienthi = "1";
                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl1.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongNhap)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                int xxxxxiiiiID_XuatKhoDaiLy;
                clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_VTHH = 0;
                cls1.fSoLuongXuat_BaoTo = 0;
                cls1.fSoLuongXuat_BaoBe = 0;
                cls1.fSoLuongThanhPhamQuyDoi = dexxTongSoLuong;
                if (dexxTongSoLuong != 0)
                    cls1.fDonGia = dexxTongtienhang / dexxTongSoLuong;
                else cls1.fDonGia = 0;
                cls1.fTongTienHang = dexxTongtienhang;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_DinhMucDot_BaoTo = 0;
                cls1.iID_DinhMucDot_BaoBe = 0;
                cls1.iID_DinhMucNguenPhuLieu = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.bCheck_BaoVe = false;
                cls1.bCheck_DaiLy = false;
                cls1.bCheck_LaiXe = false;
                cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = false;
                cls1.bTrangThai_XuatKho_DaiLy_GuiDuLieu = false;
                cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = checkNhapKhoThanhPham.Checked;
                cls1.bDaXuatKho = false;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_ThamChieuNhapKho = 0;
                cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;

                if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbSua == false)
                {
                    cls1.Insert();
                    xxxxxiiiiID_XuatKhoDaiLy = cls1.iID_XuatKhoDaiLy.Value;
                }
                else
                {
                    cls1.iID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
                    cls1.Update();
                    xxxxxiiiiID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
                }
                Luu_ChiTiet_XuatKho_DaiLy(xxxxxiiiiID_XuatKhoDaiLy);
                Luu_ThamCHieuTinhXuatKho(xxxxxiiiiID_XuatKhoDaiLy);
                MessageBox.Show("Đã lưu");
            }
        }
        private void Luu_Va_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                int iiiiID_XuatKhoDaiLy;
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl1.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongNhap)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                if (checkNhapKhoThanhPham.Checked == true) //nhap kho thành pham
                {
                    Luu_NhapKhoThanhPham();
                   
                }
                else
                {
                    Luu_NhapKho_Ban___________ThanhPham();
                }
                Luu_NhapKhoThanhPham_khauTru();
                Luu_NhapKho_NguyenPhuLieu_KhauTru();
                Luu_NhapKho_Ban___________ThanhPham_KhauTru();

                clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_VTHH = 0;
                cls1.fSoLuongXuat_BaoTo = 0;
                cls1.fSoLuongXuat_BaoBe = 0;
                cls1.fSoLuongThanhPhamQuyDoi = dexxTongSoLuong;
                if (dexxTongSoLuong != 0)
                    cls1.fDonGia = dexxTongtienhang / dexxTongSoLuong;
                else cls1.fDonGia = 0;
                cls1.fTongTienHang = dexxTongtienhang;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_DinhMucDot_BaoTo = 0;
                cls1.iID_DinhMucDot_BaoBe = 0;
                cls1.iID_DinhMucNguenPhuLieu = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.bCheck_BaoVe = false;
                cls1.bCheck_DaiLy = false;
                cls1.bCheck_LaiXe = false;
                cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;
                cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = true;
                cls1.bTrangThai_XuatKho_DaiLy_GuiDuLieu = false;
                cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = checkNhapKhoThanhPham.Checked;
                cls1.bDaXuatKho = false;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_ThamChieuNhapKho =0;
                if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbSua == false)
                {
                    cls1.Insert();
                    iiiiID_XuatKhoDaiLy = cls1.iID_XuatKhoDaiLy.Value;
                }
                else
                {
                    cls1.iID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
                    cls1.Update();
                    iiiiID_XuatKhoDaiLy = UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.miID_XuatKhoDaiLy;
                }
                // chi tiet nhập kho
                Luu_ChiTiet_XuatKho_DaiLy(iiiiID_XuatKhoDaiLy);
                Luu_ThamCHieuTinhXuatKho(iiiiID_XuatKhoDaiLy);              
                MessageBox.Show("Đã lưu và gửi dữ liệu");

            }
        }
        public KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII()
        {
            InitializeComponent();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
                }
                clsDaiLy_tbNhapKho clsvattu = new clsDaiLy_tbNhapKho();
                clsvattu.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dtvattu = clsvattu.SelectAll_W_ID_DaiLy_hienThiLockUp();
             
                if(dteDenNgay.EditValue!=null & dteTuNgay.EditValue!=null)
                {
                    DateTime tungay = dteTuNgay.DateTime;
                    DateTime denngay = dteDenNgay.DateTime.AddDays(1);
                    dtvattu.DefaultView.RowFilter = " NgayChungTu <='"+dteDenNgay.DateTime+ "' and NgayChungTu >='" + dteTuNgay.DateTime+"' and HoanThanh = False";
                }
                else
                {
                    dtvattu.DefaultView.RowFilter = " HoanThanh = False";
                }
                
                DataView dvvattu = dtvattu.DefaultView;
                DataTable newdtvattu = dvvattu.ToTable();
                gridMaHang.DataSource = newdtvattu;
                gridMaHang.ValueMember = "ID_NhapKhoDaiLy";
                gridMaHang.DisplayMember = "SoChungTu";

            }
            catch
            {

            }
        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
            //    gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "0");
            //if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "0")
            //    gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "0");
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_ChiLuu();
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

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Luu_Va_GuiDuLieu();
        }

        private void btXoaGrid2_Click(object sender, EventArgs e)
        {
            gridView2.SetFocusedRowCellValue(clHienThi2, "0");
        }

        private void gridView2_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }
       
        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv = new DataView(DatatableABC);
            dv.RowFilter = filterString;
            DataTable dt = dv.ToTable();
            string shienthi = "1";
            dt.DefaultView.RowFilter = "HienThi='" + shienthi + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable mdtPrint_Cu = dvxxx.ToTable();

            mdtPrint = new DataTable();
            mdtPrint.Columns.Add("ID_VTHH", typeof(string));
            mdtPrint.Columns.Add("MaVT", typeof(string));
            mdtPrint.Columns.Add("TenVTHH", typeof(string));
            mdtPrint.Columns.Add("DonViTinh", typeof(string));           
            mdtPrint.Columns.Add("SoLuongNhap", typeof(double));
            mdtPrint.Columns.Add("DonGia", typeof(double));
            mdtPrint.Columns.Add("ThanhTien", typeof(double));

            DataTable DatatableABC222 = (DataTable)gridControl2.DataSource;
            CriteriaOperator op222 = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";         
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx+"'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();


            if (mdtPrint_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < mdtPrint_Cu.Rows.Count; i++)
                {
                    DataRow _ravi3 = mdtPrint.NewRow();
                    _ravi3["ID_VTHH"] = mdtPrint_Cu.Rows[i]["ID_VTHH"].ToString();
                    _ravi3["MaVT"] = mdtPrint_Cu.Rows[i]["MaVT"].ToString();
                    _ravi3["TenVTHH"] = mdtPrint_Cu.Rows[i]["TenVTHH"].ToString();
                    _ravi3["DonViTinh"] = mdtPrint_Cu.Rows[i]["DonViTinh"].ToString();
                    _ravi3["SoLuongNhap"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["SoLuongNhap"].ToString());
                    _ravi3["DonGia"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["DonGia"].ToString());
                    _ravi3["ThanhTien"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["ThanhTien"].ToString());
                    mdtPrint.Rows.Add(_ravi3);
                }
                if(mdtKhauTru.Rows.Count>0)
                {
                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        DataRow _ravi3 = mdtPrint.NewRow();
                        _ravi3["ID_VTHH"] = mdtKhauTru.Rows[i]["ID_VTHH"].ToString();
                        _ravi3["MaVT"] = mdtKhauTru.Rows[i]["MaVT"].ToString();
                        _ravi3["TenVTHH"] = mdtKhauTru.Rows[i]["TenVTHH"].ToString();
                        _ravi3["DonViTinh"] = mdtKhauTru.Rows[i]["DonViTinh"].ToString();
                        _ravi3["SoLuongNhap"] = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        _ravi3["DonGia"] = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        _ravi3["ThanhTien"] = Convert.ToDouble(mdtKhauTru.Rows[i]["ThanhTien"].ToString());
                        mdtPrint.Rows.Add(_ravi3);
                    }
                }
                
                int IID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = IID_DaiLy;
                DataTable dxckksd = cls.SelectOne();
                msDiaChi = cls.sDiaChi.Value;
                msSoDienThoai = cls.sSoDienThoai.Value;
                msTenDaiLy = cls.sTenDaiLy.Value;
                msDienGiai = txtDienGiai.Text.ToString();
                msSoChungTu = txtSoChungTu.Text.ToString();
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                msGhiChu = txtGhiChu.Text.ToString();              
                mbPrint = true;
                frmPrint_nhapKho_DaiLy ff = new frmPrint_nhapKho_DaiLy();
                ff.Show();
            }
        }

        private void KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII_Load(object sender, EventArgs e)
        {
            clSoLuongNhap1.Caption = "Số lượng \n nhập";
            dteDenNgay.DateTime = DateTime.Today;
            DateTime ngaydautien;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt32(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt32(ngayhomnay.ToString("MM"));
            ngaydautien = GetFistDayInMonth(nam, thang);       
            dteTuNgay.EditValue = ngaydautien;
         
            Load_LockUp();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            dt2.Columns.Add("ID_ThamChieu", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(double));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("TiLe", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            gridControl1.DataSource = dt2;
            if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbThemMoi_XuatKhohoDaiLy == true)
                HienThi_ThemMoi_XuatKho();
            else if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbSua == true)
            {

                HienThi_Sua_XuatKho();
            }
            else if (UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbCopy == true)
            {

                HienThi_Sua_XuatKho();
                HienThi_ThemMoi_XuatKho();
            }

        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clSoChungTu1)
            {
                clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                cls.iID_NhapKhoDaiLy = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int iiiiID_NhapKhoDaiLy = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                int iiiID_ThanhPham = Convert.ToInt32(dt.Rows[0]["ID_VTHH_TPQuyDoi"].ToString());
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiiID_ThanhPham;
                DataTable dtvt = clsvt.SelectOne();

                DataTable dt2 = cls.SelectOne_W_ID_VTHH_TPQuyDoi();
                gridView4.SetRowCellValue(e.RowHandle, clID_NhapKhoDaiLy1, iiiiID_NhapKhoDaiLy);
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH1, clsvt.sTenVTHH.Value);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh1, clsvt.sDonViTinh.Value);
                gridView4.SetRowCellValue(e.RowHandle, clMaVT2221, clsvt.sMaVT.Value);
                gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongThanhPhamQuyDoi1, dt.Rows[0]["SoLuongThanhPhamQuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clDonGia1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clThanhTien1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clID_VTHH1, iiiID_ThanhPham);
              
                
            }
            try
            {
                if (e.Column == clSoLuongNhap1)
                {
                    double soluongthanhphamquydoi = 0;
                    double soluongnhapthucte = 0;
                    if (gridView4.GetFocusedRowCellValue(clSoLuongThanhPhamQuyDoi1).ToString() == "")
                        soluongthanhphamquydoi = 1;
                    else
                        soluongthanhphamquydoi = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongThanhPhamQuyDoi1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        soluongnhapthucte = 0;
                    else
                        soluongnhapthucte = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    double tile = soluongnhapthucte / soluongthanhphamquydoi;
                    //  gridView4.SetRowCellValue(e.RowHandle, clTiLe, tile);
                    gridView4.SetFocusedRowCellValue(clTiLe1, tile);

                    if (gridView4.GetFocusedRowCellValue(clDonGia1).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);
                }
                if (e.Column == clDonGia1)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia1).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);
                    
                }
            }
            catch
            {

            }
            
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
            gridView4.SetFocusedRowCellValue(clHienThi1, "0");
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
          
            gridControl2.DataSource = null;
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            
            DataTable new_Table = new DataTable();

           

            string shienthi = "1";
            DataTable dtkkk = (DataTable)gridControl1.DataSource;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv2232xx = dtkkk.DefaultView;
            DataTable dt = dv2232xx.ToTable();
            string[] sssDienGiai = new string[dt.Rows.Count];
            clsDaiLy_tbChiTietNhapKho cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string smavt = dt.Rows[i]["MaVT"].ToString();
                string soluong = dt.Rows[i]["SoLuongNhap"].ToString();
                string sdvt = dt.Rows[i]["DonViTinh"].ToString();
                sssDienGiai[i] = ""+ soluong + " ("+ sdvt + ") "+smavt+"_______";
                double tile = Convert.ToDouble(dt.Rows[i]["TiLe"].ToString());
                int iiID_NhapKhoDaiLy = Convert.ToInt32(dt.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                cls.iID_NhapKhoDaiLy = iiID_NhapKhoDaiLy;
                DataTable dtmnoi = cls.SelectAll_W_ID_NhapKhoDaiLy_Moi();
                for (int j = 0; j < dtmnoi.Rows.Count; j++)
                {
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_NhapKhoDaiLy"] = Convert.ToInt32(dtmnoi.Rows[j]["ID_NhapKhoDaiLy"].ToString());
                    _ravi2["ID_VTHH"] = dtmnoi.Rows[j]["ID_VTHH"].ToString();
                    _ravi2["MaVT"] = dtmnoi.Rows[j]["ID_VTHH"].ToString();
                    _ravi2["TenVTHH"] = dtmnoi.Rows[j]["TenVTHH"].ToString();
                    _ravi2["DonViTinh"] = dtmnoi.Rows[j]["DonViTinh"].ToString();
                    _ravi2["SoLuong"] = tile * Convert.ToDouble(dtmnoi.Rows[j]["SoLuongNhap"].ToString());
                    _ravi2["DonGia"] = Convert.ToDouble(dtmnoi.Rows[j]["DonGia"].ToString());
                    _ravi2["HienThi"] = "1";
                    _ravi2["ThanhTien"] = tile * Convert.ToDouble(dtmnoi.Rows[j]["SoLuongNhap"].ToString()) * Convert.ToDouble(dtmnoi.Rows[j]["DonGia"].ToString());
                 
                    dt2.Rows.Add(_ravi2);
                    
                }
               
            }

            txtDienGiai.Text = string.Concat(sssDienGiai);
            new_Table.Columns.Add("ID_VTHH", typeof(string));
            new_Table.Columns.Add("MaVT", typeof(string));
            new_Table.Columns.Add("TenVTHH", typeof(string));
            new_Table.Columns.Add("DonViTinh", typeof(string));
            new_Table.Columns.Add("SoLuong", typeof(double));
            new_Table.Columns.Add("DonGia", typeof(double));
            new_Table.Columns.Add("GhiChu", typeof(string));
            new_Table.Columns.Add("HienThi", typeof(string));
            new_Table.Columns.Add("HienThi2", typeof(string));
            new_Table.Columns.Add("ThanhTien", typeof(double));
            new_Table.Columns.Add("NhapKho_TP_1_BTP_2_NPL_3", typeof(string));
            new_Table.Columns.Add("MaKho", typeof(string));
            var groupedByState = dt2.AsEnumerable()
                .GroupBy(r => r.Field<String>("ID_VTHH"));
            foreach (var group in groupedByState)
            {
                DataRow maxPremRow = group.OrderByDescending(r => r.Field<String>("ID_VTHH")).First();
                DataRow newRow = new_Table.Rows.Add();


                newRow.SetField("ID_VTHH", maxPremRow.Field<string>("ID_VTHH"));
                newRow.SetField("SoLuong", group.Sum(r => r.Field<double?>("SoLuong")));
                newRow.SetField("MaVT", maxPremRow.Field<string>("ID_VTHH"));
                newRow.SetField("TenVTHH", maxPremRow.Field<string>("TenVTHH"));
                newRow.SetField("DonViTinh", maxPremRow.Field<string>("DonViTinh"));
                newRow.SetField("GhiChu","");
                newRow.SetField("DonGia", 0);
                newRow.SetField("ThanhTien", 0);
                newRow.SetField("HienThi", "1");
                newRow.SetField("HienThi2", "0");
                newRow.SetField("NhapKho_TP_1_BTP_2_NPL_3", "");
                newRow.SetField("MaKho", "");
            }
            gridControl2.DataSource = new_Table;

        }
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT2)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView2.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView2.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView2.SetRowCellValue(e.RowHandle, clID_VTHH2, kk);
                    gridView2.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView2.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView2.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView2.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView2.SetRowCellValue(e.RowHandle, clDonGia2, 0);                 

                  
                }
            }

            if (e.Column == clNhapKho_TP_1_BTP_2_NPL_3_22222)
            {
                if (gridView2.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() != "")
                    gridView2.SetRowCellValue(e.RowHandle, clHienThi2222, "1");

                if(gridView2.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString()== "Kho TP")
                     gridView2.SetRowCellValue(e.RowHandle, clMaKho, "1");
                else if (gridView2.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho BTP")
                    gridView2.SetRowCellValue(e.RowHandle, clMaKho, "2");
                else if (gridView2.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho NPL")
                    gridView2.SetRowCellValue(e.RowHandle, clMaKho, "3");
                else gridView2.SetRowCellValue(e.RowHandle, clMaKho, "");
             
            }

            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clSoLuong2)
                {

                    if (gridView2.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clDonGia2));
                    if (gridView2.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;                   
                        fffsoluong = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView2.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);
                }
                if (e.Column == clDonGia2)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia2));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);

                }
            }
            catch
            {

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
