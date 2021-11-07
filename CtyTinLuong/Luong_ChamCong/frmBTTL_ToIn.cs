
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
    public partial class frmBTTL_ToIn : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan, _indexTongCa1 = 0;
        public string _ten_vthh, _MaNhanVien = "";
        private DataTable _data, _dtSL_Ca1, _dtSL_Ca2;
        //private DataTable _data, _dtCong_Ca1, _dtCong_Ca2, _dtSL_Ca1, _dtSL_Ca2;

        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_ToIn(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
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

            PhuCapBaoHiem.Caption = "PHỤ CẤP\nBẢO HIỂM";
        }

        #region loaddata
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
        //    double _PCBaoHiem_Tong_Ca1 = 0;
        //    double _Tong_Ca1 = 0;



        //    //
        //    double _ThanhTien_Tong_Ca2 = 0;
        //    double _ThucNhan_Tong_Ca2 = 0;
        //    double _NgayCong_Tong_Ca2 = 0;
        //    double _SanLuong_Tong_Ca2 = 0;
        //    double _XangXe_Tong_Ca2 = 0;
        //    double _BaoHiem_Tong_Ca2 = 0;
        //    double _PCBaoHiem_Tong_Ca2 = 0;
        //    double _Tong_Ca2 = 0;



        //    using (clsThin clsThin_ = new clsThin())
        //    {
        //        //Lấy dữ liệu ca1
        //        //_dtCong_Ca1 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, true);
        //        _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "Ca 1");

        //        //Lấy dữ liệu ca2
        //        //_dtCong_Ca2 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, false);
        //        _dtSL_Ca2 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "Ca 2");

        //        int SttCa1 = 0;
        //        int ID_congNhanRoot = -1;
        //        int ID_VthhRoot = -1;
        //        int ID_congNhanAddPCBH = Convert.ToInt32(_dtSL_Ca1.Rows[0]["ID_CongNhan"].ToString());

        //        for (int i = 0; i < _dtSL_Ca1.Rows.Count; ++i)
        //        {
        //            int ID_congNhan = Convert.ToInt32(_dtSL_Ca1.Rows[i]["ID_CongNhan"].ToString());
        //            int ID_Vthh = Convert.ToInt32(_dtSL_Ca1.Rows[i]["ID_VTHH_Ra"].ToString());

        //            ModelSanLuong nvSL = getNV_SanLuong(ID_congNhan, ID_Vthh, _dtSL_Ca1);
        //            tinhTongCN t = tongTien(ID_congNhan, _dtSL_Ca1);

        //            //
        //            if (ID_congNhanRoot != ID_congNhan)
        //            {
        //                ID_congNhanRoot = ID_congNhan;
        //                ID_VthhRoot = -1;
        //                if (ID_VthhRoot != ID_Vthh)
        //                {
        //                    DataRow ravi_ = _data.NewRow();
        //                    ID_VthhRoot = ID_Vthh;

        //                    //STT
        //                    SttCa1++;
        //                    ravi_["STT"] = SttCa1;
        //                    ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

        //                    ravi_["HinhThuc"] = nvSL.TenVthhThuong;

        //                    if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
        //                    else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N0");

        //                    if (nvSL.SlThuong == 0) ravi_["SanLuong"] = "";
        //                    else ravi_["SanLuong"] = nvSL.SlThuong.ToString("N0");

        //                    if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
        //                    else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

        //                    ravi_["ThanhTien"] = nvSL.ThanhTienThuong.ToString("N0");


        //                    double tongtien = t.TongTien;
        //                    ravi_["Tong"] = (nvSL.PhuCapBaoHiem + tongtien).ToString("N0");

        //                    ravi_["ThucNhan"] = (nvSL.PhuCapBaoHiem + tongtien - nvSL.TruBaoHiem).ToString("N0");

        //                    _SanLuong_Tong_Ca1 += nvSL.SlTong;
        //                    _ThanhTien_Tong_Ca1 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
        //                    _Tong_Ca1 += (nvSL.PhuCapBaoHiem + tongtien);
        //                    _ThucNhan_Tong_Ca1 += (nvSL.PhuCapBaoHiem + tongtien - nvSL.TruBaoHiem);


        //                    if (nvSL.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
        //                    else ravi_["BaoHiem"] = nvSL.TruBaoHiem.ToString("N0");

        //                    if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
        //                    else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

        //                    _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

        //                    _BaoHiem_Tong_Ca1 += nvSL.TruBaoHiem;

        //                    _data.Rows.Add(ravi_);

        //                    //
        //                    if (nvSL.SlTang > 0)
        //                    {
        //                        DataRow ravi_tang = _data.NewRow();

        //                        //STT
        //                        ravi_tang["STT"] = SttCa1;
        //                        ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

        //                        ravi_tang["HinhThuc"] = nvSL.TenVthhTang;

        //                        ravi_tang["NgayCong"] = "";

        //                        if (nvSL.SlTang == 0) ravi_tang["SanLuong"] = "";
        //                        else ravi_tang["SanLuong"] = nvSL.SlTang.ToString("N0");

        //                        if (nvSL.DonGiaTang == 0) ravi_tang["DonGia"] = "";
        //                        else ravi_tang["DonGia"] = nvSL.DonGiaTang.ToString("N2");

        //                        ravi_tang["ThanhTien"] = nvSL.ThanhTienTang.ToString("N0");

        //                        _data.Rows.Add(ravi_tang);
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }
        //            else
        //            {
        //                if (ID_VthhRoot != ID_Vthh)
        //                {
        //                    DataRow ravi_ = _data.NewRow();
        //                    ID_VthhRoot = ID_Vthh;

        //                    //STT
        //                    ravi_["STT"] = SttCa1;
        //                    ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

        //                    ravi_["HinhThuc"] = nvSL.TenVthhThuong;

        //                    if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
        //                    else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N0");

        //                    if (nvSL.SlThuong == 0) ravi_["SanLuong"] = "";
        //                    else ravi_["SanLuong"] = nvSL.SlThuong.ToString("N0");

        //                    if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
        //                    else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

        //                    ravi_["ThanhTien"] = nvSL.ThanhTienThuong.ToString("N0");

        //                    _SanLuong_Tong_Ca1 += nvSL.SlTong;
        //                    _ThanhTien_Tong_Ca1 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);

        //                    _data.Rows.Add(ravi_);

        //                    //
        //                    if (nvSL.SlTang > 0)
        //                    {
        //                        DataRow ravi_tang = _data.NewRow();

        //                        //STT
        //                        ravi_tang["STT"] = SttCa1;
        //                        ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

        //                        ravi_tang["HinhThuc"] = nvSL.TenVthhTang;

        //                        ravi_tang["NgayCong"] = "";

        //                        if (nvSL.SlTang == 0) ravi_tang["SanLuong"] = "";
        //                        else ravi_tang["SanLuong"] = nvSL.SlTang.ToString("N0");

        //                        if (nvSL.DonGiaTang == 0) ravi_tang["DonGia"] = "";
        //                        else ravi_tang["DonGia"] = nvSL.DonGiaTang.ToString("N2");

        //                        ravi_tang["ThanhTien"] = nvSL.ThanhTienTang.ToString("N0");

        //                        _data.Rows.Add(ravi_tang);
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }

        //            //if (ID_congNhanAddPCBH != ID_congNhan)
        //            //{
        //            //    if (t.PhuCapBaoHiem > 0)
        //            //    {
        //            //        DataRow ravi_tang = _data.NewRow();
        //            //        ravi_tang["STT"] = SttCa1;
        //            //        ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());
        //            //        ravi_tang["HinhThuc"] = "Phụ cấp bảo hiểm";
        //            //        ravi_tang["NgayCong"] = "";
        //            //        ravi_tang["SanLuong"] = "";
        //            //        ravi_tang["DonGia"] = "";
        //            //        ravi_tang["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");
        //            //        ravi_tang["ThanhTien"] = "";
        //            //        _data.Rows.Add(ravi_tang);
        //            //    }
        //            //}
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
        //            _ravi["HinhThuc"] = "";
        //        }
        //        else
        //        {
        //            _ravi["HinhThuc"] = _NgayCong_Tong_Ca1.ToString("N0");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca1 == 0)
        //        {
        //            _ravi["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi["SanLuong"] = _SanLuong_Tong_Ca1.ToString("N0");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca1 == 0)
        //        {
        //            _ravi["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi["ThanhTien"] = _ThanhTien_Tong_Ca1.ToString("N0");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca1 == 0)
        //        {
        //            _ravi["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi["XangXe"] = _XangXe_Tong_Ca1.ToString("N0");
        //        }

        //        //
        //        if (_Tong_Ca1 == 0)
        //        {
        //            _ravi["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi["Tong"] = _Tong_Ca1.ToString("N0");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca1 == 0)
        //        {
        //            _ravi["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi["BaoHiem"] = _BaoHiem_Tong_Ca1.ToString("N0");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca1 == 0)
        //        {
        //            _ravi["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi["ThucNhan"] = _ThucNhan_Tong_Ca1.ToString("N0");
        //        }

        //        //_data.Rows.Add(_ravi);
        //        _data.Rows.InsertAt(_ravi, 0);
        //        _indexTongCa1 = _data.Rows.Count;


        //        //Ca 2:
        //        int SttCa2 = 0;
        //        ID_congNhanRoot = -1;
        //        ID_VthhRoot = -1;

        //        for (int i = 0; i < _dtSL_Ca2.Rows.Count; ++i)
        //        {
        //            int ID_congNhan = Convert.ToInt32(_dtSL_Ca2.Rows[i]["ID_CongNhan"].ToString());
        //            int ID_Vthh = Convert.ToInt32(_dtSL_Ca2.Rows[i]["ID_VTHH_Ra"].ToString());

        //            ModelSanLuong nvSL = getNV_SanLuong(ID_congNhan, ID_Vthh, _dtSL_Ca2);
        //            tinhTongCN t = tongTien(ID_congNhan, _dtSL_Ca2);

        //            //
        //            if (ID_congNhanRoot != ID_congNhan)
        //            {
        //                ID_congNhanRoot = ID_congNhan;
        //                ID_VthhRoot = -1;

        //                if (ID_VthhRoot != ID_Vthh)
        //                {
        //                    DataRow ravi_ = _data.NewRow();
        //                    ID_VthhRoot = ID_Vthh;

        //                    //STT
        //                    SttCa2++;
        //                    ravi_["STT"] = SttCa2;
        //                    ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

        //                    ravi_["HinhThuc"] = nvSL.TenVthhThuong;

        //                    if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
        //                    else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N0");

        //                    if (nvSL.SlThuong == 0) ravi_["SanLuong"] = "";
        //                    else ravi_["SanLuong"] = nvSL.SlThuong.ToString("N0");

        //                    if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
        //                    else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

        //                    ravi_["ThanhTien"] = nvSL.ThanhTienThuong.ToString("N0");


        //                    double tongtien = t.TongTien;
        //                    ravi_["Tong"] = (nvSL.PhuCapBaoHiem + tongtien).ToString("N0");

        //                    ravi_["ThucNhan"] = (nvSL.PhuCapBaoHiem + tongtien - nvSL.TruBaoHiem).ToString("N0");

        //                    _SanLuong_Tong_Ca2 += nvSL.SlTong;
        //                    _ThanhTien_Tong_Ca2 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);
        //                    _Tong_Ca2 += (nvSL.PhuCapBaoHiem + tongtien);
        //                    _ThucNhan_Tong_Ca2 += (nvSL.PhuCapBaoHiem + tongtien - nvSL.TruBaoHiem);


        //                    if (nvSL.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
        //                    else ravi_["BaoHiem"] = nvSL.TruBaoHiem.ToString("N0");

        //                    if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
        //                    else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

        //                    _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

        //                    _BaoHiem_Tong_Ca2 += nvSL.TruBaoHiem;

        //                    _data.Rows.Add(ravi_);

        //                    //
        //                    if (nvSL.SlTang > 0)
        //                    {
        //                        DataRow ravi_tang = _data.NewRow();

        //                        //STT
        //                        ravi_tang["STT"] = SttCa2;
        //                        ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

        //                        ravi_tang["HinhThuc"] = nvSL.TenVthhTang;

        //                        ravi_tang["NgayCong"] = "";

        //                        if (nvSL.SlTang == 0) ravi_tang["SanLuong"] = "";
        //                        else ravi_tang["SanLuong"] = nvSL.SlTang.ToString("N0");

        //                        if (nvSL.DonGiaTang == 0) ravi_tang["DonGia"] = "";
        //                        else ravi_tang["DonGia"] = nvSL.DonGiaTang.ToString("N2");

        //                        ravi_tang["ThanhTien"] = nvSL.ThanhTienTang.ToString("N0");

        //                        _data.Rows.Add(ravi_tang);
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }
        //            else
        //            {
        //                if (ID_VthhRoot != ID_Vthh)
        //                {
        //                    DataRow ravi_ = _data.NewRow();
        //                    ID_VthhRoot = ID_Vthh;

        //                    //STT
        //                    ravi_["STT"] = SttCa2;
        //                    ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

        //                    ravi_["HinhThuc"] = nvSL.TenVthhThuong;

        //                    if (nvSL.SoNgayCong == 0) ravi_["NgayCong"] = "";
        //                    else ravi_["NgayCong"] = nvSL.SoNgayCong.ToString("N0");

        //                    if (nvSL.SlThuong == 0) ravi_["SanLuong"] = "";
        //                    else ravi_["SanLuong"] = nvSL.SlThuong.ToString("N0");

        //                    if (nvSL.DonGiaThuong == 0) ravi_["DonGia"] = "";
        //                    else ravi_["DonGia"] = nvSL.DonGiaThuong.ToString("N2");

        //                    ravi_["ThanhTien"] = nvSL.ThanhTienThuong.ToString("N0");

        //                    _SanLuong_Tong_Ca2 += nvSL.SlTong;
        //                    _ThanhTien_Tong_Ca2 += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);

        //                    _data.Rows.Add(ravi_);

        //                    //
        //                    if (nvSL.SlTang > 0)
        //                    {
        //                        DataRow ravi_tang = _data.NewRow();

        //                        //STT
        //                        ravi_tang["STT"] = SttCa2;
        //                        ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

        //                        ravi_tang["HinhThuc"] = nvSL.TenVthhTang;

        //                        ravi_tang["NgayCong"] = "";

        //                        if (nvSL.SlTang == 0) ravi_tang["SanLuong"] = "";
        //                        else ravi_tang["SanLuong"] = nvSL.SlTang.ToString("N0");

        //                        if (nvSL.DonGiaTang == 0) ravi_tang["DonGia"] = "";
        //                        else ravi_tang["DonGia"] = nvSL.DonGiaTang.ToString("N2");

        //                        ravi_tang["ThanhTien"] = nvSL.ThanhTienTang.ToString("N0");

        //                        _data.Rows.Add(ravi_tang);
        //                    }
        //                }
        //                else
        //                {

        //                }
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
        //            _ravi_ca2["HinhThuc"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["HinhThuc"] = _NgayCong_Tong_Ca2.ToString("N0");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["SanLuong"] = _SanLuong_Tong_Ca2.ToString("N0");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["ThanhTien"] = _ThanhTien_Tong_Ca2.ToString("N0");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["XangXe"] = _XangXe_Tong_Ca2.ToString("N0");
        //        }

        //        //
        //        if (_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["Tong"] = _Tong_Ca2.ToString("N0");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["BaoHiem"] = _BaoHiem_Tong_Ca2.ToString("N0");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca2 == 0)
        //        {
        //            _ravi_ca2["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi_ca2["ThucNhan"] = _ThucNhan_Tong_Ca2.ToString("N0");
        //        }

        //        //_data.Rows.Add(_ravi_ca2);
        //        _data.Rows.InsertAt(_ravi_ca2, _indexTongCa1);

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
        //            _ravi_2ca["HinhThuc"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["HinhThuc"] = (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1).ToString("N0");
        //        }

        //        //
        //        if (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["SanLuong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["SanLuong"] = (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1).ToString("N0");
        //        }

        //        //
        //        if (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["ThanhTien"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["ThanhTien"] = (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1).ToString("N0");
        //        }

        //        //
        //        if (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["XangXe"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["XangXe"] = (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1).ToString("N0");
        //        }

        //        //
        //        if (_Tong_Ca2 + _Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["Tong"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["Tong"] = (_Tong_Ca2 + _Tong_Ca1).ToString("N0");
        //        }

        //        //
        //        if (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["BaoHiem"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["BaoHiem"] = (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1).ToString("N0");
        //        }

        //        // 
        //        if (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1 == 0)
        //        {
        //            _ravi_2ca["ThucNhan"] = "";
        //        }
        //        else
        //        {
        //            _ravi_2ca["ThucNhan"] = (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1).ToString("N0");
        //        }

        //        _data.Rows.Add(_ravi_2ca);

        //        gridControl1.DataSource = _data;
        //        //  
        //        isload = false;
        //    }
        //}


        ////Tính tổng sản lượng một công nhân:
        //private ModelSanLuong getNV_SanLuong(int idcn, int idvthh, DataTable dt)
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
        //    string LoaiHangHoa = "";
        //    List<int> dsNgayCong = new List<int>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString())
        //            && idvthh == Convert.ToInt32(item["ID_VTHH_Ra"].ToString()))
        //        {
        //            hoTen = item["TenVTHH"].ToString();
        //            slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
        //            donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
        //            donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
        //            phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
        //            truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
        //            LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();

        //            int NgaySX = Convert.ToDateTime(item["BaoHiem_Value"].ToString()).Day;

        //            if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
        //            {
        //                if (!dsNgayCong.Contains(NgaySX))
        //                {
        //                    dsNgayCong.Add(NgaySX);
        //                }
        //            }
        //        }
        //    }

        //    soNgayCong = dsNgayCong.Count;
        //    if (LoaiHangHoa.Contains("in mác"))
        //    {
        //        slThuong = slTong;
        //        tenVthhThuong = "Sản lượng máy in mác";
        //        tenVthhTang = "";
        //    }
        //    else if (LoaiHangHoa.Contains("in trúc bách"))
        //    {
        //        slThuong = slTong;
        //        tenVthhThuong = "Sản lượng máy in TB";
        //        tenVthhTang = "";
        //    }
        //    else if (LoaiHangHoa.Contains("in nhũ"))
        //    {
        //        if ((slTong - (soNgayCong * 35)) > 0)
        //        {
        //            slThuong = soNgayCong * 35;
        //            slTang = slTong - (soNgayCong * 40);
        //        }
        //        else slThuong = slTong;

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

        //private tinhTongCN tongTien(int idcn, DataTable dt)
        //{
        //    tinhTongCN t = new tinhTongCN();
        //    double result = 0;
        //    double PhuCapBH = 0;
        //    int ID_VthhRoot = -1;
        //    bool isInMac_TB = false;

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        int ID_congNhan_ = Convert.ToInt32(item["ID_CongNhan"].ToString());
        //        int ID_Vthh_ = Convert.ToInt32(item["ID_VTHH_Ra"].ToString());

        //        //
        //        if (idcn == ID_congNhan_)
        //        {
        //            if (ID_VthhRoot != ID_Vthh_)
        //            {
        //                ID_VthhRoot = ID_Vthh_;
        //                ModelSanLuong nvSL = getNV_SanLuong(ID_congNhan_, ID_Vthh_, dt);
        //                result += (nvSL.ThanhTienThuong + nvSL.ThanhTienTang);

        //                PhuCapBH += nvSL.PhuCapBaoHiem;

        //                if (nvSL.TenVthhThuong.ToLower().Contains("in mác") || nvSL.TenVthhThuong.ToLower().Contains("in tb"))
        //                {
        //                    isInMac_TB = true;
        //                }
        //            }
        //        }
        //    }

        //    if (isInMac_TB)
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
        #endregion

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
                _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "Ca 1", _id_bophan);

                //Lấy dữ liệu ca2
                _dtSL_Ca2 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "Ca 2", _id_bophan);

                int SttCa1 = 0;
                int ID_congNhanRoot = -1;
                //int ID_congNhanAddPCBH = Convert.ToInt32(_dtSL_Ca1.Rows[0]["ID_CongNhan"].ToString());

                for (int i = 0; i < _dtSL_Ca1.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_dtSL_Ca1.Rows[i]["ID_CongNhan"].ToString());
                    string MaNV_ = _dtSL_Ca1.Rows[i]["MaNhanVien"].ToString();
                    //
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ModelSanLuong nvSL_thuong = getNV_SanLuong(ID_congNhan, "thường", _dtSL_Ca1);
                        ModelSanLuong nvSL_nhu = getNV_SanLuong(ID_congNhan, "in nhũ", _dtSL_Ca1);
                        ModelSanLuong nvSL_mac = getNV_SanLuong(ID_congNhan, "in mác", _dtSL_Ca1);
                        ModelSanLuong nvSL_tb = getNV_SanLuong(ID_congNhan, "in trúc bách", _dtSL_Ca1);
                        ModelSanLuong nvHocViec = getNV_HocViec(ID_congNhan, _dtSL_Ca1);


                        tinhTongCN t = tongTien(nvSL_thuong, nvSL_nhu, nvSL_mac, nvSL_tb, nvHocViec);

                        ID_congNhanRoot = ID_congNhan;
                        SttCa1++;
                        if (nvSL_thuong.SlTong > 0)
                        {
                            DataRow ravi_ = _data.NewRow();
                            ravi_["ID_CongNhan"] = ID_congNhan;
                            ravi_["MaNhanVien"] = MaNV_;

                             ravi_["STT"] = SttCa1;
                            ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                            ravi_["HinhThuc"] = nvSL_thuong.TenVthhThuong;

                            if (nvSL_thuong.SoNgayCong == 0) ravi_["NgayCong"] = "";
                            else ravi_["NgayCong"] = nvSL_thuong.SoNgayCong.ToString("N0");

                            if (nvSL_thuong.SlThuong == 0) ravi_["SanLuong"] = "";
                            else ravi_["SanLuong"] = nvSL_thuong.SlThuong.ToString("N0");

                            if (nvSL_thuong.DonGiaThuong == 0) ravi_["DonGia"] = "";
                            else ravi_["DonGia"] = nvSL_thuong.DonGiaThuong.ToString("N2");

                            ravi_["ThanhTien"] = nvSL_thuong.ThanhTienThuong.ToString("N0");


                            double tongtien = t.TongTien;
                            ravi_["Tong"] = (nvSL_thuong.PhuCapBaoHiem + tongtien).ToString("N0");

                            ravi_["ThucNhan"] = (nvSL_thuong.PhuCapBaoHiem + tongtien - nvSL_thuong.TruBaoHiem).ToString("N0");

                            _SanLuong_Tong_Ca1 += nvSL_thuong.SlTong;
                            _ThanhTien_Tong_Ca1 += (nvSL_thuong.ThanhTienThuong + nvSL_thuong.ThanhTienTang);
                            _Tong_Ca1 += (nvSL_thuong.PhuCapBaoHiem + tongtien);
                            _ThucNhan_Tong_Ca1 += (nvSL_thuong.PhuCapBaoHiem + tongtien - nvSL_thuong.TruBaoHiem);


                            if (nvSL_thuong.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                            else ravi_["BaoHiem"] = nvSL_thuong.TruBaoHiem.ToString("N0");

                            if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                            else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                            _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                            _BaoHiem_Tong_Ca1 += nvSL_thuong.TruBaoHiem;

                            _data.Rows.Add(ravi_);

                            //
                            if (nvSL_thuong.SlTang > 0)
                            {
                                DataRow ravi_tang = _data.NewRow();
                                ravi_tang["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_tang["STT"] = SttCa1;
                                ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_tang["HinhThuc"] = nvSL_thuong.TenVthhTang;

                                ravi_tang["NgayCong"] = "";

                                if (nvSL_thuong.SlTang == 0) ravi_tang["SanLuong"] = "";
                                else ravi_tang["SanLuong"] = nvSL_thuong.SlTang.ToString("N0");

                                if (nvSL_thuong.DonGiaTang == 0) ravi_tang["DonGia"] = "";
                                else ravi_tang["DonGia"] = nvSL_thuong.DonGiaTang.ToString("N2");

                                ravi_tang["ThanhTien"] = nvSL_thuong.ThanhTienTang.ToString("N0");

                                _data.Rows.Add(ravi_tang);
                            }
                        }

                        //Hàng nhũ
                        if (nvSL_nhu.SlTong > 0)
                        {
                            if(nvSL_thuong.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_nhu.TenVthhThuong;

                                if (nvSL_nhu.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_nhu.SoNgayCong.ToString("N0");

                                if (nvSL_nhu.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_nhu.SlThuong.ToString("N0");

                                if (nvSL_nhu.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_nhu.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_nhu.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_nhu.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_nhu.PhuCapBaoHiem + tongtien - nvSL_nhu.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_nhu.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);
                                _Tong_Ca1 += (nvSL_nhu.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca1 += (nvSL_nhu.PhuCapBaoHiem + tongtien - nvSL_nhu.TruBaoHiem);


                                if (nvSL_nhu.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_nhu.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca1 += nvSL_nhu.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_nhu.TenVthhThuong;

                                if (nvSL_nhu.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_nhu.SoNgayCong.ToString("N0");

                                if (nvSL_nhu.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_nhu.SlThuong.ToString("N0");

                                if (nvSL_nhu.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_nhu.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_nhu.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_nhu.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }


                        //Hàng trúc bách
                        if (nvSL_tb.SlTong > 0)
                        {
                            if (nvSL_nhu.SlTong == 0 && nvSL_thuong.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_tb.TenVthhThuong;

                                if (nvSL_tb.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_tb.SoNgayCong.ToString("N0");

                                if (nvSL_tb.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_tb.SlThuong.ToString("N0");

                                if (nvSL_tb.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_tb.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_tb.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_tb.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_tb.PhuCapBaoHiem + tongtien - nvSL_tb.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_tb.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);
                                _Tong_Ca1 += (nvSL_tb.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca1 += (nvSL_tb.PhuCapBaoHiem + tongtien - nvSL_tb.TruBaoHiem);


                                if (nvSL_tb.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_tb.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca1 += nvSL_tb.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_tb.TenVthhThuong;

                                if (nvSL_tb.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_tb.SoNgayCong.ToString("N0");

                                if (nvSL_tb.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_tb.SlThuong.ToString("N0");

                                if (nvSL_tb.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_tb.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_tb.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_tb.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }

                        //Hàng in mác
                        if (nvSL_mac.SlTong > 0)
                        {
                            if (nvSL_tb.SlTong == 0 && nvSL_thuong.SlTong == 0 && nvSL_nhu.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_mac.TenVthhThuong;

                                if (nvSL_mac.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_mac.SoNgayCong.ToString("N0");

                                if (nvSL_mac.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_mac.SlThuong.ToString("N0");

                                if (nvSL_mac.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_mac.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_mac.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_mac.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_mac.PhuCapBaoHiem + tongtien - nvSL_mac.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_mac.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);
                                _Tong_Ca1 += (nvSL_mac.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca1 += (nvSL_mac.PhuCapBaoHiem + tongtien - nvSL_mac.TruBaoHiem);


                                if (nvSL_mac.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_mac.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca1 += nvSL_mac.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca1.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_mac.TenVthhThuong;

                                if (nvSL_mac.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_mac.SoNgayCong.ToString("N0");

                                if (nvSL_mac.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_mac.SlThuong.ToString("N0");

                                if (nvSL_mac.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_mac.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_mac.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca1 += nvSL_mac.SlTong;
                                _ThanhTien_Tong_Ca1 += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }

                        //Học việc
                        if (nvHocViec.SoNgayCong > 0)
                        {
                            if (nvSL_tb.SlTong == 0 && nvSL_thuong.SlTong == 0 && nvSL_nhu.SlTong == 0 && nvHocViec.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = nvHocViec.HoTen;

                                ravi_["HinhThuc"] = nvHocViec.TenVthhThuong;

                                if (nvHocViec.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.SoNgayCong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvHocViec.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvHocViec.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvHocViec.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvHocViec.PhuCapBaoHiem + tongtien - nvHocViec.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca1 += nvHocViec.SoNgayCong;
                                _ThanhTien_Tong_Ca1 += (nvHocViec.ThanhTienThuong + nvHocViec.ThanhTienTang);
                                _Tong_Ca1 += (nvHocViec.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca1 += (nvHocViec.PhuCapBaoHiem + tongtien - nvHocViec.TruBaoHiem);


                                if (nvHocViec.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvHocViec.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca1 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca1 += nvHocViec.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = nvHocViec.HoTen;

                                ravi_["HinhThuc"] = nvHocViec.TenVthhThuong;

                                if (nvHocViec.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.SoNgayCong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvHocViec.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvHocViec.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca1 += nvHocViec.SoNgayCong;
                                _ThanhTien_Tong_Ca1 += (nvHocViec.ThanhTienThuong + nvHocViec.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }
                    }
                    else
                    {
                        
                    }
                }

                //Add thêm row tổng ca 1:
                DataRow _ravi = _data.NewRow();
                _ravi["ID_CongNhan"] = 0;
                _ravi["MaNhanVien"] = "";
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
                    _ravi["HinhThuc"] = _NgayCong_Tong_Ca1.ToString("N0");
                }

                //
                if (_SanLuong_Tong_Ca1 == 0)
                {
                    _ravi["SanLuong"] = "";
                }
                else
                {
                    _ravi["SanLuong"] = _SanLuong_Tong_Ca1.ToString("N0");
                }

                //
                if (_ThanhTien_Tong_Ca1 == 0)
                {
                    _ravi["ThanhTien"] = "";
                }
                else
                {
                    _ravi["ThanhTien"] = _ThanhTien_Tong_Ca1.ToString("N0");
                }

                //
                if (_XangXe_Tong_Ca1 == 0)
                {
                    _ravi["XangXe"] = "";
                }
                else
                {
                    _ravi["XangXe"] = _XangXe_Tong_Ca1.ToString("N0");
                }

                //
                if (_Tong_Ca1 == 0)
                {
                    _ravi["Tong"] = "";
                }
                else
                {
                    _ravi["Tong"] = _Tong_Ca1.ToString("N0");
                }

                //
                if (_BaoHiem_Tong_Ca1 == 0)
                {
                    _ravi["BaoHiem"] = "";
                }
                else
                {
                    _ravi["BaoHiem"] = _BaoHiem_Tong_Ca1.ToString("N0");
                }

                // 
                if (_ThucNhan_Tong_Ca1 == 0)
                {
                    _ravi["ThucNhan"] = "";
                }
                else
                {
                    _ravi["ThucNhan"] = _ThucNhan_Tong_Ca1.ToString("N0");
                }

                //_data.Rows.Add(_ravi);
                _data.Rows.InsertAt(_ravi, 0);
                _indexTongCa1 = _data.Rows.Count;


                //Ca 2:
                int SttCa2 = 0;
                ID_congNhanRoot = -1;
                //int ID_congNhanAddPCBH = Convert.ToInt32(_dtSL_Ca2.Rows[0]["ID_CongNhan"].ToString());

                for (int i = 0; i < _dtSL_Ca2.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_dtSL_Ca2.Rows[i]["ID_CongNhan"].ToString());
                    string MaNV_ = _dtSL_Ca2.Rows[i]["MaNhanVien"].ToString();
                    //
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ModelSanLuong nvSL_thuong = getNV_SanLuong(ID_congNhan, "thường", _dtSL_Ca2);
                        ModelSanLuong nvSL_nhu = getNV_SanLuong(ID_congNhan, "in nhũ", _dtSL_Ca2);
                        ModelSanLuong nvSL_mac = getNV_SanLuong(ID_congNhan, "in mác", _dtSL_Ca2);
                        ModelSanLuong nvSL_tb = getNV_SanLuong(ID_congNhan, "in trúc bách", _dtSL_Ca2);
                        ModelSanLuong nvHocViec = getNV_HocViec(ID_congNhan, _dtSL_Ca2);

                        tinhTongCN t = tongTien(nvSL_thuong, nvSL_nhu, nvSL_mac, nvSL_tb, nvHocViec);

                        ID_congNhanRoot = ID_congNhan;
                        SttCa2++;
                        if (nvSL_thuong.SlTong > 0)
                        {
                            DataRow ravi_ = _data.NewRow();
                            ravi_["ID_CongNhan"] = ID_congNhan;
                            ravi_["MaNhanVien"] = MaNV_;

                            ravi_["STT"] = SttCa2;
                            ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                            ravi_["HinhThuc"] = nvSL_thuong.TenVthhThuong;

                            if (nvSL_thuong.SoNgayCong == 0) ravi_["NgayCong"] = "";
                            else ravi_["NgayCong"] = nvSL_thuong.SoNgayCong.ToString("N0");

                            if (nvSL_thuong.SlThuong == 0) ravi_["SanLuong"] = "";
                            else ravi_["SanLuong"] = nvSL_thuong.SlThuong.ToString("N0");

                            if (nvSL_thuong.DonGiaThuong == 0) ravi_["DonGia"] = "";
                            else ravi_["DonGia"] = nvSL_thuong.DonGiaThuong.ToString("N2");

                            ravi_["ThanhTien"] = nvSL_thuong.ThanhTienThuong.ToString("N0");


                            double tongtien = t.TongTien;
                            ravi_["Tong"] = (nvSL_thuong.PhuCapBaoHiem + tongtien).ToString("N0");

                            ravi_["ThucNhan"] = (nvSL_thuong.PhuCapBaoHiem + tongtien - nvSL_thuong.TruBaoHiem).ToString("N0");

                            _SanLuong_Tong_Ca2 += nvSL_thuong.SlTong;
                            _ThanhTien_Tong_Ca2 += (nvSL_thuong.ThanhTienThuong + nvSL_thuong.ThanhTienTang);
                            _Tong_Ca2 += (nvSL_thuong.PhuCapBaoHiem + tongtien);
                            _ThucNhan_Tong_Ca2 += (nvSL_thuong.PhuCapBaoHiem + tongtien - nvSL_thuong.TruBaoHiem);


                            if (nvSL_thuong.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                            else ravi_["BaoHiem"] = nvSL_thuong.TruBaoHiem.ToString("N0");

                            if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                            else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                            _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                            _BaoHiem_Tong_Ca2 += nvSL_thuong.TruBaoHiem;

                            _data.Rows.Add(ravi_);

                            //
                            if (nvSL_thuong.SlTang > 0)
                            {
                                DataRow ravi_tang = _data.NewRow();
                                ravi_tang["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_tang["STT"] = SttCa2;
                                ravi_tang["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_tang["HinhThuc"] = nvSL_thuong.TenVthhTang;

                                ravi_tang["NgayCong"] = "";

                                if (nvSL_thuong.SlTang == 0) ravi_tang["SanLuong"] = "";
                                else ravi_tang["SanLuong"] = nvSL_thuong.SlTang.ToString("N0");

                                if (nvSL_thuong.DonGiaTang == 0) ravi_tang["DonGia"] = "";
                                else ravi_tang["DonGia"] = nvSL_thuong.DonGiaTang.ToString("N2");

                                ravi_tang["ThanhTien"] = nvSL_thuong.ThanhTienTang.ToString("N0");

                                _data.Rows.Add(ravi_tang);
                            }
                        }

                        //Hàng nhũ
                        if (nvSL_nhu.SlTong > 0)
                        {
                            if (nvSL_thuong.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_nhu.TenVthhThuong;

                                if (nvSL_nhu.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_nhu.SoNgayCong.ToString("N0");

                                if (nvSL_nhu.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_nhu.SlThuong.ToString("N0");

                                if (nvSL_nhu.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_nhu.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_nhu.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_nhu.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_nhu.PhuCapBaoHiem + tongtien - nvSL_nhu.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_nhu.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);
                                _Tong_Ca2 += (nvSL_nhu.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca2 += (nvSL_nhu.PhuCapBaoHiem + tongtien - nvSL_nhu.TruBaoHiem);


                                if (nvSL_nhu.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_nhu.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca2 += nvSL_nhu.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_nhu.TenVthhThuong;

                                if (nvSL_nhu.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_nhu.SoNgayCong.ToString("N0");

                                if (nvSL_nhu.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_nhu.SlThuong.ToString("N0");

                                if (nvSL_nhu.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_nhu.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_nhu.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_nhu.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }


                        //Hàng trúc bách
                        if (nvSL_tb.SlTong > 0)
                        {
                            if (nvSL_nhu.SlTong == 0 && nvSL_thuong.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_tb.TenVthhThuong;

                                if (nvSL_tb.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_tb.SoNgayCong.ToString("N0");

                                if (nvSL_tb.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_tb.SlThuong.ToString("N0");

                                if (nvSL_tb.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_tb.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_tb.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_tb.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_tb.PhuCapBaoHiem + tongtien - nvSL_tb.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_tb.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);
                                _Tong_Ca2 += (nvSL_tb.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca2 += (nvSL_tb.PhuCapBaoHiem + tongtien - nvSL_tb.TruBaoHiem);


                                if (nvSL_tb.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_tb.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca2 += nvSL_tb.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_tb.TenVthhThuong;

                                if (nvSL_tb.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_tb.SoNgayCong.ToString("N0");

                                if (nvSL_tb.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_tb.SlThuong.ToString("N0");

                                if (nvSL_tb.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_tb.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_tb.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_tb.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }

                        //Hàng in mác
                        if (nvSL_mac.SlTong > 0)
                        {
                            if (nvSL_tb.SlTong == 0 && nvSL_thuong.SlTong == 0 && nvSL_nhu.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_mac.TenVthhThuong;

                                if (nvSL_mac.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_mac.SoNgayCong.ToString("N0");

                                if (nvSL_mac.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_mac.SlThuong.ToString("N0");

                                if (nvSL_mac.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_mac.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_mac.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvSL_mac.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvSL_mac.PhuCapBaoHiem + tongtien - nvSL_mac.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_mac.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);
                                _Tong_Ca2 += (nvSL_mac.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca2 += (nvSL_mac.PhuCapBaoHiem + tongtien - nvSL_mac.TruBaoHiem);


                                if (nvSL_mac.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvSL_mac.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca2 += nvSL_mac.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = CheckString.ChuanHoaHoTen(_dtSL_Ca2.Rows[i]["TenNhanVien"].ToString());

                                ravi_["HinhThuc"] = nvSL_mac.TenVthhThuong;

                                if (nvSL_mac.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvSL_mac.SoNgayCong.ToString("N0");

                                if (nvSL_mac.SlThuong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvSL_mac.SlThuong.ToString("N0");

                                if (nvSL_mac.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvSL_mac.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvSL_mac.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca2 += nvSL_mac.SlTong;
                                _ThanhTien_Tong_Ca2 += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }

                        //Học việc
                        if (nvHocViec.SoNgayCong > 0)
                        {
                            if (nvSL_tb.SlTong == 0 && nvSL_thuong.SlTong == 0 && nvSL_nhu.SlTong == 0 && nvHocViec.SlTong == 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = nvHocViec.HoTen;

                                ravi_["HinhThuc"] = nvHocViec.TenVthhThuong;

                                if (nvHocViec.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.SoNgayCong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvHocViec.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvHocViec.ThanhTienThuong.ToString("N0");


                                double tongtien = t.TongTien;
                                ravi_["Tong"] = (nvHocViec.PhuCapBaoHiem + tongtien).ToString("N0");

                                ravi_["ThucNhan"] = (nvHocViec.PhuCapBaoHiem + tongtien - nvHocViec.TruBaoHiem).ToString("N0");

                                _SanLuong_Tong_Ca2 += nvHocViec.SoNgayCong;
                                _ThanhTien_Tong_Ca2 += (nvHocViec.ThanhTienThuong + nvHocViec.ThanhTienTang);
                                _Tong_Ca2 += (nvHocViec.PhuCapBaoHiem + tongtien);
                                _ThucNhan_Tong_Ca2 += (nvHocViec.PhuCapBaoHiem + tongtien - nvHocViec.TruBaoHiem);


                                if (nvHocViec.TruBaoHiem == 0) ravi_["BaoHiem"] = "";
                                else ravi_["BaoHiem"] = nvHocViec.TruBaoHiem.ToString("N0");

                                if (t.PhuCapBaoHiem == 0) ravi_["PhuCapBaoHiem"] = "";
                                else ravi_["PhuCapBaoHiem"] = t.PhuCapBaoHiem.ToString("N0");

                                _PCBaoHiem_Tong_Ca2 += t.PhuCapBaoHiem;

                                _BaoHiem_Tong_Ca2 += nvHocViec.TruBaoHiem;

                                _data.Rows.Add(ravi_);
                            }
                            else
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["MaNhanVien"] = MaNV_;
                                //STT
                                ravi_["STT"] = SttCa2;
                                ravi_["TenNhanVien"] = nvHocViec.HoTen;

                                ravi_["HinhThuc"] = nvHocViec.TenVthhThuong;

                                if (nvHocViec.SoNgayCong == 0) ravi_["NgayCong"] = "";
                                else ravi_["NgayCong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.SoNgayCong == 0) ravi_["SanLuong"] = "";
                                else ravi_["SanLuong"] = nvHocViec.SoNgayCong.ToString("N0");

                                if (nvHocViec.DonGiaThuong == 0) ravi_["DonGia"] = "";
                                else ravi_["DonGia"] = nvHocViec.DonGiaThuong.ToString("N2");

                                ravi_["ThanhTien"] = nvHocViec.ThanhTienThuong.ToString("N0");

                                _SanLuong_Tong_Ca2 += nvHocViec.SoNgayCong;
                                _ThanhTien_Tong_Ca2 += (nvHocViec.ThanhTienThuong + nvHocViec.ThanhTienTang);

                                _data.Rows.Add(ravi_);
                            }
                        }
                    }
                    else
                    {

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
                    _ravi_ca2["HinhThuc"] = _NgayCong_Tong_Ca2.ToString("N0");
                }

                //
                if (_SanLuong_Tong_Ca2 == 0)
                {
                    _ravi_ca2["SanLuong"] = "";
                }
                else
                {
                    _ravi_ca2["SanLuong"] = _SanLuong_Tong_Ca2.ToString("N0");
                }

                //
                if (_ThanhTien_Tong_Ca2 == 0)
                {
                    _ravi_ca2["ThanhTien"] = "";
                }
                else
                {
                    _ravi_ca2["ThanhTien"] = _ThanhTien_Tong_Ca2.ToString("N0");
                }

                //
                if (_XangXe_Tong_Ca2 == 0)
                {
                    _ravi_ca2["XangXe"] = "";
                }
                else
                {
                    _ravi_ca2["XangXe"] = _XangXe_Tong_Ca2.ToString("N0");
                }

                //
                if (_Tong_Ca2 == 0)
                {
                    _ravi_ca2["Tong"] = "";
                }
                else
                {
                    _ravi_ca2["Tong"] = _Tong_Ca2.ToString("N0");
                }

                //
                if (_BaoHiem_Tong_Ca2 == 0)
                {
                    _ravi_ca2["BaoHiem"] = "";
                }
                else
                {
                    _ravi_ca2["BaoHiem"] = _BaoHiem_Tong_Ca2.ToString("N0");
                }

                // 
                if (_ThucNhan_Tong_Ca2 == 0)
                {
                    _ravi_ca2["ThucNhan"] = "";
                }
                else
                {
                    _ravi_ca2["ThucNhan"] = _ThucNhan_Tong_Ca2.ToString("N0");
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
                    _ravi_2ca["HinhThuc"] = (_NgayCong_Tong_Ca2 + _NgayCong_Tong_Ca1).ToString("N0");
                }

                //
                if (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1 == 0)
                {
                    _ravi_2ca["SanLuong"] = "";
                }
                else
                {
                    _ravi_2ca["SanLuong"] = (_SanLuong_Tong_Ca2 + _SanLuong_Tong_Ca1).ToString("N0");
                }

                //
                if (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1 == 0)
                {
                    _ravi_2ca["ThanhTien"] = "";
                }
                else
                {
                    _ravi_2ca["ThanhTien"] = (_ThanhTien_Tong_Ca2 + _ThanhTien_Tong_Ca1).ToString("N0");
                }

                //
                if (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1 == 0)
                {
                    _ravi_2ca["XangXe"] = "";
                }
                else
                {
                    _ravi_2ca["XangXe"] = (_XangXe_Tong_Ca2 + _XangXe_Tong_Ca1).ToString("N0");
                }

                //
                if (_Tong_Ca2 + _Tong_Ca1 == 0)
                {
                    _ravi_2ca["Tong"] = "";
                }
                else
                {
                    _ravi_2ca["Tong"] = (_Tong_Ca2 + _Tong_Ca1).ToString("N0");
                }

                //
                if (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1 == 0)
                {
                    _ravi_2ca["BaoHiem"] = "";
                }
                else
                {
                    _ravi_2ca["BaoHiem"] = (_BaoHiem_Tong_Ca2 + _BaoHiem_Tong_Ca1).ToString("N0");
                }

                // 
                if (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1 == 0)
                {
                    _ravi_2ca["ThucNhan"] = "";
                }
                else
                {
                    _ravi_2ca["ThucNhan"] = (_ThucNhan_Tong_Ca2 + _ThucNhan_Tong_Ca1).ToString("N0");
                }

                _data.Rows.Add(_ravi_2ca);

                gridControl1.DataSource = _data;
                //  
                isload = false;
            }
        }

        //Tính tổng sản lượng một công nhân:
        private ModelSanLuong getNV_SanLuong(int idcn, string loaiVthh, DataTable dt)
        {
            ModelSanLuong nv = new ModelSanLuong();
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
            double PCBH_tmp = 0;
            double truBaoHiem = 0;

            List<int> dsNgayCong = new List<int>();

            foreach (DataRow item in dt.Rows)
            {
                string loaiHH = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
                string HocViec = (CheckString.ChuanHoaHoTen(item["HV_DienGiai"].ToString())).ToLower();
                switch (loaiVthh)
                {
                    case "thường":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (!loaiHH.Contains("in mác") && !loaiHH.Contains("in trúc bách") && !loaiHH.Contains("in nhũ") 
                                    && !HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                                {
                                    hoTen = item["TenNhanVien"].ToString();
                                    slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                                    PCBH_tmp = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in nhũ":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in nhũ") && !HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                                {
                                    hoTen = item["TenNhanVien"].ToString();
                                    slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                                    PCBH_tmp = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in mác":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in mác") && !HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                                {
                                    hoTen = item["TenNhanVien"].ToString();
                                    slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                                    PCBH_tmp = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in trúc bách":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in trúc bách") && !HocViec.Contains("học việc") && !HocViec.Contains("thử việc"))
                                {
                                    hoTen = item["TenNhanVien"].ToString();
                                    slTong += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                                    PCBH_tmp = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            soNgayCong = dsNgayCong.Count;

            if (loaiVthh.Contains("in mác"))
            {
                slThuong = slTong;
                tenVthhThuong = "Sản lượng máy in mác";
                tenVthhTang = "";
            }
            else if (loaiVthh.Contains("in trúc bách"))
            {
                slThuong = slTong;
                tenVthhThuong = "Sản lượng máy in TB";
                tenVthhTang = "";
            }
            else if (loaiVthh.Contains("in nhũ"))
            {
                slThuong = slTong;

                phuCapBaoHiem = slTong * 900000 / 910;

                tenVthhThuong = "Sản lượng giấy cuộn nhũ";
                tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
            }
            else
            {
                if ((slTong - (soNgayCong * 40)) > 0)
                {
                    slThuong = soNgayCong * 40;
                    slTang = slTong - (soNgayCong * 40);
                }
                else slThuong = slTong;

                phuCapBaoHiem = slTong * 900000 / 1040;

                tenVthhThuong = "Sản lượng giấy cuộn";
                tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
            }

            //Những người không đóng bảo hiểm sẽ tính cộng bảo hiểm (khi chọn giá trị cộng bh trong bảng DML > 0)
            //những người chạy máy in mác, trúc bách thì không tính cộng bảo hiểm
            //công nhân chạy máy in mác, trúc bách họ không được cộng bảo hiểm vì bảo hiểm tính vào đơn giá rồi
            //những người đóng bảo hiểm thì công ty đã chi hơn triệu nộp lên cơ quan bảo hiểm rồi nên không được cộng BH
            if (truBaoHiem > 0 || PCBH_tmp == 0)
            {
                phuCapBaoHiem = 0;
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
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
        }

        private ModelSanLuong getNV_HocViec(int idcn, DataTable dt)
        {
            ModelSanLuong nv = new ModelSanLuong();
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
            double PCBH_tmp = 0;
            double truBaoHiem = 0;
            double HV_DonGiaCongNhat_Thuong = 0;
            double HV_DonGiaCongNhat_Tang = 0;


            List<int> dsNgayCong = new List<int>();

            foreach (DataRow item in dt.Rows)
            {
                string loaiHH = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
                string HocViec = (CheckString.ChuanHoaHoTen(item["HV_DienGiai"].ToString())).ToLower();

                if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                {
                    hoTen = item["TenNhanVien"].ToString();
                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;
                    PCBH_tmp = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());

                    if (HocViec.Contains("học việc") || HocViec.Contains("thử việc"))
                    {
                        HV_DonGiaCongNhat_Thuong = CheckString.ConvertToDouble_My(item["HV_DonGiaCongNhat_Thuong"].ToString());
                        HV_DonGiaCongNhat_Tang = CheckString.ConvertToDouble_My(item["HV_DonGiaCongNhat_Tang"].ToString());

                        if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
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

            //Những người không đóng bảo hiểm sẽ tính cộng bảo hiểm (khi chọn giá trị cộng bh trong bảng DML > 0)
            //những người chạy máy in mác, trúc bách thì không tính cộng bảo hiểm
            //công nhân chạy máy in mác, trúc bách họ không được cộng bảo hiểm vì bảo hiểm tính vào đơn giá rồi
            //những người đóng bảo hiểm thì công ty đã chi hơn triệu nộp lên cơ quan bảo hiểm rồi nên không được cộng BH
            if (truBaoHiem > 0 || PCBH_tmp == 0)
            {
                phuCapBaoHiem = 0;
            }

            nv.HoTen = hoTen;
            nv.TenVthhThuong = tenVthhThuong;
            nv.TenVthhTang = tenVthhTang;
            nv.SlTong = slTong;
            nv.SlThuong = slThuong;
            nv.SlTang = slTang;
            nv.DonGiaThuong = HV_DonGiaCongNhat_Thuong;
            nv.DonGiaTang = HV_DonGiaCongNhat_Tang;
            nv.SoNgayCong = soNgayCong;
            nv.ThanhTienThuong = HV_DonGiaCongNhat_Thuong * soNgayCong;
            nv.ThanhTienTang = 0;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
        }

        private tinhTongCN tongTien(ModelSanLuong nvSL_thuong, ModelSanLuong nvSL_nhu, ModelSanLuong nvSL_mac, ModelSanLuong nvSL_tb, ModelSanLuong nvHocViec)
        {
            tinhTongCN t = new tinhTongCN();
            double result = 0;
            double PhuCapBH = 0;

            result += (nvSL_thuong.ThanhTienThuong + nvSL_thuong.ThanhTienTang);
            result += (nvSL_nhu.ThanhTienThuong + nvSL_nhu.ThanhTienTang);
            result += (nvSL_mac.ThanhTienThuong + nvSL_mac.ThanhTienTang);
            result += (nvSL_tb.ThanhTienThuong + nvSL_tb.ThanhTienTang);
            result += (nvHocViec.ThanhTienThuong + nvHocViec.ThanhTienTang);

            PhuCapBH += nvSL_thuong.PhuCapBaoHiem;
            PhuCapBH += nvSL_nhu.PhuCapBaoHiem;

            if (nvSL_mac.SlTong > 0 || nvSL_tb.SlTong > 0)
            {
                PhuCapBH = 0;
            }
            else
            {
                if (PhuCapBH >= 900000) PhuCapBH = 900000;
            }

            t.TongTien = result;
            t.PhuCapBaoHiem = PhuCapBH;

            return t;
        }


        private void frmBTTL_ToIn_Load(object sender, EventArgs e)
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_CongNhan).ToString());
                _MaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();

                if (_MaNhanVien != "")
                {
                    Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "frmBTTL_ToIn", this);
                    ff.Show();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "frmBTTL_ToIn", this);
            ff.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_ToIn_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_ToIn_CT(_thang, _nam, _data);
            ff.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.RowHandle == _data.Rows.Count - 1 || e.RowHandle == _data.Rows.Count - 2 || e.RowHandle == _indexTongCa1)
            //{
            //    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //}
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_ToIn_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_ToIn_TQ(_thang, _nam, _data);
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

    public class tinhTongCN
    {
        public double TongTien { get; set; }
        public double PhuCapBaoHiem { get; set; }
        public double TongSL_All { get; set; }

    }
}


