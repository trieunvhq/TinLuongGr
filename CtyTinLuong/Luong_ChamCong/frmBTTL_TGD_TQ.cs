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
    public partial class frmBTTL_TGD_TQ : Form
    {
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong; 
        public string msTenNhanVien;

        public int _nam, _thang;
        public string  _ten_vthh;
        private DataTable _data;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();
        public frmBTTL_TGD_TQ()
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
            }
            else
            {
            }
            _nam = DateTime.Now.Year;
            _thang = DateTime.Now.Month;

            int tongluong_ = 0;
            int songayan_ = 0;
            int trutiencom_ = 0;
            int tongtien_ = 0;
            int tamung_ = 0;
            int thucnhan_ = 0;
            DataTable data_moi_ = new DataTable();
           

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TGD_SF(_nam, _thang);
                data_moi_ = clsThin_.T_BTTL_TGD_SF(_nam, _thang);

                data_moi_.Rows.Clear();
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
                    //_data.Rows[i]["DonGia"] = dongia_.ToString("N0");




                    double dongia_ = Convert.ToDouble(_data.Rows[i]["DonGia_Value"].ToString());
                    double sanluong_ = Convert.ToDouble(_data.Rows[i]["SanLuong"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    TongLuong_ += (dongia_ * sanluong_);

                    double TruTienCom_ = Convert.ToDouble(_data.Rows[i]["TruTienCom_Value"].ToString());
                    if (ID_CongNhan_ != ID_CongNhan_Cu)
                    {
                        DataRow _ravi2 = data_moi_.NewRow();
                        _ravi2["ID_CongNhan"] = ID_CongNhan_;
                        _ravi2["Thang"] = _thang;
                        _ravi2["Nam"] = _nam;
                        _ravi2["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();

                        double TamUng_ = Convert.ToDouble(_data.Rows[i]["TamUng_Value"].ToString());
                        _ravi2["TongLuong"] = TongLuong_.ToString("N0");

                        ID_CongNhan_Cu = ID_CongNhan_;

                        _ravi2["TongTien"] = (TongLuong_ - TruTienCom_).ToString("N0");
                        _ravi2["ThucNhan"] = (TongLuong_ - TruTienCom_ - TamUng_).ToString("N0");

                        if (TruTienCom_ == 0)
                            _ravi2["TruTienCom"] = "";
                        else
                            _ravi2["TruTienCom"] = TruTienCom_.ToString("N0");

                        if (SoNgayAn_ == 0)
                            _ravi2["SoNgayAn"] = "";
                        else
                            _ravi2["SoNgayAn"] = SoNgayAn_.ToString("N0");

                        if (TamUng_ == 0)
                            _ravi2["TamUng"] = "";
                        else
                            _ravi2["TamUng"] = TruTienCom_.ToString("N0");
                        data_moi_.Rows.Add(_ravi2);

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

            DataRow _ravi = data_moi_.NewRow(); 
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "TỔNG";
            _ravi["TongLuong"] = tongluong_.ToString("N0");
            _ravi["SoNgayAn"] = songayan_.ToString("N0");
            _ravi["TruTienCom"] = trutiencom_.ToString("N0");
            _ravi["TongTien"] = tongtien_.ToString("N0");
            _ravi["TamUng"] = tamung_.ToString("N0");
            _ravi["ThucNhan"] = thucnhan_.ToString("N0");

            data_moi_.Rows.Add(_ravi);
            gridControl1.DataSource = data_moi_;
            //  
            isload = false;
        } 
        private void frmBTTL_TGD_TQ_Load(object sender, EventArgs e)
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
            catch {
                MessageBox.Show("Tháng không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show( "Năm không hợp lệ","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
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
            GuiDuLieuBangLuong();
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
        private void GuiDuLieuBangLuong()
        {
            bool isGuiThanhCong = false;
            using (clsThin clsThin_ = new clsThin())
            {
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                    if (id_vthh_ == 0)
                    {
                        continue;
                    }
                    else
                    {
                        isGuiThanhCong = true;
                    }
                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                        Convert.ToInt32(_data.Rows[i]["ID_NhanSu"].ToString()),
                        _thang,
                        _nam,
                        id_vthh_,
                        Convert.ToInt32(_data.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay1"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay2"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay3"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay4"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay5"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay6"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay7"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay8"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay9"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay10"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay11"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay12"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay13"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay14"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay15"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay16"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay17"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay18"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay19"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay20"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay21"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay22"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay23"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay24"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay25"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay26"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay27"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay28"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay29"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay30"].ToString()),
                        (float)Convert.ToDouble(_data.Rows[i]["Ngay31"].ToString()),
                        0, true);
                }
                if (isGuiThanhCong)
                {
                    MessageBox.Show("Gửi dữ liệu chấm công thành công!");
                }
                else
                {
                    MessageBox.Show( "Chưa chọn loại hàng hóa","Lỗi",
       MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
               

        }
    }
}


