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
    public partial class UCDinhMucDot : UserControl
    {
        public static bool mb_TheMoi_DinhMuc_Dot;
       
        public static int miDID_VTHH;
        public static bool mb_bool_NgungTheoDoi;
       
        public static int miID_DinhMuc_Dot;
        int xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;
        private void btXoa_Click(object sender, EventArgs e)
        {
            try
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
                        clsDinhMuc_tbDinhMuc_DOT cls1 = new clsDinhMuc_tbDinhMuc_DOT();
                        cls1.iID_DinhMuc_Dot = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());
                        cls1.Delete();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                mb_TheMoi_DinhMuc_Dot = true;
                frmChiTietDinhMucDot ff = new frmChiTietDinhMucDot(this);
                //_frmQLSX.Hide();
                ff.Show();
                //_frmQLSX.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    miID_DinhMuc_Dot = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());                 
                    miDID_VTHH= Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                    mb_bool_NgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());                 
                    mb_TheMoi_DinhMuc_Dot = false;
                    frmChiTietDinhMucDot ff = new frmChiTietDinhMucDot(this);
                    //_frmQLSX.Hide();
                    ff.Show();
                    //_frmQLSX.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDinhMucDot_Load(sender, e);
            Cursor.Current = Cursors.Default;
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }


        private void Load_DaTa(int xxxIDLoaiHang)
        {
            try
            {
                clsDinhMuc_tbDinhMuc_DOT cls = new clsDinhMuc_tbDinhMuc_DOT();
                DataTable dt = cls.SA_W_Loaihang(xxxIDLoaiHang);
                gridControl1.DataSource = dt;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        SanXuat_frmQuanLySanXuat _frmQLSX;
        public UCDinhMucDot(SanXuat_frmQuanLySanXuat frmQLSX = null)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();
        }

       

        private void UCDinhMucDot_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                clSoLuongKiemTra.Caption = "SL\nkiểm tra";
                clTrongLuongKiemTra.Caption = "Trọng\nlượng";
                clQuyRaKien.Caption = "Quy\nra kiện";
                clPhePham.Caption = "Phế\nphẩm";
                clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";

                mb_TheMoi_DinhMuc_Dot = false;
                xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 1;
                Load_DaTa(xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
