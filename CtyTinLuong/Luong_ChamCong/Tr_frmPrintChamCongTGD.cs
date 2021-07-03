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
    public partial class Tr_frmPrintChamCongTGD : Form
    {
        private int _thang;
        private int _nam;
        DataTable _data;
        public Tr_frmPrintChamCongTGD(int thang, int nam, DataTable data)
        {
            _thang = thang;
            _nam = nam;
            _data = data;
            InitializeComponent();
        }

        private void Tr_frmPrintChamCongTGD_Load(object sender, EventArgs e)
        {
            Tr_PrintChamCongTGD xtr111 = new Tr_PrintChamCongTGD(_thang, _nam);

            DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbCongNhatChamCongToGapDan.Clone();
            //ds.tbCongNhatChamCongToGapDan.Clear();
            //clsThin cls1 = new clsThin();

            //DataTable _data = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");

            for (int i = 0; i < _data.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["Ngay1"] = Convert.ToDouble(_data.Rows[i]["Ngay1"].ToString());
                _ravi["Ngay2"] = Convert.ToDouble(_data.Rows[i]["Ngay2"].ToString());
                _ravi["Ngay3"] = Convert.ToDouble(_data.Rows[i]["Ngay3"].ToString());
                _ravi["Ngay4"] = Convert.ToDouble(_data.Rows[i]["Ngay4"].ToString());
                _ravi["Ngay5"] = Convert.ToDouble(_data.Rows[i]["Ngay5"].ToString());
                _ravi["Ngay6"] = Convert.ToDouble(_data.Rows[i]["Ngay6"].ToString());
                _ravi["Ngay7"] = Convert.ToDouble(_data.Rows[i]["Ngay7"].ToString());
                _ravi["Ngay8"] = Convert.ToDouble(_data.Rows[i]["Ngay8"].ToString());
                _ravi["Ngay9"] = Convert.ToDouble(_data.Rows[i]["Ngay9"].ToString());
                _ravi["Ngay10"] = Convert.ToDouble(_data.Rows[i]["Ngay10"].ToString());
                _ravi["Ngay11"] = Convert.ToDouble(_data.Rows[i]["Ngay11"].ToString());
                _ravi["Ngay12"] = Convert.ToDouble(_data.Rows[i]["Ngay12"].ToString());
                _ravi["Ngay13"] = Convert.ToDouble(_data.Rows[i]["Ngay13"].ToString());
                _ravi["Ngay14"] = Convert.ToDouble(_data.Rows[i]["Ngay14"].ToString());
                _ravi["Ngay15"] = Convert.ToDouble(_data.Rows[i]["Ngay15"].ToString());
                _ravi["Ngay16"] = Convert.ToDouble(_data.Rows[i]["Ngay16"].ToString());
                _ravi["Ngay17"] = Convert.ToDouble(_data.Rows[i]["Ngay17"].ToString());
                _ravi["Ngay18"] = Convert.ToDouble(_data.Rows[i]["Ngay18"].ToString());
                _ravi["Ngay19"] = Convert.ToDouble(_data.Rows[i]["Ngay19"].ToString());
                _ravi["Ngay20"] = Convert.ToDouble(_data.Rows[i]["Ngay20"].ToString());
                _ravi["Ngay21"] = Convert.ToDouble(_data.Rows[i]["Ngay21"].ToString());
                _ravi["Ngay22"] = Convert.ToDouble(_data.Rows[i]["Ngay22"].ToString());
                _ravi["Ngay23"] = Convert.ToDouble(_data.Rows[i]["Ngay23"].ToString());
                _ravi["Ngay24"] = Convert.ToDouble(_data.Rows[i]["Ngay24"].ToString());
                _ravi["Ngay25"] = Convert.ToDouble(_data.Rows[i]["Ngay25"].ToString());
                _ravi["Ngay26"] = Convert.ToDouble(_data.Rows[i]["Ngay26"].ToString());
                _ravi["Ngay27"] = Convert.ToDouble(_data.Rows[i]["Ngay27"].ToString());
                _ravi["Ngay28"] = Convert.ToDouble(_data.Rows[i]["Ngay28"].ToString());
                _ravi["Ngay29"] = Convert.ToDouble(_data.Rows[i]["Ngay29"].ToString());
                _ravi["Ngay30"] = Convert.ToDouble(_data.Rows[i]["Ngay30"].ToString());
                _ravi["Ngay31"] = Convert.ToDouble(_data.Rows[i]["Ngay31"].ToString());
                _ravi["Tong"] = Convert.ToDouble(_data.Rows[i]["Tong"].ToString());
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";

            //xtr111.DataSource = null;
            //xtr111.DataSource = _data;


            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
