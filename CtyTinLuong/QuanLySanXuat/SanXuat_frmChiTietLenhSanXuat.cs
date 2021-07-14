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
    public partial class SanXuat_frmChiTietLenhSanXuat : Form
    {
        public static string msCaTruong, msCongNhan, msCaSanXuat,msTenMay, msNguoiLap;
         public static DataTable mdtLenhSanXuat;
          public static DateTime mdaNgayThang;
        //int iiiIDiID_CaTruong, iiiiID_CongNhan;
       
        //string sssssCa_May;
        //DateTime dadadaNgay_May;
        //int miID_LenhSX;
        private bool KiemTraLuu()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;

            if (txtLenhSX.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có mã lệnh");
                return false;
            }
            else if(cbCaSX.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn ca sản xuất");
                return false;
            }
            else if (dteNgaySX.EditValue==null)
            {
                MessageBox.Show("Chưa chọn ngày tháng");
                return false;
            }
            else if (gridMaCaTruong.EditValue==null)
            {
                MessageBox.Show("Chưa chọn ca trưởng");
                return false;
            }
            else if (gridMaCN.EditValue == null)
            {
                MessageBox.Show("Chưa chọn công nhân");
                return false;
            }
            else if (gridMaNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa chọn người lập");
                return false;
            }
            else if(dttttt2.Rows.Count==0)
            {
                MessageBox.Show("Dữ liệu trống");
                return false;
            }
            else return true;

        }
    

        private void Luu_Va_Gui_DuLieu(int iiDI_LSSX)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsHUU_LenhSanXuat cls1 = new clsHUU_LenhSanXuat();            
                if (cls1.Update_W_GuiDuLieu(iiDI_LSSX, true))
                {
                    this.Close();
                    _ucSXLSX.btRefresh_Click(null, null);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Đã gửi dữ liệu nhập xuất kho", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Gửi dữ liệu nhập xuất kho không thành công!", "Error");
                }
            }
        }
     
        private void HienThi_SUa_LenhSanXuat(int xxID_lenhSanhxuat_)
        {
           
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            DataTable dt2 = cls2.SA_new(xxID_lenhSanhxuat_);
            gridControl1.DataSource = dt2;
            
            
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            cls.iID_LenhSanXuat = xxID_lenhSanhxuat_;
            DataTable dt = cls.SelectOne();
            if (cls.bGuiDuLieu.Value == true)
            {
                btLuu_Gui_Dong.Enabled = false;               
            }
            txtLenhSX.Text = cls.sMaLenhSanXuat.Value.ToString();
            dteNgaySX.EditValue = cls.daNgayThangSanXuat.Value;
            cbCaSX.Text = cls.sCaSanXuat.Value.ToString();
           // checkNgungTheoDoi.Checked = cls.bNgungTheoDoi.Value;
            gridMaCaTruong.EditValue = cls.iID_CaTruong.Value;
            gridMaCN.EditValue = cls.iID_CongNhan.Value;
            if (dt.Rows[0]["ID_NguoiLap"].ToString()!="")
                gridMaNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            txtGhiChu.Text = cls.sGhiChu.Value.ToString();           
        }
       
        private void Load_lockUP_EDIT()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.T_SelectAll(8); 

            gridMaCaTruong.Properties.DataSource = dtNguoi;
            gridMaCaTruong.Properties.ValueMember = "ID_NhanSu";
            gridMaCaTruong.Properties.DisplayMember = "MaNhanVien";

             
            dtNguoi = clsNguoi.T_SelectAll(4);
            gridMaNguoiLap.Properties.DataSource = dtNguoi;
            gridMaNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridMaNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dtNguoi = clsNguoi.T_SelectAll(0);
            gridMaCN.Properties.DataSource = dtNguoi;
            gridMaCN.Properties.ValueMember = "ID_NhanSu";
            gridMaCN.Properties.DisplayMember = "MaNhanVien";

            dtNguoi.Dispose();
            clsNguoi.Dispose();
        }

        UC_SanXuat_LenhSanXuat _ucSXLSX;
        public SanXuat_frmChiTietLenhSanXuat(UC_SanXuat_LenhSanXuat ucSXLSX)
        {
            _ucSXLSX = ucSXLSX;
            InitializeComponent();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void SanXuat_frmChiTietLenhSanXuat_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // textBox4.Text = "" + UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat.ToString() + "; " + UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat.ToString() + "";
            clSanLuong_TangCa.Caption = "SL\n tăng ca";
            clSanLuong_Thuong.Caption = "Sản\n lượng";
            //LoadCombobox();
            Load_lockUP_EDIT();
           
            HienThi_SUa_LenhSanXuat(UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat);

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
                int iiiIDiID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                clsncc.iID_NhanSu = iiiIDiID_CaTruong;
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCaTruong.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
                //if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
                //{
                //    if (gridMaCaTruong.EditValue != null & dteNgaySX.EditValue != null)
                //    {
                //        clsPhieu_ChiTietPhieu_New clsin = new clsPhieu_ChiTietPhieu_New();
                //        clsin.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
                //        clsin.daNgaySanXuat = dteNgaySX.DateTime;
                //        clsin.sCaSanXuat = cbCaSX.Text.ToString();
                //        DataTable dtxx_DISTINCT = clsin.SelectAll_TaoLenhSX_W_CaTruong_CongNhan_Ngay_CaSX_DISTINCT();

                //        gridMaCN.Properties.DataSource = dtxx_DISTINCT;
                //        gridMaCN.Properties.ValueMember = "ID_NhanSu";
                //        gridMaCN.Properties.DisplayMember = "MaNhanVien";
                //    }
                //}



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
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaCN.EditValue.ToString());
                int iiiiID_CongNhan= Convert.ToInt32(gridMaCN.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenCN.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
            try
            {
                //if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
                //{
                  
                //        hienthiGridControl222222222();
                //}

            }
            catch
            {

            }

        }

        private void gridMaNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridMaNguoiLap.EditValue.ToString());             
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenNguoilap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }

   

        private void dteNgaySX_EditValueChanged(object sender, EventArgs e)
        {
          
            //dadadaNgay_May = dteNgaySX.DateTime;
            //try
            //{
            //    if (UC_SanXuat_LenhSanXuat.mb_ThemMoi_LenhSanXuat == true)
            //    {
            //        if (gridMaCaTruong.EditValue != null & dteNgaySX.EditValue != null)
            //        {
            //            clsPhieu_ChiTietPhieu_New clsin = new clsPhieu_ChiTietPhieu_New();
            //            clsin.iID_CaTruong = Convert.ToInt32(gridMaCaTruong.EditValue.ToString());
            //            clsin.daNgaySanXuat = dteNgaySX.DateTime;
            //            clsin.sCaSanXuat = cbCaSX.Text.ToString();
            //            DataTable dtin = clsin.SelectAll_TaoLenhSX_W_CaTruong_CongNhan_Ngay_CaSX_DISTINCT();
            //            gridMaCN.Properties.DataSource = dtin;
            //            gridMaCN.Properties.ValueMember = "ID_NhanSu";
            //            gridMaCN.Properties.DisplayMember = "MaNhanVien";
            //        }
            //    }

                
            //}
            //catch
            //{

            //}
           
           
        }


        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            Luu_Va_Gui_DuLieu(UC_SanXuat_LenhSanXuat.mID_iD_LenhSanXuat);

            Cursor.Current = Cursors.Default;
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
                gridMaNguoiLap.Focus();
            }
        }

        private void txtTenCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtTenNguoilap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    btLuu_Dong.Focus();
            //}
        }

        private void gridMaCN_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaCN.Properties.View.Columns[0].Visible = false;
        }

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cbCaSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sssssCa_May = cbCaSX.Text.ToString();
           
        }

       
        private void btPrint_Click(object sender, EventArgs e)        {
           
            if (!KiemTraLuu()) return;
            else
            {
              
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dttttt2.DefaultView;
                mdtLenhSanXuat = dvmoi.ToTable();

               

                msCaTruong = txtTenCaTruong.Text.ToString();
                msCongNhan = txtTenCN.Text.ToString();
                msCaSanXuat = cbCaSX.Text.ToString();                
                msNguoiLap = txtTenNguoilap.Text.ToString();
                mdaNgayThang = dteNgaySX.DateTime;

                frmPrintLenhSanXuat_I_C_D ff = new frmPrintLenhSanXuat_I_C_D();
                ff.Show();
            }
        }

       
      
    }
}
