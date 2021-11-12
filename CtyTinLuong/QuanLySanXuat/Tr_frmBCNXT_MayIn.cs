
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
    public partial class Tr_frmBCNXT_MayIn : UserControl
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

        public Tr_frmBCNXT_MayIn(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();
        }

        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
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
                _data = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "", _id_bophan);

                int ID_congNhanRoot = -1;
                int stt = 0;

                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    double dongia_ = CheckString.ConvertToDouble_My(_data.Rows[i]["DonGia_Value"].ToString());
                    _data.Rows[i]["DonGia"] = dongia_.ToString("N0");

                    int ID_congNhan = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());

                    double sanluong_ = CheckString.ConvertToDouble_My(_data.Rows[i]["SanLuong"].ToString());

                    //Tổng lương (đơn giá * sản lượng):
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


                        //Tổng tiền
                        tong_ = TongMotNV(ID_congNhan, _data);
                        tong_tong_ += tong_;
                        _data.Rows[i]["TongTien"] = (tong_).ToString("N0");

                        //thực nhận
                        thuclinh_ = (tong_ - trutamung_);
                        thuclinh_tong_ += thuclinh_;
                        _data.Rows[i]["ThucNhan"] = (thuclinh_).ToString("N0");
                    }
                    else
                    {
                        _data.Rows[i]["STT"] = stt;

                        //Lương trách nhiệm:
                        _data.Rows[i]["LuongTrachNhiem"] = "";

                        //tạm ứng
                        _data.Rows[i]["TamUng"] = "";

                        //Tổng tiền
                        _data.Rows[i]["TongTien"] = "";

                        //thực nhận
                        _data.Rows[i]["ThucNhan"] = "";
                    }
                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["ID_CongNhan"] = 0;
            _ravi["Thang"] = _thang;
            _ravi["Nam"] = _nam;
            _ravi["TenNhanVien"] = "Tổng";
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

        private ModelShowSanLuongToIn getNV_SanLuong(int idcn, string loaiVthh, DataTable dt)
        {
            ModelShowSanLuongToIn nv = new ModelShowSanLuongToIn();
            string hoTen = "";
            string tenVthhThuong = "";
            string tenVthhTang = "";
            double slTong = 0;
            double slThuong = 0;
            double slTang = 0;
            double donGiaThuong = 0;
            double donGiaTang = 0;
            double soNgayCong = 0;
            double phuCapBaoHiem = 0;
            double truBaoHiem = 0;
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                string loaiHH = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
                switch (loaiVthh)
                {
                    case "thường":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (!loaiHH.Contains("in mác") && !loaiHH.Contains("in trúc bách") && !loaiHH.Contains("in nhũ"))
                                {
                                    hoTen = item["TenVTHH"].ToString();
                                    double sl = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    slTong += sl;
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    nv.DsSLNgay[NgaySX - 1] += sl;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in nhũ":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in nhũ"))
                                {
                                    hoTen = item["TenVTHH"].ToString();
                                    double sl = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    slTong += sl;
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    nv.DsSLNgay[NgaySX - 1] += sl;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in mác":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in mác"))
                                {
                                    hoTen = item["TenVTHH"].ToString();
                                    double sl = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    slTong += sl;
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    nv.DsSLNgay[NgaySX - 1] += sl;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "in trúc bách":
                        {
                            if (idcn == Convert.ToInt32(item["ID_CongNhan"].ToString()))
                            {
                                if (loaiHH.Contains("in trúc bách"))
                                {
                                    hoTen = item["TenVTHH"].ToString();
                                    double sl = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                                    slTong += sl;
                                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                                    nv.DsSLNgay[NgaySX - 1] += sl;

                                    if (CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString()) > 0)
                                    {
                                        if (!dsNgayCong.Contains(NgaySX))
                                        {
                                            dsNgayCong.Add(NgaySX);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }

            soNgayCong = dsNgayCong.Count;

            if (loaiVthh.Contains("in mác"))
            {
                slThuong = slTong;
                tenVthhThuong = "Sản lượng máy in mác";
                tenVthhTang = "";
            }
            else if (loaiVthh.Contains("in trúc bách"))
            {
                slThuong = slTong;
                tenVthhThuong = "Sản lượng máy in TB";
                tenVthhTang = "";
            }
            else if (loaiVthh.Contains("in nhũ"))
            {
                //if ((slTong - (soNgayCong * 35)) > 0)
                //{
                //    slThuong = soNgayCong * 35;
                //    slTang = slTong - (soNgayCong * 40);
                //}
                //else slThuong = slTong;
                slThuong = slTong;

                phuCapBaoHiem = slTong * 900000 / 910;

                tenVthhThuong = "Sản lượng giấy cuộn nhũ";
                tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
            }
            else
            {
                if ((slTong - (soNgayCong * 40)) > 0)
                {
                    slThuong = soNgayCong * 40;
                    slTang = slTong - (soNgayCong * 40);
                }
                else slThuong = slTong;

                phuCapBaoHiem = slTong * 900000 / 1040;

                tenVthhThuong = "Sản lượng giấy cuộn";
                tenVthhTang = "Sản lượng vượt 40q/ca/tháng";
            }

            nv.HoTen = hoTen;
            nv.TenVthhThuong = tenVthhThuong;
            nv.TenVthhTang = tenVthhTang;
            nv.SlTong = slTong;
            nv.SlThuong = slThuong;
            nv.SlTang = slTang;
            nv.DonGiaThuong = donGiaThuong;
            nv.DonGiaTang = donGiaTang;
            nv.SoNgayCong = soNgayCong;
            nv.ThanhTienThuong = slThuong * donGiaThuong;
            nv.ThanhTienTang = slTang * donGiaTang;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
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


        private void Tr_frmBCNXT_MayIn_Load(object sender, EventArgs e)
        {
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT(_thang, _nam, _data);
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

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_TQ(_thang, _nam, _data);
            ff.Show();
        }


        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}


