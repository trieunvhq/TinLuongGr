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
    public partial class Tr_frmPrintBTTL_TDB_TQ : Form
    {
        private int _thang;
        private int _nam;
        private DataTable _data;

        public Tr_frmPrintBTTL_TDB_TQ(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TDB_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TDB_TQ xtr111 = new Tr_PrintBTTL_TDB_TQ(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbBTTL_TGD_CT.NewRow();
                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = _data.Rows[i]["DonViTinh"].ToString();
                _ravi["SanLuong"] = _data.Rows[i]["SanLuong"].ToString();
                _ravi["DonGia"] = _data.Rows[i]["DonGia"].ToString();
                _ravi["ThanhTien"] = _data.Rows[i]["ThanhTien"].ToString();
                _ravi["LuongTrachNhiem"] = _data.Rows[i]["LuongTrachNhiem"].ToString();
                _ravi["TongTien"] = _data.Rows[i]["TongTien"].ToString();
                _ravi["TamUng"] = _data.Rows[i]["TamUng"].ToString();
                _ravi["ThucNhan"] = _data.Rows[i]["ThucNhan"].ToString();

                ds.tbBTTL_TGD_CT.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_TGD_CT;
            xtr111.DataMember = "tbBTTL_TGD_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

    }
}
