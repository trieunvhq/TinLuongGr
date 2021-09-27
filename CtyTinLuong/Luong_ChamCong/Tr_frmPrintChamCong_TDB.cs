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
    public partial class Tr_frmPrintChamCong_TDB : Form
    {
        private int _thang, _nam;
        public int _id_bophan;
        public string _TenVTHH;
        private DataTable _data;
        private bool _isTo1;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        public Tr_frmPrintChamCong_TDB(int thang, int nam, DataTable data, bool isTo1)
        {
            _isTo1 = isTo1;
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintChamCong_TDB_Load(object sender, EventArgs e)
        {
            Tr_PrintChamCong_TDB xtr111 = new Tr_PrintChamCong_TDB(_thang, _nam, _isTo1);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();
                _ravi["STT"] = (i +1).ToString();
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                _ravi["Ngay1"] = _data.Rows[i]["Ngay1"].ToString();
                _ravi["Ngay2"] = _data.Rows[i]["Ngay2"].ToString();
                _ravi["Ngay3"] = _data.Rows[i]["Ngay3"].ToString();
                _ravi["Ngay4"] = _data.Rows[i]["Ngay4"].ToString();
                _ravi["Ngay5"] = _data.Rows[i]["Ngay5"].ToString();
                _ravi["Ngay6"] = _data.Rows[i]["Ngay6"].ToString();
                _ravi["Ngay7"] = _data.Rows[i]["Ngay7"].ToString();
                _ravi["Ngay8"] = _data.Rows[i]["Ngay8"].ToString();
                _ravi["Ngay9"] = _data.Rows[i]["Ngay9"].ToString();
                _ravi["Ngay10"] = _data.Rows[i]["Ngay10"].ToString();
                _ravi["Ngay11"] = _data.Rows[i]["Ngay11"].ToString();
                _ravi["Ngay12"] = _data.Rows[i]["Ngay12"].ToString();
                _ravi["Ngay13"] = _data.Rows[i]["Ngay13"].ToString();
                _ravi["Ngay14"] = _data.Rows[i]["Ngay14"].ToString();
                _ravi["Ngay15"] = _data.Rows[i]["Ngay15"].ToString();
                _ravi["Ngay16"] = _data.Rows[i]["Ngay16"].ToString();
                _ravi["Ngay17"] = _data.Rows[i]["Ngay17"].ToString();
                _ravi["Ngay18"] = _data.Rows[i]["Ngay18"].ToString();
                _ravi["Ngay19"] = _data.Rows[i]["Ngay19"].ToString();
                _ravi["Ngay20"] = _data.Rows[i]["Ngay20"].ToString();
                _ravi["Ngay21"] = _data.Rows[i]["Ngay21"].ToString();
                _ravi["Ngay22"] = _data.Rows[i]["Ngay22"].ToString();
                _ravi["Ngay23"] = _data.Rows[i]["Ngay23"].ToString();
                _ravi["Ngay24"] = _data.Rows[i]["Ngay24"].ToString();
                _ravi["Ngay25"] = _data.Rows[i]["Ngay25"].ToString();
                _ravi["Ngay26"] = _data.Rows[i]["Ngay26"].ToString();
                _ravi["Ngay27"] = _data.Rows[i]["Ngay27"].ToString();
                _ravi["Ngay28"] = _data.Rows[i]["Ngay28"].ToString();
                _ravi["Ngay29"] = _data.Rows[i]["Ngay29"].ToString();
                _ravi["Ngay30"] = _data.Rows[i]["Ngay30"].ToString();
                _ravi["Ngay31"] = _data.Rows[i]["Ngay31"].ToString();
                _ravi["Tong"] = _data.Rows[i]["Tong"].ToString();
                ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;

        }
    }
}
