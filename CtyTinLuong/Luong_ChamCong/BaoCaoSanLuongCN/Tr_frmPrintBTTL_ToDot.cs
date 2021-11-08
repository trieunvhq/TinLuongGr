using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmPrintBTTL_ToDot : Form
    {

        public int _nam, _thang;
        private DataTable _data;
        private int[] _colDelete;
        private bool _isTo1;


        public Tr_frmPrintBTTL_ToDot(int thang, int nam, DataTable data, int[] colDelete, bool isTo1)
        {
            _isTo1 = isTo1;
            _data = data;
            _thang = thang;
            _nam = nam;
            _colDelete = colDelete;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmBangChamCong_TBX_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_ToDot xtr111 = new Tr_PrintBTTL_ToDot(_thang, _nam, _colDelete, _isTo1);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.Tr_BTTL_ToDot.NewRow();


                _ravi["NgayThang"] = _data.Rows[i]["NgayThang"].ToString();
                _ravi["DonViTinh"] = _data.Rows[i]["DonViTinh"].ToString();
                _ravi["Dot4_8_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot4_8_Bao"].ToString());
                _ravi["Dot4_8_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot4_8_Kg"].ToString());
                _ravi["Dot36_72_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot36_72_Bao"].ToString());
                _ravi["Dot36_72_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot36_72_Kg"].ToString());
                _ravi["Dot45_90_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot45_90_Bao"].ToString());
                _ravi["Dot45_90_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot45_90_Kg"].ToString());
                _ravi["Dot48_96_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot48_96_Bao"].ToString());
                _ravi["Dot48_96_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot48_96_Kg"].ToString());
                _ravi["Dot56_112_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot56_112_Bao"].ToString());
                _ravi["Dot56_112_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot56_112_Kg"].ToString());
                _ravi["Dot42_84_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot42_84_Bao"].ToString());
                _ravi["Dot42_84_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot42_84_Kg"].ToString());
                _ravi["Dot51_103_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot51_103_Bao"].ToString());
                _ravi["Dot51_103_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot51_103_Kg"].ToString());
                _ravi["Dot51_103tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot51_103tb_Bao"].ToString());
                _ravi["Dot51_103tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot51_103tb_Kg"].ToString());
                _ravi["Dot53_106tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot53_106tb_Bao"].ToString());
                _ravi["Dot53_106tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot53_106tb_Kg"].ToString());
                _ravi["Dot50_100tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot50_100tb_Bao"].ToString());
                _ravi["Dot50_100tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot50_100tb_Kg"].ToString());
                _ravi["Dot11_17tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot11_17tb_Bao"].ToString());
                _ravi["Dot11_17tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot11_17tb_Kg"].ToString());
                _ravi["Dot45_90tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot45_90tb_Bao"].ToString());
                _ravi["Dot45_90tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot45_90tb_Kg"].ToString());
                _ravi["Dot42_84tb_Bao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot42_84tb_Bao"].ToString());
                _ravi["Dot42_84tb_Kg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Dot42_84tb_Kg"].ToString());
                _ravi["TongBao"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongBao"].ToString());
                _ravi["TongKg"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongKg"].ToString());
                _ravi["DonGia_Tan"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Tan"].ToString());
                _ravi["TongBaotb"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongBaotb"].ToString());
                _ravi["TongKgtb"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongKgtb"].ToString());
                _ravi["DonGiatb_Tan"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGiatb_Tan"].ToString());
                _ravi["ThanhTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThanhTien"].ToString());
                ds.Tr_BTTL_ToDot.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.Tr_BTTL_ToDot;
            xtr111.DataMember = "Tr_BTTL_ToDot";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
