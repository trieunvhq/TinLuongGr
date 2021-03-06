using DevExpress.XtraEditors;
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
        int iMacDinh_VTHH_Vao = 0;
        int iMacDinh_VTHH_Ra = 0;
        string sMacDinh_CaSX = "";
        string sMacDinh_TenVTHH_Vao = "";
        string sMacDinh_DVT_Vao = "";
        string sMacDinh_TenVTHH_Ra = "";
        string sMacDinh_DVT_Ra = "";
        DateTime daNgayMacdinh = DateTime.Now;
        private int _SoTrang = 1;
        private int _SoDong;
        private int _Loaimay = 1;
        private bool isload = false;

        int iID_VTHH_Vao_IN, iID_VTHH_Vao_CAT, iID_VTHH_Vao_DOT;
        int iID_VTHH_Ra_IN, iID_VTHH_Ra_CAT, iID_VTHH_Ra_DOT;
        string sTenVTHH_vao_IN, sDonViTinh_vao_IN;
        string sTenVTHH_ra_IN, sDonViTinh_ra_IN;

        string sTenVTHH_vao_CAT, sDonViTinh_vao_CAT;
        string sTenVTHH_ra_CAT, sDonViTinh_ra_CAT;

        string sTenVTHH_vao_DOT, sDonViTinh_vao_DOT;
        string sTenVTHH_ra_DOT, sDonViTinh_ra_DOT;

        double sanluongthuong_ = 0, sanluongtangca_ = 0;
        DataTable dt_Change_;

        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
                {
                    gridControl1.DataSource = null;
                    isload = true;
                    _SoTrang = sotrang;
                    _SoDong = sodong;
                    DataTable dt2 = new DataTable();

                    dt2 = cls.H_load_Phieu_ngaythang_T8(sotrang, _SoDong, xxtungay, xxdenngay);

                    gridControl1.DataSource = dt2;

                    isload = false;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void ResetSoTrang(int xxsodong, DateTime xxtungay, DateTime xxdenngay)
        {
            try
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HienThi_Pannel(int iiID_loaimay)
        {
            try
            {
                if (checkthemmoi.Checked == false)
                {
                    bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                else
                {
                    if (iiID_loaimay == 1) // máy in
                    {
                        bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    }
                    else
                        bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                }
                if (iiID_loaimay == 1) // máy in
                {
                    gridBand_VatTu_IN.Visible = true;
                    gridBand_ThanhPham_IN.Visible = true;
                    gridBand_VatTu_CAT.Visible = false;
                    gridBand_ThanhPham_CAT.Visible = false;
                    gridBand_VatTu_DOT.Visible = false;
                    gridBand_ThanhPham_DOT.Visible = false;

                    clMaPhieu.OptionsColumn.AllowEdit = true;
                    clNgayLapPhieu.OptionsColumn.AllowEdit = true;
                    clMaPhieu.OptionsColumn.AllowFocus = true;
                    clNgayLapPhieu.OptionsColumn.AllowFocus = true;
                    //bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    clDot.Visible = false;
                    clCopy.Visible = false;
                }
                else if (iiID_loaimay == 2)
                {
                    gridBand_VatTu_IN.Visible = false;
                    gridBand_ThanhPham_IN.Visible = false;
                    gridBand_VatTu_CAT.Visible = true;
                    gridBand_ThanhPham_CAT.Visible = true;
                    gridBand_VatTu_DOT.Visible = false;
                    gridBand_ThanhPham_DOT.Visible = false;
                    clMaPhieu.OptionsColumn.AllowEdit = true;
                    clNgayLapPhieu.OptionsColumn.AllowEdit = true;
                    clMaPhieu.OptionsColumn.AllowFocus = true;
                    clNgayLapPhieu.OptionsColumn.AllowFocus = true;
                    //bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    clDot.Visible = false;
                    clCopy.Visible = true;
                }
                else if (iiID_loaimay == 3)
                {
                    gridBand_VatTu_IN.Visible = false;
                    gridBand_ThanhPham_IN.Visible = false;
                    gridBand_VatTu_CAT.Visible = false;
                    gridBand_ThanhPham_CAT.Visible = false;
                    gridBand_VatTu_DOT.Visible = true;
                    gridBand_ThanhPham_DOT.Visible = true;
                    clMaPhieu.OptionsColumn.AllowEdit = false;
                    clNgayLapPhieu.OptionsColumn.AllowEdit = false;
                    clMaPhieu.OptionsColumn.AllowFocus = false;
                    clNgayLapPhieu.OptionsColumn.AllowFocus = false;
                    //bandedGridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    clDot.Visible = true;
                    clCopy.Visible = false;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Load_LockUp()
        {
            try
            {
                using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
                {
                    DataSet dtset = cls.H_LockUp_PhieuSanXuat_thang8();

                    gridMaVT_Vao_IN.DataSource = dtset.Tables[4];
                    gridMaVT_Vao_IN.ValueMember = "ID_VTHH";
                    gridMaVT_Vao_IN.DisplayMember = "MaVT";

                    gridMaVT_Ra_IN.DataSource = dtset.Tables[4];
                    gridMaVT_Ra_IN.ValueMember = "ID_VTHH";
                    gridMaVT_Ra_IN.DisplayMember = "MaVT";

                    gridMaVT_Vao_CAT.DataSource = dtset.Tables[4];
                    gridMaVT_Vao_CAT.ValueMember = "ID_VTHH";
                    gridMaVT_Vao_CAT.DisplayMember = "MaVT";

                    gridMaVT_Ra_CAT.DataSource = dtset.Tables[4];
                    gridMaVT_Ra_CAT.ValueMember = "ID_VTHH";
                    gridMaVT_Ra_CAT.DisplayMember = "MaVT";

                    gridMaVT_Vao_DOT.DataSource = dtset.Tables[4];
                    gridMaVT_Vao_DOT.ValueMember = "ID_VTHH";
                    gridMaVT_Vao_DOT.DisplayMember = "MaVT";

                    gridMaVT_Ra_DOT.DataSource = dtset.Tables[4];
                    gridMaVT_Ra_DOT.ValueMember = "ID_VTHH";
                    gridMaVT_Ra_DOT.DisplayMember = "MaVT";


                    gridMacDinh_VatTu_Vao.Properties.DataSource = dtset.Tables[4];
                    gridMacDinh_VatTu_Vao.Properties.ValueMember = "ID_VTHH";
                    gridMacDinh_VatTu_Vao.Properties.DisplayMember = "MaVT";

                    gridMacDinh_VatTu_Ra.Properties.DataSource = dtset.Tables[4];
                    gridMacDinh_VatTu_Ra.Properties.ValueMember = "ID_VTHH";
                    gridMacDinh_VatTu_Ra.Properties.DisplayMember = "MaVT";

                    gridDMLuong_IN.DataSource = dtset.Tables[8];
                    gridDMLuong_IN.ValueMember = "ID_DinhMuc_Luong_SanLuong";
                    gridDMLuong_IN.DisplayMember = "MaDinhMuc";

                    gridDMLuong_CAT.DataSource = dtset.Tables[8];
                    gridDMLuong_CAT.ValueMember = "ID_DinhMuc_Luong_SanLuong";
                    gridDMLuong_CAT.DisplayMember = "MaDinhMuc";

                    gridDMLuong_DOT.DataSource = dtset.Tables[8];
                    gridDMLuong_DOT.ValueMember = "ID_DinhMuc_Luong_SanLuong";
                    gridDMLuong_DOT.DisplayMember = "MaDinhMuc";

                    gridCaTruong_IN.DataSource = dtset.Tables[0];
                    gridCaTruong_IN.ValueMember = "ID_NhanSu";
                    gridCaTruong_IN.DisplayMember = "MaNhanVien";

                    gridCaTruong_CAT.DataSource = dtset.Tables[0];
                    gridCaTruong_CAT.ValueMember = "ID_NhanSu";
                    gridCaTruong_CAT.DisplayMember = "MaNhanVien";

                    gridCaTruong_DOT.DataSource = dtset.Tables[0];
                    gridCaTruong_DOT.ValueMember = "ID_NhanSu";
                    gridCaTruong_DOT.DisplayMember = "MaNhanVien";

                    cbCaTruongMacDinh.DataSource = dtset.Tables[0];
                    cbCaTruongMacDinh.ValueMember = "ID_NhanSu";
                    cbCaTruongMacDinh.DisplayMember = "TenNhanVien";

                    gridMacDinh_Luong.Properties.DataSource = dtset.Tables[8];
                    gridMacDinh_Luong.Properties.ValueMember = "ID_DinhMuc_Luong_SanLuong";
                    gridMacDinh_Luong.Properties.DisplayMember = "MaDinhMuc";


                    gridCongNhan_IN.DataSource = dtset.Tables[1];
                    gridCongNhan_IN.ValueMember = "ID_NhanSu";
                    gridCongNhan_IN.DisplayMember = "TenNhanVien";

                    gridMaMay_IN.DataSource = dtset.Tables[5];
                    gridMaMay_IN.ValueMember = "ID_May";
                    gridMaMay_IN.DisplayMember = "TenMay";



                    gridCongNhan_CAT.DataSource = dtset.Tables[2];
                    gridCongNhan_CAT.ValueMember = "ID_NhanSu";
                    gridCongNhan_CAT.DisplayMember = "TenNhanVien";


                    gridMaMay_CAT.DataSource = dtset.Tables[6];
                    gridMaMay_CAT.ValueMember = "ID_May";
                    gridMaMay_CAT.DisplayMember = "TenMay";


                    gridCongNhan_DOT.DataSource = dtset.Tables[3];
                    gridCongNhan_DOT.ValueMember = "ID_NhanSu";
                    gridCongNhan_DOT.DisplayMember = "TenNhanVien";

                    gridMaMay_DOT.DataSource = dtset.Tables[7];
                    gridMaMay_DOT.ValueMember = "ID_May";
                    gridMaMay_DOT.DisplayMember = "MaMay";

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
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tinh_SanLuong(double sanluongtong, int iiID_DinhmucLuong, int iiID_CongNhan, int iiID_VTHH_Ra__, DateTime ngaysanxuat__, string casanxxutaxx_)
        {
            try
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTra_TrungMaPhieu(string xsmaphieu, DateTime ngaykethuc, bool MayIn, bool MayCat, bool MayDot)
        {
            try
            {
                DateTime ngaybatdau;
                DataTable dt = new DataTable();
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                ngaybatdau = ngaykethuc.AddDays(-30);
                dt = cls.H_KiemTra_Trung_Phieu_SX_T8(xsmaphieu, ngaybatdau, ngaykethuc, MayIn, MayCat, MayDot);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đã có Mã phiếu: " + xsmaphieu + "\nVui lòng thử lại", "Kiểm tra");
                    return false;
                }
                else return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
        }
        private bool KiemTra_Hang(int xxloaimay)
        {
            try
            {
                if (xxloaimay == 1)
                {
                    int xID_CaTruong_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_IN).ToString());
                    string sMaphieu____IN = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                    int xIDmay_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_May_IN).ToString());
                    int xID_CongNhan_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_IN).ToString());
                    int xID_DinhMuc_Luong_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_IN).ToString());
                    int xID_VTHH_Vao_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao_IN).ToString());
                    int xID_VTHH_Ra_IN = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_IN).ToString());
                    string sSoLuong_Vao_IN = bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao_IN).ToString();
                    string sSanLuong_Thuong_IN = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Thuong_IN).ToString();
                    string sSanLuong_TangCa_IN = bandedGridView1.GetFocusedRowCellValue(clSanLuong_TangCa_IN).ToString();
                    string sngaysanxuat_IN = bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString();
                    string scasaanxuat_IN = bandedGridView1.GetFocusedRowCellDisplayText(clCaSanXuat_IN).ToString();
                    string sSanLuong_Tong_IN = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_IN).ToString();
                    if (xID_CaTruong_IN == 0 || xIDmay_IN == 0 || xID_CongNhan_IN == 0 || xID_DinhMuc_Luong_IN == 0 || xID_VTHH_Vao_IN == 0 || xID_VTHH_Ra_IN == 0)
                    {
                        return false;
                    }
                    else if (sMaphieu____IN == "" || sSoLuong_Vao_IN == "" || sSanLuong_Tong_IN == "" || sSanLuong_Thuong_IN == "" || sSanLuong_TangCa_IN == "" || sngaysanxuat_IN == "" || scasaanxuat_IN == "")
                    {
                        return false;
                    }
                    else return true;
                }
                else if (xxloaimay == 2)
                {
                    int xID_CaTruong_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_CAT).ToString());
                    int xIDmay_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_May_CAT).ToString());
                    int xID_CongNhan_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_CAT).ToString());
                    int xID_DinhMuc_Luong_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_CAT).ToString());
                    int xID_VTHH_Vao_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao_CAT).ToString());
                    int xID_VTHH_Ra_CAT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_CAT).ToString());
                    string sSoLuong_Vao_CAT = bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao_CAT).ToString();
                    string sSanLuong_Thuong_CAT = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Thuong_CAT).ToString();
                    string sSanLuong_TangCa_CAT = bandedGridView1.GetFocusedRowCellValue(clSanLuong_TangCa_CAT).ToString();
                    string sngaysanxuat_CAT = bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString();
                    string scasaanxuat_CAT = bandedGridView1.GetFocusedRowCellDisplayText(clCaSanXuat_CAT).ToString();
                    string sSanLuong_Tong_CAT = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_CAT).ToString();
                    if (xID_CaTruong_CAT == 0 || xIDmay_CAT == 0 || xID_CongNhan_CAT == 0 || xID_DinhMuc_Luong_CAT == 0 || xID_VTHH_Vao_CAT == 0 || xID_VTHH_Ra_CAT == 0)
                    {
                        return false;
                    }
                    else if (sSoLuong_Vao_CAT == "" || sSanLuong_Tong_CAT == "" || sSanLuong_Thuong_CAT == "" || sSanLuong_TangCa_CAT == "" || sngaysanxuat_CAT == "" || scasaanxuat_CAT == "")
                    {
                        return false;
                    }
                    else return true;
                }
                else if (xxloaimay == 3)
                {
                    int xID_CaTruong_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_DOT).ToString());

                    int xIDmay_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_May_DOT).ToString());
                    int xID_CongNhan_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_DOT).ToString());
                    int xID_DinhMuc_Luong_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_DOT).ToString());
                    int xID_VTHH_Vao_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao_DOT).ToString());
                    int xID_VTHH_Ra_DOT = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_DOT).ToString());
                    string sSoLuong_Vao_DOT = bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao_DOT).ToString();
                    string ssokgmoatbaoxx = bandedGridView1.GetFocusedRowCellValue(clSoKG_MotBao_May_Dot).ToString();
                    string ssdocaodot = bandedGridView1.GetFocusedRowCellValue(clDoCao_Dot).ToString();
                    string sngaysanxuat_DOT = bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString();
                    string scasaanxuat_DOT = bandedGridView1.GetFocusedRowCellDisplayText(clCaSanXuat_DOT).ToString();
                    string sSanLuong_Tong_DOT = bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_DOT).ToString();
                    if (xID_CaTruong_DOT == 0 || xIDmay_DOT == 0 || xID_CongNhan_DOT == 0 || xID_DinhMuc_Luong_DOT == 0 || xID_VTHH_Vao_DOT == 0 || xID_VTHH_Ra_DOT == 0)
                    {
                        return false;
                    }
                    else if (sSoLuong_Vao_DOT == "" || sSanLuong_Tong_DOT == "" || ssokgmoatbaoxx == "" || ssdocaodot == "" || sngaysanxuat_DOT == "" || scasaanxuat_DOT == "")
                    {
                        return false;
                    }
                    else return true;
                }
                else return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool KiemTra_Luu_DuLieu(int xxloaimay)
        {
            try
            {
                dt_Change_ = new DataTable();
                DataTable dt2 = (DataTable)gridControl1.DataSource;
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                dt = dt2.Copy();
                if (xxloaimay == 1)
                {
                    dt.DefaultView.RowFilter = "Change_IN='1' and Test_IN='0'";
                    dv = dt.DefaultView;
                    dt_Change_ = dv.ToTable();
                }
                else if (xxloaimay == 2)
                {
                    dt.DefaultView.RowFilter = "Change_CAT='1' and Test_CAT='0'";
                    dv = dt.DefaultView;
                    dt_Change_ = dv.ToTable();
                }
                else if (xxloaimay == 3)
                {
                    dt.DefaultView.RowFilter = "Change_DOT='1' and Test_DOT='0'";
                    dv = dt.DefaultView;
                    dt_Change_ = dv.ToTable();
                }

                if (dt_Change_.Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Luu_DuLieu_May_IN()
        {
            try
            {
                for (int i = 0; i < dt_Change_.Rows.Count; i++)
                {
                    clsPhieu_tbPhieu cls1 = new clsPhieu_tbPhieu();
                    cls1.sMaPhieu = dt_Change_.Rows[i]["MaPhieu"].ToString();
                    cls1.daNgayLapPhieu = Convert.ToDateTime(dt_Change_.Rows[i]["NgayLapPhieu"].ToString());
                    cls1.sCaSanXuat = dt_Change_.Rows[i]["CaSanXuat_IN"].ToString();
                    cls1.iID_CaTruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_IN"].ToString());
                    cls1.sGhiChu = "";
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

                    int xxidccatruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_IN"].ToString());
                    int xxidcongnhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan_IN"].ToString());
                    DateTime xxngaysxxx = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat_IN"].ToString());
                    string xxcasxxx = dt_Change_.Rows[i]["CaSanXuat_IN"].ToString();
                    int xxid_vtvao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao_IN"].ToString());
                    int xxid_Vt_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra_IN"].ToString());
                    double xxSoLuong_Vaoxx = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao_IN"].ToString());
                    double xxsanluongthuongxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Thuong_IN"].ToString());
                    double xxxxSanLuong_TangCaxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_TangCa_IN"].ToString());
                    double xxxxPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham_IN"].ToString());

                    cls.iID_SoPhieu = xxID_Sophieu_;
                    cls.iID_May = Convert.ToInt32(dt_Change_.Rows[i]["ID_May_IN"].ToString());
                    cls.iID_CongNhan = xxidcongnhan;

                    cls.iID_CaTruong = xxidccatruong;
                    cls.daNgaySanXuat = xxngaysxxx;
                    cls.sGhiChu = "";
                    cls.sCaSanXuat = xxcasxxx;
                    cls.iID_DinhMuc_Luong = Convert.ToInt32(dt_Change_.Rows[i]["ID_DinhMuc_Luong_IN"].ToString());
                    cls.iID_VTHH_Vao = xxid_vtvao;
                    cls.fSoLuong_Vao = xxSoLuong_Vaoxx;
                    cls.fDonGia_Vao = 0;
                    cls.iID_VTHH_Ra = xxid_Vt_Ra;
                    cls.fSanLuong_Thuong = xxsanluongthuongxx;
                    cls.fSanLuong_TangCa = xxxxSanLuong_TangCaxx;
                    cls.fSanLuong_Tong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Tong_IN"].ToString());
                    cls.fDonGia_Xuat = 0;
                    cls.fPhePham = xxxxPhePham;
                    cls.bBMay_IN = true;
                    cls.bBMay_CAT = false;
                    cls.bBMay_DOT = false;

                    cls.bTrangThaiXuatNhap = false;
                    cls.bGuiDuLieu = true;
                    cls.bTrangThaiTaoLenhSanXuat = false;
                    cls.fSoKG_MotBao_May_Dot = 0;
                    cls.fDoCao_Dot = 0;
                    if (dt_Change_.Rows[i]["ID_ChiTietPhieu_IN"].ToString() == "")
                    {
                        cls.Insert();

                    }
                    else
                    {
                        cls.iID_ChiTietPhieu = Convert.ToInt32(dt_Change_.Rows[i]["ID_ChiTietPhieu_IN"].ToString());
                        cls.Update();
                    }
                    int iiiDID_ChiTietPhieuxxx;
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                    TaoLenhSanXuat(_Loaimay, xxID_Sophieu_, iiiDID_ChiTietPhieuxxx, xxidccatruong, xxidcongnhan, xxngaysxxx, xxcasxxx, xxid_vtvao, xxid_Vt_Ra, xxSoLuong_Vaoxx,
                        xxsanluongthuongxx, xxxxSanLuong_TangCaxx, xxxxPhePham);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Luu_DuLieu_May_CAT()
        {
            try
            {
                for (int i = 0; i < dt_Change_.Rows.Count; i++)
                {

                    clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

                    int xxidccatruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_CAT"].ToString());
                    int xxidcongnhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan_CAT"].ToString());
                    DateTime xxngaysxxx = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat_CAT"].ToString());
                    string xxcasxxx = dt_Change_.Rows[i]["CaSanXuat_CAT"].ToString();
                    int xxid_vtvao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao_CAT"].ToString());
                    int xxid_Vt_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra_CAT"].ToString());
                    double xxSoLuong_Vaoxx = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao_CAT"].ToString());
                    double xxsanluongthuongxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Thuong_CAT"].ToString());
                    double xxxxSanLuong_TangCaxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_TangCa_CAT"].ToString());
                    double xxxxPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham_CAT"].ToString());

                    int xxID_Sophieu_ = Convert.ToInt32(dt_Change_.Rows[i]["ID_SoPhieu"].ToString());
                    cls.iID_SoPhieu = xxID_Sophieu_;
                    cls.iID_May = Convert.ToInt32(dt_Change_.Rows[i]["ID_May_CAT"].ToString());
                    cls.iID_CongNhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan_CAT"].ToString());
                    cls.iID_CaTruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_CAT"].ToString());
                    cls.daNgaySanXuat = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat_CAT"].ToString());
                    cls.sGhiChu = "";
                    cls.sCaSanXuat = dt_Change_.Rows[i]["CaSanXuat_CAT"].ToString();
                    cls.iID_DinhMuc_Luong = Convert.ToInt32(dt_Change_.Rows[i]["ID_DinhMuc_Luong_CAT"].ToString());
                    cls.iID_VTHH_Vao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao_CAT"].ToString());
                    cls.fSoLuong_Vao = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao_CAT"].ToString());
                    cls.fDonGia_Vao = 0;
                    cls.iID_VTHH_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra_CAT"].ToString());
                    cls.fSanLuong_Thuong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Thuong_CAT"].ToString());
                    cls.fSanLuong_TangCa = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_TangCa_CAT"].ToString());
                    cls.fSanLuong_Tong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Tong_CAT"].ToString());
                    cls.fDonGia_Xuat = 0;
                    cls.fPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham_CAT"].ToString());
                    cls.bBMay_IN = false;
                    cls.bBMay_CAT = true;
                    cls.bBMay_DOT = false;
                    cls.bTrangThaiXuatNhap = false;
                    cls.bGuiDuLieu = true;
                    cls.bTrangThaiTaoLenhSanXuat = false;
                    cls.fSoKG_MotBao_May_Dot = 0;
                    cls.fDoCao_Dot = 0;
                    if (dt_Change_.Rows[i]["ID_ChiTietPhieu_CAT"].ToString() == "")
                    {
                        cls.Insert();

                    }
                    else
                    {
                        cls.iID_ChiTietPhieu = Convert.ToInt32(dt_Change_.Rows[i]["ID_ChiTietPhieu_CAT"].ToString());
                        cls.Update();
                    }
                    int iiiDID_ChiTietPhieuxxx;
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                    TaoLenhSanXuat(_Loaimay, xxID_Sophieu_, iiiDID_ChiTietPhieuxxx, xxidccatruong, xxidcongnhan, xxngaysxxx, xxcasxxx, xxid_vtvao, xxid_Vt_Ra, xxSoLuong_Vaoxx,
                       xxsanluongthuongxx, xxxxSanLuong_TangCaxx, xxxxPhePham);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Luu_DuLieu_May_DOT()
        {
            try
            {
                for (int i = 0; i < dt_Change_.Rows.Count; i++)
                {
                    int xxidccatruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_DOT"].ToString());
                    int xxidcongnhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan_DOT"].ToString());
                    DateTime xxngaysxxx = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat_DOT"].ToString());
                    string xxcasxxx = dt_Change_.Rows[i]["CaSanXuat_DOT"].ToString();
                    int xxid_vtvao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao_DOT"].ToString());
                    int xxid_Vt_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra_DOT"].ToString());
                    double xxSoLuong_Vaoxx = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao_DOT"].ToString());
                    double xxsanluongthuongxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Thuong_DOT"].ToString());
                    double xxxxSanLuong_TangCaxx = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_TangCa_DOT"].ToString());
                    double xxxxPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham_DOT"].ToString());

                    clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                    int xxID_Sophieu_ = Convert.ToInt32(dt_Change_.Rows[i]["ID_SoPhieu"].ToString());
                    cls.iID_SoPhieu = xxID_Sophieu_;
                    cls.iID_May = Convert.ToInt32(dt_Change_.Rows[i]["ID_May_DOT"].ToString());
                    cls.iID_CongNhan = Convert.ToInt32(dt_Change_.Rows[i]["ID_CongNhan_DOT"].ToString());
                    cls.iID_CaTruong = Convert.ToInt32(dt_Change_.Rows[i]["ID_CaTruong_DOT"].ToString());
                    cls.daNgaySanXuat = Convert.ToDateTime(dt_Change_.Rows[i]["NgaySanXuat_DOT"].ToString());
                    cls.sGhiChu = "";
                    cls.sCaSanXuat = dt_Change_.Rows[i]["CaSanXuat_DOT"].ToString();
                    cls.iID_DinhMuc_Luong = Convert.ToInt32(dt_Change_.Rows[i]["ID_DinhMuc_Luong_DOT"].ToString());
                    cls.iID_VTHH_Vao = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Vao_DOT"].ToString());
                    cls.fSoLuong_Vao = Convert.ToDouble(dt_Change_.Rows[i]["SoLuong_Vao_DOT"].ToString());
                    cls.fDonGia_Vao = 0;
                    cls.iID_VTHH_Ra = Convert.ToInt32(dt_Change_.Rows[i]["ID_VTHH_Ra_DOT"].ToString());
                    cls.fSanLuong_Thuong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Tong_DOT"].ToString());
                    cls.fSanLuong_TangCa = 0;
                    cls.fSanLuong_Tong = Convert.ToDouble(dt_Change_.Rows[i]["SanLuong_Tong_DOT"].ToString());
                    cls.fDonGia_Xuat = 0;
                    cls.fPhePham = CheckString.ConvertToDouble_My(dt_Change_.Rows[i]["PhePham_DOT"].ToString());
                    cls.bBMay_IN = false;
                    cls.bBMay_CAT = false;
                    cls.bBMay_DOT = true;
                    cls.bTrangThaiXuatNhap = false;
                    cls.bGuiDuLieu = true;
                    cls.bTrangThaiTaoLenhSanXuat = false;
                    cls.fSoKG_MotBao_May_Dot = Convert.ToDouble(dt_Change_.Rows[i]["SoKG_MotBao_May_Dot"].ToString());
                    cls.fDoCao_Dot = Convert.ToDouble(dt_Change_.Rows[i]["DoCao_Dot"].ToString());
                    if (dt_Change_.Rows[i]["ID_ChiTietPhieu_DOT"].ToString() == "")
                    {
                        cls.Insert();

                    }
                    else
                    {
                        cls.iID_ChiTietPhieu = Convert.ToInt32(dt_Change_.Rows[i]["ID_ChiTietPhieu_DOT"].ToString());
                        cls.Update();
                    }
                    int iiiDID_ChiTietPhieuxxx;
                    iiiDID_ChiTietPhieuxxx = cls.iID_ChiTietPhieu.Value;
                    TaoLenhSanXuat(_Loaimay, xxID_Sophieu_, iiiDID_ChiTietPhieuxxx, xxidccatruong, xxidcongnhan, xxngaysxxx, xxcasxxx, xxid_vtvao, xxid_Vt_Ra, xxSoLuong_Vaoxx,
                      xxsanluongthuongxx, xxxxSanLuong_TangCaxx, xxxxPhePham);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Luu_DuLieu(int xxloaimay)
        {
            try
            {
                if (!KiemTra_Luu_DuLieu(_Loaimay)) return;
                else
                {
                    DataTable dt2 = (DataTable)gridControl1.DataSource;

                    if (xxloaimay == 1)
                    {
                        Luu_DuLieu_May_IN();
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                dt2.Rows[i]["Change_IN"] = "0";
                            }
                            gridControl1.DataSource = dt2;
                        }
                    }
                    else if (xxloaimay == 2)
                    {
                        Luu_DuLieu_May_CAT();
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                dt2.Rows[i]["Change_CAT"] = "0";
                            }
                            gridControl1.DataSource = dt2;
                        }
                    }
                    else if (xxloaimay == 3)
                    {
                        Luu_DuLieu_May_DOT();
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                dt2.Rows[i]["Change_DOT"] = "0";
                            }
                            gridControl1.DataSource = dt2;
                        }
                    }

                    LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime);

                }
                MessageBox.Show("Đã lưu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TaoLenhSanXuat(int xxID_LoaiMay, int xxIDSoPhieu, int iiiDID_ChiTietPhieu, int xxid_Catruong, int xxid_congnhan, DateTime ngaysanxuat, string casanxuat, int xxID_VTHH_Vao, int xxID_VTHH_Ra, double xxSoLuong_Vao, double xxSanLuong_Thuong, double xxSanLuong_TangCa, double xxPhePham)
        {
            try
            {
                clsHUU_LenhSanXuat clsLSX = new clsHUU_LenhSanXuat();
                clsLSX.iID_CaTruong = xxid_Catruong;
                clsLSX.iID_LoaiMay = xxID_LoaiMay;
                clsLSX.iID_CongNhan = xxid_congnhan;
                clsLSX.daNgayThangSanXuat = ngaysanxuat;
                clsLSX.sCaSanXuat = casanxuat;
                DataTable dxLSX1 = clsLSX.SelectAll_TaoLenhSX_May_CaTruong_CongNhan_Ngay_CaSX_May_IN();
                int ID_LenhSanXuatxx;
                if (dxLSX1.Rows.Count > 0)
                {
                    ID_LenhSanXuatxx = Convert.ToInt32(dxLSX1.Rows[0]["ID_LenhSanXuat"].ToString());
                }
                else
                {
                    clsHUU_LenhSanXuat cls1 = new CtyTinLuong.clsHUU_LenhSanXuat();
                    DataTable xxxdv3 = cls1.SelectAll();
                    int k = xxxdv3.Rows.Count;
                    string MaLenhSanXuat;
                    if (xxxdv3.Rows.Count == 0)
                        MaLenhSanXuat = "LSX1";
                    else
                    {
                        string xxx = xxxdv3.Rows[k - 1]["MaLenhSanXuat"].ToString();
                        int xxx2 = Convert.ToInt16(xxx.Substring(3).Trim()) + 1;
                        MaLenhSanXuat = "LSX" + xxx2 + "";
                    }

                    // them moi lenh SX 
                    clsLSX.iID_CaTruong = xxid_Catruong;
                    clsLSX.iID_LoaiMay = xxID_LoaiMay;
                    clsLSX.iID_CongNhan = xxid_congnhan;
                    clsLSX.iID_NguoiLap = 12;
                    clsLSX.daNgayThangSanXuat = ngaysanxuat;
                    clsLSX.sCaSanXuat = casanxuat;
                    clsLSX.sGhiChu = "";
                    clsLSX.bTonTai = true;
                    clsLSX.bNgungTheoDoi = false;
                    clsLSX.sMaLenhSanXuat = MaLenhSanXuat;
                    clsLSX.bGuiDuLieu = false;
                    if (xxID_LoaiMay == 1)
                    {
                        clsLSX.bBoolMayIn = true;
                        clsLSX.bBoolMayCat = false;
                        clsLSX.bBoolMayDot = false;
                    }
                    else if (xxID_LoaiMay == 2)
                    {
                        clsLSX.bBoolMayIn = false;
                        clsLSX.bBoolMayCat = true;
                        clsLSX.bBoolMayDot = false;
                    }
                    else if (xxID_LoaiMay == 3)
                    {
                        clsLSX.bBoolMayIn = false;
                        clsLSX.bBoolMayCat = false;
                        clsLSX.bBoolMayDot = true;
                    }
                    clsLSX.bTrangThai_NhapKho_May_IN = false;
                    clsLSX.bTrangThai_XuatKho_May_IN = false;
                    clsLSX.bTrangThai_NhapKho_May_CAT = false;
                    clsLSX.bTrangThai_XuatKho_May_CAT = false;
                    clsLSX.bTrangThai_NhapKho_May_DOT = false;
                    clsLSX.bTrangThai_XuatKho_May_DOT = false;
                    clsLSX.Insert();
                    ID_LenhSanXuatxx = clsLSX.iID_LenhSanXuat.Value;

                }

                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                cls.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
                cls.Update_TrangThaiTaoLenhSanXuat();

                clsHUU_LenhSanXuat_ChiTietLenhSanXuat clsLSX_chitiet = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                clsLSX_chitiet.iID_LenhSanXuat = ID_LenhSanXuatxx;
                clsLSX_chitiet.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
                clsLSX_chitiet.iID_SoPhieu = xxIDSoPhieu;
                clsLSX_chitiet.iID_VTHHVao = xxID_VTHH_Vao;
                clsLSX_chitiet.fSoLuongVao = xxSoLuong_Vao;
                clsLSX_chitiet.iID_VTHHRa = xxID_VTHH_Ra;
                clsLSX_chitiet.fSanLuongThuong = xxSanLuong_Thuong;
                clsLSX_chitiet.fSanLuongTangCa = xxSanLuong_TangCa;
                clsLSX_chitiet.fPhePham = xxPhePham;
                clsLSX_chitiet.fDonGiaVao = 0;
                clsLSX_chitiet.fDonGiaRa = 0;
                clsLSX_chitiet.bNgungTheoDoi = false;
                clsLSX_chitiet.bTonTai = true;

                clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
                cls2.iID_LenhSanXuat = ID_LenhSanXuatxx;
                cls2.iID_ChiTietPhieu = iiiDID_ChiTietPhieu;
                cls2.iID_SoPhieu = xxIDSoPhieu;
                DataTable dt2 = cls2.SelectAll_ID_LenhSanXuat_ID_ChiTietPhieu_ID_SoPhieu();
                if (dt2.Rows.Count > 0)
                {
                    clsLSX_chitiet.iID_ChiTietLenhSanXuat = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietLenhSanXuat"].ToString());
                    clsLSX_chitiet.Update();
                }
                else
                {
                    clsLSX_chitiet.Insert();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        public PhieuSanXuat_IN_CAT_New_thang8()
        {
            InitializeComponent();
        }
      
        private void PhieuSanXuat_IN_CAT_New_thang8_Load(object sender, EventArgs e)
        {
            try
            {
                dteDenNgay.DateTime = DateTime.Today;
                dteTuNgay.DateTime = DateTime.Today.AddDays(-7);
                gridMacDinh_Luong.EditValue = 8;
                _SoDong = Convert.ToInt32(txtSoDong.Text);
                dteNgayMacDinh.DateTime = DateTime.Today;
                gridLoaiMay.EditValue = 1;
                _Loaimay = 1;
                HienThi_Pannel(_Loaimay);
                Load_LockUp();


                clSanLuong_Tong_IN.Caption = "Sản\nlượng";
                clID_DinhMuc_Luong_IN.Caption = "ĐM\nlương";
                clSanLuong_Tong_CAT.Caption = "Sản\nlượng";
                clID_DinhMuc_Luong_CAT.Caption = "ĐM\nlương";
                clSanLuong_Tong_DOT.Caption = "Sản\nlượng";
                clID_DinhMuc_Luong_DOT.Caption = "ĐM\nlương";
                clID_CaTruong_IN.Caption = "Ca\ntrưởng";
                clID_CaTruong_CAT.Caption = "Ca\ntrưởng";
                clID_CaTruong_DOT.Caption = "Ca\ntrưởng";

                clID_VTHH_Ra_CAT.Width = clID_VTHH_Ra_DOT.Width = clID_VTHH_Ra_IN.Width = clID_VTHH_Vao_CAT.Width = clID_VTHH_Vao_DOT.Width = clID_VTHH_Vao_IN.Width = 65;
                clDonViTinh_Ra_DOT.Width = clDonViTinh_Ra_IN.Width = clDonViTinh_Vao_CAT.Width = clDonViTinh_Vao_DOT.Width = clDonViTinh_Vao_IN.Width = 45;
                clSoLuong_Vao_CAT.Width = clSoLuong_Vao_DOT.Width = clSoLuong_Vao_IN.Width = 60;
                clSoKG_MotBao_May_Dot.Width = clDoCao_Dot.Width = clPhePham_CAT.Width = clPhePham_DOT.Width = clPhePham_IN.Width = 50;
                clNgayLapPhieu.Width = clNgaySanXuat_IN.Width = clNgaySanXuat_CAT.Width = clNgaySanXuat_DOT.Width = 65;
                clCaSanXuat_CAT.Width = clCaSanXuat_DOT.Width = clCaSanXuat_IN.Width = 40;
                clID_May_CAT.Width = clID_May_DOT.Width = clID_May_IN.Width = 50;
                clID_CaTruong_CAT.Width = clID_CaTruong_DOT.Width = clID_CaTruong_IN.Width = 60;
                clID_DinhMuc_Luong_DOT.Width = clID_DinhMuc_Luong_CAT.Width = clID_DinhMuc_Luong_IN.Width = 65;

                clXoa.Width = clDot.Width = 35;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                HienThi_Pannel(_Loaimay);
                txtSoTrang.Text = "1";
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime);                
                Cursor.Current = Cursors.Default;               

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luu_DuLieu(_Loaimay) == true)
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        Luu_DuLieu(_Loaimay);
                    }

                }

                _SoDong = Convert.ToInt32(txtSoDong.Text);

                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (_Loaimay == 1)
                {
                    #region in
                    if (e.Column == clMaPhieu)
                    {
                        if (bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString() != "")
                        {
                            string smaphieu = bandedGridView1.GetRowCellValue(e.RowHandle, clMaPhieu).ToString();
                            DateTime ngaysanxuat = Convert.ToDateTime(bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString());
                            if (KiemTra_TrungMaPhieu(smaphieu, ngaysanxuat, true, false, false) == false)
                            {
                                bandedGridView1.SetRowCellValue(e.RowHandle, clMaPhieu, "");
                                return;
                            }
                            else bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                        }
                    }
                    if (e.Column == clID_VTHH_Vao_IN)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_IN, sTenVTHH_vao_IN);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_IN, sDonViTinh_vao_IN);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                    }

                    if (e.Column == clID_VTHH_Ra_IN)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_IN, sTenVTHH_ra_IN);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_IN, sDonViTinh_ra_IN);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                    }
                    if (e.Column == clNgayLapPhieu || e.Column == clNgaySanXuat_IN || e.Column == clCaSanXuat_IN || e.Column == clID_May_IN || e.Column == clSoLuong_Vao_IN || e.Column == clID_CongNhan_IN || e.Column == clID_DinhMuc_Luong_IN || e.Column == clID_CaTruong_IN)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
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
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                    }
                    #endregion
                }
                else if (_Loaimay == 2)
                {
                    #region cat
                    //if (e.Column == clMaPhieu)
                    //{
                    //    if (bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString() != "")
                    //    {
                    //        string smaphieu = bandedGridView1.GetRowCellValue(e.RowHandle, clMaPhieu).ToString();
                    //        DateTime ngaysanxuat = Convert.ToDateTime(bandedGridView1.GetRowCellValue(e.RowHandle, clNgayLapPhieu).ToString());
                    //        if (KiemTra_TrungMaPhieu(smaphieu, ngaysanxuat) == false)
                    //        {
                    //            bandedGridView1.SetRowCellValue(e.RowHandle, clMaPhieu, "");
                    //            return;
                    //        }
                    //        else bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                    //    }
                    //}
                    if (e.Column == clID_VTHH_Vao_CAT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_CAT, sTenVTHH_vao_CAT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_CAT, sDonViTinh_vao_CAT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_CAT, "1");
                    }

                    if (e.Column == clID_VTHH_Ra_CAT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_CAT, sTenVTHH_ra_CAT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_CAT, sDonViTinh_ra_CAT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_CAT, "1");
                    }
                    if (e.Column == clNgaySanXuat_CAT || e.Column == clCaSanXuat_CAT || e.Column == clID_May_CAT || e.Column == clSoLuong_Vao_CAT || e.Column == clID_CongNhan_CAT || e.Column == clID_DinhMuc_Luong_CAT || e.Column == clID_CaTruong_CAT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_CAT, "1");
                    }
                    if (e.Column == clSanLuong_Tong_CAT)
                    {
                        double xsanluongtong = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_CAT).ToString());
                        int xiD_dinhMucluong = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_CAT).ToString());
                        int xidcongnhan = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_CAT).ToString());
                        int xidvthhra = CheckString.ConvertTo_Int_My(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_CAT).ToString());
                        DateTime xngaysanxuat = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgayLapPhieu).ToString());
                        string xcasanxuat = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat_CAT).ToString();

                        Tinh_SanLuong(xsanluongtong, xiD_dinhMucluong, xidcongnhan, xidvthhra, xngaysanxuat, xcasanxuat);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_Thuong_CAT, sanluongthuong_);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clSanLuong_TangCa_CAT, sanluongtangca_);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_CAT, "1");
                    }
                    #endregion 
                }
                else if (_Loaimay == 3)
                {
                    #region dot
                    if (e.Column == clID_VTHH_Vao_DOT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_DOT, sTenVTHH_vao_DOT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_DOT, sDonViTinh_vao_DOT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }

                    if (e.Column == clID_VTHH_Ra_DOT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_DOT, sTenVTHH_ra_DOT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_DOT, sDonViTinh_ra_DOT);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }
                    if ( e.Column == clNgaySanXuat_DOT || e.Column == clCaSanXuat_DOT || e.Column == clID_May_DOT || e.Column == clSoLuong_Vao_DOT || e.Column == clID_CongNhan_DOT || e.Column == clID_DinhMuc_Luong_DOT || e.Column == clID_CaTruong_DOT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }
                    if (e.Column == clSanLuong_Tong_DOT)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }
                    if (e.Column == clDoCao_Dot)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }
                    if (e.Column == clSoKG_MotBao_May_Dot)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                    }
                    #endregion
                }                
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (checkthemmoi.Checked == true)
                {
                    if (_Loaimay == 1)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clNgayLapPhieu, daNgayMacdinh);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clNgaySanXuat_IN, daNgayMacdinh);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong_IN, iMacDinh_Luong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_CaTruong_IN, iMacDinh_CaTruong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clCaSanXuat_IN, sMacDinh_CaSX);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_IN, "1");
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Vao_IN, iMacDinh_VTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Ra_IN, iMacDinh_VTHH_Ra);

                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_IN, sMacDinh_TenVTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_IN, sMacDinh_DVT_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_IN, sMacDinh_TenVTHH_Ra);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_IN, sMacDinh_DVT_Ra);
                    }
                    else if (_Loaimay == 2)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clNgaySanXuat_CAT, daNgayMacdinh);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong_CAT, iMacDinh_Luong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_CaTruong_CAT, iMacDinh_CaTruong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clCaSanXuat_CAT, sMacDinh_CaSX);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_CAT, "1");
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Vao_CAT, iMacDinh_VTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Ra_CAT, iMacDinh_VTHH_Ra);

                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_CAT, sMacDinh_TenVTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_CAT, sMacDinh_DVT_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_CAT, sMacDinh_TenVTHH_Ra);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_CAT, sMacDinh_DVT_Ra);
                    }
                    else if (_Loaimay == 3)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clNgaySanXuat_DOT, daNgayMacdinh);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong_DOT, iMacDinh_Luong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_CaTruong_DOT, iMacDinh_CaTruong);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clCaSanXuat_DOT, sMacDinh_CaSX);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clChange_DOT, "1");
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Vao_DOT, iMacDinh_VTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clID_VTHH_Ra_DOT, iMacDinh_VTHH_Ra);

                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Vao_DOT, sMacDinh_TenVTHH_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Vao_DOT, sMacDinh_DVT_Vao);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTenVTHH_Ra_DOT, sMacDinh_TenVTHH_Ra);
                        bandedGridView1.SetRowCellValue(e.RowHandle, clDonViTinh_Ra_DOT, sMacDinh_DVT_Ra);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sMacDinh_CaSX = cbCaSXMacDinh.Text;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCaTruongMacDinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                iMacDinh_CaTruong = (int)cbCaTruongMacDinh.SelectedValue;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void dteNgayMacDinh_EditValueChanged(object sender, EventArgs e)
        {
            daNgayMacdinh = dteNgayMacDinh.DateTime;
        }

        private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {      
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    string change = "", sstesst = "";
                    if (_Loaimay == 1)
                    {
                        change = View.GetRowCellValue(e.RowHandle, View.Columns["Change_IN"]).ToString();
                        sstesst = View.GetRowCellValue(e.RowHandle, View.Columns["Test_IN"]).ToString();
                    }
                    else if (_Loaimay == 2)
                    {
                        change = View.GetRowCellValue(e.RowHandle, View.Columns["Change_CAT"]).ToString();
                        sstesst = View.GetRowCellValue(e.RowHandle, View.Columns["Test_CAT"]).ToString();

                    }
                    else if (_Loaimay == 3)
                    {
                        change = View.GetRowCellValue(e.RowHandle, View.Columns["Change_DOT"]).ToString();
                        sstesst = View.GetRowCellValue(e.RowHandle, View.Columns["Test_DOT"]).ToString();

                    }
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (_Loaimay == 1)
                {
                    if (KiemTra_Hang(_Loaimay) == false)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTest_IN, "1");
                    }
                    else bandedGridView1.SetRowCellValue(e.RowHandle, clTest_IN, "0");
                }
                else if (_Loaimay == 2)
                {
                    if (KiemTra_Hang(_Loaimay) == false)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTest_CAT, "1");
                    }
                    else bandedGridView1.SetRowCellValue(e.RowHandle, clTest_CAT, "0");

                }
                else if (_Loaimay == 3)
                {
                    if (KiemTra_Hang(_Loaimay) == false)
                    {
                        bandedGridView1.SetRowCellValue(e.RowHandle, clTest_DOT, "1");
                    }
                    else bandedGridView1.SetRowCellValue(e.RowHandle, clTest_DOT, "0");

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMacDinh_Luong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                iMacDinh_Luong = (int)gridMacDinh_Luong.EditValue;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
         
            if (KiemTra_Luu_DuLieu(_Loaimay) == true)
            {
                Luu_DuLieu(_Loaimay);
            }
            else MessageBox.Show("Đã lưu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bandedGridView1.GetFocusedRowCellValue(clID_SoPhieu).ToString() != "")
                {
                    string maPhieu = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();

                    DialogResult traloi = MessageBox.Show("Xóa hết dữ liệu phiếu: " + maPhieu + "", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int xxiID_SoPhieu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_SoPhieu).ToString());

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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Vao_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Vao_CAT = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_vao_CAT = row["TenVTHH"].ToString();
                sDonViTinh_vao_CAT = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Vao_DOT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Vao_DOT = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_vao_DOT = row["TenVTHH"].ToString();
                sDonViTinh_vao_DOT = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Ra_CAT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Ra_CAT = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_ra_CAT = row["TenVTHH"].ToString();
                sDonViTinh_ra_CAT = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Ra_DOT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Ra_DOT = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_ra_DOT = row["TenVTHH"].ToString();
                sDonViTinh_ra_DOT = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMacDinh_VatTu_Vao_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((GridLookUpEdit)sender).GetSelectedDataRow()).Row;
                iMacDinh_VTHH_Vao=Convert.ToInt32(row["ID_VTHH"].ToString());
                sMacDinh_TenVTHH_Vao = row["TenVTHH"].ToString();
                sMacDinh_DVT_Vao = row["DonViTinh"].ToString();
                //MessageBox.Show("id: " + iMacDinh_VTHH_Vao.ToString() + " ten: " + sMacDinh_TenVTHH_Vao + ", dvt: " + sMacDinh_DVT_Vao + "");
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMacDinh_VatTu_Ra_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((GridLookUpEdit)sender).GetSelectedDataRow()).Row;
                iMacDinh_VTHH_Ra = Convert.ToInt32(row["ID_VTHH"].ToString());
                sMacDinh_TenVTHH_Ra = row["TenVTHH"].ToString();
                sMacDinh_DVT_Ra = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
        }

        private void btDot_Click(object sender, EventArgs e)
        {
            try
            {
                if (bandedGridView1.GetFocusedRowCellValue(clID_SoPhieu).ToString() != "")
                {
                    int xxiID_SoPhieu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_SoPhieu).ToString());
                    int xxidcatruong = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_DOT).ToString());
                    string casxxx = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat_DOT).ToString();
                    DateTime ngaythangxx = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat_DOT).ToString());
                    BoSungCongNhanMayDot ff = new BoSungCongNhanMayDot(xxiID_SoPhieu, xxidcatruong, casxxx, ngaythangxx);
                    ff.Show();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Vao_IN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)71)
            //{
            //    MessageBox.Show("helo");
            //}
        }

        private void btCpopy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //GridView gridView = gridControl1.FocusedView as GridView;
            //DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);            
            //MessageBox.Show(row.ToString());
        }

        private void bandedGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void bandedGridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //if (e.FocusedColumn == clID_VTHH_Vao_IN)
            //{
            //    gridMaVT_Vao_IN.ShowPopup();
            //}
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luu_DuLieu(_Loaimay) == true)
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        Luu_DuLieu(_Loaimay);
                    }
                }
                this.Close();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhieuSanXuat_IN_CAT_New_thang8_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (KiemTra_Luu_DuLieu(_Loaimay) == true)
            //{
            //    DialogResult traloi;
            //    traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (traloi == DialogResult.Yes)
            //    {
            //        Luu_DuLieu(_Loaimay);
            //    }

            //}
        }

        DateTime ngaylap = DateTime.Today;
        string sssmaphieu = "";

        DateTime ngaysx_IN = DateTime.Today;
        string ssscasx_IN = "";
        double dddsoluongvao_IN = 0, dddsanluongtong_IN = 0, dddphepham_IN = 0;

        private void btCpopy_Click(object sender, EventArgs e)
        {
            try
            {
                int id_soPhieu = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_SoPhieu).ToString());
                string smaphieu__ = bandedGridView1.GetFocusedRowCellValue(clMaPhieu).ToString();
                iID_VTHH_Vao_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Vao_CAT).ToString());
                sTenVTHH_vao_CAT = bandedGridView1.GetFocusedRowCellValue(clTenVTHH_Vao_CAT).ToString();
                sDonViTinh_vao_CAT = bandedGridView1.GetFocusedRowCellValue(clDonViTinh_Vao_CAT).ToString();
                dddsoluongvao_CAT = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuong_Vao_CAT).ToString());
                ngaysx_CAT = Convert.ToDateTime(bandedGridView1.GetFocusedRowCellValue(clNgaySanXuat_CAT).ToString());
                ssscasx_CAT = bandedGridView1.GetFocusedRowCellValue(clCaSanXuat_CAT).ToString();
                iimaysx_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_May_CAT).ToString());
                iiiID_catruong_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CaTruong_CAT).ToString());

                iID_VTHH_Ra_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_VTHH_Ra_CAT).ToString());
                sTenVTHH_ra_CAT = bandedGridView1.GetFocusedRowCellValue(clTenVTHH_Ra_CAT).ToString();
                sDonViTinh_ra_CAT = bandedGridView1.GetFocusedRowCellValue(clDonViTinh_Ra_CAT).ToString();
                iiiidID_CongNhan_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_CongNhan_CAT).ToString());
                iiiD_dmluong_CAT = Convert.ToInt32(bandedGridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_CAT).ToString());
                dddsanluongtong_CAT = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSanLuong_Tong_CAT).ToString());
                dddphepham_CAT = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clPhePham_CAT).ToString());

                bandedGridView1.AddNewRow();
                //set a new row cell value. The static GridControl.NewItemRowHandle field allows you to retrieve the added row
                //bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, bandedGridView1.Columns["MaPhieu"], "test máy cắt");
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_ChiTietPhieu_CAT, "");
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_SoPhieu, id_soPhieu);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clMaPhieu, smaphieu__);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_VTHH_Vao_CAT, iID_VTHH_Vao_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clTenVTHH_Vao_CAT, sTenVTHH_vao_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clDonViTinh_Vao_CAT, sDonViTinh_vao_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clSoLuong_Vao_CAT, dddsoluongvao_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clNgaySanXuat_CAT, ngaysx_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clCaSanXuat_CAT, ssscasx_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_May_CAT, iimaysx_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_CaTruong_CAT, iiiID_catruong_CAT);

                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_VTHH_Ra_CAT, iID_VTHH_Ra_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clTenVTHH_Ra_CAT, sTenVTHH_ra_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clDonViTinh_Ra_CAT, sDonViTinh_ra_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_CongNhan_CAT, iiiidID_CongNhan_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clID_DinhMuc_Luong_CAT, iiiD_dmluong_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clSanLuong_Tong_CAT, dddsanluongtong_CAT);
                bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, clPhePham_CAT, dddphepham_CAT);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkthemmoi_CheckedChanged(object sender, EventArgs e)
        {

        }

        int iimaysx_IN = 0, iiiID_catruong_IN = 0, iiiidID_CongNhan_IN = 0, iiiD_dmluong_IN = 0;

        DateTime ngaysx_CAT = DateTime.Today;
        string ssscasx_CAT = "";
        double dddsoluongvao_CAT = 0, dddsanluongtong_CAT = 0, dddphepham_CAT = 0;
        int iimaysx_CAT = 0, iiiID_catruong_CAT = 0, iiiidID_CongNhan_CAT = 0, iiiD_dmluong_CAT = 0;

        DateTime ngaysx_DOT = DateTime.Today;
        string ssscasx_DOT = "";
        double dddsoluongvao_DOT = 0, dddsanluongtong_DOT = 0, dddphepham_DOT = 0, xxsokgmotbao_dot=0, xxdocao_dot=0;
        int iimaysx_DOT = 0, iiiID_catruong_DOT = 0, iiiidID_CongNhan_DOT = 0, iiiD_dmluong_DOT = 0;

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                GridControl grid = sender as GridControl;
                GridView view = grid.FocusedView as GridView;
                GridView gridView = gridControl1.FocusedView as GridView;
                DataRow row = gridView.GetDataRow(bandedGridView1.FocusedRowHandle);


                if (bandedGridView1.FocusedRowHandle == bandedGridView1.RowCount - 1)
                    return;
                else if (e.Control && e.KeyCode == Keys.C)
                {

                    if (_Loaimay == 1)
                    {
                        ngaylap = Convert.ToDateTime(row["NgayLapPhieu"].ToString());
                        //sssmaphieu = row["MaPhieu"].ToString();
                        sssmaphieu = "";


                        iID_VTHH_Vao_IN = Convert.ToInt32(row["ID_VTHH_Vao_IN"].ToString());
                        sTenVTHH_vao_IN = row["TenVTHH_Vao_IN"].ToString();
                        sDonViTinh_vao_IN = row["DonViTinh_Vao_IN"].ToString();
                        dddsoluongvao_IN = Convert.ToDouble(row["SoLuong_Vao_IN"].ToString());
                        ngaysx_IN = Convert.ToDateTime(row["NgaySanXuat_IN"].ToString());
                        ssscasx_IN = row["CaSanXuat_IN"].ToString();
                        iimaysx_IN = Convert.ToInt32(row["ID_May_IN"].ToString());
                        iiiID_catruong_IN = Convert.ToInt32(row["ID_CaTruong_IN"].ToString());

                        iID_VTHH_Ra_IN = Convert.ToInt32(row["ID_VTHH_Ra_IN"].ToString());
                        sTenVTHH_ra_IN = row["TenVTHH_Ra_IN"].ToString();
                        sDonViTinh_ra_IN = row["DonViTinh_Ra_IN"].ToString();
                        iiiidID_CongNhan_IN = Convert.ToInt32(row["ID_CongNhan_IN"].ToString());
                        iiiD_dmluong_IN = Convert.ToInt32(row["ID_DinhMuc_Luong_IN"].ToString());
                        dddsanluongtong_IN = Convert.ToDouble(row["SanLuong_Tong_IN"].ToString());
                        dddphepham_IN = Convert.ToDouble(row["PhePham_IN"].ToString());
                        e.Handled = true;
                        Clipboard.SetText("" + iID_VTHH_Vao_IN + "|" + sTenVTHH_vao_IN + "|" + sDonViTinh_vao_IN + "|" + dddsoluongvao_IN + "|" + ngaysx_IN + "|" + iimaysx_IN + "|" + iiiID_catruong_IN + "|" + iID_VTHH_Ra_IN + "|" + sTenVTHH_ra_IN + "|" + sDonViTinh_ra_IN + "|" + iiiidID_CongNhan_IN + "|" + iiiD_dmluong_IN + "|" + dddsanluongtong_IN + "|" + dddphepham_IN + "");

                    }
                    else if (_Loaimay == 2)
                    {
                        iID_VTHH_Vao_CAT = Convert.ToInt32(row["ID_VTHH_Vao_CAT"].ToString());
                        sTenVTHH_vao_CAT = row["TenVTHH_Vao_CAT"].ToString();
                        sDonViTinh_vao_CAT = row["DonViTinh_Vao_CAT"].ToString();
                        dddsoluongvao_CAT = Convert.ToDouble(row["SoLuong_Vao_CAT"].ToString());
                        ngaysx_CAT = Convert.ToDateTime(row["NgaySanXuat_CAT"].ToString());
                        ssscasx_CAT = row["CaSanXuat_CAT"].ToString();
                        iimaysx_CAT = Convert.ToInt32(row["ID_May_CAT"].ToString());
                        iiiID_catruong_CAT = Convert.ToInt32(row["ID_CaTruong_CAT"].ToString());

                        iID_VTHH_Ra_CAT = Convert.ToInt32(row["ID_VTHH_Ra_CAT"].ToString());
                        sTenVTHH_ra_CAT = row["TenVTHH_Ra_CAT"].ToString();
                        sDonViTinh_ra_CAT = row["DonViTinh_Ra_CAT"].ToString();
                        iiiidID_CongNhan_CAT = Convert.ToInt32(row["ID_CongNhan_CAT"].ToString());
                        iiiD_dmluong_CAT = Convert.ToInt32(row["ID_DinhMuc_Luong_CAT"].ToString());
                        dddsanluongtong_CAT = Convert.ToDouble(row["SanLuong_Tong_CAT"].ToString());
                        dddphepham_CAT = Convert.ToDouble(row["PhePham_CAT"].ToString());
                        e.Handled = true;
                    }
                    else if (_Loaimay == 3)
                    {
                        iID_VTHH_Vao_DOT = Convert.ToInt32(row["ID_VTHH_Vao_DOT"].ToString());
                        sTenVTHH_vao_DOT = row["TenVTHH_Vao_DOT"].ToString();
                        sDonViTinh_vao_DOT = row["DonViTinh_Vao_DOT"].ToString();
                        dddsoluongvao_DOT = Convert.ToDouble(row["SoLuong_Vao_DOT"].ToString());
                        ngaysx_DOT = Convert.ToDateTime(row["NgaySanXuat_DOT"].ToString());
                        ssscasx_DOT = row["CaSanXuat_DOT"].ToString();
                        iimaysx_DOT = Convert.ToInt32(row["ID_May_DOT"].ToString());
                        iiiID_catruong_DOT = Convert.ToInt32(row["ID_CaTruong_DOT"].ToString());

                        iID_VTHH_Ra_DOT = Convert.ToInt32(row["ID_VTHH_Ra_DOT"].ToString());
                        sTenVTHH_ra_DOT = row["TenVTHH_Ra_DOT"].ToString();
                        sDonViTinh_ra_DOT = row["DonViTinh_Ra_DOT"].ToString();
                        iiiidID_CongNhan_DOT = Convert.ToInt32(row["ID_CongNhan_DOT"].ToString());
                        iiiD_dmluong_DOT = Convert.ToInt32(row["ID_DinhMuc_Luong_DOT"].ToString());
                        dddsanluongtong_DOT = Convert.ToDouble(row["SanLuong_Tong_DOT"].ToString());
                        dddphepham_DOT = Convert.ToDouble(row["PhePham_DOT"].ToString());

                        xxsokgmotbao_dot = Convert.ToDouble(row["SoKG_MotBao_May_Dot"].ToString());
                        xxdocao_dot = Convert.ToDouble(row["DoCao_Dot"].ToString());
                        e.Handled = true;
                    }
                }
                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (checkthemmoi.Checked == false)
                    {
                        if (e.Handled == false)
                        {
                            bandedGridView1.AddNewRow();
                            bandedGridView1.SetRowCellValue(GridControl.NewItemRowHandle, bandedGridView1.Columns["MaPhieu"], "xxx");
                        }

                    }
                    else
                    {
                        if (_Loaimay == 1)
                        {
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clNgayLapPhieu, ngaylap);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clMaPhieu, sssmaphieu);

                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Vao_IN, iID_VTHH_Vao_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Vao_IN, sTenVTHH_vao_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Vao_IN, sDonViTinh_vao_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSoLuong_Vao_IN, dddsoluongvao_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clNgaySanXuat_IN, ngaysx_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clCaSanXuat_IN, ssscasx_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_May_IN, iimaysx_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CaTruong_IN, iiiID_catruong_IN);

                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Ra_IN, iID_VTHH_Ra_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Ra_IN, sTenVTHH_ra_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Ra_IN, sDonViTinh_ra_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CongNhan_IN, iiiidID_CongNhan_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_DinhMuc_Luong_IN, iiiD_dmluong_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSanLuong_Tong_IN, dddsanluongtong_IN);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clPhePham_IN, dddphepham_IN);

                            e.Handled = true;
                        }
                        else if (_Loaimay == 2)
                        {
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Vao_CAT, iID_VTHH_Vao_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Vao_CAT, sTenVTHH_vao_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Vao_CAT, sDonViTinh_vao_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSoLuong_Vao_CAT, dddsoluongvao_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clNgaySanXuat_CAT, ngaysx_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clCaSanXuat_CAT, ssscasx_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_May_CAT, iimaysx_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CaTruong_CAT, iiiID_catruong_CAT);

                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Ra_CAT, iID_VTHH_Ra_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Ra_CAT, sTenVTHH_ra_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Ra_CAT, sDonViTinh_ra_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CongNhan_CAT, iiiidID_CongNhan_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_DinhMuc_Luong_CAT, iiiD_dmluong_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSanLuong_Tong_CAT, dddsanluongtong_CAT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clPhePham_CAT, dddphepham_CAT);

                            e.Handled = true;
                        }

                        else if (_Loaimay == 3)
                        {
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Vao_DOT, iID_VTHH_Vao_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Vao_DOT, sTenVTHH_vao_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Vao_DOT, sDonViTinh_vao_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSoLuong_Vao_DOT, dddsoluongvao_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clNgaySanXuat_DOT, ngaysx_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clCaSanXuat_DOT, ssscasx_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_May_DOT, iimaysx_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CaTruong_DOT, iiiID_catruong_DOT);

                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_VTHH_Ra_DOT, iID_VTHH_Ra_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clTenVTHH_Ra_DOT, sTenVTHH_ra_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDonViTinh_Ra_DOT, sDonViTinh_ra_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_CongNhan_DOT, iiiidID_CongNhan_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clID_DinhMuc_Luong_DOT, iiiD_dmluong_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSanLuong_Tong_DOT, dddsanluongtong_DOT);
                            //bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clsa, dddsanluongtong_DOT);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clPhePham_DOT, dddphepham_DOT);

                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clSoKG_MotBao_May_Dot, xxsokgmotbao_dot);
                            bandedGridView1.SetRowCellValue(bandedGridView1.FocusedRowHandle, clDoCao_Dot, xxdocao_dot);

                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luu_DuLieu(_Loaimay) == true)
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Đã có sự thay đổi dữ liệu. Có muốn lưu lại", "Lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        Luu_DuLieu(_Loaimay);
                    }

                }

                if (isload)
                    return;
                Load_PhieuSX(false);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Ra_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Ra_IN = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_ra_IN = row["TenVTHH"].ToString();
                sDonViTinh_ra_IN = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_Vao_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                iID_VTHH_Vao_IN = Convert.ToInt32(row["ID_VTHH"].ToString());
                sTenVTHH_vao_IN = row["TenVTHH"].ToString();
                sDonViTinh_vao_IN = row["DonViTinh"].ToString();
               
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
