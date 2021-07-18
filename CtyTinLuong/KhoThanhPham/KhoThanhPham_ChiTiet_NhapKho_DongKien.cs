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
    public partial class KhoThanhPham_ChiTiet_NhapKho_DongKien : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai, msGhiChu;
        public static double mdbTongSotien;

        private string SoCHungTu_NhapKhoThanhPham()
        {
            string sochungtu;
            clsKhoThanhPham_tbNhapKho cls = new clsKhoThanhPham_tbNhapKho();
            DataTable dt1 = cls.SelectAll();

            int k2 = dt1.Rows.Count;
            if (k2 == 0)
                sochungtu = "NKTP 1";
            else
            {
                string xxx = dt1.Rows[k2 - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                if (xxx2 >= 10000)
                    sochungtu = "NKTP 1";
                else sochungtu = "NKTP " + xxx2 + "";

            }
            cls.Dispose();
            dt1.Dispose();
            return sochungtu;
        }
        private void HienThi_Sua()
        {
            clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
            cls1.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
            DataTable dt = cls1.SelectOne();
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtGhiChu.Text = cls1.sGhiChu.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;
           

            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_DongKien.miID_NhapKho;
            DataTable dtxx = cls2.Select_ALL_W_ID_NhapKho_ThanhPham();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuongNhap", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dtxx.Rows.Count; i++)
            {
                double dongiaxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["DonGia"].ToString());
                double SoLuongxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["SoLuongNhap"].ToString());
                int ID_VTHHxxx = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = ID_VTHHxxx;
                DataTable dtvt = clsvt.SelectOne();
                DataRow _ravi3 = dt2.NewRow();

                _ravi3["ID_VTHH"] = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                _ravi3["MaVT"] = ID_VTHHxxx;
                _ravi3["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clsvt.sDonViTinh.Value;
                _ravi3["SoLuongNhap"] = SoLuongxxx333;
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtxx.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuongxxx333 * dongiaxxx333;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
            double deTOngtien;
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;
            txtSoChungTu.Text = SoCHungTu_NhapKhoThanhPham();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKhoDongKien", typeof(string));
            dt2.Columns.Add("SoLuongThanhPham_QuyDoi", typeof(string));
            dt2.Columns.Add("SoLuongTon_SauKhiNhapKhoThanhPham", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuongNhap", typeof(string));        
            dt2.Columns.Add("DonGia", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            gridControl1.DataSource = dt2;
        }

        private void KhoThanhPham_ChiTiet_NhapKho_DongKien_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = DateTime.Today.AddDays(-30);
            Load_LockUp();
            if (UCThanhPham_NhapKho_DongKien.mbThemMoi_NhapKho == true)
                HienThi_ThemMoi();
            else HienThi_Sua();
            Cursor.Current = Cursors.Default;
        }

        private void Load_LockUp_ThamChieu(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbNhapKho cls = new clsDongKien_TbNhapKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridThamChieu.DataSource = dt;
            gridThamChieu.ValueMember = "ID_NhapKhoDongKien";
            gridThamChieu.DisplayMember = "SoChungTu";
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue !=null)
                Load_LockUp_ThamChieu(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double dongia = 0, soluong = 0, thanhtien = 0;
            if (e.Column == clID_NhapKhoDongKien1)
            {
                int xxIDkk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                clsDongKien_TbNhapKho cls = new clsDongKien_TbNhapKho();           
                DataTable dt = cls.SO_ID(xxIDkk);             
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH1, dt.Rows[0]["TenVTHH"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh1, dt.Rows[0]["DonViTinh"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clMaVT1, dt.Rows[0]["MaVT"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongThanhPhamQuyDoi1, dt.Rows[0]["SoLuongThanhPham_QuyDoi"].ToString());
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongTon_SauKhiNhapKhoThanhPham, dt.Rows[0]["SoLuongTon_SauKhiNhapKhoThanhPham"].ToString());

                gridView4.SetRowCellValue(e.RowHandle, clHienThi1, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoLuongNhap1, 0);
                gridView4.SetRowCellValue(e.RowHandle, clDonGia1, 0);

                dongia = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clDonGia1));
                soluong = CheckString.ConvertToDouble_My(gridView4.GetFocusedRowCellValue(clSoLuongNhap1));
                thanhtien = soluong * dongia;
                gridView4.SetFocusedRowCellValue(clThanhTien1, thanhtien);

            }
        }

        private void Load_LockUp()
        {
           



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dt = clsNguoi.T_SelectAll(5);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";



        }
        public KhoThanhPham_ChiTiet_NhapKho_DongKien()
        {
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
