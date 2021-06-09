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
    public partial class UCNPL_XuatKho_Khacccccccccccccc : UserControl
    {
        public static int miiD_XuatKho;
        public static bool mbThemMoi;
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
        private void HienThiGridControl_2(int xxiID_XuatKho)
        {

            clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
            cls2.iID_XuatKho = xxiID_XuatKho;
            DataTable dtxxxx = cls2.SelectAll_W_ID_XuatKho();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("DonGia", typeof(float));
            dt2.Columns.Add("ThanhTien", typeof(float));
            dt2.Columns.Add("GhiChu", typeof(string));
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();

            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {
                double soluong, dongia;
                soluong = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongXuat"].ToString());
                dongia = Convert.ToDouble(dtxxxx.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                int iiDI_Vthh = Convert.ToInt16(dtxxxx.Rows[i]["ID_VTHH"].ToString());
                _ravi["ID_VTHH"] = iiDI_Vthh;
                cls.iID_VTHH = iiDI_Vthh;
                DataTable dtVT_vao = cls.SelectOne();
                _ravi["MaVT"] = iiDI_Vthh;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["SoLuong"] = soluong;
                _ravi["DonGia"] = dongia;
                
                _ravi["ThanhTien"] = soluong * dongia;
                _ravi["HienThi"] = "1";
                _ravi["GhiChu"] = dtxxxx.Rows[i]["GhiChu"].ToString();
                dt2.Rows.Add(_ravi);
            }
            
            gridControl2.DataSource = dt2;
        }
        private void HienThi(DateTime xxtungay, DateTime xxdenngay)
        {
                clsKhoNPL_tbXuatKho cls = new CtyTinLuong.clsKhoNPL_tbXuatKho();
                DataTable dt2xx = cls.SelectAll();
                dt2xx.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and checkXuatKho_Khac=True";
                DataView dv22xxx = dt2xx.DefaultView;
               
                DataTable dt = dv22xxx.ToTable();

                dt.DefaultView.RowFilter = " NgayChungTu<='" + xxdenngay + "'";
                DataView dvxxx = dt.DefaultView;
                DataTable dt22 = dvxxx.ToTable();
                dt22.DefaultView.RowFilter = " NgayChungTu>='" + xxtungay + "'";
                DataView dv2 = dt22.DefaultView;
                dv2.Sort = "NgayChungTu DESC, ID_XuatKhoNPL DESC";
                DataTable dxxxx = dv2.ToTable();

                gridControl1.DataSource = dxxxx;
         

        }
        private void HienThi_ALL()
        {

            clsKhoNPL_tbXuatKho cls = new CtyTinLuong.clsKhoNPL_tbXuatKho();
            DataTable dt2xx = cls.SelectAll();
            dt2xx.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=false and checkXuatKho_Khac=True";
            DataView dv22xxx = dt2xx.DefaultView;
          
            dv22xxx.Sort = "NgayChungTu DESC, ID_XuatKhoNPL DESC";
            DataTable dxxxx = dv22xxx.ToTable();

            gridControl1.DataSource = dxxxx;


        }
        public UCNPL_XuatKho_Khacccccccccccccc()
        {
            InitializeComponent();
        }

        private void UCNPL_XuatKho_Khacccccccccccccc_Load(object sender, EventArgs e)
        {
            Load_LockUp();
            dteDenNgay.EditValue = DateTime.Today;
            dteTuNgay.EditValue = null;
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCNPL_XuatKho_Khacccccccccccccc_Load( sender,  e);
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                mbThemMoi = false;
                miiD_XuatKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                KhoNPL_ChiTiet_XuatKho_Khac ff = new KhoNPL_ChiTiet_XuatKho_Khac();
                ff.Show();
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                int iiIDnhapKhp = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
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
            if (gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsKhoNPL_tbXuatKho cls1 = new clsKhoNPL_tbXuatKho();
                    cls1.iID_XuatKhoNPL = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());


                    cls1.Delete();
                    clsKhoNPL_tbChiTietXuatKho cls2 = new clsKhoNPL_tbChiTietXuatKho();
                    cls2.iID_XuatKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_XuatKhoNPL).ToString());
                    cls2.Delete_W_ID_XuatKho();
                    MessageBox.Show("Đã xóa");
                    if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                    {
                        HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                    }
                    else HienThi_ALL();
                }


            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            KhoNPL_ChiTiet_XuatKho_Khac ff = new KhoNPL_ChiTiet_XuatKho_Khac();
            ff.Show();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.DateTime != null & dteTuNgay.DateTime != null)
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
        }
    }
}
