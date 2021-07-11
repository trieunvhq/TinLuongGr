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
    public partial class DaiLy_FrmChiTiet_XuatKho_GapDan : Form
    {
        private void Hienthi_Lable_TonKho(int xxID_VTHH)
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = xxID_VTHH;
            DataTable dt = cls.SelectOne();
            double soluongton = 0;
            clsGapDan_ChiTiet_NhapKho cls1 = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
            double soluongxuat, soluongnhap;
            DataTable dt_NhapTruoc = new DataTable();
            DataTable dt_XuatTruoc = new DataTable();
            dt_NhapTruoc = cls1.SA_distinct_NhapTruocKy(DateTime.Now);
            dt_XuatTruoc = cls2.SA_distinct_XuatTruocKy(DateTime.Now);
            string filterExpression = "ID_VTHH=" + xxID_VTHH + "";
            DataRow[] rows_Xuat = dt_XuatTruoc.Select(filterExpression);
            DataRow[] rows_Nhap = dt_NhapTruoc.Select(filterExpression);
            if (rows_Xuat.Length == 0)
                soluongxuat = 0;
            else
                soluongxuat = Convert.ToDouble(rows_Xuat[0]["SoLuong_XuatTruocKy"].ToString());
            if (rows_Nhap.Length == 0)
                soluongnhap = 0;
            else
                soluongnhap = Convert.ToDouble(rows_Nhap[0]["SoLuong_NhapTruocKy"].ToString());
            soluongton = soluongnhap - soluongxuat;

            label_TonKho.Text = "" + cls.sMaVT.Value + " - " + cls.sTenVTHH.Value + " || Tồn kho: " + soluongton.ToString() + "";

            //if (gridView1.GetFocusedRowCellValue(clID_VTHH).ToString() != "")
            //{
            //    int xxID = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
            //    Hienthi_Lable_TonKho(xxID);
            //}
        }
        private void HienThi_GridControl_Moiiiiiiiiiiii(double soluongxuatxxx)
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DinhMuc", typeof(float));
            dt2.Columns.Add("SoLuongTheoDinhMuc", typeof(float));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("SoLuongTon", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("GhiChu", typeof(string));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("Check_VatTu_Phu", typeof(bool));

            clsGapDan_ChiTiet_NhapKho cls = new CtyTinLuong.clsGapDan_ChiTiet_NhapKho();
            //cls.iID_NhapKho = Convert.ToInt32(gridThamChieu.EditValue.ToString());

            DataTable dtchitiet1 = cls.SelectAll_W_ID_NhapKho();
            //  dtchitiet1.DefaultView.RowFilter = "Check_VatTu_Phu = True";
            DataView dv2 = dtchitiet1.DefaultView;
            DataTable dtchitietnhapkho = dv2.ToTable();
            for (int i = 0; i < dtchitietnhapkho.Rows.Count; i++)
            {
                double SoLuong = Convert.ToDouble(dtchitietnhapkho.Rows[i]["SoLuongNhap"].ToString());
                double dongiaxxx333 = Convert.ToDouble(dtchitietnhapkho.Rows[i]["DonGia"].ToString());

                int ID_VTHHxx = Convert.ToInt32(dtchitietnhapkho.Rows[i]["ID_VTHH"].ToString());

                clsTbVatTuHangHoa clvthh = new clsTbVatTuHangHoa();
                clvthh.iID_VTHH = ID_VTHHxx;
                DataTable dtvth = clvthh.SelectOne();
                clsKhoNPL_tbChiTietNhapKho xcls = new clsKhoNPL_tbChiTietNhapKho();
                xcls.iID_VTHH = ID_VTHHxx;
                DataTable dtbtp = xcls.Select_W_ID_VTHH();
                clsDinhMuc_ChiTiet_DinhMuc_ToGapDan clsdm = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
                clsdm.iID_DinhMuc_ToGapDan = Convert.ToInt32(dtchitietnhapkho.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                clsdm.iID_VTHH = ID_VTHHxx;
                DataTable dtdm = clsdm.SelectOne_W_ID_DinhMuc_ToGapDan_AND_ID_VTHH();

                double xxsoluongdinhmuc = Convert.ToDouble(dtdm.Rows[0]["SoLuong"].ToString());
                //var xxdinhmuc = Math.Round(double.Parse(xxsoluong), 3);

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID_VTHH"] = ID_VTHHxx;
                _ravi3["MaVT"] = ID_VTHHxx;
                _ravi3["DinhMuc"] = xxsoluongdinhmuc;
                _ravi3["SoLuongTheoDinhMuc"] = xxsoluongdinhmuc * soluongxuatxxx;
                _ravi3["TenVTHH"] = clvthh.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clvthh.sDonViTinh.Value;
                _ravi3["SoLuong"] = SoLuong;
                if (dtbtp.Rows.Count > 0)
                    _ravi3["SoLuongTon"] = Convert.ToDouble(dtbtp.Rows[0]["SoLuongTon"].ToString());
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtchitietnhapkho.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuong * dongiaxxx333;
                _ravi3["Check_VatTu_Phu"] = false;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
            //double deTOngtien;
            //string shienthi = "1";
            //object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + " and Check_VatTu_Phu = True");
            //if (xxxx.ToString() != "")
            //    deTOngtien = Convert.ToDouble(xxxx);
            //else deTOngtien = 0;
            //txtTongTienHang.Text = deTOngtien.ToString();

        }
        public static DateTime mdaPrintNgayXuatKho;
        public static DataTable mdtPrint_ChiTietXuatKho;
        public static string msPrintSoChungTu, msPrintDienGiaig, msPrintThuKho, msPrintNguoiNhan, msPrintNguoiLap;
      
        
        private void HienThi_Sua_XuatKho(bool isChoXuatKho, int iiID_xuatkho_)
        {
            if (isChoXuatKho == true)
            {
                clsGapDan_tbXuatKho_Temp cls1 = new clsGapDan_tbXuatKho_Temp();
                cls1.iID_XuatKho = iiID_xuatkho_;
                DataTable dt22222 = cls1.SelectOne();
                txtSoChungTu.Text = cls1.sSoChungTu.Value;
                dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                if (cls1.bCheckNhapKhoThanhPham == true)
                    checkNhapKhoThanhPham.Checked = true;
                else checkNhapKho_banThanhPham.Checked = true;
                clsGapDan_ThamChieuTinhXuatKho_Temp cls = new clsGapDan_ThamChieuTinhXuatKho_Temp();

                DataTable dt222 = cls.SA_ID_XuatKho_moi(iiID_xuatkho_);
                gridControl2.DataSource = dt222;

                clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();
                DataTable dtxx = cls2.SA_ID_XuatKho_HienThi(iiID_xuatkho_);
                gridControl1.DataSource = dtxx;
                cls.Dispose();
                cls1.Dispose();
            }
            else
            {
                clsGapDan_tbXuatKho cls1 = new clsGapDan_tbXuatKho();
                cls1.iID_XuatKho = iiID_xuatkho_;
                DataTable dt22222 = cls1.SelectOne();
                txtSoChungTu.Text = cls1.sSoChungTu.Value;
                dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
                gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
                if (cls1.bCheckNhapKhoThanhPham == true)
                    checkNhapKhoThanhPham.Checked = true;
                else checkNhapKho_banThanhPham.Checked = true;
                clsGapDan_ThamChieuTinhXuatKho cls = new clsGapDan_ThamChieuTinhXuatKho();

                DataTable dt222 = cls.SA_ID_XuatKho_2(iiID_xuatkho_);
                gridControl2.DataSource = dt222;

                clsGapDan_ChiTiet_XuatKho_Temp cls2 = new clsGapDan_ChiTiet_XuatKho_Temp();
                DataTable dtxx = cls2.SA_ID_XuatKho_HienThi(iiID_xuatkho_);
                gridControl1.DataSource = dtxx;
                cls.Dispose();
                cls1.Dispose();
            }
               
        }
        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();

            gridNguoiLap.Properties.DataSource = dtNguoi;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";
            dtNguoi.Dispose();
            clsNguoi.Dispose();

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            gridMaVT.DataSource = dt;
            gridMaVT.ValueMember = "ID_VTHH";
            gridMaVT.DisplayMember = "MaVT";

            dt.Dispose();
            cls.Dispose();

        }
        private void Load_LockUp_MaHang(DateTime xxtungay, DateTime xxdenngay)
        {
            clsGapDan_tbNhapKho cls = new clsGapDan_tbNhapKho();
            DataTable dt = cls.SA_NgayThang(xxtungay, xxdenngay);
            gridMaHang.DataSource = dt;
            gridMaHang.ValueMember = "ID_NhapKho";
            gridMaHang.DisplayMember = "SoChungTu";
            cls.Dispose();
        }
        private bool KiemTraLuu()
        {
            DataTable dv3 = new DataTable();
            if (gridControl1.DataSource != null)
            {
                string shienthi = "1";
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv = dttttt2.DefaultView;
                dv3 = dv.ToTable();
            }

            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                return false;
            }
            
            else if (dteNgayChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Không để trống ngày chứng từ");
                return false;
            }
            else if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số chứng từ ");
                return false;
            }
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa có người nhập kho");
                return false;
            }
            else return true;

        }
  
        private void Luu_ThamCHieuTinhXuatKho(int iiID_Xuatkhogapdan)
        {

            if (!KiemTraLuu()) return;
            else
            {
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dtthamchieu = dv2232xx.ToTable();

                DataTable dt3_cu = new DataTable();
                clsGapDan_ThamChieuTinhXuatKho cls3 = new clsGapDan_ThamChieuTinhXuatKho();
                cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;              
             
                dt3_cu = cls3.SelectAll_W_ID_XuatKhoGapDan();
                if (dt3_cu.Rows.Count > 0)
                {
                    cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                    cls3.bTonTai = false;
                    cls3.Update_All_TonTai_W_ID_XuatKhoGapDan();
                }

                for (int i = 0; i < dtthamchieu.Rows.Count; i++)
                {
                   
                    cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;                   
                    cls3.iID_VTHH = Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH"].ToString());
                    int iiiID_VTHHXX= Convert.ToInt32(dtthamchieu.Rows[i]["ID_VTHH"].ToString());
                    cls3.fSoLuongXuat = Convert.ToDouble(dtthamchieu.Rows[i]["SoLuongXuat"].ToString());                   
                    cls3.bTonTai = true;
                    cls3.bNgungTheoDoi = false;
                    if (dtthamchieu.Rows[i]["DonGia"].ToString() == "")
                        cls3.fDonGia = 0;
                    else cls3.fDonGia = Convert.ToDouble(dtthamchieu.Rows[i]["DonGia"].ToString());

                    cls3.iID_DinhMuc_ToGapDan= Convert.ToInt32(dtthamchieu.Rows[i]["ID_DinhMuc_ToGapDan"].ToString());
                    string expression;
                    expression = "ID_VTHH=" + iiiID_VTHHXX + "";
                    DataRow[] foundRows;
                    foundRows = dt3_cu.Select(expression);
                    if (foundRows.Length > 0)
                    {
                        cls3.iID_ThamChieu = Convert.ToInt32(foundRows[0]["ID_ThamChieu"].ToString());
                        cls3.Update();
                    }
                    else
                    {
                        cls3.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt3moi = new DataTable();
                cls3.iID_XuatKhoGapDan = iiID_Xuatkhogapdan;
                DataTable dt3hhshss = cls3.SelectAll_W_ID_XuatKhoGapDan();
                dt3hhshss.DefaultView.RowFilter = "TonTai=False";
                DataView dvdt3jjs = dt3hhshss.DefaultView;
                dt3moi = dvdt3jjs.ToTable();
                for (int i = 0; i < dt3moi.Rows.Count; i++)
                {
                    int IiID_ThamChieuyxxxx = Convert.ToInt32(dt3moi.Rows[i]["ID_ThamChieu"].ToString());
                    cls3.iID_ThamChieu = IiID_ThamChieuyxxxx;
                    cls3.Delete();
                }
            }
        }

        private void Luu_ChiTiet_XuatKho_GapDan(int iiiID_xuatkhogapgan)
        {

            if (!KiemTraLuu()) return;
            else
            {

                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl1.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt232 = dv2232xx.ToTable();

                clsGapDan_ChiTiet_XuatKho cls2 = new clsGapDan_ChiTiet_XuatKho();
                DataTable dt2_cu = new DataTable();
                cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                dt2_cu = cls2.SelectAll_ID_XuatKho();
                if (dt2_cu.Rows.Count > 0)
                {
                    cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                    cls2.bTonTai = false;
                    cls2.Update_ALL_tonTai_W_ID_NhapKho();
                }
             
                DataTable dttttt2 = dv2232xx.ToTable();
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                    cls2.iID_VTHH = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    int ID_VTHHxxx = Convert.ToInt32(dttttt2.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                  //  cls2.fSoLuongTon = Convert.ToDouble(dttttt2.Rows[i]["SoLuong"].ToString());
                    if (dttttt2.Rows[i]["DonGia"].ToString() == "")
                        cls2.fDonGia = 0;
                    else cls2.fDonGia = Convert.ToDouble(dttttt2.Rows[i]["DonGia"].ToString());
                    cls2.sGhiChu = dttttt2.Rows[i]["GhiChu"].ToString();
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;                 
                    //cls2.bCheck_ThanhPham = false;
                    //cls2.bCheck_VatTu_Chinh = false;                 
                    //cls2.bCheck_VatTu_Phu = false;
                    cls2.bDaXuatKho = true;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho TP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 1;
                    else if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho BTP")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 2;
                    if (dttttt2.Rows[i]["NhapKho_TP_1_BTP_2_NPL_3"].ToString() == "Kho NPL")
                        cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 3;
                    else cls2.iNhapKho_TP_1_BTP_2_NPL_3 = 0;

                    string expressionnhapkho;
                    expressionnhapkho = "ID_VTHH=" + ID_VTHHxxx + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietXuatKho = Convert.ToInt32(foundRows[0]["ID_ChiTietXuatKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }
                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2.iID_XuatKho = iiiID_xuatkhogapgan;
                dt2_moi11111 = cls2.SelectAll_ID_XuatKho();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int IID_ChiTietNhapKho_DaiLyxxxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_ChiTietXuatKho = IID_ChiTietNhapKho_DaiLyxxxx;
                    cls2.Delete();
                }

            }
        }
    
        private void Luu_XuatKho_GapDan()
        {
            if (!KiemTraLuu()) return;
            else
            {
                string ahienthi = "1";

                double dexxTongSoLuong, dexxTongtienhang;
                DataTable adt1 = (DataTable)gridControl2.DataSource;
                adt1.DefaultView.RowFilter = "HienThi=" + ahienthi + "";
                DataView adv1 = adt1.DefaultView;
                DataTable dtaaaaa = adv1.ToTable();

                object xxTongSoLuong = dtaaaaa.Compute("sum(SoLuongXuat)", "HienThi=" + ahienthi + "");
                if (xxTongSoLuong.ToString() != "")
                    dexxTongSoLuong = Convert.ToDouble(xxTongSoLuong);
                else dexxTongSoLuong = 0;

                object xxtongtienhang = dtaaaaa.Compute("sum(ThanhTien)", "HienThi=" + ahienthi + "");
                if (xxtongtienhang.ToString() != "")
                    dexxTongtienhang = Convert.ToDouble(xxtongtienhang);
                else dexxTongtienhang = 0;

                clsGapDan_tbXuatKho cls1 = new clsGapDan_tbXuatKho();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.iID_DinhMuc_ToGapDan = 0;
                cls1.iID_VTHH_ThanhPham_QuyDoi = 0;
                cls1.fDonGia_ThanhPham_QuyDoi = 0;
                cls1.fSoLuongThanhPham_QuyDoi = dexxTongSoLuong;
                cls1.fTongTienHang = dexxTongtienhang;
                cls1.iID_NguoiNhap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.sThamChieu = "";
                cls1.iID_DinhMuc_ToGapDan = 0;              
                cls1.bCheckNhapKhoThanhPham = checkNhapKhoThanhPham.Checked;               
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.sNguoiGiaoHang = txtNguoiGiaoHang.Text.ToString();
                int iiID_Nhapkho_GapDan;
                if (UCDaiLy_XuatKho_GapDan.mbsua == false)
                {
                    cls1.bTrangThaiNhapKhoBTP_ThanhPham = false;
                    cls1.bDaXuatKho = false;
                    cls1.Insert();
                    iiID_Nhapkho_GapDan = cls1.iID_XuatKho.Value;
                }
                else
                {
                    clsGapDan_tbXuatKho cls2 = new clsGapDan_tbXuatKho();
                    cls2.iID_XuatKho= UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan;
                    DataTable dt2 = cls2.SelectOne();
                    cls1.bTrangThaiNhapKhoBTP_ThanhPham = cls2.bTrangThaiNhapKhoBTP_ThanhPham.Value;
                    cls1.bDaXuatKho = cls2.bDaXuatKho.Value;

                    cls1.iID_XuatKho = UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan;
                    iiID_Nhapkho_GapDan = UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan;
                    cls1.Update();
                }
                Luu_ChiTiet_XuatKho_GapDan(iiID_Nhapkho_GapDan);
                Luu_ThamCHieuTinhXuatKho(iiID_Nhapkho_GapDan);
            }
            MessageBox.Show("Đã lưu");
            this.Close();
        }
      

        public DaiLy_FrmChiTiet_XuatKho_GapDan()
        {
            InitializeComponent();
        }

        private void DaiLy_FrmChiTiet_XuatKho_GapDan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = DateTime.Today.AddDays(-60);
            clSoLuongNhap1.Caption = "SL\n nhập";
            Load_LockUp();
            HienThi_Sua_XuatKho(frmQuanLyKhoDaiLy.isChoXuatKho_GapDan, UCDaiLy_XuatKho_GapDan.miID_XuatKho_GapDan);
            Cursor.Current = Cursors.Default;
        }


        private void btLuu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Luu_XuatKho_GapDan();
            Cursor.Current = Cursors.Default;
        }

        private void checkNhapKhoThanhPham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapKhoThanhPham.Checked == true)
                checkNhapKho_banThanhPham.Checked = false;
        }

        private void checkNhapKho_banThanhPham_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNhapKho_banThanhPham.Checked == true)
                checkNhapKhoThanhPham.Checked = false;
        }

        private void txtSoChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteNgayChungTu.Focus();
            }
        }

        private void dteNgayChungTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridNguoiLap.Focus();
            }
        }

        private void gridNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenNguoiLap.Focus();
            }
        }

        private void txtTenNguoiLap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNguoiGiaoHang.Focus();
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void btXoaGrid2_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {

        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                Load_LockUp_MaHang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dteTuNgay.EditValue != null & dteDenNgay.EditValue != null)
            {
                Load_LockUp_MaHang(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void txtNguoiGiaoHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDienGiai.Focus();
            }
        }

        private void txtDienGiai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    btLayDuLieu.Focus();
            //}
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
                    txtTenNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }
            }
            catch
            {

            }
        }
        
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
     
    }
}
