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
    public partial class Tr_frmChiTietChamCong_PhienDich : Form
    {
        private int _id_NhanVien = 0;

        frmChamCong_PhienDich _frm;
        DataTable _dtNguoi;
        public static decimal Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return decimal.Parse((string)row["expression"]);

        }

        private void Load_lockUP_EDIT()
        {
            try
            {
                using (clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu())
                {
                    _dtNguoi = clsNguoi.T_SelectAll(8);

                    _dtNguoi = clsNguoi.T_SelectAll(0);
                    searchLookMaDML.Properties.DataSource = _dtNguoi;
                    searchLookMaDML.Properties.ValueMember = "ID_NhanSu";
                    searchLookMaDML.Properties.DisplayMember = "MaNhanVien";

                    //Thay caption:
                    searchLookMaDML.Properties.View.Columns.Clear();//xóa caption cũ
                    searchLookMaDML.Properties.View.Columns.AddVisible("ID_NhanSu", "ID");
                    searchLookMaDML.Properties.View.Columns["ID_NhanSu"].Visible = false;


                    searchLookMaDML.Properties.View.Columns.AddVisible("MaNhanVien", "Mã nhân viên");
                    searchLookMaDML.Properties.View.Columns.AddVisible("TenNhanVien", "Tên nhân viên");
                    searchLookMaDML.Properties.View.Columns.AddVisible("NgaySinh", "Ngày sinh");
                }

                using (clsTr_ChamCongPhienDich cls = new clsTr_ChamCongPhienDich())
                {
                    DataTable dt = new DataTable();
                    dt = cls.Tr_KhachHang_PhienDich_SelectAll();
                    cbKhachHang.DataSource = dt;
                    cbKhachHang.ValueMember = "ID_KhachHang";
                    cbKhachHang.DisplayMember = "TenKhachHang";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LuuDuLieu(bool LuuVaDong)
        {
           try
            {
                if (!CheckDataInput()) return;

                using (clsTr_ChamCongPhienDich cls = new clsTr_ChamCongPhienDich())
                {
                    cls.iID_ChamConPhienDich = frmChamCong_PhienDich._iID_ChamCongPD;
                    cls.iID_CongNhan = Convert.ToInt32(searchLookMaDML.EditValue);
                    cls.iID_KhachHang = Convert.ToInt32(cbKhachHang.SelectedValue);
                    cls.sSoToKhai = txtSoToKhai.Text.ToString().Trim().ToUpper();
                    cls.sSoCont = txtSoCont.Text.ToString().Trim().ToUpper();
                    cls.daNgayThang = new DateTime(frmChamCong_PhienDich._nam, frmChamCong_PhienDich._thang, Convert.ToInt32(txtNgay.Value));

                    if (frmChamCong_PhienDich._mb_TheMoi)
                    {
                        if (cls.Tr_ChamCongPhienDich_Insert())
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (cls.Tr_ChamCongPhienDich_Update())
                        {
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    _frm.LoadData(false);

                    //lưu vào bảng chấm công để tính lương:
                    int id_bophan_ = KiemTraTenBoPhan("Phòng Tổng hợp");
                    if (id_bophan_ == 0) return;

                    int ngaycuathang_ = (((new DateTime(frmChamCong_PhienDich._nam, frmChamCong_PhienDich._thang, 1)).AddMonths(1)).AddDays(-1)).Day;
                    DateTime dateStart = new DateTime(frmChamCong_PhienDich._nam, frmChamCong_PhienDich._thang, 1);
                    DateTime dateEnd = new DateTime(frmChamCong_PhienDich._nam, frmChamCong_PhienDich._thang, ngaycuathang_);

                    DataTable dt = cls.Tr_ChamCongPhienDich_SelectAll(dateStart, dateEnd, Convert.ToInt32(searchLookMaDML.EditValue), "");

                    try
                    {
                        using (clsThin clsThin_ = new clsThin())
                        {
                            clsThin_.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
                                Convert.ToInt32(searchLookMaDML.EditValue),
                                frmChamCong_PhienDich._thang,
                                frmChamCong_PhienDich._nam,
                                0,
                                0,
                                dt.Rows.Count,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0, true, false, id_bophan_,
                                0,
                                1017);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể đồng bộ dữ liệu. Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                    if (LuuVaDong) this.Close();
                    else
                    {
                        _id_NhanVien = 0;
                        searchLookMaDML.ResetText();
                        txtTenNhanVien.ResetText();
                        TrUnlockReadonly();
                    }

                }
            }
            catch(Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrReadonly()
        {
            searchLookMaDML.ReadOnly = true;
            txtSoToKhai.ReadOnly = true;
            txtSoCont.ReadOnly = true;
            txtNgay.ReadOnly = true;
            cbKhachHang.Enabled = false;
        }

        private void TrUnlockReadonly()
        {
            searchLookMaDML.ReadOnly = false;
            txtSoToKhai.ReadOnly = false;
            txtSoCont.ReadOnly = false;
            txtNgay.ReadOnly = false;
            cbKhachHang.Enabled = true;
        }

        private void hienthiSUaDuLieu()
        {
            searchLookMaDML.EditValue = frmChamCong_PhienDich._iID_CongNhan;
            searchLookMaDML.ReadOnly = true;
            txtTenNhanVien.Text = frmChamCong_PhienDich._sTenCongNhan;
            cbKhachHang.SelectedValue = frmChamCong_PhienDich._iID_KhachHang;
            txtNgay.Text = frmChamCong_PhienDich._iNgay.ToString();
            txtSoToKhai.Text = frmChamCong_PhienDich._sSoToKhai;
            txtSoCont.Text = frmChamCong_PhienDich._sSoCont;
        }
        private void HienThi_ThemMoi()
        {
            searchLookMaDML.ReadOnly = false;
            searchLookMaDML.Text = "";
            txtTenNhanVien.Text = "";
            txtNgay.Text = DateTime.Now.Day.ToString();
            txtSoToKhai.Text = "";
            txtSoCont.Text = "";
        }
        public Tr_frmChiTietChamCong_PhienDich(frmChamCong_PhienDich frm)
        {
            InitializeComponent();
            _frm = frm;
            btLUU.Enabled = true;

            int ngaycuathang_ = (((new DateTime(frmChamCong_PhienDich._nam, frmChamCong_PhienDich._thang, 1)).AddMonths(1)).AddDays(-1)).Day;
            txtNgay.Maximum = ngaycuathang_;
        }

        private void Tr_frmChiTietChamCong_PhienDich_Load(object sender, EventArgs e)
        {
            TrUnlockReadonly();
            Load_lockUP_EDIT();
            searchLookMaDML.ReadOnly = false;

            if (frmChamCong_PhienDich._mb_TheMoi)
            {
                HienThi_ThemMoi();
            }
            else
                hienthiSUaDuLieu();
            
        }

       

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frm.LoadData(false);
            this.Close();
        }


        private void btLUU_Click(object sender, EventArgs e)
        {
            LuuDuLieu(true);
            _frm.LoadData(false);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmChamCong_PhienDich._mb_TheMoi = true;
            _id_NhanVien = 0;
            //searchLookMaDML.ResetText();
            //txtTenNhanVien.ResetText();
            TrUnlockReadonly();
        }

      
        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(searchLookMaDML.Text))
            {
                MessageBox.Show("Kiểm tra lại mã công nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookMaDML.Focus();
                return false;
            }
            else if (_id_NhanVien == 0)
            {
                MessageBox.Show("Kiểm tra lại mã công nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); //
                searchLookMaDML.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoToKhai.Text))
            {
                MessageBox.Show("Kiểm tra lại số tờ khai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoToKhai.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtSoCont.Text))
            {
                MessageBox.Show("Kiểm tra lại số cont!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoCont.Focus();
                return false;
            }

            else return true;
        }

        private void searchLookMaDML_EditValueChanged(object sender, EventArgs e)
        {
            
        }



        private void searchLookMaDML_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
                return;
            else if (e.Value.ToString() == "")
                return;
            else
            {
                _id_NhanVien = Convert.ToInt32(e.Value.ToString());
                for (int i = 0; i < _dtNguoi.Rows.Count; i++)
                {
                    if (_id_NhanVien == Convert.ToUInt32(_dtNguoi.Rows[i]["ID_NhanSu"].ToString()))
                    {
                        txtTenNhanVien.Text = _dtNguoi.Rows[i]["TenNhanVien"].ToString();
                        //e.DisplayText = _dtNguoi.Rows[i]["MaNhanVien"].ToString();
                    }
                }
                //MessageBox.Show(searchLookMaDML.EditValue.ToString()); //string str = dt.Rows[0]["MaNhanVien"].ToString(); 
            }
        }

       

        private void searchLookMaDML_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoToKhai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoCont_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");

                }
            }
            return _id_bophan;
        }
    }
}
