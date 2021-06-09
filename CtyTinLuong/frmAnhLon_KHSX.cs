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
    public partial class frmAnhLon_KHSX : Form
    {
        public frmAnhLon_KHSX()
        {
            InitializeComponent();
        }

        private void frmAnhLon_KHSX_Load(object sender, EventArgs e)
        {
            pictureEdit1.Image = Image.FromStream(frmChiTietKeHoachSanXuat.stmBLOBData);
        }
    }
}
