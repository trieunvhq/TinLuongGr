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
    public partial class Tr_frmChiTiet_PhiPhatSinh : Form
    {
        private int _id_NhanVien = 0;

        Tr_frmPhiPhatSinh _frm;
        DataTable _dtBoPhan;
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
                using (clsThin clsThin_ = new clsThin())
                {
                    _dtBoPhan = clsThin_.T_NhanSu_tbBoPhan_SA();

                    for (int i = _dtBoPhan.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = _dtBoPhan.Rows[i];
                        if (Convert.ToInt32(dr["ID_BoPhan"].ToString()) == 0)
                            dr.Delete();
                    }
                    _dtBoPhan.AcceptChanges();

                    searchLookBoPhan.Properties.DataSource = _dtBoPhan;
                    searchLookBoPhan.Properties.ValueMember = "ID_BoPhan";
                    searchLookBoPhan.Properties.DisplayMember = "TenBoPhan";

                    //Thay caption:
                    searchLookBoPhan.Properties.View.Columns.Clear();//xóa caption cũ
                    searchLookBoPhan.Properties.View.Columns.AddVisible("ID_BoPhan", "ID");
                    //searchLookBoPhan.Properties.View.Columns["ID_NhanSu"].Visible = false;
                    searchLookBoPhan.Properties.View.Columns.AddVisible("TenBoPhan", "Tên bộ phân");
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

                using (clsTr_PhiPhatSinh cls = new clsTr_PhiPhatSinh())
                {
                    cls.iID_PhiPhatSinh = Tr_frmPhiPhatSinh._ID_PhiPhatSinh;
                    cls.iID_BoPhan = Convert.ToInt32(searchLookBoPhan.EditValue);
                    cls.fTienCong = CheckString.ConvertToDouble_My(txtTienCong.Text);
                    cls.fTienTru = CheckString.ConvertToDouble_My(txtTienTru.Text);
                    cls.sTenPhi = txtTenPhi.Text;
                    cls.sDienGiai = txtDienGiai.Text;
                    cls.bCaLamViec = radioCa1.Checked;
                    cls.iThang = Tr_frmPhiPhatSinh._thang;
                    cls.iThang = Tr_frmPhiPhatSinh._nam;


                    if (Tr_frmPhiPhatSinh._mb_TheMoi)
                    {
                        if (cls.Tr_PhiPhatSinh_Insert())
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (cls.Tr_PhiPhatSinh_Update())
                        {
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    _frm.LoadData(false, true);

                    if (LuuVaDong) this.Close();
                    else
                    {
                        _id_NhanVien = 0;
                        searchLookBoPhan.ResetText();
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
            searchLookBoPhan.ReadOnly = true;
            txtTienCong.ReadOnly = true;
            txtTienTru.ReadOnly = true;
            txtTenPhi.ReadOnly = true;
            txtDienGiai.ReadOnly = true;
            radioCa1.Enabled = false;
            radioCa2.Enabled = false;
        }

        private void TrUnlockReadonly()
        {
            searchLookBoPhan.ReadOnly = false;
            txtTienCong.ReadOnly = false;
            txtTienTru.ReadOnly = false;
            txtTenPhi.ReadOnly = false;
            txtDienGiai.ReadOnly = false;
            radioCa1.Enabled = true;
            radioCa2.Enabled = true;
        }

        private void hienthiSUaDuLieu()
        {
            searchLookBoPhan.EditValue = Tr_frmPhiPhatSinh._ID_BoPhan;
            searchLookBoPhan.ReadOnly = true;
            txtTienCong.Text = Tr_frmPhiPhatSinh._TienCong.ToString();
            txtTienTru.Text = Tr_frmPhiPhatSinh._TienTru.ToString();
            txtTenPhi.Text = Tr_frmPhiPhatSinh._TenPhi;
            txtDienGiai.Text = Tr_frmPhiPhatSinh._DienGiai;
            if (Tr_frmPhiPhatSinh._CaLamViec) radioCa1.Checked = true;
            else radioCa2.Checked = true;
        }
        private void HienThi_ThemMoi()
        {
            searchLookBoPhan.ReadOnly = false;
            searchLookBoPhan.Text = "";
            txtTienCong.Text = "";
            txtTienTru.Text = "";
            txtTenPhi.Text = "";
            txtDienGiai.Text = "";
            radioCa1.Checked = true;
        }
        public Tr_frmChiTiet_PhiPhatSinh(Tr_frmPhiPhatSinh frm = null)
        {
            InitializeComponent();
            _frm = frm;
            btLUU.Enabled = true;
        }

        private void Tr_frmChiTiet_PhiPhatSinh_Load(object sender, EventArgs e)
        {
            TrUnlockReadonly();
            Load_lockUP_EDIT();
            searchLookBoPhan.ReadOnly = false;

            if (Tr_frmPhiPhatSinh._mb_TheMoi)
            {
                HienThi_ThemMoi();
            }
            else
                hienthiSUaDuLieu();

        }

       

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frm.LoadData(false, radioCa1.Checked);
            this.Close();
        }


        private void btLUU_Click(object sender, EventArgs e)
        {
            LuuDuLieu(true);
            _frm.LoadData(false, radioCa1.Checked);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Tr_frmPhiPhatSinh._mb_TheMoi = true;
            _id_NhanVien = 0;
            TrUnlockReadonly();
        }

      
        private bool CheckDataInput()
        {
            if (string.IsNullOrWhiteSpace(searchLookBoPhan.Text))
            {
                MessageBox.Show("Kiểm tra lại mã công nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchLookBoPhan.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTienCong.Text))
            {
                MessageBox.Show("Kiểm tra lại số tiền cộng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienCong.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTienTru.Text))
            {
                MessageBox.Show("Kiểm tra lại số tiền trừ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTienTru.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTenPhi.Text))
            {
                MessageBox.Show("Kiểm tra lại tên phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPhi.Focus();
                return false;
            }

            else return true;
        }

        private void searchLookMaDML_EditValueChanged(object sender, EventArgs e)
        {
            
        }



        private void searchLookMaDML_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
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

        private void txtTenPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
