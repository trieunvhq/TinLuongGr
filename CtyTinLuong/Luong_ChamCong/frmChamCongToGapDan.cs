using CtyTinLuong.Constants;
using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
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
    public partial class frmChamCongToGapDan : Form
    {
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public bool mbBosungCongNhantrongthang;
        public DataTable mdataatbaleDanhSachChamCOng;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan, _id_vthh;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();
        public frmChamCongToGapDan()
        {
            InitializeComponent();
            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);
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
        private DataTable _dataLoaiHang;

        int Tong_Ngay1 = 0;
        int Tong_Ngay2 = 0;
        int Tong_Ngay3 = 0;
        int Tong_Ngay4 = 0;
        int Tong_Ngay5 = 0;
        int Tong_Ngay6 = 0;
        int Tong_Ngay7 = 0;
        int Tong_Ngay8 = 0;
        int Tong_Ngay9 = 0;
        int Tong_Ngay10 = 0;
        int Tong_Ngay11 = 0;
        int Tong_Ngay12 = 0;
        int Tong_Ngay13 = 0;
        int Tong_Ngay14 = 0;
        int Tong_Ngay15 = 0;
        int Tong_Ngay16 = 0;
        int Tong_Ngay17 = 0;
        int Tong_Ngay18 = 0;
        int Tong_Ngay19 = 0;
        int Tong_Ngay20 = 0;
        int Tong_Ngay21 = 0;
        int Tong_Ngay22 = 0;
        int Tong_Ngay23 = 0;
        int Tong_Ngay24 = 0;
        int Tong_Ngay25 = 0;
        int Tong_Ngay26 = 0;
        int Tong_Ngay27 = 0;
        int Tong_Ngay28 = 0;
        int Tong_Ngay29 = 0;
        int Tong_Ngay30 = 0;
        int Tong_Ngay31 = 0;

        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
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

                using (clsThin clsThin_ = new clsThin())
                {
                    DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SA();

                    cbBoPhan.DisplayMember = "TenBoPhan";
                    cbBoPhan.ValueMember = "ID_BoPhan";
                    cbBoPhan.DataSource = dt_;
                    cbBoPhan.SelectedValue = 18;
                    cbBoPhan.Enabled = true;


                    _dataLoaiHang = clsThin_.T_LoaiHangSX_SF(-1);

                    DataRow row = _dataLoaiHang.NewRow();
                    row["ID_VTHH"] = 0;
                    row["TenVTHH"] = "-->Tất cả"; 
                    _dataLoaiHang.Rows.InsertAt(row,0);
                    cbLoaiHangSX.DataSource = _dataLoaiHang;
                    cbLoaiHangSX.DisplayMember = "TenVTHH";
                    cbLoaiHangSX.ValueMember = "ID_VTHH";
                    cbLoaiHangSX.Enabled = true;

                    _id_dinhmuc_togapdan = 0;
                    txtDinhMuc.Text = "";

                    try
                    {
                        _id_vthh = (int)cbLoaiHangSX.SelectedValue;
                        _id_bophan = (int)cbBoPhan.SelectedValue;
                        if (_id_vthh == 0)
                        {
                            _ten_vthh = "";
                        }
                        else
                        {
                            _ten_vthh = cbLoaiHangSX.Text;
                        } 
                    }
                    catch { }
                }
            }
            else
            {
            }
            _nam = DateTime.Now.Year;
            _thang = DateTime.Now.Month; 

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, _id_bophan, _id_vthh, "");
                ds_id_congnhan = new List<int>();

                int Ngay1 = 0;
                int Ngay2 = 0;
                int Ngay3 = 0;
                int Ngay4 = 0;
                int Ngay5 = 0;
                int Ngay6 = 0;
                int Ngay7 = 0;
                int Ngay8 = 0;
                int Ngay9 = 0;
                int Ngay10 = 0;
                int Ngay11 = 0;
                int Ngay12 = 0;
                int Ngay13 = 0;
                int Ngay14 = 0;
                int Ngay15 = 0;
                int Ngay16 = 0;
                int Ngay17 = 0;
                int Ngay18 = 0;
                int Ngay19 = 0;
                int Ngay20 = 0;
                int Ngay21 = 0;
                int Ngay22 = 0;
                int Ngay23 = 0;
                int Ngay24 = 0;
                int Ngay25 = 0;
                int Ngay26 = 0;
                int Ngay27 = 0;
                int Ngay28 = 0;
                int Ngay29 = 0;
                int Ngay30 = 0;
                int Ngay31 = 0;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    ds_id_congnhan.Add(Convert.ToInt32(_data.Rows[i]["ID_NhanSu"].ToString()));
                      
                    if(_id_vthh==0)
                    {
                        int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                        _data.Rows[i]["ID_VTHH"] = id_vthh_;
                        _data.Rows[i]["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();
                        //
                    }
                    else
                    {
                        _data.Rows[i]["ID_VTHH"] = _id_vthh;
                        _data.Rows[i]["TenVTHH"] = _id_vthh;
                    }
                    Ngay1 = Convert.ToInt32(_data.Rows[i]["Ngay1"].ToString());
                    Ngay2 = Convert.ToInt32(_data.Rows[i]["Ngay2"].ToString());
                    Ngay3 = Convert.ToInt32(_data.Rows[i]["Ngay3"].ToString());
                    Ngay4 = Convert.ToInt32(_data.Rows[i]["Ngay4"].ToString());
                    Ngay5 = Convert.ToInt32(_data.Rows[i]["Ngay5"].ToString());
                    Ngay6 = Convert.ToInt32(_data.Rows[i]["Ngay6"].ToString());
                    Ngay7 = Convert.ToInt32(_data.Rows[i]["Ngay7"].ToString());
                    Ngay8 = Convert.ToInt32(_data.Rows[i]["Ngay8"].ToString());
                   Ngay9 = Convert.ToInt32(_data.Rows[i]["Ngay9"].ToString());
                   Ngay10 = Convert.ToInt32(_data.Rows[i]["Ngay10"].ToString());
                   Ngay11 =  Convert.ToInt32(_data.Rows[i]["Ngay11"].ToString());
                   Ngay12 =  Convert.ToInt32(_data.Rows[i]["Ngay12"].ToString());
                   Ngay13 =  Convert.ToInt32(_data.Rows[i]["Ngay13"].ToString());
                   Ngay14 =  Convert.ToInt32(_data.Rows[i]["Ngay14"].ToString());
                   Ngay15 =  Convert.ToInt32(_data.Rows[i]["Ngay15"].ToString());
                   Ngay16 =  Convert.ToInt32(_data.Rows[i]["Ngay16"].ToString());
                   Ngay17 =  Convert.ToInt32(_data.Rows[i]["Ngay17"].ToString());
                   Ngay18 =  Convert.ToInt32(_data.Rows[i]["Ngay18"].ToString());
                   Ngay19 =  Convert.ToInt32(_data.Rows[i]["Ngay19"].ToString());
                   Ngay20 =  Convert.ToInt32(_data.Rows[i]["Ngay20"].ToString());
                   Ngay21 =  Convert.ToInt32(_data.Rows[i]["Ngay21"].ToString());
                   Ngay22 =  Convert.ToInt32(_data.Rows[i]["Ngay22"].ToString());
                   Ngay23 =  Convert.ToInt32(_data.Rows[i]["Ngay23"].ToString());
                   Ngay24 =  Convert.ToInt32(_data.Rows[i]["Ngay24"].ToString());
                   Ngay25 =  Convert.ToInt32(_data.Rows[i]["Ngay25"].ToString());
                   Ngay26 =  Convert.ToInt32(_data.Rows[i]["Ngay26"].ToString());
                   Ngay27 =  Convert.ToInt32(_data.Rows[i]["Ngay27"].ToString());
                   Ngay28 =  Convert.ToInt32(_data.Rows[i]["Ngay28"].ToString());
                   Ngay29 =  Convert.ToInt32(_data.Rows[i]["Ngay29"].ToString());
                   Ngay30 =  Convert.ToInt32(_data.Rows[i]["Ngay30"].ToString());
                   Ngay31 =  Convert.ToInt32(_data.Rows[i]["Ngay31"].ToString());
                    //
                    _data.Rows[i]["Ngay1"] = Ngay1.ToString("N0");  
                    _data.Rows[i]["Ngay2"] = Ngay2.ToString("N0");
                    _data.Rows[i]["Ngay3"] = Ngay3.ToString("N0"); 
                    _data.Rows[i]["Ngay4"] = Ngay4.ToString("N0");
                    _data.Rows[i]["Ngay5"] = Ngay5.ToString("N0");
                    _data.Rows[i]["Ngay6"] = Ngay6.ToString("N0");
                    _data.Rows[i]["Ngay7"] = Ngay7.ToString("N0");
                    _data.Rows[i]["Ngay8"] = Ngay8.ToString("N0");
                    _data.Rows[i]["Ngay9"] = Ngay9.ToString("N0");
                    _data.Rows[i]["Ngay10"] = Ngay10.ToString("N0");
                    _data.Rows[i]["Ngay11"] = Ngay11.ToString("N0");
                    _data.Rows[i]["Ngay12"] = Ngay12.ToString("N0");
                    _data.Rows[i]["Ngay13"] = Ngay13.ToString("N0");
                    _data.Rows[i]["Ngay14"] = Ngay14.ToString("N0");
                    _data.Rows[i]["Ngay15"] = Ngay15.ToString("N0");
                    _data.Rows[i]["Ngay16"] = Ngay16.ToString("N0");
                    _data.Rows[i]["Ngay17"] = Ngay17.ToString("N0");
                    _data.Rows[i]["Ngay18"] = Ngay18.ToString("N0");
                    _data.Rows[i]["Ngay19"] = Ngay19.ToString("N0");
                    _data.Rows[i]["Ngay20"] = Ngay20.ToString("N0");
                    _data.Rows[i]["Ngay21"] = Ngay21.ToString("N0");
                    _data.Rows[i]["Ngay22"] = Ngay22.ToString("N0");
                    _data.Rows[i]["Ngay23"] = Ngay23.ToString("N0");
                    _data.Rows[i]["Ngay24"] = Ngay24.ToString("N0");
                    _data.Rows[i]["Ngay25"] = Ngay25.ToString("N0");
                    _data.Rows[i]["Ngay26"] = Ngay26.ToString("N0");
                    _data.Rows[i]["Ngay27"] = Ngay27.ToString("N0");
                    _data.Rows[i]["Ngay28"] = Ngay28.ToString("N0");
                    _data.Rows[i]["Ngay29"] = Ngay29.ToString("N0");
                    _data.Rows[i]["Ngay30"] = Ngay30.ToString("N0");
                    _data.Rows[i]["Ngay31"] = Ngay31.ToString("N0");

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
                stt_ = Convert.ToInt32(_data.Rows[_data.Rows.Count - 1]["STT"].ToString());

            }
            //
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_SF(_id_bophan + ",");

                for (int i = 0; i < dt_.Rows.Count; ++i)
                {
                    int id_nhansu_ = Convert.ToInt32(dt_.Rows[i]["ID_NhanSu"].ToString()); 
                    if (ds_id_congnhan.Contains(id_nhansu_))
                    {

                    }
                    else
                    {
                        DataRow _ravi = _data.NewRow();
                        _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
                        _ravi["ID_CongNhan"] = id_nhansu_;
                        _ravi["Thang"] = _thang;
                        _ravi["Nam"] = _nam;
                        _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0;  _ravi["Ngay3"] = 0;
                        _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
                        _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
                        _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0; 
                        _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
                        _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
                        _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
                        _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
                        _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
                        _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
                        _ravi["Ngay30"] = 0;  _ravi["Ngay31"] = 0;

                        _ravi["SanLuong"] = 0;
                        _ravi["ID_NhanSu"] = id_nhansu_;
                        _ravi["Tong"] = 0;
                        _ravi["GuiDuLieu"] = false;
                        _ravi["MaNhanVien"] = dt_.Rows[i]["MaNhanVien"].ToString();
                        _ravi["TenNhanVien"] = dt_.Rows[i]["TenNhanVien"].ToString();
                        _ravi["TenVTHH"] = _ten_vthh;
                        _ravi["MaVT"] = "";
                        _ravi["ID_VTHH"] = _id_vthh;
                        _ravi["ID_DinhMuc_Luong_SanLuong"] = _id_dinhmuc_togapdan;
                        _ravi["MaDinhMuc"] = "";
                        _ravi["DinhMuc_KhongTang"] = 0;
                        _ravi["DinhMuc_Tang"] = 0;

                        ++stt_;
                        _ravi["STT"] = (stt_);
                        _data.Rows.Add(_ravi);
                    }
                }
            }
            //for(int i=0; i<_dataLoaiHang.Rows.Count; i++)
            //{
            //    comboThin.Items.Add(_dataLoaiHang.Rows[i]["TenVTHH"].ToString());
            //}
            gridThin.EditValueChanged +=(o,e)=> {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenNhanVien"] = "TỔNG";
            _ravi2["Ngay1"] = Tong_Ngay1.ToString("N0");
            _ravi2["Ngay2"] = Tong_Ngay2.ToString("N0");
            _ravi2["Ngay3"] = Tong_Ngay3.ToString("N0");
            _ravi2["Ngay4"] = Tong_Ngay4.ToString("N0");
            _ravi2["Ngay5"] = Tong_Ngay5.ToString("N0");
            _ravi2["Ngay6"] = Tong_Ngay6.ToString("N0");
            _ravi2["Ngay7"] = Tong_Ngay7.ToString("N0");
            _ravi2["Ngay8"] = Tong_Ngay8.ToString("N0");
            _ravi2["Ngay9"] = Tong_Ngay9.ToString("N0");
            _ravi2["Ngay10"] = Tong_Ngay10.ToString("N0");
            _ravi2["Ngay11"] = Tong_Ngay11.ToString("N0");
            _ravi2["Ngay12"] = Tong_Ngay12.ToString("N0");
            _ravi2["Ngay13"] = Tong_Ngay13.ToString("N0");
            _ravi2["Ngay14"] = Tong_Ngay14.ToString("N0");
            _ravi2["Ngay15"] = Tong_Ngay15.ToString("N0");
            _ravi2["Ngay16"] = Tong_Ngay16.ToString("N0");
            _ravi2["Ngay17"] = Tong_Ngay17.ToString("N0");
            _ravi2["Ngay18"] = Tong_Ngay18.ToString("N0");
            _ravi2["Ngay19"] = Tong_Ngay19.ToString("N0");
            _ravi2["Ngay20"] = Tong_Ngay20.ToString("N0");
            _ravi2["Ngay21"] = Tong_Ngay21.ToString("N0");
            _ravi2["Ngay22"] = Tong_Ngay22.ToString("N0");
            _ravi2["Ngay23"] = Tong_Ngay23.ToString("N0");
            _ravi2["Ngay24"] = Tong_Ngay24.ToString("N0");
            _ravi2["Ngay25"] = Tong_Ngay25.ToString("N0");
            _ravi2["Ngay26"] = Tong_Ngay26.ToString("N0");
            _ravi2["Ngay27"] = Tong_Ngay27.ToString("N0");
            _ravi2["Ngay28"] = Tong_Ngay28.ToString("N0");
            _ravi2["Ngay29"] = Tong_Ngay29.ToString("N0");
            _ravi2["Ngay30"] = Tong_Ngay30.ToString("N0");
            _ravi2["Ngay31"] = Tong_Ngay31.ToString("N0");


            _ravi2["Tong"] = (Tong_Ngay1 + Tong_Ngay2+ Tong_Ngay3+ Tong_Ngay4 + Tong_Ngay5
                + Tong_Ngay6 + Tong_Ngay7 + Tong_Ngay8 + Tong_Ngay9 + Tong_Ngay10
                + Tong_Ngay11 + Tong_Ngay12 + Tong_Ngay13 + Tong_Ngay14 + Tong_Ngay15
                + Tong_Ngay16 + Tong_Ngay17 + Tong_Ngay18 + Tong_Ngay19 + Tong_Ngay20
                + Tong_Ngay21 + Tong_Ngay22 + Tong_Ngay23 + Tong_Ngay24 + Tong_Ngay25
                + Tong_Ngay26 + Tong_Ngay27 + Tong_Ngay28 + Tong_Ngay29 + Tong_Ngay30 + Tong_Ngay31).ToString("N0");

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
        private void frmChamCongToGapDan_Load(object sender, EventArgs e)
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
            catch {
                MessageBox.Show("Tháng không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show( "Năm không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            frmMaHang_ChamCong_ToGapDan ff = new frmMaHang_ChamCong_ToGapDan(this);
            ff.Show();
        }
          
        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            //GuiDuLieuBangLuong();

            CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan ff = new CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan(7,2021);
            ff.Show();
        }

        private int _id_dinhmuc_togapdan;

        private void cbLoaiHangSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isload)
                return;

            lbChinhSua.Text = "Chỉnh sửa";
            txtDinhMuc.ForeColor = Color.Black;
            _id_vthh = (int)cbLoaiHangSX.SelectedValue;
            if(_id_vthh==0)
            {
                _ten_vthh = "";
            }
            else
            {
                _ten_vthh = cbLoaiHangSX.Text;
            }
            using (clsThin clsThin_ = new clsThin())
            {
                int nam_, thang_;
                try {
                    thang_ = Convert.ToInt32(txtThang.Text);
                }
                catch
                {
                    MessageBox.Show( "Tháng không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    nam_ = Convert.ToInt32(txtNam.Text);
                }
                catch
                {
                    MessageBox.Show( "Năm không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }  
                if(_id_vthh==0)
                {
                    _id_dinhmuc_togapdan = 0;
                    txtDinhMuc.Text = "-->Tất cả";
                }
                else
                {
                    DataRow row_ = ((DataRowView)cbLoaiHangSX.SelectedItem).Row; 
                    _id_dinhmuc_togapdan = Convert.ToInt32(row_["ID_DinhMuc_Luong_SanLuong"].ToString());
                    txtDinhMuc.Text = row_["DienGiai"].ToString() + " (" + row_["MaDinhMuc"].ToString() + ")";
                }
                /*
                DataTable dt_ = clsThin_.T_DinhMuc_DinhMuc_Luong_TheoSanLuong_SO(id_vthh_, thang_, nam_);
                 
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    _id_dinhmuc_togapdan = Convert.ToInt32(dt_.Rows[0]["ID_DinhMuc_Luong_SanLuong"]);
                    float dinhmuc_ = ConvertToFloat(dt_.Rows[0]["DinhMuc_KhongTang"].ToString());
                    txtDinhMuc.Text = dt_.Rows[0]["MaDinhMuc"] + " (" + dinhmuc_.ToString("N0") + ")";
                    if (_id_dinhmuc_togapdan == 0)
                    {
                        txtDinhMuc.Text = "Chưa cài đặt định mức!";
                        lbChinhSua.Text = "Thêm mới";
                        txtDinhMuc.ForeColor = Color.Red; 
                    }
                    else
                    {

                    }
                } 
                else
                {
                    txtDinhMuc.Text = "Chưa cài đặt định mức!";
                    lbChinhSua.Text = "Thêm mới";
                    txtDinhMuc.ForeColor = Color.Red;
                    _id_dinhmuc_togapdan = 0;
                }*/
            }
            LoadData(false);
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
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch 
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
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
            this.Close();
        }
        private void GuiDuLieuBangLuong()
        {
            bool isGuiThanhCong = false;
            using (clsThin clsThin_ = new clsThin())
            {
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    if (_data.Rows[i]["ID_VTHH"].ToString() == "")
                        continue;

                    int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                    if (id_vthh_ == 0)
                    {
                        continue;
                    }
                    else
                    {
                        isGuiThanhCong = true;
                    }
                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                        Convert.ToInt32(_data.Rows[i]["ID_NhanSu"].ToString()),
                        _thang,
                        _nam,
                        id_vthh_,
                        Convert.ToInt32(_data.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay1"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay2"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay3"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay4"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay5"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay6"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay7"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay8"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay9"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay10"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay11"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay12"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay13"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay14"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay15"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay16"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay17"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay18"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay19"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay20"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay21"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay22"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay23"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay24"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay25"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay26"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay27"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay28"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay29"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay30"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay31"].ToString()),
                        0, true);
                }
                if (isGuiThanhCong)
                {
                    MessageBox.Show("Gửi dữ liệu chấm công thành công!");
                }
                else
                {
                    MessageBox.Show( "Chưa chọn loại hàng hóa","Lỗi",
       MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
               

        }
    }
}


