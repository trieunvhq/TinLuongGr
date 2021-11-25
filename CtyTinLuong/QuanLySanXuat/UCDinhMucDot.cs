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
        public static bool _bCopyDinhMucDot = false;

        public static int miDID_VTHH;
        public static bool mb_bool_NgungTheoDoi;
       
        public static int miID_DinhMuc_Dot;
        int xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;

        public static int _ID_DinhMuc_Dot = 0;
        public static DateTime _NgayThang;
        public static string _Ca = "";
        public static string _SoHieu = "";
        public static int _ID_VTHH = 0;
        public static string _LoaiGiay = "";
        public static Double _SoLuongKiemTra = 0;
        public static Double _TrongLuongKiemTra = 0;
        public static Double _SoLuongQuyDoi = 0;
        public static string _DonViQuyDoi = "";
        public static Double _QuyRaKien = 0;
        public static Double _PhePham = 0;
        public static Double _DoCao = 0;
        public static Double _SoKG_MotBao = 0;
        public static Double _SoKienMotBao = 0;
        public static bool _TonTai = false;
        public static bool _NgungTheoDoi = false;
        public static string _GhiChu = "";
        public static bool _Khoa = false;
        public static string _TenVTHH = "";
        public static string _MaVT = "";
        public static string _DonViTinh = "";

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
                    _bCopyDinhMucDot = false;
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

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString() != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                _bCopyDinhMucDot = true;
                mb_TheMoi_DinhMuc_Dot = false;
                _ID_DinhMuc_Dot = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Dot).ToString());
                _NgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(clNgayThang).ToString());
                _Ca = gridView1.GetFocusedRowCellValue(clCa).ToString();
                _SoHieu = gridView1.GetFocusedRowCellValue(clSoHieu).ToString();
                _ID_VTHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                _LoaiGiay = gridView1.GetFocusedRowCellValue(clLoaiGiay).ToString();
                _SoLuongKiemTra = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuongKiemTra).ToString());
                _TrongLuongKiemTra = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clTrongLuongKiemTra).ToString());
                _SoLuongQuyDoi = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoLuongQuyDoi).ToString());
                _DonViQuyDoi = gridView1.GetFocusedRowCellValue(clDonViQuyDoi).ToString();
                _QuyRaKien = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clQuyRaKien).ToString());
                _PhePham = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clPhePham).ToString());
                _DoCao = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clDoCao).ToString());
                _SoKG_MotBao = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoKG_MotBao).ToString());
                _SoKienMotBao = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(clSoKienMotBao).ToString());
                _TonTai = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clTonTai).ToString());
                _NgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                _GhiChu = gridView1.GetFocusedRowCellValue(clGhiChu).ToString();
                _Khoa = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clKhoa).ToString());
                _TenVTHH = gridView1.GetFocusedRowCellValue(clTenVT).ToString();
                _MaVT = gridView1.GetFocusedRowCellValue(clMaVT).ToString();
                _DonViTinh = gridView1.GetFocusedRowCellValue(clDonViTinh1).ToString();
                frmChiTietDinhMucDot ff = new frmChiTietDinhMucDot(this);
                ff.Show();
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
