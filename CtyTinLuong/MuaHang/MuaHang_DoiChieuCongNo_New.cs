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
    public partial class MuaHang_DoiChieuCongNo_New : Form
    {
        DataTable _data;
        public static bool isChiTiet_thuchi = false;
        public static int miID_ChungTu, mibientrangthai;
        private void Load_lockUp()
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.Select_DISTINCT_W_ID_TaiKhoanKeToanCon_COngNo_MuaHang_Select_DISTINCT();
            GridSoTaiKhoan.Properties.DataSource = dt;
            GridSoTaiKhoan.Properties.DisplayMember = "SoTaiKhoanCon";
            GridSoTaiKhoan.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
        }
        public void LoadData(int iiID_Con, DateTime xxtungay, DateTime xxdenngay)
        {
            DataTable dt2xxxx = new DataTable();
            dt2xxxx.Columns.Add("HienThi", typeof(string));
            dt2xxxx.Columns.Add("STT", typeof(string));
            dt2xxxx.Columns.Add("NgayThang", typeof(string));
            dt2xxxx.Columns.Add("SoChungTu", typeof(string));
            dt2xxxx.Columns.Add("DienGiai", typeof(string));
            dt2xxxx.Columns.Add("No", typeof(double));
            dt2xxxx.Columns.Add("Co", typeof(double));
            dt2xxxx.Columns.Add("SoLuong", typeof(double));
            dt2xxxx.Columns.Add("DonGia", typeof(double));
            dt2xxxx.Columns.Add("ThanhTien", typeof(double));
            dt2xxxx.Columns.Add("ID_ChungTu", typeof(string));
            //TK_DoiUng
            gridControl2.DataSource = null;

            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dtdudau = cls.Sum_Co_No_W_ID_Con_NgayThang_Du_Dau_HUU(iiID_Con, xxtungay);
            DataTable dtphatsinh = cls.Sum_Co_No_W_ID_Con_NgayThang_PhatSinh_HUU(iiID_Con, xxtungay, xxdenngay);
            double dNoDauKy_0, dCoDauKy_0;
            if (dtdudau.Rows.Count > 0)
            {
                dNoDauKy_0 = CheckString.ConvertToDouble_My(dtdudau.Rows[0]["NoDauKy"].ToString());
                dCoDauKy_0 = CheckString.ConvertToDouble_My(dtdudau.Rows[0]["CoDauKy"].ToString());
            }
            else
            {
                dNoDauKy_0 = dCoDauKy_0 = 0;
            }

            double No_Co_Khong = Math.Abs(dCoDauKy_0 - dNoDauKy_0);
            DataRow _ravi_Khong = dt2xxxx.NewRow();
            _ravi_Khong["DienGiai"] = "Dư đầu kỳ";
            _ravi_Khong["HienThi"] = false;
            if (dNoDauKy_0 <= dCoDauKy_0)
            {
                _ravi_Khong["No"] = 0;
                _ravi_Khong["Co"] = No_Co_Khong;
            }
            else
            {
                _ravi_Khong["No"] = No_Co_Khong;
                _ravi_Khong["Co"] = 0;
            }
            dt2xxxx.Rows.Add(_ravi_Khong);

            //double Nophatsinh = dNoDauKy_0;
            //double Cophatsinh = dCoDauKy_0;

            if (dtphatsinh.Rows.Count > 0)
            {

                for (int i = 0; i < dtphatsinh.Rows.Count; i++)
                {
                    bool isTraHang;
                    DataRow _ravi = dt2xxxx.NewRow();
                    if (Convert.ToBoolean(dtphatsinh.Rows[i]["Check_PhanNganHang"].ToString()) == true)
                    {
                        _ravi["ID_ChungTu"] = dtphatsinh.Rows[i]["ID_ChungTu"].ToString();
                    }
                       
                    _ravi["STT"] = (i + 1).ToString();                   
                    DateTime ngay = Convert.ToDateTime(dtphatsinh.Rows[i]["NgayThang"].ToString());
                    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");
                    _ravi["DienGiai"] = dtphatsinh.Rows[i]["DienGiai"].ToString();
                    _ravi["SoChungTu"] = dtphatsinh.Rows[i]["SoChungTu"].ToString();
                    double Noxx_hang = CheckString.ConvertToDouble_My(dtphatsinh.Rows[i]["No"].ToString());
                    double Coxx_hang = CheckString.ConvertToDouble_My(dtphatsinh.Rows[i]["Co"].ToString());
                    if (string.IsNullOrEmpty(dtphatsinh.Rows[i]["CheckTraLaiNhaCungCap"].ToString()))
                        isTraHang = false;
                    else
                        isTraHang = Convert.ToBoolean(dtphatsinh.Rows[i]["CheckTraLaiNhaCungCap"].ToString());

                    _ravi["No"] = Noxx_hang;
                    _ravi["Co"] = Coxx_hang;

                    //if (isTraHang)
                    //{
                    //    Nophatsinh -= Noxx_hang;
                    //    Cophatsinh -= Coxx_hang;
                    //}
                    //else
                    //{
                    //    Nophatsinh += Noxx_hang;
                    //    Cophatsinh += Coxx_hang;
                    //}


                    dt2xxxx.Rows.Add(_ravi);

                    if (dtphatsinh.Rows[i]["ID_ChungTu"].ToString() != "" & Convert.ToBoolean(dtphatsinh.Rows[i]["Check_PhanNganHang"].ToString()) == false)
                    {
                        clsMH_tbChiTietMuaHang cls2 = new clsMH_tbChiTietMuaHang();
                        cls2.iID_MuaHang = Convert.ToInt32(dtphatsinh.Rows[i]["ID_ChungTu"].ToString());
                        DataTable dt3 = cls2.SelectAll_W_ID_MuaHang_MaVT_TenVT();
                        if (dt3.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt3.Rows.Count; k++)
                            {
                                Decimal xxsoluong = CheckString.ConvertToDecimal_My(dt3.Rows[k]["SoLuong"].ToString());
                                Decimal xxdongia = CheckString.ConvertToDecimal_My(dt3.Rows[k]["DonGia"].ToString());
                                DataRow _ravi_con = dt2xxxx.NewRow();
                                _ravi_con["SoLuong"] = xxsoluong;
                                _ravi_con["DonGia"] = xxdongia;

                                _ravi_con["DienGiai"] = dt3.Rows[k]["TenVTHH"].ToString();
                                _ravi_con["ThanhTien"] = CheckString.ConvertToDecimal_My(xxsoluong * xxdongia);
                                //_ravi_con["NgayThang"] = dt3.Rows[k]["SoCongTeNo"].ToString();
                                //_ravi_con["DoiTuong"] = dt3.Rows[k]["SoChungTu"].ToString();
                                dt2xxxx.Rows.Add(_ravi_con);
                            }
                        }
                    }

                }
            }
            double Nophatsinh = CheckString.ConvertToDouble_My(dtphatsinh.Compute("sum(No)", "TonTai=True"));
            double Cophatsinh = CheckString.ConvertToDouble_My(dtphatsinh.Compute("sum(Co)", "TonTai=True"));
            DataRow _ravi_2 = dt2xxxx.NewRow();
            _ravi_2["DienGiai"] = "Cộng phát sinh trong kỳ";
            _ravi_2["HienThi"] = false;

            _ravi_2["No"] = Nophatsinh;
            _ravi_2["Co"] = Cophatsinh;

            dt2xxxx.Rows.Add(_ravi_2);
            gridControl2.DataSource = dt2xxxx;

            DataRow _ravi_cuoi = dt2xxxx.NewRow();
            _ravi_cuoi["DienGiai"] = "Dư cuối kỳ";
            _ravi_cuoi["HienThi"] = false;

            double nocuoiky = Nophatsinh + dNoDauKy_0;
            double cocuoiky = Cophatsinh + dCoDauKy_0;
            double No_Co_cuoi = Math.Abs(nocuoiky - cocuoiky);
            if (nocuoiky <= cocuoiky)
            {
                _ravi_cuoi["No"] = 0;
                _ravi_cuoi["Co"] = No_Co_cuoi;
            }
            else
            {
                _ravi_cuoi["No"] = No_Co_cuoi;
                _ravi_cuoi["Co"] = 0;
            }

            dt2xxxx.Rows.Add(_ravi_cuoi);
            _data = dt2xxxx;
            gridControl2.DataSource = dt2xxxx;
        }
        public MuaHang_DoiChieuCongNo_New()
        {
            InitializeComponent();
        }

        private void MuaHang_DoiChieuCongNo_New_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_lockUp();
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            //GridSoTaiKhoan.EditValue = BanHang_CongNo.miiiID_TaiKhoanKeToanCon;
            dteTuNgay.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null & GridSoTaiKhoan.EditValue != null)
            {
                int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void GridSoTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            cls.iID_TaiKhoanKeToanCon = xxid;
            DataTable dt = cls.SelectOne();
            txtTenTK.Text = cls.sTenTaiKhoanCon.Value;
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null)
            {
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MuaHang_DoiChieuCongNo_New_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null & GridSoTaiKhoan.EditValue != null)
            {
                string doiTuong = "Đối tượng: " + txtTenTK.Text + " (" + GridSoTaiKhoan.EditValue.ToString() + ")";
                string taiKhoan = "Tài khoản: Phải trả cho người bán " + "(" + GridSoTaiKhoan.Text + ")";
                Tr_frmPrint_DoiChieuCongNo_NCC ff = new Tr_frmPrint_DoiChieuCongNo_NCC(dteTuNgay.DateTime,
                            dteDenNgay.DateTime, _data, taiKhoan, doiTuong);
                ff.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo");
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void GridSoTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtTenTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_ChungTu).ToString()!="")
            {
                miID_ChungTu = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ChungTu).ToString());
                clsNganHang_tbThuChi cls = new clsNganHang_tbThuChi();
                cls.iID_ThuChi = miID_ChungTu;
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    isChiTiet_thuchi = true;
                    UCQuy_NganHang_BaoCo.isChiTiet_thuchi = false;
                    frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.isChiTiet_thuchi = false;
                    BanHang_DoiChieu_CongNo_new.isChiTiet_thuchi = false;
                    mibientrangthai = cls.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5.Value;
                    Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww ff = new Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww();
                    ff.Show();
                }
            }
           
        }

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null & GridSoTaiKhoan.EditValue != null)
            {
                int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            if (dteTuNgay.DateTime != null & dteDenNgay.DateTime != null & GridSoTaiKhoan.EditValue != null)
            {
                int xxid = Convert.ToInt32(GridSoTaiKhoan.EditValue.ToString());
                LoadData(xxid, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void GridSoTaiKhoan_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridSoTaiKhoan.Properties.View.Columns[0].Visible = false;
        }
    }
}
