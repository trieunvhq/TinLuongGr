using DevExpress.Data.Filtering;
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
    public partial class SanXuat_frmChiTietSoPhieu_RutGon : Form
    {
        public static DataTable mdtPrint_tbChiTietPhieu;
        public static string xxsotrang;
        public static DateTime mdatungay, mdadenngay;

        private int _SoTrang = 1;
        private bool isload = false;
        public void LoadData(int sotrang, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            isload = true;          
            _SoTrang = sotrang;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));

            dt2.Columns.Add("ID_VTHH_Vao_IN", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra_IN", typeof(string));
            dt2.Columns.Add("MaVT_Vao_IN", typeof(string));
            dt2.Columns.Add("MaVT_Ra_IN", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao_IN", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra_IN", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao_IN", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra_IN", typeof(string));
            dt2.Columns.Add("SoLuong_Vao_IN", typeof(string));
            dt2.Columns.Add("SoLuong_Ra_IN", typeof(string));
            dt2.Columns.Add("PhePham_IN", typeof(string));
            dt2.Columns.Add("NgaySanXuat_IN", typeof(string));
            dt2.Columns.Add("CaSanXuat_IN", typeof(string));
            dt2.Columns.Add("CongNhan_IN", typeof(string));
            dt2.Columns.Add("MaMay_IN", typeof(string));

            dt2.Columns.Add("ID_VTHH_Vao_CAT", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra_CAT", typeof(string));
            dt2.Columns.Add("MaVT_Vao_CAT", typeof(string));
            dt2.Columns.Add("MaVT_Ra_CAT", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao_CAT", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra_CAT", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao_CAT", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra_CAT", typeof(string));
            dt2.Columns.Add("SoLuong_Vao_CAT", typeof(string));
            dt2.Columns.Add("SoLuong_Ra_CAT", typeof(string));
            dt2.Columns.Add("PhePham_CAT", typeof(string));
            dt2.Columns.Add("NgaySanXuat_CAT", typeof(string));
            dt2.Columns.Add("CaSanXuat_CAT", typeof(string));
            dt2.Columns.Add("CongNhan_CAT", typeof(string));
            dt2.Columns.Add("MaMay_CAT", typeof(string));

            dt2.Columns.Add("ID_VTHH_Vao_DOT", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra_DOT", typeof(string));
            dt2.Columns.Add("MaVT_Vao_DOT", typeof(string));
            dt2.Columns.Add("MaVT_Ra_DOT", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao_DOT", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra_DOT", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao_DOT", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra_DOT", typeof(string));
            dt2.Columns.Add("SoLuong_Vao_DOT", typeof(string));
            dt2.Columns.Add("SoLuong_Ra_DOT", typeof(string));
            dt2.Columns.Add("PhePham_DOT", typeof(string));
            dt2.Columns.Add("NgaySanXuat_DOT", typeof(string));
            dt2.Columns.Add("CaSanXuat_DOT", typeof(string));
            dt2.Columns.Add("CongNhan_DOT", typeof(string));
            dt2.Columns.Add("MaMay_DOT", typeof(string));

            clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();
            clsTbVatTuHangHoa clsVT_Ra = new clsTbVatTuHangHoa();
            clsNhanSu_tbNhanSu clsnhansu = new clsNhanSu_tbNhanSu();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            clsPhieu_tbPhieu clsphieu = new clsPhieu_tbPhieu();
            clsT_MayMoc clsmaymoc = new clsT_MayMoc();
            DataTable dtphieu = clsphieu.SelectAll_Load_DaTa_Day(_SoTrang, xxtungay, xxdenngay);


            if (dtphieu.Rows.Count > 0)
            {
                for (int i = 0; i < dtphieu.Rows.Count; i++)
                {

                    int ID_SoPhieu = Convert.ToInt32(dtphieu.Rows[i]["ID_SoPhieu"].ToString());

                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_SoPhieu"] = ID_SoPhieu;
                    _ravi["MaPhieu"] = dtphieu.Rows[i]["MaPhieu"].ToString();

                    cls.iID_SoPhieu = ID_SoPhieu;
                   
                    
                    DataTable dtmaycat = cls.SelectAll_W_iID_SoPhieu_May_CAT();
                    DataTable dtmaydot = cls.SelectAll_W_iID_SoPhieu_May_DOT(); 
                    DataTable dtmayin = cls.SelectAll_W_iID_SoPhieu_May_IN();
                    if (dtmayin.Rows.Count > 0)
                    {
                        int ID_CongNhan = Convert.ToInt32(dtmayin.Rows[0]["ID_CongNhan"].ToString());
                        clsnhansu.iID_NhanSu = ID_CongNhan;
                        DataTable dtnhansu = clsnhansu.SelectOne();
                        string CongNhan = clsnhansu.sTenNhanVien.Value;
                        DateTime daNgaySanXuat = Convert.ToDateTime(dtmayin.Rows[0]["NgaySanXuat"].ToString());
                        string NgaySanXuat = daNgaySanXuat.ToString("dd/MM/yyyy");
                        string CaSanXuat = dtmayin.Rows[0]["CaSanXuat"].ToString();
                        int ID_VTHH_Vao = Convert.ToInt32(dtmayin.Rows[0]["ID_VTHH_Vao"].ToString());
                        clsVT_Vao.iID_VTHH = ID_VTHH_Vao;
                        DataTable dtvtvao = clsVT_Vao.SelectOne();
                        string MaVT_Vao = clsVT_Vao.sMaVT.Value;
                        string DonViTinh_Vao = clsVT_Vao.sDonViTinh.Value;
                        string TenVatTu_Vao = clsVT_Vao.sTenVTHH.Value;
                        double SoLuong_Vao = Convert.ToDouble(dtmayin.Rows[0]["SoLuong_Vao"].ToString());
                        int ID_VTHH_Ra = Convert.ToInt32(dtmayin.Rows[0]["ID_VTHH_Ra"].ToString());
                        clsVT_Ra.iID_VTHH = ID_VTHH_Ra;
                        DataTable dtvt_Ra = clsVT_Ra.SelectOne();
                        string MaVT_Ra = clsVT_Ra.sMaVT.Value;
                        string DonViTinh_Ra = clsVT_Ra.sDonViTinh.Value;
                        string TenVatTu_Ra = clsVT_Ra.sTenVTHH.Value;
                        double SanLuong_Tong = Convert.ToDouble(dtmayin.Rows[0]["SanLuong_Tong"].ToString());
                        double PhePham = Convert.ToDouble(dtmayin.Rows[0]["PhePham"].ToString());
                        int ID_Mayxxx = Convert.ToInt32(dtmayin.Rows[0]["ID_May"].ToString());
                        clsmaymoc.iId = ID_Mayxxx;
                        DataTable dtmay = clsmaymoc.SelectOne();
                        string MaMay_IN = clsmaymoc.sMaMay.Value;
                        _ravi["ID_VTHH_Vao_IN"] = ID_VTHH_Vao;
                        _ravi["ID_VTHH_Ra_IN"] = ID_VTHH_Ra;
                        _ravi["MaVT_Vao_IN"] = MaVT_Vao;
                        _ravi["MaVT_Ra_IN"] = MaVT_Ra;
                        _ravi["DonViTinh_Vao_IN"] = DonViTinh_Vao;
                        _ravi["DonViTinh_Ra_IN"] = DonViTinh_Ra;
                        _ravi["TenVatTu_Vao_IN"] = TenVatTu_Vao;
                        _ravi["TenVatTu_Ra_IN"] = TenVatTu_Ra;
                        _ravi["SoLuong_Vao_IN"] = SoLuong_Vao.ToString();
                        _ravi["SoLuong_Ra_IN"] = SanLuong_Tong.ToString();
                        _ravi["PhePham_IN"] = PhePham;
                        _ravi["NgaySanXuat_IN"] = NgaySanXuat;
                        _ravi["CaSanXuat_IN"] = CaSanXuat;
                        _ravi["CongNhan_IN"] = CongNhan;
                        _ravi["MaMay_IN"] = MaMay_IN;
                    }

                    if (dtmaycat.Rows.Count > 0)
                    {
                        int ID_CongNhan = Convert.ToInt32(dtmaycat.Rows[0]["ID_CongNhan"].ToString());
                        clsnhansu.iID_NhanSu = ID_CongNhan;
                        DataTable dtnhansu = clsnhansu.SelectOne();
                        string CongNhan = clsnhansu.sTenNhanVien.Value;
                        DateTime daNgaySanXuat = Convert.ToDateTime(dtmaycat.Rows[0]["NgaySanXuat"].ToString());
                        string NgaySanXuat = daNgaySanXuat.ToString("dd/MM/yyyy");
                        string CaSanXuat = dtmaycat.Rows[0]["CaSanXuat"].ToString();
                        int ID_VTHH_Vao = Convert.ToInt32(dtmaycat.Rows[0]["ID_VTHH_Vao"].ToString());
                        clsVT_Vao.iID_VTHH = ID_VTHH_Vao;
                        DataTable dtvtvao = clsVT_Vao.SelectOne();
                        string MaVT_Vao = clsVT_Vao.sMaVT.Value;
                        string DonViTinh_Vao = clsVT_Vao.sDonViTinh.Value;
                        string TenVatTu_Vao = clsVT_Vao.sTenVTHH.Value;
                        double SoLuong_Vao = Convert.ToDouble(dtmaycat.Rows[0]["SoLuong_Vao"].ToString());
                        int ID_VTHH_Ra = Convert.ToInt32(dtmaycat.Rows[0]["ID_VTHH_Ra"].ToString());
                        clsVT_Ra.iID_VTHH = ID_VTHH_Ra;
                        DataTable dtvt_Ra = clsVT_Ra.SelectOne();
                        string MaVT_Ra = clsVT_Ra.sMaVT.Value;
                        string DonViTinh_Ra = clsVT_Ra.sDonViTinh.Value;
                        string TenVatTu_Ra = clsVT_Ra.sTenVTHH.Value;
                        double SanLuong_Tong = Convert.ToDouble(dtmaycat.Rows[0]["SanLuong_Tong"].ToString());
                        double PhePham = Convert.ToDouble(dtmaycat.Rows[0]["PhePham"].ToString());
                        int ID_Mayxxx = Convert.ToInt32(dtmaycat.Rows[0]["ID_May"].ToString());
                        clsmaymoc.iId = ID_Mayxxx;
                        DataTable dtmay = clsmaymoc.SelectOne();
                        string MaMay_CAT = clsmaymoc.sMaMay.Value;

                        _ravi["ID_VTHH_Vao_CAT"] = ID_VTHH_Vao;
                        _ravi["ID_VTHH_Ra_CAT"] = ID_VTHH_Ra;
                        _ravi["MaVT_Vao_CAT"] = MaVT_Vao;
                        _ravi["MaVT_Ra_CAT"] = MaVT_Ra;
                        _ravi["DonViTinh_Vao_CAT"] = DonViTinh_Vao;
                        _ravi["DonViTinh_Ra_CAT"] = DonViTinh_Ra;
                        _ravi["TenVatTu_Vao_CAT"] = TenVatTu_Vao;
                        _ravi["TenVatTu_Ra_CAT"] = TenVatTu_Ra;
                        _ravi["SoLuong_Vao_CAT"] = SoLuong_Vao.ToString();
                        _ravi["SoLuong_Ra_CAT"] = SanLuong_Tong.ToString();
                        _ravi["PhePham_CAT"] = PhePham;
                        _ravi["NgaySanXuat_CAT"] = NgaySanXuat;
                        _ravi["CaSanXuat_CAT"] = CaSanXuat;
                        _ravi["CongNhan_CAT"] = CongNhan;
                        _ravi["MaMay_CAT"] = MaMay_CAT;
                    }

                    if (dtmaydot.Rows.Count > 0)
                    {
                        int ID_CongNhan = Convert.ToInt32(dtmaydot.Rows[0]["ID_CongNhan"].ToString());
                        clsnhansu.iID_NhanSu = ID_CongNhan;
                        DataTable dtnhansu = clsnhansu.SelectOne();
                        string CongNhan = clsnhansu.sTenNhanVien.Value;
                        DateTime daNgaySanXuat = Convert.ToDateTime(dtmaydot.Rows[0]["NgaySanXuat"].ToString());
                        string NgaySanXuat = daNgaySanXuat.ToString("dd/MM/yyyy");
                        string CaSanXuat = dtmaydot.Rows[0]["CaSanXuat"].ToString();
                        int ID_VTHH_Vao = Convert.ToInt32(dtmaydot.Rows[0]["ID_VTHH_Vao"].ToString());
                        clsVT_Vao.iID_VTHH = ID_VTHH_Vao;
                        DataTable dtvtvao = clsVT_Vao.SelectOne();
                        string MaVT_Vao = clsVT_Vao.sMaVT.Value;
                        string DonViTinh_Vao = clsVT_Vao.sDonViTinh.Value;
                        string TenVatTu_Vao = clsVT_Vao.sTenVTHH.Value;
                        double SoLuong_Vao = Convert.ToDouble(dtmaydot.Rows[0]["SoLuong_Vao"].ToString());
                        int ID_VTHH_Ra = Convert.ToInt32(dtmaydot.Rows[0]["ID_VTHH_Ra"].ToString());
                        clsVT_Ra.iID_VTHH = ID_VTHH_Ra;
                        DataTable dtvt_Ra = clsVT_Ra.SelectOne();
                        string MaVT_Ra = clsVT_Ra.sMaVT.Value;
                        string DonViTinh_Ra = clsVT_Ra.sDonViTinh.Value;
                        string TenVatTu_Ra = clsVT_Ra.sTenVTHH.Value;
                        double SanLuong_Tong = Convert.ToDouble(dtmaydot.Rows[0]["SanLuong_Tong"].ToString());
                        double PhePham = Convert.ToDouble(dtmaydot.Rows[0]["PhePham"].ToString());
                        int ID_Mayxxx = Convert.ToInt32(dtmaydot.Rows[0]["ID_May"].ToString());
                        clsmaymoc.iId = ID_Mayxxx;
                        DataTable dtmay = clsmaymoc.SelectOne();
                        string MaMay_DOT = clsmaymoc.sMaMay.Value;
                        _ravi["ID_VTHH_Vao_DOT"] = ID_VTHH_Vao;
                        _ravi["ID_VTHH_Ra_DOT"] = ID_VTHH_Ra;
                        _ravi["MaVT_Vao_DOT"] = MaVT_Vao;
                        _ravi["MaVT_Ra_DOT"] = MaVT_Ra;
                        _ravi["DonViTinh_Vao_DOT"] = DonViTinh_Vao;
                        _ravi["DonViTinh_Ra_DOT"] = DonViTinh_Ra;
                        _ravi["TenVatTu_Vao_DOT"] = TenVatTu_Vao;
                        _ravi["TenVatTu_Ra_DOT"] = TenVatTu_Ra;
                        _ravi["SoLuong_Vao_DOT"] = SoLuong_Vao.ToString();
                        _ravi["SoLuong_Ra_DOT"] = SanLuong_Tong.ToString();
                        _ravi["PhePham_DOT"] = PhePham;
                        _ravi["NgaySanXuat_DOT"] = NgaySanXuat;
                        _ravi["CaSanXuat_DOT"] = CaSanXuat;
                        _ravi["CongNhan_DOT"] = CongNhan;
                        _ravi["MaMay_DOT"] = MaMay_DOT;
                    }

                    dt2.Rows.Add(_ravi);

                }
                gridControl1.DataSource = dt2;
            }

            isload = false;
        }
        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            LoadData(sotrang_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {
            
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu())
            {
                DataTable dt_ = cls.SelectAll_Tinh_SoPhieu_new(xxtungay, xxdenngay);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }
      
        public SanXuat_frmChiTietSoPhieu_RutGon()
        {
            InitializeComponent();
        }

        private void SanXuat_frmChiTietSoPhieu_RutGon_Load(object sender, EventArgs e)
        {
            dteTuNgay.EditValue = DateTime.Now.AddDays(-30);
            dteDenNgay.EditValue = DateTime.Now;            
            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);

            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btTImKiem_Click(object sender, EventArgs e)
        {
            bandedGridView1.OptionsFind.AlwaysVisible = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SanXuat_frmChiTietSoPhieu_RutGon_Load(sender, e);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint_tbChiTietPhieu = dv1212.ToTable();
            if(mdtPrint_tbChiTietPhieu.Rows.Count>0)
            {
                xxsotrang = "Số trang: " + txtSoTrang.Text.ToString() + "" + lbTongSoTrang.Text + "";
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                frmPrintChiTietPhieuSanXuat ff = new frmPrintChiTietPhieuSanXuat();
                ff.Show();
            }
          
            
            
        }
        
        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_PhieuSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void txtSoTrang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
        
            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            LoadData(1, false, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            //ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            //ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //LoadData(1, false);
            //if (isload)
            //    return;

            //try
            //{
            //    //  _ngay_batdau = Convert.ToDateTime(dteTuNgay.DateTime);
            //    ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //    LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
            //catch
            //{ }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            //ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);

            //if (isload)
            //    return;
            //try
            //{
            //    _ngay_ketthuc = Convert.ToDateTime(dteDenNgay.DateTime);
            //    ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //    LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
            //catch
            //{ }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
    }
}
