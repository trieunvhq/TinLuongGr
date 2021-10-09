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
    public partial class Tr_frmPrintBTTL_PKToan_TQ : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintBTTL_PKToan_TQ(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmPrintBTTL_PKToan_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_PKToan_TQ xtr111 = new Tr_PrintBTTL_PKToan_TQ(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            int ID_congNhanRoot = -1;

            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbBTTL_PKToan_CT.NewRow();
                int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());

                if (ID_congNhanRoot != ID_congNhan)
                {
                    ID_congNhanRoot = ID_congNhan;
                    _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                    _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                }
                else
                {
                    _ravi["STT"] = "";
                    _ravi["TenNhanVien"] = "";
                }

                _ravi["Cong"] = _data.Rows[i]["TenLoaiCong"].ToString();

                _ravi["NgayCong"] = _data.Rows[i]["SanLuong"].ToString();
                _ravi["LuongCoBan"] = _data.Rows[i]["DonGia"].ToString();

                if (_data.Rows[i]["LuongTrachNhiem"].ToString() != "")
                {
                    _ravi["TrachNhiem"] = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongTrachNhiem"].ToString());
                }
                else _ravi["TrachNhiem"] = 0;

                if (_data.Rows[i]["TongLuong"].ToString() != "")
                {
                    _ravi["TongTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongLuong"].ToString());
                }
                else _ravi["TongTien"] = 0;

                if (_data.Rows[i]["PhuCap"].ToString() != "")
                {
                    _ravi["PhuCap"] = CheckString.ConvertToDouble_My(_data.Rows[i]["PhuCap"].ToString());
                }
                else _ravi["PhuCap"] = 0;

                if (_data.Rows[i]["BaoHiem"].ToString() != "")
                {
                    _ravi["BaoHiem"] = CheckString.ConvertToDouble_My(_data.Rows[i]["BaoHiem"].ToString());
                }
                else _ravi["BaoHiem"] = 0;

                if (_data.Rows[i]["TongTien"].ToString() != "")
                {
                    _ravi["TongLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongTien"].ToString());
                }
                else _ravi["TongLuong"] = 0;

                if (_data.Rows[i]["TamUng"].ToString() != "")
                {
                    _ravi["TamUng"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng"].ToString());
                }
                else _ravi["TamUng"] = 0;

                if (_data.Rows[i]["ThucNhan"].ToString() != "")
                {
                    _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThucNhan"].ToString());
                }
                else _ravi["ThucNhan"] = 0;

                ds.tbBTTL_PKToan_CT.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_PKToan_CT;
            xtr111.DataMember = "tbBTTL_PKToan_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
