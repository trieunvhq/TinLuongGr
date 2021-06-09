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
            if (!KiemTraLuu()) return;
            else
            {
                clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan();
                cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                if (dteNgayLap.Text.ToString() != "")
                    cls1.daNgayLap = dteNgayLap.DateTime;
                else cls1.daNgayLap = DateTime.Today;

                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.Insert();

                int iiiID_DinhMuc_ToGapDan = cls1.iID_DinhMuc_ToGapDan.Value;
                // insert thành phẩm
              
                clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                cls2.iID_DinhMuc_ToGapDan = iiiID_DinhMuc_ToGapDan;
                cls2.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                cls2.fSoLuong = 1;
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bCheck_ThanhPham = true;
                cls2.bCheck_VatTu_Chinh = false;
                cls2.bCheck_VatTu_Phu = false;
                cls2.Insert();
                //insert vật tư chính
                cls2.iID_DinhMuc_ToGapDan = iiiID_DinhMuc_ToGapDan;
                cls2.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                cls2.fSoLuong = Convert.ToDouble(txtSoLuongVTChinh.Text.ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bCheck_ThanhPham = false;
                cls2.bCheck_VatTu_Chinh = true;
                cls2.bCheck_VatTu_Phu = false;
                cls2.Insert();


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
                        cls2.fSoLuong = Convert.ToDouble(dv3.Rows[i]["SoLuong"].ToString());
                    else cls2.fSoLuong = 0;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bCheck_ThanhPham = false;
                    cls2.bCheck_VatTu_Chinh = false;
                    cls2.bCheck_VatTu_Phu = true;
                    cls2.Insert();
                }
                MessageBox.Show("Đã lưu");
                this.Close();

            }
        }

        private void Luu_Sua__DM_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan();
                cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                if (dteNgayLap.Text.ToString() != "")
                    cls1.daNgayLap = dteNgayLap.DateTime;
                else cls1.daNgayLap = DateTime.Today;

                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.iID_DinhMuc_ToGapDan = UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
                cls1.Update();

                // XÓa trước
                clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                cls2.iID_DinhMuc_ToGapDan = UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
                cls2.Delete_ALL_W_ID_DinhMuc_ToGapDan();

                // insert thành phẩm
                
                cls2.iID_DinhMuc_ToGapDan = UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
                cls2.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                cls2.fSoLuong = 1;
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bCheck_ThanhPham = true;
                cls2.bCheck_VatTu_Chinh = false;
                cls2.bCheck_VatTu_Phu = false;
                cls2.Insert();
                //insert vật tư chính
                cls2.iID_DinhMuc_ToGapDan = UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
                cls2.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                cls2.fSoLuong = Convert.ToDouble(txtSoLuongVTChinh.Text.ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.bCheck_ThanhPham = false;
                cls2.bCheck_VatTu_Chinh = true;
                cls2.bCheck_VatTu_Phu = false;
                cls2.Insert();

                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();

                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    cls2.iID_DinhMuc_ToGapDan = UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan; ;
                    cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                    if (dv3.Rows[i]["SoLuong"].ToString() != "")
                        cls2.fSoLuong = Convert.ToDouble(dv3.Rows[i]["SoLuong"].ToString());
                    else cls2.fSoLuong = 0;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.bCheck_ThanhPham = false;
                    cls2.bCheck_VatTu_Chinh = false;
                    cls2.bCheck_VatTu_Phu = true;
                    cls2.Insert();
                }
                MessageBox.Show("Đã lưu");
                this.Close();

            }
        }

        private void HienThi_ThemMoi_DinhMuc_NPL()
        {
            dteNgayLap.EditValue = DateTime.Today;

        }

        private void HienThi_Sua_DinhMuc_NPL()
        {
            clsDinhMuc_DinhMuc_ToGapDan cls1 = new clsDinhMuc_DinhMuc_ToGapDan();
            cls1.iID_DinhMuc_ToGapDan =  UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
            DataTable dt = cls1.SelectOne();
            txtMaDinhMucNPL.Text = cls1.sMaDinhMuc.Value.ToString();
            dteNgayLap.EditValue = cls1.daNgayLap.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            

            clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls2 = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
            cls2.iID_DinhMuc_ToGapDan= UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
            DataTable dt322 = cls2.SelectAll_W_ID_DinhMuc_ToGapDan();
            DataTable dt422 = dt322.Copy();
            dt322.DefaultView.RowFilter = " Check_ThanhPham = True";
            DataView dv1 = dt322.DefaultView;
            DataTable dt22 = dv1.ToTable();
            gridMaTPQuyDoi.EditValue = Convert.ToInt32(dt22.Rows[0]["ID_VTHH"].ToString());

            dt422.DefaultView.RowFilter = " Check_VatTu_Chinh = True";
            DataView dv2 = dt422.DefaultView;
            DataTable dt223 = dv2.ToTable();
            gridMaVTchinh1.EditValue = Convert.ToInt32(dt223.Rows[0]["ID_VTHH"].ToString());
            txtSoLuongVTChinh.Text= dt223.Rows[0]["SoLuong"].ToString();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTiet_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("ID_DinhMuc_ToGapDan", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("MaVT");// 
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("Check_VatTu_Phu", typeof(bool));
            //Check_VatTu_Phu


            cls2.iID_DinhMuc_ToGapDan =  UCSanXuat_DinhMuc_ToGapDan.miID_DinhMuc_ToGapDan;
            DataTable dtxxx = cls2.SelectAll_W_ID_DinhMuc_ToGapDan();
            Double ddsoluong;
            dtxxx.DefaultView.RowFilter = "TonTai=True and Check_VatTu_Phu=True";
            DataView dv = dtxxx.DefaultView;
            DataTable dt3 = dv.ToTable();

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                if (dt3.Rows[i]["SoLuong"].ToString() == "")
                    ddsoluong = 0;
                else ddsoluong = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTiet_DinhMuc_ToGapDan"] = Convert.ToInt16(dt3.Rows[i]["ID_ChiTiet_DinhMuc_ToGapDan"].ToString());
                _ravi["ID_DinhMuc_ToGapDan"] = Convert.ToInt16(dt3.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                _ravi["ID_VTHH"] = Convert.ToInt16(dt3.Rows[i]["ID_VTHH"].ToString());
                int ID_VTHHxxxx= Convert.ToInt16(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa clsvth = new clsTbVatTuHangHoa();
                clsvth.iID_VTHH = ID_VTHHxxxx;
                DataTable dtvthh = clsvth.SelectOne();
                _ravi["SoLuong"] = ddsoluong;
                _ravi["MaVT"] = ID_VTHHxxxx;
                _ravi["TenVTHH"] = clsvth.sTenVTHH.Value;
                _ravi["DonViTinh"] = clsvth.sDonViTinh.Value;
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;

        }

        private bool KiemTraLuu()
        {
            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();

            if (txtMaDinhMucNPL.ToString() == "")
            {
                MessageBox.Show("Chưa có mã Thành phẩm quy đổi");
                return false;
            }
            else if (gridMaTPQuyDoi.EditValue == null)
            {
                MessageBox.Show("Chưa chọn Bán thành phẩm quy đổi ");
                return false;
            }
            else if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else return true;

        }
        public frmDinhMuc_ChiTietDinhMucToGapDan()
        {
            InitializeComponent();
        }

        private void frmDinhMuc_ChiTietDinhMucToGapDan_Load(object sender, EventArgs e)
        {
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
            
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            gridMaTPQuyDoi.Properties.DataSource = dtxx2;
            gridMaTPQuyDoi.Properties.ValueMember = "ID_VTHH";
            gridMaTPQuyDoi.Properties.DisplayMember = "MaVT";
            //
            gridMaVTchinh1.Properties.DataSource = dtxx2;
            gridMaVTchinh1.Properties.ValueMember = "ID_VTHH";
            gridMaVTchinh1.Properties.DisplayMember = "MaVT";

            repositoryItemLookUpEdit2.DataSource = dtxx2;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";

            if (UCSanXuat_DinhMuc_ToGapDan.mb_TheMoi_DinhMuc_ToGapDan == true)
                HienThi_ThemMoi_DinhMuc_NPL();
            else HienThi_Sua_DinhMuc_NPL();
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
            if (UCSanXuat_DinhMuc_ToGapDan.mb_TheMoi_DinhMuc_ToGapDan == true)
                Luu_ThemMoi_DM_NPL();
            else Luu_Sua__DM_NPL();
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
            catch
            {

            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView1.SetRowCellValue(e.RowHandle, clCheck_VatTu_Phu, true);

                }
            }

            //if (e.Column == clMaVT)
            //{
            //    gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, iID_VTHH);
            //    gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, sTenVTHH);
            //    gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, sDonViTinh);

            //    gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
            //    string shienthixx = "1";
            //    gridView1.SetRowCellValue(e.RowHandle, clHienThi, shienthixx);

            //}
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
            catch
            {

            }
        }
    }
}
