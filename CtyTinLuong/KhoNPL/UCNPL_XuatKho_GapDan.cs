using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace CtyTinLuong
{
    public partial class UCNPL_XuatKho_GapDan : UserControl
    {
        public static int miiID_NhapKhoGapDan;
        public static bool mbThemMoi,mbCopy,mbSua;
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }
        private void HienThiGridControl_2(int xxidnhapkhogapdan)
        {

            clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
            cls2.iID_NhapKho = xxidnhapkhogapdan;
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKho();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("GhiChu", typeof(string));
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();

            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["ID_VTHH"] = iiDI_Vthh;
                cls.iID_VTHH = iiDI_Vthh;
                DataTable dtVT_vao = cls.SelectOne();
                _ravi["MaVT"] = iiDI_Vthh;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["SoLuong"] = soluong;
                _ravi["DonGia"] = dongia;

                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }

        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKho", typeof(int));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("ID_VTHH_ThanhPham_QuyDoi", typeof(int));
            dt2.Columns.Add("DonGia_ThanhPham_QuyDoi", typeof(double));
            dt2.Columns.Add("SoLuongThanhPham_QuyDoi", typeof(double));
            dt2.Columns.Add("TongTienHang", typeof(double));
            dt2.Columns.Add("ID_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("MaDinhMuc", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TrangThai_XuatKho_NPL", typeof(bool));
            clsGapDan_tbNhapKho cls = new CtyTinLuong.clsGapDan_tbNhapKho();
            DataTable dt = cls.SelectAll_HienThi();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
            DataTable dxxxx = dv2.ToTable();
            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                double DonGia_ThanhPham_QuyDoi = Convert.ToDouble(dxxxx.Rows[i]["DonGia_ThanhPham_QuyDoi"].ToString());
                double SoLuongThanhPham_QuyDoi = Convert.ToDouble(dxxxx.Rows[i]["SoLuongThanhPham_QuyDoi"].ToString());
                int ID_VTHH_ThanhPham_QuyDoixxx = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                DataRow _ravi = dt2.NewRow();

                _ravi["ID_NhapKho"] = Convert.ToInt16(dxxxx.Rows[i]["ID_NhapKho"].ToString());

                _ravi["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                _ravi["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                _ravi["ID_VTHH_ThanhPham_QuyDoi"] = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                _ravi["DonGia_ThanhPham_QuyDoi"] = DonGia_ThanhPham_QuyDoi;
                _ravi["SoLuongThanhPham_QuyDoi"] = SoLuongThanhPham_QuyDoi;
                _ravi["TongTienHang"] = DonGia_ThanhPham_QuyDoi * SoLuongThanhPham_QuyDoi;
                _ravi["ID_DinhMuc_ToGapDan"] = Convert.ToInt16(dxxxx.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                _ravi["MaDinhMuc"] = dxxxx.Rows[i]["MaDinhMuc"].ToString();
                _ravi["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                _ravi["TrangThai_XuatKho_NPL"] = Convert.ToBoolean(dxxxx.Rows[i]["TrangThai_XuatKho_NPL"].ToString());
                _ravi["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();

                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;


        }
        private void HienThi_ALL()
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_NhapKho", typeof(int));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("ID_VTHH_ThanhPham_QuyDoi", typeof(int));
            dt2.Columns.Add("DonGia_ThanhPham_QuyDoi", typeof(double));
            dt2.Columns.Add("SoLuongThanhPham_QuyDoi", typeof(double));
            dt2.Columns.Add("TongTienHang", typeof(double));
            dt2.Columns.Add("ID_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("MaDinhMuc", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TrangThai_XuatKho_NPL", typeof(bool));
            //TrangThai_XuatKho_NPL
            clsGapDan_tbNhapKho cls = new CtyTinLuong.clsGapDan_tbNhapKho();
            DataTable dt = cls.SelectAll_HienThi();
            DataView dv = dt.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
            DataTable dxxxx = dv.ToTable();
            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                double DonGia_ThanhPham_QuyDoi = Convert.ToDouble(dxxxx.Rows[i]["DonGia_ThanhPham_QuyDoi"].ToString());
                double SoLuongThanhPham_QuyDoi = Convert.ToDouble(dxxxx.Rows[i]["SoLuongThanhPham_QuyDoi"].ToString());
                int ID_VTHH_ThanhPham_QuyDoixxx = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                DataRow _ravi = dt2.NewRow();

                _ravi["ID_NhapKho"] = Convert.ToInt16(dxxxx.Rows[i]["ID_NhapKho"].ToString());

                _ravi["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                _ravi["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                _ravi["ID_VTHH_ThanhPham_QuyDoi"] = Convert.ToInt16(dxxxx.Rows[i]["ID_VTHH_ThanhPham_QuyDoi"].ToString());
                _ravi["DonGia_ThanhPham_QuyDoi"] = DonGia_ThanhPham_QuyDoi;
                _ravi["SoLuongThanhPham_QuyDoi"] = SoLuongThanhPham_QuyDoi;
                _ravi["TongTienHang"] = DonGia_ThanhPham_QuyDoi * SoLuongThanhPham_QuyDoi;
                _ravi["ID_DinhMuc_ToGapDan"] = Convert.ToInt16(dxxxx.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                _ravi["MaDinhMuc"] = dxxxx.Rows[i]["MaDinhMuc"].ToString();
                _ravi["MaVT"] = dxxxx.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dxxxx.Rows[i]["TenVTHH"].ToString();
                _ravi["TrangThai_XuatKho_NPL"] = Convert.ToBoolean(dxxxx.Rows[i]["TrangThai_XuatKho_NPL"].ToString());
                _ravi["DonViTinh"] = dxxxx.Rows[i]["DonViTinh"].ToString();

                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;



        }
        public UCNPL_XuatKho_GapDan()
        {
            InitializeComponent();
        }

        private void UCNPL_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCNPL_XuatKho_GapDan_Load( sender,  e);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                mbThemMoi = false;
                mbCopy = false;
                mbSua = true;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
                ff.Show();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                mbThemMoi = false;
                mbCopy = true;
                mbSua = false;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
                ff.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThai_XuatKho_NPL"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                clsGapDan_tbNhapKho cls2xxxx = new clsGapDan_tbNhapKho();
                cls2xxxx.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                DataTable dt1 = cls2xxxx.SelectOne();
                if (cls2xxxx.bTrangThai_XuatKho_NPL.Value == true)
                {
                    MessageBox.Show("Đã gửi dữ liệu, không thể xoá");
                    return;

                }
                else
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
                        cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());


                        cls1.Delete();
                        clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                        cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                        cls2.Delete_ALL_W_ID_NhapKho();
                        MessageBox.Show("Đã xóa");
                        if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                        {
                            HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                        }
                        else HienThi_ALL();
                    }
                }

            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbCopy = false;
            mbSua = false;
            KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
            ff.Show();
        }
    }
}
