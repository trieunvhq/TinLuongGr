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
    public partial class BanHang_frmChiTietMotVatTu : Form
    {
        private void HienThi(int xxID_VTHH, DateTime xxtungay, DateTime xxdenngay)
        {

            DataTable dt2 = new DataTable();

            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("TenKH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectAll_W_ID_VTHH_SoChungTu_NgayThang_DienGiai_ID_KH();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "NgayChungTu DESC";
            DataTable dxxxx = dv2.ToTable();
            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                double DonGia = Convert.ToDouble(dxxxx.Rows[i]["DonGia"].ToString());
                double SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuong"].ToString());
                int iID_KhachHangccc = Convert.ToInt32(dxxxx.Rows[i]["ID_KhachHang"].ToString());
                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = iID_KhachHangccc;
                DataTable dtncc = clsncc.SelectOne();
                DataRow _ravi = dt2.NewRow();

                _ravi["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                _ravi["SoLuong"] = SoLuong;
                _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                _ravi["DonGia"] = DonGia;
                _ravi["ThanhTien"] = SoLuong * DonGia;
                _ravi["TenKH"] = clsncc.sTenKH.Value;
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;


        }
        private void HienThi_ALL(int xxID_VTHH)
        {
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("SoChungTu", typeof(string));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("TenKH", typeof(string));
            //TenNhaCungCap

            clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dxxxx = cls.SelectAll_W_ID_VTHH_SoChungTu_NgayThang_DienGiai_ID_KH();

            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                double DonGia = Convert.ToDouble(dxxxx.Rows[i]["DonGia"].ToString());
                double SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuong"].ToString());
                int iID_KhachHangccc = Convert.ToInt32(dxxxx.Rows[i]["ID_KhachHang"].ToString());
                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = iID_KhachHangccc;
                DataTable dtncc = clsncc.SelectOne();
                DataRow _ravi = dt2.NewRow();
                _ravi["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                _ravi["SoLuong"] = SoLuong;
                _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                _ravi["DonGia"] = DonGia;
                _ravi["ThanhTien"] = SoLuong * DonGia;
                _ravi["TenKH"] = clsncc.sTenKH.Value;
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;


        }

        private void Load_Lockup()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));

            clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang();
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtdistin = cls.SelectAll_Distint_ID_VTHH();
            if (dtdistin.Rows.Count > 0)
            {
                for (int i = 0; i < dtdistin.Rows.Count; i++)
                {

                    int iiiID_VTHH = Convert.ToInt32(dtdistin.Rows[i]["ID_VTHH"].ToString());
                    clsvthhh.iID_VTHH = iiiID_VTHH;
                    DataTable dt = clsvthhh.SelectOne();
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiID_VTHH;
                    _ravi["MaVT"] = clsvthhh.sMaVT.Value;
                    _ravi["TenVTHH"] = clsvthhh.sTenVTHH.Value;
                    dt2.Rows.Add(_ravi);
                }
            }




            gridMaVT.Properties.DataSource = dt2;
            gridMaVT.Properties.ValueMember = "ID_VTHH";
            gridMaVT.Properties.DisplayMember = "MaVT";
        }
        public BanHang_frmChiTietMotVatTu()
        {
            InitializeComponent();
        }

        private void BanHang_frmChiTietMotVatTu_Load(object sender, EventArgs e)
        {
            Load_Lockup();
            gridMaVT.EditValue = UCBanHang_ChiTiet_ALL.miID_VTHH;
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL(UCBanHang_ChiTiet_ALL.miID_VTHH);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                int iiID = Convert.ToInt32(gridMaVT.EditValue.ToString());
                cls.iID_VTHH = iiID;
                DataTable dt = cls.SelectOne();
                txtTenVT.Text = cls.sTenVTHH.Value;
                txtDVT.Text = cls.sDonViTinh.Value;
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    HienThi(iiID, dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
                else
                    HienThi_ALL(iiID);
            }
            catch
            { }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_frmChiTietMotVatTu_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int iiID = Convert.ToInt32(gridMaVT.EditValue.ToString());
                HienThi(iiID, dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
