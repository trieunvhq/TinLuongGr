
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

        SanXuat_frmQuanLySanXuat _frmQLLCC;

        public Tr_frmBCNXT_MayIn(int id_bophan, SanXuat_frmQuanLySanXuat frmQLLCC)
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

        private ModelNXT_MayInCat getNV_SanLuong(int idVthh, DataTable dt)
        {
            ModelNXT_MayInCat nv = new ModelNXT_MayInCat();
            int NgayThang = 0;
            string DonViTinh = "";
            string MaHang = "";
            double TonDau = 0;
            double TonCuoi = 0;
            double Nhap = 0;
            double Xuat = 0;
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
            }

            foreach (DataRow item in dt.Rows)
            {
                if (idVthh == Convert.ToInt32(item["ID_VTHH_Ra"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();

                    Nhap += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                    Xuat = CheckString.ConvertToDouble_My(item["Xuat"].ToString());
                    TonDau = CheckString.ConvertToDouble_My(item["TonDau"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                    if (!dsNgayCong.Contains(NgaySX))
                    {
                        dsNgayCong.Add(NgaySX);
                    }
                }
            }


            nv.NgayThang = 0;
            nv.DonViTinh = "";
            nv.MaHang = "";
            nv.TonDau = 0;
            nv.TonCuoi = 0;
            nv.Nhap = 0;
            nv.Xuat = 0;

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


