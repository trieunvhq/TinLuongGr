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
    public partial class frmCaiMacDinnhMaHangToGapDan : Form
    {
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
                cls1.Delete_ALL_WW_Thang_WW_Nam();
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();

                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    cls1.iID_VTHH = Convert.ToInt32(dv3.Rows[i]["ID_VTHH"].ToString());
                    cls1.iThang = Convert.ToInt32(txtThang.Text.ToString());
                    cls1.iNam = Convert.ToInt32(txtNam.Text.ToString());
                    cls1.iID_DinhMuc_Luong_SanLuong= Convert.ToInt32(dv3.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString());
                    cls1.Insert();
                }
                MessageBox.Show("Đã lưu");
                this.Close();
            }
        }
        private void HienThi_themMoi()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHang_ToGapDan", typeof(int));           
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));           
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ID_DinhMuc_Luong_SanLuong");
            dt2.Columns.Add("MaDinhMuc");
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DinhMuc_KhongTang", typeof(double));
            dt2.Columns.Add("DinhMuc_Tang", typeof(double));
            gridControl1.DataSource = dt2;
        }
        private void HienThi_Sua()
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHang_ToGapDan", typeof(int));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ID_DinhMuc_Luong_SanLuong");
            dt2.Columns.Add("MaDinhMuc");
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DinhMuc_KhongTang", typeof(double));
            dt2.Columns.Add("DinhMuc_Tang", typeof(double));

            clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
            cls.iThang = Convert.ToInt32(txtThang.Text.ToString());
            cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
            DataTable dt3 = cls.SelectAll_WW_Thang_WW_Nam();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_MaHang_ToGapDan"] = Convert.ToInt32(dt3.Rows[i]["ID_MaHang_ToGapDan"].ToString());
                _ravi["ID_VTHH"] = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                _ravi["Thang"] = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                _ravi["Nam"] = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());
               
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["HienThi"] = "1";
                _ravi["ID_DinhMuc_Luong_SanLuong"] = Convert.ToDouble(dt3.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString());
                _ravi["MaDinhMuc"] = dt3.Rows[i]["ID_DinhMuc_Luong_SanLuong"].ToString();
                //_ravi["MaDinhMuc"] = dt3.Rows[i]["MaDinhMuc"].ToString();
                _ravi["DinhMuc_KhongTang"] = Convert.ToDouble(dt3.Rows[i]["DinhMuc_KhongTang"].ToString());
                _ravi["DinhMuc_Tang"] = Convert.ToDouble(dt3.Rows[i]["DinhMuc_Tang"].ToString());
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;

        }
        public frmCaiMacDinnhMaHangToGapDan()
        {
            InitializeComponent();
        }

        private void frmCaiMacDinnhMaHangToGapDan_Load(object sender, EventArgs e)
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dtdm = clsdm.SelectAll();
            dtdm.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvdm = dtdm.DefaultView;
            DataTable newdtdm = dvdm.ToTable();

            repositoryItemGridLookUpEdit2.DataSource = newdtdm;
            repositoryItemGridLookUpEdit2.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            repositoryItemGridLookUpEdit2.DisplayMember = "MaDinhMuc";


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MaHang_ToGapDan", typeof(int));
            dt2.Columns.Add("ID_ChamCong", typeof(int));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("DaCaiDat", typeof(bool));
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ID_DinhMuc_Luong_SanLuong");
            dt2.Columns.Add("MaDinhMuc");
            dt2.Columns.Add("DinhMuc_KhongTang", typeof(double));
            dt2.Columns.Add("DinhMuc_Tang", typeof(double));
            gridControl1.DataSource = dt2;

            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            txtNam.Text = nam.ToString();
            txtThang.Text = thang.ToString();
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
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
        }

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
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                }
            }

            if (e.Column == clMaDinhMuc)
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsdm.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dtdm = clsdm.SelectOne();
               
                int kkxxx = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
               
                if (dtdm != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, clID_DinhMuc_Luong_SanLuong, kkxxx);
                    gridView4.SetRowCellValue(e.RowHandle, clDinhMuc_KhongTang, dtdm.Rows[0]["DinhMuc_KhongTang"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clDinhMuc_Tang, dtdm.Rows[0]["DinhMuc_Tang"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                }
            }
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh cls = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
                cls.iThang = Convert.ToInt32(txtThang.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                DataTable dt3 = cls.SelectAll_WW_Thang_WW_Nam();
                if (dt3.Rows.Count == 0)
                    HienThi_themMoi();
                else
                    HienThi_Sua();
            }
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }
    }
}
