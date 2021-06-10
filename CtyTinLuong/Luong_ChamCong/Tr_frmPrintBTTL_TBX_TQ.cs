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
    public partial class Tr_frmPrintBTTL_TBX_TQ : Form
    {

        private int _thang, _nam;

        public Tr_frmPrintBTTL_TBX_TQ(int thang, int nam)
        {
            _thang = thang;
            _nam = nam;
            InitializeComponent();
        }

        private void Tr_frmBTTL_TBX_TQ_Load(object sender, EventArgs e)
        {
             Tr_PrintBTTL_TBX_TQ xtr111 = new Tr_PrintBTTL_TBX_TQ(_thang, _nam);

            DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbCongNhatChamCongToGapDan.Clone();
            //ds.tbCongNhatChamCongToGapDan.Clear();
            clsThin cls1 = new clsThin();

            DataTable dt3 = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");

            xtr111.DataSource = null;
            xtr111.DataSource = dt3;


            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
