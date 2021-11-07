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
    public partial class Tr_frmChiTietDML_CongNhat : Form
    {
        private int HinhThucTinhLuong;
        private int _idDinhMucLuong = 0;
        private int _id_NhanVien = 0;
        private bool _checkTuNgay = false;

        Tr_frmQuanLyDML_CongNhat _frmQuanLyDinhMucLuong;
        DataTable _dtNguoi;
        public static decimal Evaluate(string expression)
        {

            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);

        }

        private void Load_lockUP_EDIT()
        {
            try
            {
                using (clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu())
                {
                    _dtNguoi = clsNguoi.T_SelectAll(8);

                    _dtNguoi = clsNguoi.T_SelectAll(0);
                    searchLookMaDML.Properties.DataSource = _dtNguoi;
                    searchLookMaDML.Properties.ValueMember = "ID_NhanSu";
                    searchLookMaDML.Properties.DisplayMember = "MaNhanVien";

                    //searchLookMaDML.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;

                    //Thay caption:
                    searchLookMaDML.Properties.View.Columns.Clear();//xóa caption cũ
                    searchLookMaDML.Properties.View.Columns.AddVisible("ID_NhanSu", "ID");
                    searchLookMaDML.Properties.View.Columns["ID_NhanSu"].Visible = false;


                    searchLookMaDML.Properties.View.Columns.AddVisible("MaNhanVien", "Mã nhân viên");
                    searchLookMaDML.Properties.View.Columns.AddVisible("TenNhanVien", "Tên nhân viên");
                    searchLookMaDML.Properties.View.Columns.AddVisible("NgaySinh", "Ngày sinh");
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraLuu()
        {
            clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dxxxx = dv.ToTable();
            string maLuong = searchLookMaDML.Text.ToString();
            string filterExpression = "";
            filterExpression = "MaDinhMucLuongCongNhat ='" + maLuong + "'";
            DataRow[] rows = dxxxx.Select(filterExpression);
            int k = rows.Length;
            if (searchLookMaDML.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn mã Định mức");
                return false;
            }
            else if (Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat == true)
            {
                if (k > 0)
                {
                    MessageBox.Show("Đã có Mã định mức lương: " + maLuong + "\n Vui lòng chọn lại tên mã lương khác");
                    return false;
                }
                else return true;
            }

            else return true;

        }
        private void LuuDuLieu(bool LuuVaDong)
        {
           try
            {
                //if (!KiemTraLuu()) return;
                if (!CheckDataInput()) return;


                using (clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong())
                {
                    cls.iId = Tr_frmQuanLyDML_CongNhat.miID_Sua_DinhMucLuongCongNhat;
                    cls.iId_nhanvien = _id_NhanVien;
                    cls.daTu_ngay = dateTuNgay.DateTime;
                    cls.daDen_ngay = dateDenNgay.DateTime;
                    cls.bDachamcong = false;
                    cls.sDienGiai = txtDienGiai.Text.Trim();
                    cls.iHinhThucTinhLuong = HinhThucTinhLuong;
                    cls.dcLuongCoDinh = CheckString.ConvertToDecimal_My(txtLuongCoDinh.Text.ToString());
                    cls.dcPhuCapXangXe = CheckString.ConvertToDecimal_My(txtPhuCapXang.Text.ToString());
                    cls.dcPhuCapDienthoai = CheckString.ConvertToDecimal_My(txtPhuCapDienThoai.Text.ToString());
                    cls.dcPhuCapVeSinhMay = CheckString.ConvertToDecimal_My(txtPhuCapVeSinhMay.Text.ToString());
                    cls.dcPhuCapTienAn = CheckString.ConvertToDecimal_My(txtPhuCapTienAn.Text.ToString());
                    cls.dcTrachNhiem = CheckString.ConvertToDecimal_My(txtTrachNhiem.Text.ToString());
                    cls.fPhanTramBaoHiem = CheckString.ConvertToDouble_My(txtPhanTramBaoHiem.Text.ToString());
                    cls.dcLuongCoBanTinhBaoHiem = CheckString.ConvertToDecimal_My(txtLuongCoBan.Text.ToString());
                    cls.dcBaoHiem = CheckString.ConvertToDecimal_My(txtBaoHiem.Text.ToString());
                    cls.dcPhuCapBaoHiem = CheckString.ConvertToDecimal_My(txtPhuCapBH.Text.ToString());
                    cls.dcDinhMucLuongTheoGio = CheckString.ConvertToDecimal_My(txtDMLuongTheoGio.Text.ToString());
                    cls.dcDinhMucLuongTangCa = CheckString.ConvertToDecimal_My(txtDinhMucTangCa.Text.ToString());
                    cls.bNgungtheodoi = checkNgungTheoDoi.Checked;
                    cls.bIsXangTheoThang = radioXangTheoThang.Checked;
                    cls.bTontai = true;

                    if (Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat == true)
                    {
                        if (cls.Insert())
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int nam_now = DateTime.Now.Year;
                        int thang_now = DateTime.Now.Month;
                        if (nam_now == dateDenNgay.DateTime.Year)
                        {
                            if (thang_now > dateDenNgay.DateTime.Month)
                            {
                                if (dateDenNgay.DateTime.Month == thang_now - 1)
                                {
                                    int ngaycuoithang_ = (((new DateTime(nam_now, thang_now -1, 1)).AddMonths(1)).AddDays(-1)).Day;
                                    DateTime date_cuoithang = new DateTime(nam_now, thang_now -1, ngaycuoithang_);
                                    if (dateDenNgay.DateTime < date_cuoithang)
                                    {
                                        MessageBox.Show("Tháng " + dateDenNgay.DateTime.Month.ToString() + " đã thanh toán lương cho công nhân. "
                                            + "Nhập ngày kết thúc phải >= " + date_cuoithang.ToString("dd/MM/yyyy"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Tháng " + dateDenNgay.DateTime.Month.ToString() + " đã thanh toán lương cho công nhân. "
                                    + "Nhập tháng kết thúc phải >= tháng hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        else if (DateTime.Now.Year > dateDenNgay.DateTime.Year)
                        {
                            MessageBox.Show("Năm " + dateDenNgay.DateTime.Year.ToString() + " đã thanh toán lương cho công nhân. "
                                + "Nhập năm kết thúc phải >= năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (_checkTuNgay)
                        {
                            if (nam_now == dateTuNgay.DateTime.Year)
                            {
                                if (dateTuNgay.DateTime.Month < thang_now)
                                {
                                    MessageBox.Show("Tháng " + dateTuNgay.DateTime.Month.ToString() + " đã thanh toán lương cho công nhân. "
                                    + "Nhập tháng bắt đầu phải >= tháng hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                            }
                            else if (DateTime.Now.Year > dateTuNgay.DateTime.Year)
                            {
                                MessageBox.Show("Năm " + dateTuNgay.DateTime.Year.ToString() + " đã thanh toán lương cho công nhân. "
                                    + "Nhập năm bắt đầu phải >= năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                           

                        //cls.iID_DinhMucLuong_CongNhat = Tr_frmQuanLyDML_CongNhat.miID_Sua_DinhMucLuongCongNhat;
                        if (cls.Update())
                        {
                            try
                            {
                                DataTable dt = cls.Tr_DinhMuc_Luong_Select_TheoIDNV(_id_NhanVien);
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                                    {
                                        cls.iId = Convert.ToInt32(dt.Rows[i + 1]["id"].ToString());
                                        cls.daTu_ngay = (Convert.ToDateTime(dt.Rows[i]["den_ngay"].ToString())).AddDays(+1);
                                        cls.Tr_DinhMuc_Luong_Update_TuNgay();
                                    }
                                }
                            }
                            catch (Exception ea)
                            {
                                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (LuuVaDong) this.Close();
                    else
                    {
                        _id_NhanVien = 0;
                        searchLookMaDML.ResetText();
                        txtTenNhanVien.ResetText();
                        TrUnlockReadonly();
                    }

                }
            }
            catch(Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrReadonly()
        {
            if (!frmDangNhap._bIsAdmin)
            {
                searchLookMaDML.ReadOnly = true;
                dateTuNgay.ReadOnly = true;
                //dateDenNgay.ReadOnly = true;
                txtLuongCoDinh.ReadOnly = true;
                txtPhuCapXang.ReadOnly = true;
                txtPhuCapDienThoai.ReadOnly = true;
                txtPhuCapVeSinhMay.ReadOnly = true;
                txtPhuCapTienAn.ReadOnly = true;
                txtTrachNhiem.ReadOnly = true;
                txtPhanTramBaoHiem.ReadOnly = true;
                txtLuongCoBan.ReadOnly = true;
                txtPhuCapBH.ReadOnly = true;
                txtDMLuongTheoGio.ReadOnly = true;
                txtDinhMucTangCa.ReadOnly = true;
                checCoDinh.Enabled = false;
                checCongNhat.Enabled = false;
                checSanLuong.Enabled = false;
                checMax_hai.Enabled = false;
                radioXangTheoThang.Enabled = false;
                radioXangTheoNgay.Enabled = false;
            }
        }

        private void TrUnlockReadonly()
        {
            searchLookMaDML.ReadOnly = false;
            dateTuNgay.ReadOnly = false;
            dateDenNgay.ReadOnly = false;
            txtLuongCoDinh.ReadOnly = false;
            txtPhuCapXang.ReadOnly = false;
            txtPhuCapDienThoai.ReadOnly = false;
            txtPhuCapVeSinhMay.ReadOnly = false;
            txtPhuCapTienAn.ReadOnly = false;
            txtTrachNhiem.ReadOnly = false;
            txtPhanTramBaoHiem.ReadOnly = false;
            txtLuongCoBan.ReadOnly = false;
            txtPhuCapBH.ReadOnly = false;
            txtDMLuongTheoGio.ReadOnly = false;
            txtDinhMucTangCa.ReadOnly = false;
            checCoDinh.Enabled = true;
            checCongNhat.Enabled = true;
            checSanLuong.Enabled = true;
            checMax_hai.Enabled = true;
            radioXangTheoThang.Enabled = true;
            radioXangTheoNgay.Enabled = true;
        }

        private void hienthiSUaDuLieu()
        {
            _checkTuNgay = false;

            btLUU.Enabled = true;
            clsTr_DinhMuc_Luong cls = new CtyTinLuong.clsTr_DinhMuc_Luong();
            cls.iId = Tr_frmQuanLyDML_CongNhat.miID_Sua_DinhMucLuongCongNhat;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                dateTuNgay.EditValue = Convert.ToDateTime(dt.Rows[0]["tu_ngay"].ToString());
                dateDenNgay.EditValue = Convert.ToDateTime(dt.Rows[0]["den_ngay"].ToString());

                if (DateTime.Now.Month > dateTuNgay.DateTime.Month)
                {
                    TrReadonly();
                }
                else
                {
                    _checkTuNgay = true;
                }

                if (DateTime.Now.Month > dateDenNgay.DateTime.Month)
                {
                    dateDenNgay.ReadOnly = true;
                }

                _id_NhanVien = Convert.ToInt32(dt.Rows[0]["id_nhanvien"].ToString());

                searchLookMaDML.EditValue = _id_NhanVien;
                searchLookMaDML.ReadOnly = true;

                txtTenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();

                if (cls.iHinhThucTinhLuong.Value == 1)
                    checCoDinh.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 2)
                    checCongNhat.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 3)
                    checSanLuong.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 4)
                    checMax_hai.Checked = true;

                if (cls.bIsXangTheoThang.Value)
                {
                    radioXangTheoThang.Checked = true;
                }
                else
                {
                    radioXangTheoNgay.Checked = true;
                }
                
                txtLuongCoDinh.Text = cls.dcLuongCoDinh.Value.ToString();
                txtPhuCapXang.Text = cls.dcPhuCapXangXe.Value.ToString();
                txtPhuCapDienThoai.Text = cls.dcPhuCapDienthoai.Value.ToString();
                txtPhuCapVeSinhMay.Text = cls.dcPhuCapVeSinhMay.Value.ToString();
                txtPhuCapTienAn.Text = cls.dcPhuCapTienAn.Value.ToString();
                txtTrachNhiem.Text = cls.dcTrachNhiem.Value.ToString();
                txtPhanTramBaoHiem.Text = cls.fPhanTramBaoHiem.Value.ToString();
                txtLuongCoBan.Text = cls.dcLuongCoBanTinhBaoHiem.Value.ToString();
                txtBaoHiem.Text = cls.dcBaoHiem.Value.ToString();
                txtPhuCapBH.Text = cls.dcPhuCapBaoHiem.Value.ToString();
                txtDMLuongTheoGio.Text = cls.dcDinhMucLuongTheoGio.Value.ToString();
                txtDinhMucTangCa.Text = cls.dcDinhMucLuongTangCa.Value.ToString();
                checkNgungTheoDoi.Checked = cls.bNgungtheodoi.Value;
            }
        }
        private void HienThi_ThemMoi()
        {
            //searchLookMaDML.Text = "";
            txtDienGiai.Text = "";
            checCongNhat.Checked = true;
            txtLuongCoDinh.Text = "0";
            txtPhuCapXang.Text = "0";
            txtPhuCapDienThoai.Text = "0";
            txtPhuCapVeSinhMay.Text = "0";
            txtPhuCapTienAn.Text = "0";
            txtTrachNhiem.Text = "0";
            txtPhanTramBaoHiem.Text = "0";
            txtLuongCoBan.Text = "4729400";
            txtBaoHiem.Text = "0";
            txtPhuCapBH.Text = "0";
            txtDMLuongTheoGio.Text = "0";
            txtDinhMucTangCa.Text = "0";
            checkNgungTheoDoi.Checked = false;
        }
        public Tr_frmChiTietDML_CongNhat(Tr_frmQuanLyDML_CongNhat frm)
        {
            InitializeComponent();
            _frmQuanLyDinhMucLuong = frm;
            btLUU.Enabled = true;

            radioXangTheoThang.Checked = true;
        }

        private void Tr_frmChiTietDML_CongNhat_Load(object sender, EventArgs e)
        {
            TrUnlockReadonly();
            HinhThucTinhLuong = 0;
            Load_lockUP_EDIT();
            searchLookMaDML.ReadOnly = false;

            if (Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat == true)
            {

                HienThi_ThemMoi();
            }
            else
                hienthiSUaDuLieu();
            
        }

        private void txtLuongCoDinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtLuongCoDinh.Text);
                //txtLuongCoDinh.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtLuongCoDinh.Text, System.Globalization.NumberStyles.AllowThousands);
                txtLuongCoDinh.Text = String.Format(culture, "{0:N0}", value);
                txtLuongCoDinh.Select(txtLuongCoDinh.Text.Length, 0);
            }
            catch
            {
            }
           
        }

        private void txtPhuCapXang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtPhuCapXang.Text);
                //txtPhuCapXang.Text = String.Format("{0:#,##0.00}", value);
                //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                //Double value = CheckString.ConvertToDouble_My(txtPhuCapXang.Text.Trim());
                //txtPhuCapXang.Text = String.Format(culture, "{0:N0}", value);
                //txtPhuCapXang.Select(txtPhuCapXang.Text.Length, 0);
            }
            catch
            {
            }
           
        }

        private void txtPhuCapDienThoai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtPhuCapDienThoai.Text);
                //txtPhuCapDienThoai.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtPhuCapDienThoai.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPhuCapDienThoai.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapDienThoai.Select(txtPhuCapDienThoai.Text.Length, 0);
            }
            catch
            {
            }
             
        }

        private void txtPhuCapVeSinhMay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtPhuCapVeSinhMay.Text);
                //txtPhuCapVeSinhMay.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtPhuCapVeSinhMay.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPhuCapVeSinhMay.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapVeSinhMay.Select(txtPhuCapVeSinhMay.Text.Length, 0);
            }
            catch
            {
            }
            
        }

        private void txtPhuCapTienAn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtPhuCapTienAn.Text);
                //txtPhuCapTienAn.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtPhuCapTienAn.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPhuCapTienAn.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapTienAn.Select(txtPhuCapTienAn.Text.Length, 0);
            }
            catch
            {
            }
            
        }

        private void txtTrachNhiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtTrachNhiem.Text);
                //txtTrachNhiem.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtTrachNhiem.Text, System.Globalization.NumberStyles.AllowThousands);
                txtTrachNhiem.Text = String.Format(culture, "{0:N0}", value);
                txtTrachNhiem.Select(txtTrachNhiem.Text.Length, 0);
            }
            catch
            {
            }
         
        }

        private void txtLuongCoBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtLuongCoBan.Text);
                //txtLuongCoBan.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtLuongCoBan.Text, System.Globalization.NumberStyles.AllowThousands);
                txtLuongCoBan.Text = String.Format(culture, "{0:N0}", value);
                txtLuongCoBan.Select(txtLuongCoBan.Text.Length, 0);
            }
            catch
            {
            }
           
        }

        private void txtDMLuongTheoGio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                //decimal value = decimal.Parse(txtDMLuongTheoGio.Text, System.Globalization.NumberStyles.AllowThousands);
                double value = CheckString.ConvertToDouble_My(txtDMLuongTheoGio.Text.Trim());
                //txtDMLuongTheoGio.Text = String.Format(culture, "{0:N0}", value);
                //txtDMLuongTheoGio.Select(txtDMLuongTheoGio.Text.Length, 0);

                //
                //txtDinhMucTangCa.Text = String.Format(culture, "{0:N2}", CheckString.ConvertToDouble_My("("+value.ToString() +"/8)*(3/2)"));
                txtDinhMucTangCa.Text = String.Format(culture, "{0:N0}", CheckString.ConvertToDouble_My((value*3)/16));

                txtDinhMucTangCa.Select(txtDinhMucTangCa.Text.Length, 0);
            }
            catch
            {
            }


            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            ////decimal value = decimal.Parse(txtDMLuongTheoGio.Text, System.Globalization.NumberStyles.AllowThousands);
            //double value = CheckString.ConvertToDouble_My(txtDMLuongTheoGio.Text.Trim());
            //txtDMLuongTheoGio.Text = String.Format(culture, "{0:N0}", value);
            //txtDMLuongTheoGio.Select(txtDMLuongTheoGio.Text.Length, 0);

            ////
            //txtDinhMucTangCa.Text = String.Format(culture, "{0:N0}", ((value / 8) * (3 / 2)));
            //txtDinhMucTangCa.Select(txtDinhMucTangCa.Text.Length, 0);

        }

        private void txtDinhMucTangCa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtDinhMucTangCa.Text);
                //txtDinhMucTangCa.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtDinhMucTangCa.Text, System.Globalization.NumberStyles.AllowThousands);
                txtDinhMucTangCa.Text = String.Format(culture, "{0:N0}", value);
                txtDinhMucTangCa.Select(txtDinhMucTangCa.Text.Length, 0);
            }
            catch
            {
            }
            
        }

        private void checCoDinh_CheckedChanged(object sender, EventArgs e)
        {
            if (checCoDinh.Checked == true)
            {
                HinhThucTinhLuong = 1;
                checCongNhat.Checked = false;
                checSanLuong.Checked = false;
                checMax_hai.Checked = false;
            }

        }

        private void checCongNhat_CheckedChanged(object sender, EventArgs e)
        {
            if (checCongNhat.Checked == true)
            {
                HinhThucTinhLuong = 2;
                checCoDinh.Checked = false;
                checSanLuong.Checked = false;
                checMax_hai.Checked = false;
                txtLuongCoDinh.Text = "0";
            }
        }

        private void checSanLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (checSanLuong.Checked == true)
            {
                HinhThucTinhLuong = 3;
                checCoDinh.Checked = false;
                checCongNhat.Checked = false;
                checMax_hai.Checked = false;
                txtLuongCoDinh.Text = "0";
            }
        }

        private void checMax_hai_CheckedChanged(object sender, EventArgs e)
        {
            if (checMax_hai.Checked == true)
            {
                HinhThucTinhLuong = 4;
                checCoDinh.Checked = false;
                checCongNhat.Checked = false;
                checSanLuong.Checked = false;
                txtLuongCoDinh.Text = "0";
            }
        }

        private void txtBaoHiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtBaoHiem.Text, System.Globalization.NumberStyles.AllowThousands);
                txtBaoHiem.Text = String.Format(culture, "{0:N0}", value);
                txtBaoHiem.Select(txtBaoHiem.Text.Length, 0);
            }
            catch
            {
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQuanLyDinhMucLuong.HienThi();
            this.Close();
        }

        private void txtPhanTramBaoHiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double phantram = CheckString.ConvertToDouble_My(txtPhanTramBaoHiem.Text.ToString());
                double luongcoban = CheckString.ConvertToDouble_My(txtLuongCoBan.Text.ToString());
                double baohiem = CheckString.ConvertToDouble_My(phantram * luongcoban / 100);
                txtBaoHiem.Text = baohiem.ToString();

                if(Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat == true)
                    txtPhuCapBH.Text = baohiem.ToString();
            }
            catch
            {
            }

            
        }

        private void btLUU_Click(object sender, EventArgs e)
        {
            LuuDuLieu(true);
            _frmQuanLyDinhMucLuong.HienThi();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat = true;
            _id_NhanVien = 0;
            searchLookMaDML.ResetText();
            txtTenNhanVien.ResetText();
            TrUnlockReadonly();
        }

        private void txtPhuCapBH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtPhuCapBH.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPhuCapBH.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapBH.Select(txtPhuCapBH.Text.Length, 0);
            }
            catch
            {
            }
        }

        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(searchLookMaDML.Text))
            {
                MessageBox.Show("Kiểm tra lại mã định mức!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookMaDML.Focus();
                return false;
            }
            else if (_id_NhanVien == 0)
            {
                MessageBox.Show("Kiểm tra lại mã định mức!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                searchLookMaDML.Focus();
                return false;
            }
            else if (dateTuNgay.EditValue == null)
            {
                MessageBox.Show("Kiểm tra lại ngày bắt đầu áp dụng định mức lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTuNgay.Focus();
                return false;
            }
            else if (dateDenNgay.EditValue == null)
            {
                MessageBox.Show("Kiểm tra lại ngày kết thúc áp dụng định mức lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateDenNgay.Focus();
                return false;
            }
            else if (dateDenNgay.DateTime <= dateTuNgay.DateTime)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu áp dụng định mức lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateDenNgay.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLuongCoDinh.Text))
            {
                MessageBox.Show("Kiểm tra lại lương cố định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuongCoDinh.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtLuongCoDinh.Text))
            {
                MessageBox.Show("Kiểm tra lại lương cố định. Lương cố định phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuongCoDinh.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhuCapXang.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp xăng xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapXang.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhuCapXang.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp xăng xe. Phụ cấp xăng xe phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapXang.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhuCapDienThoai.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapDienThoai.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhuCapDienThoai.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp điện thoại. Phụ cấp điện thoại phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapDienThoai.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhuCapVeSinhMay.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp vệ sinh máy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapVeSinhMay.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhuCapVeSinhMay.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp vệ sinh máy. Phụ cấp vệ sinh máy phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapVeSinhMay.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhuCapTienAn.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp tiền ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapTienAn.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhuCapTienAn.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp tiền ăn. Phụ cấp tiền ăn phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapTienAn.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTrachNhiem.Text))
            {
                MessageBox.Show("Kiểm tra lại tiền trách nhiệm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrachNhiem.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtTrachNhiem.Text))
            {
                MessageBox.Show("Kiểm tra lại tiền trách nhiệm. Tiền trách nhiệm phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrachNhiem.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhanTramBaoHiem.Text))
            {
                MessageBox.Show("Kiểm tra lại phần trăm bảo hiểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhanTramBaoHiem.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhanTramBaoHiem.Text))
            {
                MessageBox.Show("Kiểm tra lại phần trăm bảo hiểm. Phần trăm bảo hiểm phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhanTramBaoHiem.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
            {
                MessageBox.Show("Kiểm tra lại lương cơ bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuongCoBan.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtLuongCoBan.Text))
            {
                MessageBox.Show("Kiểm tra lại lương cơ bản. Lương cơ bản phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuongCoBan.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhuCapBH.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp bảo hiểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapBH.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtPhuCapBH.Text))
            {
                MessageBox.Show("Kiểm tra lại phụ cấp bảo hiểm. Phụ cấp bảo hiểm phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhuCapBH.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDMLuongTheoGio.Text))
            {
                MessageBox.Show("Kiểm tra lại lương/ngày thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDMLuongTheoGio.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtDMLuongTheoGio.Text))
            {
                MessageBox.Show("Kiểm tra lại lương/ngày thường. Lương/ngày thường phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDMLuongTheoGio.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDinhMucTangCa.Text))
            {
                MessageBox.Show("Kiểm tra lại lương/ngày tăng ca!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDinhMucTangCa.Focus();
                return false;
            }
            else if (!CheckString.CheckIsNumber(txtDinhMucTangCa.Text))
            {
                MessageBox.Show("Kiểm tra lại lương/ngày tăng ca. Lương/ngày tăng ca phải nhập vào là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDinhMucTangCa.Focus();
                return false;
            }
            
            else return true;
        }

        private void searchLookMaDML_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Tr_frmQuanLyDML_CongNhat.mb_TheMoi_DinhMucLuongCongNhat)
                {
                    using (clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong())
                    {
                        DataTable dt = cls.Tr_DinhMuc_Luong_Select_TheoIDNV(_id_NhanVien);
                        if (dt.Rows.Count > 0)
                        {
                            dateTuNgay.EditValue = (Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["den_ngay"].ToString())).AddDays(+1);
                            dateTuNgay.ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //try
            //{
            //    clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
            //    clsncc.iID_NhanSu = Convert.ToInt32(searchLookMaDML.EditValue.ToString());
            //    int iiiiID_CongNhan = Convert.ToInt32(searchLookMaDML.EditValue.ToString());
            //    DataTable dt = clsncc.SelectOne();
            //    if (dt.Rows.Count > 0)
            //    {
            //        txtTenNhanVien.Text = dt.Rows[0]["TenNhanVien"].ToString();
            //    }
            //}
            //catch (Exception ea)
            //{
            //    MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ////================
        }



        private void searchLookMaDML_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
                return;
            else if (e.Value.ToString() == "")
                return;
            else
            {
                _id_NhanVien = Convert.ToInt32(e.Value.ToString());
                for (int i = 0; i < _dtNguoi.Rows.Count; i++)
                {
                    if (_id_NhanVien == Convert.ToUInt32(_dtNguoi.Rows[i]["ID_NhanSu"].ToString()))
                    {
                        txtTenNhanVien.Text = _dtNguoi.Rows[i]["TenNhanVien"].ToString();
                        //e.DisplayText = _dtNguoi.Rows[i]["MaNhanVien"].ToString();
                    }
                }
                //MessageBox.Show(searchLookMaDML.EditValue.ToString()); //string str = dt.Rows[0]["MaNhanVien"].ToString(); 
            }
        }

        private void txtDMLuongTheoGio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    double value = CheckString.ConvertToDouble_My(txtDMLuongTheoGio.Text.Trim());
                    txtDMLuongTheoGio.Text = String.Format(culture, "{0:N0}", value);
                    txtDMLuongTheoGio.Select(txtDMLuongTheoGio.Text.Length, 0);

                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    ////decimal value = decimal.Parse(txtDMLuongTheoGio.Text, System.Globalization.NumberStyles.AllowThousands);
                    //double value = CheckString.ConvertToDouble_My(txtDMLuongTheoGio.Text.Trim());
                    //txtDMLuongTheoGio.Text = String.Format(culture, "{0:N0}", value);
                    //txtDMLuongTheoGio.Select(txtDMLuongTheoGio.Text.Length, 0);

                    ////
                    //txtDinhMucTangCa.Text = String.Format(culture, "{0:N0}", ((value / 8) * (3 / 2)));
                    //txtDinhMucTangCa.Select(txtDinhMucTangCa.Text.Length, 0);

                    SendKeys.Send("{TAB}");
                }
                catch
                {
                }
            }
        }

        private void searchLookMaDML_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dateTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dateDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtLuongCoDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhuCapXang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                Double value = CheckString.ConvertToDouble_My(txtPhuCapXang.Text.Trim());
                txtPhuCapXang.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapXang.Select(txtPhuCapXang.Text.Length, 0);

                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhuCapDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhuCapVeSinhMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhuCapTienAn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTrachNhiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhanTramBaoHiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtLuongCoBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBaoHiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhuCapBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDinhMucTangCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
