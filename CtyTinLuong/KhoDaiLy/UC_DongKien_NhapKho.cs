using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UC_DongKien_NhapKho : UserControl
    {
        public UC_DongKien_NhapKho()
        {
            InitializeComponent();
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {

        }
        private void UC_DongKien_NhapKho_Load(object sender, EventArgs e)
        {
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
    }
}
