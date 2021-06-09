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
    public partial class UCDaiLy_TinhLuong : UserControl
    {
        public static bool mbThemMoiTraLuong;
        public static int mID_TraLuong_Sua;

        private void HienThi_ALL()
        {
            clsDaiLy_BangLuong cls = new clsDaiLy_BangLuong();
            DataTable dt3 = cls.SelectAll_HienLuong_DaiLy();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_BangLuong", typeof(int));
            dt2.Columns.Add("ID_DaiLy", typeof(int));
            dt2.Columns.Add("Thang", typeof(int));
            dt2.Columns.Add("Nam", typeof(int));
            dt2.Columns.Add("LuongDaiLy", typeof(decimal));
            dt2.Columns.Add("TamUng", typeof(decimal));
            dt2.Columns.Add("SoTienDaTra", typeof(decimal));
            dt2.Columns.Add("ThucNhan", typeof(decimal));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("DaTraLuong", typeof(bool));
            dt2.Columns.Add("TenDaiLy", typeof(string));            
            dt2.Columns.Add("Chon", typeof(bool));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ID_BangLuong = Convert.ToInt32(dt3.Rows[i]["LuongDaiLy"].ToString());
                int ID_DaiLy = Convert.ToInt32(dt3.Rows[i]["ID_DaiLy"].ToString());
                int Thang = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                int Nam = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());               

                Decimal LuongDaiLy = Convert.ToDecimal(dt3.Rows[i]["LuongDaiLy"].ToString());
                Decimal TamUng = Convert.ToDecimal(dt3.Rows[i]["TamUng"].ToString());
                Decimal SoTienDaTra = Convert.ToDecimal(dt3.Rows[i]["SoTienDaTra"].ToString());
                Decimal ThucNhan = LuongDaiLy - TamUng - SoTienDaTra;

                bool DaTraLuong = Convert.ToBoolean(dt3.Rows[i]["DaTraLuong"].ToString());
                string TenDaiLy = dt3.Rows[i]["TenDaiLy"].ToString();
                string MaDaiLy = dt3.Rows[i]["MaDaiLy"].ToString();
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_BangLuong"] = ID_BangLuong;
                _ravi["ID_DaiLy"] = ID_DaiLy;
                _ravi["Thang"] = Thang;
                _ravi["Nam"] = Nam;
                _ravi["LuongDaiLy"] = LuongDaiLy;
                _ravi["TamUng"] = TamUng;
                _ravi["SoTienDaTra"] = SoTienDaTra;               
                _ravi["DaTraLuong"] = DaTraLuong;
                _ravi["TenDaiLy"] = TenDaiLy;
                _ravi["MaDaiLy"] = MaDaiLy;
                _ravi["ThucNhan"] = ThucNhan;
                _ravi["Chon"] = false;
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;

            
            
        }
        private void HienThi()
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                clsDaiLy_BangLuong cls = new clsDaiLy_BangLuong();
                DataTable dt = cls.SelectAll_HienLuong_DaiLy();
                int ssxxthang = Convert.ToInt32(txtThang.Text.ToString());
                int ssxxnam = Convert.ToInt32(txtNam.Text.ToString());

                dt.DefaultView.RowFilter = "Thang=" + ssxxthang + " and Nam=" + ssxxnam + "";
                DataView dv = dt.DefaultView;
                DataTable dt3 = dv.ToTable();                

               
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID_BangLuong", typeof(int));
                dt2.Columns.Add("ID_DaiLy", typeof(int));
                dt2.Columns.Add("Thang", typeof(int));
                dt2.Columns.Add("Nam", typeof(int));
                dt2.Columns.Add("LuongDaiLy", typeof(decimal));
                dt2.Columns.Add("TamUng", typeof(decimal));
                dt2.Columns.Add("SoTienDaTra", typeof(decimal));
                dt2.Columns.Add("ThucNhan", typeof(decimal));

                dt2.Columns.Add("DaTraLuong", typeof(bool));
                dt2.Columns.Add("TenDaiLy", typeof(string));
                dt2.Columns.Add("MaDaiLy", typeof(string));
                dt2.Columns.Add("Chon", typeof(bool));
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    int ID_BangLuong = Convert.ToInt32(dt3.Rows[i]["LuongDaiLy"].ToString());
                    int ID_DaiLy = Convert.ToInt32(dt3.Rows[i]["ID_DaiLy"].ToString());
                    int Thang = Convert.ToInt32(dt3.Rows[i]["Thang"].ToString());
                    int Nam = Convert.ToInt32(dt3.Rows[i]["Nam"].ToString());

                    Decimal LuongDaiLy = Convert.ToDecimal(dt3.Rows[i]["LuongDaiLy"].ToString());
                    Decimal TamUng = Convert.ToDecimal(dt3.Rows[i]["TamUng"].ToString());
                    Decimal SoTienDaTra = Convert.ToDecimal(dt3.Rows[i]["SoTienDaTra"].ToString());
                    Decimal ThucNhan = LuongDaiLy - TamUng - SoTienDaTra;

                    bool DaTraLuong = Convert.ToBoolean(dt3.Rows[i]["DaTraLuong"].ToString());
                    string TenDaiLy = dt3.Rows[i]["TenDaiLy"].ToString();
                    string MaDaiLy = dt3.Rows[i]["MaDaiLy"].ToString();
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_BangLuong"] = ID_BangLuong;
                    _ravi["ID_DaiLy"] = ID_DaiLy;
                    _ravi["Thang"] = Thang;
                    _ravi["Nam"] = Nam;
                    _ravi["LuongDaiLy"] = LuongDaiLy;
                    _ravi["TamUng"] = TamUng;
                    _ravi["SoTienDaTra"] = SoTienDaTra;
                    _ravi["DaTraLuong"] = DaTraLuong;
                    _ravi["TenDaiLy"] = TenDaiLy;
                    _ravi["MaDaiLy"] = MaDaiLy;
                    _ravi["ThucNhan"] = ThucNhan;
                    _ravi["Chon"] = false;
                    dt2.Rows.Add(_ravi);
                }

                gridControl1.DataSource = dt2;

              
            }
        }
        public UCDaiLy_TinhLuong()
        {
            InitializeComponent();
        }

        private void UCDaiLy_TinhLuong_Load(object sender, EventArgs e)
        {
            txtThang.ResetText();
            DateTime ngayhomnay = DateTime.Today;
            txtNam.Text = ngayhomnay.ToString("yyyy");
            HienThi_ALL();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCDaiLy_TinhLuong_Load( sender,  e);
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
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

        private void btThemMoi_Click(object sender, EventArgs e)
        {
         
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue(clID_BangLuong).ToString() != "")
            //{
            //    mbThemMoiTraLuong = false;
            //    mID_TraLuong_Sua = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_BangLuong).ToString());
            //    frmLuong_ChiTietTraLuong ff = new CtyTinLuong.frmLuong_ChiTietTraLuong();
            //    ff.Show();
            //}     
        }

        //private void check_ALL_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (check_ALL.Checked == true)
        //    {
        //        DataTable dt3 = (DataTable)gridControl1.DataSource;
        //        for (int i = 0; i < dt3.Rows.Count; i++)
        //        {
        //            dt3.Rows[i]["Chon"] = true;
        //        }
        //        gridControl1.DataSource = dt3;
        //    }
        //    if (check_ALL.Checked == false)
        //    {
        //        DataTable dt3 = (DataTable)gridControl1.DataSource;
        //        for (int i = 0; i < dt3.Rows.Count; i++)
        //        {
        //            dt3.Rows[i]["Chon"] = false;
        //        }
        //        gridControl1.DataSource = dt3;
        //    }
        //    double deTOngtien;
        //    DataTable dataTable = (DataTable)gridControl1.DataSource;
        //    object xxxx = dataTable.Compute("sum(ThucNhan)", "Chon=True");
        //    if (xxxx.ToString() != "")
        //        deTOngtien = Convert.ToDouble(xxxx);
        //    else deTOngtien = 0;
        //    txtTongTienLuong.Text = deTOngtien.ToString();
        //    txtSoTienThanhToan.Text = deTOngtien.ToString();
        //}

        private void btThemMoi_Click_1(object sender, EventArgs e)
        {
            mbThemMoiTraLuong = true;
            frmLuong_ChiTietTraLuong ff = new frmLuong_ChiTietTraLuong();
            ff.Show();
        }
    }
}
