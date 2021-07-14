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
    public partial class NPL_ChiTietLenhSanXuat : Form
    {
        private bool KiemTraLuu()
        {

            if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                txtSoChungTu.Focus();
                return false;
            }

            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người nhập kho ");
                gridNguoiLap.Focus();
                return false;
            }
            else if (dteNgayChungTuNPL.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                dteNgayChungTuNPL.Focus();
                return false;
            }
           

            else return true;

        }        
        private void Luu_XuatKho_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    double tongtienhang;
                    tongtienhang = CheckString.ConvertToDouble_My(txtTongTienHang.Text.ToString());
                    clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
                    cls1.sDienGiai = txtDienGiaiNPL.Text.ToString();
                    cls1.daNgayChungTu = dteNgayChungTuNPL.DateTime;
                    cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls1.fTongTienHang = tongtienhang;
                    cls1.iID_NguoiXuatKho = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                    cls1.sThamChieu = txtLenhSX.Text.ToString();
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaXuatKho = true;
                    cls1.iInt_GapDan_1_Khac_2_binhThuong_0 = 0;
                    cls1.Insert();
                    // insert tbChiTietNhapKho
                    string shienthi = "1";
                    int iiiiIDID_XuatKhoNPL = cls1.iID_XuatKhoNPL.Value;
                    clsKhoNPL_tbChiTietXuatKho clschitietxuatkho = new clsKhoNPL_tbChiTietXuatKho();
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dvmoi = dttttt2.DefaultView;
                    DataTable dtmoi = dvmoi.ToTable();
                    for (int i = 0; i < dtmoi.Rows.Count; i++)
                    {
                        clschitietxuatkho.iID_XuatKho = iiiiIDID_XuatKhoNPL;
                        clschitietxuatkho.iID_VTHH = Convert.ToInt16(dtmoi.Rows[i]["ID_VTHHVao"].ToString());
                        clschitietxuatkho.fSoLuongXuat = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["SoLuongVao"].ToString());
                        clschitietxuatkho.fDonGia = CheckString.ConvertToDouble_My(dtmoi.Rows[i]["DonGiaVao"].ToString());
                        clschitietxuatkho.bTonTai = true;
                        clschitietxuatkho.bNgungTheoDoi = false;
                        clschitietxuatkho.bDaXuatKho = true;
                        clschitietxuatkho.sGhiChu = "";
                        clschitietxuatkho.Insert();


                    }

                    /// Update trang thai nhap lenh san xuất
                    clsHUU_LenhSanXuat clsxxx = new CtyTinLuong.clsHUU_LenhSanXuat();
                    clsxxx.iID_LenhSanXuat = UCNPL_XuatKho_TheoLenhSanXuat_mayIN.mID_iD_LenhSanXuat;
                    clsxxx.Update_TrangThai_XuatKho_NPL_may_IN();
                    this.Close();
                    _ucXK.UCNPL_XuatKho_TheoLenhSanXuat_mayIN_Load(null, null);
                    MessageBox.Show("Đã xuất kho!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lưu xuất kho không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }       
        private void Load_lockUP_EDIT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.T_SelectAll(8); 

            gridMaCaTruong.Properties.DataSource = dtNguoi;
            gridMaCaTruong.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruong.Properties.DisplayMember = "MaNhanVien";

            dtNguoi = clsNguoi.T_SelectAll(5); 

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dtNguoi = clsNguoi.T_SelectAll_ChucVu(3); 

            gridMaCN.Properties.DataSource = dtNguoi;
            gridMaCN.Properties.ValueMember = "ID_NhanSu";
            gridMaCN.Properties.DisplayMember = "MaNhanVien";


            dtNguoi.Dispose();
            clsNguoi.Dispose();
        }
        private void HienThi_SUa_LenhSanXuat(int xxID_LSX)
        {
            DataTable dt2 = new DataTable();
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();           
            dt2 = cls2.SA_new(xxID_LSX);       
            gridControl1.DataSource = dt2;

            double deTOngtien;
        
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            cls.iID_LenhSanXuat = xxID_LSX;
            DataTable dt = cls.SelectOne();

            txtLenhSX.Text = cls.sMaLenhSanXuat.Value.ToString();
            dteNgaySX.EditValue = cls.daNgayThangSanXuat.Value;
            cbCaSX.Text = cls.sCaSanXuat.Value.ToString();
        
            gridMaCaTruong.EditValue = cls.iID_CaTruong.Value;
            gridMaCN.EditValue = cls.iID_CongNhan.Value;
            
            txtGhiChu.Text = cls.sGhiChu.Value.ToString();
          
            dteNgayChungTuNPL.DateTime = DateTime.Today;
        }

        UCNPL_XuatKho_TheoLenhSanXuat_mayIN _ucXK;
        public NPL_ChiTietLenhSanXuat(UCNPL_XuatKho_TheoLenhSanXuat_mayIN ucXK)
        {
            _ucXK = ucXK;
            InitializeComponent();
        }
        private void gridMaNguoiLap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NPL_ChiTietLenhSanXuat_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            gridNguoiLap.EditValue = 14;
            clSanLuongTangCa_May.Caption = "SL\n tăng ca";
            clSanLuongThuong_May.Caption = "Sản\n lượng";
            
            Load_lockUP_EDIT();
           
            HienThi_SUa_LenhSanXuat(UCNPL_XuatKho_TheoLenhSanXuat_mayIN.mID_iD_LenhSanXuat);

            clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "XKNPL 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt16(xxx.Substring(5).Trim()) + 1;
                txtSoChungTu.Text = "XKNPL " + xxx2.ToString() + "";
            }
            Cursor.Current = Cursors.Default;
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridMaCaTruong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                int iiiIDiID_CaTruong = Convert.ToInt16(gridMaCaTruong.EditValue.ToString());
                clsncc.iID_NhanSu = iiiIDiID_CaTruong;
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCaTruong.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                
            }
            catch
            {

            }
        }

        private void gridMaCN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridMaCN.EditValue.ToString());
               
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCN.Text = dt.Rows[0]["TenNhanVien"].ToString();
                }
            }
            catch
            {

            }
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiXuatKho.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

        private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;        

            if (e.Column == clSoLuongNhap_May)
            {
                if (bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao));
                if (bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May));
                fffthanhtien = fffsoluong * ffdongia;
                bandedGridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia_Vao)
            {
                if (bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clDonGia_Vao));
                if (bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = CheckString.ConvertToDouble_My(bandedGridView1.GetFocusedRowCellValue(clSoLuongNhap_May));
                fffthanhtien = fffsoluong * ffdongia;
                bandedGridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();
        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHang.Text);
                txtTongTienHang.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {
            }
        }
        
        private void btXuatKho_Click(object sender, EventArgs e)
        {
            Luu_XuatKho_NPL();
        }

        private void txtLenhSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgaySX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cbCaSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaCaTruong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaCN.Focus();
            }
        }

        private void txtTenCaTruong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtTenCN_KeyPress(object sender, KeyPressEventArgs e)
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
                dteNgayChungTuNPL.Focus();
            }
        }

        private void txtSoChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgayChungTuNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridNguoiLap.Focus();
            }
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiaiNPL.Focus();
            }
        }

        private void txtNguoiXuatKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDienGiaiNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridControl1.Focus();
            }
        }

        private void txtTongTienHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaCN_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaCN.Properties.View.Columns[0].Visible = false;
        }
    }
}
