using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong
{
    public partial class Xtra_LenhSanXuat_I_C_D : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_LenhSanXuat_I_C_D()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        
            pCaSanXuat.Value = SanXuat_frmChiTietLenhSanXuat.msCaSanXuat;
            pCaTruong.Value = SanXuat_frmChiTietLenhSanXuat.msCaTruong;
            pCongNhan.Value = SanXuat_frmChiTietLenhSanXuat.msCongNhan;
            pNgaySanXuat.Value = SanXuat_frmChiTietLenhSanXuat.mdaNgayThang.ToString("dd/MM/yyyy");
            pNguoiLap.Value = SanXuat_frmChiTietLenhSanXuat.msNguoiLap;            
        }

    }
}
