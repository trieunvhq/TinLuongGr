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
    public partial class UC_KhoNVL_frmDaNhapKho : UserControl
    {
        public static int miD_NhapKho;
        public static string msThamChieuMuaHang;
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
        private void HienThiGridControl_2(int xxIID_NhapKho)
        {
            
            clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
            cls2.iID_NhapKho = xxIID_NhapKho;
            DataTable dt3 = cls2.Select_W_ID_NhapKho_HienThi_SuaDonHang();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietNhapKho"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_NhapKho");
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongNhap"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietNhapKho"] = dt3.Rows[i]["ID_ChiTietNhapKho"].ToString();
                _ravi["ID_NhapKho"] = dt3.Rows[i]["ID_NhapKho"].ToString();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();

                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }
           
            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
           

                clsKhoNPL_tbNhapKho cls = new CtyTinLuong.clsKhoNPL_tbNhapKho();
                DataTable dt2xx = cls.SelectAll();
                dt2xx.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
                DataView dv22xxx = dt2xx.DefaultView;
                dv22xxx.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
                DataTable dt = dv22xxx.ToTable();            

                dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                DataView dvxxx = dt.DefaultView;
                DataTable dt22 = dvxxx.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
                DataTable dxxxx = dv2.ToTable();

                gridControl1.DataSource = dxxxx;
          
        }
        private void HienThi_ALL()
        {            

            clsKhoNPL_tbNhapKho cls = new CtyTinLuong.clsKhoNPL_tbNhapKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_NhapKho DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }
      
        public UC_KhoNVL_frmDaNhapKho()
        {
            InitializeComponent();
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
                if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
                {
                    msThamChieuMuaHang = gridView1.GetFocusedRowCellValue(clThamChieu).ToString();
                    miD_NhapKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
                    KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang ff = new KhoNPL_frmChiTiet_Da_NhapKho_TuMuaHang();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void UC_KhoNVL_frmDaNhapKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = null;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_KhoNVL_frmDaNhapKho_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime,dteDenNgay.DateTime.AddDays(1));
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
                    cls1.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());


                    cls1.Delete();
                    clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
                    cls2.iID_NhapKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_NhapKhoNPL).ToString());
                    cls2.Delete_ALL_W_ID_NhapKho();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    else HienThi_ALL();
                }


            }




        }
    }
}
