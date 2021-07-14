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
    public partial class UCBTP_XuatKho_LSX_I_C_D : UserControl
    {
        public static int mID_iD_LenhSanXuat, miID_loaiMay;
        public static string msMaLenhSanxuat;

      
        public void LoadData( DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;          
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            DataTable dt = cls.SA_XuatKho_BTP(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;

            cls.Dispose();
            dt.Dispose();

        }
    

    
        private void HienThiGridControl_2(int xxID_lenhsanxuat)
        {
            DataTable dt2 = new DataTable();
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls.iID_LenhSanXuat = xxID_lenhsanxuat;
            DataTable dt = cls.SA_ID_LSX(xxID_lenhsanxuat);
            gridControl2.DataSource = dt;
            cls.Dispose();
            dt.Dispose();

            //DataTable dt2 = new DataTable();
            //clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            //cls2.iID_LenhSanXuat = xxID_lenhsanxuat;
            //DataTable dtxxxx = cls2.SelectAll_w_iID_LenhSanXuat();
            //dt2.Columns.Add("ID_VTHH", typeof(int));
            //dt2.Columns.Add("MaVT", typeof(string));
            //dt2.Columns.Add("DonViTinh", typeof(string));
            //dt2.Columns.Add("TenVTHH", typeof(string));
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("DonGia", typeof(float));
            //dt2.Columns.Add("ThanhTien", typeof(float));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();

            //for (int i = 0; i < dtxxxx.Rows.Count; i++)
            //{
            //    double soluong, dongia;
            //    DataRow _ravi = dt2.NewRow();
            //    int iiDI_Vthh_vao = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
            //    _ravi["ID_VTHH"] = iiDI_Vthh_vao;
            //    clsVT_Vao.iID_VTHH = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
            //    DataTable dtVT_vao = clsVT_Vao.SelectOne();
            //    _ravi["MaVT"] = iiDI_Vthh_vao;
            //    _ravi["DonViTinh"] = clsVT_Vao.sDonViTinh.Value;
            //    _ravi["TenVTHH"] = clsVT_Vao.sTenVTHH.Value;
            //    _ravi["SoLuong"] = CheckString.ConvertToDouble_My(dtxxxx.Rows[i]["SoLuongVao"].ToString());
            //    _ravi["DonGia"] = CheckString.ConvertToDouble_My(dtxxxx.Rows[i]["DonGiaVao"].ToString());
            //    soluong = CheckString.ConvertToDouble_My(dtxxxx.Rows[i]["SoLuongVao"].ToString());
            //    dongia = CheckString.ConvertToDouble_My(dtxxxx.Rows[i]["DonGiaVao"].ToString());
            //    _ravi["ThanhTien"] = soluong * dongia;
            //    _ravi["HienThi"] = "1";
            //    //_ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
            //    dt2.Rows.Add(_ravi);
            //}

            //gridControl2.DataSource = dt2;
        }

        frmQuanLyKhoBanThanhPham _frmKBTP;
        public UCBTP_XuatKho_LSX_I_C_D(frmQuanLyKhoBanThanhPham frmKBTP)
        {
            _frmKBTP = frmKBTP;
            InitializeComponent();
        }

        private void UCBTP_XuatKho_LSX_I_C_D_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            dteTuNgay.EditValue = DateTime.Now.AddDays(-30);
            dteDenNgay.EditValue = DateTime.Now;
            LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);
          
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadData(dteTuNgay.DateTime, dteDenNgay.DateTime);

                Cursor.Current = Cursors.Default;
            }
        }

        private void btfresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCBTP_XuatKho_LSX_I_C_D_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
                {
                    miID_loaiMay = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LoaiMay).ToString());
                    msMaLenhSanxuat = gridView1.GetFocusedRowCellValue(clMaLenhSanXuat).ToString();
                    mID_iD_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                    KhoBTP_ChiTiet_NhapKho_XuatKho_LSX ff = new KhoBTP_ChiTiet_NhapKho_XuatKho_LSX();
                    //_frmKBTP.Hide();
                    ff.Show();
                    //_frmKBTP.Show();
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

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
    }
}
