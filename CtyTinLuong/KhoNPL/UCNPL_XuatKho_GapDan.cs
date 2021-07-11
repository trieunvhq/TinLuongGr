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
    public partial class UCNPL_XuatKho_GapDan : UserControl
    {
        public static int miiID_NhapKhoGapDan;
        public static bool mbThemMoi,mbCopy,mbSua;
     
        private void HienThiGridControl_2(int xxidnhapkhogapdan)
        {

            clsGapDan_ChiTiet_NhapKho_Temp cls2 = new clsGapDan_ChiTiet_NhapKho_Temp();
            cls2.iID_NhapKho = xxidnhapkhogapdan;
            DataTable dtxxxx = cls2.SA_W_ID_NhapKho(xxidnhapkhogapdan);
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_VTHH", typeof(int));
            //dt2.Columns.Add("MaVT", typeof(string));
            //dt2.Columns.Add("DonViTinh", typeof(string));
            //dt2.Columns.Add("TenVTHH", typeof(string));
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("DonGia", typeof(float));
            //dt2.Columns.Add("ThanhTien", typeof(float));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();

            //for (int i = 0; i < dtxxxx.Rows.Count; i++)
            //{
            //    double soluong, dongia;
            //    soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongNhap"].ToString());
            //    dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();
            //    int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
            //    _ravi["ID_VTHH"] = iiDI_Vthh;
            //    cls.iID_VTHH = iiDI_Vthh;
            //    DataTable dtVT_vao = cls.SelectOne();
            //    _ravi["MaVT"] = iiDI_Vthh;
            //    _ravi["DonViTinh"] = cls.sDonViTinh.Value;
            //    _ravi["TenVTHH"] = cls.sTenVTHH.Value;
            //    _ravi["SoLuong"] = soluong;
            //    _ravi["DonGia"] = dongia;

            //    _ravi["ThanhTien"] = soluong * dongia;
            //    _ravi["HienThi"] = "1";
            //    _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
            //    dt2.Rows.Add(_ravi);
            //}

            gridControl2.DataSource = dtxxxx;
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
        
            clsGapDan_tbNhapKho_Temp cls = new CtyTinLuong.clsGapDan_tbNhapKho_Temp();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);         
            gridControl1.DataSource = dt;


        }
   

        KhoNPL_frmNPL _frmKNPL;
        public UCNPL_XuatKho_GapDan(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
        }

        private void UCNPL_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCNPL_XuatKho_GapDan_Load( sender,  e);
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                mbThemMoi = false;
                mbCopy = false;
                mbSua = true;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
                //_frmKNPL.Hide();
                ff.Show();
                //_frmKNPL.Show();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
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

        private void btCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                mbThemMoi = false;
                mbCopy = true;
                mbSua = false;
                miiID_NhapKhoGapDan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
                ff.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThai_XuatKho_NPL"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
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
                btLayDuLieu.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString() != "")
            {
                clsGapDan_tbNhapKho cls2xxxx = new clsGapDan_tbNhapKho();
                cls2xxxx.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                DataTable dt1 = cls2xxxx.SelectOne();
                if (cls2xxxx.bTrangThai_XuatKho_NPL.Value == true)
                {
                    MessageBox.Show("Đã gửi dữ liệu, không thể xoá");
                    return;

                }
                else
                {
                    DialogResult traloi;
                    traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (traloi == DialogResult.Yes)
                    {
                        clsGapDan_tbNhapKho cls1 = new clsGapDan_tbNhapKho();
                        cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());


                        cls1.Delete();
                        clsGapDan_ChiTiet_NhapKho cls2 = new clsGapDan_ChiTiet_NhapKho();
                        cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho).ToString());
                        cls2.Delete_ALL_W_ID_NhapKho();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                    }
                }

            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbCopy = false;
            mbSua = false;
            KhoNPL_frmChiTiet_XuatKho_gapDan ff = new KhoNPL_frmChiTiet_XuatKho_gapDan();
            //_frmKNPL.Hide();
            ff.Show();
            //_frmKNPL.Show();
        }
    }
}
