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
    public partial class UC_DongKien_XuatCont_BenDaiLy : UserControl
    {
        public static bool _mbSua = false, _mbThemMoi = false, _mbCopy = false;
        public static int _iID_XuatContDongKien = 0, _idNguoiLap = 0;
        public static bool _tonTai, _NgungTheoDoi, _DaXuatKho;
        public static DateTime _NgayThang;
        public static string _SoChungTu, _DienGiai, _GhiChu, _TenNguoiLap;
        public UC_DongKien_XuatCont_BenDaiLy()
        {
            InitializeComponent();
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbXuatKho cls = new clsDongKien_TbXuatKho();
            DataTable dt = cls.Tr_DongKien_XuatCont_NgayThang_S(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
       
        public void UC_DongKien_XuatCont_BenDaiLy_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_DongKien_XuatCont_BenDaiLy_Load( sender,  e);
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() != "")
            {
                _mbThemMoi = false;
                _mbSua = false;
                _mbCopy = true;
                _iID_XuatContDongKien = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString());
                _idNguoiLap = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NguoiLap).ToString());
                _tonTai = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(TonTai).ToString());
                _NgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(NgungTheoDoi).ToString());
                _DaXuatKho = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(DaXuatKho).ToString());
                _NgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(NgayThang).ToString());
                _SoChungTu = gridView1.GetFocusedRowCellValue(SoChungTu).ToString();
                _DienGiai = gridView1.GetFocusedRowCellValue(DienGiai).ToString();
                _GhiChu = gridView1.GetFocusedRowCellValue(GhiChu).ToString();
                _TenNguoiLap = gridView1.GetFocusedRowCellValue(TenNhanVien).ToString();
                Tr_frmChiTietXuatContDongKien ff = new Tr_frmChiTietXuatContDongKien(this);
                ff.Show();
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            //if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() != "")
            //{

            //}
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien) == null
                || gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() == "")
            {
                return;
            }

            try
            {
                DialogResult ff = MessageBox.Show("Bạn có muốn xóa dữ liệu " + gridView1.GetFocusedRowCellValue(SoChungTu).ToString().Trim() + "?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ff == DialogResult.No)
                    return;

                int ID_XuatContDongKien_ = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString());
                clsDongKien_TbXuatKho_XuatContDL cls1 = new clsDongKien_TbXuatKho_XuatContDL();
                clsThin cls2 = new clsThin();

                cls2.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_DeleteIdXuatCont(ID_XuatContDongKien_);

                cls1.iID_XuatContDongKien = ID_XuatContDongKien_;
                cls1.Delete();

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

                cls1.Dispose();
                cls2.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa hàng hóa khỏi bảng..." + ex.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _mbThemMoi = true;
            _mbSua = false;
            _mbCopy = false;
            Tr_frmChiTietXuatContDongKien ff = new Tr_frmChiTietXuatContDongKien(this);
            ff.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() != "")
            {
                _mbThemMoi = false;
                _mbSua = true;
                _mbCopy = false;
                _iID_XuatContDongKien = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString());
                _idNguoiLap = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NguoiLap).ToString());
                _tonTai = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(TonTai).ToString());
                _NgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(NgungTheoDoi).ToString());
                _DaXuatKho = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(DaXuatKho).ToString());
                _NgayThang = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(NgayThang).ToString());
                _SoChungTu = gridView1.GetFocusedRowCellValue(SoChungTu).ToString();
                _DienGiai = gridView1.GetFocusedRowCellValue(DienGiai).ToString();
                _GhiChu = gridView1.GetFocusedRowCellValue(GhiChu).ToString(); 
                _TenNguoiLap = gridView1.GetFocusedRowCellValue(TenNhanVien).ToString(); 
                 Tr_frmChiTietXuatContDongKien ff = new Tr_frmChiTietXuatContDongKien(this);
                ff.Show();
            }
        }

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }
    }
}
