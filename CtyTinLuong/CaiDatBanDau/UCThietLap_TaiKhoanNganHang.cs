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
    public partial class UCThietLap_TaiKhoanNganHang : UserControl
    {
        public static DataTable mdatatabletbTaiKhoanKeToan;
        private void LuuDuLieu_ChiLuu()
        {
            DataTable dv3 = (DataTable)gridControl1.DataSource;
            clsNganHang_SoDuBanDau_TaiKhoanKeToan cls2 = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();
            for (int i = 0; i < dv3.Rows.Count; i++)
            {
                cls2.iID_TaiKhoanKeToanCon = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                cls2.iID_TaiKhoanKeToanMe = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                cls2.fCoKhong = Convert.ToDouble(dv3.Rows[i]["CoKhong"].ToString());
                cls2.fNoKhong = Convert.ToDouble(dv3.Rows[i]["NoKhong"].ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.Update();
            }
            MessageBox.Show("Đã Lưu");
        }
        private void Luu_Va_GuiDuLieu()
        {
            DataTable dv3 = (DataTable)gridControl1.DataSource;
            clsNganHang_SoDuBanDau_TaiKhoanKeToan cls2 = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();
            for (int i = 0; i < dv3.Rows.Count; i++)
            {
                cls2.iID_TaiKhoanKeToanCon = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                cls2.iID_TaiKhoanKeToanMe = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                cls2.fCoKhong = Convert.ToDouble(dv3.Rows[i]["CoKhong"].ToString());
                cls2.fNoKhong = Convert.ToDouble(dv3.Rows[i]["NoKhong"].ToString());
                cls2.bTonTai = true;
                cls2.bNgungTheoDoi = false;
                cls2.Update();
            }
            MessageBox.Show("Đã Lưu");
        }
        public UCThietLap_TaiKhoanNganHang()
        {
            InitializeComponent();
        }

        private void UCThietLap_TaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            clsNganHang_SoDuBanDau_TaiKhoanKeToan cls = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();
            DataTable dt = cls.SelectAll_HienThi();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;            
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu_ChiLuu();
        }

        private void btThemmoi_Click(object sender, EventArgs e)
        {
            mdatatabletbTaiKhoanKeToan = (DataTable)gridControl1.DataSource;
            CaiDatBanDau_ChonTaiKhoanNganHang ff = new CtyTinLuong.CaiDatBanDau_ChonTaiKhoanNganHang();
            ff.Show();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCThietLap_TaiKhoanNganHang_Load(sender, e);
        }
    }
}
