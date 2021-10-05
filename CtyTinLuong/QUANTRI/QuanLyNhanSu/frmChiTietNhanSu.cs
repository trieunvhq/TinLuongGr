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
    public partial class frmChiTietNhanSu : Form
    {
        private bool KiemTraLuu()
        {
            if (txtMaNV.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn Mã Nhân viên ");
                return false;
            }
            else if (txtHoTen.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có tên ");
                return false;
            }
            else if (checkBoxNu.Checked==false & checkBoxNam.Checked==false)
            {
                MessageBox.Show("Chưa chọn giới tính ");
                return false;
            }
            else if (cbBoPhan.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn bộ phận ");
                return false;
            }
            else if (cbChucVu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn chức vụ ");
                return false;
            }
            else if (cbLoaiHopDong.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn hợp đồng lao động ");
                return false;
            }
            //else if (gridMaDinhMucLuong.Text.ToString() == "")
            //{
            //    MessageBox.Show("Chưa chọn cách tính lương ");
            //    return false;
            //}
            else return true;

        }
        private void Luu_DuLieu()
        {
            try
            {
                if (!KiemTraLuu()) return;
                else
                {
                    clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                    cls.sMaNhanVien = txtMaNV.Text.ToString();
                    cls.sLoaiHopDongLaoDong = cbLoaiHopDong.Text.ToString();
                    cls.iID_BoPhan = Convert.ToInt16(cbBoPhan.SelectedValue.ToString());
                    cls.iID_ChucVu = Convert.ToInt16(cbChucVu.SelectedValue.ToString());
                    cls.sTenNhanVien = txtHoTen.Text.ToString();
                    cls.sSoDienThoai = txtSDT.Text.ToString();
                    if (dteNgayBatDau.EditValue != null)
                        cls.daNgayBatDau = dteNgayBatDau.DateTime;
                    else cls.daNgayBatDau = DateTime.Today;
                    if (dteNgayChinhThuc.EditValue != null)
                        cls.daNgayChinhThuc = dteNgayChinhThuc.DateTime;
                    else cls.daNgayChinhThuc = DateTime.Today;
                    if (dteNgayThoiViec.EditValue != null)
                        cls.daNgayThoiViec = dteNgayThoiViec.DateTime;
                    else cls.daNgayThoiViec = new DateTime(1900,1,1);
                    if (dteNgayNopBHXH.EditValue != null)
                        cls.daNgayNopBHXH = dteNgayNopBHXH.DateTime;
                    else cls.daNgayNopBHXH = new DateTime(1900, 1, 1);
                    if (dteNgaySinh.EditValue != null)
                        cls.daNgaySinh = dteNgaySinh.DateTime;
                    else cls.daNgaySinh = DateTime.Today;
                    if (dteNgayCapCMT.EditValue != null)
                        cls.daNgayCapCMT = dteNgayCapCMT.DateTime;
                    else cls.daNgayCapCMT = DateTime.Today;
                    cls.sNoiSinh = txtNoiSinh.Text.ToString();
                    if (checkBoxNam.Checked == true)
                        cls.bGioiTinh = true;
                    else cls.bGioiTinh = false;
                    cls.sDanToc = txtDanToc.Text.ToString();
                    cls.sTonGiao = txtTonGiao.Text.ToString();
                    cls.sQuocTich = txtQuocTich.Text.ToString();
                    cls.sSoCMT = txtSoCMT.Text.ToString();
                    cls.sNoiCapCMT = txtNoiCapCMT.Text.ToString();
                    //cls.sLoaiHinhLuong = cbLoaiHinhLuong.Text.ToString();
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls.sGhiChu = txtGhiChu.Text.ToString();
                    cls.iID_DinhMucLuong_CongNhat = 0;// Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
                    cls.bLuongCongNhat = true;
                    cls.bLuongSanLuong = false;
                    cls.iID_DinhMuc_Luong_SanLuong = 0;
                    if (frmNhanSu.mbSua == false)
                    {
                        if (!String.IsNullOrEmpty(txtMaNV.Text))
                        {
                            if (cls.SelectOne_MaNhanVien(txtMaNV.Text.Trim()))
                            {
                                MessageBox.Show("Mã nhân viên \"" + txtMaNV.Text.Trim() + "\" đã tồn tại", "Thông báo");
                                txtMaNV.Focus();
                                return;
                            }
                        }

                        if (!String.IsNullOrEmpty(txtHoTen.Text))
                        {
                            if (cls.SelectOne_TenNhanVien(txtHoTen.Text.Trim()))
                            {
                                if (MessageBox.Show("Tên nhân viên \"" + txtHoTen.Text.Trim() + "\" đã tồn tại", "Thông báo",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    txtHoTen.Focus();
                                    return;
                                }
                            }
                        }

                        //
                        cls.Insert();
                    }
                    else
                    {
                        cls.iID_NhanSu = frmNhanSu.miID_Sua_NhanVien;
                        cls.Update();
                    }

                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Kiểm tra lại các trường nhập vào! " + ee.Message.ToString(), "Lỗi nhập dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Load_lockUP_EDIT()
        {
            try
            {
                using(clsHUU_DinhMucLuong_CongNhat clsvthhh = new clsHUU_DinhMucLuong_CongNhat())
                {
                    DataTable dtvthh = clsvthhh.SelectAll();
                    dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
                    DataView dvvthh = dtvthh.DefaultView;
                    DataTable newdtvthh = dvvthh.ToTable();

                    gridMaDinhMucLuong.Properties.DataSource = newdtvthh;
                    gridMaDinhMucLuong.Properties.ValueMember = "ID_DinhMucLuong_CongNhat";
                    gridMaDinhMucLuong.Properties.DisplayMember = "MaDinhMucLuongCongNhat";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThi_Sua()
        {
            try
            {
                using (clsNhanSu_tbNhanSu cls1 = new CtyTinLuong.clsNhanSu_tbNhanSu())
                {
                    cls1.iID_NhanSu = frmNhanSu.miID_Sua_NhanVien;
                    DataTable dt1 = cls1.Select_hienThi_ChiTietNhanSu();

                    txtMaNV.Text = dt1.Rows[0]["MaNhanVien"].ToString();
                    txtHoTen.Text = dt1.Rows[0]["TenNhanVien"].ToString();
                    txtSDT.Text = dt1.Rows[0]["SoDienThoai"].ToString();
                    cbBoPhan.Text = dt1.Rows[0]["TenBoPhan"].ToString();
                    cbChucVu.Text = dt1.Rows[0]["TenChucVu"].ToString();
                    cbLoaiHopDong.Text = dt1.Rows[0]["LoaiHopDongLaoDong"].ToString();
                    if (dt1.Rows[0]["NgayBatDau"].ToString() != "")
                        dteNgayBatDau.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayBatDau"].ToString());
                    if (dt1.Rows[0]["NgayChinhThuc"].ToString() != "")
                        dteNgayChinhThuc.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayChinhThuc"].ToString());
                    if (dt1.Rows[0]["NgayNopBHXH"].ToString() != "")
                        dteNgayNopBHXH.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayNopBHXH"].ToString());
                    else dteNgayNopBHXH.EditValue = null;

                    if (dt1.Rows[0]["NgayThoiViec"].ToString() != "")
                        dteNgayThoiViec.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayThoiViec"].ToString());
                    else dteNgayThoiViec.EditValue = null;

                    if (dt1.Rows[0]["NgaySinh"].ToString() != "")
                        dteNgaySinh.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgaySinh"].ToString());
                    txtNoiSinh.Text = dt1.Rows[0]["NoiSinh"].ToString();
                    txtDanToc.Text = dt1.Rows[0]["DanToc"].ToString();
                    txtQuocTich.Text = dt1.Rows[0]["QuocTich"].ToString();
                    txtSoCMT.Text = dt1.Rows[0]["SoCMT"].ToString();
                    if (dt1.Rows[0]["NgayCapCMT"].ToString() != "")
                        dteNgayCapCMT.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayCapCMT"].ToString());
                    txtNoiCapCMT.Text = dt1.Rows[0]["NoiCapCMT"].ToString();
                    if (dt1.Rows[0]["GioiTinh"].ToString() != "1")
                        checkBoxNam.Checked = true;
                    if (dt1.Rows[0]["GioiTinh"].ToString() != "0")
                        checkBoxNu.Checked = true;

                    cls1.iID_NhanSu = frmNhanSu.miID_Sua_NhanVien;
                    DataTable dtxxx = cls1.SelectOne();
                    gridMaDinhMucLuong.EditValue = cls1.iID_DinhMucLuong_CongNhat.Value;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void LoadCombobox()
        {
            try
            {
                using (clsNhanSu_tbBoPhan cls1 = new clsNhanSu_tbBoPhan())
                {
                    DataTable dt1 = cls1.SelectAll();
                    dt1.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                    DataView dv1 = dt1.DefaultView;
                    DataTable daadv1 = dv1.ToTable();
                    cbBoPhan.DataSource = daadv1;
                    cbBoPhan.DisplayMember = "TenBoPhan";
                    cbBoPhan.ValueMember = "ID_BoPhan";

                    clsNhanSu_tbChucVu cls2 = new clsNhanSu_tbChucVu();
                    DataTable dt2 = cls2.SelectAll();
                    dt2.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                    DataView dv2 = dt2.DefaultView;
                    DataTable daadv2 = dv2.ToTable();
                    cbChucVu.DataSource = daadv2;
                    cbChucVu.DisplayMember = "TenChucVu";
                    cbChucVu.ValueMember = "ID_ChucVu";
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmChiTietNhanSu()
        {
            InitializeComponent();
        }
       
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Load_lockUP_EDIT();
                LoadCombobox();
                if (frmNhanSu.mbSua == true)
                    HienThi_Sua();
                else if (frmNhanSu.mbCopy == true)
                    HienThi_Sua();
                else
                { }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Kiểm tra lại kết nối! " + ea.Message.ToString(), "Lỗi đọc dữ liệu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxNam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNam.Checked == true)
                checkBoxNu.Checked = false;
        }

        private void checkBoxNu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNu.Checked == true)
                checkBoxNam.Checked = false;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Luu_DuLieu();
        }

        private void cbBoPhan2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbBoPhan.SelectedValue.ToString());
        }

        private void gridMaDinhMucLuong_EditValueChanged(object sender, EventArgs e)
        {
            //clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
            //cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
            //DataTable dt = cls.SelectOne();
            //txtDienGiai.Text = cls.sDienGiai.Value;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
