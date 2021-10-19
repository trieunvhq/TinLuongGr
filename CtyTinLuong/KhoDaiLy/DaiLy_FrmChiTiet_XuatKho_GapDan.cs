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
    public partial class DaiLy_FrmChiTiet_XuatKho_GapDan : Form
    {
        private DataTable _dtDonGiatheoVTHH, _data, _dtCongNhan;
        private int _id_bophan, _id_vthh;

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
                soluongxuat = CheckString.ConvertToDouble_My(rows_Xuat[0]["SoLuong_XuatTruocKy"].ToString());
            if (rows_Nhap.Length == 0)
                soluongnhap = 0;
            else
                soluongnhap = CheckString.ConvertToDouble_My(rows_Nhap[0]["SoLuong_NhapTruocKy"].ToString());
            soluongton = soluongnhap - soluongxuat;

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";
            cls1.Dispose();
            cls2.Dispose();
            cls.Dispose();
            dt_NhapTruoc.Dispose();
            dt_XuatTruoc.Dispose();
            dt.Dispose();
        }

        public static DateTime mdaPrintNgayXuatKho;
        public static DataTable mdtPrint_ChiTietXuatKho;
        public static string msPrintSoChungTu, msPrintDienGiaig, msPrintThuKho, msPrintNguoiNhan, msPrintNguoiLap;
        
        private void HienThi_Grid_ConTrol_Themmoi(double soluongxuat, int xxID_DMgapdan)
        {
            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            DataTable dt = cls.SA_IDDM_W_SoLuong(soluongxuat,xxID_DMgapdan);
            gridControl1.DataSource = dt;          
            cls.Dispose();
            dt.Dispose();
        }
        private string SoCHungTu_GapDan()
        {
            string sochungtu;
            clsGapDan_tbXuatKho cls = new clsGapDan_tbXuatKho();
            DataTable dt1 = cls.SelectAll();
         
            int k2 = dt1.Rows.Count;
            if (k2 == 0)
                sochungtu = "XKGD 1";
            else
            {
                string xxx = dt1.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "XKGD 1";
                else sochungtu = "XKGD " + xxx2 + "";

            }
            cls.Dispose();
            dt1.Dispose();
            return sochungtu;
        }


        private void HienThi_Sua_XuatKho(int iiID_xuatkho_)
        {
            clsGapDan_tbXuatKho cls = new clsGapDan_tbXuatKho();
            cls.iID_XuatKho = iiID_xuatkho_;
            DataTable dt = cls.SelectOne();
            txtSoChungTu.Text = cls.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiNhap.Value;
            gridDinhMucGapDan.EditValue = cls.iID_DinhMuc_ToGapDan.Value;
            txtSoLuongTP.Text = cls.fSoLuongThanhPham_QuyDoi.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtThamChieu.Text = cls.sThamChieu.Value;
            cls.Dispose();
            dt.Dispose();

            clsGapDan_ChiTiet_XuatKho cls1 = new clsGapDan_ChiTiet_XuatKho();
            DataTable dt1 = cls1.SA_ID_XuatKho(_id_bophan, iiID_xuatkho_, dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year);
            gridControl1.DataSource = dt1;

            cls1.Dispose();
            dt1.Dispose();
        }

        private void HienThi_Copy(int iiID_xuatkho_)
        {
            clsGapDan_tbXuatKho cls = new clsGapDan_tbXuatKho();
            cls.iID_XuatKho = iiID_xuatkho_;
            DataTable dt = cls.SelectOne();
            txtSoChungTu.Text = SoCHungTu_GapDan();
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiNhap.Value;
            gridDinhMucGapDan.EditValue = cls.iID_DinhMuc_ToGapDan.Value;
            txtSoLuongTP.Text = cls.fSoLuongThanhPham_QuyDoi.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtThamChieu.Text = cls.sThamChieu.Value;
            cls.Dispose();
            dt.Dispose();

            clsGapDan_ChiTiet_XuatKho cls1 = new clsGapDan_ChiTiet_XuatKho();
          
            DataTable dt1 = cls1.SA_ID_XuatKho(_id_bophan, iiID_xuatkho_, dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year);
            gridControl1.DataSource = dt1;
            cls1.Dispose();
            dt1.Dispose();
        }
        private void HienThiThemMoi()
        {
            gridNguoiLap.EditValue = 12;
            dteNgayChungTu.EditValue = DateTime.Today;          
            txtSoChungTu.Text = SoCHungTu_GapDan();
            string xxx = SoCHungTu_GapDan();
            txtThamChieu.Text = xxx.Replace("XKGD", "NKĐK");
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


            clsThin clsThin_ = new clsThin();
            _dtCongNhan = clsThin_.T_NhanSu_SF(_id_bophan + ",");
            //_dtCongNhan = clsNguoi.T_SelectAll(_id_bophan);
            gridCongNhan.DataSource = _dtCongNhan;
            gridCongNhan.ValueMember = "ID_NhanSu";
            gridCongNhan.DisplayMember = "MaNhanVien";

            dt.Dispose();
            dt2.Dispose();
            cls.Dispose();
            clsNguoi.Dispose();

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            DataTable dtvt = clsvt.SelectAll();
            //clsTr_MaHangToGD_DB_DK clsvt = new clsTr_MaHangToGD_DB_DK();
            //DataTable dtvt = clsvt.Tr_MaHangToGD_DB_DK_SelectBoPhan(dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year, _id_bophan);

            gridMaVT.DataSource = dtvt;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";

            dtvt.Dispose();
            clsvt.Dispose();
        }
      
        private bool KiemTraLuu()
        {
           
            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                gridControl1.Focus();
                return false;
            }

            else if (dteNgayChungTu.Text.ToString() == "")
            {
                dteNgayChungTu.Focus();
                MessageBox.Show("Không để trống ngày chứng từ");
                return false;
            }
           
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số chứng từ ");
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa có người nhập kho");
                gridNguoiLap.Focus();
                return false;
            }
            else if (gridDinhMucGapDan.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa chọn định mức");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }

        private void Luu_ThamCHieuTinhXuatKho(int iiID_Xuatkhogapdan)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dtthamchieu = dv2232xx.ToTable();

                DataTable dt3_cu = new DataTable();
                clsGapDan_ThamChieuTinhXuatKho cls3 = new clsGapDan_ThamChieuTinhXuatKho();
                cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;

                dt3_cu = cls3.SelectAll_W_ID_XuatKhoGapDan();
                if (dt3_cu.Rows.Count > 0)
                {
                    cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                    cls3.bTonTai = false;
                    cls3.Update_All_TonTai_W_ID_XuatKhoGapDan();
                }

                for (int i = 0; i < dtthamchieu.Rows.Count; i++)
                {

                    cls3 = new clsGapDan_ThamChieuTinhXuatKho();

                    cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                    cls3.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                    int iID_NhapKhoGapDanxxx = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoGapDan"].ToString());
                    cls3.fSoLuongXuat = CheckString.ConvertToDouble_My(dtthamchieu.Rows[i]["SoLuongXuat"].ToString());
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    if (dtthamchieu.Rows[i]["DonGia"].ToString() == "")
                        cls3.fDonGia = 0;
                    else cls3.fDonGia = CheckString.ConvertToDouble_My(dtthamchieu.Rows[i]["DonGia"].ToString());
                    cls3.iID_DinhMuc_ToGapDan = Convert.ToInt32(dtthamchieu.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                    cls3.fSoLuongThanhPham_QuyDoi = CheckString.ConvertToDouble_My(dtthamchieu.Rows[i]["SoLuongThanhPham_QuyDoi"].ToString());
                    cls3.iID_NhapKhoGapDan = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoGapDan"].ToString());
                    string expression;
                    expression = "ID_NhapKhoGapDan=" + iID_NhapKhoGapDanxxx + "";
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
                cls3 = new clsGapDan_ThamChieuTinhXuatKho();
                DataTable dt3moi = new DataTable();
                cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                DataTable dt3hhshss = cls3.SelectAll_W_ID_XuatKhoGapDan();
                dt3hhshss.DefaultView.RowFilter = "TonTai=False";
                DataView dvdt3jjs = dt3hhshss.DefaultView;
                dt3moi = dvdt3jjs.ToTable();
                for (int i = 0; i < dt3moi.Rows.Count; i++)
                {
                    int IiID_ThamChieuyxxxx = Convert.ToInt32(dt3moi.Rows[i]["ID_ThamChieu"].ToString());
                    cls3.iID_ThamChieu = IiID_ThamChieuyxxxx;
                    cls3.Delete();
                }
                cls3.Dispose();
            }

        }

        private void Luu_ChiTiet_XuatKho_GapDan(int iiiID_xuatkhogapgan)
        {
            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                dt2_cu = cls2.SelectAll_ID_XuatKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_tonTai_W_ID_NhapKho();
                }

                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongXuat"].ToString());
                    cls2.fDonGia = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaXuatKho = true;
                  
                    cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 0;
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
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                dt2_moi11111 = cls2.SelectAll_ID_XuatKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_ChiTietXuatKho = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }
                cls2.Dispose();
            }
        }

        private void Luu_NhapKhoDongKien(int iiID_Xuatkho_Gapdan)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsDongKien_TbNhapKho cls1 = new clsDongKien_TbNhapKho();
                clsDongKien_TbNhapKho cls2 = new clsDongKien_TbNhapKho();
                cls1.iID_NhapKhoDongKien = iiID_Xuatkho_Gapdan;
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtThamChieu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1.iID_VTHH_ThanhPham_QuyDoi = Convert.ToInt32(txtID_ThanhPham.Text);
                cls1.fDonGia_ThanhPham_QuyDoi = CheckString.ConvertToDouble_My(txtDonGiaTP.Text);
                cls1.fSoLuongThanhPham_QuyDoi = CheckString.ConvertToDouble_My(txtSoLuongTP.Text);
                cls1.fTongTienHang = CheckString.ConvertToDouble_My(txtThanhTien.Text);
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtSoChungTu.Text;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiGiaoHang = "";
                cls1.bDaNhapKho = true;              
                DataTable dt2 = cls2.SelectOne();
                if (dt2.Rows.Count > 0)
                    cls1.bTrangThaiNhapKhoThanhPham = cls2.bTrangThaiNhapKhoThanhPham.Value;
                else cls1.bTrangThaiNhapKhoThanhPham = false;
                if (UCDaiLy_XuatKho_GapDan.mbsua == false)
                {
                    cls1.fSoLuongTon_SauKhiNhapKhoThanhPham= CheckString.ConvertToDouble_My(txtSoLuongTP.Text);
                    cls1.Insert();
                }
                else
                    cls1.Update();
                cls1.Dispose();
                cls2.Dispose();
                dt2.Dispose();
            }
        }
        private void Luu_XuatKho_GapDan()
        {
            if (!KiemTraLuu()) return;
            else
            {
                //    try
                //    {            

                clsGapDan_tbXuatKho cls1 = new clsGapDan_tbXuatKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1.iID_VTHH_ThanhPham_QuyDoi = Convert.ToInt32(txtID_ThanhPham.Text);
                cls1.fDonGia_ThanhPham_QuyDoi = CheckString.ConvertToDouble_My(txtDonGiaTP.Text);
                cls1.fSoLuongThanhPham_QuyDoi = CheckString.ConvertToDouble_My(txtSoLuongTP.Text);
                cls1.fTongTienHang = CheckString.ConvertToDouble_My(txtThanhTien.Text);
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtThamChieu.Text;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiGiaoHang = "";
                cls1.bTrangThaiNhapKhoBTP_ThanhPham = true;
                cls1.bDaXuatKho = true;
                cls1.bCheckNhapKhoThanhPham = true;
                int iiID_Nhapkho_GapDan;

                if (UCDaiLy_XuatKho_GapDan.mbsua == false)
                {
                    cls1.Insert();
                    iiID_Nhapkho_GapDan = cls1.iID_XuatKho.Value;

                }
                else
                {

                    cls1.iID_XuatKho = UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan;
                    iiID_Nhapkho_GapDan = UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan;
                    cls1.Update();
                }


                Luu_ChiTiet_XuatKho_GapDan(iiID_Nhapkho_GapDan);
                Luu_NhapKhoDongKien(iiID_Nhapkho_GapDan);
                //Luu_ThamCHieuTinhXuatKho(iiID_Nhapkho_GapDan);
                cls1.Dispose();

                //
                this.Close();
                _ucDLXKGD.UCDaiLy_XuatKho_GapDan_Load(null, null);
                MessageBox.Show("Đã lưu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //catch
                //{
                //    MessageBox.Show("Không thể lưu dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        UCDaiLy_XuatKho_GapDan _ucDLXKGD;
        public DaiLy_FrmChiTiet_XuatKho_GapDan(UCDaiLy_XuatKho_GapDan ucDLXKGD)
        {
            _ucDLXKGD = ucDLXKGD;
            InitializeComponent();

            //
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhanSu", typeof(int));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("SanLuong", typeof(string));
            dt2.Columns.Add("DonGia", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(string));
            gridControl2.DataSource = dt2;

            _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
        }


        private void DaiLy_FrmChiTiet_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            if (UCDaiLy_XuatKho_GapDan.mbthemmoi == true)
                HienThiThemMoi();
            else if (UCDaiLy_XuatKho_GapDan.mbcopy == true)
                HienThi_Copy(UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan);
            else if (UCDaiLy_XuatKho_GapDan.mbsua == true)
                HienThi_Sua_XuatKho(UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan);

            Load_LockUp();

            using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
            {
                _dtDonGiatheoVTHH = cls.Tr_MaHangToGD_DB_DK_SelectBoPhan(dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year, _id_bophan);
            }

            Cursor.Current = Cursors.Default;
        }
        
        private void btLuu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Luu_XuatKho_GapDan();
            Cursor.Current = Cursors.Default;
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

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenNguoiLap.Focus();
            }
        }

        private void txtTenNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ///*txtNguoiGiaoHang*/.Focus();
            }
        }
        
        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_VTHH2)
            {
                int idvthh = Convert.ToInt16(gridView3.GetRowCellValue(e.RowHandle, e.Column));
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = idvthh;
                int kk = Convert.ToInt16(gridView3.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView3.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView3.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView3.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView3.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView3.SetRowCellValue(e.RowHandle, clDonGia2, getDonGiaTheoIDVHH(idvthh));
                    gridView3.SetRowCellValue(e.RowHandle, clThanhTien2, 0);
                }
            }

            if (e.Column == clNhapKho_TP_1_BTP_2_NPL_3_22222)
            {
                if (gridView3.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() != "")
                    gridView3.SetRowCellValue(e.RowHandle, clHienThi2222, "1");

                if (gridView3.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho TP")
                    gridView3.SetRowCellValue(e.RowHandle, clMaKho, "1");
                else if (gridView3.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho BTP")
                    gridView3.SetRowCellValue(e.RowHandle, clMaKho, "2");
                else if (gridView3.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho NPL")
                    gridView3.SetRowCellValue(e.RowHandle, clMaKho, "3");
                else gridView3.SetRowCellValue(e.RowHandle, clMaKho, "");

            }

            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clSoLuong2)
                {
                    if (gridView3.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView3.GetFocusedRowCellValue(clDonGia2));
                    if (gridView3.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    fffsoluong = CheckString.ConvertToDouble_My(gridView3.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView3.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);
                }
                if (e.Column == clDonGia2)
                {
                    if (gridView3.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView3.GetFocusedRowCellValue(clDonGia2));
                    if (gridView3.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView3.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView3.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);

                }
            }
            catch
            {

            }
        }

        private void gridView3_RowClick(object sender, RowClickEventArgs e)
        {
            //if (gridView3.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            if (gridView3.GetFocusedRowCellValue(clID_VTHH2) == null
                || gridView3.GetFocusedRowCellValue(clID_VTHH2).ToString() == "")
                return;
            else
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView3.GetFocusedRowCellValue(clID_VTHH2).ToString());
                _id_vthh = iiIDnhapKhp;
                LoadDataChamCongCN(iiIDnhapKhp);
            }
        }

        private void gridDinhMucGapDan_EditValueChanged(object sender, EventArgs e)
        {
            int xxxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());

            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();

            DataTable dt = cls.SA_ID_DinhMuc_ThanhPham(xxxID);
            txtTenVT_ThanhPham.Text = dt.Rows[0]["TenVTHH"].ToString();
            DVT_ThanhPham.Text = dt.Rows[0]["DonViTinh"].ToString();
            txtID_ThanhPham.Text = dt.Rows[0]["ID_VTHH"].ToString();
            cls.Dispose();
            dt.Dispose();


            clsDinhMuc_DinhMuc_ToGapDan cls2 = new clsDinhMuc_DinhMuc_ToGapDan();
            cls2.iID_DinhMuc_ToGapDan = xxxID;
            DataTable dt2 = cls2.SelectOne();
            txtDienGiaiDMNPL.Text = cls2.sDienGiai.Value;
            if (UCDaiLy_XuatKho_GapDan.mbthemmoi == true)
                txtDienGiai.Text = cls2.sDienGiai.Value;
            cls2.Dispose();
            dt2.Dispose();

            try
            {
                double soluongxuat = Convert.ToDouble(txtSoLuongTP.Text.ToString());
                HienThi_Grid_ConTrol_Themmoi(soluongxuat, xxxID);
            }
            catch
            { }

            
        }

        private void txtSoLuongTP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xxxID = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                double soluongxuat = Convert.ToDouble(txtSoLuongTP.Text.ToString());
                HienThi_Grid_ConTrol_Themmoi(soluongxuat, xxxID);
            }
            catch
            { }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == STT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    btLayDuLieu.Focus();
            //}
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                txtTenNguoiLap.Text = clsncc.sTenNhanVien.Value;
                clsncc.Dispose();
            }
            catch
            {

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double getDonGiaTheoIDVHH(int idvthh)
        {
            double result = 0;

            for (int i = 0; i < _dtDonGiatheoVTHH.Rows.Count; i++)
            {
                if (idvthh == Convert.ToInt32(_dtDonGiatheoVTHH.Rows[i]["ID_VTHH"].ToString()))
                {
                    result = CheckString.ConvertToDouble_My(_dtDonGiatheoVTHH.Rows[i]["DonGia"].ToString());
                    break;
                }
            }
            return result;
        }

        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                }
            }
            return _id_bophan;
        }

        private string getTenCN(int idcn)
        {
            string result = "";

            for (int i = 0; i < _dtCongNhan.Rows.Count; i++)
            {
                if (idcn == Convert.ToInt32(_dtCongNhan.Rows[i]["ID_NhanSu"].ToString()))
                {
                    result = _dtCongNhan.Rows[i]["TenNhanVien"].ToString();
                    break;
                }
            }
            return result;
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == ID_NhanSu)
            {
                if (e.Value == null && e.Value.ToString() == "") return;
                int id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
                int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
                double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));
                //double ngay1_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay1));
                //double ngay2_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay2));
                //double ngay3_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay3));
                //double ngay4_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay4));
                //double ngay5_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay5));
                //double ngay6_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay6));
                //double ngay7_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay7));
                //double ngay8_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay8));
                //double ngay9_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay9));
                //double ngay10_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay10));
                //double ngay11_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay11));
                //double ngay12_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay12));
                //double ngay13_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay13));
                //double ngay14_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay14));
                //double ngay15_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay15));
                //double ngay16_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay16));
                //double ngay17_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay17));
                //double ngay18_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay18));
                //double ngay19_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay19));
                //double ngay20_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay20));
                //double ngay21_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay21));
                //double ngay22_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay22));
                //double ngay23_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay23));
                //double ngay24_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay24));
                //double ngay25_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay25));
                //double ngay26_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay26));
                //double ngay27_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay27));
                //double ngay28_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay28));
                //double ngay29_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay29));
                //double ngay30_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay30));
                //double ngay31_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, Ngay31));

                string tenCN = getTenCN(id_nhansu);
                //gridView1.SetRowCellValue(e.RowHandle, ID_NhanSu, id_nhansu);
                gridView1.SetRowCellValue(e.RowHandle, TenNhanVien, tenCN);

                //
                try
                {
                    using (clsThin clsThin_ = new clsThin())
                    {
                        if (id_ChamCong == 0)
                        {
                            if (checkIDCNisTonTai(id_nhansu))
                            {
                                MessageBox.Show("Không thể thêm công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            id_nhansu,
                            dteNgayChungTu.DateTime.Day,
                            dteNgayChungTu.DateTime.Month,
                            dteNgayChungTu.DateTime.Year,
                            _id_vthh,
                            (float)sanluong_,
                            0, true, false, _id_bophan, 0, 1);
                        }
                        else
                        {
                            if (checkIDCN_Update(id_ChamCong, id_nhansu)) return;
                            else
                            {
                                if (checkIDCNisTonTai(id_nhansu))
                                {
                                    MessageBox.Show("Không thể chọn công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
                            id_nhansu,
                            dteNgayChungTu.DateTime.Day,
                            dteNgayChungTu.DateTime.Month,
                            dteNgayChungTu.DateTime.Year,
                            _id_vthh,
                            (float)sanluong_,
                            0, true, false, _id_bophan, 0, 1,
                            id_ChamCong);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCN
                        + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.Column == SanLuong)
            {
                if (e.Value != null && e.Value.ToString() != "" && !(gridView4.GetRowCellValue(e.RowHandle, ID_NhanSu) is DBNull))
                {
                    int id_nhansu;
                    try
                    {
                        id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
                    }
                    catch
                    {
                        return;
                    }

                    int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
                    double dongia = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, DonGia));
                    double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));

                    //
                    gridView1.SetRowCellValue(e.RowHandle, ThanhTien, sanluong_* dongia);

                    //
                    try
                    {
                        using (clsThin clsThin_ = new clsThin())
                        {
                            //if (!checkIDCN_Update(id_ChamCong, id_nhansu))
                            //{
                            //    if (checkIDCNisTonTai(id_nhansu))
                            //    {
                            //        MessageBox.Show("Không thể chọn công nhân " + getTenCN(id_nhansu) + ". Bởi vì " + getTenCN(id_nhansu) + " đã tồn tại trong bộ phận này!",
                            //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }
                            //}

                            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
                            id_nhansu,
                            dteNgayChungTu.DateTime.Day,
                            dteNgayChungTu.DateTime.Month,
                            dteNgayChungTu.DateTime.Year,
                            _id_vthh,
                            (float)sanluong_,
                            0, true, false, _id_bophan, 0, 1,
                            id_ChamCong);
                            //if (id_ChamCong == 0)
                            //{
                            //    if (checkIDCNisTonTai(id_nhansu))
                            //    {
                            //        MessageBox.Show("Không thể thêm công nhân " + getTenCN(id_nhansu) + ". Bởi vì " + getTenCN(id_nhansu) + " đã tồn tại trong bộ phận này!",
                            //            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }

                            //    clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            //    id_nhansu,
                            //    dteNgayChungTu.DateTime.Day,
                            //    dteNgayChungTu.DateTime.Month,
                            //    dteNgayChungTu.DateTime.Year,
                            //    _id_vthh,
                            //    (float)sanluong_,
                            //    0, true, false, _id_bophan, 0, 1);
                            //}
                            //else
                            //{
                            //    if (!checkIDCN_Update(id_ChamCong, id_nhansu))
                            //    {
                            //        if (checkIDCNisTonTai(id_nhansu))
                            //        {
                            //            MessageBox.Show("Không thể chọn công nhân " + getTenCN(id_nhansu) + ". Bởi vì " + getTenCN(id_nhansu) + " đã tồn tại trong bộ phận này!",
                            //                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //            return;
                            //        }
                            //    }

                            //    clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
                            //    id_nhansu,
                            //    dteNgayChungTu.DateTime.Day,
                            //    dteNgayChungTu.DateTime.Month,
                            //    dteNgayChungTu.DateTime.Year,
                            //    _id_vthh,
                            //    (float)sanluong_,
                            //    0, true, false, _id_bophan, 0, 1,
                            //    id_ChamCong);
                            //}
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + getTenCN(id_nhansu)
                            + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaGridv1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan) == null
                    ||gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "" 
                    || gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "0")
                {
                    return;
                }

                //int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NhanSu).ToString());
                int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa công nhân: " + gridView1.GetFocusedRowCellValue(TenNhanVien).ToString(), "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    using (clsThin clsThin_ = new clsThin())
                    {
                        if(clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(ID_ChiTietChamCong_TGD))
                        {
                            LoadDataChamCongCN(_id_vthh);
                        }
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Lỗi xóa công nhân khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["STT"], view.RowCount.ToString());
            view.SetRowCellValue(e.RowHandle, view.Columns["ID_ChiTietChamCong_ToGapDan"], 0); 
            view.SetRowCellValue(e.RowHandle, view.Columns["ID_VTHH"], _id_vthh);
            view.SetRowCellValue(e.RowHandle, view.Columns["ThanhTien"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["DonGia"], getDonGiaTheoIDVHH(_id_vthh));
            view.SetRowCellValue(e.RowHandle, view.Columns["SanLuong"], "");
            //view.SetRowCellValue(e.RowHandle, view.Columns["ID_NhanSu"], 0);

            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay1"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay2"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay3"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay4"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay5"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay6"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay7"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay8"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay9"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay10"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay11"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay12"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay13"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay14"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay15"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay16"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay17"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay18"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay19"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay20"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay21"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay22"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay23"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay24"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay25"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay26"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay27"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay28"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay29"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay30"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["Ngay31"], 0);
        }


        private void LoadDataChamCongCN(int idVTHH)
        {
            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(dteNgayChungTu.DateTime.Year, 
                        dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Day, _id_bophan, idVTHH, "");
            }

            gridControl2.DataSource = _data;
        }

        private bool SaveAllDataChamCong(DataTable _data)
        {
            bool isGuiThanhCong = false;
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        if (_data.Rows[i]["ID_CongNhan"].ToString() == "")
                            continue;

                        int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                        if (ID_CongNhan_ == 0)
                        {
                            continue;
                        }


                        string Cong_ = _data.Rows[i]["Cong"].ToString();
                        bool isTang = false;
                        if (Cong_.Contains("Tăng"))
                        {
                            isTang = true;
                        }
                        clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            ID_CongNhan_,
                            dteNgayChungTu.DateTime.Month,
                            dteNgayChungTu.DateTime.Year,
                            Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString()),
                            0,
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
                            0, true, isTang, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));

                        isGuiThanhCong = true;
                    }
                    if (isGuiThanhCong)
                    {
                        LoadDataChamCongCN(1);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu bảng chấm công. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isGuiThanhCong;
        }

        private void SaveOneCN(DataTable _data, int idcn_, double sanluong_)
        {
            string tenCongNhan_ = "";

            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                        if (ID_CongNhan_ == idcn_)
                        {
                            int ngay = dteNgayChungTu.DateTime.Day;
                            _data.Rows[i]["Ngay" + ngay] = String.Format("{0:0.##}", sanluong_);

                            tenCongNhan_ = _data.Rows[i]["TenNhanVien"].ToString();
                            string Cong_ = _data.Rows[i]["Cong"].ToString();
                            bool isTang = false;
                            if (Cong_.Contains("Tăng"))
                            {
                                isTang = true;
                            }
                            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                                ID_CongNhan_,
                                dteNgayChungTu.DateTime.Month,
                                dteNgayChungTu.DateTime.Year,
                                Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString()),
                                0,
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
                                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
                                0, true, isTang, _id_bophan,
                                Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                                Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCongNhan_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOneCN_Datarow(DataRow dt_row)
        {
            string tenCongNhan_ = "";

            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    int ID_CongNhan_ = Convert.ToInt32(dt_row["ID_CongNhan"].ToString());
                    tenCongNhan_ = dt_row["TenNhanVien"].ToString();
                    string Cong_ = dt_row["Cong"].ToString();
                    bool isTang = false;
                    if (Cong_.Contains("Tăng"))
                    {
                        isTang = true;
                    }
                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                        ID_CongNhan_,
                        dteNgayChungTu.DateTime.Month,
                        dteNgayChungTu.DateTime.Year,
                        Convert.ToInt32(dt_row["ID_VTHH"].ToString()),
                        0,
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay1"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay2"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay3"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay4"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay5"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay6"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay7"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay8"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay9"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay10"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay11"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay12"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay13"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay14"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay15"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay16"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay17"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay18"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay19"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay20"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay21"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay22"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay23"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay24"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay25"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay26"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay27"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay28"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay29"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay30"].ToString()),
                        (float)CheckString.ConvertToDouble_My(dt_row["Ngay31"].ToString()),
                        0, true, isTang, _id_bophan,
                        Convert.ToInt32(dt_row["ID_DinhMucLuong_CongNhat"].ToString()),
                        Convert.ToInt32(dt_row["ID_LoaiCong"].ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCongNhan_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkIDCNisTonTai(int idcn)
        {
            bool result = false;


            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt3 = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(dteNgayChungTu.DateTime.Year,
                        dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Day, _id_bophan, _id_vthh, "");

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (idcn == Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private bool checkIDCN_Update(int ID_ChamCong, int idcn)
        {
            bool result = false;

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt3 = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(dteNgayChungTu.DateTime.Year,
                        dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Day, _id_bophan, _id_vthh, "");

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (ID_ChamCong == Convert.ToInt32(dt3.Rows[i]["ID_ChiTietChamCong_ToGapDan"].ToString()) && idcn == Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

    }
}
