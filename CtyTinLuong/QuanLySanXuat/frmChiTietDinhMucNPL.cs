using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmChiTietDinhMucNPL : Form
    {
      //  Double fSoLuong;
        private void Luu_ThemMoi_DM_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();
                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;
                    cls1.iID_VTHH_ThanhPham = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls1.iID_VTHH_Chinh= Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());                   
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls1.Insert();


                    int iID_DinhMuc_NPLxxxx = cls1.iID_DinhMuc_NPL.Value;
                    clsDinhMuc_ChiTiet_DM_NPL cls2 = new clsDinhMuc_ChiTiet_DM_NPL();
                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_NPL = iID_DinhMuc_NPLxxxx;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["strSoLuong"].ToString() != "")
                            cls2.fSoLuong = convertToDouble(dv3.Rows[i]["strSoLuong"].ToString());
                        else cls2.fSoLuong = 0;                   
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.Insert2(dv3.Rows[i]["strSoLuong"].ToString());
                    }
                    this.Close();
                    _ucDMNPL.btRefresh_Click(null, null);
                    MessageBox.Show("Đã lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }
        private double convertToDouble(string str)
        {
            double abc_ = 0; 
            try
            {
                if (str.Contains("/"))
                {
                    abc_ = (CheckString.ConvertToDouble_My(str.Split('/')[0])) / (CheckString.ConvertToDouble_My(str.Split('/')[1]));
                }
                else
                {
                    abc_ = CheckString.ConvertToDouble_My(str);
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại định dạng dữ liệu nhập vào! " + ea.Message.ToString(), "Lỗi ép kiểu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return abc_;
        }


        private void Luu_Sua__DM_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;
                    cls1.iID_VTHH_ThanhPham = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls1.iID_VTHH_Chinh = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());                    
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls1.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                    cls1.Update();


                    clsDinhMuc_ChiTiet_DM_NPL cls2 = new clsDinhMuc_ChiTiet_DM_NPL();
                    cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                    cls2.Delete_W_ID_DinhMuc_NPL();
                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["strSoLuong"].ToString() != "")
                            cls2.fSoLuong = convertToDouble(dv3.Rows[i]["strSoLuong"].ToString());
                        else cls2.fSoLuong = 0;
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.Insert2(dv3.Rows[i]["strSoLuong"].ToString());
                    }
                    this.Close();
                    _ucDMNPL.btRefresh_Click(null, null);
                    MessageBox.Show("Đã lưu");
                }
                catch (Exception ea)
                {
                    MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void HienThi_ThemMoi_DinhMuc_NPL()
        {
            dteNgayLap.EditValue = DateTime.Today;
        }

        DataTable dt2;
        private void HienThi_Sua_DinhMuc_NPL()
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls1.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                DataTable dt = cls1.SelectOne();
                gridMaTPQuyDoi.EditValue = cls1.iID_VTHH_ThanhPham.Value;
                gridMaVTchinh1.EditValue = cls1.iID_VTHH_Chinh.Value;

                txtMaDinhMucNPL.Text = cls1.sMaDinhMuc.Value.ToString();
                dteNgayLap.EditValue = cls1.daNgayLap.Value;
                txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
                checkNgungTheoDoi.Checked = Convert.ToBoolean(cls1.bNgungTheoDoi.Value.ToString());


                clsDinhMuc_ChiTiet_DM_NPL cls2 = new CtyTinLuong.clsDinhMuc_ChiTiet_DM_NPL();
                cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                dt2 = cls2.T_SelectAll_HienThi_LookUp();
                for (int i = 0; i < dt2.Rows.Count; ++i)
                {
                    dt2.Rows[i]["MaVT"] = Convert.ToInt32(dt2.Rows[i]["ID_VTHH"].ToString());
                }
                gridControl1.DataSource = dt2;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool KiemTraLuu()
        {
            try
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();

                if (txtMaDinhMucNPL.ToString() == "")
                {
                    MessageBox.Show("Chưa có mã Thành phẩm quy đổi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDinhMucNPL.Focus();
                    return false;
                }
                else if (gridMaTPQuyDoi.EditValue == null)
                {
                    MessageBox.Show("Chưa chọn Bán thành phẩm quy đổi ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridMaTPQuyDoi.Focus();
                    return false;
                }
                else if (dv3.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa chọn hàng hóa ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại các trường nhập vào! " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ucDinhMucNGuyenPhuLieu _ucDMNPL;

        public frmChiTietDinhMucNPL(ucDinhMucNGuyenPhuLieu ucDMNPL)
        {
            _ucDMNPL = ucDMNPL;
            InitializeComponent();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridLook_MaTPQuyDoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenThanhPhamQuyDoi.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtMaDinhMucNPL.Text = dt.Rows[0]["MaVT"].ToString();
                    txtDVTMaTP.Text = dt.Rows[0]["DonViTinh"].ToString();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ucDinhMucNGuyenPhuLieu.mb_TheMoi_DinhMuc_NPL == true)
                Luu_ThemMoi_DM_NPL();
            else Luu_Sua__DM_NPL();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                DataView dv = view.DataSource as DataView;
                if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
                {
                    e.Visible = false;
                    e.Handled = true;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: " + ea.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmChiTietDinhMucNPL_Load(object sender, EventArgs e)
        {
            try
            {
                using (clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    dt2 = new DataTable();
                    dt2.Columns.Add("ID_ChiTietDinhMucNPL", typeof(int));
                    dt2.Columns.Add("ID_DinhMuc_NPL", typeof(int));
                    dt2.Columns.Add("ID_VTHH", typeof(int));
                    dt2.Columns.Add("SoLuong", typeof(float));
                    dt2.Columns.Add("strSoLuong", typeof(string));
                    dt2.Columns.Add("MaVT");// 
                    dt2.Columns.Add("TenVTHH");
                    dt2.Columns.Add("DonViTinh");
                    dt2.Columns.Add("HienThi", typeof(string));
                    gridControl1.DataSource = dt2;


                    DataTable dtxx2 = cls.T_SelectAll();

                    gridMaTPQuyDoi.Properties.DataSource = dtxx2;
                    gridMaTPQuyDoi.Properties.ValueMember = "ID_VTHH";
                    gridMaTPQuyDoi.Properties.DisplayMember = "MaVT";
                    //
                    gridMaVTchinh1.Properties.DataSource = dtxx2;
                    gridMaVTchinh1.Properties.ValueMember = "ID_VTHH";
                    gridMaVTchinh1.Properties.DisplayMember = "MaVT";

                    repositoryItemSearchLookUpEdit1.DataSource = dtxx2;
                    repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
                    repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";

                    if (ucDinhMucNGuyenPhuLieu.mb_TheMoi_DinhMuc_NPL == true)
                        HienThi_ThemMoi_DinhMuc_NPL();
                    else HienThi_Sua_DinhMuc_NPL();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaVTchinh1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenVTchinh1.Text = dt.Rows[0]["TenVTHH"].ToString();                  
                    txtDVT_VTchinh1.Text = dt.Rows[0]["DonViTinh"].ToString(); 
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridMaTPQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtMaDinhMucNPL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaVTchinh1.Focus();
            }
        }

        private void txtTenThanhPhamQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVTMaTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaVTchinh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtTenVTchinh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVT_VTchinh1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgayLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void checkNgungTheoDoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        { 
            gridMaTPQuyDoi.Properties.View.Columns[0].Visible = false;
             
        }

        private void gridMaVTchinh1_EditValueChanged_1(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)gridMaVTchinh1.GetSelectedDataRow()).Row;
            txtTenVTchinh1.Text = row["TenVTHH"].ToString();
            txtDVT_VTchinh1.Text = row["DonViTinh"].ToString();
        }

        private void gridMaVTchinh1_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVTchinh1.Properties.View.Columns[0].Visible = false;
        }

        private void repositoryItemSearchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
            }
            catch { }
        }

        int iID_VTHH;
        string sMaVT, sTenVTHH, sDonViTinh;
        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
            iID_VTHH = Convert.ToInt32(row["ID_VTHH"].ToString());
            sTenVTHH = row["TenVTHH"].ToString();
            sDonViTinh = row["DonViTinh"].ToString();
        } 

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void gridView1_RowClick_1(object sender, RowClickEventArgs e)
        {

        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == clMaVT)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, iID_VTHH);
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, sTenVTHH);
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, sDonViTinh);

                    gridView1.SetRowCellValue(e.RowHandle, strSoLuong, "0");
                    string shienthixx = "1";
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, shienthixx);
                }
                else
                {
                    int index_ = e.RowHandle;
                    string name_ = e.Column.FieldName;
                    if (name_.Contains("strSoLuong"))
                    {
                        string str_ = (string)e.Value;
                        char[] str_array_ = str_.ToCharArray();
                        if (str_array_.Length > 0)
                        {
                            if ((int)str_array_[0] == 47)
                            {
                                str_ = "1" + str_;
                            }
                            else if ((int)str_array_[0] == 46)
                            {
                                str_ = "0" + str_;
                            }
                        }
                        bool isthaydoi_ = false;
                        bool daucham = false;
                        bool dauchia = false;
                        for (int i = 0; i < str_array_.Length; ++i)
                        {
                            int asii_ = (int)str_array_[i];

                            if ((asii_ >= 46 && asii_ <= 57) && asii_ != 47 && asii_ != 46)
                            { }
                            else if ((asii_ == 46))
                            {
                                if (daucham)
                                {
                                    isthaydoi_ = true;
                                    str_ = str_.Replace(str_array_[i].ToString(), "");
                                    MessageBox.Show("Bạn gõ số lượng không hợp lệ (Chỉ bao gồm số và các ký tự / hoặc .) ở dòng " + (index_ + 1), "Số lượng không hợp lệ", MessageBoxButtons.OK);
                                }
                                daucham = true;
                            }
                            else if ((asii_ == 47))
                            {
                                if (dauchia)
                                {
                                    isthaydoi_ = true;
                                    str_ = str_.Replace(str_array_[i].ToString(), "");
                                    MessageBox.Show("Bạn gõ số lượng không hợp lệ (Chỉ bao gồm số và các ký tự / hoặc .) ở dòng " + (index_ + 1), "Số lượng không hợp lệ", MessageBoxButtons.OK);
                                }
                                dauchia = true;
                            }
                            else
                            {
                                isthaydoi_ = true;
                                str_ = str_.Replace(str_array_[i].ToString(), "");
                                MessageBox.Show("Bạn gõ số lượng không hợp lệ (Chỉ bao gồm số và các ký tự / hoặc .) ở dòng " + (index_ + 1), "Số lượng không hợp lệ", MessageBoxButtons.OK);
                            }
                        }

                        str_array_ = str_.ToCharArray();
                        if (str_array_.Length > 1)
                        {
                            if ((int)str_array_[str_array_.Length - 1] == 47)
                            {
                                str_ = str_.Remove(str_.Length - 1, 1);
                            }
                            else if ((int)str_array_[str_array_.Length - 1] == 46)
                            {
                                str_ = str_.Remove(str_.Length - 1, 1);
                            }
                        }

                        if (index_ >= 0)
                        {
                            dt2.Rows[index_][name_] = str_;
                            if (isthaydoi_)
                            {
                                gridControl1.DataSource = null;
                                gridControl1.DataSource = dt2;
                                gridView1.FocusedRowHandle = index_;
                            }
                            else
                            {
                                gridView1.FocusedRowHandle = index_ + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: " + ea.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraEditors.LookUpEdit editor = sender as DevExpress.XtraEditors.LookUpEdit;
                //iID_ChiTietDinhMucNPL = Convert.ToInt16(editor.GetColumnValue("ID_ChiTietDinhMucNPL"));
                //iID_DinhMuc_NPL = Convert.ToInt16(editor.GetColumnValue("ID_DinhMuc_NPL"));
                iID_VTHH = Convert.ToInt16(editor.GetColumnValue("ID_VTHH"));
                sMaVT = editor.GetColumnValue("MaVT").ToString();
                sTenVTHH = editor.GetColumnValue("TenVTHH").ToString();
                sDonViTinh = editor.GetColumnValue("DonViTinh").ToString();
                //fSoLuong = CheckString.ConvertToDouble_My(editor.GetColumnValue("SoLuong").ToString());
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: " + ea.Message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
