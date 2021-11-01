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
    public partial class Tr_frmPrintBTTL_CongNhan_ToDot : Form
    {

        private int _thang, _nam;
        DataTable _data;
        private bool _isTo1;

        public Tr_frmPrintBTTL_CongNhan_ToDot(int thang, int nam, DataTable data, bool isTo1)
        {
            _isTo1 = isTo1;
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmBTTL_TBX_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_CongNhan_ToDot xtr111 = new Tr_PrintBTTL_CongNhan_ToDot(_thang, _nam, _isTo1);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.Tr_ChiaLuongToDot.NewRow();
                _ravi["STT"] = _data.Rows[i]["STT"];
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"];
                _ravi["GioLamViec"] = _data.Rows[i]["GioLV"];
                _ravi["DonGia"] = _data.Rows[i]["DonGia"];
                _ravi["ThanhTien"] = _data.Rows[i]["ThanhTien"];
                ds.Tr_ChiaLuongToDot.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.Tr_ChiaLuongToDot;
            xtr111.DataMember = "Tr_ChiaLuongToDot";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
