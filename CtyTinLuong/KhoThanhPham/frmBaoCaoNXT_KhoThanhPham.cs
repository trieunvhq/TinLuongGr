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
    public partial class frmBaoCaoNXT_KhoThanhPham : Form
    {
        public static bool mbPrint_NXT_Kho_NPL = false;
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

        public DataTable NPL_tinhtoanNXT_NhapXuat_TrongKy(DateTime tungayxx, DateTime denngayxx)
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

            clsKhoThanhPham_tbChiTietNhapKho cls1 = new CtyTinLuong.clsKhoThanhPham_tbChiTietNhapKho();

            DataTable dt = cls1.SelectAll_MaVT_TenVT_DVT_NXT();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxx + "'and DaNhapKho=True";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungayxx + "'";
            DataView dv2 = dt22.DefaultView;
            DataTable dtNHAPKHO = dv2.ToTable();
            DataTable dtDISTINCT = cls1.SelectAll_distinct();

            clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();
            DataTable dt2222 = cls2.SelectAll_MaVT_TenVT_DVT_NXT();
            dt2222.DefaultView.RowFilter = " NgayChungTu<='" + denngayxx + "'and DaXuatKho=True";
            DataView dv222321 = dt2222.DefaultView;
            DataTable dt22cccsss = dv222321.ToTable();
            dt22cccsss.DefaultView.RowFilter = " NgayChungTu>='" + tungayxx + "'";
            DataView dv12121xxxxx2 = dt22cccsss.DefaultView;
            DataTable dtXUATKHO = dv12121xxxxx2.ToTable();

            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
                    string MaVT, TenVTHH, DonViTinh;
                    clsTbVatTuHangHoa clsvthh = new clsTbVatTuHangHoa();
                    clsvthh.iID_VTHH = ID_VTHHxxx;
                    DataTable dtvthhhahhh = clsvthh.SelectOne();
                    MaVT = clsvthh.sMaVT.Value;
                    TenVTHH = clsvthh.sTenVTHH.Value;
                    DonViTinh = clsvthh.sDonViTinh.Value;

                    double SoLuongNhap_TrongKy, GiaTriNhap_TrongKy, SoLuongXuat_TrongKy, GiaTriXuat_TrongKy;
                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows_NhapKho;
                    foundRows_NhapKho = dtNHAPKHO.Select(expressionnhapkho);

                    string expressionxuatkho;
                    expressionxuatkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows_XuatKho;
                    foundRows_XuatKho = dtXUATKHO.Select(expressionxuatkho);

                    if (foundRows_NhapKho.Length > 0) //có nhập kho
                    {
                        DataTable dtnhapkho_MotVat_tu = NPL_TinhToan_NhapKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
                        SoLuongNhap_TrongKy = Convert.ToDouble(dtnhapkho_MotVat_tu.Rows[0]["SoLuongNhap_TrongKy"].ToString());
                        GiaTriNhap_TrongKy = Convert.ToDouble(dtnhapkho_MotVat_tu.Rows[0]["GiaTriNhap_TrongKy"].ToString());

                        if (foundRows_XuatKho.Length > 0) // có  xuất kho
                        {
                            DataTable dtxuatkho_maotVatTu = NPL_TinhToan_XuatKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
                            SoLuongXuat_TrongKy = Convert.ToDouble(dtxuatkho_maotVatTu.Rows[0]["SoLuongXuat_TrongKy"].ToString());
                            GiaTriXuat_TrongKy = Convert.ToDouble(dtxuatkho_maotVatTu.Rows[0]["GiaTriXuat_TrongKy"].ToString());
                        }
                        else // không có xuất kho
                        {
                            SoLuongXuat_TrongKy = 0;
                            GiaTriXuat_TrongKy = 0;
                        }
                    }
                    else // không có nhập kho
                    {
                        SoLuongNhap_TrongKy = 0;
                        GiaTriNhap_TrongKy = 0;

                        if (foundRows_XuatKho.Length > 0) // có  xuất kho
                        {
                            DataTable dtxuatkho_maotVatTu = NPL_TinhToan_XuatKho_ID_VTHH(ID_VTHHxxx, tungayxx, denngayxx);
                            SoLuongXuat_TrongKy = Convert.ToDouble(dtxuatkho_maotVatTu.Rows[0]["SoLuongXuat_TrongKy"].ToString());
                            GiaTriXuat_TrongKy = Convert.ToDouble(dtxuatkho_maotVatTu.Rows[0]["GiaTriXuat_TrongKy"].ToString());
                        }
                        else // không có xuất kho
                        {
                            SoLuongXuat_TrongKy = 0;
                            GiaTriXuat_TrongKy = 0;
                        }
                    }

                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_VTHH"] = ID_VTHHxxx;
                    _ravi2["MaVT"] = MaVT;
                    _ravi2["TenVTHH"] = TenVTHH;
                    _ravi2["DonViTinh"] = DonViTinh;
                    _ravi2["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                    _ravi2["GiaTriNhap_TrongKy"] = GiaTriNhap_TrongKy;
                    _ravi2["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi2["GiaTriXuat_TrongKy"] = GiaTriXuat_TrongKy;
                    dt2.Rows.Add(_ravi2);


                }
            }


            return dt2;

        }

        public DataTable NPL_tinhtoanNXT_Ton_DauKy(DateTime tungayxx, DateTime denngayxx)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            clsKhoThanhPham_tbChiTietNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbChiTietNhapKho();
            DataTable dt = cls.SelectAll_MaVT_TenVT_DVT_NXT();
            dt.DefaultView.RowFilter = "bool_TonDauKy = False and NgayChungTu<='" + tungayxx + "'and DaNhapKho=True";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            DataTable dtDISTINCT = cls.SelectAll_distinct();
            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    int ID_VTHHxxx = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());
                    DataTable dtcnjsj = cls.SelectAll();
                    dtcnjsj.DefaultView.RowFilter = " bool_TonDauKy = True and ID_VTHH=" + ID_VTHHxxx + "";
                    DataView dv222 = dtcnjsj.DefaultView;
                    DataTable dt0 = dv222.ToTable();
                    DataTable dtnhapkho = NPL_TinhToan_NhapKho_tonDauKy_ID_VTHH(ID_VTHHxxx, tungayxx);
                    DataTable dtxuatkho = NPL_TinhToan_XuatKho_tonDauKy__ID_VTHH(ID_VTHHxxx, tungayxx);
                    double soluongton_khong, giatriton_khong, soluongnhap, giatrinhap, soluongxuat, giatrixuat;
                    if (dt0.Rows.Count > 0) // có tồn không
                    {
                        soluongton_khong = Convert.ToDouble(dt0.Rows[0]["SoLuongNhap"].ToString());
                        double giatrikhong = Convert.ToDouble(dt0.Rows[0]["DonGia"].ToString());
                        giatriton_khong = soluongton_khong * giatrikhong;
                    }
                    else // không có tồn không
                    {
                        soluongton_khong = giatriton_khong = 0;
                    }

                    if (dtnhapkho.Rows.Count > 0) // có nhập
                    {
                        soluongnhap = Convert.ToDouble(dtnhapkho.Rows[0]["SoLuongNhap_TrongKy"].ToString());
                        giatrinhap = Convert.ToDouble(dtnhapkho.Rows[0]["GiaTriNhap_TrongKy"].ToString());
                    }
                    else // không có nhập
                    {
                        soluongnhap = giatrinhap = 0;
                    }

                    if (dtxuatkho.Rows.Count > 0) // có xuất
                    {
                        soluongxuat = Convert.ToDouble(dtxuatkho.Rows[0]["SoLuongXuat_TrongKy"].ToString());
                        giatrixuat = Convert.ToDouble(dtxuatkho.Rows[0]["GiaTriXuat_TrongKy"].ToString());
                    }
                    else // không có xuất
                    {
                        soluongxuat = giatrixuat = 0;
                    }

                    if (dt0.Rows.Count > 0)
                    {
                        DataRow _ravi2 = dt2.NewRow();
                        _ravi2["ID_VTHH"] = ID_VTHHxxx;
                        _ravi2["SoLuong_TonDauKy"] = soluongton_khong + soluongnhap - soluongxuat;
                        _ravi2["GiaTri_TonDauKy"] = giatriton_khong + giatrinhap - giatrixuat;
                        dt2.Rows.Add(_ravi2);
                    }
                    else // không có tồn ko
                    {
                        if (dtnhapkho.Rows.Count > 0) //có nhập
                        {
                            DataRow _ravi2 = dt2.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHHxxx;
                            _ravi2["SoLuong_TonDauKy"] = soluongton_khong + soluongnhap - soluongxuat;
                            _ravi2["GiaTri_TonDauKy"] = giatriton_khong + giatrinhap - giatrixuat;
                            dt2.Rows.Add(_ravi2);
                        }
                        else
                        {
                            if (dtxuatkho.Rows.Count > 0) //có xuất
                            {
                                DataRow _ravi2 = dt2.NewRow();
                                _ravi2["ID_VTHH"] = ID_VTHHxxx;
                                _ravi2["SoLuong_TonDauKy"] = soluongton_khong + soluongnhap - soluongxuat;
                                _ravi2["GiaTri_TonDauKy"] = giatriton_khong + giatrinhap - giatrixuat;
                                dt2.Rows.Add(_ravi2);
                            }

                        }
                    }
                }

            }

            return dt2;
        }
        public DataTable NPL_TinhToan_NhapKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));

            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            clsKhoThanhPham_tbChiTietNhapKho cls = new clsKhoThanhPham_tbChiTietNhapKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectOne_W_ID_VTHH_W_NgayThang_newwwwwwww();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'and DaNhapKho=True";
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

        public DataTable NPL_TinhToan_XuatKho_ID_VTHH(int iiiIDVTHH, DateTime tungayxxxx, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
            clsKhoThanhPham_tbChiTietXuatKho cls = new clsKhoThanhPham_tbChiTietXuatKho();
            cls.iID_VTHH = iiiIDVTHH;
            //DataTable dt = cls.SelectAll_W_ID_VTHH_TinhToan_TenDaiLy_NXT();
            DataTable dt = cls.SelectAll_W_ID_VTHH_TinhToan_N_X_T();
            dt.DefaultView.RowFilter = " NgayChungTu<='" + denngayxxx + "'and DaXuatKho=True";
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

        public DataTable NPL_TinhToan_NhapKho_tonDauKy_ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));
            clsKhoThanhPham_tbChiTietNhapKho cls = new clsKhoThanhPham_tbChiTietNhapKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectOne_W_ID_VTHH_W_NgayThang_newwwwwwww();
            dt.DefaultView.RowFilter = "bool_TonDauKy = False and NgayChungTu<'" + denngayxxx + "'and DaNhapKho=True";
            DataView dv = dt.DefaultView;
            DataTable adt1 = dv.ToTable();


            if (adt1.Rows.Count > 0) // có nhập
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
            } // không có nhập

            return dt2;
        }

        public DataTable NPL_TinhToan_XuatKho_tonDauKy__ID_VTHH(int iiiIDVTHH, DateTime denngayxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));
            clsKhoThanhPham_tbChiTietXuatKho cls = new clsKhoThanhPham_tbChiTietXuatKho();
            cls.iID_VTHH = iiiIDVTHH;
            DataTable dt = cls.SelectAll_W_ID_VTHH_TinhToan_N_X_T();
            dt.DefaultView.RowFilter = " NgayChungTu<'" + denngayxxx + "'and DaXuatKho=True";
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

        private void NPL_HienThi()
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                DateTime denngay = dteDenNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;
                clsKhoThanhPham_tbChiTietNhapKho cls = new CtyTinLuong.clsKhoThanhPham_tbChiTietNhapKho();


                DataTable dttrongky = NPL_tinhtoanNXT_NhapXuat_TrongKy(tungay, denngay);
                DataTable dtTonDauKy = NPL_tinhtoanNXT_Ton_DauKy(tungay, denngay);

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


                for (int i = 0; i < dttrongky.Rows.Count; i++)
                {
                    int iiiiiID_VTHH;
                    iiiiiID_VTHH = Convert.ToInt16(dttrongky.Rows[i]["ID_VTHH"].ToString());

                    double SoLuong_TonDauKy, GiaTri_TonDauKy, SoLuongNhap_TrongKy, GiaTriNhap_TrongKy,
                        SoLuongXuat_TrongKy, GiaTriXuat_TrongKy, SoLuongTon_CuoiKy, GiaTriTon_CuoiKy;

                    SoLuongNhap_TrongKy = Convert.ToDouble(dttrongky.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                    GiaTriNhap_TrongKy = Convert.ToDouble(dttrongky.Rows[i]["GiaTriNhap_TrongKy"].ToString());

                    SoLuongXuat_TrongKy = Convert.ToDouble(dttrongky.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                    GiaTriXuat_TrongKy = Convert.ToDouble(dttrongky.Rows[i]["GiaTriXuat_TrongKy"].ToString());

                    string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                    DataRow[] rows = dtTonDauKy.Select(filterExpression);
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
                    DataRow[] rows = dttrongky.Select(filterExpression);
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

                gridControl1.DataSource = dt2;
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                NPL_HienThi();
            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            {
                if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
                {
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;
                    miiID_VTHH = Convert.ToInt16(bandedGridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                    //msoluongTonDauKy, mGiaTriTonDauKy;
                    msoluongTonDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clSoLuong_TonDauKy).ToString());
                    mGiaTriTonDauKy = Convert.ToDouble(bandedGridView1.GetFocusedRowCellValue(clGiaTri_TonDauKy).ToString());


                    frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham ff2 = new frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham();
                    ff2.Show();
                }

            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                mbPrint_NXT_Kho_NPL = true;
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = bandedGridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                mdt_ChiTiet_Print = dv1212.ToTable();

                if (mdt_ChiTiet_Print.Rows.Count == 0)
                    MessageBox.Show("Không có dữ liệu");
                else
                {
                    mdatungay = dteTuNgay.DateTime;
                    mdadenngay = dteDenNgay.DateTime;
                    msNguoiLap_Prtint = "";
                    frmPrint_Nhap_Xuat_Ton_TongHop ff = new frmPrint_Nhap_Xuat_Ton_TongHop();
                    ff.Show();

                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmBaoCaoNXT_KhoThanhPham_Load( sender,  e); 
        }

        public frmBaoCaoNXT_KhoThanhPham()
        {
            InitializeComponent();
        }

        private void frmBaoCaoNXT_KhoThanhPham_Load(object sender, EventArgs e)
        {
            DateTime ngaydautien, ngaycuoicung;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            dteDenNgay.EditValue = ngaycuoicung;
            dteTuNgay.EditValue = ngaydautien;
            NPL_HienThi();
        }
    }
}
