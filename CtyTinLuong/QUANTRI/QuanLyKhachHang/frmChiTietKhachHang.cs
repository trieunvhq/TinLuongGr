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
    public partial class frmChiTietKhachHang : Form
    {
        private bool KiemTraLuuThemMoi()
        {
            clsTbKhachHang cls = new CtyTinLuong.clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            string tenkhach = txtTen.Text;
            string MaKH = txtMaKH.Text;
            string expression;
            expression = "TenKH='" + tenkhach + "'";
            DataRow[] foundRows;
            foundRows = dt.Select(expression);

            string expression22;
            expression22 = "MaKH='" + MaKH + "'";
            DataRow[] foundRows222;
            foundRows222 = dt.Select(expression22);

            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chưa chọn nhập mã khách hàng");
                txtMaKH.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Chưa nhập tên khách hàng!");
                txtTen.Focus();
                return false;
            }
            else if (foundRows222.Length > 0)
            {
                MessageBox.Show("Đã có mã khách hàng tồn tại trong hệ thống ");
                txtMaKH.Focus();
                return false;
            }
            else if (foundRows.Length > 0)
            {
                MessageBox.Show("Đã có tên khách hàng tồn tại trong hệ thống ");
                txtTen.Focus();
                return false;
            }
            else if (gridTKKeToan.Text == "")
            {
                MessageBox.Show("Chưa có tài khoản kế toán ");
                return false;
            }
            else if (gridTKKeToan.EditValue == null)
            {
                MessageBox.Show("Chưa có tài khoản kế toán ");
                return false;
            }
            else return true;
        }

        private bool KiemTraSua(int idkh)
        {
            clsTbKhachHang cls = new CtyTinLuong.clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            string tenkhach = txtTen.Text.Trim();
            string MaKH = txtMaKH.Text;

            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chưa chọn nhập mã khách hàng");
                txtMaKH.Focus();
                return false;
            } 
            else if (String.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Chưa nhập tên khách hàng!");
                txtTen.Focus();
                return false;
            }
            else if (gridTKKeToan.EditValue == null)
            {
                MessageBox.Show("Chưa có tài khoản kế toán ");
                return false;
            } 
            else if (checkMaKHUpdate(dt, MaKH, idkh))
            {
                MessageBox.Show("Đã có mã khách hàng tồn tại trong hệ thống ");
                txtMaKH.Focus();
                return false;
            }
            else if (checkTenUpdate(dt, tenkhach, idkh))
            {
                MessageBox.Show("Đã có tên khách hàng tồn tại trong hệ thống ");
                txtTen.Focus();
                return false;
            }
            else if (checkTKKTUpdate(dt, idkh, Convert.ToInt32(gridTKKeToan.EditValue)))
            {
                MessageBox.Show("Tài khoản kế toán " + gridTKKeToan.Text + " đã được sử dụng. Vui lòng chọn tài khoản khác",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return false;
            }
            else return true;
        }

        private bool checkMaKHUpdate(DataTable dt, string maKhach, int idkh)
        {
            bool tmp = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idkh != Convert.ToInt32(dt.Rows[i]["ID_KhachHang"].ToString()))
                {
                    if (maKhach == dt.Rows[i]["MaKH"].ToString())
                    {
                        tmp = true;
                        break;
                    }
                }
            }
            return tmp;
        }

        private bool checkTenUpdate(DataTable dt, string tenkhach, int idkh)
        {
            bool tmp = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idkh != Convert.ToInt32(dt.Rows[i]["ID_KhachHang"].ToString()))
                {
                    if (tenkhach == dt.Rows[i]["TenKH"].ToString())
                    {
                        tmp = true; 
                        break;
                    }

                }
            }
            return tmp;
        }

        private bool checkTKKTUpdate(DataTable dt, int idkh, int tkkt)
        {
            bool tmp = false;
            int idtmp = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idkh != Convert.ToInt32(dt.Rows[i]["ID_KhachHang"].ToString()))
                {
                    if (tkkt == Convert.ToInt32(dt.Rows[i]["ID_TaiKhoanKeToan"].ToString()))
                    {
                        tmp = true;
                        break;
                    }
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idkh == Convert.ToInt32(dt.Rows[i]["ID_KhachHang"].ToString()))
                {
                    idtmp = Convert.ToInt32(dt.Rows[i]["ID_TaiKhoanKeToan"].ToString());
                    break;
                }
            }

            using (clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon())
            {
                DataTable kt = cls.SelectAll();
                for (int i = 0; i < kt.Rows.Count; i++)
                {
                    if (idtmp != Convert.ToInt32(kt.Rows[i]["ID_TaiKhoanKeToanCon"].ToString()))
                    {
                        if (tkkt == Convert.ToInt32(kt.Rows[i]["ID_TaiKhoanKeToanCon"].ToString()))
                        {
                            if (Convert.ToBoolean(kt.Rows[i]["Khoa"].ToString()))
                            {
                                tmp = true;
                                break;
                            }
                        }
                    }
                }
            }
            return tmp;
        }

        private void Luu_Khoa_TaiKhoanNganHang(int xxID_TK____)
        {
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.Update_Khoa_True(xxID_TK____);
        }
        private void Load_lockUp(bool themmoi)
        {
            DataTable dt = new DataTable();
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            if (themmoi == true)
            {
                dt = cls.SA_Khoa_False(); 
            }
            else dt = cls.SelectAll();
            gridTKKeToan.Properties.DataSource = dt;
            gridTKKeToan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKKeToan.Properties.DisplayMember = "SoTaiKhoanCon";
        }

        private void LuuDuLieu()
        {
            try
            {
                using (clsTbKhachHang cls = new clsTbKhachHang())
                { 
                    cls.sMaKH = txtMaKH.Text;
                    cls.sMaSoThue = txtMaSoThue.Text;
                    cls.sTenKH = txtTen.Text;
                    cls.sDiaChi = txtDiaChi.Text;
                    cls.sDienGiai = txtDienGiai.Text;
                    cls.sSoDienThoai = txtSDT.Text;
                    cls.sEmail = txtEmail.Text;
                    cls.sSoTaiKhoan = txtSoTaiKhoan.Text;
                    cls.sTenNganHang = txtNganHang.Text;
                    cls.sTinh_ThanhPho = txtTinh_ThanhPho.Text;
                    cls.sChiNhanh = txtChiNhanh.Text;
                    cls.bNgungTheoDoi = checNgungTheoDoi.Checked; ;
                    cls.bTonTai = true;
                    cls.sDaiDien = txtDaiDien.Text;
                    cls.iID_TaiKhoanKeToan = Convert.ToInt32(gridTKKeToan.EditValue.ToString());

                    if (frmKhachHang.mbSua == true)
                    {
                        if (!KiemTraSua(frmKhachHang.miID_Sua_KH))
                            return;
                        clsTbKhachHang clsxx = new clsTbKhachHang();
                        clsxx.iID_KhachHang = frmKhachHang.miID_Sua_KH;
                        DataTable dt = clsxx.SelectOne();
                        cls.bKhoa = clsxx.bKhoa.Value;
                        cls.iID_KhachHang = frmKhachHang.miID_Sua_KH;

                        if (cls.Update())
                        {
                            if (frmKhachHang._iID_TaiKhoanKeToan != Convert.ToInt32(gridTKKeToan.EditValue))
                            {
                                using (clsThin clt = new clsThin())
                                {
                                    clt.Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(frmKhachHang._iID_TaiKhoanKeToan, false);
                                    clt.Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(Convert.ToInt32(gridTKKeToan.EditValue), true);
                                }
                            }
                            _frmKH.btRefresh_Click(null, null);
                        }
                        //MessageBox.Show("Đã lưu");
                        this.Close();
                    }
                    else
                    {
                        //if (!String.IsNullOrEmpty(txtMaKH.Text))
                        //{
                        //    if (cls.SelectOne_MaKH(txtMaKH.Text.Trim()))
                        //    {
                        //        MessageBox.Show("Mã khách hàng \"" + txtMaKH.Text.Trim() + "\" đã tồn tại", "Thông báo");
                        //        txtMaKH.Focus();
                        //        return;
                        //    }
                        //}

                        //if (!String.IsNullOrEmpty(txtTen.Text))
                        //{
                        //    if (cls.SelectOne_TenKH(txtTen.Text.Trim()))
                        //    {
                        //        if (MessageBox.Show("Tên khách hàng \"" + txtTen.Text.Trim() + "\" đã tồn tại", "Thông báo",
                        //                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        //        {
                        //            txtTen.Focus();
                        //            return;
                        //        }
                        //    }
                        //}

                        if (!KiemTraLuuThemMoi())
                            return;

                        cls.bKhoa = false;
                        if (cls.Insert())
                        {
                            using (clsThin clt = new clsThin())
                            {
                                clt.Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(Convert.ToInt32(gridTKKeToan.EditValue.ToString()), true);
                                _frmKH.btRefresh_Click(null, null);
                            }
                        }
                        //MessageBox.Show("Đã thêm mới");
                        this.Close();
                    }
                }
            }
            catch(Exception ea)
            {
                MessageBox.Show("Lỗi:... " + ea.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HienThi_SuaThongTin_KhachHang()
        {
            clsTbKhachHang cls = new clsTbKhachHang();
            cls.iID_KhachHang = frmKhachHang.miID_Sua_KH;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtMaKH.Text = dt.Rows[0]["MaKH"].ToString();
                txtMaSoThue.Text = dt.Rows[0]["MaSoThue"].ToString();
                txtTen.Text = dt.Rows[0]["TenKH"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                txtSDT.Text = dt.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSoTaiKhoan.Text = dt.Rows[0]["SoTaiKhoan"].ToString();
                txtNganHang.Text = dt.Rows[0]["TenNganHang"].ToString();
                txtTinh_ThanhPho.Text = dt.Rows[0]["Tinh_ThanhPho"].ToString();
                txtChiNhanh.Text = dt.Rows[0]["ChiNhanh"].ToString();
                txtDaiDien.Text = dt.Rows[0]["DaiDien"].ToString();
                checNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
                if (dt.Rows[0]["ID_TaiKhoanKeToan"].ToString() != "")
                    gridTKKeToan.EditValue = cls.iID_TaiKhoanKeToan.Value;
            }
        }

        frmKhachHang _frmKH;
        public frmChiTietKhachHang(frmKhachHang frmKH)
        {
            _frmKH = frmKH;
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void frmChiTietKhachHang_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (frmKhachHang.mbSua == true)
            {
                Load_lockUp(false);
                HienThi_SuaThongTin_KhachHang();
            }
            else if (frmKhachHang.mbCopy == true)
            {
                Load_lockUp(true);
                HienThi_SuaThongTin_KhachHang();
            }
            else
            {
                Load_lockUp(true);
            }

            if (frmKhachHang.mbCopy || frmKhachHang.mbThemMoi)
            {
                //txtMaKH.Text = CheckString.creatMaKhachHang();
                txtMaKH.Text = gridTKKeToan.Text;
            }

            Cursor.Current = Cursors.Default;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridTKKeToan_EditValueChanged(object sender, EventArgs e)
        {
            int xxid = Convert.ToInt32(gridTKKeToan.EditValue.ToString());
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.iID_TaiKhoanKeToanCon = xxid;
            DataTable dt = cls.SelectOne();
            txtTenTaiKhoan.Text = cls.sTenTaiKhoanCon.Value;
            txtTen.Text = cls.sTenTaiKhoanCon.Value;
            txtMaKH.Text = gridTKKeToan.Text;
            //if(cls.bKhoa==true)
            //{
            //    if (frmKhachHang.mbSua == false)
            //    {

            //    }
            //}

        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoanKeToan.mbTheMoi = true;
            frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(null, this, null);
            ff.Show();
        }
    }
}
