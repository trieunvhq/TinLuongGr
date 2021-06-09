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
    public partial class UCbanThanhPham_DaXuatKho : UserControl
    {
        public static int miiID_XuatKhoBTP;
       
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
        private void HienThiGridControl_2(int xxxidnhapkho)
        {

            clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
            cls2.iID_XuatKhoBTP = xxxidnhapkho;
            DataTable dt3 = cls2.SelectOne_W_ID_XuatKhoBTP();
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

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Decimal xxsoluong = Convert.ToDecimal(dt3.Rows[i]["SoLuongXuat"].ToString());
                Decimal xxdongia = Convert.ToDecimal(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHHxx;
                DataTable dtvj = cls.SelectOne();
                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = ID_VTHHxx;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDecimal(xxsoluong * xxdongia);
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }

            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
            clsKhoBTP_tbXuatKho cls = new CtyTinLuong.clsKhoBTP_tbXuatKho();
            DataTable dt2xx = cls.SelectAll();
            dt2xx.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv22xxx = dt2xx.DefaultView;          
            DataTable dt = dv22xxx.ToTable();

            dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
            DataView dvxxx = dt.DefaultView;
            DataTable dt22 = dvxxx.ToTable();
            dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
            DataView dv2 = dt22.DefaultView;
            dv2.Sort = "NgayChungTu DESC, ID_XuatKhoBTP DESC";
            DataTable dxxxx = dv2.ToTable();

            gridControl1.DataSource = dxxxx;

        }
        private void HienThi_ALL()
        {

            clsKhoBTP_tbXuatKho cls = new CtyTinLuong.clsKhoBTP_tbXuatKho();
            DataTable dt2 = cls.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false";
            DataView dv = dt2.DefaultView;
            dv.Sort = "NgayChungTu DESC, ID_XuatKhoBTP DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;


        }

        public UCbanThanhPham_DaXuatKho()
        {
            InitializeComponent();
        }

        private void UCbanThanhPham_DaXuatKho_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCbanThanhPham_DaXuatKho_Load( sender,  e);
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
                if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
                {
                    miiID_XuatKhoBTP = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                    KhoBTP_ChiTietDaXuatKho ff = new KhoBTP_ChiTietDaXuatKho();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                HienThiGridControl_2(iiIDnhapKhp);
            }
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoBTP_tbXuatKho cls1 = new clsKhoBTP_tbXuatKho();
                    cls1.iID_XuatKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());


                    cls1.Delete();
                    clsKhoBTP_ChiTietXuatKho cls2 = new clsKhoBTP_ChiTietXuatKho();
                    cls2.iID_XuatKhoBTP = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoBTP).ToString());
                    cls2.Delete_ALL_W_ID_XuatKhoBTP();
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
