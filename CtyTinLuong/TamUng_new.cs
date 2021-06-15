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
        public TamUng_new()
        {
            InitializeComponent();
        }

        private void TamUng_new_Load(object sender, EventArgs e)
        {
            Load_LockUp_DoiTuong();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
