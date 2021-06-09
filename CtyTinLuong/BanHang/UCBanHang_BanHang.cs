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
    public partial class UCBanHang_BanHang : UserControl
    {
       
        public static int miiiID_BanHang;

        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {

            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.SelectAll_w_TenKH();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'and TrangThai_KhoThanhPham= True";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = " TrangThai_KhoThanhPham ASC, NgayChungTu DESC, ID_BanHang DESC";
            DataTable dxxxx = dv2.ToTable();
            gridControl1.DataSource = dxxxx;


        }
        private void HienThi_ALL()
        {
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.SelectAll_w_TenKH();
            dt.DefaultView.RowFilter = " TrangThai_KhoThanhPham= True";
            DataView dv2 = dt.DefaultView;
            dv2.Sort = "TrangThaiBanHang ASC, NgayChungTu DESC, ID_BanHang DESC";
            DataTable dxxxx = dv2.ToTable();
            gridControl1.DataSource = dxxxx;
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
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuong"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietBanHang"] = dt3.Rows[i]["ID_ChiTietBanHang"].ToString();
                _ravi["ID_BanHang"] = dt3.Rows[i]["ID_BanHang"].ToString();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }

      
        public UCBanHang_BanHang()
        {
            InitializeComponent();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCBanHang_BanHang_Load(sender, e);
        }

        private void UCBanHang_BanHang_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

      
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{

            //    clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            //    cls.iID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
            //    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
            //    cls.Update_NgungTheoDoi();
            //}
            //catch
            //{

            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_BanHang).ToString() != "")
                {//msDienGiai
                    miiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                    BanHang_FrmChiTietBanHang_Newwwwwwww ff = new BanHang_FrmChiTietBanHang_Newwwwwwww();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["TrangThaiBanHang"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            clsBanHang_tbBanHang cls1 = new clsBanHang_tbBanHang();

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                cls1.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                cls1.Delete();
                clsBanHang_ChiTietBanHang cls2 = new clsBanHang_ChiTietBanHang();
                cls2.iID_BanHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                cls2.Delete_W_iID_BanHang();
                MessageBox.Show("Đã xóa");
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
                else
                    HienThi_ALL();

            }
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
            if (gridView1.GetFocusedRowCellValue(clID_BanHang).ToString() != "")
            {
                int xxxmiiiID_BanHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BanHang).ToString());
                HienThi_Gridcontrol_2(xxxmiiiID_BanHang);
            }
        }
    }
}
