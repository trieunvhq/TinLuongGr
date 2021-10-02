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
    public partial class Tr_frmPrintBTTL_TBX_CT : Form
    {
        private int _thang;
        private int _nam;
        private DataTable _data;

        public Tr_frmPrintBTTL_TBX_CT(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TBX_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TBX_CT xtr111 = new Tr_PrintBTTL_TBX_CT(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbBTTL_TBX_CT.NewRow();

                //
                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();
                _ravi["DonGia"] = _data.Rows[i]["DonGia"].ToString();       //Lương cơ bản
                _ravi["SanLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString()).ToString("N1");   //Ngày công
                _ravi["TongLuong"] = _data.Rows[i]["TongLuong"].ToString();  //Tổng
                _ravi["LuongTrachNhiem"] = _data.Rows[i]["LuongTrachNhiem"].ToString();
                _ravi["TongTien"] = _data.Rows[i]["TongTien"].ToString();
                _ravi["TamUng"] = _data.Rows[i]["TamUng"].ToString();
                _ravi["ThucNhan"] = _data.Rows[i]["ThucNhan"].ToString();

                ds.tbBTTL_TBX_CT.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_TBX_CT;
            xtr111.DataMember = "tbBTTL_TBX_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
