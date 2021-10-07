using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //Application.Run(new Tr_frmQuanLyDML_CongNhat());


            //Application.Run(new frmDangNhap());

            //Application.Run(new PhieuSanXuat_IN_CAT_New_thang8());
            //Application.Run(new frmtestcopy());
        }
    }
}
