using DevExpress.Data.Filtering;
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

        public static DataTable mdttableDuLieuTraLuong;
        public static DateTime mdangaythang;
        public static string msNguoiLap;
        int bienthangthai = 3; string sochungtu_tbThuChi;

        public void HienThiSoChungTu(int bientrangthaikkkkkkkkkk)
        {
            clsNganHang_tbThuChi cls2 = new clsNganHang_tbThuChi();
            DataTable dt = cls2.SelectAll();
            if (bientrangthaikkkkkkkkkk == 1)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =1 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BC 1";
                    else txtsochungtu_tbThuChi.Text = "BC " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 2)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =2 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "BN 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "BN 1";
                    else txtsochungtu_tbThuChi.Text = "BN " + xxx2 + "";
                }
            }

            else if (bientrangthaikkkkkkkkkk == 3)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =3 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PC 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PC 1";
                    else txtsochungtu_tbThuChi.Text = "PC " + xxx2 + "";
                }
            }
            else if (bientrangthaikkkkkkkkkk == 4)
            {
                dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and BienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 =4 ";
                DataView dv2 = dt.DefaultView;
                DataTable newdt2 = dv2.ToTable();
                int k = newdt2.Rows.Count;
                if (k == 0)
                {
                    txtsochungtu_tbThuChi.Text = "PT 1";
                }
                else
                {
                    string xxx = newdt2.Rows[k - 1]["SoChungTu"].ToString();
                    int xxx2 = Convert.ToInt32(xxx.Substring(2).Trim()) + 1;
                    if (xxx2 >= 10000)
                        txtsochungtu_tbThuChi.Text = "PT 1";
                    else txtsochungtu_tbThuChi.Text = "PT " + xxx2 + "";
                }
            }
        }
        private void Luu__TbThuChi()
        {
            if (!KiemTraLuu()) return;
            else
            {
                HienThiSoChungTu(bienthangthai);
                sochungtu_tbThuChi = txtsochungtu_tbThuChi.Text.ToString();
                clsNganHang_tbThuChi clsxxx1 = new clsNganHang_tbThuChi();
                clsxxx1.daNgayChungTu = dteNgayChungTu.DateTime;
                clsxxx1.sSoChungTu = sochungtu_tbThuChi;
                clsxxx1.sDienGiai = txtDienGiai.Text.ToString();
                clsxxx1.fSoTien = Convert.ToDouble(txtSoTienThanhToan.Text.ToString());
                clsxxx1.sThamChieu = txtSoChungTu.Text.ToString();
                clsxxx1.sDoiTuong = "TT Lương";
                clsxxx1.bTonTai = true;
                clsxxx1.bNgungTheoDoi = false;
                clsxxx1.iID_NguoiLap = 13;
                clsxxx1.bTienUSD = false;
                clsxxx1.fTiGia = 1;
                clsxxx1.iBienTrangThai_BaoCo1_BaoNo_2_PhieuChi3_PhieuThu4 = bienthangthai;
                clsxxx1.bDaGhiSo = false;
                //clsxxx1.bBitThuChiKhac = false;
                clsxxx1.iID_DoiTuong = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                clsxxx1.iBienMuaHang1_BanHang2_ConLai_0 = 0;
                clsxxx1.Insert();
                // không Lưu chi tiết biến động tài khoản ngân hàng

            }
        }
        private bool KiemTraLuu()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "Chon=True";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();
            if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chọn chứng từ mua hàng để thanh toán ");
                return false;
            }
            else if (txtSoChungTu.Text.ToString() == "")
            {
                MessageBox.Show("Chưa có số CT ");
                return false;
            }

            else if (gridNguoiLap.EditValue == null)
            {
                MessageBox.Show("Chưa có người trả lương ");
                return false;
            }
            else if (dteNgayChungTu.EditValue == null)
            {
                MessageBox.Show("Chưa chọn ngày chứng từ ");
                return false;
            }
            //else if (gridTKCo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa TK có ");
            //    return false;
            //}
            //else if (gridTKNo.EditValue == null)
            //{
            //    MessageBox.Show("Chưa chọn TK nợ ");
            //    return false;
            //}
            
            else if (Convert.ToDouble(txtSoTienThanhToan.Text.ToString()) == 0)
            {
                MessageBox.Show("Số tiền thanh toán lớn hơn 0 ");
                return false;
            }
            else return true;

        }        
        private void LUU_DuLieu_ChiLuu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                clsHUU_CongNhat_TraLuong cls = new clsHUU_CongNhat_TraLuong();               
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "Chon=True";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();
                decimal sotienthanhtoan = Convert.ToDecimal(txtSoTienThanhToan.Text.ToString());
                if (UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong == true)
                {
                    if (dv3.Rows.Count == 1)
                    {
                        cls.daNgayChungTu = dteNgayChungTu.DateTime;
                        cls.sSoChungTu = txtSoChungTu.Text.ToString();
                        cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                        cls.sDienGiai = txtDienGiai.Text.ToString();
                        cls.bTonTai = true;
                        cls.bNgungTheoDoi = false;
                        cls.bGuiDuLieu = false;
                        cls.bDaTraLuong = false;
                        cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[0]["ID_CongNhan"].ToString());
                        cls.iThang = Convert.ToInt16(dv3.Rows[0]["Thang"].ToString());
                        cls.iNam = Convert.ToInt16(dv3.Rows[0]["Nam"].ToString());
                        cls.dcSoTien = sotienthanhtoan;
                        cls.Insert();

                    }
                    else
                    {
                        for (int i = 0; i < dv3.Rows.Count; i++)
                        {
                            cls.daNgayChungTu = dteNgayChungTu.DateTime;
                            cls.sSoChungTu = txtSoChungTu.Text.ToString();
                            cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                            cls.sDienGiai = txtDienGiai.Text.ToString();
                            cls.bTonTai = true;
                            cls.bNgungTheoDoi = false;
                            cls.bGuiDuLieu = false;
                            cls.bDaTraLuong = false;
                            cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[i]["ID_CongNhan"].ToString());
                            cls.iThang = Convert.ToInt16(dv3.Rows[i]["Thang"].ToString());
                            cls.iNam = Convert.ToInt16(dv3.Rows[i]["Nam"].ToString());
                            cls.dcSoTien = Convert.ToDecimal(dv3.Rows[i]["ThucNhan"].ToString());
                            cls.Insert();
                        }
                    }
                }
                else
                {
                    cls.iID_TraLuong = UCLuong_TraLuongNewwwwwwwwww.mID_TraLuong_Sua;
                    cls.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls.sDienGiai = txtDienGiai.Text.ToString();
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.bGuiDuLieu = false;
                    cls.bDaTraLuong = false;
                    cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[0]["ID_CongNhan"].ToString());
                    cls.iThang = Convert.ToInt16(dv3.Rows[0]["Thang"].ToString());
                    cls.iNam = Convert.ToInt16(dv3.Rows[0]["Nam"].ToString());
                    cls.dcSoTien = sotienthanhtoan;
                    cls.Update();
                }

                
            }

        }
        private void Luu__VaobangLuong()
        {
            if (!KiemTraLuu()) return;
            else
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
               
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "Chon=True";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();
                if (dv3.Rows.Count == 1)
                {
                    decimal sotienthanhtoan = Convert.ToDecimal(txtSoTienThanhToan.Text.ToString());
                    cls.iID_CongNhan = Convert.ToInt16(dv3.Rows[0]["ID_CongNhan"].ToString());
                    cls.iThang = Convert.ToInt16(dv3.Rows[0]["Thang"].ToString());
                    cls.iNam = Convert.ToInt16(dv3.Rows[0]["Nam"].ToString());
                    DataTable dtxxjjg = cls.SelectOne_W_Thang_Nam_ID_Congnhan();
                    decimal SoTienDaTraLuong_Cu = Convert.ToDecimal(dv3.Rows[0]["SoTienDaTraLuong"].ToString());
                    cls.dcSoTienDaTraLuong = SoTienDaTraLuong_Cu + sotienthanhtoan;
                    cls.Update_SoTienDaTraLuong_W_ID_CongNhanh_W_thang_Nam();
                    decimal luonglonnhat = Convert.ToDecimal(dtxxjjg.Rows[0]["LuongLonNhat"].ToString());
                    int ID_ChiTietChamCongxxx= Convert.ToInt16(dtxxjjg.Rows[0]["ID_ChiTietChamCong"].ToString());
                    if (luonglonnhat == SoTienDaTraLuong_Cu + sotienthanhtoan)
                    {
                        cls.iID_ChiTietChamCong = ID_ChiTietChamCongxxx;
                        cls.Update_DaTraLuong();
                    }
                }
                else
                {
                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls.iID_CongNhan = Convert.ToInt16(dv3.Rows[i]["ID_CongNhan"].ToString());
                        cls.iThang = Convert.ToInt16(dv3.Rows[i]["Thang"].ToString());
                        cls.iNam = Convert.ToInt16(dv3.Rows[i]["Nam"].ToString());
                        DataTable dtxxjjg = cls.SelectOne_W_Thang_Nam_ID_Congnhan();
                        decimal SoTienDaTraLuong_Cu = Convert.ToDecimal(dv3.Rows[i]["SoTienDaTraLuong"].ToString());
                        decimal sotienthanhtoan2222 = Convert.ToDecimal(dv3.Rows[i]["ThucNhan"].ToString());
                        cls.dcSoTienDaTraLuong = SoTienDaTraLuong_Cu + sotienthanhtoan2222;
                        cls.Update_SoTienDaTraLuong_W_ID_CongNhanh_W_thang_Nam();
                        decimal luonglonnhat = Convert.ToDecimal(dtxxjjg.Rows[0]["LuongLonNhat"].ToString());
                        int ID_ChiTietChamCongxxx = Convert.ToInt16(dtxxjjg.Rows[0]["ID_ChiTietChamCong"].ToString());
                        cls.iID_ChiTietChamCong = ID_ChiTietChamCongxxx;
                        cls.Update_DaTraLuong();
                     

                    }
                }

            }

        }
        private void LUU_Va_Gui_DuLieu()
        {

            if (!KiemTraLuu()) return;
            else
            {
                Luu__VaobangLuong();
                Luu__TbThuChi();
                clsHUU_CongNhat_TraLuong cls = new clsHUU_CongNhat_TraLuong();
                DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                dttttt2.DefaultView.RowFilter = "Chon=True";
                DataView dv = dttttt2.DefaultView;
                DataTable dv3 = dv.ToTable();
                decimal sotienthanhtoan = Convert.ToDecimal(txtSoTienThanhToan.Text.ToString());
                if (UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong == true)
                {
                    if (dv3.Rows.Count == 1)
                    {
                        cls.daNgayChungTu = dteNgayChungTu.DateTime;
                        cls.sSoChungTu = txtSoChungTu.Text.ToString();
                        cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                        cls.sDienGiai = txtDienGiai.Text.ToString();
                        cls.bTonTai = true;
                        cls.bNgungTheoDoi = false;
                        cls.bGuiDuLieu = true;
                        cls.bDaTraLuong = false;
                        cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[0]["ID_CongNhan"].ToString());
                        cls.iThang = Convert.ToInt16(dv3.Rows[0]["Thang"].ToString());
                        cls.iNam = Convert.ToInt16(dv3.Rows[0]["Nam"].ToString());
                        cls.dcSoTien = sotienthanhtoan;
                        cls.Insert();

                    }
                    else
                    {
                        for (int i = 0; i < dv3.Rows.Count; i++)
                        {
                            cls.daNgayChungTu = dteNgayChungTu.DateTime;
                            cls.sSoChungTu = txtSoChungTu.Text.ToString();
                            cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                            cls.sDienGiai = txtDienGiai.Text.ToString();
                            cls.bTonTai = true;
                            cls.bNgungTheoDoi = false;
                            cls.bGuiDuLieu = true;
                            cls.bDaTraLuong = false;
                            cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[i]["ID_CongNhan"].ToString());
                            cls.iThang = Convert.ToInt16(dv3.Rows[i]["Thang"].ToString());
                            cls.iNam = Convert.ToInt16(dv3.Rows[i]["Nam"].ToString());
                            cls.dcSoTien = Convert.ToDecimal(dv3.Rows[i]["ThucNhan"].ToString());
                            cls.Insert();
                        }
                    }
                }
                else
                {
                    cls.iID_TraLuong = UCLuong_TraLuongNewwwwwwwwww.mID_TraLuong_Sua;
                    cls.daNgayChungTu = dteNgayChungTu.DateTime;
                    cls.sSoChungTu = txtSoChungTu.Text.ToString();
                    cls.iID_NguoiLap = Convert.ToInt32(gridNguoiLap.EditValue.ToString());
                    cls.sDienGiai = txtDienGiai.Text.ToString();
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.bGuiDuLieu = true;
                    cls.bDaTraLuong = false;
                    cls.iID_NhanVien = Convert.ToInt16(dv3.Rows[0]["ID_CongNhan"].ToString());
                    cls.iThang = Convert.ToInt16(dv3.Rows[0]["Thang"].ToString());
                    cls.iNam = Convert.ToInt16(dv3.Rows[0]["Nam"].ToString());
                    cls.dcSoTien = sotienthanhtoan;
                    cls.Update();
                }
            }

        }      
        private void HienThi_ThemMoi()
        {
            gridNguoiLap.EditValue = 11;
            clsDaiLy_TraLuong cls = new CtyTinLuong.clsDaiLy_TraLuong();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dv2 = dv.ToTable();
            int k = dv2.Rows.Count;
            if (k == 0)
                txtSoChungTu.Text = "TL 1";
            else
            {
                string xxx = dv2.Rows[k - 1]["SoChungTu"].ToString();
                int xxx2 = Convert.ToInt16(xxx.Substring(2).Trim()) + 1;
                if(xxx2>=10000)
                    txtSoChungTu.Text = "TL 1";
               else txtSoChungTu.Text = "TL " + xxx2 + "";

            }
            HienThi_GridconTrol_ThemMoi();            
           

        }
        private void HienThi_Sua()
        {
            clsDaiLy_TraLuong cls = new CtyTinLuong.clsDaiLy_TraLuong();
            cls.iID_TraLuong = UCDaiLy_TraLuong.mID_TraLuong_Sua;
            DataTable dt = cls.SelectOne();
            txtSoChungTu.Text = cls.sSoChungTu.Value;
            dteNgayChungTu.EditValue = cls.daNgayChungTu.Value;
            gridNguoiLap.EditValue = cls.iID_NguoiLap.Value;
            txtDienGiai.Text = cls.sDienGiai.Value;
            txtSoTienThanhToan.Text = cls.dcSoTien.Value.ToString();
            txtTongTienLuong.Text = cls.dcSoTien.Value.ToString();

            HienThi_GridconTrol_Sua();
            if (cls.bDaTraLuong == true || cls.bGuiDuLieu==true)
            {
                btLuu_Dong.Enabled = false;
                btLuu_Gui_Dong.Enabled = false;
            }
           
        }
        private void HienThi_GridconTrol_ThemMoi()
        {
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            DataTable dt3 = cls.SelectAll_TraLuongCongNhan();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_CongNhan", typeof(int));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("SLThuong", typeof(double));
            dt2.Columns.Add("SLTangCa", typeof(double));
            dt2.Columns.Add("LuongCoDinh", typeof(decimal));
            dt2.Columns.Add("LuongCongNhat", typeof(decimal));
            dt2.Columns.Add("LuongSanLuong", typeof(decimal));
            dt2.Columns.Add("LuongLonNhat", typeof(decimal));
            dt2.Columns.Add("PhuCapXangXe", typeof(decimal));
            dt2.Columns.Add("PhuCapDienthoai", typeof(decimal));
            dt2.Columns.Add("PhuCapVeSinhMay", typeof(decimal));
            dt2.Columns.Add("PhuCapTienAn", typeof(decimal));
            dt2.Columns.Add("TrachNhiem", typeof(decimal));
            dt2.Columns.Add("TruTienAn", typeof(decimal));
            dt2.Columns.Add("TamUng", typeof(decimal));
            dt2.Columns.Add("BaoHiem", typeof(decimal));
            dt2.Columns.Add("SoTienDaTraLuong", typeof(decimal));
            dt2.Columns.Add("ThucNhan", typeof(decimal));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("DaTraLuong", typeof(bool));
            dt2.Columns.Add("Chon", typeof(bool));

            //LuongLonNhat
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = dt2.NewRow();
                int ID_CongNhan = Convert.ToInt32(dt3.Rows[i]["ID_CongNhan"].ToString());
                double SLThuong = Convert.ToDouble(dt3.Rows[i]["SLThuong"].ToString());
                double SLTangCa = Convert.ToDouble(dt3.Rows[i]["SLTangCa"].ToString());
                decimal LuongCoDinh = Convert.ToDecimal(dt3.Rows[i]["LuongCoDinh"].ToString());
                decimal LuongCongNhat = Convert.ToDecimal(dt3.Rows[i]["LuongCongNhat"].ToString());
                decimal LuongSanLuong = Convert.ToDecimal(dt3.Rows[i]["LuongSanLuong"].ToString());
                decimal LuongLonNhat = Convert.ToDecimal(dt3.Rows[i]["LuongLonNhat"].ToString());
                decimal PhuCapXangXe = Convert.ToDecimal(dt3.Rows[i]["PhuCapXangXe"].ToString());
                decimal PhuCapDienthoai = Convert.ToDecimal(dt3.Rows[i]["PhuCapDienthoai"].ToString());
                decimal PhuCapVeSinhMay = Convert.ToDecimal(dt3.Rows[i]["PhuCapVeSinhMay"].ToString());
                decimal PhuCapTienAn = Convert.ToDecimal(dt3.Rows[i]["PhuCapTienAn"].ToString());
                decimal TrachNhiem = Convert.ToDecimal(dt3.Rows[i]["TrachNhiem"].ToString());
                decimal TruTienAn = Convert.ToDecimal(dt3.Rows[i]["TruTienAn"].ToString());
                decimal TamUng = Convert.ToDecimal(dt3.Rows[i]["TamUng"].ToString());
                decimal BaoHiem = Convert.ToDecimal(dt3.Rows[i]["BaoHiem"].ToString());
                decimal SoTienDaTraLuong = Convert.ToDecimal(dt3.Rows[i]["SoTienDaTraLuong"].ToString());
                decimal ThucNhan;
                string TenNhanVien = dt3.Rows[i]["TenNhanVien"].ToString();
                bool DaTraLuong = Convert.ToBoolean(dt3.Rows[i]["DaTraLuong"].ToString());
                bool Chon = false;
                ThucNhan = LuongLonNhat + PhuCapXangXe + PhuCapDienthoai + PhuCapVeSinhMay + PhuCapTienAn + TrachNhiem - TruTienAn - TamUng - BaoHiem - SoTienDaTraLuong;
                cls.iID_CongNhan = ID_CongNhan;
                cls.dcThucNhan = ThucNhan;
                //cls.Update_ThucNhan_W_ID_CongNhan_W_thang_Nam();
                _ravi["ID_CongNhan"] = ID_CongNhan;
                _ravi["Thang"] = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                _ravi["Nam"] = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());
                _ravi["SLThuong"] = SLThuong;
                _ravi["SLTangCa"] = SLTangCa;
                _ravi["LuongCoDinh"] = LuongCoDinh;
                _ravi["LuongCongNhat"] = LuongCongNhat;
                _ravi["LuongSanLuong"] = LuongSanLuong;
                _ravi["LuongLonNhat"] = LuongLonNhat;
                _ravi["PhuCapXangXe"] = PhuCapXangXe;
                _ravi["PhuCapDienthoai"] = PhuCapDienthoai;
                _ravi["PhuCapVeSinhMay"] = PhuCapVeSinhMay;
                _ravi["PhuCapTienAn"] = PhuCapTienAn;
                _ravi["TrachNhiem"] = TrachNhiem;
                _ravi["TruTienAn"] = TruTienAn;
                _ravi["TamUng"] = TamUng;
                _ravi["BaoHiem"] = BaoHiem;
                _ravi["SoTienDaTraLuong"] = SoTienDaTraLuong;
                _ravi["TamUng"] = TamUng;
                _ravi["LuongCongNhat"] = LuongCongNhat;
                _ravi["LuongSanLuong"] = LuongSanLuong;
                _ravi["BaoHiem"] = BaoHiem;
                _ravi["ThucNhan"] = ThucNhan;
                _ravi["TenNhanVien"] = TenNhanVien;
                _ravi["DaTraLuong"] = DaTraLuong;
                _ravi["Chon"] = Chon;
                dt2.Rows.Add(_ravi);
            }

            dt2.DefaultView.RowFilter = "DaTraLuong=false";
            DataView dv = dt2.DefaultView;
            dv.Sort = "Nam DESC, Thang DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
           
        }
        private void HienThi_GridconTrol_Sua()
        {
            clsHUU_CongNhat_TraLuong clsxx = new CtyTinLuong.clsHUU_CongNhat_TraLuong();
            clsxx.iID_TraLuong = UCLuong_TraLuongNewwwwwwwwww.mID_TraLuong_Sua;
            DataTable dt = clsxx.SelectOne();
            int Thang = clsxx.iThang.Value;
            int Nam = clsxx.iNam.Value;
            int ID_CongNhan = clsxx.iID_NhanVien.Value;
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            cls.iThang = Thang;
            cls.iNam = Nam;
            cls.iID_CongNhan = ID_CongNhan;           
            DataTable dt3 = cls.SelectOne_W_Thang_Nam_ID_Congnhan();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("ID_CongNhan", typeof(int));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("SLThuong", typeof(double));
            dt2.Columns.Add("SLTangCa", typeof(double));
            dt2.Columns.Add("LuongCoDinh", typeof(decimal));
            dt2.Columns.Add("LuongCongNhat", typeof(decimal));
            dt2.Columns.Add("LuongSanLuong", typeof(decimal));
            dt2.Columns.Add("LuongLonNhat", typeof(decimal));
            dt2.Columns.Add("PhuCapXangXe", typeof(decimal));
            dt2.Columns.Add("PhuCapDienthoai", typeof(decimal));
            dt2.Columns.Add("PhuCapVeSinhMay", typeof(decimal));
            dt2.Columns.Add("PhuCapTienAn", typeof(decimal));
            dt2.Columns.Add("TrachNhiem", typeof(decimal));
            dt2.Columns.Add("TruTienAn", typeof(decimal));
            dt2.Columns.Add("TamUng", typeof(decimal));
            dt2.Columns.Add("BaoHiem", typeof(decimal));
            dt2.Columns.Add("SoTienDaTraLuong", typeof(decimal));
            dt2.Columns.Add("ThucNhan", typeof(decimal));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("DaTraLuong", typeof(bool));
            dt2.Columns.Add("Chon", typeof(bool));

            //LuongLonNhat
            DataRow _ravi = dt2.NewRow();

            double SLThuong = Convert.ToDouble(dt3.Rows[0]["SLThuong"].ToString());
            double SLTangCa = Convert.ToDouble(dt3.Rows[0]["SLTangCa"].ToString());
            decimal LuongCoDinh = Convert.ToDecimal(dt3.Rows[0]["LuongCoDinh"].ToString());
            decimal LuongCongNhat = Convert.ToDecimal(dt3.Rows[0]["LuongCongNhat"].ToString());
            decimal LuongSanLuong = Convert.ToDecimal(dt3.Rows[0]["LuongSanLuong"].ToString());
            decimal LuongLonNhat = Convert.ToDecimal(dt3.Rows[0]["LuongLonNhat"].ToString());
            decimal PhuCapXangXe = Convert.ToDecimal(dt3.Rows[0]["PhuCapXangXe"].ToString());
            decimal PhuCapDienthoai = Convert.ToDecimal(dt3.Rows[0]["PhuCapDienthoai"].ToString());
            decimal PhuCapVeSinhMay = Convert.ToDecimal(dt3.Rows[0]["PhuCapVeSinhMay"].ToString());
            decimal PhuCapTienAn = Convert.ToDecimal(dt3.Rows[0]["PhuCapTienAn"].ToString());
            decimal TrachNhiem = Convert.ToDecimal(dt3.Rows[0]["TrachNhiem"].ToString());
            decimal TruTienAn = Convert.ToDecimal(dt3.Rows[0]["TruTienAn"].ToString());
            decimal TamUng = Convert.ToDecimal(dt3.Rows[0]["TamUng"].ToString());
            decimal BaoHiem = Convert.ToDecimal(dt3.Rows[0]["BaoHiem"].ToString());
            decimal SoTienDaTraLuong = Convert.ToDecimal(dt3.Rows[0]["SoTienDaTraLuong"].ToString());
            decimal ThucNhan;
            string TenNhanVien = dt3.Rows[0]["TenNhanVien"].ToString();
            bool DaTraLuong = Convert.ToBoolean(dt3.Rows[0]["DaTraLuong"].ToString());
            bool Chon = true;
            ThucNhan = LuongLonNhat + PhuCapXangXe + PhuCapDienthoai + PhuCapVeSinhMay + PhuCapTienAn + TrachNhiem - TruTienAn - TamUng - BaoHiem - SoTienDaTraLuong;
            cls.iID_CongNhan = ID_CongNhan;
            cls.dcThucNhan = ThucNhan;
            //cls.Update_ThucNhan_W_ID_CongNhan_W_thang_Nam();
            _ravi["ID_CongNhan"] = ID_CongNhan;
            _ravi["Thang"] = Thang;
            _ravi["Nam"] = Nam;
            _ravi["SLThuong"] = SLThuong;
            _ravi["SLTangCa"] = SLTangCa;
            _ravi["LuongCoDinh"] = LuongCoDinh;
            _ravi["LuongCongNhat"] = LuongCongNhat;
            _ravi["LuongSanLuong"] = LuongSanLuong;
            _ravi["LuongLonNhat"] = LuongLonNhat;
            _ravi["PhuCapXangXe"] = PhuCapXangXe;
            _ravi["PhuCapDienthoai"] = PhuCapDienthoai;
            _ravi["PhuCapVeSinhMay"] = PhuCapVeSinhMay;
            _ravi["PhuCapTienAn"] = PhuCapTienAn;
            _ravi["TrachNhiem"] = TrachNhiem;
            _ravi["TruTienAn"] = TruTienAn;
            _ravi["TamUng"] = TamUng;
            _ravi["BaoHiem"] = BaoHiem;
            _ravi["SoTienDaTraLuong"] = SoTienDaTraLuong;
            _ravi["TamUng"] = TamUng;
            _ravi["LuongCongNhat"] = LuongCongNhat;
            _ravi["LuongSanLuong"] = LuongSanLuong;
            _ravi["BaoHiem"] = BaoHiem;
            _ravi["ThucNhan"] = ThucNhan;
            _ravi["TenNhanVien"] = TenNhanVien;
            _ravi["DaTraLuong"] = DaTraLuong;
            _ravi["Chon"] = Chon;
            dt2.Rows.Add(_ravi);
            DataView dv = dt2.DefaultView;
            dv.Sort = "Nam DESC, Thang DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;

        }
        private void Load_LockUp()
        {
            clsNganHang_TaiKhoanKeToanCon clsme = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dtme = clsme.SelectAll();
            dtme.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=false";
            DataView dvme = dtme.DefaultView;
            DataTable newdtme = dvme.ToTable();

            //gridTKCo.Properties.DataSource = newdtme;
            //gridTKCo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            //gridTKCo.Properties.DisplayMember = "SoTaiKhoanCon";

            //gridTKNo.Properties.DataSource = newdtme;
            //gridTKNo.Properties.ValueMember = "ID_TaiKhoanKeToanCon";
            //gridTKNo.Properties.DisplayMember = "SoTaiKhoanCon";

            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False and ID_BoPhan=4";
            DataView dvCaTruong = dtNguoi.DefaultView;
            DataTable newdtCaTruong = dvCaTruong.ToTable();

            gridNguoiLap.Properties.DataSource = newdtCaTruong;
            gridNguoiLap.Properties.ValueMember = "ID_NhanSu";
            gridNguoiLap.Properties.DisplayMember = "MaNhanVien";

            gridNguoiLap.EditValue = 11;
        }

        public frmLuong_ChiTietTraLuong()
        {
            InitializeComponent();
        }

        private void frmLuong_ChiTietTraLuong_Load(object sender, EventArgs e)
        {
            
            dteNgayChungTu.DateTime = DateTime.Today;         
            Load_LockUp();
            if (UCLuong_TraLuongNewwwwwwwwww.mbThemMoiTraLuong==true)
                HienThi_ThemMoi();
            else
                HienThi_Sua();
        }

        private void gridNguoiLap_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsNhanSu_tbNhanSu clsncc = new clsNhanSu_tbNhanSu();
                clsncc.iID_NhanSu = Convert.ToInt16(gridNguoiLap.EditValue.ToString());
                DataTable dt = clsncc.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtNguoiMuaHang.Text = dt.Rows[0]["TenNhanVien"].ToString();

                }

            }
            catch
            {

            }
        }

        private void txtTongTienLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal value = decimal.Parse(txtTongTienLuong.Text);
                //txtTongTienLuong.Text = String.Format("{0:#,##0.00}", value);

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtTongTienLuong.Text, System.Globalization.NumberStyles.AllowThousands);
                txtTongTienLuong.Text = String.Format(culture, "{0:N0}", value);
                txtTongTienLuong.Select(txtTongTienLuong.Text.Length, 0);

            }
            catch
            {

            }
        }

        private void txtSoTienThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtSoTienThanhToan.Text, System.Globalization.NumberStyles.AllowThousands);
                txtSoTienThanhToan.Text = String.Format(culture, "{0:N0}", value);
                txtSoTienThanhToan.Select(txtSoTienThanhToan.Text.Length, 0);
            }
            catch
            {

            }
        }

        //private void txtTienNo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal value = decimal.Parse(txtTienNo.Text);
        //        txtTienNo.Text = String.Format("{0:#,##0.00}", value);
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void txtTienCo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal value = decimal.Parse(txtTienCo.Text);
        //        txtTienCo.Text = String.Format("{0:#,##0.00}", value);
        //    }
        //    catch
        //    {

        //    }
        //}

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Dong_Click(object sender, EventArgs e)
        {
            LUU_DuLieu_ChiLuu();
            MessageBox.Show("Đã lưu");
            this.Close();
        }

        private void check_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ALL.Checked == true)
            {
                DataTable dt3 = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    dt3.Rows[i]["Chon"] = true;
                }
                gridControl1.DataSource = dt3;
            }
            if (check_ALL.Checked == false)
            {
                DataTable dt3 = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    dt3.Rows[i]["Chon"] = false;
                }
                gridControl1.DataSource = dt3;
            }
            double deTOngtien;
            DataTable dataTable = (DataTable)gridControl1.DataSource;
            object xxxx = dataTable.Compute("sum(ThucNhan)", "Chon=True");
            if (xxxx.ToString() != "")
                deTOngtien = Convert.ToDouble(xxxx);
            else deTOngtien = 0;
            txtTongTienLuong.Text = deTOngtien.ToString();
            txtSoTienThanhToan.Text = deTOngtien.ToString();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                double deTOngtien;
                DataTable dataTable = (DataTable)gridControl1.DataSource;
                object xxxx = dataTable.Compute("sum(ThucNhan)", "Chon=True");
                if (xxxx.ToString() != "")
                    deTOngtien = Convert.ToDouble(xxxx);
                else deTOngtien = 0;
                txtTongTienLuong.Text = deTOngtien.ToString();
                txtSoTienThanhToan.Text = deTOngtien.ToString();
            }
            catch
            {
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clChon)
            {
                try
                {
                    double deTOngtien;
                    DataTable dataTable = (DataTable)gridControl1.DataSource;
                    object xxxx = dataTable.Compute("sum(ThucNhan)", "Chon=True");
                    if (xxxx.ToString() != "")
                        deTOngtien = Convert.ToDouble(xxxx);
                    else deTOngtien = 0;
                    txtTongTienLuong.Text = deTOngtien.ToString();
                    txtSoTienThanhToan.Text = deTOngtien.ToString();
                }
                catch
                {
                }
            }
        }

        private void btLuu_Gui_Dong_Click(object sender, EventArgs e)
        {
            LUU_Va_Gui_DuLieu();
            MessageBox.Show("Đã lưu và gửi dữ liệu cho kế toán ngân hàng");
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (!KiemTraLuu()) return;
            else
            {
                DataTable DatatableABC = (DataTable)gridControl1.DataSource;
                CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
                string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                DataView dv1212 = new DataView(DatatableABC);
                dv1212.RowFilter = filterString;
                DataTable dttttt2 = dv1212.ToTable();
            
                dttttt2.DefaultView.RowFilter = "Chon=True";
                DataView dv = dttttt2.DefaultView;
                mdttableDuLieuTraLuong = dv.ToTable();              
                mdangaythang = dteNgayChungTu.DateTime;
                msNguoiLap = txtNguoiMuaHang.Text.ToString();               

                frmPrint_TraLuong ff = new frmPrint_TraLuong();
                ff.Show();
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtSoTienThanhToan.Text = txtTongTienLuong.Text;
        }
    }
}
