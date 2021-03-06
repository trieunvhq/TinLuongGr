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
    public partial class frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham : Form
    {
        public static bool mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
        public static int miID_VTHH;
   
        public static DataTable mdt_ChiTiet_MotVatTu_N_X_T_Print;
        public static DateTime mdatungay, mdadenngay;

        private void Load_Lockup()
        {
            try
            {
                using (clsKhoBTP_tbChiTietNhapKho cls = new CtyTinLuong.clsKhoBTP_tbChiTietNhapKho())
                {
                    DataTable dt2 = cls.SD_MaVT_Load_lockUP();

                    gridMaVT.Properties.DataSource = dt2;
                    gridMaVT.Properties.ValueMember = "ID_VTHH";
                    gridMaVT.Properties.DisplayMember = "MaVT";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDaTa(int xxID_VTHH___, DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                DataTable dt_NhapTruoc = new DataTable();
                DataTable dt_XuatTruoc = new DataTable();
                clsKhoBTP_tbChiTietNhapKho cls1 = new CtyTinLuong.clsKhoBTP_tbChiTietNhapKho();
                clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();

                dt_NhapTruoc = cls1.SA_NhapTruocKy_ID_VTHH(xxID_VTHH___, xxtungay);
                dt_XuatTruoc = cls2.SA_XuatTruocKy_ID_VTHH(xxID_VTHH___, xxtungay);

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

                cls1 = new CtyTinLuong.clsKhoBTP_tbChiTietNhapKho();
                cls2 = new clsKhoBTP_ChiTietXuatKho();
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdt_ChiTiet_MotVatTu_N_X_T_Print = dv1212.ToTable();


                if (mdt_ChiTiet_MotVatTu_N_X_T_Print.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }
                else
                {
                    miID_VTHH = Convert.ToInt32(gridMaVT.EditValue.ToString());
                    mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = true;
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;
                    frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu();
                    ff.Show();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa())
                {
                    int xidvt = Convert.ToInt32(gridMaVT.EditValue.ToString());
                    cls.iID_VTHH = xidvt;
                    DataTable dt = cls.SelectOne();
                    txtTenVT.Text = cls.sTenVTHH.Value;
                    txtDVT.Text = cls.sDonViTinh.Value;
                    LoadDaTa(xidvt, dteTuNgay.DateTime, dteDenNgay.DateTime);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int xxid = Convert.ToInt32(gridMaVT.EditValue.ToString());
                LoadDaTa(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaVT_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVT.Properties.View.Columns[0].Visible = false;
        }

        private void frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_Lockup();
                dteTuNgay.EditValue = frmBaoCaoNhapXuatTon_BanThanhPham.mdatungay;
                dteDenNgay.EditValue = frmBaoCaoNhapXuatTon_BanThanhPham.mdadenngay;
                gridMaVT.EditValue = frmBaoCaoNhapXuatTon_BanThanhPham.miiID_VTHH;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
