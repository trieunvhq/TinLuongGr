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
    public partial class BanHang_SoTongHopbanHang : Form
    {
        public static DateTime mdatungay, mdadenngay;
        public static DataTable mdtPrint;
        public static bool mbPrint;
       
        public void LoadData( DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
         
         
            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dt = cls.SelectAll_distinct_ID_VTHH_HUU(xxtungay, xxdenngay);


            gridControl1.DataSource = dt;
           
        }
     
        public BanHang_SoTongHopbanHang()
        {
            InitializeComponent();
        }
        

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_SoTongHopbanHang_Load( sender,  e);
        }

        private void BanHang_SoTongHopbanHang_Load(object sender, EventArgs e)
        {
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteDenNgay.EditValue = DateTime.Now;
            LoadData( dteTuNgay.DateTime, dteDenNgay.DateTime);

        }
    }
}
