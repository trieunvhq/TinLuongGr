
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
    public partial class frmChamCong_ToIn : UserControl
    {
        public int  _ID_DinhMucLuong_CongNhat = 0;
        public int _nam, _thang, _id_bophan = 25;
        private string _MaDinhMucLuongCongNhat;
        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();
        public frmChamCong_ToIn(int id_bophan)
        {
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
             
        }
        public void Load_DinhMuc(int id_dinhmuc,string ma,int id_congnhan)
        {
            _ID_DinhMucLuong_CongNhat = id_dinhmuc;
            _MaDinhMucLuongCongNhat = ma;
            if (id_congnhan>0)
            {
                for (int i = 0; i < _data.Rows.Count - 1; ++i)
                {
                    if(Convert.ToDouble(_data.Rows[i]["ID_CongNhan"].ToString())==id_congnhan)
                    {
                        _data.Rows[i]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                        _data.Rows[i]["MaDinhMucLuongCongNhat"] = ma;
                        if (i > 0)
                        {
                            int j = i - 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                --j;
                                if (j < 0)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            }
                        }
                        if (i < _data.Rows.Count - 1)
                        {
                            int j = i + 1;
                            int id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
                            while (id_congnhan1_ == id_congnhan)
                            {
                                _data.Rows[j]["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                                _data.Rows[j]["MaDinhMucLuongCongNhat"] = ma;
                                ++j;
                                if (j >= _data.Rows.Count - 1)
                                    break;

                                id_congnhan1_ = Convert.ToInt32(_data.Rows[j]["ID_CongNhan"].ToString());
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
            gridControl1.DataSource = _data;
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
        // 
        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            { 
                DateTime dtnow = DateTime.Now;
                _nam = DateTime.Now.Year;
                _thang = DateTime.Now.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
                DateTime date_ = new DateTime(dtnow.Year, dtnow.Month, 1);
                int ngaycuathang_ = (((new DateTime(dtnow.Year, dtnow.Month, 1)).AddMonths(1)).AddDays(-1)).Day;
                if (ngaycuathang_ == 28)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = false;
                }
                else if (ngaycuathang_ == 29)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = false;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 30)
                {
                    Ngay31.Visible = false;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                else if (ngaycuathang_ == 31)
                {
                    Ngay31.Visible = true;
                    Ngay30.Visible = true;
                    Ngay29.Visible = true;
                }
                string thu_ = LayThu(date_);
                for (int i = 0; i < ngaycuathang_; ++i)
                {
                    ds_grid[i].Caption = (i + 1) + "\n" + LayThu(new DateTime(dtnow.Year, dtnow.Month, (i + 1)));
                    if (ds_grid[i].Caption.Contains("CN"))
                    {
                        ds_grid[i].AppearanceCell.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.BackColor = Color.LightGray;
                        ds_grid[i].AppearanceHeader.ForeColor = Color.Red;
                        ds_grid[i].AppearanceCell.ForeColor = Color.Red;
                    }
                } 
            }
            else
            {
            }
            // 
            //
            //
            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_Phieu_ChiTietPhieu_New_SF(_nam, _thang, true, false, false);
              
                double[] Ngay_ = new double[31];
                double[] NgayTong_ = new double[31];
                double[] Ngay_TangCa_ = new double[31];
                double[] NgayTong_TangCa_ = new double[31];
                DataTable data_hienthi = new DataTable();
                data_hienthi.Columns.Add("ID_CongNhan");
                data_hienthi.Columns.Add("TenNhanVien");
                data_hienthi.Columns.Add("Cong");
                for (int i=0;i<31;++i)
                {
                    data_hienthi.Columns.Add("Ngay"+(i+1));
                }
                data_hienthi.Columns.Add("Tong");
                data_hienthi.Columns.Add("VuotSanLuong"); 
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    int id_congnhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                    int ngay_ = Convert.ToInt32(_data.Rows[i]["Ngay"].ToString());
                    if (i<_data.Rows.Count-1)
                    {
                        Ngay_[ngay_ - 1] = Convert.ToDouble(_data.Rows[i]["SanLuong_Thuong"].ToString());
                        NgayTong_[ngay_ - 1] += Ngay_[ngay_ - 1];
                        //
                        Ngay_TangCa_[ngay_ - 1] = Convert.ToDouble(_data.Rows[i]["SanLuong_TangCa"].ToString());
                        NgayTong_TangCa_[ngay_ - 1] += Ngay_TangCa_[ngay_ - 1];
                        if (id_congnhan_ != Convert.ToDouble(_data.Rows[i+1]["ID_CongNhan"].ToString()))
                        {
                            DataRow ravi_1 = data_hienthi.NewRow();
                            DataRow ravi_2 = data_hienthi.NewRow();
                            ravi_1["ID_CongNhan"] = 0; 
                            ravi_1["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                            //
                            ravi_2["ID_CongNhan"] = 0;
                            ravi_2["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                            double tong_1 = 0;
                            double tong_2 = 0;
                            for (int index_ngay = 0; index_ngay < 31; ++index_ngay)
                            {
                                tong_1 += Ngay_[index_ngay];
                                ravi_1["Ngay" + (index_ngay + 1)] = Ngay_[index_ngay].ToString("N0");

                                tong_2 += Ngay_TangCa_[index_ngay];
                                ravi_2["Ngay" + (index_ngay + 1)] = Ngay_TangCa_[index_ngay].ToString("N0");
                            }
                            ravi_1["Tong"] = tong_1;
                            ravi_2["Tong"] = tong_2;
                            ravi_1["Cong"] = "SL";
                            ravi_2["Cong"] = "CN";
                            data_hienthi.Rows.Add(ravi_1);
                            data_hienthi.Rows.Add(ravi_2);
                            Ngay_ = new double[31];
                            Ngay_TangCa_ = new double[31];
                        }
                        else
                        {

                        }
                    } 
                    else
                    {
                        DataRow ravi_1 = data_hienthi.NewRow();
                        DataRow ravi_2 = data_hienthi.NewRow();
                        ravi_1["ID_CongNhan"] = 0; 
                        ravi_1["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();

                        ravi_2["ID_CongNhan"] = 0;
                        ravi_2["TenNhanVien"] = _data.Rows[i]["TenNhanVien"].ToString();
                        double tong_1 = 0;
                        double tong_2 = 0;
                        for (int index_ngay = 0; index_ngay < 31; ++index_ngay)
                        {
                            tong_1 += Ngay_[index_ngay];
                            ravi_1["Ngay" + (index_ngay + 1)] = Ngay_[index_ngay].ToString("N0");

                            tong_2 += Ngay_TangCa_[index_ngay];
                            ravi_2["Ngay" + (index_ngay + 1)] = Ngay_TangCa_[index_ngay].ToString("N0");
                        }
                        ravi_1["Tong"] = tong_1;
                        ravi_2["Tong"] = tong_2;
                        ravi_1["Cong"] = "SL";
                        ravi_2["Cong"] = "CN";
                        data_hienthi.Rows.Add(ravi_1);
                        data_hienthi.Rows.Add(ravi_2);
                        //
                        DataRow _ravi2 = data_hienthi.NewRow(); 
                        _ravi2["ID_CongNhan"] = 0; 
                        _ravi2["TenNhanVien"] = "TỔNG";

                        tong_1 = 0;
                        tong_2 = 0;
                        for (int index_ngay = 0; index_ngay < 31; ++index_ngay)
                        {
                            tong_1 += NgayTong_[index_ngay];
                            tong_2 += NgayTong_TangCa_[index_ngay];
                            _ravi2["Ngay" + (index_ngay + 1)]
                                = (NgayTong_TangCa_[index_ngay] + NgayTong_[index_ngay]).ToString("N0");
                        }
                        _ravi2["Tong"] = (tong_1+tong_2).ToString("N0");
                        data_hienthi.Rows.Add(_ravi2); 
                        //
                    }
                }
                gridControl1.DataSource = data_hienthi;
            }

            isload = false;
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
        private void frmChamCong_ToIn_Load(object sender, EventArgs e)
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
                    double temp_ = Convert.ToDouble(_data.Rows[index_][name_].ToString());
                    _data.Rows[index_]["Tong"] = temp_ + Convert.ToDouble(_data.Rows[index_]["Tong"].ToString());
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
            CongTong();
            // gridView1.SetRowCellValue(e.RowHandle, clSLThuong, tongcong); 
        }

        private void CongTong()
        {
            int[] _ds_ngay_tong_ = new int[31];
            int tong_tong_ = 0;
            for (int i = 0; i < _data.Rows.Count - 1; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    _ds_ngay_tong_[j] += Convert.ToInt32(_data.Rows[i]["Ngay" + (j + 1)].ToString());
                }
                tong_tong_ += Convert.ToInt32(_data.Rows[i]["Tong"].ToString());
            }
            for (int j = 0; j < 31; ++j)
            {
                _data.Rows[_data.Rows.Count - 1]["Ngay" + (j + 1)] = _ds_ngay_tong_[j];
            }
            _data.Rows[_data.Rows.Count - 1]["Tong"] = tong_tong_;
            gridControl1.DataSource = _data;
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
            _thang = Convert.ToInt32(txtThang.Text);
            LoadData(false);
            try
            {
            }
            catch (Exception ee)
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
            catch (Exception ee)
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
            //miiID_chiTietChamCong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clID_ChiTietChamCong).ToString());
            //miiD_DinhMuc_Luong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clID_DinhMucLuong_CongNhat).ToString());
            // miID_congNhan = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());

            // msTenNhanVien = gridView1.GetFocusedRowCellValue(clTenNhanVien).ToString();
            //frmMaHang_ChamCong_ToGapDan ff = new frmMaHang_ChamCong_ToGapDan(this);
            //ff.Show();
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            //GuiDuLieuBangLuong();

            //CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan ff = new CtyTinLuong.Luong_ChamCong.T_frmPrintChamCongToGapDan(7,2021);
            //ff.Show();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX(_thang, _nam);
            ff.ShowDialog();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuanLyDinhMucLuong ff = new frmQuanLyDinhMucLuong(0, "frmChamCong_ToIn", this);
            ff.ShowDialog();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  clTenNhanVien)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString()); 
                 
                frmQuanLyDinhMucLuong ff = new frmQuanLyDinhMucLuong(id_congnhan_, "frmChamCong_ToIn", this);
                ff.ShowDialog();

            }
            catch (Exception ee)
            {

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        } 
    }
}

