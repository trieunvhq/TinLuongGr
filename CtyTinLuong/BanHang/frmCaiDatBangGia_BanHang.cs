using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmCaiDatBangGia_BanHang : Form
    {
        public static DataTable mdtPrint;
        public static bool mbPrint;
        public static string msTenKhachHang, msDienThoai, msDiaChi,msDienGiai;
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            GridLookUpEdit_MaVatTu.DataSource = newdtvthh;
            GridLookUpEdit_MaVatTu.ValueMember = "ID_VTHH";
            GridLookUpEdit_MaVatTu.DisplayMember = "MaVT";

            clsTbKhachHang cls = new clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable newdt = dv.ToTable();

            gridKH.Properties.DataSource = newdt;
            gridKH.Properties.ValueMember = "ID_KhachHang";
            gridKH.Properties.DisplayMember = "MaKH";

           
        }
        private void HienThi_ALLL()
        {
           


            clsBanHang_BangGia cls = new clsBanHang_BangGia();
           
            DataTable dt3 = cls.SelectAll();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_BangGia"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("ID_KhachHang");
            dt2.Columns.Add("DonGia");
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("DienGiai");
            dt2.Columns.Add("GhiChu");
            dt2.Columns.Add("NgayLap", typeof(DateTime));

            dt2.Columns.Add("MaVT");
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");

          
            dt2.Columns.Add("HienThi");
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_BangGia"] = dt3.Rows[i]["ID_BangGia"].ToString();
                    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["ID_KhachHang"] = dt3.Rows[i]["ID_KhachHang"].ToString();
                    _ravi["DonGia"] = dt3.Rows[i]["DonGia"].ToString();
                    _ravi["TienUSD"] = Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                    _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    _ravi["NgayLap"] = Convert.ToDateTime(dt3.Rows[i]["NgayLap"].ToString());
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                  
                    cls1.iID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                    DataTable dt1 = cls1.SelectOne();                  
                    _ravi["MaVT"] = cls1.iID_VTHH.Value.ToString();
                    _ravi["TenVTHH"] = cls1.sTenVTHH.Value;
                    _ravi["DonViTinh"] = cls1.sDonViTinh.Value;
                  
                    _ravi["HienThi"] = "1";
                    dt2.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = dt2;

        }
        private void HienThi(int xxID_khachhang)
        {
         
            clsBanHang_BangGia cls = new clsBanHang_BangGia();
            cls.iID_KhachHang = xxID_khachhang;
            DataTable dt3 = cls.SelectAll_ID_KhachHang();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_BangGia"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("ID_KhachHang");   
            dt2.Columns.Add("DonGia");
            dt2.Columns.Add("TienUSD", typeof(bool));
            dt2.Columns.Add("DienGiai");
            dt2.Columns.Add("GhiChu");
            dt2.Columns.Add("NgayLap", typeof(DateTime));

            dt2.Columns.Add("MaVT");
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");

         
            dt2.Columns.Add("HienThi");
            if (dt3.Rows.Count>0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_BangGia"] = dt3.Rows[i]["ID_BangGia"].ToString();
                    _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                    _ravi["ID_KhachHang"] = xxID_khachhang;                  
                    _ravi["DonGia"] = dt3.Rows[i]["DonGia"].ToString(); 
                    _ravi["TienUSD"] =Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                    _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    _ravi["NgayLap"] =Convert.ToDateTime(dt3.Rows[i]["NgayLap"].ToString());
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                    
                    cls1.iID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                    DataTable dt1 = cls1.SelectOne();
                   
                    _ravi["MaVT"] = cls1.iID_VTHH.Value.ToString();
                    _ravi["TenVTHH"] = cls1.sTenVTHH.Value;
                    _ravi["DonViTinh"] = cls1.sDonViTinh.Value;
                   
                    _ravi["HienThi"] = "1";
                    dt2.Rows.Add(_ravi);
                }
            }            

            gridControl1.DataSource = dt2;
            
        }
        public frmCaiDatBangGia_BanHang()
        {
            InitializeComponent();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls1.SelectOne();
                gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, cls1.sTenVTHH.Value);
                gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, cls1.sMaVT.Value);
                gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);
                gridView4.SetRowCellValue(e.RowHandle, clTienUSD, true);
                if (gridView4.GetFocusedRowCellValue(clID_BangGia).ToString() == "")
                    gridView4.SetRowCellValue(e.RowHandle, clNgayLap, DateTime.Today);
                gridView4.SetRowCellValue(e.RowHandle, clID_KhachHang, gridKH.EditValue);
            }
            //if (e.Column == clMaKH)
            //{
            //    clsTbKhachHang cls2 = new clsTbKhachHang();
            //    cls2.iID_KhachHang = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
            //    int kk = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));
            //    DataTable dt = cls2.SelectOne();
              
            //        gridView4.SetRowCellValue(e.RowHandle, clID_KhachHang, kk);
            //        gridView4.SetRowCellValue(e.RowHandle, clTenKH, cls2.sTenKH.Value);
                   
            //}
        }

        private void frmCaiDatBangGia_BanHang_Load(object sender, EventArgs e)
        {
            gridKH.EditValue = null;
            txtTenKH.Text = "";
            gridView4.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            Load_LockUp();
            HienThi_ALLL();
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            if (gridView4.GetFocusedRowCellValue(clID_BangGia).ToString() != "")
            {
                DialogResult traloi;             
                traloi = MessageBox.Show("Xóa dữ liệu này. Lưu ý sẽ mất hế dữ liệu?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsBanHang_BangGia cls = new clsBanHang_BangGia();
                    cls.iID_BangGia = Convert.ToInt32(gridView4.GetFocusedRowCellValue(clID_BangGia).ToString());
                    cls.Delete();
                    MessageBox.Show("Đã xoá");
                    gridView4.SetFocusedRowCellValue(clHienThi, "0");

                }
            }
        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (gridKH.EditValue != null)
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dvmoi = dtkkk.DefaultView;
                DataTable dtmoi = dvmoi.ToTable();
                clsBanHang_BangGia cls = new clsBanHang_BangGia();
                for (int i = 0; i < dtmoi.Rows.Count; i++)
                {
                    cls.iID_KhachHang = Convert.ToInt32(dtkkk.Rows[i]["ID_KhachHang"].ToString());
                    cls.iID_VTHH = Convert.ToInt32(dtkkk.Rows[i]["ID_VTHH"].ToString());
                    cls.fDonGia = Convert.ToDouble(dtkkk.Rows[i]["DonGia"].ToString());
                    cls.bTienUSD = Convert.ToBoolean(dtkkk.Rows[i]["TienUSD"].ToString());
                    cls.sDienGiai = dtkkk.Rows[i]["DienGiai"].ToString();
                    cls.sGhiChu = dtkkk.Rows[i]["GhiChu"].ToString();
                    cls.daNgayLap = Convert.ToDateTime(dtkkk.Rows[i]["NgayLap"].ToString());
                    if (dtkkk.Rows[i]["ID_BangGia"].ToString() != "") // sửa
                    {
                        cls.iID_BangGia = Convert.ToInt32(dtkkk.Rows[i]["ID_BangGia"].ToString());
                        cls.Update();
                    }
                    else
                    {
                        cls.Insert();
                    }
                }
                MessageBox.Show("Đã lưu");
            }

            //else
            //    MessageBox.Show("chưa chọn khách hàng");
            //}
            //catch
            //{ }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridKH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbKhachHang clsncc = new clsTbKhachHang();
                int iiIDIIII = Convert.ToInt16(gridKH.EditValue.ToString());
                clsncc.iID_KhachHang = Convert.ToInt16(gridKH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                    HienThi(iiIDIIII);
                }
                if(gridKH.EditValue!=null)
                    gridView4.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            }
            catch
            {

            }
        }

        private void gridView4_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmCaiDatBangGia_BanHang_Load(sender, e);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
           
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView4.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            //dv1212.RowFilter = filterString;
            //DataTable dttttt2 = dv1212.ToTable();
            //string shienthi = "1";
            //dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            //DataView dv = dttttt2.DefaultView;
            mdtPrint = dv1212.ToTable();
            if(mdtPrint.Rows.Count>0)
            {
                mbPrint = true;
                if(gridKH.EditValue!=null)
                {
                    clsTbKhachHang cls = new clsTbKhachHang();
                    cls.iID_KhachHang = Convert.ToInt32(gridKH.EditValue.ToString());
                    DataTable dt = cls.SelectOne();
                    msDiaChi = cls.sDiaChi.Value;
                    msTenKhachHang = cls.sTenKH.Value;
                    msDienThoai = cls.sSoDienThoai.Value;
                }
                else
                {
                   
                    msDiaChi = "";
                    msTenKhachHang = txtTenKH.Text.ToString();
                    msDienThoai = "";
                }
                
                msDienGiai = "Đơn giá bán hàng";

                frmPrint_baoGia_BanHanag ff = new frmPrint_baoGia_BanHanag();
                ff.Show();
            }
      

          
        }
    }
}
