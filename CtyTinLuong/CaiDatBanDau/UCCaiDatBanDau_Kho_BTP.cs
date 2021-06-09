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
    public partial class UCCaiDatBanDau_Kho_BTP : UserControl
    {
        private void HienThi()
        {
            clsKhoBTP_tbChiTiet_tonDauKy cls2 = new clsKhoBTP_tbChiTiet_tonDauKy();
            DataTable dt3 = cls2.SelectAll_W_TenVTHH_HienThi_TonKho_GridConTrol();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietTonDauKy", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                double xxsoluong = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                double xxdongia = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietTonDauKy"] = dt3.Rows[i]["ID_ChiTietTonDauKy"].ToString();

                _ravi["ID_VTHH"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["SoLuong"] = xxsoluong;
                _ravi["DonGia"] = xxdongia;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["ThanhTien"] = xxsoluong * xxdongia;
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;
        }
        private void Load_LockUp()
        {
            clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();


            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_VTHH";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaVT";

        }
        private void LuuDuLieu()
        {
            clsKhoBTP_tbChiTiet_tonDauKy cls1 = new clsKhoBTP_tbChiTiet_tonDauKy();
            DataTable dt_Cu = cls1.SelectAll();

            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable newdt = dv.ToTable();

            if (newdt.Rows.Count > 0)
            {
                for (int i = 0; i < newdt.Rows.Count; i++)
                {
                    int ID_VTHH = Convert.ToInt16(newdt.Rows[i]["ID_VTHH"].ToString());
                    string filterExpression = "ID_VTHH=" + ID_VTHH + "";
                    DataRow[] rows = dt_Cu.Select(filterExpression);
                    if (rows.Length == 0)
                    {
                        cls1.iID_VTHH = Convert.ToInt16(newdt.Rows[i]["ID_VTHH"].ToString());

                        if (newdt.Rows[i]["SoLuong"].ToString() != "")
                            cls1.fSoLuong = Convert.ToDouble(newdt.Rows[i]["SoLuong"].ToString());
                        if (newdt.Rows[i]["DonGia"].ToString() != "")
                            cls1.fDonGia = Convert.ToDouble(newdt.Rows[i]["DonGia"].ToString());
                        cls1.bTonTai = true;
                        cls1.bNgungTheoDoi = false;
                        cls1.Insert();

                    }
                    else
                    {
                        cls1.iID_ChiTietTonDauKy = Convert.ToInt16(newdt.Rows[i]["ID_ChiTietTonDauKy"].ToString());
                        cls1.iID_VTHH = Convert.ToInt16(newdt.Rows[i]["ID_VTHH"].ToString());
                        if (newdt.Rows[i]["SoLuong"].ToString() != "")
                            cls1.fSoLuong = Convert.ToDouble(newdt.Rows[i]["SoLuong"].ToString());
                        if (newdt.Rows[i]["DonGia"].ToString() != "")
                            cls1.fDonGia = Convert.ToDouble(newdt.Rows[i]["DonGia"].ToString());
                        cls1.bTonTai = true;
                        cls1.bNgungTheoDoi = false;
                        cls1.Update();
                    }

                }

            }
            else
            {

            }

            MessageBox.Show("Đã lưu");
        }
        public UCCaiDatBanDau_Kho_BTP()
        {
            InitializeComponent();
        }

        private void UCCaiDatBanDau_Kho_BTP_Load(object sender, EventArgs e)
        {
            btLuu.Visible = false;
            //btRefresh.Visible = false;
            Load_LockUp();
            HienThi();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCCaiDatBanDau_Kho_BTP_Load( sender,  e);
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double fffsoluong = 0;
            double ffdongia = 0;
            double fffthanhtien = 0;
            if (e.Column == clMaVT)
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt16(gridView4.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView4.SetRowCellValue(e.RowHandle, clID_VTHH, kk);
                    gridView4.SetRowCellValue(e.RowHandle, clTenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clDonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                    gridView4.SetRowCellValue(e.RowHandle, clSoLuong, 0);
                    gridView4.SetRowCellValue(e.RowHandle, clDonGia, 0);

                    if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                    if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
                }
            }

            if (e.Column == clSoLuong)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }
            if (e.Column == clDonGia)
            {
                if (gridView4.GetFocusedRowCellValue(clDonGia).ToString() == "")
                    ffdongia = 0;
                else
                    ffdongia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clDonGia));
                if (gridView4.GetFocusedRowCellValue(clSoLuong).ToString() == "")
                    fffsoluong = 0;
                else
                    fffsoluong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
                fffthanhtien = fffsoluong * ffdongia;
                gridView4.SetFocusedRowCellValue(clThanhTien, fffthanhtien);
            }

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

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            if (gridView4.GetFocusedRowCellValue(clID_ChiTietTonDauKy).ToString() != "")
            {
                clsKhoBTP_tbChiTiet_tonDauKy cls = new CtyTinLuong.clsKhoBTP_tbChiTiet_tonDauKy();
                cls.iID_ChiTietTonDauKy = Convert.ToInt16(gridView4.GetFocusedRowCellValue(clID_ChiTietTonDauKy).ToString());
                cls.Delete();
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
            }
            else if (gridView4.GetFocusedRowCellValue(clID_ChiTietTonDauKy).ToString() == "")
            {
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
                gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
            }
        }

        private void gridView4_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //try
            //{
            //    if (Convert.ToDouble(gridView4.GetFocusedRowCellValue(clThanhTien)) != 0 & gridView4.GetFocusedRowCellValue(clThanhTien).ToString() != "" & gridView4.GetFocusedRowCellValue(clThanhTien).ToString() != "0")
            //    {
            //        clsKhoBTP_tbChiTiet_tonDauKy cls = new CtyTinLuong.clsKhoBTP_tbChiTiet_tonDauKy();
            //        if (gridView4.GetFocusedRowCellValue(clID_ChiTietTonDauKy).ToString() == "") // themm moi
            //        {
            //            cls.iID_VTHH = Convert.ToInt16(gridView4.GetFocusedRowCellValue(clID_VTHH));
            //            cls.fSoLuong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
            //            cls.fDonGia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));

            //            cls.bTonTai = true;
            //            cls.bNgungTheoDoi = false;
            //            cls.Insert();
            //        }
            //        else // Sửa
            //        {
            //            cls.iID_ChiTietTonDauKy = Convert.ToInt16(gridView4.GetFocusedRowCellValue(clID_ChiTietTonDauKy));
            //            cls.iID_VTHH = Convert.ToInt16(gridView4.GetFocusedRowCellValue(clID_VTHH));
            //            cls.fSoLuong = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));
            //            cls.fDonGia = Convert.ToDouble(gridView4.GetFocusedRowCellValue(clSoLuong));

            //            cls.bTonTai = true;
            //            cls.bNgungTheoDoi = false;
            //            cls.Update();
            //        }
            //    }

            //}
            //catch
            //{

            //}
        }
    }
}
