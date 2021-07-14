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
    public partial class GapDan_frmChiTietNhapXuatTon_MotVatTu : Form
    {
        public static bool mbPrint = false;
        public static string msMaVT, msTenVTHH, msDonViTinh;
        public static DataTable mdtPrint;
        public static DateTime mdatungay, mdadenngay;
        private void Load_Lockup()
        {
            clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            DataTable dt2 = cls.SD_MaVT_Load_lockUP();

            gridMaVT.Properties.DataSource = dt2;
            gridMaVT.Properties.ValueMember = "ID_VTHH";
            gridMaVT.Properties.DisplayMember = "MaVT";
            dt2.Dispose();
            cls.Dispose();
        }
        private void LoadDaTa(int xxID_VTHH___, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();

            dt_NhapTruoc = cls1.SA_NhapTruocKy_ID_VTHH(xxID_VTHH___,  xxtungay);
            dt_XuatTruoc = cls2.SA_XuatTruocKy_ID_VTHH(xxID_VTHH___,  xxtungay);

            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2xxxx.Columns.Add("Nhap", typeof(string));
            dt2xxxx.Columns.Add("Xuat", typeof(string));
            dt2xxxx.Columns.Add("Ton", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));           
            dt2xxxx.Columns.Add("DienGiai", typeof(string));

            double SoLuong_NhapTruocKy, SoLuong_XuatTruocKy, SoLuong_TonDauKy = 0;
            if (dt_NhapTruoc.Rows.Count > 0)
            {
                DataRow _ravi = dt2xxxx.NewRow();
                SoLuong_NhapTruocKy = CheckString.ConvertToDouble_My(dt_NhapTruoc.Rows[0]["SoLuong_NhapTruocKy"].ToString());
                if (dt_XuatTruoc.Rows.Count > 0)
                    SoLuong_XuatTruocKy = CheckString.ConvertToDouble_My(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                else
                    SoLuong_XuatTruocKy = 0;
                SoLuong_TonDauKy = SoLuong_NhapTruocKy - SoLuong_XuatTruocKy;
                _ravi["DienGiai"] = "Tồn đầu kỳ";
                _ravi["Ton"] = SoLuong_TonDauKy;
                dt2xxxx.Rows.Add(_ravi);
            }
            else if (dt_XuatTruoc.Rows.Count > 0)
            {
                DataRow _ravi = dt2xxxx.NewRow();
                SoLuong_XuatTruocKy = CheckString.ConvertToDouble_My(dt_XuatTruoc.Rows[0]["SoLuong_XuatTruocKy"].ToString());
                SoLuong_TonDauKy = -SoLuong_XuatTruocKy;
                _ravi["DienGiai"] = "Tồn đầu kỳ";
                _ravi["Ton"] = SoLuong_TonDauKy;
                dt2xxxx.Rows.Add(_ravi);
            }

            else
            {
                DataRow _ravi = dt2xxxx.NewRow();
                _ravi["DienGiai"] = "Tồn đầu kỳ";
                _ravi["Ton"] = 0;
                dt2xxxx.Rows.Add(_ravi);
            }

            cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            cls2 = new clsGapDan_ChiTiet_XuatKho();
            DataTable dtnhap = new DataTable();
            DataTable dtxuat = new DataTable();

            dtnhap = cls1.SA_NhapTrongKy_ID_VTHH(xxID_VTHH___, xxtungay, xxdenngay);
            dtxuat = cls2.SA_XuatTrongKy_ID_VTHH(xxID_VTHH___, xxtungay, xxdenngay);


            DateTime ngaydautien;
            ngaydautien = xxtungay;

            TimeSpan timespsanxxxx = xxdenngay - xxtungay;
            int songay = timespsanxxxx.Days;
            double Tong_SoLuongNhap = 0, Tong_SoluongXuat = 0;
            double soluongton = SoLuong_TonDauKy;
            for (int i = 0; i <= songay; i++)
            {

                string expression;
                expression = "NgayChungTu='" + ngaydautien + "'";
                DataRow[] foundRows_Nhap, foundRows_Xuat;
                foundRows_Nhap = dtnhap.Select(expression);
                foundRows_Xuat = dtxuat.Select(expression);
                if (foundRows_Nhap.Length > 0)
                {
                    for (int j = 0; j < foundRows_Nhap.Length; j++)
                    {

                        DataRow _ravi_Nhap = dt2xxxx.NewRow();
                        double soluongnhap = CheckString.ConvertToDouble_My(foundRows_Nhap[j]["SoLuongNhap"].ToString());
                        _ravi_Nhap["NgayChungTu"] = ngaydautien;
                        _ravi_Nhap["DienGiai"] = foundRows_Nhap[j]["DienGiai"].ToString();
                        _ravi_Nhap["SoChungTu_NhapKho"] = foundRows_Nhap[j]["SoChungTu"].ToString();                      
                        _ravi_Nhap["Nhap"] = soluongnhap;
                        _ravi_Nhap["Ton"] = soluongton + soluongnhap;
                        soluongton = soluongton + soluongnhap;
                        Tong_SoLuongNhap = Tong_SoLuongNhap + soluongnhap;
                        dt2xxxx.Rows.Add(_ravi_Nhap);
                    }
                }
                if (foundRows_Xuat.Length > 0)
                {
                    for (int j = 0; j < foundRows_Xuat.Length; j++)
                    {
                        DataRow _ravi_Xuat = dt2xxxx.NewRow();
                        _ravi_Xuat["NgayChungTu"] = ngaydautien;
                        double soluongxuat = CheckString.ConvertToDouble_My(foundRows_Xuat[j]["SoLuongXuat"].ToString());
                        _ravi_Xuat["Xuat"] = soluongxuat;
                        _ravi_Xuat["SoChungTu_XuatKho"] = foundRows_Xuat[j]["SoChungTu"].ToString();                        
                        _ravi_Xuat["DienGiai"] = foundRows_Xuat[j]["DienGiai"].ToString();
                        _ravi_Xuat["Ton"] = soluongton - soluongxuat;
                        dt2xxxx.Rows.Add(_ravi_Xuat);
                        soluongton = soluongton - soluongxuat;
                        Tong_SoluongXuat = Tong_SoluongXuat + soluongxuat;

                    }
                }
                ngaydautien = ngaydautien.AddDays(1);
            }
            DataRow _ravi_Cuoi = dt2xxxx.NewRow();
            _ravi_Cuoi["DienGiai"] = "NXT trong kỳ";
            _ravi_Cuoi["Ton"] = soluongton;
            _ravi_Cuoi["Nhap"] = Tong_SoLuongNhap;
            _ravi_Cuoi["Xuat"] = Tong_SoluongXuat;
            dt2xxxx.Rows.Add(_ravi_Cuoi);
            gridControl1.DataSource = dt2xxxx;
        }
        public GapDan_frmChiTietNhapXuatTon_MotVatTu()
        {
            InitializeComponent();
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
            mdtPrint = dv1212.ToTable();
            if(mdtPrint.Rows.Count>0)
            {
              
                mbPrint = true;
                msMaVT = gridMaVT.Text.ToString();
                msTenVTHH = txtTenVT.Text;
                msDonViTinh = txtDVT.Text;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;

                frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu();
                ff.Show();
            }
            
        }

      

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GapDan_frmChiTietNhapXuatTon_MotVatTu_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void gridMaVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenVT.Focus();
            }
        }

        private void txtTenVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDVT.Focus();
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btPrint.Focus();
            }
        }

        private void gridMaVT_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVT.Properties.View.Columns[0].Visible = false;
            gridMaVT.Properties.View.Columns[3].Visible = false;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int xxid = Convert.ToInt32(gridMaVT.EditValue.ToString());
            LoadDaTa(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            Cursor.Current = Cursors.Default;
        }

        private void gridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            int xidvt = Convert.ToInt32(gridMaVT.EditValue.ToString());
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xidvt;
            DataTable dt = cls.SelectOne();
            try
            {
                txtTenVT.Text = cls.sTenVTHH.Value;
                txtDVT.Text = cls.sDonViTinh.Value;               
                LoadDaTa(xidvt, dteTuNgay.DateTime, dteDenNgay.DateTime);
                
            }
            catch
            {

            }
        }

        private void GapDan_frmChiTietNhapXuatTon_MotVatTu_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_Lockup();
            dteTuNgay.EditValue = DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.mdatungay;
            dteDenNgay.EditValue = DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.mdadenngay;
            gridMaVT.EditValue= DaiLy_GapDan_BaoCao_Nhap_Xuat_Ton.miiID_VTHH;
            Cursor.Current = Cursors.Default;
        }
    }
}
