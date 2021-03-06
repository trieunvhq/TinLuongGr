
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
    public partial class frmBTTL_TDB_Old : UserControl
    {  

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_TDB_Old(frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            InitializeComponent();
            clLuongTrachNhiem.Caption = "L.TRÁCH\nNHIỆM";
        }

        public void LoadData(bool islandau, int id_bophan_)
        {
            isload = true;
            _id_bophan = id_bophan_;
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
            _nam = Convert.ToInt16(txtNam.Text);
            _thang = Convert.ToInt16(txtThang.Text);

            double sanluong_tong = 0;
            double thanhtien_tong = 0;
            double tongluong_tong = 0;
            double songayan_tong = 0;
            double trutiencom_tong = 0;
            double tongtien_tong = 0;
            double tamung_tong = 0;
            double thucnhan_tong = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TGD_SF(_nam, _thang,_id_bophan);
                double TongLuong_row = 0; 
                int ID_CongNhan_Cu = 0;
                int stt = 1;
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
                    
                    songayan_tong += Convert.ToInt32(_data.Rows[i]["SoNgayAn"].ToString());
                    trutiencom_tong += Convert.ToInt32(_data.Rows[i]["TruTienCom"].ToString());
                    tamung_tong += Convert.ToInt32(_data.Rows[i]["TamUng"].ToString());
                    //  
                    //_data.Rows[i]["DonGia"] = dongia_.ToString("N0");




                    double dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());
                    sanluong_tong += sanluong_;
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    TongLuong_row += (dongia_ * sanluong_);
                    tongluong_tong += (dongia_ * sanluong_);
                    thanhtien_tong += (dongia_ * sanluong_);

                    double TruTienCom_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom_Value"].ToString());
                    if (ID_CongNhan_ != ID_CongNhan_Cu || i==_data.Rows.Count-1)
                    {
                        _data.Rows[i]["STT"] = stt.ToString();
                        ++stt;

                           double SoNgayAn_row = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn_Value"].ToString());
                        double TamUng_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        _data.Rows[i]["TongLuong"] = TongLuong_row.ToString("N0");

                        ID_CongNhan_Cu = ID_CongNhan_;

                        _data.Rows[i]["TongTien"] = (TongLuong_row - TruTienCom_).ToString("N0");
                        tongtien_tong += (TongLuong_row - TruTienCom_);
                        _data.Rows[i]["ThucNhan"] = (TongLuong_row - TruTienCom_ - TamUng_).ToString("N0");
                        thucnhan_tong += (TongLuong_row - TruTienCom_ - TamUng_);
                        if (TruTienCom_ == 0)
                            _data.Rows[i]["TruTienCom"] = "";
                        else
                            _data.Rows[i]["TruTienCom"] = TruTienCom_.ToString("N0");

                        if (SoNgayAn_row == 0)
                            _data.Rows[i]["SoNgayAn"] = "";
                        else
                            _data.Rows[i]["SoNgayAn"] = SoNgayAn_row.ToString("N0");

                        if (TamUng_ == 0)
                            _data.Rows[i]["TamUng"] = "";
                        else
                            _data.Rows[i]["TamUng"] = TruTienCom_.ToString("N0");

                        trutiencom_tong += TruTienCom_;
                        songayan_tong += SoNgayAn_row;
                       
                        TongLuong_row = 0;
                    }
                    else
                    {
                        _data.Rows[i]["TongLuong"] = "";
                        _data.Rows[i]["TruTienCom"] = "";
                        _data.Rows[i]["SoNgayAn"] = "";
                        _data.Rows[i]["TongTien"] = "";
                        _data.Rows[i]["TamUng"] = "";
                        _data.Rows[i]["ThucNhan"] = "";
                    }
                    _data.Rows[i]["ThanhTien"] = (dongia_ * sanluong_).ToString("N0");
                    
                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "TỔNG";
            _ravi["SanLuong"] = sanluong_tong.ToString("N0");
            _ravi["ThucNhan"] = thucnhan_tong.ToString("N0"); 
            _ravi["TongLuong"] = tongluong_tong.ToString("N0");
            _ravi["SoNgayAn"] = songayan_tong.ToString("N0");
            _ravi["TruTienCom"] = trutiencom_tong.ToString("N0");
            _ravi["TongTien"] = tongtien_tong.ToString("N0");
            _ravi["TamUng"] = tamung_tong.ToString("N0");
            _ravi["ThanhTien"] = thanhtien_tong.ToString("N0");

            _data.Rows.Add(_ravi);
            gridControl1.DataSource = _data;
            //  
            isload = false;
        }
        private void frmBTTL_TDB_Old_Load(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.Default;
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
                LoadData(false,_id_bophan);
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
                LoadData(false,_id_bophan);
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

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_CT_Old ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_CT_Old(_thang, _nam, _data);
            ff.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        { 
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
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
           // GuiDuLieuBangLuong();
        }

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_TQ_Old ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_TQ_Old(_thang, _nam, _data);
            ff.Show();
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
                        result = CheckString.ConvertToDouble_My(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch
            {
                try
                {
                    result = CheckString.ConvertToDouble_My(s);
                }
                catch
                {
                    try
                    {
                        result = CheckString.ConvertToDouble_My(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
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
            _frmQLLCC.Close();
        }
    }
}


