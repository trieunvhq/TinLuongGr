using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCDinhMucHangNhu : UserControl
    {
        public static bool mb_TheMoi_DinhMuc_Dot;

        public static int miDID_VTHH;
        public static bool mb_bool_NgungTheoDoi;

        public static int miID_DinhMuc_Dot;

        public static int xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;
        private void Load_DaTa(int xxxIDLoaiHang)
        {
            clsDinhMuc_tbDinhMuc_DOT cls = new clsDinhMuc_tbDinhMuc_DOT();
            DataTable dt = cls.SA_W_Loaihang(xxxIDLoaiHang);
            gridControl1.DataSource = dt;

        }

        SanXuat_frmQuanLySanXuat _frmQLSX;
        public UCDinhMucHangNhu(SanXuat_frmQuanLySanXuat frmQLSX = null)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();
        }

        private void UCDinhMucHangNhu_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           
            mb_TheMoi_DinhMuc_Dot = false;
            xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 2;
            checkHangNhu.Checked = true;
            Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
            Cursor.Current = Cursors.Default;
        }

     

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clKhoa).ToString()) == true)
            {
                MessageBox.Show("Dữ liệu khoá, không thể xoá");
                return;
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    clsDinhMuc_tbDinhMuc_DOT cls1 = new clsDinhMuc_tbDinhMuc_DOT();
                    cls1.iID_DinhMuc_Dot = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());
                    cls1.Delete();
                    MessageBox.Show("Đã xóa");
                    Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_DinhMuc_Dot = true;
            frmChiTietDinhMuc_HangNhu ff = new frmChiTietDinhMuc_HangNhu();
            //_frmQLSX.Hide();
            ff.ShowDialog();
            //_frmQLSX.Show();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    miID_DinhMuc_Dot = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());
                    miDID_VTHH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                    mb_bool_NgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                    mb_TheMoi_DinhMuc_Dot = false;
                    frmChiTietDinhMuc_HangNhu ff = new frmChiTietDinhMuc_HangNhu();
                    //_frmQLSX.Hide();
                    ff.ShowDialog();
                    //_frmQLSX.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls.iID_DinhMuc_NPL = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void checkHangNhu_CheckedChanged(object sender, EventArgs e)
        {
            if(checkHangNhu.Checked==true)
            {
                xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 2;
                checkHangCuc.Checked = false;
                checkHangSot.Checked = false;

                clSoKG_MotBao.Visible = true;
                clSoKienMotBao.Caption = "Kiện/Bao";
                clSoKG_MotBao.Caption = "Cục/Bao";

                Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
            }
        }

        private void checkHangCuc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangCuc.Checked == true)
            {
                xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 3;
                checkHangNhu.Checked = false;
                checkHangSot.Checked = false;

                clSoKienMotBao.Caption = "Cục/Kiện";
                clSoKG_MotBao.Visible = false;

                Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
            }
        }

        private void checkHangSot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangSot.Checked == true)
            {
                clSoKG_MotBao.Visible = true;
                clSoKienMotBao.Caption = "Kiện/Sọt";
                clSoKG_MotBao.Caption = "Kg/Sọt";

                xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 4;
                checkHangNhu.Checked = false;
                checkHangCuc.Checked = false;
                Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
            }
        }
    }
}
