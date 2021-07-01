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
        public static bool mbThemMoi_ThuChi, mbooolBitThuChiKhac;

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
            mbThemMoi_ThuChi = true;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            dteDenNgay.EditValue = DateTime.Today;
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCQuy_NganHang_BaoCo_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_ThuChi = true;
           
            Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
            _frmQNH.Hide();
            ff.ShowDialog();
            _frmQNH.Show();
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

                mbThemMoi_ThuChi = false;
                miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ThuChi).ToString());               
                Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
                _frmQNH.Hide();
                ff.ShowDialog();
                _frmQNH.Show();
            }

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4);
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
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime, frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4);

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
