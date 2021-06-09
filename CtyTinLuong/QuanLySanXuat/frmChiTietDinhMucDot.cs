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
    public partial class frmChiTietDinhMucDot : Form
    {
        
        private void Luu_ThemMoi_DM_DOT()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    Double fsoluongkiemtra, ftrongluong1, fsoluongQuydoi, fquyrakien, fphepham, fdocao, fsoKG_1bao, fsokienmotbao;
                    if (txtSoLuongKiemTra.Text.ToString() == "")
                        fsoluongkiemtra = 0;
                    else fsoluongkiemtra = Convert.ToDouble(txtSoLuongKiemTra.Text.ToString().Trim());

                    if (txtTrongLuongKiemTra.Text.ToString() == "")
                        ftrongluong1 = 0;
                    else ftrongluong1 = Convert.ToDouble(txtTrongLuongKiemTra.Text.ToString().Trim());

                    if (txtSoLuongQuyDoi.Text.ToString() == "")
                        fsoluongQuydoi = 0;
                    else fsoluongQuydoi = Convert.ToDouble(txtSoLuongQuyDoi.Text.ToString().Trim());

                    if (txtQuyRaKien.Text.ToString() == "")
                        fquyrakien = 0;
                    else fquyrakien = Convert.ToDouble(txtQuyRaKien.Text.ToString().Trim());

                    if (txtPhePham.Text.ToString() == "")
                        fphepham = 0;
                    else fphepham = Convert.ToDouble(txtPhePham.Text.ToString().Trim());

                    if (txtDoCao.Text.ToString() == "")
                        fdocao = 0;
                    else fdocao = Convert.ToDouble(txtDoCao.Text.ToString().Trim());

                    if (txtSoKGMotBao.Text.ToString() == "")
                        fsoKG_1bao = 0;
                    else fsoKG_1bao = Convert.ToDouble(txtSoKGMotBao.Text.ToString().Trim());

                    if (txtSoKienMotBao.Text.ToString() == "")
                        fsokienmotbao = 0;
                    else fsokienmotbao = Convert.ToDouble(txtSoKienMotBao.Text.ToString().Trim());

                    clsDinhMuc_tbDinhMuc_DOT cls = new clsDinhMuc_tbDinhMuc_DOT();
                    if (dteNgayThang.Text.ToString() != "")
                        cls.daNgayThang = dteNgayThang.DateTime;
                    else cls.daNgayThang = DateTime.Today;
                    string sssca = "";
                    if (checkCa1.Checked == true) sssca = "Ca 1";
                    if (checkCa1.Checked == false) sssca = "Ca 2";
                    cls.sCa = sssca;
                    cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
                    cls.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());
                    cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
                    cls.fSoLuongKiemTra = fsoluongkiemtra;
                    cls.fTrongLuongKiemTra = ftrongluong1;
                    cls.fSoLuongQuyDoi = fsoluongQuydoi;
                    cls.sDonViQuyDoi = txtDonViQuyDoi.Text.ToString().Trim();
                    cls.fQuyRaKien = fquyrakien;
                    cls.fPhePham = fphepham;
                    cls.fDoCao = fdocao;
                    cls.fSoKG_MotBao = fsoKG_1bao;
                    cls.fSoKienMotBao = fsokienmotbao;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls.sGhiChu = txtGhiChu.Text.ToString();
                    cls.bKhoa = false;
                    cls.bCheckHangNhu_True = false;
                    cls.Insert();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                catch
                {

                }

            }
        }

        private void Luu_Sua__DM_DOT()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDinhMuc_tbDinhMuc_DOT cls2 = new CtyTinLuong.clsDinhMuc_tbDinhMuc_DOT();
                    cls2.iID_DinhMuc_Dot = UCDinhMucDot.miID_DinhMuc_Dot;
                    DataTable dt2 = cls2.SelectOne();
                    bool khoadulieu = cls2.bKhoa.Value;
                    Double fsoluongkiemtra, ftrongluong1, fsoluongQuydoi, fquyrakien, fphepham, fdocao, fsoKG_1bao, fsokienmotbao;
                    if (txtSoLuongKiemTra.Text.ToString() == "")
                        fsoluongkiemtra = 0;
                    else fsoluongkiemtra = Convert.ToDouble(txtSoLuongKiemTra.Text.ToString().Trim());

                    if (txtTrongLuongKiemTra.Text.ToString() == "")
                        ftrongluong1 = 0;
                    else ftrongluong1 = Convert.ToDouble(txtTrongLuongKiemTra.Text.ToString().Trim());

                    if (txtSoLuongQuyDoi.Text.ToString() == "")
                        fsoluongQuydoi = 0;
                    else fsoluongQuydoi = Convert.ToDouble(txtSoLuongQuyDoi.Text.ToString().Trim());

                    if (txtQuyRaKien.Text.ToString() == "")
                        fquyrakien = 0;
                    else fquyrakien = Convert.ToDouble(txtQuyRaKien.Text.ToString().Trim());

                    if (txtPhePham.Text.ToString() == "")
                        fphepham = 0;
                    else fphepham = Convert.ToDouble(txtPhePham.Text.ToString());

                    if (txtDoCao.Text.ToString() == "")
                        fdocao = 0;
                    else fdocao = Convert.ToDouble(txtDoCao.Text.ToString().Trim());

                    if (txtSoKGMotBao.Text.ToString() == "")
                        fsoKG_1bao = 0;
                    else fsoKG_1bao = Convert.ToDouble(txtSoKGMotBao.Text.ToString().Trim());

                    if (txtSoKienMotBao.Text.ToString() == "")
                        fsokienmotbao = 0;
                    else fsokienmotbao = Convert.ToDouble(txtSoKienMotBao.Text.ToString().Trim());

                    clsDinhMuc_tbDinhMuc_DOT cls = new clsDinhMuc_tbDinhMuc_DOT();
                    if (dteNgayThang.Text.ToString() != "")
                        cls.daNgayThang = dteNgayThang.DateTime;
                    string sssca = "";
                    if (checkCa1.Checked == true) sssca = "Ca 1";
                    if (checkCa1.Checked == false) sssca = "Ca 2";
                    cls.iID_DinhMuc_Dot = UCDinhMucDot.miID_DinhMuc_Dot;
                    cls.sCa = sssca;
                    cls.sSoHieu = txtSoHieu.Text.ToString().Trim();                   
                    cls.sLoaiGiay = txtLoaiGiay.Text.ToString().Trim();
                    cls.fSoLuongKiemTra = fsoluongkiemtra;
                    cls.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());
                    cls.fTrongLuongKiemTra = ftrongluong1;
                    cls.fSoLuongQuyDoi = fsoluongQuydoi;
                    cls.sDonViQuyDoi = txtDonViQuyDoi.Text.ToString().Trim();
                    cls.fQuyRaKien = fquyrakien;
                    cls.fPhePham = fphepham;
                    cls.fDoCao = fdocao;
                    cls.fSoKG_MotBao = fsoKG_1bao;
                    cls.fSoKienMotBao = fsokienmotbao;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls.sGhiChu = txtGhiChu.Text.ToString();
                    cls.bKhoa = khoadulieu;
                    cls.bCheckHangNhu_True = false;
                    cls.Update();
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                catch
                {

                }
            }
        }
        private void HienThi_ThemMoi_DinhMuc_DOT()
        {
            checkCa1.Checked = true;
            check_KhongDungCongThuc.Checked = true;
            dteNgayThang.EditValue = DateTime.Today;

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridLookUpEditLoaiHang.Properties.DataSource = dtxx;
            gridLookUpEditLoaiHang.Properties.ValueMember = "ID_VTHH";
            gridLookUpEditLoaiHang.Properties.DisplayMember = "MaVT";

        }

        private void HienThi_Sua_DinhMuc_DOT()
        {
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dt.DefaultView;
            DataTable dtxx = dv.ToTable();
            gridLookUpEditLoaiHang.Properties.DataSource = dtxx;
            gridLookUpEditLoaiHang.Properties.ValueMember = "ID_VTHH";
            gridLookUpEditLoaiHang.Properties.DisplayMember = "MaVT";

            clsDinhMuc_tbDinhMuc_DOT cls2 = new CtyTinLuong.clsDinhMuc_tbDinhMuc_DOT();
            cls2.iID_DinhMuc_Dot = UCDinhMucDot.miID_DinhMuc_Dot;
            DataTable dt2 = cls2.SelectOne();

            dteNgayThang.EditValue = Convert.ToDateTime(dt2.Rows[0]["NgayThang"].ToString());
            txtSoHieu.Text = dt2.Rows[0]["SoHieu"].ToString();
            if (dt2.Rows[0]["Ca"].ToString() == "Ca 1") checkCa1.Checked = true;
            else checkCa2.Checked = true;
            checkNgungTheoDoi.Checked =Convert.ToBoolean(dt2.Rows[0]["NgungTheoDoi"].ToString());
            gridLookUpEditLoaiHang.EditValue = UCDinhMucDot.miDID_VTHH;
            txtLoaiGiay.Text = dt2.Rows[0]["LoaiGiay"].ToString();
            txtSoLuongKiemTra.Text = dt2.Rows[0]["SoLuongKiemTra"].ToString();
            txtTrongLuongKiemTra.Text = dt2.Rows[0]["TrongLuongKiemTra"].ToString();
            txtSoLuongQuyDoi.Text = dt2.Rows[0]["SoLuongQuyDoi"].ToString();
            txtDonViQuyDoi.Text = dt2.Rows[0]["DonViQuyDoi"].ToString();
            txtQuyRaKien.Text = dt2.Rows[0]["QuyRaKien"].ToString();
            txtDoCao.Text = dt2.Rows[0]["DoCao"].ToString();
            txtSoKienMotBao.Text = dt2.Rows[0]["SoKienMotBao"].ToString();
            txtPhePham.Text = dt2.Rows[0]["PhePham"].ToString();
            txtSoKGMotBao.Text = dt2.Rows[0]["SoKG_MotBao"].ToString();
            //txtSoKien60Bao.Text = dt2.Rows[0][""].ToString();
            txtGhiChu.Text = dt2.Rows[0]["GhiChu"].ToString();
           
          
        }
        private bool KiemTraLuu()
        {

            if (txtSoHieu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số hiệu");
                return false;
            }
            else if (dteNgayThang.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày tháng ");
                return false;
            }
            //else if (txtLoaiHang.Text.ToString() == "")
            //{
            //    MessageBox.Show("Chưa chọn loại hàng");
            //    return false;
            //}
            else if (txtLoaiGiay.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn loại giấy");
                return false;
            }
          
            else if (txtSoLuongKiemTra.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn đơn vị tính");
                return false;
            }
            else if (txtTrongLuongKiemTra.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số lượng kiêm tra");
                return false;
            }
            else if (txtSoLuongQuyDoi.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số lượng quy đổi");
                return false;
            }
            else if (txtQuyRaKien.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có quy ra kiện");
                return false;
            }
            else if (txtDoCao.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn độ cao");
                return false;
            }
            else if (txtSoKienMotBao.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số kiện 1 bao");
                return false;
            }
            else if (txtSoKGMotBao.Text.ToString() == "")
            {
                MessageBox.Show("Chưa chọn số Kg/ 1bao");
                return false;
            }
            else return true;

        }

        public frmChiTietDinhMucDot()
        {
            InitializeComponent();
        }

        private void checkCa1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCa1.Checked == true)
                checkCa2.Checked = false;
        }

        private void checkCa2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkCa2.Checked == true)
                checkCa1.Checked = false;
        }

        private void frmChiTietDinhMucDot_Load(object sender, EventArgs e)
        {
           

            if (UCDinhMucDot.mb_TheMoi_DinhMuc_Dot==true)
            {
                HienThi_ThemMoi_DinhMuc_DOT();
            }
            else
            {
              
                HienThi_Sua_DinhMuc_DOT();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkCongThuc1_CheckedChanged(object sender, EventArgs e)
        {
            Double fsoluongQuydoi;
            
            if (txtSoLuongQuyDoi.Text.ToString() == "")
                fsoluongQuydoi = 0;
            else fsoluongQuydoi = Convert.ToDouble(txtSoLuongQuyDoi.Text.ToString().Trim());

         
           
            if (checkCongThuc1.Checked == true)
            {
                txtSoKienMotBao.Enabled = false;
                txtSoKien60Bao.Enabled = false;
                checkCongThuc2.Checked = false;
                check_KhongDungCongThuc.Checked = false;
                txtSoKienMotBao.Text = (fsoluongQuydoi * 50 / 1000).ToString();
                txtSoKien60Bao.Text= (fsoluongQuydoi * 50*60 / 1000).ToString();
            }
        }

        private void checkCongThuc2_CheckedChanged(object sender, EventArgs e)
        {
            Double fsoKG_1bao, ftrongluong1;

            if (txtSoKGMotBao.Text.ToString() == "")
                fsoKG_1bao = 1;
            else fsoKG_1bao = Convert.ToDouble(txtSoKGMotBao.Text.ToString().Trim());

            if (txtTrongLuongKiemTra.Text.ToString() == "")
                ftrongluong1 = 0;
            else ftrongluong1 = Convert.ToDouble(txtTrongLuongKiemTra.Text.ToString().Trim());

            if (checkCongThuc2.Checked == true)
            {
                txtSoKienMotBao.Enabled = false;
                txtSoKien60Bao.Enabled = false;
                checkCongThuc1.Checked = false;
                check_KhongDungCongThuc.Checked = false;
                txtSoKienMotBao.Text = (fsoKG_1bao/ ftrongluong1).ToString();
                txtSoKien60Bao.Text = (fsoKG_1bao*60 / ftrongluong1).ToString();
            }
        }

        private void check_KhongDungCongThuc_CheckedChanged(object sender, EventArgs e)
        {
            if (check_KhongDungCongThuc.Checked == true)
            {
                txtSoKienMotBao.Enabled = true;
                txtSoKien60Bao.Enabled = true;
                checkCongThuc2.Checked = false;
                checkCongThuc1.Checked = false;
            }
        }

        private void btLuu_va_Dong_Click(object sender, EventArgs e)
        {
            if (UCDinhMucDot.mb_TheMoi_DinhMuc_Dot == true)
            {
                Luu_ThemMoi_DM_DOT();
            }
            else
            {

                Luu_Sua__DM_DOT();
            }
         
        }

        private void gridLookUpEditLoaiHang_EditValueChanged(object sender, EventArgs e)
        {
            clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
            string manccc = gridLookUpEditLoaiHang.SelectedText.ToString();
            clsncc.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());

            DataTable dt = clsncc.SelectOne();
            if (dt.Rows.Count > 0)
            {
                txtTenVatTu.Text = dt.Rows[0]["TenVTHH"].ToString();
                txtDVT1.Text= dt.Rows[0]["DonViTinh"].ToString();
            }
        }

        private void txtSoKienMotBao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
