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
    public partial class BanHang_frmChiTietMotVatTu : Form
    {
        private void HienThi(int xxID_VTHH, DateTime xxtungay, DateTime xxdenngay)
        { 
            try
            {
                using (clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang())
                {
                    cls.iID_VTHH = xxID_VTHH;
                    DataTable dxxxx = cls.T_SelectAll_W_ID_VTHH_SoChungTu_NgayThang_DienGiai_ID_KH(xxtungay, xxdenngay);

                    gridControl1.DataSource = dxxxx;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HienThi_ALL(int xxID_VTHH)
        { 
            try
            {
                using (clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang())
                {
                    //TenNhaCungCap
                    cls.iID_VTHH = xxID_VTHH;
                    DataTable dxxxx = cls.SelectAll_W_ID_VTHH_SoChungTu_NgayThang_DienGiai_ID_KH();

                    //for (int i = 0; i < dxxxx.Rows.Count; i++)
                    //{
                    //    double DonGia = CheckString.ConvertToDouble_My(dxxxx.Rows[i]["DonGia"].ToString());
                    //    double SoLuong = CheckString.ConvertToDouble_My(dxxxx.Rows[i]["SoLuong"].ToString());
                    //    int iID_KhachHangccc = Convert.ToInt32(dxxxx.Rows[i]["ID_KhachHang"].ToString());
                    //    //clsTbKhachHang clsncc = new clsTbKhachHang();
                    //    //clsncc.iID_KhachHang = iID_KhachHangccc;
                    //    //DataTable dtncc = clsncc.SelectOne();
                    //    DataRow _ravi = dt2.NewRow();
                    //    _ravi["SoChungTu"] = dxxxx.Rows[i]["SoChungTu"].ToString();
                    //    _ravi["DienGiai"] = dxxxx.Rows[i]["DienGiai"].ToString();
                    //    _ravi["SoLuong"] = SoLuong;
                    //    _ravi["NgayChungTu"] = Convert.ToDateTime(dxxxx.Rows[i]["NgayChungTu"].ToString());
                    //    _ravi["DonGia"] = DonGia;
                    //    _ravi["ThanhTien"] = SoLuong * DonGia;
                    //    _ravi["TenKH"] = clsncc.sTenKH.Value;
                    //    dt2.Rows.Add(_ravi);
                    //}
                    gridControl1.DataSource = dxxxx;
                    //dxxxx.Dispose();
                    //cls.Dispose();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Lockup()
        { 
            try
            {
                using (clsBanHang_ChiTietBanHang cls = new CtyTinLuong.clsBanHang_ChiTietBanHang())
                {
                    //clsTbVatTuHangHoa clsvthhh = new clsTbVatTuHangHoa();
                    DataTable dt2 = cls.SelectAll_Distint_ID_VTHH();


                    gridMaVT.Properties.DataSource = dt2;
                    gridMaVT.Properties.ValueMember = "ID_VTHH";
                    gridMaVT.Properties.DisplayMember = "MaVT";
                    //dt2.Dispose();
                    //cls.Dispose();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public BanHang_frmChiTietMotVatTu()
        {
            InitializeComponent();
        }

        private void BanHang_frmChiTietMotVatTu_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_Lockup();
                gridMaVT.EditValue = UCBanHang_ChiTiet_ALL.miID_VTHH;
                dteDenNgay.EditValue = DateTime.Today;
                dteTuNgay.EditValue = null;
                HienThi_ALL(UCBanHang_ChiTiet_ALL.miID_VTHH);
                dteTuNgay.Focus();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                int iiID = Convert.ToInt32(gridMaVT.EditValue.ToString());
                cls.iID_VTHH = iiID;
                DataTable dt = cls.SelectOne();
                txtTenVT.Text = cls.sTenVTHH.Value;
                txtDVT.Text = cls.sDonViTinh.Value;
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    HienThi(iiID, dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
                else
                    HienThi_ALL(iiID);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_frmChiTietMotVatTu_Load(sender, e);
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    int iiID = Convert.ToInt32(gridMaVT.EditValue.ToString());
                    HienThi(iiID, dteTuNgay.DateTime, dteDenNgay.DateTime.AddDays(1));
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == clSTT)
                {
                    e.DisplayText = (e.RowHandle + 1).ToString();
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dteDenNgay.Focus();
            }
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btLayDuLieu.Focus();
                btLayDuLieu_Click(null, null);
            }
        }

        private void btLayDuLieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridMaVT.Focus();
            }
        }

        private void gridMaVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtTenVT.Focus();
            }
        }

        private void txtTenVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDVT.Focus();
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gridView1.Focus();
            }
        }
         
        private void gridMaVT_QueryPopUp(object sender, CancelEventArgs e)
        {
            gridMaVT.Properties.View.Columns[0].Visible = false;
        }

    }
}
