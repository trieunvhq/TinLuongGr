

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

        private DataTable _data, _dt_DinhMuc;
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


            //using (clsThin clsThin_ = new clsThin())
            //{
            //    _dt_DinhMuc = clsThin_.T_NhanSu_SF("0");    
            //    cbNhanSu.DataSource = _dt_DinhMuc;
            //    cbNhanSu.DisplayMember = "TenNhanVien";
            //    cbNhanSu.ValueMember = "ID_NhanSu"; 
            //}

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


        private void frmChamCong_PhienDich_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
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
          
        }


        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
           
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
                            LoadData(false);
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

