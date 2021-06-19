using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CtyTinLuong
{
    public partial class XtraDaiLy_Luong_RutGon : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraDaiLy_Luong_RutGon()
        {
            InitializeComponent();
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
