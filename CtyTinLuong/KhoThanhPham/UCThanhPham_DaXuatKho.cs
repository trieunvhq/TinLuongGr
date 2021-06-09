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

    public partial class UCThanhPham_DaXuatKho : UserControl
    {

        public static int miID_XuatKho;
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
        private void HienThiGridControl_2(int xxidxuatkhp)
        {

            clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();
            cls2.iID_XuatKho_ThanhPham = xxidxuatkhp;
            DataTable dt3 = cls2.SelectAll_W_ID_XuatKho_HienThi_ChiTiet();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(decimal));

            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("GhiChu");

            dt2.Columns.Add("ThanhTien", typeof(decimal));
            dt2.Columns.Add("HienThi", typeof(string));
            if (dt3.Rows.Count == 0)
            {
                gridControl2.DataSource = null;
            }
            else
            {


                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongXuat"].ToString());
                    Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                    DataRow _ravi = dt2.NewRow();
                    //_ravi["ID_ChiTietNhapKho"] = dt3.Rows[i]["ID_ChiTietNhapKho"].ToString();
                    //_ravi["ID_NhapKho"] = dt3.Rows[i]["ID_NhapKho"].ToString();
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
            }
            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {


            clsKhoThanhPham_tbXuatKho cls = new CtyTinLuong.clsKhoThanhPham_tbXuatKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv = dt2.DefaultView;
            //dv.Sort = "NgayChungTu DESC, ID_XuatKhoBTP DESC";
            DataTable dt = dv.ToTable();


            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable dt22 = dvxxx.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "DaXuatKho ASC, NgayChungTu DESC, ID_XuatKho_ThanhPham DESC";
            DataTable dxxxx = dv2.ToTable();

            gridControl1.DataSource = dxxxx;


        }
        private void HienThi_ALL()
        {
            clsKhoThanhPham_tbXuatKho cls = new CtyTinLuong.clsKhoThanhPham_tbXuatKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_XuatKho_ThanhPham DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }
      
        public UCThanhPham_DaXuatKho()
        {
            InitializeComponent();
        }

        private void UCThanhPham_DaXuatKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }
        
        private void btRefresh_Click_2(object sender, EventArgs e)
        {
            UCThanhPham_DaXuatKho_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoThanhPham_tbXuatKho cls1 = new clsKhoThanhPham_tbXuatKho();
                    cls1.iID_XuatKho_ThanhPham = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());


                    cls1.Delete();
                    clsKhoThanhPham_tbChiTietXuatKho cls2 = new clsKhoThanhPham_tbChiTietXuatKho();
                    cls2.iID_XuatKho_ThanhPham = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
                    cls2.Delete_ALL_ID_XuatKho_ThanhPham();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    else HienThi_ALL();
                }


            }
        }

        private void gridView1_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString() != "")
                {
                    miID_XuatKho = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKho_ThanhPham).ToString());
                    KhoThanhPham_frmChiTiet_Da_XuatKho ff = new KhoThanhPham_frmChiTiet_Da_XuatKho();
                    ff.Show();
                }
            }
            catch
            {

            }
        }
    }
}
