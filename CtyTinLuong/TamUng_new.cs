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
        DataTable dtdoituong = new DataTable();
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
            //gridNguoiLap.EditValue = 11;
            //clsDaiLy_TamUng cls = new CtyTinLuong.clsDaiLy_TamUng();
            //DataTable dtthuchi = cls.SelectAll();
            //dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            //DataView dvthuchi = dtthuchi.DefaultView;
            //DataTable dvthuchi3 = dvthuchi.ToTable();
            //int k = dvthuchi3.Rows.Count;
            //if (k == 0)
            //    txtSoChungTu.Text = "TU 1";
            //else
            //{
            //    string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
            //    int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
            //    if (xxx2 >= 10000)
            //        txtSoChungTu.Text = "TU 1";
            //    else txtSoChungTu.Text = "TU " + xxx2 + "";
            //}

            //string thang = DateTime.Today.ToString("MM");
            //string nam = DateTime.Today.ToString("yyyy");
            //dteNgayChungTu.DateTime = DateTime.Today;
            //txtNam.Text = nam;
            //txtThang.Text = thang;

        }
        private void HienThi_Sua()
        {
            //clsDaiLy_TamUng cls = new CtyTinLuong.clsDaiLy_TamUng();
            //cls.iID_TamUng = UCDaiLy_TamUng.miiiiID_TamUng;
            //DataTable dt = cls.SelectOne();
            //if (dt.Rows.Count > 0)
            //{
            //    if (cls.bGuiDuLieu.Value == true)
            //    {
            //        btLuu_Copy.Enabled = false;
            //        btLuu_Dong.Enabled = false;
            //        btLuu_Gui_Copy.Enabled = false;
            //        btLuu_Gui_Dong.Enabled = false;
            //    }
            //    gridMaDaiLy.EditValue = cls.iID_DaiLy.Value;

            //    txtSoChungTu.Text = cls.sSoChungTu.Value;
            //    dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            //    gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            //    txtThang.Text = cls.iKhauTruLuongThang.Value.ToString();
            //    txtNam.Text = cls.iKhauTruLuongThang_Nam.Value.ToString();

            //    txtDienGiai.Text = cls.sDienGiai.Value;
            //    txtSoTienTamUng.Text = cls.dcSoTien.Value.ToString();

            //}
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
            else HienThi_Sua();

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
    }
}
