using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Filtering;

namespace CtyTinLuong
{
    public partial class UCDaiLy_GapDan_baocao_NXT : UserControl
    {

        public static bool mbPrint_NXT_Kho = false;
        public static string msNguoiLap_Prtint;
        public static DataTable mdt_ChiTiet_Print;
        public static int miiID_VTHH;
        public static double msoluongTonDauKy, mGiaTriTonDauKy;
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
        public static DateTime GetFirstDayInYear(int year)
        {
            DateTime aDateTime = new DateTime(year, 1, 1);
            return aDateTime;
        }

        #region cũ
        //public DataTable tinhtoanNXT_NhapXuat_TrongKy(DateTime tungayxx, DateTime denngayxx)
        //{
        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
        //    dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

        //    clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
        //    //SelectAll_W_MaVT_TenVT_DVT_NXT
        //    DataTable dt = cls.SelectAll_W_MaVT_TenVT_DVT_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable dt22 = dv.ToTable();
        //    dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxx + "'";
        //    DataView dv2 = dt22.DefaultView;
        //    DataTable dxxxx = dv2.ToTable();

        //    DataTable dtDISTINCT = cls.SelectAll_distinct();


        //    if (dtDISTINCT.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
        //        {
        //            int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
        //            string expression;
        //            expression = "ID_VTHH=" + ID_VTHHxxx + "";
        //            DataRow[] foundRows;
        //            foundRows = dxxxx.Select(expression);
        //            if (foundRows.Length > 0)
        //            {
        //                DataTable dtnhapkho = TinhToan_NhapKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
        //                if (dtnhapkho.Rows.Count > 0)
        //                {
        //                    DataRow _ravi2 = dt2.NewRow();
        //                    _ravi2["ID_VTHH"] = ID_VTHHxxx;
        //                    _ravi2["MaVT"] = dtnhapkho.Rows[0]["MaVT"].ToString();
        //                    _ravi2["TenVTHH"] = dtnhapkho.Rows[0]["TenVTHH"].ToString();
        //                    _ravi2["DonViTinh"] = dtnhapkho.Rows[0]["DonViTinh"].ToString();
        //                    double soluongnhaptrognky, giatrinhaptrongky, soluongxuattrognky, giatrixuattrongky;
        //                    soluongnhaptrognky = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongNhap_TrongKy"].ToString());
        //                    giatrinhaptrongky = Convert.ToDouble(dtnhapkho.Rows[0]["GiaTriNhap_TrongKy"].ToString());
        //                    DataTable dtxuatkho = TinhToan_XuatKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
        //                    if (dtxuatkho.Rows.Count > 0)
        //                    {
        //                        soluongxuattrognky = Convert.ToDouble(dtxuatkho.Rows[0]["SoLuongXuat_TrongKy"].ToString());
        //                        giatrixuattrongky = Convert.ToDouble(dtxuatkho.Rows[0]["GiaTriXuat_TrongKy"].ToString());
        //                    }
        //                    else
        //                    {
        //                        soluongxuattrognky = 0;
        //                        giatrixuattrongky = 0;
        //                    }

        //                    _ravi2["SoLuongNhap_TrongKy"] = soluongnhaptrognky;
        //                    _ravi2["GiaTriNhap_TrongKy"] = giatrinhaptrongky;
        //                    _ravi2["SoLuongXuat_TrongKy"] = soluongxuattrognky;
        //                    _ravi2["GiaTriXuat_TrongKy"] = giatrixuattrongky;
        //                    dt2.Rows.Add(_ravi2);
        //                }
        //            }

        //        }
        //    }
        //    return dt2;
        //}
        //public DataTable tinhtoanNXT_Ton_DauKy(DateTime tungayxx, DateTime denngayxx)
        //{
        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
        //    dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

        //    clsGapDan_ChiTiet_NhapKho clsnpl = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
        //    DataTable dt = clsnpl.SelectAll_W_MaVT_TenVT_DVT_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<='" + tungayxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable dt22 = dv.ToTable();
        //    //dt.DefaultView.RowFilter = " boolTonDauKy = True";
        //    //DataView dv222 = dt.DefaultView;
        //    //DataTable xxxxdt22 = dv222.ToTable();
        //    ////if(xxxxdt22.Rows.Count>0)
        //    //{
        //    //    if (tungayxx <= Convert.ToDateTime(xxxxdt22.Rows[0]["NgayChungTu"].ToString()))
        //    //    {
        //    //        for (int i = 0; i < xxxxdt22.Rows.Count; i++)
        //    //        {
        //    //            DataRow _ravi = dt2.NewRow();
        //    //            double soluongnhap, dongianhap;
        //    //            soluongnhap = Convert.ToDouble(xxxxdt22.Rows[0]["SoLuongNhap"].ToString());
        //    //            dongianhap = Convert.ToDouble(xxxxdt22.Rows[0]["DonGia"].ToString());
        //    //            _ravi["ID_VTHH"] = Convert.ToInt32(xxxxdt22.Rows[i]["ID_VTHH"].ToString());
        //    //            _ravi["MaVT"] = xxxxdt22.Rows[0]["MaVT"].ToString();
        //    //            _ravi["TenVTHH"] = xxxxdt22.Rows[0]["TenVTHH"].ToString();
        //    //            _ravi["DonViTinh"] = xxxxdt22.Rows[0]["DonViTinh"].ToString();
        //    //            _ravi["SoLuong_TonDauKy"] = soluongnhap;
        //    //            _ravi["GiaTri_TonDauKy"] = soluongnhap * dongianhap;
        //    //            dt2.Rows.Add(_ravi);
        //    //        }

        //    //    }
        //    //}            
        //    //else
        //    //{
        //    DataTable dtDISTINCT = clsnpl.SelectAll_distinct();


        //    if (dtDISTINCT.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
        //        {
        //            int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
        //            string expression;
        //            expression = "ID_VTHH=" + ID_VTHHxxx + "";
        //            DataRow[] foundRows;
        //            foundRows = dt22.Select(expression);
        //            if (foundRows.Length > 0)
        //            {
        //                DataTable dtnhapkho = TinhToan_NhapKho_tonDauKy_ID_VTHH(ID_VTHHxxx, tungayxx);
        //                if (dtnhapkho.Rows.Count > 0)
        //                {
        //                    DataRow _ravi2 = dt2.NewRow();
        //                    _ravi2["ID_VTHH"] = ID_VTHHxxx;
        //                    _ravi2["MaVT"] = dtnhapkho.Rows[0]["MaVT"].ToString();
        //                    _ravi2["TenVTHH"] = dtnhapkho.Rows[0]["TenVTHH"].ToString();
        //                    _ravi2["DonViTinh"] = dtnhapkho.Rows[0]["DonViTinh"].ToString();
        //                    double soluongnhaptrognky, giatrinhaptrongky, soluongxuattrognky, giatrixuattrongky;
        //                    soluongnhaptrognky = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongNhap_TrongKy"].ToString());
        //                    giatrinhaptrongky = Convert.ToDouble(dtnhapkho.Rows[0]["GiaTriNhap_TrongKy"].ToString());
        //                    DataTable dtxuatkho = TinhToan_XuatKho_tonDauKy__ID_VTHH(ID_VTHHxxx, tungayxx);
        //                    if (dtxuatkho.Rows.Count > 0)
        //                    {
        //                        soluongxuattrognky = Convert.ToDouble(dtxuatkho.Rows[0]["SoLuongXuat_TrongKy"].ToString());
        //                        giatrixuattrongky = Convert.ToDouble(dtxuatkho.Rows[0]["GiaTriXuat_TrongKy"].ToString());
        //                    }
        //                    else
        //                    {
        //                        soluongxuattrognky = 0;
        //                        giatrixuattrongky = 0;
        //                    }

        //                    _ravi2["SoLuong_TonDauKy"] = soluongnhaptrognky - soluongxuattrognky;
        //                    _ravi2["GiaTri_TonDauKy"] = giatrinhaptrongky - giatrixuattrongky;

        //                    dt2.Rows.Add(_ravi2);
        //                }
        //            }

        //        }
        //    }
        //    //}

        //    return dt2;
        //}

        //public DataTable TinhToan_NhapKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        //{

        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
        //    clsGapDan_ChiTiet_NhapKho cls = new clsGapDan_ChiTiet_NhapKho();
        //    cls.iID_VTHH = iiiIDVTHH;
        //    DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable dt22 = dv.ToTable();
        //    dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxxxx + "'";
        //    DataView dv2 = dt22.DefaultView;
        //    DataTable adt1 = dv2.ToTable();

        //    if (adt1.Rows.Count > 0)
        //    {
        //        DataTable bdt = new DataTable();
        //        bdt.Columns.Add("HienThi", typeof(bool));
        //        bdt.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //        bdt.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
        //        for (int i = 0; i < adt1.Rows.Count; i++)
        //        {
        //            DataRow xxx_ravi2 = bdt.NewRow();
        //            xxx_ravi2["HienThi"] = true;
        //            xxx_ravi2["SoLuongNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString());
        //            xxx_ravi2["GiaTriNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
        //            bdt.Rows.Add(xxx_ravi2);
        //        }
        //        double deSoLuongNhap_TrongKy, deGiaTriNhap_TrongKy;
        //        object xxdeSoLuongNhap_TrongKy = bdt.Compute("sum(SoLuongNhap_TrongKy)", "HienThi = True");
        //        deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);
        //        object xxGiaTriNhap_TrongKy = bdt.Compute("sum(GiaTriNhap_TrongKy)", "HienThi = True");
        //        deGiaTriNhap_TrongKy = Convert.ToDouble(xxGiaTriNhap_TrongKy);

        //        DataRow _ravi2 = dt2.NewRow();
        //        _ravi2["ID_VTHH"] = iiiIDVTHH;
        //        _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
        //        _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
        //        _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
        //        _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
        //        _ravi2["GiaTriNhap_TrongKy"] = deGiaTriNhap_TrongKy;
        //        dt2.Rows.Add(_ravi2);
        //    }
        //    return dt2;
        //}

        //public DataTable TinhToan_XuatKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        //{

        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
        //    clsGapDan_ChiTiet_XuatKho cls = new clsGapDan_ChiTiet_XuatKho();
        //    cls.iID_VTHH = iiiIDVTHH;
        //    //SelectOne_W_ID_VTHH_TinhToan_NXT
        //    DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable dt22 = dv.ToTable();
        //    dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxxxx + "'";
        //    DataView dv2 = dt22.DefaultView;
        //    DataTable adt1 = dv2.ToTable();
        //    if (adt1.Rows.Count > 0)
        //    {
        //        DataTable bdt = new DataTable();
        //        bdt.Columns.Add("HienThi", typeof(bool));
        //        bdt.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //        bdt.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
        //        for (int i = 0; i < adt1.Rows.Count; i++)
        //        {
        //            DataRow xxx_ravi2 = bdt.NewRow();
        //            xxx_ravi2["HienThi"] = true;
        //            xxx_ravi2["SoLuongXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString());
        //            xxx_ravi2["GiaTriXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
        //            bdt.Rows.Add(xxx_ravi2);
        //        }
        //        double deSoLuongXuat_TrongKy, deGiaTriXuat_TrongKy;
        //        object xxdeSoLuongXuat_TrongKy = bdt.Compute("sum(SoLuongXuat_TrongKy)", "HienThi = True");
        //        deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
        //        object xxdeGiaTriXuat_TrongKy = bdt.Compute("sum(GiaTriXuat_TrongKy)", "HienThi = True");
        //        deGiaTriXuat_TrongKy = Convert.ToDouble(xxdeGiaTriXuat_TrongKy);

        //        DataRow _ravi2 = dt2.NewRow();
        //        _ravi2["ID_VTHH"] = iiiIDVTHH;
        //        _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
        //        _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
        //        _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
        //        _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
        //        _ravi2["GiaTriXuat_TrongKy"] = deGiaTriXuat_TrongKy;
        //        dt2.Rows.Add(_ravi2);
        //    }
        //    return dt2;
        //}

        //public DataTable TinhToan_NhapKho_tonDauKy_ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        //{
        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
        //    clsGapDan_ChiTiet_NhapKho cls = new clsGapDan_ChiTiet_NhapKho();
        //    cls.iID_VTHH = iiiIDVTHH;
        //    DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<'" + denngayxxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable adt1 = dv.ToTable();
        //    if (adt1.Rows.Count > 0)
        //    {
        //        DataTable bdt = new DataTable();
        //        bdt.Columns.Add("HienThi", typeof(bool));
        //        bdt.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //        bdt.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
        //        for (int i = 0; i < adt1.Rows.Count; i++)
        //        {
        //            DataRow xxx_ravi2 = bdt.NewRow();
        //            xxx_ravi2["HienThi"] = true;
        //            xxx_ravi2["SoLuongNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString());
        //            xxx_ravi2["GiaTriNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
        //            bdt.Rows.Add(xxx_ravi2);
        //        }
        //        double deSoLuongNhap_TrongKy, deGiaTriNhap_TrongKy;
        //        object xxdeSoLuongNhap_TrongKy = bdt.Compute("sum(SoLuongNhap_TrongKy)", "HienThi = True");
        //        deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);
        //        object xxGiaTriNhap_TrongKy = bdt.Compute("sum(GiaTriNhap_TrongKy)", "HienThi = True");
        //        deGiaTriNhap_TrongKy = Convert.ToDouble(xxGiaTriNhap_TrongKy);
        //        DataRow _ravi2 = dt2.NewRow();
        //        _ravi2["ID_VTHH"] = iiiIDVTHH;
        //        _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
        //        _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
        //        _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
        //        _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
        //        _ravi2["GiaTriNhap_TrongKy"] = deGiaTriNhap_TrongKy;
        //        dt2.Rows.Add(_ravi2);
        //    }
        //    return dt2;
        //}

        //public DataTable TinhToan_XuatKho_tonDauKy__ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        //{

        //    DataTable dt2 = new DataTable();
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DonViTinh", typeof(string));
        //    dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //    dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
        //    clsGapDan_ChiTiet_XuatKho cls = new clsGapDan_ChiTiet_XuatKho();
        //    cls.iID_VTHH = iiiIDVTHH;
        //    DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
        //    dt.DefaultView.RowFilter = " NgayChungTu<'" + denngayxxx + "'";
        //    DataView dv = dt.DefaultView;
        //    DataTable adt1 = dv.ToTable();

        //    if (adt1.Rows.Count > 0)
        //    {

        //        DataTable bdt = new DataTable();
        //        bdt.Columns.Add("HienThi", typeof(bool));
        //        bdt.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //        bdt.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
        //        for (int i = 0; i < adt1.Rows.Count; i++)
        //        {
        //            DataRow xxx_ravi2 = bdt.NewRow();
        //            xxx_ravi2["HienThi"] = true;
        //            xxx_ravi2["SoLuongXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString());
        //            xxx_ravi2["GiaTriXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
        //            bdt.Rows.Add(xxx_ravi2);
        //        }
        //        double deSoLuongXuat_TrongKy, deGiaTriXuat_TrongKy;
        //        object xxdeSoLuongXuat_TrongKy = bdt.Compute("sum(SoLuongXuat_TrongKy)", "HienThi = True");
        //        deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
        //        object xxdeGiaTriXuat_TrongKy = bdt.Compute("sum(GiaTriXuat_TrongKy)", "HienThi = True");
        //        deGiaTriXuat_TrongKy = Convert.ToDouble(xxdeGiaTriXuat_TrongKy);
        //        DataRow _ravi2 = dt2.NewRow();
        //        _ravi2["ID_VTHH"] = iiiIDVTHH;
        //        _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
        //        _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
        //        _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
        //        _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
        //        _ravi2["GiaTriXuat_TrongKy"] = deGiaTriXuat_TrongKy;
        //        dt2.Rows.Add(_ravi2);

        //    }
        //    return dt2;
        //}
        //private void HienThi()
        //{
        //    if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
        //    {
        //        DateTime denngay = dteNgay.DateTime;
        //        DateTime tungay = dteTuNgay.DateTime;
        //        clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
        //        DataTable dt = cls.SelectAll_W_MaVT_TenVT_DVT_NXT();
        //        dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'";
        //        DataView dv = dt.DefaultView;
        //        DataTable dt22 = dv.ToTable();
        //        dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
        //        DataView dv2 = dt22.DefaultView;
        //        DataTable dxxxx = dv2.ToTable();

        //        DataTable dtnpl = tinhtoanNXT_NhapXuat_TrongKy(tungay, denngay);
        //        DataTable dtTonDauKy = tinhtoanNXT_Ton_DauKy(tungay, denngay);

        //        DataTable dt2 = new DataTable();
        //        dt2.Columns.Add("ID_VTHH", typeof(int));
        //        dt2.Columns.Add("MaVT", typeof(string));
        //        dt2.Columns.Add("TenVTHH", typeof(string));
        //        dt2.Columns.Add("DonViTinh", typeof(string));

        //        dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
        //        dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

        //        dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
        //        dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

        //        dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
        //        dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

        //        dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
        //        dt2.Columns.Add("GiaTriTon_CuoiKy", typeof(double));
        //        if (dtnpl.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtnpl.Rows.Count; i++)
        //            {
        //                int iiiiiID_VTHH;
        //                double SoLuong_TonDauKy;
        //                double GiaTri_TonDauKy;

        //                double SoLuongNhap_TrongKy;
        //                double GiaTriNhap_TrongKy;

        //                double SoLuongXuat_TrongKy;
        //                double GiaTriXuat_TrongKy;

        //                double SoLuongTon_CuoiKy;
        //                double GiaTriTon_CuoiKy;

        //                SoLuongNhap_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["SoLuongNhap_TrongKy"].ToString());
        //                GiaTriNhap_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["GiaTriNhap_TrongKy"].ToString());

        //                SoLuongXuat_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["SoLuongXuat_TrongKy"].ToString());
        //                GiaTriXuat_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["GiaTriXuat_TrongKy"].ToString());
        //                iiiiiID_VTHH = Convert.ToInt16(dtnpl.Rows[i]["ID_VTHH"].ToString());
        //                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
        //                DataRow[] rows = dtTonDauKy.Select(filterExpression);
        //                if (rows.Length == 0)
        //                {
        //                    SoLuong_TonDauKy = 0;
        //                    GiaTri_TonDauKy = 0;
        //                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
        //                    GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;

        //                    DataRow _ravi = dt2.NewRow();
        //                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
        //                    _ravi["MaVT"] = dtnpl.Rows[i]["MaVT"].ToString();
        //                    _ravi["TenVTHH"] = dtnpl.Rows[i]["TenVTHH"].ToString();
        //                    _ravi["DonViTinh"] = dtnpl.Rows[i]["DonViTinh"].ToString();

        //                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
        //                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

        //                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
        //                    _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

        //                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
        //                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

        //                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
        //                    _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;
        //                    dt2.Rows.Add(_ravi);
        //                }
        //                else
        //                {
        //                    SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[0]["SoLuong_TonDauKy"].ToString());
        //                    GiaTri_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[0]["GiaTri_TonDauKy"].ToString());
        //                    // GiaTri_TonDauKy = SoLuong_TonDauKy * dongiatondauky;
        //                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
        //                    GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;

        //                    DataRow _ravi = dt2.NewRow();
        //                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
        //                    _ravi["MaVT"] = dtnpl.Rows[i]["MaVT"].ToString();
        //                    _ravi["TenVTHH"] = dtnpl.Rows[i]["TenVTHH"].ToString();
        //                    _ravi["DonViTinh"] = dtnpl.Rows[i]["DonViTinh"].ToString();

        //                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
        //                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

        //                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
        //                    _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

        //                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
        //                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

        //                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
        //                    _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;
        //                    dt2.Rows.Add(_ravi);
        //                }
        //            }
        //            for (int i = 0; i < dtTonDauKy.Rows.Count; i++)
        //            {
        //                int iiiiiID_VTHH;
        //                double SoLuong_TonDauKy;
        //                double GiaTri_TonDauKy;

        //                double SoLuongNhap_TrongKy;
        //                double GiaTriNhap_TrongKy;

        //                double SoLuongXuat_TrongKy;
        //                double GiaTriXuat_TrongKy;

        //                double SoLuongTon_CuoiKy;
        //                double GiaTriTon_CuoiKy;

        //                SoLuongNhap_TrongKy = 0;
        //                GiaTriNhap_TrongKy = 0;

        //                SoLuongXuat_TrongKy = 0;
        //                GiaTriXuat_TrongKy = 0;

        //                iiiiiID_VTHH = Convert.ToInt16(dtTonDauKy.Rows[i]["ID_VTHH"].ToString());
        //                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
        //                DataRow[] rows = dtnpl.Select(filterExpression);
        //                if (rows.Length == 0)
        //                {
        //                    SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["SoLuong_TonDauKy"].ToString());
        //                    GiaTri_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["GiaTri_TonDauKy"].ToString());
        //                    SoLuongNhap_TrongKy = 0;
        //                    GiaTriNhap_TrongKy = 0;

        //                    SoLuongXuat_TrongKy = 0;
        //                    GiaTriXuat_TrongKy = 0;
        //                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
        //                    GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;
        //                    DataRow _ravi = dt2.NewRow();
        //                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
        //                    _ravi["MaVT"] = dtTonDauKy.Rows[i]["MaVT"].ToString();
        //                    _ravi["TenVTHH"] = dtTonDauKy.Rows[i]["TenVTHH"].ToString();
        //                    _ravi["DonViTinh"] = dtTonDauKy.Rows[i]["DonViTinh"].ToString();

        //                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
        //                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;

        //                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
        //                    _ravi["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;

        //                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
        //                    _ravi["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;

        //                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
        //                    _ravi["GiaTriTon_CuoiKy"] = GiaTriTon_CuoiKy;
        //                    dt2.Rows.Add(_ravi);

        //                }
        //            }
        //        }


        //        gridControl1.DataSource = dt2;
        //    }
        //}
        #endregion

        public DataTable tinhtoanNXT_NhapXuat_TrongKy(DateTime tungayxx, DateTime denngayxx)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            //SelectAll_W_MaVT_TenVT_DVT_NXT
            DataTable dt = cls.SelectAll_W_MaVT_TenVT_DVT_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxx + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxx + "'";
            DataView dv2 = dt22.DefaultView;
            DataTable dxxxx = dv2.ToTable();

            DataTable dtDISTINCT = cls.SelectAll_distinct();


            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
                    string expression;
                    expression = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dxxxx.Select(expression);
                    if (foundRows.Length > 0)
                    {
                        DataTable dtnhapkho = TinhToan_NhapKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
                        if (dtnhapkho.Rows.Count > 0)
                        {
                            DataRow _ravi2 = dt2.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHHxxx;
                            _ravi2["MaVT"] = dtnhapkho.Rows[0]["MaVT"].ToString();
                            _ravi2["TenVTHH"] = dtnhapkho.Rows[0]["TenVTHH"].ToString();
                            _ravi2["DonViTinh"] = dtnhapkho.Rows[0]["DonViTinh"].ToString();
                            double soluongnhaptrognky, giatrinhaptrongky, soluongxuattrognky, giatrixuattrongky;
                            soluongnhaptrognky = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongNhap_TrongKy"].ToString());
                            giatrinhaptrongky = Convert.ToDouble(dtnhapkho.Rows[0]["GiaTriNhap_TrongKy"].ToString());
                            DataTable dtxuatkho = TinhToan_XuatKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
                            if (dtxuatkho.Rows.Count > 0)
                            {
                                soluongxuattrognky = Convert.ToDouble(dtxuatkho.Rows[0]["SoLuongXuat_TrongKy"].ToString());
                                giatrixuattrongky = Convert.ToDouble(dtxuatkho.Rows[0]["GiaTriXuat_TrongKy"].ToString());
                            }
                            else
                            {
                                soluongxuattrognky = 0;
                                giatrixuattrongky = 0;
                            }

                            _ravi2["SoLuongNhap_TrongKy"] = soluongnhaptrognky;
                            _ravi2["GiaTriNhap_TrongKy"] = giatrinhaptrongky;
                            _ravi2["SoLuongXuat_TrongKy"] = soluongxuattrognky;
                            _ravi2["GiaTriXuat_TrongKy"] = giatrixuattrongky;
                            dt2.Rows.Add(_ravi2);
                        }
                    }

                }
            }
            return dt2;
        }
        public DataTable tinhtoanNXT_Ton_DauKy(DateTime tungayxx, DateTime denngayxx)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            clsGapDan_ChiTiet_NhapKho clsnpl = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            DataTable dt = clsnpl.SelectAll_W_MaVT_TenVT_DVT_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + tungayxx + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            
            DataTable dtDISTINCT = clsnpl.SelectAll_distinct();


            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
                    string expression;
                    expression = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt22.Select(expression);
                    if (foundRows.Length > 0)
                    {
                        DataTable dtnhapkho = TinhToan_NhapKho_tonDauKy_ID_VTHH(ID_VTHHxxx, tungayxx);
                        if (dtnhapkho.Rows.Count > 0)
                        {
                            DataRow _ravi2 = dt2.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHHxxx;
                            _ravi2["MaVT"] = dtnhapkho.Rows[0]["MaVT"].ToString();
                            _ravi2["TenVTHH"] = dtnhapkho.Rows[0]["TenVTHH"].ToString();
                            _ravi2["DonViTinh"] = dtnhapkho.Rows[0]["DonViTinh"].ToString();
                            double soluongnhaptrognky, giatrinhaptrongky, soluongxuattrognky, giatrixuattrongky;
                            soluongnhaptrognky = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongNhap_TrongKy"].ToString());
                            giatrinhaptrongky = Convert.ToDouble(dtnhapkho.Rows[0]["GiaTriNhap_TrongKy"].ToString());
                            DataTable dtxuatkho = TinhToan_XuatKho_tonDauKy__ID_VTHH(ID_VTHHxxx, tungayxx);
                            if (dtxuatkho.Rows.Count > 0)
                            {
                                soluongxuattrognky = Convert.ToDouble(dtxuatkho.Rows[0]["SoLuongXuat_TrongKy"].ToString());
                                giatrixuattrongky = Convert.ToDouble(dtxuatkho.Rows[0]["GiaTriXuat_TrongKy"].ToString());
                            }
                            else
                            {
                                soluongxuattrognky = 0;
                                giatrixuattrongky = 0;
                            }

                            _ravi2["SoLuong_TonDauKy"] = soluongnhaptrognky - soluongxuattrognky;
                            _ravi2["GiaTri_TonDauKy"] = giatrinhaptrongky - giatrixuattrongky;

                            dt2.Rows.Add(_ravi2);
                        }
                    }

                }
            }           

            return dt2;
        }

        public DataTable TinhToan_NhapKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            clsGapDan_ChiTiet_NhapKho cls = new clsGapDan_ChiTiet_NhapKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxxxx + "'";
            DataView dv2 = dt22.DefaultView;
            DataTable adt1 = dv2.ToTable();

            if (adt1.Rows.Count > 0)
            {
                DataTable bdt = new DataTable();
                bdt.Columns.Add("HienThi", typeof(bool));
                bdt.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
                bdt.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
                for (int i = 0; i < adt1.Rows.Count; i++)
                {
                    DataRow xxx_ravi2 = bdt.NewRow();
                    xxx_ravi2["HienThi"] = true;
                    xxx_ravi2["SoLuongNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString());
                    xxx_ravi2["GiaTriNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
                    bdt.Rows.Add(xxx_ravi2);
                }
                double deSoLuongNhap_TrongKy, deGiaTriNhap_TrongKy;
                object xxdeSoLuongNhap_TrongKy = bdt.Compute("sum(SoLuongNhap_TrongKy)", "HienThi = True");
                deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);
                object xxGiaTriNhap_TrongKy = bdt.Compute("sum(GiaTriNhap_TrongKy)", "HienThi = True");
                deGiaTriNhap_TrongKy = Convert.ToDouble(xxGiaTriNhap_TrongKy);

                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID_VTHH"] = iiiIDVTHH;
                _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
                _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
                _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
                _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
                _ravi2["GiaTriNhap_TrongKy"] = deGiaTriNhap_TrongKy;
                dt2.Rows.Add(_ravi2);
            }
            return dt2;
        }

        public DataTable TinhToan_XuatKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
            clsGapDan_ChiTiet_XuatKho cls = new clsGapDan_ChiTiet_XuatKho();
            cls.iID_VTHH = iiiIDVTHH;
            //SelectOne_W_ID_VTHH_TinhToan_NXT
            DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxxxx + "'";
            DataView dv2 = dt22.DefaultView;
            DataTable adt1 = dv2.ToTable();
            if (adt1.Rows.Count > 0)
            {
                DataTable bdt = new DataTable();
                bdt.Columns.Add("HienThi", typeof(bool));
                bdt.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
                bdt.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
                for (int i = 0; i < adt1.Rows.Count; i++)
                {
                    DataRow xxx_ravi2 = bdt.NewRow();
                    xxx_ravi2["HienThi"] = true;
                    xxx_ravi2["SoLuongXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString());
                    xxx_ravi2["GiaTriXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
                    bdt.Rows.Add(xxx_ravi2);
                }
                double deSoLuongXuat_TrongKy, deGiaTriXuat_TrongKy;
                object xxdeSoLuongXuat_TrongKy = bdt.Compute("sum(SoLuongXuat_TrongKy)", "HienThi = True");
                deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
                object xxdeGiaTriXuat_TrongKy = bdt.Compute("sum(GiaTriXuat_TrongKy)", "HienThi = True");
                deGiaTriXuat_TrongKy = Convert.ToDouble(xxdeGiaTriXuat_TrongKy);

                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID_VTHH"] = iiiIDVTHH;
                _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
                _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
                _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
                _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
                _ravi2["GiaTriXuat_TrongKy"] = deGiaTriXuat_TrongKy;
                dt2.Rows.Add(_ravi2);
            }
            return dt2;
        }

        public DataTable TinhToan_NhapKho_tonDauKy_ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            clsGapDan_ChiTiet_NhapKho cls = new clsGapDan_ChiTiet_NhapKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<'" + denngayxxx + "'";
            DataView dv = dt.DefaultView;
            DataTable adt1 = dv.ToTable();
            if (adt1.Rows.Count > 0)
            {
                DataTable bdt = new DataTable();
                bdt.Columns.Add("HienThi", typeof(bool));
                bdt.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
                bdt.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
                for (int i = 0; i < adt1.Rows.Count; i++)
                {
                    DataRow xxx_ravi2 = bdt.NewRow();
                    xxx_ravi2["HienThi"] = true;
                    xxx_ravi2["SoLuongNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString());
                    xxx_ravi2["GiaTriNhap_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongNhap"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
                    bdt.Rows.Add(xxx_ravi2);
                }
                double deSoLuongNhap_TrongKy, deGiaTriNhap_TrongKy;
                object xxdeSoLuongNhap_TrongKy = bdt.Compute("sum(SoLuongNhap_TrongKy)", "HienThi = True");
                deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);
                object xxGiaTriNhap_TrongKy = bdt.Compute("sum(GiaTriNhap_TrongKy)", "HienThi = True");
                deGiaTriNhap_TrongKy = Convert.ToDouble(xxGiaTriNhap_TrongKy);
                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID_VTHH"] = iiiIDVTHH;
                _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
                _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
                _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
                _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
                _ravi2["GiaTriNhap_TrongKy"] = deGiaTriNhap_TrongKy;
                dt2.Rows.Add(_ravi2);
            }
            return dt2;
        }

        public DataTable TinhToan_XuatKho_tonDauKy__ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
            clsGapDan_ChiTiet_XuatKho cls = new clsGapDan_ChiTiet_XuatKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectOne_W_ID_VTHH_TinhToan_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<'" + denngayxxx + "'";
            DataView dv = dt.DefaultView;
            DataTable adt1 = dv.ToTable();

            if (adt1.Rows.Count > 0)
            {

                DataTable bdt = new DataTable();
                bdt.Columns.Add("HienThi", typeof(bool));
                bdt.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
                bdt.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
                for (int i = 0; i < adt1.Rows.Count; i++)
                {
                    DataRow xxx_ravi2 = bdt.NewRow();
                    xxx_ravi2["HienThi"] = true;
                    xxx_ravi2["SoLuongXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString());
                    xxx_ravi2["GiaTriXuat_TrongKy"] = Convert.ToDouble(adt1.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(adt1.Rows[i]["DonGia"].ToString());
                    bdt.Rows.Add(xxx_ravi2);
                }
                double deSoLuongXuat_TrongKy, deGiaTriXuat_TrongKy;
                object xxdeSoLuongXuat_TrongKy = bdt.Compute("sum(SoLuongXuat_TrongKy)", "HienThi = True");
                deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
                object xxdeGiaTriXuat_TrongKy = bdt.Compute("sum(GiaTriXuat_TrongKy)", "HienThi = True");
                deGiaTriXuat_TrongKy = Convert.ToDouble(xxdeGiaTriXuat_TrongKy);
                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID_VTHH"] = iiiIDVTHH;
                _ravi2["MaVT"] = adt1.Rows[0]["MaVT"].ToString();
                _ravi2["TenVTHH"] = adt1.Rows[0]["TenVTHH"].ToString();
                _ravi2["DonViTinh"] = adt1.Rows[0]["DonViTinh"].ToString();
                _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
                _ravi2["GiaTriXuat_TrongKy"] = deGiaTriXuat_TrongKy;
                dt2.Rows.Add(_ravi2);

            }
            return dt2;
        }
        private void HienThi()
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                DateTime denngay = dteNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;
                clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
                DataTable dt = cls.SelectAll_W_MaVT_TenVT_DVT_NXT();
                dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'";
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                DataTable dxxxx = dv2.ToTable();

                DataTable dtnpl = tinhtoanNXT_NhapXuat_TrongKy(tungay, denngay);
                DataTable dtTonDauKy = tinhtoanNXT_Ton_DauKy(tungay, denngay);

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
                if (dtnpl.Rows.Count > 0)
                {
                    for (int i = 0; i < dtnpl.Rows.Count; i++)
                    {
                        int iiiiiID_VTHH;
                        double SoLuong_TonDauKy;
                        double GiaTri_TonDauKy;

                        double SoLuongNhap_TrongKy;
                        double GiaTriNhap_TrongKy;

                        double SoLuongXuat_TrongKy;
                        double GiaTriXuat_TrongKy;

                        double SoLuongTon_CuoiKy;
                        double GiaTriTon_CuoiKy;

                        SoLuongNhap_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                        GiaTriNhap_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                        SoLuongXuat_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                        GiaTriXuat_TrongKy = Convert.ToDouble(dtnpl.Rows[i]["GiaTriXuat_TrongKy"].ToString());
                        iiiiiID_VTHH = Convert.ToInt16(dtnpl.Rows[i]["ID_VTHH"].ToString());
                        string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                        DataRow[] rows = dtTonDauKy.Select(filterExpression);
                        if (rows.Length == 0)
                        {
                            SoLuong_TonDauKy = 0;
                            GiaTri_TonDauKy = 0;
                            SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                            GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;

                            DataRow _ravi = dt2.NewRow();
                            _ravi["ID_VTHH"] = iiiiiID_VTHH;
                            _ravi["MaVT"] = dtnpl.Rows[i]["MaVT"].ToString();
                            _ravi["TenVTHH"] = dtnpl.Rows[i]["TenVTHH"].ToString();
                            _ravi["DonViTinh"] = dtnpl.Rows[i]["DonViTinh"].ToString();

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
                        else
                        {
                            SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[0]["SoLuong_TonDauKy"].ToString());
                            GiaTri_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[0]["GiaTri_TonDauKy"].ToString());
                            // GiaTri_TonDauKy = SoLuong_TonDauKy * dongiatondauky;
                            SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                            GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;

                            DataRow _ravi = dt2.NewRow();
                            _ravi["ID_VTHH"] = iiiiiID_VTHH;
                            _ravi["MaVT"] = dtnpl.Rows[i]["MaVT"].ToString();
                            _ravi["TenVTHH"] = dtnpl.Rows[i]["TenVTHH"].ToString();
                            _ravi["DonViTinh"] = dtnpl.Rows[i]["DonViTinh"].ToString();

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
                    for (int i = 0; i < dtTonDauKy.Rows.Count; i++)
                    {
                        int iiiiiID_VTHH;
                        double SoLuong_TonDauKy;
                        double GiaTri_TonDauKy;

                        double SoLuongNhap_TrongKy;
                        double GiaTriNhap_TrongKy;

                        double SoLuongXuat_TrongKy;
                        double GiaTriXuat_TrongKy;

                        double SoLuongTon_CuoiKy;
                        double GiaTriTon_CuoiKy;

                        SoLuongNhap_TrongKy = 0;
                        GiaTriNhap_TrongKy = 0;

                        SoLuongXuat_TrongKy = 0;
                        GiaTriXuat_TrongKy = 0;

                        iiiiiID_VTHH = Convert.ToInt16(dtTonDauKy.Rows[i]["ID_VTHH"].ToString());
                        string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                        DataRow[] rows = dtnpl.Select(filterExpression);
                        if (rows.Length == 0)
                        {
                            SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["SoLuong_TonDauKy"].ToString());
                            GiaTri_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["GiaTri_TonDauKy"].ToString());
                            SoLuongNhap_TrongKy = 0;
                            GiaTriNhap_TrongKy = 0;

                            SoLuongXuat_TrongKy = 0;
                            GiaTriXuat_TrongKy = 0;
                            SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                            GiaTriTon_CuoiKy = GiaTri_TonDauKy + GiaTriNhap_TrongKy - GiaTriXuat_TrongKy;
                            DataRow _ravi = dt2.NewRow();
                            _ravi["ID_VTHH"] = iiiiiID_VTHH;
                            _ravi["MaVT"] = dtTonDauKy.Rows[i]["MaVT"].ToString();
                            _ravi["TenVTHH"] = dtTonDauKy.Rows[i]["TenVTHH"].ToString();
                            _ravi["DonViTinh"] = dtTonDauKy.Rows[i]["DonViTinh"].ToString();

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
                }


                gridControl1.DataSource = dt2;
            }
        }

        public UCDaiLy_GapDan_baocao_NXT()
        {
            InitializeComponent();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi();
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
                {
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteNgay.DateTime;
                    miiID_VTHH = Convert.ToInt16(bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                    //msoluongTonDauKy, mGiaTriTonDauKy;
                    msoluongTonDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuong_TonDauKy).ToString());
                    mGiaTriTonDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clGiaTri_TonDauKy).ToString());
                    GapDan_frmChiTietNhapXuatTon_MotVatTu ff = new GapDan_frmChiTietNhapXuatTon_MotVatTu();
                    ff.Show();
                }

            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                mbPrint_NXT_Kho = true;
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdt_ChiTiet_Print = dv1212.ToTable();
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteNgay.DateTime;
                msNguoiLap_Prtint = "";
                if (mdt_ChiTiet_Print.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu");
                else
                {                   
                    frmPrint_Nhap_Xuat_Ton_TongHop ff = new frmPrint_Nhap_Xuat_Ton_TongHop();
                    ff.Show();
                }
            }
        }

        private void UCDaiLy_GapDan_baocao_NXT_Load(object sender, EventArgs e)
        {
            DateTime ngaydautien, ngaycuoicung;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            dteNgay.EditValue = ngaycuoicung;
            dteTuNgay.EditValue = ngaydautien;
            HienThi();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCDaiLy_GapDan_baocao_NXT_Load( sender,  e);
        }
    }
}
