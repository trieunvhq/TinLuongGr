using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmBangSanLuongToIn : Form
    {
        private DataTable _data;
        private List<GridColumn> ds_grid = new List<GridColumn>();
        private int _thang, _nam;
        private bool isload = true;

        DateTime ngaydauthang, ngaycuoithang;
        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;

       


        private bool _deleted_29 = false;
        private bool _deleted_30 = false;
        private bool _deleted_31 = false;

        public Tr_frmBangSanLuongToIn()
        {
            InitializeComponent();
            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);

            ds_grid = new List<GridColumn>();
            ds_grid.Add(Ngay1); ds_grid.Add(Ngay2); ds_grid.Add(Ngay3); ds_grid.Add(Ngay4); ds_grid.Add(Ngay5);
            ds_grid.Add(Ngay6); ds_grid.Add(Ngay7); ds_grid.Add(Ngay8); ds_grid.Add(Ngay9); ds_grid.Add(Ngay10);
            ds_grid.Add(Ngay11); ds_grid.Add(Ngay12); ds_grid.Add(Ngay13); ds_grid.Add(Ngay14); ds_grid.Add(Ngay15);
            ds_grid.Add(Ngay16); ds_grid.Add(Ngay17); ds_grid.Add(Ngay18); ds_grid.Add(Ngay19); ds_grid.Add(Ngay20);
            ds_grid.Add(Ngay21); ds_grid.Add(Ngay22); ds_grid.Add(Ngay23); ds_grid.Add(Ngay24); ds_grid.Add(Ngay25);
            ds_grid.Add(Ngay26); ds_grid.Add(Ngay27); ds_grid.Add(Ngay28); ds_grid.Add(Ngay29); ds_grid.Add(Ngay30);
            ds_grid.Add(Ngay31);

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("ID_CongNhan", typeof(string)); 
            _data.Columns.Add("TenNhanVien", typeof(string)); 
            _data.Columns.Add("HinhThuc", typeof(string));
            _data.Columns.Add("Ngay1", typeof(string));
            _data.Columns.Add("Ngay2", typeof(string));
            _data.Columns.Add("Ngay3", typeof(string));
            _data.Columns.Add("Ngay4", typeof(string));
            _data.Columns.Add("Ngay5", typeof(string));
            _data.Columns.Add("Ngay6", typeof(string));
            _data.Columns.Add("Ngay7", typeof(string));
            _data.Columns.Add("Ngay8", typeof(string));
            _data.Columns.Add("Ngay9", typeof(string));
            _data.Columns.Add("Ngay10", typeof(string));
            _data.Columns.Add("Ngay11", typeof(string));
            _data.Columns.Add("Ngay12", typeof(string));
            _data.Columns.Add("Ngay13", typeof(string));
            _data.Columns.Add("Ngay14", typeof(string));
            _data.Columns.Add("Ngay15", typeof(string));
            _data.Columns.Add("Ngay16", typeof(string));
            _data.Columns.Add("Ngay17", typeof(string));
            _data.Columns.Add("Ngay18", typeof(string));
            _data.Columns.Add("Ngay19", typeof(string));
            _data.Columns.Add("Ngay20", typeof(string));
            _data.Columns.Add("Ngay21", typeof(string));
            _data.Columns.Add("Ngay22", typeof(string));
            _data.Columns.Add("Ngay23", typeof(string));
            _data.Columns.Add("Ngay24", typeof(string));
            _data.Columns.Add("Ngay25", typeof(string));
            _data.Columns.Add("Ngay26", typeof(string));
            _data.Columns.Add("Ngay27", typeof(string));
            _data.Columns.Add("Ngay28", typeof(string));
            _data.Columns.Add("Ngay29", typeof(string));
            _data.Columns.Add("Ngay30", typeof(string));
            _data.Columns.Add("Ngay31", typeof(string));
            _data.Columns.Add("Tong", typeof(string));
            _data.Columns.Add("SLGiayCuon", typeof(string));
            _data.Columns.Add("VuotSL", typeof(string));
            _data.Columns.Add("SoNgayCong", typeof(string));

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl2.RepositoryItems.Add(emptyEditor);
        }

        private void Tr_frmBangSanLuongToIn_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(true);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            double Tong_SLGiayCuon = 0;
            double Tong_VuotSanLuong = 0;
            double[] DsTongNgay = new double[31];
            for (int i = 0; i < 31; i++) DsTongNgay[i] = 0;

            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }
            else
            {
            }

            ChangeColTitle(_thang, _nam);

            try
            {
                using (clsThin clsth = new clsThin())
                {
                    DataTable dt = clsth.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 1, 0, 0, "");
                    int ID_congNhanRoot = -1;
                    int SttCa1 = 0;

                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        int ID_congNhan = Convert.ToInt32(dt.Rows[i]["ID_CongNhan"].ToString());

                        ModelShowSanLuongToIn nvSL_thuong = getNV_SanLuong(ID_congNhan, "thường", dt);
                        ModelShowSanLuongToIn nvSL_nhu = getNV_SanLuong(ID_congNhan, "in nhũ", dt);
                        ModelShowSanLuongToIn nvSL_mac = getNV_SanLuong(ID_congNhan, "in mác", dt);
                        ModelShowSanLuongToIn nvSL_tb = getNV_SanLuong(ID_congNhan, "in trúc bách", dt);

                        //
                        if (ID_congNhanRoot != ID_congNhan)
                        {
                            ID_congNhanRoot = ID_congNhan;
                            SttCa1++;
                            if (nvSL_thuong.SlTong > 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = dt.Rows[i]["TenNhanVien"].ToString();

                                ravi_["HinhThuc"] = "SL thường";

                                for (int k = 0; k < 31; k++)
                                {
                                    ravi_["Ngay" + (k + 1)] = nvSL_thuong.DsSLNgay[k];
                                    DsTongNgay[k] += nvSL_thuong.DsSLNgay[k];
                                }
                                ravi_["Tong"] = nvSL_thuong.SlTong;
                                ravi_["SLGiayCuon"] = nvSL_thuong.SoNgayCong * 40;
                                ravi_["VuotSL"] = nvSL_thuong.SlTong - (nvSL_thuong.SoNgayCong * 40);
                                ravi_["SoNgayCong"] = nvSL_thuong.SoNgayCong;

                                Tong_SLGiayCuon += nvSL_thuong.SoNgayCong * 40;
                                Tong_VuotSanLuong += nvSL_thuong.SlTong - (nvSL_thuong.SoNgayCong * 40);

                                _data.Rows.Add(ravi_);
                            }

                            //Hàng nhũ
                            if (nvSL_nhu.SlTong > 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = dt.Rows[i]["TenNhanVien"].ToString();

                                ravi_["HinhThuc"] = "SL nhũ";

                                for (int k = 0; k < 31; k++)
                                {
                                    ravi_["Ngay" + (k + 1)] = nvSL_nhu.DsSLNgay[k];
                                    DsTongNgay[k] += nvSL_nhu.DsSLNgay[k];
                                }
                                ravi_["Tong"] = nvSL_nhu.SlTong;
                                ravi_["SLGiayCuon"] = nvSL_nhu.SlTong;
                                ravi_["VuotSL"] = "";
                                ravi_["SoNgayCong"] = nvSL_nhu.SoNgayCong;

                                Tong_SLGiayCuon += nvSL_nhu.SlTong;

                                _data.Rows.Add(ravi_);
                            }


                            //Hàng trúc bách
                            if (nvSL_tb.SlTong > 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = dt.Rows[i]["TenNhanVien"].ToString();

                                ravi_["HinhThuc"] = "SL TB";

                                for (int k = 0; k < 31; k++)
                                {
                                    ravi_["Ngay" + (k + 1)] = nvSL_tb.DsSLNgay[k];
                                    DsTongNgay[k] += nvSL_tb.DsSLNgay[k];
                                }
                                ravi_["Tong"] = nvSL_tb.SlTong;
                                ravi_["SLGiayCuon"] = nvSL_tb.SlTong;
                                ravi_["VuotSL"] = "";
                                ravi_["SoNgayCong"] = nvSL_tb.SoNgayCong;

                                Tong_SLGiayCuon += nvSL_tb.SlTong;

                                _data.Rows.Add(ravi_);
                            }

                            //Hàng in mác
                            if (nvSL_mac.SlTong > 0)
                            {
                                DataRow ravi_ = _data.NewRow();
                                ravi_["ID_CongNhan"] = ID_congNhan;
                                ravi_["STT"] = SttCa1;
                                ravi_["TenNhanVien"] = dt.Rows[i]["TenNhanVien"].ToString();

                                ravi_["HinhThuc"] = "SL mác";

                                for (int k = 0; k < 31; k++)
                                {
                                    ravi_["Ngay" + (k + 1)] = nvSL_mac.DsSLNgay[k];
                                    DsTongNgay[k] += nvSL_mac.DsSLNgay[k];
                                }
                                ravi_["Tong"] = nvSL_mac.SlTong;
                                ravi_["SLGiayCuon"] = nvSL_mac.SlTong;
                                ravi_["VuotSL"] = "";
                                ravi_["SoNgayCong"] = nvSL_mac.SoNgayCong;

                                Tong_SLGiayCuon += nvSL_mac.SlTong;

                                _data.Rows.Add(ravi_);
                            }
                        }
                        else
                        {

                        }
                    }

                    DataRow _ravi2 = _data.NewRow();
                    _ravi2["ID_CongNhan"] = 0;
                    _ravi2["TenNhanVien"] = "";
                    _ravi2["HinhThuc"] = "Sản lượng";


                    double tong_tong = 0;
                    for (int i = 0; i < 31; i++)
                    {
                        _ravi2["Ngay" + (i+1)] = String.Format("{0:0.##}", DsTongNgay[i]);
                        tong_tong += DsTongNgay[i];
                    }
                    _ravi2["Tong"] = String.Format("{0:0.##}", tong_tong);
                    _ravi2["SLGiayCuon"] = String.Format("{0:0.##}", Tong_SLGiayCuon);
                    _ravi2["VuotSL"] = String.Format("{0:0.##}", Tong_VuotSanLuong);
                    _ravi2["SoNgayCong"] = "";

                    _data.Rows.Add(_ravi2);
                }

                gridControl2.DataSource = _data;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            int soNgayCong = 0;
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

                                    nv.DsSLNgay[NgaySX] += sl;

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

                                    nv.DsSLNgay[NgaySX] += sl;

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

                                    nv.DsSLNgay[NgaySX] += sl;

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

                                    nv.DsSLNgay[NgaySX] += sl;

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

        private string LayThu(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                case DayOfWeek.Sunday:
                    return "CN";
            }
            return "";
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            }
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            _thang = Convert.ToInt32(txtThang.Text);
            LoadData(false);
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            _nam = Convert.ToInt32(txtNam.Text);
            LoadData(false);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangSanLuongToIN ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangSanLuongToIN(_thang, _nam, _data);
            ff.Show();
        }

        private void ChangeColTitle(int thang, int nam)
        {
            if (thang <= 0 || thang > 12 || nam <= 1900)
            {
                DateTime dtnow = DateTime.Now;
                nam = DateTime.Now.Year;
                thang = DateTime.Now.Month;
            }
            DateTime date_ = new DateTime(nam, thang, 1);
            int ngaycuathang_ = (((new DateTime(nam, thang, 1)).AddMonths(1)).AddDays(-1)).Day;
            if (ngaycuathang_ == 28)
            {
                Ngay31.Visible = false;
                Ngay30.Visible = false;
                Ngay29.Visible = false;

                _deleted_29 = true;
                _deleted_30 = true;
                _deleted_31 = true;
            }
            else if (ngaycuathang_ == 29)
            {
                Ngay31.Visible = false;
                Ngay30.Visible = false;
                Ngay29.Visible = true;
                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = true;
                _deleted_31 = true;
            }
            else if (ngaycuathang_ == 30)
            {
                Ngay31.Visible = false;
                Ngay29.Visible = true;
                Ngay30.Visible = true;
                _deleted_31 = true;

                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;
                if (_deleted_30) Ngay30.VisibleIndex = Ngay29.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = false;
            }
            else if (ngaycuathang_ == 31)
            {
                Ngay29.Visible = true;
                Ngay30.Visible = true;
                Ngay31.Visible = true;
                if (_deleted_29) Ngay29.VisibleIndex = Ngay28.VisibleIndex + 1;
                if (_deleted_30) Ngay30.VisibleIndex = Ngay29.VisibleIndex + 1;
                if (_deleted_31) Ngay31.VisibleIndex = Ngay30.VisibleIndex + 1;

                _deleted_29 = false;
                _deleted_30 = false;
                _deleted_31 = false;
            }
            string thu_ = LayThu(date_);
            for (int i = 0; i < ngaycuathang_; ++i)
            {
                ds_grid[i].Caption = (i + 1) + "\n" + LayThu(new DateTime(nam, thang, (i + 1)));
                if (ds_grid[i].Caption.Contains("CN"))
                {
                    ds_grid[i].AppearanceCell.BackColor = Color.LightGray;
                    ds_grid[i].AppearanceHeader.BackColor = Color.LightGray;
                    ds_grid[i].AppearanceHeader.ForeColor = Color.Red;
                    ds_grid[i].AppearanceCell.ForeColor = Color.Red;
                }
                else
                {
                    ds_grid[i].AppearanceCell.BackColor = Color.White;
                    ds_grid[i].AppearanceHeader.BackColor = Color.White;
                    ds_grid[i].AppearanceHeader.ForeColor = Color.Black;
                    ds_grid[i].AppearanceCell.ForeColor = Color.Black;
                }
            }
        }

        private string thutrongtuanxyz(int ewwd)
        {

            string xxx = "";
            if (ewwd == 0)
                xxx = "Thứ 7";
            else if (ewwd.ToString() == "1")
                xxx = "Chủ nhật ";
            else xxx = "Thứ " + ewwd.ToString() + "";
            return xxx;
        }

    }
}
