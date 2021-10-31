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
    public partial class frmChiTietNhaCungCap : Form
    {

        private bool KiemTraLuuThemMoi()
        {
            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            DataTable dt = cls.SelectAll();
            string tenNCC = txtTen.Text;
            string MaNhaCungCap = txtMaNCC.Text;
            string expression;
            expression = "TenNhaCungCap='" + tenNCC + "'";
            DataRow[] foundRows;
            foundRows = dt.Select(expression);

            string expression22;
            expression22 = "MaNhaCungCap='" + MaNhaCungCap + "'";
            DataRow[] foundRows222;
            foundRows222 = dt.Select(expression22);

            if (String.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Chưa chọn nhập mã nhà cung cấp");
                txtMaNCC.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Chưa nhập tên nhà cung cấp!");
                txtTen.Focus();
                return false;
            }
            else if (foundRows222.Length > 0)
            {
                MessageBox.Show("Đã có mã nhà cung cấp tồn tại trong hệ thống ");
                txtMaNCC.Focus();
                return false;
            }
            else if (foundRows.Length > 0)
            {
                MessageBox.Show("Đã có tên nhà cung cấp tồn tại trong hệ thống ");
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
            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            DataTable dt = cls.SelectAll();
            string tenNCC = txtTen.Text.Trim();
            string MaNhaCungCap = txtMaNCC.Text;

            if (String.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Chưa chọn nhập mã nhà cung cấp");
                txtMaNCC.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Chưa nhập tên nhà cung cấp!");
                txtTen.Focus();
                return false;
            }
            else if (gridTKKeToan.EditValue == null)
            {
                MessageBox.Show("Chưa có tài khoản kế toán ");
                return false;
            }
            else if (checkMaNCCUpdate(dt, MaNhaCungCap, idkh))
            {
                MessageBox.Show("Đã có mã nhà cung cấp tồn tại trong hệ thống ");
                txtMaNCC.Focus();
                return false;
            }
            else if (checkTenUpdate(dt, tenNCC, idkh))
            {
                MessageBox.Show("Đã có tên nhà cung cấp tồn tại trong hệ thống ");
                txtTen.Focus();
                return false;
            }
            else if (checkTKKTUpdate(dt, idkh, Convert.ToInt32(gridTKKeToan.EditValue)))
            {
                MessageBox.Show("Tài khoản kế toán " + gridTKKeToan.Text + " đã được sử dụng. Vui lòng chọn tài khoản khác",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return false;
            }
            else return true;
        }

        private bool checkMaNCCUpdate(DataTable dt, string maNCC, int idkh)
        {
            bool tmp = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idkh != Convert.ToInt32(dt.Rows[i]["ID_NhaCungCap"].ToString()))
                {
                    if (maNCC == dt.Rows[i]["MaNhaCungCap"].ToString())
                    {
                        tmp = true;
                        break;
                    }
                }
            }
            return tmp;
        }

        private bool checkTenUpdate(DataTable dt, string tenNCC, int idkh)
        {
            bool tmp = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int idncc_ = Convert.ToInt32(dt.Rows[i]["ID_NhaCungCap"].ToString());
                if (idkh != idncc_)
                {
                    string tenNCC_ = dt.Rows[i]["TenNhaCungCap"].ToString();
                    if (tenNCC == tenNCC_)
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
                if (idkh != Convert.ToInt32(dt.Rows[i]["ID_NhaCungCap"].ToString()))
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
                if (idkh == Convert.ToInt32(dt.Rows[i]["ID_NhaCungCap"].ToString()))
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

        private void Load_lockUp(bool themmoi)
        {
            DataTable dt = new DataTable();
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            if (themmoi == true)
                dt = cls.SA_Khoa_False();
            else dt = cls.SelectAll();
            gridTKKeToan.Properties.DataSource = dt;
            gridTKKeToan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            gridTKKeToan.Properties.DisplayMember = "SoTaiKhoanCon";
        }


        //private bool KiemTraLuu()
        //{
        //    if (txtMaNCC.Text.ToString() == "")
        //    {
        //        MessageBox.Show("Chưa chọn Mã Nhân viên ");
        //        return false;
        //    }
        //    else if (txtTen.Text.ToString() == "")
        //    {
        //        MessageBox.Show("Chưa có tên ");
        //        return false;
        //    }
        //    else if (gridTKKeToan.EditValue==null)
        //    {
        //        MessageBox.Show("Chưa có tài khoản kế toán ");
        //        return false;
        //    }
        //    else return true;

        //}
        private void Luu_Khoa_TaiKhoanNganHang(int xxID_TK____)
        {
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.Update_Khoa_True(xxID_TK____);
        }
        private void LuuDuLieu()
        {
            try
            {
                Luu_Khoa_TaiKhoanNganHang(Convert.ToInt32(gridTKKeToan.EditValue.ToString()));
                clsTbNhaCungCap cls = new clsTbNhaCungCap();
                cls.sMaNhaCungCap = txtMaNCC.Text.ToString();
                cls.sMaSoThue = txtMaSoThue.Text.ToString();
                cls.sTenNhaCungCap = txtTen.Text.ToString();
                cls.sDiaChi = txtDiaChi.Text.ToString();
                cls.sDienGiai = txtDienGiai.Text.ToString();
                cls.sSoDienThoai = txtSDT.Text.ToString();
                cls.sEmail = txtEmail.Text.ToString();
                cls.sSoTaiKhoan = txtSoTaiKhoan.Text.ToString();
                cls.sTenNganHang = txtNganHang.Text.ToString();
                cls.sTinh_ThanhPho = txtTinh_ThanhPho.Text.ToString();
                cls.sChiNhanh = txtChiNhanh.Text.ToString();
                cls.bNgungTheoDoi = checNgungTheoDoi.Checked; ;
                cls.bTonTai = true;
                cls.sNguoiLienHe = txtDaiDien.Text.ToString();
                if (gridTKKeToan.EditValue != null)
                    cls.iID_TaiKhoanKeToan = Convert.ToInt16(gridTKKeToan.EditValue.ToString());
                if(frmNhaCungCap.mbSua==true)
                {
                    if (!KiemTraSua(frmNhaCungCap.miID_Sua_NCC))
                        return;
                    clsTbNhaCungCap clsxx = new clsTbNhaCungCap();
                    clsxx.iID_NhaCungCap = frmNhaCungCap.miID_Sua_NCC;
                    DataTable dt = clsxx.SelectOne();
                    cls.bKhoa = clsxx.bKhoa.Value;

                    cls.iID_NhaCungCap = frmNhaCungCap.miID_Sua_NCC;
                    if (cls.Update())
                    {
                        if (frmNhaCungCap._iID_TaiKhoanKeToan != Convert.ToInt32(gridTKKeToan.EditValue))
                        {
                            using (clsThin clt = new clsThin())
                            {
                                clt.Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(frmNhaCungCap._iID_TaiKhoanKeToan, false);
                                clt.Tr_NganHang_TaiKhoanKeToanCon_Update_Khoa(Convert.ToInt32(gridTKKeToan.EditValue), true);
                            }
                        }
                        _frm.btRefresh_Click(null, null);
                    }
                    //MessageBox.Show("Đã lưu");
                    this.Close();
                }
                else
                {
                    //if (!String.IsNullOrEmpty(txtMaNCC.Text))
                    //{
                    //    if (cls.SelectOne_MaNhaCungCap(txtMaNCC.Text.Trim()))
                    //    {
                    //        MessageBox.Show("Mã nhà cung cấp \"" + txtMaNCC.Text.Trim() + "\" đã tồn tại", "Thông báo");
                    //        txtMaNCC.Focus();
                    //        return;
                    //    }
                    //}

                    ////
                    //if (!String.IsNullOrEmpty(txtTen.Text))
                    //{
                    //    if (cls.SelectOne_TenNhaCungCap(txtTen.Text.Trim()))
                    //    {
                    //        if (MessageBox.Show("Tên nhà cung cấp \"" + txtTen.Text.Trim() + "\" đã tồn tại", "Thông báo",
                    //                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
                            _frm.btRefresh_Click(null, null);
                        }
                    }
                    //MessageBox.Show("Đã thêm mới"); 
                    this.Close();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi:... " + ea.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void HienThi_SuaThongTin_NCC()
        {
            clsTbNhaCungCap cls = new clsTbNhaCungCap();
            cls.iID_NhaCungCap = frmNhaCungCap.miID_Sua_NCC;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtMaNCC.Text = dt.Rows[0]["MaNhaCungCap"].ToString();
                txtMaSoThue.Text = dt.Rows[0]["MaSoThue"].ToString();
                txtTen.Text = dt.Rows[0]["TenNhaCungCap"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                txtDienGiai.Text = dt.Rows[0]["DienGiai"].ToString();
                txtSDT.Text = dt.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSoTaiKhoan.Text = dt.Rows[0]["SoTaiKhoan"].ToString();
                txtNganHang.Text = dt.Rows[0]["TenNganHang"].ToString();
                txtTinh_ThanhPho.Text = dt.Rows[0]["Tinh_ThanhPho"].ToString();
                txtChiNhanh.Text = dt.Rows[0]["ChiNhanh"].ToString();
                txtDaiDien.Text = dt.Rows[0]["NguoiLienHe"].ToString();
                checNgungTheoDoi.Checked = Convert.ToBoolean(dt.Rows[0]["NgungTheoDoi"].ToString());
                if (dt.Rows[0]["ID_TaiKhoanKeToan"].ToString() != "")
                    gridTKKeToan.EditValue = cls.iID_TaiKhoanKeToan.Value;
            }

        }

        frmNhaCungCap _frm;
        public frmChiTietNhaCungCap(frmNhaCungCap frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThoat_Click_1(object sender, EventArgs e)
        {

        }

        private void btThoat_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        public void frmChiTietNhaCungCap_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          

            if (frmNhaCungCap.mbSua == true)
            {
                Load_lockUp(false);
                HienThi_SuaThongTin_NCC();
            }
            else if (frmNhaCungCap.mbCopy == true)
            {
                Load_lockUp(true);
                HienThi_SuaThongTin_NCC();
            }
            else
            {
                Load_lockUp(true);
            }

            if (frmNhaCungCap.mbCopy || frmNhaCungCap.mbThemMoi)
            {
                //txtMaKH.Text = CheckString.creatMaKhachHang();
                txtMaNCC.Text = gridTKKeToan.Text;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
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
            txtMaNCC.Text = gridTKKeToan.Text;
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoanKeToan.mbTheMoi = true;
            frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this);
            ff.Show();
        }

        public void GetTKngamDinh(string stk, int ID_TKme)
        {
            if (ID_TKme != -1)
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    DataTable dt = clsThin_.Tr_NganHang_TaiKhoanKeToanCon_SelectOne(ID_TKme, stk);
                    if (dt.Rows.Count > 0)
                    {
                        gridTKKeToan.Properties.DataSource = dt;
                        gridTKKeToan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
                        gridTKKeToan.Properties.DisplayMember = "SoTaiKhoanCon";
                        gridTKKeToan.EditValue = dt.Rows[0]["ID_TaiKhoanKeToanCon"].ToString();
                    }
                }
            }
        }
    }
}
