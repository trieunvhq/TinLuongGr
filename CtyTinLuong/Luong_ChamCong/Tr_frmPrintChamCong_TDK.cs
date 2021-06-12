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

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_frmPrintChamCong_TDK : Form
    {
        private int _thang, _nam;
        public int _id_bophan;
        public string _TenVTHH;
        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        public Tr_frmPrintChamCong_TDK(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintChamCong_TDK_Load(object sender, EventArgs e)
        {
            Tr_PrintChamCong_TDK xtr111 = new Tr_PrintChamCong_TDK(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;


            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_LoaiHangSX_SF(0);

                //cbHangHoa.DataSource = dt_;
                //cbHangHoa.DisplayMember = "TenVTHH";
                //cbHangHoa.ValueMember = "ID_VTHH";
            }

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, _id_bophan, 0, "");

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

                }
            }

            //gridControl1.DataSource = _data;

            isload = false;


            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;

        }
    }
}
