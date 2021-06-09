using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace CtyTinLuong
{
    public partial class UCMuaHang : UserControl
    {
        public static bool mbbTheMoi_DonHang,mbCopY;
        public static int miiiID_Sua_DonHang;      
        private void HienThiGridControl_2(int xxiDmuahang)
        {
            clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
            cls2.iID_MuaHang = xxiDmuahang;
            DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietMuaHang"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_MuaHang");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuong"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietMuaHang"] = dt3.Rows[i]["ID_ChiTietMuaHang"].ToString();
                _ravi["ID_MuaHang"] = dt3.Rows[i]["ID_MuaHang"].ToString();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }
        private void HienThi_ALL(bool bxxTranLaiHangMua)
        {

            clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
            DataTable dt = cls.SelectAll_HienThi_GridConTrol();
            if (bxxTranLaiHangMua == true)
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and CheckTraLaiNhaCungCap = True";
            else dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and CheckTraLaiNhaCungCap = False";
            DataView dv = dt.DefaultView;
            dv.Sort = " GuiDuLieu ASC, NgayChungTu DESC, ID_MuaHang DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }
        private void HienThi(bool bxxTranLaiHangMua)
        {
            if (dteTuNgay.EditValue != null & dteNgay.EditValue != null)
            {
                DateTime denngay = dteNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;

                clsMH_tbMuaHang cls = new clsMH_tbMuaHang();
                DataTable dt = cls.SelectAll_HienThi_GridConTrol();
                if (bxxTranLaiHangMua == true)
                    dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'and CheckTraLaiNhaCungCap = True";
                else dt.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'and CheckTraLaiNhaCungCap = False";
              
                DataView dv = dt.DefaultView;
                DataTable dt22 = dv.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = " GuiDuLieu ASC, NgayChungTu DESC, ID_MuaHang DESC";
                DataTable dxxxx = dv2.ToTable();
                gridControl1.DataSource = dxxxx;
            }

        }
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            gridMaVT.DataSource = newdtvthh;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";


        }
        public UCMuaHang()
        {
            InitializeComponent();
        }
        
        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCMuaHang_Load(sender, e);
        }

        private void UCMuaHang_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            if(frmMuaHang2222.mbTraLaiHangMua==true)
            HienThi_ALL(true);
            else HienThi_ALL(false);

            mbbTheMoi_DonHang = false;
          
            clKhongNhapKho.Caption = "Mua hàng\n nhập kho";
            //clSoTienDaThanhToan.Caption = "Đã\nthanh toán";
            clTongTienHang.Caption = "Tổng\ntiền hàng";
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            clGuiDuLieu.Caption = "Đã \nGửi DL";
           
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbbTheMoi_DonHang = true;
            mbCopY = true;
            frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333();         
            ff.Show();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {//msDienGiai
                    mbCopY = false;
                    mbbTheMoi_DonHang = false;
                    miiiID_Sua_DonHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());                  
                    frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                   
                }
            }
           
        }

        private void btXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            clsMH_tbMuaHang cls1 = new clsMH_tbMuaHang();           
            cls1.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
            DataTable dt1 = cls1.SelectOne();
            if (cls1.bTrangThaiNhapKho.Value == true)
            {
                MessageBox.Show("Đã nhập kho, không thể xoá");
                return;
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    cls1.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    cls1.Delete();
                    clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
                    cls2.iID_MuaHang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    cls2.Delete_W_ID_MuaHang();
                    MessageBox.Show("Đã xóa");
                    if (frmMuaHang2222.mbTraLaiHangMua == true)
                        HienThi(true);
                    else HienThi(false);
                }
            }
                

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                if (frmMuaHang2222.mbTraLaiHangMua == true)
                    HienThi(true);
                else HienThi(false);
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
            {
                int iDImuahang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                HienThiGridControl_2(iDImuahang);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void btCopy_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString() != "")
                {//msDienGiai
                    mbCopY = true;
                    mbbTheMoi_DonHang = false;
                    miiiID_Sua_DonHang = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_MuaHang).ToString());
                    frmChiTietMuaHang3333333333 ff = new frmChiTietMuaHang3333333333();
                    ff.Show();
                }
            }
            catch
            {

            }
        }
    }
}
