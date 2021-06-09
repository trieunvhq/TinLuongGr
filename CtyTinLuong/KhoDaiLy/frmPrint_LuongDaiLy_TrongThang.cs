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
    public partial class frmPrint_LuongDaiLy_TrongThang : Form
    {
        public frmPrint_LuongDaiLy_TrongThang()
        {
            InitializeComponent();
        }

        private void frmPrint_LuongDaiLy_TrongThang_Load(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            dt3 = frmChiTietLuong_DaiLy.mdtPrint_TraLuong_DaiLy;
            XtraDaiLy_ChiTietLuong xtr111 = new XtraDaiLy_ChiTietLuong();
            DataTable mdt_TraLuong_DaiLy = new DataTable();          
            mdt_TraLuong_DaiLy.Columns.Add("NgayChungTu", typeof(DateTime));
            mdt_TraLuong_DaiLy.Columns.Add("SoLuongXuat", typeof(double));
            mdt_TraLuong_DaiLy.Columns.Add("DonGia", typeof(double));
            mdt_TraLuong_DaiLy.Columns.Add("TongTienHang", typeof(double));
            mdt_TraLuong_DaiLy.Columns.Add("MaDaiLy", typeof(string));
            mdt_TraLuong_DaiLy.Columns.Add("TenDaiLy", typeof(string));
            mdt_TraLuong_DaiLy.Columns.Add("MaVT", typeof(string));
            mdt_TraLuong_DaiLy.Columns.Add("TenVTHH", typeof(string));
            mdt_TraLuong_DaiLy.Columns.Add("DonViTinh", typeof(string));          

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLuongDaiLy.Clone();
            ds.tbLuongDaiLy.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbLuongDaiLy.NewRow();                          
                _ravi["NgayChungTu"] = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                _ravi["SoLuongXuat"] = Convert.ToDouble(dt3.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["TongTienHang"] = Convert.ToDouble(dt3.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString()) * Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                //_ravi["MaDaiLy"] = "" + dt3.Rows[i]["MaDaiLy"].ToString() + ": ";
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
             
                ds.tbLuongDaiLy.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLuongDaiLy;
            xtr111.DataMember = "tbLuongDaiLy";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
