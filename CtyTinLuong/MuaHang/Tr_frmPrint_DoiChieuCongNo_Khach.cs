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
    public partial class Tr_frmPrint_DoiChieuCongNo_Khach : Form
    {

        public DateTime _tuNgay, _denNgay;
        private DataTable _data;


        public Tr_frmPrint_DoiChieuCongNo_Khach(DateTime tuNgay, DateTime denNgay, DataTable data)
        {
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;

            InitializeComponent();
        }

        //
        private void Tr_frmPrint_DoiChieuCongNo_Khach_Load(object sender, EventArgs e)
        {
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbBH_DoiChieuCongNo_NCC.NewRow();

                //
                _ravi["STT"] = (i + 1).ToString();
                _ravi["DoiTuong"] = _data.Rows[i]["DoiTuong"].ToString();
                _ravi["NgayThang"] = _data.Rows[i]["NgayThang"].ToString();
                _ravi["DienGiai"] = _data.Rows[i]["DienGiai"].ToString();

                if (_data.Rows[i]["SoLuong"].ToString() == "")
                {
                    _ravi["SoLuong"] = "";
                }
                else
                {
                    _ravi["SoLuong"] = Convert.ToDouble(_data.Rows[i]["SoLuong"].ToString()).ToString("N2");
                }

                //
                if (_data.Rows[i]["DonGia"].ToString() == "")
                {
                    _ravi["DonGia"] = "";
                }
                else
                {
                    _ravi["DonGia"] = Convert.ToDouble(_data.Rows[i]["DonGia"].ToString()).ToString("N2");
                }

                //
                if (_data.Rows[i]["ThanhTien"].ToString() == "")
                {
                    _ravi["ThanhTien"] = "";
                }
                else
                {
                    _ravi["ThanhTien"] = Convert.ToDouble(_data.Rows[i]["ThanhTien"].ToString()).ToString("N2");
                }


                //
                if (_data.Rows[i]["No"].ToString() == "")
                {
                    _ravi["No"] = "";
                }
                else
                {
                    _ravi["No"] = Convert.ToDouble(_data.Rows[i]["No"].ToString()).ToString("N2");
                }


                //
                if (_data.Rows[i]["Co"].ToString() == "")
                {
                    _ravi["Co"] = "";
                }
                else
                {
                    _ravi["Co"] = Convert.ToDouble(_data.Rows[i]["Co"].ToString()).ToString("N2");
                }

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
