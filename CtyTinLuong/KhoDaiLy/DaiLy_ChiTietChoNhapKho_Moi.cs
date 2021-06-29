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
    public partial class DaiLy_ChiTietChoNhapKho_Moi : Form
    {
        public static bool mbPrint_Chitiet_XuatKho_DaiLyGiaCong;
        public static DateTime mdaNgayXuatKho;
        public static DataTable mdt_ChiTietXuatKho;
        public static string msdvtthanhphamquydoi, msMaDaiLy, msDiaChiDaiLy, msSDTDaiLy, msGhiChu, msSoChungTu, msDienGiaig, msThuKho, msNguoiNhan, msNguoiLap, msMaThanhPham, msTenThanhPham;
        public static double mfsoluongtpqiuydoi;

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (checkHangSot.Checked == true)
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
                else if (checkHangNhu.Checked == true)
                    cls1.iHangDoT_1_hangNhu_2_ConLai3 = 2;
                else if (checkHangSot.Checked == true)
                    cls1.iHangDoT_1_hangNhu_2_ConLai3 = 3;
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
            else if (cls1.iHangDoT_1_hangNhu_2_ConLai3 == 2)
                checkHangNhu.Checked = true;
            else if (cls1.iHangDoT_1_hangNhu_2_ConLai3 == 3)
                checkHangSot.Checked = true;

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

        public DaiLy_ChiTietChoNhapKho_Moi()
        {
            InitializeComponent();
        }

        private void DaiLy_ChiTietChoNhapKho_Moi_Load(object sender, EventArgs e)
        {

        }
    }
}
