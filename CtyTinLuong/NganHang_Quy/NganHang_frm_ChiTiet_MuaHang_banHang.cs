using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class NganHang_frm_ChiTiet_MuaHang_banHang : Form
    {
        public NganHang_frm_ChiTiet_MuaHang_banHang()
        {
            InitializeComponent();
        }

        private void NganHang_frm_ChiTiet_MuaHang_banHang_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = null;
            //clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            //cls2.iID_MuaHang = xxiDmuahang;
            //DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            //DataTable dt2 = new DataTable();

            //dt2.Columns.Add("SoLuong", typeof(float));
            //dt2.Columns.Add("DonGia", typeof(double));
            //dt2.Columns.Add("MaVT");
            //dt2.Columns.Add("TenVTHH");
            //dt2.Columns.Add("DonViTinh");
            //dt2.Columns.Add("ThanhTien", typeof(double));
            //dt2.Columns.Add("HienThi", typeof(string));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuong"].ToString());
            //    Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
            //    DataRow _ravi = dt2.NewRow();

            //    _ravi["SoLuong"] = xxsoluong;
            //    _ravi["DonGia"] = xxdongia;
            //    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
            //    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
            //    _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
            //    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
            //    _ravi["HienThi"] = "1";
            //    dt2.Rows.Add(_ravi);
            //}

            //gridControl1.DataSource = dt2;
        }
    }
}
