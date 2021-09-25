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
    public partial class Tr_frmPrintBTTL_TMC_CT : Form
    {
        private int _thang;
        private int _nam;
        private DataTable _data;

        public Tr_frmPrintBTTL_TMC_CT(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TMC_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TMC_CT xtr111 = new Tr_PrintBTTL_TMC_CT(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbBTTL_TMC_CT.NewRow();

                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["Cong"] = _data.Rows[i]["Cong"].ToString();
                _ravi["SanLuong"] = _data.Rows[i]["SanLuong"].ToString();
                _ravi["DonGia"] = _data.Rows[i]["DonGia"].ToString();
                _ravi["ThanhTien"] = _data.Rows[i]["ThanhTien"].ToString();
                _ravi["XangXe"] = _data.Rows[i]["XangXe"].ToString();
                _ravi["Tong"] = _data.Rows[i]["Tong"].ToString();
                _ravi["BaoHiem"] = _data.Rows[i]["BaoHiem"].ToString();
                _ravi["ThucNhan"] = _data.Rows[i]["ThucNhan"].ToString();

                ds.tbBTTL_TMC_CT.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;

            xtr111.DataSource = ds.tbBTTL_TMC_CT;
            xtr111.DataMember = "tbBTTL_TMC_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
