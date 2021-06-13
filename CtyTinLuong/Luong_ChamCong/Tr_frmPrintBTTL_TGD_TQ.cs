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
    public partial class Tr_frmPrintBTTL_TGD_TQ : Form
    {

        private int _thang, _nam;
        private string tenbophan = "Tổ Gấp dán";
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _id_bophan;
        public string _ten_vthh;
        private DataTable _data;

        public Tr_frmPrintBTTL_TGD_TQ(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmBTTL_TGD_TQ_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TGD_TQ xtr111 = new Tr_PrintBTTL_TGD_TQ(_thang, _nam);

            //
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

                    tongluong_ += Convert.ToInt32(_data.Rows[i]["TongLuong"].ToString());
                    songayan_ += Convert.ToInt32(_data.Rows[i]["SoNgayAn"].ToString());
                    trutiencom_ += Convert.ToInt32(_data.Rows[i]["TruTienCom"].ToString());
                    tongtien_ += Convert.ToInt32(_data.Rows[i]["TongTien"].ToString());
                    tamung_ += Convert.ToInt32(_data.Rows[i]["TamUng"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    thucnhan_ += Convert.ToInt32(_data.Rows[i]["ThucNhan"].ToString());
                    //  
                    double SoNgayAn_ = Convert.ToDouble(_data.Rows[i]["SoNgayAn_Value"].ToString());
                    double dongia_ = Convert.ToDouble(_data.Rows[i]["DonGia_Value"].ToString());
                    double sanluong_ = Convert.ToDouble(_data.Rows[i]["SanLuong"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    TongLuong_ += (dongia_ * sanluong_);

                    double TruTienCom_ = Convert.ToDouble(_data.Rows[i]["TruTienCom_Value"].ToString());
                    if (ID_CongNhan_ != ID_CongNhan_Cu)
                    {
                        DataRow _ravi2 = ds.tbBTTL_TGD_TQ.NewRow();
                        _ravi2["STT"] = (i+1).ToString();
                        _ravi2["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();

                        double TamUng_ = Convert.ToDouble(_data.Rows[i]["TamUng_Value"].ToString());
                        _ravi2["TongLuong"] = Convert.ToDouble(TongLuong_);

                        ID_CongNhan_Cu = ID_CongNhan_;

                        _ravi2["TongTien"] = Convert.ToDouble(TongLuong_ - TruTienCom_);
                        _ravi2["ThucNhan"] = Convert.ToDouble(TongLuong_ - TruTienCom_ - TamUng_);

                        if (TruTienCom_ == 0)
                            _ravi2["TruTienCom"] = Convert.ToDouble(0);
                        else
                            _ravi2["TruTienCom"] = Convert.ToDouble(TruTienCom_);

                        if (SoNgayAn_ == 0)
                            _ravi2["SoNgayAn"] = 0;
                        else
                            _ravi2["SoNgayAn"] = Convert.ToDouble(SoNgayAn_);

                        if (TamUng_ == 0)
                            _ravi2["TamUng"] = 0;
                        else
                            _ravi2["TamUng"] = Convert.ToDouble(TruTienCom_);
                        ds.tbBTTL_TGD_TQ.Rows.Add(_ravi2);

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
                    _data.Rows[i]["ThanhTien"] = Convert.ToDouble(dongia_ * sanluong_);

                }
            }

            //
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBTTL_TGD_TQ;
            xtr111.DataMember = "tbBTTL_TGD_TQ";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

    }
}
