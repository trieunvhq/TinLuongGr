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
            else if (gridMaDinhMucLuong.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn cách tính lương ");
                return false;
            }
            else return true;

        }
        private void Luu_DuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                cls.sMaNhanVien = txtMaNV.Text.ToString();
                cls.sLoaiHopDongLaoDong = cbLoaiHopDong.Text.ToString();
                cls.iID_BoPhan =Convert.ToInt16(cbBoPhan.SelectedValue.ToString());
                cls.iID_ChucVu= Convert.ToInt16(cbChucVu.SelectedValue.ToString());
                cls.sTenNhanVien = txtHoTen.Text.ToString();
                cls.sSoDienThoai = txtSDT.Text.ToString();
                if (dteNgayBatDau.Text.ToString() != "")
                    cls.daNgayBatDau = dteNgayBatDau.DateTime;
                else cls.daNgayBatDau = DateTime.Today;
                if (dteNgayChinhThuc.Text.ToString() != "")
                    cls.daNgayChinhThuc = dteNgayChinhThuc.DateTime;
                else cls.daNgayChinhThuc = DateTime.Today;
                if (dteNgayThoiViec.Text.ToString() != "")
                    cls.daNgayThoiViec = dteNgayThoiViec.DateTime;
                else cls.daNgayThoiViec = DateTime.Today;
                if (dteNgayNopBHXH.Text.ToString() != "")
                    cls.daNgayNopBHXH = dteNgayNopBHXH.DateTime;
                else cls.daNgayNopBHXH = DateTime.Today;
                if (dteNgaySinh.Text.ToString() != "")
                    cls.daNgaySinh = dteNgaySinh.DateTime;
                else cls.daNgaySinh = DateTime.Today;
                if (dteNgayCapCMT.Text.ToString() != "")
                    cls.daNgayCapCMT = dteNgayCapCMT.DateTime;
                else cls.daNgayCapCMT = DateTime.Today;
                cls.sNoiSinh=txtNoiSinh.Text.ToString();
                if (checkBoxNam.Checked == true)
                    cls.bGioiTinh = true;
                else cls.bGioiTinh = false;
                cls.sDanToc=txtDanToc.Text.ToString();
                cls.sTonGiao=txtTonGiao.Text.ToString();
                cls.sQuocTich = txtQuocTich.Text.ToString();
                cls.sSoCMT = txtSoCMT.Text.ToString();
                cls.sNoiCapCMT = txtNoiCapCMT.Text.ToString();
                //cls.sLoaiHinhLuong = cbLoaiHinhLuong.Text.ToString();
                cls.bTonTai = true;
                cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                cls.sGhiChu = txtGhiChu.Text.ToString();
                cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
                cls.bLuongCongNhat = true;
                cls.bLuongSanLuong = false;
                cls.iID_DinhMuc_Luong_SanLuong = 0;
                if (frmNhanSu.mbSua == false)
                {
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

        private void Load_lockUP_EDIT()
        {
            clsHUU_DinhMucLuong_CongNhat clsvthhh = new clsHUU_DinhMucLuong_CongNhat();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();

            gridMaDinhMucLuong.Properties.DataSource = newdtvthh;
            gridMaDinhMucLuong.Properties.ValueMember = "ID_DinhMucLuong_CongNhat";
            gridMaDinhMucLuong.Properties.DisplayMember = "MaDinhMucLuongCongNhat";

        }
        private void HienThi_Sua()
        {
            clsNhanSu_tbNhanSu cls1 = new CtyTinLuong.clsNhanSu_tbNhanSu();
            cls1.iID_NhanSu = frmNhanSu.miID_Sua_NhanVien;
            DataTable dt1 = cls1.Select_hienThi_ChiTietNhanSu();
           
            txtMaNV.Text = dt1.Rows[0]["MaNhanVien"].ToString();
            txtHoTen.Text= dt1.Rows[0]["TenNhanVien"].ToString();
            txtSDT.Text= dt1.Rows[0]["SoDienThoai"].ToString();
            cbBoPhan.Text= dt1.Rows[0]["TenBoPhan"].ToString();
            cbChucVu.Text= dt1.Rows[0]["TenChucVu"].ToString();
            cbLoaiHopDong.Text= dt1.Rows[0]["LoaiHopDongLaoDong"].ToString();
            if (dt1.Rows[0]["NgayBatDau"].ToString() != "")
                dteNgayBatDau.EditValue = Convert.ToDateTime(dt1.Rows[0]["NgayBatDau"].ToString());
            if (dt1.Rows[0]["NgayChinhThuc"].ToString() != "")
                dteNgayChinhThuc.EditValue= Convert.ToDateTime(dt1.Rows[0]["NgayChinhThuc"].ToString());
            if (dt1.Rows[0]["NgayNopBHXH"].ToString() != "")
                dteNgayNopBHXH.EditValue=dt1.Rows[0]["NgayNopBHXH"].ToString();
            if (dt1.Rows[0]["NgayThoiViec"].ToString() != "")
                dteNgayThoiViec.EditValue= Convert.ToDateTime(dt1.Rows[0]["NgayThoiViec"].ToString());
           
            if (dt1.Rows[0]["NgaySinh"].ToString() != "")
                dteNgaySinh.EditValue= Convert.ToDateTime(dt1.Rows[0]["NgaySinh"].ToString());
            txtNoiSinh.Text= dt1.Rows[0]["NoiSinh"].ToString();
            txtDanToc.Text= dt1.Rows[0]["DanToc"].ToString();
            txtQuocTich.Text= dt1.Rows[0]["QuocTich"].ToString();
            txtSoCMT.Text= dt1.Rows[0]["SoCMT"].ToString();
            if (dt1.Rows[0]["NgayCapCMT"].ToString() != "")
                dteNgayCapCMT.EditValue= Convert.ToDateTime(dt1.Rows[0]["NgayCapCMT"].ToString());
            txtNoiCapCMT.Text= dt1.Rows[0]["NoiCapCMT"].ToString();
            if (dt1.Rows[0]["GioiTinh"].ToString() != "1")
                checkBoxNam.Checked = true;
            if (dt1.Rows[0]["GioiTinh"].ToString() != "0")
                checkBoxNu.Checked = true;

            cls1.iID_NhanSu = frmNhanSu.miID_Sua_NhanVien;
            DataTable dtxxx = cls1.SelectOne();
            gridMaDinhMucLuong.EditValue = cls1.iID_DinhMucLuong_CongNhat.Value;
           
        }
       
        private void LoadCombobox()
        {
            clsNhanSu_tbBoPhan cls1 = new clsNhanSu_tbBoPhan();
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
            //TenChucVu
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

            Load_lockUP_EDIT();
            LoadCombobox();
            if (frmNhanSu.mbSua == true)
                HienThi_Sua();
            else if (frmNhanSu.mbCopy == true)
                HienThi_Sua();
            else
            {  }
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
            clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
            cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridMaDinhMucLuong.EditValue.ToString());
            DataTable dt = cls.SelectOne();
            txtDienGiai.Text = cls.sDienGiai.Value;
        }
    }
}
