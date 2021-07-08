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
    public partial class Tr_frmPrint_DoiChieuCongNo_NCC : Form
    {

        public DateTime _tuNgay, _denNgay;
        private DataTable _data;


        public Tr_frmPrint_DoiChieuCongNo_NCC(DateTime tuNgay, DateTime denNgay, DataTable data)
        {
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;

            InitializeComponent();
        }

        //
        private void Tr_frmPrint_DoiChieuCongNo_NCC_Load(object sender, EventArgs e)
        {
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbBH_DoiChieuCongNo_NCC.NewRow();

                //
                _ravi["STT"] = (i + 1).ToString();
                _ravi["DoiTuong"] = _data.Rows[i]["DoiTuong"].ToString();
                _ravi["NgayThang"] = Convert.ToDateTime(_data.Rows[i]["NgayThang"].ToString());
                _ravi["DienGiai"] = Convert.ToDouble(_data.Rows[i]["DienGiai"].ToString());
                _ravi["SoLuong"] = Convert.ToDouble(_data.Rows[i]["SoLuong"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(_data.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = Convert.ToDouble(_data.Rows[i]["ThanhTien"].ToString());
                _ravi["No"] = Convert.ToDouble(_data.Rows[i]["No"].ToString());
                _ravi["Co"] = Convert.ToDouble(_data.Rows[i]["Co"].ToString());

                ds.tbBH_DoiChieuCongNo_NCC.Rows.Add(_ravi);
            }

            Tr_Xtra_DoiChieuCongNo_NCC xtr111 = new Tr_Xtra_DoiChieuCongNo_NCC(_tuNgay, _denNgay);
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBH_DoiChieuCongNo_NCC;
            xtr111.DataMember = "tbBH_DoiChieuCongNo_NCC";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
