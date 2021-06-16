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
    public partial class frmBaoCao_Nhap_Xuat_ton_kho_DaiLy : Form
    {
        private void Load_lockup()
        {
            clsTbDanhMuc_DaiLy cls = new CtyTinLuong.clsTbDanhMuc_DaiLy();
            DataTable dt = cls.SelectAll();
            gridMaDaiLy.Properties.DataSource = dt;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";
        }
        private void LoadDaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            DataTable dt_NhapTruoc= cls1.SA_distinct_NhapTruocKy(xxtungay);
            DataTable dt_NhapTrongKy = cls1.SA_distinct_NhapTrongKy(xxtungay, xxdenngay);

            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            DataTable dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(xxtungay);
            DataTable dt_XuatTrongKy=cls2.SA_distinct_XuatTrongKy(xxtungay, xxdenngay);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2.Columns.Add("GiaTriTon_CuoiKy", typeof(double));
            for (int i = 0; i < dt_NhapTrongKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                iiiiiID_VTHH = Convert.ToInt16(dt_NhapTrongKy.Rows[i]["ID_VTHH"].ToString());

                double SoLuong_TonDauKy, GiaTri_TonDauKy, SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                    SoLuongXuat_TrongKy, GiaTriXuat_TrongKy, SoLuongTon_CuoiKy, GiaTriTon_CuoiKy;

                SoLuongNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                GiaTriNhap_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                SoLuongXuat_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                GiaTriXuat_TrongKy = Convert.ToDouble(dt_NhapTrongKy.Rows[i]["GiaTriXuat_TrongKy"].ToString());

                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dt_NhapTruoc.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = 0;
                    GiaTri_TonDauKy = 0;
                }
                else
                {
                    SoLuong_TonDauKy = Convert.ToDouble(rows[0]["SoLuong_TonDauKy"].ToString());
                    GiaTri_TonDauKy = Convert.ToDouble(rows[0]["GiaTri_TonDauKy"].ToString());

                }
                SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiiiiID_VTHH;
                DataTable dtvt = clsvt.SelectOne();
                _ravi["MaVT"] = clsvt.sMaVT.Value;
                _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;

                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

                _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;

                dt2.Rows.Add(_ravi);

            }
        }
        public frmBaoCao_Nhap_Xuat_ton_kho_DaiLy()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load(object sender, EventArgs e)
        {
            Load_lockup();
            LoadDaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);


        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmBaoCao_Nhap_Xuat_ton_kho_DaiLy_Load( sender,  e);
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbDanhMuc_DaiLy clsncc = new clsTbDanhMuc_DaiLy();
                clsncc.iID_DaiLy = Convert.ToInt32(gridMaDaiLy.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                txtTenDaiLy.Text = dt.Rows[0]["TenDaiLy"].ToString();
            }
            catch
            {

            }
        }
    }
}
