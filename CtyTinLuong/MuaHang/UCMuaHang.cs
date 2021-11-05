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
    public partial class UCMuaHang : UserControl
    {
        public static bool mbThemMoi, mbSua,mbCopY;
        public static int miiiID_Sua_DonHang;
        private bool isload = false;
        private void HienThiGridControl_2(int xxiDmuahang)
        {
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = xxiDmuahang;
            DataTable dt2 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();          
            gridControl2.DataSource = dt2;
        }
        DataTable dtnganhang;
        private void HienThi_lableCongNo(int iiiID_NhaCungCap)
        {
            clsTbNhaCungCap clsxx = new clsTbNhaCungCap();
            clsxx.iID_NhaCungCap = iiiID_NhaCungCap;
            DataTable dtxx = clsxx.SelectOne();
            string makh = clsxx.sMaNhaCungCap.Value;
            string tenncc = clsxx.sTenNhaCungCap.Value;          
            if(dtxx.Rows[0]["ID_TaiKhoanKeToan"].ToString()!="")
            {
                double dNoCuoiKy, dCoCuoiKy;
                double dNo_CuoiKy, dCo_CuoiKy;
                int iiIDID_TaiKhoanKeToanCon = clsxx.iID_TaiKhoanKeToan.Value;
                
                string filterExpression = "ID_TaiKhoanKeToanCon ="+ iiIDID_TaiKhoanKeToanCon + "";
                DataRow[] foundRows = dtnganhang.Select(filterExpression);
              
                if (foundRows.Length > 0)
                {                   
                    dNo_CuoiKy = CheckString.ConvertToDouble_My(foundRows[0]["No_CuoiKy"].ToString());
                    dCo_CuoiKy = CheckString.ConvertToDouble_My(foundRows[0]["Co_CuoiKy"].ToString());
                    if (dNo_CuoiKy <= dCo_CuoiKy)
                    {                       
                        dCoCuoiKy = dCo_CuoiKy - dNo_CuoiKy;
                        label_CongNo.Text = ""+makh+": "+tenncc+"|| Dư có: " + dCoCuoiKy.ToString("#,###") + "";
                    }
                    else
                    {
                        dNoCuoiKy = -dCo_CuoiKy + dNo_CuoiKy;
                        label_CongNo.Text = "" + makh + ": " + tenncc + "|| Nợ có: " + dNoCuoiKy.ToString("#,###") + "";
                    }
                }
               

               
            }
              

        }
        private void Load_DaTa(bool bxxTranLaiHangMua, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt = new DataTable();
            clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
            dt = cls.SA_NgayThang_(bxxTranLaiHangMua, xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
       
        frmMuaHang2222 _frmMH;

        public UCMuaHang(frmMuaHang2222 frmMH)
        {
            _frmMH = frmMH;
            InitializeComponent();
        }
        
        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCMuaHang_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void UCMuaHang_Load(object sender, EventArgs e)
        {
            isload = true;

            Cursor.Current = Cursors.WaitCursor;
           
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            dtnganhang = cls.Sum_Co_No_NgayThang_HUU(287, dteTuNgay.DateTime, DateTime.Now);

            Load_DaTa(frmMuaHang2222.mbTraLaiHangMua, dteTuNgay.DateTime, dteDenNgay.DateTime);
            
           
            clTongTienHang.Caption = "Tổng\ntiền hàng";
          
            Cursor.Current = Cursors.Default;
            dteTuNgay.Focus();

            isload = false;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbThemMoi = true;
            mbSua = false;
            mbCopY = false;
            frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333(this);
            //_frmMH.Hide();
            ff.Show();
            //_frmMH.Show();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {//msDienGiai
                    Cursor.Current = Cursors.WaitCursor;
                    mbCopY = false;
                    mbThemMoi = false;
                    mbSua = true;
                    miiiID_Sua_DonHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());                  
                    frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333(this);
                    //_frmMH.Hide();
                    ff.Show();
                    //_frmMH.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiNhapKho"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }

        }

        private void btXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            clsMH_tbMuaHang cls1 = new clsMH_tbMuaHang();           
            cls1.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
            DataTable dt1 = cls1.SelectOne();
            int xxxID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
            string xxsochungtu = cls1.sSoChungTu.Value;
            DateTime xxngay = cls1.daNgayChungTu.Value;
            if (cls1.bTrangThaiNhapKho.Value == true)
            {
                MessageBox.Show("Đã nhập kho, không thể xoá");
                return;
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                   
                    cls1.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    cls1.Delete();
                    clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
                    cls2.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    cls2.Delete_W_ID_MuaHang();
                    //xoá chi tiết biến động tài khoản
                   clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                    clsxx.iID_ChungTu = xxxID_MuaHang;
                    clsxx.sSoChungTu = xxsochungtu;
                    clsxx.daNgayThang = xxngay;

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
                    Load_DaTa(frmMuaHang2222.mbTraLaiHangMua, dteTuNgay.DateTime, dteDenNgay.DateTime);
                }
            }
                

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_DaTa(frmMuaHang2222.mbTraLaiHangMua, dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
            {
                int iDImuahang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                HienThiGridControl_2(iDImuahang);
             
            }

            if (gridView1.GetFocusedRowCellValue(clIDNhaCungCap).ToString() != "")
            {
                int iiID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clIDNhaCungCap).ToString());
                HienThi_lableCongNo(iiID);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
        }

        private void dteTuNgay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (isload)
                return;
            DateTime date1 = (DateTime)e.OldValue;
            DateTime date2 = (DateTime)e.NewValue;
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    mbCopY = true;
                    mbThemMoi = false;
                    mbSua = false;
                   
                    miiiID_Sua_DonHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333(this);
                    //_frmMH.Hide();
                    ff.Show();
                    //_frmMH.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }
    }
}
