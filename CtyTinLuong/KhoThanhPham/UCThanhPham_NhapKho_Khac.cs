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
    public partial class UCThanhPham_NhapKho_Khac : UserControl
    {
        public static int miID_NhapKho;
        public static bool mbThemMoi_NhapKho;
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

            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = xxIID_NhapKho;
            DataTable dt3 = cls2.SelectAll_W_ID_NhapKho_HienThiDaNhapKho();
            DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID_ChiTietNhapKho"); // ID của tbChi tiet don hàng
            //dt2.Columns.Add("ID_NhapKho");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));
            if (dt3.Rows.Count == 0)
            {
                gridControl2.DataSource = null;
            }
            else
            {


                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongNhap"].ToString());
                    Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    //_ravi["ID_ChiTietNhapKho"] = dt3.Rows[i]["ID_ChiTietNhapKho"].ToString();
                    //_ravi["ID_NhapKho"] = dt3.Rows[i]["ID_NhapKho"].ToString();
                    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();

                    _ravi["SoLuong"] = xxsoluong;
                    _ravi["DonGia"] = xxdongia;
                    _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                    _ravi["HienThi"] = "1";
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    dt2.Rows.Add(_ravi);
                }
            }
            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {

            clsKhoThanhPham_tbNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbNhapKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and Check_NhapKho_Khac=True";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_NhapKho_ThanhPham DESC";
            DataTable dt = dv.ToTable();


            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable dt22 = dvxxx.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "DaNhapKho ASC, NgayChungTu DESC, ID_NhapKho_ThanhPham DESC";
            DataTable dxxxx = dv2.ToTable();

            gridControl1.DataSource = dxxxx;
          

        }
        private void HienThi_ALL()
        {
            clsKhoThanhPham_tbNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbNhapKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and Check_NhapKho_Khac=True";
            DataView dv = dt2.DefaultView;
            dv.Sort = "DaNhapKho ASC, NgayChungTu DESC, ID_NhapKho_ThanhPham DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }

        frmQuanLyKhoThanhPham _frmQLKTP;
        public UCThanhPham_NhapKho_Khac(frmQuanLyKhoThanhPham frmQLKTP)
        {
            _frmQLKTP = frmQLKTP;
            InitializeComponent();
        }

        private void UCThanhPham_NhapKho_Khac_Load(object sender, EventArgs e)
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
            UCThanhPham_NhapKho_Khac_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                Cursor.Current = Cursors.Default;
            }
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                mbThemMoi_NhapKho = false;
                miID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                KhoThanhPham_ChiTiet_NhapKho_Khac ff = new KhoThanhPham_ChiTiet_NhapKho_Khac();
                //_frmQLKTP.Hide();
                ff.Show();
                //_frmQLKTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaNhapKho"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_NhapKho = true;
            KhoThanhPham_ChiTiet_NhapKho_Khac ff = new KhoThanhPham_ChiTiet_NhapKho_Khac();
            //_frmQLKTP.Hide();
            ff.Show();
            //_frmQLKTP.Show();
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKho_ThanhPham).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
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

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
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
