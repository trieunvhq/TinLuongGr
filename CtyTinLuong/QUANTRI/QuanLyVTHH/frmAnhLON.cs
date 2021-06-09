using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmAnhLON : Form
    {
        public frmAnhLON()
        {
            InitializeComponent();
        }

        private void frmAnhLON_Load(object sender, EventArgs e)
        {
            //Byte[] byteBLOBData = new Byte[0];
            //byteBLOBData = frmChiTietVTHH.stmBLOBData22222;
            //MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
            pictureEdit1.Image = Image.FromStream(frmChiTietVTHH.stmBLOBData22222);
        }
    }
}
