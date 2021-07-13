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
    public partial class UCChoNhapKho_DaiLy_new : UserControl
    {
        public static int miID_NhapKhoDaiLy;
        private void HienThiGridControl_2(int xxID_nhapkho)
        {

            DataTable dt2 = new DataTable();
            clsDaiLy_tbChiTietNhapKho_Temp cls2 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho_Temp();
            cls2.iID_NhapKhoDaiLy = xxID_nhapkho;
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi();          
            gridControl3.DataSource = dtxxxx;
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbNhapKho_Temp cls = new clsDaiLy_tbNhapKho_Temp();
            DataTable dtxx = cls.SA_NgayThang_ChoGhiSo(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxx;
            
        }
        private void Luu_ChiTiet_NhapKho_DaiLy(int iiiID_NhapKhoDaiLy)
        {
            clsDaiLy_tbChiTietNhapKho_Temp cls = new clsDaiLy_tbChiTietNhapKho_Temp();
            cls.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
            DataTable dttttt2 = cls.SelectAll_W_ID_NhapKhoDaiLy_Moi();
            if (dttttt2.Rows.Count > 0)
            {
                clsDaiLy_tbChiTietNhapKho cls2 = new clsDaiLy_tbChiTietNhapKho();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_NhapKhoDaiLy = iiiID_NhapKhoDaiLy;
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_DaiLy = Convert.ToInt32(dttttt2.Rows[i]["ID_DaiLy"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongNhap = Convert.ToDouble(dttttt2.Rows[i]["SoLuongNhap"].ToString());
                    cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuongTon"].ToString());
                    cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaNhapKho = false;
                    cls2.bBoolTonDauKy = false;
                    cls2.Insert();
                }
            }
            
        }
        private string sochungtunhapkho_DaiLy()
        {
            string sochungtu = "";
            clsDaiLy_tbNhapKho cls = new clsDaiLy_tbNhapKho();
            DataTable dt = cls.SelectAll();
            int k = dt.Rows.Count;
            if (dt.Rows.Count == 0)
                sochungtu = "NKDL 1";
            else
            {
              
                string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "NKDL " + xxx2 + "";
            }
          
            return sochungtu;
            
        }
        private void Luu_NhapKhoDaiLy(int xxxID_NhapKhoDaiLy)
        {

            clsDaiLy_tbNhapKho_Temp clsxx = new clsDaiLy_tbNhapKho_Temp();
            clsxx.iID_NhapKhoDaiLy = xxxID_NhapKhoDaiLy;
            DataTable dt1 = clsxx.SelectOne();
            
            clsDaiLy_tbNhapKho cls1 = new clsDaiLy_tbNhapKho();
            cls1.iID_NhapKhoDaiLy = xxxID_NhapKhoDaiLy;
            cls1.daNgayChungTu = clsxx.daNgayChungTu;
            cls1.sSoChungTu = sochungtunhapkho_DaiLy();
            cls1.fTongTienHang = clsxx.fTongTienHang;
            cls1.iID_DaiLy = clsxx.iID_DaiLy;
            cls1.sDienGiai = clsxx.sDienGiai;
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            cls1.fSoLuongXuat_BaoTo = clsxx.fSoLuongXuat_BaoTo;
            cls1.fSoLuongXuat_BaoBe = clsxx.fSoLuongXuat_BaoBe;
            cls1.iID_DinhMucDot_BaoTo = clsxx.iID_DinhMucDot_BaoTo;
            cls1.iID_DinhMucDot_BaoBe = clsxx.iID_DinhMucDot_BaoBe;
            cls1.fSoLuongThanhPhamQuyDoi = clsxx.fSoLuongThanhPhamQuyDoi;
            cls1.fSoLuongTonThanhPhamQuyDoi = clsxx.fSoLuongTonThanhPhamQuyDoi;
            cls1.iID_DinhMucNguenPhuLieu = clsxx.iID_DinhMucNguenPhuLieu;
            cls1.iID_VTHH_TPQuyDoi = clsxx.iID_VTHH_TPQuyDoi;
            cls1.sGhiChu = clsxx.sGhiChu;
            cls1.iID_NguoiNhap = clsxx.iID_NguoiNhap;
            cls1.bHoanThanh = false;

            cls1.bTrangThaiXuatNhap_KhoDaiLy = true;
            cls1.bTrangThaiXuatNhap_Kho_BTP = false;
            cls1.bTrangThaiXuatNhap_Kho_NPL = true;
            cls1.sThamChieu = clsxx.sThamChieu;
            cls1.bCheck_BaoVe = false;
            cls1.bCheck_DaiLy = false;
            cls1.bCheck_LaiXe = false;
            cls1.bDaNhapKho = true;
            cls1.bBool_TonDauKy = false;
            cls1.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = clsxx.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0;
            cls1.Insert();
            int iiID_Nhapkho;
            iiID_Nhapkho = cls1.iID_NhapKhoDaiLy.Value;          
            Luu_ChiTiet_NhapKho_DaiLy(iiID_Nhapkho);

            // update temp tbdaily_nhapkho
            clsxx = new clsDaiLy_tbNhapKho_Temp();
            clsxx.iID_NhapKhoDaiLy = xxxID_NhapKhoDaiLy;
            clsxx.Update_TrangThaiXuatNhap_KhoDaiLy();
        }
     
        public UCChoNhapKho_DaiLy_new()
        {
            InitializeComponent();
        }

        public void UCChoNhapKho_DaiLy_new_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-60);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCChoNhapKho_DaiLy_new_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy) != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_NhapKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                DaiLy_ChiTietChoNhapKho_Moi ff = new DaiLy_ChiTietChoNhapKho_Moi(this);                
                ff.Show();
            }

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy) != null)
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }
        
        private void btNhapKho_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy) != null)
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoDaiLy).ToString());
                Luu_NhapKhoDaiLy(iiIDnhapKhp);
                MessageBox.Show("Đã nhập kho đại lý");
                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
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
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
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
        private void gridView4_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
    }
}
