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
    public partial class Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ : Form
    {
        private int _thang, _nam, _id_bophan;
        private bool isload = true;

        private bool KiemTraLuu()
        {

            DataTable dv3 = (DataTable)gridControl1.DataSource;

            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtThang.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn tháng ");
                return false;
            }
            else if (txtNam.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn năm ");
                return false;
            }

            else return true;
        }


        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls1 = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
                cls1.iThang = Convert.ToInt32(txtThang.Text.ToString());
                cls1.iNam = Convert.ToInt32(txtNam.Text.ToString());
                // xoá trước
                cls1.Tr_CaiMacDinhMaHang_TDB_delete_thang_nam();
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();

                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    if (checkIDVTHH(Convert.ToInt32(dv3.Rows[i]["ID_VTHH"].ToString())))
                    {
                        cls1.iID_VTHH = Convert.ToInt32(dv3.Rows[i]["ID_VTHH"].ToString());
                        cls1.iThang = Convert.ToInt32(txtThang.Text.ToString());
                        cls1.iNam = Convert.ToInt32(txtNam.Text.ToString());
                        cls1.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(dv3.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString());
                        cls1.Tr_CaiMacDinhMaHang_TDB_Insert();
                    }
                }
                MessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void HienThi_themMoi()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            dt2.Columns.Add("id_bophan");
            dt2.Columns.Add("TenBoPhan");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("NgungTheoDoi", typeof(bool));
            gridControl1.DataSource = dt2;
        }
        private void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            dt2.Columns.Add("id_bophan");
            dt2.Columns.Add("TenBoPhan");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("NgungTheoDoi", typeof(bool));

            clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK();
            DataTable dt3 = cls.Tr_MaHangToGD_DB_DK_SelectBoPhan(_thang, _nam, _id_bophan);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_MaHangToGD_DB_DK"] = Convert.ToInt32(dt3.Rows[i]["ID_MaHangToGD_DB_DK"].ToString());
                _ravi["id_bophan"] = Convert.ToInt32(dt3.Rows[i]["id_bophan"].ToString());
                _ravi["TenBoPhan"] = dt3.Rows[i]["TenBoPhan"].ToString();
                _ravi["ID_VTHH"] = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                _ravi["Thang"] = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                _ravi["Nam"] = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                _ravi["NgungTheoDoi"] = Convert.ToBoolean(dt3.Rows[i]["NgungTheoDoi"].ToString());
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;
            isload = false;
        }

        public Tr_frmCaiMacDinnhMaHangTGD_DB_DK_()
        {
            InitializeComponent();

            _thang = DateTime.Now.Month;
            _nam = DateTime.Now.Year;
            txtNam.Text = _nam.ToString();
            txtThang.Text = _thang.ToString();

            _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
            if (_id_bophan == 0) return;
            radioGapDan.Checked = true;
        }

        private void Tr_frmCaiMacDinnhMaHangTGD_DB_DK__Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

            //clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            //DataTable dtdm = clsdm.SelectAll();
            //dtdm.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            //DataView dvdm = dtdm.DefaultView;
            //DataTable newdtdm = dvdm.ToTable();

            //repositoryItemGridLookUpEdit2.DataSource = newdtdm;
            //repositoryItemGridLookUpEdit2.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            //repositoryItemGridLookUpEdit2.DisplayMember = "MaDinhMuc";


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHangToGD_DB_DK", typeof(int));
            dt2.Columns.Add("id_bophan");
            dt2.Columns.Add("TenBoPhan");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("NgungTheoDoi", typeof(bool));
            gridControl1.DataSource = dt2;

            //DateTime ngayhomnay = DateTime.Today;
            //int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            //int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            //txtNam.Text = nam.ToString();
            //txtThang.Text = thang.ToString();
            Cursor.Current = Cursors.Default;
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            //gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
        }

        private int _idVTHH = 0;

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    //gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    _idVTHH = Convert.ToInt32(dt.Rows[0]["ID_VTHH"].ToString());
                }
            }

            if (e.Column == DonGia)
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsdm.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dtdm = clsdm.SelectOne();
               
                int kkxxx = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
               
                if (dtdm != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, id_bophan, kkxxx);
                    gridView4.SetRowCellValue(e.RowHandle, TenBoPhan, dtdm.Rows[0]["DinhMuc_KhongTang"].ToString());
                    //gridView4.SetRowCellValue(e.RowHandle, clDinhMuc_Tang, dtdm.Rows[0]["DinhMuc_Tang"].ToString());
                    //gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                }
            }
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //GridView view = sender as GridView;
            //DataView dv = view.DataSource as DataView;
            //if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            //{
            //    e.Visible = false;
            //    e.Handled = true;
            //}
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            //if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            //{
            //    clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
            //    cls.iThang = Convert.ToInt32(txtThang.Text.ToString());
            //    cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
            //    DataTable dt3 = cls.Tr_CaiMacDinhMaHang_TDB_SelectAll_thang_nam();
            //    if (dt3.Rows.Count == 0)
            //        HienThi_themMoi();
            //    else
            //        LoadData();
            //}
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        //Kiểm tra idvthh trong tháng đã tồn tại chưa:
        private bool checkIDVTHH(int IdVthh)
        {
            using (clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh())
            {
                int thang = Convert.ToInt32(txtThang.Value);
                int nam = Convert.ToInt32(txtNam.Value);
                cls.iThang = thang;
                cls.iNam = nam;
                DataTable dt3 = cls.Tr_CaiMacDinhMaHang_TDB_SelectAll_thang_nam();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (IdVthh == Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString())
                        && thang == Convert.ToInt32(dt3.Rows[i]["Thang"].ToString())
                        && nam == Convert.ToInt32(dt3.Rows[i]["Nam"].ToString()))
                    {
                        return false;
                    }
                }
            }

                return true;
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);
                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioGapDan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGapDan.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ Gấp dán");
                if (_id_bophan == 0) return;
            }
        }

        private void radioDongBao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDongBao.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ đóng bao"); 
                if (_id_bophan == 0) return;
            }
        }

        private void radioDongKien_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDongBao.Checked)
            {
                _id_bophan = KiemTraTenBoPhan("Tổ đóng kiện");
                if (_id_bophan == 0) return;
            }
        }

        private void gridView4_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["STT"], view.RowCount.ToString());
            view.SetRowCellValue(e.RowHandle, view.Columns["ID_MaHangToGD_DB_DK"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["DonGia"], 0);
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
