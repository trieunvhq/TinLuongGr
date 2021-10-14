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
            DataTable dt1 = cls1.SA_ID_XuatKho(iiID_xuatkho_);
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
          
            DataTable dt1 = cls1.SA_ID_XuatKho(iiID_xuatkho_);
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

            DataTable dt3 = clsNguoi.T_SelectAll(18);
            gridCongNhan.DataSource = dt3;
            gridCongNhan.ValueMember = "ID_NhanSu";
            gridCongNhan.DisplayMember = "TenNhanVien";

            dt.Dispose();
            dt2.Dispose();
            cls.Dispose();
            clsNguoi.Dispose();

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            DataTable dtvt = clsvt.SelectAll();
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
        }
        private void DaiLy_FrmChiTiet_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            Load_LockUp();
            if (UCDaiLy_XuatKho_GapDan.mbthemmoi == true)
                HienThiThemMoi();
            else if (UCDaiLy_XuatKho_GapDan.mbcopy == true)
                HienThi_Copy(UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan);
            else if (UCDaiLy_XuatKho_GapDan.mbsua == true)
                HienThi_Sua_XuatKho(UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan);
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
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView3.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView3.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {

                    gridView3.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView3.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView3.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView3.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView3.SetRowCellValue(e.RowHandle, clDonGia2, 0);


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
            //if (gridView3.GetFocusedRowCellValue(clID_VTHH2) != null)
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH2).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
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

        
    }
}
