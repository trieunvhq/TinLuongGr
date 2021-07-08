﻿using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
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
    public partial class KhoNPL_ChiTiet_NhapKho_Khac : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai;
        public static double mdbTongSotien;
     
        public KhoNPL_ChiTiet_NhapKho_Khac()
        {
            InitializeComponent();
        }

        private void HienThi_Gridcontrol()
        {
            clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
            cls2.iID_NhapKho = UCNPL_NhapKho_Khacccccccccccc.miD_NhapKho;
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
            if(dt3.Rows.Count>0)
            {
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
            }
            
            gridControl1.DataSource = dt2;
        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;           
         
            clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
            DataTable dt1 = cls1.SelectAll();
            dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt1.DefaultView;
            DataTable dv3 = dv.ToTable();
            int k = dv3.Rows.Count;
            if (k == 0)
            {
                txtSoChungTu.Text = "NKNPL 1";
            }
            else
            {
                string xxx = dt1.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt32(xxx.Substring(5).Trim()) + 1;
                txtSoChungTu.Text = "NKNPL " + xxx2.ToString() + "";
            }
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
          
            gridControl1.DataSource = dt2;
        }

        private void HienThi_Sua()
        {
            clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
            cls1.iID_NhapKho = UCNPL_NhapKho_Khacccccccccccc.miD_NhapKho;
            DataTable dt1 = cls1.SelectOne();
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls1.iID_NguoiNhapKho.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtTongTienHangCoVAT.Text = cls1.fTongTienHang.Value.ToString();
            HienThi_Gridcontrol();
           
        }

        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dt = clsvthhh.T_SelectAll(); 


            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemSearchLookUpEdit1.DisplayMember = "MaVT";



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            dt = clsNguoi.T_SelectAll(5); 
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            dt.Dispose();
            clsvthhh.Dispose();
            clsNguoi.Dispose();
        }
        private void Luu_ChiTietNhapKho(int iiIDINhapKho)
        {

            string shienthi = "1";

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dvmoi.ToTable();

            clsKhoNPL_tbChiTietNhapKho cls = new clsKhoNPL_tbChiTietNhapKho();
            cls.iID_NhapKho = iiIDINhapKho;
            DataTable dt2_Cu = cls.Select_W_ID_NhapKho();
            if (dt2_Cu.Rows.Count > 0)
            {
                for (int i = 0; i < dt2_Cu.Rows.Count; i++)
                {

                    cls.iID_NhapKho = iiIDINhapKho;
                    cls.bTonTai = false;
                    cls.Update_ALL_TonTai_W_ID_NhapKho();
                }
            }
            for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
            {


                int ID_VTHHxxx = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_VTHH = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_VTHH"].ToString());
                cls.iID_NhapKho = iiIDINhapKho;
                if (dt_gridcontrol.Rows[i]["SoLuong"].ToString() != "")
                {
                    cls.fSoLuongNhap = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                    cls.fSoLuongTon = Convert.ToDouble(dt_gridcontrol.Rows[i]["SoLuong"].ToString());
                }
                else
                {
                    cls.fSoLuongNhap = 0;
                    cls.fSoLuongTon = 0;
                }
                if (dt_gridcontrol.Rows[i]["DonGia"].ToString() != "")
                    cls.fDonGia = Convert.ToDouble(dt_gridcontrol.Rows[i]["DonGia"].ToString());
                else cls.fDonGia = 0;
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                cls.bDaNhapKho = true;
                cls.bBoolTonDauKy = false;

                string expressionnhapkho;
                expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                DataRow[] foundRows;
                foundRows = dt2_Cu.Select(expressionnhapkho);
                if (foundRows.Length > 0)
                {
                    cls.iID_ChiTietNhapKho = Convert.ToInt32(foundRows[0]["ID_ChiTietNhapKho"].ToString());
                    cls.Update();
                }
                else
                {
                    cls.Insert();
                }

            }
            // xoa ton tai=false
            clsKhoNPL_tbChiTietNhapKho cls2 = new clsKhoNPL_tbChiTietNhapKho();
            DataTable dt2_moi11111 = new DataTable();
            cls2.iID_NhapKho = iiIDINhapKho;
            dt2_moi11111 = cls2.Select_W_ID_NhapKho();
            dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
            DataView dvdt2_moi = dt2_moi11111.DefaultView;
            DataTable dt2_moi = dvdt2_moi.ToTable();
            for (int i = 0; i < dt2_moi.Rows.Count; i++)
            {
                int ID_ChiTietNhapKhoxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietNhapKho"].ToString());
                cls2.iID_ChiTietNhapKho = ID_ChiTietNhapKhoxxxx;
                cls2.Delete();
            }



        }
        private void Luu_NhapKho_NPL()
        {

            double tongtienhang;
            tongtienhang = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());                      
            clsKhoNPL_tbNhapKho cls1 = new clsKhoNPL_tbNhapKho();
          
            cls1.sDienGiai = txtDienGiai.Text.ToString();
            cls1.daNgayChungTu = dteNgayChungTu.DateTime;
            cls1.sSoChungTu = txtSoChungTu.Text.ToString();
            cls1.fTongTienHang = tongtienhang;
            cls1.iID_NguoiNhapKho = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
            cls1.sThamChieu = txtThamChieu.Text.ToString();
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            cls1.bDaNhapKho = true;
            cls1.bBool_TonDauKy = false;
            cls1.bCheck_NhapKho_Khac = true;
            int xxiD_nhpakho;
          if(UCNPL_NhapKho_Khacccccccccccc.mbThemMoi==true)
            {
                cls1.Insert();
                xxiD_nhpakho = cls1.iID_NhapKho.Value;
            }
          else
            {
                cls1.iID_NhapKho = UCNPL_NhapKho_Khacccccccccccc.miD_NhapKho;
                cls1.Update();
                xxiD_nhpakho = UCNPL_NhapKho_Khacccccccccccc.miD_NhapKho;
            }
            Luu_ChiTietNhapKho(xxiD_nhpakho);
            MessageBox.Show("Đã lưu");
        }
        private void KhoNPL_ChiTiet_NhapKho_Khac_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            if (UCNPL_NhapKho_Khacccccccccccc.mbThemMoi == true)
                HienThi_ThemMoi();
            else HienThi_Sua();
            Cursor.Current = Cursors.Default;
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clMaVT)
            {
                gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, iID_VTHH);
                gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, sTenVTHH);
                gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, sDonViTinh);
                gridView1.SetRowCellValue(e.RowHandle, clHienThi, "1");
                gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                gridView1.SetRowCellValue(e.RowHandle, clDonGia, 0);

                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }

            if (e.Column == clSoLuong)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView1.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clDonGia));
                if (gridView1.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView1.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienHangCoVAT.Text = deTOngtien.ToString();

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienHangCoVAT.Text = deTOngtien.ToString();
            }
            catch
            { }
        }

        private void txtTongTienHangCoVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtTongTienHangCoVAT.Text);
                txtTongTienHangCoVAT.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_NhapKho_NPL();
        }

        private void txtSoChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteNgayChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtThamChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNguoiNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTongTienHangCoVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        int iID_VTHH;
        string sMaVT, sTenVTHH, sDonViTinh;
        private void repositoryItemSearchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)((SearchLookUpEdit)sender).GetSelectedDataRow()).Row;
            iID_VTHH = Convert.ToInt32(row["ID_VTHH"].ToString());
            sTenVTHH = row["TenVTHH"].ToString();
            sDonViTinh = row["DonViTinh"].ToString();
        }

        private void repositoryItemSearchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            try
            {
                ((SearchLookUpEdit)sender).Properties.View.Columns[0].Visible = false;
            }
            catch { }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            try
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
                mdtPrint = dv.ToTable();
                if (mdtPrint.Rows.Count > 0)
                {
                    mbPrint = true;
                    mdaNgayChungTu = dteNgayChungTu.DateTime;
                    msSoChungTu = txtSoChungTu.Text.ToString();
                    msNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                    mdbTongSotien = Convert.ToDouble(txtTongTienHangCoVAT.Text.ToString());
                    msDienGiai = txtDienGiai.Text.ToString();
                    frmPrint_Nhap_Xuat_Kho ff = new frmPrint_Nhap_Xuat_Kho();
                    ff.ShowDialog();
                }
            }
            catch { }
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiNhap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }
    }
}
