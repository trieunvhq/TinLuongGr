using CtyTinLuong.Constants;
using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmBTTL_PKT : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true; 

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();
        public frmBTTL_PKT(int id_bophan)
        {
            _id_bophan = id_bophan;
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
                 
            }
            else
            {
            }
            double tongluong_tong_ = 0;
            double luongtrachnhiem_tong_ = 0;
            double tong_tong_ = 0;
            double trutamung_tong_ = 0;
            double thuclinh_tong_ = 0;


            double tongluong_ = 0;
            double luongtrachnhiem_ = 0;
            double tong_ = 0;
            double trutamung_ = 0;
            double thuclinh_ = 0;

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
                        dongia_ = Convert.ToDouble(_data.Rows[i]["DinhMucLuongTangCa"].ToString());
                        _data.Rows[i]["TenVTHH"] = "Tăng ca";

                    }
                    else
                    {
                        dongia_ = Convert.ToDouble(_data.Rows[i]["DinhMucLuongTheoGio"].ToString());
                        _data.Rows[i]["TenVTHH"] = "Công nhật";
                    }
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");
                    //
                    _data.Rows[i]["STT"] = (i / 2) + 1;

                    tongluong_ = (dongia_ * sanluong_);
                    tongluong_tong_ += tongluong_;
                    _data.Rows[i]["TongLuong"] = (dongia_ * sanluong_).ToString("N0");

                    luongtrachnhiem_ = Convert.ToDouble(_data.Rows[i]["LuongTrachNhiem_Value"].ToString());
                    luongtrachnhiem_tong_ += luongtrachnhiem_;
                    if (luongtrachnhiem_ == 0)
                        _data.Rows[i]["LuongTrachNhiem"] = "";
                    else
                        _data.Rows[i]["LuongTrachNhiem"] = luongtrachnhiem_.ToString("N0");

                    trutamung_ = Convert.ToDouble(_data.Rows[i]["TamUng_Value"].ToString());
                    trutamung_tong_ += trutamung_;
                    if (trutamung_ == 0)
                        _data.Rows[i]["TamUng"] = "";
                    else
                        _data.Rows[i]["TamUng"] = trutamung_.ToString("N0");



                    tong_ = ((dongia_ * sanluong_) + luongtrachnhiem_);
                    tong_tong_ += tong_;
                    _data.Rows[i]["TongTien"] = (tong_).ToString("N0");

                    thuclinh_ = (tong_ - trutamung_);
                    thuclinh_tong_ += thuclinh_;
                    _data.Rows[i]["ThucNhan"] = (thuclinh_).ToString("N0");



                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "TỔNG";
            if (tongluong_tong_ == 0)
            {
                _ravi["TongLuong"] = "";
            }
            else
            {
                _ravi["TongLuong"] = tongluong_tong_.ToString("N0");
            }
            // 
            if (trutamung_tong_ == 0)
            {
                _ravi["TamUng"] = "";
            }
            else
            {
                _ravi["TamUng"] = trutamung_tong_.ToString("N0");
            }
            // 
            if (tong_tong_ == 0)
            {
                _ravi["TongTien"] = "";
            }
            else
            {
                _ravi["TongTien"] = tong_tong_.ToString("N0");
            }
            // 
            if (trutamung_tong_ == 0)
            {
                _ravi["TamUng"] = "";
            }
            else
            {
                _ravi["TamUng"] = trutamung_tong_.ToString("N0");
            }
            // 
            if (thuclinh_tong_ == 0)
            {
                _ravi["ThucNhan"] = "";
            }
            else
            {
                _ravi["ThucNhan"] = thuclinh_tong_.ToString("N0");
            }

            _data.Rows.Add(_ravi);
            gridControl1.DataSource = _data;
            //  
            isload = false;
        }
        private void frmBTTL_PKT_Load(object sender, EventArgs e)
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
            ff.ShowDialog();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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
            //this.Close();
        }
    }
}


