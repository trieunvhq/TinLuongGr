
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
    public partial class frmBTTL_TDK : UserControl
    {  

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_TDK(frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            InitializeComponent();
            LuongTrachNhiem.Caption = "TRỪ TIỀN\nCƠM";
            ThanhTien.Caption = "THÀNH\nTIỀN";
            TongLuong.Caption = "TỔNG\nLƯƠNG";
            SoNgayAn.Caption = "SỐ NGÀY\nĂN";
            SanLuong.Caption = "SẢN\nLƯỢNG";
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
            _nam = DateTime.Now.Year;
            _thang = DateTime.Now.Month;

            double sanluong_tong = 0;
            double thanhtien_tong = 0;
            double tongluong_tong = 0;
            double songayan_tong = 0;
            double trutiencom_tong = 0;
            double tongtien_tong = 0;
            double tamung_tong = 0;
            double thucnhan_tong = 0;

            //double Tong_sanluong_tong = 0;
            //double Tong_thanhtien_tong = 0;
            //double Tong_tongluong_tong = 0;
            //double Tong_songayan_tong = 0;
            //double Tong_trutiencom_tong = 0;
            //double Tong_tongtien_tong = 0;
            //double Tong_tamung_tong = 0;
            //double Tong_thucnhan_tong = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.Tr_BTTL_TDK(_nam, _thang,_id_bophan);
                int ID_congNhanRoot = -1;
                int stt = 0;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()); //Convert.ToInt32(_data.Rows[i + 1]["ID_CongNhan"].ToString());

                    //
                    int id_vthh_ = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                    _data.Rows[i]["ID_VTHH"] = id_vthh_;
                    _data.Rows[i]["TenNhanVien"] = CheckString.ChuanHoaHoTen(_data.Rows[i]["TenNhanVien"].ToString());
                    _data.Rows[i]["TenVTHH"] = _data.Rows[i]["TenVTHH"].ToString();

                    songayan_tong += CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn_Value"].ToString());
                    trutiencom_tong += CheckString.ConvertToDouble_My(_data.Rows[i]["TruTienCom"].ToString());
                    tamung_tong += CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng"].ToString());
                    //  

                    double dongia_ = 0;

                    //Loại công:
                    string LoaiCong = _data.Rows[i]["Cong"].ToString();

                    if (LoaiCong.ToLower().Contains("gia nghĩa 2"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["GiaNgia2_Value"].ToString());
                    }
                    else if (LoaiCong.ToLower().Contains("gia nghĩa"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["GiaNghia_Value"].ToString());
                    }
                    else if (LoaiCong.ToLower().Contains("thọ kim bật 3"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["ThoKimBat3_Value"].ToString());
                    }
                    else if (LoaiCong.ToLower().Contains("nc bật 6 buộc"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["NCBat6Buoc_Value"].ToString());
                    }
                    else if (LoaiCong.ToLower().Contains("nc bật 6"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["NCBat6_Value"].ToString());
                    }
                    else if (LoaiCong.ToLower().Contains("cuc đột")
                        || LoaiCong.ToLower().Contains("cục đột")
                        || LoaiCong.ToLower().Contains("cúc đột"))
                    {
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["CucDot_Value"].ToString());
                    }
                    else
                    {
                        //Đơn giá của các loại công còn lại:
                        dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["MacDinh_Value"].ToString());
                    }
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    //Sản lượng:
                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong_Value"].ToString());
                    sanluong_tong += sanluong_;
                    if (sanluong_ == 0)
                        _data.Rows[i]["SanLuong"] = "";
                    else
                        _data.Rows[i]["SanLuong"] = sanluong_.ToString();

                    //Thành tiền:
                    double thanhtien_ = dongia_ * sanluong_;
                    thanhtien_tong += thanhtien_;
                    if (thanhtien_ == 0)
                        _data.Rows[i]["ThanhTien"] = "";
                    else
                        _data.Rows[i]["ThanhTien"] = thanhtien_.ToString("N0");

                    if (ID_congNhanRoot != ID_CongNhan_)
                    {
                        ID_congNhanRoot = ID_CongNhan_;
                        stt++;
                        _data.Rows[i]["STT"] = stt;
                        
                        //Tổng lương:
                        double TongLuong = TinhTongLuongMotCongNhan(_data, ID_CongNhan_);
                        tongluong_tong += TongLuong;
                        if (TongLuong == 0)
                            _data.Rows[i]["TongLuong"] = "";
                        else
                            _data.Rows[i]["TongLuong"] = TongLuong.ToString("N0");

                        //Số ngày ăn:
                        double SoNgayAn_row = CheckString.ConvertToDouble_My(_data.Rows[i]["SoNgayAn_Value"].ToString());
                        songayan_tong += SoNgayAn_row;
                        if (SoNgayAn_row == 0)
                            _data.Rows[i]["SoNgayAn"] = "";
                        else
                            _data.Rows[i]["SoNgayAn"] = SoNgayAn_row.ToString();

                        //Trừ tiền cơm:
                        double GiaCom = CheckString.ConvertToDouble_My(_data.Rows[i]["GiaCom_Value"].ToString());
                        trutiencom_tong += (GiaCom * SoNgayAn_row);
                        if ((GiaCom * SoNgayAn_row) == 0)
                            _data.Rows[i]["TruTienCom"] = "";
                        else
                            _data.Rows[i]["TruTienCom"] = (GiaCom * SoNgayAn_row).ToString("N0");

                        //Tổng Tiền:
                        double TongTien = TongLuong - (GiaCom * SoNgayAn_row);
                        tongtien_tong += TongTien;
                        if (TongTien == 0)
                            _data.Rows[i]["TongTien"] = "";
                        else
                            _data.Rows[i]["TongTien"] = TongTien.ToString("N0");

                        //Tạm ứng:
                        double TamUng_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        tamung_tong += TamUng_;
                        if (TamUng_ == 0)
                            _data.Rows[i]["TamUng"] = "";
                        else
                            _data.Rows[i]["TamUng"] = TamUng_.ToString("N0");

                        //Thực nhận:
                        double ThucNhan = TongTien - TamUng_;
                        thucnhan_tong += ThucNhan;
                        if (ThucNhan == 0)
                            _data.Rows[i]["ThucNhan"] = "";
                        else
                            _data.Rows[i]["ThucNhan"] = ThucNhan.ToString("N0");
                    }
                    else
                    {
                        _data.Rows[i]["STT"] = stt;
                        _data.Rows[i]["TongLuong"] = "";
                        _data.Rows[i]["SoNgayAn"] = "";
                        _data.Rows[i]["TruTienCom"] = "";
                        _data.Rows[i]["TongTien"] = "";
                        _data.Rows[i]["TamUng"] = "";
                        _data.Rows[i]["ThucNhan"] = "";
                    }
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
        private void frmBTTL_TDK_Load(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.Default;
        }

        //Hàm tính tổng lương của từng công nhân theo ID_CongNhan:
        private double TinhTongLuongMotCongNhan (DataTable dt, int ID_CongNhan)
        {
            double result = 0;
            //Tổng lương:
            if (_data != null && _data.Rows.Count > 0)
            {
                for (int i = 0; i < _data.Rows.Count; i++)
                {
                    if (ID_CongNhan == Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()))
                    {
                        double DonGia_Sub = 0;
                        double SanLuong_Sub = 0;

                        //Loại công:
                        string LoaiCong = _data.Rows[i]["Cong"].ToString();

                        if (LoaiCong.ToLower().Contains("gia nghĩa 2"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["GiaNgia2_Value"].ToString());
                        }
                        else if (LoaiCong.ToLower().Contains("gia nghĩa"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["GiaNghia_Value"].ToString());
                        }
                        else if (LoaiCong.ToLower().Contains("thọ kim bật 3"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["ThoKimBat3_Value"].ToString());
                        }
                        else if (LoaiCong.ToLower().Contains("nc bật 6 buộc"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["NCBat6Buoc_Value"].ToString());
                        }
                        else if (LoaiCong.ToLower().Contains("nc bật 6"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["NCBat6_Value"].ToString());
                        }
                        else if (LoaiCong.ToLower().Contains("cuc đột")
                            || LoaiCong.ToLower().Contains("cục đột")
                            || LoaiCong.ToLower().Contains("cúc đột"))
                        {
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["CucDot_Value"].ToString());
                        }
                        else
                        {
                            //Đơn giá của các loại công còn lại:
                            DonGia_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["MacDinh_Value"].ToString());
                        }

                        //Sản lượng:
                        SanLuong_Sub = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong_Value"].ToString());

                        result += (SanLuong_Sub * DonGia_Sub);
                    }
                }
            }

            return result;
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TGD_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TGD_CT(_thang, _nam, _data);
            ff.ShowDialog();
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TGD_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TGD_TQ(_thang, _nam, _data);
            ff.ShowDialog();
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


