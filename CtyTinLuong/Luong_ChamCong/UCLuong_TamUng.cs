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
    public partial class UCLuong_TamUng : UserControl
    {
        public static int miiiiID_TamUng;
        public static bool mbThemMoiTamUng;
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
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                //DateTime ngaydautien, ngaycuoicung;
                //// DateTime ngayhomnay = 
                //int thang = Convert.ToInt16(txtThang.Text.ToString());
                //int nam = Convert.ToInt16(txtNam.Text.ToString());
                //ngaydautien = GetFistDayInMonth(nam, thang);
                //ngaycuoicung = GetLastDayInMonth(nam, thang);
                //clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
                //DataTable dt = cls.SelectAll_W_tenNhanVien();
                //dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                //DataView dv = dt.DefaultView;
                //dv.Sort = "NgayChungTu DESC";
                //DataTable dxxxx = dv.ToTable();
                //dxxxx.DefaultView.RowFilter = " NgayChungTu<='" + ngaycuoicung + "'";
                //DataView dvxx = dxxxx.DefaultView;
                //DataTable dt22xxx = dvxx.ToTable();
                //dt22xxx.DefaultView.RowFilter = " NgayChungTu>='" + ngaydautien + "'";
                //gridControl1.DataSource = dt22xxx;
            }


        }
        private void HienThi_ALL()
        {
            //clsHUU_CongNhat_TamUng cls = new CtyTinLuong.clsHUU_CongNhat_TamUng();
            //DataTable dt = cls.SelectAll_W_tenNhanVien();
            //dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            //DataView dv = dt.DefaultView;
            //dv.Sort = "NgayChungTu DESC";
            //DataTable dxxxx = dv.ToTable();
            //gridControl1.DataSource = dxxxx;
        }
        public UCLuong_TamUng()
        {
            InitializeComponent();
        }

        private void UCLuong_TamUng_Load(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;           
            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
           
            txtNam.Text = nam.ToString();
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCLuong_TamUng_Load( sender,  e);
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
            if (gridView1.GetFocusedRowCellValue(ID_TamUng).ToString() != "")
            {
                mbThemMoiTamUng = false;
                miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
                TamUng_new ff = new CtyTinLuong.TamUng_new();
                ff.Show();
            }
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                HienThi();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoiTamUng = true;
            //miiiiID_TamUng = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TamUng).ToString());
            TamUng_new ff = new CtyTinLuong.TamUng_new();
            ff.Show();
        }
    }
}
