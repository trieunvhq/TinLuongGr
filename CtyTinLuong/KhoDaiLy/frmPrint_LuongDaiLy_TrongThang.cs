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
        private void Print_DaiLy_BangLuong_ALL(DataTable dt3)
        {
            XtraDaiLy_ChiTietLuong xtr111 = new XtraDaiLy_ChiTietLuong();           
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
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
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
        private void Print_DaiLy_BangLuong_RutGon(DataTable dt3)
        {
            XtraDaiLy_Luong_RutGon xtr111 = new XtraDaiLy_Luong_RutGon();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLuongDaiLy.Clone();
            ds.tbLuongDaiLy.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbLuongDaiLy.NewRow();
                _ravi["STT"] = (i+1).ToString();
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();                
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                _ravi["TongLuong"] = Convert.ToDouble(dt3.Rows[i]["TongTien"].ToString());
                _ravi["TamUng"] = Convert.ToDouble(dt3.Rows[i]["SoTien_TamUng"].ToString());
                _ravi["ThucNhan"] = Convert.ToDouble(dt3.Rows[i]["ThucNhan"].ToString());
                ds.tbLuongDaiLy.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLuongDaiLy;
            xtr111.DataMember = "tbLuongDaiLy";          
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void frmPrint_LuongDaiLy_TrongThang_Load(object sender, EventArgs e)
        {
            if (DaiLy_BangLuong.mbPrint_ALL == true)
                Print_DaiLy_BangLuong_ALL(DaiLy_BangLuong.mdtPrint);
            if (DaiLy_BangLuong.mbPrint_RutGon == true)
                Print_DaiLy_BangLuong_RutGon(DaiLy_BangLuong.mdtPrint);
        }

        private void frmPrint_LuongDaiLy_TrongThang_FormClosed(object sender, FormClosedEventArgs e)
        {
            DaiLy_BangLuong.mbPrint_ALL = false;
            DaiLy_BangLuong.mbPrint_RutGon = false;
        }
    }
}
