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
    public partial class UCQuy_NganHang_BaoCo : UserControl
    {
        public static int miID_ThuChi_Sua;
        public static bool mbThemMoi_ThuChi, mbooolBitThuChiKhac;

        private void HienThi()
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                DateTime denngay = dteDenNgay.DateTime;
                DateTime tungay = dteTuNgay.DateTime;

                clsNganHang_tbThuChi cls = new CtyTinLuong.clsNganHang_tbThuChi();
                DataTable dt = cls.SelectAll();
                if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 1)
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
                else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 2)
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
                else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 3)
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
                else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 4)
                    dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
                DataView dv = dt.DefaultView;
                dv.Sort = "DaGhiSo ASC, NgayChungTu DESC, ID_ThuChi DESC";
                DataTable dxxxx = dv.ToTable();
                dxxxx.DefaultView.RowFilter = " NgayChungTu<='" + denngay + "'";
                DataView dvxx = dxxxx.DefaultView;
                DataTable dt22xxx = dvxx.ToTable();
                dt22xxx.DefaultView.RowFilter = " NgayChungTu>='" + tungay + "'";
                gridControl1.DataSource = dt22xxx;
            }


        }
        private void HienThi_ALL()
        {

            clsNganHang_tbThuChi cls = new CtyTinLuong.clsNganHang_tbThuChi();
            DataTable dt = cls.SelectAll();
            if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 1)
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 2)
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 3)
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
            else if (frmQuy_NganHang_Newwwwwwwwwwwwwwwww.miTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 == 4)
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
            DataView dv = dt.DefaultView;
            dv.Sort = "DaGhiSo ASC, NgayChungTu DESC, ID_ThuChi DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;

        }
        public UCQuy_NganHang_BaoCo()
        {
            InitializeComponent();
        }

        private void UCQuy_NganHang_BaoCo_Load(object sender, EventArgs e)
        {
            mbThemMoi_ThuChi = true;                      
            dteTuNgay.EditValue = null;
            dteDenNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCQuy_NganHang_BaoCo_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi_ThuChi = true;
           
            Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
            ff.Show();
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
            if (gridView1.GetFocusedRowCellValue(ID_ThuChi).ToString() != "")
            {

                mbThemMoi_ThuChi = false;
                miID_ThuChi_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_ThuChi).ToString());
               
                //if (Convert.ToBoolean(gridView1.GetFocusedRowCellValue(BitThuChiKhac).ToString()) == true)
                //{
                //    mbooolBitThuChiKhac = true;

                //    //Quy_nganHang_ChiTiet_thuChi_Newwwwwwwwwwwwwwww ff = new CtyTinLuong.Quy_nganHang_ChiTiet_thuChi_Newwwwwwwwwwwwwwww();
                //    //ff.Show();
                //}
                //else
                //{
                //    mbooolBitThuChiKhac = false;
                //    //Quy_nganHang_ChiTiet_thuChi_TuMuaHang_BanHang_VanVan ff = new CtyTinLuong.Quy_nganHang_ChiTiet_thuChi_TuMuaHang_BanHang_VanVan();
                //    //ff.Show();
                //}
                Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new CtyTinLuong.Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
                ff.Show();
            }

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaGhiSo"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;
                   
                }
            }
        }
    }
}
