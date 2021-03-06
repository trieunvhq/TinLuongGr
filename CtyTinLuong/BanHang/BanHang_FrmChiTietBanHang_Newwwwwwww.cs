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
    public partial class BanHang_FrmChiTietBanHang_Newwwwwwww : Form
    {
        int bienthangthai;
        //string sochungtu_tbThuChi;
        public static DateTime mdaNgayChungTu;
        public static double mdbSoLuongXuat;
        public static bool mbPrint_XuatKho, mbPrint_HoaDon;
        public static DataTable mdtPrint;
        public static string msDiaChi,msDienGiai, msNguoiNhanHang, msSoChungTu, msSoTienBangChu, msSoTKCo, msSoTKNo;
        public static double mdbGiaHanNo, mdbNoCu,mdbNoMoi, mdbSoTienCo,mdbSoTienNo, mdbTienChuaVAT,mdbTienVAT, mdbTongTienVAT, mdbTongNo ;

        private void update_baove(int iiID_banHang__)
        {
            try
            {
                using (clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang())
                {
                    cls1.iID_BanHang = iiID_banHang__;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_W_BaoVe();
                    cls1.Update_TrangThai_DaXong();
                    cls1.Update_W_LaiXe();
                    cls1.Update_TrangThai_DaXong();
                    if (cls1.bTrangThaiBanHang.Value == true)
                    {
                        clsBanHang_ChiTietBanHang clschitiet = new clsBanHang_ChiTietBanHang();
                        clschitiet.iID_BanHang = iiID_banHang__;
                        clschitiet.Update_ALL_W_DaXong();
                    }
                    MessageBox.Show("Đã qua cửa bảo vệ và lái xe");
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Luu_BienDongTaiKhoan(int xxxxID_BanHang)
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {

                    clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    clsxx.iID_ChungTu = xxxxID_BanHang;
                    clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    clsxx.daNgayThang = dteNgayChungTu.DateTime;

                    DataTable dt2_cu = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
                    if (dt2_cu.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2_cu.Rows.Count; i++)
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
                        int ID_TaiKhoanKeToanConxxxx1 = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                        clsxx.iID_ChungTu = xxxxID_BanHang;
                        clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                        clsxx.daNgayThang = dteNgayChungTu.DateTime;
                        clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                        if (dv3cccccc.Rows[0]["Co"].ToString() != "")
                            clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["Co"].ToString());
                        else clsxx.fCo = 0;
                        if (dv3cccccc.Rows[0]["No"].ToString() != "")
                            clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["No"].ToString());
                        else clsxx.fNo = 0;
                        clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[0]["TienUSD"].ToString());
                        if (dv3cccccc.Rows[0]["TiGia"].ToString() != "")
                            clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["TiGia"].ToString());
                        else clsxx.fTiGia = 0;
                        clsxx.bTonTai = true;
                        clsxx.bNgungTheoDoi = false;
                        clsxx.bDaGhiSo = true;
                        clsxx.bBBool_TonDauKy = false;
                        clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 2;
                        clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                        clsxx.sDienGiai = txtDienGiai.Text.ToString();
                        clsxx.bCheck_PhanNganHang = false;

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
                                clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["Co"].ToString());
                            else clsxx.fCo = 0;
                            if (dv3cccccc.Rows[1]["No"].ToString() != "")
                                clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["No"].ToString());
                            else clsxx.fNo = 0;
                            clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[1]["TienUSD"].ToString());
                            if (dv3cccccc.Rows[1]["TiGia"].ToString() != "")
                                clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["TiGia"].ToString());
                            else clsxx.fTiGia = 0;
                            clsxx.bTonTai = true;
                            clsxx.bNgungTheoDoi = false;
                            clsxx.bDaGhiSo = true;
                            clsxx.bBBool_TonDauKy = false;
                            clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 4;
                            clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                            clsxx.sDienGiai = txtDienGiai.Text.ToString();
                            clsxx.bCheck_PhanNganHang = false;
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
                                    clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["Co"].ToString());
                                else clsxx.fCo = 0;
                                if (dv3cccccc.Rows[2]["No"].ToString() != "")
                                    clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["No"].ToString());
                                else clsxx.fNo = 0;
                                clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[2]["TienUSD"].ToString());
                                if (dv3cccccc.Rows[2]["TiGia"].ToString() != "")
                                    clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["TiGia"].ToString());
                                else clsxx.fTiGia = 0;
                                clsxx.bTonTai = true;
                                clsxx.bNgungTheoDoi = false;
                                clsxx.bDaGhiSo = true;
                                clsxx.bBBool_TonDauKy = false;
                                clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 3;
                                clsxx.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                                clsxx.sDienGiai = txtDienGiai.Text.ToString();
                                clsxx.bCheck_PhanNganHang = false;
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Luu_TbThuChi(int xxxxID_BanHang)
        {
            try
            {
                using (clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi())
                {
                    if (!KiemTraLuu()) return;
                    else
                    {
                        HienThiSoChungTu(bienthangthai);

                        
                        cls1.daNgayChungTu = dteNgayChungTu.DateTime;

                        cls1.sDienGiai = txtDienGiai.Text.ToString();
                        cls1.fSoTien = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                        cls1.sThamChieu = txtSoChungTu.Text.ToString();
                        cls1.sDoiTuong = txtTenKH.Text.ToString();
                        cls1.bTonTai = true;
                        cls1.bNgungTheoDoi = false;
                        cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                        cls1.bTienUSD = checkUSD.Checked;
                        cls1.fTiGia = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
                        cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 = bienthangthai;
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
                            cls1.sSoChungTu = txtsochungtu_tbThuChi.Text.ToString();
                            cls1.Insert();
                        }

                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void HienThiSoChungTu(int bientrangthaikkkkkkkkkk)
        {
            try
            {
                using (clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi())
                {
                    DataTable dt = cls2.SelectAll();
                    if (bientrangthaikkkkkkkkkk == 1)
                    {
                        dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 =1 ";
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
                        dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 =2 ";
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
                        dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 =3 ";
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
                        dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 =4 ";
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
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Luu_Chitiet_BanHang(int xxxID_banHang)
        {
            try
            {
                using(clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang())
                {
                    if (!KiemTraLuu()) return;
                    else
                    {

                        string shienthi = "1";
                        DataTable dtkkk = (DataTable)gridControl1.DataSource;
                        dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                        DataView dv2232xx = dtkkk.DefaultView;
                        DataTable dt_gridcontrol = dv2232xx.ToTable();

                        
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
                            cls2.fSoLuong = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                            cls2.fDonGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["DonGia"].ToString());
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
                            int ID_ChiTietBanHangxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietBanHang"].ToString());
                            cls2.iID_ChiTietBanHang = ID_ChiTietBanHangxxxx;
                            cls2.Delete();
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThi_GridConTrol_SauKhiChon()
        {
            try
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
                dt2xx.Columns.Add("SoTaiKhoanMoi", typeof(string));

                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = Convert.ToInt16(gridKH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                int ID_TaiKhoanKeToanCon = clsncc.iID_TaiKhoanKeToan.Value;
                double tongtienhangcoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                double tienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                double tongtienhang_ChuaCoVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());

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
                _ravi["SoTaiKhoanMoi"] = clscon.sSoTaiKhoanCon.Value;
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
                _ravi["SoTaiKhoanMoi"] = clscon2.sSoTaiKhoanCon.Value;
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
                _ravi["SoTaiKhoanMoi"] = clscon3.sSoTaiKhoanCon.Value;
                dt2xx.Rows.Add(_ravi3);

                gridControl2.DataSource = dt2xx;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
          

        private bool KiemTraLuu()
        {
            try
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
                    txtSoChungTu.Focus();
                    return false;
                }
                else if (txtTongTienHangCoVAT.Text.ToString() == "")
                {
                    MessageBox.Show("Chưa có số CT ");
                    txtTongTienHangCoVAT.Focus();
                    return false;
                }
                else if (gridKH.EditValue.ToString() == "")
                {
                    MessageBox.Show("Chưa có NCC ");
                    gridKH.Focus();
                    return false;
                }
                else if (gridNguoiLap.EditValue.ToString() == "")
                {
                    MessageBox.Show("Chưa có người mua hàng ");
                    gridNguoiLap.Focus();
                    return false;
                }
                else if (dteNgayChungTu.EditValue.ToString() == "")
                {
                    MessageBox.Show("Chưa chọn ngày chứng từ ");
                    dteNgayChungTu.Focus();
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

        private void LuuDuLieu(int iiID_banHang__)
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dvmoi = dttttt2.DefaultView;
                    DataTable dtmoi = dvmoi.ToTable();

                    clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();
                    cls1.iID_BanHang = iiID_banHang__;
                    DataTable dt1 = cls1.SelectOne();

                    clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
                    cls.iID_BanHang = iiID_banHang__;
                    cls.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls.sSoHoaDon = txtSoHoaDon.Text.ToString();
                    cls.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                    cls.fTongTienHangChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                    cls.fTongTienHangCoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    cls.sDienGiai = txtDienGiai.Text.ToString();
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.iID_NguoiBan = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls.bTienUSD = checkUSD.Checked;
                    cls.fPhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                    cls.fTienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                    cls.bTrangThaiBanHang = true;
                    cls.bCheck_BaoVe = cls1.bCheck_BaoVe.Value;
                    cls.bCheck_LaiXe = cls1.bCheck_LaiXe.Value;
                    cls.sThamChieu = txtThamChieu.Text.ToString();
                    cls.bDaXong = cls1.bDaXong.Value;
                    cls.sMaSoCongTeNo = txtMaCongTennor.Text.ToString();
                    cls.bTrangThai_KhoThanhPham = true;
                    cls.fTiGia = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
                    cls.sSoCongTeNo = txtSoCont.Text;
                    cls.Update();
                    int xxIDbanhangxx = iiID_banHang__;
                    // Insert chi tietbanhang
                    Luu_BienDongTaiKhoan(xxIDbanhangxx);
                    //Luu_TbThuChi(xxIDbanhangxx);
                    Luu_Chitiet_BanHang(xxIDbanhangxx);
                    this.Close();
                    if (_ucBH != null) _ucBH.btRefresh_Click(null, null);
                    if (_frmBH != null) _frmBH.btRefresh_Click(null, null);
                    MessageBox.Show("Đã lưu", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lưu dữ liệu thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void HienThi_Sua(int iiID_banHang__)
        {
            try
            {
                gridNguoiLap.EditValue = 11;
                checkUSD.Checked = true;

                clsBanHang_tbBanHang cls = new CtyTinLuong.clsBanHang_tbBanHang();
                cls.iID_BanHang = iiID_banHang__;
                DataTable dt = cls.SelectOne();
                if (dt.Rows[0]["MaSoCongTeNo"].ToString() != "")
                    txtMaCongTennor.Text = cls.sMaSoCongTeNo.Value;
                txtSoCont.Text = cls.sSoCongTeNo.Value;
                if (cls.bCheck_BaoVe == true) checkBaoVe_LaiXe.Checked = true;
                else checkBaoVe_LaiXe.Checked = false;


                txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();
                txtTiGia.Text = cls.fTiGia.Value.ToString();

                txtSoHoaDon.Text = cls.sSoHoaDon.Value.ToString();
                dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
                txtThamChieu.Text = cls.sThamChieu.Value;
                gridNguoiLap.EditValue = cls.iID_NguoiBan.Value;
                txtDienGiai.Text = cls.sDienGiai.Value.ToString();
                txtTongTienHangChuaVAT.Text = cls.fTongTienHangChuaVAT.Value.ToString();
                txtTongTienHangCoVAT.Text = cls.fTongTienHangCoVAT.Value.ToString();
                checkUSD.Checked = cls.bTienUSD.Value;
                if (cls.bTienUSD.Value == false) checkVNĐ.Checked = true;
                txtPhanTramVAT.Text = cls.fPhanTramVAT.Value.ToString();
                txtTienVAT.Text = cls.fTienVAT.Value.ToString();

                clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                cls2.iID_BanHang = iiID_banHang__;
                DataTable dt2 = cls2.Select_HienThiSuaDonHang();

                gridControl1.DataSource = dt2;


                clsNganHang_ChiTietBienDongTaiKhoanKeToan clstaikhoan = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clstaikhoan.iID_ChungTu = iiID_banHang__;
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
                dt2xx.Columns.Add("SoTaiKhoanCon");
                dt2xx.Columns.Add("TenTaiKhoanCon", typeof(string));
                dt2xx.Columns.Add("HienThi", typeof(string));
                if (dttaikhoanm.Rows.Count > 0)
                {
                    //for (int i = 0; i < dttaikhoanm.Rows.Count; i++)
                    //{
                    //    int ID_TaiKhoanKeToanCon = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                    //    clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    //    clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                    //    DataTable dtcon = clscon.SelectOne();
                    //    DataRow _ravi = dt2xx.NewRow();
                    //    _ravi["ID_ChiTietBienDongTaiKhoan"] = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    //    _ravi["ID_ChungTu"] = Convert.ToInt32(dttaikhoanm.Rows[i]["ID_ChungTu"].ToString());
                    //    _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt32(ID_TaiKhoanKeToanCon.ToString());
                    //    _ravi["No"] = CheckString.ConvertToDouble_My(dttaikhoanm.Rows[i]["No"].ToString());
                    //    _ravi["Co"] = CheckString.ConvertToDouble_My(dttaikhoanm.Rows[i]["Co"].ToString());
                    //    _ravi["TienUSD"] = Convert.ToBoolean(dttaikhoanm.Rows[i]["TienUSD"].ToString());
                    //    _ravi["TiGia"] = CheckString.ConvertToDouble_My(dttaikhoanm.Rows[i]["TiGia"].ToString());
                    //    _ravi["DaGhiSo"] = Convert.ToBoolean(dttaikhoanm.Rows[i]["DaGhiSo"].ToString());

                    //    _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                    //    _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                    //    _ravi["HienThi"] = "1";
                    //    dt2xx.Rows.Add(_ravi);
                    //}
                }
                //gridControl2.DataSource = dt2xx;
                gridControl2.DataSource = dttaikhoanm;

                //clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                //cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                //cls1.sThamChieu = txtSoChungTu.Text.ToString();
                //cls1.iID_DoiTuong = Convert.ToInt32(gridKH.EditValue.ToString());
                //DataTable dt1 = cls1.SelectOne_W_Ngay_ThamChieu_ID_DoiTuong();
                //if (dt1.Rows.Count > 0)
                //{
                //    int bientrangthaixx = Convert.ToInt32(dt1.Rows[0]["BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5"].ToString());
                //    if (bientrangthaixx == 4)
                //    {
                //        bienthangthai = 4;
                //        checkPhieuThu.Checked = true;
                //        checkBaoCo.Checked = false;
                //    }
                //    if (bientrangthaixx == 1)
                //    {
                //        bienthangthai = 1;
                //        checkPhieuThu.Checked = false;
                //        checkBaoCo.Checked = true;
                //    }
                //}
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
                using (clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa())
                {
                    DataTable dtvthh = clsvthhh.SelectAll();
                    dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                    DataView dvvthh = dtvthh.DefaultView;
                    DataTable newdtvthh = dvvthh.ToTable();


                    repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
                    repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
                    repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";
                }

                using (clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon())
                {
                    DataTable dtcon = clscon.SelectAll();
                    dtcon.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
                    DataView dvcon = dtcon.DefaultView;
                    DataTable newdtcon = dvcon.ToTable();

                    repositoryItemGridLookUpEdit2.DataSource = newdtcon;
                    repositoryItemGridLookUpEdit2.ValueMember = "ID_TaiKhoanKeToanCon";
                    repositoryItemGridLookUpEdit2.DisplayMember = "SoTaiKhoanCon";
                }

                using (clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu())
                {
                    DataTable newdtCaTruong = clsNguoi.T_SelectAll(4);
                    //dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
                    //DataView dvCaTruong = dtNguoi.DefaultView;
                    //DataTable newdtCaTruong = dvCaTruong.ToTable();

                    gridNguoiLap.Properties.DataSource = newdtCaTruong;
                    gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
                    gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
                }

                using (clsTbKhachHang cls = new clsTbKhachHang())
                {
                    DataTable newdt = cls.T_SelectAll();
                    gridKH.Properties.DataSource = newdt;
                    gridKH.Properties.ValueMember = "ID_KhachHang";
                    gridKH.Properties.DisplayMember = "MaKH";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        UCBanHang_BanHang _ucBH;
        BanHang_frmBangKeHoaDonBanHang _frmBH;
        public BanHang_FrmChiTietBanHang_Newwwwwwww(UCBanHang_BanHang ucBH = null, BanHang_frmBangKeHoaDonBanHang frmBH = null)
        {
            _frmBH = frmBH;
            _ucBH = ucBH;
            InitializeComponent();
        }

        private void BanHang_FrmChiTietBanHang_Newwwwwwww_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_LockUp();
                if (UCBanHang_BanHang.isClick == true)
                    HienThi_Sua(UCBanHang_BanHang.miiiID_BanHang);
                else if (BanHang_frmBangKeHoaDonBanHang.isClick == true)
                    HienThi_Sua(BanHang_frmBangKeHoaDonBanHang.miiiID_BanHang);
                txtSoChungTu.Focus();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                using (clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu())
                {
                    clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    DataTable dt = clsncc.SelectOne();
                    if (dt.Rows.Count > 0)
                    {
                        txtNguoiMuaHang.Text = dt.Rows[0]["TenNhanVien"].ToString();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtTienVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTienVAT.Text);
                txtTienVAT.Text = String.Format("{0:#,##0.00}", value);


                double tienvat;
                //tienno = CheckString.ConvertToDouble_My(txtTienNo.Text.ToString());
                tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                //txtTienCo.Text = (tienno + tienvat).ToString();

                double tongtienchuaVAT;
                tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void txtPhanTramVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double PhanTramVAT, tongtienhang, tienvat, tongtienchuaVAT;
                tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                PhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                txtTienVAT.Text = (tongtienhang * PhanTramVAT / 100).ToString();
                tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTongTienHangChuaVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                double tongtienchuaVAT, tienvat;
                tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridview_ChiTietBanHang.SetRowCellValue(gridview_ChiTietBanHang.FocusedRowHandle, clHienThi1, "0");
            gridview_ChiTietBanHang.SetRowCellValue(gridview_ChiTietBanHang.FocusedRowHandle, clSoLuong, 0);
        }

      
        private void txtTongTienHangCoVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);
                
                double tienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                double tienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                double tongtiencoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                gridView8.SetRowCellValue(0, clNo, tongtiencoVAT);
                gridView8.SetRowCellValue(0, clCo, 0);
                gridView8.SetRowCellValue(1, clNo, 0);
                gridView8.SetRowCellValue(1, clCo, tienVAT);
                gridView8.SetRowCellValue(2, clNo, 0);
                gridView8.SetRowCellValue(2, clCo, tienchuaVAT);
                
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ntPrint_hoadon_Click(object sender, EventArgs e)
        {
            try
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

                    mdbTongTienVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    mdbTienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                    mdbTienChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                    DataTable dttaikhoan = (DataTable)gridControl2.DataSource;
                    if (dttaikhoan.Rows.Count >= 2)
                    {
                        try
                        {
                            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                            int id_131 = Convert.ToInt32(dttaikhoan.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                            int id_VAT = Convert.ToInt32(dttaikhoan.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                            int id_511 = Convert.ToInt32(dttaikhoan.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                            clscon.iID_TaiKhoanKeToanCon = id_131;
                            DataTable dtcon1 = clscon.SelectOne();
                            msSoTKNo = clscon.sSoTaiKhoanCon.Value;
                            clscon.iID_TaiKhoanKeToanCon = id_511;
                            DataTable dtcon2 = clscon.SelectOne();
                            msSoTKCo = clscon.sSoTaiKhoanCon.Value;

                            mdbSoTienNo = CheckString.ConvertToDouble_My(dttaikhoan.Rows[0]["No"].ToString());
                            mdbSoTienCo = CheckString.ConvertToDouble_My(dttaikhoan.Rows[2]["Co"].ToString());


                            double Nophatsinh, Cophatsinh, nodaukyxxx, codaukyxx;
                            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls2 = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                            DataTable dtphasinh = cls2.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_W_NhoHon_NgayThang_and_Bool_TonDauKy_False(id_131, DateTime.Today.AddDays(1));
                            cls2.iID_TaiKhoanKeToanCon = id_131;
                            DataTable dtdauky = cls2.SelectAll_Sum_Co_No_W_ID_TaiKhoanKeToanCon_and_Bool_TonDauKy_True();

                            if (dtdauky.Rows.Count > 0)
                            {
                                nodaukyxxx = CheckString.ConvertToDouble_My(dtdauky.Rows[0]["No"].ToString());
                                codaukyxx = CheckString.ConvertToDouble_My(dtdauky.Rows[0]["Co"].ToString());
                            }
                            else codaukyxx = nodaukyxxx = 0;

                            if (dtphasinh.Rows.Count > 0)
                            {
                                Nophatsinh = CheckString.ConvertToDouble_My(dtphasinh.Rows[0]["No"].ToString());
                                Cophatsinh = CheckString.ConvertToDouble_My(dtphasinh.Rows[0]["Co"].ToString());
                            }
                            else Nophatsinh = Cophatsinh = 0;
                            mdbGiaHanNo = 0;
                            mdbNoCu = nodaukyxxx + Nophatsinh - codaukyxx - Cophatsinh;
                            mdbNoMoi = mdbTongTienVAT;
                            mdbTongNo = mdbNoCu + mdbNoMoi;
                        }
                        catch (Exception ea)
                        {
                            MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    clsSoTienBangChu cls = new clsSoTienBangChu();
                    if (checkUSD.Checked == false)
                        msSoTienBangChu = cls.DocTienBangChu(CheckString.ConvertToDouble_My(mdbTongTienVAT), " đồng.");
                    else msSoTienBangChu = cls.DocTienBangChu(CheckString.ConvertToDouble_My(mdbTongTienVAT), " USD.");

                    // =
                    //;
                    //public static double mdbGiaHanNo, mdbNoCu, mdbNoMoi, , , , , , mdbTongNo;

                    mbPrint_HoaDon = true;
                    mbPrint_XuatKho = false;


                    frmPrint_BanHang ff = new frmPrint_BanHang();
                    ff.Show();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtSoHoaDon.Focus();
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtMaCongTennor.Focus();
            }
        }

        private void txtMaCongTennor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtThamChieu.Focus();
            }
        }

        private void txtThamChieu_KeyPress(object sender, KeyPressEventArgs e)
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
                txtNguoiMuaHang.Focus();
            }
        }

        private void txtNguoiMuaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridKH.Focus();
            }
        }

        private void gridKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTiGia.Focus();
            }
        }

        private void txtTongTienHangChuaVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTiGia.Focus();
            }
        }

        private void txtTiGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPhanTramVAT.Focus();
            }
        }

        private void txtPhanTramVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTienVAT.Focus();
            }
        }

        private void txtTienVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTongTienHangCoVAT.Focus();
            }
        }

        private void txtTongTienHangCoVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLuu.Focus();
            }
        }

        private void gridview_ChiTietBanHang_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridview_ChiTietBanHang_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clID_VTHH)
                {
                    clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                    cls.iID_VTHH = Convert.ToInt32(gridview_ChiTietBanHang.GetRowCellValue(e.RowHandle, e.Column));
                    DataTable dt = cls.SelectOne();
                    gridview_ChiTietBanHang.SetRowCellValue(e.RowHandle, clTenVTHH, cls.sTenVTHH.Value);
                    gridview_ChiTietBanHang.SetRowCellValue(e.RowHandle, clDonViTinh, cls.sDonViTinh.Value);
                    gridview_ChiTietBanHang.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                    gridview_ChiTietBanHang.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridview_ChiTietBanHang.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia));
                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridview_ChiTietBanHang.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }

                if (e.Column == clSoLuong)
                {
                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia));
                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridview_ChiTietBanHang.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                if (e.Column == clDonGia)
                {
                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clDonGia));
                    if (gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridview_ChiTietBanHang.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();

                try
                {
                    decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                    txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                    double tongtienchuaVAT, tienvat;
                    tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                    tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                    txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();

                }
                catch (Exception ea)
                {
                    MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridview_ChiTietBanHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void gridNguoiLap_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridNguoiLap.Properties.View.Columns[0].Visible = false;
        }

        private void gridview_ChiTietBanHang_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                DataView dv = view.DataSource as DataView;
                if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
                {
                    e.Visible = false;
                    e.Handled = true;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridKH_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridKH.Properties.View.Columns[0].Visible = false;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            try
            {
                if (UCBanHang_BanHang.isClick == true)
                    LuuDuLieu(UCBanHang_BanHang.miiiID_BanHang);
                else if (BanHang_frmBangKeHoaDonBanHang.isClick == true)
                    LuuDuLieu(BanHang_frmBangKeHoaDonBanHang.miiiID_BanHang);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void gridView8_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clID_TaiKhoanKeToanCon)
                {
                    using (clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon())
                    {
                        cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView8.GetRowCellValue(e.RowHandle, e.Column));
                        int kk = Convert.ToInt32(gridView8.GetRowCellValue(e.RowHandle, e.Column));
                        DataTable dt = cls.SelectOne();
                        if (dt.Rows.Count > 0)
                        {
                            gridView8.SetRowCellValue(e.RowHandle, clID_TaiKhoanKeToanCon, kk);
                            //gridView8.SetRowCellValue(e.RowHandle, ID_TaiKhoanKeToanMe, cls.iID_TaiKhoanKeToanMe.Value);
                            gridView8.SetRowCellValue(e.RowHandle, clTenTaiKhoanCon, dt.Rows[0]["TenTaiKhoanCon"].ToString());
                            gridView8.SetRowCellValue(e.RowHandle, HienThi, "1");
                            gridView8.SetRowCellValue(e.RowHandle, TienUSD, checkUSD.Checked);
                            gridView8.SetRowCellValue(e.RowHandle, clCo, 0);
                            gridView8.SetRowCellValue(e.RowHandle, clNo, 0);
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        
        private void gridKH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = Convert.ToInt16(gridKH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    HienThi_GridConTrol_SauKhiChon();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBaoVe_LaiXe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe_LaiXe.Checked == true)
                {
                    if (UCBanHang_BanHang.isClick == true)
                        update_baove(UCBanHang_BanHang.miiiID_BanHang);
                    else if (BanHang_frmBangKeHoaDonBanHang.isClick == true)
                        update_baove(BanHang_frmBangKeHoaDonBanHang.miiiID_BanHang);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
        private void linkKeHoachSanXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                mdbSoLuongXuat = CheckString.ConvertToDouble_My(gridview_ChiTietBanHang.GetRowCellValue(0, clSoLuong).ToString());
                BanHang_FrmThamChieuKeHoachSanXuat ff = new CtyTinLuong.BanHang_FrmThamChieuKeHoachSanXuat();
                ff.Show();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        dttttt2.Rows[i]["TiGia"] = txtTiGia.Text.ToString();
                    }
                    gridControl2.DataSource = dttttt2;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btPrint_XuatKho_Click(object sender, EventArgs e)
        {
            try
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
                    mdbTongTienVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    msDienGiai = txtDienGiai.Text.ToString();
                    frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                    ff.Show();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
    }
}
