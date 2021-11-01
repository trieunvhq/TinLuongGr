
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
    public partial class frmBTTL_TDB : UserControl
    {  

        public int _nam, _thang, _id_bophan;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true;


        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        public frmBTTL_TDB(frmQuanLy_Luong_ChamCong frmQLLCC, int idbp)
        {
            _id_bophan = idbp;
            _frmQLLCC = frmQLLCC;
            InitializeComponent();
            LuongTrachNhiem.Caption = "LƯƠNG\nT.NHIỆM";
            ThanhTien.Caption = "THÀNH\nTIỀN";
            TongLuong.Caption = "TỔNG\nLƯƠNG";
            SoNgayAn.Caption = "SỐ NGÀY\nĂN";
            SanLuong.Caption = "SẢN\nLƯỢNG";
            radioTo1.Checked = true;

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("Thang", typeof(string));
            _data.Columns.Add("Nam", typeof(string));
            _data.Columns.Add("ID_VTHH_Ra", typeof(string));
            _data.Columns.Add("TenVTHH", typeof(string));
            _data.Columns.Add("MaVT", typeof(string));
            _data.Columns.Add("SanLuong", typeof(string));
            _data.Columns.Add("DonViTinh", typeof(string));
            _data.Columns.Add("DonGia", typeof(string));
            _data.Columns.Add("ThanhTien", typeof(string));
            _data.Columns.Add("LuongTrachNhiem", typeof(string));
            _data.Columns.Add("XangXe", typeof(string));
            _data.Columns.Add("TamUng", typeof(string));
            _data.Columns.Add("BaoHiem", typeof(string));
            _data.Columns.Add("ThucNhan", typeof(string));
            _data.Columns.Add("PhuCapBaoHiem", typeof(string));

        }


        public void LoadData(bool islandau)
        {
            _data.Clear();

            isload = true;

            double sanluong_tong = 0;
            double thanhtien_tong = 0;

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
                            ravi_["Thang"] = _thang;
                            ravi_["Nam"] = _nam;
                            ravi_["ID_VTHH_Ra"] = ID_VTHH;
                            ravi_["TenVTHH"] = vt.TenVthhThuong;
                            ravi_["MaVT"] = vt.MaVT;
                            ravi_["SanLuong"] = vt.SlTong;
                            sanluong_tong += vt.SlTong;
                            ravi_["DonViTinh"] = vt.DonViTinh;
                            ravi_["DonGia"] = vt.DonGiaThuong;
                            ravi_["ThanhTien"] = vt.TienTong;
                            thanhtien_tong += vt.TienTong;
                            ravi_["LuongTrachNhiem"] = "";
                            ravi_["XangXe"] = "";
                            ravi_["TamUng"] = "";
                            ravi_["BaoHiem"] = "";
                            ravi_["ThucNhan"] = "";
                            ravi_["PhuCapBaoHiem"] = "";

                            _data.Rows.Add(ravi_);
                        }
                    }


                    //Tổng rows:
                    DataRow ravi_tg = _data.NewRow();
                    ravi_tg["STT"] = "";
                    ravi_tg["Thang"] = _thang;
                    ravi_tg["Nam"] = _nam;
                    ravi_tg["ID_VTHH_Ra"] = "";
                    ravi_tg["TenVTHH"] = "Tổng";
                    ravi_tg["MaVT"] = "";
                    ravi_tg["SanLuong"] = sanluong_tong;
                    ravi_tg["DonViTinh"] = "";
                    ravi_tg["DonGia"] = "";
                    ravi_tg["ThanhTien"] = thanhtien_tong;
                    ravi_tg["LuongTrachNhiem"] = "";
                    ravi_tg["XangXe"] = "";
                    ravi_tg["TamUng"] = "";
                    ravi_tg["BaoHiem"] = "";
                    ravi_tg["ThucNhan"] = thanhtien_tong;
                    ravi_tg["PhuCapBaoHiem"] = "";

                    _data.Rows.Add(ravi_tg);
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
            double DonGiaTDB = 0;
            double donGiaThuong = 0;
            double donGiaTang = 0;
            double soNgayCong = 0;
            double phuCapBaoHiem = 0;
            double truBaoHiem = 0;
            string LoaiHangHoa = "";
            string donViTinh = "";

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
                    donViTinh = item["DonViTinh"].ToString();
                    maVT = item["MaVT"].ToString();
                    DonGiaTDB = CheckString.ConvertToDouble_My(item["DonGia_Value"].ToString());
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

            //for (int i = 0; i < 31; i++)
            //{
            //    nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
            //    slThuong += nv.DsSLNgay[i];
            //}


            nv.HoTen = hoTen;
            nv.MaVT = maVT;
            nv.DonViTinh = donViTinh;
            nv.TenVthhThuong = tenVthhThuong;
            nv.TenVthhTang = tenVthhTang; //bỏ
            nv.SlTong = slTong;
            nv.SlThuong = slThuong; //bỏ
            nv.SlTang = slTang; //bỏ
            nv.DonGiaThuong = DonGiaTDB;
            nv.DonGiaTang = donGiaTang; //bỏ
            nv.SoNgayCong = soNgayCong; //bỏ
            nv.ThanhTienThuong = slThuong * donGiaThuong; //bỏ
            nv.ThanhTienTang = slTang * donGiaTang;
            nv.TienTong = DonGiaTDB * slTong;
            nv.PhuCapBaoHiem = phuCapBaoHiem;
            nv.TruBaoHiem = truBaoHiem;

            return nv;
        }

       
        private void frmBTTL_TDB_Load(object sender, EventArgs e)
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_CT(_thang, _nam, _data, radioTo1.Checked);
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
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TDB_TQ(_thang, _nam, _data, radioTo1.Checked);
            ff.Show();
        }

        private void radioTo1_CheckedChanged(object sender, EventArgs e)
        {
            if (isload)
                return;

            LoadData(false);
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
                MessageBox.Show("Lỗi:... " +ea.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLuongTrachNhiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
               
            }
        }

        private void txtLuongTrachNhiem_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            using (clsThin cls = new clsThin())
            {
                cls.Tr_LgTrNhiem_DB_DK_I(_thang, _nam, CheckString.ConvertToDouble_My(txtLuongTrachNhiem.Text.Trim()), _id_bophan, radioTo1.Checked, true);
            }
            LoadData(false);
        }

        private void radioTo2_CheckedChanged(object sender, EventArgs e)
        {
            //if (isload)
            //    return;

            //LoadData(false);
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


