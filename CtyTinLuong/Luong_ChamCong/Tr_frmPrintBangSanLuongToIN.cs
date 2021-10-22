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
    public partial class Tr_frmPrintBangSanLuongToIN : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintBangSanLuongToIN(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
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

        private void Tr_frmPrintBangSanLuongToIN_Load(object sender, EventArgs e)
        {
            TrPrintBangSanLuongToIN xtr111 = new TrPrintBangSanLuongToIN(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.Tr_BangSanLuongToIN.NewRow();

                //
                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["HinhThuc"] = _data.Rows[i]["HinhThuc"].ToString();
                _ravi["Ngay1"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString());
                _ravi["Ngay2"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString());
                _ravi["Ngay3"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString());
                _ravi["Ngay4"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString());
                _ravi["Ngay5"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString());
                _ravi["Ngay6"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString());
                _ravi["Ngay7"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString());
                _ravi["Ngay8"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString());
                _ravi["Ngay9"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString());
                _ravi["Ngay10"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString());
                _ravi["Ngay11"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString());
                _ravi["Ngay12"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString());
                _ravi["Ngay13"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString());
                _ravi["Ngay14"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString());
                _ravi["Ngay15"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString());
                _ravi["Ngay16"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString());
                _ravi["Ngay17"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString());
                _ravi["Ngay18"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString());
                _ravi["Ngay19"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString());
                _ravi["Ngay20"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString());
                _ravi["Ngay21"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString());
                _ravi["Ngay22"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString());
                _ravi["Ngay23"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString());
                _ravi["Ngay24"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString());
                _ravi["Ngay25"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString());
                _ravi["Ngay26"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString());
                _ravi["Ngay27"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString());
                _ravi["Ngay28"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString());
                _ravi["Ngay29"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString());
                _ravi["Ngay30"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString());
                _ravi["Ngay31"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString());
                _ravi["Tong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString());
                _ravi["SLGiayCuon"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SLGiayCuon"].ToString());
                _ravi["VuotSL"] = CheckString.ConvertToDouble_My(_data.Rows[i]["VuotSL"].ToString());

                ds.Tr_BangSanLuongToIN.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.Tr_BangSanLuongToIN;
            xtr111.DataMember = "Tr_BangSanLuongToIN";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
