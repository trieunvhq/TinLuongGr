using DevExpress.XtraEditors;
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
    public partial class BoSungCongNhanMayDot : Form
    {
        int iiID_sophieu_, iiCaTruong_;
        string casx_;
        DateTime ngaysx_;
        private void LuuDuLieu_BoSungCongNhan()
        {
            try
            {
                DataTable dv3 = (DataTable)gridControl1.DataSource;

                if (dv3.Rows.Count > 0)
                {
                    clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls1 = new CtyTinLuong.clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot();
                    cls1.iID_SoPhieu = iiID_sophieu_;
                    cls1.bGuiDuLieu = false;
                    cls1.Update_ALL_GuiDuLieu_W_ID_SoPhieu();
                    DataTable dt2_cu = cls1.SelectAll_W_ID_SoPhieu();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls1.iID_SoPhieu = iiID_sophieu_;
                        cls1.iID_CongNhan = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
                        int iID_CongNhanxxxx = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
                        cls1.iID_CaTruong = iiCaTruong_;
                        cls1.daNgaySanXuat = ngaysx_;
                        cls1.sCaSanXuat = casx_;
                        cls1.bGuiDuLieu = true;
                        cls1.bCheck_MayDot_True_May_Cat_False = true;

                        string expressionnhapkho;
                        expressionnhapkho = "ID_CongNhan=" + iID_CongNhanxxxx + "";
                        DataRow[] foundRows;
                        foundRows = dt2_cu.Select(expressionnhapkho);
                        if (foundRows.Length > 0)
                        {
                            cls1.iID_ChiTietPhieu_BoSungMayDot = Convert.ToInt32(foundRows[0]["ID_ChiTietPhieu_BoSungMayDot"].ToString());
                            cls1.Update();
                        }
                        else
                        {
                            cls1.Insert();
                        }

                    }
                    // xoa ton tai=false
                    clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls2 = new clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot();
                    DataTable dt2_moi11111 = new DataTable();
                    cls2.iID_SoPhieu = iiID_sophieu_;
                    dt2_moi11111 = cls2.SelectAll_W_ID_SoPhieu();
                    dt2_moi11111.DefaultView.RowFilter = "GuiDuLieu = False";
                    DataView dvdt2_moi = dt2_moi11111.DefaultView;
                    DataTable dt2_moi = dvdt2_moi.ToTable();
                    for (int i = 0; i < dt2_moi.Rows.Count; i++)
                    {
                        int ID_ChiTietPhieu_BoSungMayDotcccxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietPhieu_BoSungMayDot"].ToString());
                        cls2.iID_ChiTietPhieu_BoSungMayDot = ID_ChiTietPhieu_BoSungMayDotcccxxx;
                        cls2.Delete();
                    }
                    MessageBox.Show("Đã lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_DaTa(int xxxiiID_Sophieu_)
        {
            try
            {
                using (clsThin clsNguoi = new clsThin())
                {
                    DataTable dt = clsNguoi.T_NhanSu_SF("11");
                    gridMaCongNhan.DataSource = dt;
                    gridMaCongNhan.ValueMember = "ID_NhanSu";
                    gridMaCongNhan.DisplayMember = "MaNhanVien";
                }
                using (clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot cls = new CtyTinLuong.clsPhieu_ChiTietPhieu_New_BoSungCongNhan_MayDot())
                {
                    DataTable dt2 = new DataTable();
                    cls.iID_SoPhieu = xxxiiID_Sophieu_;
                    dt2 = cls.SelectAll_W_ID_SoPhieu();
                    gridControl1.DataSource = dt2;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public BoSungCongNhanMayDot(int idsophieu, int idcatruongxx, string scasxxx, DateTime dangaysxx)
        {
            InitializeComponent();
            iiID_sophieu_ = idsophieu;
            iiCaTruong_ = idcatruongxx;
            casx_ = scasxxx;
            ngaysx_ = dangaysxx;
        }

        private void btChiLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu_BoSungCongNhan();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string tennhanvien_;
        private void gridMaCongNhan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
                tennhanvien_ = row["TenNhanVien"].ToString();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại trường mã công nhân! " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clID_CongNhan)
            {
                gridView1.SetRowCellValue(e.RowHandle, clTenNhanVien, tennhanvien_);
            }
        }

        private void gridView1_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void BoSungCongNhanMayDot_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_DaTa(iiID_sophieu_);         
           
            Cursor.Current = Cursors.Default;
        }
    }
}
