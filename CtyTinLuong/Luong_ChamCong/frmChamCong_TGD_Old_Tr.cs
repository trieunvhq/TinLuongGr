

using CtyTinLuong.Model;
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
    public partial class frmChamCong_TGD_Old_Tr : UserControl
    {
        public int  _ID_DinhMucLuong_CongNhat = 0;
        private string _MaDinhMucLuongCongNhat;
        public int _nam, _thang, _id_bophan = 25;
        private DataTable _data, _dt_DinhMuc, _dt_LoaiHang;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmChamCong_TGD_Old_Tr(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC = null)
        {
            _frmQLLCC = frmQLLCC;
            _ID_DinhMucLuong_CongNhat = 0;
            _MaDinhMucLuongCongNhat = "";
            _id_bophan = id_bophan;
            InitializeComponent();

            MaDinhMucLuongCongNhat.Caption = "Đ.MỨC\nLƯƠNG";

            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);

            this.cbNhanSu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNhanSu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void Load_DinhMuc(int id_dinhmuc,string ma,int id_congnhan)
        {
            _ID_DinhMucLuong_CongNhat = id_dinhmuc;
            _MaDinhMucLuongCongNhat = ma;
            if (id_congnhan>0)
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    if(Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString())==id_congnhan)
                    {
                        _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                        _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                        if (i > 0)
                        {
                            int j = i - 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                --j;
                                if (j < 0)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            }
                        }
                        if (i < _data.Rows.Count - 1)
                        {
                            int j = i + 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                ++j;
                                if (j >= _data.Rows.Count - 1)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            }
                        }
                        break;
                    }
                    else
                    { }
                }
            }
            else
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                    _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                }
            }
            gridControl1.DataSource = _data;
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

        double Tong_Ngay1 = 0;
        double Tong_Ngay2 = 0;
        double Tong_Ngay3 = 0;
        double Tong_Ngay4 = 0;
        double Tong_Ngay5 = 0;
        double Tong_Ngay6 = 0;
        double Tong_Ngay7 = 0;
        double Tong_Ngay8 = 0;
        double Tong_Ngay9 = 0;
        double Tong_Ngay10 = 0;
        double Tong_Ngay11 = 0;
        double Tong_Ngay12 = 0;
        double Tong_Ngay13 = 0;
        double Tong_Ngay14 = 0;
        double Tong_Ngay15 = 0;
        double Tong_Ngay16 = 0;
        double Tong_Ngay17 = 0;
        double Tong_Ngay18 = 0;
        double Tong_Ngay19 = 0;
        double Tong_Ngay20 = 0;
        double Tong_Ngay21 = 0;
        double Tong_Ngay22 = 0;
        double Tong_Ngay23 = 0;
        double Tong_Ngay24 = 0;
        double Tong_Ngay25 = 0;
        double Tong_Ngay26 = 0;
        double Tong_Ngay27 = 0;
        double Tong_Ngay28 = 0;
        double Tong_Ngay29 = 0;
        double Tong_Ngay30 = 0;
        double Tong_Ngay31 = 0;


        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            { 
                DateTime dtnow = DateTime.Now;
                _nam = DateTime.Now.Year;
                _thang = DateTime.Now.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
                DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
                int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;
                if (ngaycuathang_ == 28)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = false;
                }
                else if (ngaycuathang_ == 29)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 30)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 31)
                {
                    Ngay31.Visible = true;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                string thu_ = LayThu(date_);
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    ds_grid[i].Caption = (i + 1) + "\n" + LayThu(new DateTime(dtnow.Year, dtnow.Month, (i + 1)));
                    if (ds_grid[i].Caption.Contains("CN"))
                    {
                        ds_grid[i].AppearanceCell.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.ForeColor = Color.Red;
                        ds_grid[i].AppearanceCell.ForeColor = Color.Red;
                    }
                }

            }
            else
            {
            }
            using (clsThin clsThin_ = new clsThin())
            {
                _dt_DinhMuc = clsThin_.Tr_NhanSu_TGD("0");
                cbNhanSu.DataSource = _dt_DinhMuc;
                cbNhanSu.DisplayMember = "TenNhanVien";
                cbNhanSu.ValueMember = "ID_NhanSu";

                //Xóa các loại công không có trong gấp dán từ db:
                _dt_LoaiHang = clsThin_.T_LoaiCong_SA();
                for (int i = _dt_LoaiHang.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = _dt_LoaiHang.Rows[i];
                    if (dr["Ten"].ToString().ToLower().Contains("công nhật")
                        || dr["Ten"].ToString().ToLower().Contains("tăng ca")
                        || dr["Ten"].ToString().ToLower().Contains("sản lượng")
                        || dr["Ten"].ToString().ToLower().Contains("công thiếu tháng trước")
                        || dr["Ten"].ToString().ToLower().Contains("công 7 giờ")
                        || dr["Ten"].ToString().ToLower().Contains("công phụ máy")) 
                        dr.Delete();
                }
                _dt_LoaiHang.AcceptChanges();
                cbLoaiCong.DataSource = _dt_LoaiHang;
                cbLoaiCong.DisplayMember = "Ten";
                cbLoaiCong.ValueMember = "ID_LoaiCong";
            }

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(0, _nam, _thang, _id_bophan, 0, "");
                ds_id_congnhan = new List<int>();

                double Ngay1 = 0;
                double Ngay2 = 0;
                double Ngay3 = 0;
                double Ngay4 = 0;
                double Ngay5 = 0;
                double Ngay6 = 0;
                double Ngay7 = 0;
                double Ngay8 = 0;
                double Ngay9 = 0;
                double Ngay10 = 0;
                double Ngay11 = 0;
                double Ngay12 = 0;
                double Ngay13 = 0;
                double Ngay14 = 0;
                double Ngay15 = 0;
                double Ngay16 = 0;
                double Ngay17 = 0;
                double Ngay18 = 0;
                double Ngay19 = 0;
                double Ngay20 = 0;
                double Ngay21 = 0;
                double Ngay22 = 0;
                double Ngay23 = 0;
                double Ngay24 = 0;
                double Ngay25 = 0;
                double Ngay26 = 0;
                double Ngay27 = 0;
                double Ngay28 = 0;
                double Ngay29 = 0;
                double Ngay30 = 0;
                double Ngay31 = 0;

                //
                int ID_congNhanRoot = -1;
                int stt_tmp = 0;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                    ds_id_congnhan.Add(ID_congNhan);    // Add(Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()));

                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ID_congNhanRoot = ID_congNhan;
                        stt_tmp++;
                        _data.Rows[i]["STT"] = stt_tmp;
                    }
                    else
                    {
                        _data.Rows[i]["STT"] = stt_tmp;
                    }


                    Ngay1 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString());
                    Ngay2 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString());
                    Ngay3 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString());
                    Ngay4 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString());
                    Ngay5 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString());
                    Ngay6 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString());
                    Ngay7 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString());
                    Ngay8 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString());
                    Ngay9 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString());
                    Ngay10 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString());
                    Ngay11 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString());
                    Ngay12 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString());
                    Ngay13 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString());
                    Ngay14 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString());
                    Ngay15 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString());
                    Ngay16 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString());
                    Ngay17 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString());
                    Ngay18 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString());
                    Ngay19 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString());
                    Ngay20 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString());
                    Ngay21 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString());
                    Ngay22 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString());
                    Ngay23 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString());
                    Ngay24 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString());
                    Ngay25 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString());
                    Ngay26 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString());
                    Ngay27 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString());
                    Ngay28 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString());
                    Ngay29 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString());
                    Ngay30 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString());
                    Ngay31 = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString());
                    //
                    _data.Rows[i]["Ngay1"] = String.Format("{0:0.##}", Ngay1);
                    _data.Rows[i]["Ngay2"] = String.Format("{0:0.##}", Ngay2);
                    _data.Rows[i]["Ngay3"] = String.Format("{0:0.##}", Ngay3);
                    _data.Rows[i]["Ngay4"] = String.Format("{0:0.##}", Ngay4);
                    _data.Rows[i]["Ngay5"] = String.Format("{0:0.##}", Ngay5);
                    _data.Rows[i]["Ngay6"] = String.Format("{0:0.##}", Ngay6);
                    _data.Rows[i]["Ngay7"] = String.Format("{0:0.##}", Ngay7);
                    _data.Rows[i]["Ngay8"] = String.Format("{0:0.##}", Ngay8);
                    _data.Rows[i]["Ngay9"] = String.Format("{0:0.##}", Ngay9);
                    _data.Rows[i]["Ngay10"] = String.Format("{0:0.##}", Ngay10);
                    _data.Rows[i]["Ngay11"] = String.Format("{0:0.##}", Ngay11);
                    _data.Rows[i]["Ngay12"] = String.Format("{0:0.##}", Ngay12);
                    _data.Rows[i]["Ngay13"] = String.Format("{0:0.##}", Ngay13);
                    _data.Rows[i]["Ngay14"] = String.Format("{0:0.##}", Ngay14);
                    _data.Rows[i]["Ngay15"] = String.Format("{0:0.##}", Ngay15);
                    _data.Rows[i]["Ngay16"] = String.Format("{0:0.##}", Ngay16);
                    _data.Rows[i]["Ngay17"] = String.Format("{0:0.##}", Ngay17);
                    _data.Rows[i]["Ngay18"] = String.Format("{0:0.##}", Ngay18);
                    _data.Rows[i]["Ngay19"] = String.Format("{0:0.##}", Ngay19);
                    _data.Rows[i]["Ngay20"] = String.Format("{0:0.##}", Ngay20);
                    _data.Rows[i]["Ngay21"] = String.Format("{0:0.##}", Ngay21);
                    _data.Rows[i]["Ngay22"] = String.Format("{0:0.##}", Ngay22);
                    _data.Rows[i]["Ngay23"] = String.Format("{0:0.##}", Ngay23);
                    _data.Rows[i]["Ngay24"] = String.Format("{0:0.##}", Ngay24);
                    _data.Rows[i]["Ngay25"] = String.Format("{0:0.##}", Ngay25);
                    _data.Rows[i]["Ngay26"] = String.Format("{0:0.##}", Ngay26);
                    _data.Rows[i]["Ngay27"] = String.Format("{0:0.##}", Ngay27);
                    _data.Rows[i]["Ngay28"] = String.Format("{0:0.##}", Ngay28);
                    _data.Rows[i]["Ngay29"] = String.Format("{0:0.##}", Ngay29);
                    _data.Rows[i]["Ngay30"] = String.Format("{0:0.##}", Ngay30);
                    _data.Rows[i]["Ngay31"] = String.Format("{0:0.##}", Ngay31);

                    Tong_Ngay1 += Ngay1;
                    Tong_Ngay2 += Ngay2;
                    Tong_Ngay3 += Ngay3;
                    Tong_Ngay4 += Ngay4;
                    Tong_Ngay5 += Ngay5;
                    Tong_Ngay6 += Ngay6;
                    Tong_Ngay7 += Ngay7;
                    Tong_Ngay8 += Ngay8;
                    Tong_Ngay9 += Ngay9;
                    Tong_Ngay10 += Ngay10;
                    Tong_Ngay11 += Ngay11;
                    Tong_Ngay12 += Ngay12;
                    Tong_Ngay13 += Ngay13;
                    Tong_Ngay14 += Ngay14;
                    Tong_Ngay15 += Ngay15;
                    Tong_Ngay16 += Ngay16;
                    Tong_Ngay17 += Ngay17;
                    Tong_Ngay18 += Ngay18;
                    Tong_Ngay19 += Ngay19;
                    Tong_Ngay20 += Ngay20;
                    Tong_Ngay21 += Ngay21;
                    Tong_Ngay22 += Ngay22;
                    Tong_Ngay23 += Ngay23;
                    Tong_Ngay24 += Ngay24;
                    Tong_Ngay25 += Ngay25;
                    Tong_Ngay26 += Ngay26;
                    Tong_Ngay27 += Ngay27;
                    Tong_Ngay28 += Ngay28;
                    Tong_Ngay29 += Ngay29;
                    Tong_Ngay30 += Ngay30;
                    Tong_Ngay31 += Ngay31;
                    
                }
            }
            LoadCongNhanVaoBang(_id_bophan);

            isload = false;
        }
        private List<int> ds_id_congnhan = new List<int>();
        private void LoadCongNhanVaoBang(int id_bophan)
        {
            int stt_ = 0;
            if (_data != null && _data.Rows.Count > 0)
            {
                //int ID_congNhanRoot = -1;
                //int stt_tmp = 0;
                //for (int i = 0; i < _data.Rows.Count; ++i)
                //{
                //    int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                //    if (ID_congNhanRoot != ID_congNhan)
                //    {
                //        //
                //        ID_congNhanRoot = ID_congNhan;
                //        stt_tmp++;
                //        _data.Rows[i]["STT"] = stt_tmp;
                //    }
                //    else
                //    {
                //        _data.Rows[i]["STT"] = stt_tmp;
                //    }

                //}

                //Lấy số thứ tự hiện tại
                stt_ = Convert.ToInt32(_data.Rows[_data.Rows.Count - 1]["STT"].ToString());
            }

            //
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.Tr_NhanSu_TGD(_id_bophan + ",");

                for (int i = 0; i < dt_.Rows.Count; ++i)
                {
                    if (_ID_DinhMucLuong_CongNhat == 0)
                    {
                        _ID_DinhMucLuong_CongNhat = Convert.ToInt32(dt_.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                        _MaDinhMucLuongCongNhat = dt_.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                    }
                    //
                    int id_nhansu_ = Convert.ToInt32(dt_.Rows[i]["ID_NhanSu"].ToString());
                    if (ds_id_congnhan.Contains(id_nhansu_))
                    {

                    }
                    else
                    {
                        ++stt_;
                        for (int j = 0; j < _dt_LoaiHang.Rows.Count; j++)
                        {
                            DataRow _ravi = _data.NewRow();
                            _ravi["STT"] = (stt_);
                            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
                            _ravi["ID_CongNhan"] = id_nhansu_;
                            _ravi["Thang"] = _thang;
                            _ravi["Nam"] = _nam;
                            _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0; _ravi["Ngay3"] = 0;
                            _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
                            _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
                            _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0;
                            _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
                            _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
                            _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
                            _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
                            _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
                            _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
                            _ravi["Ngay30"] = 0; _ravi["Ngay31"] = 0;

                            _ravi["SanLuong"] = 0;
                            _ravi["Tong"] = 0;
                            _ravi["GuiDuLieu"] = false;
                            _ravi["MaNhanVien"] = dt_.Rows[i]["MaNhanVien"].ToString();
                            _ravi["TenNhanVien"] = dt_.Rows[i]["TenNhanVien"].ToString();

                            _ravi["MaDinhMuc"] = "";
                            _ravi["DinhMuc_KhongTang"] = 0;
                            _ravi["DinhMuc_Tang"] = 0;
                            _ravi["ID_LoaiCong"] = 0;

                            _ravi["Cong"] = _dt_LoaiHang.Rows[j]["Ten"].ToString();
                            _ravi["ID_LoaiCong"] = _dt_LoaiHang.Rows[j]["ID_LoaiCong"].ToString();
                            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                            _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;
                            _data.Rows.Add(_ravi);
                        }
                    }
                }
            }
            //for(int i=0; i<_dataLoaiHang.Rows.Count; i++)
            //{
            //    comboThin.Items.Add(_dataLoaiHang.Rows[i]["TenVTHH"].ToString());
            //}
            gridThin.EditValueChanged += (o, e) => {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenNhanVien"] = "Tổng";
            _ravi2["Ngay1"] = String.Format("{0:0.##}", Tong_Ngay1);
            _ravi2["Ngay2"] = String.Format("{0:0.##}", Tong_Ngay2);
            _ravi2["Ngay3"] = String.Format("{0:0.##}", Tong_Ngay3);
            _ravi2["Ngay4"] = String.Format("{0:0.##}", Tong_Ngay4);
            _ravi2["Ngay5"] = String.Format("{0:0.##}", Tong_Ngay5);
            _ravi2["Ngay6"] = String.Format("{0:0.##}", Tong_Ngay6);
            _ravi2["Ngay7"] = String.Format("{0:0.##}", Tong_Ngay7);
            _ravi2["Ngay8"] = String.Format("{0:0.##}", Tong_Ngay8);
            _ravi2["Ngay9"] = String.Format("{0:0.##}", Tong_Ngay9);
            _ravi2["Ngay10"] = String.Format("{0:0.##}", Tong_Ngay10);
            _ravi2["Ngay11"] = String.Format("{0:0.##}", Tong_Ngay11);
            _ravi2["Ngay12"] = String.Format("{0:0.##}", Tong_Ngay12);
            _ravi2["Ngay13"] = String.Format("{0:0.##}", Tong_Ngay13);
            _ravi2["Ngay14"] = String.Format("{0:0.##}", Tong_Ngay14);
            _ravi2["Ngay15"] = String.Format("{0:0.##}", Tong_Ngay15);
            _ravi2["Ngay16"] = String.Format("{0:0.##}", Tong_Ngay16);
            _ravi2["Ngay17"] = String.Format("{0:0.##}", Tong_Ngay17);
            _ravi2["Ngay18"] = String.Format("{0:0.##}", Tong_Ngay18);
            _ravi2["Ngay19"] = String.Format("{0:0.##}", Tong_Ngay19);
            _ravi2["Ngay20"] = String.Format("{0:0.##}", Tong_Ngay20);
            _ravi2["Ngay21"] = String.Format("{0:0.##}", Tong_Ngay21);
            _ravi2["Ngay22"] = String.Format("{0:0.##}", Tong_Ngay22);
            _ravi2["Ngay23"] = String.Format("{0:0.##}", Tong_Ngay23);
            _ravi2["Ngay24"] = String.Format("{0:0.##}", Tong_Ngay24);
            _ravi2["Ngay25"] = String.Format("{0:0.##}", Tong_Ngay25);
            _ravi2["Ngay26"] = String.Format("{0:0.##}", Tong_Ngay26);
            _ravi2["Ngay27"] = String.Format("{0:0.##}", Tong_Ngay27);
            _ravi2["Ngay28"] = String.Format("{0:0.##}", Tong_Ngay28);
            _ravi2["Ngay29"] = String.Format("{0:0.##}", Tong_Ngay29);
            _ravi2["Ngay30"] = String.Format("{0:0.##}", Tong_Ngay30);
            _ravi2["Ngay31"] = String.Format("{0:0.##}", Tong_Ngay31);


            _ravi2["Tong"] = String.Format("{0:0.##}", (Tong_Ngay1 + Tong_Ngay2 + Tong_Ngay3 + Tong_Ngay4 + Tong_Ngay5
                + Tong_Ngay6 + Tong_Ngay7 + Tong_Ngay8 + Tong_Ngay9 + Tong_Ngay10
                + Tong_Ngay11 + Tong_Ngay12 + Tong_Ngay13 + Tong_Ngay14 + Tong_Ngay15
                + Tong_Ngay16 + Tong_Ngay17 + Tong_Ngay18 + Tong_Ngay19 + Tong_Ngay20
                + Tong_Ngay21 + Tong_Ngay22 + Tong_Ngay23 + Tong_Ngay24 + Tong_Ngay25
                + Tong_Ngay26 + Tong_Ngay27 + Tong_Ngay28 + Tong_Ngay29 + Tong_Ngay30 + Tong_Ngay31));

            _data.Rows.Add(_ravi2);
            //
            gridControl1.DataSource = _data;
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
        private void frmChamCong_TGD_Old_Tr_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index_ = e.RowHandle;
            string name_ = e.Column.FieldName;
            if (name_.Contains("Ngay"))
            {
                _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);

                _data.Rows[index_][name_] = String.Format("{0:0.##}", CheckString.ConvertToDouble_My(_data.Rows[index_][name_].ToString()));
                if (_data.Rows.Count > index_)
                {
                    //double temp_ = CheckString.ConvertToDouble_My(_data.Rows[index_][name_].ToString());
                    //_data.Rows[index_]["Tong"] = temp_ + CheckString.ConvertToDouble_My(_data.Rows[index_]["Tong"].ToString());
                    CongTong_Row(index_);
                }
                //SendKeys.Send("{DOWN}");

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
            CongTong();
            // gridView1.SetRowCellValue(e.RowHandle, clSLThuong, tongcong); 
        }

        //CongTong_Row(index_);
        private void CongTong_Row(int index)
        {
            double tong_row = 0;

            for (int j = 0; j < 31; ++j)
            {
                tong_row += CheckString.ConvertToDouble_My(_data.Rows[index]["Ngay" + (j + 1)].ToString());
            }

            _data.Rows[index]["Tong"] = String.Format("{0:0.##}", tong_row);
        }

        private void CongTong()
        {
            double[] _ds_ngay_tong_ = new double[31];
            double tong_tong_ = 0;
            for (int i = 0; i < _data.Rows.Count - 1; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    _ds_ngay_tong_[j] += CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay" + (j + 1)].ToString());
                }
                tong_tong_ += CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString());
            }
            for (int j = 0; j < 31; ++j)
            {
                _data.Rows[_data.Rows.Count - 1]["Ngay" + (j + 1)] = String.Format("{0:0.##}", _ds_ngay_tong_[j]);
            }
            _data.Rows[_data.Rows.Count - 1]["Tong"] = String.Format("{0:0.##}", tong_tong_);
            gridControl1.DataSource = _data;
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
            GuiDuLieuBangLuong();
        }


        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            if ((int)cbNhanSu.SelectedValue == 0)
            {
            }
            else
            {
                int id_loaicong_ = (int)cbLoaiCong.SelectedValue;
               
                ThemMotCongNhanVaoBang((int)cbNhanSu.SelectedValue, cbNhanSu.Text, true, id_loaicong_,cbLoaiCong.Text);
            }
        }
        private void ThemMotCongNhanVaoBang(int id_nhansu_, string ten_, bool isNew,int id_loaicong_,string ten_loaicong_)
        {
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                if (id_nhansu_ == Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()))
                {
                    if(Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()) == id_loaicong_)
                    {
                        MessageBox.Show("Đã tồn tại công nhân trong bảng này!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (isNew && _data != null && _data.Rows.Count > 0)
            {
                _data.Rows.RemoveAt(_data.Rows.Count - 1);
            }
            else
            {

            }
            // 
            int pos_ = 0;
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                if (id_nhansu_ == Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()))
                {
                    pos_ = i;
                }
            }
            //
            DataRow _ravi = _data.NewRow();
            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi["ID_LoaiCong"] = id_loaicong_;
            _ravi["ID_CongNhan"] = id_nhansu_;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0; _ravi["Ngay3"] = 0;
            _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
            _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
            _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0;
            _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
            _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
            _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
            _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
            _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
            _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
            _ravi["Ngay30"] = 0; _ravi["Ngay31"] = 0;

            _ravi["Tong"] = 0;
            _ravi["GuiDuLieu"] = false;
            _ravi["MaNhanVien"] = "";
            _ravi["TenNhanVien"] = ten_;

            _ravi["Cong"] = ten_loaicong_;
            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;

            _data.Rows.InsertAt(_ravi, pos_);

            gridThin.EditValueChanged += (o, e) => {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenNhanVien"] = "Tổng";
            _ravi2["Ngay1"] = String.Format("{0:0.##}", Tong_Ngay1);
            _ravi2["Ngay2"] = String.Format("{0:0.##}", Tong_Ngay2);
            _ravi2["Ngay3"] = String.Format("{0:0.##}", Tong_Ngay3);
            _ravi2["Ngay4"] = String.Format("{0:0.##}", Tong_Ngay4);
            _ravi2["Ngay5"] = String.Format("{0:0.##}", Tong_Ngay5);
            _ravi2["Ngay6"] = String.Format("{0:0.##}", Tong_Ngay6);
            _ravi2["Ngay7"] = String.Format("{0:0.##}", Tong_Ngay7);
            _ravi2["Ngay8"] = String.Format("{0:0.##}", Tong_Ngay8);
            _ravi2["Ngay9"] = String.Format("{0:0.##}", Tong_Ngay9);
            _ravi2["Ngay10"] = String.Format("{0:0.##}", Tong_Ngay10);
            _ravi2["Ngay11"] = String.Format("{0:0.##}", Tong_Ngay11);
            _ravi2["Ngay12"] = String.Format("{0:0.##}", Tong_Ngay12);
            _ravi2["Ngay13"] = String.Format("{0:0.##}", Tong_Ngay13);
            _ravi2["Ngay14"] = String.Format("{0:0.##}", Tong_Ngay14);
            _ravi2["Ngay15"] = String.Format("{0:0.##}", Tong_Ngay15);
            _ravi2["Ngay16"] = String.Format("{0:0.##}", Tong_Ngay16);
            _ravi2["Ngay17"] = String.Format("{0:0.##}", Tong_Ngay17);
            _ravi2["Ngay18"] = String.Format("{0:0.##}", Tong_Ngay18);
            _ravi2["Ngay19"] = String.Format("{0:0.##}", Tong_Ngay19);
            _ravi2["Ngay20"] = String.Format("{0:0.##}", Tong_Ngay20);
            _ravi2["Ngay21"] = String.Format("{0:0.##}", Tong_Ngay21);
            _ravi2["Ngay22"] = String.Format("{0:0.##}", Tong_Ngay22);
            _ravi2["Ngay23"] = String.Format("{0:0.##}", Tong_Ngay23);
            _ravi2["Ngay24"] = String.Format("{0:0.##}", Tong_Ngay24);
            _ravi2["Ngay25"] = String.Format("{0:0.##}", Tong_Ngay25);
            _ravi2["Ngay26"] = String.Format("{0:0.##}", Tong_Ngay26);
            _ravi2["Ngay27"] = String.Format("{0:0.##}", Tong_Ngay27);
            _ravi2["Ngay28"] = String.Format("{0:0.##}", Tong_Ngay28);
            _ravi2["Ngay29"] = String.Format("{0:0.##}", Tong_Ngay29);
            _ravi2["Ngay30"] = String.Format("{0:0.##}", Tong_Ngay30);
            _ravi2["Ngay31"] = String.Format("{0:0.##}", Tong_Ngay31);


            _ravi2["Tong"] = String.Format("{0:0.##}", (Tong_Ngay1 + Tong_Ngay2 + Tong_Ngay3 + Tong_Ngay4 + Tong_Ngay5
                + Tong_Ngay6 + Tong_Ngay7 + Tong_Ngay8 + Tong_Ngay9 + Tong_Ngay10
                + Tong_Ngay11 + Tong_Ngay12 + Tong_Ngay13 + Tong_Ngay14 + Tong_Ngay15
                + Tong_Ngay16 + Tong_Ngay17 + Tong_Ngay18 + Tong_Ngay19 + Tong_Ngay20
                + Tong_Ngay21 + Tong_Ngay22 + Tong_Ngay23 + Tong_Ngay24 + Tong_Ngay25
                + Tong_Ngay26 + Tong_Ngay27 + Tong_Ngay28 + Tong_Ngay29 + Tong_Ngay30 + Tong_Ngay31));


            _data.Rows.Add(_ravi2);
            //
            gridControl1.DataSource = _data;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCongTGD ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCongTGD(_thang, _nam, _data);
            ff.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmDinhMucLuongSL_TGD ff = new Tr_frmDinhMucLuongSL_TGD(0, "frmChamCong_TGD_Old_Tr", this);
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  clTenNhanVien)
            {
                
            }
        }

        //Tô đậm dòng tổng:
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString().ToLower().Contains("tổng"))
                {
                    return;
                }

                int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa công nhân: " + gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString(), "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    bool deleted = false;

                    if (ID_ChiTietChamCong_TGD == 0)
                    {
                        DataRow[] rows;
                        rows = _data.Select("ID_CongNhan=' " + id_cn + " ' ");
                        foreach (DataRow row in rows)
                        {
                            _data.Rows.Remove(row);
                            deleted = true;
                        }
                    }
                    else
                    {
                        using (clsThin clsThin_ = new clsThin())
                        {
                            for (int i = 0; i < _data.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()) == id_cn)
                                {
                                    int id_ChiTietChamCong_TGD_ = Convert.ToInt32(_data.Rows[i]["ID_ChiTietChamCong_ToGapDan"].ToString());
                                    if (clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(id_ChiTietChamCong_TGD_))
                                    {
                                        deleted = true;
                                    }

                                }
                            }
                        }
                    }

                    if (deleted)
                    {
                        DataRow[] rows;
                        rows = _data.Select("ID_CongNhan=' " + id_cn + " ' ");
                        foreach (DataRow row in rows)
                        {
                            _data.Rows.Remove(row);
                        }

                        if (ds_id_congnhan.Contains(id_cn)) ds_id_congnhan.Remove(id_cn);

                        gridControl1.DataSource = _data;
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa công nhân khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString()); 
                 
                Tr_frmDinhMucLuongSL_TGD ff = new Tr_frmDinhMucLuongSL_TGD(id_congnhan_, "frmChamCong_TGD_Old_Tr", this);
                ff.Show();

            }
            catch (Exception ee)
            {

            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
        private void GuiDuLieuBangLuong()
        {
            Cursor.Current = Cursors.WaitCursor;

            bool isGuiThanhCong = false;
            using (clsThin clsThin_ = new clsThin())
            {
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    if (_data.Rows[i]["ID_CongNhan"].ToString() == "")
                        continue;

                    int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                    if (ID_CongNhan_ == 0)
                    {
                        continue;
                    }
                    else
                    {
                        isGuiThanhCong = true;
                    }
                    string Cong_ = _data.Rows[i]["Cong"].ToString();
                    bool isTang = false;
                    if (Cong_.Contains("Tăng"))
                    {
                        isTang = true;
                    }
                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                        ID_CongNhan_,
                        _thang,
                        _nam,
                        0,
                        0,
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
                        (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
                        0, true, isTang, _id_bophan,
                        Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                        Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                }
                if (isGuiThanhCong)
                {
                    MessageBox.Show("Lưu dữ liệu chấm công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu chấm công không thành công. Kiểm tra lại!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Cursor.Current = Cursors.Default;
        }
    }
}

