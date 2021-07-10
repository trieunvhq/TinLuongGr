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
    public partial class frmChiTietTaiKhoanKeToanCon : Form
    {
        private bool KiemTraLuu()
        {
           if (txtSoTKCon.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số tk con ");
                return false;
            }
            else if (txtTenTKCon.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên TK con ");
                return false;
            }
            else return true;
        }
        private void HienThi()
        {
            clsNganHang_tbHeThongTaiKhoanKeToanMe clsme = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            DataTable dtme = clsme.SelectAll();
            //dtme.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            //DataView dvme = dtme.DefaultView;
            //DataTable newdtme = dvme.ToTable();
            gridTK_me.Properties.DataSource = dtme;
            gridTK_me.Properties.ValueMember = "ID_TaiKhoanKeToanMe";
            gridTK_me.Properties.DisplayMember = "SoTaiKhoanMe";
            if (frmQuanLyTaiKhoanKeToan.mbTheMoi == false)
            {
                
                clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                clscon.iID_TaiKhoanKeToanCon = frmQuanLyTaiKhoanKeToan.miID_TaiKhoan;
                DataTable dtcon = clscon.SelectOne();
                txtSoTKCon.Text = clscon.sSoTaiKhoanCon.Value.ToString();
                txtTenTKCon.Text = clscon.sTenTaiKhoanCon.Value.ToString();
                txtDienGiaiCon.Text = clscon.sDienGiaiCon.Value.ToString();
                txtGhiChuCon.Text = clscon.sGhiChuCon.Value.ToString();
                checkNgungTheoDoi.Checked = clscon.bNgungTheoDoi.Value;
                gridTK_me.EditValue = clscon.iID_TaiKhoanKeToanMe.Value;
            }
        }
        private void LuuDuLieu()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!KiemTraLuu()) return;
            else
            {
                if (frmQuanLyTaiKhoanKeToan.mbTheMoi == true)
                {
                    string ssotkcon = txtSoTKCon.Text.ToString();
                    clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                    DataTable dt = cls.SelectAll();
                    dt.DefaultView.RowFilter = "TonTai=True and SoTaiKhoanCon ='" + ssotkcon + "'";
                    DataView dv = dt.DefaultView;
                    DataTable newdt = dv.ToTable();

                    if (newdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Đã có tài khoản: " + ssotkcon + ". Vui lòng chọn tài khoản khác ");
                        return;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtSoTKCon.Text))
                        {
                            if (cls.SelectOne_SoTaiKhoanCon(txtSoTKCon.Text.Trim()))
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Số tài khoản con \"" + txtSoTKCon.Text.Trim() + "\" đã tồn tại", "Thông báo");
                                txtSoTKCon.Focus();
                                return;
                            }
                        }


                        if (!String.IsNullOrEmpty(txtTenTKCon.Text))
                        {
                            if (cls.SelectOne_TenTaiKhoanCon(txtTenTKCon.Text.Trim()))
                            {
                                Cursor.Current = Cursors.Default;
                                if (MessageBox.Show("Tên tài khoản con \"" + txtTenTKCon.Text.Trim() + "\" đã tồn tại", "Thông báo",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    txtTenTKCon.Focus();
                                    return;
                                }
                            }
                        }

                        cls.iID_TaiKhoanKeToanMe = Convert.ToInt16(gridTK_me.EditValue.ToString());
                        cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                        cls.bTonTai = true;
                        cls.sSoTaiKhoanCon = txtSoTKCon.Text.ToString();
                        cls.sTenTaiKhoanCon = txtTenTKCon.Text.ToString();
                        cls.sDienGiaiCon = txtDienGiaiCon.Text.ToString();
                        cls.sGhiChuCon = txtGhiChuCon.Text.ToString();
                        cls.bKhoa = false;
                        cls.Insert();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã lưu");
                    }
                      
                }
                else if (frmQuanLyTaiKhoanKeToan.mbTheMoi == false)
                {
                    clsNganHang_TaiKhoanKeToanCon clsxxx = new CtyTinLuong.clsNganHang_TaiKhoanKeToanCon();
                    clsxxx.iID_TaiKhoanKeToanCon= frmQuanLyTaiKhoanKeToan.miID_TaiKhoan;
                    DataTable dtxx = clsxxx.SelectOne();
                    clsNganHang_TaiKhoanKeToanCon cls = new CtyTinLuong.clsNganHang_TaiKhoanKeToanCon();
                    cls.iID_TaiKhoanKeToanMe = Convert.ToInt16(gridTK_me.EditValue.ToString());
                    cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls.bTonTai = true;
                    cls.sSoTaiKhoanCon = txtSoTKCon.Text.ToString();
                    cls.sTenTaiKhoanCon = txtTenTKCon.Text.ToString();
                    cls.sDienGiaiCon = txtDienGiaiCon.Text.ToString();
                    cls.sGhiChuCon = txtGhiChuCon.Text.ToString();
                    cls.iID_TaiKhoanKeToanCon = frmQuanLyTaiKhoanKeToan.miID_TaiKhoan;
                    cls.bKhoa = clsxxx.bKhoa.Value;
                    cls.Update();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã lưu");
                }
            }
            Cursor.Current = Cursors.Default;
        }


        public frmChiTietTaiKhoanKeToanCon()
        {
            InitializeComponent();
        }

        private void frmChiTietTaiKhoanKeToanCon_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void gridTK_me_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iiID = Convert.ToInt16(gridTK_me.EditValue.ToString());
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new CtyTinLuong.clsNganHang_tbHeThongTaiKhoanKeToanMe();
                cls.iID_TaiKhoanKeToanMe = iiID;
                DataTable dt = cls.SelectOne();
                txtTenTKMe.Text = cls.sTenTaiKhoanMe.Value.ToString();
                txtDienGiaiMe.Text = cls.sDienGiaiMe.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void txtSoTKCon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTKCon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
