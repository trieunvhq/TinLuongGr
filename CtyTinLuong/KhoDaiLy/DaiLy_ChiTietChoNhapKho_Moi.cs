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
    public partial class DaiLy_ChiTietChoNhapKho_Moi : Form
    {
        public static bool mbPrint_Chitiet_XuatKho_DaiLyGiaCong;
        public static DateTime mdaNgayXuatKho;
        public static DataTable mdt_ChiTietXuatKho;
        public static string msdvtthanhphamquydoi, msMaDaiLy, msDiaChiDaiLy, msSDTDaiLy, msGhiChu, msSoChungTu, msDienGiaig, msThuKho, msNguoiNhan, msNguoiLap, msMaThanhPham, msTenThanhPham;
        public static double mfsoluongtpqiuydoi;


        int miID_DinhMucNPL_XXx;

        int iiiIDThanhPham_QuyDoi;
      
        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            double soluongxuat, soluongnhap;
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy( DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy( DateTime.Now);
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

            label_TonKho.Text = ""+cls.sMaVT.Value+" - "+cls.sTenVTHH.Value+" || Tồn kho: "+soluongton.ToString()+"";

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }
        private void TinhTongSoKg_TongSoKien()
        {
            try
            {
                double soluongbaoto, soluongbaobe, sokg1baoto, sokg1baobe, sokien1baoto, sokien1baobe;
                soluongbaoto = CheckString.ConvertToDouble_My(txtSoLuong_BaoTo.Text.ToString());
                soluongbaobe = CheckString.ConvertToDouble_My(txtSoLuong_BaoBe.Text.ToString());
                sokg1baoto = CheckString.ConvertToDouble_My(txtSoKG1Bao_To.Text.ToString());
                sokg1baobe = CheckString.ConvertToDouble_My(txtSoKG1Bao_Be.Text.ToString());
                sokien1baobe = CheckString.ConvertToDouble_My(txtSoKien_1_BaoBe.Text.ToString());
                sokien1baoto = CheckString.ConvertToDouble_My(txtSoKien_1_BaoTo.Text.ToString());

                txtQuyRaKien_BaoBe.Text = (soluongbaobe * sokien1baobe).ToString();
                txtQuyRaKien_BaoTo.Text = (soluongbaoto * sokien1baoto).ToString();

                txtTongSoKG.Text = (soluongbaobe * sokg1baobe + soluongbaoto * sokg1baoto).ToString();
                if (CheckHangCuc.Checked == true)
                {
                    txtTongSoKG.Text = txtSoLuong_BaoTo.Text;
                    txtQuyRaKien_BaoTo.Text = (soluongbaoto / sokien1baoto).ToString();
                    double soluongthanhphamquydoi = soluongbaoto / sokien1baoto;

                    txtSoLuongThanhPhamQuyDoi.Text = Math.Round((double)(soluongthanhphamquydoi)).ToString();
                }
                else
                {
                    double soluongthanhphamquydoi = soluongbaobe * sokien1baobe + soluongbaoto * sokien1baoto;
                    txtSoLuongThanhPhamQuyDoi.Text = Math.Round((double)(soluongthanhphamquydoi)).ToString();
                }

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
                gridMaDaiLy.Focus();
                return false;
            }
            else if (gridMaDinhMucDot_BaoTo.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao to");
                gridMaDinhMucDot_BaoTo.Focus();
                return false;
            }
            else if (gridMaDinhMucDot_BaoBe.EditValue == null)
            {
                MessageBox.Show("chưa chọn Định mức đột bao be");
                gridMaDinhMucDot_BaoBe.Focus();
                return false;
            }
            else if (gridMaDinhMucNPL.EditValue == null)
            {
                MessageBox.Show("chưa chọn định mức nguyên phụ liệu");
                gridMaDinhMucNPL.Focus();
                return false;
            }
            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                dteNgayChungTu.Focus();
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
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("chưa có người nhập kho");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }
        private void Luu_ChiTiet_NhapKho_DaiLy(int iiiID_NhapKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    string shienthi = "1";
                    DataTable dtkkk = (DataTable)gridControl1.DataSource;
                    dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv2232xx = dtkkk.DefaultView;
                    DataTable dt232 = dv2232xx.ToTable();

                    clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                    cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                    cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls2.iID_VTHH = iiiIDThanhPham_QuyDoi;
                    cls2.fSoLuongNhap = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                    cls2.fSoLuongTon = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                    cls2.fDonGia = 0;
                    cls2.sGhiChu = "";
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaNhapKho = false;
                    cls2.bBoolTonDauKy = false;
                    cls2.Insert();
                    DataTable dttttt2 = dv2232xx.ToTable();
                    for (int i = 0; i < dttttt2.Rows.Count; i++)
                    {
                        cls2 = new clsDaiLy_tbChiTietNhapKho();
                        cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                        int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                        cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                        cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                        cls2.fSoLuongNhap = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuong"].ToString());
                        cls2.fSoLuongTon = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["SoLuong"].ToString());
                        if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                            cls2.fDonGia = 0;
                        else cls2.fDonGia = CheckString.ConvertToDouble_My(dttttt2.Rows[i]["DonGia"].ToString());
                        cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.bDaNhapKho = false;
                        cls2.bBoolTonDauKy = false;
                        cls2.Insert();
                    }

                    this.Close();
                    _ucNKDL.UCChoNhapKho_DaiLy_new_Load(null, null);
                    MessageBox.Show("Đã lưu và gửi dữ liệu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Luu_NhapKhoDaiLy(int xxxID_NhapKho)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
               
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.fTongTienHang = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.fSoLuongXuat_BaoTo = CheckString.ConvertToDouble_My(txtSoLuong_BaoTo.Text.ToString());
                cls1.fSoLuongXuat_BaoBe = CheckString.ConvertToDouble_My(txtSoLuong_BaoBe.Text.ToString());
                cls1.iID_DinhMucDot_BaoTo = Convert.ToInt32(gridMaDinhMucDot_BaoTo.EditValue.ToString());
                cls1.iID_DinhMucDot_BaoBe = Convert.ToInt32(gridMaDinhMucDot_BaoBe.EditValue.ToString());
                cls1.fSoLuongThanhPhamQuyDoi = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.fSoLuongTonThanhPhamQuyDoi = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                cls1.iID_DinhMucNguenPhuLieu = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                cls1.iID_VTHH_TPQuyDoi = iiiIDThanhPham_QuyDoi;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bHoanThanh = false;
                cls1.bTrangThaiXuatNhap_KhoDaiLy = true;
                cls1.bTrangThaiXuatNhap_Kho_BTP = true;
                cls1.bTrangThaiXuatNhap_Kho_NPL = true;
                cls1.sThamChieu = txtThamChieu.Text.ToString();
                cls1.bCheck_BaoVe = false;
                cls1.bCheck_DaiLy = false;
                cls1.bCheck_LaiXe = false;
                cls1.bDaNhapKho = true;
                cls1.bBool_TonDauKy = false;
                if (checkHangDot.Checked == true)
                    cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 1;
                else if (checkHangNhu.Checked == true)
                    cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 2;
                else if (CheckHangCuc.Checked == true)
                    cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 3;
                else if (checkHangSot.Checked == true)
                    cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 4;
                cls1.Insert();
               
                int iiID_Nhapkho;
                iiID_Nhapkho = cls1.iID_NhapKhoDaiLy.Value;
               
                Luu_ChiTiet_NhapKho_DaiLy(iiID_Nhapkho);

                // update trạng thái nhập kho
                clsDaiLy_tbNhapKho_Temp clstemp = new clsDaiLy_tbNhapKho_Temp();
                clstemp.iID_NhapKhoDaiLy = xxxID_NhapKho;
                clstemp.Update_TrangThaiXuatNhap_KhoDaiLy();

                MessageBox.Show("Đã lưu");
                this.Close();
             
            }

        }
        private void Load_lock_DinhMucDot(int iiiiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0)
        {
            clsDinhMuc_tbDinhMuc_DOT clsdinhmucdot = new clsDinhMuc_tbDinhMuc_DOT();
            DataTable dt3 = clsdinhmucdot.SA_W_Loaihang(iiiiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);



            gridMaDinhMucDot_BaoTo.Properties.DataSource = dt3;
            gridMaDinhMucDot_BaoTo.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoTo.Properties.DisplayMember = "SoHieu";

            gridMaDinhMucDot_BaoBe.Properties.DataSource = dt3;
            gridMaDinhMucDot_BaoBe.Properties.ValueMember = "ID_DinhMuc_Dot";
            gridMaDinhMucDot_BaoBe.Properties.DisplayMember = "SoHieu";
        }
        private void HienThi_GridControl_Sua(int iiiixxID_NhapKhodaily)
        {
            double soluongthanhpham = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
            double TongsoKG = CheckString.ConvertToDouble_My(txtTongSoKG.Text.ToString());

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

            clsDaiLy_tbChiTietNhapKho_Temp cls = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho_Temp();
            cls.iID_NhapKhoDaiLy = iiiixxID_NhapKhodaily;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            int id_dinhmuc_ = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
            DataTable dt_ChiTiet_nhapkho_DaiLy = cls.SelectAll_W_ID_NhapKhoDaiLy_Moi2(id_dinhmuc_);

            clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new CtyTinLuong.clsDinhMuc_tbDM_NguyenPhuLieu();
            cls1.iID_DinhMuc_NPL = id_dinhmuc_;
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
            cls.iID_NhapKhoDaiLy = iiiixxID_NhapKhodaily;
            cls.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            double soluongxuat = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["SoLuongNhap"].ToString());
            double dongiaxxx = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[1]["DonGia"].ToString());

            _ravi["ID_VTHH"] = iiID_VatTuChinh1;
            _ravi["MaVT"] = iiID_VatTuChinh1;

            _ravi["DinhMuc"] = 1;
            // _ravi["SoLuongTon"] = CheckString.ConvertToDouble_My(dtkhoBTPvtuchinh1.Rows[0]["SoLuongTon"].ToString());
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
                double dongiaxxx333 = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["DonGia"].ToString());
                DataRow _ravi3 = dt2.NewRow();
                int ID_VTHH = Convert.ToInt32(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["ID_VTHH"].ToString());
                _ravi3["ID_VTHH"] = ID_VTHH;
                _ravi3["MaVT"] = ID_VTHH;
                //clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
                //clvthh.iID_VTHH = ID_VTHH;
                //DataTable dtvth = clvthh.SelectOne();
                _ravi3["TenVTHH"] = dt_ChiTiet_nhapkho_DaiLy.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dt_ChiTiet_nhapkho_DaiLy.Rows[i]["DonViTinh"].ToString();
                //if (i == 1)
                //{
                //    clsKhoBTP_tbChiTietNhapKho xcls = new clsKhoBTP_tbChiTietNhapKho();
                //    xcls.iID_VTHH = ID_VTHH;
                //    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                //    if (dtbtp.Rows.Count > 0)
                //        _ravi3["SoLuongTon"] = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["SoLuongTon_KhoBTP"].ToString());
                //}
                //else
                //{
                ////    clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
                ////    xcls.iID_VTHH = ID_VTHH;
                ////    DataTable dtbtp = xcls.Select_W_ID_VTHH();
                ////    if (dtbtp.Rows.Count > 0)
                //    _ravi3["SoLuongTon"] = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[0]["SoLuongTon_KhoNPL"].ToString());
                //}

                //clsDinhMuc_ChiTiet_DM_NPL clsdm = new clsDinhMuc_ChiTiet_DM_NPL();
                //clsdm.iID_DinhMuc_NPL = Convert.ToInt32(gridMaDinhMucNPL.EditValue.ToString());
                //clsdm.iID_VTHH = ID_VTHH;
                //DataTable dtctietdinhmuc = clsdm.SelectOne_W_ID_VTHH_W_ID_DinhMuc_NPL();
                string xxsoluongdmimuc = dt_ChiTiet_nhapkho_DaiLy.Rows[i]["SoLuong_DM"].ToString();
                double xxxxsoluongdmimucc = Math.Round(double.Parse(xxsoluongdmimuc), 3);


                _ravi3["DinhMuc"] = xxxxsoluongdmimucc;
                _ravi3["SoLuongTheoDinhMuc"] = xxxxsoluongdmimucc * soluongthanhpham;
                double SoLuong = CheckString.ConvertToDouble_My(dt_ChiTiet_nhapkho_DaiLy.Rows[i]["SoLuongNhap"].ToString());
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
        private void sochungtunhapkho_DaiLy()
        {
            
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt = cls.SelectAll();
            int k = dt.Rows.Count;
            if (dt.Rows.Count == 0)
                txtSoChungTu.Text = "NKDL 1";
            else
            {
                string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                txtSoChungTu.Text = "NKDL " + xxx2 + "";

            }
            

        }
        private void HienThi_Sua_XuatKho( int xxID_NhapKhodaily)
        {
            sochungtunhapkho_DaiLy();

            clsDaiLy_tbNhapKho_Temp cls1 = new clsDaiLy_tbNhapKho_Temp();
            cls1.iID_NhapKhoDaiLy = xxID_NhapKhodaily;
            DataTable dt = cls1.SelectOne();
            if (cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 1)
                checkHangDot.Checked = true;
            else if (cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 2)
                checkHangNhu.Checked = true;
            else if (cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 3)
                CheckHangCuc.Checked = true;
            else if (cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 4)
                checkHangSot.Checked = true;

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
            HienThi_GridControl_Sua(xxID_NhapKhodaily);
        }
        private void Load_LockUp()
        {
            clsThin cls = new clsThin();
            DataSet dtset_ = cls.T_LockUp_DaiLy_ChiTietChoNhapKho_Moi();
             
            gridNguoiLap.Properties.DataSource = dtset_.Tables[0];
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
             
            repositoryItemLookUpEdit2.DataSource = dtset_.Tables[1];
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";
             
            gridMaDaiLy.Properties.DataSource = dtset_.Tables[2];
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";
             

            gridMaDinhMucNPL.Properties.DataSource = dtset_.Tables[3];
            gridMaDinhMucNPL.Properties.ValueMember = "ID_DinhMuc_NPL";
            gridMaDinhMucNPL.Properties.DisplayMember = "MaDinhMuc";
             

            repositoryItemLookUpEdit2.DataSource = dtset_.Tables[1];
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";
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

                double SoKG_1BaoTo = CheckString.ConvertToDouble_My(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_To = CheckString.ConvertToDouble_My(dt.Rows[0]["SoKienMotBao"].ToString());
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

                double SoKG_1BaoBe = CheckString.ConvertToDouble_My(dt.Rows[0]["SoKG_MotBao"].ToString());
                double SoKienMotBao_Be = CheckString.ConvertToDouble_My(dt.Rows[0]["SoKienMotBao"].ToString());
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
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }
            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);

                //double deTOngtien;

                //string shienthi = "1";
                //DataTable dt2 = (DataTable)gridControl1.DataSource;
                //object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and BoolVTChinh = False");
                //if (xxxx.ToString() != "")
                //    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
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
            try
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

                mfsoluongtpqiuydoi = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());

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
            catch
            {
                MessageBox.Show("Liên hệ bên viết phần mềm để khắc phục sự cố này!", "Thông báo");
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
        
        private void checkHangDot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangDot.Checked == true)
            {
                Load_lock_DinhMucDot(1);
                checkHangNhu.Checked = false;
                checkHangSot.Checked = false;
                CheckHangCuc.Checked = false;
                layoutbaobe.Visibility = LayoutVisibility.Always;
                layoutDM_Duoi.Visibility = LayoutVisibility.Always;
                layoutKg1baonho.Visibility = LayoutVisibility.Always;
                layoutkien1baonho.Visibility = LayoutVisibility.Always;
                layoutQuyKien_Duoi.Visibility = LayoutVisibility.Always;
                layoutkg1baoto.Visibility = LayoutVisibility.Always;
                layoutkg1baoto.Text = "Kg/bao to";

                layoutbaoto.Text = "SL Bao To";
                layoutControlItem_tongSoKG.Text = "Tổng số Kg";
                layoutKg1baonho.Text = "Kg/Bao bé";
                layoutbaobe.Text = "SL Bao bé";

                layoutkien1baoto.Text = "Số kiện/bao to";
                layoutkien1baonho.Text = "Số kiện/bao bé";
            }
        }

        private void CheckHangCuc_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckHangCuc.Checked == true)
            {
                Load_lock_DinhMucDot(3);
                checkHangNhu.Checked = false;
                checkHangDot.Checked = false;
                checkHangSot.Checked = false;
                layoutbaobe.Visibility = LayoutVisibility.Never;
                layoutDM_Duoi.Visibility = LayoutVisibility.Never;
                layoutKg1baonho.Visibility = LayoutVisibility.Never;
                layoutkien1baonho.Visibility = LayoutVisibility.Never;
                layoutQuyKien_Duoi.Visibility = LayoutVisibility.Never;
                layoutkg1baoto.Visibility = LayoutVisibility.Never;

                //   layoutkg1baoto.Text = "Cục/ 1bao";
                layoutbaoto.Text = "Số lượng xuất (Cục)";
                layoutControlItem_tongSoKG.Text = "Tổng số cục";
                layoutkien1baoto.Text = "Số Cục/Kiện";
                txtSoLuong_BaoBe.Text = "0";
                txtSoKG1Bao_Be.Text = "0";
                txtSoKien_1_BaoBe.Text = "0";
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
                gridNguoiLap.Focus();
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
                gridMaDaiLy.Focus();
            }
        }

        private void txtTenNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaDaiLy.Focus();
            }
        }

        private void gridMaDaiLy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtTenDaiLy_KeyPress(object sender, KeyPressEventArgs e)
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
                txtSoLuong_BaoTo.Focus();
            }
        }

        private void txtSoLuong_BaoTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaDinhMucDot_BaoTo.Focus();
            }
        }

        private void gridMaDinhMucDot_BaoTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoKG1Bao_To.Focus();
            }
        }

        private void txtSoKG1Bao_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoKien_1_BaoTo.Focus();
            }
        }

        private void txtSoKien_1_BaoTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtQuyRaKien_BaoTo.Focus();
            }
        }

        private void txtQuyRaKien_BaoTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoLuong_BaoBe.Focus();
            }
        }

        private void txtSoLuong_BaoBe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaDinhMucDot_BaoBe.Focus();
            }
        }

        private void gridMaDinhMucDot_BaoBe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoKG1Bao_Be.Focus();
            }
        }

        private void txtSoKG1Bao_Be_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoKien_1_BaoBe.Focus();
            }
        }

        private void txtSoKien_1_BaoBe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtQuyRaKien_BaoBe.Focus();
            }
        }

        private void txtQuyRaKien_BaoBe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaDinhMucNPL.Focus();
            }
        }

        private void gridMaDinhMucNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoLuongThanhPhamQuyDoi.Focus();
            }
        }

        private void txtDienGiaiDMNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtMaTPQuyDoi.Focus();
            }
        }

        private void txtMaTPQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoLuongThanhPhamQuyDoi.Focus();
            }
        }

        private void txtSoLuongThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDonGiaThanhPhamQuyDoi.Focus();
            }
        }

        private void txtTenThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDVTThanhPhamQuyDoi.Focus();
            }
        }

        private void txtDVTThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDonGiaThanhPhamQuyDoi.Focus();
            }
        }

        private void txtDonGiaThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtTongTienHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTongSoKG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                try
                {
                    Hienthi_Lable_TonKho(xxID);
                }
                catch { }
               
            }
        }

        private void checkHangNhu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangNhu.Checked == true)
            {
                Load_lock_DinhMucDot(2);
                checkHangSot.Checked = false;
                checkHangDot.Checked = false;
                CheckHangCuc.Checked = false;
                layoutbaobe.Visibility = LayoutVisibility.Never;
                layoutDM_Duoi.Visibility = LayoutVisibility.Never;
                layoutKg1baonho.Visibility = LayoutVisibility.Never;
                layoutkien1baonho.Visibility = LayoutVisibility.Never;
                layoutQuyKien_Duoi.Visibility = LayoutVisibility.Never;
                layoutkg1baoto.Visibility = LayoutVisibility.Always;

                layoutkg1baoto.Text = "Cục/ 1bao";
                layoutbaoto.Text = "SL xuất (Bao)";
                layoutControlItem_tongSoKG.Text = "Tổng số cục";
                layoutkien1baoto.Text = "Số kiện/bao";
                txtSoLuong_BaoBe.Text = "0";
                txtSoKG1Bao_Be.Text = "0";
                txtSoKien_1_BaoBe.Text = "0";
            }
        }

        private void checkHangSot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangSot.Checked == true)
            {
                Load_lock_DinhMucDot(4);
                checkHangNhu.Checked = false;
                checkHangDot.Checked = false;
                CheckHangCuc.Checked = false;


                layoutkg1baoto.Text = "Kg/ sọt";
                layoutbaoto.Text = "SL xuất (Sọt)";
                layoutkien1baoto.Text = "Số kiện/Sọt";
                layoutControlItem_tongSoKG.Text = "Tổng số Kg";

                layoutbaobe.Visibility = LayoutVisibility.Never;
                layoutDM_Duoi.Visibility = LayoutVisibility.Never;
                layoutKg1baonho.Visibility = LayoutVisibility.Never;
                layoutkien1baonho.Visibility = LayoutVisibility.Never;
                layoutQuyKien_Duoi.Visibility = LayoutVisibility.Never;
                layoutkg1baoto.Visibility = LayoutVisibility.Always;

                txtSoLuong_BaoBe.Text = "0";
                txtSoKG1Bao_Be.Text = "0";
                txtSoKien_1_BaoBe.Text = "0";
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
            Luu_NhapKhoDaiLy(UCChoNhapKho_DaiLy_new.miID_NhapKhoDaiLy);
        }

        private void txtSoLuongThanhPhamQuyDoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double soluong = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                double dongia = CheckString.ConvertToDouble_My(txtDonGiaThanhPhamQuyDoi.Text.ToString());
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
                double soluong = CheckString.ConvertToDouble_My(txtSoLuongThanhPhamQuyDoi.Text.ToString());
                double dongia = CheckString.ConvertToDouble_My(txtDonGiaThanhPhamQuyDoi.Text.ToString());
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

        UCChoNhapKho_DaiLy_new _ucNKDL;

        public DaiLy_ChiTietChoNhapKho_Moi(UCChoNhapKho_DaiLy_new ucNKDL)
        {
            _ucNKDL = ucNKDL;
            InitializeComponent();
        }

        private void DaiLy_ChiTietChoNhapKho_Moi_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            HienThi_Sua_XuatKho(UCChoNhapKho_DaiLy_new.miID_NhapKhoDaiLy);

            txtSoChungTu.Focus();
            Cursor.Current = Cursors.Default;
        }

     
    }
}
