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
    public partial class frmChiTietChamCong_Mot_CongNhan : Form
    {
        private void LuuDuLieu()
        {

            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            cls.iID_ChiTietChamCong = frmBangChamCongTrongThang.miiID_chiTietChamCong;
            cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
            cls.Update_W_DinhMucLuongCongNhat();
            MessageBox.Show("Đã lưu");
           
        }
        private void HienThi()
        {
            clsHUU_DinhMucLuong_CongNhat clsvthhh = new clsHUU_DinhMucLuong_CongNhat();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            gridMaDinhMucLuong.Properties.DataSource = newdtvthh;
            gridMaDinhMucLuong.Properties.ValueMember = "ID_DinhMucLuong_CongNhat";
            gridMaDinhMucLuong.Properties.DisplayMember = "MaDinhMucLuongCongNhat";

            gridMaDinhMucLuong.EditValue = frmBangChamCongTrongThang.miiD_DinhMuc_Luong;
            txtThangxxx.Text = frmBangChamCongTrongThang.miThang.ToString();
            txtNam.Text = frmBangChamCongTrongThang.miNam.ToString();
            txtHoTenxxx.Text = frmBangChamCongTrongThang.msTenNhanVien;
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            cls.iID_ChiTietChamCong = frmBangChamCongTrongThang.miiID_chiTietChamCong;
            DataTable dt = cls.SelectOne();
            txtSLThuongxxxx.Text = cls.fSLThuong.Value.ToString();
            txtSLTangCaxxx.Text = cls.fSLTangCa.Value.ToString();

        }
        public frmChiTietChamCong_Mot_CongNhan()
        {
            InitializeComponent();
        }

        private void frmChiTietChamCong_Mot_CongNhan_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void txtTamUng_Validated(object sender, EventArgs e)
        {

        }

        private void txtTamUng_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTamUng_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTamUng_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDMNgayThuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDMThu7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDMCHuNhat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThucNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBaoHiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMaNguoiLap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridDMLuong_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTongLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDMBaoHiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMaDinhMucLuong_EditValueChanged(object sender, EventArgs e)
        {
            clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
            cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
            DataTable dt = cls.SelectOne();
            txtDienGiai.Text = cls.sDienGiai.Value;
           
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
            
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLUU_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
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

        private void txtBaoHiem_TextChanged_1(object sender, EventArgs e)
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
    }
}
