using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Tr_frmChiTiet_LuongSanLuongCN_TMC : Form
    {
        private List<GridColumn> ds_grid = new List<GridColumn>();
        private int _thang, _nam, _ID_CongNhan, _id_bophan;
        private string _tenNV;
        private bool isload = true;
        private bool _deleted_29 = false;
        private bool _deleted_30 = false;
        private bool _deleted_31 = false;

        DataTable _dataSL, _dataLuong;

        DateTime ngaydauthang, ngaycuoithang;
        private void Load_LockUp()
        {
            //    try
            //    {
            //        using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
            //        {
            //            DataTable dt = cls.SelectAll_distinct_ID_CongNhan_W_NgayThang(ngaydauthang, ngaycuoithang);

            //            gridCongNhan.Properties.DataSource = dt;
            //            gridCongNhan.Properties.ValueMember = "ID_CongNhan";
            //            gridCongNhan.Properties.DisplayMember = "MaNhanVien";
            //        }
            //    }
            //    catch (Exception ea)
            //    {
            //        MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        DataTable dt2;

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

        public void LoadData(bool islandau)
        {
            _dataSL.Clear();
            _dataLuong.Clear();

            isload = true;

            double _ThanhTien_Tong_BL = 0;  //Thành tiền
            double _ThucNhan_Tong_BL = 0;
            double _NgayCong_Tong_BL = 0;
            double _SanLuong_Tong_BL = 0;
            double _XangXe_Tong_BL = 0;
            double _BaoHiem_Tong_BL = 0;
            double _PCBaoHiem_Tong_BL = 0;
            double _Tong_BL = 0;

            List<int> DsID_Vthh_ = new List<int>();
            double[] DsTongNgay = new double[31];
            for (int i = 0; i < 31; i++) DsTongNgay[i] = 0;

            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }
            else
            {
            }

            ChangeColTitle(_thang, _nam);
            lbThangNamTitle.Text = "BẢNG KẾT QUẢ THÁNG " + _thang + " NĂM " + _nam;
            lbTenCN.Text = "(Họ tên: " + _tenNV + " - Bộ phận: Máy cắt)";

            try
            {
                using (clsThin clsth = new clsThin())
                {
                    DataTable dt = clsth.Tr_Phieu_ChiTietPhieu_New_ToInCatDot_SelectOne(_nam, _thang, 0, 1, 0, "", _id_bophan, _ID_CongNhan);
                    if (dt.Rows.Count == 0)
                    {
                        isload = false;
                        return;
                    }

                    DataTable dtTang = clsth.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectOneCN_TMC(_nam, _thang, _id_bophan, _ID_CongNhan, 2);

                    int ID_VTHHRoot = -1;
                    int SttSL = 0;
                    int SttBL = 0;

                    double[] DsNgayCong = new double[31];
                    double SoNgayCong = 0;

                    ModelShowSanLuongToIn dotTang = getNV_SanLuong_DotTang(dt);
                    if (dotTang.DsIdVthh_DotTang.Count > 0)
                    {
                        DataRow ravi_ = _dataSL.NewRow();
                        SttSL++;
                        ravi_["STT"] = SttSL;
                        ravi_["ID_CongNhan"] = _ID_CongNhan;
                        ravi_["MaVT"] = dotTang.MaVT;
                        ravi_["TenVTHH"] = dotTang.TenVthhThuong;

                        for (int k = 0; k < 31; k++)
                        {
                            ravi_["Ngay" + (k + 1)] = String.Format("{0:0.##}", dotTang.DsSLNgay_Tong[k]);
                            DsNgayCong[k] = dotTang.DsCong[k];
                        }

                        ravi_["Tong"] = dotTang.SlThuong;

                        if (dotTang.SlTang > 0)
                        {
                            _dataSL.Rows.InsertAt(ravi_, 0);

                            DataRow ravi_tang = _dataSL.NewRow();
                            SttSL++;
                            ravi_tang["STT"] = SttSL;
                            ravi_tang["ID_CongNhan"] = _ID_CongNhan;
                            ravi_tang["MaVT"] = dotTang.MaVT;
                            ravi_tang["TenVTHH"] = dotTang.TenVthhTang;

                            for (int k = 0; k < 31; k++)
                            {
                                ravi_tang["Ngay" + (k + 1)] = String.Format("{0:0.##}", dotTang.DsSLNgay_Tang[k]);
                            }

                            ravi_tang["Tong"] = String.Format("{0:0.##}", dotTang.SlTang);
                            _dataSL.Rows.InsertAt(ravi_tang, 1);
                        }
                        else
                        {
                            _dataSL.Rows.Add(ravi_);
                        }

                        //
                        //================================================================================
                        //Tạo bảng lương công nhân:
                        tinhTongCN t = tongTien(dotTang.DsIdVthh_DotTang[0], dt);

                        DataRow ravi_BL = _dataLuong.NewRow();
                        SttBL++;
                        ravi_BL["STT"] = SttBL;
                        ravi_BL["ID_CongNhan"] = _ID_CongNhan;
                        ravi_BL["MaVT"] = dotTang.MaVT;
                        ravi_BL["TenVTHH"] = dotTang.TenVthhThuong;

                        if (dotTang.SlThuong == 0) ravi_BL["SanLuong"] = "";
                        else ravi_BL["SanLuong"] = dotTang.SlThuong.ToString("N2");

                        if (dotTang.DonGiaThuong == 0) ravi_BL["DonGia"] = "";
                        else ravi_BL["DonGia"] = dotTang.DonGiaThuong.ToString("N2");

                        ravi_BL["DonGiaTang"] = "";

                        ravi_BL["ThanhTien"] = dotTang.ThanhTienThuong.ToString("N2");

                        if (_dataLuong.Rows.Count == 0)
                        {
                            if (dotTang.TruBaoHiem == 0) ravi_BL["BaoHiem"] = "";
                            else ravi_BL["BaoHiem"] = dotTang.TruBaoHiem.ToString("N2");
                        }

                        _SanLuong_Tong_BL = t.TongSL_All;
                        _BaoHiem_Tong_BL = dotTang.TruBaoHiem;
                        _ThanhTien_Tong_BL = t.TongTien;
                        _ThucNhan_Tong_BL = t.TongTien - dotTang.TruBaoHiem;

                        if (dotTang.SlTang > 0)
                        {
                            _dataLuong.Rows.InsertAt(ravi_BL, 0);

                            DataRow ravi_BL_tang = _dataLuong.NewRow();
                            SttBL++;
                            ravi_BL_tang["STT"] = SttBL;
                            ravi_BL_tang["ID_CongNhan"] = _ID_CongNhan;
                            ravi_BL_tang["MaVT"] = dotTang.MaVT;
                            ravi_BL_tang["TenVTHH"] = dotTang.TenVthhTang;

                            if (dotTang.SlTang == 0) ravi_BL_tang["SanLuong"] = "";
                            else ravi_BL_tang["SanLuong"] = dotTang.SlTang.ToString("N2");

                            ravi_BL_tang["DonGia"] = "";

                            if (dotTang.DonGiaTang == 0) ravi_BL_tang["DonGiaTang"] = "";
                            else ravi_BL_tang["DonGiaTang"] = dotTang.DonGiaTang.ToString("N2");

                            ravi_BL_tang["ThanhTien"] = dotTang.ThanhTienTang.ToString("N2");

                            _dataLuong.Rows.InsertAt(ravi_BL_tang, 1);
                        }
                        else
                        {
                            _dataLuong.Rows.Add(ravi_BL);
                        }
                    }


                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        int ID_VTHH = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Vao"].ToString());
                        int ID_congNhan = Convert.ToInt32(dt.Rows[i]["ID_CongNhan"].ToString());
                        string MaNV_ = dt.Rows[i]["MaNhanVien"].ToString();

                        ModelShowSanLuongToIn vt = getNV_SanLuong(ID_VTHH, dt);
                        tinhTongCN t = tongTien(ID_congNhan, dt);

                        SoNgayCong = vt.SoNgayCong;
                        //
                        if (ID_VTHH != ID_VTHHRoot && !DsID_Vthh_.Contains(ID_VTHH) && !dotTang.DsIdVthh_DotTang.Contains(ID_VTHH))
                        {
                            DsID_Vthh_.Add(ID_VTHH);

                            ID_VTHHRoot = ID_VTHH;
                            DataRow ravi_ = _dataSL.NewRow();
                            SttSL++;
                            ravi_["STT"] = SttSL;
                            ravi_["ID_CongNhan"] = _ID_CongNhan;
                            ravi_["MaVT"] = vt.MaVT;
                            ravi_["TenVTHH"] = vt.TenVthhThuong;

                            for (int k = 0; k < 31; k++)
                            {
                                ravi_["Ngay" + (k + 1)] = String.Format("{0:0.##}", vt.DsSLNgay_Tong[k]); 
                                DsNgayCong[k] = vt.DsCong[k];
                            }

                            ravi_["Tong"] = vt.SlThuong;

                            if (vt.SlTang > 0)
                            {
                                _dataSL.Rows.InsertAt(ravi_, 0);

                                DataRow ravi_tang = _dataSL.NewRow();
                                SttSL++;
                                ravi_tang["STT"] = SttSL;
                                ravi_tang["ID_CongNhan"] = _ID_CongNhan;
                                ravi_tang["MaVT"] = vt.MaVT;
                                ravi_tang["TenVTHH"] = vt.TenVthhTang;

                                for (int k = 0; k < 31; k++)
                                {
                                    ravi_tang["Ngay" + (k + 1)] = String.Format("{0:0.##}", vt.DsSLNgay_Tang[k]); 
                                }

                                ravi_tang["Tong"] = String.Format("{0:0.##}", vt.SlTang); 
                                _dataSL.Rows.InsertAt(ravi_tang, 1);
                            }
                            else
                            {
                                _dataSL.Rows.Add(ravi_);
                            }

                            //================================================================================
                            //Tạo bảng lương công nhân:
                            DataRow ravi_BL = _dataLuong.NewRow();
                            SttBL++;
                            ravi_BL["STT"] = SttBL;
                            ravi_BL["ID_CongNhan"] = ID_congNhan;
                            ravi_BL["MaVT"] = vt.MaVT;
                            ravi_BL["TenVTHH"] = vt.TenVthhThuong;

                            if (vt.SlThuong == 0) ravi_BL["SanLuong"] = "";
                            else ravi_BL["SanLuong"] = vt.SlThuong.ToString("N2");

                            if (vt.DonGiaThuong == 0) ravi_BL["DonGia"] = "";
                            else ravi_BL["DonGia"] = vt.DonGiaThuong.ToString("N2");

                            ravi_BL["DonGiaTang"] = "";

                            ravi_BL["ThanhTien"] = vt.ThanhTienThuong.ToString("N2");

                            if (_dataLuong.Rows.Count == 0)
                            {
                                if (vt.TruBaoHiem == 0) ravi_BL["BaoHiem"] = "";
                                else ravi_BL["BaoHiem"] = vt.TruBaoHiem.ToString("N2");
                            }

                            _SanLuong_Tong_BL = t.TongSL_All;
                            _BaoHiem_Tong_BL = vt.TruBaoHiem;
                            _ThanhTien_Tong_BL = t.TongTien;
                            _ThucNhan_Tong_BL = t.TongTien - vt.TruBaoHiem;

                            if (vt.SlTang > 0)
                            {
                                _dataLuong.Rows.InsertAt(ravi_BL, 0);

                                DataRow ravi_BL_tang = _dataLuong.NewRow();
                                SttBL++;
                                ravi_BL_tang["STT"] = SttBL;
                                ravi_BL_tang["ID_CongNhan"] = ID_congNhan;
                                ravi_BL_tang["MaVT"] = vt.MaVT;
                                ravi_BL_tang["TenVTHH"] = vt.TenVthhTang;

                                if (vt.SlTang == 0) ravi_BL_tang["SanLuong"] = "";
                                else ravi_BL_tang["SanLuong"] = vt.SlTang.ToString("N2");

                                ravi_BL_tang["DonGia"] = "";

                                if (vt.DonGiaTang == 0) ravi_BL_tang["DonGiaTang"] = "";
                                else ravi_BL_tang["DonGiaTang"] = vt.DonGiaTang.ToString("N2");

                                ravi_BL_tang["ThanhTien"] = vt.ThanhTienTang.ToString("N2");

                                _dataLuong.Rows.InsertAt(ravi_BL_tang, 1);
                            }
                            else
                            {
                                _dataLuong.Rows.Add(ravi_BL);
                            }
                            //================================end===========================
                        }
                    }


                    //Thêm Ngày công đi làm:
                    DataRow ravi_CongThg = _dataSL.NewRow();
                    SttBL++;
                    ravi_CongThg["STT"] = "";
                    ravi_CongThg["ID_CongNhan"] = 0;
                    ravi_CongThg["MaVT"] = "";
                    ravi_CongThg["TenVTHH"] = "Công";

                    for (int k = 0; k < 31; k++)
                    {
                        ravi_CongThg["Ngay" + (k + 1)] = String.Format("{0:0.##}", DsNgayCong[k]); 
                    }

                    ravi_CongThg["Tong"] = String.Format("{0:0.##}", SoNgayCong); 
                    _dataSL.Rows.Add(ravi_CongThg);

                    if (dtTang.Rows.Count > 0)
                    {
                        //Thêm Ngày tăng ca đi làm:
                        DataRow ravi_Tang = _dataSL.NewRow();
                        SttBL++;
                        ravi_Tang["STT"] = "";
                        ravi_Tang["ID_CongNhan"] = 0;
                        ravi_Tang["MaVT"] = "";
                        ravi_Tang["TenVTHH"] = "Tăng ca";

                        double tg = 0;
                        for (int k = 0; k < 31; k++)
                        {
                            double cog = CheckString.ConvertToDouble_My(dtTang.Rows[0]["Ngay" + (k + 1)].ToString());
                            ravi_Tang["Ngay" + (k + 1)] = String.Format("{0:0.##}", cog);
                            tg += cog;
                        }

                        ravi_Tang["Tong"] = String.Format("{0:0.##}", tg);
                        _dataSL.Rows.Add(ravi_Tang);
                    }

                    //==========Thêm row tổng lương:
                    DataRow ravi_BL_tong = _dataLuong.NewRow();
                    ravi_BL_tong["STT"] = "";
                    ravi_BL_tong["ID_CongNhan"] = 0;
                    ravi_BL_tong["MaVT"] = "";
                    ravi_BL_tong["TenVTHH"] = "Cộng";

                    if (_SanLuong_Tong_BL == 0) ravi_BL_tong["SanLuong"] = "";
                    else ravi_BL_tong["SanLuong"] = _SanLuong_Tong_BL.ToString("N2");

                    if (_ThanhTien_Tong_BL == 0) ravi_BL_tong["ThanhTien"] = "";
                    else ravi_BL_tong["ThanhTien"] = _ThanhTien_Tong_BL.ToString("N2");

                    if (_BaoHiem_Tong_BL == 0) ravi_BL_tong["BaoHiem"] = "";
                    else ravi_BL_tong["BaoHiem"] = _BaoHiem_Tong_BL.ToString("N2");

                    if (_ThucNhan_Tong_BL == 0) ravi_BL_tong["ThucNhan"] = "";
                    else ravi_BL_tong["ThucNhan"] = _ThucNhan_Tong_BL.ToString("N2");
                    _dataLuong.Rows.Add(ravi_BL_tong);
                }

                gridControl2.DataSource = _dataSL;
                gridControl1.DataSource = _dataLuong;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isload = false;
        }

        //Tính tổng sản lượng một công nhân:
        //List<int> _iDsVthh_DotTang = new List<int>();

        private ModelShowSanLuongToIn getNV_SanLuong(int idvthh, DataTable dt)
        {
            ModelShowSanLuongToIn nv = new ModelShowSanLuongToIn();
            string hoTen = "";
            string maVT = "";
            string tenVthhThuong = "";
            string tenVthhTang = "";
            double slTong = 0;
            double slThuong = 0;
            double slTang = 0;
            double donGiaThuong = 0;
            double donGiaTang = 0;
            double soNgayCong = 0;
            double phuCapBaoHiem = 0;
            double truBaoHiem = 0;
            string LoaiHangHoa = "";

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
                nv.DsSLNgay_Tang[i] = 0;
                nv.DsSLNgay_Tong[i] = 0;
                nv.DsCong[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH_Vao"].ToString()))
                {
                    double SL_Tog_ = 0;
                    double Cong_ = 0;

                    hoTen = item["TenNhanVien"].ToString();
                    tenVthhThuong = item["TenVTHH_Vao"].ToString();
                    maVT = item["MaVT_Vao"].ToString();
                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                    phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                    LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
                    soNgayCong = CheckString.ConvertToDouble_My(item["SoNgayCong"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;
                    
                    Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

                    //Máy cắt tính theo lết: 1 lết = 5 cuộn:
                    SL_Tog_ = CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString()) /5;
                    slTong += SL_Tog_;
                   
                    nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;

                    for (int i = 0; i < 31; i++)
                    {
                        nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i+1)].ToString());
                    }
                }
            }

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
                slThuong += nv.DsSLNgay[i];
            }


            nv.HoTen = hoTen;
            nv.MaVT = maVT;
            nv.TenVthhThuong = tenVthhThuong;
            nv.TenVthhTang = tenVthhTang;
            nv.SlTong = slTong;
            nv.SlThuong = slThuong;
            nv.SlTang = slTang;
            nv.DonGiaThuong = donGiaThuong;
            nv.DonGiaTang = donGiaTang;
            nv.SoNgayCong = soNgayCong;
            nv.ThanhTienThuong = slThuong * donGiaThuong;
            nv.ThanhTienTang = slTang * donGiaTang;
            nv.TienTong = slThuong * donGiaThuong + slTang * donGiaTang;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
        }

        private ModelShowSanLuongToIn getNV_SanLuong_DotTang(DataTable dt)
        {
            ModelShowSanLuongToIn nv = new ModelShowSanLuongToIn();
            string hoTen = "";
            string maVT = "";
            string tenVthhThuong = "";
            string tenVthhTang = "";
            double slTong = 0;
            double slThuong = 0;
            double slTang = 0;
            double donGiaThuong = 0;
            double donGiaTang = 0;
            double soNgayCong = 0;
            double phuCapBaoHiem = 0;
            double truBaoHiem = 0;
            string LoaiHangHoa = "";

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
                nv.DsSLNgay_Tang[i] = 0;
                nv.DsSLNgay_Tong[i] = 0;
                nv.DsCong[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                int idvthh = Convert.ToInt32(item["ID_VTHH_Vao"].ToString()); //cũ:ID_VTHH_Ra
                LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();

                if (LoaiHangHoa.Contains("cắt đột tăng"))
                {
                    nv.DsIdVthh_DotTang.Add(idvthh);
                    double SL_Tog_ = 0;
                    double Cong_ = 0;

                    hoTen = item["TenNhanVien"].ToString();
                    tenVthhThuong = item["TenVTHH_Vao"].ToString();
                    maVT = item["MaVT_Vao"].ToString();
                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                    phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                    soNgayCong = CheckString.ConvertToDouble_My(item["SoNgayCong"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                    Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

                    //Máy cắt tính theo lết: 1 lết = 5 cuộn:
                    SL_Tog_ = CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString()) /5; //cũ:SanLuong_Tong_Value
                    slTong += SL_Tog_;
                    if (Cong_ > 0)
                    {
                        tenVthhThuong = "Đột";
                        tenVthhTang = "Đột tăng ";
                    }

                    nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;

                    for (int i = 0; i < 31; i++)
                    {
                        nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i + 1)].ToString());
                    }
                }
            }


            for (int i = 0; i < 31; i++)
            {
                if (nv.DsCong[i] > 0 && nv.DsSLNgay_Tong[i] > 10)
                {
                    nv.DsSLNgay_Tang[i] = nv.DsSLNgay_Tong[i] - 10;
                    slTang += nv.DsSLNgay_Tong[i] - 10;
                    nv.DsSLNgay[i] = 10;
                }
                else
                {
                    nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
                }
            }

            slThuong = slTong - slTang;

            nv.HoTen = hoTen;
            nv.MaVT = maVT;
            nv.TenVthhThuong = tenVthhThuong;
            nv.TenVthhTang = tenVthhTang;
            nv.SlTong = slTong;
            nv.SlThuong = slThuong;
            nv.SlTang = slTang;
            nv.DonGiaThuong = donGiaThuong;
            nv.DonGiaTang = donGiaTang;
            nv.SoNgayCong = soNgayCong;
            nv.ThanhTienThuong = slThuong * donGiaThuong;
            nv.ThanhTienTang = slTang * donGiaTang;
            nv.TienTong = slThuong * donGiaThuong + slTang * donGiaTang;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
        }

        private tinhTongCN tongTien(int idcn, DataTable dt)
        {
            tinhTongCN t = new tinhTongCN();
            double result = 0;
            double PhuCapBH = 0;
            double TongSL_All_ = 0;
            int ID_VthhRoot = -1;

            ModelShowSanLuongToIn dotTang = getNV_SanLuong_DotTang(dt);
            if(dotTang.DsIdVthh_DotTang.Count > 0)
            {
                result += (dotTang.ThanhTienThuong + dotTang.ThanhTienTang);
                TongSL_All_ += dotTang.SlTong;
                PhuCapBH = dotTang.PhuCapBaoHiem;
            }

            foreach (DataRow item in dt.Rows)
            {
                int ID_congNhan_ = Convert.ToInt32(item["ID_CongNhan"].ToString());
                int ID_Vthh_ = Convert.ToInt32(item["ID_VTHH_Vao"].ToString());

                //
                if (ID_VthhRoot != ID_Vthh_ && !dotTang.DsIdVthh_DotTang.Contains(ID_Vthh_))
                {
                    ID_VthhRoot = ID_Vthh_;
                    ModelShowSanLuongToIn nvSL = getNV_SanLuong(ID_Vthh_, dt);
                    result += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
                    TongSL_All_ += nvSL.SlTong;
                    PhuCapBH = nvSL.PhuCapBaoHiem;
                }
            }

            t.TongTien = result;
            t.PhuCapBaoHiem = PhuCapBH;
            t.TongSL_All = TongSL_All_;

            return t;
        }


        public void HienThiGridcontrol2(int iiID_CongNhan)
        {
            try
            {
                gridControl1.DataSource = null;

                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();

                DataTable dtxxxx = new DataTable();
                dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan_HUU(iiID_CongNhan, ngaydauthang, ngaycuoithang);

                DataTable dt2xx = new DataTable();

                dt2xx.Columns.Add("MaVT", typeof(string));
                dt2xx.Columns.Add("TenVTHH", typeof(string));
                dt2xx.Columns.Add("DonViTinh", typeof(string));
                dt2xx.Columns.Add("SanLuong_Thuong", typeof(string));
                dt2xx.Columns.Add("SanLuong_TangCa", typeof(string));
                dt2xx.Columns.Add("DinhMuc_KhongTang", typeof(double));
                dt2xx.Columns.Add("DinhMuc_Tang", typeof(double));
                dt2xx.Columns.Add("ThanhTien", typeof(double));

                DataRow _ravi_1 = dt2xx.NewRow();

                int id_vthh_cu_ = 0;

                for (int k = 0; k < dtxxxx.Rows.Count; k++)
                {
                    int xxID_VTHH = Convert.ToInt32(dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString());
                    //double snluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                    //double snluong_tangca = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());
                    double xxsanluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_Thuong)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                    double xxsanluong_tang = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_TangCa)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                    double xxthanhtien = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(ThanhTien)", "ID_VTHH_Ra=" + xxID_VTHH + ""));
                    int id_vthh_ = 0;
                    if (k < dtxxxx.Rows.Count - 1)
                    {
                        id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString());
                        if (dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                        {
                            _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                            _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                            _ravi_1["DonViTinh"] = dtxxxx.Rows[k]["DonViTinh"].ToString();
                            _ravi_1["SanLuong_Thuong"] = xxsanluong_thuong;
                            _ravi_1["SanLuong_TangCa"] = xxsanluong_tang;
                            _ravi_1["DinhMuc_KhongTang"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                            _ravi_1["DinhMuc_Tang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                            _ravi_1["ThanhTien"] = xxthanhtien;
                            dt2xx.Rows.Add(_ravi_1);
                            _ravi_1 = dt2xx.NewRow();
                            id_vthh_cu_ = id_vthh_;
                        }
                        else
                        { }
                    }
                    else
                    {
                        _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["DonViTinh"] = dtxxxx.Rows[k]["DonViTinh"].ToString();
                        _ravi_1["SanLuong_Thuong"] = xxsanluong_thuong;
                        _ravi_1["SanLuong_TangCa"] = xxsanluong_tang;
                        _ravi_1["DinhMuc_KhongTang"] = dtxxxx.Rows[k]["DinhMuc_KhongTang"].ToString();
                        _ravi_1["DinhMuc_Tang"] = dtxxxx.Rows[k]["DinhMuc_Tang"].ToString();
                        _ravi_1["ThanhTien"] = xxthanhtien;


                        dt2xx.Rows.Add(_ravi_1);



                        _ravi_1 = dt2xx.NewRow();

                    }

                }

                gridControl1.DataSource = dt2xx;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;

        public Tr_frmChiTiet_LuongSanLuongCN_TMC(int thang, int nam, int idbophan, int idcn, string tenNV)
        {
            _tenNV = tenNV;
            _thang = thang;
            _nam = nam;
            _ID_CongNhan = idcn;
            _id_bophan = idbophan;

            InitializeComponent();

            txtNam.Text = nam.ToString();
            txtThang.Text = thang.ToString();

            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);

            _dataSL = new DataTable();
            _dataSL.Columns.Add("STT", typeof(string));
            _dataSL.Columns.Add("ID_CongNhan", typeof(string));
            _dataSL.Columns.Add("MaVT", typeof(string));
            _dataSL.Columns.Add("TenVTHH", typeof(string));
            _dataSL.Columns.Add("Ngay1", typeof(string));
            _dataSL.Columns.Add("Ngay2", typeof(string));
            _dataSL.Columns.Add("Ngay3", typeof(string));
            _dataSL.Columns.Add("Ngay4", typeof(string));
            _dataSL.Columns.Add("Ngay5", typeof(string));
            _dataSL.Columns.Add("Ngay6", typeof(string));
            _dataSL.Columns.Add("Ngay7", typeof(string));
            _dataSL.Columns.Add("Ngay8", typeof(string));
            _dataSL.Columns.Add("Ngay9", typeof(string));
            _dataSL.Columns.Add("Ngay10", typeof(string));
            _dataSL.Columns.Add("Ngay11", typeof(string));
            _dataSL.Columns.Add("Ngay12", typeof(string));
            _dataSL.Columns.Add("Ngay13", typeof(string));
            _dataSL.Columns.Add("Ngay14", typeof(string));
            _dataSL.Columns.Add("Ngay15", typeof(string));
            _dataSL.Columns.Add("Ngay16", typeof(string));
            _dataSL.Columns.Add("Ngay17", typeof(string));
            _dataSL.Columns.Add("Ngay18", typeof(string));
            _dataSL.Columns.Add("Ngay19", typeof(string));
            _dataSL.Columns.Add("Ngay20", typeof(string));
            _dataSL.Columns.Add("Ngay21", typeof(string));
            _dataSL.Columns.Add("Ngay22", typeof(string));
            _dataSL.Columns.Add("Ngay23", typeof(string));
            _dataSL.Columns.Add("Ngay24", typeof(string));
            _dataSL.Columns.Add("Ngay25", typeof(string));
            _dataSL.Columns.Add("Ngay26", typeof(string));
            _dataSL.Columns.Add("Ngay27", typeof(string));
            _dataSL.Columns.Add("Ngay28", typeof(string));
            _dataSL.Columns.Add("Ngay29", typeof(string));
            _dataSL.Columns.Add("Ngay30", typeof(string));
            _dataSL.Columns.Add("Ngay31", typeof(string));
            _dataSL.Columns.Add("Tong", typeof(string));

            _dataLuong = new DataTable();
            _dataLuong.Columns.Add("STT", typeof(string));
            _dataLuong.Columns.Add("Thang", typeof(int));
            _dataLuong.Columns.Add("Nam", typeof(int));
            _dataLuong.Columns.Add("ID_CongNhan", typeof(int));
            _dataLuong.Columns.Add("MaVT", typeof(string));
            _dataLuong.Columns.Add("TenVTHH", typeof(string));
            _dataLuong.Columns.Add("SanLuong", typeof(string));
            _dataLuong.Columns.Add("DonGia", typeof(string));
            _dataLuong.Columns.Add("DonGiaTang", typeof(string));
            _dataLuong.Columns.Add("ThanhTien", typeof(string));
            _dataLuong.Columns.Add("XangXe", typeof(string));
            _dataLuong.Columns.Add("Tong", typeof(string));
            _dataLuong.Columns.Add("BaoHiem", typeof(string));
            _dataLuong.Columns.Add("TamUng", typeof(string));
            _dataLuong.Columns.Add("AnCa", typeof(string));
            _dataLuong.Columns.Add("ThucNhan", typeof(string));
            _dataLuong.Columns.Add("NgayCong", typeof(string));
            _dataLuong.Columns.Add("PhuCapBaoHiem", typeof(string));

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl2.RepositoryItems.Add(emptyEditor);
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private int xxID;
        private void gridCongNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                //clsncc.iID_NhanSu = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                //DataTable dt = clsncc.SelectOne();

                //txtHoTen.Text = clsncc.sTenNhanVien.Value;
                //xxID = Convert.ToInt32(gridCongNhan.EditValue.ToString());
                //LoadData(xxID);
                //HienThiGridcontrol2(xxID);

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tr_frmChiTiet_LuongSanLuongCN_TMC_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadData(false);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btRefesh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmChiTiet_LuongSanLuongCN_TMC_Load( sender,  e);
            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT1)
                if(e.RowHandle%2==0)
                e.DisplayText = (e.RowHandle/2 + 1).ToString();
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            try
            {
                if (isload)
                    return;
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            try
            {
                if (isload)
                    return;
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
        }

        private void gridCongNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridCongNhan_QueryPopUp(object sender, CancelEventArgs e)
        {
        }

        private void gridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ten = View.GetRowCellValue(e.RowHandle, View.Columns["TenVTHH"]).ToString();
                if (ten == "Cộng")
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            _nam = Convert.ToInt32(txtNam.Text.ToString());
            _thang = Convert.ToInt32(txtThang.Text.ToString());
            Tr_frmPrintSanLuong_CT_Luong_TMC ff = new Tr_frmPrintSanLuong_CT_Luong_TMC(_thang, _nam, _ID_CongNhan, _tenNV, _dataSL, _dataLuong);
            ff.Show();
        }

        private void ChangeColTitle(int thang, int nam)
        {
            if (thang <= 0 || thang > 12 || nam <= 1900)
            {
                DateTime dtnow = DateTime.Now;
                nam = DateTime.Now.Year;
                thang = DateTime.Now.Month;
            }
            DateTime date_ = new DateTime(nam, thang, 1);
            int ngaycuathang_ = (((new DateTime(nam, thang, 1)).AddMonths(1)).AddDays(-1)).Day;
            if (ngaycuathang_ == 28)
            {
                Ngay31.Visible = false;
                Ngay30.Visible = false;
                Ngay29.Visible = false;

                _deleted_29 = true;
                _deleted_30 = true;
                _deleted_31 = true;
            }
            else if (ngaycuathang_ == 29)
            {
                Ngay31.Visible = false;
                Ngay30.Visible = false;
                Ngay29.Visible = true;
                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = true;
                _deleted_31 = true;
            }
            else if (ngaycuathang_ == 30)
            {
                Ngay31.Visible = false;
                Ngay29.Visible = true;
                Ngay30.Visible = true;
                _deleted_31 = true;

                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;
                if (_deleted_30) Ngay30.VisibleIndex = Ngay29.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = false;
            }
            else if (ngaycuathang_ == 31)
            {
                Ngay29.Visible = true;
                Ngay30.Visible = true;
                Ngay31.Visible = true;
                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;
                if (_deleted_30) Ngay30.VisibleIndex = Ngay29.VisibleIndex + 1;
                if (_deleted_31) Ngay31.VisibleIndex = Ngay30.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = false;
                _deleted_31 = false;
            }
            string thu_ = LayThu(date_);
            for (int i = 0; i < ngaycuathang_; ++i)
            {
                ds_grid[i].Caption = (i + 1) + "\n" + LayThu(new DateTime(nam, thang, (i + 1)));
                if (ds_grid[i].Caption.Contains("CN"))
                {
                    ds_grid[i].AppearanceCell.BackColor = Color.LightGray;
                    ds_grid[i].AppearanceHeader.BackColor = Color.LightGray;
                    ds_grid[i].AppearanceHeader.ForeColor = Color.Red;
                    ds_grid[i].AppearanceCell.ForeColor = Color.Red;
                }
                else
                {
                    ds_grid[i].AppearanceCell.BackColor = Color.White;
                    ds_grid[i].AppearanceHeader.BackColor = Color.White;
                    ds_grid[i].AppearanceHeader.ForeColor = Color.Black;
                    ds_grid[i].AppearanceCell.ForeColor = Color.Black;
                }
            }
        }

        private string LayThu(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                case DayOfWeek.Sunday:
                    return "CN";
            }
            return "";
        }

        private string thutrongtuanxyz(int ewwd)
        {

            string xxx = "";
            if (ewwd == 0)
                xxx = "Thứ 7";
            else if (ewwd.ToString() == "1")
                xxx = "Chủ nhật ";
            else xxx = "Thứ " + ewwd.ToString() + "";
            return xxx;
        }

        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                }
            }
            return _id_bophan;
        }

    }
}
