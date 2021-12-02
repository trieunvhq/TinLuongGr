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
    public partial class Tr_frmChiTietXuatContDongKien : Form
    {
        private DataTable _dtDonGiatheoVTHH, _dtHangHoa;
        private void Hienthi_Lable_TonKho(int xxID_VTHH, double SLxuat, double SLrowOld)
        {
            clsThin cls = new clsThin();
            DataTable dt = cls.Tr_DongKien_TbXuatKho_ChiTietXuatKho_TonKho_S(xxID_VTHH, dteNgayChungTu.DateTime);

            if (dt.Rows.Count > 0)
            {
                double tonKho = CheckString.ConvertToDouble_My(dt.Rows[0]["SoLuongCon"].ToString());
                string maVT = dt.Rows[0]["MaVT"].ToString();
                string tenVT = dt.Rows[0]["TenVTHH"].ToString();

                label_TonKho.Text = maVT + " - " + tenVT + " || Tồn kho: " + (tonKho - SLxuat + SLrowOld).ToString("N0");
            }

            cls.Dispose();
            dt.Dispose();
        }

        public static DateTime mdaPrintNgayXuatKho;
        public static DataTable mdtPrint_ChiTietXuatKho;
        public static string msPrintSoChungTu, msPrintDienGiaig, msPrintThuKho, msPrintNguoiNhan, msPrintNguoiLap;
        
        //private void HienThi_Grid_ConTrol_Themmoi(double soluongxuat, int xxID_DMgapdan)
        //{
        //    clsDinhMuc_ChiTiet_DinhMuc_ToGapDan cls = new CtyTinLuong.clsDinhMuc_ChiTiet_DinhMuc_ToGapDan();
        //    DataTable dt = cls.SA_IDDM_W_SoLuong(soluongxuat,xxID_DMgapdan, dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year);
        //    gridControl1.DataSource = dt;          
        //    cls.Dispose();
        //    dt.Dispose();
        //}
       
        private void HienThi_Sua_XuatKho(int iiID_xuatkho_)
        {
            txtSoChungTu.Text = UC_DongKien_XuatCont_BenDaiLy._SoChungTu;
            dteNgayChungTu.EditValue = UC_DongKien_XuatCont_BenDaiLy._NgayThang;
            gridNguoiLap.EditValue = UC_DongKien_XuatCont_BenDaiLy._idNguoiLap;
            txtTenNguoiLap.Text =  UC_DongKien_XuatCont_BenDaiLy._TenNguoiLap;
            txtDienGiai.Text = UC_DongKien_XuatCont_BenDaiLy._DienGiai;


            clsThin cls1 = new clsThin();
            DataTable dt = cls1.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_S(UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien);
            gridControl1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                txtSoLuongTP.Text = (Convert.ToDecimal(dt.Compute("SUM(SoLuongXuat)", string.Empty))).ToString("N0");
                txtThanhTien.Text = (Convert.ToDecimal(dt.Compute("SUM(ThanhTien)", string.Empty))).ToString("N0");
            }

            cls1.Dispose();
            dt.Dispose();
        }

        private void HienThi_Copy(int iiID_xuatkho_)
        {
            txtSoChungTu.Text = CheckString.creatSoChungTuXuatContDK();
            dteNgayChungTu.EditValue = UC_DongKien_XuatCont_BenDaiLy._NgayThang;
            gridNguoiLap.EditValue = UC_DongKien_XuatCont_BenDaiLy._idNguoiLap;
            txtTenNguoiLap.Text = UC_DongKien_XuatCont_BenDaiLy._TenNguoiLap;
            txtDienGiai.Text = UC_DongKien_XuatCont_BenDaiLy._DienGiai;


            clsThin cls1 = new clsThin();
            DataTable dt = cls1.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_S(UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien);
            gridControl1.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                txtSoLuongTP.Text = (Convert.ToDecimal(dt.Compute("SUM(SoLuongXuat)", string.Empty))).ToString("N0");
                txtThanhTien.Text = (Convert.ToDecimal(dt.Compute("SUM(ThanhTien)", string.Empty))).ToString("N0");
            }

            cls1.Dispose();
            dt.Dispose();
        }
        private void HienThiThemMoi()
        {
            gridNguoiLap.EditValue = 12;
            dteNgayChungTu.EditValue = DateTime.Today;          
            txtSoChungTu.Text = CheckString.creatSoChungTuXuatContDK();
        }

        private void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dt = clsNguoi.T_SelectAll(4);
            gridNguoiLap.Properties.DataSource = dt;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";


            dt.Dispose();
            clsNguoi.Dispose();

            clsThin clsvt = new clsThin();
            _dtHangHoa = clsvt.Tr_DongKien_TbXuatKho_ChiTietXuatKho_SDL();

            searchMaVT.DataSource = _dtHangHoa;
            searchMaVT.ValueMember = "ID_VTHH";
            searchMaVT.DisplayMember = "MaVT";
            //Thay caption:
            searchMaVT.View.Columns.Clear();//xóa caption cũ
            searchMaVT.View.Columns.AddVisible("ID_VTHH", "ID");
            searchMaVT.View.Columns.AddVisible("MaVT", "Mã");
            searchMaVT.View.Columns.AddVisible("TenVTHH", "Tên");

            searchMaVT.View.Columns["ID_VTHH"].Visible = false;

            clsvt.Dispose();
        }
      
        private bool KiemTraLuu()
        {
           
            if (gridControl1.DataSource == null)
            {
                MessageBox.Show("chưa có hàng hoá");
                gridControl1.Focus();
                return false;
            }

            else if (dteNgayChungTu.Text.ToString() == "")
            {
                dteNgayChungTu.Focus();
                MessageBox.Show("Không để trống ngày chứng từ");
                return false;
            }
           
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số chứng từ ");
                txtSoChungTu.Focus();
                return false;
            }
            else if (gridNguoiLap.EditValue.ToString() == "")
            {
                MessageBox.Show("chưa có người lập");
                gridNguoiLap.Focus();
                return false;
            }
            else return true;

        }

        private void Luu_ChiTiet_XuatContDongKien(int id_XuatCont)
        {
            if (!KiemTraLuu()) return;
            else
            {
                DataTable dt = (DataTable)gridControl1.DataSource;

                clsDongKien_TbXuatKho_XuatContDL_ChiTiet cls2 = new clsDongKien_TbXuatKho_XuatContDL_ChiTiet();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cls2.iID_ChiTietXuatKho = Convert.ToInt32(dt.Rows[i]["ID_ChiTietXuatKho"].ToString());
                    cls2.iID_XuatContDongKien = id_XuatCont;
                    cls2.iID_VTHH = Convert.ToInt32(dt.Rows[i]["ID_VTHH"].ToString());

                    int ID_VTHH_ = Convert.ToInt32(dt.Rows[i]["ID_VTHH"].ToString());
                    cls2.fSoLuongXuat = CheckString.ConvertToDouble_My(dt.Rows[i]["SoLuongXuat"].ToString());
                    cls2.fDonGia = CheckString.ConvertToDouble_My(dt.Rows[i]["DonGia"].ToString());
                    cls2.fThanhTien = CheckString.ConvertToDouble_My(dt.Rows[i]["ThanhTien"].ToString());
                    cls2.sDienGiai = dt.Rows[i]["DienGiai"].ToString();

                    clsThin cls = new clsThin();
                    DataTable foundRows = cls.Tr_DongKien_TbXuatKho_XuatContDL_ChiTiet_ID_XuatCont_S(id_XuatCont, ID_VTHH_);
                    if (foundRows.Rows.Count > 0)
                    {
                        cls2.iID_ChiTietXuatKho = Convert.ToInt32(foundRows.Rows[0]["ID_ChiTietXuatKho"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }

                    cls.Dispose();
                }

                cls2.Dispose();
            }
        }


      
        private void Luu_XuatCont_DongKien()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDongKien_TbXuatKho_XuatContDL cls1 = new clsDongKien_TbXuatKho_XuatContDL();
                    cls1.daNgayThang = dteNgayChungTu.DateTime;
                    cls1.sSoChungTu = txtSoChungTu.Text;
                    cls1.sDienGiai = txtDienGiai.Text;
                    cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = false;
                    cls1.bDaXuatKho = true;
                    cls1.sGhiChu = "";
                    int iID_XuatContDongKien_;

                    if (UC_DongKien_XuatCont_BenDaiLy._mbThemMoi || UC_DongKien_XuatCont_BenDaiLy._mbCopy)
                    {
                        cls1.Insert();
                        iID_XuatContDongKien_ = cls1.iID_XuatContDongKien.Value;
                    }
                    else
                    {
                        cls1.iID_XuatContDongKien = UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien;
                        iID_XuatContDongKien_ = UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien;
                        cls1.Update();
                    }

                    Luu_ChiTiet_XuatContDongKien(iID_XuatContDongKien_);
                    cls1.Dispose();

                    //
                    this.Close();
                    _ucDLXKGD.UC_DongKien_XuatCont_BenDaiLy_Load(null, null);
                    MessageBox.Show("Đã lưu dữ liệ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể lưu dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        UC_DongKien_XuatCont_BenDaiLy _ucDLXKGD;
        public Tr_frmChiTietXuatContDongKien(UC_DongKien_XuatCont_BenDaiLy ucDLXKGD)
        {
            _ucDLXKGD = ucDLXKGD;
            InitializeComponent();

            //
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietXuatKho", typeof(int));
            dt2.Columns.Add("ID_XuatContDongKien", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuongXuat", typeof(string));
            dt2.Columns.Add("DonGia", typeof(string));
            dt2.Columns.Add("ThanhTien", typeof(string));
            dt2.Columns.Add("DienGiai", typeof(string));
            gridControl1.DataSource = dt2;
        }


        private void Tr_frmChiTietXuatContDongKien_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();

            if (UC_DongKien_XuatCont_BenDaiLy._mbThemMoi)
                HienThiThemMoi();
            else if (UC_DongKien_XuatCont_BenDaiLy._mbCopy)
                HienThi_Copy(UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien);
            else if (UC_DongKien_XuatCont_BenDaiLy._mbSua)
                HienThi_Sua_XuatKho(UC_DongKien_XuatCont_BenDaiLy._iID_XuatContDongKien);

            using (clsTr_MaHangToGD_DB_DK cls = new clsTr_MaHangToGD_DB_DK())
            {
                _dtDonGiatheoVTHH = cls.Tr_MaHangToGD_DB_DK_SelectBoPhan(dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year, KiemTraTenBoPhan("Đóng kiện"));
            }

            Cursor.Current = Cursors.Default;
        }
        
        private void btLuu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Luu_XuatCont_DongKien();
            Cursor.Current = Cursors.Default;
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
                ///*txtNguoiGiaoHang*/.Focus();
            }
        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmCaiMacDinnhMaHangTGD_DB_DK_ ff = new Tr_frmCaiMacDinnhMaHangTGD_DB_DK_(dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Year, "GapDan");
            ff.Show();
            Cursor.Current = Cursors.Default;
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
                txtTenNguoiLap.Text = clsncc.sTenNhanVien.Value;
                clsncc.Dispose();
            }
            catch
            {

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double getDonGiaTheoIDVHH(int idvthh)
        {
            double result = 0;

            for (int i = 0; i < _dtDonGiatheoVTHH.Rows.Count; i++)
            {
                if (idvthh == Convert.ToInt32(_dtDonGiatheoVTHH.Rows[i]["ID_VTHH"].ToString()))
                {
                    result = CheckString.ConvertToDouble_My(_dtDonGiatheoVTHH.Rows[i]["DonGia"].ToString());
                    break;
                }
            }
            return result;
        }

        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");
                }
            }
            return _id_bophan;
        }

        private string getTenCN(int idcn)
        {
            string result = "";

            //    for (int i = 0; i < _dtCongNhan.Rows.Count; i++)
            //    {
            //        if (idcn == Convert.ToInt32(_dtCongNhan.Rows[i]["ID_NhanSu"].ToString()))
            //        {
            //            result = _dtCongNhan.Rows[i]["TenNhanVien"].ToString();
            //            break;
            //        }
            //    }
            return result;
        }


        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column == ID_NhanSu)
        //    {
        //        if (_id_vthh == 0)
        //        {
        //            MessageBox.Show("Vui lòng chọn hàng hóa trước! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (e.Value == null && e.Value.ToString() == "") return;
        //        int id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
        //        int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //        double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));

        //        string tenCN = getTenCN(id_nhansu);
        //        //gridView1.SetRowCellValue(e.RowHandle, ID_NhanSu, id_nhansu);
        //        gridView1.SetRowCellValue(e.RowHandle, TenNhanVien, tenCN);

        //        ////
        //        //try
        //        //{
        //        //    using (clsThin clsThin_ = new clsThin())
        //        //    {
        //        //        if (id_ChamCong == 0)
        //        //        {
        //        //            if (checkIDCNisTonTai(id_nhansu))
        //        //            {
        //        //                MessageBox.Show("Không thể thêm công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
        //        //                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //                return;
        //        //            }

        //        //            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_I(
        //        //            id_nhansu,
        //        //            dteNgayChungTu.DateTime.Day,
        //        //            dteNgayChungTu.DateTime.Month,
        //        //            dteNgayChungTu.DateTime.Year,
        //        //            _id_vthh,
        //        //            (float)sanluong_,
        //        //            0, true, false, _id_bophan, 0, 1);
        //        //            LoadDataChamCongCN(_id_vthh);
        //        //        }
        //        //        else
        //        //        {
        //        //            if (checkIDCN_Update(id_ChamCong, id_nhansu)) return;
        //        //            else
        //        //            {
        //        //                if (checkIDCNisTonTai(id_nhansu))
        //        //                {
        //        //                    MessageBox.Show("Không thể chọn công nhân " + tenCN + ". Bởi vì " + tenCN + " đã tồn tại trong bộ phận này!",
        //        //                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //                    return;
        //        //                }
        //        //            }

        //        //            clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
        //        //            id_nhansu,
        //        //            dteNgayChungTu.DateTime.Day,
        //        //            dteNgayChungTu.DateTime.Month,
        //        //            dteNgayChungTu.DateTime.Year,
        //        //            _id_vthh,
        //        //            (float)sanluong_,
        //        //            0, true, false, _id_bophan, 0, 1,
        //        //            id_ChamCong);
        //        //        }
        //        //    }
        //        //}
        //        //catch
        //        //{
        //        //    MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + tenCN
        //        //        + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //}
        //    }
        //    else if (e.Column == SanLuong)
        //    {
        //        if (_id_vthh == 0)
        //        {
        //            MessageBox.Show("Vui lòng chọn hàng hóa trước! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (e.Value != null && e.Value.ToString() != "" && !(gridView4.GetRowCellValue(e.RowHandle, ID_NhanSu) is DBNull))
        //        {
        //            int ID_ChiTietChamCong_ToGapDan_ = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //            int id_nhansu;
        //            try
        //            {
        //                id_nhansu = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_NhanSu));
        //            }
        //            catch
        //            {
        //                return;
        //            }

        //            int id_ChamCong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, ID_ChiTietChamCong_ToGapDan));
        //            double dongia = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, DonGia));
        //            double sanluong_ = CheckString.ConvertToDouble_My(gridView1.GetRowCellValue(e.RowHandle, SanLuong));

        //            //
        //            gridView1.SetRowCellValue(e.RowHandle, ThanhTien, sanluong_* dongia);

        //            if (ID_ChiTietChamCong_ToGapDan_ == 0)
        //                tinhTongSL(sanluong_);
        //            else
        //                tinhTongSL(0);

        //            ////
        //            //try
        //            //{
        //            //    using (clsThin clsThin_ = new clsThin())
        //            //    {
        //            //        clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_U(
        //            //        id_nhansu,
        //            //        dteNgayChungTu.DateTime.Day,
        //            //        dteNgayChungTu.DateTime.Month,
        //            //        dteNgayChungTu.DateTime.Year,
        //            //        _id_vthh,
        //            //        (float)sanluong_,
        //            //        0, true, false, _id_bophan, 0, 1,
        //            //        id_ChamCong);
        //            //    }
        //            //}
        //            //catch
        //            //{
        //            //    MessageBox.Show("Không thể đồng bộ dữ liệu công nhân " + getTenCN(id_nhansu)
        //            //        + ". Kiểm tra lại kết nối!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //}
        //        }
        //    }
        //}

        private void tinhTongSL(double tongSLIn, double tongTienIn)
        {
            double TongSL = tongSLIn;
            double TongTien = tongTienIn;

            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                TongSL += CheckString.ConvertToDouble_My(this.gridView1.GetRowCellValue(i, "SoLuongXuat"));
                TongTien += CheckString.ConvertToDouble_My(this.gridView1.GetRowCellValue(i, "ThanhTien"));
            }

            txtSoLuongTP.Text = TongSL.ToString("N0");
            txtThanhTien.Text = TongTien.ToString("N0");
        }


        private void btnXoaGridv1_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;

                //if (gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan) == null
                //    ||gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "" 
                //    || gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString() == "0")
                //{
                //    return;
                //}

                ////int id_cn = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_NhanSu).ToString());
                //int ID_ChiTietChamCong_TGD = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietChamCong_ToGapDan).ToString());

                //DialogResult traloi;
                //traloi = MessageBox.Show("Xác nhận xóa công nhân: " + gridView1.GetFocusedRowCellValue(TenNhanVien).ToString(), "Delete",
                //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (traloi == DialogResult.Yes)
                //{
                //    using (clsThin clsThin_ = new clsThin())
                //    {
                //        if(clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_Delete(ID_ChiTietChamCong_TGD))
                //        {
                //            LoadDataChamCongCN(_id_vthh);
                //        }
                //    }

                //}

                //Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Lỗi xóa công nhân khỏi bảng..." + ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == ID_VTHH)
            {
                int idvthh = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = idvthh;
                int kk = Convert.ToInt16(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, ID_ChiTietXuatKho, 0);
                    string ss = dt.Rows[0]["TenVTHH"].ToString();
                    gridView1.SetRowCellValue(e.RowHandle, TenVTHH, dt.Rows[0]["TenVTHH"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, DonViTinh, dt.Rows[0]["DonViTinh"].ToString());
                    gridView1.SetRowCellValue(e.RowHandle, SoLuongXuat, 0);
                    gridView1.SetRowCellValue(e.RowHandle, DonGia, getDonGiaTheoIDVHH(idvthh).ToString("N0"));
                    gridView1.SetRowCellValue(e.RowHandle, ThanhTien, 0);

                    Hienthi_Lable_TonKho(idvthh, 0, 0);
                }
            }

            try
            {
                double fffsoluong = 0;
                double ffdongia = 0;
                double fffthanhtien = 0;
                if (e.Column == SoLuongXuat)
                {
                    int idvthh = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_VTHH));

                    if (gridView1.GetFocusedRowCellValue(DonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(DonGia));
                    if (gridView1.GetFocusedRowCellValue(SoLuongXuat).ToString() == "")
                        fffsoluong = 0;
                    fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(SoLuongXuat));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(ThanhTien, fffthanhtien.ToString("N0"));

                    if (!UC_DongKien_XuatCont_BenDaiLy._mbSua && !UC_DongKien_XuatCont_BenDaiLy._mbCopy)
                        tinhTongSL(fffsoluong, fffthanhtien);
                    else
                        tinhTongSL(0, 0);

                    double SLrow_old = 0;

                    if (Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietXuatKho)) > 0)
                    {
                        clsDongKien_TbXuatKho_XuatContDL_ChiTiet cl = new clsDongKien_TbXuatKho_XuatContDL_ChiTiet();
                        cl.iID_ChiTietXuatKho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietXuatKho));
                        DataTable dt = cl.SelectOne();

                        if (dt.Rows.Count > 0)
                            SLrow_old = CheckString.ConvertToDouble_My(dt.Rows[0]["SoLuongXuat"].ToString());
                    }

                    if (Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_ChiTietXuatKho)) == 0)
                        Hienthi_Lable_TonKho(idvthh, fffsoluong, 0);
                    else
                        Hienthi_Lable_TonKho(idvthh, fffsoluong, SLrow_old);

                }
                if (e.Column == DonGia)
                {
                    if (gridView1.GetFocusedRowCellValue(DonGia).ToString() == "")
                        ffdongia = 0;
                    else
                        ffdongia = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(DonGia));
                    if (gridView1.GetFocusedRowCellValue(SoLuongXuat).ToString() == "")
                        fffsoluong = 0;
                    else
                        fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(SoLuongXuat));
                    fffthanhtien = fffsoluong * ffdongia;
                    gridView1.SetFocusedRowCellValue(ThanhTien, fffthanhtien);
                }
            }
            catch
            {

            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView1_RowClick_1(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(ID_VTHH) == null
                || gridView1.GetFocusedRowCellValue(ID_VTHH).ToString() == ""
                || gridView1.GetFocusedRowCellValue(ID_VTHH).ToString() == "0")
            {
                return;
            }

            if (gridView1.GetFocusedRowCellValue(ID_VTHH).ToString() != "")
            {
                int idvthh = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_VTHH).ToString());
                double fffsoluong = CheckString.ConvertToDouble_My(gridView1.GetFocusedRowCellValue(SoLuongXuat));
                if (UC_DongKien_XuatCont_BenDaiLy._mbThemMoi)
                    Hienthi_Lable_TonKho(idvthh, fffsoluong, 0);
                else
                    Hienthi_Lable_TonKho(idvthh, 0, 0);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGiaTP_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                //Hienthi_thanhTien_thanhpham();
                //decimal value = decimal.Parse(txtDonGiaTP.Text);
                //txtDonGiaTP.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtThanhTien.Text);
                //txtThanhTien.Text = String.Format("{0:#,##0.00}", value);
            }
            catch
            {

            }
        }


        private bool checkIDCNisTonTai(int idcn)
        {
            bool result = false;


            //using (clsThin clsThin_ = new clsThin())
            //{
            //    DataTable dt3 = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(dteNgayChungTu.DateTime.Year,
            //            dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Day, _id_bophan, _id_vthh, "");

            //    for (int i = 0; i < dt3.Rows.Count; i++)
            //    {
            //        if (idcn == Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString()))
            //        {
            //            result = true;
            //            break;
            //        }
            //    }
            //}

            return result;
        }

        private bool checkIDCN_Update(int ID_ChamCong, int idcn)
        {
            bool result = false;

            //using (clsThin clsThin_ = new clsThin())
            //{
            //    DataTable dt3 = clsThin_.Tr_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_SelectTGD(dteNgayChungTu.DateTime.Year,
            //            dteNgayChungTu.DateTime.Month, dteNgayChungTu.DateTime.Day, _id_bophan, _id_vthh, "");

            //    for (int i = 0; i < dt3.Rows.Count; i++)
            //    {
            //        if (ID_ChamCong == Convert.ToInt32(dt3.Rows[i]["ID_ChiTietChamCong_ToGapDan"].ToString()) && idcn == Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString()))
            //        {
            //            result = true;
            //            break;
            //        }
            //    }
            //}

            return result;
        }

    }
}
