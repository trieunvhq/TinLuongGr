﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
        public static int miID_SoPhieu;
        int iMacDinh_Luong = 0;
        int iMacDinh_CaTruong = 0;
        string sMacDinh_CaSX = "";
        DateTime daNgayMacdinh = DateTime.Now;
        private int _SoTrang = 1;
        private int _SoDong;
        private int _Loaimay = 1;
        private bool isload = false;

        string sTenVTHH_vao, sDonViTinh_vao;
        string sTenVTHH_ra, sDonViTinh_ra;
        double sanluongthuong_ = 0, sanluongtangca_ = 0;
        DataTable dt_Change_;
        private bool KiemTra_Change()
        {
            dt_Change_ = new DataTable();
            DataTable dt2 = (DataTable)gridControl1.DataSource;
            DataTable dt = dt2.Copy();
            dt.DefaultView.RowFilter = "Change='1'";
            DataView dv = dt.DefaultView;
            dt_Change_ = dv.ToTable();
            if (dt_Change_.Rows.Count > 0)
            {
                return true;
            }
            else return false;

        }
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            _SoDong = sodong;
            DataTable dt2 = new DataTable();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

            dt2 = cls.H_load_Phieu_ngaythang_T8(sotrang, _SoDong, xxtungay, xxdenngay);

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
            
            LoadData(sotrang_, sodong_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(int xxsodong,DateTime xxtungay, DateTime xxdenngay)
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
              
                    dt_ = cls.H_Tinh_SoPhieu_T8(xxtungay, xxdenngay);
               
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

            gridMacDinh_Luong.Properties.DataSource = dtset.Tables[8];
            gridMacDinh_Luong.Properties.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            gridMacDinh_Luong.Properties.DisplayMember = "MaDinhMuc";

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
            int xID_CaTruong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_IN).ToString());
            string sMaphieu___ = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
            int xIDmay= CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_May_IN).ToString());
            int xID_CongNhan= CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_IN).ToString());           
            int xID_DinhMuc_Luong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_IN).ToString());
            int xID_VTHH_Vao = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao_IN).ToString());
            int xID_VTHH_Ra = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_IN).ToString());
            string sSoLuong_Vao = bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao_IN).ToString();
            string sSanLuong_Thuong = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Thuong_IN).ToString();
            string sSanLuong_TangCa = bandedGridView1.GetFocusedRowCellValue(clSanLuong_TangCa_IN).ToString();
            string sngaysanxuat = bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString();
            string scasaanxuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat_IN).ToString();
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
        private void Luu_DuLieu_IN_CAT()
        {
            if (!KiemTra_Change()) return;
            else
            {
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                if (dttttt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dttttt2.Rows.Count; i++)
                    {
                        dttttt2.Rows[i]["Change"] = "0";
                    }
                    gridControl1.DataSource = dttttt2;
                }
                for (int i = 0; i < dt_Change_.Rows.Count; i++)
                {
                    clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();
                    cls1.sMaPhieu = dt_Change_.Rows[i]["MaPhieu"].ToString();
                    cls1.daNgayLapPhieu = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat"].ToString());
                    cls1.sCaSanXuat = dt_Change_.Rows[i]["CaSanXuat"].ToString();
                    cls1.iID_CaTruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong"].ToString());
                    cls1.sGhiChu = dt_Change_.Rows[i]["GhiChu"].ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bGuiDuLieu = false;
                    cls1.bCheck_In = false;
                    cls1.bCheck_Cat = false;
                    cls1.bCheck_Dot = false;
                    cls1.iBienTrangThai = 0;
                    cls1.bDaKetThuc = false;
                    int xxID_Sophieu_;
                    if (dt_Change_.Rows[i]["ID_SoPhieu"].ToString() == "")
                    {
                        cls1.Insert();
                        xxID_Sophieu_ = cls1.iID_SoPhieu.Value;
                    }
                    else
                    {
                        cls1.iID_SoPhieu = Convert.ToInt32(dt_Change_.Rows[i]["ID_SoPhieu"].ToString());
                        cls1.Update();
                        xxID_Sophieu_ = cls1.iID_SoPhieu.Value;
                    }

                    clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

                    cls.iID_SoPhieu = xxID_Sophieu_;
                    cls.iID_May = Convert.ToInt32(dt_Change_.Rows[i]["ID_May"].ToString());
                    cls.iID_CongNhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan"].ToString());
                    cls.iID_CaTruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong"].ToString());
                    cls.daNgaySanXuat = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat"].ToString());
                    cls.sGhiChu = "";
                    cls.sCaSanXuat = dt_Change_.Rows[i]["CaSanXuat"].ToString();
                    cls.iID_DinhMuc_Luong = Convert.ToInt32(dt_Change_.Rows[i]["ID_DinhMuc_Luong"].ToString());
                    cls.iID_VTHH_Vao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao"].ToString());
                    cls.fSoLuong_Vao = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao"].ToString());
                    cls.fDonGia_Vao = 0;
                    cls.iID_VTHH_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra"].ToString());
                    cls.fSanLuong_Thuong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Thuong"].ToString());
                    cls.fSanLuong_TangCa = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_TangCa"].ToString());
                    cls.fSanLuong_Tong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Tong"].ToString());
                    cls.fDonGia_Xuat = 0;
                    cls.fPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham"].ToString());
                    if (Convert.ToInt32(gridLoaiMay.EditValue.ToString()) == 1)
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
                    if (dt_Change_.Rows[i]["ID_ChiTietPhieu"].ToString() == "")
                    {
                        cls.Insert();

                    }
                    else
                    {
                        cls.iID_ChiTietPhieu = Convert.ToInt32(dt_Change_.Rows[i]["ID_ChiTietPhieu"].ToString());
                        cls.Update();
                    }
                    int iiiDID_ChiTietPhieuxxx;
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                    TaoLenhSanXuat(xxID_Sophieu_, iiiDID_ChiTietPhieuxxx);
                    LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime);
                }
                
               
            }
            MessageBox.Show("Đã lưu");
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
            
            gridMacDinh_Luong.EditValue = 8;
            _SoDong = Convert.ToInt32(txtSoDong.Text);
            dteNgayMacDinh.DateTime= DateTime.Today;
            clSanLuong_Tong_IN.Caption = "Sản\nlượng";
            clID_DinhMuc_Luong_IN.Caption = "ĐM\nlương";
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
            Load_LockUp(_Loaimay);
         
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
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
                
                Cursor.Current = Cursors.Default;               

            }
            catch
            { }
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            if (KiemTra_Change() == true)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Luu_DuLieu_IN_CAT();
                }

            }

            _SoDong = Convert.ToInt32(txtSoDong.Text);

            ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
            LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        
        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clMaPhieu)
                {
                    if (bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString() != "")
                    {
                        string smaphieu = bandedGridView1.GetRowCellValue(e.RowHandle, clMaPhieu).ToString();
                        DateTime ngaysanxuat = Convert.ToDateTime(bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString());
                        if (KiemTra_TrungMaPhieu(smaphieu, ngaysanxuat) == false)
                        {
                            bandedGridView1.SetRowCellValue(e.RowHandle, clMaPhieu, "");
                            return;
                        }
                        else bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
                    }
                }
                if (e.Column == clID_VTHH_Vao_IN)
                {
                    bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_IN, sTenVTHH_vao);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_IN, sDonViTinh_vao);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
                }

                if (e.Column == clID_VTHH_Ra_IN)
                {
                    bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_IN, sTenVTHH_ra);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_IN, sDonViTinh_ra);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
                }
                if (e.Column == clNgayLapPhieu || e.Column == clCaSanXuat_IN || e.Column == clID_May_IN || e.Column == clSoLuong_Vao_IN || e.Column == clID_CongNhan_IN || e.Column == clID_DinhMuc_Luong_IN || e.Column == clID_CaTruong_IN || e.Column == clGhiChu_IN)
                {                  
                    bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
                }
                if (e.Column == clSanLuong_Tong_IN)
                {
                    double xsanluongtong = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_IN).ToString());
                    int xiD_dinhMucluong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_IN).ToString());
                    int xidcongnhan = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_IN).ToString());
                    int xidvthhra = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_IN).ToString());
                    DateTime xngaysanxuat = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString());
                    string xcasanxuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat_IN).ToString();

                    Tinh_SanLuong(xsanluongtong, xiD_dinhMucluong, xidcongnhan, xidvthhra, xngaysanxuat, xcasanxuat);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_Thuong_IN, sanluongthuong_);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_TangCa_IN, sanluongtangca_);
                    bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
                }
                
            }
            catch
            { }

        }

        private void bandedGridView1_ClipboardRowPasting(object sender, DevExpress.XtraGrid.Views.Grid.ClipboardRowPastingEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridColumn columnText = view.Columns["Text"];
            //GridColumn columnInfo = view.Columns["Info"];
            //if (e.Values[columnInfo].ToString() == "NBR")
            //    e.Values[columnText] = _lookups["NBR"].Where(x => x.DisplayName == e.Values[columnText].ToString()).FirstOrDefault().Name;
            //else if (e.Values[columnInfo].ToString() == "ITM")
            //    e.Values[columnText] = _lookups["ITM"].Where(x => x.DisplayName == e.Values[columnText].ToString()).FirstOrDefault().Name;
            //else if (e.Values[columnInfo].ToString() == "CHO")
            //    e.Values[columnText] = _lookups["CHO"].Where(x => x.DisplayName == e.Values[columnText].ToString()).FirstOrDefault().Name;
        }
       
        private void bandedGridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            bandedGridView1.SetRowCellValue(e.RowHandle, clNgayLapPhieu, daNgayMacdinh);
            bandedGridView1.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong_IN, iMacDinh_Luong);
            bandedGridView1.SetRowCellValue(e.RowHandle, clID_CaTruong_IN, iMacDinh_CaTruong);
            bandedGridView1.SetRowCellValue(e.RowHandle, clCaSanXuat_IN, sMacDinh_CaSX);
           
            bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "1");
          
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

        private void dteNgayMacDinh_EditValueChanged(object sender, EventArgs e)
        {
            daNgayMacdinh = dteNgayMacDinh.DateTime;
        }

        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {          
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string change = View.GetRowCellValue(e.RowHandle, View.Columns["Change"]).ToString();
                string sstesst = View.GetRowCellValue(e.RowHandle, View.Columns["Test_IN"]).ToString();
                if (sstesst == "1")
                {
                    e.Appearance.BackColor = Color.OrangeRed;

                }
                else if (change == "1")
                {
                    e.Appearance.BackColor = Color.PaleTurquoise;

                }
                
            }
        }
        private void bandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
                if (KiemTraLuu_In_CAT() == false)
                {                   
                    bandedGridView1.SetRowCellValue(e.RowHandle, clTest_IN, "1");
                }
                else bandedGridView1.SetRowCellValue(e.RowHandle, clTest_IN, "0");
          
            //if (bandedGridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString() == "")
            //{
            //    if (KiemTraLuu_In_CAT() == false)
            //    {
            //        bandedGridView1.SetRowCellValue(e.RowHandle, clChange, "0");
            //        bandedGridView1.SetRowCellValue(e.RowHandle, clTest, "1");
            //    }
            //    else bandedGridView1.SetRowCellValue(e.RowHandle, clTest, "0");
            //}

        }

        private void gridMacDinh_Luong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                iMacDinh_Luong = (int)gridMacDinh_Luong.EditValue;
            }
            catch
            { }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            
            if (KiemTra_Change() == true)
            {                
                Luu_DuLieu_IN_CAT();               
            }
            else MessageBox.Show("Đã lưu");
            
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString() != "")
            {
                string maPhieu = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();

                DialogResult traloi = MessageBox.Show("Xóa hết dữ liệu phiếu: " + maPhieu + "", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int xxiID_SoPhieu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                  
                    clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();

                    cls1.iID_SoPhieu = xxiID_SoPhieu;
                    if (cls1.Delete())
                    {
                        clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
                        cls2.iID_SoPhieu = xxiID_SoPhieu;
                        cls2.Delete_All_W_ID_SoPhieu();
                        // xoá chi tiet lenh sản xuất
                        clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls3 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                        cls3.iID_SoPhieu = xxiID_SoPhieu;
                        cls3.Delete_ALL_W_ID_SoPhieu();
                        // xoá lenh san xuat
                        cls3.iID_SoPhieu = xxiID_SoPhieu;
                        DataTable dt4 = cls3.SelectAll_W_ID_SoPhieu();
                        if (dt4.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dt4.Rows.Count; i++)
                            {
                                int ID_LenhSanXuatxx = Convert.ToInt32(dt4.Rows[i]["ID_LenhSanXuat"].ToString());
                                clsHUU_LenhSanXuat cls4 = new clsHUU_LenhSanXuat();
                                cls4.iID_LenhSanXuat = ID_LenhSanXuatxx;
                                cls4.Delete();
                            }
                        }
                    }
                    MessageBox.Show("Đã xoá");
                    LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime);
                }
            }
            else
            {
                bandedGridView1.DeleteRow(bandedGridView1.FocusedRowHandle);
            }
        }      

        private void btThoat_Click(object sender, EventArgs e)
        {
            if (KiemTra_Change() == true)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Luu_DuLieu_IN_CAT();
                }

            }
            this.Close();
        }

        private void PhieuSanXuat_IN_CAT_New_thang8_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KiemTra_Change() == true)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Luu_DuLieu_IN_CAT();
                }

            }
        }
               
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            bool handled = false;
            if (e.KeyData == (Keys.C | Keys.Control))
            {
                //value = view.GetFocusedRow();
                //handled = true;
                bandedGridView1.CopyToClipboard();
            }

            if (e.KeyData == (Keys.V | Keys.Control))
            {
                //view.SetFocusedRowCellValue(view.FocusedColumn, value);
                //handled = true;
                bandedGridView1.PasteFromClipboard();
            }

            e.Handled = handled;
            e.SuppressKeyPress = handled;
        }

        private void btDot_Click(object sender, EventArgs e)
        {
            if(bandedGridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString()!="" & bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_IN).ToString() != "")
            {
                int xxID_VTHHRa= Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_IN).ToString());
                miID_SoPhieu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(CLID_SoPhieu).ToString());
                SanXuat_frmChiTietPhieu_MayDot ff = new SanXuat_frmChiTietPhieu_MayDot(xxID_VTHHRa);
                ff.Show();
            }
        }

      

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (KiemTra_Change() == true)
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Luu_DuLieu_IN_CAT();
                }

            }

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