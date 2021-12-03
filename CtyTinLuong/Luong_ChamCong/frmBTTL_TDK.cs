
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
    public partial class frmBTTL_TDK : UserControl
    {  

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_TDK(frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            InitializeComponent();
            LuongTrachNhiem.Caption = "LƯƠNG\nT.NHIỆM";
            ThanhTien.Caption = "THÀNH\nTIỀN";
            TongLuong.Caption = "TỔNG\nLƯƠNG";
            SoNgayAn.Caption = "SỐ NGÀY\nĂN";
            SanLuong.Caption = "SẢN\nLƯỢNG";

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("TenVTHH", typeof(string));
            _data.Columns.Add("SanLuong", typeof(string));
            _data.Columns.Add("DonGia", typeof(string));
            _data.Columns.Add("ThanhTien", typeof(string));
            _data.Columns.Add("LuongTrachNhiem", typeof(string));
            _data.Columns.Add("TongTien", typeof(string));
            _data.Columns.Add("TamUng", typeof(string));
            _data.Columns.Add("ThucNhan", typeof(string));
        }

        public void LoadData(bool islandau, int id_bophan_)
        {
            _data.Clear();
            isload = true;
            _id_bophan = id_bophan_;
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

            double ThucNhan = 0;
            double SanLuongTong = 0;
            double TongTien = 0;
            double LuongTrachNhiem_Tong = 0;


            txtLuongTrachNhiem.ReadOnly = false;
            txtLuongTrachNhiem.ResetText();

            if (DateTime.Now.Year == _nam)
            {
                if (DateTime.Now.Month > _thang)
                {
                    txtLuongTrachNhiem.ReadOnly = true;
                }
            }
            else if (DateTime.Now.Year > _nam)
            {
                txtLuongTrachNhiem.ReadOnly = true;
            }

            List<int> dsIDVTHH = new List<int>();

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dtl = clsThin_.Tr_LgTrNhiem_DB_DK_S(_nam, _thang, _id_bophan, true);
                if (dtl.Rows.Count > 0)
                {
                    txtLuongTrachNhiem.Text = dtl.Rows[0]["LuongTrachNhiem"].ToString();
                }
                else
                {
                    if (DateTime.Now.Year == _nam && DateTime.Now.Month <= _thang)
                    {
                        clsThin_.Tr_LgTrNhiem_DB_DK_I(_thang, _nam, 200000, _id_bophan, true, true);
                        txtLuongTrachNhiem.Text = "200000";
                    }
                    else if (DateTime.Now.Year < _nam)
                    {
                        clsThin_.Tr_LgTrNhiem_DB_DK_I(_thang, _nam, 200000, _id_bophan, true, true);
                        txtLuongTrachNhiem.Text = "200000";
                    }
                }

                LuongTrachNhiem_Tong = CheckString.ConvertToDouble_My(txtLuongTrachNhiem.Text.Trim());

                //
                int stt = 0;

                DataTable dtGD = clsThin_.Tr_DongKien_TbXuatKho_ChiTietXuatKho_ChamCong(_thang, _nam);
                DataTable dtDL = clsThin_.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_ChamCong(_thang, _nam);
                foreach (DataRow item in dtGD.Rows)
                {
                    if (!dsIDVTHH.Contains(Convert.ToInt32(item["ID_VTHH"].ToString())))
                    {
                        dsIDVTHH.Add(Convert.ToInt32(item["ID_VTHH"].ToString()));
                    }
                }

                foreach (DataRow item in dtDL.Rows)
                {
                    if (!dsIDVTHH.Contains(Convert.ToInt32(item["ID_VTHH"].ToString())))
                    {
                        dsIDVTHH.Add(Convert.ToInt32(item["ID_VTHH"].ToString()));
                    }
                }

                foreach (int item in dsIDVTHH)
                {
                    ModelDongKien dk = getSLDK(item, dtGD, dtDL);
                    stt++;
                    DataRow _ravi = _data.NewRow();
                    _ravi["STT"] = stt;
                    _ravi["TenVTHH"] = dk.TenHangHoa;
                    _ravi["SanLuong"] = dk.SanLuongTong.ToString("N0");
                    _ravi["DonGia"] = dk.DonGia.ToString("N0");
                    _ravi["LuongTrachNhiem"] = "";
                    _ravi["ThanhTien"] = dk.ThanhTienTong.ToString("N0");
                    _ravi["TongTien"] = dk.ThanhTienTong.ToString("N0");
                    _ravi["TamUng"] = "";
                    _ravi["ThucNhan"] = "";

                    ThucNhan += dk.ThanhTienTong;
                    SanLuongTong += dk.SanLuongTong;

                    _data.Rows.Add(_ravi);
                }

                //Add row tổng:
                if (dsIDVTHH.Count > 0)
                {
                    DataRow _ravi = _data.NewRow();
                    _ravi["STT"] = "";
                    _ravi["TenVTHH"] = "Tổng";
                    _ravi["SanLuong"] = SanLuongTong.ToString("N0");
                    _ravi["DonGia"] = "";
                    _ravi["LuongTrachNhiem"] = LuongTrachNhiem_Tong.ToString("N0");
                    _ravi["TongTien"] = TongTien.ToString("N0");
                    _ravi["ThanhTien"] = TongTien.ToString("N0");
                    _ravi["TamUng"] = "";
                    _ravi["ThucNhan"] = (ThucNhan + LuongTrachNhiem_Tong).ToString("N0");
                    _data.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = _data;
            isload = false;
        }


        private ModelDongKien getSLDK(int idvthh, DataTable dtGD, DataTable dtDL)
        {
            ModelDongKien dk = new ModelDongKien();
            string maVT_ = "";
            string tenVTHH_ = "";
            double donGia_ = 0;
            double SanLuongTong_ = 0;


            for (int i = 0; i < 31; i++)
            {
                dk.DsSLNgay[i] = 0;
            }

            // Gấp dán:
            foreach (DataRow item in dtGD.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH"].ToString()))
                {
                    tenVTHH_ = item["TenVTHH"].ToString();
                    maVT_ = item["MaVT"].ToString();
                    donGia_ = CheckString.ConvertToDouble_My(item["DonGia"].ToString());
                    int NgaySX = Convert.ToDateTime(item["NgayChungTu"].ToString()).Day;
                    dk.DsSLNgay[NgaySX - 1] += CheckString.ConvertToDouble_My(item["SoLuongXuat"].ToString());
                }
            }

            // Đại lý:
            foreach (DataRow item in dtDL.Rows)
            {
                if (idvthh == Convert.ToInt32(item["ID_VTHH"].ToString()))
                {
                    if (tenVTHH_ == "")
                        tenVTHH_ = item["TenVTHH"].ToString();

                    if (maVT_ == "")
                        maVT_ = item["MaVT"].ToString();

                    if (donGia_ == 0)
                        donGia_ = CheckString.ConvertToDouble_My(item["DonGia"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgayThang"].ToString()).Day;
                    dk.DsSLNgay[NgaySX - 1] += CheckString.ConvertToDouble_My(item["SoLuongXuat"].ToString());
                }
            }

            for (int i = 0; i < 31; i++)
            {
                SanLuongTong_ += dk.DsSLNgay[i];
            }

            dk.DonGia = donGia_;
            dk.MaVT = maVT_;
            dk.TenHangHoa = tenVTHH_;
            dk.SanLuongTong = SanLuongTong_;
            dk.ThanhTienTong = SanLuongTong_ * donGia_;

            return dk;
        }


        private void frmBTTL_TDK_Load(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.Default;
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
                LoadData(false,_id_bophan);
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
                LoadData(false,_id_bophan);
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDK ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDK(_thang, _nam, _data);
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

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDK_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDK_TQ(_thang, _nam, _data);
            ff.Show();
        }

        private void txtLuongTrachNhiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                //decimal value = decimal.Parse(txtLuongTrachNhiem.Text, System.Globalization.NumberStyles.AllowThousands);
                double value = CheckString.ConvertToDouble_My(txtLuongTrachNhiem.Text.Trim());
                txtLuongTrachNhiem.Text = String.Format(culture, "{0:N0}", value);
                txtLuongTrachNhiem.Select(txtLuongTrachNhiem.Text.Length, 0);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi:... " + ea.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLuongTrachNhiem_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            using (clsThin cls = new clsThin())
            {
                cls.Tr_LgTrNhiem_DB_DK_I(_thang, _nam, CheckString.ConvertToDouble_My(txtLuongTrachNhiem.Text.Trim()), _id_bophan, true, true);
            }
            LoadData(false, _id_bophan);
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


