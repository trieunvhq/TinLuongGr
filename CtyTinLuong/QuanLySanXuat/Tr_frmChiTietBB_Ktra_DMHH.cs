using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Tr_frmChiTietBB_Ktra_DMHH : Form
    {
        private bool Insert_BB_Ktra_DMHHSX()
        {
            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();
            cls.daNgayThang = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
            cls.iCa = Convert.ToInt32(txtCa.Text.ToString());
            cls.sLoaiHang = txtLoaiHang.Text.ToString().Trim();
            cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
            cls.fSoLuongKtra = CheckString.ConvertToDouble_My(txtSoLuongKtra.Text.ToString());
            cls.sDonVi_first = txtDonVi_in.Text.ToString().Trim();
            cls.fTrongLuong = CheckString.ConvertToDouble_My(txtTrongLuong.Text.ToString());
            cls.fSoLuong = CheckString.ConvertToDouble_My(txtSoLuong.Text.ToString());
            cls.sDonVi_Second = txtDonVi_Out.Text.ToString().Trim();
            cls.fQuyRaKien = CheckString.ConvertToDouble_My(txtQuyRaKien.Text.ToString());
            cls.fPhePham = CheckString.ConvertToDouble_My(txtPhePham.Text.ToString());
            cls.fDoCao = CheckString.ConvertToDouble_My(txtDoCao.Text.ToString());
            cls.fMotBao_kg = CheckString.ConvertToDouble_My(txt1Bao_kg.Text.ToString());
            cls.fMotBao_SoKien = CheckString.ConvertToDouble_My(txt1Bao_SoKien.Text.ToString());
            cls.fSauMuoi_BaoKien = CheckString.ConvertToDouble_My(txt60Bao_Kien.Text.ToString());
            cls.sGhiChu = txtGhiChu.Text.ToString().Trim();

            if (cls.Insert()) return true;
            else return false;
        }


        // 
        private bool Update_BB_Ktra_DMHHSX()
        {
            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();

            cls.iId_BB = Tr_UC_BB_Ktra_DM_HHSX.miID_BienBan;
            cls.daNgayThang = Convert.ToDateTime(dateNgayThang.EditValue.ToString());
            cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
            cls.iCa = Convert.ToInt32(txtCa.Text.ToString());
            cls.sLoaiHang = txtLoaiHang.Text.ToString().Trim();
            cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
            cls.fSoLuongKtra = CheckString.ConvertToDouble_My(txtSoLuongKtra.Text.ToString());
            cls.sDonVi_first = txtDonVi_in.Text.ToString().Trim();
            cls.fTrongLuong = CheckString.ConvertToDouble_My(txtTrongLuong.Text.ToString());
            cls.fSoLuong = CheckString.ConvertToDouble_My(txtSoLuong.Text.ToString());
            cls.sDonVi_Second = txtDonVi_Out.Text.ToString().Trim();
            cls.fQuyRaKien = CheckString.ConvertToDouble_My(txtQuyRaKien.Text.ToString());
            cls.fPhePham = CheckString.ConvertToDouble_My(txtPhePham.Text.ToString());
            cls.fDoCao = CheckString.ConvertToDouble_My(txtDoCao.Text.ToString());
            cls.fMotBao_kg = CheckString.ConvertToDouble_My(txt1Bao_kg.Text.ToString());
            cls.fMotBao_SoKien = CheckString.ConvertToDouble_My(txt1Bao_SoKien.Text.ToString());
            cls.fSauMuoi_BaoKien = CheckString.ConvertToDouble_My(txt60Bao_Kien.Text.ToString());
            cls.sGhiChu = txtGhiChu.Text.ToString().Trim();

            if (cls.Update()) return true;
            else return false;
        }
       
   
        private void Load_frmEdit()
        {
            dateNgayThang.EditValue = Tr_UC_BB_Ktra_DM_HHSX.mdNgayThang;
            txtSoHieu.Text = Tr_UC_BB_Ktra_DM_HHSX.msSoHieu;
            txtCa.Text = Tr_UC_BB_Ktra_DM_HHSX.miCaSanXuat.ToString();
            txtLoaiHang.Text = Tr_UC_BB_Ktra_DM_HHSX.msLoaiHang.ToString();
            txtLoaiGiay.Text = Tr_UC_BB_Ktra_DM_HHSX.msLoaiGiay.ToString();
            txtSoLuongKtra.Text = Tr_UC_BB_Ktra_DM_HHSX.mfSoLuongKiemTra.ToString();
            txtDonVi_in.Text = Tr_UC_BB_Ktra_DM_HHSX.msDonVi;
            txtTrongLuong.Text = Tr_UC_BB_Ktra_DM_HHSX.mfTrongLuong.ToString();
            txtSoLuong.Text = Tr_UC_BB_Ktra_DM_HHSX.mfSoLuong.ToString();
            txtDonVi_Out.Text = Tr_UC_BB_Ktra_DM_HHSX.msDonVi_;
            txtQuyRaKien.Text = Tr_UC_BB_Ktra_DM_HHSX.mfQuyRaKien.ToString();
            txtPhePham.Text = Tr_UC_BB_Ktra_DM_HHSX.mfPhePham.ToString();
            txtDoCao.Text = Tr_UC_BB_Ktra_DM_HHSX.mfDoCao.ToString();
            txt1Bao_kg.Text = Tr_UC_BB_Ktra_DM_HHSX.mfMotBao_kg.ToString();
            txt1Bao_SoKien.Text = Tr_UC_BB_Ktra_DM_HHSX.mfMotBao_SoKien.ToString();
            txt60Bao_Kien.Text = Tr_UC_BB_Ktra_DM_HHSX.mfSauMuoi_BaoKien.ToString();
            txtGhiChu.Text = Tr_UC_BB_Ktra_DM_HHSX.msGhiChu;
        }

        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoHieu.Text))
            {
                MessageBox.Show("Kiểm tra lại Số hiệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHieu.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoHieu.Text))
            {
                MessageBox.Show("Kiểm tra lại Số hiệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHieu.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCa.Text))
            {
                MessageBox.Show("Kiểm tra lại Ca sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCa.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtCa.Text))
            {
                MessageBox.Show("Kiểm tra lại Ca sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCa.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLoaiHang.Text))
            {
                MessageBox.Show("Kiểm tra lại Loại hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiHang.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLoaiGiay.Text))
            {
                MessageBox.Show("Kiểm tra lại Loại giấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiGiay.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoLuongKtra.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongKtra.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoLuongKtra.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongKtra.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDonVi_in.Text))
            {
                MessageBox.Show("Kiểm tra lại Đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonVi_in.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTrongLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Trọng lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrongLuong.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtTrongLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Trọng lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrongLuong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtSoLuong.Text))
            {
                MessageBox.Show("Kiểm tra lại Số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDonVi_Out.Text))
            {
                MessageBox.Show("Kiểm tra lại Đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonVi_Out.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtQuyRaKien.Text))
            {
                MessageBox.Show("Kiểm tra lại Quy ra kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuyRaKien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtQuyRaKien.Text))
            {
                MessageBox.Show("Kiểm tra lại Quy ra kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuyRaKien.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPhePham.Text))
            {
                MessageBox.Show("Kiểm tra lại Phế phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhePham.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtPhePham.Text))
            {
                MessageBox.Show("Kiểm tra lại Phế phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhePham.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDoCao.Text))
            {
                MessageBox.Show("Kiểm tra lại Độ cao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoCao.Focus();
                return false;
            }
            else if (!CheckIsNumber(txtDoCao.Text))
            {
                MessageBox.Show("Kiểm tra lại Độ cao!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoCao.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt1Bao_kg.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao (kg)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_kg.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt1Bao_kg.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao (kg)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_kg.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt1Bao_SoKien.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao giao số kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_SoKien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt1Bao_SoKien.Text))
            {
                MessageBox.Show("Kiểm tra lại 1 Bao giao số kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt1Bao_SoKien.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt60Bao_Kien.Text))
            {
                MessageBox.Show("Kiểm tra lại 60 Bao/kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt60Bao_Kien.Focus();
                return false;
            }
            else if (!CheckIsNumber(txt60Bao_Kien.Text))
            {
                MessageBox.Show("Kiểm tra lại 60 Bao/kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt60Bao_Kien.Focus();
                return false;
            }
            else return true;
        }

        //
        public static bool CheckIsNumber(string Value)
        {
            double OutVal;
            if (Double.TryParse(Value, out OutVal))
            {
                // it is a number
                return true;
            }
            else
            {
                // it is not a number
                return false;
            }
        }

        Tr_UC_BB_Ktra_DM_HHSX _ucBBKTDM;
        public Tr_frmChiTietBB_Ktra_DMHH(Tr_UC_BB_Ktra_DM_HHSX ucBBKTDM)
        {
            _ucBBKTDM = ucBBKTDM;
            InitializeComponent();
            dateNgayThang.EditValue = DateTime.Now;

            if (Tr_UC_BB_Ktra_DM_HHSX.mbCopy_BB_Ktra)
            {
                Load_frmEdit();
            }
            dateNgayThang.Focus();
        }

        private void Tr_frmChiTietBB_Ktra_DMHH_Load(object sender, EventArgs e)
        {
            dateNgayThang.Focus();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            if  (Tr_UC_BB_Ktra_DM_HHSX.mbAdd_BB_Ktra == true 
                && Tr_UC_BB_Ktra_DM_HHSX.mb_Sua_BB_Ktra == false)
            {
                if (CheckDataInput())
                {
                    if (Insert_BB_Ktra_DMHHSX())
                    {
                        this.Close();
                        _ucBBKTDM.btRefresh_Click(null, null);
                        MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (Tr_UC_BB_Ktra_DM_HHSX.mbAdd_BB_Ktra == false
                && Tr_UC_BB_Ktra_DM_HHSX.mb_Sua_BB_Ktra == true)
            {
                if (Update_BB_Ktra_DMHHSX())
                {
                    this.Close();
                    _ucBBKTDM.btRefresh_Click(null, null);
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu dữ thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void dateNgayThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoHieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtLoaiHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtLoaiGiay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoLuongKtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDonVi_in_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTrongLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDonVi_Out_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtQuyRaKien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPhePham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDoCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt1Bao_kg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt1Bao_SoKien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt60Bao_Kien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btSave.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
