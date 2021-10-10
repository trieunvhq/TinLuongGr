
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
    public partial class frmBTTL_PMC : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _nam, _thang, _id_bophan, _indexTongCa1 = 0;
        public string _ten_vthh;
        private DataTable _data;
        private DataTable _data_Ca2;

        private bool isload = true; 

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_PMC(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            //_data = new DataTable();
            //_data.Columns.Add("Thang", typeof(int));
            //_data.Columns.Add("Nam", typeof(int));
            //_data.Columns.Add("ID_CongNhan", typeof(int));
            //_data.Columns.Add("STT", typeof(string));
            //_data.Columns.Add("TenNhanVien", typeof(string));
            //_data.Columns.Add("Cong", typeof(string));
            //_data.Columns.Add("SanLuong", typeof(string));
            //_data.Columns.Add("DonGia", typeof(string));
            //_data.Columns.Add("ThanhTien", typeof(string));
            //_data.Columns.Add("XangXe", typeof(string));
            //_data.Columns.Add("Tong", typeof(string));
            //_data.Columns.Add("BaoHiem", typeof(string));
            //_data.Columns.Add("ThucNhan", typeof(string));

            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();
            CongBaoHiem.Caption = "CỘNG\nBẢO HIỂM";
            LuongTrachNhiem.Caption = "L.TRÁCH\nNHIỆM";
            TongTien.Caption = "TỔNG\nLƯƠNG";
            TruBaoHiem.Caption = "TRỪ BẢO\nHIỂM";
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
            double tongluong_tong_Ca1 = 0;
            double _TongTien_Tong_Ca1 = 0;
            double luongtrachnhiem_tong_Ca1 = 0;
            double trutamung_tong_Ca1 = 0;
            double thuclinh_tong_Ca1 = 0;
            double _NgayCong_Tong_Ca1 = 0;


            double tongluong_Ca1 = 0;
            double _TongTien_Ca1 = 0;
            double luongtrachnhiem_Ca1 = 0;
            double trutamung_Ca1 = 0;
            double thuclinh_Ca1 = 0;
            double _NgayCong_Ca1 = 0;

            //
            double tongluong_tong_Ca2 = 0;
            double _TongTien_Tong_Ca2 = 0;
            double luongtrachnhiem_tong_Ca2 = 0;
            double trutamung_tong_Ca2 = 0;
            double thuclinh_tong_Ca2 = 0;
            double _NgayCong_Tong_Ca2 = 0;


            double tongluong_Ca2 = 0;
            double _TongTien_Ca2 = 0;
            double luongtrachnhiem_Ca2 = 0;
            double trutamung_Ca2 = 0;
            double thuclinh_Ca2 = 0;
            double _NgayCong_Ca2 = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                //Lấy dữ liệu ca1
                _data = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, true);
                _indexTongCa1 = _data.Rows.Count;
                //Lấy dữ liệu ca2
                _data_Ca2 = clsThin_.Tr_BTTL_SF_CheckIsTangCa(_nam, _thang, _id_bophan, false);

                int SttCa1 = 0;
                int ID_congNhanRoot = -1;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());

                    _data.Rows[i]["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();

                    //Lương cơ bản:
                    double LuongCoBan = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    _data.Rows[i]["DonGia"] = LuongCoBan.ToString("N0");

                    //Ngày công:
                    _NgayCong_Ca1 = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong_Value"].ToString());
                    _data.Rows[i]["SanLuong"] = _NgayCong_Ca1.ToString("N2");
                    _NgayCong_Tong_Ca1 += _NgayCong_Ca1;

                    ////Loại công:
                    //string LoaiCong = _data.Rows[i]["Cong"].ToString();
                    //_data.Rows[i]["TenVTHH"] = LoaiCong;

                    //if (LoaiCong.ToLower().Contains("tăng"))
                    //{
                    //    //Đơn giá tăng ca:
                    //    LuongCoBan = CheckString.ConvertToDouble_My(_data.Rows[i]["DinhMucLuongTangCa"].ToString());
                    //}
                    //else if (LoaiCong.ToLower().Contains("công nhật"))
                    //{
                    //    //Đơn giá công nhật
                    //    LuongCoBan = CheckString.ConvertToDouble_My(_data.Rows[i]["DinhMucLuongTheoGio"].ToString());
                    //}
                    //else
                    //{
                    //    //Đơn giá của các loại công còn lại:
                    //    LuongCoBan = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongCoDinh"].ToString());
                    //}

                    //tổng lương:
                    tongluong_Ca1 = CheckString.ConvertToDouble_My(_data.Rows[i]["TongLuong_Value"].ToString());
                    tongluong_tong_Ca1 += tongluong_Ca1;
                    _data.Rows[i]["TongLuong"] = (tongluong_Ca1).ToString("N0");

                    //
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ID_congNhanRoot = ID_congNhan;

                        //STT
                        SttCa1++;
                        _data.Rows[i]["STT"] = SttCa1; 

                        //
                        luongtrachnhiem_Ca1 = CheckString.ConvertToDouble_My(_data.Rows[i]["LuongTrachNhiem_Value"].ToString());
                        luongtrachnhiem_tong_Ca1 += luongtrachnhiem_Ca1;
                        if (luongtrachnhiem_Ca1 == 0)
                            _data.Rows[i]["LuongTrachNhiem"] = "";
                        else
                            _data.Rows[i]["LuongTrachNhiem"] = luongtrachnhiem_Ca1.ToString("N0");

                        trutamung_Ca1 = CheckString.ConvertToDouble_My(_data.Rows[i]["TamUng_Value"].ToString());
                        trutamung_tong_Ca1 += trutamung_Ca1;
                        if (trutamung_Ca1 == 0)
                            _data.Rows[i]["TamUng"] = "";
                        else
                            _data.Rows[i]["TamUng"] = trutamung_Ca1.ToString("N0");

                        //Tổng tiền
                        _TongTien_Ca1 = TongMotNV(ID_congNhan, _data) + luongtrachnhiem_Ca1;
                        _TongTien_Tong_Ca1 += _TongTien_Ca1;
                        _data.Rows[i]["TongTien"] = (_TongTien_Ca1).ToString("N0");


                        thuclinh_Ca1 = (_TongTien_Ca1 - trutamung_Ca1);
                        thuclinh_tong_Ca1 += thuclinh_Ca1;
                        _data.Rows[i]["ThucNhan"] = (thuclinh_Ca1).ToString("N0");
                    }
                    else
                    {
                        _data.Rows[i]["STT"] = SttCa1;
                        _data.Rows[i]["LuongTrachNhiem"] = "";
                        _data.Rows[i]["TongTien"] = "";
                        _data.Rows[i]["TamUng"] = "";
                        _data.Rows[i]["ThucNhan"] = "";
                    }
                }

                //Add thêm row tổng ca 1:
                DataRow _ravi = _data.NewRow();
                _ravi["ID_CongNhan"] = 0;
                _ravi["Thang"] = _thang;
                _ravi["Nam"] = _nam;
                _ravi["TenNhanVien"] = "Tổng ca 1";

                //
                if (_NgayCong_Tong_Ca1 == 0)
                {
                    _ravi["SanLuong"] = "";
                }
                else
                {
                    _ravi["SanLuong"] = _NgayCong_Tong_Ca1.ToString("N0");
                }

                //
                if (tongluong_tong_Ca1 == 0)
                {
                    _ravi["TongLuong"] = "";
                }
                else
                {
                    _ravi["TongLuong"] = tongluong_tong_Ca1.ToString("N0");
                }

                // 
                if (luongtrachnhiem_tong_Ca1 == 0)
                {
                    _ravi["LuongTrachNhiem"] = "";
                }
                else
                {
                    _ravi["LuongTrachNhiem"] = luongtrachnhiem_tong_Ca1.ToString("N0");
                }

                //
                if (_TongTien_Tong_Ca1 == 0)
                {
                    _ravi["TongTien"] = "";
                }
                else
                {
                    _ravi["TongTien"] = _TongTien_Tong_Ca1.ToString("N0");
                }

                // 
                if (trutamung_tong_Ca1 == 0)
                {
                    _ravi["TamUng"] = "";
                }
                else
                {
                    _ravi["TamUng"] = trutamung_tong_Ca1.ToString("N0");
                }

                // 
                if (thuclinh_tong_Ca1 == 0)
                {
                    _ravi["ThucNhan"] = "";
                }
                else
                {
                    _ravi["ThucNhan"] = thuclinh_tong_Ca1.ToString("N0");
                }

                _data.Rows.Add(_ravi);

                //Ca 2:
                int SttCa2 = 0;
                ID_congNhanRoot = -1;
                for (int i = 0; i < _data_Ca2.Rows.Count; ++i)
                {
                    DataRow _ravi_Ca2 = _data.NewRow();

                    int ID_congNhan = Convert.ToInt32(_data_Ca2.Rows[i]["ID_CongNhan"].ToString());

                    _ravi_Ca2["TenNhanVien"] = _data_Ca2.Rows[i]["TenNhanVien"].ToString();

                    //Lương cơ bản:
                    double LuongCoBan = CheckString.ConvertToDouble_My(_data_Ca2.Rows[i]["DonGia_Value"].ToString());
                    _ravi_Ca2["DonGia"] = LuongCoBan.ToString("N0");

                    //Ngày công:
                    _NgayCong_Ca2 = CheckString.ConvertToDouble_My(_data_Ca2.Rows[i]["SanLuong_Value"].ToString());
                    _ravi_Ca2["SanLuong"] = _NgayCong_Ca2.ToString("N2");
                    _NgayCong_Tong_Ca2 += _NgayCong_Ca2;

                    //tổng lương:
                    tongluong_Ca2 = CheckString.ConvertToDouble_My(_data_Ca2.Rows[i]["TongLuong_Value"].ToString());
                    tongluong_tong_Ca2 += tongluong_Ca2;
                    _ravi_Ca2["TongLuong"] = (tongluong_Ca2).ToString("N0");

                    //
                    if (ID_congNhanRoot != ID_congNhan)
                    {
                        ID_congNhanRoot = ID_congNhan;

                        //STT
                        SttCa2++;
                        _ravi_Ca2["STT"] = SttCa2;

                        //
                        luongtrachnhiem_Ca2 = CheckString.ConvertToDouble_My(_data_Ca2.Rows[i]["LuongTrachNhiem_Value"].ToString());
                        luongtrachnhiem_tong_Ca2 += luongtrachnhiem_Ca2;
                        if (luongtrachnhiem_Ca2 == 0)
                            _ravi_Ca2["LuongTrachNhiem"] = "";
                        else
                            _ravi_Ca2["LuongTrachNhiem"] = luongtrachnhiem_Ca2.ToString("N0");

                        trutamung_Ca2 = CheckString.ConvertToDouble_My(_data_Ca2.Rows[i]["TamUng_Value"].ToString());
                        trutamung_tong_Ca2 += trutamung_Ca2;
                        if (trutamung_Ca2 == 0)
                            _ravi_Ca2["TamUng"] = "";
                        else
                            _ravi_Ca2["TamUng"] = trutamung_Ca2.ToString("N0");

                        //Tổng tiền
                        _TongTien_Ca2 = TongMotNV(ID_congNhan, _data_Ca2) + luongtrachnhiem_Ca2;
                        _TongTien_Tong_Ca2 += _TongTien_Ca2;
                        _ravi_Ca2["TongTien"] = (_TongTien_Ca2).ToString("N0");


                        thuclinh_Ca2 = (_TongTien_Ca2 - trutamung_Ca2);
                        thuclinh_tong_Ca2 += thuclinh_Ca2;
                        _ravi_Ca2["ThucNhan"] = (thuclinh_Ca2).ToString("N0");
                    }
                    else
                    {
                        _ravi_Ca2["STT"] = SttCa2;
                        _ravi_Ca2["LuongTrachNhiem"] = "";
                        _ravi_Ca2["TongTien"] = "";
                        _ravi_Ca2["TamUng"] = "";
                        _ravi_Ca2["ThucNhan"] = "";
                    }

                    _data.Rows.Add(_ravi_Ca2);
                }

                //Add thêm row tổng ca 2:
                DataRow _ravi2 = _data.NewRow();
                _ravi2["ID_CongNhan"] = 0;
                _ravi2["Thang"] = _thang;
                _ravi2["Nam"] = _nam;
                _ravi2["TenNhanVien"] = "Tổng ca 2";

                //
                if (_NgayCong_Tong_Ca2 == 0)
                {
                    _ravi2["SanLuong"] = "";
                }
                else
                {
                    _ravi2["SanLuong"] = _NgayCong_Tong_Ca2.ToString("N0");
                }

                //
                if (tongluong_tong_Ca2 == 0)
                {
                    _ravi2["TongLuong"] = "";
                }
                else
                {
                    _ravi2["TongLuong"] = tongluong_tong_Ca2.ToString("N0");
                }

                // 
                if (luongtrachnhiem_tong_Ca2 == 0)
                {
                    _ravi2["LuongTrachNhiem"] = "";
                }
                else
                {
                    _ravi2["LuongTrachNhiem"] = luongtrachnhiem_tong_Ca2.ToString("N0");
                }

                if (_TongTien_Tong_Ca2 == 0)
                {
                    _ravi["TongTien"] = "";
                }
                else
                {
                    _ravi["TongTien"] = _TongTien_Tong_Ca2.ToString("N0");
                }

                // 
                if (trutamung_tong_Ca2 == 0)
                {
                    _ravi2["TamUng"] = "";
                }
                else
                {
                    _ravi2["TamUng"] = trutamung_tong_Ca2.ToString("N0");
                }

                // 
                if (thuclinh_tong_Ca2 == 0)
                {
                    _ravi2["ThucNhan"] = "";
                }
                else
                {
                    _ravi2["ThucNhan"] = thuclinh_tong_Ca2.ToString("N0");
                }

                _data.Rows.Add(_ravi2);

                //Add thêm row tổng ca1+ ca2:
                DataRow _ravi2_Tong2Ca = _data.NewRow();
                _ravi2_Tong2Ca["ID_CongNhan"] = 0;
                _ravi2_Tong2Ca["Thang"] = _thang;
                _ravi2_Tong2Ca["Nam"] = _nam;
                _ravi2_Tong2Ca["TenNhanVien"] = "Tổng cộng";

                //
                if (_NgayCong_Tong_Ca1 + _NgayCong_Tong_Ca2 == 0)
                {
                    _ravi2_Tong2Ca["SanLuong"] = "";
                }
                else
                {
                    _ravi2_Tong2Ca["SanLuong"] = (_NgayCong_Tong_Ca1 + _NgayCong_Tong_Ca2).ToString("N0");
                }

                //
                if (tongluong_tong_Ca1 + tongluong_tong_Ca2 == 0)
                {
                    _ravi2_Tong2Ca["TongLuong"] = "";
                }
                else
                {
                    _ravi2_Tong2Ca["TongLuong"] = (tongluong_tong_Ca1 + tongluong_tong_Ca2).ToString("N0");
                }

                // 
                if (luongtrachnhiem_tong_Ca1 + luongtrachnhiem_tong_Ca2 == 0)
                {
                    _ravi2_Tong2Ca["LuongTrachNhiem"] = "";
                }
                else
                {
                    _ravi2_Tong2Ca["LuongTrachNhiem"] = (luongtrachnhiem_tong_Ca1 + luongtrachnhiem_tong_Ca2).ToString("N0");
                }

                if (_TongTien_Tong_Ca1 + _TongTien_Tong_Ca2 == 0)
                {
                    _ravi["TongTien"] = "";
                }
                else
                {
                    _ravi["TongTien"] = (_TongTien_Tong_Ca1 + _TongTien_Tong_Ca2).ToString("N0");
                }

                // 
                if (trutamung_tong_Ca1 + trutamung_tong_Ca2 == 0)
                {
                    _ravi2_Tong2Ca["TamUng"] = "";
                }
                else
                {
                    _ravi2_Tong2Ca["TamUng"] = (trutamung_tong_Ca1 + trutamung_tong_Ca2).ToString("N0");
                }

                // 
                if (thuclinh_tong_Ca1 + thuclinh_tong_Ca2 == 0)
                {
                    _ravi2_Tong2Ca["ThucNhan"] = "";
                }
                else
                {
                    _ravi2_Tong2Ca["ThucNhan"] = (thuclinh_tong_Ca1 + thuclinh_tong_Ca2).ToString("N0");
                }

                _data.Rows.Add(_ravi2_Tong2Ca);
            }

            

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

        private void frmBTTL_PMC_Load(object sender, EventArgs e)
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PhuMC_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PhuMC_CT(_thang, _nam, _data);
            ff.ShowDialog();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1 || e.RowHandle == _data.Rows.Count - 2 || e.RowHandle == _indexTongCa1)
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PhuMC_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_PhuMC_TQ(_thang, _nam, _data);
            ff.ShowDialog();
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


