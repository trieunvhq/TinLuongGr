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
    public partial class DaiLy_BangLuong : Form
    {
        DateTime ngaybatdau, ngayketthuc;
        public DaiLy_BangLuong()
        {
            InitializeComponent();
        }
        private void HienThi_GridConTrol_2(int xxID_DaiLy, DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt_luong = cls1.SA_ID_DaiLy_TinhLuong(xxID_DaiLy, xxtungay, xxdenngay);
        }
        private void LoadDaTa(int thang, int nam, DateTime xxtungay, DateTime xxdenngay)
        {
            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt = cls1.SD_w_TU(thang, nam, xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
        private void DaiLy_BangLuong_Load(object sender, EventArgs e)
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();
            txtThang.Text = DateTime.Now.Month.ToString();
            
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            int xxthang = Convert.ToInt32(txtThang.Text.ToString());         

            if (txtNam.Text!="")
            {
                int xxnam = Convert.ToInt32(txtNam.Text.ToString());
                LoadDaTa(xxthang, xxnam);
            }

        }
    }
}
