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
    public partial class UC_KhoNVL_frmChoNhapKho : UserControl
    {
        //public static bool mb_TheMoi_DonHang;
        public static int miID_MuaHang_NhapKho;
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
        private void HienThiGridControl_2(int xxiDmuahang)
        {
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = xxiDmuahang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            //dt2.Columns.Add("ID_MuaHang");
            //dt2.Columns.Add("ID_VTHH");
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("MaVT");// tb VTHH
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("ThanhTien", typeof(double));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuong"].ToString());
            //    Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();
            //    _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
            //    _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
            //    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
            //    _ravi["SoLuong"] = xxsoluong;
            //    _ravi["DonGia"] = xxdongia;
            //    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
            //    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
            //    _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
            //    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
            //    _ravi["HienThi"] = "1";
            //    dt2.Rows.Add(_ravi);
            //}

            gridControl2.DataSource = dt3;
        }
       
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
            DataTable dt = cls.H_MuaHang_SA_NgayThang(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }

        KhoNPL_frmNPL _frmKNPL;
        public UC_KhoNVL_frmChoNhapKho(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
        }

        public void UC_KhoNVL_frmChoNhapKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           // Load_LockUp();
            dteNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);            
            Cursor.Current = Cursors.Default;
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {
                    miID_MuaHang_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    KhoNPL_frmChiTiet_MuaHang_NhapKho ff = new KhoNPL_frmChiTiet_MuaHang_NhapKho(this);
                    //_frmKNPL.Hide();
                    ff.Show();
                    //_frmKNPL.Show();
                }
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

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            UC_KhoNVL_frmChoNhapKho_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Load_DaTa(dteTuNgay.DateTime, dteNgay.DateTime);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
            {
                int iDImuahang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                HienThiGridControl_2(iDImuahang);
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu_Click(null, null);
                SendKeys.Send("{TAB}");
            }
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_DaTa(dteTuNgay.DateTime, dteNgay.DateTime);
            }
            catch
            { }
        }

        private void dteNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_DaTa(dteTuNgay.DateTime, dteNgay.DateTime);
            }
            catch
            { }
        }
    }
}
