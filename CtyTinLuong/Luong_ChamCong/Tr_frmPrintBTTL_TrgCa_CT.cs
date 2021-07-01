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
    public partial class Tr_frmPrintBTTL_TrgCa_CT : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintBTTL_TrgCa_CT(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmPrintBTTL_TrgCa_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TrgCa_CT xtr111 = new Tr_PrintBTTL_TrgCa_CT(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbBTTL_TrgCa_CT.NewRow();

                //
                _ravi["STT"] = (i + 1).ToString();
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["NgayCong"] = _data.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                _ravi["TongTien"] = _data.Rows[i]["Cong"].ToString();
                
                _ravi["TrachNhiem"] = Convert.ToDouble(_data.Rows[i]["Ngay13"].ToString());
                _ravi["TongLuong"] = Convert.ToDouble(_data.Rows[i]["Ngay14"].ToString());
                _ravi["BaoHiem"] = Convert.ToDouble(_data.Rows[i]["Ngay15"].ToString());
                _ravi["TamUng"] = Convert.ToDouble(_data.Rows[i]["Ngay16"].ToString());
                _ravi["ThucNhan"] = Convert.ToDouble(_data.Rows[i]["Ngay17"].ToString());
                
                ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_TrgCa_CT;
            xtr111.DataMember = "tbBTTL_TrgCa_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
