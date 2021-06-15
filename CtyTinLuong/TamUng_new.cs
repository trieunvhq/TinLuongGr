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
    public partial class TamUng_new : Form
    {
        int bienthangthai = 0;
        DataTable dtdoituong = new DataTable();

        public string HienThiSoChungTu()
        {
            string sochungtuThuChi="";
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SelectAll();
            if (bienthangthai == 1)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    sochungtuThuChi = "BC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    sochungtuThuChi = "BC " + xxx2 + "";
                }
              
            }

            else if (bienthangthai == 2)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    sochungtuThuChi = "BN 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    sochungtuThuChi = "BN " + xxx2 + "";
                }
              
            }

            else if (bienthangthai == 3)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    sochungtuThuChi = "PC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    sochungtuThuChi = "PC " + xxx2 + "";
                }
               
            }
            else if (bienthangthai == 4)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    sochungtuThuChi = "PT 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    sochungtuThuChi = "PT " + xxx2 + "";
                }
                
            }
            return sochungtuThuChi;
        }
        private void Load_LockUp_DoiTuong()
        {
            dtdoituong.Clear();

            if (checkCongNhanVien.Checked == true) // Khác
            {
                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dtdoituong.NewRow();
                    _ravi["ID_DoiTuong"] = Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString());
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["MaNhanVien"].ToString();
                    _ravi["TenDoiTuong"] = dt3.Rows[i]["TenNhanVien"].ToString();
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            }
            if (checkDaiLy.Checked == true) // Khác
            {
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                DataTable dt = cls.SelectAll();
                dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dtdoituong.NewRow();
                    _ravi["ID_DoiTuong"] = Convert.ToInt32(dt3.Rows[i]["ID_DaiLy"].ToString());
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["MaDaiLy"].ToString();
                    _ravi["TenDoiTuong"] = dt3.Rows[i]["TenDaiLy"].ToString();                 
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

            }
           

        }

        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 11;
            checkPhieuChi.Checked = true;
            checkCongNhanVien.Checked = true;
            clsTamUng_New      cls = new CtyTinLuong.clsTamUng_New();
            DataTable dtthuchi = cls.SelectAll();
            dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvthuchi = dtthuchi.DefaultView;
            DataTable dvthuchi3 = dvthuchi.ToTable();
            int k = dvthuchi3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "TU 1";
            else
            {
                string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;               
                txtSoChungTu.Text = "TU " + xxx2 + "";
            }

            string thang = DateTime.Today.ToString("MM");
            string nam = DateTime.Today.ToString("yyyy");
            dteNgayChungTu.DateTime = DateTime.Today;
            txtNam.Text = nam;
            txtThang.Text = thang;

        }
        private void HienThi_Sua(int iiDI_tamung)
        {
            clsTamUng_New cls = new CtyTinLuong.clsTamUng_New();
            cls.iID_TamUng = iiDI_tamung;
            DataTable dt = cls.SelectOne();
            if (dt.Rows.Count > 0)
            {               
                gridDoiTuong.EditValue = cls.iID_DoiTuong.Value;
                txtSoChungTu.Text = cls.sSoChungTu.Value;
                dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
                gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
                txtThang.Text = cls.iKhauTruLuongThang.Value.ToString();
                txtNam.Text = cls.iKhauTruLuongThang_Nam.Value.ToString();
                txtDienGiai.Text = cls.sDienGiai.Value;
                txtSoTienTamUng.Text = cls.fTongSoTien.Value.ToString();
                txtGhiChu.Text = cls.sGhiChu.Value;
            }
            clsTamUng_ChiTietTamUng cls2 = new clsTamUng_ChiTietTamUng();
            cls2.iID_TamUng = iiDI_tamung;
            //DataTable dtchitiet=cls2.SelectAll
            gridControl2.DataSource = null;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietBienDongTaiKhoan", typeof(int));
            dt2xx.Columns.Add("ID_ChungTu", typeof(int));
            dt2xx.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2xx.Columns.Add("No", typeof(double));
            dt2xx.Columns.Add("Co", typeof(double));
            dt2xx.Columns.Add("TienUSD", typeof(bool));
            dt2xx.Columns.Add("TiGia", typeof(double));
            dt2xx.Columns.Add("DaGhiSo", typeof(bool));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("SoTaiKhoanCon");
            dt2xx.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));
            //DataRow _ravi = dt2xx.NewRow();
            //_ravi["TienUSD"] = checkUSD.Checked;
            //_ravi["TiGia"] = 1;
            //_ravi["DaGhiSo"] = false;
            //_ravi["GhiChu"] = "";
            //_ravi["SoTaiKhoanCon"] = ID_TaiKhoanKeToanCon.ToString();
            //_ravi["TenTaiKhoanCon"] = dtcon.Rows[0]["TenTaiKhoanCon"].ToString();
            //_ravi["HienThi"] = "1";
            //dt2xx.Rows.Add(_ravi);
           
        }
        public TamUng_new()
        {
            InitializeComponent();
        }

        private void TamUng_new_Load(object sender, EventArgs e)
        {
            Load_LockUp_DoiTuong();
            if (UCLuong_TamUng.mbThemMoiTamUng == true)
                HienThi_ThemMoi();
            else HienThi_Sua(UCLuong_TamUng.miiiiID_TamUng);

        }


        private void checkDaiLy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDaiLy.Checked == true)
            {
                checkCongNhanVien.Checked = false;
                Load_LockUp_DoiTuong();
            }
        }

        private void checkCongNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCongNhanVien.Checked == true)
            {
                checkDaiLy.Checked = false;
                Load_LockUp_DoiTuong();
            }
        }

        private void checkPhieuChi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPhieuChi.Checked == true)
            {
                bienthangthai = 3;
                checkBaoNo.Checked = false;
            }
        }

        private void checkBaoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBaoNo.Checked == true)
            {
                bienthangthai = 2;
                checkPhieuChi.Checked = false;
            }
        }

        private void txtSoTienTamUng_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value = decimal.Parse(txtSoTienTamUng.Text);
                txtSoTienTamUng.Text = String.Format("{0:#,##0.00}", value);
               
            }
            catch
            {

            }
        }
    }
}
