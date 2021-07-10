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
    public partial class UCBanHang_BanHang : UserControl
    {
        public static bool isClick=false;
        public static int miiiID_BanHang;

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {

            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.SA_NgayThang_(true, xxtungay, xxdenngay);          
            gridControl1.DataSource = dt;
            dt.Dispose();
            cls.Dispose();

        }
      

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
        private void HienThi_Gridcontrol_2(int xxID_banHang)
        {
            clsBanHang_ChiTietBanHang cls = new clsBanHang_ChiTietBanHang();
            cls.iID_BanHang = xxID_banHang;
            DataTable dt3 = cls.Select_HienThiSuaDonHang();           
            gridControl2.DataSource = dt3;
            dt3.Dispose();
            cls.Dispose();
        }

        frmQuanLyBanHang _frmQLBH;
        public UCBanHang_BanHang(frmQuanLyBanHang frmQLBH)
        {
            _frmQLBH = frmQLBH;
            InitializeComponent();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCBanHang_BanHang_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void UCBanHang_BanHang_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime); 
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT11)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

      
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{

            //    clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            //    cls.iID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
            //    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
            //    cls.Update_NgungTheoDoi();
            //}
            //catch
            //{

            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_BanHang) != null)
                {
                    isClick = true;
                    miiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                    BanHang_FrmChiTietBanHang_Newwwwwwww ff = new BanHang_FrmChiTietBanHang_Newwwwwwww();
                   
                    ff.Show();
                   
                }
            }
            catch
            {

            }
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiBanHang"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                int xxxxID_BanHang= Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                clsBanHang_tbBanHang cls1moi = new clsBanHang_tbBanHang();
                cls1moi.iID_BanHang = xxxxID_BanHang;
                DataTable dt1moi = cls1moi.SelectOne();
                string sochungtu = cls1moi.sSoChungTu.Value;
                DateTime ngaychungtu = cls1moi.daNgayChungTu.Value;
                clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();
                cls1.iID_BanHang = xxxxID_BanHang;            
                cls1.Delete();
                clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                cls2.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                cls2.Delete_W_iID_BanHang();
                // xoá bien dong tai khoan
                clsNganHang_ChiTietBienDongTaiKhoanKeToan clsxx = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
                clsxx.iID_ChungTu = xxxxID_BanHang;
                clsxx.sSoChungTu = sochungtu;
                clsxx.daNgayThang = ngaychungtu;

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
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

            }

            Cursor.Current = Cursors.Default;
        }
         
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_BanHang).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                int xxxmiiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                HienThi_Gridcontrol_2(xxxmiiiID_BanHang);

                Cursor.Current = Cursors.Default;
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
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void gridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT233)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
