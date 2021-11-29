using DevExpress.XtraEditors;
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
    public partial class KhoThanhPham_XuatKho_DongKien : Form
    {
        private int id_vthh;
        private string tenvthh, donvitinhvthh, _Nguon;

        public KhoThanhPham_XuatKho_DongKien()
        {
            InitializeComponent();
        }

        private void Hienthi_Lable_TonKho(int xxID_VTHH, double soluongxuat_moi)
        {

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();

            clsDongKien_TbNhapKho_ChiTietNhapKho cls1 = new CtyTinLuong.clsDongKien_TbNhapKho_ChiTietNhapKho();
            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_xuatTruoc = new DataTable();

            dt_NhapTruoc = cls1.H_DK_SA_NhapTruocKy_ID_VTHH(DateTime.Today, xxID_VTHH);
            dt_xuatTruoc = cls2.H_DK_SA_XuatTruocKy_ID_VTHH(DateTime.Today, xxID_VTHH);
            double soluongxuat_cu;
            if (dt_xuatTruoc.Rows.Count>0)
                soluongxuat_cu = Convert.ToDouble(dt_xuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
            else soluongxuat_cu = 0;
            double soluongnhap = 0;
            if (dt_NhapTruoc.Rows.Count > 0)
                soluongnhap = Convert.ToDouble(dt_NhapTruoc.Rows[0]["SoLuong_NhapTruocKy"].ToString());
            else
                soluongnhap = 0;

            double soluongton = soluongnhap - soluongxuat_moi- soluongxuat_cu;
            if (soluongton < 0)
                MessageBox.Show("" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "");
            //label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";


        }
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
                sochungtu = "NKTP 1";
            }
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;               
                sochungtu = "NKTP " + xxx2 + "";

            }

            return sochungtu;
        }

        private string Load_soChungTu_XuatKhoDongKien()
        {
            string sochungtu = "";
            clsDongKien_TbXuatKho cls3 = new clsDongKien_TbXuatKho();
            DataTable dt1 = cls3.SelectAll();           
            int k = dt1.Rows.Count;
            if (k == 0)
            {
                sochungtu = "XKDK 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "XKDK " + xxx2 + "";
            }

            return sochungtu;
        }
        private void HienThi_ThemMoi_XuatKho()
        {
            mbthemmoi_ = true;
            mbtrangthainhapkhothanhpham = false;

            gridNguoiLap.EditValue = 15;           
            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = Load_soChungTu_XuatKhoDongKien();
            txtThamChieu.Text = Load_soChungTu_KhoThanhPham();            
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietXuatKho", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));          
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongXuat", typeof(double));          
            dt2.Columns.Add("DonGia", typeof(double));          
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));


            gridControl1.DataSource = dt2;
        }
        private void HienThi_Sua_XuatKho(int xxid_Xuatkho_)
        {
            mbthemmoi_ = false;
       
            clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            cls1.iID_XuatKhoDongKien = xxid_Xuatkho_;
            DataTable dt = cls1.SelectOne();          
            if (cls1.bNhapThanhPham_True == true)
            {
                //btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
            mbtrangthainhapkhothanhpham = cls1.bNhapThanhPham_True.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;            
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;

            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt2 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_Xuatkho_);
            gridControl1.DataSource = dt2;

        }
        private void HienThi_Copy_XuatKho(int xxid_Xuatkho_)
        {
            mbthemmoi_ = true;
            clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            cls1.iID_XuatKhoDongKien = xxid_Xuatkho_;
            DataTable dt = cls1.SelectOne();
            mbtrangthainhapkhothanhpham = false;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = Load_soChungTu_XuatKhoDongKien();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtThamChieu.Text = Load_soChungTu_KhoThanhPham();
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;

            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt2 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_Xuatkho_);
            gridControl1.DataSource = dt2;

        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();        

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            

            clsDongKien_TbNhapKho_ChiTietNhapKho cls = new clsDongKien_TbNhapKho_ChiTietNhapKho();
            DataTable dt = cls.H_DongKien_S_D_IDVTHH_XKDK();      
            Search_MaVT.DataSource = dt;
            Search_MaVT.ValueMember = "ID_VTHH";
            Search_MaVT.DisplayMember = "MaVT";

            //Thay caption:
            Search_MaVT.View.Columns.Clear();//xóa caption cũ
            Search_MaVT.View.Columns.AddVisible("MaVT", "Mã");
            Search_MaVT.View.Columns.AddVisible("TenVTHH", "Tên");
            Search_MaVT.View.Columns.AddVisible("DonViTinh", "ĐVT");
            Search_MaVT.View.Columns.AddVisible("Nguon", "Nguồn");
        }

        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();           
            if (gridControl1.DataSource != null)
            {                
                dv3 = (DataTable)gridControl1.DataSource;
               
            }            
            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }                       

            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                dteNgayChungTu.Focus();
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
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }

        private void Luu_ChiTiet_XuatKho_dongKien(int xxid_xuatkho)
        {
            clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            DataTable dt2_cu = new DataTable();         

            dt2_cu = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_xuatkho);
            if (dt2_cu.Rows.Count > 0)
            {
                cls2.H_DongKien_CT_XK_U_TonTai(xxid_xuatkho, false);
            }
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dttttt2.Rows.Count; i++)
            {
                cls2.iID_XuatKho_DongKien = xxid_xuatkho;               
                int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                cls2.fSoLuongXuat = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuongXuat"].ToString());
                if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["DonGia"].ToString());
                cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                cls2.fThanhTien= CheckString.ConvertToDouble_My(dttttt2.Rows[i]["ThanhTien"].ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaXuatKho = true;

                if (dttttt2.Rows[i]["GhiChu"].ToString() == "Đại lý")
                    cls2.iGapDan_1_DaiLy_2 = 2;
                else if (dttttt2.Rows[i]["GhiChu"].ToString() == "Gấp dán")
                    cls2.iGapDan_1_DaiLy_2 = 1;
                else
                    cls2.iGapDan_1_DaiLy_2 = 0;
                               
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
            dt2_moi11111 = cls2.H_DongKien_ChiTiet_XK_SA_IDXK(xxid_xuatkho);
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietXuatKho_xxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                cls2.iID_ChiTietXuatKho = ID_ChiTietXuatKho_xxxx;
                cls2.Delete();
            }


        }
        bool mbtrangthainhapkhothanhpham; bool mbthemmoi_;
        private void Luu_XuatKho_DongKien(int id_xuatkho_)
        {
            clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
            cls1.daNgayChungTu = dteNgayChungTu.DateTime;
            cls1.sDienGiai = txtDienGiai.Text;
            cls1.sSoChungTu = txtSoChungTu.Text;
            cls1.sNguoiGiaoHang = txtNguoiGiaohang.Text;
            cls1.sThamChieu = txtThamChieu.Text;
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            cls1.bNhapThanhPham_True = mbtrangthainhapkhothanhpham;
            if (mbthemmoi_ == true)
                cls1.Insert();
            else
            {
                cls1.iID_XuatKhoDongKien = id_xuatkho_;
                cls1.Update();
            }
            int iiid___ = cls1.iID_XuatKhoDongKien.Value;
            Luu_ChiTiet_XuatKho_dongKien(iiid___);
        }

        private void Luu_NhapKhoThanhPham()
        {

            if (!KiemTraLuu()) return;
            else
            {

               

                double dexxTongtienhang;
                DataTable dtaaaaa = (DataTable)gridControl1.DataSource;
              
                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = CheckString.ConvertToDouble_My(xxtongtienhang);
                else dexxTongtienhang = 0;

                Load_soChungTu_KhoThanhPham();
                clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = Load_soChungTu_KhoThanhPham();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = dexxTongtienhang;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();
                cls3.iID_DaiLy = 0;
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.iInt_Dongkien_1_GapDan_2_DaiLy_3_Khac_4_ConLai_0 = 3;
                cls3.sGhiChu = txtGhiChu.Text.ToString();
                cls3.sNguoiGiaoHang = txtNguoiGiaohang.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkhothanhpham = cls3.iID_NhapKho_ThanhPham.Value;
                clsKhoThanhPham_tbChiTietNhapKho cls5 = new clsKhoThanhPham_tbChiTietNhapKho();
                for (int i = 0; i < dtaaaaa.Rows.Count; i++)
                {
                    cls5.iID_NhapKho_ThanhPham = iiDI_nhapkhothanhpham;
                    cls5.iID_VTHH = Convert.ToInt32(dtaaaaa.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = CheckString.ConvertToDouble_My(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fSoLuongTon = CheckString.ConvertToDouble_My(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fDonGia = CheckString.ConvertToDouble_My(dtaaaaa.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;
                    cls5.iID_DaiLy = 0;
                    cls5.bDaNhapKho = true;
                    cls5.bBool_TonDauKy = false;
                    cls5.sGhiChu = dtaaaaa.Rows[i]["GhiChu"].ToString();
                    cls5.Insert();
                }


            }
        }
        private void Luu_ChiLuu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    Luu_XuatKho_DongKien(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
                    MessageBox.Show("Đã lưu", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Luu_Va_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    mbtrangthainhapkhothanhpham = true;
                    Luu_XuatKho_DongKien(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
                    Luu_NhapKhoThanhPham();
                    MessageBox.Show("Đã lưu và gửi dữ liệu");
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void KhoThanhPham_XuatKho_DongKien_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            if (UCThanhPham_NhapKho_DongKien.mbThemMoi == true)
                HienThi_ThemMoi_XuatKho();
            else if (UCThanhPham_NhapKho_DongKien.mbSua == true)
                HienThi_Sua_XuatKho(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
            else HienThi_Copy_XuatKho(UCThanhPham_NhapKho_DongKien.miID_NhapKho);
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

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_VTHH)
            {
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, tenvthh);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, donvitinhvthh);
                gridView4.SetRowCellValue(e.RowHandle, Nguon, _Nguon);
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongXuat, "1");
                gridView4.SetRowCellValue(e.RowHandle, clDonGia, "0");
                gridView4.SetRowCellValue(e.RowHandle, clThanhTien, "0");
            }
            //try
            //{
                if (e.Column == clSoLuongXuat)
                {
                    int xid = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH).ToString());
                    double soluongxid = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clSoLuongXuat).ToString());
                    Hienthi_Lable_TonKho(xid, soluongxid);
                }
            //}
            //catch
            //{

            //}
            
        }


        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.DeleteRow(gridView4.FocusedRowHandle);
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_ChiLuu();
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Luu_Va_GuiDuLieu();
        }

        private void Search_MaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                id_vthh = Convert.ToInt32(row["ID_VTHH"].ToString());
                tenvthh = row["TenVTHH"].ToString();
                donvitinhvthh = row["DonViTinh"].ToString();
                _Nguon = row["Nguon"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
