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

            for (int i = 0; i < _data.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()) == 0)
                    _ravi["Ngay1"] = "";
                else 
                    _ravi["Ngay1"] = _data.Rows[i]["Ngay1"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()) == 0)
                    _ravi["Ngay2"] = "";
                else
                    _ravi["Ngay2"] = _data.Rows[i]["Ngay2"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()) == 0)
                    _ravi["Ngay3"] = "";
                else
                    _ravi["Ngay3"] = _data.Rows[i]["Ngay3"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()) == 0)
                    _ravi["Ngay4"] = "";
                else
                    _ravi["Ngay4"] = _data.Rows[i]["Ngay4"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()) == 0)
                    _ravi["Ngay5"] = "";
                else
                    _ravi["Ngay5"] = _data.Rows[i]["Ngay5"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()) == 0)
                    _ravi["Ngay6"] = "";
                else
                    _ravi["Ngay6"] = _data.Rows[i]["Ngay6"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()) == 0)
                    _ravi["Ngay7"] = "";
                else
                    _ravi["Ngay7"] = _data.Rows[i]["Ngay7"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()) == 0)
                    _ravi["Ngay8"] = "";
                else
                    _ravi["Ngay8"] = _data.Rows[i]["Ngay8"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()) == 0)
                    _ravi["Ngay9"] = "";
                else
                    _ravi["Ngay9"] = _data.Rows[i]["Ngay9"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()) == 0)
                    _ravi["Ngay10"] = "";
                else
                    _ravi["Ngay10"] = _data.Rows[i]["Ngay10"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()) == 0)
                    _ravi["Ngay11"] = "";
                else
                    _ravi["Ngay11"] = _data.Rows[i]["Ngay11"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()) == 0)
                    _ravi["Ngay12"] = "";
                else
                    _ravi["Ngay12"] = _data.Rows[i]["Ngay12"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()) == 0)
                    _ravi["Ngay13"] = "";
                else
                    _ravi["Ngay13"] = _data.Rows[i]["Ngay13"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()) == 0)
                    _ravi["Ngay14"] = "";
                else
                    _ravi["Ngay14"] = _data.Rows[i]["Ngay14"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()) == 0)
                    _ravi["Ngay15"] = "";
                else
                    _ravi["Ngay15"] = _data.Rows[i]["Ngay15"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()) == 0)
                    _ravi["Ngay16"] = "";
                else
                    _ravi["Ngay16"] = _data.Rows[i]["Ngay16"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()) == 0)
                    _ravi["Ngay17"] = "";
                else
                    _ravi["Ngay17"] = _data.Rows[i]["Ngay17"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()) == 0)
                    _ravi["Ngay18"] = "";
                else
                    _ravi["Ngay18"] = _data.Rows[i]["Ngay18"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()) == 0)
                    _ravi["Ngay19"] = "";
                else
                    _ravi["Ngay19"] = _data.Rows[i]["Ngay19"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()) == 0)
                    _ravi["Ngay20"] = "";
                else
                    _ravi["Ngay20"] = _data.Rows[i]["Ngay20"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()) == 0)
                    _ravi["Ngay21"] = "";
                else
                    _ravi["Ngay21"] = _data.Rows[i]["Ngay21"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()) == 0)
                    _ravi["Ngay22"] = "";
                else
                    _ravi["Ngay22"] = _data.Rows[i]["Ngay22"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()) == 0)
                    _ravi["Ngay23"] = "";
                else
                    _ravi["Ngay23"] = _data.Rows[i]["Ngay23"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()) == 0)
                    _ravi["Ngay24"] = "";
                else
                    _ravi["Ngay24"] = _data.Rows[i]["Ngay24"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()) == 0)
                    _ravi["Ngay25"] = "";
                else
                    _ravi["Ngay25"] = _data.Rows[i]["Ngay25"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()) == 0)
                    _ravi["Ngay26"] = "";
                else
                    _ravi["Ngay26"] = _data.Rows[i]["Ngay26"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()) == 0)
                    _ravi["Ngay27"] = "";
                else
                    _ravi["Ngay27"] = _data.Rows[i]["Ngay27"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()) == 0)
                    _ravi["Ngay28"] = "";
                else
                    _ravi["Ngay28"] = _data.Rows[i]["Ngay28"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()) == 0)
                    _ravi["Ngay29"] = "";
                else
                    _ravi["Ngay29"] = _data.Rows[i]["Ngay29"].ToString();


                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()) == 0)
                    _ravi["Ngay30"] = "";
                else
                    _ravi["Ngay30"] = _data.Rows[i]["Ngay30"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()) == 0)
                    _ravi["Ngay31"] = "";
                else
                    _ravi["Ngay31"] = _data.Rows[i]["Ngay31"].ToString();

                if (CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString()) == 0)
                    _ravi["Tong"] = "";
                else
                    _ravi["Tong"] = _data.Rows[i]["Tong"].ToString();

                //_ravi["Ngay2"] = _data.Rows[i]["Ngay2"].ToString();
                //_ravi["Ngay3"] = _data.Rows[i]["Ngay3"].ToString();
                //_ravi["Ngay4"] = _data.Rows[i]["Ngay4"].ToString();
                //_ravi["Ngay5"] = _data.Rows[i]["Ngay5"].ToString();
                //_ravi["Ngay6"] = _data.Rows[i]["Ngay6"].ToString();
                //_ravi["Ngay7"] = _data.Rows[i]["Ngay7"].ToString();
                //_ravi["Ngay8"] = _data.Rows[i]["Ngay8"].ToString();
                //_ravi["Ngay9"] = _data.Rows[i]["Ngay9"].ToString();
                //_ravi["Ngay10"] = _data.Rows[i]["Ngay10"].ToString();
                //_ravi["Ngay11"] = _data.Rows[i]["Ngay11"].ToString();
                //_ravi["Ngay12"] = _data.Rows[i]["Ngay12"].ToString();
                //_ravi["Ngay13"] = _data.Rows[i]["Ngay13"].ToString();
                //_ravi["Ngay14"] = _data.Rows[i]["Ngay14"].ToString();
                //_ravi["Ngay15"] = _data.Rows[i]["Ngay15"].ToString();
                //_ravi["Ngay16"] = _data.Rows[i]["Ngay16"].ToString();
                //_ravi["Ngay17"] = _data.Rows[i]["Ngay17"].ToString();
                //_ravi["Ngay18"] = _data.Rows[i]["Ngay18"].ToString();
                //_ravi["Ngay19"] = _data.Rows[i]["Ngay19"].ToString();
                //_ravi["Ngay20"] = _data.Rows[i]["Ngay20"].ToString();
                //_ravi["Ngay21"] = _data.Rows[i]["Ngay21"].ToString();
                //_ravi["Ngay22"] = _data.Rows[i]["Ngay22"].ToString();
                //_ravi["Ngay23"] = _data.Rows[i]["Ngay23"].ToString();
                //_ravi["Ngay24"] = _data.Rows[i]["Ngay24"].ToString();
                //_ravi["Ngay25"] = _data.Rows[i]["Ngay25"].ToString();
                //_ravi["Ngay26"] = _data.Rows[i]["Ngay26"].ToString();
                //_ravi["Ngay27"] = _data.Rows[i]["Ngay27"].ToString();
                //_ravi["Ngay28"] = _data.Rows[i]["Ngay28"].ToString();
                //_ravi["Ngay29"] = _data.Rows[i]["Ngay29"].ToString();
                //_ravi["Ngay30"] = _data.Rows[i]["Ngay30"].ToString();
                //_ravi["Ngay31"] = _data.Rows[i]["Ngay31"].ToString();
                //_ravi["Tong"] = _data.Rows[i]["Tong"].ToString();

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
