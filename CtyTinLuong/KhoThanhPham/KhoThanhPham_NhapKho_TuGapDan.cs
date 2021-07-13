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
    public partial class KhoThanhPham_NhapKho_TuGapDan : Form
    {
        //
        public static bool mbThemMoi_XuatKhohoDaiLy, mbCopy, mbSua;
        public static int miID_XuatKhoDaiLy;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayChungTu;
        public static string msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy, msSoChungTu, msGhiChu;
        public static string msdvtthanhphamquydoi, msMaThanhPham, msTenThanhPham;
        public static double mfPrint_soluongtpqiuydoi;
        //

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

            clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            //cls.iID_NhapKho = Convert.ToInt32(gridThamChieu.EditValue.ToString());

            DataTable dtchitiet1 = cls.SelectAll_W_ID_NhapKho();
            //  dtchitiet1.DefaultView.RowFilter = "Check_VatTu_Phu = True";
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
                _ravi3["SoLuongTheoDinhMuc"] = xxsoluongdinhmuc * soluongxuatxxx;
                _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
                _ravi3["SoLuong"] = SoLuong;
                if (dtbtp.Rows.Count > 0)
                    _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtchitietnhapkho.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
                _ravi3["Check_VatTu_Phu"] = false;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
           

        }
        public static DateTime mdaPrintNgayXuatKho;
        public static DataTable mdtPrint_ChiTietXuatKho;
        public static string msPrintSoChungTu, msPrintDienGiaig, msPrintThuKho, msPrintNguoiNhan, msPrintNguoiLap;

        private string sochungtu_gapdan()
        {
            string sochungtu = "";
            clsGapDan_tbXuatKho_Temp cls3 = new clsGapDan_tbXuatKho_Temp();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "XKGD 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "XKGD " + xxx2 + "";

            }
            return sochungtu;
        }
        private void HienThi_ThemMoi_XuatKho()
        {
            checkNhapKhoThanhPham.Checked = true;
            checkNhapKho_banThanhPham.Checked = false;
            gridNguoiLap.EditValue = 14;

            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = sochungtu_gapdan();

           DataTable dt22xx = new DataTable();
            dt22xx.Columns.Add("ID_NhapKhoGapDan", typeof(int));
            dt22xx.Columns.Add("ID_DinhMuc_ToGapDan", typeof(int));
            dt22xx.Columns.Add("ID_VTHH_ThanhPham_QuyDoi", typeof(int));
            dt22xx.Columns.Add("MaVT", typeof(string));
            dt22xx.Columns.Add("TenVTHH", typeof(string));          
            dt22xx.Columns.Add("DonViTinh", typeof(string));
           
            dt22xx.Columns.Add("SoLuongXuat", typeof(double));
            dt22xx.Columns.Add("SoLuongThanhPham_QuyDoi", typeof(double));           
            dt22xx.Columns.Add("DonGia", typeof(double));
            dt22xx.Columns.Add("TiLe", typeof(double));
            dt22xx.Columns.Add("HienThi", typeof(string));
            dt22xx.Columns.Add("ThanhTien", typeof(double));
            gridControl2.DataSource = dt22xx;


        }
        private void HienThi_Sua_XuatKho(int iiiiID_XuatKho)
        {
            clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
            cls1.iID_XuatKho = iiiiID_XuatKho;
            DataTable dt22222 = cls1.SelectOne();
            if (cls1.bGuiDuLieu == true)
            {
                btLuu_Gui_Dong.Enabled = false;
                btLuu.Enabled = false;
            }
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            if (cls1.bCheckNhapKhoThanhPham == true)
                checkNhapKhoThanhPham.Checked = true;
            else checkNhapKho_banThanhPham.Checked = true;
            clsGapDan_ThamChieuTinhXuatKho_Temp cls = new clsGapDan_ThamChieuTinhXuatKho_Temp();
            
            DataTable dt222 = cls.SA_ID_XuatKho_moi(iiiiID_XuatKho);          
            gridControl2.DataSource = dt222;


            clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();            
            DataTable dtxx = cls2.SA_ID_XuatKho_HienThi(iiiiID_XuatKho);
            gridControl1.DataSource = dtxx;
            
            cls.Dispose();
            cls1.Dispose();
        }

        private void HienThi_Copy(int iiiiID_XuatKho)
        {
            clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
            cls1.iID_XuatKho = iiiiID_XuatKho;
            DataTable dt22222 = cls1.SelectOne();           
            txtSoChungTu.Text = sochungtu_gapdan();
            dteNgayChungTu.EditValue = DateTime.Today;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            if (cls1.bCheckNhapKhoThanhPham == true)
                checkNhapKhoThanhPham.Checked = true;
            else checkNhapKho_banThanhPham.Checked = true;
            clsGapDan_ThamChieuTinhXuatKho_Temp cls = new clsGapDan_ThamChieuTinhXuatKho_Temp();

            DataTable dt222 = cls.SA_ID_XuatKho_moi(iiiiID_XuatKho);
            gridControl2.DataSource = dt222;


            clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();
            DataTable dtxx = cls2.SA_ID_XuatKho_HienThi(iiiiID_XuatKho);
            gridControl1.DataSource = dtxx;

            cls.Dispose();
            cls1.Dispose();
        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();          

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            dtNguoi.Dispose();
            clsNguoi.Dispose();

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();           
            gridMaVT.DataSource = dt;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";

            dt.Dispose();
            cls.Dispose();
        }
        private void Load_LockUp_MaHang(DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
            DataTable dt = cls.SA_NgayThang(xxtungay,xxdenngay);            
            gridMaHang.DataSource = dt;
            gridMaHang.ValueMember = "ID_NhapKho";
            gridMaHang.DisplayMember = "SoChungTu";
           
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
        private string soChungTu_KhoThanhPham()
        {
            string sochungtu;
            clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "NKTP 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "NKTP " + xxx2 + "";

            }
            return sochungtu;
        }
        private string soChungTu_KhoNPL()
        {
            string sochungtu;
            clsKhoNPL_tbNhapKho cls3 = new clsKhoNPL_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "NKNPL 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                sochungtu = "NKNPL " + xxx2 + "";

            }
            return sochungtu;
        }

        private string soChungTu_Kho_BTP()
        {
            string sochungtu;
            clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
            DataTable dt1 = cls3.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
                sochungtu = "NKBTP 1";
            else
            {
                string xxx = dv3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                sochungtu = "NKBTP " + xxx2 + "";

            }
            return sochungtu;
        }
        private void Luu_NhapKho_Khac_KhoNPL()
        {
            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
                if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
                {
                    clsKhoNPL_tbNhapKho cls3 = new clsKhoNPL_tbNhapKho();
                    cls3.sDienGiai = txtDienGiai.Text.ToString();
                    cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls3.fTongTienHang = 0;
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    cls3.iID_NguoiNhapKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls3.sThamChieu = txtSoChungTu.Text.ToString();
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = true;
                    DataTable dt3npl = cls3.SelectOne_W_ThamChieu_NhapKho_DaiLy();
                    int iiID_nhapkhoNPL;
                    if (dt3npl.Rows.Count == 0)

                    {
                        cls3.sSoChungTu = soChungTu_KhoNPL();
                        cls3.Insert();
                        iiID_nhapkhoNPL = cls3.iID_NhapKho.Value;
                    }
                    else
                    {
                        cls3.iID_NhapKho = Convert.ToInt32(dt3npl.Rows[0]["ID_NhapKho"].ToString());
                        cls3.sSoChungTu = dt3npl.Rows[0]["SoChungTu"].ToString();
                        cls3.Update();
                        iiID_nhapkhoNPL = Convert.ToInt32(dt3npl.Rows[0]["ID_NhapKho"].ToString());
                    }
                    Luu_ChiTietNhapKho_NPL(iiID_nhapkhoNPL);

                }

            }

        }
        private void Luu_NhapKho_Khac_Kho_banThanhPham()
        {
            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
                if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
                {

                    clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
                    cls3.sDienGiai = txtDienGiai.Text.ToString();
                    cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls3.fTongTienHang = 0;
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls3.sThamChieu = txtSoChungTu.Text.ToString();
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = true;
                    DataTable dt3btp = cls3.SelectOne_W_ThamChieu_NhapKho_HangTuDaiLyVe();
                    int iiIDnhapkho_Btp;
                    if (dt3btp.Rows.Count == 0)

                    {
                        cls3.sSoChungTu = soChungTu_Kho_BTP();
                        cls3.Insert();
                        iiIDnhapkho_Btp = cls3.iID_NhapKhoBTP.Value;
                    }
                    else
                    {
                        cls3.iID_NhapKhoBTP = Convert.ToInt32(dt3btp.Rows[0]["ID_NhapKhoBTP"].ToString());
                        cls3.sSoChungTu = dt3btp.Rows[0]["SoChungTu"].ToString();
                        cls3.Update();
                        iiIDnhapkho_Btp = Convert.ToInt32(dt3btp.Rows[0]["ID_NhapKhoBTP"].ToString());
                    }
                    Luu_ChiTietNhapKho_BanThanhPham(iiIDnhapkho_Btp);

                }


            }

        }
        private void Luu_NhapKho_Khac_KhoThanhPham()
        {
            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
                if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho TP")
                {
                    clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
                    cls3.sDienGiai = txtDienGiai.Text.ToString();
                    cls3.sSoChungTu = soChungTu_KhoThanhPham();
                    cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls3.fTongTienHang = 0;
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls3.sThamChieu = txtSoChungTu.Text.ToString();
                    cls3.iID_DaiLy = 0;
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = true;
                    cls3.sGhiChu = "";
                    cls3.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    DataTable dt3thanhpham = cls3.SelectOne_W_ThamChieu_SoChungTu_XuatKho_DaiLy();
                    int iiIDnhapkho_tp;
                    if (dt3thanhpham.Rows.Count == 0)

                    {
                        cls3.sSoChungTu = soChungTu_Kho_BTP();
                        cls3.Insert();
                        iiIDnhapkho_tp = cls3.iID_NhapKho_ThanhPham.Value;
                    }
                    else
                    {
                        cls3.iID_NhapKho_ThanhPham = Convert.ToInt32(dt3thanhpham.Rows[0]["ID_NhapKho_ThanhPham"].ToString());
                        cls3.sSoChungTu = dt3thanhpham.Rows[0]["SoChungTu"].ToString();
                        cls3.Update();
                        iiIDnhapkho_tp = Convert.ToInt32(dt3thanhpham.Rows[0]["ID_NhapKho_ThanhPham"].ToString());
                    }
                    Luu_ChiTietNhapKho_thanhpham(iiIDnhapkho_tp);

                }

            }

        }
        private void Luu_ChiTietNhapKho_thanhpham(int iiIDINhapKho)
        {

            clsKhoBTP_tbChiTietNhapKho cls5 = new clsKhoBTP_tbChiTietNhapKho();

            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            //NhapKho_TP_1_BTP_2_NPL_3
            string xx = "2";
            dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            if (mdtKhauTru.Rows.Count > 0)
            {
                clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = soChungTu_KhoThanhPham();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = 0;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.bCheck_NhapKho_Khac = false;

                cls3.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkho = cls3.iID_NhapKhoBTP.Value;

                for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                {
                    cls5.iID_NhapKho = iiDI_nhapkho;
                    cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                    cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                    cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;
                    cls5.bDaNhapKho = true;
                    cls5.bBoolTonDauKy = false;
                    cls5.sGhiChu = "";
                    cls5.Insert();
                }
            }

        }
        private void Luu_ChiTietNhapKho_BanThanhPham(int iiIDINhapKho)
        {


            clsKhoBTP_tbChiTietNhapKho cls = new clsKhoBTP_tbChiTietNhapKho();
            cls.iID_NhapKho = iiIDINhapKho;
            DataTable dt2_Cu = cls.SelectAll_W_ID_NhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_ToTai_W_ID_NhapKho();
                }
            }

            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
                if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
                {
                    int ID_VTHHxxx = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_NhapKho = iiIDINhapKho;
                    if (mdtKhauTru.Rows[i]["SoLuong"].ToString() != "")
                    {
                        cls.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                    }
                    else
                    {
                        cls.fSoLuongNhap = 0;
                        cls.fSoLuongTon = 0;
                    }
                    if (mdtKhauTru.Rows[i]["DonGia"].ToString() != "")
                        cls.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                    else cls.fDonGia = 0;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.sGhiChu = mdtKhauTru.Rows[i]["GhiChu"].ToString();
                    cls.bDaNhapKho = true;
                    cls.bBoolTonDauKy = false;

                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_Cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                        cls.Update();
                    }
                    else
                    {
                        cls.Insert();
                    }

                }
            }

            // xoa ton tai=false
            clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho = iiIDINhapKho;
            dt2_moi11111 = cls2.SelectAll_W_ID_NhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                cls2.iID_ChiTietNhapKho = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }

        }
        private void Luu_ChiTietNhapKho_NPL(int iiIDINhapKho)
        {
            clsKhoNPL_tbChiTietNhapKho cls = new clsKhoNPL_tbChiTietNhapKho();
            cls.iID_NhapKho = iiIDINhapKho;
            DataTable dt2_Cu = cls.Select_W_ID_NhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_TonTai_W_ID_NhapKho();
                }
            }

            DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
            CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
                if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
                {
                    int ID_VTHHxxx = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_NhapKho = iiIDINhapKho;
                    if (mdtKhauTru.Rows[i]["SoLuong"].ToString() != "")
                    {
                        cls.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                    }
                    else
                    {
                        cls.fSoLuongNhap = 0;
                        cls.fSoLuongTon = 0;
                    }
                    if (mdtKhauTru.Rows[i]["DonGia"].ToString() != "")
                        cls.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                    else cls.fDonGia = 0;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.sGhiChu = mdtKhauTru.Rows[i]["GhiChu"].ToString();
                    cls.bDaNhapKho = true;
                    cls.bBoolTonDauKy = false;

                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_Cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                        cls.Update();
                    }
                    else
                    {
                        cls.Insert();
                    }
                }
            }

            // xoa ton tai=false
            clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho = iiIDINhapKho;
            dt2_moi11111 = cls2.Select_W_ID_NhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                cls2.iID_ChiTietNhapKho = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }



        }

        private void Luu_ThamCHieuTinhXuatKho(int iiID_Xuatkhogapdan)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dtthamchieu = dv2232xx.ToTable();

                DataTable dt3_cu = new DataTable();
                clsGapDan_ThamChieuTinhXuatKho_Temp cls3 = new clsGapDan_ThamChieuTinhXuatKho_Temp();
               
                dt3_cu = cls3.SA_W_ID_XuatKho(iiID_Xuatkhogapdan);
                if (dt3_cu.Rows.Count > 0)
                {
                    cls3.Update_ALL_TonTai(iiID_Xuatkhogapdan,false);
                }

                for (int i = 0; i < dtthamchieu.Rows.Count; i++)
                {
                    cls3 = new clsGapDan_ThamChieuTinhXuatKho_Temp();

                    cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                    cls3.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                    int iID_NhapKhoGapDanxxx = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoGapDan"].ToString());
                    cls3.fSoLuongXuat = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongXuat"].ToString());
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    if (dtthamchieu.Rows[i]["DonGia"].ToString() == "")
                        cls3.fDonGia = 0;
                    else cls3.fDonGia = Convert.ToDouble(dtthamchieu.Rows[i]["DonGia"].ToString());

                    cls3.iID_DinhMuc_ToGapDan = Convert.ToInt32(dtthamchieu.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                    cls3.fSoLuongThanhPham_QuyDoi = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongThanhPham_QuyDoi"].ToString());
                    cls3.iID_NhapKhoGapDan= Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoGapDan"].ToString());
                    string expression;
                    expression = "ID_NhapKhoGapDan=" + iID_NhapKhoGapDanxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt3_cu.Select(expression);
                    if (foundRows.Length > 0)
                    {
                        cls3.iID_ThamChieu = Convert.ToInt32(foundRows[0]["ID_ThamChieu"].ToString());
                        cls3.Update();
                    }
                    else
                    {
                        cls3.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt3moi = new DataTable();
               
                DataTable dt3hhshss = cls3.SA_W_ID_XuatKho(iiID_Xuatkhogapdan);
                dt3hhshss.DefaultView.RowFilter = "TonTai=False";
                DataView dvdt3jjs = dt3hhshss.DefaultView;
                dt3moi = dvdt3jjs.ToTable();
                for (int i = 0; i < dt3moi.Rows.Count; i++)
                {
                    int IiID_ThamChieuyxxxx = Convert.ToInt32(dt3moi.Rows[i]["ID_ThamChieu"].ToString());
                    cls3.iID_ThamChieu = IiID_ThamChieuyxxxx;
                    cls3.Delete();
                }
                cls3.Dispose();
            }
        }

        private void Luu_ChiTiet_XuatKho_GapDan(int iiiID_xuatkhogapgan)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();
                DataTable dt2_cu = new DataTable();             
                dt2_cu = cls2.SA_ID_XuatKho(iiiID_xuatkhogapgan);
                if (dt2_cu.Rows.Count > 0)
                {                    
                    cls2.Update_ALL_tonTai(iiiID_xuatkhogapgan, false);
                }

                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());                   
                    cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                   
                    cls2.bDaXuatKho = true;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho TP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 1;
                    else if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 2;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 3;
                    else cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 0;

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
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();               
                dt2_moi11111 = cls2.SA_ID_XuatKho(iiiID_xuatkhogapgan);
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_ChiTietXuatKho = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }
                cls2.Dispose();
            }
        }
        private void Luu_XuatKho_GapDan_GuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                

                clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = 0;
                cls1.iID_VTHH_ThanhPham_QuyDoi = 0;
                cls1.fDonGia_ThanhPham_QuyDoi = 0;
                cls1.fSoLuongThanhPham_QuyDoi = 0;
                cls1.fTongTienHang = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = "";
                cls1.iID_DinhMuc_ToGapDan = 0;
                cls1.bTrangThaiNhapKhoBTP_ThanhPham = false;
                cls1.bCheckNhapKhoThanhPham = checkNhapKhoThanhPham.Checked;
                cls1.bDaXuatKho = true;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls1.bGuiDuLieu = true;
                int iiID_Nhapkho_GapDan;
                if (UCThanhPham_NhapKhoTu_GapDan.mbSua == false)
                {
                    cls1.Insert();
                    iiID_Nhapkho_GapDan = cls1.iID_XuatKho.Value;
                }
                else
                {
                    cls1.iID_XuatKho = UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho;
                    iiID_Nhapkho_GapDan = UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho;
                    cls1.Update();
                }
                Luu_ChiTiet_XuatKho_GapDan(iiID_Nhapkho_GapDan);
                Luu_ThamCHieuTinhXuatKho(iiID_Nhapkho_GapDan);

                if (checkNhapKhoThanhPham.Checked == true) //nhap kho thành pham
                {
                    Luu_NhapKhoThanhPham();
                    Luu_NhapKho_Khac_KhoNPL();
                    Luu_NhapKho_Khac_Kho_banThanhPham();

                }
                else
                {
                    Luu_NhapKho_Ban___________ThanhPham();
                    Luu_NhapKho_Khac_KhoNPL();
                    Luu_NhapKho_Khac_KhoThanhPham();
                }
            }

        }
        private void Luu_XuatKho_GapDan_ChiLuuu()
        {
            if (!KiemTraLuu()) return;
            else
            {
               
                clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = 0;
                cls1.iID_VTHH_ThanhPham_QuyDoi = 0;
                cls1.fDonGia_ThanhPham_QuyDoi = 0;
                cls1.fSoLuongThanhPham_QuyDoi = 0;
                cls1.fTongTienHang = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = "";
                cls1.iID_DinhMuc_ToGapDan = 0;
                cls1.bCheckNhapKhoThanhPham = checkNhapKhoThanhPham.Checked;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls1.bGuiDuLieu = false;
                cls1.bTrangThaiNhapKhoBTP_ThanhPham = false;
                cls1.bDaXuatKho = true;
                int iiID_Xuatkho_GapDan;
                if (UCThanhPham_NhapKhoTu_GapDan.mbSua == false)
                {
                    cls1.Insert();
                    iiID_Xuatkho_GapDan = cls1.iID_XuatKho.Value;
                }
                else
                {     
                    cls1.iID_XuatKho = UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho;
                    iiID_Xuatkho_GapDan = UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho;
                    cls1.Update();
                }
                Luu_ChiTiet_XuatKho_GapDan(iiID_Xuatkho_GapDan);
                Luu_ThamCHieuTinhXuatKho(iiID_Xuatkho_GapDan);
                MessageBox.Show("Đã lưu");
                this.Close();
            }

        }
        private void Luu_NhapKho_Ban___________ThanhPham()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl2.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongXuat)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                clsKhoBTP_tbNhapKho cls3 = new clsKhoBTP_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = soChungTu_Kho_BTP();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = 0;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.bCheck_NhapKho_Khac = false;
                cls3.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkho = cls3.iID_NhapKhoBTP.Value;
                clsKhoBTP_tbChiTietNhapKho cls5 = new clsKhoBTP_tbChiTietNhapKho();
                for (int i = 0; i < dtaaaaa.Rows.Count; i++)
                {
                    cls5.iID_NhapKho = iiDI_nhapkho;
                    cls5.iID_VTHH = Convert.ToInt32(dtaaaaa.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fSoLuongTon = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fDonGia = Convert.ToDouble(dtaaaaa.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;
                    cls5.bDaNhapKho = true;
                    cls5.bBoolTonDauKy = false;
                    cls5.sGhiChu = "";
                    cls5.Insert();
                }

                DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
                CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
                DataView dv222 = new DataView(DatatableABC222);
                dv222.RowFilter = filterString222;
                DataTable dt222 = dv222.ToTable();
                //NhapKho_TP_1_BTP_2_NPL_3
                string xx = "2";
                dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
                DataView dvxxx222 = dt222.DefaultView;
                DataTable mdtKhauTru = dvxxx222.ToTable();
                if (mdtKhauTru.Rows.Count > 0)
                {
                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        cls5.iID_NhapKho = iiDI_nhapkho;
                        cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                        cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        cls5.bTonTai = true;
                        cls5.bNgungTheoDoi = false;
                        cls5.bDaNhapKho = true;
                        cls5.bBoolTonDauKy = false;
                        cls5.sGhiChu = "";
                        cls5.Insert();
                    }
                }
            }

        }

        private void Luu_NhapKhoThanhPham()
        {

            if (!KiemTraLuu()) return;
            else
            {

                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl2.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongXuat)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;


                clsKhoThanhPham_tbNhapKho cls3 = new clsKhoThanhPham_tbNhapKho();
                cls3.sDienGiai = txtDienGiai.Text.ToString();
                cls3.sSoChungTu = soChungTu_KhoThanhPham();
                cls3.daNgayChungTu = dteNgayChungTu.DateTime;
                cls3.fTongTienHang = dexxTongtienhang;
                cls3.bTonTai = true;
                cls3.bNgungTheoDoi = false;
                cls3.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls3.sThamChieu = txtSoChungTu.Text.ToString();
                cls3.iID_DaiLy = 0;
                cls3.bDaNhapKho = true;
                cls3.bBool_TonDauKy = false;
                cls3.bCheck_NhapKho_Khac = false;
                cls3.sGhiChu = "";
                cls3.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                cls3.Insert();
                int iiDI_nhapkhothanhpham = cls3.iID_NhapKho_ThanhPham.Value;
                clsKhoThanhPham_tbChiTietNhapKho cls5 = new clsKhoThanhPham_tbChiTietNhapKho();
                for (int i = 0; i < dtaaaaa.Rows.Count; i++)
                {
                    cls5.iID_NhapKho_ThanhPham = iiDI_nhapkhothanhpham;
                    cls5.iID_VTHH = Convert.ToInt32(dtaaaaa.Rows[i]["ID_VTHH"].ToString());
                    cls5.fSoLuongNhap = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fSoLuongTon = Convert.ToDouble(dtaaaaa.Rows[i]["SoLuongXuat"].ToString());
                    cls5.fDonGia = Convert.ToDouble(dtaaaaa.Rows[i]["DonGia"].ToString());
                    cls5.bTonTai = true;
                    cls5.bNgungTheoDoi = false;
                    cls5.iID_DaiLy = 0;
                    cls5.bDaNhapKho = true;
                    cls5.bBool_TonDauKy = false;
                    cls5.sGhiChu = "";
                    cls5.Insert();
                }
                DataTable DatatableABC222 = (DataTable)gridControl1.DataSource;
                CriteriaOperator op222 = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
                DataView dv222 = new DataView(DatatableABC222);
                dv222.RowFilter = filterString222;
                DataTable dt222 = dv222.ToTable();
                //NhapKho_TP_1_BTP_2_NPL_3
                string xx = "1";
                dt222.DefaultView.RowFilter = "MaKho ='" + xx + "'";
                DataView dvxxx222 = dt222.DefaultView;
                DataTable mdtKhauTru = dvxxx222.ToTable();
                if (mdtKhauTru.Rows.Count > 0)
                {
                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        cls5.iID_NhapKho_ThanhPham = iiDI_nhapkhothanhpham;
                        cls5.iID_VTHH = Convert.ToInt32(mdtKhauTru.Rows[i]["ID_VTHH"].ToString());
                        cls5.fSoLuongNhap = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fSoLuongTon = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        cls5.fDonGia = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        cls5.bTonTai = true;
                        cls5.bNgungTheoDoi = false;
                        cls5.iID_DaiLy = 0;
                        cls5.bDaNhapKho = true;
                        cls5.bBool_TonDauKy = false;
                        cls5.sGhiChu = "";
                        cls5.Insert();
                    }
                }

            }
        }
      

        private DataTable tinhtoan(double soluongxuatxxx, int iiiID_Dinhmuc)
        {
            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls1 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            DataTable dt2 = cls1.SA_IDDM_W_SoLuong(soluongxuatxxx, iiiID_Dinhmuc);
            cls1.Dispose();
            return dt2;
           
        }
        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            gridControl1.DataSource = null;


            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH", typeof(string));
       
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));

            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));

            DataTable new_Table = new DataTable();

            string shienthi = "1";
            DataTable dtkkk = (DataTable)gridControl2.DataSource;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv2232xx = dtkkk.DefaultView;
            DataTable dt = dv2232xx.ToTable();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double soluongxuat = Convert.ToDouble(dt.Rows[i]["SoLuongXuat"].ToString());
                int _XXID_DinhMuc_ToGapDan = Convert.ToInt32(dt.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
              
                DataTable dtmnoi = tinhtoan(soluongxuat, _XXID_DinhMuc_ToGapDan);
                for (int j = 0; j < dtmnoi.Rows.Count; j++)
                {
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_VTHH"] = dtmnoi.Rows[j]["ID_VTHH"].ToString();                  
                    _ravi2["TenVTHH"] = dtmnoi.Rows[j]["TenVTHH"].ToString();
                    _ravi2["DonViTinh"] = dtmnoi.Rows[j]["DonViTinh"].ToString();
                    _ravi2["SoLuong"] =  Convert.ToDouble(dtmnoi.Rows[j]["SoLuong"].ToString());                   
                    _ravi2["HienThi"] = "1";
                    dt2.Rows.Add(_ravi2);
                }
            }


            new_Table.Columns.Add("ID_VTHH", typeof(string));
            new_Table.Columns.Add("MaVT", typeof(string));
            new_Table.Columns.Add("TenVTHH", typeof(string));
            new_Table.Columns.Add("DonViTinh", typeof(string));
            new_Table.Columns.Add("SoLuong", typeof(double));
            new_Table.Columns.Add("DonGia", typeof(double));
            new_Table.Columns.Add("GhiChu", typeof(string));
            new_Table.Columns.Add("HienThi", typeof(string));
            new_Table.Columns.Add("HienThi2", typeof(string));
            new_Table.Columns.Add("ThanhTien", typeof(double));
            new_Table.Columns.Add("NhapKho_TP_1_BTP_2_NPL_3", typeof(string));
            new_Table.Columns.Add("MaKho", typeof(string));
          

            var groupedByState = dt2.AsEnumerable()
                .GroupBy(r => r.Field<String>("ID_VTHH"));
            foreach (var group in groupedByState)
            {
                DataRow maxPremRow = group.OrderByDescending(r => r.Field<String>("ID_VTHH")).First();
                DataRow newRow = new_Table.Rows.Add();

                newRow.SetField("ID_VTHH", maxPremRow.Field<string>("ID_VTHH"));
                newRow.SetField("SoLuong", group.Sum(r => r.Field<double?>("SoLuong")));
                newRow.SetField("MaVT", maxPremRow.Field<string>("ID_VTHH"));
                newRow.SetField("TenVTHH", maxPremRow.Field<string>("TenVTHH"));
                newRow.SetField("DonViTinh", maxPremRow.Field<string>("DonViTinh"));
                newRow.SetField("GhiChu", "");
                newRow.SetField("DonGia", 0);
                newRow.SetField("ThanhTien", 0);
                newRow.SetField("HienThi", "1");
                newRow.SetField("HienThi2", "0");
                newRow.SetField("NhapKho_TP_1_BTP_2_NPL_3", "");
                newRow.SetField("MaKho", "");
               
            }
            gridControl1.DataSource = new_Table;
            Cursor.Current = Cursors.Default;
        }

   

        private void btXoa1_Click(object sender, EventArgs e)
        {
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi1, "0");
          //  gridView4.SetRowCellValue(gridView4.FocusedRowHandle, cl, 0);
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

        private void btXoaGrid2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi2, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong2, 0);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            Luu_XuatKho_GapDan_ChiLuuu();
            Cursor.Current = Cursors.Default;
        }

        private void checkNhapKhoThanhPham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapKhoThanhPham.Checked == true)
                checkNhapKho_banThanhPham.Checked = false;
        }

        private void checkNhapKho_banThanhPham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapKho_banThanhPham.Checked == true)
                checkNhapKhoThanhPham.Checked = false;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH2).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_VTHH2)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                  
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clDonGia2, 0);


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
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia2));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);
                }
                if (e.Column == clDonGia2)
                {
                    if (gridView1.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia2));
                    if (gridView1.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);

                }
            }
            catch
            {

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

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!KiemTraLuu()) return;
            else
            {
                Luu_XuatKho_GapDan_GuDuLieu();
               
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Đã lưu và gửi dữ liệu");
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        
        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clID_NhapKho)
            {
                clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
                int iiiiID_NhapKho = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SO(iiiiID_NhapKho);
                gridView4.SetRowCellValue(e.RowHandle, clID_VTHH1, dt.Rows[0]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH1, dt.Rows[0]["TenVTHH"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh1, dt.Rows[0]["DonViTinh"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clMaVT2221, dt.Rows[0]["MaVT"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongThanhPhamQuyDoi1, dt.Rows[0]["SoLuongThanhPham_QuyDoi"].ToString());               
                gridView4.SetRowCellValue(e.RowHandle, clDonGia1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clThanhTien1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, dt.Rows[0]["SoLuongThanhPham_QuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clID_DinhMuc_ToGapDan, dt.Rows[0]["ID_DinhMuc_ToGapDan"].ToString());
            }
            try
            {
                if (e.Column == clSoLuongNhap1)
                {
                    double soluongthanhphamquydoi = 0;
                    double soluongnhapthucte = 0;
                    soluongthanhphamquydoi = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongThanhPhamQuyDoi1));
                    soluongnhapthucte = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    double tile = soluongnhapthucte / soluongthanhphamquydoi;
                    if (tile > 1)
                    {
                        MessageBox.Show("Số lượng xuất không lớn hơn số lượng nhập");
                        gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, 0);
                        return;
                    }
                    else
                    {
                        gridView4.SetFocusedRowCellValue(clTiLe1, tile);
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                        fffthanhtien = fffsoluong * ffdongia;
                        gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);
                    }

                }
                if (e.Column == clDonGia1)
                {
                    ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                    fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);
                }
            }
            catch
            {

            }
        }

      
        private void gridMaHang_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void gridMaHang_Popup(object sender, EventArgs e)
        {
           
        }

        private void dteTuNgay_EditValueChanged_1(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                Load_LockUp_MaHang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                Load_LockUp_MaHang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView4_CustomRowFilter_1(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
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
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi1, "0");
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuongNhap1, 0);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv = new DataView(DatatableABC);
            dv.RowFilter = filterString;
            DataTable dt = dv.ToTable();
            string shienthi = "1";
            dt.DefaultView.RowFilter = "HienThi='" + shienthi + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable mdtPrint_Cu = dvxxx.ToTable();

            mdtPrint = new DataTable();
            mdtPrint.Columns.Add("ID_VTHH", typeof(string));
            mdtPrint.Columns.Add("MaVT", typeof(string));
            mdtPrint.Columns.Add("TenVTHH", typeof(string));
            mdtPrint.Columns.Add("DonViTinh", typeof(string));
            mdtPrint.Columns.Add("SoLuongNhap", typeof(double));
            mdtPrint.Columns.Add("DonGia", typeof(double));
            mdtPrint.Columns.Add("ThanhTien", typeof(double));

            DataTable DatatableABC222 = (DataTable)gridControl2.DataSource;
            CriteriaOperator op222 = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString222 = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op222);
            DataView dv222 = new DataView(DatatableABC222);
            dv222.RowFilter = filterString222;
            DataTable dt222 = dv222.ToTable();
            string xx = "1";
            dt222.DefaultView.RowFilter = "HienThi2 ='" + xx + "'";
            DataView dvxxx222 = dt222.DefaultView;
            DataTable mdtKhauTru = dvxxx222.ToTable();


            if (mdtPrint_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < mdtPrint_Cu.Rows.Count; i++)
                {
                    DataRow _ravi3 = mdtPrint.NewRow();
                    _ravi3["ID_VTHH"] = mdtPrint_Cu.Rows[i]["ID_VTHH"].ToString();
                    _ravi3["MaVT"] = mdtPrint_Cu.Rows[i]["MaVT"].ToString();
                    _ravi3["TenVTHH"] = mdtPrint_Cu.Rows[i]["TenVTHH"].ToString();
                    _ravi3["DonViTinh"] = mdtPrint_Cu.Rows[i]["DonViTinh"].ToString();
                    _ravi3["SoLuongNhap"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["SoLuongNhap"].ToString());
                    _ravi3["DonGia"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["DonGia"].ToString());
                    _ravi3["ThanhTien"] = Convert.ToDouble(mdtPrint_Cu.Rows[i]["ThanhTien"].ToString());
                    mdtPrint.Rows.Add(_ravi3);
                }
                if (mdtKhauTru.Rows.Count > 0)
                {
                    for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
                    {
                        DataRow _ravi3 = mdtPrint.NewRow();
                        _ravi3["ID_VTHH"] = mdtKhauTru.Rows[i]["ID_VTHH"].ToString();
                        _ravi3["MaVT"] = mdtKhauTru.Rows[i]["MaVT"].ToString();
                        _ravi3["TenVTHH"] = mdtKhauTru.Rows[i]["TenVTHH"].ToString();
                        _ravi3["DonViTinh"] = mdtKhauTru.Rows[i]["DonViTinh"].ToString();
                        _ravi3["SoLuongNhap"] = Convert.ToDouble(mdtKhauTru.Rows[i]["SoLuong"].ToString());
                        _ravi3["DonGia"] = Convert.ToDouble(mdtKhauTru.Rows[i]["DonGia"].ToString());
                        _ravi3["ThanhTien"] = Convert.ToDouble(mdtKhauTru.Rows[i]["ThanhTien"].ToString());
                        mdtPrint.Rows.Add(_ravi3);
                    }
                }

                //int IID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                //clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                //cls.iID_DaiLy = IID_DaiLy;
                //DataTable dxckksd = cls.SelectOne();
                //msDiaChi = cls.sDiaChi.Value;
                //msSoDienThoai = cls.sSoDienThoai.Value;
                //msTenDaiLy = cls.sTenDaiLy.Value;
                msDienGiai = txtDienGiai.Text.ToString();
                msSoChungTu = txtSoChungTu.Text.ToString();
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                //msGhiChu = txtGhiChu.Text.ToString();
                mbPrint = true;
                frmPrint_nhapKho_DaiLy ff = new frmPrint_nhapKho_DaiLy();
                ff.ShowDialog();
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

      
        public KhoThanhPham_NhapKho_TuGapDan()
        {
            InitializeComponent();
        }

        private void KhoThanhPham_NhapKho_TuGapDan_Load(object sender, EventArgs e)
        {          
            Cursor.Current = Cursors.WaitCursor;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            dteDenNgay.EditValue = DateTime.Today;
            clSoLuongNhap1.Caption = "SL \n Nhập";
             Load_LockUp();
            if (UCThanhPham_NhapKhoTu_GapDan.mbThemMoi == true)
                HienThi_ThemMoi_XuatKho();
            else if (UCThanhPham_NhapKhoTu_GapDan.mbCopy == true)
                HienThi_Copy(UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho);
            else HienThi_Sua_XuatKho(UCThanhPham_NhapKhoTu_GapDan.miID_XuatKho);
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
