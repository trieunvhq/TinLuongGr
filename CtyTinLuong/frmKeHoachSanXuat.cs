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
    public partial class frmKeHoachSanXuat : Form
    {
        public static bool mbThemMoi, mbSua, mbCopy, mPrint;
        public static int miID_KeHoachSanXuat;
        public static DataTable mdtChiTiet_Print;
        public static DateTime  mdaTuNgay,mdaDenNgay;

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
        //private void HienThi_ALL()
        //{
        //    DataTable dt2 = new DataTable();            
        //    dt2.Columns.Add("ID_KeHoachSanXuat", typeof(int));
        //    dt2.Columns.Add("NgayDatHang", typeof(DateTime));
        //    dt2.Columns.Add("ID_KhachHang", typeof(int));
        //    dt2.Columns.Add("ID_VTHH", typeof(int));
        //    dt2.Columns.Add("SoLuong", typeof(double));
        //    dt2.Columns.Add("QuyCach", typeof(string));
        //    dt2.Columns.Add("NgayDuKienXuat", typeof(DateTime));
        //    dt2.Columns.Add("NgayXuatThucTe", typeof(DateTime));
        //    dt2.Columns.Add("SoLuongThucXuat", typeof(double));
        //    dt2.Columns.Add("SoCountner", typeof(double));
        //    dt2.Columns.Add("ID_BanHang", typeof(int));
        //    dt2.Columns.Add("GhiChu", typeof(string));
        //    dt2.Columns.Add("TenKH", typeof(string));
        //    dt2.Columns.Add("MaVT", typeof(string));
        //    dt2.Columns.Add("TenVTHH", typeof(string));
        //    dt2.Columns.Add("DaHoanThanh", typeof(bool));
        //    dt2.Columns.Add("DienGiai", typeof(string));
        //    dt2.Columns.Add("HienThi", typeof(string));
        //    dt2.Columns.Add("MaKeHoach", typeof(string));
        //    clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();         
        //    DataTable dxxxx = cls.SelectAll();
        //    DataView dv = dxxxx.DefaultView;
        //    dv.Sort = "DaHoanThanh DESC";
        //    DataTable dt = dv.ToTable();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        int ID_KeHoachSanXuat, ID_KhachHang, ID_VTHH, ID_BanHang;
        //        DateTime NgayDatHang, NgayDuKienXuat, NgayXuatThucTe;
        //        double SoLuong, SoCountner, SoLuongThucXuat;
        //        string QuyCach, GhiChu, TenKH, MaVT, TenVTHH, DienGiai;

        //        ID_KeHoachSanXuat= Convert.ToInt32(dxxxx.Rows[i]["ID_KeHoachSanXuat"].ToString());
        //        ID_KhachHang = Convert.ToInt32(dxxxx.Rows[i]["ID_KhachHang"].ToString());
        //        ID_VTHH = Convert.ToInt32(dxxxx.Rows[i]["ID_VTHH"].ToString());
        //        if (dxxxx.Rows[i]["ID_BanHang"].ToString() != "")
        //            ID_BanHang = Convert.ToInt32(dxxxx.Rows[i]["ID_BanHang"].ToString());
        //        else ID_BanHang = 0;

        //        NgayDatHang = Convert.ToDateTime(dxxxx.Rows[i]["NgayDatHang"].ToString());
        //        NgayDuKienXuat = Convert.ToDateTime(dxxxx.Rows[i]["NgayDuKienXuat"].ToString());
        //        NgayXuatThucTe = Convert.ToDateTime(dxxxx.Rows[i]["NgayXuatThucTe"].ToString());

        //        SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuong"].ToString());
        //        SoCountner = Convert.ToDouble(dxxxx.Rows[i]["SoCountner"].ToString());
        //        SoLuongThucXuat = Convert.ToDouble(dxxxx.Rows[i]["SoLuongThucXuat"].ToString());

        //        QuyCach = dxxxx.Rows[i]["QuyCach"].ToString();
        //        GhiChu = dxxxx.Rows[i]["GhiChu"].ToString();
        //        DienGiai = dxxxx.Rows[i]["DienGiai"].ToString();
        //        clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
        //        cls1.iID_VTHH = ID_VTHH;
        //        DataTable dt1 = cls1.SelectOne();
        //        MaVT = cls1.sMaVT.Value;
        //        TenVTHH = cls1.sTenVTHH.Value;

        //        clsTbKhachHang cls2 = new clsTbKhachHang();
        //        cls2.iID_KhachHang = ID_KhachHang;
        //        DataTable dt22222 = cls2.SelectOne();
        //        TenKH = cls2.sTenKH.Value;
              
        //        DataRow _ravi = dt2.NewRow();
                
        //        _ravi["ID_KeHoachSanXuat"] = ID_KeHoachSanXuat;
        //        _ravi["NgayDatHang"] = NgayDatHang;
        //        _ravi["ID_KhachHang"] = ID_KhachHang;
        //        _ravi["ID_VTHH"] = ID_VTHH;
        //        _ravi["SoLuong"] = SoLuong;
        //        _ravi["QuyCach"] = QuyCach;
        //        _ravi["NgayDuKienXuat"] = NgayDuKienXuat;
        //        _ravi["NgayXuatThucTe"] = NgayXuatThucTe;
        //        _ravi["SoLuongThucXuat"] = SoLuongThucXuat;
        //        _ravi["SoCountner"] = SoCountner;
        //        _ravi["ID_BanHang"] = ID_BanHang;
        //        _ravi["GhiChu"] = GhiChu;
        //        _ravi["DienGiai"] = DienGiai;
        //        _ravi["TenKH"] = TenKH;
        //        _ravi["MaVT"] = MaVT;
        //        _ravi["TenVTHH"] = TenVTHH;
        //        _ravi["HienThi"] = "1";
        //        _ravi["MaKeHoach"] = dxxxx.Rows[i]["MaKeHoach"].ToString();
        //        _ravi["DaHoanThanh"] = Convert.ToBoolean(dxxxx.Rows[i]["DaHoanThanh"].ToString());
        //        dt2.Rows.Add(_ravi);

        //    }
           
        //    gridControl1.DataSource = dt2;

        //}

        private void HienThi(DateTime tungayxxxx, DateTime denngayxxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_KeHoachSanXuat", typeof(int));
            dt2.Columns.Add("NgayDatHang", typeof(DateTime));
            dt2.Columns.Add("ID_KhachHang", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("QuyCach", typeof(string));
            dt2.Columns.Add("NgayDuKienXuat", typeof(DateTime));
            dt2.Columns.Add("NgayXuatThucTe", typeof(DateTime));
            dt2.Columns.Add("SoLuongThucXuat", typeof(double));
            dt2.Columns.Add("SoCountner", typeof(double));
            dt2.Columns.Add("ID_BanHang", typeof(int));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("TenKH", typeof(string));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DaHoanThanh", typeof(bool));
            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("MaKeHoach", typeof(string));
            clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();

            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " NgayDatHang<='" + denngayxxxx + "'";
            DataView dv = dt.DefaultView;
            DataTable dt22 = dv.ToTable();
            dt22.DefaultView.RowFilter = " NgayDatHang>='" + tungayxxxx + "'";
            DataView dv2 = dt22.DefaultView;
            dv.Sort = "DaHoanThanh DESC";
            DataTable dxxxx = dv2.ToTable();
            for (int i = 0; i < dxxxx.Rows.Count; i++)
            {
                int ID_KeHoachSanXuat, ID_KhachHang, ID_VTHH, ID_BanHang;
                DateTime NgayDatHang, NgayDuKienXuat, NgayXuatThucTe;
                double SoLuong, SoCountner, SoLuongThucXuat;
                string QuyCach, GhiChu, TenKH, MaVT, TenVTHH, DienGiai;

                ID_KeHoachSanXuat = Convert.ToInt32(dxxxx.Rows[i]["ID_KeHoachSanXuat"].ToString());
                ID_KhachHang = Convert.ToInt32(dxxxx.Rows[i]["ID_KhachHang"].ToString());
                ID_VTHH = Convert.ToInt32(dxxxx.Rows[i]["ID_VTHH"].ToString());
                if (dxxxx.Rows[i]["ID_BanHang"].ToString() != "")
                    ID_BanHang = Convert.ToInt32(dxxxx.Rows[i]["ID_BanHang"].ToString());
                else ID_BanHang = 0;
                NgayDatHang = Convert.ToDateTime(dxxxx.Rows[i]["NgayDatHang"].ToString());
                NgayDuKienXuat = Convert.ToDateTime(dxxxx.Rows[i]["NgayDuKienXuat"].ToString());
                NgayXuatThucTe = Convert.ToDateTime(dxxxx.Rows[i]["NgayXuatThucTe"].ToString());

                SoLuong = Convert.ToDouble(dxxxx.Rows[i]["SoLuong"].ToString());
                SoCountner = Convert.ToDouble(dxxxx.Rows[i]["SoCountner"].ToString());
                SoLuongThucXuat = Convert.ToDouble(dxxxx.Rows[i]["SoLuongThucXuat"].ToString());

                QuyCach = dxxxx.Rows[i]["QuyCach"].ToString();
                GhiChu = dxxxx.Rows[i]["GhiChu"].ToString();
                DienGiai = dxxxx.Rows[i]["DienGiai"].ToString();
                clsTbVatTuHangHoa cls1 = new clsTbVatTuHangHoa();
                cls1.iID_VTHH = ID_VTHH;
                DataTable dt1 = cls1.SelectOne();
                MaVT = cls1.sMaVT.Value;
                TenVTHH = cls1.sTenVTHH.Value;

                clsTbKhachHang cls2 = new clsTbKhachHang();
                cls2.iID_KhachHang = ID_KhachHang;
                DataTable dt22222 = cls2.SelectOne();
                TenKH = cls2.sTenKH.Value;

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_KeHoachSanXuat"] = ID_KeHoachSanXuat;
                _ravi["NgayDatHang"] = NgayDatHang;
                _ravi["ID_KhachHang"] = ID_KhachHang;
                _ravi["ID_VTHH"] = ID_VTHH;
                _ravi["SoLuong"] = SoLuong;
                _ravi["QuyCach"] = QuyCach;
                _ravi["NgayDuKienXuat"] = NgayDuKienXuat;
                _ravi["NgayXuatThucTe"] = NgayXuatThucTe;
                _ravi["SoLuongThucXuat"] = SoLuongThucXuat;
                _ravi["SoCountner"] = SoCountner;
                _ravi["ID_BanHang"] = ID_BanHang;
                _ravi["GhiChu"] = GhiChu;
                _ravi["DienGiai"] = DienGiai;
                //DienGiai
                _ravi["TenKH"] = TenKH;
                _ravi["MaVT"] = MaVT;
                _ravi["TenVTHH"] = TenVTHH;
                _ravi["HienThi"] = "1";
                _ravi["MaKeHoach"] = dxxxx.Rows[i]["MaKeHoach"].ToString();
                _ravi["DaHoanThanh"] = Convert.ToBoolean(dxxxx.Rows[i]["DaHoanThanh"].ToString());
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;

        }
        public frmKeHoachSanXuat()
        {
            InitializeComponent();
        }

        private void frmKeHoachSanXuat_Load(object sender, EventArgs e)
        {
            DateTime ngaydautien, ngaycuoicung;
            DateTime ngayhomnay = DateTime.Today;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"));
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            dteDenNgay.EditValue = ngaycuoicung;
            dteTuNgay.EditValue = ngaydautien;

            mbThemMoi = false;
            mbSua = false;
            mbCopy = false;
            clSoCountner.Caption = "Số \n cont";
            clNgayDatHang.Caption = " Ngày\n đặt\n hàng";
            clNgayDuKienXuat.Caption = " Ngày\n dự\n kiến\n xuất";
            clNgayXuatThucTe.Caption = " Ngày\n xuát\n thực\n tế";
            clSoLuong.Caption = "Số\n lượng";
            clSoLuongThucXuat.Caption = "Số\n lượng\n xuất\n thực\n tế ";
            clMaKeHoach.Caption = "Mã\n Kế hoạch";
          
            HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                HienThi(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void btCopY_Click(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_KeHoachSanXuat).ToString()!="")
            {
                mbThemMoi = false;
                mbSua = false;
                mbCopy = true;
                miID_KeHoachSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_KeHoachSanXuat).ToString());
                frmChiTietKeHoachSanXuat ff = new CtyTinLuong.frmChiTietKeHoachSanXuat();
                ff.Show();
            }
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_KeHoachSanXuat).ToString() != "")
            {
                mbThemMoi = false;
                mbSua = true;
                mbCopy = false;
                miID_KeHoachSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_KeHoachSanXuat).ToString());
                frmChiTietKeHoachSanXuat ff = new CtyTinLuong.frmChiTietKeHoachSanXuat();
                ff.Show();
            }

            
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["DaHoanThanh"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
           
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            DataTable dttttt2 = dv1212.ToTable();
            string shienthi = "1";
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            mdtChiTiet_Print = dv.ToTable();
            if(mdtChiTiet_Print.Rows.Count>0)
            {
                mdaTuNgay = dteTuNgay.DateTime;
                mdaDenNgay = dteDenNgay.DateTime;
                mPrint = true;
                frmPrint_KeHoachSanXuat ff= new frmPrint_KeHoachSanXuat();
                ff.Show();
            }
            else
            {
                MessageBox.Show("Không có sữ liệu");
                return;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            frmKeHoachSanXuat_Load( sender,  e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            mbThemMoi = true;
            mbSua = false;
            mbCopy = false;
            frmChiTietKeHoachSanXuat ff = new CtyTinLuong.frmChiTietKeHoachSanXuat();
            ff.Show();
        }
    }
}
