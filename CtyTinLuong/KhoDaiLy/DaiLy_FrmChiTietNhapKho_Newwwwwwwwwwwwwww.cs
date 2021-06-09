using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
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
    public partial class DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww : Form
    {
        public static bool mbPrint_Chitiet_XuatKho_DaiLyGiaCong;
        public static DateTime mdaNgayXuatKho;
        public static DataTable mdt_ChiTietXuatKho;
        public static string msdvtthanhphamquydoi, msMaDaiLy, msDiaChiDaiLy, msSDTDaiLy, msGhiChu, msSoChungTu, msDienGiaig, msThuKho, msNguoiNhan, msNguoiLap, msMaThanhPham, msTenThanhPham;
        public static double mfsoluongtpqiuydoi;

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        int miID_DinhMucNPL_XXx;
        int iiiIDThanhPham_QuyDoi;
        bool Check_BaoVe, Check_LaiXe, Check_DaiLy;

        private void TinhTongSoKg_TongSoKien()
        {
            try
            {
                double soluongbaoto, soluongbaobe, sokg1baoto, sokg1baobe, sokien1baoto, sokien1baobe;
                soluongbaoto = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
                soluongbaobe = Convert.ToDouble(txtSoLuong_BaoBe.Text.ToString());
                sokg1baoto = Convert.ToDouble(txtSoKG1Bao_To.Text.ToString());
                sokg1baobe = Convert.ToDouble(txtSoKG1Bao_Be.Text.ToString());
                sokien1baobe = Convert.ToDouble(txtSoKien_1_BaoBe.Text.ToString());
                sokien1baoto = Convert.ToDouble(txtSoKien_1_BaoTo.Text.ToString());

                txtQuyRaKien_BaoBe.Text = (soluongbaobe * sokien1baobe).ToString();
                txtQuyRaKien_BaoTo.Text = (soluongbaoto * sokien1baoto).ToString();
                txtSoLuongThanhPhamQuyDoi.Text = (soluongbaobe * sokien1baobe + soluongbaoto * sokien1baoto).ToString();
                txtTongSoKG.Text = (soluongbaobe * sokg1baobe + soluongbaoto * sokg1baoto).ToString();
                if (checkHangNhu.Checked == true)
                    txtTongSoKG.Text = txtSoLuong_BaoTo.Text;
            }
            catch
            {

            }
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

            else if (gridMaDaiLy.EditValue == null)
            {
                MessageBox.Show("chưa chọn đại lý");
                return false;
            }
            else if (gridMaDinhMucDot_BaoTo.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao to");
                return false;
            }
            else if (gridMaDinhMucDot_BaoBe.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao be");
                return false;
            }
            else if (gridMaDinhMucNPL.EditValue == null)
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
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }       

        private bool Luu_themMoi_DuLieubangLuong()
        {

            if (!KiemTraLuu()) return false;
            else
            {
                int ID_DaiLyxx = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                int thangx = Convert.ToInt32(dteNgayChungTu.DateTime.ToString("MM"));
                int namxx = Convert.ToInt32(dteNgayChungTu.DateTime.ToString("yyyy"));
                DateTime tungay = GetFistDayInMonth(namxx, thangx);
                DateTime denngay = GetLastDayInMonth(namxx, thangx);

                clsDaiLy_BangLuong clsxx = new clsDaiLy_BangLuong();
                clsxx.iThang = thangx;
                clsxx.iNam = namxx;
                clsxx.iID_DaiLy = ID_DaiLyxx;
                DataTable dt = clsxx.SelectOne__W_Thang_Nam_ID_DaiLy();
                if (dt.Rows.Count == 0)
                {
                    clsxx.iID_DaiLy = ID_DaiLyxx;
                    clsxx.iThang = thangx;
                    clsxx.iNam = namxx;
                    clsxx.dcLuongDaiLy = 0;
                    clsxx.dcTamUng = 0;
                    clsxx.dcSoTienDaTra = 0;
                    clsxx.sDienGiai = "";
                    clsxx.bTonTai = true;
                    clsxx.bNgungTheoDoi = false;
                    clsxx.bDaTraLuong = false;
                    clsxx.Insert();
                }

                return true;
            }

        }

        private void Luu_ChiTiet_NhapKho_DaiLy(int iiiID_NhapKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                dt2_cu = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_TonTai_W_ID_NhapKhoDaiLy();
                }
                cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls2.iID_VTHH = iiiIDThanhPham_QuyDoi;
                cls2.fSoLuongNhap = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fSoLuongTon = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls2.fDonGia = 0;
                cls2.sGhiChu = "";
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bDaNhapKho = false;
                cls2.bBoolTonDauKy = false;
                // Nhap kho Thành pham quy doi
                int ID_VTHHxxx_TP = iiiIDThanhPham_QuyDoi;
                string expression_TP;
                expression_TP = "ID_VTHH=" + ID_VTHHxxx_TP + "";
                DataRow[] foundRows_TP;
                foundRows_TP = dt2_cu.Select(expression_TP);
                if (foundRows_TP.Length > 0)
                {
                    cls2.iID_ChiTietNhapKho_DaiLy = Convert.ToInt32(foundRows_TP[0]["ID_ChiTietNhapKho_DaiLy"].ToString());
                    cls2.Update();
                }
                else
                {
                    cls2.Insert();
                }
                // nhap kho vạt tư khác

                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaNhapKho = false;
                    cls2.bBoolTonDauKy = false;

                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietNhapKho_DaiLy = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho_DaiLy"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                dt2_moi11111 = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho_DaiLy"].ToString());
                    cls2.iID_ChiTietNhapKho_DaiLy = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }


            }
        }
        private bool Luu_NhapKhoDaiLy()
        {

            if (!KiemTraLuu()) return false;
            else
            {
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                cls1.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                DataTable dt = cls1.SelectOne();
                Check_BaoVe = cls1.bCheck_BaoVe.Value;
                Check_LaiXe = cls1.bCheck_LaiXe.Value;
                Check_DaiLy = cls1.bCheck_DaiLy.Value;
              //  DaNhapKho = cls1.bDaNhapKho.Value;


                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = Convert.ToDouble(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.fSoLuongXuat_BaoTo = Convert.ToDouble(txtSoLuong_BaoTo.Text.ToString());
                cls1.fSoLuongXuat_BaoBe = Convert.ToDouble(txtSoLuong_BaoBe.Text.ToString());
                cls1.iID_DinhMucDot_BaoTo = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
                cls1.iID_DinhMucDot_BaoBe = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
                cls1.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongTonThanhPhamQuyDoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bHoanThanh = checkHoanThanh.Checked;

                cls1.bTrangThaiXuatNhap_KhoDaiLy = true;
                cls1.bTrangThaiXuatNhap_Kho_BTP = true;
                cls1.bTrangThaiXuatNhap_Kho_NPL = true;
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bCheck_BaoVe = Check_BaoVe;
                cls1.bCheck_DaiLy = Check_DaiLy;
                cls1.bCheck_LaiXe = Check_LaiXe;
                cls1.bDaNhapKho = true;
                cls1.bBool_TonDauKy = false;
                if (checkHangDot.Checked == true)
                    cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;
                else cls1.iHangDoT_1_hangNhu_2_ConLai3 = 2;
                cls1.Update();
                // update danhapkho neu có check bao ve check lai xe check dai ly
                int iiID_Nhapkho;
                iiID_Nhapkho = cls1.iID_NhapKhoDaiLy.Value;
                if (Convert.ToBoolean(dt.Rows[0]["Check_BaoVe"].ToString()) == true & (Convert.ToBoolean(dt.Rows[0]["Check_LaiXe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_DaiLy"].ToString()) == true))
                {
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
                }
                Luu_ChiTiet_NhapKho_DaiLy(UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy);
               
                return true;
            }

        }
        
        private void HienThi_GridControl_Sua()
        {


            double soluongthanhpham = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
            double TongsoKG = Convert.ToDouble(txtTongSoKG.Text.ToString());

            gridControl1.DataSource = null;
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
            dt2.Columns.Add("BoolVTChinh", typeof(bool));
            dt2.Columns.Add("BoolNPL", typeof(bool));

            clsDaiLy_tbChiTietNhapKho cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            DataTable dt_ChiTiet_nhapkho_DaiLy = cls.SelectAll_W_ID_NhapKhoDaiLy();

            clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new CtyTinLuong.clsDinhMuc_tbDM_NguyenPhuLieu();
            cls1.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
            DataTable dt1 = cls1.SelectOne();
            int iiID_DinhMucNPL = Convert.ToInt32(dt1.Rows[0]["ID_DinhMuc_NPL"].ToString());
            int iiID_VatTuChinh1 = Convert.ToInt32(dt1.Rows[0]["ID_VTHH_Chinh"].ToString());
            clsKhoBTP_tbChiTietNhapKho clskhoBTP = new clsKhoBTP_tbChiTietNhapKho();
            clskhoBTP.iID_VTHH = iiID_VatTuChinh1;
            DataTable dtkhoBTPvtuchinh1 = clskhoBTP.Select_W_ID_VTHH_w_Ten_VTHH_KhoDaiLy();
            DataRow _ravi = dt2.NewRow();
            if (dtkhoBTPvtuchinh1.Rows.Count > 0)
            {
                _ravi["TenVTHH"] = dtkhoBTPvtuchinh1.Rows[0]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dtkhoBTPvtuchinh1.Rows[0]["DonViTinh"].ToString();
            }
            else
            {
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiID_VatTuChinh1;
                DataTable dtvt = clsvt.SelectOne();
                _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi["DonViTinh"] = clsvt.sMaVT.Value;
            }
            cls.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            double soluongxuat = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["SoLuongNhap"].ToString());
            double dongiaxxx = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["DonGia"].ToString());

            _ravi["ID_VTHH"] = iiID_VatTuChinh1;
            _ravi["MaVT"] = iiID_VatTuChinh1;

            _ravi["DinhMuc"] = 1;
            // _ravi["SoLuongTon"] = Convert.ToDouble(dtkhoBTPvtuchinh1.Rows[0]["SoLuongTon"].ToString());
            _ravi["SoLuongTheoDinhMuc"] = TongsoKG;
            _ravi["SoLuong"] = soluongxuat;
            _ravi["DonGia"] = dongiaxxx;
            _ravi["GhiChu"] = "";
            _ravi["HienThi"] = "1";
            _ravi["ThanhTien"] = soluongxuat * dongiaxxx;
            _ravi["BoolVTChinh"] = true;

            dt2.Rows.Add(_ravi);
            for (int i = 2; i < dt_ChiTiet_nhapkho_DaiLy.Rows.Count; i++)
            {
                double dongiaxxx333 = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["DonGia"].ToString());
                DataRow _ravi3 = dt2.NewRow();
                int ID_VTHH = Convert.ToInt32(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["ID_VTHH"].ToString());
                _ravi3["ID_VTHH"] = ID_VTHH;
                _ravi3["MaVT"] = ID_VTHH;
                clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
                clvthh.iID_VTHH = ID_VTHH;
                DataTable dtvth = clvthh.SelectOne();
                _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
                if (i == 1)
                {
                    clsKhoBTP_tbChiTietNhapKho xcls = new clsKhoBTP_tbChiTietNhapKho();
                    xcls.iID_VTHH = ID_VTHH;
                    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                    if (dtbtp.Rows.Count > 0)
                        _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                }
                else
                {
                    clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
                    xcls.iID_VTHH = ID_VTHH;
                    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                    if (dtbtp.Rows.Count > 0)
                        _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                }

                clsDinhMuc_ChiTiet_DM_NPL clsdm = new clsDinhMuc_ChiTiet_DM_NPL();
                clsdm.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                clsdm.iID_VTHH = ID_VTHH;
                DataTable dtctietdinhmuc = clsdm.SelectOne_W_ID_VTHH_W_ID_DinhMuc_NPL();
                double xxxxsoluongdmimucc = 0;
                if (dtctietdinhmuc.Rows.Count > 0)
                {
                    string xxsoluongdmimuc = dtctietdinhmuc.Rows[0]["SoLuong"].ToString();
                    xxxxsoluongdmimucc = Math.Round(double.Parse(xxsoluongdmimuc), 3);
                }
                else
                {
                    xxxxsoluongdmimucc = 0;
                }


                _ravi3["DinhMuc"] = xxxxsoluongdmimucc;
                _ravi3["SoLuongTheoDinhMuc"] = xxxxsoluongdmimucc * soluongthanhpham;
                double SoLuong = Convert.ToDouble(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuong"] = SoLuong;
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dt_ChiTiet_nhapkho_DaiLy.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
                _ravi3["BoolVTChinh"] = false;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;

           

        }
      
        private void HienThi_Sua_XuatKho()
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            cls1.iID_NhapKhoDaiLy = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            DataTable dt = cls1.SelectOne();
            if (cls1.iHangDoT_1_hangNhu_2_ConLai3 == 1)
                checkHangDot.Checked = true;
            if (cls1.bCheck_BaoVe.Value == true)
                checkBaoVe.Checked = true;
            else checkBaoVe.Checked = false;
            if (cls1.bCheck_LaiXe.Value == true)
                checkLaiXe.Checked = true;
            else checkLaiXe.Checked = false;
            if (cls1.bCheck_DaiLy.Value == true)
                checkDaiLy.Checked = true;
            else checkDaiLy.Checked = false;

            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtSoLuong_BaoTo.Text = cls1.fSoLuongXuat_BaoTo.Value.ToString();
            txtSoLuong_BaoBe.Text = cls1.fSoLuongXuat_BaoBe.Value.ToString();
            gridMaDinhMucDot_BaoTo.EditValue = cls1.iID_DinhMucDot_BaoTo.Value;
            gridMaDinhMucDot_BaoBe.EditValue = cls1.iID_DinhMucDot_BaoBe.Value;
            gridMaDinhMucNPL.EditValue = cls1.iID_DinhMucNguenPhuLieu.Value;
            gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
            txtGhiChu.Text = cls1.sGhiChu.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            checkHoanThanh.Checked = cls1.bHoanThanh.Value;          
            HienThi_GridControl_Sua();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_BaoTo_TextChanged(object sender, EventArgs e)
        {
            TinhTongSoKg_TongSoKien();
        }

        private void gridMaDinhMucDot_BaoTo_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_tbDinhMuc_DOT clsncc = new clsDinhMuc_tbDinhMuc_DOT();

            clsncc.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();
            try
            {

                double SoKG_1BaoTo = Convert.ToDouble(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_To = Convert.ToDouble(dt.Rows[0]["SoKienMotBao"].ToString());
                txtSoKG1Bao_To.Text = SoKG_1BaoTo.ToString();
                txtSoKien_1_BaoTo.Text = SoKienMotBao_To.ToString();
                TinhTongSoKg_TongSoKien();
                
            }
            catch
            {

            }
        }

        private void gridMaDinhMucDot_BaoBe_EditValueChanged(object sender, EventArgs e)
        {
            clsDinhMuc_tbDinhMuc_DOT clsncc = new clsDinhMuc_tbDinhMuc_DOT();
            clsncc.iID_DinhMuc_Dot = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();
            try
            {

                double SoKG_1BaoBe = Convert.ToDouble(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_Be = Convert.ToDouble(dt.Rows[0]["SoKienMotBao"].ToString());
                txtSoKG1Bao_Be.Text = SoKG_1BaoBe.ToString();
                txtSoKien_1_BaoBe.Text = SoKienMotBao_Be.ToString();
                TinhTongSoKg_TongSoKien();
               
            }
            catch
            {

            }
        }

        private void txtSoLuong_BaoBe_TextChanged(object sender, EventArgs e)
        {
            TinhTongSoKg_TongSoKien();
        }

        private void gridMaDinhMucNPL_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu clsncc = new clsDinhMuc_tbDM_NguyenPhuLieu();

                clsncc.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                miID_DinhMucNPL_XXx = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {

                    txtDienGiaiDMNPL.Text = dt.Rows[0]["DienGiai"].ToString();
                  
                }

                iiiIDThanhPham_QuyDoi = Convert.ToInt32(dt.Rows[0]["ID_VTHH_ThanhPham"].ToString());
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = iiiIDThanhPham_QuyDoi;
                DataTable dt1 = cls1.SelectOne();
                if (dt1.Rows.Count > 0)
                {

                    txtMaTPQuyDoi.Text = dt1.Rows[0]["MaVT"].ToString();
                    txtDVTThanhPhamQuyDoi.Text = dt1.Rows[0]["DonViTinh"].ToString();
                    txtTenThanhPhamQuyDoi.Text = dt1.Rows[0]["TenVTHH"].ToString();

                }

            }
            catch
            {

            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
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
                    gridView1.SetRowCellValue(e.RowHandle, clBoolVTChinh, false);

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

                //double deTOngtien;

                //string shienthi = "1";
                //DataTable dt2 = (DataTable)gridControl1.DataSource;
                //object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
                //if (xxxx.ToString() != "")
                //    deTOngtien = Convert.ToDouble(xxxx);
                //else deTOngtien = 0;
                //txtTongTienHang.Text = deTOngtien.ToString();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            mbPrint_Chitiet_XuatKho_DaiLyGiaCong = true;
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();
            string shienthi = "1";
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            mdt_ChiTietXuatKho = dv.ToTable();


            clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
            clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            DataTable dt = clsncc.SelectOne();
            msDiaChiDaiLy = clsncc.sDiaChi.Value;
            msSDTDaiLy = clsncc.sSoDienThoai.Value;
            msMaDaiLy = clsncc.sMaDaiLy.Value;


            msTenThanhPham = txtTenThanhPhamQuyDoi.Text.ToString();
            msdvtthanhphamquydoi = txtDVTThanhPhamQuyDoi.Text.ToString();
            msMaThanhPham = txtMaTPQuyDoi.Text.ToString();

            mfsoluongtpqiuydoi = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());

            mdaNgayXuatKho = dteNgayChungTu.DateTime;
            msSoChungTu = txtSoChungTu.Text.ToString();
            msDienGiaig = txtDienGiai.Text.ToString();
            msThuKho = txtTenNguoiLap.Text.ToString();
            msNguoiNhan = txtTenDaiLy.Text.ToString();
            msNguoiLap = "Phạm Thị Lành";
            msGhiChu = txtGhiChu.Text.ToString();
            frmPrint_nhapKho_DaiLy ff = new frmPrint_nhapKho_DaiLy();
            ff.Show();
        }

        private void DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww_FormClosed(object sender, FormClosedEventArgs e)
        {
            mbPrint_Chitiet_XuatKho_DaiLyGiaCong = false;
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

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
                }
            }
            catch
            {

            }
        }

        private void checkBaoVe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe.Checked == true)
                {
                    clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                    int iiID_Nhapkho;
                    iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_BaoVe();


                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();


                    MessageBox.Show("Đã qua cửa bảo vệ");
                }
            }
            catch
            {

            }

            
        }

        private void checkLaiXe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe.Checked == true)
                {
                    clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                    int iiID_Nhapkho;
                    iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_LaiXe();

                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();

                    MessageBox.Show("Đã qua cửa lái xe");
                }
            }
            catch
            {

            }
        }

        private void checkDaiLy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe.Checked == true)
                {
                    clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
                    int iiID_Nhapkho;
                    iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_DaiLy_Duoc_GiaoHang();
                    
                    cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
                    cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
                   
                    MessageBox.Show("Đại lý đã nhận hàng");
                }
            }
            catch
            {

            }
        }

        private void checkHangDot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangDot.Checked == true)
            {
                //Load_LockUp_DinhMucDot();
                checkHangNhu.Checked = false;

                layoutControlItem1_duoi.Visibility = LayoutVisibility.Always;
                layoutControlItem2_duoi.Visibility = LayoutVisibility.Always;
                layoutControlItem3_duoi.Visibility = LayoutVisibility.Always;
                layoutControlItem27.Visibility = LayoutVisibility.Always;
                layoutControlItem4_duoi.Visibility = LayoutVisibility.Always;
                layoutControlItem1tren.Text = "Kg/ 1bao";
                layoutControlItembaoto.Text = "SL Bao To";
                layoutControlItem_tongSoKG.Text = "Tổng số Kg";
            }
        }

        private void checkHangNhu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangNhu.Checked == true)
            {
                //Load_LockUp_DinhMucDot();
                checkHangDot.Checked = false;
                layoutControlItem1_duoi.Visibility = LayoutVisibility.Never;
                layoutControlItem2_duoi.Visibility = LayoutVisibility.Never;
                layoutControlItem3_duoi.Visibility = LayoutVisibility.Never;
                layoutControlItem27.Visibility = LayoutVisibility.Never;
                layoutControlItem4_duoi.Visibility = LayoutVisibility.Never;
                layoutControlItem1tren.Text = "Cục/ 1bao";
                layoutControlItembaoto.Text = "Số lượng xuất";
                layoutControlItem_tongSoKG.Text = "Tổng số cục";
            }
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

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else if (!Luu_NhapKhoDaiLy()) return;
            else if (!Luu_themMoi_DuLieubangLuong()) return;
            else
            {
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }


        private void btDaiLy_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_DaiLy_Duoc_GiaoHang();
            //if (Convert.ToBoolean(dt.Rows[0]["Check_BaoVe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_LaiXe"].ToString()) == true & Convert.ToBoolean(dt.Rows[0]["Check_DaiLy"].ToString()) == true)
            //{
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();
            //}

            MessageBox.Show("Đại lý đã nhận hàng");
        }

        private void btLaiXe_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_LaiXe();

            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();

            MessageBox.Show("Đã qua cửa lái xe");
        }

        private void btBaoVe_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            int iiID_Nhapkho;
            iiID_Nhapkho = UC_DaiLy_NhapKho_ChoGhiSo.miID_NhapKhoDaiLy;
            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            DataTable dt = cls1.SelectOne();
            cls1.Update_TrangThai_W_BaoVe();


            cls1.iID_NhapKhoDaiLy = iiID_Nhapkho;
            cls1.Update_TrangThai_DaNhapkho_CheckBaoVe_LaiXe_DaiLy();


            MessageBox.Show("Đã qua cửa bảo vệ");
        }

        private void txtSoLuongThanhPhamQuyDoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double soluong = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                double dongia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                txtTongTienHang.Text = (soluong * dongia).ToString();
            }
            catch
            {

            }
        }

        private void txtDonGiaThanhPhamQuyDoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double soluong = Convert.ToDouble(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                double dongia = Convert.ToDouble(txtDonGiaThanhPhamQuyDoi.Text.ToString());
                txtTongTienHang.Text = (soluong * dongia).ToString();
            }
            catch
            {

            }
        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);
                //txtTienCo.Text = txtTongTienHang.Text;
                //txtTienNo.Text = txtTongTienHang.Text;

            }
            catch
            {

            }
        }

        private void txtDonGiaThanhPhamQuyDoi_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtDonGiaThanhPhamQuyDoi.Text);
                txtDonGiaThanhPhamQuyDoi.Text = String.Format("{0:#,##0.00}", value);
                //txtTienCo.Text = txtTongTienHang.Text;
                //txtTienNo.Text = txtTongTienHang.Text;

            }
            catch
            {

            }
        }

        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
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

            repositoryItemLookUpEdit2.DataSource = dtxx2;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";

            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
            DataTable dtdaily = clsdaily.SelectAll();
            dtdaily.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dtdaily.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";


            clsDinhMuc_tbDM_NguyenPhuLieu clsdinhmucnpl = new clsDinhMuc_tbDM_NguyenPhuLieu();
            DataTable dt2 = clsdinhmucnpl.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvnpl = dt2.DefaultView;
            DataTable newdtnpl = dvnpl.ToTable();


            gridMaDinhMucNPL.Properties.DataSource = newdtnpl;
            gridMaDinhMucNPL.Properties.ValueMember = "ID_DinhMuc_NPL";
            gridMaDinhMucNPL.Properties.DisplayMember = "MaDinhMuc";

            clsDinhMuc_tbDinhMuc_DOT clsdinhmucdot = new clsDinhMuc_tbDinhMuc_DOT();
            DataTable dt3 = clsdinhmucdot.SelectAll();
            dt3.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv3 = dt3.DefaultView;
            dv3.Sort = "NgayThang DESC";
            DataTable dtxx3 = dv3.ToTable();


            gridMaDinhMucDot_BaoBe.Properties.DataSource = dtxx3;
            gridMaDinhMucDot_BaoBe.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoBe.Properties.DisplayMember = "SoHieu";

            gridMaDinhMucDot_BaoTo.Properties.DataSource = dtxx3;
            gridMaDinhMucDot_BaoTo.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoTo.Properties.DisplayMember = "SoHieu";

            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemLookUpEdit2.DataSource = newdtvthh;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";
        }
        public DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww()
        {
            InitializeComponent();
        }

        private void DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww_Load(object sender, EventArgs e)
        {
            
            Load_LockUp();

            HienThi_Sua_XuatKho();
        }
    }
}
