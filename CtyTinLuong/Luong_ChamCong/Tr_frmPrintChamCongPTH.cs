﻿using System;
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
    public partial class Tr_frmPrintChamCongPTH : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintChamCongPTH(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmBangChamCong_TBX_Load(object sender, EventArgs e)
        {
            TrPrintChamCongPTH xtr111 = new TrPrintChamCongPTH(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

                //
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["MaDinhMucLuongCongNhat"] = _data.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                _ravi["Cong"] = _data.Rows[i]["Cong"].ToString();
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
