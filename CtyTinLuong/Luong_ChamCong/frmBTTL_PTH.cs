
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
    public partial class frmBTTL_PTH : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true; 

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_PTH(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();

            //ColSanLuong.Caption = "NGÀY\nCÔNG";
            ColSanLuong.Caption = "CÔNG\n/SL";
            ColCongBaoHiem.Caption = "PHỤ CẤP\nBẢO HIỂM";
            ColLuongTrachNhiem.Caption = "L.TRÁCH\nNHIỆM";
            ColTongTien.Caption = "TỔNG\nLƯƠNG";
            TruBaoHiem.Caption = "TRỪ\nBẢO HIỂM";
            DonGia.Caption = "LƯƠNG\nCƠ BẢN";
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
            double _TruBaoHiem_Tong = 0;
            double PhuCapBH_Tong = 0;



            double tongluong_ = 0;
            double luongtrachnhiem_ = 0;
            double tong_ = 0;
            double trutamung_ = 0;
            double _TruBaoHiem = 0;
            double PhuCapBH_ = 0;
            double thuclinh_ = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.Tr_BTTL_SF_NoCheckTime(_nam, _thang, _id_bophan);

                int ID_congNhanRoot = -1;
                int stt = 0;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    double dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());

                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());

                    //Tổng:
                    tongluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TongLuong_Value"].ToString());
                    tongluong_tong_ += tongluong_;
                    _data.Rows[i]["TongLuong"] = tongluong_.ToString("N0");

                    //
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        //
                        ID_congNhanRoot = ID_congNhan;
                        stt++;
                        _data.Rows[i]["STT"] = stt;

                        //PC bảo hiểm:
                        PhuCapBH_ = CheckString.ConvertToDouble_My(_data.Rows[i]["PhuCapBaoHiem_Value"].ToString());
                        PhuCapBH_Tong += PhuCapBH_;
                        if (PhuCapBH_ == 0)
                            _data.Rows[i]["CongBaoHiem"] = "";
                        else
                            _data.Rows[i]["CongBaoHiem"] = PhuCapBH_.ToString("N0");

                        //Trừ bảo hiểm:

                        _TruBaoHiem = CheckString.ConvertToDouble_My(_data.Rows[i]["BaoHiem_Value"].ToString());
                        _TruBaoHiem_Tong += _TruBaoHiem;
                        if (_TruBaoHiem == 0)
                            _data.Rows[i]["BaoHiem"] = "";
                        else
                            _data.Rows[i]["BaoHiem"] = _TruBaoHiem.ToString("N0");

                        //Lương trách nhiệm:
                        luongtrachnhiem_ = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongTrachNhiem_Value"].ToString());
                        luongtrachnhiem_tong_ += luongtrachnhiem_;
                        if (luongtrachnhiem_ == 0)
                            _data.Rows[i]["LuongTrachNhiem"] = "";
                        else
                            _data.Rows[i]["LuongTrachNhiem"] = luongtrachnhiem_.ToString("N0");

                        //tạm ứng
                        trutamung_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        trutamung_tong_ += trutamung_;
                        if (trutamung_ == 0)
                            _data.Rows[i]["TamUng"] = "";
                        else
                            _data.Rows[i]["TamUng"] = trutamung_.ToString("N0");


                        //Tổng Lương: = tổng + PCBH + trách nhiệm:
                        tong_ = TongMotNV(ID_congNhan, _data) + PhuCapBH_ + luongtrachnhiem_;
                        tong_tong_ += tong_;
                        _data.Rows[i]["TongTien"] = (tong_).ToString("N0");

                        //thực nhận
                        thuclinh_ = (tong_ - trutamung_ - _TruBaoHiem);
                        thuclinh_tong_ += thuclinh_;
                        _data.Rows[i]["ThucNhan"] = (thuclinh_).ToString("N0");
                    }
                    else
                    {
                        _data.Rows[i]["STT"] = stt;

                        _data.Rows[i]["CongBaoHiem"] = "";
                        _data.Rows[i]["BaoHiem"] = "";
                        _data.Rows[i]["LuongTrachNhiem"] = "";
                        _data.Rows[i]["TamUng"] = "";
                        _data.Rows[i]["TongTien"] = "";
                        _data.Rows[i]["ThucNhan"] = "";
                    }
                }
            }


            //using (clsThin clsThin_ = new clsThin())
            //{
            //    /// tang ca
            //    _data = clsThin_.Tr_BTTL_SF(_nam, _thang, _id_bophan, true);

            //    int ID_congNhanRoot = -1;
            //    int stt = 0;

            //    for (int i = 0; i < _data.Rows.Count; ++i)
            //    {
            //        //_data.Rows[i]["TenVTHH"] = "Tăng ca";

            //        PhuCapBH_ = CheckString.ConvertToDouble_My(_data.Rows[i]["PhuCapBaoHiem_Value"].ToString());
            //        PhuCapBH_Tong += PhuCapBH_;
            //        if (PhuCapBH_ == 0)
            //            _data.Rows[i]["CongBaoHiem"] = "";
            //        else
            //            _data.Rows[i]["CongBaoHiem"] = PhuCapBH_.ToString("N0");

            //        int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());


            //        _data.Rows[i]["DonGia"] = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString()).ToString("N0");


            //        _TruBaoHiem = CheckString.ConvertToDouble_My(_data.Rows[i]["BaoHiem_Value"].ToString());
            //        _TruBaoHiem_Tong += _TruBaoHiem;
            //        if (_TruBaoHiem == 0)
            //            _data.Rows[i]["BaoHiem"] = "";
            //        else
            //            _data.Rows[i]["BaoHiem"] = _TruBaoHiem.ToString("N0");

            //        //

            //        luongtrachnhiem_ = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongTrachNhiem_Value"].ToString());
            //        luongtrachnhiem_tong_ += luongtrachnhiem_;
            //        if (luongtrachnhiem_ == 0)
            //            _data.Rows[i]["LuongTrachNhiem"] = "";
            //        else
            //            _data.Rows[i]["LuongTrachNhiem"] = luongtrachnhiem_.ToString("N0");

            //        trutamung_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
            //        trutamung_tong_ += trutamung_;
            //        if (trutamung_ == 0)
            //            _data.Rows[i]["TamUng"] = "";
            //        else
            //            _data.Rows[i]["TamUng"] = trutamung_.ToString("N0");

            //        double tongluong1_ = CheckString.ConvertToDouble_My(_data.Rows[i]["TongLuong_Value"].ToString());
            //        _data.Rows[i]["TongLuong"] = tongluong1_.ToString("N0");

            //        tong_ = (tongluong1_ + luongtrachnhiem_ + PhuCapBH_);
            //        tong_tong_ += tong_;
            //        _data.Rows[i]["TongTien"] = (tong_).ToString("N0");

            //        thuclinh_ = (tong_ - trutamung_ - _TruBaoHiem);
            //        thuclinh_tong_ += thuclinh_;
            //        _data.Rows[i]["ThucNhan"] = (thuclinh_).ToString("N0");

            //    }
            //    // Cong nhat
            //    DataTable data2 = clsThin_.Tr_BTTL_SF(_nam, _thang, _id_bophan, false);

            //    for (int i = 0; i < data2.Rows.Count; ++i)
            //    {
            //        DataRow _ravi2 = _data.NewRow();
            //        _ravi2["TenNhanVien"] = data2.Rows[i]["TenNhanVien"].ToString();
            //        //_ravi2["TenVTHH"] = data2.Rows[i]["TenLoaiCong"].ToString(); //Tên loại công


            //        PhuCapBH_ = CheckString.ConvertToDouble_My(data2.Rows[i]["PhuCapBaoHiem_Value"].ToString());
            //        PhuCapBH_Tong += PhuCapBH_;
            //        if (PhuCapBH_ == 0)
            //            _ravi2["CongBaoHiem"] = "";
            //        else
            //            _ravi2["CongBaoHiem"] = PhuCapBH_.ToString("N0");

            //        int ID_congNhan2 = Convert.ToInt32(data2.Rows[i]["ID_CongNhan"].ToString());


            //        _ravi2["DonGia"] = CheckString.ConvertToDouble_My(data2.Rows[i]["DonGia_Value"].ToString()).ToString("N0");


            //        _TruBaoHiem = CheckString.ConvertToDouble_My(data2.Rows[i]["BaoHiem_Value"].ToString());
            //        _TruBaoHiem_Tong += _TruBaoHiem;
            //        if (_TruBaoHiem == 0)
            //            _ravi2["BaoHiem"] = "";
            //        else
            //            _ravi2["BaoHiem"] = _TruBaoHiem.ToString("N0");

            //        //

            //        luongtrachnhiem_ = CheckString.ConvertToDouble_My(data2.Rows[i]["LuongTrachNhiem_Value"].ToString());
            //        luongtrachnhiem_tong_ += luongtrachnhiem_;
            //        if (luongtrachnhiem_ == 0)
            //            _ravi2["LuongTrachNhiem"] = "";
            //        else
            //            _ravi2["LuongTrachNhiem"] = luongtrachnhiem_.ToString("N0");

            //        trutamung_ = CheckString.ConvertToDouble_My(data2.Rows[i]["TamUng_Value"].ToString());
            //        trutamung_tong_ += trutamung_;
            //        if (trutamung_ == 0)
            //            _ravi2["TamUng"] = "";
            //        else
            //            _ravi2["TamUng"] = trutamung_.ToString("N0");

            //        double tongluong2_ = CheckString.ConvertToDouble_My(data2.Rows[i]["TongLuong_Value"].ToString());
            //        _ravi2["TongLuong"] = tongluong2_.ToString("N0");

            //        tong_ = (tongluong2_ + luongtrachnhiem_ + PhuCapBH_);
            //        tong_tong_ += tong_;
            //        _ravi2["TongTien"] = (tong_).ToString("N0");

            //        thuclinh_ = (tong_ - trutamung_ - _TruBaoHiem);
            //        thuclinh_tong_ += thuclinh_;
            //        _ravi2["ThucNhan"] = (thuclinh_).ToString("N0");
            //        //chen vao ben duoi tang ca cua 1 cong nhan
            //        for (int zz = 0; zz < _data.Rows.Count; ++zz)
            //        {
            //            if (_data.Rows[zz]["ID_CongNhan"].ToString() == ID_congNhan2.ToString())
            //            {
            //                _data.Rows.InsertAt(_ravi2, zz + 1);
            //                break;
            //            }
            //        }
            //    }
            //}

            //

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
            // 
            if (luongtrachnhiem_tong_ == 0)
            {
                _ravi["LuongTrachNhiem"] = "";
            }
            else
            {
                _ravi["LuongTrachNhiem"] = luongtrachnhiem_tong_.ToString("N0");
            } 
            // 
            if (_TruBaoHiem_Tong == 0)
            {
                _ravi["BaoHiem"] = "";
            }
            else
            {
                _ravi["BaoHiem"] = _TruBaoHiem_Tong.ToString("N0");
            }

            //
            if (PhuCapBH_Tong == 0)
            {
                _ravi["CongBaoHiem"] = "";
            }
            else
            {
                _ravi["CongBaoHiem"] = PhuCapBH_Tong.ToString("N0");
            }

            _data.Rows.Add(_ravi);
            gridControl1.DataSource = _data;
            //  
            isload = false;
        }

        //Tính tổng:
        private double TongMotNV(int idcn, DataTable dt)
        {
            double Result = 0;

            foreach (DataRow item in dt.Rows)
            {
                if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                {
                    Result += CheckString.ConvertToDouble_My(item["TongLuong_Value"].ToString());
                }
            }

            return Result;
        }

        private void frmBTTL_PTH_Load(object sender, EventArgs e)
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PTH_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PTH_CT(_thang, _nam, _data);
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

        private void btnCheDoHienThi_Click(object sender, EventArgs e)
        {
            //if(ColSanLuong.Visible)
            //{
            //    ColSanLuong.Visible = false;
            //    ColTenVTHH.Visible = false;
            //    ColSanLuong.Visible = false;
            //    ColSanLuong.Visible = false;
            //}
            //else
            //{

            //}
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PTH_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PTH_TQ(_thang, _nam, _data);
            ff.Show();
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


