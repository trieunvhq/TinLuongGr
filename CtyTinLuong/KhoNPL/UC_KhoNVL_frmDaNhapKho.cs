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
    public partial class UC_KhoNVL_frmDaNhapKho : UserControl
    {
        public static int miD_NhapKho;
        public static string msThamChieuMuaHang;
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
        private void HienThiGridControl_2(int xxIID_NhapKho)
        {
            
            clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
            //cls2.iID_NhapKho = xxIID_NhapKho;
            DataTable dt3 = cls2.H_NPL_CTNK_SO_ID_NK(xxIID_NhapKho);
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_ChiTietNhapKho"); // ID của tbChi tiet don hàng
            //dt2.Columns.Add("ID_NhapKho");
            //dt2.Columns.Add("ID_VTHH");
            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(decimal));

            //dt2.Columns.Add("MaVT");// tb VTHH
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("GhiChu");

            //dt2.Columns.Add("ThanhTien", typeof(decimal));
            //dt2.Columns.Add("HienThi", typeof(string));

            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuongNhap"].ToString());
            //    Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();
            //    _ravi["ID_ChiTietNhapKho"] = dt3.Rows[i]["ID_ChiTietNhapKho"].ToString();
            //    _ravi["ID_NhapKho"] = dt3.Rows[i]["ID_NhapKho"].ToString();
            //    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();

            //    _ravi["SoLuong"] = xxsoluong;
            //    _ravi["DonGia"] = xxdongia;
            //    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
            //    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
            //    _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
            //    _ravi["HienThi"] = "1";
            //    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
            //    dt2.Rows.Add(_ravi);
            //}
           
            gridControl2.DataSource = dt3;
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
           

                clsKhoNPL_tbNhapKho cls = new CtyTinLuong.clsKhoNPL_tbNhapKho();
                DataTable dt2xx = cls.H_NPL_NhapKho_SA_NgayThang(xxtungay,xxdenngay);
                //dt2xx.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
                //DataView dv22xxx = dt2xx.DefaultView;
                //dv22xxx.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
                //DataTable dt = dv22xxx.ToTable();            

                //dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                //DataView dvxxx = dt.DefaultView;
                //DataTable dt22 = dvxxx.ToTable();
                //dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                //DataView dv2 = dt22.DefaultView;
                //dv2.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
                //DataTable dxxxx = dv2.ToTable();

                gridControl1.DataSource = dt2xx;
          
        }
      
        KhoNPL_frmNPL _frmKNPL;
        public UC_KhoNVL_frmDaNhapKho(KhoNPL_frmNPL frmKNPL)
        {
            _frmKNPL = frmKNPL;
            InitializeComponent();
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
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
                {
                    msThamChieuMuaHang = gridView1.GetFocusedRowCellValue(clThamChieu).ToString();
                    miD_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
                    KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang ff = new KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang(this);
                    //_frmKNPL.Hide();
                    ff.Show();
                    //_frmKNPL.Show();
                }
            }
            catch
            {

            }
        }

        public void UC_KhoNVL_frmDaNhapKho_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_KhoNVL_frmDaNhapKho_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_DaTa(dteTuNgay.DateTime,dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
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

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
                    cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());


                    cls1.Delete();
                    clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
                    cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
                    cls2.Delete_ALL_W_ID_NhapKho();
                    MessageBox.Show("Đã xóa");
                    
                        Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                  
                }


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
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            { }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            { }
        }
    }
}
