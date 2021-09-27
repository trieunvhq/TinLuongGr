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
    public partial class Tr_frmPrintBTTL_TDB_CT_Old : Form
    {
        private int _thang;
        private int _nam;
        DataTable _data;
        public Tr_frmPrintBTTL_TDB_CT_Old(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TDB_CT_Load(object sender, EventArgs e)
        {
            DataSet_TinLuong ds = new DataSet_TinLuong();


            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbBTTL_TGD_CT.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                if (string.IsNullOrEmpty(_data.Rows[i]["TongTien"].ToString()))
                {
                    _ravi["TongTien"] = 0;
                }
                else _ravi["TongTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongTien"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["LuongTrachNhiem"].ToString()))
                {
                    _ravi["LuongTrachNhiem"] = 0;
                }
                else _ravi["LuongTrachNhiem"] = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongTrachNhiem"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["SoNgayAn"].ToString()))
                {
                    _ravi["SoNgayAn"] = 0;
                }
                else _ravi["SoNgayAn"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["TruTienCom"].ToString()))
                {
                    _ravi["TruTienCom"] = 0;
                }
                else _ravi["TruTienCom"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["TamUng"].ToString()))
                {
                    _ravi["TamUng"] = 0;
                }
                else _ravi["TamUng"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["ThucNhan"].ToString()))
                {
                    _ravi["ThucNhan"] = 0;
                }
                else _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThucNhan"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["DonGia"].ToString()))
                {
                    _ravi["DonGia"] = 0;
                }
                else _ravi["DonGia"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["ThanhTien"].ToString()))
                {
                    _ravi["ThanhTien"] = 0;
                }
                else _ravi["ThanhTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThanhTien"].ToString());

                if (string.IsNullOrEmpty(_data.Rows[i]["SanLuong"].ToString()))
                {
                    _ravi["SanLuong"] = 0;
                }
                else _ravi["SanLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());

                ds.tbBTTL_TGD_CT.Rows.Add(_ravi);
            }

            Tr_PrintBTTL_TDB_CT_old xtr111 = new Tr_PrintBTTL_TDB_CT_old(_thang, _nam);
            xtr111.DataSource = null;
            //xtr111.DataSource = LoadData();

            xtr111.DataSource = ds.tbBTTL_TGD_CT;
            xtr111.DataMember = "tbBTTL_TGD_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
