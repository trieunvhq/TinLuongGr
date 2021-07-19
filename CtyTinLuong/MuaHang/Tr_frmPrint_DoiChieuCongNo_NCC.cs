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
        private string _TaiKhoan, _DoiTuong;


        public Tr_frmPrint_DoiChieuCongNo_NCC(DateTime tuNgay, DateTime denNgay, DataTable data, string TaiKhoan, string DoiTuong)
        {
            _data = data;
            _tuNgay = tuNgay;
            _denNgay = denNgay;
            _TaiKhoan = TaiKhoan;
            _DoiTuong = DoiTuong;

            InitializeComponent();
        }

        //
        private void Tr_frmPrint_DoiChieuCongNo_NCC_Load(object sender, EventArgs e)
        {
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbMH_DoiChieuCongNo_Khach.NewRow();

                //
                _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                _ravi["NgayThang"] = _data.Rows[i]["NgayThang"].ToString();
                _ravi["DienGiai"] = _data.Rows[i]["DienGiai"].ToString();
                _ravi["SoChungTu"] = _data.Rows[i]["SoChungTu"].ToString();
                _ravi["TaiKhoanDoiUng"] = "";

                if (_data.Rows[i]["SoLuong"].ToString() == "")
                {
                    _ravi["SoLuong"] = "";
                }
                else
                {
                    _ravi["SoLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SoLuong"].ToString()).ToString("N2");
                }

                //
                if (_data.Rows[i]["DonGia"].ToString() == "")
                {
                    _ravi["DonGia"] = "";
                }
                else
                {
                    _ravi["DonGia"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia"].ToString()).ToString("N2");
                }

                //
                if (_data.Rows[i]["ThanhTien"].ToString() == "")
                {
                    _ravi["ThanhTien"] = "";
                }
                else
                {
                    _ravi["ThanhTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThanhTien"].ToString()).ToString("N2");
                }


                //
                if (_data.Rows[i]["No"].ToString() == "")
                {
                    _ravi["No"] = "";
                }
                else
                {
                    _ravi["No"] = CheckString.ConvertToDouble_My(_data.Rows[i]["No"].ToString()).ToString("N2");
                }


                //
                if (_data.Rows[i]["Co"].ToString() == "")
                {
                    _ravi["Co"] = "";
                }
                else
                {
                    _ravi["Co"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Co"].ToString()).ToString("N2");
                }

                ds.tbMH_DoiChieuCongNo_Khach.Rows.Add(_ravi);
            }

            Tr_Xtra_DoiChieuCongNo_Khach xtr111 = new Tr_Xtra_DoiChieuCongNo_Khach(_tuNgay, _denNgay, _TaiKhoan, _DoiTuong);
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbMH_DoiChieuCongNo_Khach;
            xtr111.DataMember = "tbMH_DoiChieuCongNo_Khach";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
