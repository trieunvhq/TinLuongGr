

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
        public int  _ID_DinhMucLuong_CongNhat = 0;
        public int _nam, _thang, _id_bophan;
        private string _MaDinhMucLuongCongNhat;
        private DataTable _data;
        private bool isload = true;
        private List<GridColumn> ds_grid = new List<GridColumn>();

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public frmChamCong_PhienDich(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {

            _frmQLLCC = frmQLLCC;
            _ID_DinhMucLuong_CongNhat = 0;
            _MaDinhMucLuongCongNhat = "";
            _id_bophan = id_bophan;
            InitializeComponent();

            ID_ChamConPhienDich.Caption = "Đ.MỨC\nLƯƠNG";


            this.cbNhanSu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbNhanSu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);
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
                int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;
                DateTime dateStart = new DateTime(_nam, _thang, 1);
                DateTime dateEnd = new DateTime(_nam, _thang, ngaycuathang_);

                _data = clsThin_.Tr_ChamCongPhienDich_SelectAll(dateStart, dateEnd, 0);
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
            //LoadCongNhanVaoBang(_id_bophan);

            isload = false;
            gridControl1.DataSource = _data;
        }
        private List<int> ds_id_congnhan = new List<int>();
        private void LoadCongNhanVaoBang(int id_bophan)
        {
            int stt_ = 0;
            if (_data != null && _data.Rows.Count > 0)
            {
                stt_ = Convert.ToInt32(_data.Rows[_data.Rows.Count - 1]["STT"].ToString());
            }

            //Add công nhân tháng trước tự động nếu tháng mới chưa có dữ liệu:
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang(_thang, _nam, _id_bophan);
                if (dt_.Rows.Count == 0)
                {
                    int thangTruoc = 1;
                    int namTruoc = _nam;
                    switch (_thang)
                    {
                        case 1:
                            thangTruoc = 12;
                            namTruoc = _nam - 1;
                            break;
                        default:
                            thangTruoc = _thang - 1;
                            namTruoc = _nam;
                            break;
                    }

                    dt_ = clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectCNtheoThang(thangTruoc, namTruoc, _id_bophan);
                    for (int i = 0; i < dt_.Rows.Count; ++i)
                    {
                        //if (_ID_DinhMucLuong_CongNhat == 0)
                        //{
                        _ID_DinhMucLuong_CongNhat = Convert.ToInt32(dt_.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                        _MaDinhMucLuongCongNhat = dt_.Rows[i]["MaDinhMucLuongCongNhat"].ToString();
                        //}
                        //
                        int id_nhansu_ = Convert.ToInt32(dt_.Rows[i]["ID_CongNhan"].ToString());
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

                            _ravi["SanLuong"] = 0;
                            _ravi["Tong"] = 0;
                            _ravi["GuiDuLieu"] = false;
                            _ravi["MaNhanVien"] = dt_.Rows[i]["MaNhanVien"].ToString();
                            _ravi["TenNhanVien"] = dt_.Rows[i]["TenNhanVien"].ToString();

                            _ravi["MaDinhMuc"] = "";
                            _ravi["DinhMuc_KhongTang"] = 0;
                            _ravi["DinhMuc_Tang"] = 0;
                            _ravi["Cong"] = dt_.Rows[i]["Cong"].ToString();
                            _ravi["ID_LoaiCong"] = dt_.Rows[i]["ID_LoaiCong"].ToString();

                            ++stt_;
                            _ravi["STT"] = (stt_);
                            _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                            _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;
                            _data.Rows.Add(_ravi);
                        }
                    }
                }
            }


            gridThin.EditValueChanged += (o, e) =>
            {

            };
            // dat doan cuoi nay đi


            DataRow _ravi2 = _data.NewRow();
            _ravi2["ID_ChiTietChamCong_ToGapDan"] = 0;
            _ravi2["ID_CongNhan"] = 0;
            _ravi2["Thang"] = _thang;
            _ravi2["Nam"] = _nam;
            _ravi2["TenNhanVien"] = "TỔNG";
            _ravi2["Ngay1"] = String.Format("{0:0.##}", Tong_Ngay1);
            _ravi2["Ngay2"] = String.Format("{0:0.##}", Tong_Ngay2);
            _ravi2["Ngay3"] = String.Format("{0:0.##}", Tong_Ngay3);
            _ravi2["Ngay4"] = String.Format("{0:0.##}", Tong_Ngay4);
            _ravi2["Ngay5"] = String.Format("{0:0.##}", Tong_Ngay5);
            _ravi2["Ngay6"] = String.Format("{0:0.##}", Tong_Ngay6);
            _ravi2["Ngay7"] = String.Format("{0:0.##}", Tong_Ngay7);
            _ravi2["Ngay8"] = String.Format("{0:0.##}", Tong_Ngay8);
            _ravi2["Ngay9"] = String.Format("{0:0.##}", Tong_Ngay9);
            _ravi2["Ngay10"] = String.Format("{0:0.##}", Tong_Ngay10);
            _ravi2["Ngay11"] = String.Format("{0:0.##}", Tong_Ngay11);
            _ravi2["Ngay12"] = String.Format("{0:0.##}", Tong_Ngay12);
            _ravi2["Ngay13"] = String.Format("{0:0.##}", Tong_Ngay13);
            _ravi2["Ngay14"] = String.Format("{0:0.##}", Tong_Ngay14);
            _ravi2["Ngay15"] = String.Format("{0:0.##}", Tong_Ngay15);
            _ravi2["Ngay16"] = String.Format("{0:0.##}", Tong_Ngay16);
            _ravi2["Ngay17"] = String.Format("{0:0.##}", Tong_Ngay17);
            _ravi2["Ngay18"] = String.Format("{0:0.##}", Tong_Ngay18);
            _ravi2["Ngay19"] = String.Format("{0:0.##}", Tong_Ngay19);
            _ravi2["Ngay20"] = String.Format("{0:0.##}", Tong_Ngay20);
            _ravi2["Ngay21"] = String.Format("{0:0.##}", Tong_Ngay21);
            _ravi2["Ngay22"] = String.Format("{0:0.##}", Tong_Ngay22);
            _ravi2["Ngay23"] = String.Format("{0:0.##}", Tong_Ngay23);
            _ravi2["Ngay24"] = String.Format("{0:0.##}", Tong_Ngay24);
            _ravi2["Ngay25"] = String.Format("{0:0.##}", Tong_Ngay25);
            _ravi2["Ngay26"] = String.Format("{0:0.##}", Tong_Ngay26);
            _ravi2["Ngay27"] = String.Format("{0:0.##}", Tong_Ngay27);
            _ravi2["Ngay28"] = String.Format("{0:0.##}", Tong_Ngay28);
            _ravi2["Ngay29"] = String.Format("{0:0.##}", Tong_Ngay29);
            _ravi2["Ngay30"] = String.Format("{0:0.##}", Tong_Ngay30);
            _ravi2["Ngay31"] = String.Format("{0:0.##}", Tong_Ngay31);


            _ravi2["Tong"] = String.Format("{0:0.##}", (Tong_Ngay1 + Tong_Ngay2 + Tong_Ngay3 + Tong_Ngay4 + Tong_Ngay5
                + Tong_Ngay6 + Tong_Ngay7 + Tong_Ngay8 + Tong_Ngay9 + Tong_Ngay10
                + Tong_Ngay11 + Tong_Ngay12 + Tong_Ngay13 + Tong_Ngay14 + Tong_Ngay15
                + Tong_Ngay16 + Tong_Ngay17 + Tong_Ngay18 + Tong_Ngay19 + Tong_Ngay20
                + Tong_Ngay21 + Tong_Ngay22 + Tong_Ngay23 + Tong_Ngay24 + Tong_Ngay25
                + Tong_Ngay26 + Tong_Ngay27 + Tong_Ngay28 + Tong_Ngay29 + Tong_Ngay30 + Tong_Ngay31));

            _data.Rows.Add(_ravi2);
            //
            gridControl1.DataSource = _data;
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

            if (!_data.Rows[index_]["TenNhanVien"].ToString().ToLower().Contains("tổng")) SaveOneCN_Datarow(_data.Rows[index_]);
        }

        //CongTong_Row(index_);
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
            if (GuiDuLieuBangLuong())
            {
                MessageBox.Show("Lưu dữ liệu chấm công thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu lỗi", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;

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
                _ravi["ID_DinhMucLuong_CongNhat"] = _ID_DinhMucLuong_CongNhat;
                _ravi["MaDinhMucLuongCongNhat"] = _MaDinhMucLuongCongNhat;

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
            SaveOneCN(id_nhansu_);
            LoadData(false);
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
                int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_CongNhan).ToString());
                _MaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
                Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "frmChamCong_PhienDich", this);
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
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;

            //    if (gridView1.GetFocusedRowCellValue(TenNhanVien).ToString().ToLower().Contains("tổng"))
            //    {
            //        return;
            //    }

            //    int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_CongNhan).ToString());
            //    int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

            //    DialogResult traloi;
            //    traloi = MessageBox.Show("Xác nhận xóa công nhân: " + gridView1.GetFocusedRowCellValue(TenNhanVien).ToString(), "Delete",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (traloi == DialogResult.Yes)
            //    {
            //        bool deleted = false;

            //        if (ID_ChiTietChamCong_TGD == 0)
            //        {
            //            DataRow[] rows;
            //            rows = _data.Select("ID_CongNhan=' " + id_cn + " ' ");
            //            foreach (DataRow row in rows)
            //            {
            //                _data.Rows.Remove(row);
            //                deleted = true;
            //            }
            //        }
            //        else
            //        {
            //            using (clsThin clsThin_ = new clsThin())
            //            {
            //                for (int i = 0; i < _data.Rows.Count; i++)
            //                {
            //                    if (Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString()) == id_cn)
            //                    {
            //                        int id_ChiTietChamCong_TGD_ = Convert.ToInt32(_data.Rows[i]["ID_ChiTietChamCong_ToGapDan"].ToString());
            //                        if (clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(id_ChiTietChamCong_TGD_))
            //                        {
            //                            deleted = true;
            //                        }

            //                    }
            //                }
            //            }
            //        }

            //        if (deleted)
            //        {
            //            DataRow[] rows;
            //            rows = _data.Select("ID_CongNhan=' " + id_cn + " ' ");
            //            foreach (DataRow row in rows)
            //            {
            //                _data.Rows.Remove(row);
            //            }

            //            if (ds_id_congnhan.Contains(id_cn)) ds_id_congnhan.Remove(id_cn);

            //            gridControl1.DataSource = _data;
            //            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Xóa dữ liệu thất bại. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }

            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("Error xóa công nhân khỏi bảng..." +ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

        private bool GuiDuLieuBangLuong()
        {
            bool isGuiThanhCong = false;
            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        if (_data.Rows[i]["ID_CongNhan"].ToString() == "")
                            continue;

                        int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                        if (ID_CongNhan_ == 0)
                        {
                            continue;
                        }


                        string Cong_ = _data.Rows[i]["Cong"].ToString();
                        bool isTang = false;
                        if (Cong_.Contains("Tăng"))
                        {
                            isTang = true;
                        }
                        clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                            ID_CongNhan_,
                            _thang,
                            _nam,
                            0,
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
                            0, true, isTang, _id_bophan,
                            Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                            Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));

                        isGuiThanhCong = true;
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

        private void SaveOneCN(int idcn_)
        {
            string tenCongNhan_ = "";

            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    for (int i = 0; i < _data.Rows.Count; ++i)
                    {
                        int ID_CongNhan_ = Convert.ToInt32(_data.Rows[i]["ID_CongNhan"].ToString());
                        if (ID_CongNhan_ == idcn_)
                        {
                            tenCongNhan_ = _data.Rows[i]["TenNhanVien"].ToString();
                            string Cong_ = _data.Rows[i]["Cong"].ToString();
                            bool isTang = false;
                            if (Cong_.Contains("Tăng"))
                            {
                                isTang = true;
                            }
                            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                                ID_CongNhan_,
                                _thang,
                                _nam,
                                0,
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
                                0, true, isTang, _id_bophan,
                                Convert.ToInt32(_data.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString()),
                                Convert.ToInt32(_data.Rows[i]["ID_LoaiCong"].ToString()));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCongNhan_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveOneCN_Datarow(DataRow dt_row)
        {
            string tenCongNhan_ = "";

            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    int ID_CongNhan_ = Convert.ToInt32(dt_row["ID_CongNhan"].ToString());
                    tenCongNhan_ = dt_row["TenNhanVien"].ToString();
                    string Cong_ = dt_row["Cong"].ToString();
                    bool isTang = false;
                    if (Cong_.Contains("Tăng"))
                    {
                        isTang = true;
                    }
                    clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                        ID_CongNhan_,
                        _thang,
                        _nam,
                        0,
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
                        0, true, isTang, _id_bophan,
                        Convert.ToInt32(dt_row["ID_DinhMucLuong_CongNhat"].ToString()),
                        Convert.ToInt32(dt_row["ID_LoaiCong"].ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCongNhan_
                    + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

