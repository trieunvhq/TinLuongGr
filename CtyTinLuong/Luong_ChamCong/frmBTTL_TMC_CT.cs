
using CtyTinLuong.Model;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmBTTL_TMC_CT : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan, _indexTongCa1 = 0;
        public string _ten_vthh;
        private DataTable _data, _dtCong_Ca1, _dtCong_Ca2, _dtSL_Ca1, _dtSL_Ca2;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_TMC_CT(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _data = new DataTable();
            _data.Columns.Add("Thang", typeof(int));
            _data.Columns.Add("Nam", typeof(int));
            _data.Columns.Add("ID_CongNhan", typeof(int));
            _data.Columns.Add("MaNhanVien", typeof(string));
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("TenNhanVien", typeof(string));
            _data.Columns.Add("HinhThuc", typeof(string));
            _data.Columns.Add("SanLuong", typeof(string));
            _data.Columns.Add("DonGia", typeof(string));
            _data.Columns.Add("ThanhTien", typeof(string));
            _data.Columns.Add("XangXe", typeof(string));
            _data.Columns.Add("Tong", typeof(string));
            _data.Columns.Add("BaoHiem", typeof(string));
            _data.Columns.Add("ThucNhan", typeof(string));
            _data.Columns.Add("NgayCong", typeof(string));
            _data.Columns.Add("PhuCapBaoHiem", typeof(string));

            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();
        }

        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
                DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
                int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;

                _nam = DateTime.Now.Year;
                _thang = DateTime.Now.Month;
            }
            else
            {
            }
            double _ThanhTien_Tong_Ca1 = 0;  //Thành tiền
            double _ThucNhan_Tong_Ca1 = 0;
            double _NgayCong_Tong_Ca1 = 0;
            double _SanLuong_Tong_Ca1 = 0;
            double _XangXe_Tong_Ca1 = 0;
            double _BaoHiem_Tong_Ca1 = 0;
            double _PCBaoHiem_Tong_Ca1 = 0;
            double _Tong_Ca1 = 0;



            //
            double _ThanhTien_Tong_Ca2 = 0;
            double _ThucNhan_Tong_Ca2 = 0;
            double _NgayCong_Tong_Ca2 = 0;
            double _SanLuong_Tong_Ca2 = 0;
            double _XangXe_Tong_Ca2 = 0;
            double _BaoHiem_Tong_Ca2 = 0;
            double _PCBaoHiem_Tong_Ca2 = 0;
            double _Tong_Ca2 = 0;



            using (clsThin clsThin_ = new clsThin())
            {
                //Lấy dữ liệu ca1
                //_dtCong_Ca1 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, true);
                _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 1, 0, "Ca 1", _id_bophan);

                //Lấy dữ liệu ca2
                //_dtCong_Ca2 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, false);
                _dtSL_Ca2 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 1, 0, "Ca 2", _id_bophan);

                int SttCa1 = 0;
                int ID_congNhanRoot = -1;
                int ID_VthhRoot = -1;
                List<int> DsID_Vthh_Ca1 = new List<int>();
                List<int> DsID_Vthh_Ca2 = new List<int>();
                List<int> DsID_CN_Ca1_ = new List<int>();
                List<int> DsID_CN_Ca2_ = new List<int>();

                for (int i = 0; i < _dtSL_Ca1.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_dtSL_Ca1.Rows[i]["ID_CongNhan"].ToString());
                    int ID_Vthh = Convert.ToInt32(_dtSL_Ca1.Rows[i]["ID_VTHH_Vao"].ToString());
                    string MaNV_ = _dtSL_Ca1.Rows[i]["MaNhanVien"].ToString();

                    ModelShowSanLuongToIn nvSL = getNV_SanLuong(ID_congNhan, ID_Vthh, _dtSL_Ca1);
                    tinhTongCN t = tongTien(ID_congNhan, _dtSL_Ca1);

                    //
                    if (!DsID_CN_Ca1_.Contains(ID_congNhan))
                    {
                        DsID_CN_Ca1_.Add(ID_congNhan);
                        if (!DsID_Vthh_Ca1.Contains(ID_Vthh))
                        {
                            DataRow ravi_ = _data.NewRow();
                            DsID_Vthh_Ca1.Add(ID_Vthh);

                            //STT
                            SttCa1++;
                            ravi_["STT"] = SttCa1;
                            ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());
                            ravi_["ID_CongNhan"] = ID_congNhan;
                            ravi_["MaNhanVien"] = MaNV_;
                            ravi_["HinhThuc"] = nvSL.TenVthhThuong;

                            if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
                            else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N2");

                            if (t.TongSL_All == 0) ravi_["SanLuong"] = "";
                            else ravi_["SanLuong"] = t.TongSL_All.ToString("N2");

                            if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
                            else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

                            ravi_["ThanhTien"] = t.TongTien.ToString("N2");


                            double tongtien = t.TongTien;
                            ravi_["Tong"] = tongtien.ToString("N2");

                            ravi_["ThucNhan"] = (tongtien - nvSL.TruBaoHiem).ToString("N2");

                            _SanLuong_Tong_Ca1 += t.TongSL_All;
                            //_ThanhTien_Tong_Ca1 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
                            _Tong_Ca1 += tongtien;
                            _ThucNhan_Tong_Ca1 += (tongtien - nvSL.TruBaoHiem);


                            if (nvSL.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                            else ravi_["BaoHiem"] = nvSL.TruBaoHiem.ToString("N2");

                            if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                            else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N2");

                            _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                            _BaoHiem_Tong_Ca1 += nvSL.TruBaoHiem;

                            _data.Rows.Add(ravi_);
                        }
                        else
                        {

                        }
                    }
                }

                //Add thêm row tổng ca 1:
                DataRow _ravi = _data.NewRow();
                _ravi["ID_CongNhan"] = 0;
                _ravi["Thang"] = _thang;
                _ravi["Nam"] = _nam;
                _ravi["TenNhanVien"] = "CA 1:";

                //
                if (_NgayCong_Tong_Ca1 == 0)
                {
                    _ravi["HinhThuc"] = "";
                }
                else
                {
                    _ravi["HinhThuc"] = _NgayCong_Tong_Ca1.ToString("N2");
                }

                //
                if (_SanLuong_Tong_Ca1 == 0)
                {
                    _ravi["SanLuong"] = "";
                }
                else
                {
                    _ravi["SanLuong"] = _SanLuong_Tong_Ca1.ToString("N2");
                }

                //
                if (_ThanhTien_Tong_Ca1 == 0)
                {
                    _ravi["ThanhTien"] = "";
                }
                else
                {
                    _ravi["ThanhTien"] = _ThanhTien_Tong_Ca1.ToString("N2");
                }

                //
                if (_XangXe_Tong_Ca1 == 0)
                {
                    _ravi["XangXe"] = "";
                }
                else
                {
                    _ravi["XangXe"] = _XangXe_Tong_Ca1.ToString("N2");
                }

                //
                if (_Tong_Ca1 == 0)
                {
                    _ravi["Tong"] = "";
                }
                else
                {
                    _ravi["Tong"] = _Tong_Ca1.ToString("N2");
                }

                //
                if (_BaoHiem_Tong_Ca1 == 0)
                {
                    _ravi["BaoHiem"] = "";
                }
                else
                {
                    _ravi["BaoHiem"] = _BaoHiem_Tong_Ca1.ToString("N2");
                }

                // 
                if (_ThucNhan_Tong_Ca1 == 0)
                {
                    _ravi["ThucNhan"] = "";
                }
                else
                {
                    _ravi["ThucNhan"] = _ThucNhan_Tong_Ca1.ToString("N2");
                }

                //_data.Rows.Add(_ravi);
                _data.Rows.InsertAt(_ravi, 0);
                _indexTongCa1 = _data.Rows.Count;


                //Ca 2:
                int SttCa2 = 0;
                ID_congNhanRoot = -1;
                ID_VthhRoot = -1;

                for (int i = 0; i < _dtSL_Ca2.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_dtSL_Ca2.Rows[i]["ID_CongNhan"].ToString());
                    int ID_Vthh = Convert.ToInt32(_dtSL_Ca2.Rows[i]["ID_VTHH_Vao"].ToString());
                    string MaNV_ = _dtSL_Ca2.Rows[i]["MaNhanVien"].ToString();

                    ModelShowSanLuongToIn nvSL = getNV_SanLuong(ID_congNhan, ID_Vthh, _dtSL_Ca2);
                    tinhTongCN t = tongTien(ID_congNhan, _dtSL_Ca2);

                    //
                    if (!DsID_CN_Ca2_.Contains(ID_congNhan))
                    {
                        DsID_CN_Ca2_.Add(ID_congNhan);
                        if (!DsID_Vthh_Ca2.Contains(ID_Vthh))
                        {
                            DataRow ravi_ = _data.NewRow();
                            DsID_Vthh_Ca2.Add(ID_Vthh);

                            //STT
                            SttCa2++;
                            ravi_["STT"] = SttCa2;
                            ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());
                            ravi_["ID_CongNhan"] = ID_congNhan;
                            ravi_["MaNhanVien"] = MaNV_;
                            ravi_["HinhThuc"] = nvSL.TenVthhThuong;

                            if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
                            else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N2");

                            if (t.TongSL_All == 0) ravi_["SanLuong"] = "";
                            else ravi_["SanLuong"] = t.TongSL_All.ToString("N2");

                            if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
                            else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

                            ravi_["ThanhTien"] = t.TongTien.ToString("N2");


                            double tongtien = t.TongTien;
                            ravi_["Tong"] = tongtien.ToString("N2");

                            ravi_["ThucNhan"] = (tongtien - nvSL.TruBaoHiem).ToString("N2");

                            _SanLuong_Tong_Ca2 += t.TongSL_All;
                            //_ThanhTien_Tong_Ca2 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
                            _Tong_Ca2 += tongtien;
                            _ThucNhan_Tong_Ca2 += (tongtien - nvSL.TruBaoHiem);


                            if (nvSL.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                            else ravi_["BaoHiem"] = nvSL.TruBaoHiem.ToString("N2");

                            if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                            else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N2");

                            _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                            _BaoHiem_Tong_Ca2 += nvSL.TruBaoHiem;

                            _data.Rows.Add(ravi_);
                        }
                        else
                        {

                        }
                    }
                }

                //Add thêm row tổng ca 2:
                DataRow _ravi_ca2 = _data.NewRow();
                _ravi_ca2["ID_CongNhan"] = 0;
                _ravi_ca2["MaNhanVien"] = "";
                _ravi_ca2["Thang"] = _thang;
                _ravi_ca2["Nam"] = _nam;
                _ravi_ca2["TenNhanVien"] = "CA 2:";

                //
                if (_NgayCong_Tong_Ca2 == 0)
                {
                    _ravi_ca2["HinhThuc"] = "";
                }
                else
                {
                    _ravi_ca2["HinhThuc"] = _NgayCong_Tong_Ca2.ToString("N2");
                }

                //
                if (_SanLuong_Tong_Ca2 == 0)
                {
                    _ravi_ca2["SanLuong"] = "";
                }
                else
                {
                    _ravi_ca2["SanLuong"] = _SanLuong_Tong_Ca2.ToString("N2");
                }

                //
                if (_ThanhTien_Tong_Ca2 == 0)
                {
                    _ravi_ca2["ThanhTien"] = "";
                }
                else
                {
                    _ravi_ca2["ThanhTien"] = _ThanhTien_Tong_Ca2.ToString("N2");
                }

                //
                if (_XangXe_Tong_Ca2 == 0)
                {
                    _ravi_ca2["XangXe"] = "";
                }
                else
                {
                    _ravi_ca2["XangXe"] = _XangXe_Tong_Ca2.ToString("N2");
                }

                //
                if (_Tong_Ca2 == 0)
                {
                    _ravi_ca2["Tong"] = "";
                }
                else
                {
                    _ravi_ca2["Tong"] = _Tong_Ca2.ToString("N2");
                }

                //
                if (_BaoHiem_Tong_Ca2 == 0)
                {
                    _ravi_ca2["BaoHiem"] = "";
                }
                else
                {
                    _ravi_ca2["BaoHiem"] = _BaoHiem_Tong_Ca2.ToString("N2");
                }

                // 
                if (_ThucNhan_Tong_Ca2 == 0)
                {
                    _ravi_ca2["ThucNhan"] = "";
                }
                else
                {
                    _ravi_ca2["ThucNhan"] = _ThucNhan_Tong_Ca2.ToString("N2");
                }

                //_data.Rows.Add(_ravi_ca2);
                _data.Rows.InsertAt(_ravi_ca2, _indexTongCa1);

                //Add Tổng 2 ca:
                //Add thêm row tổng ca 2:
                DataRow _ravi_2ca = _data.NewRow();
                _ravi_2ca["ID_CongNhan"] = 0;
                _ravi_2ca["MaNhanVien"] = "";
                _ravi_2ca["Thang"] = _thang;
                _ravi_2ca["Nam"] = _nam;
                _ravi_2ca["TenNhanVien"] = "Tổng";

                //
                if (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1 == 0)
                {
                    _ravi_2ca["HinhThuc"] = "";
                }
                else
                {
                    _ravi_2ca["HinhThuc"] = (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1).ToString("N2");
                }

                //
                if (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1 == 0)
                {
                    _ravi_2ca["SanLuong"] = "";
                }
                else
                {
                    _ravi_2ca["SanLuong"] = (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1).ToString("N2");
                }

                //
                if (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1 == 0)
                {
                    _ravi_2ca["ThanhTien"] = "";
                }
                else
                {
                    _ravi_2ca["ThanhTien"] = (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1).ToString("N2");
                }

                //
                if (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1 == 0)
                {
                    _ravi_2ca["XangXe"] = "";
                }
                else
                {
                    _ravi_2ca["XangXe"] = (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1).ToString("N2");
                }

                //
                if (_Tong_Ca2 + _Tong_Ca1 == 0)
                {
                    _ravi_2ca["Tong"] = "";
                }
                else
                {
                    _ravi_2ca["Tong"] = (_Tong_Ca2 + _Tong_Ca1).ToString("N2");
                }

                //
                if (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1 == 0)
                {
                    _ravi_2ca["BaoHiem"] = "";
                }
                else
                {
                    _ravi_2ca["BaoHiem"] = (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1).ToString("N2");
                }

                // 
                if (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1 == 0)
                {
                    _ravi_2ca["ThucNhan"] = "";
                }
                else
                {
                    _ravi_2ca["ThucNhan"] = (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1).ToString("N2");
                }

                _data.Rows.Add(_ravi_2ca);

                gridControl1.DataSource = _data;
                //  
                isload = false;
            }
        }


        //Tính tổng sản lượng một công nhân:
        private ModelShowSanLuongToIn getNV_SanLuong(int idcn, int idvthh, DataTable dt)
        {
            ModelShowSanLuongToIn nv = new ModelShowSanLuongToIn();
            string hoTen = "";
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
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
                nv.DsSLNgay_Tang[i] = 0;
                nv.DsCong[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString())
                    && idvthh == Convert.ToInt32(item["ID_VTHH_Vao"].ToString()))
                {
                    double SL_Tog_ = 0;
                    //double SL_Thg_ = 0;
                    //double SL_Tang_ = 0;
                    double Cong_ = 0;
                    string HocViec = (CheckString.ChuanHoaHoTen(item["HV_DienGiai"].ToString())).ToLower();

                    hoTen = item["TenNhanVien"].ToString();
                    tenVthhThuong = item["TenVTHH_Vao"].ToString();
                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                    phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                    LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();

                    soNgayCong = CheckString.ConvertToDouble_My(item["SoNgayCong"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;
                    Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

                    //Máy cắt tính theo lết: 1 lết = 5 cuộn:
                    if (!HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                    {
                        SL_Tog_ = CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString()) / 5;
                        slTong += SL_Tog_;
                        //SL_Thg_ = SL_Tog_;
                        nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;
                    }
                    else
                    {
                        donGiaThuong = CheckString.ConvertToDouble_My(item["HV_DonGiaCongNhat_Thuong"].ToString());
                    }

                    for (int i = 0; i < 31; i++)
                    {
                        nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i + 1)].ToString());
                    }

                    //if (Cong_ > 0)
                    //{
                    //    if (LoaiHangHoa.Contains("cắt đột tăng"))
                    //    {
                    //        if (SL_Tog_ > 10)
                    //        {
                    //            SL_Thg_ = 10;
                    //            SL_Tang_ = SL_Tog_ - 10;
                    //        }
                    //        tenVthhThuong = "Đột";
                    //        tenVthhTang = "SL tăng";
                    //    }
                    //}

                    //slThuong += SL_Thg_;
                    //slTang += SL_Tang_;
                    //nv.DsSLNgay[NgaySX - 1] += SL_Thg_;
                    //nv.DsSLNgay_Tang[NgaySX - 1] += SL_Tang_;
                    //nv.DsCong[NgaySX - 1] += Cong_;
                }
            }

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
                slThuong += nv.DsSLNgay[i];
            }

            nv.HoTen = hoTen;
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

        private ModelShowSanLuongToIn getNV_SanLuong_DotTang(int idcn, DataTable dt)
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
                int idvthh = Convert.ToInt32(item["ID_VTHH_Vao"].ToString());
                LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();

                if (LoaiHangHoa.Contains("cắt đột tăng") && idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                {
                    nv.DsIdVthh_DotTang.Add(idvthh);
                    double SL_Tog_ = 0;
                    double Cong_ = 0;
                    string HocViec = (CheckString.ChuanHoaHoTen(item["HV_DienGiai"].ToString())).ToLower();

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
                    if (!HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                    {
                        SL_Tog_ = CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString()) / 5;
                        slTong += SL_Tog_;
                        nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;
                    }
                    
                    if (Cong_ > 0)
                    {
                        tenVthhThuong = "Đột";
                        tenVthhTang = "Đột tăng ";
                    }

                    for (int i = 0; i < 31; i++)
                    {
                        nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i + 1)].ToString());
                    }
                }
            }


            //Điều kiện tính sản lượng đột tăng:
            //Trong ngày có phát sinh công => Chấm công trong bảng chấm công tổ máy cắt
            // Sản lượng phải > 10; vượt 10 sẽ được ăn theo đơn giá cắt đột tăng
            // Định mức phần diễn giải ghi rõ "cắt đột tăng", nếu không sẽ tính theo sản lượng và đơn giá thường


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

        private ModelShowSanLuongToIn getNV_HocViec(int idcn, DataTable dt)
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
            int ID_VthhRoot = -1;
            List<int> DsID_Vthh_ = new List<int>();
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
                nv.DsSLNgay_Tang[i] = 0;
                nv.DsSLNgay_Tong[i] = 0;
                nv.DsCong[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                int ID_Vthh_ = Convert.ToInt32(item["ID_VTHH_Vao"].ToString());

                //
                if (ID_VthhRoot != ID_Vthh_ && !DsID_Vthh_.Contains(ID_Vthh_) && idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                {
                    string HocViec = (CheckString.ChuanHoaHoTen(item["HV_DienGiai"].ToString())).ToLower();

                    if (HocViec.Contains("học việc") || HocViec.Contains("thử việc"))
                    {
                        double Cong_ = 0;

                        hoTen = item["TenNhanVien"].ToString();
                        donGiaThuong = CheckString.ConvertToDouble_My(item["HV_DonGiaCongNhat_Thuong"].ToString());
                        donGiaTang = CheckString.ConvertToDouble_My(item["HV_DonGiaCongNhat_Tang"].ToString());
                        phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                        truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());

                        int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                        Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

                        if (Cong_ > 0)
                        {
                            if (!dsNgayCong.Contains(NgaySX))
                            {
                                dsNgayCong.Add(NgaySX);
                            }
                        }

                        if (HocViec.Contains("học việc"))
                            tenVthhThuong = "Học việc";
                        else
                            tenVthhThuong = "Thử việc";
                    }
                }
            }
            soNgayCong = dsNgayCong.Count;

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
            nv.ThanhTienThuong = soNgayCong * donGiaThuong;
            nv.ThanhTienTang = 0;
            nv.TienTong = soNgayCong * donGiaThuong;
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
            List<int> DsID_Vthh_ = new List<int>();

            ModelShowSanLuongToIn dotTang = getNV_SanLuong_DotTang(idcn, dt);
            ModelShowSanLuongToIn hocViec = getNV_HocViec(idcn, dt);

            if (dotTang.DsIdVthh_DotTang.Count > 0)
            {
                result += (dotTang.ThanhTienThuong + dotTang.ThanhTienTang);
                TongSL_All_ += dotTang.SlTong;
                PhuCapBH = dotTang.PhuCapBaoHiem;
            }

            if (hocViec.SoNgayCong > 0)
            {
                result += hocViec.ThanhTienThuong;
                TongSL_All_ += hocViec.SoNgayCong;
                PhuCapBH = hocViec.PhuCapBaoHiem;
            }

            foreach (DataRow item in dt.Rows)
            {
                int ID_congNhan_ = Convert.ToInt32(item["ID_CongNhan"].ToString());
                int ID_Vthh_ = Convert.ToInt32(item["ID_VTHH_Vao"].ToString());

                //
                if (idcn == ID_congNhan_)
                {
                    if (ID_VthhRoot != ID_Vthh_ && !DsID_Vthh_.Contains(ID_Vthh_) && !dotTang.DsIdVthh_DotTang.Contains(ID_Vthh_))
                    {
                        DsID_Vthh_.Add(ID_Vthh_);
                        ID_VthhRoot = ID_Vthh_;
                        ModelShowSanLuongToIn nvSL = getNV_SanLuong(ID_congNhan_, ID_Vthh_, dt);
                        result += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
                        TongSL_All_ += nvSL.SlTong;
                        PhuCapBH = nvSL.PhuCapBaoHiem;
                    }
                }
            }

            t.TongTien = result;
            t.PhuCapBaoHiem = PhuCapBH;
            t.TongSL_All = TongSL_All_;

            return t;
        }

        //private ModelSanLuong getNV_SanLuong(int idcn, string loaiVthh, DataTable dt)
        //{
        //    ModelSanLuong nv = new ModelSanLuong();
        //    string hoTen = "";
        //    string tenVthhThuong = "";
        //    string tenVthhTang = "";
        //    double slTong = 0;
        //    double slThuong = 0;
        //    double slTang = 0;
        //    double donGiaThuong = 0;
        //    double donGiaTang = 0;
        //    int soNgayCong = 0;
        //    double phuCapBaoHiem = 0;
        //    double truBaoHiem = 0;
        //    List<int> dsNgayCong = new List<int>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        string loaiHH = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
        //        switch (loaiVthh)
        //        {
        //            case "thường":
        //                {
        //                    if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //                    {
        //                        if (!loaiHH.Contains("in mác") && !loaiHH.Contains("in trúc bách") && !loaiHH.Contains("in nhũ"))
        //                        {
        //                            hoTen = item["TenVTHH"].ToString();
        //                            slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
        //                            donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
        //                            donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //                            //phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
        //                            truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
        //                            int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

        //                            if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
        //                            {
        //                                if (!dsNgayCong.Contains(NgaySX))
        //                                {
        //                                    dsNgayCong.Add(NgaySX);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                break;
        //            case "in nhũ":
        //                {
        //                    if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //                    {
        //                        if (loaiHH.Contains("in nhũ"))
        //                        {
        //                            hoTen = item["TenVTHH"].ToString();
        //                            slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
        //                            donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
        //                            donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //                            truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
        //                            int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

        //                            if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
        //                            {
        //                                if (!dsNgayCong.Contains(NgaySX))
        //                                {
        //                                    dsNgayCong.Add(NgaySX);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                break;
        //            case "in mác":
        //                {
        //                    if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //                    {
        //                        if (loaiHH.Contains("in mác"))
        //                        {
        //                            hoTen = item["TenVTHH"].ToString();
        //                            slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
        //                            donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
        //                            donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //                            truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
        //                            int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

        //                            if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
        //                            {
        //                                if (!dsNgayCong.Contains(NgaySX))
        //                                {
        //                                    dsNgayCong.Add(NgaySX);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                break;
        //            case "in trúc bách":
        //                {
        //                    if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //                    {
        //                        if (loaiHH.Contains("in trúc bách"))
        //                        {
        //                            hoTen = item["TenVTHH"].ToString();
        //                            slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
        //                            donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
        //                            donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //                            truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
        //                            int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

        //                            if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
        //                            {
        //                                if (!dsNgayCong.Contains(NgaySX))
        //                                {
        //                                    dsNgayCong.Add(NgaySX);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                break;
        //        }
        //    }

        //    soNgayCong = dsNgayCong.Count;

        //    if (loaiVthh.Contains("in mác"))
        //    {
        //        slThuong = slTong;
        //        tenVthhThuong = "Sản lượng máy in mác";
        //        tenVthhTang = "";
        //    }
        //    else if (loaiVthh.Contains("in trúc bách"))
        //    {
        //        slThuong = slTong;
        //        tenVthhThuong = "Sản lượng máy in TB";
        //        tenVthhTang = "";
        //    }
        //    else if (loaiVthh.Contains("in nhũ"))
        //    {
        //        //if ((slTong - (soNgayCong * 35)) > 0)
        //        //{
        //        //    slThuong = soNgayCong * 35;
        //        //    slTang = slTong - (soNgayCong * 40);
        //        //}
        //        //else slThuong = slTong;
        //        slThuong = slTong;

        //        phuCapBaoHiem = slTong * 900000 / 910;

        //        tenVthhThuong = "Sản lượng giấy cuộn nhũ";
        //        tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
        //    }
        //    else
        //    {
        //        if ((slTong - (soNgayCong * 40)) > 0)
        //        {
        //            slThuong = soNgayCong * 40;
        //            slTang = slTong - (soNgayCong * 40);
        //        }
        //        else slThuong = slTong;

        //        phuCapBaoHiem = slTong * 900000 / 1040;

        //        tenVthhThuong = "Sản lượng giấy cuộn";
        //        tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
        //    }

        //    nv.HoTen = hoTen;
        //    nv.TenVthhThuong = tenVthhThuong;
        //    nv.TenVthhTang = tenVthhTang;
        //    nv.SlTong = slTong;
        //    nv.SlThuong = slThuong;
        //    nv.SlTang = slTang;
        //    nv.DonGiaThuong = donGiaThuong;
        //    nv.DonGiaTang = donGiaTang;
        //    nv.SoNgayCong = soNgayCong;
        //    nv.ThanhTienThuong = slThuong * donGiaThuong;
        //    nv.ThanhTienTang = slTang * donGiaTang;
        //    nv.PhuCapBaoHiem = phuCapBaoHiem;
        //    nv.TruBaoHiem = truBaoHiem;

        //    return nv;
        //}

        //private tinhTongCN tongTien(ModelSanLuong nvSL_thuong, ModelSanLuong nvSL_nhu, ModelSanLuong nvSL_mac, ModelSanLuong nvSL_tb)
        //{
        //    tinhTongCN t = new tinhTongCN();
        //    double result = 0;
        //    double PhuCapBH = 0;

        //    result += (nvSL_thuong.ThanhTienThuong + nvSL_thuong.ThanhTienTang);
        //    result += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);
        //    result += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);
        //    result += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);

        //    PhuCapBH += nvSL_thuong.PhuCapBaoHiem;
        //    PhuCapBH += nvSL_nhu.PhuCapBaoHiem;

        //    if (nvSL_mac.SlTong > 0 || nvSL_tb.SlTong > 0)
        //    {
        //        PhuCapBH = 0;
        //    }
        //    else
        //    {
        //        if (PhuCapBH >= 900000) PhuCapBH = 900000;
        //    }

        //    t.TongTien = result;
        //    t.PhuCapBaoHiem = PhuCapBH;

        //    return t;
        //}
        //public void LoadData(bool islandau)
        //{
        //    _data.Clear();
        //    isload = true;
        //    if (islandau)
        //    {
        //        DateTime dtnow = DateTime.Now;
        //        txtNam.Text = dtnow.Year.ToString();
        //        txtThang.Text = dtnow.Month.ToString();
        //        DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
        //        int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;

        //        _nam = DateTime.Now.Year;
        //        _thang = DateTime.Now.Month;
        //        //_thang = 4;


        //    }
        //    else
        //    {
        //    }
        //    double _ThanhTien_Tong_Ca1 = 0;  //Thành tiền
        //    double _ThucNhan_Tong_Ca1 = 0;
        //    double _NgayCong_Tong_Ca1 = 0;
        //    double _SanLuong_Tong_Ca1 = 0;
        //    double _XangXe_Tong_Ca1 = 0;
        //    double _BaoHiem_Tong_Ca1 = 0;
        //    double _Tong_Ca1 = 0;



        //    //
        //    double _ThanhTien_Tong_Ca2 = 0;
        //    double _ThucNhan_Tong_Ca2 = 0;
        //    double _NgayCong_Tong_Ca2 = 0;
        //    double _SanLuong_Tong_Ca2 = 0;
        //    double _XangXe_Tong_Ca2 = 0;
        //    double _BaoHiem_Tong_Ca2 = 0;
        //    double _Tong_Ca2 = 0;



        //    using (clsThin clsThin_ = new clsThin())
        //    {
        //        //Lấy dữ liệu ca1
        //        _dtCong_Ca1 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, true);
        //        _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 1, 0, "Ca 1", _id_bophan);

        //        //Lấy dữ liệu ca2
        //        _dtCong_Ca2 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, false);
        //        _dtSL_Ca2 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 1, 0, "Ca 2", _id_bophan);

        //        int SttCa1 = 0;
        //        int ID_congNhanRoot = -1;

        //        for (int i = 0; i < _dtCong_Ca1.Rows.Count; ++i)
        //        {
        //            int ID_congNhan = Convert.ToInt32(_dtCong_Ca1.Rows[i]["ID_CongNhan"].ToString());

        //            //
        //            if (ID_congNhanRoot != ID_congNhan)
        //            {
        //                DataRow ravi_ = _data.NewRow();
        //                ID_congNhanRoot = ID_congNhan;

        //                ModelSanLuong nvSL = getNV_SanLuong(ID_congNhan, _dtSL_Ca1);

        //                //STT
        //                SttCa1++;
        //                ravi_["STT"] = SttCa1;
        //                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtCong_Ca1.Rows[i]["TenNhanVien"].ToString());

        //                if (nvCN.CongTong == 0) ravi_["Cong"] = "";
        //                else ravi_["Cong"] = nvCN.CongTong.ToString("N2");

        //                if (nvSL.SlTong == 0) ravi_["SanLuong"] = "";
        //                else ravi_["SanLuong"] = nvSL.SlTong.ToString("N2");

        //                if (nvCN.DonGia == 0) ravi_["DonGia"] = "";
        //                else ravi_["DonGia"] = nvCN.DonGia.ToString("N2");

        //                if (nvCN.ThanhTien > nvSL.ThanhTien)
        //                {
        //                    ravi_["ThanhTien"] = nvCN.ThanhTien.ToString("N2");
        //                    ravi_["Tong"] = (nvCN.ThanhTien + nvCN.XangXe).ToString("N2");
        //                    ravi_["ThucNhan"] = (nvCN.ThanhTien + nvCN.XangXe - nvCN.BaoHiem).ToString("N2");

        //                    _ThanhTien_Tong_Ca1 += nvCN.ThanhTien;
        //                    _Tong_Ca1 += nvCN.ThanhTien + nvCN.XangXe;
        //                    _ThucNhan_Tong_Ca1 += nvCN.ThanhTien + nvCN.XangXe - nvCN.BaoHiem;
        //                }
        //                else
        //                {
        //                    ravi_["ThanhTien"] = nvSL.ThanhTien.ToString("N2");
        //                    ravi_["Tong"] = (nvSL.ThanhTien + nvCN.XangXe).ToString("N2");
        //                    ravi_["ThucNhan"] = (nvSL.ThanhTien + nvCN.XangXe - nvCN.BaoHiem).ToString("N2");

        //                    _ThanhTien_Tong_Ca1 += nvSL.ThanhTien;
        //                    _Tong_Ca1 += nvSL.ThanhTien + nvCN.XangXe;
        //                    _ThucNhan_Tong_Ca1 += nvSL.ThanhTien + nvCN.XangXe - nvCN.BaoHiem;
        //                }

        //                if (nvCN.XangXe == 0) ravi_["XangXe"] = "";
        //                else ravi_["XangXe"] = nvCN.XangXe.ToString("N2");

        //                if (nvCN.BaoHiem == 0) ravi_["BaoHiem"] = "";
        //                else ravi_["BaoHiem"] = nvCN.BaoHiem.ToString("N2");

        //                _NgayCong_Tong_Ca1 += nvCN.CongTong;
        //                _SanLuong_Tong_Ca1 += nvSL.SlTong;
        //                _XangXe_Tong_Ca1 += nvCN.XangXe;
        //                _BaoHiem_Tong_Ca1 += nvCN.BaoHiem;

        //                _data.Rows.Add(ravi_);
        //            }
        //        }

        //        //Add thêm row tổng ca 1:
        //        DataRow _ravi = _data.NewRow();
        //        _ravi["ID_CongNhan"] = 0;
        //        _ravi["Thang"] = _thang;
        //        _ravi["Nam"] = _nam;
        //        _ravi["TenNhanVien"] = "CA 1:";

        //        //
        //        if (_NgayCong_Tong_Ca1 == 0)
        //        {
        //            _ravi["Cong"] = "";
        //        }
        //        else
        //        {
        //            _ravi["Cong"] = _NgayCong_Tong_Ca1.ToString("N2");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca1 == 0)
        //        {
        //            _ravi["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi["SanLuong"] = _SanLuong_Tong_Ca1.ToString("N2");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca1 == 0)
        //        {
        //            _ravi["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi["ThanhTien"] = _ThanhTien_Tong_Ca1.ToString("N2");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca1 == 0)
        //        {
        //            _ravi["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi["XangXe"] = _XangXe_Tong_Ca1.ToString("N2");
        //        }

        //        //
        //        if (_Tong_Ca1 == 0)
        //        {
        //            _ravi["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi["Tong"] = _Tong_Ca1.ToString("N2");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca1 == 0)
        //        {
        //            _ravi["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi["BaoHiem"] = _BaoHiem_Tong_Ca1.ToString("N2");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca1 == 0)
        //        {
        //            _ravi["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi["ThucNhan"] = _ThucNhan_Tong_Ca1.ToString("N2");
        //        }

        //        _data.Rows.Add(_ravi);
        //        _indexTongCa1 = _data.Rows.Count - 1;


        //        //Ca 2:
        //        int SttCa2 = 0;
        //        ID_congNhanRoot = -1;

        //        for (int i = 0; i < _dtCong_Ca2.Rows.Count; ++i)
        //        {
        //            int ID_congNhan = Convert.ToInt32(_dtCong_Ca2.Rows[i]["ID_CongNhan"].ToString());

        //            //
        //            if (ID_congNhanRoot != ID_congNhan)
        //            {
        //                DataRow ravi_ = _data.NewRow();
        //                ID_congNhanRoot = ID_congNhan;

        //                ModelCongNhat nvCN = getNV_CongNhat(ID_congNhan, _dtCong_Ca2);
        //                ModelSanLuong nvSL = getNV_SanLuong(ID_congNhan, _dtSL_Ca2);

        //                //STT
        //                SttCa2++;
        //                ravi_["STT"] = SttCa2;
        //                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtCong_Ca2.Rows[i]["TenNhanVien"].ToString());

        //                if (nvCN.CongTong == 0) ravi_["Cong"] = "";
        //                else ravi_["Cong"] = nvCN.CongTong.ToString("N2");

        //                if (nvSL.SlTong == 0) ravi_["SanLuong"] = "";
        //                else ravi_["SanLuong"] = nvSL.SlTong.ToString("N2");

        //                if (nvCN.DonGia == 0) ravi_["DonGia"] = "";
        //                else ravi_["DonGia"] = nvCN.DonGia.ToString("N2");

        //                if (nvCN.ThanhTien > nvSL.ThanhTien)
        //                {
        //                    ravi_["ThanhTien"] = nvCN.ThanhTien.ToString("N2");
        //                    ravi_["Tong"] = (nvCN.ThanhTien + nvCN.XangXe).ToString("N2");
        //                    ravi_["ThucNhan"] = (nvCN.ThanhTien + nvCN.XangXe - nvCN.BaoHiem).ToString("N2");

        //                    _ThanhTien_Tong_Ca2 += nvCN.ThanhTien;
        //                    _Tong_Ca2 += nvCN.ThanhTien + nvCN.XangXe;
        //                    _ThucNhan_Tong_Ca2 += nvCN.ThanhTien + nvCN.XangXe - nvCN.BaoHiem;
        //                }
        //                else
        //                {
        //                    ravi_["ThanhTien"] = nvSL.ThanhTien.ToString("N2");
        //                    ravi_["Tong"] = (nvSL.ThanhTien + nvCN.XangXe).ToString("N2");
        //                    ravi_["ThucNhan"] = (nvSL.ThanhTien + nvCN.XangXe - nvCN.BaoHiem).ToString("N2");

        //                    _ThanhTien_Tong_Ca2 += nvSL.ThanhTien;
        //                    _Tong_Ca2 += nvSL.ThanhTien + nvCN.XangXe;
        //                    _ThucNhan_Tong_Ca2 += nvSL.ThanhTien + nvCN.XangXe - nvCN.BaoHiem;
        //                }

        //                if (nvCN.XangXe == 0) ravi_["XangXe"] = "";
        //                else ravi_["XangXe"] = nvCN.XangXe.ToString("N2");

        //                if (nvCN.BaoHiem == 0) ravi_["BaoHiem"] = "";
        //                else ravi_["BaoHiem"] = nvCN.BaoHiem.ToString("N2");

        //                _NgayCong_Tong_Ca2 += nvCN.CongTong;
        //                _SanLuong_Tong_Ca2 += nvSL.SlTong;
        //                _XangXe_Tong_Ca2 += nvCN.XangXe;
        //                _BaoHiem_Tong_Ca2 += nvCN.BaoHiem;

        //                _data.Rows.Add(ravi_);
        //            }
        //        }

        //        //Add thêm row tổng ca 2:
        //        DataRow _ravi_ca2 = _data.NewRow();
        //        _ravi_ca2["ID_CongNhan"] = 0;
        //        _ravi_ca2["Thang"] = _thang;
        //        _ravi_ca2["Nam"] = _nam;
        //        _ravi_ca2["TenNhanVien"] = "CA 2:";

        //        //
        //        if (_NgayCong_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["Cong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["Cong"] = _NgayCong_Tong_Ca2.ToString("N2");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["SanLuong"] = _SanLuong_Tong_Ca2.ToString("N2");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["ThanhTien"] = _ThanhTien_Tong_Ca2.ToString("N2");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["XangXe"] = _XangXe_Tong_Ca2.ToString("N2");
        //        }

        //        //
        //        if (_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["Tong"] = _Tong_Ca2.ToString("N2");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["BaoHiem"] = _BaoHiem_Tong_Ca2.ToString("N2");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["ThucNhan"] = _ThucNhan_Tong_Ca2.ToString("N2");
        //        }

        //        _data.Rows.Add(_ravi_ca2);

        //        //Add Tổng 2 ca:
        //        //Add thêm row tổng ca 2:
        //        DataRow _ravi_2ca = _data.NewRow();
        //        _ravi_2ca["ID_CongNhan"] = 0;
        //        _ravi_2ca["Thang"] = _thang;
        //        _ravi_2ca["Nam"] = _nam;
        //        _ravi_2ca["TenNhanVien"] = "Tổng";

        //        //
        //        if (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["Cong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["Cong"] = (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1).ToString("N2");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["SanLuong"] = (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1).ToString("N2");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["ThanhTien"] = (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1).ToString("N2");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["XangXe"] = (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1).ToString("N2");
        //        }

        //        //
        //        if (_Tong_Ca2 + _Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["Tong"] = (_Tong_Ca2 + _Tong_Ca1).ToString("N2");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["BaoHiem"] = (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1).ToString("N2");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["ThucNhan"] = (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1).ToString("N2");
        //        }

        //        _data.Rows.Add(_ravi_2ca);

        //        gridControl1.DataSource = _data;
        //        //  
        //        isload = false;
        //    }
        //}

        ////Tính tổng công nhật:
        //private double TongCongNhat(int idcn, DataTable dt)
        //{
        //    double Result = 0;

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString())
        //            && item["Cong"].ToString().Contains("công nhật"))
        //        {
        //            Result += CheckString.ConvertToDouble_My(item["SanLuong_Value"].ToString());
        //        }
        //    }

        //    return Result;
        //}

        ////Tính tổng công tăng ca:
        //private double TongCongTangCa(int idcn, DataTable dt)
        //{
        //    double Result = 0;

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString())
        //            && item["Cong"].ToString().Contains("tăng"))
        //        {
        //            Result += CheckString.ConvertToDouble_My(item["SanLuong_Value"].ToString());
        //        }
        //    }

        //    return Result;
        //}


        ////Tính tổng công nhật 1 công nhân:
        //private ModelCongNhat getNV_CongNhat(int idcn, DataTable dt)
        //{
        //    ModelCongNhat nv = new ModelCongNhat();
        //    double congNhat = 0;
        //    double congTang = 0;
        //    double TongCong = 0;
        //    double ThanhTien = 0;
        //    double donGia = 0;
        //    double xangXe = 0;
        //    double baoHiem = 0;

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //        {
        //            TongCong += CheckString.ConvertToDouble_My(item["SanLuong_Value"].ToString());
        //            ThanhTien += CheckString.ConvertToDouble_My(item["TongLuong_Value"].ToString());
        //            xangXe = CheckString.ConvertToDouble_My(item["XangXe_Value"].ToString());
        //            baoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());

        //            if (item["TenLoaiCong"].ToString().ToLower().Contains("công nhật"))
        //            {
        //                donGia = CheckString.ConvertToDouble_My(item["DonGia_Value"].ToString());
        //            }
        //            //if (item["Cong"].ToString().ToLower().Contains("công nhật"))
        //            //{
        //            //    congNhat += CheckString.ConvertToDouble_My(item["SanLuong_Value"].ToString());
        //            //    donGiaCong = CheckString.ConvertToDouble_My(item["DinhMucLuongTheoGio"].ToString());
        //            //}

        //            //if (item["Cong"].ToString().ToLower().Contains("tăng"))
        //            //{
        //            //    congTang += CheckString.ConvertToDouble_My(item["SanLuong_Value"].ToString());
        //            //    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMucLuongTangCa"].ToString());
        //            //}
        //        }
        //    }

        //    nv.CongNhat = congNhat;
        //    nv.CongTang = congTang;
        //    nv.DonGia = donGia;
        //    nv.XangXe = xangXe;
        //    nv.BaoHiem = baoHiem;
        //    nv.CongTong = TongCong;
        //    nv.ThanhTien = ThanhTien;

        //    return nv;
        //}

        ////Tính tổng sản lượng một công nhân:
        //private ModelSanLuong getNV_SanLuong(int idcn, DataTable dt)
        //{
        //    ModelSanLuong nv = new ModelSanLuong();
        //    double slThuong =0;
        //    double slTang = 0;
        //    double tienThuong = 0;
        //    double tienTang = 0;

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
        //        {

        //            slThuong += CheckString.ConvertToDouble_My(item["SanLuong_Thuong_Value"].ToString());
        //            slTang += CheckString.ConvertToDouble_My(item["SanLuong_TangCa_Value"].ToString());

        //            tienThuong += CheckString.ConvertToDouble_My(item["SanLuong_Thuong_Value"].ToString()) 
        //                          * CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());

        //            tienTang += CheckString.ConvertToDouble_My(item["SanLuong_TangCa_Value"].ToString())
        //                        * CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //        }
        //    }

        //    nv.SlThuong = slThuong;
        //    nv.SlTang = slTang;
        //    nv.SlTong = slThuong + slTang;
        //    //nv.ThanhTien = tienThuong + tienTang;

        //    return nv;
        //}

        ////Loại công:
        //string LoaiCong = _dtCong_Ca1.Rows[i]["Cong"].ToString();
        //_data.Rows[i]["TenVTHH"] = LoaiCong;

        //            if (LoaiCong.ToLower().Contains("tăng"))
        //            {
        //                //Đơn giá tăng ca:
        //                LuongCoBan = CheckString.ConvertToDouble_My(_dtCong_Ca1.Rows[i]["DinhMucLuongTangCa"].ToString());
        //            }
        //            else if (LoaiCong.ToLower().Contains("công nhật"))
        //            {
        //                //Đơn giá công nhật
        //                LuongCoBan = CheckString.ConvertToDouble_My(_dtCong_Ca1.Rows[i]["DinhMucLuongTheoGio"].ToString());
        //            }


        private void frmBTTL_TMC_CT_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index_ = e.RowHandle;
            string name_ = e.Column.FieldName;
            if (name_.Contains("Ngay"))
            {
                _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
                if (_data.Rows.Count > index_)
                {
                    int temp_ = Convert.ToInt32(_data.Rows[index_][name_].ToString());
                    _data.Rows[index_]["Tong"] = temp_ + Convert.ToInt32(_data.Rows[index_]["Tong"].ToString());
                }

            }
            else if (name_.Contains("TenVTHH"))
            {
                if (gridView1.GetFocusedRowCellValue(name_) == null)
                {
                    _data.Rows[index_][name_] = "";
                }
                else
                {
                    _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
                }
            }
            // gridView1.SetRowCellValue(e.RowHandle, clSLThuong, tongcong); 
        }

        private void linkQuanLyMaHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhThang();
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhThang();
        }
        private void HoanThanhThang()
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HoanThanhNam()
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Năm không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_CongNhan).ToString());
                string tencn_ = gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString();
                if (id_congnhan_ != 0)
                {
                    Tr_frmChiTiet_LuongSanLuongCN_TMC ff = new Tr_frmChiTiet_LuongSanLuongCN_TMC(_thang, _nam, _id_bophan, id_congnhan_, tencn_);
                    ff.Show();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_CT(_thang, _nam, _data);
            ff.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ten = View.GetRowCellValue(e.RowHandle, View.Columns["TenNhanVien"]).ToString();
                if (ten == "CA 1:" || ten == "CA 2:" || ten == "Tổng")
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_TQ(_thang, _nam, _data);
            ff.Show();
        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //miiID_chiTietChamCong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ChiTietChamCong).ToString());
            //miiD_DinhMuc_Luong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
            // miID_congNhan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());

            // msTenNhanVien = gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString();
            //frmMaHang_ChamCong_ToGapDan ff = new frmMaHang_ChamCong_ToGapDan(this);
            //ff.Show();
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
           // GuiDuLieuBangLuong();
        }

        private float ConvertToFloat(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = CheckString.ConvertToDouble_My(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch
            {
                try
                {
                    result = CheckString.ConvertToDouble_My(s);
                }
                catch
                {
                    try
                    {
                        result = CheckString.ConvertToDouble_My(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return (float)result;
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}


