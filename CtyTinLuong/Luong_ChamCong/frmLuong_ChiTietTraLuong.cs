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
    public partial class frmLuong_ChiTietTraLuong : Form
    {
        int bienthangthai = 0;

        DataTable dtdoituong = new DataTable();
        private void HienThi_ALL_DaiLy()
        {
            clsNgayThang clsnt = new clsNgayThang();
            DateTime ngayvatdau = clsnt.GetFistDayInMonth(Convert.ToInt32(txtNam.Text), Convert.ToInt32(txtThang.Text));
            DateTime ngayketthu = clsnt.GetLastDayInMonth(Convert.ToInt32(txtNam.Text), Convert.ToInt32(txtThang.Text));
           
            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt3 = cls1.SD_w_TU(Convert.ToInt32(txtNam.Text), Convert.ToInt32(txtThang.Text), ngayvatdau, ngayketthu);
            gridControl2.DataSource = null;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietTraLuong", typeof(int));
            dt2xx.Columns.Add("ID_TraLuong", typeof(int));
            dt2xx.Columns.Add("ID_DoiTuong", typeof(int));
            dt2xx.Columns.Add("MaDoiTuong", typeof(string));
            dt2xx.Columns.Add("DoiTuong", typeof(string));
            dt2xx.Columns.Add("Luong_Thang", typeof(int));
            dt2xx.Columns.Add("Luong_Nam", typeof(int));
            dt2xx.Columns.Add("SoTien", typeof(double));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = dt2xx.NewRow();
                    //_ravi["ID_ChiTietTraLuong"] = dt3.Rows[i]["ID_ChiTietTraLuong"].ToString();
                    //_ravi["ID_TraLuong"] = dt3.Rows[i]["ID_TraLuong"].ToString();
                    _ravi["ID_DoiTuong"] = dt3.Rows[i]["ID_DaiLy"].ToString();
                    _ravi["MaDoiTuong"] = dt3.Rows[i]["ID_DaiLy"].ToString();
                    _ravi["DoiTuong"] = dt3.Rows[i]["TenDaiLy"].ToString();
                    _ravi["Luong_Thang"] = Convert.ToInt32(txtThang.Text);
                    _ravi["Luong_Nam"] = Convert.ToInt32(txtNam.Text);
                    _ravi["SoTien"] =CheckString.ConvertToDouble_My(dt3.Rows[i]["Tongtien"].ToString())- CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                    //_ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    _ravi["HienThi"] = "1";
                    dt2xx.Rows.Add(_ravi);
                }
            }

            gridControl2.DataSource = dt2xx;
        }
        public string SoChungTu_tbThuChi()
        {
            string sochungtuThuChi = "";
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
            clsTraLuong_new cls = new CtyTinLuong.clsTraLuong_new();
            DataTable dtthuchi = cls.SelectAll();
            dtthuchi.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dvthuchi = dtthuchi.DefaultView;
            DataTable dvthuchi3 = dvthuchi.ToTable();
            int k = dvthuchi3.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "TL 1";
            else
            {
                string xxx = dvthuchi3.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
                txtSoChungTu.Text = "TL " + xxx2 + "";
            }

            string thang = DateTime.Today.ToString("MM");
            string nam = DateTime.Today.ToString("yyyy");
            dteNgayChungTu.DateTime = DateTime.Today;
            txtNam.Text = nam;
            txtThang.Text = thang;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietTraLuong", typeof(int));
            dt2xx.Columns.Add("ID_TraLuong", typeof(int));
            dt2xx.Columns.Add("ID_DoiTuong", typeof(int));
            dt2xx.Columns.Add("MaDoiTuong", typeof(string));
            dt2xx.Columns.Add("DoiTuong", typeof(string));
            dt2xx.Columns.Add("Luong_Thang", typeof(int));
            dt2xx.Columns.Add("Luong_Nam", typeof(int));
            dt2xx.Columns.Add("SoTien", typeof(double));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));
            gridControl2.DataSource = dt2xx;
        }
        private void HienThi_Sua(int iiID_TraLuong)
        {
            clsTraLuong_new cls = new CtyTinLuong.clsTraLuong_new();
            cls.iID_TraLuong = iiID_TraLuong;
            DataTable dt = cls.SelectOne();

            gridDoiTuong.EditValue = cls.iID_DoiTuong.Value;
            txtSoChungTu.Text = cls.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            txtThang.Text = cls.iLuong_Thang.Value.ToString();
            txtNam.Text = cls.iLuong_Nam.Value.ToString();
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtTongSoTien.Text = cls.fTongSoTien.Value.ToString();
            txtGhiChu.Text = cls.sGhiChu.Value;
            if (cls.bCheckDaiLy == true)
                checkDaiLy.Checked = true;
            else checkCongNhanVien.Checked = true;
            if (cls.bGuiDuLieu == true)
                btLuu_Gui.Enabled = false;
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

            clsTraLuong_ChiTietTraLuong_new cls2 = new clsTraLuong_ChiTietTraLuong_new();
            cls2.iID_TraLuong = iiID_TraLuong;
            DataTable dtchitiet = new DataTable();
            if (checkDaiLy.Checked == true)
                dtchitiet = cls2.SA_W_ID_TraLuong_DaiLy();
            else dtchitiet = cls2.SA_W_ID_TraLuong_CongNhan();
            gridControl2.DataSource = null;
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_ChiTietTraLuong", typeof(int));
            dt2xx.Columns.Add("ID_TraLuong", typeof(int));
            dt2xx.Columns.Add("ID_DoiTuong", typeof(int));
            dt2xx.Columns.Add("MaDoiTuong", typeof(string));
            dt2xx.Columns.Add("DoiTuong", typeof(string));
            dt2xx.Columns.Add("Luong_Thang", typeof(int));
            dt2xx.Columns.Add("Luong_Nam", typeof(int));
            dt2xx.Columns.Add("SoTien", typeof(double));
            dt2xx.Columns.Add("GhiChu", typeof(string));
            dt2xx.Columns.Add("HienThi", typeof(string));
            if (dtchitiet.Rows.Count > 0)
            {
                for (int i = 0; i < dtchitiet.Rows.Count; i++)
                {
                    DataRow _ravi = dt2xx.NewRow();
                    _ravi["ID_ChiTietTraLuong"] = dtchitiet.Rows[i]["ID_ChiTietTraLuong"].ToString();
                    _ravi["ID_TraLuong"] = dtchitiet.Rows[i]["ID_TraLuong"].ToString();
                    _ravi["ID_DoiTuong"] = dtchitiet.Rows[i]["ID_DoiTuong"].ToString();
                    _ravi["MaDoiTuong"] = dtchitiet.Rows[i]["ID_DoiTuong"].ToString();
                    _ravi["DoiTuong"] = dtchitiet.Rows[i]["DoiTuong"].ToString();
                    _ravi["Luong_Thang"] = dtchitiet.Rows[i]["Luong_Thang"].ToString();
                    _ravi["Luong_Nam"] = dtchitiet.Rows[i]["Luong_Nam"].ToString();
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
                cls1.fSoTien = CheckString.ConvertToDouble_My(txtTongSoTien.Text.ToString());
                cls1.sThamChieu = txtSoChungTu.Text;
                cls1.sDoiTuong = txtDoiTuong.Text.ToString();
                cls1.bTonTai = true;
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.bNgungTheoDoi = false;
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.bTienUSD = false;
                cls1.fTiGia = 1;
                cls1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4_DoiTien_5 = bienthangthai;
               
                cls1.iBienMuaHang1_BanHang2_ConLai_0 = 9;

                clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
                cls2.daNgayChungTu = dteNgayChungTu.DateTime;
                cls2.sThamChieu = txtSoChungTu.Text.ToString();
                cls2.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                DataTable dt1 = cls2.SelectOne_W_Ngay_ThamChieu_ID_DoiTuong();
                if (dt1.Rows.Count == 0)
                {
                    cls1.bDaGhiSo = false;

                    cls1.Insert();

                }
                else
                {
                    cls1.bDaGhiSo = Convert.ToBoolean(dt1.Rows[0]["DaGhiSo"].ToString());
                    cls1.iID_ThuChi = Convert.ToInt32(dt1.Rows[0]["ID_ThuChi"].ToString());
                    cls1.Update();
                }

            }
        }
        private void Luu_ChiTiet_TraLuong(int xxxID_Traluong)
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsTraLuong_ChiTietTraLuong_new cls2 = new CtyTinLuong.clsTraLuong_ChiTietTraLuong_new();
                string shienthi = "1";
                DataTable dtkkk = (DataTable)gridControl2.DataSource;
                dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                DataView dv2232xx = dtkkk.DefaultView;
                DataTable dt_gridcontrol = dv2232xx.ToTable();
                DataTable dt2_cu = new DataTable();

                cls2.iID_TraLuong = xxxID_Traluong;
                dt2_cu = cls2.SA_W_ID_TraLuong();
                if (dt2_cu.Rows.Count > 0)
                {
                    for (int i = 0; i < dt2_cu.Rows.Count; i++)
                    {
                        cls2.iID_TraLuong = xxxID_Traluong;
                        cls2.bTonTai = false;
                        cls2.Update_ALL_TonTai_W_ID_TraLuong();
                    }
                }
                for (int i = 0; i < dt_gridcontrol.Rows.Count; i++)
                {


                    int iiID_DoiTuong = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_DoiTuong"].ToString());
                    cls2 = new CtyTinLuong.clsTraLuong_ChiTietTraLuong_new();

                    cls2.iID_TraLuong = xxxID_Traluong;
                    cls2.iID_DoiTuong = Convert.ToInt32(dt_gridcontrol.Rows[i]["ID_DoiTuong"].ToString());
                    cls2.iLuong_Thang = Convert.ToInt32(txtThang.Text);
                    cls2.iLuong_Nam = Convert.ToInt32(txtNam.Text);
                    cls2.bCheckDaiLy = checkDaiLy.Checked;
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
                        cls2.iID_ChiTietTraLuong = Convert.ToInt32(foundRows[0]["ID_ChiTietTraLuong"].ToString());
                        cls2.Update();
                    }
                    else
                    {
                        cls2.Insert();
                    }
                }

                // xoa ton tai=false
                DataTable dt2_moi11111 = new DataTable();
                cls2 = new CtyTinLuong.clsTraLuong_ChiTietTraLuong_new();
                cls2.iID_TraLuong = xxxID_Traluong;
                dt2_moi11111 = cls2.SA_W_ID_TraLuong();
                dt2_moi11111.DefaultView.RowFilter = "TonTai = False";
                DataView dvdt2_moi = dt2_moi11111.DefaultView;
                DataTable dt2_moi = dvdt2_moi.ToTable();
                for (int i = 0; i < dt2_moi.Rows.Count; i++)
                {
                    int ID_ChiTietTamUngxx = Convert.ToInt32(dt2_moi.Rows[i]["ID_ChiTietTamUng"].ToString());
                    cls2.iID_ChiTietTraLuong = ID_ChiTietTamUngxx;
                    cls2.Delete();
                }

            }
        }
        private void LuuDuLieu_TraLuong()
        {
            if (!KiemTraLuu()) return;
            else
            {

                int xxID_traluong_ = 0;
                clsTraLuong_new cls1 = new clsTraLuong_new();
                cls1.daNgayChungTu = dteNgayChungTu.DateTime;
                cls1.sSoChungTu = txtSoChungTu.Text.ToString();
                cls1.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                cls1.iID_DoiTuong = Convert.ToInt32(gridDoiTuong.EditValue.ToString());
                cls1.iLuong_Thang = Convert.ToInt32(txtThang.Text);
                cls1.iLuong_Nam = Convert.ToInt32(txtNam.Text);
                cls1.fTongSoTien = CheckString.ConvertToDouble_My(txtTongSoTien.Text.ToString());
                cls1.sDienGiai = txtDienGiai.Text.ToString();
                cls1.bCheckDaiLy = checkDaiLy.Checked;
                cls1.sGhiChu = txtGhiChu.Text;
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                if (UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong == true)
                {
                    cls1.bGuiDuLieu = false;
                    cls1.Insert();
                    xxID_traluong_ = cls1.iID_TraLuong.Value;

                }
                else
                {
                    xxID_traluong_ = UCLuong_TraLuongNewwwwwwwwww.mID_TraLuong_Sua;

                    clsTraLuong_new cls2 = new clsTraLuong_new();
                    cls2.iID_TraLuong = xxID_traluong_;
                    DataTable dt2 = cls2.SelectOne();
                    cls1.bGuiDuLieu = cls2.bGuiDuLieu.Value;

                    cls1.iID_TraLuong = xxID_traluong_;
                    cls1.Update();
                }
                Luu_ChiTiet_TraLuong(xxID_traluong_);

            }
        }
        private void LuuDuLieu_ChiLuu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                LuuDuLieu_TraLuong();
                MessageBox.Show("Đã lưu");
            }
        }

        private void LuuDuLieu_Va_GuiDuLieu()
        {
            if (!KiemTraLuu()) return;
            else
            {
                LuuDuLieu_TraLuong();
                LuuDuLieu_ThuChi();
                MessageBox.Show("Đã lưu và gửi dữ liệu");
            }
        }
        public frmLuong_ChiTietTraLuong()
        {
            InitializeComponent();
        }

        private void frmLuong_ChiTietTraLuong_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            if (UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong == true)
                HienThi_ThemMoi();
            else HienThi_Sua(UCLuong_TraLuongNewwwwwwwwww.mID_TraLuong_Sua);
            Load_LockUp_DoiTuong();
            Cursor.Current = Cursors.Default;
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

        private void txtTongSoTien_TextChanged(object sender, EventArgs e)
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
                deTOngtien = CheckString.ConvertToDouble_My(xxxx);
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
            LuuDuLieu_ChiLuu();
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
                    deTOngtien = CheckString.ConvertToDouble_My(xxxx);
                else deTOngtien = 0;
                txtTongSoTien.Text = deTOngtien.ToString();
            }
            catch
            { }
        }

        private void btLuu_Gui_Click(object sender, EventArgs e)
        {
            LuuDuLieu_Va_GuiDuLieu();
        }

        private void checkALL_CheckedChanged(object sender, EventArgs e)
        {
            if(UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong==true)
            {
                if(checkALL.Checked==true)
                {
                    if(checkDaiLy.Checked==true)
                    {
                        HienThi_ALL_DaiLy();
                    }
                }
            }
        }
    }
}
