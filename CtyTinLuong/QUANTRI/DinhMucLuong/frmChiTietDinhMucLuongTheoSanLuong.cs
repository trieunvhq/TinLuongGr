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
    public partial class frmChiTietDinhMucLuongTheoSanLuong : Form
    {
        private void hienthiSUaDuLieu()
        {
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new CtyTinLuong.clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            cls.iID_DinhMuc_Luong_SanLuong = frmQuanLyDinhMucLuongTheoSanLuong.miID_Sua_DinhMucLuongTheoSanLuong;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtMaDinhMuc.Text = dt.Rows[0]["MaDinhMuc"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                gridMaVTHH.EditValue = frmQuanLyDinhMucLuongTheoSanLuong.miiiID_VTHH;
                txtDonGiaTang.Text = dt.Rows[0]["DinhMuc_Tang"].ToString();
                txtDonGiaThuong.Text = dt.Rows[0]["DinhMuc_KhongTang"].ToString();             
                checkNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
                txtMaxSanLuongThuong.Text = cls.fMaxSanLuongThuong.Value.ToString();
            }
        }
    
        private void Luu_ThemMoi_DinhMuc()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                cls.sMaDinhMuc = txtMaDinhMuc.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.iID_VTHH= Convert.ToInt16(gridMaVTHH.EditValue.ToString());
                cls.dcDinhMuc_KhongTang = Convert.ToDecimal(txtDonGiaThuong.Text.ToString());            
                cls.dcDinhMuc_Tang = Convert.ToDecimal(txtDonGiaTang.Text.ToString());               
                cls.bTonTai = true;
                cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                cls.fMaxSanLuongThuong= Convert.ToDouble(txtMaxSanLuongThuong.Text.ToString());
                cls.Insert();
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }
        private void Luu_Sua_DinhMuc()
        {
            if (!KiemTraLuu()) return;
            else
            {

                clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                cls.iID_DinhMuc_Luong_SanLuong = frmQuanLyDinhMucLuongTheoSanLuong.miID_Sua_DinhMucLuongTheoSanLuong;               
                cls.sMaDinhMuc = txtMaDinhMuc.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.iID_VTHH = Convert.ToInt16(gridMaVTHH.EditValue.ToString());
                cls.dcDinhMuc_KhongTang = Convert.ToDecimal(txtDonGiaThuong.Text.ToString());
                cls.dcDinhMuc_Tang = Convert.ToDecimal(txtDonGiaTang.Text.ToString());
                cls.bTonTai = true;
                cls.fMaxSanLuongThuong = Convert.ToDouble(txtMaxSanLuongThuong.Text.ToString());
                cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                cls.Update();
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }
        private bool KiemTraLuu()
        {
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dxxxx = dv.ToTable();
            string maLuong = txtMaDinhMuc.Text.ToString();
            string filterExpression = "";
            filterExpression = "MaDinhMuc ='" + maLuong + "'";
            DataRow[] rows = dxxxx.Select(filterExpression);
            int k = rows.Length;

            if (txtMaDinhMuc.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn mã Định mức");
                return false;
            }
            
            else if (txtMaDinhMuc.Text.ToString() == "DM0")
            {
                MessageBox.Show("Định mức chuẩn, bị trùng tên Định mức chuẩn");
                return false;
            }
           
            else if (txtDonGiaTang.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn đơn giá tăng");
                return false;
            }
            else if (txtDonGiaThuong.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn đơn giá thường");
                return false;
            }
            else if (frmQuanLyDinhMucLuongTheoSanLuong.mb_TheMoi_DinhMucLuongSanLuong == true)
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
        public frmChiTietDinhMucLuongTheoSanLuong()
        {
            InitializeComponent();
        }

        private void frmChiTietDinhMucLuongTheoSanLuong_Load(object sender, EventArgs e)
        {
            clsTbVatTuHangHoa clsVT = new clsTbVatTuHangHoa();
            DataTable dtVT = clsVT.SelectAll();
            dtVT.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvVT = dtVT.DefaultView;
            DataTable newdtVT = dvVT.ToTable();

            gridMaVTHH.Properties.DataSource = newdtVT;
            gridMaVTHH.Properties.ValueMember = "ID_VTHH";
            gridMaVTHH.Properties.DisplayMember = "MaVT";
           
            if (frmQuanLyDinhMucLuongTheoSanLuong.mb_TheMoi_DinhMucLuongSanLuong == false)
                hienthiSUaDuLieu();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLUU_Click(object sender, EventArgs e)
        {
            if (frmQuanLyDinhMucLuongTheoSanLuong.mb_TheMoi_DinhMucLuongSanLuong == true)
                Luu_ThemMoi_DinhMuc();
            else Luu_Sua_DinhMuc();
        }

        private void gridMaVTHH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();

                clsncc.iID_VTHH = Convert.ToInt16(gridMaVTHH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenVTHH.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();

                }
            }
            catch
            {

            }
        }

        private void txtDonGiaThuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtDonGiaThuong.Text, System.Globalization.NumberStyles.AllowThousands);
                txtDonGiaThuong.Text = String.Format(culture, "{0:N0}", value);
                txtDonGiaThuong.Select(txtDonGiaThuong.Text.Length, 0);
            }
            catch
            {

            }
           
        }

        private void txtDonGiaTang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtDonGiaTang.Text, System.Globalization.NumberStyles.AllowThousands);
                txtDonGiaTang.Text = String.Format(culture, "{0:N0}", value);
                txtDonGiaTang.Select(txtDonGiaTang.Text.Length, 0);
            }
            catch
            {

            }
           
        }
    }
}
