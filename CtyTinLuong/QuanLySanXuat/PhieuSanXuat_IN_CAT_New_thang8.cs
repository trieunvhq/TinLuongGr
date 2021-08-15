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
    public partial class PhieuSanXuat_IN_CAT_New_thang8 : Form
    {
        private int _SoTrang = 1;
        private int _SoDong = 25;
        private int _Loaimay = 1;
        private bool isload = false;
        public void LoadData(int sotrang, int sodong, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay, int xxid_loaiMay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            _SoDong = sodong;
            DataTable dt2 = new DataTable();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            if (xxid_loaiMay == 1)
                dt2 = cls.H_load_Phieu_T8_ngaythang_IN(sotrang, _SoDong, xxtungay, xxdenngay);
            else if (xxid_loaiMay ==2)
                dt2 = cls.H_load_Phieu_T8_ngaythang_CAT(sotrang, _SoDong, xxtungay, xxdenngay);
            else if (xxid_loaiMay == 3)
                dt2 = cls.H_load_Phieu_T8_ngaythang_DOT(sotrang, _SoDong, xxtungay, xxdenngay);
            gridControl1.DataSource = dt2;

            isload = false;
        }
        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            int sodong_ = 25;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                sodong_ = Convert.ToInt32(txtSoDong.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";

                sodong_ = 1;
                txtSoDong.Text = "25";
            }
            int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
            LoadData(sotrang_, sodong_, true, dteTuNgay.DateTime, dteDenNgay.DateTime, xxid);
        }
        public void ResetSoTrang(int xxsodong,DateTime xxtungay, DateTime xxdenngay, int xxid_loaiMay)
        {

            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
            {
                DataTable dt_ = new DataTable();
                if (xxid_loaiMay == 1)
                    dt_ = cls.H_Tinh_SoPhieu_T8_IN(xxtungay, xxdenngay);
                else if (xxid_loaiMay == 2)
                    dt_ = cls.H_Tinh_SoPhieu_T8_CAT(xxtungay, xxdenngay);
                else if (xxid_loaiMay == 3)
                    dt_ = cls.H_Tinh_SoPhieu_T8_DOT(xxtungay, xxdenngay);
              
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(CheckString.ConvertToDouble_My(dt_.Rows[0]["tongso"].ToString()) / (double)xxsodong)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        private void Load_LockUp(int iiID_loaimay)
        {
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataSet dtset = cls.H_LockUp_PhieuSanXuat_thang8();                   

            gridMaVT_Vao.DataSource = dtset.Tables[4];
            gridMaVT_Vao.ValueMember = "ID_VTHH";
            gridMaVT_Vao.DisplayMember = "MaVT";

            gridMaVT_Ra.DataSource = dtset.Tables[4];
            gridMaVT_Ra.ValueMember = "ID_VTHH";
            gridMaVT_Ra.DisplayMember = "MaVT";


            gridDMLuong.DataSource = dtset.Tables[8];
            gridDMLuong.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            gridDMLuong.DisplayMember = "MaDinhMuc";

            gridCaTruong.DataSource = dtset.Tables[0];
            gridCaTruong.ValueMember = "ID_NhanSu";
            gridCaTruong.DisplayMember = "MaNhanVien";

            if (iiID_loaimay==1) // máy in
            {
                gridCongNhan.DataSource = dtset.Tables[1];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";               

                gridMaMay.DataSource = dtset.Tables[5];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }

            if (iiID_loaimay == 2) // máy cắt
            {
                gridCongNhan.DataSource = dtset.Tables[2];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";

            
                gridMaMay.DataSource = dtset.Tables[6];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }
            if (iiID_loaimay == 3) // máy đột
            {
                gridCongNhan.DataSource = dtset.Tables[3];
                gridCongNhan.ValueMember = "ID_NhanSu";
                gridCongNhan.DisplayMember = "TenNhanVien";

                gridMaMay.DataSource = dtset.Tables[7];
                gridMaMay.ValueMember = "ID_May";
                gridMaMay.DisplayMember = "TenMay";
            }

            cls.Dispose();
        }
        public PhieuSanXuat_IN_CAT_New_thang8()
        {
            InitializeComponent();
        }

        private void PhieuSanXuat_IN_CAT_New_thang8_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("loaimay", typeof(String));
            DataRow row1 = dt.NewRow();
            row1["id"] = 1;
            row1["loaimay"] = "Máy In";
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["id"] = 2;
            row2["loaimay"] = "Máy Cắt";
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["id"] = 3;
            row3["loaimay"] = "Máy Đột";
            dt.Rows.Add(row3);


            gridLoaiMay.Properties.DataSource = dt;
            gridLoaiMay.Properties.ValueMember = "id";
            gridLoaiMay.Properties.DisplayMember = "loaimay";

            gridLoaiMay.EditValue = 1;

            dteDenNgay.DateTime = DateTime.Today;
            dteTuNgay.DateTime = DateTime.Today.AddDays(-7);

            _Loaimay = Convert.ToInt32(gridLoaiMay.EditValue);
            Load_LockUp(_Loaimay);
            _SoDong = 25;
            ResetSoTrang(_SoDong,dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
            LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_PhieuSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtSoTrang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            Load_PhieuSX(false);
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
           
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //int xxid = Convert.ToInt32(gridLoaiMay.EditValue);
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridLoaiMay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _Loaimay = Convert.ToInt32(gridLoaiMay.EditValue);
                Load_LockUp(_Loaimay);
                ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                LoadData(1, _SoDong, true, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
                Cursor.Current = Cursors.Default;
            }
            catch
            { }
        }

        private void txtSoDong_TextChanged(object sender, EventArgs e)
        {
            _SoDong = Convert.ToInt32(txtSoDong.Text);          
           
           // ResetSoTrang(_SoDong, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
            LoadData(_SoTrang, _SoDong, false, dteTuNgay.DateTime, dteDenNgay.DateTime, _Loaimay);
        }
    }
}
