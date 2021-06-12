using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class T_frmPrintChamComToGapDan : Form
    {
        private int _thang, _nam;
        private int _id_vthh;
        private string _ten_vthh;
        private string _ten_vthh_select;

        public T_frmPrintChamComToGapDan(int thang, int nam, int id_vthh, string ten_vthh_select)
        {
            _thang = thang;
            _nam = nam;
            _id_vthh = id_vthh;
            _ten_vthh_select = ten_vthh_select;
            InitializeComponent();
        }

        private DataTable _dataLoaiHang;
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public bool mbBosungCongNhantrongthang;
        public DataTable mdataatbaleDanhSachChamCOng;
        public string msTenNhanVien;
        private int _id_dinhmuc_togapdan;

        public int  _id_bophan;
        private DataTable _data;
        private bool isload = true;
        private List<DevExpress.XtraGrid.Columns.GridColumn> ds_grid = new List<GridColumn>();
        private List<int> ds_id_congnhan = new List<int>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        private void T_frmPrintChamCongToGapDan_Load(object sender, EventArgs e)
        {
            T_PrintChamComToGapDan xtr111 = new T_PrintChamComToGapDan(_thang, _nam);

            DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbCongNhatChamCongToGapDan.Clone();
            //ds.tbCongNhatChamCongToGapDan.Clear();
            //clsThin cls1 = new clsThin();

            //DataTable dt3 = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");

            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    //DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

            //    //_ravi["TenNhanVien"] = dt3.Rows[i]["TenNhanVien"].ToString();
            //    //_ravi["Ngay1"] = Convert.ToInt32(dt3.Rows[i]["Ngay1"].ToString());
            //    //_ravi["Ngay2"] = Convert.ToInt32(dt3.Rows[i]["Ngay2"].ToString());
            //    //_ravi["Ngay3"] = Convert.ToInt32(dt3.Rows[i]["Ngay3"].ToString());
            //    //_ravi["Ngay4"] = Convert.ToInt32(dt3.Rows[i]["Ngay4"].ToString());
            //    //_ravi["Ngay5"] = Convert.ToInt32(dt3.Rows[i]["Ngay5"].ToString());
            //    //_ravi["Ngay6"] = Convert.ToInt32(dt3.Rows[i]["Ngay6"].ToString());
            //    //_ravi["Ngay7"] = Convert.ToInt32(dt3.Rows[i]["Ngay7"].ToString());
            //    //_ravi["Ngay8"] = Convert.ToInt32(dt3.Rows[i]["Ngay8"].ToString());
            //    //_ravi["Ngay9"] = Convert.ToInt32(dt3.Rows[i]["Ngay9"].ToString());
            //    //_ravi["Ngay10"] = Convert.ToInt32(dt3.Rows[i]["Ngay10"].ToString());
            //    //_ravi["Ngay11"] = Convert.ToInt32(dt3.Rows[i]["Ngay11"].ToString());
            //    //_ravi["Ngay12"] = Convert.ToInt32(dt3.Rows[i]["Ngay12"].ToString());
            //    //_ravi["Ngay13"] = Convert.ToInt32(dt3.Rows[i]["Ngay13"].ToString());
            //    //_ravi["Ngay14"] = Convert.ToInt32(dt3.Rows[i]["Ngay14"].ToString());
            //    //_ravi["Ngay15"] = Convert.ToInt32(dt3.Rows[i]["Ngay15"].ToString());
            //    //_ravi["Ngay16"] = Convert.ToInt32(dt3.Rows[i]["Ngay16"].ToString());
            //    //_ravi["Ngay17"] = Convert.ToInt32(dt3.Rows[i]["Ngay17"].ToString());
            //    //_ravi["Ngay18"] = Convert.ToInt32(dt3.Rows[i]["Ngay18"].ToString());
            //    //_ravi["Ngay19"] = Convert.ToInt32(dt3.Rows[i]["Ngay19"].ToString());
            //    //_ravi["Ngay20"] = Convert.ToInt32(dt3.Rows[i]["Ngay20"].ToString());
            //    //_ravi["Ngay21"] = Convert.ToInt32(dt3.Rows[i]["Ngay21"].ToString());
            //    //_ravi["Ngay22"] = Convert.ToInt32(dt3.Rows[i]["Ngay22"].ToString());
            //    //_ravi["Ngay23"] = Convert.ToInt32(dt3.Rows[i]["Ngay23"].ToString());
            //    //_ravi["Ngay24"] = Convert.ToInt32(dt3.Rows[i]["Ngay24"].ToString());
            //    //_ravi["Ngay25"] = Convert.ToInt32(dt3.Rows[i]["Ngay25"].ToString());
            //    //_ravi["Ngay26"] = Convert.ToInt32(dt3.Rows[i]["Ngay26"].ToString());
            //    //_ravi["Ngay27"] = Convert.ToInt32(dt3.Rows[i]["Ngay27"].ToString());
            //    //_ravi["Ngay28"] = Convert.ToInt32(dt3.Rows[i]["Ngay28"].ToString());
            //    //_ravi["Ngay29"] = Convert.ToInt32(dt3.Rows[i]["Ngay29"].ToString());
            //    //_ravi["Ngay30"] = Convert.ToInt32(dt3.Rows[i]["Ngay30"].ToString());
            //    //_ravi["Ngay31"] = Convert.ToInt32(dt3.Rows[i]["Ngay31"].ToString());
            //    //_ravi["Tong"] = Convert.ToDouble(dt3.Rows[i]["Tong"].ToString());
            //    //_ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
            //    //_ravi["KyNhan"] = "ấdasd";


            //    // ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
            //}
               
            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;
                

            using (clsThin clsThin_ = new clsThin())
            {
                _dataLoaiHang = clsThin_.T_LoaiHangSX_SF(-1);

                DataRow row = _dataLoaiHang.NewRow();
                row["ID_VTHH"] = 0;
                row["TenVTHH"] = "-->Tất cả";
                _dataLoaiHang.Rows.InsertAt(row, 0);

                _id_dinhmuc_togapdan = 0;
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
                    ds_id_congnhan.Add(Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()));

                    if (_id_vthh == 0)
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
                    Ngay11 = Convert.ToInt32(_data.Rows[i]["Ngay11"].ToString());
                    Ngay12 = Convert.ToInt32(_data.Rows[i]["Ngay12"].ToString());
                    Ngay13 = Convert.ToInt32(_data.Rows[i]["Ngay13"].ToString());
                    Ngay14 = Convert.ToInt32(_data.Rows[i]["Ngay14"].ToString());
                    Ngay15 = Convert.ToInt32(_data.Rows[i]["Ngay15"].ToString());
                    Ngay16 = Convert.ToInt32(_data.Rows[i]["Ngay16"].ToString());
                    Ngay17 = Convert.ToInt32(_data.Rows[i]["Ngay17"].ToString());
                    Ngay18 = Convert.ToInt32(_data.Rows[i]["Ngay18"].ToString());
                    Ngay19 = Convert.ToInt32(_data.Rows[i]["Ngay19"].ToString());
                    Ngay20 = Convert.ToInt32(_data.Rows[i]["Ngay20"].ToString());
                    Ngay21 = Convert.ToInt32(_data.Rows[i]["Ngay21"].ToString());
                    Ngay22 = Convert.ToInt32(_data.Rows[i]["Ngay22"].ToString());
                    Ngay23 = Convert.ToInt32(_data.Rows[i]["Ngay23"].ToString());
                    Ngay24 = Convert.ToInt32(_data.Rows[i]["Ngay24"].ToString());
                    Ngay25 = Convert.ToInt32(_data.Rows[i]["Ngay25"].ToString());
                    Ngay26 = Convert.ToInt32(_data.Rows[i]["Ngay26"].ToString());
                    Ngay27 = Convert.ToInt32(_data.Rows[i]["Ngay27"].ToString());
                    Ngay28 = Convert.ToInt32(_data.Rows[i]["Ngay28"].ToString());
                    Ngay29 = Convert.ToInt32(_data.Rows[i]["Ngay29"].ToString());
                    Ngay30 = Convert.ToInt32(_data.Rows[i]["Ngay30"].ToString());
                    Ngay31 = Convert.ToInt32(_data.Rows[i]["Ngay31"].ToString());
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

                    //
                    DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

                    _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                    _ravi["Ngay1"] = Convert.ToInt32(_data.Rows[i]["Ngay1"].ToString());
                    _ravi["Ngay2"] = Convert.ToInt32(_data.Rows[i]["Ngay2"].ToString());
                    _ravi["Ngay3"] = Convert.ToInt32(_data.Rows[i]["Ngay3"].ToString());
                    _ravi["Ngay4"] = Convert.ToInt32(_data.Rows[i]["Ngay4"].ToString());
                    _ravi["Ngay5"] = Convert.ToInt32(_data.Rows[i]["Ngay5"].ToString());
                    _ravi["Ngay6"] = Convert.ToInt32(_data.Rows[i]["Ngay6"].ToString());
                    _ravi["Ngay7"] = Convert.ToInt32(_data.Rows[i]["Ngay7"].ToString());
                    _ravi["Ngay8"] = Convert.ToInt32(_data.Rows[i]["Ngay8"].ToString());
                    _ravi["Ngay9"] = Convert.ToInt32(_data.Rows[i]["Ngay9"].ToString());
                    _ravi["Ngay10"] = Convert.ToInt32(_data.Rows[i]["Ngay10"].ToString());
                    _ravi["Ngay11"] = Convert.ToInt32(_data.Rows[i]["Ngay11"].ToString());
                    _ravi["Ngay12"] = Convert.ToInt32(_data.Rows[i]["Ngay12"].ToString());
                    _ravi["Ngay13"] = Convert.ToInt32(_data.Rows[i]["Ngay13"].ToString());
                    _ravi["Ngay14"] = Convert.ToInt32(_data.Rows[i]["Ngay14"].ToString());
                    _ravi["Ngay15"] = Convert.ToInt32(_data.Rows[i]["Ngay15"].ToString());
                    _ravi["Ngay16"] = Convert.ToInt32(_data.Rows[i]["Ngay16"].ToString());
                    _ravi["Ngay17"] = Convert.ToInt32(_data.Rows[i]["Ngay17"].ToString());
                    _ravi["Ngay18"] = Convert.ToInt32(_data.Rows[i]["Ngay18"].ToString());
                    _ravi["Ngay19"] = Convert.ToInt32(_data.Rows[i]["Ngay19"].ToString());
                    _ravi["Ngay20"] = Convert.ToInt32(_data.Rows[i]["Ngay20"].ToString());
                    _ravi["Ngay21"] = Convert.ToInt32(_data.Rows[i]["Ngay21"].ToString());
                    _ravi["Ngay22"] = Convert.ToInt32(_data.Rows[i]["Ngay22"].ToString());
                    _ravi["Ngay23"] = Convert.ToInt32(_data.Rows[i]["Ngay23"].ToString());
                    _ravi["Ngay24"] = Convert.ToInt32(_data.Rows[i]["Ngay24"].ToString());
                    _ravi["Ngay25"] = Convert.ToInt32(_data.Rows[i]["Ngay25"].ToString());
                    _ravi["Ngay26"] = Convert.ToInt32(_data.Rows[i]["Ngay26"].ToString());
                    _ravi["Ngay27"] = Convert.ToInt32(_data.Rows[i]["Ngay27"].ToString());
                    _ravi["Ngay28"] = Convert.ToInt32(_data.Rows[i]["Ngay28"].ToString());
                    _ravi["Ngay29"] = Convert.ToInt32(_data.Rows[i]["Ngay29"].ToString());
                    _ravi["Ngay30"] = Convert.ToInt32(_data.Rows[i]["Ngay30"].ToString());
                    _ravi["Ngay31"] = Convert.ToInt32(_data.Rows[i]["Ngay31"].ToString());
                    _ravi["Tong"] = Convert.ToDouble(_data.Rows[i]["Tong"].ToString());
                    _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                    ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
                }
            }


            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";
            xtr111.CreateDocument();
            Tr_dcvChamCongToGapDan.DocumentSource = xtr111;
        }
    }
}
