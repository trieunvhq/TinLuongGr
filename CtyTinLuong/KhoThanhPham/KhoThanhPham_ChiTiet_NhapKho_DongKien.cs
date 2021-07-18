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
    public partial class KhoThanhPham_ChiTiet_NhapKho_DongKien : Form
    {
        public static bool mbPrint;
        public static DateTime mdaNgayChungTu;
        public static DataTable mdtPrint;
        public static string msSoChungTu, msNguoiGiaoHang, msDienGiai, msGhiChu;
        public static double mdbTongSotien;

        private void HienThi_Sua()
        {
            clsKhoThanhPham_tbNhapKho cls1 = new clsKhoThanhPham_tbNhapKho();
            cls1.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_Khac.miID_NhapKho;
            DataTable dt = cls1.SelectOne();
            gridNguoiLap.EditValue = cls1.iID_NguoiNhap.Value;
            dteNgayChungTu.EditValue = cls1.daNgayChungTu.Value;
            txtSoChungTu.Text = cls1.sSoChungTu.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value;
            txtGhiChu.Text = cls1.sGhiChu.Value;
            txtThamChieu.Text = cls1.sThamChieu.Value;
            txtNguoiGiaohang.Text = cls1.sNguoiGiaoHang.Value;
            if (dt.Rows[0]["ID_DaiLy"].ToString() != "")
                gridMaDaiLy.EditValue = cls1.iID_DaiLy.Value;

            clsKhoThanhPham_tbChiTietNhapKho cls2 = new clsKhoThanhPham_tbChiTietNhapKho();
            cls2.iID_NhapKho_ThanhPham = UCThanhPham_NhapKho_Khac.miID_NhapKho;
            DataTable dtxx = cls2.Select_ALL_W_ID_NhapKho_ThanhPham();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuongNhap", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            for (int i = 0; i < dtxx.Rows.Count; i++)
            {
                double dongiaxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["DonGia"].ToString());
                double SoLuongxxx333 = CheckString.ConvertToDouble_My(dtxx.Rows[i]["SoLuongNhap"].ToString());
                int ID_VTHHxxx = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = ID_VTHHxxx;
                DataTable dtvt = clsvt.SelectOne();
                DataRow _ravi3 = dt2.NewRow();

                _ravi3["ID_VTHH"] = Convert.ToInt16(dtxx.Rows[i]["ID_VTHH"].ToString());
                _ravi3["MaVT"] = ID_VTHHxxx;
                _ravi3["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi3["DonViTinh"] = clsvt.sDonViTinh.Value;
                _ravi3["SoLuongNhap"] = SoLuongxxx333;
                _ravi3["DonGia"] = dongiaxxx333;// lay kho NPL
                _ravi3["GhiChu"] = dtxx.Rows[i]["GhiChu"].ToString();
                _ravi3["HienThi"] = "1";
                _ravi3["ThanhTien"] = SoLuongxxx333 * dongiaxxx333;
                dt2.Rows.Add(_ravi3);

            }
            gridControl1.DataSource = dt2;
            double deTOngtien;
            string shienthi = "1";
            object xxxx = dt2.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
            else deTOngtien = 0;
            txtTongTienHang.Text = deTOngtien.ToString();

        }
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 14;
            dteNgayChungTu.EditValue = DateTime.Today;

            Load_SoChungYu_CoPy();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH");
            dt2.Columns.Add("SoLuongNhap", typeof(float));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("MaVT");// tb VTHH
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("GhiChu", typeof(string));
            gridControl1.DataSource = dt2;
        }

        private void KhoThanhPham_ChiTiet_NhapKho_DongKien_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Load_LockUp();
            if (UCThanhPham_NhapKho_Khac.mbThemMoi_NhapKho == true)
                HienThi_ThemMoi();
            else HienThi_Sua();
            Cursor.Current = Cursors.Default;
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



            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridMaDaiLy.Properties.DataSource = dtxx;
            gridMaDaiLy.Properties.ValueMember = "ID_DaiLy";
            gridMaDaiLy.Properties.DisplayMember = "MaDaiLy";

        }
        public KhoThanhPham_ChiTiet_NhapKho_DongKien()
        {
            InitializeComponent();
        }

        private void btThoat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
