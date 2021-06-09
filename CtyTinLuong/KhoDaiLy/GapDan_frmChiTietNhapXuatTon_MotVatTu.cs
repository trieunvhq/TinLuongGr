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

        public static bool mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
        public static int miID_VTHH;
        public static string msNguoiLap_Prtint;
        public static DataTable mdt_ChiTiet_MotVatTu_N_X_T_Print;
        public static DateTime mdatungay, mdadenngay;
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }

        private void HienThi()
        {
            DataTable dt2xxxx = new DataTable();

            dt2xxxx.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2xxxx.Columns.Add("Nhap", typeof(double));
            dt2xxxx.Columns.Add("DonGiaNhap", typeof(double));
            dt2xxxx.Columns.Add("GiaTriNhap", typeof(double));
            dt2xxxx.Columns.Add("Xuat", typeof(double));
            dt2xxxx.Columns.Add("DonGiaXuat", typeof(double));
            dt2xxxx.Columns.Add("GiaTriXuat", typeof(double));
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));


            DateTime dteDenNgayxx = UCDaiLy_GapDan_baocao_NXT.mdadenngay;
            DateTime dteTuNgayxxx = UCDaiLy_GapDan_baocao_NXT.mdatungay;

            DateTime ngaydautien;
            ngaydautien = dteTuNgayxxx;

            TimeSpan timespsanxxxx = dteDenNgayxx - dteTuNgayxxx;
            int songay = timespsanxxxx.Days;
            for (int i = 0; i <= songay; i++)
            {

                clsGapDan_ChiTiet_NhapKho cls1 = new clsGapDan_ChiTiet_NhapKho();
                cls1.iID_VTHH = UCDaiLy_GapDan_baocao_NXT.miiID_VTHH;
                DataTable dt1 = cls1.SelectOne_W_ID_VTHH_TinhToan_NXT();
                dt1.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'";
                DataView dv1 = dt1.DefaultView;
                DataTable dt11new = dv1.ToTable();
                //gridControl2.DataSource = dt11new;///////
                if (dt11new.Rows.Count > 0) // có nhập
                {

                    for (int k1 = 0; k1 < dt11new.Rows.Count; k1++)
                    {
                        clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
                        cls2.iID_VTHH = UCDaiLy_GapDan_baocao_NXT.miiID_VTHH;
                        DataTable dt2 = cls2.SelectOne_W_ID_VTHH_TinhToan_NXT();
                        dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'";
                        DataView dv2 = dt2.DefaultView;
                        DataTable dt22new = dv2.ToTable();
                        if (dt22new.Rows.Count > 0) // có xuất
                        {
                            double soluongnhap, dongianhap, soluongxuat, dongiaxuat;
                             soluongnhap = Convert.ToDouble(dt11new.Rows[k1]["SoLuongNhap"].ToString());
                             dongianhap = Convert.ToDouble(dt11new.Rows[k1]["DonGia"].ToString());
                            DataRow _ravi = dt2xxxx.NewRow();
                            _ravi["NgayChungTu"] = ngaydautien;
                            _ravi["Nhap"] = soluongnhap;
                            _ravi["DonGiaNhap"] = dongianhap;
                            //_ravi["DonGiaXuat"] = dongiaxuat;
                            _ravi["GiaTriNhap"] = soluongnhap * dongianhap;
                            _ravi["SoChungTu_NhapKho"] = dt11new.Rows[k1]["SoChungTu"].ToString();
                             soluongxuat = Convert.ToDouble(dt22new.Rows[0]["SoLuongXuat"].ToString());
                             dongiaxuat = Convert.ToDouble(dt22new.Rows[0]["DonGia"].ToString());
                            _ravi["Xuat"] = soluongxuat;
                            _ravi["DonGiaXuat"] = dongiaxuat;
                            _ravi["GiaTriXuat"] = soluongxuat * dongiaxuat;
                            _ravi["SoChungTu_XuatKho"] = dt22new.Rows[0]["SoChungTu"].ToString();
                            dt2xxxx.Rows.Add(_ravi);
                            if (dt22new.Rows.Count > 1)
                            {
                                for (int k2 = 1; k2 < dt22new.Rows.Count; k2++)
                                {
                                    soluongnhap = Convert.ToDouble(dt11new.Rows[k1]["SoLuongNhap"].ToString());
                                    dongianhap = Convert.ToDouble(dt11new.Rows[k1]["DonGia"].ToString());
                                    DataRow _ravi2 = dt2xxxx.NewRow();
                                    _ravi2["NgayChungTu"] = ngaydautien;
                                    _ravi2["Nhap"] = 0;
                                    _ravi2["DonGiaNhap"] = 0;
                                    //_ravi["DonGiaXuat"] = dongiaxuat;
                                    _ravi2["GiaTriNhap"] = 0 ;
                                    _ravi2["SoChungTu_NhapKho"] = "";
                                    soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                                    dongiaxuat = Convert.ToDouble(dt22new.Rows[k2]["DonGia"].ToString());
                                    _ravi2["Xuat"] = soluongxuat;
                                    _ravi2["DonGiaXuat"] = dongiaxuat;
                                    _ravi2["GiaTriXuat"] = soluongxuat * dongiaxuat;
                                    _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();
                                    dt2xxxx.Rows.Add(_ravi2);
                                }
                            }
                                
                        }
                        else
                        {
                            DataRow _ravi = dt2xxxx.NewRow();
                            double soluongnhap = Convert.ToDouble(dt11new.Rows[k1]["SoLuongNhap"].ToString());
                            double dongianhap = Convert.ToDouble(dt11new.Rows[k1]["DonGia"].ToString());
                            _ravi["NgayChungTu"] = ngaydautien;
                            _ravi["Nhap"] = soluongnhap;
                            _ravi["GiaTriNhap"] = soluongnhap * dongianhap;
                            _ravi["DonGiaNhap"] = dongianhap;
                            _ravi["DonGiaXuat"] = 0;
                            _ravi["SoChungTu_NhapKho"] = dt11new.Rows[k1]["SoChungTu"].ToString();
                            _ravi["Xuat"] = 0;
                            _ravi["GiaTriXuat"] = 0;
                            _ravi["SoChungTu_XuatKho"] = "";
                            dt2xxxx.Rows.Add(_ravi);
                        }

                    }

                }
                else // ko có nhập, kiểm tra xem có xuất không. nếu có thì thêm row
                {
                    clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
                    cls2.iID_VTHH = UCDaiLy_GapDan_baocao_NXT.miiID_VTHH;
                    DataTable dt2 = cls2.SelectOne_W_ID_VTHH_TinhToan_NXT();
                    dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'";
                    DataView dv2 = dt2.DefaultView;
                    DataTable dt22new = dv2.ToTable();
                    if (dt22new.Rows.Count > 0) // có xuất
                    {
                        for (int k2 = 0; k2 < dt22new.Rows.Count; k2++)
                        {
                            double soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                            double dongiaxuat = Convert.ToDouble(dt22new.Rows[k2]["DonGia"].ToString());
                            DataRow _ravi2 = dt2xxxx.NewRow();
                            _ravi2["NgayChungTu"] = ngaydautien;
                            _ravi2["Nhap"] = 0;
                            _ravi2["GiaTriNhap"] = 0;
                            _ravi2["SoChungTu_NhapKho"] = "";
                            _ravi2["DonGiaNhap"] = 0;
                            _ravi2["DonGiaXuat"] = dongiaxuat;
                            _ravi2["Xuat"] = soluongxuat;
                            _ravi2["GiaTriXuat"] = soluongxuat * dongiaxuat;
                            _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();
                            dt2xxxx.Rows.Add(_ravi2);
                        }
                    }
                }

                ngaydautien = ngaydautien.AddDays(1);

            }
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

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            miID_VTHH = UCDaiLy_GapDan_baocao_NXT.miiID_VTHH;
            mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = true;
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdt_ChiTiet_MotVatTu_N_X_T_Print = dv1212.ToTable();
            mdatungay = UCDaiLy_GapDan_baocao_NXT.mdatungay;
            mdadenngay = UCDaiLy_GapDan_baocao_NXT.mdadenngay;
            msNguoiLap_Prtint = "";
            frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu();
            ff.Show();
        }

        private void txtGiaTriTonDauKy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtGiaTriTonDauKy.Text);
                txtGiaTriTonDauKy.Text = String.Format("{0:#,##0.00}", value);

            }
            catch
            {

            }
        }

        private void GapDan_frmChiTietNhapXuatTon_MotVatTu_Load(object sender, EventArgs e)
        {
            DateTime teDenNgay = UCDaiLy_GapDan_baocao_NXT.mdadenngay;
            DateTime teTuNgay = UCDaiLy_GapDan_baocao_NXT.mdatungay;
            dteTuNgay.EditValue = teTuNgay;
            dteDenNgay.EditValue = teDenNgay;

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = UCDaiLy_GapDan_baocao_NXT.miiID_VTHH;
            DataTable dt = cls.SelectOne();
            txtMaVT.Text = cls.sMaVT.Value;
            txtTenVT.Text = cls.sTenVTHH.Value;
            txtDVT.Text = cls.sDonViTinh.Value;
            txtTonDauKy.Text = UCDaiLy_GapDan_baocao_NXT.msoluongTonDauKy.ToString();
            txtGiaTriTonDauKy.Text = UCDaiLy_GapDan_baocao_NXT.mGiaTriTonDauKy.ToString();

            HienThi();
        }
    }
}
