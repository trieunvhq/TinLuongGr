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
    public partial class UC_ChoXuatKho_DaiLy_new : UserControl
    {
        public static int miID_XuatKhoDaiLy;
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
        private void HienThiGridControl_2(int xxID_Xuatkho_)
        {

            DataTable dt2 = new DataTable();
            clsDaiLy_tbChiTietXuatKho_Temp cls2 = new CtyTinLuong.clsDaiLy_tbChiTietXuatKho_Temp();          
            DataTable dtxxxx = cls2.SelectAll_W_ID_NhapKhoDaiLy_Moi(xxID_Xuatkho_);
            gridControl3.DataSource = dtxxxx;
        }
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbXuatKho_Temp cls = new clsDaiLy_tbXuatKho_Temp();
            DataTable dtxx = cls.SA_NgayThang_ChoXuatKho(xxtungay, xxdenngay);
            gridControl1.DataSource = dtxx;

        }
        private void Luu_ChiTiet_XuatKho_DaiLy(int xxID_Xuatkho_)
        {
            clsDaiLy_tbChiTietXuatKho_Temp cls = new clsDaiLy_tbChiTietXuatKho_Temp();            
            DataTable dttttt2 = cls.SA_W_ID_XuatKhoDaiLy(xxID_Xuatkho_);
            if (dttttt2.Rows.Count > 0)
            {
                clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKhoDaiLy = xxID_Xuatkho_;
                    cls2.iID_DaiLy = Convert.ToInt32(dttttt2.Rows[i]["ID_DaiLy"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());                   
                    cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bDaXuatKho = true;
                    cls2.iNhapKho_TP_1_BTP_2_NPL_3 = Convert.ToInt32(dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString());
                    cls2.Insert();
                }

              
            }

        }
        private string sochungtu_Xuatkho_DaiLy()
        {
            string sochungtu = "";
            clsDaiLy_tbXuatKho cls = new clsDaiLy_tbXuatKho();
            DataTable dt = cls.SelectAll();
            int k = dt.Rows.Count;
            if (dt.Rows.Count == 0)
                sochungtu = "XKDL 1";
            else
            {

                string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(4).Trim()) + 1;
                sochungtu = "XKDL " + xxx2 + "";
            }

            return sochungtu;

        }
        private void Luu_ThamCHieuTinhXuatKho(int iiiiID_XuatKhoDaiLy)
        {
            clsDaiLy_ThamChieu_TinhXuatKho_Temp clsxx = new clsDaiLy_ThamChieu_TinhXuatKho_Temp();
            DataTable dtthamchieu = clsxx.SA_W_ID_XuatKhoDaiLy(iiiiID_XuatKhoDaiLy);
            if(dtthamchieu.Rows.Count>0)
            {
                clsDaiLy_ThamChieu_TinhXuatKho cls = new CtyTinLuong.clsDaiLy_ThamChieu_TinhXuatKho();
                for(int i=0; i< dtthamchieu.Rows.Count; i++)
                {
                    int xxiID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls.iID_NhapKhoDaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_NhapKhoDaiLy"].ToString());
                    cls.iID_DaiLy = Convert.ToInt32(dtthamchieu.Rows[i]["ID_DaiLy"].ToString());
                    cls.iID_XuatKhoDaiLy = iiiiID_XuatKhoDaiLy;
                    cls.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH"].ToString());
                    cls.fSoLuongThanhPhamQuyDoi = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                    cls.fSoLuongNhap = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongNhap"].ToString());
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.fDonGia = Convert.ToDouble(dtthamchieu.Rows[i]["DonGia"].ToString());
                    cls.Insert();
                }
            }
           
                
        }
        private void Luu_XuatKhoDaiLy(int xxxID_XuatKhoDaiLy)
        {

            clsDaiLy_tbXuatKho_Temp clsxx = new clsDaiLy_tbXuatKho_Temp();
            clsxx.iID_XuatKhoDaiLy = xxxID_XuatKhoDaiLy;
            DataTable dt1 = clsxx.SelectOne();

            clsDaiLy_tbXuatKho cls1 = new clsDaiLy_tbXuatKho();           
          
            cls1.daNgayChungTu = clsxx.daNgayChungTu;
            cls1.sSoChungTu = sochungtu_Xuatkho_DaiLy();
            cls1.iID_VTHH = clsxx.iID_VTHH;

            cls1.fSoLuongThanhPhamQuyDoi = clsxx.fSoLuongThanhPhamQuyDoi; ;

            cls1.fDonGia = clsxx.fDonGia;
          
            cls1.fTongTienHang = clsxx.fTongTienHang;
            cls1.sDienGiai = clsxx.sDienGiai;
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;

            cls1.iID_NguoiNhap = clsxx.iID_NguoiNhap;
            cls1.iID_DaiLy = clsxx.iID_DaiLy;
            cls1.bCheck_BaoVe = false;
            cls1.bCheck_DaiLy = false;
            cls1.bCheck_LaiXe = false;
            cls1.bTrangThaiXuatNhap_ThanhPham_TuDaiLyVe = true;
            cls1.bTrangThai_XuatKho_DaiLy_GuiDuLieu = true;
            cls1.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False = clsxx.bCheckNhapKho_ThanhPham_True_nhapKhoBTP_False;
            cls1.bDaXuatKho = true;
            cls1.sGhiChu = clsxx.sGhiChu;

            //cls1.iHangDoT_1_hangNhu_2_ConLai3 = clsxx
           
            cls1.Insert();
         

            int iiID_Xuatkho;
            iiID_Xuatkho = cls1.iID_XuatKhoDaiLy.Value;
            Luu_ChiTiet_XuatKho_DaiLy(iiID_Xuatkho);

            // update temp tbdaily_nhapkho
            clsxx = new clsDaiLy_tbXuatKho_Temp();
        
            clsxx.Update_GuiDuLieu(xxxID_XuatKhoDaiLy);
        }

        public UC_ChoXuatKho_DaiLy_new()
        {
            InitializeComponent();
        }

        public void UC_ChoXuatKho_DaiLy_new_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = DateTime.Today.AddDays(-30);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UC_ChoXuatKho_DaiLy_new_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    miID_XuatKhoDaiLy = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                    DaiLy_ChiTietChoXuatKho_Moi ff = new DaiLy_ChiTietChoXuatKho_Moi(this);
                    ff.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch { } 
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btNhapKho_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString() != "")
            {
                int iiiID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoDaiLy).ToString());
                Luu_XuatKhoDaiLy(iiiID);
                Luu_ThamCHieuTinhXuatKho(iiiID);
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
