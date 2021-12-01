﻿using DevExpress.Data.Filtering;
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
    public partial class Tr_frmChiTietXuatContDongKien : Form
    {
        private DataTable _dtDonGiatheoVTHH, _data, _dtCongNhan;
        private int _id_bophan, _id_vthh = 0;

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
            DataTable dt = cls.SA_IDDM_W_SoLuong(soluongxuat,xxID_DMgapdan, dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year);
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

        private string SoCHungTu_DongKien()
        {
            string sochungtu;
            clsDongKien_TbNhapKho cls = new clsDongKien_TbNhapKho();
            DataTable dt1 = cls.SelectAll();

            int k2 = dt1.Rows.Count;
            if (k2 == 0)
                sochungtu = "NKDK 1";
            else
            {
                string xxx = dt1.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "NKDK 1";
                else sochungtu = "NKDK " + xxx2 + "";

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
            txtSoLuongTP.Text = cls.fSoLuongThanhPham_QuyDoi.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtThanhTien.Text = cls.fTongTienHang.Value.ToString();
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
            txtSoLuongTP.Text = cls.fSoLuongThanhPham_QuyDoi.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtThanhTien.Text= cls.fTongTienHang.Value.ToString();
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
        }

        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dt = clsNguoi.T_SelectAll(4);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";


            dt.Dispose();
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
                MessageBox.Show("chưa có người lập");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }

        private void Luu_ChiTiet_XuatContDongKien(int id_XuatCont)
        {
            if (!KiemTraLuu()) return;
            else
            {
                DataTable dt = (DataTable)gridControl1.DataSource;

                clsDongKien_TbXuatKho_XuatContDL_ChiTiet cls2 = new clsDongKien_TbXuatKho_XuatContDL_ChiTiet();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cls2.iID_ChiTietXuatKho = Convert.ToInt32(dt.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_XuatContDongKien = id_XuatCont;
                    cls2.iID_VTHH = Convert.ToInt32(dt.Rows[i]["ID_VTHH"].ToString());

                    int ID_VTHH_ = Convert.ToInt32(dt.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = CheckString.ConvertToDouble_My(dt.Rows[i]["SoLuongXuat"].ToString());
                    cls2.fDonGia = CheckString.ConvertToDouble_My(dt.Rows[i]["DonGia"].ToString());
                    cls2.fThanhTien = CheckString.ConvertToDouble_My(dt.Rows[i]["ThanhTien"].ToString());
                    cls2.sDienGiai = dt.Rows[i]["ThanhTien"].ToString();

                    clsThin cls = new clsThin();
                    DataTable foundRows = cls.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_ID_XuatCont_S(id_XuatCont, ID_VTHH_);
                    if (foundRows.Rows.Count > 0)
                    {
                        cls2.iID_ChiTietXuatKho = Convert.ToInt32(foundRows.Rows[0]["ID_ChiTietXuatKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }

                    cls.Dispose();
                }

                cls2.Dispose();
            }
        }


      
        private void Luu_XuatCont_DongKien()
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
        public Tr_frmChiTietXuatContDongKien(UCDaiLy_XuatKho_GapDan ucDLXKGD)
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

            _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
        }


        private void Tr_frmChiTietXuatContDongKien_Load(object sender, EventArgs e)
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
                int idvthh = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = idvthh;
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia2, getDonGiaTheoIDVHH(idvthh));
                    gridView1.SetRowCellValue(e.RowHandle, clThanhTien2, 0);
                }
            }

            if (e.Column == clNhapKho_TP_1_BTP_2_NPL_3_22222)
            {
                if (gridView1.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() != "")
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi2222, "1");

                if (gridView1.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho TP")
                    gridView1.SetRowCellValue(e.RowHandle, clMaKho, "1");
                else if (gridView1.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho BTP")
                    gridView1.SetRowCellValue(e.RowHandle, clMaKho, "2");
                else if (gridView1.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() == "Kho NPL")
                    gridView1.SetRowCellValue(e.RowHandle, clMaKho, "3");
                else gridView1.SetRowCellValue(e.RowHandle, clMaKho, "");

            }

            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clSoLuong2)
                {
                    if (gridView1.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia2));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);
                }
                if (e.Column == clDonGia2)
                {
                    if (gridView1.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia2));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);

                }
            }
            catch
            {

            }
        }

        private void gridView3_RowClick(object sender, RowClickEventArgs e)
        {
            //if (gridView3.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            if (gridView1.GetFocusedRowCellValue(clID_VTHH2) == null
                || gridView1.GetFocusedRowCellValue(clID_VTHH2).ToString() == "")
                return;
            else
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH2).ToString());
                _id_vthh = iiIDnhapKhp;
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



        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_(dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year, "GapDan");
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


        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column == ID_NhanSu)
        //    {
        //        if (_id_vthh == 0)
        //        {
        //            MessageBox.Show("Vui lòng chọn hàng hóa trước! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (e.Value == null && e.Value.ToString() == "") return;
        //        int id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
        //        int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //        double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));

        //        string tenCN = getTenCN(id_nhansu);
        //        //gridView1.SetRowCellValue(e.RowHandle, ID_NhanSu, id_nhansu);
        //        gridView1.SetRowCellValue(e.RowHandle, TenNhanVien, tenCN);

        //        ////
        //        //try
        //        //{
        //        //    using (clsThin clsThin_ = new clsThin())
        //        //    {
        //        //        if (id_ChamCong == 0)
        //        //        {
        //        //            if (checkIDCNisTonTai(id_nhansu))
        //        //            {
        //        //                MessageBox.Show("Không thể thêm công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
        //        //                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //                return;
        //        //            }

        //        //            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
        //        //            id_nhansu,
        //        //            dteNgayChungTu.DateTime.Day,
        //        //            dteNgayChungTu.DateTime.Month,
        //        //            dteNgayChungTu.DateTime.Year,
        //        //            _id_vthh,
        //        //            (float)sanluong_,
        //        //            0, true, false, _id_bophan, 0, 1);
        //        //            LoadDataChamCongCN(_id_vthh);
        //        //        }
        //        //        else
        //        //        {
        //        //            if (checkIDCN_Update(id_ChamCong, id_nhansu)) return;
        //        //            else
        //        //            {
        //        //                if (checkIDCNisTonTai(id_nhansu))
        //        //                {
        //        //                    MessageBox.Show("Không thể chọn công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
        //        //                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //                    return;
        //        //                }
        //        //            }

        //        //            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
        //        //            id_nhansu,
        //        //            dteNgayChungTu.DateTime.Day,
        //        //            dteNgayChungTu.DateTime.Month,
        //        //            dteNgayChungTu.DateTime.Year,
        //        //            _id_vthh,
        //        //            (float)sanluong_,
        //        //            0, true, false, _id_bophan, 0, 1,
        //        //            id_ChamCong);
        //        //        }
        //        //    }
        //        //}
        //        //catch
        //        //{
        //        //    MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCN
        //        //        + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //}
        //    }
        //    else if (e.Column == SanLuong)
        //    {
        //        if (_id_vthh == 0)
        //        {
        //            MessageBox.Show("Vui lòng chọn hàng hóa trước! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (e.Value != null && e.Value.ToString() != "" && !(gridView4.GetRowCellValue(e.RowHandle, ID_NhanSu) is DBNull))
        //        {
        //            int ID_ChiTietChamCong_ToGapDan_ = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //            int id_nhansu;
        //            try
        //            {
        //                id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
        //            }
        //            catch
        //            {
        //                return;
        //            }

        //            int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //            double dongia = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, DonGia));
        //            double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));

        //            //
        //            gridView1.SetRowCellValue(e.RowHandle, ThanhTien, sanluong_* dongia);

        //            if (ID_ChiTietChamCong_ToGapDan_ == 0)
        //                tinhTongSL(sanluong_);
        //            else
        //                tinhTongSL(0);

        //            ////
        //            //try
        //            //{
        //            //    using (clsThin clsThin_ = new clsThin())
        //            //    {
        //            //        clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
        //            //        id_nhansu,
        //            //        dteNgayChungTu.DateTime.Day,
        //            //        dteNgayChungTu.DateTime.Month,
        //            //        dteNgayChungTu.DateTime.Year,
        //            //        _id_vthh,
        //            //        (float)sanluong_,
        //            //        0, true, false, _id_bophan, 0, 1,
        //            //        id_ChamCong);
        //            //    }
        //            //}
        //            //catch
        //            //{
        //            //    MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + getTenCN(id_nhansu)
        //            //        + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //}
        //        }
        //    }
        //}

        private void tinhTongSL(double tongIn)
        {
            double TongSL = tongIn;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                TongSL += CheckString.ConvertToDouble_My(this.gridView1.GetRowCellValue(i, "SanLuong"));
            }

            txtSoLuongTP.Text = TongSL.ToString("N0");
        }


        private void btnXoaGridv1_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;

                //if (gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan) == null
                //    ||gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "" 
                //    || gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "0")
                //{
                //    return;
                //}

                ////int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NhanSu).ToString());
                //int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

                //DialogResult traloi;
                //traloi = MessageBox.Show("Xác nhận xóa công nhân: " + gridView1.GetFocusedRowCellValue(TenNhanVien).ToString(), "Delete",
                //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (traloi == DialogResult.Yes)
                //{
                //    using (clsThin clsThin_ = new clsThin())
                //    {
                //        if(clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(ID_ChiTietChamCong_TGD))
                //        {
                //            LoadDataChamCongCN(_id_vthh);
                //        }
                //    }

                //}

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Lỗi xóa công nhân khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonGiaTP_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                //Hienthi_thanhTien_thanhpham();
                //decimal value = decimal.Parse(txtDonGiaTP.Text);
                //txtDonGiaTP.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtThanhTien.Text);
                //txtThanhTien.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

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
