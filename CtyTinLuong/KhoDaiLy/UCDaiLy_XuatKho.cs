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
    public partial class UCDaiLy_XuatKho : UserControl
    {
     
        public static int miID_XuatKhoDaiLy;
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
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(DateTime.Now);
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

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            
                clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
                DataTable dtxx = cls.SelectAll_W_TenDaiLy();
                dtxx.DefaultView.RowFilter = "TonTai = True and NgungTheoDoi = False and TrangThaiXuatNhap_ThanhPham_TuDaiLyVe =True";
                DataView dvxxx = dtxx.DefaultView;
                DataTable dt = dvxxx.ToTable();
                if (dtxx.Rows.Count > 0)
                {
                   
                    dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                    DataView dv = dt.DefaultView;
                    DataTable dt22 = dv.ToTable();
                    dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                    DataView dv2 = dt22.DefaultView;
                    dv2.Sort = "TrangThai_XuatKho_DaiLy_GuiDuLieu ASC, NgayChungTu DESC, ID_XuatKhoDaiLy DESC";
                    DataTable dxxxx = dv2.ToTable();
                    gridControl1.DataSource = dxxxx;

                }
           

        }
        private void HienThi_ALL()
        {
            clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
            DataTable dt = cls.SelectAll_W_TenDaiLy();           
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = "TonTai = True and NgungTheoDoi = False and TrangThaiXuatNhap_ThanhPham_TuDaiLyVe =True";
                DataView dv = dt.DefaultView;
                dv.Sort = "TrangThai_XuatKho_DaiLy_GuiDuLieu ASC, NgayChungTu DESC, ID_XuatKhoDaiLy DESC";
                DataTable dxxxx = dv.ToTable();
                gridControl1.DataSource = dxxxx;
            }
        }

        private void HienThi_ChiTiet_XuatKho(int xxxxmiID_XuatKhoDaiLyxxxxx)
        {

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
            cls2.iID_XuatKhoDaiLy = xxxxmiID_XuatKhoDaiLyxxxxx;
            DataTable dt222 = cls2.SelectAll_W_ID_XuatKhoDaiLy_SoChungTu_Ngay_MaVT_TenVT(xxxxmiID_XuatKhoDaiLyxxxxx);
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
                _ravi3["SoLuongNhap"] = CheckString.ConvertToDouble_My(dt222.Rows[i]["SoLuongNhap"].ToString());
                _ravi3["SoLuongThanhPhamQuyDoi"] = CheckString.ConvertToDouble_My(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["DonGia"] = CheckString.ConvertToDouble_My(dt222.Rows[i]["DonGia"].ToString());
                _ravi3["HienThi"] = "1";
                _ravi3["TiLe"] = CheckString.ConvertToDouble_My(dt222.Rows[i]["SoLuongNhap"].ToString()) / CheckString.ConvertToDouble_My(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi3["ThanhTien"] = CheckString.ConvertToDouble_My(dt222.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString()) * CheckString.ConvertToDouble_My(dt222.Rows[i]["DonGia"].ToString());

                dt2.Rows.Add(_ravi3);

            }
            gridControl2.DataSource = dt2;
        }

        frmQuanLyKhoDaiLy _frmQLKDL;
        public UCDaiLy_XuatKho(frmQuanLyKhoDaiLy frmQLKDL)
        {
            _frmQLKDL = frmQLKDL;
            InitializeComponent();
        }

        private void Load_LockUp()
        {
            clsDaiLy_tbNhapKho clsvattu = new clsDaiLy_tbNhapKho();
            //clsvattu.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
            DataTable dtvattu = clsvattu.SelectAll();
            //dtvattu.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False ";
            dtvattu.DefaultView.RowFilter = " HoanThanh = False";
            DataView dvvattu = dtvattu.DefaultView;
            DataTable newdtvattu = dvvattu.ToTable();
            gridMaHang.DataSource = newdtvattu;
            gridMaHang.ValueMember = "ID_NhapKhoDaiLy";
            gridMaHang.DisplayMember = "SoChungTu";
        }

        private void UCDaiLy_XuatKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            dteDenNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
            Cursor.Current = Cursors.Default;
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
            Cursor.Current = Cursors.WaitCursor;
            miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
            frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII ff = new frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII(this);
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
            Cursor.Current = Cursors.Default;
        }

      

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_XuatKho_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
                cls.iID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category =Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThai_XuatKho_DaiLy_GuiDuLieu"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                   
                }
            }

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
                int xxxxmiID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                HienThi_ChiTiet_XuatKho(xxxxmiID_XuatKhoDaiLy);
            }

            if (gridView1.GetFocusedRowCellValue(clID_VTHH1).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH1).ToString());
                Hienthi_Lable_TonKho(xxID);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();


            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {

                cls1.iID_XuatKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                cls1.Delete();
                clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                cls2.iID_XuatKhoDaiLy = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                cls2.Delete_ALL_W_ID_XuatKhoDaiLy();
                MessageBox.Show("Đã xóa");
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
                else HienThi_ALL();
            }

        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }
    }
}
