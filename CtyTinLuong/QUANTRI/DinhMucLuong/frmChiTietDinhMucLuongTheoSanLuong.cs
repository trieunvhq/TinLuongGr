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
            try
            {
                using (clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new CtyTinLuong.clsDinhMuc_DinhMuc_Luong_TheoSanLuong())
                {
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
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        private void Luu_ThemMoi_DinhMuc()
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {
                    using (clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong())
                    {
                        cls.sMaDinhMuc = txtMaDinhMuc.Text.ToString();
                        cls.sDienGiai = txtDienGiai.Text.ToString();
                        if (gridMaVTHH.EditValue != null)
                        {
                            cls.iID_VTHH = Convert.ToInt16(gridMaVTHH.EditValue.ToString());
                        }
                        cls.dcDinhMuc_KhongTang = CheckString.ConvertToDouble_My(txtDonGiaThuong.Text.Trim());
                        cls.dcDinhMuc_Tang = CheckString.ConvertToDouble_My(txtDonGiaTang.Text.Trim());
                        cls.bTonTai = true;
                        cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                        cls.fMaxSanLuongThuong = CheckString.ConvertToDouble_My(txtMaxSanLuongThuong.Text);
                        cls.Insert();
                        MessageBox.Show("Đã lưu! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _frm.HienThi();
                        this.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Lỗi: Dữ liệu nhập vào không hợp lệ!" + ee.Message.ToString(), "Lỗi nhập dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Luu_Sua_DinhMuc()
        {
            try
            {
                using (clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong())
                {
                    if (!KiemTraLuu()) return;
                    else
                    {
                        cls.iID_DinhMuc_Luong_SanLuong = frmQuanLyDinhMucLuongTheoSanLuong.miID_Sua_DinhMucLuongTheoSanLuong;
                        cls.sMaDinhMuc = txtMaDinhMuc.Text.ToString();
                        cls.sDienGiai = txtDienGiai.Text.ToString();

                        if (gridMaVTHH.EditValue != null)
                        {
                            cls.iID_VTHH = Convert.ToInt16(gridMaVTHH.EditValue.ToString());
                        }

                        cls.dcDinhMuc_KhongTang = CheckString.ConvertToDouble_My(txtDonGiaThuong.Text.Trim());
                        cls.dcDinhMuc_Tang = CheckString.ConvertToDouble_My(txtDonGiaTang.Text.Trim());
                        cls.bTonTai = true;
                        cls.fMaxSanLuongThuong = CheckString.ConvertToDouble_My(txtMaxSanLuongThuong.Text.ToString());
                        cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                        cls.Update();
                        MessageBox.Show("Đã lưu! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _frm.HienThi();
                        this.Close();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: Dữ liệu nhập vào không hợp lệ!" + ea.Message.ToString(), "Lỗi nhập dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool KiemTraLuu()
        {
            try
            {
                using (clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong())
                {
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
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: Dữ liệu nhập vào không hợp lệ!" + ea.Message.ToString(), "Lỗi nhập dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            

        }

        frmQuanLyDinhMucLuongTheoSanLuong _frm;
        public frmChiTietDinhMucLuongTheoSanLuong(frmQuanLyDinhMucLuongTheoSanLuong frm)
        {
            InitializeComponent();

            _frm = frm;
        }

        private void frmChiTietDinhMucLuongTheoSanLuong_Load(object sender, EventArgs e)
        {
            try
            {
                using (clsTbVatTuHangHoa clsVT = new clsTbVatTuHangHoa())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    DataTable dtVT = clsVT.T_SelectAll(); ;

                    gridMaVTHH.Properties.DataSource = dtVT;
                    gridMaVTHH.Properties.ValueMember = "ID_VTHH";
                    gridMaVTHH.Properties.DisplayMember = "MaVT";
                    dtVT.Dispose();
                    clsVT.Dispose();

                    if (frmQuanLyDinhMucLuongTheoSanLuong.mb_TheMoi_DinhMucLuongSanLuong == false)
                        hienthiSUaDuLieu();
                    else txtMaDinhMuc.Text = CheckString.creatMaDinhMucSL();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch(Exception ea)
            {
                MessageBox.Show("Lỗi: Kiểm tra lại kết nối!" + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: Kiểm tra lại kết nối!" + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonGiaThuong_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //    //decimal value = decimal.Parse(txtDonGiaThuong.Text, System.Globalization.NumberStyles.AllowThousands);
            //    double value = CheckString.ConvertToDouble_My(txtDonGiaThuong.Text);
            //    txtDonGiaThuong.Text = value.ToString("N2");
            //    //txtDonGiaThuong.Text = String.Format(culture, "{0:N0}", value);
            //    //txtDonGiaThuong.Select(txtDonGiaThuong.Text.Length, 0);
            //}
            //catch (Exception ea)
            //{
            //    MessageBox.Show("Lỗi: Kiểm tra lại kết nối!" + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void txtDonGiaTang_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //    //decimal value = decimal.Parse(txtDonGiaTang.Text, System.Globalization.NumberStyles.AllowThousands);
            //    double value = CheckString.ConvertToDouble_My(txtDonGiaTang.Text);
            //    txtDonGiaTang.Text = String.Format(culture, "{0:N0}", value);
            //    //txtDonGiaTang.Select(txtDonGiaTang.Text.Length, 0);
            //}
            //catch (Exception ea)
            //{
            //    MessageBox.Show("Lỗi: decimal.Parse(txtDonGiaTang.Text, System.Globalization.NumberStyles.AllowThousands); " 
            //        + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
           
        }

        private void gridMaVTHH_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVTHH.Properties.View.Columns[0].Visible = false;
            gridMaVTHH.Properties.View.Columns[3].Visible = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            frmQuanLyDinhMucLuongTheoSanLuong.mb_TheMoi_DinhMucLuongSanLuong = true;
            txtMaDinhMuc.Text = CheckString.creatMaDinhMucSL();
        }

        private void txtMaDinhMuc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gridMaVTHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenVTHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMaxSanLuongThuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    //decimal value = decimal.Parse(txtDonGiaThuong.Text, System.Globalization.NumberStyles.AllowThousands);
                    double value = CheckString.ConvertToDouble_My(txtMaxSanLuongThuong.Text);
                    txtMaxSanLuongThuong.Text = value.ToString("N2");
                    //txtDonGiaThuong.Text = String.Format(culture, "{0:N0}", value);
                    //txtDonGiaThuong.Select(txtDonGiaThuong.Text.Length, 0);
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Lỗi: Kiểm tra lại kết nối!" + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SendKeys.Send("{TAB}");
            }
        }

        private void txtDonGiaThuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    //decimal value = decimal.Parse(txtDonGiaThuong.Text, System.Globalization.NumberStyles.AllowThousands);
                    double value = CheckString.ConvertToDouble_My(txtDonGiaThuong.Text);
                    txtDonGiaThuong.Text = value.ToString("N2");
                    //txtDonGiaThuong.Text = String.Format(culture, "{0:N0}", value);
                    //txtDonGiaThuong.Select(txtDonGiaThuong.Text.Length, 0);
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Lỗi: Kiểm tra lại kết nối!" + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDonGiaTang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    //decimal value = decimal.Parse(txtDonGiaTang.Text, System.Globalization.NumberStyles.AllowThousands);
                    double value = CheckString.ConvertToDouble_My(txtDonGiaTang.Text);
                    txtDonGiaTang.Text = value.ToString("N2");
                    //txtDonGiaTang.Text = String.Format(culture, "{0:N0}", value);
                    //txtDonGiaTang.Select(txtDonGiaTang.Text.Length, 0);
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Lỗi: decimal.Parse(txtDonGiaTang.Text, System.Globalization.NumberStyles.AllowThousands); "
                        + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SendKeys.Send("{TAB}");
            }
        }
    }
}
