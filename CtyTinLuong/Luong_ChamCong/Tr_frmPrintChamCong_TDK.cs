using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong.Luong_ChamCong
{
    public partial class Tr_frmPrintChamCong_TDK : Form
    {
        private int _thang, _nam;

        public Tr_frmPrintChamCong_TDK(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmPrintChamCong_TDK_Load(object sender, EventArgs e)
        {
            Tr_PrintChamCong_TDK xtr111 = new Tr_PrintChamCong_TDK(_thang, _nam);
            DataSet_TinLuong ds = new DataSet_TinLuong();

            DateTime date_ = new DateTime(_nam, _thang, 1);
            int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;


            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNhatChamCongToGapDan;
            xtr111.DataMember = "tbCongNhatChamCongToGapDan";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;

        }
    }
}
