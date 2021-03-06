using DevExpress.XtraLayout.Utils;
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
    public partial class frmChiTietDinhMuc_HangNhu : Form
    {

        private void Luu_DuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    Double  fsoKG_1bao, fsokienmotbao;
                  
                    if (txtSoKGMotBao.Text.ToString() == "")
                        fsoKG_1bao = 0;
                    else fsoKG_1bao = CheckString.ConvertToDouble_My(txtSoKGMotBao.Text.ToString().Trim());

                    if (txtSoKienMotBao.Text.ToString() == "")
                        fsokienmotbao = 0;
                    else fsokienmotbao = CheckString.ConvertToDouble_My(txtSoKienMotBao.Text.ToString().Trim());

                    clsDinhMuc_tbDinhMuc_DOT cls = new clsDinhMuc_tbDinhMuc_DOT();

                    if (dteNgayThang.Text.ToString() != "")
                        cls.daNgayThang = dteNgayThang.DateTime;
                    else cls.daNgayThang = DateTime.Today;
                                      
                    cls.sCa = "Ca 1";
                    cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
                    cls.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());
                    cls.sLoaiGiay = "";
                    cls.fSoLuongKiemTra = 0;
                    cls.fTrongLuongKiemTra = 0;
                    cls.fSoLuongQuyDoi = 0;
                    cls.sDonViQuyDoi = "";                    
                    cls.fPhePham = 0;
                    cls.fDoCao = 0;                 
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.sGhiChu = txtGhiChu.Text.ToString();
                    cls.bKhoa = false;
                    cls.fQuyRaKien = 0;

                    cls.fSoKG_MotBao = fsoKG_1bao;
                    cls.fSoKienMotBao = fsokienmotbao;
                    if (checkHangNhu.Checked == true)
                        cls.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 2;
                    else if (checkHangCuc.Checked == true)
                        cls.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 3;
                    else if (checkHangSot.Checked == true)
                        cls.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 = 4;

                    if (UCDinhMucHangNhu.mb_TheMoi_DinhMuc_Dot==true)
                    {
                        if (cls.Insert())
                        {
                            this.Close();
                            _ucDMHN.btRefresh_Click(null, null);
                            MessageBox.Show("Đã lưu!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Lưu dữ liệu không thành công!", "Error");
                        }
                    }
                    else
                    {
                        cls.iID_DinhMuc_Dot = UCDinhMucHangNhu.miID_DinhMuc_Dot;
                        //cls.Update();
                        if (cls.Update())
                        {
                            this.Close();
                            _ucDMHN.btRefresh_Click(null, null);
                            MessageBox.Show("Đã lưu!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Lưu dữ liệu không thành công!", "Error");
                        }

                    }
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

     
        private void HienThi_ThemMoi_DinhMuc_DOT()
        {
          try
            {
                using (clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa())
                {
                    if (UCDinhMucHangNhu.xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 2)
                        checkHangNhu.Checked = true;
                    else if (UCDinhMucHangNhu.xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 3)
                        checkHangCuc.Checked = true;
                    else if (UCDinhMucHangNhu.xxiiHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 4)
                        checkHangSot.Checked = true;
                    dteNgayThang.EditValue = DateTime.Today;

                    DataTable dt = cls.T_SelectAll();
                    gridLookUpEditLoaiHang.Properties.DataSource = dt;
                    gridLookUpEditLoaiHang.Properties.ValueMember = "ID_VTHH";
                    gridLookUpEditLoaiHang.Properties.DisplayMember = "MaVT";
                    dt.Dispose();
                    cls.Dispose();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThi_Sua_DinhMuc_DOT()
        {
            try
            {
                using (clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa())
                {
                    
                    DataTable dt = cls.SelectAll();
                    dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                    DataView dv = dt.DefaultView;
                    DataTable dtxx = dv.ToTable();
                    gridLookUpEditLoaiHang.Properties.DataSource = dtxx;
                    gridLookUpEditLoaiHang.Properties.ValueMember = "ID_VTHH";
                    gridLookUpEditLoaiHang.Properties.DisplayMember = "MaVT";
                }

                using (clsDinhMuc_tbDinhMuc_DOT cls2 = new CtyTinLuong.clsDinhMuc_tbDinhMuc_DOT())
                {
                    cls2.iID_DinhMuc_Dot = UCDinhMucHangNhu.miID_DinhMuc_Dot;
                    DataTable dt2 = cls2.SelectOne();
                    dteNgayThang.EditValue = Convert.ToDateTime(dt2.Rows[0]["NgayThang"].ToString());
                    txtSoHieu.Text = dt2.Rows[0]["SoHieu"].ToString();
                    gridLookUpEditLoaiHang.EditValue = UCDinhMucHangNhu.miDID_VTHH;
                    txtSoKienMotBao.Text = dt2.Rows[0]["SoKienMotBao"].ToString();
                    txtSoKGMotBao.Text = dt2.Rows[0]["SoKG_MotBao"].ToString();
                    txtGhiChu.Text = dt2.Rows[0]["GhiChu"].ToString();

                    if (cls2.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 2)
                        checkHangNhu.Checked = true;
                    else if (cls2.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 3)
                        checkHangCuc.Checked = true;
                    else if (cls2.iHangDot_1_HangNhu_2_HangCuc_3_HangSot_4_ConLai_0 == 4)
                        checkHangSot.Checked = true;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private bool KiemTraLuu()
        {

            if (txtSoHieu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có mã định mức");
                txtSoHieu.Focus();
                return false;
            }
            else if (dteNgayThang.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày tháng ");
                dteNgayThang.Focus();
                return false;
            }
           
            else if (txtSoKienMotBao.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số kiện 1 bao");
                txtSoKienMotBao.Focus();
                return false;
            }
            else if (txtSoKGMotBao.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số Kg/ 1bao");
                txtSoKGMotBao.Focus();
                return false;
            }
            else return true;
        }


        UCDinhMucHangNhu _ucDMHN;
        public frmChiTietDinhMuc_HangNhu(UCDinhMucHangNhu ucDMHN)
        {
            _ucDMHN = ucDMHN;
            InitializeComponent();
        }

        private void btLuu_va_Dong_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Luu_DuLieu();
            txtSoHieu.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietDinhMuc_HangNhu_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (UCDinhMucHangNhu.mb_TheMoi_DinhMuc_Dot == true)
            {
                HienThi_ThemMoi_DinhMuc_DOT();
            }
            else
            {

                HienThi_Sua_DinhMuc_DOT();
            }
            Cursor.Current = Cursors.Default;
            checkHangNhu.Focus();
        }

        private void gridLookUpEditLoaiHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa())
                {
                    string manccc = gridLookUpEditLoaiHang.SelectedText.ToString();
                    clsncc.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());

                    DataTable dt = clsncc.SelectOne();
                    if (dt.Rows.Count > 0)
                    {
                        txtTenVatTu.Text = dt.Rows[0]["TenVTHH"].ToString();
                        txtDVT1.Text = dt.Rows[0]["DonViTinh"].ToString();
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void checkHangNhu_CheckedChanged(object sender, EventArgs e)
        {
            if(checkHangNhu.Checked==true)
            {
                checkHangSot.Checked = false;
                checkHangCuc.Checked = false;
                layout1.Visibility = LayoutVisibility.Always;
                layout1.Text = "Số cục/bao";
                layout2.Visibility = LayoutVisibility.Always;
                layout2.Text = "Số kiện/bao";
            }
        }

        private void checkHangSot_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangSot.Checked == true)
            {
                checkHangNhu.Checked = false;
                checkHangCuc.Checked = false;

                layout1.Visibility = LayoutVisibility.Always;
                layout1.Text = "Số Kg/Sọt";
                layout2.Visibility = LayoutVisibility.Always;
                layout2.Text = "Số kiện/Sọt";
            }
        }

        private void checkHangCuc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHangCuc.Checked == true)
            {
                checkHangNhu.Checked = false;
                checkHangSot.Checked = false;

                layout1.Visibility = LayoutVisibility.Never;
                //layout1.Text = "Số Kg/Sọt";
                layout2.Visibility = LayoutVisibility.Always;
                layout2.Text = "Số Cục/Kiện";
            }
        }

        private void checkHangNhu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void checkHangCuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void checkHangSot_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dteNgayThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridLookUpEditLoaiHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtSoKGMotBao.Focus();
            }
        }

        private void txtTenVatTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoKGMotBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSoKienMotBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            btLuu_va_Dong.Focus();
        }

        private void gridLookUpEditLoaiHang_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridLookUpEditLoaiHang.Properties.View.Columns[0].Visible = false;
        }
    }
}
