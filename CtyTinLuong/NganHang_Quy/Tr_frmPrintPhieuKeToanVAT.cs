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
    public partial class Tr_frmPrintPhieuKeToanVAT : Form
    {
        private int _iID_ThuChi;
        public Tr_frmPrintPhieuKeToanVAT(int iID_ThuChi)
        {
            _iID_ThuChi = iID_ThuChi;
            InitializeComponent();
        }

        private void Tr_frmBTTL_TGD_TQ_Load(object sender, EventArgs e)
        {
            using (clsThin cls = new clsThin())
            {
                DataTable _data = cls.Tr_PhieuKeToan_VAT(_iID_ThuChi);

                if (_data.Rows.Count == 0)
                    return;

                Tr_PrintPhieuKeToanVAT xtr111 = new Tr_PrintPhieuKeToanVAT(_data);

                DataSet_TinLuong ds = new DataSet_TinLuong();

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    DataRow _ravi = ds.Tr_PhieuKeToan.NewRow();

                    if (i == 2)
                        _ravi["SoTaiKhoanCon"] = "      " +  _data.Rows[i]["SoTaiKhoanCon"].ToString();
                    else
                        _ravi["SoTaiKhoanCon"] = " " + _data.Rows[i]["SoTaiKhoanCon"].ToString();

                    _ravi["TenTaiKhoanCon"] = _data.Rows[i]["TenTaiKhoanCon"].ToString();

                    if (CheckString.ConvertToDouble_My(_data.Rows[i]["No"].ToString()) == 0)
                        _ravi["No"] = "";
                    else
                        _ravi["No"] = CheckString.ConvertToDouble_My(_data.Rows[i]["No"].ToString()).ToString("N2");

                    if (CheckString.ConvertToDouble_My(_data.Rows[i]["Co"].ToString()) == 0)
                        _ravi["Co"] = "";
                    else
                        _ravi["Co"] = CheckString.ConvertToDouble_My(_data.Rows[i]["Co"].ToString()).ToString("N2");

                    if (CheckString.ConvertToDouble_My(_data.Rows[i]["TongNo"].ToString()) == 0)
                        _ravi["TongNo"] = "";
                    else
                        _ravi["TongNo"]  = CheckString.ConvertToDouble_My(_data.Rows[i]["TongNo"].ToString()).ToString("N2");

                    if (CheckString.ConvertToDouble_My(_data.Rows[i]["TongCo"].ToString()) == 0)
                        _ravi["TongCo"] = "";
                    else
                        _ravi["TongCo"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongCo"].ToString()).ToString("N2");

                    _ravi["SoChungTu"] = _data.Rows[i]["SoChungTu"].ToString();
                    _ravi["NgayChungTu"] = _data.Rows[i]["NgayChungTu"].ToString();
                    _ravi["TenDoiTuong"] = _data.Rows[i]["TenDoiTuong"].ToString();
                    _ravi["DiaChi"] = _data.Rows[i]["DiaChi"].ToString();
                    _ravi["DienGiai"] = _data.Rows[i]["DienGiai"].ToString();
                    ds.Tr_PhieuKeToan.Rows.Add(_ravi);
                }
                xtr111.DataSource = null;
                xtr111.DataSource = ds.Tr_PhieuKeToan;
                xtr111.DataMember = "Tr_PhieuKeToan";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;

            }

            
        }

    }
}
