﻿using DevExpress.Data.Filtering;
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
            dt2xxxx.Columns.Add("Nhap", typeof(string));
            dt2xxxx.Columns.Add("Xuat", typeof(string));
            dt2xxxx.Columns.Add("Ton", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_NhapKho", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu_XuatKho", typeof(string));


            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            DateTime dteDenNgayxx = frmBaoCaoNXT.mdadenngay;
            DateTime dteTuNgayxxx = frmBaoCaoNXT.mdatungay;

            DateTime ngaydautien;
            ngaydautien = dteTuNgayxxx;

            TimeSpan timespsanxxxx = dteDenNgayxx - dteTuNgayxxx;
            int songay = timespsanxxxx.Days;
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            //_ravi_Khong["DienGiai"] = "Tồn đầu kỳ";
            //_ravi_Khong["Ton"] = frmBaoCaoNXT.msoluongTonDauKy;
            //dt2xxxx.Rows.Add(_ravi_Khong);
            double soluongton = 0, Tong_SoLuongNhap = 0, Tong_SoluongXuat = 0;
            //soluongton = frmBaoCaoNXT.msoluongTonDauKy;
            for (int i = 0; i <= songay; i++)
            {

                clsKhoNPL_tbChiTietNhapKho cls1 = new clsKhoNPL_tbChiTietNhapKho();
                cls1.iID_VTHH = frmBaoCaoNXT.miiID_VTHH;
                DataTable dt1 = cls1.SelectOne_W_ID_VTHH_NXT_TinhToan_newwwwww();
                dt1.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaNhapKho=True";
                DataView dv1 = dt1.DefaultView;
                DataTable dt11new = dv1.ToTable();

                if (dt11new.Rows.Count > 0) // có nhập
                {
                    double soluongnhap, soluongxuat;
                    for (int k1 = 0; k1 < dt11new.Rows.Count; k1++)
                    {
                        DataRow _ravi = dt2xxxx.NewRow();
                        soluongnhap = Convert.ToDouble(dt11new.Rows[k1]["SoLuongNhap"].ToString());
                        _ravi["NgayChungTu"] = ngaydautien;
                        _ravi["DienGiai"] = dt11new.Rows[k1]["DienGiai"].ToString();
                        _ravi["SoChungTu_NhapKho"] = dt11new.Rows[k1]["SoChungTu"].ToString();


                        _ravi["Nhap"] = soluongnhap;
                        _ravi["Ton"] = soluongton + soluongnhap;
                        //soluongton = soluongton + soluongnhap;
                        //Tong_SoLuongNhap = Tong_SoLuongNhap + soluongnhap;
                        dt2xxxx.Rows.Add(_ravi);
                    }

                    clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                    cls2.iID_VTHH = frmBaoCaoNXT.miiID_VTHH;

                    DataTable dt2 = cls2.SelectAll_W_ID_VTHH_TinhToan_N_X_T();
                    dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaXuatKho=True";
                    DataView dv2 = dt2.DefaultView;
                    DataTable dt22new = dv2.ToTable();
                    if (dt22new.Rows.Count > 0) // có xuất
                    {
                        for (int k2 = 0; k2 < dt22new.Rows.Count; k2++)
                        {
                            DataRow _ravi2 = dt2xxxx.NewRow();
                            _ravi2["NgayChungTu"] = ngaydautien;
                            soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                            _ravi2["Xuat"] = soluongxuat;
                            _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();


                            _ravi2["DienGiai"] = dt22new.Rows[k2]["DienGiai"].ToString();
                            _ravi2["Ton"] = soluongton - soluongxuat;
                            dt2xxxx.Rows.Add(_ravi2);
                            soluongton = soluongton - soluongxuat;
                            Tong_SoluongXuat = Tong_SoluongXuat + soluongxuat;
                        }

                    }
                    ngaydautien = ngaydautien.AddDays(1);
                }
                else // ko có nhập, kiểm tra xem có xuất không. nếu có thì thêm row
                {
                    clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                    cls2.iID_VTHH = frmBaoCaoNXT.miiID_VTHH;
                    DataTable dt2 = cls2.SelectAll_W_ID_VTHH_TinhToan_N_X_T();
                    dt2.DefaultView.RowFilter = " NgayChungTu ='" + ngaydautien + "'and DaXuatKho=True";
                    DataView dv2 = dt2.DefaultView;
                    DataTable dt22new = dv2.ToTable();
                    if (dt22new.Rows.Count > 0) // có xuất
                    {
                        for (int k2 = 0; k2 < dt22new.Rows.Count; k2++)
                        {
                            double soluongxuat;
                            DataRow _ravi2 = dt2xxxx.NewRow();
                            _ravi2["NgayChungTu"] = ngaydautien;
                            soluongxuat = Convert.ToDouble(dt22new.Rows[k2]["SoLuongXuat"].ToString());
                            _ravi2["Xuat"] = soluongxuat;
                            _ravi2["SoChungTu_XuatKho"] = dt22new.Rows[k2]["SoChungTu"].ToString();


                            _ravi2["DienGiai"] = dt22new.Rows[k2]["DienGiai"].ToString();
                            _ravi2["Ton"] = soluongton - soluongxuat;
                            dt2xxxx.Rows.Add(_ravi2);
                            soluongton = soluongton - soluongxuat;
                        }
                    }
                    ngaydautien = ngaydautien.AddDays(1);
                }
            }
            DataRow _ravi_Cuoi = dt2xxxx.NewRow();
            _ravi_Cuoi["DienGiai"] = "NXT trong kỳ";
            _ravi_Cuoi["Ton"] = soluongton;
            _ravi_Cuoi["Nhap"] = Tong_SoLuongNhap;
            _ravi_Cuoi["Xuat"] = Tong_SoluongXuat;
            dt2xxxx.Rows.Add(_ravi_Cuoi);
            gridControl1.DataSource = dt2xxxx;

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
            miID_VTHH = frmBaoCaoNXT.miiID_VTHH;
            mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = true;
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdt_ChiTiet_MotVatTu_N_X_T_Print = dv1212.ToTable();
            mdatungay = frmBaoCaoNXT.mdatungay;
            mdadenngay = frmBaoCaoNXT.mdadenngay;
            msNguoiLap_Prtint = "";
            if (mdt_ChiTiet_MotVatTu_N_X_T_Print.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;

            }
            else
            {
                frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu();
                ff.Show();
            }
        }

        private void frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham_Load(object sender, EventArgs e)
        {
            DateTime teDenNgay = frmBaoCaoNXT.mdadenngay;
            DateTime teTuNgay = frmBaoCaoNXT.mdatungay;
            dteTuNgay.EditValue = teTuNgay;
            dteDenNgay.EditValue = teDenNgay;

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = frmBaoCaoNXT.miiID_VTHH;
            DataTable dt = cls.SelectOne();
            txtMaVT.Text = cls.sMaVT.Value;
            txtTenVT.Text = cls.sTenVTHH.Value;
            txtDVT.Text = cls.sDonViTinh.Value;


            HienThi();
        }
    }
}
