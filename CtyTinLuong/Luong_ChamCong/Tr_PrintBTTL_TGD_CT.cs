using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_PrintBTTL_TGD_CT : DevExpress.XtraReports.UI.XtraReport
    {
        private int _thang;
        private int _nam;
        public Tr_PrintBTTL_TGD_CT(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

    }
}
