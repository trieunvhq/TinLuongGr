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
            clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();
            DataTable dt = cls.SelectAll_MaVT_Ten_DVT();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridKeHoach.Properties.DataSource = dtxx;
            gridKeHoach.Properties.ValueMember = "ID_KeHoachSanXuat";
            gridKeHoach.Properties.DisplayMember = "MaKeHoach";

        
        }
        public BanHang_FrmThamChieuKeHoachSanXuat()
        {
            InitializeComponent();
        }

        private void BanHang_FrmThamChieuKeHoachSanXuat_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteNgayChungTu.DateTime = BanHang_FrmChiTietBanHang_Newwwwwwww.mdaNgayChungTu;
            txtSoLuongthuc.Text = BanHang_FrmChiTietBanHang_Newwwwwwww.mdbSoLuongXuat.ToString();
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
            catch
            { }
           
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
                clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();
                cls.iID_KeHoachSanXuat= Convert.ToInt32(gridKeHoach.EditValue.ToString());
                // update ngày xuất, so luong xuat,hoan thanh
                cls.fSoLuongThucXuat = Convert.ToDouble(txtSoLuongthuc.Text.ToString());
                cls.daNgayXuatThucTe = dteNgayChungTu.DateTime;
                cls.bDaHoanThanh = checkHoanThanh.Checked;
                cls.Update_NgayXuatThucTe_SoLuongThucXuat_DaHoanThanh();
                MessageBox.Show("Đã lưu");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
