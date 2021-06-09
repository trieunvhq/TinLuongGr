using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmChiTietKeHoachSanXuat : Form
    {
       

        public static MemoryStream stmBLOBData;
        public frmChiTietKeHoachSanXuat()
        {
            InitializeComponent();
        }
        private void Load_LockUp()
        {
            clsTbKhachHang cls = new clsTbKhachHang();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable newdt = dv.ToTable();
            gridKH.Properties.DataSource = newdt;
            gridKH.Properties.ValueMember = "ID_KhachHang";
            gridKH.Properties.DisplayMember = "MaKH";

            clsTbVatTuHangHoa cls2 = new clsTbVatTuHangHoa();
            DataTable dt2 = cls2.SelectAll();
            dt2.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt2.DefaultView;
            DataTable dtxx2 = dv2.ToTable();
            gridMaHang.Properties.DataSource = dtxx2;
            gridMaHang.Properties.ValueMember = "ID_VTHH";
            gridMaHang.Properties.DisplayMember = "MaVT";
        }
        private void HienThi()
        {
            Load_LockUp();
            if (frmKeHoachSanXuat.mbThemMoi == true)
            {
                dteNgayDatHang.EditValue = DateTime.Today;
                dteNgayDuKienGiaoHang.EditValue = DateTime.Today.AddDays(10);
                dteNgayGiaoHangThucTe.EditValue = DateTime.Today.AddDays(10);
                clsTbKeHoachSanXuat cls = new clsTbKeHoachSanXuat();
                DataTable dt = cls.SelectAll();
                int k = dt.Rows.Count;
                if (k == 0)
                {
                    txtMaKeHoach.Text = "KH 1";
                }
                else
                {
                    string xxx = dt.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    txtMaKeHoach.Text = "KH " + xxx2 + "";
                }
            }
            else
            {

                clsTbKeHoachSanXuat cls = new CtyTinLuong.clsTbKeHoachSanXuat();
                cls.iID_KeHoachSanXuat = frmKeHoachSanXuat.miID_KeHoachSanXuat;
                DataTable dt = cls.SelectOne();
                dteNgayDatHang.EditValue = cls.daNgayDatHang.Value;
                dteNgayDuKienGiaoHang.EditValue = cls.daNgayDuKienXuat.Value;
                dteNgayGiaoHangThucTe.EditValue = cls.daNgayXuatThucTe.Value;
                gridKH.EditValue = cls.iID_KhachHang.Value;
                gridMaHang.EditValue = cls.iID_VTHH.Value;
                txtSoLuong.Text = cls.fSoLuong.Value.ToString();
                txtSoLuongThucGiaoHang.Text = cls.fSoLuongThucXuat.Value.ToString();
                txtSoCount.Text = cls.fSoCountner.Value.ToString();
                txtQuyCach.Text = cls.sQuyCach.Value;
                txtGhiChu2222.Text = cls.sGhiChu.Value;
                checkHoanThanh.Checked = false;
                txtDienGiai222222.Text = cls.sDienGiai.Value;
                txtMaKeHoach.Text = cls.sMaKeHoach.Value;
                clsTbKeHoachSanXuat_HinhAnh cls2 = new clsTbKeHoachSanXuat_HinhAnh();
                cls2.iID_KeHoachSanXuat = frmKeHoachSanXuat.miID_KeHoachSanXuat;
                DataTable dthinhanh = cls2.SelectAll_W_ID_KeHoachSanXuat();
                if (dthinhanh.Rows.Count > 0)
                {
                    if (dthinhanh.Rows[0]["HinhAnh"].ToString() != "")
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(dthinhanh.Rows[0]["HinhAnh"]);
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        pictureEdit1.Image = Image.FromStream(stmBLOBData);
                        txtPic1.Text = dthinhanh.Rows[0]["HinhAnh"].ToString();
                        txt_ID_pic1.Text = dthinhanh.Rows[0]["ID_HinhAnhKeHoach"].ToString();
                    }
                    if (dthinhanh.Rows.Count > 1)
                    {
                        if (dthinhanh.Rows[1]["HinhAnh"].ToString() != "")
                        {
                            Byte[] byteBLOBData = new Byte[0];
                            byteBLOBData = (Byte[])(dthinhanh.Rows[1]["HinhAnh"]);
                            MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                            pictureEdit2.Image = Image.FromStream(stmBLOBData);
                            txtPic2.Text = dthinhanh.Rows[1]["HinhAnh"].ToString();
                            txt_ID_pic2.Text = dthinhanh.Rows[1]["ID_HinhAnhKeHoach"].ToString();
                        }
                    }
                    if (dthinhanh.Rows.Count > 2)
                    {
                        if (dthinhanh.Rows[2]["HinhAnh"].ToString() != "")
                        {
                            Byte[] byteBLOBData = new Byte[0];
                            byteBLOBData = (Byte[])(dthinhanh.Rows[2]["HinhAnh"]);
                            MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                            pictureEdit3.Image = Image.FromStream(stmBLOBData);
                            txtPic3.Text = dthinhanh.Rows[2]["HinhAnh"].ToString();
                            txt_ID_pic3.Text = dthinhanh.Rows[2]["ID_HinhAnhKeHoach"].ToString();
                        }
                    }
                    if (dthinhanh.Rows.Count > 3)
                    {
                        if (dthinhanh.Rows[3]["HinhAnh"].ToString() != "")
                        {
                            Byte[] byteBLOBData = new Byte[0];
                            byteBLOBData = (Byte[])(dthinhanh.Rows[3]["HinhAnh"]);
                            MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                            pictureEdit4.Image = Image.FromStream(stmBLOBData);
                            txtPic4.Text = dthinhanh.Rows[3]["HinhAnh"].ToString();
                            txt_ID_pic4.Text = dthinhanh.Rows[3]["ID_HinhAnhKeHoach"].ToString();
                        }
                    }
                }

            }

        }

        private bool KiemTraLuu()
        {

            if (dteNgayDatHang.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày tháng ");
                return false;
            }

            else return true;

        }
        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTbKeHoachSanXuat cls = new CtyTinLuong.clsTbKeHoachSanXuat();
                cls.sMaKeHoach = txtMaKeHoach.Text.ToString();
                cls.sDienGiai = txtDienGiai222222.Text.ToString();
                cls.daNgayDatHang = dteNgayDatHang.DateTime;
                cls.iID_KhachHang = Convert.ToInt32(gridKH.EditValue);
                cls.iID_VTHH = Convert.ToInt32(gridMaHang.EditValue);
                cls.fSoLuong = Convert.ToDouble(txtSoLuong.Text.ToString());
                cls.fSoLuongThucXuat = Convert.ToDouble(txtSoLuongThucGiaoHang.Text.ToString());
                cls.fSoCountner = Convert.ToDouble(txtSoCount.Text.ToString());
                cls.sQuyCach = txtQuyCach.Text.ToString();
                cls.daNgayDuKienXuat = dteNgayDuKienGiaoHang.DateTime;
                cls.daNgayXuatThucTe = dteNgayGiaoHangThucTe.DateTime;
                cls.sGhiChu = txtGhiChu2222.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = false;
                cls.bDaHoanThanh = checkHoanThanh.Checked;

                int miiiiiID_miID_KeHoachSanXuat;

                if (frmKeHoachSanXuat.mbSua == true)
                {
                    miiiiiID_miID_KeHoachSanXuat = frmKeHoachSanXuat.miID_KeHoachSanXuat;
                    cls.iID_KeHoachSanXuat = frmKeHoachSanXuat.miID_KeHoachSanXuat;
                    cls.Update();
                    Luu_HinhAnh(miiiiiID_miID_KeHoachSanXuat);


                }
                else
                {
                    cls.Insert();
                    miiiiiID_miID_KeHoachSanXuat = cls.iID_KeHoachSanXuat.Value;
                    Luu_HinhAnh(miiiiiID_miID_KeHoachSanXuat);
                }
            
                MessageBox.Show("Đã lưu");
            }
           
        }

        private void Luu_HinhAnh( int mixxxxID_keHoachSanXuat)
        {
            clsTbKeHoachSanXuat_HinhAnh cls = new clsTbKeHoachSanXuat_HinhAnh();
            cls.iID_KeHoachSanXuat = mixxxxID_keHoachSanXuat;

            if (txtPic1.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit1.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                cls.blobHinhAnh = pic;

                if (txt_ID_pic1.Text.ToString() == "")
                {
                    cls.Insert();
                    
                }
                else
                {
                    cls.Update();
                }

            }
            if (txtPic2.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit2.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                cls.blobHinhAnh = pic;

                if (txt_ID_pic2.Text.ToString() == "")
                {
                    cls.Insert();
                }
                else
                {
                    cls.Update();
                }

            }
            if (txtPic3.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit3.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                cls.blobHinhAnh = pic;

                if (txt_ID_pic3.Text.ToString() == "")
                {
                    cls.Insert();
                }
                else
                {
                    cls.Update();
                }

            }
            if (txtPic4.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit4.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                cls.blobHinhAnh = pic;

                if (txt_ID_pic4.Text.ToString() == "")
                {
                    cls.Insert();
                }
                else
                {
                    cls.Update();
                }

            }

        }
        private void frmChiTietKeHoachSanXuat_Load(object sender, EventArgs e)
        {

            HienThi();
        }

        private void gridMaDaiLy_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoChungTu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuongXuat_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMaDinhMucNPL_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridMaDinhMucDot_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDienGiaiDMNPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTongTienHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_BaoBe_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridMaDinhMucDot_BaoBe_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridKH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbKhachHang clsncc = new clsTbKhachHang();
                clsncc.iID_KhachHang = Convert.ToInt16(gridKH.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                }


            }
            catch
            {

            }
        }

        private void gridMaHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                clsncc.iID_VTHH = Convert.ToInt16(gridMaHang.EditValue.ToString());

                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenVatTu.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
                    txtQuyCach.Text = clsncc.sQuyCach.Value;
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

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
            this.Close();

        }

        private void btLuu_Copy_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
            txt_ID_pic1.ResetText();
            txt_ID_pic2.ResetText();
            txt_ID_pic3.ResetText();
            txt_ID_pic4.ResetText();
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            if (txtPic1.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit1.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                stmBLOBData = new MemoryStream(pic);
                frmAnhLon_KHSX ff = new CtyTinLuong.frmAnhLon_KHSX();
                ff.Show();
            }

        }

        private void pictureEdit2_DoubleClick(object sender, EventArgs e)
        {
            if (txtPic2.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit2.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                stmBLOBData = new MemoryStream(pic);
                frmAnhLon_KHSX ff = new CtyTinLuong.frmAnhLon_KHSX();
                ff.Show();
            }
        }

        private void pictureEdit3_DoubleClick(object sender, EventArgs e)
        {
            if (txtPic3.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit3.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                stmBLOBData = new MemoryStream(pic);
                frmAnhLon_KHSX ff = new CtyTinLuong.frmAnhLon_KHSX();
                ff.Show();
            }
        }

        private void pictureEdit4_DoubleClick(object sender, EventArgs e)
        {
            if (txtPic4.Text.ToString() != "")
            {
                MemoryStream stremxx = new MemoryStream();
                pictureEdit4.Image.Save(stremxx, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stremxx.ToArray();
                stmBLOBData = new MemoryStream(pic);
                frmAnhLon_KHSX ff = new CtyTinLuong.frmAnhLon_KHSX();
                ff.Show();
            }
        }

        private void Sua_Pic1_Click(object sender, EventArgs e)
        {
            Stream mystremmxx = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image file(*.jpg; *.jpeg; *.bmp)| *.jpg;*.jpeg;*.bmp";
            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystremmxx = ff.OpenFile()) != null)
                    {

                        string filename = ff.FileName;
                        txtPic1.Text = filename.ToString();
                        pictureEdit1.Image = Image.FromFile(filename);
                    }
                }
                catch
                {

                }

            }
        }

        private void Sua_Pic2_Click(object sender, EventArgs e)
        {
            Stream mystremmxx = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image file(*.jpg; *.jpeg; *.bmp)| *.jpg;*.jpeg;*.bmp";
            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystremmxx = ff.OpenFile()) != null)
                    {

                        string filename = ff.FileName;
                        txtPic2.Text = filename.ToString();
                        pictureEdit2.Image = Image.FromFile(filename);
                    }
                }
                catch
                {

                }

            }
        }

        private void Sua_Pic3_Click(object sender, EventArgs e)
        {
            Stream mystremmxx = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image file(*.jpg; *.jpeg; *.bmp)| *.jpg;*.jpeg;*.bmp";
            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystremmxx = ff.OpenFile()) != null)
                    {

                        string filename = ff.FileName;
                        txtPic3.Text = filename.ToString();
                        pictureEdit3.Image = Image.FromFile(filename);
                    }
                }
                catch
                {

                }

            }
        }

        private void Sua_Pic4_Click(object sender, EventArgs e)
        {
            Stream mystremmxx = null;
            OpenFileDialog ff = new OpenFileDialog();
            ff.Filter = "Image file(*.jpg; *.jpeg; *.bmp)| *.jpg;*.jpeg;*.bmp";
            if (ff.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((mystremmxx = ff.OpenFile()) != null)
                    {

                        string filename = ff.FileName;
                        txtPic4.Text = filename.ToString();
                        pictureEdit4.Image = Image.FromFile(filename);
                    }
                }
                catch
                {

                }

            }
        }

        private void Xoa_pic4_Click(object sender, EventArgs e)
        {
            if (txt_ID_pic4.Text.ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsTbKeHoachSanXuat_HinhAnh cls = new clsTbKeHoachSanXuat_HinhAnh();
                    cls.iID_HinhAnhKeHoach = Convert.ToInt32(txt_ID_pic4.Text.ToString());
                    cls.Delete();
                    MessageBox.Show("Đã xoá");
                    pictureEdit4.Image = null;
                    txt_ID_pic4.Text = "";
                    txtPic4.ResetText();
                }
            }
        }

        private void Xoa_Pic3_Click(object sender, EventArgs e)
        {
            if (txt_ID_pic3.Text.ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsTbKeHoachSanXuat_HinhAnh cls = new clsTbKeHoachSanXuat_HinhAnh();
                    cls.iID_HinhAnhKeHoach = Convert.ToInt32(txt_ID_pic3.Text.ToString());
                    cls.Delete();
                    MessageBox.Show("Đã xoá");
                    pictureEdit3.Image = null;
                    txt_ID_pic3.Text = "";
                    txtPic3.ResetText();
                }
            }
        }

        private void Xoa_pic2_Click(object sender, EventArgs e)
        {
            if (txt_ID_pic2.Text.ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsTbKeHoachSanXuat_HinhAnh cls = new clsTbKeHoachSanXuat_HinhAnh();
                    cls.iID_HinhAnhKeHoach = Convert.ToInt32(txt_ID_pic2.Text.ToString());
                    cls.Delete();
                    MessageBox.Show("Đã xoá");
                    pictureEdit2.Image = null;
                    txt_ID_pic2.Text = "";
                    txtPic2.ResetText();
                }
            }
        }

        private void Xoa_Pic1_Click(object sender, EventArgs e)
        {
            if (txt_ID_pic1.Text.ToString() != "")
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (traloi == DialogResult.Yes)
                {
                    clsTbKeHoachSanXuat_HinhAnh cls = new clsTbKeHoachSanXuat_HinhAnh();
                    cls.iID_HinhAnhKeHoach = Convert.ToInt32(txt_ID_pic1.Text.ToString());
                    cls.Delete();
                    MessageBox.Show("Đã xoá");
                    pictureEdit1.Image = null;
                    txt_ID_pic1.Text = "";
                    txtPic1.ResetText();
                }
            }
        }
    }
}
