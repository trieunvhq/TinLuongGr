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
    public partial class frmGuiDuLieuLuongTheoSanLuong : Form
    {
        private bool GuiDuLieu_LuongSanLuong_I_C_D()
        {
            DateTime ngaydautien, ngaycuoicung;          
            int thang = Convert.ToInt16(txtThang.Text.ToString());
            int nam = Convert.ToInt16(txtNam.Text.ToString());
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            cls.iThang = thang;
            cls.iNam = nam;
            DataTable dt3 = cls.Select_ALL_Thang_W_Nam();
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    int ID_CongNhan = Convert.ToInt32(dt3.Rows[i]["ID_CongNhan"].ToString());
                    clsPhieu_ChiTietPhieu_New clsphieu = new clsPhieu_ChiTietPhieu_New();
                    clsphieu.iID_CongNhan = ID_CongNhan;
                    DataTable dtChiTietPhieu_1111 = clsphieu.SelectAll_W_ID_CongNhan();
                    dtChiTietPhieu_1111.DefaultView.RowFilter = " NgaySanXuat <='" + ngaycuoicung + "'";
                    DataView dv_111111111 = dtChiTietPhieu_1111.DefaultView;
                    DataTable dtChiTietPhieu_222222222 = dv_111111111.ToTable();

                    dtChiTietPhieu_222222222.DefaultView.RowFilter = " NgaySanXuat >='" + ngaydautien + "'";
                    DataView dv_22222222 = dtChiTietPhieu_222222222.DefaultView;
                    DataTable dtChiTietPhieu = dv_22222222.ToTable();
                    //gridControl2.DataSource = dtChiTietPhieu;
                    if (dtChiTietPhieu.Rows.Count > 0)
                    {
                        DataTable dtmay = new DataTable();
                        dtmay.Columns.Add("ThanhTien", typeof(decimal));
                        dtmay.Columns.Add("HienThi", typeof(string));

                        for (int imayin = 0; imayin < dtChiTietPhieu.Rows.Count; imayin++)
                        {
                            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                            Decimal SanLuongThuong, SanLuongTangCa;
                            SanLuongThuong = Convert.ToDecimal(dtChiTietPhieu.Rows[imayin]["SanLuong_Thuong"].ToString());
                            SanLuongTangCa = Convert.ToDecimal(dtChiTietPhieu.Rows[imayin]["SanLuong_TangCa"].ToString());
                            decimal DinhMuc_KhongTang, DinhMuc_Tang, ThanhTien;
                            int ID_DinhMuc_Luong = Convert.ToInt32(dtChiTietPhieu.Rows[imayin]["ID_DinhMuc_Luong"].ToString());
                            clsdm.iID_DinhMuc_Luong_SanLuong = ID_DinhMuc_Luong;
                            DataTable dtdm = clsdm.SelectOne();
                            DinhMuc_KhongTang = clsdm.dcDinhMuc_KhongTang.Value;
                            DinhMuc_Tang = clsdm.dcDinhMuc_Tang.Value;
                            ThanhTien = SanLuongThuong * DinhMuc_KhongTang + SanLuongTangCa * DinhMuc_Tang;

                            DataRow _ravi = dtmay.NewRow();
                            _ravi["ThanhTien"] = ThanhTien;
                            _ravi["HienThi"] = "1";
                            dtmay.Rows.Add(_ravi);
                        }
                        //gridControl4.DataSource = dtmay;
                        string shienthi = "1";
                        decimal deluongsanluong;
                        object tongthanhtienxxx = dtmay.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                        deluongsanluong = Convert.ToDecimal(tongthanhtienxxx);

                        cls.iID_CongNhan = ID_CongNhan;
                        cls.iThang = thang;
                        cls.iNam = nam;

                        DataTable dtChiTietChamCong = cls.SelectOne_W_Thang_Nam_ID_Congnhan();

                        decimal luongcongnhat = Convert.ToDecimal(dtChiTietChamCong.Rows[0]["LuongCongNhat"].ToString());
                        int ID_DinhMucLuong_CongNhat = Convert.ToInt32(dtChiTietChamCong.Rows[0]["ID_DinhMucLuong_CongNhat"].ToString());
                        clsHUU_DinhMucLuong_CongNhat clsdmcongnhat = new clsHUU_DinhMucLuong_CongNhat();
                        clsdmcongnhat.iID_DinhMucLuong_CongNhat = ID_DinhMucLuong_CongNhat;
                        DataTable dtdmcongnhat = clsdmcongnhat.SelectOne();

                        if (clsdmcongnhat.iHinhThucTinhLuong == 1) // Luong cố định
                        {
                            cls.dcLuongSanLuong = 0;
                            cls.dcLuongLonNhat = Convert.ToDecimal(dtChiTietChamCong.Rows[0]["LuongCoDinh"].ToString());
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 2) // Luong công nhật
                        {
                            cls.dcLuongSanLuong = 0;
                            cls.dcLuongLonNhat = luongcongnhat;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 3) // Lương sản lượng
                        {
                            cls.dcLuongSanLuong = deluongsanluong;
                            cls.dcLuongLonNhat = deluongsanluong;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 4) // chon lớn nhất
                        {
                            cls.dcLuongSanLuong = deluongsanluong;
                            if (luongcongnhat >= deluongsanluong)
                                cls.dcLuongLonNhat = luongcongnhat;
                            else cls.dcLuongLonNhat = deluongsanluong;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }

                    }
                    else
                    {
                        cls.iID_CongNhan = ID_CongNhan;
                        cls.dcLuongSanLuong = 0;
                        cls.iThang = thang;
                        cls.iNam = nam;
                        decimal luongcongnhat = Convert.ToDecimal(dt3.Rows[i]["LuongCongNhat"].ToString());
                        cls.dcLuongLonNhat = luongcongnhat;
                        cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                    }

                }
                return true;
            }
            else return false;
        }
        private bool GuiDuLieu_LuongSanLuong_ToGapDan()
        {
            DateTime ngaydautien, ngaycuoicung;
            int thang = Convert.ToInt16(txtThang.Text.ToString());
            int nam = Convert.ToInt16(txtNam.Text.ToString());
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);
            clsHUU_CongNhat_ChiTiet_ChamCong cls = new clsHUU_CongNhat_ChiTiet_ChamCong();
            cls.iThang = thang;
            cls.iNam = nam;
            DataTable dt3 = cls.Select_ALL_Thang_W_Nam();
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    int ID_CongNhan = Convert.ToInt32(dt3.Rows[i]["ID_CongNhan"].ToString());
                    clsHuu_CongNhat_ChiTiet_ChamCong_ToGapDan clslsx = new clsHuu_CongNhat_ChiTiet_ChamCong_ToGapDan();
                    clslsx.iID_CongNhan = ID_CongNhan;                   
                    clslsx.iThang = thang;
                    clslsx.iNam = nam;
                    DataTable dtgapdan = clslsx.SelectAll_W_Thang_W_Nam_W_ID_CongNhan();
                  
                    if (dtgapdan.Rows.Count > 0)
                    {
                        DataTable dtgapdan_Tong = new DataTable();
                        dtgapdan_Tong.Columns.Add("ThanhTien", typeof(decimal));
                        dtgapdan_Tong.Columns.Add("HienThi", typeof(string));

                        for (int j = 0; j < dtgapdan.Rows.Count; j++)
                        {
                            DataRow _ravi = dtgapdan_Tong.NewRow();
                            

                            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsdm = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                            clsdm.iID_DinhMuc_Luong_SanLuong= Convert.ToInt32(dtgapdan.Rows[j]["ID_DinhMuc_Luong_SanLuong"].ToString());
                            DataTable dtdm1 = clsdm.SelectOne();
                            Decimal SanLuong;
                            decimal DinhMuc_KhongTang, ThanhTien;
                            SanLuong = Convert.ToDecimal(dtgapdan.Rows[j]["SanLuong"].ToString());
                            DinhMuc_KhongTang = clsdm.dcDinhMuc_KhongTang.Value;                          
                            ThanhTien = SanLuong * DinhMuc_KhongTang;

                            _ravi["ThanhTien"] = ThanhTien;
                            _ravi["HienThi"] = "1";
                            dtgapdan_Tong.Rows.Add(_ravi);
                        }
                           

                        string shienthi = "1";
                        decimal deluongsanluong;
                        object tongthanhtienxxx = dtgapdan_Tong.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                        deluongsanluong = Convert.ToDecimal(tongthanhtienxxx);

                        cls.iID_CongNhan = ID_CongNhan;
                        cls.iThang = thang;
                        cls.iNam = nam;

                        DataTable dtChiTietChamCong = cls.SelectOne_W_Thang_Nam_ID_Congnhan();

                        decimal luongcongnhat = Convert.ToDecimal(dtChiTietChamCong.Rows[0]["LuongCongNhat"].ToString());
                        int ID_DinhMucLuong_CongNhat = Convert.ToInt32(dtChiTietChamCong.Rows[0]["ID_DinhMucLuong_CongNhat"].ToString());
                        clsHUU_DinhMucLuong_CongNhat clsdmcongnhat = new clsHUU_DinhMucLuong_CongNhat();
                        clsdmcongnhat.iID_DinhMucLuong_CongNhat = ID_DinhMucLuong_CongNhat;
                        DataTable dtdmcongnhat = clsdmcongnhat.SelectOne();

                        if (clsdmcongnhat.iHinhThucTinhLuong == 1) // Luong cố định
                        {
                            cls.dcLuongSanLuong = 0;
                            cls.dcLuongLonNhat = Convert.ToDecimal(dtChiTietChamCong.Rows[0]["LuongCoDinh"].ToString());
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 2) // Luong công nhật
                        {
                            cls.dcLuongSanLuong = 0;
                            cls.dcLuongLonNhat = luongcongnhat;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 3) // Lương sản lượng
                        {
                            cls.dcLuongSanLuong = deluongsanluong;
                            cls.dcLuongLonNhat = deluongsanluong;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }
                        else if (clsdmcongnhat.iHinhThucTinhLuong == 4) // chon lớn nhất
                        {
                            cls.dcLuongSanLuong = deluongsanluong;
                            if (luongcongnhat >= deluongsanluong)
                                cls.dcLuongLonNhat = luongcongnhat;
                            else cls.dcLuongLonNhat = deluongsanluong;
                            cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                        }

                    }
                    else
                    {
                        cls.iID_CongNhan = ID_CongNhan;
                        cls.dcLuongSanLuong = 0;
                        cls.iThang = thang;
                        cls.iNam = nam;
                        decimal luongcongnhat = Convert.ToDecimal(dt3.Rows[i]["LuongCongNhat"].ToString());
                        cls.dcLuongLonNhat = luongcongnhat;
                        cls.Update_LuongSanLuong_LuongLonNhat_W_ID_CongNhan_W_thang_Nam();
                    }

                }
                return true;
            }
            else return false;
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
        public frmGuiDuLieuLuongTheoSanLuong()
        {
            InitializeComponent();
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt16(txtThang.Text.ToString());
            int nam = Convert.ToInt16(txtNam.Text.ToString());
           
            if (!GuiDuLieu_LuongSanLuong_I_C_D()) 
            {
                MessageBox.Show("Không có dữ liệu lương tháng: " + thang.ToString() + " năm " + nam.ToString() + "");
                return;
            }
            else if (!GuiDuLieu_LuongSanLuong_ToGapDan())
            {
                MessageBox.Show("Không có dữ liệu lương tháng: " + thang.ToString() + " năm " + nam.ToString() + "");
                return;
            }
            else
            {
              
                MessageBox.Show("Đã gửi dữ liệu lương tháng: " + thang.ToString() + " năm " + nam.ToString() + "");
                
            }
            
        }

        private void frmGuiDuLieuLuongTheoSanLuong_Load(object sender, EventArgs e)
        {
          
            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM"))-1;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            txtThang.Text = thang.ToString();
            txtNam.Text = nam.ToString();
            
        }

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
