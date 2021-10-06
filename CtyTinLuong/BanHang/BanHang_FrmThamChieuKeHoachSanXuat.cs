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
    public partial class BanHang_FrmThamChieuKeHoachSanXuat : Form
    {
        private bool KiemTraLuu()
        {
            if (gridKeHoach.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa chọn kế hoạch sản xuất ");
                return false;
            }
            
            else if (dteNgayChungTu.EditValue.ToString() == "")
            {
                MessageBox.Show("Chưa chọn ngày xuất hàng ");
                return false;
            }

            else return true;

        }
        private void Load_LockUp()
        {
            try
            {
                using (clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat())
                {
                    DataTable dt = cls.T_SelectAll_MaVT_Ten_DVT();

                    gridKeHoach.Properties.DataSource = dt;
                    gridKeHoach.Properties.ValueMember = "ID_KeHoachSanXuat";
                    gridKeHoach.Properties.DisplayMember = "MaKeHoach";
                    //dt.Dispose();
                    //cls.Dispose();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public BanHang_FrmThamChieuKeHoachSanXuat()
        {
            InitializeComponent();
        }

        private void BanHang_FrmThamChieuKeHoachSanXuat_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_LockUp();
                dteNgayChungTu.DateTime = BanHang_FrmChiTietBanHang_Newwwwwwww.mdaNgayChungTu;
                txtSoLuongthuc.Text = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbSoLuongXuat.ToString();
                gridKeHoach.Focus();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridKeHoach_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();
                cls.iID_KeHoachSanXuat = Convert.ToInt32(gridKeHoach.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                txtQuyCach.Text = cls.sQuyCach.Value;
                txtChiTieu.Text = cls.fSoLuong.Value.ToString();
                checkHoanThanh.Checked = cls.bDaHoanThanh.Value;
                txtDienGiai.Text = cls.sDienGiai.Value.ToString();

                int iIID_VTHH = cls.iID_VTHH.Value;
                clsTbVatTuHangHoa cls2 = new clsTbVatTuHangHoa();
                cls2.iID_VTHH = iIID_VTHH;
                DataTable dt2 = cls2.SelectOne();
                txtTenVatTu.Text = cls2.sTenVTHH.Value;
                txtDVT.Text = cls2.sDonViTinh.Value;
                txtmahang.Text = cls2.sMaVT.Value;

                int iiiID_khachhang = cls.iID_KhachHang.Value;
                clsTbKhachHang cls3 = new clsTbKhachHang();
                cls3.iID_KhachHang = iiiID_khachhang;
                DataTable dt3 = cls3.SelectOne();
                txtKhachHang.Text = cls3.sTenKH.Value;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void txtChiTieu_TextChanged(object sender, EventArgs e)
        {
            if (txtChiTieu.Text == txtSoLuongthuc.Text)
                checkHoanThanh.Checked = true;
        }

        private void txtSoLuongthuc_TextChanged(object sender, EventArgs e)
        {
            if (txtChiTieu.Text == txtSoLuongthuc.Text)
                checkHoanThanh.Checked = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    using (clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat())
                    {
                        cls.iID_KeHoachSanXuat = Convert.ToInt32(gridKeHoach.EditValue.ToString());
                        // update ngày xuất, so luong xuat,hoan thanh
                        cls.fSoLuongThucXuat = CheckString.ConvertToDouble_My(txtSoLuongthuc.Text.ToString());
                        cls.daNgayXuatThucTe = dteNgayChungTu.DateTime;
                        cls.bDaHoanThanh = checkHoanThanh.Checked;
                        cls.Update_NgayXuatThucTe_SoLuongThucXuat_DaHoanThanh();
                        MessageBox.Show("Đã lưu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridKeHoach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtKhachHang.Focus();
            }
        }

        private void txtKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtmahang.Focus();
            }
        }

        private void txtmahang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenVatTu.Focus();
            }
        }

        private void txtTenVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDVT.Focus();
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtQuyCach.Focus();
            }
        }

        private void txtQuyCach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtChiTieu.Focus();
            }
        }

        private void txtChiTieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteNgayChungTu.Focus();
            }
        }

        private void dteNgayChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoLuongthuc.Focus();
            }
        }

        private void txtSoLuongthuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLuu.Focus();
            }

        }

        private void btLuu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLuu.Focus();
                btLuu_Click(null, null);
            }
        }

        private void gridKeHoach_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridKeHoach.Properties.View.Columns[0].Visible = false;
        }
    }
}
