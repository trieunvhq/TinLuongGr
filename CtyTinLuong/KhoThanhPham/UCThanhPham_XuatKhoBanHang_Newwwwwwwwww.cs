﻿using System;
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
    public partial class UCThanhPham_XuatKhoBanHang_Newwwwwwwwww : UserControl
    {

        public static int miiiID_BanHang;
        public static bool mbCopY, mbThemMoi, mbSua;
      
        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {

            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.SA_NgayThang_(false, xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
            dt.Dispose();
            cls.Dispose();

        }
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
        private void HienThi_Gridcontrol_2(int xxID_banHang)
        {
            clsBanHang_ChiTietBanHang cls = new clsBanHang_ChiTietBanHang();
            cls.iID_BanHang = xxID_banHang;
            DataTable dt3 = cls.Select_HienThiSuaDonHang();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietBanHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_BanHang");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[i]["SoLuong"].ToString());
                Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietBanHang"] = dt3.Rows[i]["ID_ChiTietBanHang"].ToString();
                _ravi["ID_BanHang"] = dt3.Rows[i]["ID_BanHang"].ToString();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }

        frmQuanLyKhoThanhPham _frmQLKTP;
        public UCThanhPham_XuatKhoBanHang_Newwwwwwwwww(frmQuanLyKhoThanhPham frmQLKTP)
        {
            _frmQLKTP = frmQLKTP;
            InitializeComponent();
        }

        private void UCThanhPham_XuatKhoBanHang_Newwwwwwwwww_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UCThanhPham_XuatKhoBanHang_Newwwwwwwwww_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }


        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopY = false;
            KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii ff = new KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            mbThemMoi = false;
            mbSua = false;
            mbCopY = true;
            KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii ff = new KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();
            cls1.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString());
            DataTable dt1 = cls1.SelectOne();
            if (cls1.bTrangThai_KhoThanhPham.Value == true)
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
                    Cursor.Current = Cursors.WaitCursor;
                    cls1.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString());
                    cls1.Delete();
                    clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                    cls2.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString());
                    cls2.Delete_W_iID_BanHang();

                    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã xóa");
                }
            }

        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString() != "")
            {
                mbThemMoi = false;
                mbSua = true;
                mbCopY = false;
                miiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString());

                KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii ff = new KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThai_KhoThanhPham"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString() != "")
            {
                int xxxmiiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang1).ToString());
                HienThi_Gridcontrol_2(xxxmiiiID_BanHang);
            }
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == clMaVT2)
            //{
            //    clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            //    cls.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
            //    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
            //    DataTable dt = cls.SelectOne();
            //    if (dt != null)
            //    {
            //        gridView4.SetRowCellValue(e.RowHandle, clID_VTHH2, kk);
            //        gridView4.SetRowCellValue(e.RowHandle, clTenVTHH2, dt.Rows[0]["TenVTHH"].ToString());
            //        gridView4.SetRowCellValue(e.RowHandle, clDonViTinh2, dt.Rows[0]["DonViTinh"].ToString());
            //        gridView4.SetRowCellValue(e.RowHandle, clHienThi2, "1");
                 
            //    }



            //}
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
                SendKeys.Send("{TAB}");
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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
    }
}
