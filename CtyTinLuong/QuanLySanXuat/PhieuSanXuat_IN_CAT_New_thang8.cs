using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class PhieuSanXuat_IN_CAT_New_thang8 : Form
    {
        int iMacDinh_Luong = 0;
        int iMacDinh_CaTruong = 0;
        string sMacDinh_CaSX = "";
        DateTime daNgayMacdinh = DateTime.Now;
        private int _SoTrang = 1;
        private int _SoDong = 25;
        private int _Loaimay = 1;
        private bool isload = false;

        string sTenVTHH_vao, sDonViTinh_vao;
        string sTenVTHH_ra, sDonViTinh_ra;
        double sanluongthuong_ = 0, sanluongtangca_ = 0;
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay, int xxid_loaiMay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            _SoDong = sodong;
            DataTable dt2 = new DataTable();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            if (xxid_loaiMay == 1)
                dt2 = cls.H_load_Phieu_T8_ngaythang_IN(sotrang, _SoDong, xxtungay, xxdenngay);
            else if (xxid_loaiMay ==2)
                dt2 = cls.H_load_Phieu_T8_ngaythang_CAT(sotrang, _SoDong, xxtungay, xxdenngay);
            else if (xxid_loaiMay == 3)
                dt2 = cls.H_load_Phieu_T8_ngaythang_DOT(sotrang, _SoDong, xxtungay, xxdenngay);
            gridControl1.DataSource = dt2;

            isload = false;
        }
        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            int sodong_ = 25;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                sodong_ = Convert.ToInt32(txtSoDong.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";

                sodong_ = 1;
                txtSoDong.Text = "25";
            }
            int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
            LoadData(sotrang_, sodong_, true, dteTuNgay.DateTime, dteDenNgay.DateTime, xxid);
        }
        public void ResetSoTrang(int xxsodong,DateTime xxtungay, DateTime xxdenngay, int xxid_loaiMay)
        {

            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            //txtSoTrang.Text = "1";

            using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
            {
                DataTable dt_ = new DataTable();
                if (xxid_loaiMay == 1)
                    dt_ = cls.H_Tinh_SoPhieu_T8_IN(xxtungay, xxdenngay);
                else if (xxid_loaiMay == 2)
                    dt_ = cls.H_Tinh_SoPhieu_T8_CAT(xxtungay, xxdenngay);
                else if (xxid_loaiMay == 3)
                    dt_ = cls.H_Tinh_SoPhieu_T8_DOT(xxtungay, xxdenngay);
              
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)xxsodong)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        private void Load_LockUp(int iiID_loaimay)
        {
            
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataSet dtset = cls.H_LockUp_PhieuSanXuat_thang8();                   

            gridMaVT_Vao.DataSource = dtset.Tables[4];
            gridMaVT_Vao.ValueMember = "ID_VTHH";
            gridMaVT_Vao.DisplayMember = "MaVT";

            gridMaVT_Ra.DataSource = dtset.Tables[4];
            gridMaVT_Ra.ValueMember = "ID_VTHH";
            gridMaVT_Ra.DisplayMember = "MaVT";


            gridDMLuong.DataSource = dtset.Tables[8];
            gridDMLuong.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            gridDMLuong.DisplayMember = "MaDinhMuc";

            gridCaTruong.DataSource = dtset.Tables[0];
            gridCaTruong.ValueMember = "ID_NhanSu";
            gridCaTruong.DisplayMember = "MaNhanVien";

            cbCaTruongMacDinh.DataSource= dtset.Tables[0];
            cbCaTruongMacDinh.ValueMember = "ID_NhanSu";
            cbCaTruongMacDinh.DisplayMember = "TenNhanVien";

            cbDinhMucMacDinh.DataSource = dtset.Tables[8];
            cbDinhMucMacDinh.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            cbDinhMucMacDinh.DisplayMember = "MaDinhMuc";

            if (iiID_loaimay==1) // máy in
            {
                gridCongNhan.DataSource = dtset.Tables[1];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";               

                gridMaMay.DataSource = dtset.Tables[5];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }

            if (iiID_loaimay == 2) // máy cắt
            {
                gridCongNhan.DataSource = dtset.Tables[2];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";

            
                gridMaMay.DataSource = dtset.Tables[6];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }
            if (iiID_loaimay == 3) // máy đột
            {
                gridCongNhan.DataSource = dtset.Tables[3];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";

                gridMaMay.DataSource = dtset.Tables[7];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }

            cls.Dispose();
        }

        private void Tinh_SanLuong(double sanluongtong, int iiID_DinhmucLuong, int iiID_CongNhan, int iiID_VTHH_Ra__, DateTime ngaysanxuat__, string casanxxutaxx_)
        {           
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls1 = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            cls1.iID_DinhMuc_Luong_SanLuong = iiID_DinhmucLuong;
            DataTable dt2222 = cls1.SelectOne();
            double maxSanluongDinhMuc = cls1.fMaxSanLuongThuong.Value;

            clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
            clsncc.iID_NhanSu = iiID_CongNhan;
            DataTable dt = clsncc.SelectOne();
           
            clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();       
                    
            DataTable dtin = cls2.H_PhieuX_SUM_TinhSanLuong_Thang8(iiID_CongNhan, ngaysanxuat__, casanxxutaxx_, iiID_VTHH_Ra__);
            double SanluongHienCo = Convert.ToDouble(dtin.Rows[0]["SanLuong_Thuong"].ToString());
          
          
            if (maxSanluongDinhMuc == 0)
            {
                sanluongthuong_ = sanluongtong;
                sanluongtangca_ = 0;
            }
            else
            {
                if (SanluongHienCo >= maxSanluongDinhMuc)
                {
                    sanluongthuong_ = 0;
                    sanluongtangca_ = sanluongtong;
                }
                else
                {
                    double TongSanLuongMoi = SanluongHienCo + sanluongtong;
                    if (TongSanLuongMoi <= maxSanluongDinhMuc)
                    {
                        sanluongtangca_ = 0;
                        sanluongthuong_ = sanluongtong;
                    }
                    else
                    {
                        sanluongtangca_ = TongSanLuongMoi - maxSanluongDinhMuc;
                        sanluongthuong_ = maxSanluongDinhMuc - SanluongHienCo;
                    }
                }
            }
        }

        private bool KiemTra_TrungMaPhieu(string xsmaphieu, DateTime ngaykethuc)
        {
            DateTime ngaybatdau;
            DataTable dt = new DataTable();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();            
            ngaybatdau = ngaykethuc.AddDays(-30);
            dt = cls.H_KiemTra_Trung_Phieu_SX_T8(xsmaphieu, ngaybatdau, ngaykethuc);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đã có Mã phiếu: " + xsmaphieu + "\nVui lòng thử lại", "Kiểm tra");
                return false;
            }
            else return true;
        }
        private bool KiemTraLuu_In_CAT()
        {
            int xID_CaTruong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong).ToString());
            string sMaphieu___ = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
            int xIDmay= CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_May).ToString());
            int xID_CongNhan= CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());           
            int xID_DinhMuc_Luong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong).ToString());
            int xID_VTHH_Vao = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao).ToString());
            int xID_VTHH_Ra = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra).ToString());
            string sSoLuong_Vao = bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao).ToString();
            string sSanLuong_Thuong = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Thuong).ToString();
            string sSanLuong_TangCa = bandedGridView1.GetFocusedRowCellValue(clSanLuong_TangCa).ToString();
            string sngaysanxuat = bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat).ToString();
            string scasaanxuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat).ToString();
            if (xID_CaTruong==0||xIDmay == 0|| xID_CongNhan==0|| xID_DinhMuc_Luong==0|| xID_VTHH_Vao==0|| xID_VTHH_Ra==0) 
            {
                return false;
            }
            else if (sMaphieu___ == "" || sSoLuong_Vao == "" || sSanLuong_Thuong == "" || sSanLuong_TangCa == "" || sngaysanxuat == "" || scasaanxuat == "")
            {
                return false;
            }
           else return true;

        }
        private void Luu_ThemMoi_DuLieu_IN_CAT(bool themmoi)
        {
            if (!KiemTraLuu_In_CAT()) return;
            else
            {
                clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();
                cls1.sMaPhieu = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                cls1.daNgayLapPhieu = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat).ToString());
                cls1.sCaSanXuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat).ToString();
                cls1.iID_CaTruong = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong).ToString());
                cls1.sGhiChu = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bGuiDuLieu = false;
                cls1.bCheck_In = false;
                cls1.bCheck_Cat = false;
                cls1.bCheck_Dot = false;
                cls1.iBienTrangThai = 0;
                cls1.bDaKetThuc = false;
                if(themmoi==true)
                {
                    cls1.Insert();

                }
                else
                {
                    cls1.Update();
                }
                int xxID_Sophieu_ = cls1.iID_SoPhieu.Value;
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
              
                cls.iID_SoPhieu = xxID_Sophieu_;
                cls.iID_May = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_May).ToString());
                cls.iID_CongNhan = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                cls.iID_CaTruong = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong).ToString());
                cls.daNgaySanXuat = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat).ToString());
                cls.sGhiChu = "";
                cls.sCaSanXuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat).ToString();
                cls.iID_DinhMuc_Luong = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong).ToString());
                cls.iID_VTHH_Vao = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao).ToString());
                cls.fSoLuong_Vao = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao).ToString());
                cls.fDonGia_Vao = 0;
                cls.iID_VTHH_Ra = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra).ToString());
                cls.fSanLuong_Thuong = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Thuong).ToString());
                cls.fSanLuong_TangCa = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSanLuong_TangCa).ToString());
                cls.fSanLuong_Tong = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong).ToString());
                cls.fDonGia_Xuat = 0;
                cls.fPhePham = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao).ToString());
                if(Convert.ToInt32(gridLoaiMay.EditValue.ToString())==1)
                {
                    cls.bBMay_IN = true;
                    cls.bBMay_CAT = false;
                    cls.bBMay_DOT = false;
                }
                else if (Convert.ToInt32(gridLoaiMay.EditValue.ToString()) == 2)
                {
                    cls.bBMay_IN = false;
                    cls.bBMay_CAT = true;
                    cls.bBMay_DOT = false;
                }
                else if (Convert.ToInt32(gridLoaiMay.EditValue.ToString()) == 3)
                {
                    cls.bBMay_IN = false;
                    cls.bBMay_CAT = false;
                    cls.bBMay_DOT = true;
                }
              
                cls.bTrangThaiXuatNhap = false;
                cls.bGuiDuLieu = true;
                cls.bTrangThaiTaoLenhSanXuat = false;
                cls.fSoKG_MotBao_May_Dot = 0;
                cls.fDoCao_Dot = 0;
                if (themmoi == true)
                {
                    cls.Insert();

                }
                else
                {
                    cls.Update();
                }
                int iiiDID_ChiTietPhieuxxx;               
                iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                TaoLenhSanXuat(xxID_Sophieu_, iiiDID_ChiTietPhieuxxx);
            }
        }
        private void TaoLenhSanXuat(int xxIDSoPhieu, int iiiDID_ChiTietPhieu)
        {
            //clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            //if (cbCaSanXuat_May_IN.Text.ToString() != "" & dteNgaySanXuat_May_IN.Text.ToString() != "")
            //{

            //    int ID_May = Convert.ToInt32(gridMaMay_IN.EditValue.ToString());
            //    int ID_CongNhan = Convert.ToInt32(gridMaCongNhan_May_IN.EditValue.ToString());
            //    int ID_CaTruong = Convert.ToInt32(gridMaCaTruong_May_IN.EditValue.ToString());
            //    DateTime NgaySanXuat = Convert.ToDateTime(dteNgaySanXuat_May_IN.EditValue.ToString());
            //    string CaSanXuat = cbCaSanXuat_May_IN.Text.ToString();

            //    int ID_VTHH_Vao = Convert.ToInt32(gridHangHoaVao_may_IN.EditValue.ToString());
            //    double SoLuong_Vao = CheckString.ConvertToDouble_My(txtSoLuongNhap_May_IN.Text.ToString());
            //    double DonGia_Vao = CheckString.ConvertToDouble_My(txtDonGiaNhap_May_IN.Text.ToString());
            //    int ID_VTHH_Ra = Convert.ToInt32(gridHangHoaXuat_May_IN.EditValue.ToString());
            //    double SanLuong_Thuong = CheckString.ConvertToDouble_My(txtSanLuong_Thuong_may_IN.Text.ToString());
            //    double SanLuong_TangCa = CheckString.ConvertToDouble_My(txtSanLuong_tangca_May_IN.Text.ToString());
            //    double SanLuong_Tong = CheckString.ConvertToDouble_My(txtSanLuongTong_May_IN.Text.ToString());
            //    double DonGia_Xuat = CheckString.ConvertToDouble_My(txtDonGiaXuat_May_IN.Text.ToString());
            //    double PhePham = CheckString.ConvertToDouble_My(txtPhePham_May_IN.Text.ToString());

            //    clsHUU_LenhSanXuat clsLSX = new clsHUU_LenhSanXuat();
            //    clsLSX.iID_CaTruong = ID_CaTruong;
            //    clsLSX.iID_LoaiMay = 1;
            //    clsLSX.iID_CongNhan = ID_CongNhan;
            //    clsLSX.daNgayThangSanXuat = NgaySanXuat;
            //    clsLSX.sCaSanXuat = CaSanXuat;
            //    DataTable dxLSX1 = clsLSX.SelectAll_TaoLenhSX_May_CaTruong_CongNhan_Ngay_CaSX_May_IN();
            //    int ID_LenhSanXuatxx;
            //    if (dxLSX1.Rows.Count > 0)
            //    {
            //        ID_LenhSanXuatxx = Convert.ToInt32(dxLSX1.Rows[0]["ID_LenhSanXuat"].ToString());

            //    }
            //    else
            //    {
            //        clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
            //        DataTable xxdt1 = cls1.SelectAll();
            //        xxdt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            //        DataView xxxdv = xxdt1.DefaultView;
            //        DataTable xxxdv3 = xxxdv.ToTable();
            //        int k = xxxdv3.Rows.Count;
            //        string MaLenhSanXuat;
            //        if (xxxdv3.Rows.Count == 0)
            //            MaLenhSanXuat = "LSX1";
            //        else
            //        {
            //            string xxx = xxxdv3.Rows[k - 1]["MaLenhSanXuat"].ToString();
            //            int xxx2 = Convert.ToInt16(xxx.Substring(3).Trim()) + 1;
            //            MaLenhSanXuat = "LSX" + xxx2 + "";
            //        }

            //        // them moi lenh SX 
            //        clsLSX.iID_CaTruong = ID_CaTruong;
            //        clsLSX.iID_LoaiMay = 1;
            //        clsLSX.iID_CongNhan = ID_CongNhan;
            //        clsLSX.iID_NguoiLap = 12;
            //        clsLSX.daNgayThangSanXuat = NgaySanXuat;
            //        clsLSX.sCaSanXuat = CaSanXuat;
            //        clsLSX.sGhiChu = "";
            //        clsLSX.bTonTai = true;
            //        clsLSX.bNgungTheoDoi = false;
            //        clsLSX.sMaLenhSanXuat = MaLenhSanXuat;
            //        clsLSX.bGuiDuLieu = false;
            //        clsLSX.bBoolMayIn = true;
            //        clsLSX.bBoolMayCat = false;
            //        clsLSX.bBoolMayDot = false;
            //        clsLSX.bTrangThai_NhapKho_May_IN = false;
            //        clsLSX.bTrangThai_XuatKho_May_IN = false;
            //        clsLSX.bTrangThai_NhapKho_May_CAT = false;
            //        clsLSX.bTrangThai_XuatKho_May_CAT = false;
            //        clsLSX.bTrangThai_NhapKho_May_DOT = false;
            //        clsLSX.bTrangThai_XuatKho_May_DOT = false;
            //        clsLSX.Insert();
            //        ID_LenhSanXuatxx = clsLSX.iID_LenhSanXuat.Value;

            //    }
            //    //LuuChiTietLenhSanXuat_IN(xxIDSoPhieu, iiiDID_ChiTietPhieu, ID_LenhSanXuatxx);

            //    cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
            //    cls.Update_TrangThaiTaoLenhSanXuat();
                
            //}


        }
        public PhieuSanXuat_IN_CAT_New_thang8()
        {
            InitializeComponent();
        }

      
        private void PhieuSanXuat_IN_CAT_New_thang8_Load(object sender, EventArgs e)
        {
            dteNgayMacDinh.DateTime= DateTime.Today;
            clSanLuong_Tong.Caption = "Sản\nlượng";
            clID_DinhMuc_Luong.Caption = "ĐM\nlương";
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("loaimay", typeof(String));
            DataRow row1 = dt.NewRow();
            row1["id"] = 1;
            row1["loaimay"] = "Máy In";
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["id"] = 2;
            row2["loaimay"] = "Máy Cắt";
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["id"] = 3;
            row3["loaimay"] = "Máy Đột";
            dt.Rows.Add(row3);

            gridLoaiMay.Properties.DataSource = dt;
            gridLoaiMay.Properties.ValueMember = "id";
            gridLoaiMay.Properties.DisplayMember = "loaimay";

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id", typeof(int));
            dt2.Columns.Add("Ca", typeof(String));
            DataRow _row1 = dt2.NewRow();
            _row1["id"] = 1;
            _row1["Ca"] = "Ca 1";
            dt2.Rows.Add(_row1);

            DataRow _row2 = dt2.NewRow();
            _row2["id"] = 2;
            _row2["Ca"] = "Ca 2";
            dt2.Rows.Add(_row2);

            cbCaSXMacDinh.DataSource = dt2;
            cbCaSXMacDinh.ValueMember = "id";
            cbCaSXMacDinh.DisplayMember = "Ca";
            cbCaSXMacDinh.SelectedIndex = 1;
            gridLoaiMay.EditValue = 1;

            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = DateTime.Today.AddDays(-7);

            _Loaimay = 1;
         
         
           // ResetSoTrang(_SoDong,dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
            Load_LockUp(_Loaimay);
            //LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_PhieuSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtSoTrang_Leave(object sender, EventArgs e)
        {
          
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
           
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridLoaiMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _Loaimay = Convert.ToInt32(gridLoaiMay.EditValue);
                Load_LockUp(_Loaimay);
                txtSoTrang.Text = "1";
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            _SoDong = Convert.ToInt32(txtSoDong.Text);

            ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
            LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
        }
        
        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clMaPhieu)
                {
                    if (bandedGridView1.GetRowCellValue(e.RowHandle, clNgaySanXuat).ToString() != "")
                    {
                        string smaphieu = bandedGridView1.GetRowCellValue(e.RowHandle, clMaPhieu).ToString();
                        DateTime ngaysanxuat = Convert.ToDateTime(bandedGridView1.GetRowCellValue(e.RowHandle, clNgaySanXuat).ToString());
                        if (KiemTra_TrungMaPhieu(smaphieu, ngaysanxuat) == false)
                        {
                            bandedGridView1.SetRowCellValue(e.RowHandle, clMaPhieu, "");
                            return;
                        }
                    }
                }
                if (e.Column == clID_VTHH_Vao)
                {
                    bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao, sTenVTHH_vao);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao, sDonViTinh_vao);
                }

                if (e.Column == clID_VTHH_Ra)
                {
                    bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra, sTenVTHH_ra);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra, sDonViTinh_ra);
                }            

                if (e.Column == clSanLuong_Tong)
                {
                    double xsanluongtong = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong).ToString());
                    int xiD_dinhMucluong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong).ToString());
                    int xidcongnhan = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                    int xidvthhra = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra).ToString());
                    DateTime xngaysanxuat = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat).ToString());
                    string xcasanxuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat).ToString();

                    Tinh_SanLuong(xsanluongtong, xiD_dinhMucluong, xidcongnhan, xidvthhra, xngaysanxuat, xcasanxuat);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_Thuong, sanluongthuong_);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_TangCa, sanluongtangca_);
                }

            }
            catch
            { }

        }

        private void bandedGridView1_ClipboardRowPasting(object sender, DevExpress.XtraGrid.Views.Grid.ClipboardRowPastingEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridColumn column = view.Columns["Department"];

            //string pastedString = e.Values[column].ToString();
            //string newString = pastedString.Replace('_', ' ');
            //string newCapitalizedString = Regex.Replace(newString, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            //e.Values[column] = newCapitalizedString;
        }

       

        private void bandedGridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            bandedGridView1.SetRowCellValue(e.RowHandle, clNgaySanXuat, daNgayMacdinh);
            bandedGridView1.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong, iMacDinh_Luong);
            bandedGridView1.SetRowCellValue(e.RowHandle, clID_CaTruong, iMacDinh_CaTruong);
            bandedGridView1.SetRowCellValue(e.RowHandle, clCaSanXuat, sMacDinh_CaSX);
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sMacDinh_CaSX = cbCaSXMacDinh.Text;
            }
            catch
            { }
           
        }

        private void cbCaTruongMacDinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                iMacDinh_CaTruong = (int)cbCaTruongMacDinh.SelectedValue;
            }
            catch
            { }
            
        }

        private void cbDinhMucMacDinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                iMacDinh_Luong = (int)cbDinhMucMacDinh.SelectedValue;
            }
            catch
            { }
            
        }

        private void dteNgayMacDinh_EditValueChanged(object sender, EventArgs e)
        {
            daNgayMacdinh = dteNgayMacDinh.DateTime;
        }

        private void bandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (KiemTraLuu_In_CAT() == false)
                return;
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }

        private void gridMaVT_Ra_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;                
                sTenVTHH_ra = row["TenVTHH"].ToString();
                sDonViTinh_ra = row["DonViTinh"].ToString();
            }
            catch
            { }
            
        }

        private void gridMaVT_Vao_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;               
                sTenVTHH_vao = row["TenVTHH"].ToString();
                sDonViTinh_vao = row["DonViTinh"].ToString();
               
            }
            catch
            { }
           
        }
    }
}
