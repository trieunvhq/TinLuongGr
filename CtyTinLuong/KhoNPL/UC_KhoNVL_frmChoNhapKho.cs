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
    public partial class UC_KhoNVL_frmChoNhapKho : UserControl
    {
        //public static bool mb_TheMoi_DonHang;
        public static int miID_MuaHang_NhapKho;
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
        private void HienThiGridControl_2(int xxiDmuahang)
        {
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = xxiDmuahang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
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
                _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
                _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
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
        private void HienThi()
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                DateTime denngay = dteNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;
                clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
                DataTable dt = cls.SelectAll_HienThi_GridConTrol();
                dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'and CheckTraLaiNhaCungCap = False and GuiDuLieu=True and MuaHangNhapKho=True and TonTai= True and NgungTheoDoi=false and TrangThaiNhapKho=False";                
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = " GuiDuLieu ASC, NgayChungTu DESC, ID_MuaHang DESC";
                DataTable dxxxx = dv2.ToTable();
                gridControl1.DataSource = dxxxx;

            }

        }
        private void HienThi_ALL()
        {

            clsMH_tbMuaHang clsmuahang = new clsMH_tbMuaHang();
            DataTable dt2 = clsmuahang.SelectAll_HienThi_GridConTrol();
            dt2.DefaultView.RowFilter = "GuiDuLieu=True and MuaHangNhapKho=True and TonTai= True and NgungTheoDoi=false and TrangThaiNhapKho=False and CheckTraLaiNhaCungCap = False";
            //dt2.DefaultView.RowFilter = "GuiDuLieu=True and MuaHangNhapKho=True and TonTai= True and NgungTheoDoi=false and TrangThaiNhapKho=False and check_BaoVe = True and check_LaiXe=True";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_MuaHang DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
         
        }
        public UC_KhoNVL_frmChoNhapKho()
        {
            InitializeComponent();
        }

        private void UC_KhoNVL_frmChoNhapKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {
                    miID_MuaHang_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    KhoNPL_frmChiTiet_MuaHang_NhapKho ff = new KhoNPL_frmChiTiet_MuaHang_NhapKho();
                    ff.Show();
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

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            UC_KhoNVL_frmChoNhapKho_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
            {
                int iDImuahang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                HienThiGridControl_2(iDImuahang);
            }
        }
    }
}
