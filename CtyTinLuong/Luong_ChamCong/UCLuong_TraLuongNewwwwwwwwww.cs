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
    public partial class UCLuong_TraLuongNewwwwwwwwww : UserControl
    {
        public static bool mbThemMoiTraLuong;
        public static int mID_TraLuong_Sua;
       
        public UCLuong_TraLuongNewwwwwwwwww()
        {
            InitializeComponent();
        }

        private void UCLuong_TraLuongNewwwwwwwwww_Load(object sender, EventArgs e)
        {
           
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCLuong_TraLuongNewwwwwwwwww_Load(sender, e);
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            //mbThemMoiTraLuong = true;
            //frmLuong_ChiTietTraLuong ff = new frmLuong_ChiTietTraLuong();
            //ff.Show();
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue(ID_TraLuong).ToString() != "")
            //{
            //    mbThemMoiTraLuong = false;
            //    mID_TraLuong_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_TraLuong).ToString());
            //    frmLuong_ChiTietTraLuong ff = new CtyTinLuong.frmLuong_ChiTietTraLuong();
            //    ff.Show();
            //}           
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
