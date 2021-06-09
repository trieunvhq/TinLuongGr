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
  
    public partial class UCMuaHang_ChiTietTatCa : UserControl
    {
        public static int miID_VTHH;
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
        private void HienThi()
        {

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("SoLuong", typeof(double));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("DonGia", typeof(double));
            dt2.Columns.Add("ThanhTien", typeof(double));
            dt2.Columns.Add("NgayChungTu", typeof(DateTime));
            dt2.Columns.Add("TenNhaCungCap", typeof(string));
           

            clsMH_tbChiTietMuaHang cls = new CtyTinLuong.clsMH_tbChiTietMuaHang();
            DataTable dtdistin = cls.SelectAll_DISTINCT_W_ID_VTHH();
            if(dtdistin.Rows.Count>0)
            {
                for(int i=0; i<dtdistin.Rows.Count; i++)
                {
                    int iiiID_VTHH= Convert.ToInt32(dtdistin.Rows[i]["ID_VTHH"].ToString());
                    cls.iID_VTHH= Convert.ToInt32(dtdistin.Rows[i]["ID_VTHH"].ToString());
                    DataTable dttong = cls.Select_Sum_SoLuong_ThanhTien_W_ID_VTHH();
                    if(dttong.Rows.Count>0)
                    {
                        DataRow _ravi = dt2.NewRow();
                        _ravi["ID_VTHH"] = iiiID_VTHH;
                        clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                        clsvt.iID_VTHH = iiiID_VTHH;
                        DataTable dtvt = clsvt.SelectOne();
                        _ravi["MaVT"] = clsvt.sMaVT.Value;
                        _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                        _ravi["SoLuong"] = Convert.ToDouble(dttong.Rows[0]["SoLuong"].ToString());
                        _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                        _ravi["ThanhTien"] = Convert.ToDouble(dttong.Rows[0]["ThanhTien"].ToString());
                        dt2.Rows.Add(_ravi);
                    }
                }
            }
        
            gridControl1.DataSource = dt2;


        }


        public UCMuaHang_ChiTietTatCa()
        {
            InitializeComponent();
        }

        private void UCMuaHang_ChiTietTatCa_Load(object sender, EventArgs e)
        {
          
            HienThi();
        }

    

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                miID_VTHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                MuaHang_frmChiTietMotVatTu ff = new MuaHang_frmChiTietMotVatTu();
                ff.Show();
            }
        }
    }
}
