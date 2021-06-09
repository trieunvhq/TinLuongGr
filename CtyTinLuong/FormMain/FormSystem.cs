using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.FormMain
{
    public partial class FormSystem : Form
    {
        public FormSystem()
        {
            InitializeComponent();
            LoadTheme();
        }


        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            
            
        }

        private void btnPhucHoiCSDL_Click(object sender, EventArgs e)
        {

        }

        private void btnThietLapBanDau_Click(object sender, EventArgs e)
        {
            //frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii ggg = new frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii();
           // ggg.Show();
        }
    }
}
