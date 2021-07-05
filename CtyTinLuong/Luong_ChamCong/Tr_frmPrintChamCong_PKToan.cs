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
    public partial class Tr_frmPrintChamCong_PKToan : Form
    {

        public int _nam, _thang;
        private DataTable _data;


        public Tr_frmPrintChamCong_PKToan(int thang, int nam, DataTable data)
        {
            _data = data;
            _thang = thang;
            _nam = nam;

            InitializeComponent();
        }

        //
        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");

                }
            }
            return _id_bophan;
        }

        private void Tr_frmPrintChamCong_PKToan_Load(object sender, EventArgs e)
        {
            //clsThin clsThin_ = new clsThin();
            //_data = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, KiemTraTenBoPhan("Phòng Kế toán"), 0, "");

            TrPrintChamCong_PKToan xtr111 = new TrPrintChamCong_PKToan(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();
           
            for (int i = 0; i < _data.Rows.Count -1; ++i)
            {
                DataRow _ravi = ds.tbCongNhatChamCongToGapDan.NewRow();

                //
                _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                _ravi["MaDinhMucLuongCongNhat"] = _data.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                _ravi["Cong"] = _data.Rows[i]["Cong"].ToString();
                _ravi["Ngay1"] = Convert.ToDouble(_data.Rows[i]["Ngay1"].ToString());
                _ravi["Ngay2"] = Convert.ToDouble(_data.Rows[i]["Ngay2"].ToString());
                _ravi["Ngay3"] = Convert.ToDouble(_data.Rows[i]["Ngay3"].ToString());
                _ravi["Ngay4"] = Convert.ToDouble(_data.Rows[i]["Ngay4"].ToString());
                _ravi["Ngay5"] = Convert.ToDouble(_data.Rows[i]["Ngay5"].ToString());
                _ravi["Ngay6"] = Convert.ToDouble(_data.Rows[i]["Ngay6"].ToString());
                _ravi["Ngay7"] = Convert.ToDouble(_data.Rows[i]["Ngay7"].ToString());
                _ravi["Ngay8"] = Convert.ToDouble(_data.Rows[i]["Ngay8"].ToString());
                _ravi["Ngay9"] = Convert.ToDouble(_data.Rows[i]["Ngay9"].ToString());
                _ravi["Ngay10"] = Convert.ToDouble(_data.Rows[i]["Ngay10"].ToString());
                _ravi["Ngay11"] = Convert.ToDouble(_data.Rows[i]["Ngay11"].ToString());
                _ravi["Ngay12"] = Convert.ToDouble(_data.Rows[i]["Ngay12"].ToString());
                _ravi["Ngay13"] = Convert.ToDouble(_data.Rows[i]["Ngay13"].ToString());
                _ravi["Ngay14"] = Convert.ToDouble(_data.Rows[i]["Ngay14"].ToString());
                _ravi["Ngay15"] = Convert.ToDouble(_data.Rows[i]["Ngay15"].ToString());
                _ravi["Ngay16"] = Convert.ToDouble(_data.Rows[i]["Ngay16"].ToString());
                _ravi["Ngay17"] = Convert.ToDouble(_data.Rows[i]["Ngay17"].ToString());
                _ravi["Ngay18"] = Convert.ToDouble(_data.Rows[i]["Ngay18"].ToString());
                _ravi["Ngay19"] = Convert.ToDouble(_data.Rows[i]["Ngay19"].ToString());
                _ravi["Ngay20"] = Convert.ToDouble(_data.Rows[i]["Ngay20"].ToString());
                _ravi["Ngay21"] = Convert.ToDouble(_data.Rows[i]["Ngay21"].ToString());
                _ravi["Ngay22"] = Convert.ToDouble(_data.Rows[i]["Ngay22"].ToString());
                _ravi["Ngay23"] = Convert.ToDouble(_data.Rows[i]["Ngay23"].ToString());
                _ravi["Ngay24"] = Convert.ToDouble(_data.Rows[i]["Ngay24"].ToString());
                _ravi["Ngay25"] = Convert.ToDouble(_data.Rows[i]["Ngay25"].ToString());
                _ravi["Ngay26"] = Convert.ToDouble(_data.Rows[i]["Ngay26"].ToString());
                _ravi["Ngay27"] = Convert.ToDouble(_data.Rows[i]["Ngay27"].ToString());
                _ravi["Ngay28"] = Convert.ToDouble(_data.Rows[i]["Ngay28"].ToString());
                _ravi["Ngay29"] = Convert.ToDouble(_data.Rows[i]["Ngay29"].ToString());
                _ravi["Ngay30"] = Convert.ToDouble(_data.Rows[i]["Ngay30"].ToString());
                _ravi["Ngay31"] = Convert.ToDouble(_data.Rows[i]["Ngay31"].ToString());
                _ravi["Tong"] = Convert.ToDouble(_data.Rows[i]["Tong"].ToString());
                ds.tbCongNhatChamCongToGapDan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
