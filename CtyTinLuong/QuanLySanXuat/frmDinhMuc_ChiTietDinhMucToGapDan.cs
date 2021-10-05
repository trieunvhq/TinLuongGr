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
    public partial class frmDinhMuc_ChiTietDinhMucToGapDan : Form
    {
        private void Luu_ThemMoi_DM_NPL()
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {
                    bool ktra = false;
                    clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;

                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;

                    if (cls1.Insert())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int iiiID_DinhMuc_ToGapDan = cls1.iID_DinhMuc_ToGapDan.Value;
                    // insert thành phẩm

                    clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                    cls2.iID_DinhMuc_ToGapDan = iiiID_DinhMuc_ToGapDan;
                    cls2.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls2.fSoLuong = 1;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.iInt_TP_1_Chinh_2_Phu_3 = 1;

                    //cls2.Insert();
                    if (cls2.Insert())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //insert vật tư chính
                    cls2.iID_DinhMuc_ToGapDan = iiiID_DinhMuc_ToGapDan;
                    cls2.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                    cls2.fSoLuong = CheckString.ConvertToDouble_My(txtSoLuongVTChinh.Text.ToString());
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.iInt_TP_1_Chinh_2_Phu_3 = 2;
                    //cls2.Insert();
                    if (cls2.Insert())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_ToGapDan = iiiID_DinhMuc_ToGapDan;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["SoLuong"].ToString() != "")
                            cls2.fSoLuong = CheckString.ConvertToDouble_My(dv3.Rows[i]["SoLuong"].ToString());
                        else cls2.fSoLuong = 0;
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.iInt_TP_1_Chinh_2_Phu_3 = 3;
                        //cls2.Insert();
                        if (cls2.Insert())
                        {
                            ktra = true;
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (ktra)
                    {
                        this.Close();
                        _ucDMTGD.btRefresh_Click(null, null);
                        MessageBox.Show("Đã lưu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Luu_Sua__DM_NPL(int iiID_DinhMuc)
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {
                    bool ktra = false;
                    clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;

                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.iID_DinhMuc_ToGapDan = iiID_DinhMuc;
                    //cls1.Update();
                    if (cls1.Update())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // XÓa trước
                    clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                    cls2.iID_DinhMuc_ToGapDan = iiID_DinhMuc;
                    //cls2.Delete_ALL_W_ID_DinhMuc_ToGapDan();
                    if (cls2.Delete_ALL_W_ID_DinhMuc_ToGapDan())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // insert thành phẩm

                    cls2.iID_DinhMuc_ToGapDan = iiID_DinhMuc;
                    cls2.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls2.fSoLuong = 1;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.iInt_TP_1_Chinh_2_Phu_3 = 1;
                    //cls2.Insert();
                    if (cls2.Insert())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //insert vật tư chính
                    cls2.iID_DinhMuc_ToGapDan = iiID_DinhMuc;
                    cls2.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                    cls2.fSoLuong = CheckString.ConvertToDouble_My(txtSoLuongVTChinh.Text.ToString());
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.iInt_TP_1_Chinh_2_Phu_3 = 2;
                    //cls2.Insert();
                    if (cls2.Insert())
                    {
                        ktra = true;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_ToGapDan = iiID_DinhMuc; ;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["SoLuong"].ToString() != "")
                            cls2.fSoLuong = CheckString.ConvertToDouble_My(dv3.Rows[i]["SoLuong"].ToString());
                        else cls2.fSoLuong = 0;
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.iInt_TP_1_Chinh_2_Phu_3 = 3;
                        //cls2.Insert();
                        if (cls2.Insert())
                        {
                            ktra = true;
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (ktra)
                    {
                        this.Close();
                        _ucDMTGD.btRefresh_Click(null, null);
                        MessageBox.Show("Đã lưu!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThi_ThemMoi_DinhMuc_NPL()
        {
            dteNgayLap.EditValue = DateTime.Today;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTiet_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("ID_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("MaVT");// 
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));
            gridControl1.DataSource = dt2;
        }

        private void HienThi_Sua_DinhMuc_NPL(int iiID_DinhMuc)
        {
            try
            {
                using (clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan())
                {
                    cls1.iID_DinhMuc_ToGapDan = iiID_DinhMuc;
                    DataTable dt = cls1.SelectOne();
                    txtMaDinhMucNPL.Text = cls1.sMaDinhMuc.Value.ToString();
                    dteNgayLap.EditValue = cls1.daNgayLap.Value;
                    txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
                }

                using (clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan())
                {
                    DataTable dt_chinh = cls2.SA_ID_DinhMuc_VT_Chinh(iiID_DinhMuc);
                    DataTable dt_Phu = cls2.SA_ID_DinhMuc_VT_Phu(iiID_DinhMuc);
                    DataTable dt_ThanhPham = cls2.SA_ID_DinhMuc_ThanhPham(iiID_DinhMuc);
                    txtSoLuongVTChinh.Text = dt_chinh.Rows[0]["SoLuong"].ToString();
                    gridControl1.DataSource = dt_Phu;
                    gridMaVTchinh1.EditValue = Convert.ToInt32(dt_chinh.Rows[0]["ID_VTHH"].ToString());
                    gridMaTPQuyDoi.EditValue = Convert.ToInt32(dt_ThanhPham.Rows[0]["ID_VTHH"].ToString());
                }
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
                    MessageBox.Show("Chưa có mã Thành phẩm quy đổi", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDinhMucNPL.Focus();
                    return false;
                }
                else if (gridMaTPQuyDoi.EditValue == null)
                {
                    MessageBox.Show("Chưa chọn Bán thành phẩm quy đổi ", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridMaTPQuyDoi.Focus();
                    return false;
                }
                else if (dv3.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa chọn hàng hóa ", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else return true;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ..." + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        UCSanXuat_DinhMuc_ToGapDan _ucDMTGD;
        public frmDinhMuc_ChiTietDinhMucToGapDan(UCSanXuat_DinhMuc_ToGapDan ucDMTGD)
        {
            _ucDMTGD = ucDMTGD;
            InitializeComponent();
        }

        private void frmDinhMuc_ChiTietDinhMucToGapDan_Load(object sender, EventArgs e)
        {
            try
            {
                using (clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    DataTable dt = cls.T_SelectAll();

                    gridMaTPQuyDoi.Properties.DataSource = dt;
                    gridMaTPQuyDoi.Properties.ValueMember = "ID_VTHH";
                    gridMaTPQuyDoi.Properties.DisplayMember = "MaVT";
                    //
                    gridMaVTchinh1.Properties.DataSource = dt;
                    gridMaVTchinh1.Properties.ValueMember = "ID_VTHH";
                    gridMaVTchinh1.Properties.DisplayMember = "MaVT";

                    repositoryItemSearchLookUpEdit1.DataSource = dt;
                    repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
                    repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";
                    dt.Dispose();
                    cls.Dispose();
                    if (UCSanXuat_DinhMuc_ToGapDan.mb_TheMoi_DinhMuc_ToGapDan == true)
                        HienThi_ThemMoi_DinhMuc_NPL();
                    else HienThi_Sua_DinhMuc_NPL(UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan);

                    Cursor.Current = Cursors.Default;
                    txtMaDinhMucNPL.Focus();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (UCSanXuat_DinhMuc_ToGapDan.mb_TheMoi_DinhMuc_ToGapDan == true)
                    Luu_ThemMoi_DM_NPL();
                else Luu_Sua__DM_NPL(UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi lưu dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
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
        private int _ID_VTHH;
        private string _TenVTHH = "", _DonViTinh = "";
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_VTHH)
            {
                gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, _TenVTHH);
                gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, _DonViTinh);
                gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
            }
        }

        private void gridMaTPQuyDoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenThanhPhamQuyDoi.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVTMaTP.Text = dt.Rows[0]["DonViTinh"].ToString();

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDinhMucNPL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridMaTPQuyDoi_KeyPress(object sender, KeyPressEventArgs e)
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
                txtSoLuongVTChinh.Focus();
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

        private void txtSoLuongVTChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void repositoryItemSearchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        { 
            try
            {
                ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
            }
            catch { }
        }

        private void gridMaVTchinh1_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVTchinh1.Properties.View.Columns[0].Visible = false;
            gridMaVTchinh1.Properties.View.Columns[3].Visible = false;
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                _ID_VTHH = Convert.ToInt32(row["ID_VTHH"].ToString());
                _TenVTHH = row["TenVTHH"].ToString();
                _DonViTinh = row["DonViTinh"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
