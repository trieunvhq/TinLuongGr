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
    public partial class Tr_frmPrintSanLuong_CT_Luong_TMC : Form
    {
        private int _thang, _nam, _iiID_CongNhan;
        private string _hoTenNhanVien;
        private DataTable _data, _dataBL;

        public Tr_frmPrintSanLuong_CT_Luong_TMC(int thang, int nam, int iiID_CongNhan, string hoTenNhanVien, DataTable data, DataTable dataBL)
        {
            _dataBL = dataBL;
            _data = data;
            _thang = thang;
            _nam = nam;
            _iiID_CongNhan = iiID_CongNhan;
            _hoTenNhanVien = hoTenNhanVien;

            InitializeComponent();
        }

        private void Tr_frmPrintSanLuong_CT_Luong_TMC_Load(object sender, EventArgs e)
        {
            try
            {
                Tr_PrintSanLuong_CT_Luong_TMC xtr111 = new Tr_PrintSanLuong_CT_Luong_TMC(_thang, _nam, _iiID_CongNhan, _hoTenNhanVien, _dataBL);
                DataSet_TinLuong ds = new DataSet_TinLuong();

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    DataRow _ravi = ds.tbChiTiet_LuongSL.NewRow();

                    _ravi["TenHang"] = _data.Rows[i]["TenVTHH"].ToString();
                    _ravi["NoiDung"] = _data.Rows[i]["MaVT"].ToString();
                    _ravi["Tong"] = _data.Rows[i]["Tong"].ToString();

                    for (int k = 1; k <=31; k++)
                    {
                        _ravi["Ngay" + k] = _data.Rows[i]["Ngay" + k].ToString();
                    }

                    ds.tbChiTiet_LuongSL.Rows.Add(_ravi);
                }

                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbChiTiet_LuongSL;
                xtr111.DataMember = "tbChiTiet_LuongSL";

                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
