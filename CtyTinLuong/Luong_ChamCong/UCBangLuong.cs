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
    public partial class UCBangLuong : UserControl
    {
        public static int mID_iD_ChamCong, miiThang, miiNam;
        public static bool mb_ThemMoi_ChamCong;
        private void HienThi()
        {
            

            clsHuu_CongNhat cls = new CtyTinLuong.clsHuu_CongNhat();
            DataTable dt = cls.SelectAll();
            DataView dv = dt.DefaultView;
            dv.Sort = "Nam DESC , Thang DESC";
            DataTable dxxxx = dv.ToTable();         

            gridControl1.DataSource = dxxxx;
        }


        public UCBangLuong()
        {
            InitializeComponent();
        }

        private void UCBangLuong_Load(object sender, EventArgs e)
        {
            clNgungTheoDoi.Caption = "Bỏ\ntheo dõi";
            HienThi();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mb_ThemMoi_ChamCong = true;
            SanXuat_frmDanhSachChamCong ff = new SanXuat_frmDanhSachChamCong();
            ff.Show();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCBangLuong_Load( sender,  e);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_ChamCong).ToString() != "")
                {
                    mb_ThemMoi_ChamCong = false;
                    mID_iD_ChamCong = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_ChamCong).ToString());

                    miiThang = Convert.ToInt32(gridView1.GetFocusedRowCellValue(Thang).ToString());
                    miiNam = Convert.ToInt32(gridView1.GetFocusedRowCellValue(Nam).ToString());
                    frmBangChamCongTrongThang ff = new frmBangChamCongTrongThang();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void btXoaALL_Click(object sender, EventArgs e)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            //cls.HUU_DELETE_HUU_Huu_CongNhat_MaHang_ToGapDan();
            //cls.HUU_DELETE_HUU_BangLuong();
            //cls.HUU_DELETE_Huu_CongNhat();
            //cls.HUU_DELETE_HUU_CongNhat_ChiTiet_ChamCong();
            //cls.HUU_DELETE_HUU_CongNhat_TamUng();
            //cls.HUU_DELETE_HUU_CongNhat_TraLuong();
            MessageBox.Show("Da xoá");
        }
    }
}
