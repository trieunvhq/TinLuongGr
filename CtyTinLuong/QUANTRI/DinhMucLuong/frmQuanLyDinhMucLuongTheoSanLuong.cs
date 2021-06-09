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
    public partial class frmQuanLyDinhMucLuongTheoSanLuong : Form
    {
        public static bool mb_TheMoi_DinhMucLuongSanLuong;
        public static string msTenDinhMucLuongSanLuong;
        public static int miID_Sua_DinhMucLuongTheoSanLuong, miiiID_VTHH;
        private void HienThi()
        {
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dt = cls.SelectAll();

            if (checked_ALL.Checked == true)
            {
                dt.DefaultView.RowFilter = " TonTai= True";
            }
            else
            {
                if (checkTheoDoi.Checked == true)
                {
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";

                }
                else
                {
                    dt.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=true";

                }

            }
            DataView dv = dt.DefaultView;
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }
        public frmQuanLyDinhMucLuongTheoSanLuong()
        {
            InitializeComponent();
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

        private void frmQuanLyDinhMucLuongTheoSanLuong_Load(object sender, EventArgs e)
        {
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            mb_TheMoi_DinhMucLuongSanLuong = false;
            HienThi();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString()) != 1)
                {
                    clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                    cls.iID_DinhMuc_Luong_SanLuong = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString());
                    cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                    cls.Update_NgungTheoDoi();
                }

            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString()) == 1)
                    {
                        MessageBox.Show("Không xóa ĐM chuẩn Không");
                    }
                    else
                    {
                        clsDinhMuc_DinhMuc_Luong_TheoSanLuong cls1 = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                        cls1.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString());
                        cls1.Delete_W_TonTai();
                        MessageBox.Show("Đã xóa");
                        HienThi();
                    }
                        
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString()) != 1)
                {
                    miID_Sua_DinhMucLuongTheoSanLuong = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_DinhMuc_Luong_SanLuong).ToString());
                    msTenDinhMucLuongSanLuong = gridView1.GetFocusedRowCellValue(clMaDinhMuc).ToString();
                    mb_TheMoi_DinhMucLuongSanLuong = false;
                    miiiID_VTHH = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                    frmChiTietDinhMucLuongTheoSanLuong ff = new frmChiTietDinhMucLuongTheoSanLuong();
                    ff.Show();
                }
                else
                {
                    MessageBox.Show("Định mức chuẩn 0\n không cho sửa");
                }

            }
            catch
            {

            }
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
            mb_TheMoi_DinhMucLuongSanLuong = true;
            frmChiTietDinhMucLuongTheoSanLuong ff = new frmChiTietDinhMucLuongTheoSanLuong();
            ff.Show();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmQuanLyDinhMucLuongTheoSanLuong_Load(sender, e);
        }
    }
}
