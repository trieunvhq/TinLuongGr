using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
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
        public static DataTable mdtPrint, _dataVthh, _dataVAT;
        
        int iiiID_MuaHang;
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

        public string SoChungTu_NPL()
        {
            string sochungtu = "";
            clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                sochungtu = "NKNPL 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "NKNPL 1";
                else sochungtu = "NKNPL " + xxx2.ToString() + "";
            }
            return sochungtu;
           
        }

        private void HienThi_GridConTrol_SauKhiChon()
        {
            _dataVthh.Clear();
            _dataVAT.Clear();
            gridControl2.DataSource = null;
            //DataTable dt2xx = new DataTable();
            //dt2xx.Columns.Add("ID_ChiTietBienDongTaiKhoan", typeof(int));
            //dt2xx.Columns.Add("ID_ChungTu", typeof(int));
            //dt2xx.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            //dt2xx.Columns.Add("No", typeof(double));
            //dt2xx.Columns.Add("Co", typeof(double));
            //dt2xx.Columns.Add("TienUSD", typeof(bool));
            //dt2xx.Columns.Add("TiGia", typeof(double));
            //dt2xx.Columns.Add("DaGhiSo", typeof(bool));
            //dt2xx.Columns.Add("GhiChu", typeof(string));
            //dt2xx.Columns.Add("SoTaiKhoanCon");
            //dt2xx.Columns.Add("TenTaiKhoanCon", typeof(string));
            //dt2xx.Columns.Add("HienThi", typeof(string));

            clsTbNhaCungCap clsncc = new clsTbNhaCungCap();
            clsncc.iID_NhaCungCap = Convert.ToInt16(gridNCC.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();

            int ID_TaiKhoanKeToanCon = clsncc.iID_TaiKhoanKeToan.Value;
            double tongtienhangcoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
            double tienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text);
            double tongtienhang_ChuaCoVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
            clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();

            clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
            DataTable dtcon = clscon.SelectOne();

            if (dtcon.Rows.Count == 0)
            {
                MessageBox.Show("Nhà cung cấp chưa có tài khoản kế toán. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridNCC.ResetText();
                return;
            }

            DataRow _ravi = _dataVAT.NewRow();
            _ravi["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi["ID_ChungTu"] = 0;
            _ravi["ID_TaiKhoanKeToanCon"] = ID_TaiKhoanKeToanCon;
            if (checkTraLaiHangMua.Checked == false)
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
            _dataVAT.Rows.Add(_ravi);

            DataRow _ravi2 = _dataVAT.NewRow();
            clscon.iID_TaiKhoanKeToanCon = 36;
            DataTable dtcon2 = clscon.SelectOne();
            _ravi2["ID_ChiTietBienDongTaiKhoan"] = 0;
            _ravi2["ID_ChungTu"] = 0;
            _ravi2["ID_TaiKhoanKeToanCon"] = 36;
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
            _dataVAT.Rows.Add(_ravi2);
            //if (tienVAT > 0)
            //{
                clscon.iID_TaiKhoanKeToanCon = 28;
                DataTable dtcon3 = clscon.SelectOne();

                DataRow _ravi3 = _dataVAT.NewRow();
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
                _dataVAT.Rows.Add(_ravi3);
            //}
            gridControl2.DataSource = _dataVAT;
        }
        private void  HienThi_SoTien_CO_No()
        {
            
            try
            {
                double PhanTramVAT, tienvat, TongTien_ChuaVAT, TongTien_Co_VAT;
                TongTien_ChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text);
                PhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text);
                tienvat = (TongTien_ChuaVAT * PhanTramVAT / 100);

                txtTienVAT.Text = tienvat.ToString("N2");
                txtTongTienHangCoVAT.Text = (TongTien_ChuaVAT + tienvat).ToString("N2");

                //double tienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString()); 
                //double TongTien_ChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                TongTien_Co_VAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());

                if (frmMuaHang2222.mbTraLaiHangMua)
                {
                    gridView8.SetRowCellValue(0, clNo, TongTien_Co_VAT);
                    gridView8.SetRowCellValue(0, clCo, 0);

                    gridView8.SetRowCellValue(1, clNo, 0);
                    gridView8.SetRowCellValue(1, clCo, TongTien_ChuaVAT);

                    gridView8.SetRowCellValue(2, clNo, 0);
                    gridView8.SetRowCellValue(2, clCo, tienvat);
                }
                else
                {
                    gridView8.SetRowCellValue(0, clNo, 0);
                    gridView8.SetRowCellValue(0, clCo, TongTien_Co_VAT);

                    gridView8.SetRowCellValue(1, clNo, TongTien_ChuaVAT);
                    gridView8.SetRowCellValue(1, clCo, 0);

                    gridView8.SetRowCellValue(2, clNo, tienvat);
                    gridView8.SetRowCellValue(2, clCo, 0);
                }

                decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);                
                txtTongTienHangChuaVAT.Text = value.ToString("N2");             
            }
            catch
            {
            }
        }
        private void HienThi_lable_TonKho(int iiID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = iiID_VTHH;
            DataTable dt = cls.SelectOne();
            clsKhoNPL_tbChiTietNhapKho cls1 = new CtyTinLuong.clsKhoNPL_tbChiTietNhapKho();
            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            double SoLuong_NhapTruocKy, SoLuong_XuatTruocKy, soluongton=0;
            DataTable dt_NhapTruoc = cls1.SA_NhapTruocKy_ID_VTHH(iiID_VTHH, DateTime.Now);
            DataTable dt_XuatTruoc = cls2.SA_XuatTruocKy_ID_VTHH(iiID_VTHH, DateTime.Now);
            if (dt_NhapTruoc.Rows.Count > 0)
            {

                SoLuong_NhapTruocKy = CheckString.ConvertToDouble_My(dt_NhapTruoc.Rows[0]["SoLuong_NhapTruocKy"].ToString());
                if (dt_XuatTruoc.Rows.Count > 0)
                    SoLuong_XuatTruocKy = CheckString.ConvertToDouble_My(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                else
                    SoLuong_XuatTruocKy = 0;
                SoLuong_XuatTruocKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;

            }
            else if (dt_XuatTruoc.Rows.Count > 0)
            {
                SoLuong_XuatTruocKy = CheckString.ConvertToDouble_My(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                soluongton = -SoLuong_XuatTruocKy;
            }
            else
                soluongton = 0;
            label_TonKho.Text = ""+cls.sMaVT.Value+" - "+cls.sTenVTHH.Value+" || Tồn kho: "+soluongton.ToString()+""; 
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
                txtSoChungTu.Focus();
                return false;
            }
            else if (txtTongTienHangCoVAT.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                txtTongTienHangCoVAT.Focus();
                return false;
            }
            else if (gridNCC.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa có NCC ");
                gridNCC.Focus();
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
                        cls2.fSoLuong = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    else cls2.fSoLuong = 0;
                    if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                        cls2.fDonGia = CheckString.ConvertToDouble_My(dt_gridcontrol.Rows[i]["DonGia"].ToString());
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
                    for (int i = 0; i < dv3cccccc.Rows.Count; i++)
                    {
                        int ID_TaiKhoanKeToanConxxxx1 = Convert.ToInt32(dv3cccccc.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                        clsxx.iID_ChungTu = xxxID_MuaHang;
                        clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                        clsxx.daNgayThang = dteNgayChungTu.DateTime;
                        clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                        if (dv3cccccc.Rows[i]["Co"].ToString() != "")
                            clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[i]["Co"].ToString());
                        else clsxx.fCo = 0;
                        if (dv3cccccc.Rows[i]["No"].ToString() != "")
                            clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[i]["No"].ToString());
                        else clsxx.fNo = 0;
                        clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[i]["TienUSD"].ToString());
                        if (dv3cccccc.Rows[i]["TiGia"].ToString() != "")
                            clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[i]["TiGia"].ToString());
                        else clsxx.fTiGia = 0;
                        clsxx.bTonTai = true;
                        clsxx.bNgungTheoDoi = false;
                        clsxx.bDaGhiSo = true;
                        clsxx.bBBool_TonDauKy = false;
                        clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 1;
                        clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
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
                    }
                    //xoá tôn tai =0
                    DataTable dt2_moi11111 = new DataTable();
                    clsxx = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    clsxx.iID_ChungTu = xxxID_MuaHang;
                    clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    clsxx.daNgayThang = dteNgayChungTu.DateTime;
                    dt2_moi11111 = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
                    dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                    DataView dvdt2_moi = dt2_moi11111.DefaultView;
                    DataTable dt2_moi = dvdt2_moi.ToTable();
                    for (int i = 0; i < dt2_moi.Rows.Count; i++)
                    {
                        int xxxID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                        clsxx.iID_ChiTietBienDongTaiKhoan = xxxID_ChiTietBienDongTaiKhoan;
                        clsxx.Delete();
                    }



                    //if (dv3cccccc.Rows.Count > 0)
                    //{
                    //    int ID_TaiKhoanKeToanConxxxx1 = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                    //    clsxx.iID_ChungTu = xxxID_MuaHang;
                    //    clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    //    clsxx.daNgayThang = dteNgayChungTu.DateTime;
                    //    clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                    //    if (dv3cccccc.Rows[0]["Co"].ToString() != "")
                    //        clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["Co"].ToString());
                    //    else clsxx.fCo = 0;
                    //    if (dv3cccccc.Rows[0]["No"].ToString() != "")
                    //        clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["No"].ToString());
                    //    else clsxx.fNo = 0;
                    //    clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[0]["TienUSD"].ToString());
                    //    if (dv3cccccc.Rows[0]["TiGia"].ToString() != "")
                    //        clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[0]["TiGia"].ToString());
                    //    else clsxx.fTiGia = 0;
                    //    clsxx.bTonTai = true;
                    //    clsxx.bNgungTheoDoi = false;
                    //    clsxx.bDaGhiSo = true;
                    //    clsxx.bBBool_TonDauKy = false;
                    //    clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 1;
                    //    clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
                    //    clsxx.sDienGiai = txtDienGiai.Text.ToString();
                    //    clsxx.bCheck_PhanNganHang = false;
                    //    string expressionnhapkho;
                    //    expressionnhapkho = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx1 + "";
                    //    DataRow[] foundRows;
                    //    foundRows = dt2_cu.Select(expressionnhapkho);
                    //    if (foundRows.Length > 0)
                    //    {
                    //        clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    //        clsxx.Update();
                    //    }
                    //    else
                    //    {
                    //        clsxx.Insert();
                    //    }


                    //    if (dv3cccccc.Rows.Count >= 2)
                    //    {
                    //        int ID_TaiKhoanKeToanConxxxx2 = Convert.ToInt32(dv3cccccc.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                    //        clsxx.iID_ChungTu = xxxID_MuaHang;
                    //        clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    //        clsxx.daNgayThang = dteNgayChungTu.DateTime;
                    //        clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                    //        if (dv3cccccc.Rows[1]["Co"].ToString() != "")
                    //            clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["Co"].ToString());
                    //        else clsxx.fCo = 0;
                    //        if (dv3cccccc.Rows[1]["No"].ToString() != "")
                    //            clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["No"].ToString());
                    //        else clsxx.fNo = 0;
                    //        clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[1]["TienUSD"].ToString());
                    //        if (dv3cccccc.Rows[1]["TiGia"].ToString() != "")
                    //            clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[1]["TiGia"].ToString());
                    //        else clsxx.fTiGia = 0;
                    //        clsxx.bTonTai = true;
                    //        clsxx.bNgungTheoDoi = false;
                    //        clsxx.bDaGhiSo = true;
                    //        clsxx.bBBool_TonDauKy = false;
                    //        clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 4;
                    //        clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
                    //        clsxx.sDienGiai = txtDienGiai.Text.ToString();
                    //        clsxx.bCheck_PhanNganHang = false;
                    //        string expression222;
                    //        expression222 = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx2 + "";
                    //        DataRow[] foundRows222;
                    //        foundRows222 = dt2_cu.Select(expression222);
                    //        if (foundRows222.Length > 0)
                    //        {
                    //            clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows222[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    //            clsxx.Update();
                    //        }
                    //        else
                    //        {
                    //            clsxx.Insert();
                    //        }

                    //        // có tk VAT
                    //        if (dv3cccccc.Rows.Count == 3)
                    //        {
                    //            int ID_TaiKhoanKeToanConxxxx3 = Convert.ToInt32(dv3cccccc.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                    //            clsxx.iID_ChungTu = xxxID_MuaHang;
                    //            clsxx.sSoChungTu = txtSoChungTu.Text.ToString();
                    //            clsxx.daNgayThang = dteNgayChungTu.DateTime;
                    //            clsxx.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                    //            if (dv3cccccc.Rows[2]["Co"].ToString() != "")
                    //                clsxx.fCo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["Co"].ToString());
                    //            else clsxx.fCo = 0;
                    //            if (dv3cccccc.Rows[2]["No"].ToString() != "")
                    //                clsxx.fNo = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["No"].ToString());
                    //            else clsxx.fNo = 0;
                    //            clsxx.bTienUSD = Convert.ToBoolean(dv3cccccc.Rows[2]["TienUSD"].ToString());
                    //            if (dv3cccccc.Rows[2]["TiGia"].ToString() != "")
                    //                clsxx.fTiGia = CheckString.ConvertToDouble_My(dv3cccccc.Rows[2]["TiGia"].ToString());
                    //            else clsxx.fTiGia = 0;
                    //            clsxx.bTonTai = true;
                    //            clsxx.bNgungTheoDoi = false;
                    //            clsxx.bDaGhiSo = true;
                    //            clsxx.bBBool_TonDauKy = false;
                    //            clsxx.iTrangThai_MuaHang1_BanHang2_VAT3 = 3;
                    //            clsxx.iID_DoiTuong = Convert.ToInt32(gridNCC.EditValue.ToString());
                    //            clsxx.sDienGiai = txtDienGiai.Text.ToString();
                    //            clsxx.bCheck_PhanNganHang = false;
                    //            string expression333;
                    //            expression333 = "ID_TaiKhoanKeToanCon=" + ID_TaiKhoanKeToanConxxxx3 + "";
                    //            DataRow[] foundRows3333;
                    //            foundRows3333 = dt2_cu.Select(expression333);
                    //            if (foundRows3333.Length > 0)
                    //            {
                    //                clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(foundRows3333[0]["ID_ChiTietBienDongTaiKhoan"].ToString());
                    //                clsxx.Update();
                    //            }
                    //            else
                    //            {
                    //                clsxx.Insert();
                    //            }
                    //        }
                    //}

                    //}

                }
            }
        }

        private void Luu_NhapKho_NPL(int xxID_muahang)
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    double tongtienhang;
                    tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
                    cls1.sDienGiai = txtDienGiai.Text.ToString();
                    cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls1.sSoChungTu = SoChungTu_NPL();
                    cls1.fTongTienHang = tongtienhang;
                    cls1.iID_NguoiNhapKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls1.sThamChieu = txtSoChungTu.Text.ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaNhapKho = true;
                    cls1.bBool_TonDauKy = false;
                    cls1.bCheck_NhapKho_Khac = false;
                    cls1.Insert();
                    // insert tbChiTietNhapKho
                    string shienthi = "1";
                    int iiiiIDID_NhapKhoNPL = cls1.iID_NhapKho.Value;
                    clsKhoNPL_tbChiTietNhapKho clschitietNhapkho = new clsKhoNPL_tbChiTietNhapKho();
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dvmoi = dttttt2.DefaultView;
                    DataTable dtmoi = dvmoi.ToTable();
                    for (int i = 0; i < dtmoi.Rows.Count; i++)
                    {
                        clschitietNhapkho.iID_NhapKho = iiiiIDID_NhapKhoNPL;
                        clschitietNhapkho.iID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());

                        if (dtmoi.Rows[i]["SoLuong"].ToString() != "")
                        {
                            clschitietNhapkho.fSoLuongNhap = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["SoLuong"].ToString());
                            clschitietNhapkho.fSoLuongTon = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["SoLuong"].ToString());
                        }
                        else
                        {
                            clschitietNhapkho.fSoLuongNhap = 0;
                            clschitietNhapkho.fSoLuongTon = 0;
                        }
                        if (dtmoi.Rows[i]["DonGia"].ToString() != "")
                            clschitietNhapkho.fDonGia = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["DonGia"].ToString());
                        clschitietNhapkho.bTonTai = true;
                        clschitietNhapkho.bNgungTheoDoi = false;
                        clschitietNhapkho.sGhiChu = dtmoi.Rows[i]["GhiChu"].ToString();
                        clschitietNhapkho.bDaNhapKho = true;
                        clschitietNhapkho.bBoolTonDauKy = false;
                        clschitietNhapkho.Insert();
                    }

                    /// Update trang thai nhap kho tbMuahang
                    clsMH_tbMuaHang clsmuahang = new clsMH_tbMuaHang();
                    clsmuahang.iID_MuaHang = iiiID_MuaHang;
                    clsmuahang.Update_TrangThaiNhapKho();
                    
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập kho!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LuuDuLieu_Va_NhapKho()
        {
            try
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

                    cls.fTongTienHangChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                    cls.fTongTienHangCoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    cls.fPhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                    cls.fTienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                    cls.iID_NguoiMua = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls.bGuiDuLieu = true;
                    cls.bTonTai = true;
                   
                    cls.bNgungTheoDoi = false;
                    cls.bMuaHangNhapKho = checkMuaHangNhapKho.Checked;
                    cls.bTienUSD = checkUSD.Checked;
                    cls.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    cls.bCheckTraLaiNhaCungCap = checkTraLaiHangMua.Checked;
                    if (UCMuaHang.mbSua == false)
                    {
                        cls.bTrangThaiNhapKho = false;
                        cls.Insert();
                        iiiID_MuaHang = cls.iID_MuaHang.Value;
                    }
                    else
                    {
                        clsMH_tbMuaHang cls2 = new clsMH_tbMuaHang();
                        cls2.iID_MuaHang= UCMuaHang.miiiID_Sua_DonHang;
                        DataTable dt2 = cls2.SelectOne();
                        cls.bTrangThaiNhapKho = cls2.bTrangThaiNhapKho.Value;
                        iiiID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        cls.Update();
                    }
                    // luwu chi tiet mua hang
                    Luu_Chitiet_MuaHang(iiiID_MuaHang);
                    Luu_BienDongTaiKhoan(iiiID_MuaHang);
                    Luu_NhapKho_NPL(iiiID_MuaHang);
                    //  Luu_TbThuChi(iiiID_MuaHang);         

                    this.Close();
                    if (_ucMH != null)
                        _ucMH.btRefresh_Click(null, null);
                    MessageBox.Show("Đã lưu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Lưu dữ liệu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LuuDuLieu_Va_GuiDuLieu()
        {
            try
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

                    cls.fTongTienHangChuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                    cls.fTongTienHangCoVAT = CheckString.ConvertToDouble_My(txtTongTienHangCoVAT.Text.ToString());
                    cls.fPhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                    cls.fTienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                    cls.iID_NguoiMua = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls.bGuiDuLieu = true;
                    cls.bTonTai = true;
                    cls.bTrangThaiNhapKho = false;
                    cls.bNgungTheoDoi = false;
                    cls.bMuaHangNhapKho = checkMuaHangNhapKho.Checked;
                    cls.bTienUSD = checkUSD.Checked;
                    cls.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    cls.bCheckTraLaiNhaCungCap = checkTraLaiHangMua.Checked;
                    if (UCMuaHang.mbSua == false)
                    {
                        cls.bTrangThaiNhapKho = false;
                        cls.Insert();
                        iiiID_MuaHang = cls.iID_MuaHang.Value;
                    }
                    else
                    {
                        clsMH_tbMuaHang cls2 = new clsMH_tbMuaHang();
                        cls2.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        DataTable dt2 = cls2.SelectOne();
                        cls.bTrangThaiNhapKho = cls2.bTrangThaiNhapKho.Value;
                        iiiID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        cls.iID_MuaHang = UCMuaHang.miiiID_Sua_DonHang;
                        cls.Update();
                    }
                    // luwu chi tiet mua hang
                    Luu_Chitiet_MuaHang(iiiID_MuaHang);
                    Luu_BienDongTaiKhoan(iiiID_MuaHang);
                    //  Luu_TbThuChi(iiiID_MuaHang);         

                    this.Close();
                    if (_ucMH != null)
                        _ucMH.btRefresh_Click(null, null);
                    MessageBox.Show("Đã lưu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lưu dữ liệu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }                        
        private void HienThi_themMoi()
        {
            _dataVthh.Clear();
            _dataVAT.Clear();
            btLuu_NhapKho.Visible = true;
            checkBaoVe_LaiXe.Checked = false;
            if (frmMuaHang2222.mbTraLaiHangMua == true)
                checkTraLaiHangMua.Checked = true;
            else checkTraLaiHangMua.Checked = false;
            gridNguoiLap.EditValue = 12;
            //btBaoVe.Enabled = false;
            //btLaiXe.Enabled = false;
            //DataTable dt2 = new DataTable();


            gridControl1.DataSource = _dataVthh;
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

            //DataTable dt2xx = new DataTable();
           
            gridControl2.DataSource = _dataVAT;
           
        }
        private void HienThi_Sua(int xxID_MuaHang)
        {
            _dataVthh.Clear();
            _dataVAT.Clear();
            clsMH_tbMuaHang cls = new CtyTinLuong.clsMH_tbMuaHang();
            cls.iID_MuaHang = xxID_MuaHang;
            DataTable dt = cls.SelectOne();
            if (cls.bCheck_BaoVe == true) checkBaoVe_LaiXe.Checked = true;
            else checkBaoVe_LaiXe.Checked = false;
            if (cls.bTrangThaiNhapKho == false) btLuu_NhapKho.Visible = true;
            else btLuu_NhapKho.Visible = false;
            txtSoChungTu.Text = cls.sSoChungTu.Value.ToString();


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
            cls2.iID_MuaHang = xxID_MuaHang;
            _dataVthh = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();

            gridControl1.DataSource = _dataVthh;

            clsNganHang_ChiTietBienDongTaiKhoanKeToan clstaikhoan = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clstaikhoan.iID_ChungTu = xxID_MuaHang;
            clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
            clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
            _dataVAT = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();

            gridControl2.DataSource = _dataVAT;
            gridNCC.EditValue = cls.iIDNhaCungCap.Value;

        }
        private void HienThi_Copy(int xxID_MuaHang)
        {
            btLuu_NhapKho.Visible = true;
            if (frmMuaHang2222.mbTraLaiHangMua == true)
                checkTraLaiHangMua.Checked = true;
            else checkTraLaiHangMua.Checked = false;
            clsMH_tbMuaHang cls = new CtyTinLuong.clsMH_tbMuaHang();
            cls.iID_MuaHang = xxID_MuaHang;
            DataTable dt = cls.SelectOne();
          
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
            cls2.iID_MuaHang = xxID_MuaHang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();          

            gridControl1.DataSource = dt3;


            clsNganHang_ChiTietBienDongTaiKhoanKeToan clstaikhoan = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            clstaikhoan.iID_ChungTu = xxID_MuaHang;
            clstaikhoan.sSoChungTu = cls.sSoChungTu.Value;
            clstaikhoan.daNgayThang = cls.daNgayChungTu.Value;
            DataTable dttaikhoanm = clstaikhoan.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();           
            gridControl2.DataSource = dttaikhoanm;
            gridNCC.EditValue = cls.iIDNhaCungCap.Value;

           
        }

        private void Load_LockUp()
        {
            clsThin clsThin_ = new clsThin();
            DataSet dtSet_ = clsThin_.T_LockUp_frmChiTietMuaHang3333333333();
              
            repositoryItemSearchLookUpEdit1.DataSource = dtSet_.Tables[0];
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";
             
            gridTaiKhoan.DataSource = dtSet_.Tables[1];
            gridTaiKhoan.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTaiKhoan.DisplayMember = "SoTaiKhoanCon";
             
            gridNguoiLap.Properties.DataSource = dtSet_.Tables[2];
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            gridNCC.Properties.DataSource = dtSet_.Tables[3];
            gridNCC.Properties.ValueMember = "ID_NhaCungCap";
            gridNCC.Properties.DisplayMember = "MaNhaCungCap";

            //Thay caption:
            gridNCC.Properties.View.Columns.Clear();//xóa caption cũ
            gridNCC.Properties.View.Columns.AddVisible("ID_NhaCungCap", "ID");
            gridNCC.Properties.View.Columns.AddVisible("MaNhaCungCap", "Mã");
            gridNCC.Properties.View.Columns.AddVisible("TenNhaCungCap", "Tên");

            gridNCC.Properties.View.Columns["ID_NhaCungCap"].Visible = false;

            dtSet_.Dispose();
            clsThin_.Dispose();
        }

        UCMuaHang _ucMH;
        public frmChiTietMuaHang3333333333(UCMuaHang ucMH = null)
        {
            _ucMH = ucMH;
            InitializeComponent();

            _dataVthh = new DataTable();
            _dataVthh.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            _dataVthh.Columns.Add("ID_MuaHang");
            _dataVthh.Columns.Add("ID_VTHH");
            _dataVthh.Columns.Add("SoLuong", typeof(float));
            _dataVthh.Columns.Add("DonGia", typeof(double));
            _dataVthh.Columns.Add("MaVT");// tb VTHH
            _dataVthh.Columns.Add("TenVTHH");
            _dataVthh.Columns.Add("DonViTinh");
            _dataVthh.Columns.Add("GhiChu", typeof(string));
            _dataVthh.Columns.Add("ThanhTien", typeof(double));
            _dataVthh.Columns.Add("HienThi", typeof(string));

            _dataVAT = new DataTable();
            _dataVAT.Columns.Add("ID_ChiTietBienDongTaiKhoan", typeof(int));
            _dataVAT.Columns.Add("ID_ChungTu", typeof(int));
            //_dataVAT.Columns.Add("SoChungTu", typeof(string));
            //_dataVAT.Columns.Add("NgayThang", typeof(DateTime));
            _dataVAT.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            _dataVAT.Columns.Add("No", typeof(double));
            _dataVAT.Columns.Add("Co", typeof(double));
            _dataVAT.Columns.Add("TienUSD", typeof(bool));
            _dataVAT.Columns.Add("TiGia", typeof(double));
            _dataVAT.Columns.Add("DaGhiSo", typeof(bool));
            _dataVAT.Columns.Add("GhiChu", typeof(string));
            _dataVAT.Columns.Add("SoTaiKhoanCon");
            _dataVAT.Columns.Add("TenTaiKhoanCon", typeof(string));
            _dataVAT.Columns.Add("HienThi", typeof(string));
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
            Cursor.Current = Cursors.WaitCursor;
            txtTienVAT.Text = "0";
            
            Load_LockUp();
            if (UCMuaHang.mbThemMoi == true)
            {
                HienThi_themMoi();
            }
            else if (UCMuaHang.mbCopY == true)
            {
                HienThi_Copy(UCMuaHang.miiiID_Sua_DonHang);
            }
            else
            {
                HienThi_Sua(UCMuaHang.miiiID_Sua_DonHang);
            }
            Cursor.Current = Cursors.Default;
            txtSoChungTu.Focus();
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
                //decimal value = decimal.Parse(txtTienVAT.Text);
                ////txtTienVAT.Text = String.Format("{0:#,##0.00}", value);
                //txtTienVAT.Text = value.ToString("N2");


                //double  tienvat;
                ////tienno = CheckString.ConvertToDouble_My(txtTienNo.Text.ToString());
                //tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                ////txtTienCo.Text = (tienno + tienvat).ToString();

                //double tongtienchuaVAT;
                //tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                //tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                //txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
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
            if (e.Column == clID_VTHH)
            {
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, sTenVTHH);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, sDonViTinh);
                //gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                //gridView4.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                //gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }

            if (e.Column == clSoLuong)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

                //if (UCMuaHang.mbSua == false && UCMuaHang.mbCopY == false)
                if (_NewRow)
                    tinhTongTien(fffthanhtien);
                else
                    tinhTongTien(0);
            }
            if (e.Column == clDonGia)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

                //if (UCMuaHang.mbSua == false && UCMuaHang.mbCopY == false)
                if (_NewRow)
                    tinhTongTien(fffthanhtien);
                else
                    tinhTongTien(0);
            }
        }

        private void tinhTongTien(double tongIn)
        {
            double tienVAT, deTOngTienChuaVAT = tongIn;
            for (int i = 0; i < this.gridView4.RowCount; i++)
            {
                deTOngTienChuaVAT += CheckString.ConvertToDouble_My(this.gridView4.GetRowCellValue(i, "ThanhTien"));
            }

            tienVAT = deTOngTienChuaVAT * (CheckString.ConvertToDouble_My(txtPhanTramVAT.Text)) /100;

            txtTienVAT.Text = tienVAT.ToString("N2");
            txtTongTienHangChuaVAT.Text = deTOngTienChuaVAT.ToString("N2");
            txtTongTienHangCoVAT.Text = (deTOngTienChuaVAT + CheckString.ConvertToDouble_My(txtTienVAT.Text)).ToString("N2");
        }

        private void txtPhanTramVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HienThi_SoTien_CO_No();
                //double PhanTramVAT, tongtienhang,tienvat,tongtienchuaVAT;
                //tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                //PhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                //txtTienVAT.Text = (tongtienhang * PhanTramVAT / 100).ToString();
                //tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                //tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                //txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();
            }
            catch
            {

            }
         
        }
        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                ////double tongtienchuaVAT, tienVAT;
                ////tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                ////tienVAT = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                ////txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienVAT).ToString();

             

                //HienThi_SoTien_CO_No();

                ////decimal value = decimal.Parse(txtTongTienHangChuaVAT.Text);
                //////txtTongTienHangChuaVAT.Text = String.Format("{0:#,##0.00}", value);
                ////txtTongTienHangChuaVAT.Text = value.ToString("N2");
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
            //
        }
        private void txtTiGia_TextChanged(object sender, EventArgs e)
        {
            if (txtTiGia.Text.ToString() != "1")
            {
                double tigiaxx = CheckString.ConvertToDouble_My(txtTiGia.Text.ToString());
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

                HienThi_SoTien_CO_No();
                //decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                ////txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);
                //txtTongTienHangCoVAT.Text = value.ToString("N2");

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
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
                if(gridView4.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
                {
                    int xxID = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH).ToString());
                    HienThi_lable_TonKho(xxID);
                }
            }
            catch
            {

            }
        }


        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                _NewRow = false;
                //double deTOngtien;
                //DataTable dataTable = (DataTable)gridControl1.DataSource;
                //string shienthi = "1";
                //object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                //if (xxxx.ToString() != "")
                //    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                //else deTOngtien = 0;
                //txtTongTienHangChuaVAT.Text = deTOngtien.ToString();
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
                    gridNCC.ReadOnly = false;
                    
                    txtTenNhaCungCap.Text = dt.Rows[0]["TenNhaCungCap"].ToString();
                    if (UCMuaHang.mbSua == false)
                    {
                        HienThi_GridConTrol_SauKhiChon();
                    }
                    else
                        gridNCC.ReadOnly = true;

                    if (UCMuaHang.mbCopY)
                    {
                        tinhTongTien(0);
                    }

                    if (UCMuaHang.mbThemMoi)
                    {
                        //txtTienVAT.Text = 0.ToString("N2");
                        //txtTongTienHangChuaVAT.Text = 0.ToString("N2");
                        //txtTongTienHangCoVAT.Text = 0.ToString("N2");
                        ////HienThi_SoTien_CO_No();
                    }

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
                        cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                        DataTable dt1 = cls.SelectOne();
                        msTKCo = dt1.Rows[0]["SoTaiKhoanCon"].ToString();

                        if (dv3cccccc.Rows.Count > 1)
                        {
                            cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[1]["ID_TaiKhoanKeToanCon"].ToString());
                            DataTable dt2 = cls.SelectOne();
                            msTKNo = dt2.Rows[0]["SoTaiKhoanCon"].ToString();
                        }

                        if (dv3cccccc.Rows.Count > 2)
                        {
                            cls.iID_TaiKhoanKeToanCon = Convert.ToInt32(dv3cccccc.Rows[2]["ID_TaiKhoanKeToanCon"].ToString());
                            DataTable dt3 = cls.SelectOne();
                            msTKVAT = dt3.Rows[0]["SoTaiKhoanCon"].ToString();
                        }
                        else msTKVAT = "";
                        mdcSoTienNo = CheckString.ConvertToDecimal_My(txtTongTienHangChuaVAT.Text.ToString());
                        mdcSoTienCo = CheckString.ConvertToDecimal_My(txtTongTienHangCoVAT.Text.ToString());
                    }
                    else
                    {
                        msTKCo = "";
                        msTKNo = "";
                        msTKVAT = "";
                        mdcSoTienNo = 0;
                        mdcSoTienCo = 0;
                    }
                    mdcSoTienVAT = CheckString.ConvertToDecimal_My(txtTienVAT.Text);
                    mdcTongTienCoVAT = CheckString.ConvertToDecimal_My(txtTongTienHangCoVAT.Text.ToString());

                    frmPrintMuaHang ff = new frmPrintMuaHang();
                    ff.Show();
                }
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
                txtNguoiGiaoHang.Focus();
            }
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
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
                gridNCC.Focus();
            }
        }

        private void txtNguoiMuaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridNCC.Focus();
            }
        }

        private void gridNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtTenNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
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
                btLuu_Dong.Focus();
            }
        }

        private void txtTienVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTongTienHangCoVAT.Focus();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            UCMuaHang.mbCopY = true;
            UCMuaHang.mbThemMoi = false;
            UCMuaHang.mbSua = false;

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

        private void gridView8_CellMerge(object sender, CellMergeEventArgs e)
        {

        }

        private void btXoa2xxxx_Click(object sender, EventArgs e)
        {
            gridView8.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi___, "0");
          
        }

        private void gridView8_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        int iID_VTHH;
        string sMaVT, sTenVTHH, sDonViTinh;
        private bool _NewRow = false;

        private void gridView4_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            _NewRow = true;
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, clHienThi, "1");
            view.SetRowCellValue(e.RowHandle, clSoLuong, 0);
            view.SetRowCellValue(e.RowHandle, clDonGia, 0);
        }

        private void gridView4_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //double deTOngTienChuaVAT = 0;
            //for (int i = 0; i < this.gridView4.RowCount; i++)
            //{
            //    deTOngTienChuaVAT += CheckString.ConvertToDouble_My(this.gridView4.GetRowCellValue(i, "ThanhTien"));
            //}

            //txtTongTienHangChuaVAT.Text = deTOngTienChuaVAT.ToString("N2");
            //txtTongTienHangCoVAT.Text = (deTOngTienChuaVAT + CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString())).ToString("N2");
        }

        private void btLuu_NhapKho_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_NhapKho();
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GuiDuLieu();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }


        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
            iID_VTHH = Convert.ToInt32(row["ID_VTHH"].ToString());
            sTenVTHH = row["TenVTHH"].ToString();
            sDonViTinh = row["DonViTinh"].ToString();
        }

        private void repositoryItemSearchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
                ((SearchLookUpEdit)sender).Properties.View.Columns[3].Visible = false;
            }
            catch { }
        }

        private void txtTongTienHangCoVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridView4.Focus();
            }
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            
           // this.Close();
        }

        private void frmChiTietMuaHang3333333333_FormClosed(object sender, FormClosedEventArgs e)
        {
            UCMuaHang.mbThemMoi = true;
            UCMuaHang.mbCopY = false;
            UCMuaHang.mbSua = false;
        }

        private void checkBaoVe_LaiXe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe_LaiXe.Checked == true)
                {
                    if (UCMuaHang.mbSua == true)
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

     
        private void txtTienVAT_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
               
                ////double PhanTramVAT, tongtienhang, tienvat, tongtienchuaVAT;

                ////tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                ////PhanTramVAT = CheckString.ConvertToDouble_My(txtPhanTramVAT.Text.ToString());
                ////txtTienVAT.Text = (tongtienhang * PhanTramVAT / 100).ToString();
                ////tongtienchuaVAT = CheckString.ConvertToDouble_My(txtTongTienHangChuaVAT.Text.ToString());
                ////tienvat = CheckString.ConvertToDouble_My(txtTienVAT.Text.ToString());
                ////txtTongTienHangCoVAT.Text = (tongtienchuaVAT + tienvat).ToString();

                //HienThi_SoTien_CO_No();

                ////decimal value = decimal.Parse(txtTienVAT.Text);
                //////txtTienVAT.Text = String.Format("{0:#,##0.00}", value);
                ////txtTongTienHangCoVAT.Text = value.ToString("N2");
            }
            catch
            {

            }
        }

        private void gridView8_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_TaiKhoanKeToanCon)
            {
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();

                int kk = Convert.ToInt32(gridView8.GetRowCellValue(e.RowHandle, e.Column));
                cls.iID_TaiKhoanKeToanCon = kk;
                DataTable dt = cls.SelectOne();
                gridView8.SetRowCellValue(e.RowHandle, clTenTaiKhoanCon, cls.sTenTaiKhoanCon.Value);
                gridView8.SetRowCellValue(e.RowHandle, clHienThi___, "1");
                gridView8.SetRowCellValue(e.RowHandle, clTienUSD, false);
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
                //txtTiGia.Text = String.Format("{0:#,##0.00}", value);
                txtTiGia.Text = value.ToString("N2");
            }
            catch
            {

            }
        }
    }
}
