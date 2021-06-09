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
    public partial class frmChiTietDinhMuc_HangNhu : Form
    {

        private void Luu_DuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    Double  fsoKG_1bao, fsokienmotbao;
                  
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
                                      
                    cls.sCa = "Ca 1";
                    cls.sSoHieu = txtSoHieu.Text.ToString().Trim();
                    cls.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());
                    cls.sLoaiGiay = "";
                    cls.fSoLuongKiemTra = 0;
                    cls.fTrongLuongKiemTra = 0;
                    cls.fSoLuongQuyDoi = 0;
                    cls.sDonViQuyDoi = "";                    
                    cls.fPhePham = 0;
                    cls.fDoCao = 0;                 
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.sGhiChu = txtGhiChu.Text.ToString();
                    cls.bKhoa = false;
                    cls.fQuyRaKien = 0;

                    cls.fSoKG_MotBao = fsoKG_1bao;
                    cls.fSoKienMotBao = fsokienmotbao;
                    cls.bCheckHangNhu_True = true;
                   
                    if(UCDinhMucHangNhu.mb_TheMoi_DinhMuc_Dot==true)
                    {
                        cls.Insert();
                       
                    }
                    else
                    {
                        cls.iID_DinhMuc_Dot = UCDinhMucHangNhu.miID_DinhMuc_Dot;
                        cls.Update();
                        
                    }
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
            cls2.iID_DinhMuc_Dot = UCDinhMucHangNhu.miID_DinhMuc_Dot;
            DataTable dt2 = cls2.SelectOne();
            dteNgayThang.EditValue = Convert.ToDateTime(dt2.Rows[0]["NgayThang"].ToString());
            txtSoHieu.Text = dt2.Rows[0]["SoHieu"].ToString();       
            gridLookUpEditLoaiHang.EditValue = UCDinhMucHangNhu.miDID_VTHH;          
            txtSoKienMotBao.Text = dt2.Rows[0]["SoKienMotBao"].ToString();          
            txtSoKGMotBao.Text = dt2.Rows[0]["SoKG_MotBao"].ToString();          
            txtGhiChu.Text = dt2.Rows[0]["GhiChu"].ToString();


        }

        private bool KiemTraLuu()
        {

            if (txtSoHieu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có mã định mức");
                return false;
            }
            else if (dteNgayThang.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày tháng ");
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
        public frmChiTietDinhMuc_HangNhu()
        {
            InitializeComponent();
        }

        private void btLuu_va_Dong_Click(object sender, EventArgs e)
        {
            Luu_DuLieu();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietDinhMuc_HangNhu_Load(object sender, EventArgs e)
        {
            if (UCDinhMucHangNhu.mb_TheMoi_DinhMuc_Dot == true)
            {
                HienThi_ThemMoi_DinhMuc_DOT();
            }
            else
            {

                HienThi_Sua_DinhMuc_DOT();
            }
        }

        private void gridLookUpEditLoaiHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                string manccc = gridLookUpEditLoaiHang.SelectedText.ToString();
                clsncc.iID_VTHH = Convert.ToInt16(gridLookUpEditLoaiHang.EditValue.ToString());

                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenVatTu.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtDVT1.Text = dt.Rows[0]["DonViTinh"].ToString();
                }
            }
            catch
            { }
        }
    }
}
