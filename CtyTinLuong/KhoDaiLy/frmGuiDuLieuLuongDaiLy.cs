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
    public partial class frmGuiDuLieuLuongDaiLy : Form
    {
        private void GuDuLieuxxxx()
        {
            DateTime ngaydautien, ngaycuoicung;
            // DateTime ngayhomnay = 
            int thang = Convert.ToInt16(txtThang.Text.ToString());
            int nam = Convert.ToInt16(txtNam.Text.ToString());
            ngaydautien = GetFistDayInMonth(nam, thang);
            ngaycuoicung = GetLastDayInMonth(nam, thang);

            clsDaiLy_BangLuong cls = new clsDaiLy_BangLuong();
            cls.iThang = thang;
            cls.iNam = nam;
            DataTable dt3 = cls.Select_ALL__W_Thang_Nam();
           
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    int ID_DaiLyxxx = Convert.ToInt32(dt3.Rows[i]["ID_DaiLy"].ToString());
                    clsDaiLy_tbXuatKho clsxuatkhodaily = new clsDaiLy_tbXuatKho();
                    clsxuatkhodaily.iID_DaiLy = ID_DaiLyxxx;
                    DataTable dtxuatkho = clsxuatkhodaily.SelectAll_W_ID_DaiLy_TinhLuong();
                    dtxuatkho.DefaultView.RowFilter = " NgayChungTu <='" + ngaycuoicung + "' and DaXuatKho=True";
                    DataView dv_111111111 = dtxuatkho.DefaultView;
                    DataTable dtxuatkho_222222222 = dv_111111111.ToTable();

                    dtxuatkho_222222222.DefaultView.RowFilter = " NgayChungTu >='" + ngaydautien + "'";
                    DataView dv_22222222 = dtxuatkho_222222222.DefaultView;
                    DataTable dtxuatkho2222 = dv_22222222.ToTable();                    
                    if (dtxuatkho2222.Rows.Count > 0)
                    {
                        DataTable dtluongdaily = new DataTable();
                        dtluongdaily.Columns.Add("ThanhTien", typeof(decimal));
                        dtluongdaily.Columns.Add("HienThi", typeof(string));

                        for (int imayin = 0; imayin < dtxuatkho2222.Rows.Count; imayin++)
                        {
                            decimal SoLuongXuat, DonGia, ThanhTien;
                            SoLuongXuat = Convert.ToDecimal(dtxuatkho2222.Rows[imayin]["SoLuongXuat"].ToString());
                            DonGia = Convert.ToDecimal(dtxuatkho2222.Rows[imayin]["DonGia"].ToString());
                            ThanhTien = DonGia * SoLuongXuat ;

                            DataRow _ravi = dtluongdaily.NewRow();
                            _ravi["ThanhTien"] = ThanhTien;
                            _ravi["HienThi"] = "1";
                            dtluongdaily.Rows.Add(_ravi);
                        }                     
                        string shienthi = "1";
                        decimal deluongdaily;
                        object tongthanhtienxxx = dtluongdaily.Compute("sum(ThanhTien)", "HienThi=" + shienthi + "");
                        deluongdaily = Convert.ToDecimal(tongthanhtienxxx);

                        cls.iID_DaiLy = ID_DaiLyxxx;
                        cls.iThang = thang;
                        cls.iNam = nam;

                        DataTable dtchitietBangLuong = cls.SelectOne__W_Thang_Nam_ID_DaiLy();
                        cls.iID_BangLuong = Convert.ToInt32(dtchitietBangLuong.Rows[0]["ID_BangLuong"].ToString());
                        cls.dcLuongDaiLy = deluongdaily;
                        cls.Update_LuongDaiLy();
                       
                    }
                   

                }
                MessageBox.Show("Đã gửi dữ liệu lương Đại lý tháng: " + thang.ToString() + " năm " + nam.ToString() + "");
                
            }
            else MessageBox.Show("Không có dữ liệu lương tháng: " + thang.ToString() + " năm " + nam.ToString() + "");
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
        public frmGuiDuLieuLuongDaiLy()
        {
            InitializeComponent();
        }

        private void frmGuiDuLieuLuongDaiLy_Load(object sender, EventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            int thang = Convert.ToInt16(ngayhomnay.ToString("MM")) - 1;
            int nam = Convert.ToInt16(ngayhomnay.ToString("yyyy"));
            txtThang.Text = thang.ToString();
            txtNam.Text = nam.ToString();
        }

        private void btThoat2222_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            GuDuLieuxxxx();
        }
    }
}
