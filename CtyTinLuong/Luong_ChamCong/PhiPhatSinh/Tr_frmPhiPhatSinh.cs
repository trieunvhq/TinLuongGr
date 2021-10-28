

using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmPhiPhatSinh : UserControl
    {
        public static string _TenPhi, _DienGiai, _MaNhanVien = "";
        public static int _ID_BoPhan, _ID_PhiPhatSinh;
        public static double _TienCong, _TienTru;
        public static bool _CaLamViec, _mb_TheMoi;
        public static int _nam, _thang;

        private DataTable _data;
        private bool isload = true;

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public Tr_frmPhiPhatSinh(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _ID_BoPhan = id_bophan;
            InitializeComponent();

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);

            radioTo1.Checked = true;
        }

        public void LoadData(bool islandau, bool toDot_type)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();

                using (clsThin clsThin_ = new clsThin())
                {
                    DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SA();

                    cbBoPhan.DataSource = dt_;
                    cbBoPhan.DisplayMember = "TenBoPhan";
                    cbBoPhan.ValueMember = "ID_BoPhan";
                    cbBoPhan.SelectedValue = 0;
                    cbBoPhan.Enabled = true;
                    try
                    {
                        _ID_BoPhan = (int)cbBoPhan.SelectedValue;
                    }
                    catch { }
                }
            }
            else
            {
            }

           

            using (clsTr_PhiPhatSinh cls = new clsTr_PhiPhatSinh())
            {
                _data = cls.Tr_PhiPhatSinh_S(_thang, _nam, _ID_BoPhan, toDot_type);
            }

            gridControl1.DataSource = _data;
            isload = false;
        }


        private void Tr_frmPhiPhatSinh_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }


        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhThang();
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhThang();
        }
        private void HoanThanhThang()
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);

                LoadData(false, radioTo1.Checked);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HoanThanhNam()
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);

                LoadData(false, radioTo1.Checked);
            }
            catch
            {
                MessageBox.Show("Năm không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "Tr_frmPhiPhatSinh", this);
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  STT)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    string ten = View.GetRowCellValue(e.RowHandle, View.Columns["TenNhanVien"]).ToString();
            //    if (ten == "Tổng" || ten == "Tổng tiền" || ten == "Tổng")
            //    {
            //        e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //    }
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _ID_PhiPhatSinh = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_PhiPhatSinh).ToString());
                _ID_BoPhan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_BoPhan).ToString());
                _TienCong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(TienCong).ToString());
                _TienTru = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(TienTru).ToString());
                _TenPhi = gridView1.GetFocusedRowCellValue(TenPhi).ToString();
                _DienGiai = gridView1.GetFocusedRowCellValue(DienGiai).ToString();
                _CaLamViec = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(CaLamViec).ToString());
                _mb_TheMoi = false;
                Tr_frmChiTiet_PhiPhatSinh ff = new Tr_frmChiTiet_PhiPhatSinh(this);
                ff.Show();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            _mb_TheMoi = true;
            Tr_frmChiTiet_PhiPhatSinh ff = new Tr_frmChiTiet_PhiPhatSinh(this);
            ff.Show();
        }

        private void cbBoPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isload)
                return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (cbBoPhan.SelectedValue != null)
                {
                    _ID_BoPhan = (int)cbBoPhan.SelectedValue;
                    LoadData(false, radioTo1.Checked);
                }
            }
            catch (Exception tr)
            {
                MessageBox.Show("Error: " + tr.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == STT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void radioTo1_CheckedChanged(object sender, EventArgs e)
        {
            _CaLamViec = true;
            if (isload)
                return;
            LoadData(false, radioTo1.Checked);
        }

        private void radioTo2_CheckedChanged(object sender, EventArgs e)
        {
            _CaLamViec = false;
            if (isload)
                return;
            LoadData(false, radioTo1.Checked);
        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa công nhân khỏi bảng..." +ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                if (e.Column.FieldName == "Xoa")
                {
                    e.RepositoryItem = emptyEditor;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}

