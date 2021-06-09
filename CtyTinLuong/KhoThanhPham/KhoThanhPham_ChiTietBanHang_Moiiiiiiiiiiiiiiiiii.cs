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
    public partial class KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii : Form
    {

        int bienthangthai;
       
       
        public static DateTime mdaNgayChungTu;
        public static double mdbSoLuongXuat;
        public static bool mbPrint_XuatKho, mbPrint_HoaDon;
        public static DataTable mdtPrint;
        public static string msDiaChi, msDienGiai, msNguoiNhanHang, msSoChungTu, msSoTienBangChu, msSoTKCo, msSoTKNo;
        public static double mdbGiaHanNo, mdbNoCu, mdbNoMoi, mdbSoTienCo, mdbSoTienNo, mdbTienChuaVAT, mdbTienVAT, mdbTongTienVAT, mdbTongNo;
        public void HienThiSoChungTu(int bientrangthaikkkkkkkkkk)
        {
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SelectAll();
            if (bientrangthaikkkkkkkkkk == 1)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BC 1";
                    else txtsochungtu_tbThuChi.Text = "BC " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 2)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BN 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BN 1";
                    else txtsochungtu_tbThuChi.Text = "BN " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 3)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PC 1";
                    else txtsochungtu_tbThuChi.Text = "PC " + xxx2 + "";
                }
            }
            else if (bientrangthaikkkkkkkkkk == 4)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PT 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PT 1";
                    else txtsochungtu_tbThuChi.Text = "PT " + xxx2 + "";
                }
            }
        }
        private void Luu_BienDongTaiKhoan(int xxxxID_BanHang)
        {
            if (!KiemTraLuu()) return;
            else
            {
               
                clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();             
                clsxx.iID_ChungTu = xxxxID_BanHang;
                clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                clsxx.daNgayThang = dteNgayChungTu.DateTime;
              
                DataTable dt2_cu = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
                if(dt2_cu.Rows.Count>0)
                {
                    for(int i=0; i< dt2_cu.Rows.Count; i++)
                    {
                        clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                        clsxx.bTonTai = false;
                        clsxx.Update_W_TonTai();
                    }
                }
               
                string shienthixxx = "1";
                DataTable dtttttcccc2 = (DataTable)gridControl2.DataSource;
                dtttttcccc2.DefaultView.RowFilter = "HienThi=" + shienthixxx + "";
                DataView dvccc222 = dtttttcccc2.DefaultView;
                DataTable dv3cccccc = dvccc222.ToTable();
                
                if (dv3cccccc.Rows.Count > 0)
                {
                    int ID_TaiKhoanKeToanConxxxx1= Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                    clsxx.iID_ChungTu = xxxxID_BanHang;
                    clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    clsxx.daNgayThang = dteNgayChungTu.DateTime;
                    clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                    if (dv3cccccc.Rows[0]["Co"].ToString() != "")
                        clsxx.fCo = Convert.ToDouble(dv3cccccc.Rows[0]["Co"].ToString());
                    else clsxx.fCo = 0;
                    if (dv3cccccc.Rows[0]["No"].ToString() != "")
                        clsxx.fNo = Convert.ToDouble(dv3cccccc.Rows[0]["No"].ToString());
                    else clsxx.fNo = 0;
                    clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[0]["TienUSD"].ToString());
                    if (dv3cccccc.Rows[0]["TiGia"].ToString() != "")
                        clsxx.fTiGia = Convert.ToDouble(dv3cccccc.Rows[0]["TiGia"].ToString());
                    else clsxx.fTiGia = 0;
                    clsxx.bTonTai = true;
                    clsxx.bNgungTheoDoi = false;
                    clsxx.bDaGhiSo = true;
                    clsxx.bBBool_TonDauKy = false;
                    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 2;
                    clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                    clsxx.sDienGiai = txtDienGiai.Text.ToString();

                    string expressionnhapkho;
                    expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx1 + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                        clsxx.Update();
                    }
                    else
                    {
                        clsxx.Insert();
                    }

                   
                    if (dv3cccccc.Rows.Count >= 2)
                    {
                        int ID_TaiKhoanKeToanConxxxx2 = Convert.ToInt32(dv3cccccc.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                        clsxx.iID_ChungTu = xxxxID_BanHang;
                        clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                        clsxx.daNgayThang = dteNgayChungTu.DateTime;
                        clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                        if (dv3cccccc.Rows[1]["Co"].ToString() != "")
                            clsxx.fCo = Convert.ToDouble(dv3cccccc.Rows[1]["Co"].ToString());
                        else clsxx.fCo = 0;
                        if (dv3cccccc.Rows[1]["No"].ToString() != "")
                            clsxx.fNo = Convert.ToDouble(dv3cccccc.Rows[1]["No"].ToString());
                        else clsxx.fNo = 0;
                        clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[1]["TienUSD"].ToString());
                        if (dv3cccccc.Rows[1]["TiGia"].ToString() != "")
                            clsxx.fTiGia = Convert.ToDouble(dv3cccccc.Rows[1]["TiGia"].ToString());
                        else clsxx.fTiGia = 0;
                        clsxx.bTonTai = true;
                        clsxx.bNgungTheoDoi = false;
                        clsxx.bDaGhiSo = true;
                        clsxx.bBBool_TonDauKy = false;
                        clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 4;
                        clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                        clsxx.sDienGiai = txtDienGiai.Text.ToString();
                        string expression222;
                        expression222 = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx2 + "";
                        DataRow[] foundRows222;
                        foundRows222 = dt2_cu.Select(expression222);
                        if (foundRows222.Length > 0)
                        {
                            clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows222[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                            clsxx.Update();
                        }
                        else
                        {
                            clsxx.Insert();
                        }
                      
                        // có tk VAT
                        if (dv3cccccc.Rows.Count == 3)
                        {
                            int ID_TaiKhoanKeToanConxxxx3 = Convert.ToInt32(dv3cccccc.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                            clsxx.iID_ChungTu = xxxxID_BanHang;
                            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                            clsxx.daNgayThang = dteNgayChungTu.DateTime;
                            clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                            if (dv3cccccc.Rows[2]["Co"].ToString() != "")
                                clsxx.fCo = Convert.ToDouble(dv3cccccc.Rows[2]["Co"].ToString());
                            else clsxx.fCo = 0;
                            if (dv3cccccc.Rows[2]["No"].ToString() != "")
                                clsxx.fNo = Convert.ToDouble(dv3cccccc.Rows[2]["No"].ToString());
                            else clsxx.fNo = 0;
                            clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[2]["TienUSD"].ToString());
                            if (dv3cccccc.Rows[2]["TiGia"].ToString() != "")
                                clsxx.fTiGia = Convert.ToDouble(dv3cccccc.Rows[2]["TiGia"].ToString());
                            else clsxx.fTiGia = 0;
                            clsxx.bTonTai = true;
                            clsxx.bNgungTheoDoi = false;
                            clsxx.bDaGhiSo = true;
                            clsxx.bBBool_TonDauKy = false;
                            clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 3;
                            clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                            clsxx.sDienGiai = txtDienGiai.Text.ToString();
                            string expression333;
                            expression333 = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx3 + "";
                            DataRow[] foundRows3333;
                            foundRows3333 = dt2_cu.Select(expression333);
                            if (foundRows3333.Length > 0)
                            {
                                clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows3333[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                                clsxx.Update();
                            }
                            else
                            {
                                clsxx.Insert();
                            }
                        }
                    }
                    
                }
            }
        }

        private void Luu_TbThuChi(int xxxxID_BanHang)
        {
            if (!KiemTraLuu()) return;
            else
            {
                HienThiSoChungTu(bienthangthai);
                
                clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
               
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.fSoTien = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.sDoiTuong = txtTenKH.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = checkUSD.Checked;
                cls1.fTiGia = Convert.ToDouble(txtTiGia.Text.ToString());
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                cls1.bDaGhiSo = false;
                cls1.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                cls1.iBienMuaHang1_BanHang2_ConLai_0 = 2;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                DataTable dt1 = cls1.SelectOne_W_Ngay_ThamChieu_ID_DoiTuong();
                if (dt1.Rows.Count > 0)
                {
                    cls1.sSoChungTu = dt1.Rows[0]["SoChungTu"].ToString();
                    cls1.iID_ThuChi = Convert.ToInt32(dt1.Rows[0]["ID_ThuChi"].ToString());
                    cls1.Update();
                }
                else
                {
                    cls1.sSoChungTu  = txtsochungtu_tbThuChi.Text.ToString();
                    cls1.Insert();
                }
              
            }
        }
        private void HienThi_GridConTrol_SauKhiChon()
        {
            gridControl2.DataSource = null;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietBienDongTaiKhoan", typeof(int));
            dt2xx.Columns.Add("ID_ChungTu", typeof(int));
            dt2xx.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2xx.Columns.Add("No", typeof(double));
            dt2xx.Columns.Add("Co", typeof(double));
            dt2xx.Columns.Add("TienUSD", typeof(bool));
            dt2xx.Columns.Add("TiGia", typeof(double));
            dt2xx.Columns.Add("DaGhiSo", typeof(bool));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("SoTaiKhoanCon");
            dt2xx.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));

            clsTbKhachHang clsncc = new clsTbKhachHang();
            clsncc.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();
            int ID_TaiKhoanKeToanCon = clsncc.iID_TaiKhoanKeToan.Value;
            double tongtienhangcoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
            double tienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
            double tongtienhang_ChuaCoVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
            clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
            DataTable dtcon = clscon.SelectOne();
            DataRow _ravi = dt2xx.NewRow();
            _ravi["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi["ID_ChungTu"] = 0;
            _ravi["ID_TaiKhoanKeToanCon"] = ID_TaiKhoanKeToanCon;
            _ravi["No"] = tongtienhangcoVAT;
            _ravi["Co"] = 0;
            _ravi["TienUSD"] = checkUSD.Checked;
            _ravi["TiGia"] = txtTiGia.Text.ToString();
            _ravi["DaGhiSo"] = false;
            _ravi["GhiChu"] = "";
            _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
            _ravi["TenTaiKhoanCon"] = dtcon.Rows[0]["TenTaiKhoanCon"].ToString();
            _ravi["HienThi"] = "1";
            dt2xx.Rows.Add(_ravi);

            clsNganHang_TaiKhoanKeToanCon clscon2 = new clsNganHang_TaiKhoanKeToanCon();
            clscon2.iID_TaiKhoanKeToanCon = 79;
            DataTable dtcon2 = clscon2.SelectOne();

            // Có VAT C3331
            DataRow _ravi2 = dt2xx.NewRow();
            _ravi2["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi2["ID_ChungTu"] = 0;
            _ravi2["ID_TaiKhoanKeToanCon"] = 79;
            _ravi2["No"] = 0;
            _ravi2["Co"] = tienVAT;
            _ravi2["TienUSD"] = checkUSD.Checked;
            _ravi2["TiGia"] = txtTiGia.Text.ToString();
            _ravi2["DaGhiSo"] = false;
            _ravi2["GhiChu"] = "";
            _ravi2["SoTaiKhoanCon"] = 79;
            _ravi2["TenTaiKhoanCon"] = clscon2.sTenTaiKhoanCon.Value;
            _ravi2["HienThi"] = "1";
            dt2xx.Rows.Add(_ravi2);

            clsNganHang_TaiKhoanKeToanCon clscon3 = new clsNganHang_TaiKhoanKeToanCon();
            clscon3.iID_TaiKhoanKeToanCon = 132;
            DataTable dtcon3 = clscon3.SelectOne();

            // Có 511
            DataRow _ravi3 = dt2xx.NewRow();
            _ravi3["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi3["ID_ChungTu"] = 0;
            _ravi3["ID_TaiKhoanKeToanCon"] = 132;
            _ravi3["No"] = 0;
            _ravi3["Co"] = tongtienhang_ChuaCoVAT;
            _ravi3["TienUSD"] = checkUSD.Checked;
            _ravi3["TiGia"] = txtTiGia.Text.ToString();
            _ravi3["DaGhiSo"] = false;
            _ravi3["GhiChu"] = "";
            _ravi3["SoTaiKhoanCon"] = 132;
            _ravi3["TenTaiKhoanCon"] = clscon3.sTenTaiKhoanCon.Value;
            _ravi3["HienThi"] = "1";
            dt2xx.Rows.Add(_ravi3);

            gridControl2.DataSource = dt2xx;

            
        }
       
        private bool KiemTraLuu()
        {

            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();

            if (xxxx.ToString() == "" || dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (txtTongTienHangCoVAT.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (gridKH.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa có NCC ");
                return false;
            }
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa có người mua hàng ");
                return false;
            }
            else if (dteNgayChungTu.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }

            else return true;

        }
        
        private string Load_soChungTu_KhoThanhPham()
        {
            string sochungtuxx;
            clsKhoThanhPham_tbXuatKho cls3 = new clsKhoThanhPham_tbXuatKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtuxx = "XKTP 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtuxx = "XKTP " + xxx2 + "";

            }
            return sochungtuxx;
        }
        private void Luu_Chitiet_BanHang(int xxxID_banHang)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();

                clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                DataTable dt2_cu = new DataTable();
                cls2.iID_BanHang = xxxID_banHang;
                dt2_cu = cls2.Select_HienThiSuaDonHang();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        int ID_ChiTietBanHangxxxx = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBanHang"].ToString());
                        cls2.iID_ChiTietBanHang = ID_ChiTietBanHangxxxx;
                        cls2.bTonTai = false;
                        cls2.Update_W_TonTai();
                    }

                }
                
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    cls2.iID_BanHang = xxxID_banHang;
                    int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuong = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    cls2.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                    cls2.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                    cls2.bDaBanHang = false;
                  
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietBanHang = Convert.ToInt32(foundRows[0]["ID_ChiTietBanHang"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_BanHang = xxxID_banHang;
                dt2_moi11111 = cls2.Select_HienThiSuaDonHang();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietBanHangxxxx = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBanHang"].ToString());
                    cls2.iID_ChiTietBanHang = ID_ChiTietBanHangxxxx;
                    cls2.Delete();
                }


            }

        }

        private void Luu_Chitiet_XuatKho_ThanhPham(int xxxID_XuatKho_ThanhPham)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();

                clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKho_ThanhPham = xxxID_XuatKho_ThanhPham;
                dt2_cu = cls2.SelectAll_W_ID_XuatKho_ThanhPham();
                if (dt2_cu.Rows.Count > 0)
                {
                   
                       
                        cls2.iID_XuatKho_ThanhPham = xxxID_XuatKho_ThanhPham;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai_W_ID_XuatKho();
                    

                }

                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    int ID_VTHHxxx= Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());                   
                    cls2.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaXuatKho = true;
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                    if (gridKH.EditValue.ToString() != "")
                        cls2.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                   
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietXuatKho_ThanhPham = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho_ThanhPham"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKho_ThanhPham = xxxID_XuatKho_ThanhPham;
                dt2_moi11111 = cls2.SelectAll_W_ID_XuatKho_ThanhPham();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int dddiID_ChiTietXuatKho_ThanhPham = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietXuatKho_ThanhPham"].ToString());
                    cls2.iID_ChiTietXuatKho_ThanhPham = dddiID_ChiTietXuatKho_ThanhPham;
                    cls2.Delete();
                }


            }

        }
        private void LuuDuLieu_Chi_Luu()
        {
            if (!KiemTraLuu()) return ;
            else
            {
                int aaiixxID_banHang;
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();

                clsBanHang_tbBanHang clsbh = new clsBanHang_tbBanHang();
                clsbh.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                clsbh.daNgayChungTu = dteNgayChungTu.DateTime;
                clsbh.sSoChungTu = txtSoChungTu.Text.ToString();
                clsbh.sSoHoaDon = txtSoHoaDon.Text.ToString();
                clsbh.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                clsbh.fTongTienHangChuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                clsbh.fTongTienHangCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                clsbh.sDienGiai = txtDienGiai.Text.ToString();
                clsbh.bTonTai = true;
                clsbh.bNgungTheoDoi = false;
                clsbh.iID_NguoiBan = 11;
                clsbh.bTienUSD = checkUSD.Checked;
                clsbh.fPhanTramVAT = Convert.ToDouble(txtPhanTramVAT.Text.ToString());
                clsbh.fTienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                clsbh.bTrangThaiBanHang = false;
                clsbh.bTrangThai_KhoThanhPham = false;
                clsbh.bCheck_BaoVe = false;
                clsbh.bCheck_LaiXe = false;
                clsbh.sThamChieu = txtSoChungTu_ThanhPham.Text.ToString();
                clsbh.sMaSoCongTeNo = txtMaCongTennor.Text.ToString();
                clsbh.fTiGia= Convert.ToDouble(txtTiGia.Text.ToString());
                clsbh.bDaXong = false;
                if(UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbSua==true)
                {
                    clsbh.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                    clsbh.Update();
                    aaiixxID_banHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                }
                else
                {
                    clsbh.Insert();
                    aaiixxID_banHang = clsbh.iID_BanHang.Value;
                }
                // luu chi tiet ban hang
                Luu_Chitiet_BanHang(aaiixxID_banHang);
                //lưu thu chi và tai khoan ke toan
                Luu_TbThuChi(aaiixxID_banHang);
                Luu_BienDongTaiKhoan(aaiixxID_banHang);
                MessageBox.Show("Đã lưu");
                this.Close();

            }
        }
        private void LuuDuLieu_Va_GuiDuLieu()
        {

            if (!KiemTraLuu()) return ;
            else
            {
                int aaiixxID_banHang;
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();

                clsBanHang_tbBanHang clsbh = new clsBanHang_tbBanHang();
                clsbh.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                clsbh.daNgayChungTu = dteNgayChungTu.DateTime;
                clsbh.sSoChungTu = txtSoChungTu.Text.ToString();
                clsbh.sSoHoaDon = txtSoHoaDon.Text.ToString();
                clsbh.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                clsbh.fTongTienHangChuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                clsbh.fTongTienHangCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                clsbh.sDienGiai = txtDienGiai.Text.ToString();
                clsbh.bTonTai = true;
                clsbh.bNgungTheoDoi = false;
                clsbh.iID_NguoiBan =11;
                clsbh.bTienUSD = checkUSD.Checked;
                clsbh.fPhanTramVAT = Convert.ToDouble(txtPhanTramVAT.Text.ToString());
                clsbh.fTienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                clsbh.bTrangThaiBanHang = false;
                clsbh.bTrangThai_KhoThanhPham = true;
                clsbh.bCheck_BaoVe = false;
                clsbh.bCheck_LaiXe = false;
                clsbh.sThamChieu = txtSoChungTu_ThanhPham.Text.ToString();
                clsbh.bDaXong = false;
                clsbh.sMaSoCongTeNo = txtMaCongTennor.Text.ToString();
                clsbh.fTiGia = Convert.ToDouble(txtTiGia.Text.ToString());
                Convert.ToDouble(txtTiGia.Text.ToString());
                if (UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbSua == true)
                {
                    clsbh.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                    clsbh.Update();
                    aaiixxID_banHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                }
                else
                {
                    clsbh.Insert();
                    aaiixxID_banHang = clsbh.iID_BanHang.Value;
                }

                // luu tb xuất kho  thanh pham
                double tongtienhang;
                tongtienhang = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                clsKhoThanhPham_tbXuatKho cls1 = new clsKhoThanhPham_tbXuatKho();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = Load_soChungTu_KhoThanhPham();
                cls1.fTongTienHang = tongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.bTonTai = true;
                cls1.bDaXuatKho = true;
                cls1.bNgungTheoDoi = false;
                cls1.bCheck_XuatKho_Khac = false;
                if (gridKH.EditValue.ToString() != "")
                    cls1.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                cls1.sNguoiNhanHang = txtTenKH.Text.ToString();
                int iiiID_XuatKho_ThanhPham;
                cls1.Insert();
                iiiID_XuatKho_ThanhPham = cls1.iID_XuatKho_ThanhPham.Value;

                // luu chi tiet ban hang
                Luu_Chitiet_BanHang(aaiixxID_banHang);
                Luu_Chitiet_XuatKho_ThanhPham(iiiID_XuatKho_ThanhPham);
                // lưu tbthu chi và tailhoan ke toan
                Luu_TbThuChi(aaiixxID_banHang);
                Luu_BienDongTaiKhoan(aaiixxID_banHang);

                MessageBox.Show("Đã lưu và gửi dữ liệu");
               
            }
        }

        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;
            checkBaoCo.Checked = true;
            checkUSD.Checked = true;

            clsKhoThanhPham_tbXuatKho cls1 = new clsKhoThanhPham_tbXuatKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu_ThanhPham.Text = "XKTP 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                txtSoChungTu_ThanhPham.Text = "XKTP " + xxx2.ToString() + "";
            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt2;

            clsBanHang_tbBanHang cls22 = new clsBanHang_tbBanHang();
            DataTable dt22 = cls22.SelectAll();
            dt22.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv22 = dt22.DefaultView;
            DataTable dv322 = dv22.ToTable();
            int k22 = dv322.Rows.Count;
            if (k22 == 0)
            {
                txtSoChungTu.Text = "BH 1";
            }
            else
            {
                string xxx = dv322.Rows[k22 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                txtSoChungTu.Text = "BH " + xxx2.ToString() + "";
            }
        }
        private void HienThi_Sua()
        {
            gridNguoiLap.EditValue = 11;
            checkUSD.Checked = true;
            checkBaoCo.Checked = true;
            clsBanHang_tbBanHang cls = new CtyTinLuong.clsBanHang_tbBanHang();
            cls.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
            DataTable dt = cls.SelectOne();
            if (dt.Rows[0]["MaSoCongTeNo"].ToString() != "")
                txtMaCongTennor.Text = cls.sMaSoCongTeNo.Value;
            if (cls.bCheck_BaoVe == true) checkBaoVe_LaiXe.Checked = true;
            else checkBaoVe_LaiXe.Checked = false;
            if (UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbCopY == true)
            {
                clsBanHang_tbBanHang cls2xxx = new clsBanHang_tbBanHang();
                DataTable dtxxxx2xxx = cls2xxx.SelectAll();
                dtxxxx2xxx.DefaultView.RowFilter = "TonTai=True";
                DataView dv2 = dtxxxx2xxx.DefaultView;

                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtSoChungTu.Text = "BH 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtSoChungTu.Text = "BH 1";
                    else txtSoChungTu.Text = "BH " + xxx2 + "";
                }
            }
            else
            {
                txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();
                txtTiGia.Text = cls.fTiGia.Value.ToString();

                txtSoHoaDon.Text = cls.sSoHoaDon.Value.ToString();
                dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
                txtSoChungTu_ThanhPham.Text = cls.sThamChieu.Value;
                gridNguoiLap.EditValue = cls.iID_NguoiBan.Value;
                //gridKH.EditValue = cls.iIDNhaCungCap.Value;
                txtDienGiai.Text = cls.sDienGiai.Value.ToString();
                txtTongTienHangChuaVAT.Text = cls.fTongTienHangChuaVAT.Value.ToString();
                txtTongTienHangCoVAT.Text = cls.fTongTienHangCoVAT.Value.ToString();
                checkUSD.Checked = cls.bTienUSD.Value;
                if (cls.bTienUSD.Value == false) checkVNĐ.Checked = true;
                txtPhanTramVAT.Text = cls.fPhanTramVAT.Value.ToString();
                txtTienVAT.Text = cls.fTienVAT.Value.ToString();

                if (cls.bTrangThai_KhoThanhPham.Value == true & UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbCopY == false)
                {
                 
                    btLuu_Dong.Enabled = false;                    
                    btLuu_Gui_Dong.Enabled = false;

                }
                else
                {
                    //btLuu_Copy.Enabled = true;
                    btLuu_Dong.Enabled = true;
                    // btLuu_Gui_Copy.Enabled = true;
                    btLuu_Gui_Dong.Enabled = true;
                }

                clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                cls2.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                DataTable dt3 = cls2.Select_HienThiSuaDonHang();
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID_ChiTietBanHang"); // ID của tbChi tiet don hàng
                dt2.Columns.Add("ID_BanHang");
                dt2.Columns.Add("ID_VTHH");
                dt2.Columns.Add("SoLuong", typeof(float));
                dt2.Columns.Add("DonGia", typeof(double));
                dt2.Columns.Add("MaVT");// tb VTHH
                dt2.Columns.Add("TenVTHH");
                dt2.Columns.Add("DonViTinh");
                dt2.Columns.Add("ThanhTien", typeof(double));
                dt2.Columns.Add("HienThi", typeof(string));
                dt2.Columns.Add("GhiChu", typeof(string));
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuong"].ToString());
                    Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_ChiTietBanHang"] = dt3.Rows[i]["ID_ChiTietBanHang"].ToString();
                    _ravi["ID_BanHang"] = dt3.Rows[i]["ID_BanHang"].ToString();
                    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["SoLuong"] = xxsoluong;
                    _ravi["DonGia"] = xxdongia;
                    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    _ravi["HienThi"] = "1";
                    dt2.Rows.Add(_ravi);
                }

                gridControl1.DataSource = dt2;


                clsNganHang_ChiTietBienDongTaiKhoanKeToan clstaikhoan = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clstaikhoan.iID_ChungTu = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
               
                cls.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                DataTable dt2232323232 = cls.SelectOne();

                clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
                clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
                DataTable dttaikhoanm = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
                gridKH.EditValue = cls.iID_KhachHang.Value;
                DataTable dt2xx = new DataTable();
                dt2xx.Columns.Add("ID_ChiTietBienDongTaiKhoan", typeof(int));
                dt2xx.Columns.Add("ID_ChungTu", typeof(int));
                //dt2xx.Columns.Add("SoChungTu", typeof(string));
                //dt2xx.Columns.Add("NgayThang", typeof(DateTime));
                dt2xx.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
                dt2xx.Columns.Add("No", typeof(double));
                dt2xx.Columns.Add("Co", typeof(double));
                dt2xx.Columns.Add("TienUSD", typeof(bool));
                dt2xx.Columns.Add("TiGia", typeof(double));
                dt2xx.Columns.Add("DaGhiSo", typeof(bool));
                dt2xx.Columns.Add("GhiChu", typeof(string));
                dt2xx.Columns.Add("SoTaiKhoanCon");
                dt2xx.Columns.Add("TenTaiKhoanCon", typeof(string));
                dt2xx.Columns.Add("HienThi", typeof(string));
                if (dttaikhoanm.Rows.Count > 0)
                {
                    for (int i = 0; i < dttaikhoanm.Rows.Count; i++)
                    {
                        int ID_TaiKhoanKeToanCon = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                        DataTable dtcon = clscon.SelectOne();
                        DataRow _ravi = dt2xx.NewRow();
                        _ravi["ID_ChiTietBienDongTaiKhoan"] = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                        _ravi["ID_ChungTu"] = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_ChungTu"].ToString());
                        _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt32(ID_TaiKhoanKeToanCon.ToString());
                        _ravi["No"] = Convert.ToDouble(dttaikhoanm.Rows[i]["No"].ToString());
                        _ravi["Co"] = Convert.ToDouble(dttaikhoanm.Rows[i]["Co"].ToString());
                        _ravi["TienUSD"] = Convert.ToBoolean(dttaikhoanm.Rows[i]["TienUSD"].ToString());
                        _ravi["TiGia"] = Convert.ToDouble(dttaikhoanm.Rows[i]["TiGia"].ToString());
                        _ravi["DaGhiSo"] = Convert.ToBoolean(dttaikhoanm.Rows[i]["DaGhiSo"].ToString());
                        _ravi["GhiChu"] = "";
                        _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                        _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                        _ravi["HienThi"] = "1";
                        dt2xx.Rows.Add(_ravi);
                    }
                }
                gridControl2.DataSource = dt2xx;


            }
        }
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtcon = clscon.SelectAll();
            dtcon.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvcon = dtcon.DefaultView;
            DataTable newdtcon = dvcon.ToTable();

            repositoryItemGridLookUpEdit2.DataSource = newdtcon;
            repositoryItemGridLookUpEdit2.ValueMember = "ID_TaiKhoanKeToanCon";
            repositoryItemGridLookUpEdit2.DisplayMember = "SoTaiKhoanCon";

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbKhachHang cls = new clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable newdt = dv.ToTable();

            gridKH.Properties.DataSource = newdt;
            gridKH.Properties.ValueMember = "ID_KhachHang";
            gridKH.Properties.DisplayMember = "MaKH";
        }
        public KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii()
        {
            InitializeComponent();
        }

        private void KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            if (UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbSua == true)
                HienThi_Sua();
            else if (UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbCopY == true)
                HienThi_Sua();
            else if (UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.mbThemMoi == true)
                HienThi_ThemMoi();
        }

        private void checkVNĐ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVNĐ.Checked == true)
            {
                checkUSD.Checked = false;
                txtTiGia.Text = "1";
                txtTiGia.ReadOnly = true;
            }
            if (checkVNĐ.Checked == false)
            {
                checkUSD.Checked = true;

                txtTiGia.ReadOnly = false;
            }

            try
            {
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                if (dttttt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dttttt2.Rows.Count; i++)
                    {
                        dttttt2.Rows[i]["TienUSD"] = false;
                    }
                    gridControl1.DataSource = dttttt2;
                }
            }
            catch
            {
            }
        }

        private void checkUSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUSD.Checked == true)
                checkVNĐ.Checked = false;
            try
            {
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                if (dttttt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dttttt2.Rows.Count; i++)
                    {
                        dttttt2.Rows[i]["TienUSD"] = true;
                    }
                    gridControl2.DataSource = dttttt2;
                }
            }
            catch
            {
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    txtNguoiMuaHang.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void txtTienVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTienVAT.Text);
                txtTienVAT.Text = String.Format("{0:#,##0.00}", value);


                double tienvat;
                //tienno = Convert.ToDouble(txtTienNo.Text.ToString());
                tienvat = Convert.ToDouble(txtTienVAT.Text.ToString());
                //txtTienCo.Text = (tienno + tienvat).ToString();

                double tongtienchuaVAT;
                tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = Convert.ToDouble(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
            }
            catch
            {

            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clMaVT)
                {
                    clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                    cls.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                    DataTable dt = cls.SelectOne();
                    if (dt != null)
                    {
                        gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                        gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                        gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                        gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                        gridView4.SetRowCellValue(e.RowHandle, clSoLuong, 0);

                        clsBanHang_BangGia cls2 = new clsBanHang_BangGia();
                        cls2.iID_VTHH = kk;
                        cls2.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                        DataTable dtgia = cls2.SelectAll_W_ID_VTHH_ID_KhachHang();
                        if (dtgia.Rows.Count > 0)
                            gridView4.SetRowCellValue(e.RowHandle, clDonGia, Convert.ToDouble(dtgia.Rows[dtgia.Rows.Count - 1]["DonGia"].ToString()));
                        else gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

                        if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                            ffdongia = 0;
                        else
                            ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                        if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                            fffsoluong = 0;
                        else
                            fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                        fffthanhtien = fffsoluong * ffdongia;
                        gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                    }



                }

                if (e.Column == clSoLuong)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                if (e.Column == clDonGia)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();


                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                double tongtienchuaVAT, tienvat;
                tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = Convert.ToDouble(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();

            }
            catch
            { }


        }

        private void txtPhanTramVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double PhanTramVAT, tongtienhang, tienvat, tongtienchuaVAT;
                tongtienhang = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                PhanTramVAT = Convert.ToDouble(txtPhanTramVAT.Text.ToString());
                txtTienVAT.Text = (tongtienhang * PhanTramVAT / 100).ToString();
                tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = Convert.ToDouble(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
            }
            catch
            {

            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
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

        private void txtTongTienHangCoVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);

                double tienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                double tienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                double tongtiencoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                gridView8.SetRowCellValue(0, clNo, tongtiencoVAT);
                gridView8.SetRowCellValue(0, clCo, 0);
                gridView8.SetRowCellValue(1, clNo, 0);
                gridView8.SetRowCellValue(1, clCo, tienVAT);
                gridView8.SetRowCellValue(2, clNo, 0);
                gridView8.SetRowCellValue(2, clCo, tienchuaVAT);




            }
            catch
            {

            }
        }

        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
            }
            catch
            {

            }
        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
            }
            catch
            {

            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Chi_Luu();            
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GuiDuLieu();

        }

        private void checkPhieuThu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPhieuThu.Checked == true)
            {
                bienthangthai = 4;
                checkBaoCo.Checked = false;
            }
        }

        private void checkBaoCo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBaoCo.Checked == true)
            {
                bienthangthai = 1;
                checkPhieuThu.Checked = false;
            }
        }

        private void gridView8_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == SoTaiKhoanCon)
            {
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView8.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView8.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    gridView8.SetRowCellValue(e.RowHandle, ID_TaiKhoanKeToanCon, kk);
                    //gridView8.SetRowCellValue(e.RowHandle, ID_TaiKhoanKeToanMe, cls.iID_TaiKhoanKeToanMe.Value);
                    gridView8.SetRowCellValue(e.RowHandle, TenTaiKhoanCon, dt.Rows[0]["TenTaiKhoanCon"].ToString());
                    gridView8.SetRowCellValue(e.RowHandle, HienThi, "1");
                    gridView8.SetRowCellValue(e.RowHandle, TienUSD, checkUSD.Checked);
                    gridView8.SetRowCellValue(e.RowHandle, clCo, 0);
                    gridView8.SetRowCellValue(e.RowHandle, clNo, 0);
                }
                if (e.RowHandle == 0)
                {
                    gridView8.SetRowCellValue(e.RowHandle, clNo, txtTongTienHangCoVAT.Text.ToString());
                    gridView8.SetRowCellValue(e.RowHandle, clCo, 0);
                }
                if (e.RowHandle == 1)
                {
                    gridView8.SetRowCellValue(e.RowHandle, clCo, txtTongTienHangCoVAT.Text.ToString());
                    gridView8.SetRowCellValue(e.RowHandle, clNo, 0);
                }
                if (e.RowHandle == 2)
                {
                    if (txtTienVAT.Text.ToString() != "0")
                    {
                        gridView8.SetRowCellValue(e.RowHandle, clCo, txtTienVAT.Text.ToString());
                        gridView8.SetRowCellValue(e.RowHandle, clNo, 0);
                    }
                }
            }
            if (e.Column == TienUSD)
            {
                if (Convert.ToBoolean(gridView8.GetFocusedRowCellValue(TienUSD).ToString()) == false)
                    gridView8.SetFocusedRowCellValue(TiGia, 1);
                else
                    gridView8.SetFocusedRowCellValue(TiGia, 0);
            }
        }

        private void gridView8_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn10)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void txtTiGia_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTiGia.Text);
                txtTiGia.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void checkBaoVe_LaiXe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe_LaiXe.Checked == true)
                {
                    clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();
                    cls1.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_W_BaoVe();
                    cls1.Update_TrangThai_DaXong();
                    cls1.Update_W_LaiXe();
                    cls1.Update_TrangThai_DaXong();
                    if (cls1.bTrangThaiBanHang.Value == true)
                    {
                        clsBanHang_ChiTietBanHang clschitiet = new clsBanHang_ChiTietBanHang();
                        clschitiet.iID_BanHang = UCThanhPham_XuatKhoBanHang_Newwwwwwwwww.miiiID_BanHang;
                        clschitiet.Update_ALL_W_DaXong();
                    }
                    MessageBox.Show("Đã qua cửa bảo vệ và lái xe");
                }
            }
            catch
            {

            }
        }

        private void linkKeHoachSanXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mdaNgayChungTu = dteNgayChungTu.DateTime;
            mdbSoLuongXuat = Convert.ToDouble(gridView4.GetRowCellValue(0, clSoLuong).ToString());
            BanHang_FrmThamChieuKeHoachSanXuat ff = new CtyTinLuong.BanHang_FrmThamChieuKeHoachSanXuat();
            ff.Show();
        }

        private void gridKH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();

                }
                HienThi_GridConTrol_SauKhiChon();

            }
            catch
            {

            }
          
        }

        private void txtTiGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                if (dttttt2.Rows.Count > 0)
                {
                    for (int i = 0; i < dttttt2.Rows.Count; i++)
                    {
                        dttttt2.Rows[i]["TiGia"] = txtTiGia.Text.ToString() ;
                    }
                    gridControl2.DataSource = dttttt2;
                }
            }
            catch
            {
            }
        }

        private void txtTongTienHangChuaVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void ntPrint_hoadon_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();
            string shienthi = "1";
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            mdtPrint = dv.ToTable();
            if (mdtPrint.Rows.Count > 0)
            {
                clsTbKhachHang cls1 = new clsTbKhachHang();
                cls1.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                DataTable dt1 = cls1.SelectOne();

                mdaNgayChungTu = dteNgayChungTu.DateTime;
                msDiaChi = cls1.sDiaChi.Value;
                msDienGiai = txtDienGiai.Text.ToString();
                msNguoiNhanHang = txtTenKH.Text.ToString();
                msSoChungTu = txtSoChungTu.Text.ToString();

                mdbTongTienVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                mdbTienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                mdbTienChuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                DataTable dttaikhoan = (DataTable)gridControl2.DataSource;
                if (dttaikhoan.Rows.Count >= 2)
                {
                    try
                    {
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        int id_131 = Convert.ToInt32(dttaikhoan.Rows[0]["SoTaiKhoanCon"].ToString());
                        int id_VAT = Convert.ToInt32(dttaikhoan.Rows[1]["SoTaiKhoanCon"].ToString());
                        int id_511 = Convert.ToInt32(dttaikhoan.Rows[2]["SoTaiKhoanCon"].ToString());
                        clscon.iID_TaiKhoanKeToanCon = id_131;
                        DataTable dtcon1 = clscon.SelectOne();
                        msSoTKNo = clscon.sSoTaiKhoanCon.Value;
                        clscon.iID_TaiKhoanKeToanCon = id_511;
                        DataTable dtcon2 = clscon.SelectOne();
                        msSoTKCo = clscon.sSoTaiKhoanCon.Value;

                        mdbSoTienNo = Convert.ToDouble(dttaikhoan.Rows[0]["No"].ToString());
                        mdbSoTienCo = Convert.ToDouble(dttaikhoan.Rows[2]["Co"].ToString());


                        double Nophatsinh, Cophatsinh, nodaukyxxx, codaukyxx;
                        clsNganHang_ChiTietBienDongTaiKhoanKeToan cls2 = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                        DataTable dtphasinh = cls2.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_W_NhoHon_NgayThang_and_Bool_TonDauKy_False(id_131, DateTime.Today.AddDays(1));
                        cls2.iID_TaiKhoanKeToanCon = id_131;
                        DataTable dtdauky = cls2.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_and_Bool_TonDauKy_True();

                        if (dtdauky.Rows.Count > 0)
                        {
                            nodaukyxxx = Convert.ToDouble(dtdauky.Rows[0]["No"].ToString());
                            codaukyxx = Convert.ToDouble(dtdauky.Rows[0]["Co"].ToString());
                        }
                        else codaukyxx = nodaukyxxx = 0;

                        if (dtphasinh.Rows.Count > 0)
                        {
                            Nophatsinh = Convert.ToDouble(dtphasinh.Rows[0]["No"].ToString());
                            Cophatsinh = Convert.ToDouble(dtphasinh.Rows[0]["Co"].ToString());
                        }
                        else Nophatsinh = Cophatsinh = 0;
                        mdbGiaHanNo = 0;
                        mdbNoCu = nodaukyxxx + Nophatsinh - codaukyxx - Cophatsinh;
                        mdbNoMoi = mdbTongTienVAT;
                        mdbTongNo = mdbNoCu + mdbNoMoi;
                    }
                    catch
                    {

                    }

                }
                clsSoTienBangChu cls = new clsSoTienBangChu();
                if (checkUSD.Checked == false)
                    msSoTienBangChu = cls.DocTienBangChu(Convert.ToDouble(mdbTongTienVAT), " đồng.");
                else msSoTienBangChu = cls.DocTienBangChu(Convert.ToDouble(mdbTongTienVAT), " USD.");

                // =
                //;
                //public static double mdbGiaHanNo, mdbNoCu, mdbNoMoi, , , , , , mdbTongNo;

                mbPrint_HoaDon = true;
                mbPrint_XuatKho = false;


                frmPrint_BanHang ff = new frmPrint_BanHang();
                ff.Show();

            }
        }

        private void btPrint_XuatKho_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();
            string shienthi = "1";
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            mdtPrint = dv.ToTable();
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint_XuatKho = true;
                mbPrint_HoaDon = false;
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                msSoChungTu = txtSoChungTu.Text.ToString();

                msNguoiNhanHang = txtTenKH.Text.ToString();
                mdbTongTienVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                msDienGiai = txtDienGiai.Text.ToString();
                frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                ff.Show();

            }
        }
    }
}
