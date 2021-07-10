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
    public partial class UCDaiLy_XuatKho_GapDan : UserControl
    {
        public static int miID_XuatKho_GapDan;
        public static bool mbthemmoi, mbsua, mbcopy;
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
        private void HienThiGridControl_2(int xxID_nhapkho)
        {

            DataTable dt2 = new DataTable();
            clsGapDan_ChiTiet_XuatKho cls2 = new CtyTinLuong.clsGapDan_ChiTiet_XuatKho();
            cls2.iID_XuatKho = xxID_nhapkho;
            DataTable dtxxxx = cls2.SelectAll_ID_XuatKho();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("GhiChu", typeof(string));
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();

            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                DataRow _ravi = dt2.NewRow();
                int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["ID_VTHH"] = iiDI_Vthh;
                cls.iID_VTHH = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                DataTable dtVT_vao = cls.SelectOne();
                _ravi["MaVT"] = iiDI_Vthh;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["SoLuong"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongXuat"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongXuat"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }

            gridControl3.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_tbXuatKho cls = new CtyTinLuong.clsGapDan_tbXuatKho();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "NgayChungTu DESC, ID_XuatKho DESC";
            DataTable dxxxx = dv2.ToTable();
            gridControl1.DataSource = dxxxx;

        }
        private void HienThi_ALL()
        {
                   
            clsGapDan_tbXuatKho cls = new CtyTinLuong.clsGapDan_tbXuatKho();
            DataTable dt = cls.SelectAll();
            gridControl1.DataSource = dt;
          

        }

        frmQuanLyKhoDaiLy _frmQLKDL;
        public UCDaiLy_XuatKho_GapDan(frmQuanLyKhoDaiLy frmQLKDL)
        {
            _frmQLKDL = frmQLKDL;
            InitializeComponent();
        }

        private void UCDaiLy_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCDaiLy_XuatKho_GapDan_Load( sender,  e);
            Cursor.Current = Cursors.Default;
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
            if(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString()!="")
            {
                Cursor.Current = Cursors.WaitCursor;
                mbthemmoi = false;
                mbsua = true;
                mbcopy = false;
                miID_XuatKho_GapDan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
                DaiLy_FrmChiTiet_XuatKho_GapDan ff = new DaiLy_FrmChiTiet_XuatKho_GapDan();
                //_frmQLKDL.Hide();
                ff.Show();
                //_frmQLKDL.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho).ToString());
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

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null)
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
            Cursor.Current = Cursors.Default;
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }
        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            double soluongxuat, soluongnhap;
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(DateTime.Now);
            string filterExpression = "ID_VTHH=" + xxID_VTHH + "";
            DataRow[] rows_Xuat = dt_XuatTruoc.Select(filterExpression);
            DataRow[] rows_Nhap = dt_NhapTruoc.Select(filterExpression);
            if (rows_Xuat.Length == 0)
                soluongxuat = 0;
            else
                soluongxuat = Convert.ToDouble(rows_Xuat[0]["SoLuong_XuatTruocKy"].ToString());
            if (rows_Nhap.Length == 0)
                soluongnhap = 0;
            else
                soluongnhap = Convert.ToDouble(rows_Nhap[0]["SoLuong_NhapTruocKy"].ToString());
            soluongton = soluongnhap - soluongxuat;

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }
        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {

            if (gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString() != "")
            {
                int xxID = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_VTHH2).ToString());
                Hienthi_Lable_TonKho(xxID);
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

        private void gridControl3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaXuatKho"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbthemmoi = true;
            mbsua = false;
            mbcopy = false;
            DaiLy_FrmChiTiet_XuatKho_GapDan ff = new DaiLy_FrmChiTiet_XuatKho_GapDan();
            //_frmQLKDL.Hide();
            ff.Show();
            //_frmQLKDL.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
