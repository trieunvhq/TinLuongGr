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
    public partial class UCBanThanhPham_NhapKho_Khac : UserControl
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

            clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
            cls2.iID_NhapKho = xxIID_NhapKho;
            DataTable dt3 = cls2.SelectAll_W_ID_NhapKho();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongNhap"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHHxx;
                DataTable dtvj = cls.SelectOne();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = cls.sMaVT.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            clsKhoBTP_tbNhapKho cls = new CtyTinLuong.clsKhoBTP_tbNhapKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and Check_NhapKho_Khac=True";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_NhapKhoBTP DESC";
            DataTable dt = dv.ToTable();


            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable dt22 = dvxxx.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "NgayChungTu DESC, ID_NhapKhoBTP DESC";
            DataTable dxxxx = dv2.ToTable();

            gridControl1.DataSource = dxxxx;


        }
        private void HienThi_ALL()
        {
            clsKhoBTP_tbNhapKho cls = new CtyTinLuong.clsKhoBTP_tbNhapKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and Check_NhapKho_Khac=True";
            DataView dv = dt2.DefaultView;
            dv.Sort = "DaNhapKho ASC, NgayChungTu DESC, ID_NhapKhoBTP DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }

        frmQuanLyKhoBanThanhPham _frmKBTP;
        public UCBanThanhPham_NhapKho_Khac(frmQuanLyKhoBanThanhPham frmKBTP)
        {
            _frmKBTP = frmKBTP;
            InitializeComponent();
        }

        private void UCBanThanhPham_NhapKho_Khac_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCBanThanhPham_NhapKho_Khac_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                mbThemMoi_NhapKho = false;
                miID_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                KhoBTP_ChiTiet_NhapKho_Khac ff = new KhoBTP_ChiTiet_NhapKho_Khac();
                _frmKBTP.Hide();
                ff.ShowDialog();
                _frmKBTP.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_NhapKho = true;
            KhoBTP_ChiTiet_NhapKho_Khac ff = new KhoBTP_ChiTiet_NhapKho_Khac();
            _frmKBTP.Hide();
            ff.ShowDialog();
            _frmKBTP.Show();
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
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoBTP_tbNhapKho cls1 = new clsKhoBTP_tbNhapKho();
                    cls1.iID_NhapKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());


                    cls1.Delete();
                    clsKhoBTP_tbChiTietNhapKho cls2 = new clsKhoBTP_tbChiTietNhapKho();
                    cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoBTP).ToString());
                    cls2.Delete_ALL_W_ID_NhapKho();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    else HienThi_ALL();
                }


            }
        }
    }
}
