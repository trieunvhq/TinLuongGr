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
    public partial class KhoNPL_frmChiTiet_XuatKho_gapDan : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiNhanHang, msDienGiai;
        public static double mdbTongSotien;
        private void HienThi_ThemMoi_XuatKho()
        {
            gridNguoiLap.EditValue = 14;
            txtSoLuongXuat.Text = "1";
            dteNgayChungTu.EditValue = DateTime.Today;
            clsKhoNPL_tbXuatKho cls3 = new clsKhoNPL_tbXuatKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "XKNPL 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                if (xxx2 >= 10000)
                    txtSoChungTu.Text = "XKNPL 1";
                else txtSoChungTu.Text = "XKNPL " + xxx2 + "";

            }
            string sochungtuNhapKho_GapDan;
            clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
            DataTable dt1222 = cls.SelectAll();
            dt1222.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvxxx = dt1222.DefaultView;
            DataTable dv3xxx = dvxxx.ToTable();
            int k2 = dv3xxx.Rows.Count;
            if (k2 == 0)
                sochungtuNhapKho_GapDan = "NKGD 1";
            else
            {
                string xxx = dv3xxx.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtuNhapKho_GapDan = "NKGD 1";
                sochungtuNhapKho_GapDan = "NKGD " + xxx2 + "";

            }
            txtSoChungTuGapDan.Text = sochungtuNhapKho_GapDan;
        }
        private void HienThi_Sua_XuatKho()
        {

            clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
            cls1.iID_NhapKho = UCNPL_XuatKho_GapDan.miiID_NhapKhoGapDan;
            DataTable dt22222 = cls1.SelectOne();
            if (cls1.bTrangThai_XuatKho_NPL == true)
            {              
                btLuu_Dong.Enabled = false;             
                btLuu_Gui_Dong.Enabled = false;
                //clsKhoNPL_tbXuatKho cls2 = new CtyTinLuong.clsKhoNPL_tbXuatKho();
                //cls2.sThamChieu = cls1.sSoChungTu.Value;
                //DataTable dt2xxx = cls2.SelectOne_W_ThamChieu_NhapKho_GapDan();
                //dteNgayChungTu.EditValue = Convert.ToDateTime(dt2xxx.Rows[0]["NgayChungTu"].ToString());
                //txtDienGiai.Text = dt2xxx.Rows[0]["DienGiai"].ToString();
                //txtSoChungTu.Text = dt2xxx.Rows[0]["SoChungTu"].ToString();

            }
            else
            {
                clsKhoNPL_tbXuatKho cls3 = new clsKhoNPL_tbXuatKho();
                DataTable dt1 = cls3.SelectAll();
                dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                DataView dv = dt1.DefaultView;
                DataTable dv3 = dv.ToTable();
                int k = dv3.Rows.Count;
                if (k == 0)
                    txtSoChungTu.Text = "XKNPL 1";
                else
                {
                    string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtSoChungTu.Text = "XKNPL 1";
                    else txtSoChungTu.Text = "XKNPL " + xxx2 + "";

                }
            }
            txtSoLuongXuat.Text = cls1.fSoLuongThanhPham_QuyDoi.Value.ToString();
            gridDinhMucGapDan.EditValue = cls1.iID_DinhMuc_ToGapDan.Value;
            txtSoChungTuGapDan.Text = cls1.sSoChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sThamChieu.Value;
            txtNguoiNhanHang.Text = cls1.sNguoiNhanHang.Value;
            double iisoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(float));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("Check_VatTu_Phu", typeof(bool));
           
            clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            cls.iID_NhapKho = UCNPL_XuatKho_GapDan.miiID_NhapKhoGapDan;

            DataTable dtchitiet1 = cls.SelectAll_W_ID_NhapKho();
            dtchitiet1.DefaultView.RowFilter = "Check_VatTu_Phu = True";
            DataView dv2 = dtchitiet1.DefaultView;
            DataTable dtchitietnhapkho = dv2.ToTable();
            for (int i = 0; i < dtchitietnhapkho.Rows.Count; i++)
            {
                double SoLuong = Convert.ToDouble(dtchitietnhapkho.Rows[i]["SoLuongNhap"].ToString());
                double dongiaxxx333 = Convert.ToDouble(dtchitietnhapkho.Rows[i]["DonGia"].ToString());

                int ID_VTHHxx = Convert.ToInt32(dtchitietnhapkho.Rows[i]["ID_VTHH"].ToString());

                clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
                clvthh.iID_VTHH = ID_VTHHxx;
                DataTable dtvth = clvthh.SelectOne();
                clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
                xcls.iID_VTHH = ID_VTHHxx;
                DataTable dtbtp = xcls.Select_W_ID_VTHH();
                clsDinhMuc_ChiTiet_DinhMuc_ToGapDan clsdm = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                clsdm.iID_DinhMuc_ToGapDan = Convert.ToInt32(dtchitietnhapkho.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                clsdm.iID_VTHH = ID_VTHHxx;
                DataTable dtdm = clsdm.SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH();

                double xxsoluongdinhmuc = Convert.ToDouble(dtdm.Rows[0]["SoLuong"].ToString());
                //var xxdinhmuc = Math.Round(double.Parse(xxsoluong), 3);

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_VTHH"] = ID_VTHHxx;
                _ravi3["MaVT"] = ID_VTHHxx;
                _ravi3["DinhMuc"] = xxsoluongdinhmuc;
                _ravi3["SoLuongTheoDinhMuc"] = xxsoluongdinhmuc * iisoluongxuat;
                _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
                _ravi3["SoLuong"] = SoLuong;
                if (dtbtp.Rows.Count > 0)
                    _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtchitietnhapkho.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
                if(Convert.ToBoolean(dtchitietnhapkho.Rows[i]["Check_VatTu_Phu"].ToString())==true)
                _ravi3["Check_VatTu_Phu"] = true;
                else _ravi3["Check_VatTu_Phu"] = false;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
            double deTOngtien;
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and Check_VatTu_Phu = True");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }

        private void HienThi_GridControl_Moiiiiiiiiiiii(double soluongxuatxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(float));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("Check_VatTu_Phu", typeof(bool));

            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls1 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            cls1.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            DataTable dt422 = cls1.SelectAll_W_ID_DinhMuc_ToGapDan();
            dt422.DefaultView.RowFilter = " Check_VatTu_Phu = True";
            DataView dv1 = dt422.DefaultView;
            DataTable dt1 = dv1.ToTable();
            clsKhoNPL_tbChiTietNhapKho clsnhapkho = new clsKhoNPL_tbChiTietNhapKho();
            //gridControl2.DataSource = dtkhoBTPvtuchinh1;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    double dongiaxxx = 0;
                    double SoLuongTonxxx = 0;
                    double iiSoLuong_TheoDinhMuc = Convert.ToDouble(dt1.Rows[i]["SoLuong"].ToString());
                    int xxID_VTHH = Convert.ToInt32(dt1.Rows[i]["ID_VTHH"].ToString());
                    clsnhapkho.iID_VTHH = xxID_VTHH;
                    DataTable dtx = clsnhapkho.Select_W_ID_VTHH();
                    if (dtx.Rows.Count > 0)
                    {
                        dongiaxxx = Convert.ToDouble(dtx.Rows[0]["DonGia"].ToString());
                        SoLuongTonxxx = Convert.ToDouble(dtx.Rows[0]["SoLuongTon"].ToString());
                    }
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = xxID_VTHH;
                    _ravi["MaVT"] = Convert.ToInt32(dt1.Rows[i]["ID_VTHH"].ToString());
                    _ravi["TenVTHH"] = dt1.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt1.Rows[i]["DonViTinh"].ToString();
                    _ravi["DinhMuc"] = Convert.ToDouble(dt1.Rows[i]["SoLuong"].ToString());
                    _ravi["SoLuongTon"] = SoLuongTonxxx;
                    _ravi["SoLuongTheoDinhMuc"] = soluongxuatxxx * iiSoLuong_TheoDinhMuc;
                    _ravi["SoLuong"] = soluongxuatxxx * iiSoLuong_TheoDinhMuc;
                    _ravi["DonGia"] = dongiaxxx;
                    _ravi["GhiChu"] = "";
                    _ravi["HienThi"] = "1";
                    _ravi["ThanhTien"] = dongiaxxx * soluongxuatxxx * iiSoLuong_TheoDinhMuc;
                    _ravi["Check_VatTu_Phu"] = true;

                    dt2.Rows.Add(_ravi);
                }

            }
            gridControl1.DataSource = dt2;

            double deTOngtien;

            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=5";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            gridMaVT.DataSource = dtxx2;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";



            clsDinhMuc_DinhMuc_ToGapDan clsdinhmucnpl = new clsDinhMuc_DinhMuc_ToGapDan();
            DataTable dt2 = clsdinhmucnpl.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvnpl = dt2.DefaultView;
            DataTable newdtnpl = dvnpl.ToTable();


            gridDinhMucGapDan.Properties.DataSource = newdtnpl;
            gridDinhMucGapDan.Properties.ValueMember = "ID_DinhMuc_ToGapDan";
            gridDinhMucGapDan.Properties.DisplayMember = "MaDinhMuc";


            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }
        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }

            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }


            else if (gridDinhMucGapDan.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa chọn định mức nguyên phụ liệu");
                return false;
            }
            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
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
                return false;
            }
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }
        private string Load_soChungTu_KhoBanThanhPham()
        {
            string sochungtu = "";
            clsKhoBTP_tbXuatKho cls3 = new clsKhoBTP_tbXuatKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "XKBTP 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                sochungtu = "XKBTP " + xxx2 + "";

            }
            return sochungtu;
        }
        private void Luu_ChiTiet_ChiTiet_XuatKho_NPL(int iiID_XUatKhoNPL)
        {


            string shienthi = "1";
            DataTable dtkkk = (DataTable)gridControl1.DataSource;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dtkkk.DefaultView;
            DataTable dtmoi = dvmoi.ToTable();

            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            DataTable dt2_cu = new DataTable();
            cls2.iID_XuatKho = iiID_XUatKhoNPL;
            dt2_cu = cls2.SelectAll_W_ID_XuatKho();
            if (dt2_cu.Rows.Count > 0)
            {
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                cls2.bTonTai = false;
                cls2.Update_ALL_TonTai_W_ID_XuatKho();
            }

            // Nhap kho 
            for (int i = 0; i < dtmoi.Rows.Count; i++)
            {
                int ID_VTHHxxx = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                cls2.iID_XuatKho = iiID_XUatKhoNPL;
                cls2.iID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                cls2.fSoLuongXuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                if (dtmoi.Rows[i]["DonGia"].ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = Convert.ToDouble(dtmoi.Rows[i]["DonGia"].ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.sGhiChu = dtmoi.Rows[i]["GhiChu"].ToString();
                cls2.bDaXuatKho = true;
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
                // updatesoluongton
                try
                {
                    clsKhoNPL_tbChiTietNhapKho clschitietnhapkho = new CtyTinLuong.clsKhoNPL_tbChiTietNhapKho();
                    int iiiID_VTHH = Convert.ToInt32(dtmoi.Rows[i]["ID_VTHH"].ToString());
                    double soluongxuat = Convert.ToDouble(dtmoi.Rows[i]["SoLuong"].ToString());
                    clschitietnhapkho.iID_VTHH = iiiID_VTHH;
                    DataTable dt2 = clschitietnhapkho.Select_W_ID_VTHH();
                    if (dt2.Rows.Count > 0)
                    {
                        Double douSoLuongTonCu;
                        douSoLuongTonCu = Convert.ToDouble(dt2.Rows[0]["SoLuongTon"].ToString());
                        clschitietnhapkho.iID_ChiTietNhapKho = Convert.ToInt32(dt2.Rows[0]["ID_ChiTietNhapKho"].ToString());
                        clschitietnhapkho.fSoLuongTon = douSoLuongTonCu - soluongxuat;
                        clschitietnhapkho.Update_SoLuongTon();
                    }

                }
                catch
                {

                }
            }

            // xoa ton tai=false
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_XuatKho = iiID_XUatKhoNPL;
            dt2_moi11111 = cls2.SelectAll_W_ID_XuatKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietXuatKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                cls2.iID_ChiTietXuatKho = ID_ChiTietXuatKhoxxxx;
                cls2.Delete();
            }


        }

        private void Luu_Xuatkho_NPL()
        {
            string shienthi = "1";
            DataTable dtkkk = (DataTable)gridControl1.DataSource;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv2232xx = dtkkk.DefaultView;
            DataTable dttttt2 = dv2232xx.ToTable();
            double deTOngtien_NPL;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + " and Check_VatTu_Phu=False";
            DataView dvmoi = dtkkk.DefaultView;
            DataTable dtmoi = dvmoi.ToTable();
            object xxxx = dtmoi.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien_NPL = Convert.ToDouble(xxxx);
            else deTOngtien_NPL = 0;
            clsKhoNPL_tbXuatKho clsnplxk = new clsKhoNPL_tbXuatKho();
            clsnplxk.sDienGiai = txtDienGiai.Text.ToString();
            clsnplxk.daNgayChungTu = dteNgayChungTu.DateTime;
            clsnplxk.sSoChungTu = txtSoChungTu.Text.ToString();
            clsnplxk.fTongTienHang = deTOngtien_NPL;
            clsnplxk.iID_NguoiXuatKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
            clsnplxk.sThamChieu = txtSoChungTuGapDan.Text.ToString();
            clsnplxk.bTonTai = true;
            clsnplxk.bNgungTheoDoi = false;
            clsnplxk.bDaXuatKho = true;
            clsnplxk.bCheckXuatKho_Khac = false;
            clsnplxk.Insert();
            int iiidxuatkhonpl = clsnplxk.iID_XuatKhoNPL.Value;
            Luu_ChiTiet_ChiTiet_XuatKho_NPL(iiidxuatkhonpl);
        }
  
        private void Luu_ChiTietXuatKho_banThanhPham(int iiiDXuatKho)
        {
            clsKhoBTP_ChiTietXuatKho cls = new clsKhoBTP_ChiTietXuatKho();
            cls.iID_XuatKhoBTP = iiiDXuatKho;
            DataTable dt2_Cu = cls.SelectOne_W_ID_XuatKhoBTP();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_XuatKhoBTP = iiiDXuatKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_ToTai_W_ID_XuatKho();
                }
            }
            


                int ID_VTHHxxx = Convert.ToInt32(txtID_VatTuChinh.Text.ToString());
                cls.iID_VTHH = ID_VTHHxxx;
                cls.iID_XuatKhoBTP = iiiDXuatKho;
              
                    cls.fSoLuongXuat = Convert.ToDouble(txtSoLuongVTChinh.Text.ToString());
                    //cls.fSoLuongTon = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
             
                cls.fDonGia = 0;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.sGhiChu = "";
                cls.bDaXuatKho = true;


                string expressionnhapkho;
                expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_Cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    cls.iID_ChiTietXuatKhoBTP = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKhoBTP"].ToString());
                    cls.Update();
                }
                else
                {
                    cls.Insert();
                }

          
            // xoa ton tai=false
            clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_XuatKhoBTP = iiiDXuatKho;
            dt2_moi11111 = cls2.SelectOne_W_ID_XuatKhoBTP();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKhoBTP"].ToString());
                cls2.iID_ChiTietXuatKhoBTP = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }



        }
        private void Luu_XuatKho_BanThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {                
                clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = Load_soChungTu_KhoBanThanhPham();
                cls1.fTongTienHang = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtSoChungTuGapDan.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bDaXuatKho = true;
                cls1.bCheck_XuatKho_Khac = true;
                cls1.sNguoiNhanHang = txtTenNguoiLap.Text.ToString();
                int xxID_nhapkhobtp;
                cls1.Insert();
                xxID_nhapkhobtp = cls1.iID_XuatKhoBTP.Value;
                Luu_ChiTietXuatKho_banThanhPham(xxID_nhapkhobtp);

            }

        }
        private void Luu_NhapKho_GapDan(bool bguidulieu)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTuGapDan.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_VTHH_ThanhPham_QuyDoi = Convert.ToInt32(txtID_ThanhPham.Text.ToString());
                cls1.fDonGia_ThanhPham_QuyDoi = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongThanhPham_QuyDoi = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = txtSoChungTu.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                cls1.bBool_TonDauKy = false;
                cls1.bTrangThai_XuatKho_NPL = bguidulieu;
                cls1.bTrangThai_XuatKho_BTP = false;
                cls1.bTrangThai_NhapKho_GapDan = false;
                cls1.bDaNhapKho = false;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiNhanHang = txtNguoiNhanHang.Text.ToString();
                int iiID_Nhapkho_GapDan;
                if (UCNPL_XuatKho_GapDan.mbSua == false)
                {
                    cls1.Insert();
                    iiID_Nhapkho_GapDan = cls1.iID_NhapKho.Value;
                }
                else
                {
                    cls1.iID_NhapKho = UCNPL_XuatKho_GapDan.miiID_NhapKhoGapDan;
                    iiID_Nhapkho_GapDan = UCNPL_XuatKho_GapDan.miiID_NhapKhoGapDan;
                    cls1.Update();
                }
                Luu_ChiTiet_NhapKho_GapDan(iiID_Nhapkho_GapDan);
                
            }

        }
        private void Luu_ChiTiet_NhapKho_GapDan(int iiiID_nhapkhogapgan)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                dt2_cu = cls2.SelectAll_W_ID_NhapKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_tonTai_W_ID_NhapKho();
                }
                // Nhap kho Thành pham quy doi
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                cls2.iID_VTHH = Convert.ToInt32(txtID_ThanhPham.Text.ToString());
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                if (txtDonGiaThanhPhamQuyDoi.Text.ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.bBoolTonDauKy = false;
                cls2.bCheck_ThanhPham = true;
                cls2.bCheck_VatTu_Chinh = false;
                cls2.bCheck_VatTu_Phu = false;
                int ID_VTHHxxx_TP = Convert.ToInt32(txtID_ThanhPham.Text.ToString());
                string expression_TP;
                expression_TP = "ID_VTHH=" + ID_VTHHxxx_TP + "";
                DataRow[] foundRows_TP;
                foundRows_TP = dt2_cu.Select(expression_TP);
                if (foundRows_TP.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows_TP[0]["ID_ChiTietNhapKho"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
                }

                // Nhap kho Vật tư chính
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                cls2.iID_VTHH = Convert.ToInt32(txtID_VatTuChinh.Text.ToString());
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongVTChinh.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongVTChinh.Text.ToString());
                if (txtDonGiaThanhPhamQuyDoi.Text.ToString() == "")
                    cls2.fDonGia = 0;
                else cls2.fDonGia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.bBoolTonDauKy = false;
                cls2.bCheck_ThanhPham = false;
                cls2.bCheck_VatTu_Chinh = true;
                cls2.bCheck_VatTu_Phu = false;
              
                int ID_VTHHxxx_vatttuchinh = Convert.ToInt32(txtID_VatTuChinh.Text.ToString());
                string expression_atttuchinh;
                expression_atttuchinh = "ID_VTHH=" + ID_VTHHxxx_TP + "";
                DataRow[] foundRows_atttuchinh;
                foundRows_atttuchinh = dt2_cu.Select(expression_atttuchinh);
                if (foundRows_atttuchinh.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows_atttuchinh[0]["ID_ChiTietNhapKho"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
                }
                // cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());


                // nhap kho vạt tư khác

                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx= Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bBoolTonDauKy = false;
                    cls2.bCheck_ThanhPham = false;
                    cls2.bCheck_VatTu_Chinh = false;
                    cls2.bDaNhapKho = true;
                    cls2.bCheck_VatTu_Phu = true;
                   
                string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_NhapKho = iiiID_nhapkhogapgan;
                dt2_moi11111 = cls2.SelectAll_W_ID_NhapKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                    cls2.iID_ChiTietNhapKho = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }
                
            }
        }
        private void Luu_ChiLuu()
        {
            if (!KiemTraLuu()) return ;
            else
            {
                Luu_NhapKho_GapDan(false);
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }

        private void  Luu_Va_Gui_DuLieu()
        {
            if (!KiemTraLuu()) return ;
            else
            {
                Luu_NhapKho_GapDan(true);
                Luu_XuatKho_BanThanhPham();
                Luu_Xuatkho_NPL();
                MessageBox.Show("Đã lưu và gửi dữ liệu");
                this.Close();
            }


        }
       
        public KhoNPL_frmChiTiet_XuatKho_gapDan()
        {
            InitializeComponent();
        }

        private void KhoNPL_frmChiTiet_XuatKho_gapDan_Load(object sender, EventArgs e)
        {

            Load_LockUp();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(float));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("Check_VatTu_Phu", typeof(bool));
            
            gridControl1.DataSource = dt2;            
            if (UCNPL_XuatKho_GapDan.mbThemMoi == true)
                HienThi_ThemMoi_XuatKho();
            if(UCNPL_XuatKho_GapDan.mbCopy==true)
            {
                HienThi_Sua_XuatKho();
                HienThi_ThemMoi_XuatKho();
            }
            else if (UCNPL_XuatKho_GapDan.mbSua == true)
                HienThi_Sua_XuatKho();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
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
                    txtTenNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void gridDinhMucGapDan_EditValueChanged(object sender, EventArgs e)
        {
            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            cls.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
            DataTable dt = cls.SelectAll_W_ID_DinhMuc_ToGapDan();
            if (dt.Rows.Count > 0)
            {
                double xxsoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                DataTable dt422 = dt.Copy();
                dt422.DefaultView.RowFilter = " Check_ThanhPham = True";
                DataView dv1 = dt422.DefaultView;
                DataTable dt22 = dv1.ToTable();
                txtID_ThanhPham.Text = dt22.Rows[0]["ID_VTHH"].ToString();
                txtMaTPQuyDoi.Text = dt22.Rows[0]["MaVT"].ToString();
                txtTenThanhPhamQuyDoi.Text = dt22.Rows[0]["TenVTHH"].ToString();
                txtDVTThanhPhamQuyDoi.Text = dt22.Rows[0]["DonViTinh"].ToString();

                DataTable dt322 = dt.Copy();
                dt322.DefaultView.RowFilter = " Check_VatTu_Chinh = True";
                DataView dv2 = dt322.DefaultView;
                DataTable dt223 = dv2.ToTable();
                txtID_VatTuChinh.Text = dt223.Rows[0]["ID_VTHH"].ToString();
                txtMaVTChinh.Text = dt223.Rows[0]["MaVT"].ToString();
                txtTenVatTu_Chinh.Text = dt223.Rows[0]["TenVTHH"].ToString();

                txtDVT_VT_CHinh.Text = dt223.Rows[0]["DonViTinh"].ToString();

                double SoLuong_VTChinh_DinhMuc = Convert.ToDouble(dt223.Rows[0]["SoLuong"].ToString());
                txtSoLuongVTChinh.Text = (SoLuong_VTChinh_DinhMuc * xxsoluongxuat).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double ffdongia, fffsoluong, fffthanhtien;
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuongTheoDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDinhMuc, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clCheck_VatTu_Phu, true);

                    if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }
            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();
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
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHang.Text = deTOngtien.ToString();
            }
            catch
            { }
        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void txtDonGiaThanhPhamQuyDoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaThanhPhamQuyDoi.Text);
                txtDonGiaThanhPhamQuyDoi.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_ChiLuu();
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Luu_Va_Gui_DuLieu();
           
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void txtSoLuongXuat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuongXuat.Text.ToString() != "" & gridDinhMucGapDan.EditValue.ToString() != "")
                {
                    clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                    cls.iID_DinhMuc_ToGapDan = Convert.ToInt32(gridDinhMucGapDan.EditValue.ToString());
                    DataTable dt = cls.SelectAll_W_ID_DinhMuc_ToGapDan();

                    double xxsoluongxuat = Convert.ToDouble(txtSoLuongXuat.Text.ToString());
                    DataTable dt422 = dt.Copy();

                    DataTable dt322 = dt.Copy();
                    dt322.DefaultView.RowFilter = " Check_VatTu_Chinh = True";
                    DataView dv2 = dt322.DefaultView;
                    DataTable dt223 = dv2.ToTable();

                    double SoLuong_VTChinh_DinhMuc = Convert.ToDouble(dt223.Rows[0]["SoLuong"].ToString());
                    txtSoLuongVTChinh.Text = (SoLuong_VTChinh_DinhMuc * xxsoluongxuat).ToString();
                    //if(UCNPL_XuatKho_GapDan.mbThemMoi==true)
                    HienThi_GridControl_Moiiiiiiiiiiii(xxsoluongxuat);

                }

            }
            catch
            {

            }
        }

        private void btPrint_Click(object sender, EventArgs e)
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
            //DataRow _ravi=mdtPrint.
            //_ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
            //_ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
            //_ravi["MaVT"] = cls.sMaVT.Value;
            //_ravi["TenVTHH"] = cls.sTenVTHH.Value;
            //_ravi["DonViTinh"] = cls.sDonViTinh.Value;
            //_ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString()) * Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
            //_ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();

            mdtPrint = dv.ToTable();
            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint = true;
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                msSoChungTu = txtSoChungTu.Text.ToString();
                msNguoiNhanHang = txtTenNguoiLap.Text.ToString();
                mdbTongSotien = Convert.ToDouble(txtTongTienHang.Text.ToString());
                msDienGiai = txtDienGiai.Text.ToString();
                frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                ff.Show();

            }
        }
    }
}
