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
    public partial class Tr_frmPrintBTTL_PhuMC_TQ : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintBTTL_PhuMC_TQ(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private List<int> ds_id_congnhan = new List<int>();

        private void Tr_frmPrintBTTL_PhuMC_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_PhuMC_TQ xtr111 = new Tr_PrintBTTL_PhuMC_TQ(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            int ID_congNhanRoot = -1;

            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                DataRow _ravi = ds.tbBTTL_PhuMC_CT.NewRow();

                int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());

                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                if (i < _data.Rows.Count -1)
                {
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ID_congNhanRoot = ID_congNhan;
                        _ravi["STT"] = _data.Rows[i]["STT"].ToString();
                        _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                    }
                    else
                    {
                        _ravi["STT"] = "";
                        _ravi["TenNhanVien"] = "";
                    }
                }
                
                _ravi["Cong"] = _data.Rows[i]["TenLoaiCong"].ToString();
                _ravi["NgayCong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString()).ToString("N2");
                _ravi["LuongCoBan"] = _data.Rows[i]["DonGia"].ToString();
                _ravi["TongLuong"] = _data.Rows[i]["TongLuong"].ToString();
                _ravi["TrachNhiem"] = _data.Rows[i]["LuongTrachNhiem"].ToString();
                _ravi["TongTien"] = _data.Rows[i]["TongTien"].ToString();
                _ravi["TamUng"] = _data.Rows[i]["TamUng"].ToString();
                _ravi["ThucNhan"] = _data.Rows[i]["ThucNhan"].ToString();
                ds.tbBTTL_PhuMC_CT.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_PhuMC_CT;
            xtr111.DataMember = "tbBTTL_PhuMC_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
