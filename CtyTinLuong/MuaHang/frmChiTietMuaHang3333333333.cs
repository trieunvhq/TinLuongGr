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
    public partial class frmChiTietMuaHang3333333333 : Form
    {        
       
        public static bool mbPrint, mbTraLaiHangMua;
        public static int miiID_nguoiLap;
        public static DateTime mdangaythang;
        public static string mssochungtu, mssohoadon, msNguoiGiaoHang, msNguoiMuaHang, msTKNo, msTKCo, msTKVAT;
        public static decimal mdcSoTienNo, mdcSoTienCo, mdcSoTienVAT, mdcTongTienCoVAT;
        public static DataTable mdtPrint;
        int bienthangthai, iiiID_MuaHang;
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
                    txtsochungtu_tbThuChi.Text = "BC " + xxx2 + "";
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
        private void  HienThi_GridConTrol_SauKhiChon()
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

            clsTbNhaCungCap clsncc = new clsTbNhaCungCap();
            clsncc.iID_NhaCungCap = Convert.ToInt16(gridNCC.EditValue.ToString());
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
            if(checkTraLaiHangMua.Checked==false)
            {
                _ravi["No"] = 0;
                _ravi["Co"] = tongtienhangcoVAT;
            }
            else
            {
                _ravi["No"] = tongtienhangcoVAT;
                _ravi["Co"] = 0;
            }
           
            _ravi["TienUSD"] = checkUSD.Checked;
            _ravi["TiGia"] = 1;
            _ravi["DaGhiSo"] = false;
            _ravi["GhiChu"] = "";
            _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
            _ravi["TenTaiKhoanCon"] = dtcon.Rows[0]["TenTaiKhoanCon"].ToString();
            _ravi["HienThi"] = "1";
            dt2xx.Rows.Add(_ravi);
            
            DataRow _ravi2 = dt2xx.NewRow();
            clscon.iID_TaiKhoanKeToanCon = 46;
            DataTable dtcon2 = clscon.SelectOne();
            _ravi2["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi2["ID_ChungTu"] = 0;
            _ravi2["ID_TaiKhoanKeToanCon"] = 46;
            if (checkTraLaiHangMua.Checked == false)
            {
                _ravi2["No"] = tongtienhang_ChuaCoVAT;
                _ravi2["Co"] = 0;
            }
            else
            {
                _ravi2["No"] = 0;
                _ravi2["Co"] = tongtienhang_ChuaCoVAT;
            }
          
            _ravi2["TienUSD"] = checkUSD.Checked;
            _ravi2["TiGia"] = 1;
            _ravi2["DaGhiSo"] = false;
            _ravi2["GhiChu"] = "";
            _ravi2["SoTaiKhoanCon"] = "46";
            _ravi2["TenTaiKhoanCon"] = dtcon2.Rows[0]["TenTaiKhoanCon"].ToString();
            _ravi2["HienThi"] = "1";
            dt2xx.Rows.Add(_ravi2);
            if (tienVAT > 0)
            {
                clscon.iID_TaiKhoanKeToanCon = 28;
                DataTable dtcon3 = clscon.SelectOne();

                DataRow _ravi3 = dt2xx.NewRow();
                _ravi3["ID_ChiTietBienDongTaiKhoan"] = 0;
                _ravi3["ID_ChungTu"] = 0;
                _ravi3["ID_TaiKhoanKeToanCon"] = 28;
                if (checkTraLaiHangMua.Checked == false)
                {
                    _ravi3["No"] = tienVAT;
                    _ravi3["Co"] = 0;
                }
                else
                {
                    _ravi3["No"] = 0;
                    _ravi3["Co"] = tienVAT;
                }
               
                _ravi3["TienUSD"] = checkUSD.Checked;
                _ravi3["TiGia"] = 1;
                _ravi3["DaGhiSo"] = false;
                _ravi3["GhiChu"] = "";
                _ravi3["SoTaiKhoanCon"] = "28";
                _ravi3["TenTaiKhoanCon"] = dtcon3.Rows[0]["TenTaiKhoanCon"].ToString();
                _ravi3["HienThi"] = "1";
                dt2xx.Rows.Add(_ravi3);
            }
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
            else if (gridNCC.EditValue.ToString() == "")
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

        private void Luu_Chitiet_MuaHang(int xxxID_MuaHang)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();

                clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
                DataTable dt2_cu = new DataTable();
                cls2.iID_MuaHang = xxxID_MuaHang;
                dt2_cu = cls2.SelectAll_W_ID_MuaHang();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                      
                        cls2.iID_MuaHang = xxxID_MuaHang;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai_W_ID_MuaHang();
                    }

                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    int ID_VTHHxxx= Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_MuaHang = iiiID_MuaHang;
                    if (dt_gridcontrol.Rows[i]["SoLuong"].ToString() != "")
                        cls2.fSoLuong = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    else cls2.fSoLuong = 0;
                    if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                        cls2.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                    else cls2.fDonGia = 0;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();

                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietMuaHang = Convert.ToInt32(foundRows[0]["ID_ChiTietMuaHang"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
           
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_MuaHang = xxxID_MuaHang;
                dt2_moi11111 = cls2.SelectAll_W_ID_MuaHang();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietBanHangxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietMuaHang"].ToString());
                    cls2.iID_ChiTietMuaHang = ID_ChiTietBanHangxxxx;
                    cls2.Delete();
                }


            }

        }

        private void Luu_BienDongTaiKhoan(int xxxID_MuaHang)
        {
            if (!KiemTraLuu()) return;
            else
            {

                clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clsxx.iID_ChungTu = xxxID_MuaHang;
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
                    clsxx.iID_ChungTu = xxxID_MuaHang;
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
                    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 1;
                    clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
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
                        clsxx.iID_ChungTu = xxxID_MuaHang;
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
                        clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
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
                            clsxx.iID_ChungTu = xxxID_MuaHang;
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
                            clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
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

        private void Luu_TbThuChi(int xxxID_MuaHang)
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
                cls1.sDoiTuong = txtTenNhaCungCap.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = checkUSD.Checked;
                cls1.fTiGia = Convert.ToDouble(txtTiGia.Text.ToString());
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                cls1.bDaGhiSo = false;
                cls1.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
                cls1.iBienMuaHang1_BanHang2_ConLai_0 = 1;
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
        private void LuuDuLieu_Chi_Luu()
        {
            if (!KiemTraLuu()) return ;
            else
            {
                clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
                bool bguidulieu;
                if (UCMuaHang.mbbTheMoi_DonHang == false)
                {
                    iiiID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                    cls.iID_MuaHang = iiiID_MuaHang;
                    DataTable dt1 = cls.SelectOne();
                    bguidulieu = cls.bGuiDuLieu.Value;
                  
                }
                else
                {
                    bguidulieu = false;
                   
                }
                cls.daNgayChungTu = dteNgayChungTu.DateTime;
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.sSoHoaDon = txtSoHoaDon.Text.ToString();
                cls.iIDNhaCungCap = Convert.ToInt32(gridNCC.EditValue.ToString());
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.fTongTienHangChuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                cls.fTongTienHangCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                cls.fPhanTramVAT = Convert.ToDouble(txtPhanTramVAT.Text.ToString());
                cls.fTienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                cls.iID_NguoiMua = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls.bGuiDuLieu = bguidulieu;
                cls.bTonTai = true;
                cls.bTrangThaiNhapKho = false;
                cls.bNgungTheoDoi = false;
                cls.bMuaHangNhapKho = checkMuaHangNhapKho.Checked;
                cls.bTienUSD = checkUSD.Checked;
                cls.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls.bCheckTraLaiNhaCungCap = checkTraLaiHangMua.Checked;
                if (UCMuaHang.mbbTheMoi_DonHang == true)
                {
                    cls.Insert();
                    iiiID_MuaHang = cls.iID_MuaHang.Value;
                }
                else
                {
                    iiiID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                    cls.iID_MuaHang = iiiID_MuaHang;
                    cls.Update();
                }
                // luwu chi tiet mua hang
                Luu_Chitiet_MuaHang(iiiID_MuaHang);
                Luu_BienDongTaiKhoan(iiiID_MuaHang);
              
            }
        }
        private void LuuDuLieu_Va_GuiDuLieu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
                cls.daNgayChungTu = dteNgayChungTu.DateTime;
                cls.sSoChungTu = txtSoChungTu.Text.ToString();
                cls.sSoHoaDon = txtSoHoaDon.Text.ToString();
                cls.iIDNhaCungCap = Convert.ToInt32(gridNCC.EditValue.ToString());
                cls.sDienGiai = txtDienGiai.Text.ToString();

                cls.fTongTienHangChuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                cls.fTongTienHangCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                cls.fPhanTramVAT = Convert.ToDouble(txtPhanTramVAT.Text.ToString());
                cls.fTienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                cls.iID_NguoiMua = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls.bGuiDuLieu = true;
                cls.bTonTai = true;
                cls.bTrangThaiNhapKho = false;
                cls.bNgungTheoDoi = false;
                cls.bMuaHangNhapKho = checkMuaHangNhapKho.Checked;
                cls.bTienUSD = checkUSD.Checked;
                cls.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls.bCheckTraLaiNhaCungCap = checkTraLaiHangMua.Checked;
                if (UCMuaHang.mbbTheMoi_DonHang == true)
                {
                    cls.Insert();
                    iiiID_MuaHang = cls.iID_MuaHang.Value;
                } 
                else
                {

                    iiiID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;                    
                    cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                    cls.Update();
                }
                // luwu chi tiet mua hang
                Luu_Chitiet_MuaHang(iiiID_MuaHang);
                Luu_BienDongTaiKhoan(iiiID_MuaHang);
                Luu_TbThuChi(iiiID_MuaHang);              
            }
        }                        
        private void HienThi_themMoi()
        {
            checkBaoVe_LaiXe.Checked = false;
            if (frmMuaHang2222.mbTraLaiHangMua == true)
                checkTraLaiHangMua.Checked = true;
            else checkTraLaiHangMua.Checked = false;
            gridNguoiLap.EditValue = 12;
            //btBaoVe.Enabled = false;
            //btLaiXe.Enabled = false;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));

            gridControl1.DataSource = dt2;
            //gridTKNo.EditValue = 46;
            //gridTKVAT.EditValue = 79;
            checkMuaHangNhapKho.Checked = true;
            checkVNĐ.Checked = true;
            clsMH_tbMuaHang cls2 = new clsMH_tbMuaHang();
            DataTable dtxxxx2xxx = cls2.SelectAll();
            dtxxxx2xxx.DefaultView.RowFilter = "TonTai=True";
            DataView dv2 = dtxxxx2xxx.DefaultView;

            DataTable newdt2 = dv2.ToTable();
            int k = newdt2.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "MH 1";
            }
            else
            {
                string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                txtSoChungTu.Text = "MH " + xxx2 + "";
            }
            dteNgayChungTu.EditValue = DateTime.Today;

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
            gridControl2.DataSource = dt2xx;
            checkBaoNo.Checked = true;
        }
        private void HienThi_Sua()
        {
            clsMH_tbMuaHang cls = new CtyTinLuong.clsMH_tbMuaHang();
            cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
            DataTable dt = cls.SelectOne();
            if (cls.bCheck_BaoVe == true) checkBaoVe_LaiXe.Checked = true;
            else checkBaoVe_LaiXe.Checked = false;
            if (UCMuaHang.mbCopY == true)
            {
                checkBaoVe_LaiXe.Checked = false;
                clsMH_tbMuaHang cls2xxx = new clsMH_tbMuaHang();
                DataTable dtxxxx2xxx = cls2xxx.SelectAll();
                dtxxxx2xxx.DefaultView.RowFilter = "TonTai=True";
                DataView dv2 = dtxxxx2xxx.DefaultView;

                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtSoChungTu.Text = "MH 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;                    
                     txtSoChungTu.Text = "MH " + xxx2 + "";
                }
            }
            else
            {
                txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();
            }
           
            txtSoHoaDon.Text = cls.sSoHoaDon.Value.ToString();
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            checkMuaHangNhapKho.Checked = cls.bMuaHangNhapKho.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiMua.Value;
            //gridNCC.EditValue = cls.iIDNhaCungCap.Value;
            txtDienGiai.Text = cls.sDienGiai.Value.ToString();
            txtTongTienHangChuaVAT.Text = cls.fTongTienHangChuaVAT.Value.ToString();
            txtTongTienHangCoVAT.Text = cls.fTongTienHangCoVAT.Value.ToString();
            checkUSD.Checked = cls.bTienUSD.Value;
            if (cls.bTienUSD.Value == false) checkVNĐ.Checked = true;
            txtPhanTramVAT.Text = cls.fPhanTramVAT.Value.ToString();
            txtTienVAT.Text = cls.fTienVAT.Value.ToString();
            if (dt.Rows[0]["NguoiGiaoHang"].ToString() == "")
                txtNguoiGiaoHang.Text = "";
            else
                txtNguoiGiaoHang.Text = cls.sNguoiGiaoHang.Value.ToString();

            checkTraLaiHangMua.Checked = cls.bCheckTraLaiNhaCungCap.Value;           
                
         
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();           
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
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
                _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
                _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
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
            clstaikhoan.iID_ChungTu = UCMuaHang.miiiID_Sua_DonHang;
            clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
            clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
            DataTable dttaikhoanm = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
          
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
                    _ravi["GhiChu"] ="";
                    _ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
                    _ravi["TenTaiKhoanCon"] = clscon.sTenTaiKhoanCon.Value;
                    _ravi["HienThi"] = "1";
                    dt2xx.Rows.Add(_ravi);
                }
            }
            gridControl2.DataSource = dt2xx;

            gridNCC.EditValue = cls.iIDNhaCungCap.Value;
        }
        private void HienThi_Copy()
        {
            if (frmMuaHang2222.mbTraLaiHangMua == true)
                checkTraLaiHangMua.Checked = true;
            else checkTraLaiHangMua.Checked = false;
            clsMH_tbMuaHang cls = new CtyTinLuong.clsMH_tbMuaHang();
            cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
            DataTable dt = cls.SelectOne();
            if (UCMuaHang.mbCopY == true)
            {
                checkBaoVe_LaiXe.Checked = false;
                clsMH_tbMuaHang cls2xxx = new clsMH_tbMuaHang();
                DataTable dtxxxx2xxx = cls2xxx.SelectAll();
                dtxxxx2xxx.DefaultView.RowFilter = "TonTai=True";
                DataView dv2 = dtxxxx2xxx.DefaultView;

                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtSoChungTu.Text = "MH 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                     txtSoChungTu.Text = "MH " + xxx2 + "";
                }
            }
            else
            {
                txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();
            }

            txtSoHoaDon.Text = cls.sSoHoaDon.Value.ToString();
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            checkMuaHangNhapKho.Checked = cls.bMuaHangNhapKho.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiMua.Value;           
            txtDienGiai.Text = cls.sDienGiai.Value.ToString();
            txtTongTienHangChuaVAT.Text = cls.fTongTienHangChuaVAT.Value.ToString();
            txtTongTienHangCoVAT.Text = cls.fTongTienHangCoVAT.Value.ToString();
            checkUSD.Checked = cls.bTienUSD.Value;
            if (cls.bTienUSD.Value == false) checkVNĐ.Checked = true;
            txtPhanTramVAT.Text = cls.fPhanTramVAT.Value.ToString();
            txtTienVAT.Text = cls.fTienVAT.Value.ToString();
            if (dt.Rows[0]["NguoiGiaoHang"].ToString() == "")
                txtNguoiGiaoHang.Text = "";
            else
                txtNguoiGiaoHang.Text = cls.sNguoiGiaoHang.Value.ToString();                      

            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
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
                _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
                _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
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
            clstaikhoan.iID_ChungTu = UCMuaHang.miiiID_Sua_DonHang;
            clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
            clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
            DataTable dttaikhoanm = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();

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

            gridNCC.EditValue = cls.iIDNhaCungCap.Value;
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
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable newdt = dv.ToTable();

            gridNCC.Properties.DataSource = newdt;
            gridNCC.Properties.ValueMember = "ID_NhaCungCap";
            gridNCC.Properties.DisplayMember = "MaNhaCungCap";
        }
        public frmChiTietMuaHang3333333333()
        {
            InitializeComponent();
        }
        private void checkVNĐ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVNĐ.Checked == true)
            {
                checkUSD.Checked = false;
                txtTiGia.Text = "1";
                txtTiGia.ReadOnly = true;
                try
                {
                    DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TienUSD"] = false;
                        }
                        gridControl2.DataSource = dttttt2;
                    }
                }
                catch
                {
                }
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
            {
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
        }
        private void frmChiTietMuaHang3333333333_Load(object sender, EventArgs e)
        {
                 
            txtTienVAT.Text = "0";
            
            Load_LockUp();
            if (UCMuaHang.mbbTheMoi_DonHang == true)
            {
                HienThi_themMoi();
            }
            else if (UCMuaHang.mbCopY == true)
            {
                HienThi_Copy();
            }
            else
            {
                HienThi_Sua();
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


                double  tienvat;
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
                    gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

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

            try
            {
                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                double tongtienchuaVAT, tienvat;
                tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                tienvat = Convert.ToDouble(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
                //txtTienNo.Text = txtTongTienHangChuaVAT.Text;
                //txtTienCo.Text = txtTongTienHangCoVAT.Text;
            }
            catch
            {

            }
        }
        private void txtPhanTramVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double PhanTramVAT, tongtienhang,tienvat,tongtienchuaVAT;
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
        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                double tongtienchuaVAT, tienVAT;
                tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                tienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienVAT).ToString();
                //double tongtienCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
              
                //if (tienVAT == 0)
                //{
                //    gridView8.SetRowCellValue(0, clNo, tongtienCoVAT);
                //    gridView8.SetRowCellValue(0, clCo, 0);
                //    gridView8.SetRowCellValue(1, clNo, 0);
                //    gridView8.SetRowCellValue(1, clCo, tongtienCoVAT);
                //}
                //else
                //{
                //    gridView8.SetRowCellValue(0, clNo, tongtienchuaVAT);
                //    gridView8.SetRowCellValue(0, clCo, 0);

                //    gridView8.SetRowCellValue(1, clNo, tienVAT);
                //    gridView8.SetRowCellValue(1, clCo, 0);

                //    gridView8.SetRowCellValue(2, clNo, 0);
                //    gridView8.SetRowCellValue(2, clCo, tongtienCoVAT);
                //}
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
        private void checkMuaHangNhapKho_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkMuaHangNhapKho.Checked == true)
            //    checkMuaHangNhapKho.CheckState = CheckState.Checked;
            //if (checkMuaHangNhapKho.Checked == false)
            //    checkMuaHangNhapKho.CheckState = CheckState.Checked;

        }
        private void txtTiGia_TextChanged(object sender, EventArgs e)
        {
            if (txtTiGia.Text.ToString() != "1")
            {
                double tigiaxx = Convert.ToDouble(txtTiGia.Text.ToString());
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                try
                {
                    if (dttttt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttttt2.Rows.Count; i++)
                        {
                            dttttt2.Rows[i]["TiGia"] = tigiaxx;
                        }
                        gridControl2.DataSource = dttttt2;
                    }
                }
                catch
                {
                }

            }
        }
        private void txtTongTienHangCoVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);

               // double tongtienCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
               // double tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
               // double tienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
               // if(tienVAT==0)
               // {
               //     gridView8.SetRowCellValue(0, clNo, 0);
               //     gridView8.SetRowCellValue(0, clCo, tongtienCoVAT);
               //     gridView8.SetRowCellValue(1, clNo, tongtienCoVAT);
               //     gridView8.SetRowCellValue(1, clCo, 0);
               // }
               //else
               // {
               //     gridView8.SetRowCellValue(0, clNo, 0);
               //     gridView8.SetRowCellValue(0, clCo, tongtienCoVAT);

               //     gridView8.SetRowCellValue(1, clNo, tienVAT);
               //     gridView8.SetRowCellValue(1, clCo, 0);

               //     gridView8.SetRowCellValue(2, clNo, 0);
               //     gridView8.SetRowCellValue(2, clCo, tongtienCoVAT);
               // }
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
     
        private void gridNCC_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbNhaCungCap clsncc = new clsTbNhaCungCap();
                clsncc.iID_NhaCungCap = Convert.ToInt32(gridNCC.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenNhaCungCap.Text = dt.Rows[0]["TenNhaCungCap"].ToString();
                    //if (UCMuaHang.mbbTheMoi_DonHang == true)
                    //{
                        HienThi_GridConTrol_SauKhiChon();
                    //}

                }


            }
            catch
            {

            }
        }
        private void btPrint_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else
            {
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                DataTable dttttt2 = dv1212.ToTable();               

                string shienthi = "1";
               
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                mdtPrint = dv.ToTable();
                if(mdtPrint.Rows.Count>0)
                {
                    mbTraLaiHangMua = checkTraLaiHangMua.Checked;
                    mbPrint = true;
                    miiID_nguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    mdangaythang = dteNgayChungTu.DateTime;
                    mssochungtu = txtSoChungTu.Text.ToString();
                    mssohoadon = txtSoHoaDon.Text.ToString();
                    if (txtNguoiGiaoHang.Text.ToString() != "")
                        msNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    else msNguoiGiaoHang = txtTenNhaCungCap.Text.ToString();
                    msNguoiMuaHang = txtNguoiMuaHang.Text.ToString();

                    string shienthixxx = "1";
                    DataTable dtttttcccc2 = (DataTable)gridControl2.DataSource;
                    dtttttcccc2.DefaultView.RowFilter = "HienThi=" + shienthixxx + "";
                    DataView dvccc222 = dtttttcccc2.DefaultView;
                    DataTable dv3cccccc = dvccc222.ToTable();
                    if (dv3cccccc.Rows.Count > 0)
                    {
                        clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                        cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[0]["SoTaiKhoanCon"].ToString());
                        DataTable dt1 = cls.SelectOne();
                        msTKCo = dt1.Rows[0]["SoTaiKhoanCon"].ToString();

                        cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[1]["SoTaiKhoanCon"].ToString());
                        DataTable dt2 = cls.SelectOne();
                        msTKNo = dt2.Rows[0]["SoTaiKhoanCon"].ToString();
                        if (dv3cccccc.Rows.Count == 3)
                        {
                            cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[2]["SoTaiKhoanCon"].ToString());
                            DataTable dt3 = cls.SelectOne();
                            msTKVAT = dt3.Rows[0]["SoTaiKhoanCon"].ToString();
                        }
                        else msTKVAT = "";
                        mdcSoTienNo = Convert.ToDecimal(txtTongTienHangChuaVAT.Text.ToString());
                        mdcSoTienCo = Convert.ToDecimal(txtTongTienHangCoVAT.Text.ToString());
                    }
                    else
                    {
                        msTKCo = "";
                        msTKNo = "";
                        msTKVAT = "";
                        mdcSoTienNo = 0;
                        mdcSoTienCo = 0;
                    }
                    mdcSoTienVAT = Convert.ToDecimal(txtTienVAT.Text.ToString());
                    mdcTongTienCoVAT = Convert.ToDecimal(txtTongTienHangCoVAT.Text.ToString());

                    frmPrintMuaHang ff = new frmPrintMuaHang();
                    ff.Show();
                }
                
            }
            
        
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Chi_Luu();
            MessageBox.Show("Đã lưu");
           // this.Close();

        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GuiDuLieu();
            MessageBox.Show("Đã lưu và gửi dữ liệu");
           // this.Close();



        }

        private void frmChiTietMuaHang3333333333_FormClosed(object sender, FormClosedEventArgs e)
        {
            UCMuaHang.mbbTheMoi_DonHang = true;
            UCMuaHang.mbCopY = false;

        }

        private void checkBaoVe_LaiXe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe_LaiXe.Checked == true)
                {
                    if (UCMuaHang.mbbTheMoi_DonHang == false)
                    {
                        int ID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
                        cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        cls.Update_LaiXe();
                        cls.Update_BaoVe();
                        MessageBox.Show("Đã qua của bảo vệ, lái xe");
                    }
                }
            }
            catch
            {

            }

        }

        private void btLuu_Copy_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Chi_Luu();
            MessageBox.Show("Đã lưu");
            UCMuaHang.mbbTheMoi_DonHang = true;


            clsMH_tbMuaHang cls2 = new clsMH_tbMuaHang();
            DataTable dt2xxx = cls2.SelectAll();
            dt2xxx.DefaultView.RowFilter = "TonTai=True";
            DataView dv2 = dt2xxx.DefaultView;

            DataTable newdt2 = dv2.ToTable();
            int k = newdt2.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "MH 1";
            }
            else
            {
                string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                if (xxx2 >= 10000)
                    txtSoChungTu.Text = "MH 1";
                else txtSoChungTu.Text = "MH " + xxx2 + "";
            }           
        }


      
        private void btLuu_Gui_Copy_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GuiDuLieu();
            UCMuaHang.mbbTheMoi_DonHang = true;
            clsMH_tbMuaHang cls2 = new clsMH_tbMuaHang();
            DataTable dt2xxx = cls2.SelectAll();
            dt2xxx.DefaultView.RowFilter = "TonTai=True";
            DataView dv2 = dt2xxx.DefaultView;

            DataTable newdt2 = dv2.ToTable();
            int k = newdt2.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "MH 1";
            }
            else
            {
                string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                if (xxx2 >= 10000)
                    txtSoChungTu.Text = "MH 1";
                else txtSoChungTu.Text = "MH " + xxx2 + "";
            }

            MessageBox.Show("Đã lưu");
            
        }

        private void checkPhieuChi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPhieuChi.Checked == true)
            {
                bienthangthai = 3;
                checkBaoNo.Checked = false;
            }
        }

        private void checkBaoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBaoNo.Checked == true)
            {
                bienthangthai = 2;
                checkPhieuChi.Checked = false;
            }
        }

        private void txtTienVAT_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTienVAT.Text);
                txtTienVAT.Text = String.Format("{0:#,##0.00}", value);
                //double tongtienCoVAT = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                //double tongtienchuaVAT = Convert.ToDouble(txtTongTienHangChuaVAT.Text.ToString());
                //double tienVAT = Convert.ToDouble(txtTienVAT.Text.ToString());
                //if (tienVAT == 0)
                //{
                //    gridView8.SetRowCellValue(0, clNo, tongtienCoVAT);
                //    gridView8.SetRowCellValue(0, clCo, 0);
                //    gridView8.SetRowCellValue(1, clNo, 0);
                //    gridView8.SetRowCellValue(1, clCo, tongtienCoVAT);
                //}
                //else
                //{
                //    gridView8.SetRowCellValue(0, clNo, tongtienchuaVAT);
                //    gridView8.SetRowCellValue(0, clCo, 0);

                //    gridView8.SetRowCellValue(1, clNo, tienVAT);
                //    gridView8.SetRowCellValue(1, clCo, 0);

                //    gridView8.SetRowCellValue(2, clNo, 0);
                //    gridView8.SetRowCellValue(2, clCo, tongtienCoVAT);
                //}
            }
            catch
            {

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
                    gridView8.SetRowCellValue(e.RowHandle, TienUSD, false);
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
    }
}
