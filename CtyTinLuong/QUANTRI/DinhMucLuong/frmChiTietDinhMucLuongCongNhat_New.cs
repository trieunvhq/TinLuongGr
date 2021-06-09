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
    public partial class frmChiTietDinhMucLuongCongNhat_Newwwwww : Form
    {
        int HinhThucTinhLuong;
        public static decimal Evaluate(string expression)
        {

            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);

        }
        private bool KiemTraLuu()
        {
            clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dxxxx = dv.ToTable();
            string maLuong = txtMaDinhMuc.Text.ToString();
            string filterExpression = "";
            filterExpression = "MaDinhMucLuongCongNhat ='" + maLuong + "'";
            DataRow[] rows = dxxxx.Select(filterExpression);
            int k = rows.Length;
            if (txtMaDinhMuc.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn mã Định mức");
                return false;
            }
            else if (frmQuanLyDinhMucLuong.mb_TheMoi_DinhMucLuongCongNhat == true)
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
        private void LuuDuLieu()
        {
           if (!KiemTraLuu()) return;
            else
            {
                clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
                cls.sMaDinhMucLuongCongNhat = txtMaDinhMuc.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.iHinhThucTinhLuong = HinhThucTinhLuong;
                cls.dcLuongCoDinh = Convert.ToDecimal(txtLuongCoDinh.Text.ToString());
                cls.dcPhuCapXangXe = Convert.ToDecimal(txtPhuCapXang.Text.ToString());
                cls.dcPhuCapDienthoai = Convert.ToDecimal(txtPhuCapDienThoai.Text.ToString());
                cls.dcPhuCapVeSinhMay = Convert.ToDecimal(txtPhuCapVeSinhMay.Text.ToString());
                cls.dcPhuCapTienAn = Convert.ToDecimal(txtPhuCapTienAn.Text.ToString());
                cls.dcTrachNhiem = Convert.ToDecimal(txtTrachNhiem.Text.ToString());
                cls.fPhanTramBaoHiem = Convert.ToDouble(txtPhanTramBaoHiem.Text.ToString());
                cls.dcLuongCoBanTinhBaoHiem = Convert.ToDecimal(txtLuongCoBan.Text.ToString());
                cls.dcBaoHiem = Convert.ToDecimal(txtBaoHiem.Text.ToString());
                cls.dcDinhMucLuongTheoGio = Convert.ToDecimal(txtDMLuongTheoGio.Text.ToString());
                cls.dcDinhMucLuongTangCa = Convert.ToDecimal(txtDinhMucTangCa.Text.ToString());
                cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                cls.bTonTai = true;
               

                if (frmQuanLyDinhMucLuong.mb_TheMoi_DinhMucLuongCongNhat == true)
                {
                    cls.Insert();
                }
                else
                {
                    cls.iID_DinhMucLuong_CongNhat = frmQuanLyDinhMucLuong.miID_Sua_DinhMucLuongCongNhat;
                    cls.Update();
                }
                frmQuanLyDinhMucLuong.mb_TheMoi_DinhMucLuongCongNhat = true;
            }
        }
        private void hienthiSUaDuLieu()
        {
            clsHUU_DinhMucLuong_CongNhat cls = new CtyTinLuong.clsHUU_DinhMucLuong_CongNhat();
            cls.iID_DinhMucLuong_CongNhat = frmQuanLyDinhMucLuong.miID_Sua_DinhMucLuongCongNhat;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtMaDinhMuc.Text = dt.Rows[0]["MaDinhMucLuongCongNhat"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                if (cls.iHinhThucTinhLuong.Value == 1)
                    checCoDinh.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 2)
                    checCongNhat.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 3)
                    checSanLuong.Checked = true;
                else if (cls.iHinhThucTinhLuong.Value == 4)
                    checMax_hai.Checked = true;

                txtLuongCoDinh.Text = cls.dcLuongCoDinh.Value.ToString();
                txtPhuCapXang.Text = cls.dcPhuCapXangXe.Value.ToString();
                txtPhuCapDienThoai.Text = cls.dcPhuCapDienthoai.Value.ToString();
                txtPhuCapVeSinhMay.Text = cls.dcPhuCapVeSinhMay.Value.ToString();
                txtPhuCapTienAn.Text = cls.dcPhuCapTienAn.Value.ToString();
                txtTrachNhiem.Text = cls.dcTrachNhiem.Value.ToString();
                txtPhanTramBaoHiem.Text = cls.fPhanTramBaoHiem.Value.ToString();
                txtLuongCoBan.Text = cls.dcLuongCoBanTinhBaoHiem.Value.ToString();
                txtBaoHiem.Text = cls.dcBaoHiem.Value.ToString();
                txtDMLuongTheoGio.Text = cls.dcDinhMucLuongTheoGio.Value.ToString();
                txtDinhMucTangCa.Text = cls.dcDinhMucLuongTangCa.Value.ToString();
                checkNgungTheoDoi.Checked = cls.bNgungTheoDoi.Value;

            }
        }
        private void HienThi_ThemMoi()
        {
            txtMaDinhMuc.Text = "";
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
            txtDMLuongTheoGio.Text = "0";
            txtDinhMucTangCa.Text = "0";
            checkNgungTheoDoi.Checked = false;
        }
        public frmChiTietDinhMucLuongCongNhat_Newwwwww()
        {
            InitializeComponent();
        }

        private void frmChiTietDinhMucLuongCongNhat_Newwwwww_Load(object sender, EventArgs e)
        {
            HinhThucTinhLuong = 0;
            if (frmQuanLyDinhMucLuong.mb_TheMoi_DinhMucLuongCongNhat == true)
                HienThi_ThemMoi();
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
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtPhuCapXang.Text, System.Globalization.NumberStyles.AllowThousands);
                txtPhuCapXang.Text = String.Format(culture, "{0:N0}", value);
                txtPhuCapXang.Select(txtPhuCapXang.Text.Length, 0);
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
                //decimal value = decimal.Parse(txtDMLuongTheoGio.Text);
                //txtDMLuongTheoGio.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtDMLuongTheoGio.Text, System.Globalization.NumberStyles.AllowThousands);
                txtDMLuongTheoGio.Text = String.Format(culture, "{0:N0}", value);
                txtDMLuongTheoGio.Select(txtDMLuongTheoGio.Text.Length, 0);
            }
            catch
            {
            }
           
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
            this.Close();
        }

        private void txtPhanTramBaoHiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double phantram = Convert.ToDouble(txtPhanTramBaoHiem.Text.ToString());
                double luongcoban = Convert.ToDouble(txtLuongCoBan.Text.ToString());
                double baohiem = Convert.ToDouble(phantram * luongcoban / 100);
                txtBaoHiem.Text = baohiem.ToString();
            }
            catch
            {
            }

            
        }

        private void btLUU_Click(object sender, EventArgs e)
        {

            LuuDuLieu();
            MessageBox.Show("Đã lưu");
            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
            MessageBox.Show("Đã lưu");
            txtMaDinhMuc.ResetText();        
        }

      
    }
}
