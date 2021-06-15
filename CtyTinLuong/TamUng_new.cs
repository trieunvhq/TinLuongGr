using DevExpress.XtraGrid.Views.Grid;
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
        public string SoChungTu_tbThuChi()
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
                    _ravi["DoiTuong"] = dt3.Rows[i]["TenNhanVien"].ToString();
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

                gridDoiTuong_gridControl.DataSource = dtdoituong;
                gridDoiTuong_gridControl.ValueMember = "ID_DoiTuong";
                gridDoiTuong_gridControl.DisplayMember = "MaDoiTuong";
                
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
                    _ravi["DoiTuong"] = dt3.Rows[i]["TenDaiLy"].ToString();                 
                    dtdoituong.Rows.Add(_ravi);
                }
                gridDoiTuong.Properties.DataSource = dtdoituong;
                gridDoiTuong.Properties.ValueMember = "ID_DoiTuong";
                gridDoiTuong.Properties.DisplayMember = "MaDoiTuong";

                gridDoiTuong_gridControl.DataSource = dtdoituong;
                gridDoiTuong_gridControl.ValueMember = "ID_DoiTuong";
                gridDoiTuong_gridControl.DisplayMember = "MaDoiTuong";
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
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietTamUng", typeof(int));
            dt2xx.Columns.Add("ID_TamUng", typeof(int));
            dt2xx.Columns.Add("ID_DoiTuong", typeof(int));
            dt2xx.Columns.Add("MaDoiTuong", typeof(string));
            dt2xx.Columns.Add("DoiTuong", typeof(string));
            dt2xx.Columns.Add("KhauTruLuongThang", typeof(int));
            dt2xx.Columns.Add("KhauTruLuongThang_Nam", typeof(int));
            dt2xx.Columns.Add("SoTien", typeof(double));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));
            gridControl2.DataSource = dt2xx;
        }
        private void HienThi_Sua(int iiDI_tamung)
        {
            clsTamUng_New cls = new CtyTinLuong.clsTamUng_New();
            cls.iID_TamUng = iiDI_tamung;
            DataTable dt = cls.SelectOne();

            gridDoiTuong.EditValue = cls.iID_DoiTuong.Value;
            txtSoChungTu.Text = cls.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            txtThang.Text = cls.iKhauTruLuongThang.Value.ToString();
            txtNam.Text = cls.iKhauTruLuongThang_Nam.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtTongSoTien.Text = cls.fTongSoTien.Value.ToString();
            txtGhiChu.Text = cls.sGhiChu.Value;
            if (cls.bCheckTamUngDaiLy == true)
                checkDaiLy.Checked = true;
            else checkCongNhanVien.Checked = true;

           
            clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
            cls1.daNgayChungTu = dteNgayChungTu.DateTime;
            cls1.sThamChieu = txtSoChungTu.Text.ToString();
            cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
            DataTable dt1 = cls1.SelectOne_W_Ngay_ThamChieu_ID_DoiTuong();
            if (dt1.Rows.Count > 0)
            {
                int bientrangthaixx = Convert.ToInt32(dt1.Rows[0]["BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4"].ToString());
                if (bientrangthaixx == 3)
                {
                    bienthangthai = 3;
                    checkPhieuChi.Checked = true;
                    checkBaoNo.Checked = false;
                }
                if (bientrangthaixx == 2)
                {
                    bienthangthai = 2;
                    checkPhieuChi.Checked = false;
                    checkBaoNo.Checked = true;
                }
            }

            clsTamUng_ChiTietTamUng cls2 = new clsTamUng_ChiTietTamUng();
            cls2.iID_TamUng = iiDI_tamung;
            DataTable dtchitiet = new DataTable();
            if(checkDaiLy.Checked==true)
                dtchitiet = cls2.SA_W_ID_TamUng_DaiLy();
            else dtchitiet = cls2.SA_W_ID_TamUng_CongNhan();
            gridControl2.DataSource = null;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietTamUng", typeof(int));
            dt2xx.Columns.Add("ID_TamUng", typeof(int));
            dt2xx.Columns.Add("ID_DoiTuong", typeof(int));
            dt2xx.Columns.Add("MaDoiTuong", typeof(string));
            dt2xx.Columns.Add("DoiTuong", typeof(string));
            dt2xx.Columns.Add("KhauTruLuongThang", typeof(int));
            dt2xx.Columns.Add("KhauTruLuongThang_Nam", typeof(int));
            dt2xx.Columns.Add("SoTien", typeof(double));            
            dt2xx.Columns.Add("GhiChu", typeof(string));      
            dt2xx.Columns.Add("HienThi", typeof(string));
            if(dtchitiet.Rows.Count>0)
            {
                for(int i=0; i< dtchitiet.Rows.Count; i++)
                {
                    DataRow _ravi = dt2xx.NewRow();
                    _ravi["ID_ChiTietTamUng"] = dtchitiet.Rows[i]["ID_ChiTietTamUng"].ToString();
                    _ravi["ID_TamUng"] = dtchitiet.Rows[i]["ID_TamUng"].ToString();
                    _ravi["ID_DoiTuong"] = dtchitiet.Rows[i]["ID_DoiTuong"].ToString();
                    _ravi["MaDoiTuong"] = dtchitiet.Rows[i]["ID_DoiTuong"].ToString();
                    _ravi["DoiTuong"] = dtchitiet.Rows[i]["DoiTuong"].ToString();
                    _ravi["KhauTruLuongThang"] = dtchitiet.Rows[i]["KhauTruLuongThang"].ToString();
                    _ravi["KhauTruLuongThang_Nam"] = dtchitiet.Rows[i]["KhauTruLuongThang_Nam"].ToString();
                    _ravi["SoTien"] = dtchitiet.Rows[i]["SoTien"].ToString();
                    _ravi["GhiChu"] = dtchitiet.Rows[i]["GhiChu"].ToString();
                    _ravi["HienThi"] = "1";
                    dt2xx.Rows.Add(_ravi);
                }
            }
           
            gridControl2.DataSource = dt2xx;
        }
        private bool KiemTraLuu()
        {
            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl2.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dt_gridcontrol = dv.ToTable();

            if (dt_gridcontrol.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu tạm ứng ");
                return false;
            }
            if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }
            else if (gridDoiTuong.EditValue == null)
            {
                MessageBox.Show("Chưa có người tạm ứng ");
                return false;
            }
            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người mua hàng ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }
            else return true;

        } 

        private void LuuDuLieu_ThuChi()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsNganHang_tbThuChi cls1 = new clsNganHang_tbThuChi();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = SoChungTu_tbThuChi();
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.fSoTien = Convert.ToDouble(txtTongSoTien.Text.ToString());
                cls1.sThamChieu = txtSoChungTu.Text;
                cls1.sDoiTuong = txtDoiTuong.Text.ToString();
                cls1.bTonTai = true;
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = false;
                cls1.fTiGia = 1;
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                cls1.bDaGhiSo = true;
                cls1.iBienMuaHang1_BanHang2_ConLai_0 = 9;

                clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
                cls2.daNgayChungTu = dteNgayChungTu.DateTime;
                cls2.sThamChieu = txtSoChungTu.Text.ToString();
                cls2.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                DataTable dt1 = cls2.SelectOne_W_Ngay_ThamChieu_ID_DoiTuong();
                if (dt1.Rows.Count == 0)
                {
                    cls1.Insert();
                   
                }
                else
                {

                    cls1.iID_ThuChi = Convert.ToInt32(dt1.Rows[0]["ID_ThuChi"].ToString());
                    cls1.Update();
                }
               
            }
        }
        private void Luu_ChiTiet_TamUng(int xxxID_TamUng)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTamUng_ChiTietTamUng cls2 = new CtyTinLuong.clsTamUng_ChiTietTamUng();
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();
                DataTable dt2_cu = new DataTable();

                cls2.iID_TamUng = xxxID_TamUng;
                dt2_cu = cls2.SA_W_ID_TamUng();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        cls2.iID_TamUng = xxxID_TamUng;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai_W_ID_TamUng();
                    }
                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {
                    
                                
                    int iiID_DoiTuong= Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_DoiTuong"].ToString());
                    cls2 = new CtyTinLuong.clsTamUng_ChiTietTamUng();

                    cls2.iID_TamUng = xxxID_TamUng;
                    cls2.iID_DoiTuong = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_DoiTuong"].ToString());
                    cls2.iKhauTruLuongThang = Convert.ToInt32(dt_gridcontrol.Rows[i]["KhauTruLuongThang"].ToString());
                    cls2.iKhauTruLuongThang_Nam = Convert.ToInt32(txtNam.Text);                   
                    cls2.bCheckTamUngDaiLy = checkDaiLy.Checked;
                    cls2.bTonTai = true;
                    cls2.bNgungTheoDoi = false;
                    cls2.fSoTien = Convert.ToInt32(dt_gridcontrol.Rows[i]["SoTien"].ToString());
                    cls2.sGhiChu = dt_gridcontrol.Rows[i]["GhiChu"].ToString();
                    string expressionnhapkho;
                    expressionnhapkho = "ID_DoiTuong=" + iiID_DoiTuong + "";
                    DataRow[] foundRows;
                    foundRows = dt2_cu.Select(expressionnhapkho);
                    if (foundRows.Length > 0)
                    {
                        cls2.iID_ChiTietTamUng = Convert.ToInt32(foundRows[0]["ID_ChiTietTamUng"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2 = new CtyTinLuong.clsTamUng_ChiTietTamUng();
                cls2.iID_TamUng = xxxID_TamUng;
                dt2_moi11111 = cls2.SA_W_ID_TamUng();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietTamUngxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietTamUng"].ToString());
                    cls2.iID_ChiTietTamUng = ID_ChiTietTamUngxx;
                    cls2.Delete();
                }

            }
        }
        private void LuuDuLieu_TamUng()
        {
            if (!KiemTraLuu()) return;
            else
            {
                
                int xxID_tamung = 0;
                clsTamUng_New cls1 = new clsTamUng_New();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.iKhauTruLuongThang = Convert.ToInt32(txtThang.Text);
                cls1.iKhauTruLuongThang_Nam = Convert.ToInt32(txtNam.Text);             
                cls1.fTongSoTien = Convert.ToDouble(txtTongSoTien.Text.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bCheckTamUngDaiLy = checkDaiLy.Checked;
                cls1.sGhiChu = txtGhiChu.Text;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                if (UCLuong_TamUng.mbThemMoiTamUng == true)
                {
                    cls1.bGuiDuLieu = false;
                    cls1.Insert();
                    xxID_tamung = cls1.iID_TamUng.Value;

                }
                else
                {
                    xxID_tamung = UCLuong_TamUng.miiiiID_TamUng;

                    clsTamUng_New cls2 = new clsTamUng_New();
                    cls2.iID_TamUng = xxID_tamung;
                    DataTable dt2 = cls2.SelectOne();
                    cls1.bGuiDuLieu = cls2.bGuiDuLieu.Value;
                   
                    cls1.iID_TamUng = xxID_tamung;
                    cls1.Update();
                }
                Luu_ChiTiet_TamUng(xxID_tamung);

            }
        }
        private void LuuDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                LuuDuLieu_TamUng();
                LuuDuLieu_ThuChi();
                MessageBox.Show("Đã lưu");
            }
        }

     
        public TamUng_new()
        {
            InitializeComponent();
        }

        private void TamUng_new_Load(object sender, EventArgs e)
        {
            dtdoituong.Columns.Add("ID_DoiTuong", typeof(int));
            dtdoituong.Columns.Add("MaDoiTuong", typeof(string));
            dtdoituong.Columns.Add("DoiTuong", typeof(string));

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            clKhauTruLuongThang.Caption = "Khấu trừ\ntháng";
            Load_LockUp_DoiTuong();
            if (UCLuong_TamUng.mbThemMoiTamUng == true)
                HienThi_ThemMoi();
            else HienThi_Sua(UCLuong_TamUng.miiiiID_TamUng);
            Load_LockUp_DoiTuong();
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
                decimal value = decimal.Parse(txtTongSoTien.Text);
                txtTongSoTien.Text = String.Format("{0:#,##0.00}", value);
               
            }
            catch
            {

            }
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clHienThi, "0");
           // gridView4.SetRowCellValue(gridView4.FocusedRowHandle, clSoLuong, 0);
        }

        private void gridView4_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            if (e.Column == clMaDoiTuong)
            {
                int iiID_DoiTuong = Convert.ToInt32(gridView4.GetRowCellValue(e.RowHandle, e.Column));

                string expressionnhapkho;
                expressionnhapkho = "ID_DoiTuong=" + iiID_DoiTuong + "";
                DataRow[] foundRows;
                foundRows = dtdoituong.Select(expressionnhapkho);
                string tendoituong = "";
                if (foundRows.Length > 0)
                {
                    tendoituong = foundRows[0]["DoiTuong"].ToString();
                }


                int xxthang = Convert.ToInt32(txtThang.Text);
                gridView4.SetRowCellValue(e.RowHandle, clKhauTruLuongThang, xxthang);
                gridView4.SetRowCellValue(e.RowHandle, clID_DoiTuong, iiID_DoiTuong);
                gridView4.SetRowCellValue(e.RowHandle, clDoiTuong, tendoituong);
                gridView4.SetRowCellValue(e.RowHandle, clHienThi, "1");
                gridView4.SetRowCellValue(e.RowHandle, clSoTien, 0);


            }

            
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl2.DataSource;
            string shienthi = "1";
            object xxxx = dataTable.Compute("sum(SoTien)", "HienThi=" + shienthi + "");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongSoTien.Text = deTOngtien.ToString();
        }

        private void btThooat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iiID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                string expressionnhapkho;
                expressionnhapkho = "ID_DoiTuong=" + iiID_DoiTuong + "";
                DataRow[] foundRows;
                foundRows = dtdoituong.Select(expressionnhapkho);              
                if (foundRows.Length > 0)
                {
                    txtDoiTuong.Text = foundRows[0]["DoiTuong"].ToString();
                }
            }
            catch
            {

            }
          
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiLap.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl2.DataSource;
                string shienthi = "1";
                object xxxx = dataTable.Compute("sum(SoTien)", "HienThi=" + shienthi + "");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongSoTien.Text = deTOngtien.ToString();
            }
            catch
            { }
        }
    }
}
