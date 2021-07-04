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
    public partial class Tr_frmPrintBTTL_TMC_TQ : Form
    {
        private int _thang;
        private int _nam;
        private DataTable _data;

        public Tr_frmPrintBTTL_TMC_TQ(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TMC_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TMC_TQ xtr111 = new Tr_PrintBTTL_TMC_TQ(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();


            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            using (clsThin clsThin_ = new clsThin())
            {
                for (int i = 0; i < _data.Rows.Count -1; ++i)
                {
                    DataRow _ravi = ds.tbBTTL_TMC_CT.NewRow();

                    _ravi["STT"] = (i + 1).ToString();
                    _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                    _ravi["Cong"] = _data.Rows[i]["sCong"].ToString();
                    _ravi["SanLuong"] = Convert.ToDouble(_data.Rows[i]["sSanLuong"].ToString());
                    _ravi["DonGia"] = Convert.ToDouble(_data.Rows[i]["sDonGia"].ToString());
                    _ravi["ThanhTien"] = Convert.ToDouble(_data.Rows[i]["sThanhTien"].ToString());
                    _ravi["XangXe"] = Convert.ToDouble(_data.Rows[i]["sXangXe"].ToString());
                    _ravi["Tong"] = Convert.ToDouble(_data.Rows[i]["sTong"].ToString());
                    _ravi["TruTienCom"] = 0;
                    _ravi["BaoHiem"] = Convert.ToDouble(_data.Rows[i]["sBaoHiem"].ToString());
                    _ravi["TamUng"] = 0;
                    _ravi["ThucNhan"] = Convert.ToDouble(_data.Rows[i]["sThucNhan"].ToString());

                    ds.tbBTTL_TMC_CT.Rows.Add(_ravi);
                }
            }

            xtr111.DataSource = null;

            xtr111.DataSource = ds.tbBTTL_TMC_CT;
            xtr111.DataMember = "tbBTTL_TMC_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
