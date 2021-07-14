using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class ucDinhMucNGuyenPhuLieu : UserControl
    {
        public static bool mb_TheMoi_DinhMuc_NPL;
  
        public static int miID_DinhMuc_NPL;
        private void HienThi()
        {
            clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
            DataTable dt = cls.SelectAll();
            if (checked_ALL.Checked == true)
            {

                dt.DefaultView.RowFilter = "TonTai=True";
                DataView dv = dt.DefaultView;
                gridControl1.DataSource = dv;
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;
                }
                else
                {
                    dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=True";
                    DataView dv = dt.DefaultView;
                    gridControl1.DataSource = dv;

                }


            }
        }

        SanXuat_frmQuanLySanXuat _frmQLSX;

        public ucDinhMucNGuyenPhuLieu(SanXuat_frmQuanLySanXuat frmQLSX = null)
        {
            _frmQLSX = frmQLSX;
            InitializeComponent();
        }

        private void ucDinhMucNGuyenPhuLieu_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            clBooL_NguyenPhuLieu.Caption = "Vật tư\nphụ";
      
            clNgungTheoDoi.Caption = "Ngừng\ntheo dõi";
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.VisibleIndex = 4;
            HienThi();

            Cursor.Current = Cursors.Default;
        }

        private void checked_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_ALL.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checkTheoDoi.Checked = false;
            }
            HienThi();
        }

        private void checkTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTheoDoi.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void checkNgungTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNgungTheoDoi.Checked == true)
            {
                checkTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls.iID_DinhMuc_NPL = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString() != "")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    miID_DinhMuc_NPL = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());                   
                    mb_TheMoi_DinhMuc_NPL = false;
                    frmChiTietDinhMucNPL ff = new frmChiTietDinhMucNPL(this);
                    //_frmQLSX.Hide();
                    ff.Show();
                    //_frmQLSX.Show();
                    Cursor.Current = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                cls1.iID_DinhMuc_NPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                cls1.Delete();

                MessageBox.Show("Đã xóa");
                HienThi();
                Cursor.Current = Cursors.Default;
            }
        }
        DataTable _dt2;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int iIiID_DinhMucNPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_NPL).ToString());
                clsDinhMuc_ChiTiet_DM_NPL cls = new clsDinhMuc_ChiTiet_DM_NPL();
                cls.iID_DinhMuc_NPL = iIiID_DinhMucNPL;
                DataTable dt = cls.SelectAll_HienThi_ChiTietDinhMuc();


                dt.DefaultView.RowFilter = "TonTai=True";
                DataView dv = dt.DefaultView;
                _dt2 = dv.ToTable();

                gridControl2.DataSource = _dt2;
            }
            catch
            {

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ucDinhMucNGuyenPhuLieu_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_DinhMuc_NPL = true;
            frmChiTietDinhMucNPL ff = new frmChiTietDinhMucNPL(this);
            //_frmQLSX.Hide();
            ff.Show();
            //_frmQLSX.Show();
            Cursor.Current = Cursors.Default;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column==clStrSoLuong2)
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
                    _dt2.Rows[index_][name_] = str_;
                    if (isthaydoi_)
                    {
                        gridControl2.DataSource = null;
                        gridControl2.DataSource = _dt2;
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
}
