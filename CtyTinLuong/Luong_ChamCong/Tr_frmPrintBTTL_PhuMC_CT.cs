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
    public partial class Tr_frmPrintBTTL_PhuMC_CT : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintBTTL_PhuMC_CT(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmPrintBTTL_PhuMC_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_PhuMC_CT xtr111 = new Tr_PrintBTTL_PhuMC_CT(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbBTTL_PhuMC_CT.NewRow();

                //
                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["Cong"] = _data.Rows[i]["TenVTHH"].ToString();
                _ravi["NgayCong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString()).ToString("N1");
                _ravi["LuongCoBan"] = _data.Rows[i]["DonGia"].ToString();
                _ravi["TongLuong"] = _data.Rows[i]["TongLuong"].ToString();
                _ravi["TrachNhiem"] = _data.Rows[i]["LuongTrachNhiem"].ToString();
                _ravi["TamUng"] = _data.Rows[i]["TamUng"].ToString();
                _ravi["ThucNhan"] = _data.Rows[i]["ThucNhan"].ToString();
                ds.tbBTTL_PhuMC_CT.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_PhuMC_CT;
            xtr111.DataMember = "tbBTTL_PhuMC_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
