

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
    public partial class frmChamCong_PhienDich : UserControl
    {
        public string _MaNhanVien = "";
        public static int _nam, _thang, _id_bophan;
        public static bool _mb_TheMoi;
        public static int _iID_ChamCongPD = 0;
        public static int _iID_CongNhan = 0;
        public static int _iID_KhachHang = 0;
        public static int _iNgay = 0;
        public static string _sTenCongNhan = "";
        public static string _sTenKhachHang = "";
        public static string _sSoToKhai = "";
        public static string _sSoCont = "";



        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public frmChamCong_PhienDich(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {

            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();

            ID_ChamConPhienDich.Caption = "Đ.MỨC\nLƯƠNG";


            this.cbNhanSu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNhanSu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);
            radioAll.Checked = true;
        }


        double Tong_Ngay1 = 0;
        double Tong_Ngay2 = 0;
        double Tong_Ngay3 = 0;
        double Tong_Ngay4 = 0;
        double Tong_Ngay5 = 0;
        double Tong_Ngay6 = 0;
        double Tong_Ngay7 = 0;
        double Tong_Ngay8 = 0;
        double Tong_Ngay9 = 0;
        double Tong_Ngay10 = 0;
        double Tong_Ngay11 = 0;
        double Tong_Ngay12 = 0;
        double Tong_Ngay13 = 0;
        double Tong_Ngay14 = 0;
        double Tong_Ngay15 = 0;
        double Tong_Ngay16 = 0;
        double Tong_Ngay17 = 0;
        double Tong_Ngay18 = 0;
        double Tong_Ngay19 = 0;
        double Tong_Ngay20 = 0;
        double Tong_Ngay21 = 0;
        double Tong_Ngay22 = 0;
        double Tong_Ngay23 = 0;
        double Tong_Ngay24 = 0;
        double Tong_Ngay25 = 0;
        double Tong_Ngay26 = 0;
        double Tong_Ngay27 = 0;
        double Tong_Ngay28 = 0;
        double Tong_Ngay29 = 0;
        double Tong_Ngay30 = 0;
        double Tong_Ngay31 = 0;
        DataTable _dt_DinhMuc;

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
            else
            {
            }


            using (clsThin clsThin_ = new clsThin())
            {
                _dt_DinhMuc = clsThin_.T_NhanSu_SF("0");    //T_NhanSu_SF(_id_bophan + ","); 
                cbNhanSu.DataSource = _dt_DinhMuc;
                cbNhanSu.DisplayMember = "TenNhanVien";
                cbNhanSu.ValueMember = "ID_NhanSu"; 
            }

            using (clsTr_ChamCongPhienDich clsThin_ = new clsTr_ChamCongPhienDich())
            {
                if (_nam < 1900) _nam = 1900;
                if (_thang == 0) _thang = 1;

                int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;
                DateTime dateStart = new DateTime(_nam, _thang, 1);
                DateTime dateEnd = new DateTime(_nam, _thang, ngaycuathang_);

                _data = clsThin_.Tr_ChamCongPhienDich_SelectAll(dateStart, dateEnd, 0, _TenKhachHang);
                ds_id_congnhan = new List<int>();

                gridThin.EditValueChanged += (o, e) =>
                {

                };
                // dat doan cuoi nay đi


                DataRow _ravi2 = _data.NewRow();
                _ravi2["ID_ChamConPhienDich"] = 0;
                _ravi2["ID_CongNhan"] = 0;
                _ravi2["ID_KhachHang"] = 0;
                _ravi2["TenNhanVien"] = "TỔNG";
                _ravi2["TenKhachHang"] = "";
                _ravi2["SoToKhai"] = _data.Rows.Count;
                _ravi2["SoCont"] = "";
                _data.Rows.Add(_ravi2);

                for (int i = 0; i < _data.Rows.Count; ++i)
                { 
                    ds_id_congnhan.Add(Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString())); 
                }
            }

            isload = false;
            gridControl1.DataSource = _data;
        }
        private List<int> ds_id_congnhan = new List<int>();


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
        private void frmChamCong_PhienDich_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index_ = e.RowHandle;
            string name_ = e.Column.FieldName;
            if (name_.Contains("Ngay"))
            {
                _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
                _data.Rows[index_][name_] = String.Format("{0:0.##}", CheckString.ConvertToDouble_My(_data.Rows[index_][name_].ToString()));
                if (_data.Rows.Count > index_)
                {
                    CongTong_Row(index_);
                }
                //SendKeys.Send("{DOWN}");
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

        }

        private void CongTong_Row (int index)
        {
            double tong_row = 0;

            for (int j = 0; j < 31; ++j)
            {
                tong_row += CheckString.ConvertToDouble_My(_data.Rows[index]["Ngay" + (j + 1)].ToString());
            }

            _data.Rows[index]["Tong"] = String.Format("{0:0.##}", tong_row);
        }

        private void CongTong()
        {
            double[] _ds_ngay_tong_ = new double[31];
            double tong_tong_ = 0;
            for (int i = 0; i < _data.Rows.Count - 1; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    _ds_ngay_tong_[j] += CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay" + (j + 1)].ToString());
                }
                tong_tong_ += CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString());
            }
            for (int j = 0; j < 31; ++j)
            {
                _data.Rows[_data.Rows.Count - 1]["Ngay" + (j + 1)] = String.Format("{0:0.##}", _ds_ngay_tong_[j]);
            }
            _data.Rows[_data.Rows.Count - 1]["Tong"] = String.Format("{0:0.##}",tong_tong_);
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


        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)cbNhanSu.SelectedValue == 0) return;

                using (clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong())
                {
                    DataTable dt = cls.Tr_DinhMuc_Luong_Select_TheoIDNV((int)cbNhanSu.SelectedValue);
                    if (dt.Rows.Count > 0)
                    {
                        int nam = DateTime.Now.Year;
                        int thang = DateTime.Now.Month;
                        int ngaycuathang = (((new DateTime(nam, thang, 1)).AddMonths(1)).AddDays(-1)).Day;

                        DateTime date_start = new DateTime(nam, thang, 1);
                        DateTime date_end = new DateTime(nam, thang, ngaycuathang);

                        if (Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString()) > date_start)
                        {
                            MessageBox.Show("Định mức công nhân " + cbNhanSu.Text + " phải được tính từ ngày 01/" + thang + "/" + nam + ". Yêu cầu kiểm tra lại!",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["den_ngay"].ToString()) < date_end)
                        {
                            MessageBox.Show("Định mức công nhân " + cbNhanSu.Text + " phải được tính đến ngày " + ngaycuathang + "/" + thang + "/" + nam + ". Yêu cầu kiểm tra lại!",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Công nhân " + cbNhanSu.Text + " chưa có định mức lương. Yêu cầu cài định mức cho công nhân trước!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cbNhanSu.Text != "")
            {
                if ((int)cbNhanSu.SelectedValue == 0)
                {
                    return;
                }
                else
                {
                    ThemMotCongNhanVaoBang((int)cbNhanSu.SelectedValue, cbNhanSu.Text, true);
                }
            }
        }
        private void ThemMotCongNhanVaoBang(int id_nhansu_, string ten_, bool isNew)
        {
            for (int i = 0; i < _data.Rows.Count; ++i)
            {
                if (id_nhansu_ == Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()))
                {
                    MessageBox.Show("Đã tồn tại công nhân này trong bảng");
                    return;
                }
            }

            if (isNew && _data != null && _data.Rows.Count > 0)
            {
                _data.Rows.RemoveAt(_data.Rows.Count - 1);
            }
            else
            {

            }
            // 
            if (ds_id_congnhan.Contains(id_nhansu_))
            {

            }
            else
            {
                DataRow _ravi = _data.NewRow();
                _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
                _ravi["ID_CongNhan"] = id_nhansu_;
                _ravi["Thang"] = _thang;
                _ravi["Nam"] = _nam;
                _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0; _ravi["Ngay3"] = 0;
                _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
                _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
                _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0;
                _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
                _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
                _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
                _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
                _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
                _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
                _ravi["Ngay30"] = 0; _ravi["Ngay31"] = 0;

                _ravi["Tong"] = 0;
                _ravi["GuiDuLieu"] = false;
                _ravi["MaNhanVien"] = "";
                _ravi["TenNhanVien"] = ten_;

                _ravi["Cong"] = "Công nhật";
                _ravi["ID_LoaiCong"] = 1;

                _data.Rows.Add(_ravi);

                _ravi = _data.NewRow();
                _ravi["ID_ChiTietChamCong_ToGapDan"] = 0;
                _ravi["ID_CongNhan"] = id_nhansu_;
                _ravi["Thang"] = _thang;
                _ravi["Nam"] = _nam;
                _ravi["Ngay1"] = 0; _ravi["Ngay2"] = 0; _ravi["Ngay3"] = 0;
                _ravi["Ngay4"] = 0; _ravi["Ngay5"] = 0; _ravi["Ngay6"] = 0;
                _ravi["Ngay7"] = 0; _ravi["Ngay8"] = 0; _ravi["Ngay9"] = 0;
                _ravi["Ngay10"] = 0; _ravi["Ngay11"] = 0;
                _ravi["Ngay12"] = 0; _ravi["Ngay13"] = 0; _ravi["Ngay14"] = 0;
                _ravi["Ngay15"] = 0; _ravi["Ngay16"] = 0; _ravi["Ngay17"] = 0;
                _ravi["Ngay18"] = 0; _ravi["Ngay19"] = 0; _ravi["Ngay20"] = 0;
                _ravi["Ngay21"] = 0; _ravi["Ngay22"] = 0; _ravi["Ngay23"] = 0;
                _ravi["Ngay24"] = 0; _ravi["Ngay25"] = 0; _ravi["Ngay26"] = 0;
                _ravi["Ngay27"] = 0; _ravi["Ngay28"] = 0; _ravi["Ngay29"] = 0;
                _ravi["Ngay30"] = 0; _ravi["Ngay31"] = 0;

                _ravi["Tong"] = 0;
                _ravi["GuiDuLieu"] = false;
                _ravi["MaNhanVien"] = "";
                _ravi["TenNhanVien"] = ten_;

                _ravi["Cong"] = "Tăng ca";
                _ravi["ID_LoaiCong"] = 2;

                _data.Rows.Add(_ravi);
                ds_id_congnhan.Add(id_nhansu_);
            }
            //for(int i=0; i<_dataLoaiHang.Rows.Count; i++)
            //{
            //    comboThin.Items.Add(_dataLoaiHang.Rows[i]["TenVTHH"].ToString());
            //}
            gridThin.EditValueChanged += (o, e) => {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenNhanVien"] = "TỔNG";
            _ravi2["Ngay1"] = String.Format("{0:0.##}",Tong_Ngay1);
            _ravi2["Ngay2"] = String.Format("{0:0.##}",Tong_Ngay2);
            _ravi2["Ngay3"] = String.Format("{0:0.##}",Tong_Ngay3);
            _ravi2["Ngay4"] = String.Format("{0:0.##}",Tong_Ngay4);
            _ravi2["Ngay5"] = String.Format("{0:0.##}",Tong_Ngay5);
            _ravi2["Ngay6"] = String.Format("{0:0.##}",Tong_Ngay6);
            _ravi2["Ngay7"] = String.Format("{0:0.##}",Tong_Ngay7);
            _ravi2["Ngay8"] = String.Format("{0:0.##}",Tong_Ngay8);
            _ravi2["Ngay9"] = String.Format("{0:0.##}",Tong_Ngay9);
            _ravi2["Ngay10"] = String.Format("{0:0.##}",Tong_Ngay10);
            _ravi2["Ngay11"] = String.Format("{0:0.##}",Tong_Ngay11);
            _ravi2["Ngay12"] = String.Format("{0:0.##}",Tong_Ngay12);
            _ravi2["Ngay13"] = String.Format("{0:0.##}",Tong_Ngay13);
            _ravi2["Ngay14"] = String.Format("{0:0.##}",Tong_Ngay14);
            _ravi2["Ngay15"] = String.Format("{0:0.##}",Tong_Ngay15);
            _ravi2["Ngay16"] = String.Format("{0:0.##}",Tong_Ngay16);
            _ravi2["Ngay17"] = String.Format("{0:0.##}",Tong_Ngay17);
            _ravi2["Ngay18"] = String.Format("{0:0.##}",Tong_Ngay18);
            _ravi2["Ngay19"] = String.Format("{0:0.##}",Tong_Ngay19);
            _ravi2["Ngay20"] = String.Format("{0:0.##}",Tong_Ngay20);
            _ravi2["Ngay21"] = String.Format("{0:0.##}",Tong_Ngay21);
            _ravi2["Ngay22"] = String.Format("{0:0.##}",Tong_Ngay22);
            _ravi2["Ngay23"] = String.Format("{0:0.##}",Tong_Ngay23);
            _ravi2["Ngay24"] = String.Format("{0:0.##}",Tong_Ngay24);
            _ravi2["Ngay25"] = String.Format("{0:0.##}",Tong_Ngay25);
            _ravi2["Ngay26"] = String.Format("{0:0.##}",Tong_Ngay26);
            _ravi2["Ngay27"] = String.Format("{0:0.##}",Tong_Ngay27);
            _ravi2["Ngay28"] = String.Format("{0:0.##}",Tong_Ngay28);
            _ravi2["Ngay29"] = String.Format("{0:0.##}",Tong_Ngay29);
            _ravi2["Ngay30"] = String.Format("{0:0.##}",Tong_Ngay30);
            _ravi2["Ngay31"] = String.Format("{0:0.##}",Tong_Ngay31);


            _ravi2["Tong"] = (Tong_Ngay1 + Tong_Ngay2 + Tong_Ngay3 + Tong_Ngay4 + Tong_Ngay5
                + Tong_Ngay6 + Tong_Ngay7 + Tong_Ngay8 + Tong_Ngay9 + Tong_Ngay10
                + Tong_Ngay11 + Tong_Ngay12 + Tong_Ngay13 + Tong_Ngay14 + Tong_Ngay15
                + Tong_Ngay16 + Tong_Ngay17 + Tong_Ngay18 + Tong_Ngay19 + Tong_Ngay20
                + Tong_Ngay21 + Tong_Ngay22 + Tong_Ngay23 + Tong_Ngay24 + Tong_Ngay25
                + Tong_Ngay26 + Tong_Ngay27 + Tong_Ngay28 + Tong_Ngay29 + Tong_Ngay30 + Tong_Ngay31).ToString();


            _data.Rows.Add(_ravi2);
            //
            //gridControl1.DataSource = _data;
            LoadData(false);
        }
      
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX(_thang, _nam);
            ff.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "frmChamCong_PhienDich", this);
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  TenNhanVien)
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
                _iID_ChamCongPD = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_ChamConPhienDich).ToString()); 
                _iID_CongNhan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_CongNhan).ToString());
                _iID_KhachHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_KhachHang).ToString());
                _iNgay = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(NgayThang).ToString()).Day;
                _sTenCongNhan = gridView1.GetFocusedRowCellValue(TenNhanVien).ToString();
                _sTenKhachHang = gridView1.GetFocusedRowCellValue(TenKhachHang).ToString();
                _sSoToKhai = gridView1.GetFocusedRowCellValue(SoToKhai).ToString();
                _sSoCont = gridView1.GetFocusedRowCellValue(SoCont).ToString();
                _MaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
                _mb_TheMoi = false;
                Tr_frmChiTietChamCong_PhienDich ff = new Tr_frmChiTietChamCong_PhienDich(this);
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

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (gridView1.GetFocusedRowCellValue(TenNhanVien).ToString().ToLower().Contains("tổng"))
                {
                    return;
                }

                int ID_ChamConPhienDich_ = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChamConPhienDich).ToString());

                DialogResult traloi;
                traloi = MessageBox.Show("Xác nhận xóa tờ khai: " + gridView1.GetFocusedRowCellValue(SoToKhai).ToString(), "Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    using (clsTr_ChamCongPhienDich cls = new clsTr_ChamCongPhienDich())
                    {
                        cls.iID_ChamConPhienDich = ID_ChamConPhienDich_;
                        if (cls.Tr_ChamCongPhienDich_Delete())
                        {
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa tờ khai khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }

        private string _TenKhachHang = "";
        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            _TenKhachHang = "";
            LoadData(false);
        }

        private void radioIF_CheckedChanged(object sender, EventArgs e)
        {
            _TenKhachHang = "IF";
            LoadData(false);
        }

        private void radioYC_CheckedChanged(object sender, EventArgs e)
        {
            _TenKhachHang = "YC";
            LoadData(false);
        }

        private void radioTien_CheckedChanged(object sender, EventArgs e)
        {
            _TenKhachHang = "TIEN";
            LoadData(false);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _mb_TheMoi = true;
            Tr_frmChiTietChamCong_PhienDich ff = new Tr_frmChiTietChamCong_PhienDich(this);
            ff.Show();
        }

    }
}

