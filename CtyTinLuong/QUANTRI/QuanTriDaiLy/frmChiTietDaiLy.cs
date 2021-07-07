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
    public partial class frmChiTietDaiLy : Form
    {
        private bool KiemTraLuu()
        {            
            if (txtMaDL.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã Nhân viên ");
                return false;
            }
            else if (txtTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên ");
                return false;            }
            
            else return true;

        }
        private void Luu_ThemMoi_DaiLy()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                cls.sMaDaiLy = txtMaDL.Text.ToString();
                cls.sTenDaiLy = txtTen.Text.ToString();
                cls.sDaiDien = txtDaiDien.Text.ToString();
                cls.sDiaChi = txtDiaChi.Text.ToString();
                cls.sSoDienThoai = txtSDT.Text.ToString();
                cls.sMaSoThue = txtMaSoThue.Text.ToString();
                cls.sGhiChu = txtGhiChu.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = checNgungTheoDoi.Checked;
                cls.bKhoa = false;
                cls.Insert();
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }

        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                
            
                cls.sMaDaiLy = txtMaDL.Text.ToString().Trim();
                cls.sTenDaiLy = txtTen.Text.ToString();
                cls.sDaiDien = txtDaiDien.Text.ToString();
                cls.sDiaChi = txtDiaChi.Text.ToString();
                cls.sSoDienThoai = txtSDT.Text.ToString();
                cls.sMaSoThue = txtMaSoThue.Text.ToString();
                cls.sGhiChu = txtGhiChu.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = checNgungTheoDoi.Checked;
               
                if (frmQuanLyDaiLy.mbSua == true)
                {
                    cls.iID_DaiLy = frmQuanLyDaiLy.miID_Sua_DaiLy;
                    DataTable dt = cls.SelectOne();
                    bool bkhoa = cls.bKhoa.Value;
                    cls.bKhoa = bkhoa;
                    cls.Update();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtMaDL.Text))
                    {
                        if (cls.SelectOne_MaDaiLy(txtMaDL.Text.Trim()))
                        {
                            MessageBox.Show("Mã đại lý \"" + txtMaDL.Text.Trim() + "\" đã tồn tại", "Thông báo");
                            txtMaDL.Focus();
                            return;
                        }
                    }

                    if (!String.IsNullOrEmpty(txtTen.Text))
                    {
                        if (cls.SelectOne_TenDaiLy(txtTen.Text.Trim()))
                        {
                            if (MessageBox.Show("Tên đại lý \"" + txtTen.Text.Trim() + "\" đã tồn tại", "Thông báo",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                txtTen.Focus();
                                return;
                            }
                        }
                    }

                    //
                    cls.bKhoa = false;
                    cls.Insert();
                    MessageBox.Show("Đã thêm mới");
                    this.Close();
                }
                    
            }

        }
        private void HienThi_SuaThongTin_DaiLy()
        {
            clsTbDanhMuc_DaiLy cls = new CtyTinLuong.clsTbDanhMuc_DaiLy();
            cls.iID_DaiLy = frmQuanLyDaiLy.miID_Sua_DaiLy;
            DataTable dt = cls.SelectOne();

            txtMaDL.Text = cls.sMaDaiLy.ToString();
            txtTen.Text = cls.sTenDaiLy.ToString();
            txtDaiDien.Text = cls.sDaiDien.ToString();
            txtDiaChi.Text = cls.sDiaChi.ToString();
            txtMaSoThue.Text = cls.sMaSoThue.ToString();
            txtGhiChu.Text = cls.sGhiChu.ToString();
            txtSDT.Text = cls.sSoDienThoai.ToString();
            checNgungTheoDoi.Checked = cls.bNgungTheoDoi.Value;
        }
        
        public frmChiTietDaiLy()
        {
            InitializeComponent();
        }

        private void frmChiTietDaiLy_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (frmQuanLyDaiLy.mbSua == true)
                HienThi_SuaThongTin_DaiLy();
            else if (frmQuanLyDaiLy.mbCopy == true)
                HienThi_SuaThongTin_DaiLy();

            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void txtMaDL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
