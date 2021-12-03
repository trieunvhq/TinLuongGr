

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
    public partial class frmChamCong_TDK : UserControl
    {
        public string _MaNhanVien = "";
        public int  _ID_DinhMucLuong_CongNhat;
        public int _nam, _thang, _id_bophan = 25;
        private string _MaDinhMucLuongCongNhat;
        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public frmChamCong_TDK(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _ID_DinhMucLuong_CongNhat = 0;
            _MaDinhMucLuongCongNhat = "";
            _id_bophan = id_bophan;
            InitializeComponent();

            MaDinhMucLuongCongNhat.Caption = "ĐỊNH MỨC";

            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);

            this.cbHangHoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHangHoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("MaVT", typeof(string));
            _data.Columns.Add("TenVTHH", typeof(string));
            _data.Columns.Add("Ngay1", typeof(double));
            _data.Columns.Add("Ngay2", typeof(double));
            _data.Columns.Add("Ngay3", typeof(double));
            _data.Columns.Add("Ngay4", typeof(double));
            _data.Columns.Add("Ngay5", typeof(double));
            _data.Columns.Add("Ngay6", typeof(double));
            _data.Columns.Add("Ngay7", typeof(double));
            _data.Columns.Add("Ngay8", typeof(double));
            _data.Columns.Add("Ngay9", typeof(double));
            _data.Columns.Add("Ngay10", typeof(double));
            _data.Columns.Add("Ngay11", typeof(double));
            _data.Columns.Add("Ngay12", typeof(double));
            _data.Columns.Add("Ngay13", typeof(double));
            _data.Columns.Add("Ngay14", typeof(double));
            _data.Columns.Add("Ngay15", typeof(double));
            _data.Columns.Add("Ngay16", typeof(double));
            _data.Columns.Add("Ngay17", typeof(double));
            _data.Columns.Add("Ngay18", typeof(double));
            _data.Columns.Add("Ngay19", typeof(double));
            _data.Columns.Add("Ngay20", typeof(double));
            _data.Columns.Add("Ngay21", typeof(double));
            _data.Columns.Add("Ngay22", typeof(double));
            _data.Columns.Add("Ngay23", typeof(double));
            _data.Columns.Add("Ngay24", typeof(double));
            _data.Columns.Add("Ngay25", typeof(double));
            _data.Columns.Add("Ngay26", typeof(double));
            _data.Columns.Add("Ngay27", typeof(double));
            _data.Columns.Add("Ngay28", typeof(double));
            _data.Columns.Add("Ngay29", typeof(double));
            _data.Columns.Add("Ngay30", typeof(double));
            _data.Columns.Add("Ngay31", typeof(double));
            _data.Columns.Add("Tong", typeof(double));
        }
        public void Load_DinhMuc(int id_dinhmuc,string ma,int id_congnhan)
        {
            _ID_DinhMucLuong_CongNhat = id_dinhmuc;
            _MaDinhMucLuongCongNhat = ma;
            if (id_congnhan>0)
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    if(Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString())==id_congnhan)
                    {
                        _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                        _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                        if (i > 0)
                        {
                            int j = i - 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                --j;
                                if (j < 0)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            }
                        }
                        if (i < _data.Rows.Count - 1)
                        {
                            int j = i + 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                ++j;
                                if (j >= _data.Rows.Count - 1)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
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
        DataTable _dt_HangHoa;

        private bool _deleted_29 = false;
        private bool _deleted_30 = false;
        private bool _deleted_31 = false;

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


        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            if (islandau)
            { 
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }

            List<int> dsIDVTHH = new List<int>();

            ChangeColTitle(_thang, _nam);

            //using (clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh())
            //{
            //    cls.iThang = _thang;
            //    cls.iNam = _nam;
            //    _dt_HangHoa = cls.Tr_CaiMacDinhMaHang_TDK_SelectAll_thang_nam();
            //    cbHangHoa.DataSource = _dt_HangHoa;
            //    cbHangHoa.DisplayMember = "TenVTHH";
            //    cbHangHoa.ValueMember = "ID_VTHH";
            //}

            //using (clsThin clsThin_ = new clsThin())
            //{
            //    _dt_HangHoa = clsThin_.T_LoaiHangSX_SF(0);
            //    cbHangHoa.DataSource = _dt_HangHoa;
            //    cbHangHoa.DisplayMember = "TenVTHH";
            //    cbHangHoa.ValueMember = "ID_VTHH";
            //}

            using (clsThin clsThin_ = new clsThin())
            {
                int stt = 0;
                double tongTong = 0;

                DataTable dtGD = clsThin_.Tr_DongKien_TbXuatKho_ChiTietXuatKho_ChamCong(_thang, _nam);
                DataTable dtDL = clsThin_.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_ChamCong(_thang, _nam);
                foreach (DataRow item in dtGD.Rows)
                {
                    if (!dsIDVTHH.Contains(Convert.ToInt32(item["ID_VTHH"].ToString())))
                    {
                        dsIDVTHH.Add(Convert.ToInt32(item["ID_VTHH"].ToString()));
                    }
                }

                foreach (DataRow item in dtDL.Rows)
                {
                    if (!dsIDVTHH.Contains(Convert.ToInt32(item["ID_VTHH"].ToString())))
                    {
                        dsIDVTHH.Add(Convert.ToInt32(item["ID_VTHH"].ToString()));
                    }
                }

                foreach (int item in dsIDVTHH)
                {
                    ModelDongKien dk = getSLDK(item, dtGD, dtDL);
                    stt++;

                    DataRow _ravi = _data.NewRow();
                    _ravi["STT"] = stt;
                    _ravi["MaVT"] = dk.MaVT;
                    _ravi["TenVTHH"] = dk.TenHangHoa;
                    _ravi["Tong"] = dk.SanLuongTong.ToString("N0");

                    for (int i = 0; i < 31; i++)
                    {
                        _ravi["Ngay" + (i +1)] = dk.DsSLNgay[i];
                    }

                    _data.Rows.Add(_ravi);
                    tongTong += dk.SanLuongTong;
                }

                //Add row tổng:
                if (dsIDVTHH.Count > 0)
                {
                    DataRow _ravi = _data.NewRow();
                    _ravi["STT"] = "";
                    _ravi["MaVT"] = "";
                    _ravi["TenVTHH"] = "Tổng";
                    _ravi["Tong"] = tongTong.ToString("N0");

                    for (int i = 0; i < 31; i++)
                    {
                        string calc = "SUM(Ngay" + (i + 1) + ")";
                        _ravi["Ngay" + (i + 1)] = CheckString.ConvertToDouble_My(_data.Compute(calc, string.Empty)).ToString("N0");
                    }

                    _data.Rows.Add(_ravi);
                }
            }
            gridControl1.DataSource = _data;
            isload = false;
        }

        private ModelDongKien getSLDK(int idvthh, DataTable dtGD, DataTable dtDL)
        {
            ModelDongKien dk = new ModelDongKien();
            string maVT_ = "";
            string tenVTHH_ = "";
            double donGia_ = 0;
            double SanLuongTong_ = 0;


            for (int i = 0; i < 31; i++)
            {
                dk.DsSLNgay[i] = 0;
            }

            // Gấp dán:
            foreach (DataRow item in dtGD.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH"].ToString()))
                {
                    tenVTHH_ = item["TenVTHH"].ToString();
                    maVT_ = item["MaVT"].ToString();
                    donGia_ = CheckString.ConvertToDouble_My(item["DonGia"].ToString());
                    int NgaySX = Convert.ToDateTime(item["NgayChungTu"].ToString()).Day;
                    dk.DsSLNgay[NgaySX - 1] += CheckString.ConvertToDouble_My(item["SoLuongXuat"].ToString());
                }
            }

            // Gấp dán:
            foreach (DataRow item in dtDL.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH"].ToString()))
                {
                    if (tenVTHH_ == "")
                        tenVTHH_ = item["TenVTHH"].ToString();

                    if (maVT_ == "")
                        maVT_ = item["MaVT"].ToString();

                    if (donGia_ == 0)
                        donGia_ = CheckString.ConvertToDouble_My(item["DonGia"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgayThang"].ToString()).Day;
                    dk.DsSLNgay[NgaySX - 1] += CheckString.ConvertToDouble_My(item["SoLuongXuat"].ToString());
                }
            }

            for (int i = 0; i < 31; i++)
            {
                SanLuongTong_ += dk.DsSLNgay[i];
            }

            dk.DonGia = donGia_;
            dk.MaVT = maVT_;
            dk.TenHangHoa = tenVTHH_;
            dk.SanLuongTong = SanLuongTong_;
            dk.ThanhTienTong = SanLuongTong_ * donGia_;

            return dk;
        }


        private List<int> _ListID_HangHoa = new List<int>();

        private void LoadHangHoaVaoBang(int id_bophan)
        {
            int stt_ = 0;
            if (_data != null && _data.Rows.Count > 0)
            {
                stt_ = Convert.ToInt32(_data.Rows[_data.Rows.Count - 1]["STT"].ToString());
            }

            //Add công nhân tháng trước tự động nếu tháng mới chưa có dữ liệu:
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang(_thang, _nam, _id_bophan);
                if (dt_.Rows.Count == 0)
                {
                    int thangTruoc = 1;
                    int namTruoc = _nam;
                    switch (_thang)
                    {
                        case 1:
                            thangTruoc = 12;
                            namTruoc = _nam - 1;
                            break;
                        default:
                            thangTruoc = _thang - 1;
                            namTruoc = _nam;
                            break;
                    }

                    dt_ = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang(thangTruoc, namTruoc, _id_bophan);
                    for (int i = 0; i < dt_.Rows.Count; ++i)
                    {
                        //if (_ID_DinhMucLuong_CongNhat == 0)
                        //{
                        _ID_DinhMucLuong_CongNhat = Convert.ToInt32(dt_.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                        _MaDinhMucLuongCongNhat = dt_.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                        //}
                        //
                        int id_vthh_ = Convert.ToInt32(dt_.Rows[i]["ID_VTHH"].ToString());
                        if (_ListID_HangHoa.Contains(id_vthh_))
                        {

                        }
                        else
                        {
                            DataRow _ravi = _data.NewRow();
                            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
                            _ravi["ID_VTHH"] = id_vthh_;
                            _ravi["TenVTHH"] = dt_.Rows[i]["TenVTHH"].ToString();
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
                            _ravi["ID_LoaiCong"] = dt_.Rows[i]["ID_LoaiCong"].ToString();

                            ++stt_;
                            _ravi["STT"] = (stt_);
                            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                            _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;
                            _data.Rows.Add(_ravi);
                        }
                    }
                }
            }

            ////Load toàn bộ danh sách hàng hóa:
            //using (clsThin clsThin_ = new clsThin())
            //{
            //    //DataTable dt_ = clsThin_.T_NhanSu_SF(_id_bophan + ",");

            //    for (int i = 0; i < _dt_HangHoa.Rows.Count; ++i)
            //    {
            //        //if (_ID_DinhMucLuong_CongNhat == 0)
            //        //{
            //        //    _ID_DinhMucLuong_CongNhat = Convert.ToInt32(_dt_HangHoa.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
            //        //    _MaDinhMucLuongCongNhat = _dt_HangHoa.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
            //        //}
            //        ////
            //        //cbHangHoa.DisplayMember = "TenVTHH";
            //        //cbHangHoa.ValueMember = "ID_VTHH";
            //        int ID_VTHH_ = Convert.ToInt32(_dt_HangHoa.Rows[i]["ID_VTHH"].ToString());
            //        if (_ListID_HangHoa.Contains(ID_VTHH_))
            //        {

            //        }
            //        else
            //        {
            //            DataRow _ravi = _data.NewRow();
            //            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
            //            _ravi["ID_VTHH"] = ID_VTHH_;
            //            _ravi["Thang"] = _thang;
            //            _ravi["Nam"] = _nam;
            //            _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0; _ravi["Ngay3"] = 0;
            //            _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
            //            _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
            //            _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0;
            //            _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
            //            _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
            //            _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
            //            _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
            //            _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
            //            _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
            //            _ravi["Ngay30"] = 0; _ravi["Ngay31"] = 0;

            //            _ravi["SanLuong"] = 0;
            //            _ravi["Tong"] = 0;
            //            _ravi["ID_LoaiCong"] = -1;
            //            _ravi["GuiDuLieu"] = false;
            //            _ravi["TenVTHH"] = _dt_HangHoa.Rows[i]["TenVTHH"].ToString();

            //            _ravi["MaDinhMuc"] = "";
            //            _ravi["DinhMuc_KhongTang"] = 0;
            //            _ravi["DinhMuc_Tang"] = 0;
            //            _ravi["Cong"] = "Công nhật";

            //            ++stt_;
            //            _ravi["STT"] = (stt_);
            //            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
            //            _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;
            //            _data.Rows.Add(_ravi);
            //        }
            //    }
            //}

            //
            gridThin.EditValueChanged += (o, e) => {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_VTHH"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenVTHH"] = "Tổng";
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
        private void frmChamCong_TDK_Load(object sender, EventArgs e)
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
            if (!_data.Rows[index_]["TenVTHH"].ToString().ToLower().Contains("tổng")) SaveOneCN_Datarow(_data.Rows[index_]);
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
                MessageBox.Show("Tháng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Năm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (cbHangHoa.Text != "")
            {
                if ((int)cbHangHoa.SelectedValue == 0)
                {
                }
                else
                {
                    ThemMotHangHoaVaoBang((int)cbHangHoa.SelectedValue, cbHangHoa.Text, true);
                }
            }
        }
        private void ThemMotHangHoaVaoBang(int ID_VTHH_, string ten_, bool isNew)
        {
            //for (int i = 0; i < _data.Rows.Count; ++i)
            //{
            //    if (ID_VTHH_ == Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()))
            //    {
            //        MessageBox.Show("Đã tồn tại hàng hóa này trong bảng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            //string MaHangHoa = "";
            //for (int i = 0; i < _dt_HangHoa.Rows.Count; i++)
            //{
            //    if (ID_VTHH_ == Convert.ToInt16(_dt_HangHoa.Rows[i]["ID_VTHH"].ToString()))
            //    {
            //        MaHangHoa = _dt_HangHoa.Rows[i]["MaVT"].ToString();
            //    }
            //}

            //Kiểm tra có tồn tại ID_VTHH_ chưa? nếu chưa thì thêm vào listID:
            if (_ListID_HangHoa.Contains(ID_VTHH_))
            {
                MessageBox.Show("Đã tồn tại hàng hóa này trong bảng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _ListID_HangHoa.Add(ID_VTHH_);
            }

            //
            if (isNew && _data != null && _data.Rows.Count > 0)
            {
                _data.Rows.RemoveAt(_data.Rows.Count - 1);
            }
            else
            {

            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi["ID_CongNhan"] = 0;
            _ravi["ID_VTHH"] = ID_VTHH_;
            _ravi["TenVTHH"] = ten_;
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
            _ravi["ID_LoaiCong"] = 1;
            _ravi["GuiDuLieu"] = false;

            _ravi["MaDinhMuc"] = "";
            _ravi["DinhMuc_KhongTang"] = 0;
            _ravi["DinhMuc_Tang"] = 0;
            //_ravi["Cong"] = "Công nhật";

            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
            _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;

            _data.Rows.Add(_ravi);

            //
            gridThin.EditValueChanged += (o, e) => {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["ID_VTHH"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenVTHH"] = "Tổng";
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
            //gridControl1.DataSource = _data;
            SaveOneCN(ID_VTHH_);
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCong_TDK ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCong_TDK(_thang, _nam, _data);
            ff.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmCaiMacDinnhMaHangTDK ff = new Tr_frmCaiMacDinnhMaHangTDK();
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  TenVTHH)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ten = View.GetRowCellValue(e.RowHandle, View.Columns["TenVTHH"]).ToString();
                if (ten == "Tổng")
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_VTHH).ToString());

                Tr_frmCaiMacDinnhMaHangTDK ff = new Tr_frmCaiMacDinnhMaHangTDK();
                ff.Show();

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gridView1.GetFocusedRowCellValue(TenVTHH).ToString().ToLower().Contains("tổng"))
                {
                    return;
                }

                int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_VTHH).ToString());
                int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa mặt hàng: " + gridView1.GetFocusedRowCellValue(TenVTHH).ToString(), "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    bool deleted = false;

                    if (ID_ChiTietChamCong_TGD == 0)
                    {
                        DataRow[] rows;
                        rows = _data.Select("ID_VTHH=' " + id_cn + " ' ");
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
                                if (Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString()) == id_cn)
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
                        rows = _data.Select("ID_VTHH=' " + id_cn + " ' ");
                        foreach (DataRow row in rows)
                        {
                            _data.Rows.Remove(row);
                        }

                        if (_ListID_HangHoa.Contains(id_cn)) _ListID_HangHoa.Remove(id_cn);

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

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                if (e.Column.FieldName == "Xoa")
                {
                    e.RepositoryItem = emptyEditor;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
        //private void GuiDuLieuBangLuong()
        //{
        //    bool isGuiThanhCong = false;
        //    using (clsThin clsThin_ = new clsThin())
        //    {
        //        for (int i = 0; i < _data.Rows.Count; ++i)
        //        {
        //            if (_data.Rows[i]["ID_VTHH"].ToString() == "")
        //                continue;

        //            int ID_VTHH = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
        //            if (ID_VTHH == 0)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                isGuiThanhCong = true;
        //            }
        //            string Cong_ = _data.Rows[i]["Cong"].ToString();
        //            bool isTang = false;
        //            if (Cong_.Contains("Tăng"))
        //            {
        //                isTang = true;
        //            }
        //            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
        //                0,
        //                _thang,
        //                _nam,
        //                ID_VTHH,
        //                0,
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
        //                (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
        //                0, true, isTang, _id_bophan,
        //                Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
        //                Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
        //        }
        //        if (isGuiThanhCong)
        //        {
        //            MessageBox.Show("Lưu dữ liệu chấm công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Lưu dữ liệu chấm công không thành công. Kiểm tra lại!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //    }


        //}

        private bool GuiDuLieuBangLuong()
        {
            bool isGuiThanhCong = false;
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        if (_data.Rows[i]["ID_VTHH"].ToString() == "")
                            continue;

                        int ID_VTHH = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                        if (ID_VTHH == 0)
                        {
                            continue;
                        }
                        else
                        {
                            isGuiThanhCong = true;
                        }
                        //string Cong_ = _data.Rows[i]["Cong"].ToString();
                        //bool isTang = false;
                        //if (Cong_.Contains("Tăng"))
                        //{
                        //    isTang = true;
                        //}
                        clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            0,
                            _thang,
                            _nam,
                            ID_VTHH,
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
                            0, true, false, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                    }
                    if (isGuiThanhCong)
                    {
                        LoadData(false);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu bảng chấm công. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isGuiThanhCong;
        }

        private void SaveOneCN(int idvthh_)
        {
            string tenVTHH_ = "";
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        tenVTHH_ = _data.Rows[i]["TenVTHH"].ToString();
                        int ID_VTHH = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                        if (ID_VTHH == idvthh_)
                        {
                            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            0,
                            _thang,
                            _nam,
                            ID_VTHH,
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
                            0, true, false, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu hàng hóa: " + tenVTHH_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOneCN_Datarow(DataRow dt_row)
        {
            string tenVTHH_ = "";
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    tenVTHH_ = dt_row["TenVTHH"].ToString();
                    int ID_VTHH = Convert.ToInt32(dt_row["ID_VTHH"].ToString());

                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                    0,
                    _thang,
                    _nam,
                    ID_VTHH,
                    0,
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay1"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay2"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay3"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay4"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay5"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay6"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay7"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay8"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay9"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay10"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay11"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay12"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay13"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay14"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay15"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay16"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay17"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay18"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay19"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay20"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay21"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay22"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay23"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay24"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay25"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay26"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay27"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay28"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay29"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay30"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay31"].ToString()),
                    0, true, false, _id_bophan,
                    Convert.ToInt32(dt_row["ID_DinhMucLuong_CongNhat"].ToString()),
                    Convert.ToInt32(dt_row["ID_LoaiCong"].ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu hàng hóa: " + tenVTHH_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

