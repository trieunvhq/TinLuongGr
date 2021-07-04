using CtyTinLuong.Constants;
using CtyTinLuong.Model;
using DevExpress.Utils;
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
    public partial class frmBTTL_TMC_CT : UserControl
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

        public frmBTTL_TMC_CT(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();
        }

        double _Cong = 0;
        double _SanLuong = 0;
        double _DonGia = 0;
        double _ThanhTien = 0;
        double _XangXe = 0;
        double _Tong = 0;
        double _BaoHiem = 0;
        double _ThucNhan = 0;
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
                 
            }
            else
            {
            }
            _nam = DateTime.Now.Year;
            _thang = DateTime.Now.Month;
            
         _Cong = 0;
         _SanLuong = 0;
         _DonGia = 0;
         _ThanhTien = 0;
         _XangXe = 0;
         _Tong = 0;
         _BaoHiem = 0;
         _ThucNhan = 0;
            double Cong_ = 0;
            double SanLuong_ = 0;
            double DonGia_ = 0;
            double ThanhTien_ = 0;
            double XangXe_ = 0;
            double Tong_ = 0;
            double BaoHiem_ = 0;
            double ThucNhan_ = 0; 

            using (clsThin clsThin_ = new clsThin())
            {
                _data = clsThin_.T_BTTL_TMC_SF(_nam, _thang,"");
               
                for (int i = 0; i < _data.Rows.Count; ++i)
                {
                    Cong_ = Convert.ToDouble(_data.Rows[i]["Cong"].ToString());
                    SanLuong_ = Convert.ToDouble(_data.Rows[i]["SanLuong"].ToString());
                    DonGia_ = Convert.ToDouble(_data.Rows[i]["DonGia"].ToString());
                    ThanhTien_ = Convert.ToDouble(_data.Rows[i]["ThanhTien"].ToString());
                    XangXe_ = Convert.ToDouble(_data.Rows[i]["XangXe"].ToString());
                    Tong_ = Convert.ToDouble(_data.Rows[i]["Tong"].ToString());
                    BaoHiem_ = Convert.ToDouble(_data.Rows[i]["BaoHiem"].ToString());
                    ThucNhan_ = Convert.ToDouble(_data.Rows[i]["ThucNhan"].ToString());
                    //
                    _Cong += Cong_;
                    _SanLuong += SanLuong_;
                    _DonGia += DonGia_;
                    _ThanhTien += ThanhTien_;
                    _XangXe += XangXe_;
                    _Tong += Tong_;
                    _BaoHiem += BaoHiem_;
                    _ThucNhan += ThucNhan_;
                    //   
                    _data.Rows[i]["sCong"] = Cong_;
                    _data.Rows[i]["sSanLuong"] = SanLuong_.ToString("N0");
                    _data.Rows[i]["sDonGia"] = DonGia_.ToString("N0");
                    _data.Rows[i]["sThanhTien"] = ThanhTien_.ToString("N0");
                    _data.Rows[i]["sXangXe"] = XangXe_.ToString("N0");
                    _data.Rows[i]["sTong"] = Tong_.ToString("N0");
                    _data.Rows[i]["sBaoHiem"] = BaoHiem_.ToString("N0");
                    _data.Rows[i]["sThucNhan"] = ThucNhan_.ToString("N0");
                }
            }

            DataRow _ravi = _data.NewRow();
            _ravi["TenNhanVien"] = "Tổng";
            _ravi["sCong"] = _Cong;
            _ravi["sSanLuong"] = _SanLuong.ToString("N0");
            _ravi["sDonGia"] = _DonGia.ToString("N0");
            _ravi["sThanhTien"] = _ThanhTien.ToString("N0");
            _ravi["sXangXe"] = _XangXe.ToString("N0");
            _ravi["sTong"] = _Tong.ToString("N0");
            _ravi["sBaoHiem"] = _BaoHiem.ToString("N0");
            _ravi["sThucNhan"] = _ThucNhan.ToString("N0");

            _data.Rows.Add(_ravi);
            gridControl1.DataSource = _data;
            //   
            isload = false;
        }
        private void frmBTTL_TMC_CT_Load(object sender, EventArgs e)
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

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TMC_CT(_thang, _nam, _data);
            ff.ShowDialog();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView; 
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            }
           
        }

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {

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
           // GuiDuLieuBangLuong();
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
        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}


