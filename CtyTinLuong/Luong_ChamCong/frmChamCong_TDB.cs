

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
    public partial class frmChamCong_TDB : UserControl
    {
        public string _MaNhanVien = "";
        public int  _ID_DinhMucLuong_CongNhat = 0;
        private string _MaDinhMucLuongCongNhat;
        public int _nam, _thang, _id_bophan = 25;
        private DataTable _data;
        private bool isload = true, _To1, _To2;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;

        public frmChamCong_TDB(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _ID_DinhMucLuong_CongNhat = 0;
            _MaDinhMucLuongCongNhat = "";
            _id_bophan = id_bophan;

            InitializeComponent();


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
            _data.Columns.Add("MaVT", typeof(string));
            _data.Columns.Add("DonViTinh", typeof(string));
            _data.Columns.Add("TenVTHH", typeof(string));
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

            this.cbHangHoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHangHoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;


            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);
            radioTo1.Checked = true;
        }
        public void Load_DinhMuc(int id_dinhmuc,string ma,int id_congnhan)
        {
            _ID_DinhMucLuong_CongNhat = id_dinhmuc;
            _MaDinhMucLuongCongNhat = ma;
            if (id_congnhan>0)
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    if(Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString())==id_congnhan)
                    {
                        _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                        _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                        if (i>0)
                        {
                            int j = i-1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                --j;
                                if (j < 0)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            } 
                        }
                        if (i < _data.Rows.Count-1)
                        {
                            int j = i + 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                ++j;
                                if (j >= _data.Rows.Count-1)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_VTHH"].ToString());
                            }
                        } 
                        break;
                    }
                    else
                    { }
                }
            }
            else
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                    _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                }
            }
            //gridControl1.DataSource = _data;
            GuiDuLieuBangLuong();
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

        private bool _deleted_29 = false;
        private bool _deleted_30 = false;
        private bool _deleted_31 = false;

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

        public void LoadData(bool islandau)
        {
            _data.Clear();

            isload = true;

            double SanLuong_Tong_Tong = 0;

            List<int> DsID_Vthh_ = new List<int>();

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
                    DataTable dt = clsth.Tr_Phieu_ChiTietPhieu_New_ToInCatDot_DongBao(_nam, _thang, 0, 1, 0, _id_bophan, radioTo1.Checked, radioTo2.Checked);
                    if (dt.Rows.Count == 0)
                    {
                        isload = false;
                        return;
                    }

                    int ID_VTHHRoot = -1;
                    int SttSL = 0;
                    int SttBL = 0;

                    double[] DsTong_Col = new double[31];

                    for (int i = 0; i < dt.Rows.Count; ++i)
                    {
                        int ID_VTHH = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Ra"].ToString());
                        string MaNV_ = dt.Rows[i]["MaNhanVien"].ToString();

                        if (ID_VTHH != ID_VTHHRoot && !DsID_Vthh_.Contains(ID_VTHH))
                        {
                            DsID_Vthh_.Add(ID_VTHH);
                            ID_VTHHRoot = ID_VTHH;

                            ModelShowSanLuongToIn vt = getNV_SanLuong(ID_VTHH, dt);

                            DataRow ravi_ = _data.NewRow();
                            SttSL++;
                            ravi_["STT"] = SttSL;
                            ravi_["MaVT"] = vt.MaVT;
                            ravi_["DonViTinh"] = dt.Rows[i]["DonViTinh"].ToString();
                            ravi_["TenVTHH"] = vt.TenVthhThuong;

                            for (int k = 0; k < 31; k++)
                            {
                                if (vt.DsSLNgay_Tong[k] == 0)
                                    ravi_["Ngay" + (k + 1)] = "";
                                else
                                    ravi_["Ngay" + (k + 1)] = vt.DsSLNgay_Tong[k].ToString("N0");
                                DsTong_Col[k] += vt.DsSLNgay_Tong[k];
                            }

                            if (vt.SlTong == 0)
                                ravi_["Tong"] = "";
                            else
                                ravi_["Tong"] = vt.SlTong.ToString("N0");
                            SanLuong_Tong_Tong += vt.SlTong;

                            _data.Rows.Add(ravi_);
                        }
                    }


                    //Tổng rows:
                    DataRow ravi_Tong_Col = _data.NewRow();
                    SttBL++;
                    ravi_Tong_Col["STT"] = "";
                    ravi_Tong_Col["MaVT"] = "";
                    ravi_Tong_Col["DonViTinh"] = "";
                    ravi_Tong_Col["TenVTHH"] = "Tổng";

                    for (int k = 0; k < 31; k++)
                    {
                        if (DsTong_Col[k] == 0)
                            ravi_Tong_Col["Ngay" + (k + 1)] = "";
                        else
                            ravi_Tong_Col["Ngay" + (k + 1)] = DsTong_Col[k].ToString("N0");
                    }

                    ravi_Tong_Col["Tong"] = SanLuong_Tong_Tong.ToString("N0");
                    _data.Rows.Add(ravi_Tong_Col);
                }
                gridControl1.DataSource = _data;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isload = false;
        }
        private ModelShowSanLuongToIn getNV_SanLuong(int idvthh, DataTable dt)
        {
            ModelShowSanLuongToIn nv = new ModelShowSanLuongToIn();
            string hoTen = "";
            string maVT = "";
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
            string LoaiHangHoa = "";

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = 0;
                nv.DsSLNgay_Tang[i] = 0;
                nv.DsSLNgay_Tong[i] = 0;
                nv.DsCong[i] = 0;
            }

            foreach (DataRow item in dt.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH_Ra"].ToString()))
                {
                    double SL_Tog_ = 0;
                    double Cong_ = 0;

                    hoTen = item["TenNhanVien"].ToString();
                    tenVthhThuong = item["TenVTHH"].ToString();
                    maVT = item["MaVT"].ToString();
                    donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                    donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
                    phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
                    truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
                    LoaiHangHoa = (CheckString.ChuanHoaHoTen(item["DienGiai"].ToString())).ToLower();
                    soNgayCong = CheckString.ConvertToDouble_My(item["SoNgayCong"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                    Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

                    SL_Tog_ = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                    slTong += SL_Tog_;

                    nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;

                    for (int i = 0; i < 31; i++)
                    {
                        nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i + 1)].ToString());
                    }
                }
            }

            for (int i = 0; i < 31; i++)
            {
                nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
                slThuong += nv.DsSLNgay[i];
            }


            nv.HoTen = hoTen;
            nv.MaVT = maVT;
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
            nv.TienTong = slThuong * donGiaThuong + slTang * donGiaTang;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
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
        private void frmChamCong_TDB_Load(object sender, EventArgs e)
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
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            if (GuiDuLieuBangLuong())
            {
                MessageBox.Show("Lưu dữ liệu chấm công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu lỗi", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCong_TDB ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintChamCong_TDB(_thang, _nam, _data, radioTo1.Checked, radioTo2.Checked);
            ff.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Tr_frmCaiMacDinnhMaHangTDB ff = new Tr_frmCaiMacDinnhMaHangTDB();
            Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_();
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  TenVTHH)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_VTHH).ToString());
                Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_();
                //Tr_frmCaiMacDinnhMaHangTDB ff = new Tr_frmCaiMacDinnhMaHangTDB();
                ff.Show();

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void radioCa1_CheckedChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            LoadData(false);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa công nhân khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                if (e.Column.FieldName == "Xoa")
                {
                    e.RepositoryItem = emptyEditor;
                }
            }
        }

        private void radioTo2_CheckedChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            LoadData(false);
        }

        private void radioCN_CheckedChanged(object sender, EventArgs e)
        {
            //if (isload)
            //    return;
            //LoadData(false);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
        private bool GuiDuLieuBangLuong()
        {
            bool isGuiThanhCong = false;
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        if (_data.Rows[i]["ID_VTHH"].ToString() == "")
                            continue;

                        int ID_VTHH = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                        if (ID_VTHH == 0)
                        {
                            continue;
                        }
                        else
                        {
                            isGuiThanhCong = true;
                        }
                        string Cong_ = _data.Rows[i]["Cong"].ToString();
                        bool isTang = false;
                        if (Cong_.Contains("Tăng"))
                        {
                            isTang = true;
                        }
                        clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            0,
                            _thang,
                            _nam,
                            ID_VTHH,
                            0,
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
                            0, true, radioTo1.Checked, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                    }
                    if (isGuiThanhCong)
                    {
                        LoadData(false);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu bảng chấm công. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isGuiThanhCong;
        }

        private void SaveOneCN(int idvthh_)
        {
            string tenVTHH_ = "";
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        tenVTHH_ = _data.Rows[i]["TenVTHH"].ToString();
                        int ID_VTHH = Convert.ToInt32(_data.Rows[i]["ID_VTHH"].ToString());
                        if (ID_VTHH == idvthh_)
                        {
                            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            0,
                            _thang,
                            _nam,
                            ID_VTHH,
                            0,
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay1"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay2"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay3"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay4"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay5"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay6"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay7"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay8"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay9"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay10"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay11"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay12"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay13"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay14"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay15"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay16"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay17"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay18"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay19"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay20"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay21"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay22"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay23"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay24"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay25"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay26"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay27"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay28"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay29"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay30"].ToString()),
                            (float)CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay31"].ToString()),
                            0, true, radioTo1.Checked, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu hàng hóa: " + tenVTHH_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOneCN_Datarow(DataRow dt_row)
        {
            string tenVTHH_ = "";
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    tenVTHH_ = dt_row["TenVTHH"].ToString();
                    int ID_VTHH = Convert.ToInt32(dt_row["ID_VTHH"].ToString());

                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                    0,
                    _thang,
                    _nam,
                    ID_VTHH,
                    0,
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay1"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay2"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay3"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay4"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay5"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay6"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay7"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay8"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay9"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay10"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay11"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay12"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay13"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay14"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay15"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay16"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay17"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay18"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay19"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay20"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay21"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay22"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay23"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay24"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay25"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay26"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay27"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay28"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay29"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay30"].ToString()),
                    (float)CheckString.ConvertToDouble_My(dt_row["Ngay31"].ToString()),
                    0, true, radioTo1.Checked, _id_bophan,
                    Convert.ToInt32(dt_row["ID_DinhMucLuong_CongNhat"].ToString()),
                    Convert.ToInt32(dt_row["ID_LoaiCong"].ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu hàng hóa: " + tenVTHH_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

