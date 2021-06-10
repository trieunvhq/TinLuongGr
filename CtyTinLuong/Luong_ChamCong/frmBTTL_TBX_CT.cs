using CtyTinLuong.Constants;
using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmBTTL_TBX_CT : Form
    {
        private string tenbophan = "tổ bốc xếp";

        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;
        private double _dinhmuc_tangca = 0, _dinhmuc_cong = 0;

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();
        public frmBTTL_TBX_CT()
        {
            InitializeComponent();
        }

        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
                DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
                int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;

                _nam = DateTime.Now.Year;
                _thang = DateTime.Now.Month;

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
                        return;
                    }
                    ///
                    dt_ = clsThin_.T_DM_SO(_nam, _thang, _id_bophan);
                    if (dt_ != null && dt_.Rows.Count == 1)
                    {
                        _dinhmuc_cong = Convert.ToDouble(dt_.Rows[0]["DinhMuc_KhongTang"].ToString());
                        _dinhmuc_tangca = Convert.ToDouble(dt_.Rows[0]["DinhMuc_Tang"].ToString());
                    }
                }

            }
            else
            {
            }

            double TongLuong = 0;

            double songayan = 0;
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
            _ravi["TenNhanVien"] = "TỔNG";
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
            gridControl1.DataSource = _data;
            //  
            isload = false;
        }
        private void frmBTTL_TBX_CT_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index_ = e.RowHandle;
            string name_ = e.Column.FieldName;
            if (name_.Contains("Ngay"))
            {
                _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
                if (_data.Rows.Count > index_)
                {
                    int temp_ = Convert.ToInt32(_data.Rows[index_][name_].ToString());
                    _data.Rows[index_]["Tong"] = temp_ + Convert.ToInt32(_data.Rows[index_]["Tong"].ToString());
                }

            }
            else if (name_.Contains("TenVTHH"))
            {
                if (gridView1.GetFocusedRowCellValue(name_) == null)
                {
                    _data.Rows[index_][name_] = "";
                }
                else
                {
                    _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
                }
            }
            // gridView1.SetRowCellValue(e.RowHandle, clSLThuong, tongcong); 
        }

        private void linkQuanLyMaHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhThang();
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhThang();
        }
        private void HoanThanhThang()
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HoanThanhNam()
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Năm không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT(_thang, _nam);
            ff.Show();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //miiID_chiTietChamCong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ChiTietChamCong).ToString());
            //miiD_DinhMuc_Luong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
            // miID_congNhan = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());

            // msTenNhanVien = gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString();
            //frmMaHang_ChamCong_ToGapDan ff = new frmMaHang_ChamCong_ToGapDan(this);
            //ff.Show();
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
        }

        private float ConvertToFloat(string s)
        {
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return (float)result;
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


