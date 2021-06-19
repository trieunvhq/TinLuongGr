using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class DaiLy_BangLuong : Form
    {
        DateTime ngaybatdau, ngayketthuc;        
        public DaiLy_BangLuong()
        {
            InitializeComponent();
        }
        private void HienThi_GridConTrol_2(int xxID_DaiLy, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl2.DataSource = null;
            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt_luong = cls1.SA_ID_DaiLy_TinhLuong(xxID_DaiLy, xxtungay, xxdenngay);
            gridControl2.DataSource = dt_luong;
        }
        private void LoadDaTa(int thang, int nam, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;

            DataTable dt2 = new DataTable();
         
            dt2.Columns.Add("ID_DaiLy", typeof(string));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("TongTien", typeof(double));
            dt2.Columns.Add("SoTien_TamUng", typeof(double));          
            dt2.Columns.Add("ThucNhan", typeof(double));           
       

            clsDaiLy_tbXuatKho cls1 = new CtyTinLuong.clsDaiLy_tbXuatKho();
            DataTable dt3 = cls1.SD_w_TU(thang, nam, xxtungay, xxdenngay);
            if(dt3.Rows.Count>0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    double tongtienxx = Convert.ToDouble(dt3.Rows[i]["TongTien"].ToString());
                    double SoTien_TamUngxxx = Convert.ToDouble(dt3.Rows[i]["SoTien_TamUng"].ToString());
                    DataRow _ravi = dt2.NewRow();

                    _ravi["ID_DaiLy"] = dt3.Rows[i]["ID_DaiLy"].ToString();
                    _ravi["TongTien"] = tongtienxx;
                    _ravi["SoTien_TamUng"] = SoTien_TamUngxxx;
                    _ravi["ThucNhan"] = tongtienxx- SoTien_TamUngxxx;                 
                    _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                    _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();

                    dt2.Rows.Add(_ravi);
                }
            }
            gridControl1.DataSource = dt2;
        }
        private void DaiLy_BangLuong_Load(object sender, EventArgs e)
        {
            
            txtNam.Text = DateTime.Now.Year.ToString();  
            txtThang.Text = (DateTime.Now.Month).ToString();
            
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            int xxthang = Convert.ToInt32(txtThang.Text.ToString());         

            if (txtNam.Text!="")
            {
                int xxnam = Convert.ToInt32(txtNam.Text.ToString());
                clsNgayThang cls = new CtyTinLuong.clsNgayThang();
                ngaybatdau = cls.GetFistDayInMonth(xxnam, xxthang);
                ngayketthuc = cls.GetLastDayInMonth(xxnam, xxthang);
                LoadDaTa(xxthang, xxnam,ngaybatdau, ngayketthuc);
            }

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString()!="")
            {
                int xxID_ = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_DaiLy).ToString());               
                HienThi_GridConTrol_2(xxID_, ngaybatdau, ngayketthuc);
            }
        }
    }
}
