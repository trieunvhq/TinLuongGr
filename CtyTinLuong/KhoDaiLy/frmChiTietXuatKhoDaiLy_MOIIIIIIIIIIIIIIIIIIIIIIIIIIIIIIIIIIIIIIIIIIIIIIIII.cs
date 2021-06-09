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
    public partial class frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII : Form
    {

        public static bool mbThemMoi_XuatKhohoDaiLy, mbCopy, mbSua;
        public static int miID_XuatKhoDaiLy;
        public static bool mbPrint;
        public static DataTable mdtPrint;
        public static DateTime mdaNgayChungTu;
        public static string msDiaChi, msSoDienThoai, msDienGiai, msTenDaiLy, msSoChungTu, msGhiChu;
        public static string msdvtthanhphamquydoi, msMaThanhPham, msTenThanhPham;
        public static double mfPrint_soluongtpqiuydoi;

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
        private void Luu_themMoi_DuLieubangLuong()
        {

            if (!KiemTraLuu()) return ;
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

               
            }
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
        private void HienThi_Sua_XuatKho()
        {
            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
            cls1.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
            DataTable dt = cls1.SelectOne();
            if (cls1.bCheck_BaoVe.Value == true)
                checkBaoVe.Checked = true;
            else checkBaoVe.Checked = false;
            if (cls1.bCheck_LaiXe.Value == true)
                checkLaiXe.Checked = true;
            else checkLaiXe.Checked = false;
            if (cls1.bCheck_DaiLy.Value == true)
                checkDaiLy.Checked = true;
            else checkDaiLy.Checked = false;

          

            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value.ToString();
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            txtGhiChu.Text = cls1.sGhiChu.Value;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            dt2.Columns.Add("ID_ThamChieu", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(double));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("TiLe", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));

            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            clsDaiLy_ThamChieu_TinhXuatKho cls2 = new clsDaiLy_ThamChieu_TinhXuatKho();
            cls2.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
            DataTable dt222 = cls2.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
            for (int i = 0; i < dt222.Rows.Count; i++)
            {

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_ThamChieu"] = Convert.ToInt32(dt222.Rows[i]["ID_ThamChieu"].ToString());
                _ravi3["ID_NhapKhoDaiLy"] = Convert.ToInt32(dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                _ravi3["ID_VTHH"] = Convert.ToInt32(dt222.Rows[i]["ID_VTHH"].ToString());
                _ravi3["SoChungTu"] = dt222.Rows[i]["ID_NhapKhoDaiLy"].ToString();
                _ravi3["MaVT"] = dt222.Rows[i]["MaVT"].ToString();
                _ravi3["TenVTHH"] = dt222.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dt222.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuongNhap"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuongThanhPhamQuyDoi"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["DonGia"] = Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";
                _ravi3["TiLe"] = Convert.ToDouble(dt222.Rows[i]["SoLuongNhap"].ToString()) / Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["ThanhTien"] = Convert.ToDouble(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString()) * Convert.ToDouble(dt222.Rows[i]["DonGia"].ToString());

                dt2.Rows.Add(_ravi3);

            }

            gridControl1.DataSource = dt2;
            clsDaiLy_tbChiTietXuatKho cls = new clsDaiLy_tbChiTietXuatKho();
            cls.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
            DataTable dtxx = cls.SelectAll_W_ID_XuatKhoDaiLy();

            DataTable dt3 = new DataTable();
            //ID_ChiTietXuatKho_DaiLy
            dt3.Columns.Add("ID_ChiTietXuatKho_DaiLy", typeof(int));
            dt3.Columns.Add("ID_VTHH", typeof(int));
            dt3.Columns.Add("MaVT", typeof(string));
            dt3.Columns.Add("TenVTHH", typeof(string));
            dt3.Columns.Add("DonViTinh", typeof(string));
            dt3.Columns.Add("SoLuong", typeof(double));
            dt3.Columns.Add("DonGia", typeof(double));
            dt3.Columns.Add("GhiChu", typeof(string));
            dt3.Columns.Add("HienThi", typeof(string));
            dt3.Columns.Add("ThanhTien", typeof(double));
            dt3.Columns.Add("NhapKho_TP_1_BTP_2_NPL_3", typeof(string));
            dt3.Columns.Add("HienThi2", typeof(string));
            for (int i = 0; i < dtxx.Rows.Count; i++)
            {
                DataRow _ravi3 = dt3.NewRow();
                _ravi3["ID_ChiTietXuatKho_DaiLy"] = Convert.ToInt32(dtxx.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                _ravi3["ID_VTHH"] = Convert.ToInt32(dtxx.Rows[i]["ID_VTHH"].ToString());
                _ravi3["MaVT"] = dtxx.Rows[i]["ID_VTHH"].ToString();
                _ravi3["TenVTHH"] = dtxx.Rows[i]["TenVTHH"].ToString();
                _ravi3["DonViTinh"] = dtxx.Rows[i]["DonViTinh"].ToString();
                _ravi3["SoLuong"] = Convert.ToDouble(dtxx.Rows[i]["SoLuongXuat"].ToString());
                _ravi3["DonGia"] = Convert.ToDouble(dtxx.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";

                _ravi3["ThanhTien"] = Convert.ToDouble(dtxx.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(dtxx.Rows[i]["DonGia"].ToString());
                _ravi3["GhiChu"] = dtxx.Rows[i]["GhiChu"].ToString();
                if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "1")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho TP";
                    _ravi3["HienThi2"] = "1";
                }
                else if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "2")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho BTP";
                    _ravi3["HienThi2"] = "1";
                }
                else if (dtxx.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "3")
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "Kho NPL";
                    _ravi3["HienThi2"] = "1";
                }
                else
                {
                    _ravi3["NhapKho_TP_1_BTP_2_NPL_3"] = "";
                    _ravi3["HienThi2"] = "0";
                }
                dt3.Rows.Add(_ravi3);

            }
            gridControl2.DataSource = dt3;

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
                clsDaiLy_tbNhapKho clsvattu = new clsDaiLy_tbNhapKho();
                clsvattu.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dtvattu = clsvattu.SelectAll_W_ID_DaiLy_hienThiLockUp();
                //dtvattu.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False ";
                dtvattu.DefaultView.RowFilter = " HoanThanh = False";
                DataView dvvattu = dtvattu.DefaultView;
                DataTable newdtvattu = dvvattu.ToTable();
                gridMaHang.DataSource = newdtvattu;
                gridMaHang.ValueMember = "ID_NhapKhoDaiLy";
                gridMaHang.DisplayMember = "SoChungTu";

            }
            catch
            {

            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            Luu_Va_GuiDuLieu();
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

      

        private void btXoaGrid2_Click(object sender, EventArgs e)
        {
            gridView2.SetFocusedRowCellValue(clHienThi2, "0");
        }

        private void gridView2_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
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

                int IID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.iID_DaiLy = IID_DaiLy;
                DataTable dxckksd = cls.SelectOne();
                msDiaChi = cls.sDiaChi.Value;
                msSoDienThoai = cls.sSoDienThoai.Value;
                msTenDaiLy = cls.sTenDaiLy.Value;
                msDienGiai = txtDienGiai.Text.ToString();
                msSoChungTu = txtSoChungTu.Text.ToString();
                mdaNgayChungTu = dteNgayChungTu.DateTime;
                msGhiChu = txtGhiChu.Text.ToString();
                mbPrint = true;
                frmPrint_nhapKho_DaiLy ff = new frmPrint_nhapKho_DaiLy();
                ff.Show();
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clSoChungTu1)
            {
                clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                cls.iID_NhapKhoDaiLy = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int iiiiID_NhapKhoDaiLy = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                int iiiID_ThanhPham = Convert.ToInt32(dt.Rows[0]["ID_VTHH_TPQuyDoi"].ToString());
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiiID_ThanhPham;
                DataTable dtvt = clsvt.SelectOne();

                DataTable dt2 = cls.SelectOne_W_ID_VTHH_TPQuyDoi();
                gridView4.SetRowCellValue(e.RowHandle, clID_NhapKhoDaiLy1, iiiiID_NhapKhoDaiLy);
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH1, clsvt.sTenVTHH.Value);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh1, clsvt.sDonViTinh.Value);
                gridView4.SetRowCellValue(e.RowHandle, clMaVT2221, clsvt.sMaVT.Value);
                gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongThanhPhamQuyDoi1, dt.Rows[0]["SoLuongThanhPhamQuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clDonGia1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clThanhTien1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clID_VTHH1, iiiID_ThanhPham);


            }
            try
            {
                if (e.Column == clSoLuongNhap1)
                {
                    double soluongthanhphamquydoi = 0;
                    double soluongnhapthucte = 0;
                    if (gridView4.GetFocusedRowCellValue(clSoLuongThanhPhamQuyDoi1).ToString() == "")
                        soluongthanhphamquydoi = 1;
                    else
                        soluongthanhphamquydoi = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongThanhPhamQuyDoi1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        soluongnhapthucte = 0;
                    else
                        soluongnhapthucte = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    double tile = soluongnhapthucte / soluongthanhphamquydoi;
                    //  gridView4.SetRowCellValue(e.RowHandle, clTiLe, tile);
                    gridView4.SetFocusedRowCellValue(clTiLe1, tile);

                    if (gridView4.GetFocusedRowCellValue(clDonGia1).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);
                }
                if (e.Column == clDonGia1)
                {
                    if (gridView4.GetFocusedRowCellValue(clDonGia1).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia1));
                    if (gridView4.GetFocusedRowCellValue(clSoLuongNhap1).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien1, fffthanhtien);

                }
            }
            catch
            {

            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
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

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView2.SetFocusedRowCellValue(clHienThi1, "0");
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT2)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView2.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView2.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView2.SetRowCellValue(e.RowHandle, clID_VTHH2, kk);
                    gridView2.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
                    gridView2.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
                    gridView2.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                    gridView2.SetRowCellValue(e.RowHandle, clSoLuong2, 0);
                    gridView2.SetRowCellValue(e.RowHandle, clDonGia2, 0);


                }
            }

            if (e.Column == clNhapKho_TP_1_BTP_2_NPL_3_22222)
            {
                if (gridView2.GetFocusedRowCellValue(clNhapKho_TP_1_BTP_2_NPL_3_22222).ToString() != "")
                    gridView2.SetRowCellValue(e.RowHandle, clHienThi2222, "1");
            }

            
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == clSoLuong2)
                {

                    if (gridView2.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clDonGia2));
                    if (gridView2.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    fffsoluong = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView2.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);
                }
                if (e.Column == clDonGia2)
                {
                    if (gridView2.GetFocusedRowCellValue(clDonGia2).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clDonGia2));
                    if (gridView2.GetFocusedRowCellValue(clSoLuong2).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView2.GetFocusedRowCellValue(clSoLuong2));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView2.SetFocusedRowCellValue(clThanhTien2, fffthanhtien);

                }
            
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBaoVe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBaoVe.Checked == true)
                {
                    clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                    int iiID_Xuatkho;
                    iiID_Xuatkho = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_BaoVe();
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    cls1.Update_TrangThai_DaXuatkho();
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
                if (checkLaiXe.Checked == true)
                {
                    clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                    int iiID_Xuatkho;
                    iiID_Xuatkho = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_LaiXe();

                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    cls1.Update_TrangThai_DaXuatkho();

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
                if (checkLaiXe.Checked == true)
                {
                    clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                    int iiID_Xuatkho;
                    iiID_Xuatkho = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    DataTable dt = cls1.SelectOne();
                    cls1.Update_TrangThai_W_DaiLy_Duoc_GiaoHang();

                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    cls1.Update_TrangThai_DaXuatkho();

                    MessageBox.Show("Đại lý đã giao hàng");
                }
            }
            catch
            {

            }
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



            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
            DataTable dtdaily = clsdaily.SelectAll();
            dtdaily.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dtdaily.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            gridMaVT.DataSource = dtxx2;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }
        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            DataTable dv4 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }
            if (gridControl2.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl2.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv4 = dv.ToTable();
            }
            if (dv3.Rows.Count == 0 || dv4.Rows.Count == 0)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }

            else if (gridMaDaiLy.EditValue == null)
            {
                MessageBox.Show("chưa chọn đại lý");
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

        private void Luu_NhapKho_Khac(int iiiiID_XuatKhoDaiLy)
        {
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
            for(int i=0; i<mdtKhauTru.Rows.Count; i++)
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
                    cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls3.bDaNhapKho = true;
                    cls3.bBool_TonDauKy = false;
                    cls3.bCheck_NhapKho_Khac = true;
                    cls3.sGhiChu = txtGhiChu.Text.ToString();
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
                else if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
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
                else if (mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
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
        private void Luu_ChiTietNhapKho_thanhpham(int iiIDINhapKho)
        {

            string shienthi = "1";

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dvmoi.ToTable();

            clsKhoThanhPham_tbChiTietNhapKho cls = new clsKhoThanhPham_tbChiTietNhapKho();
            cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
            DataTable dt2_Cu = cls.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_tontai_W_ID_NhapKhoTP();
                }
            }
            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {


                int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_NhapKho_ThanhPham = iiIDINhapKho;
                if (dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString() != "")
                {
                    cls.fSoLuongNhap = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
                    cls.fSoLuongTon = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuongNhap"].ToString());
                }
                else
                {
                    cls.fSoLuongNhap = 0;
                    cls.fSoLuongTon = 0;
                }
                if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                    cls.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                else cls.fDonGia = 0;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                cls.bDaNhapKho = true;
                cls.bBool_TonDauKy = false;

                string expressionnhapkho;
                expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_Cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    cls.iID_ChiTietNhapKho_ThanhPham = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho_ThanhPham"].ToString());
                    cls.Update();
                }
                else
                {
                    cls.Insert();
                }

            }
            // xoa ton tai=false
            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho_ThanhPham = iiIDINhapKho;
            dt2_moi11111 = cls2.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho_ThanhPham"].ToString());
                cls2.iID_ChiTietNhapKho_ThanhPham = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
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
            for (int i = 0; i < mdtKhauTru.Rows.Count; i++)
            {
               if(mdtKhauTru.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
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
        private void Luu_ChiTiet_XuatKho_DaiLy(int iiiiID_XuatKhoDaiLy, bool bdaxuatkho)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt2_cu = cls2.SelectAll_W_ID_XuatKhoDaiLy();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        int ID_ChiTietXuatKho_DaiLyxxxx = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                        cls2.iID_ChiTietXuatKho_DaiLy = ID_ChiTietXuatKho_DaiLyxxxx;
                        cls2.bTonTai = false;
                        cls2.Update_W_TonTai();
                    }

                }
                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                    cls2.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaXuatKho = bdaxuatkho;
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
                        cls2.iID_ChiTietXuatKho_DaiLy = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho_DaiLy"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                    try
                    {
                        if(bdaxuatkho==true)
                        {
                            // update soluongton
                            clsDaiLy_tbChiTietNhapKho clschitietnhapkho = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
                            clschitietnhapkho.iID_DaiLy = Convert.ToInt16(gridMaDaiLy.EditValue.ToString());
                            clschitietnhapkho.iID_VTHH = ID_VTHHxxx;
                            DataTable dt2xxx = clschitietnhapkho.SelectOne_w_ID_VTHH_W_ID_DaiLy();
                            if (dt2xxx.Rows.Count > 0)
                            {
                                double soluongxuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                                Double douSoLuongTonCu;
                                douSoLuongTonCu = Convert.ToDouble(dt2xxx.Rows[0]["SoLuongTon"].ToString());
                                clschitietnhapkho.iID_ChiTietNhapKho_DaiLy = Convert.ToInt16(dt2xxx.Rows[0]["ID_ChiTietNhapKho_DaiLy"].ToString());
                                clschitietnhapkho.fSoLuongTon = douSoLuongTonCu - soluongxuat;
                                clschitietnhapkho.Update_SoLuongTon();
                            }
                        }
                       
                    }
                    catch
                    {

                    }
                   
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt2_moi11111 = cls2.SelectAll_W_ID_XuatKhoDaiLy();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietXuatKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho_DaiLy"].ToString());
                    cls2.iID_ChiTietXuatKho_DaiLy = ID_ChiTietXuatKho_DaiLyxxxx;
                    cls2.Delete();
                }


            }
        }

        private void Luu_ThamCHieuTinhXuatKho(int iiiiID_XuatKhoDaiLy)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dtthamchieu = dv2232xx.ToTable();

                clsDaiLy_ThamChieu_TinhXuatKho cls3 = new clsDaiLy_ThamChieu_TinhXuatKho();
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                DataTable dt3_cu = new DataTable();
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                dt3_cu = cls3.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
                if (dt3_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt3_cu.Rows.Count; i++)
                    {

                        cls3.iID_ThamChieu = Convert.ToInt32(dt3_cu.Rows[i]["ID_ThamChieu"].ToString());
                        cls3.bTonTai = false;
                        cls3.Update_W_TonTai();
                    }
                }

                for (int i = 0; i < dtthamchieu.Rows.Count; i++)
                {
                    int xxiID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls3.iID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls3.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                    cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                    cls3.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH"].ToString());
                    cls3.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                    cls3.fSoLuongNhap = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongNhap"].ToString());
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    if (dtthamchieu.Rows[i]["DonGia"].ToString() == "")
                        cls3.fDonGia = 0;
                    else cls3.fDonGia = Convert.ToDouble(dtthamchieu.Rows[i]["DonGia"].ToString());


                    string expression;
                    expression = "ID_NhapKhoDaiLy=" + xxiID_NhapKhoDaiLy + "";
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
                cls3.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                DataTable dt3hhshss = cls3.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT();
                dt3hhshss.DefaultView.RowFilter = "TonTai=False";
                DataView dvdt3jjs = dt3hhshss.DefaultView;
                dt3moi = dvdt3jjs.ToTable();
                for (int i = 0; i < dt3moi.Rows.Count; i++)
                {
                    int IiID_ThamChieuyxxxx = Convert.ToInt32(dt3moi.Rows[i]["ID_ThamChieu"].ToString());
                    cls3.iID_ThamChieu = IiID_ThamChieuyxxxx;
                    cls3.Delete();
                }
            }
        }
        private void Luu_ChiLuu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                int iiID_Xuatkho = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                bool Check_BaoVe, Check_LaiXe, Check_DaiLy, DaXuatKho, checkNhapKhoThanhPham;
                clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                cls1.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                DataTable dt = cls1.SelectOne();
                Check_BaoVe = cls1.bCheck_BaoVe.Value;
                Check_LaiXe = cls1.bCheck_LaiXe.Value;
                Check_DaiLy = cls1.bCheck_DaiLy.Value;
                DaXuatKho = cls1.bDaXuatKho.Value;
                checkNhapKhoThanhPham = cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False.Value;
                if (cls1.bCheck_BaoVe.Value == true & cls1.bCheck_DaiLy.Value == true & cls1.bCheck_LaiXe.Value == true)
                {
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    cls1.Update_TrangThai_DaXuatkho();
                }


                string ahienthi = "1";
                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl1.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongNhap)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                int xxxxxiiiiID_XuatKhoDaiLy;
               
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_VTHH = 0;
                cls1.fSoLuongXuat_BaoTo = 0;
                cls1.fSoLuongXuat_BaoBe = 0;
                cls1.fSoLuongThanhPhamQuyDoi = dexxTongSoLuong;
                if (dexxTongSoLuong != 0)
                    cls1.fDonGia = dexxTongtienhang / dexxTongSoLuong;
                else cls1.fDonGia = 0;
                cls1.fTongTienHang = dexxTongtienhang;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_DinhMucDot_BaoTo = 0;
                cls1.iID_DinhMucDot_BaoBe = 0;
                cls1.iID_DinhMucNguenPhuLieu = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());                
                cls1.bCheck_BaoVe = Check_BaoVe;
                cls1.bCheck_DaiLy = Check_DaiLy;
                cls1.bCheck_LaiXe = Check_LaiXe;
                cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = true;
                cls1.bTrangThai_XuatKho_DaiLy_GuiDuLieu = false;
                cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = checkNhapKhoThanhPham;                
                cls1.bDaXuatKho = false;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_ThamChieuNhapKho = 0;
                cls1.iHangDoT_1_hangNhu_2_ConLai3 = 1;

                cls1.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                cls1.Update();
                xxxxxiiiiID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;

                Luu_ChiTiet_XuatKho_DaiLy(xxxxxiiiiID_XuatKhoDaiLy,false);
                Luu_ThamCHieuTinhXuatKho(xxxxxiiiiID_XuatKhoDaiLy);
                MessageBox.Show("Đã lưu");
            }
        }
        private void Luu_Va_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                int iiID_Xuatkho = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                bool Check_BaoVe, Check_LaiXe, Check_DaiLy, DaXuatKho, checkNhapKhoThanhPham;
                clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();
                cls1.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                DataTable dt = cls1.SelectOne();
                Check_BaoVe = cls1.bCheck_BaoVe.Value;
                Check_LaiXe = cls1.bCheck_LaiXe.Value;
                Check_DaiLy = cls1.bCheck_DaiLy.Value;
                DaXuatKho = cls1.bDaXuatKho.Value;
                checkNhapKhoThanhPham = cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False.Value;
                if (cls1.bCheck_BaoVe.Value == true & cls1.bCheck_DaiLy.Value == true & cls1.bCheck_LaiXe.Value == true)
                {
                    cls1.iID_XuatKhoDaiLy = iiID_Xuatkho;
                    cls1.Update_TrangThai_DaXuatkho();
                }

                int iiiiID_XuatKhoDaiLy;
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl1.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongNhap)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;
                
               
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_VTHH = 0;
                cls1.fSoLuongXuat_BaoTo = 0;
                cls1.fSoLuongXuat_BaoBe = 0;
                cls1.fSoLuongThanhPhamQuyDoi = dexxTongSoLuong;
                if (dexxTongSoLuong != 0)
                    cls1.fDonGia = dexxTongtienhang / dexxTongSoLuong;
                else cls1.fDonGia = 0;
                cls1.fTongTienHang = dexxTongtienhang;
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_DinhMucDot_BaoTo = 0;
                cls1.iID_DinhMucDot_BaoBe = 0;
                cls1.iID_DinhMucNguenPhuLieu = 0;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                cls1.bCheck_BaoVe = Check_BaoVe;
                cls1.bCheck_DaiLy = Check_DaiLy;
                cls1.bCheck_LaiXe = Check_LaiXe;
                cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = true;
                cls1.bTrangThai_XuatKho_DaiLy_GuiDuLieu = true;
                cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = checkNhapKhoThanhPham;
                cls1.bDaXuatKho = true;
                cls1.sGhiChu = txtGhiChu.Text.ToString();
                cls1.iID_ThamChieuNhapKho = 0;
                cls1.iID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                cls1.Update();
                iiiiID_XuatKhoDaiLy = UCDaiLy_XuatKho.miID_XuatKhoDaiLy;
                // chi tiet nhập kho

                Luu_themMoi_DuLieubangLuong();
                Luu_ChiTiet_XuatKho_DaiLy(iiiiID_XuatKhoDaiLy, true);
                Luu_ThamCHieuTinhXuatKho(iiiiID_XuatKhoDaiLy);
                Luu_NhapKho_Khac(iiiiID_XuatKhoDaiLy);
                    MessageBox.Show("Đã lưu và gửi");

            }
        }
        public frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII()
        {
            InitializeComponent();
        }

        private void frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII_Load(object sender, EventArgs e)
        {
            clSoLuongNhap1.Caption = "Số lượng \n nhập";            

            Load_LockUp();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDaiLy", typeof(int));
            dt2.Columns.Add("ID_ThamChieu", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("SoLuongNhap", typeof(double));
            dt2.Columns.Add("SoLuongThanhPhamQuyDoi", typeof(double));
            dt2.Columns.Add("TiLe", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            gridControl1.DataSource = dt2;
            HienThi_Sua_XuatKho();

        }
    }
}
