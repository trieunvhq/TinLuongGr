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
    public partial class Tr_frmPrintBTTL_TGD_CT : Form
    {
        private int _thang;
        private int _nam;
        public Tr_frmPrintBTTL_TGD_CT(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TGD_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TGD_CT xtr111 = new Tr_PrintBTTL_TGD_CT(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();


            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    _id_bophan = 0;
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                }
            }

            int tongluong_ = 0;
            int songayan_ = 0;
            int trutiencom_ = 0;
            int tongtien_ = 0;
            int tamung_ = 0;
            int thucnhan_ = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TGD_SF(_nam, _thang, _id_bophan);
                double TongLuong_ = 0;
                int ID_CongNhan_Cu = 0;
                if (_data != null && _data.Rows.Count > 0)
                {
                    ID_CongNhan_Cu = Convert.ToInt32(_data.Rows[0]["ID_CongNhan"].ToString());
                }
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int ID_CongNhan_;
                    if (i < _data.Rows.Count - 1)
                    {
                        ID_CongNhan_ = Convert.ToInt32(_data.Rows[i + 1]["ID_CongNhan"].ToString());
                    }
                    else
                    {
                        ID_CongNhan_ = 0;
                    }
                    int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                    _data.Rows[i]["ID_VTHH"] = id_vthh_;
                    _data.Rows[i]["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                    tongluong_ += Convert.ToInt32(_data.Rows[i]["TongLuong"].ToString());
                    songayan_ += Convert.ToInt32(_data.Rows[i]["SoNgayAn"].ToString());
                    trutiencom_ += Convert.ToInt32(_data.Rows[i]["TruTienCom"].ToString());
                    tongtien_ += Convert.ToInt32(_data.Rows[i]["TongTien"].ToString());
                    tamung_ += Convert.ToInt32(_data.Rows[i]["TamUng"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    //  
                    double SoNgayAn_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn_Value"].ToString());
                    //_data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    double dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    TongLuong_ += (dongia_ * sanluong_);

                    double TruTienCom_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom_Value"].ToString());
                    if (ID_CongNhan_ != ID_CongNhan_Cu)
                    {
                        double TamUng_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        _data.Rows[i]["TongLuong"] = TongLuong_.ToString("N0");

                        ID_CongNhan_Cu = ID_CongNhan_;

                        _data.Rows[i]["TongTien"] = (TongLuong_ - TruTienCom_).ToString("N0");
                        _data.Rows[i]["ThucNhan"] = (TongLuong_ - TruTienCom_ - TamUng_).ToString("N0");

                       _data.Rows[i]["TruTienCom"] = TruTienCom_;

                        _data.Rows[i]["SoNgayAn"] = SoNgayAn_;

                       _data.Rows[i]["TamUng"] = TamUng_;

                        TongLuong_ = 0;
                    }
                    else
                    {
                        _data.Rows[i]["TongLuong"] = 0;
                        _data.Rows[i]["TruTienCom"] = 0;
                        _data.Rows[i]["SoNgayAn"] = 0;
                        _data.Rows[i]["TongTien"] = 0;
                        _data.Rows[i]["TamUng"] = 0;
                    }
                    _data.Rows[i]["ThanhTien"] = (dongia_ * sanluong_).ToString("N0");

                    DataRow _ravi = ds.tbBTTL_TGD_CT.NewRow();
                    _ravi["STT"] = (i + 1).ToString();
                    _ravi["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                    _ravi["TongTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongTien"].ToString());
                    _ravi["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();
                    _ravi["TongLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TongLuong"].ToString());
                    _ravi["SoNgayAn"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn"].ToString());
                    _ravi["TruTienCom"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom"].ToString());
                    _ravi["TamUng"] = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng"].ToString());
                    _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThucNhan"].ToString());
                    _ravi["DonGia"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia"].ToString());
                    _ravi["ThanhTien"] = CheckString.ConvertToDouble_My(_data.Rows[i]["ThanhTien"].ToString());
                    _ravi["SanLuong"] = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());
                    ds.tbBTTL_TGD_CT.Rows.Add(_ravi);
                }
            }

            xtr111.DataSource = null;
            //xtr111.DataSource = LoadData();

            xtr111.DataSource = ds.tbBTTL_TGD_CT;
            xtr111.DataMember = "tbBTTL_TGD_CT";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        //
        private string tenbophan = "Tổ Gấp dán";
        public int _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        public DataTable LoadData()
        {
            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    _id_bophan = 0;
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                }
            }

            int tongluong_ = 0;
            int songayan_ = 0;
            int trutiencom_ = 0;
            int tongtien_ = 0;
            int tamung_ = 0;
            int thucnhan_ = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TGD_SF(_nam, _thang, _id_bophan);
                double TongLuong_ = 0;
                int ID_CongNhan_Cu = 0;
                if (_data != null && _data.Rows.Count > 0)
                {
                    ID_CongNhan_Cu = Convert.ToInt32(_data.Rows[0]["ID_CongNhan"].ToString());
                }
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int ID_CongNhan_;
                    if (i < _data.Rows.Count - 1)
                    {
                        ID_CongNhan_ = Convert.ToInt32(_data.Rows[i + 1]["ID_CongNhan"].ToString());
                    }
                    else
                    {
                        ID_CongNhan_ = 0;
                    }
                    int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                    _data.Rows[i]["ID_VTHH"] = id_vthh_;
                    _data.Rows[i]["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                    tongluong_ += Convert.ToInt32(_data.Rows[i]["TongLuong"].ToString());
                    songayan_ += Convert.ToInt32(_data.Rows[i]["SoNgayAn"].ToString());
                    trutiencom_ += Convert.ToInt32(_data.Rows[i]["TruTienCom"].ToString());
                    tongtien_ += Convert.ToInt32(_data.Rows[i]["TongTien"].ToString());
                    tamung_ += Convert.ToInt32(_data.Rows[i]["TamUng"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    //  
                    double SoNgayAn_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn_Value"].ToString());
                    //_data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    double dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    TongLuong_ += (dongia_ * sanluong_);

                    double TruTienCom_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom_Value"].ToString());
                    if (ID_CongNhan_ != ID_CongNhan_Cu)
                    {
                        double TamUng_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        _data.Rows[i]["TongLuong"] = TongLuong_.ToString("N0");

                        ID_CongNhan_Cu = ID_CongNhan_;

                        _data.Rows[i]["TongTien"] = (TongLuong_ - TruTienCom_).ToString("N0");
                        _data.Rows[i]["ThucNhan"] = (TongLuong_ - TruTienCom_ - TamUng_).ToString("N0");

                        if (TruTienCom_ == 0)
                            _data.Rows[i]["TruTienCom"] = "";
                        else
                            _data.Rows[i]["TruTienCom"] = TruTienCom_.ToString("N0");

                        if (SoNgayAn_ == 0)
                            _data.Rows[i]["SoNgayAn"] = "";
                        else
                            _data.Rows[i]["SoNgayAn"] = SoNgayAn_.ToString("N0");

                        if (TamUng_ == 0)
                            _data.Rows[i]["TamUng"] = "";
                        else
                            _data.Rows[i]["TamUng"] = TruTienCom_.ToString("N0");

                        TongLuong_ = 0;
                    }
                    else
                    {
                        _data.Rows[i]["TongLuong"] = "";
                        _data.Rows[i]["TruTienCom"] = "";
                        _data.Rows[i]["SoNgayAn"] = "";
                        _data.Rows[i]["TongTien"] = "";
                        _data.Rows[i]["TamUng"] = "";
                    }
                    _data.Rows[i]["ThanhTien"] = (dongia_ * sanluong_).ToString("N0");

                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "Tổng";
            _ravi["TongLuong"] = tongluong_.ToString("N0");
            _ravi["SoNgayAn"] = songayan_.ToString("N0");
            _ravi["TruTienCom"] = trutiencom_.ToString("N0");
            _ravi["TongTien"] = tongtien_.ToString("N0");
            _ravi["TamUng"] = tamung_.ToString("N0");
            _ravi["ThucNhan"] = thucnhan_.ToString("N0");

            _data.Rows.Add(_ravi);
            return _data;
        }
    }
}
