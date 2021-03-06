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
    public partial class UCQuy_NganHang_BaoCo : UserControl
    {
        public static int miID_ThuChi_Sua;
        public static bool mbTheMoi, mbCoPy, mbSua, mbooolBitThuChiKhac;
        public static bool isChiTiet_thuchi = false;
        private void Load_DaTa(DateTime xxtungay, DateTime  xxdenngay, int bientrangthai)
        {
            DataTable dt = new DataTable();
            clsNganHang_tbThuChi cls = new CtyTinLuong.clsNganHang_tbThuChi();
            dt = cls.SA_NgayThang(xxtungay, xxdenngay, bientrangthai);
            gridControl1.DataSource = dt;
        }
     

        frmQuy_NganHang_Newwwwwwwwwwwwwwwww _frmQNH;

        public UCQuy_NganHang_BaoCo(frmQuy_NganHang_Newwwwwwwwwwwwwwwww frmQNH)
        {
            _frmQNH = frmQNH;
            InitializeComponent();
        }

        private void UCQuy_NganHang_BaoCo_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCQuy_NganHang_BaoCo_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            isChiTiet_thuchi = true;
            frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.isChiTiet_thuchi = false;

            if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5 == 5)
            {

                mbTheMoi = true;
                mbCoPy = false;
                mbSua = false;
                QuyNganHang_Frm_DoiTienUSD ff = new CtyTinLuong.QuyNganHang_Frm_DoiTienUSD();              
                ff.Show();
                
            }
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5 == 6)
            {
                mbTheMoi = true;
                mbCoPy = false;
                mbSua = false;
                QuyNganHang_Frm_PhieuKeToan ff = new CtyTinLuong.QuyNganHang_Frm_PhieuKeToan();              
                ff.Show();
              
            }
            else
            {
                mbTheMoi = true;
                mbCoPy = false;
                mbSua = false;
                Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();              
                ff.Show();
               
            }
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
            if (gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString() != "")
            {
                isChiTiet_thuchi = true;
                frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.isChiTiet_thuchi = false;
                BanHang_DoiChieu_CongNo_new.isChiTiet_thuchi = false;
                MuaHang_DoiChieuCongNo_New.isChiTiet_thuchi = false;
                mbTheMoi = false;
                mbCoPy = false;
                mbSua = true;
                if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5==5)
                {
                    
                    miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                    QuyNganHang_Frm_DoiTienUSD ff = new CtyTinLuong.QuyNganHang_Frm_DoiTienUSD();                  
                    ff.Show();
                }
                else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5 == 6)
                {

                    miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                    QuyNganHang_Frm_PhieuKeToan ff = new CtyTinLuong.QuyNganHang_Frm_PhieuKeToan();
                    ff.Show();
                }
                else
                {                  
                    miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                    Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
                    ff.Show();
                }
               
            }

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                int iiIDthuchi= Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                cls1.iID_ThuChi = iiIDthuchi;
                DataTable dt1 = cls1.SelectOne();
                string sochungtu = cls1.sSoChungTu.Value;
                DateTime ngay = cls1.daNgayChungTu.Value;

                cls1 = new clsNganHang_tbThuChi();
                cls1.iID_ThuChi = iiIDthuchi;
                cls1.Delete();
                clsNganHang_tbThuChi_ChiTietThuChi cls2 = new clsNganHang_tbThuChi_ChiTietThuChi();
                cls2.iID_ThuChi = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                cls2.Delete_ALL_W_ID_ThuChi();

                //xoá chi tiết biến động tài khoản
               clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clsxx.iID_ChungTu = iiIDthuchi;
                clsxx.sSoChungTu = sochungtu;
                clsxx.daNgayThang = ngay;

                DataTable dt2_cu = clsxx.Select_W_iID_ChungTu_sSoChungTu_daNgayThang();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        clsxx.iID_ChiTietBienDongTaiKhoan = Convert.ToInt32(dt2_cu.Rows[i]["ID_ChiTietBienDongTaiKhoan"].ToString());
                        clsxx.Delete();
                    }
                }
                MessageBox.Show("Đã xóa");
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);

            }
   
    }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
            }
        }

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString() != "")
            {
                int ID_ThuChi_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                if (ID_ThuChi_ == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Tr_frmPrintPhieuKeToanVAT ff = new Tr_frmPrintPhieuKeToanVAT(ID_ThuChi_);
                    ff.Show();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn phiếu kế toán để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btCopY_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString() != "")
            {
                isChiTiet_thuchi = true;
                if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien5 == 5)
                {
                    mbTheMoi = false;
                    mbCoPy = true;
                    mbSua = false;
                    miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                    QuyNganHang_Frm_DoiTienUSD ff = new CtyTinLuong.QuyNganHang_Frm_DoiTienUSD();                  
                    ff.Show();
                   
                }
                else
                {
                    mbTheMoi = false;
                    mbCoPy = true;
                    mbSua = false;
                    miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());
                    Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();                 
                    ff.Show();
                  
                }

            }

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaGhiSo"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                   
                }
            }
        }
    }
}
