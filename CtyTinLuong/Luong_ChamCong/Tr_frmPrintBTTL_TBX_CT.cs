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
    public partial class Tr_frmPrintBTTL_TBX_CT : Form
    {
        private int _thang;
        private int _nam;
        public Tr_frmPrintBTTL_TBX_CT(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintBTTL_TBX_CT_Load(object sender, EventArgs e)
        {
            Tr_PrintBTTL_TBX_CT xtr111 = new Tr_PrintBTTL_TBX_CT(_thang, _nam);

            //DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbCongNhatChamCongToGapDan.Clone();
            //ds.tbCongNhatChamCongToGapDan.Clear();
            //clsThin cls1 = new clsThin();

            //DataTable dt3 = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");


            xtr111.DataSource = null;
            xtr111.DataSource = LoadData();


            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }


        private string tenbophan = "tổ bốc xếp";
        int _id_bophan;
        double _dinhmuc_cong;
        double _dinhmuc_tangca;
        DataTable _data;
        public DataTable LoadData()
        {
            
            DateTime dtnow = DateTime.Now;
            DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
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
                ///
                dt_ = clsThin_.T_DM_SO(_nam, _thang, _id_bophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _dinhmuc_cong = Convert.ToDouble(dt_.Rows[0]["DinhMuc_KhongTang"].ToString());
                    _dinhmuc_tangca = Convert.ToDouble(dt_.Rows[0]["DinhMuc_Tang"].ToString());
                }
            }

           

            double TongLuong = 0;

            double LuongTrachNhiem = 0;
            double tongtien = 0;
            double tamung = 0;
            double thucnhan = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TGD_SF(_nam, _thang, _id_bophan);


                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    double dongia_;
                    double sanluong_ = Convert.ToDouble(_data.Rows[i]["SanLuong"].ToString());
                    bool istangca_ = Convert.ToBoolean(_data.Rows[i]["IsTangCa"].ToString());
                    if (istangca_)
                    {
                        dongia_ = _dinhmuc_tangca;
                        _data.Rows[i]["TenVTHH"] = "Tăng ca";

                    }
                    else
                    {
                        dongia_ = _dinhmuc_cong;
                        _data.Rows[i]["TenVTHH"] = "Công nhật";
                    }
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");
                    //
                    _data.Rows[i]["STT"] = (i / 2) + 1;

                    TongLuong += (dongia_ * sanluong_);
                    _data.Rows[i]["TongLuong"] = (dongia_ * sanluong_).ToString("N0");

                    double LuongTrachNhiem_ = Convert.ToDouble(_data.Rows[i]["LuongTrachNhiem"].ToString());
                    LuongTrachNhiem += LuongTrachNhiem_;
                    if (LuongTrachNhiem_ == 0)
                        _data.Rows[i]["LuongTrachNhiem"] = "";
                    else
                        _data.Rows[i]["LuongTrachNhiem"] = LuongTrachNhiem_.ToString("N0");

                    double TamUng_ = Convert.ToDouble(_data.Rows[i]["TamUng_Value"].ToString());
                    tamung += TamUng_;
                    if (TamUng_ == 0)
                        _data.Rows[i]["TamUng"] = "";
                    else
                        _data.Rows[i]["TamUng"] = TamUng_.ToString("N0");



                    tongtien += ((dongia_ * sanluong_) - TamUng_);
                    _data.Rows[i]["TongTien"] = ((dongia_ * sanluong_) + LuongTrachNhiem_).ToString("N0");

                    thucnhan += ((dongia_ * sanluong_) - +LuongTrachNhiem_ - TamUng_);
                    _data.Rows[i]["ThucNhan"] = ((dongia_ * sanluong_) - +LuongTrachNhiem_ - TamUng_).ToString("N0");



                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "Tổng";
            if (TongLuong == 0)
            {
                _ravi["TongLuong"] = "";
            }
            else
            {
                _ravi["TongLuong"] = TongLuong.ToString("N0");
            }
            // 
            if (tongtien == 0)
            {
                _ravi["TongTien"] = "";
            }
            else
            {
                _ravi["TongTien"] = tongtien.ToString("N0");
            }
            // 
            if (tamung == 0)
            {
                _ravi["TamUng"] = "";
            }
            else
            {
                _ravi["TamUng"] = tamung.ToString("N0");
            }
            // 
            if (thucnhan == 0)
            {
                _ravi["ThucNhan"] = "";
            }
            else
            {
                _ravi["ThucNhan"] = thucnhan.ToString("N0");
            }

            _data.Rows.Add(_ravi);
            return _data;
            //  
        }
    }
}
