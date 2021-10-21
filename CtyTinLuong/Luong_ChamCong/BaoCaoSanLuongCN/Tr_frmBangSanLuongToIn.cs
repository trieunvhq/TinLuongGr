using DevExpress.XtraGrid.Columns;
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
    public partial class Tr_frmBangSanLuongToIn : Form
    {
        private DataTable _data = new DataTable();
        private List<GridColumn> ds_grid = new List<GridColumn>();
        private int _thang, _nam;
        DateTime ngaydauthang, ngaycuoithang;


        public Tr_frmBangSanLuongToIn()
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

        private void Tr_frmBangSanLuongToIn_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData(int xxID_CongNhan)
        {
            try
            {
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                DataTable dtxxxx = new DataTable();
                dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan(xxID_CongNhan, ngaydauthang, ngaycuoithang);
                int days = DateTime.DaysInMonth(2021, 10);

                DataRow _ravi_1 = _data.NewRow();
                DataRow _ravi_2 = _data.NewRow();

                int id_vthh_cu_ = 0;
                double tong1 = 0, tong2 = 0;
                for (int k = 0; k < dtxxxx.Rows.Count; k++)
                {
                    double snluong_thuong = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                    double snluong_tangca = CheckString.ConvertToDouble_My(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());
                    //int xxid_vthh= Convert.ToInt32(dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString());
                    //tong1 = CheckString.ConvertToDouble_My(dtxxxx.Compute("sum(SanLuong_Thuong)", "ID_VTHH_Ra=" + xxid_vthh + ""));

                    int ngay_ = (Convert.ToDateTime(dtxxxx.Rows[k]["NgaySanXuat"].ToString()).Day);
                    _ravi_1["Ngay" + (ngay_)] = snluong_thuong.ToString();
                    _ravi_2["Ngay" + (ngay_)] = snluong_tangca.ToString();
                    tong1 += snluong_thuong;
                    tong2 += snluong_tangca;
                    _ravi_1["Tong"] = tong1.ToString();
                    _ravi_2["Tong"] = tong2;
                    //
                    int id_vthh_ = 0;
                    if (k < dtxxxx.Rows.Count - 1)
                    {
                        id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString());

                        if (dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                        {
                            _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                            _ravi_1["NoiDung"] = "Thường";

                            _ravi_2["TenVTHH"] = "";
                            _ravi_2["NoiDung"] = "Tăng ca";


                            _data.Rows.Add(_ravi_1);
                            _data.Rows.Add(_ravi_2);
                            tong1 = 0;
                            tong2 = 0;
                            _ravi_1 = _data.NewRow();
                            _ravi_2 = _data.NewRow();
                            id_vthh_cu_ = id_vthh_;
                        }
                        else
                        { }
                    }
                    else
                    {
                        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["NoiDung"] = "Thường";

                        _ravi_2["TenVTHH"] = "";
                        _ravi_2["NoiDung"] = "Tăng ca";


                        _data.Rows.Add(_ravi_1);
                        _data.Rows.Add(_ravi_2);

                        tong1 = 0;
                        tong2 = 0;
                        _ravi_1 = _data.NewRow();
                        _ravi_2 = _data.NewRow();
                    }
                }

                gridControl2.DataSource = _data;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
