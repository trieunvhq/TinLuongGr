using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmImPortPhieuNganHang : Form
    {
        public frmImPortPhieuNganHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btChonFile_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

                OleDbConnection con = new OleDbConnection();
                string Tenfile_Execl;
                DataTable dt = new DataTable();
                DataTable dtNganhang = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();
                OleDbDataAdapter adapterNganHang = new OleDbDataAdapter();
                string str_adapterNganHang = "Select * from [Sheet1$]";
                adapterNganHang = new OleDbDataAdapter(str_adapterNganHang, con);
                adapterNganHang.Fill(dtNganhang);

                DataTable dtnganghang2 = new DataTable();

                dtnganghang2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
                dtnganghang2.Columns.Add("ID_TaiKhoanKeToanMe", typeof(int));
                dtnganghang2.Columns.Add("Co", typeof(double));
                dtnganghang2.Columns.Add("No", typeof(double));
                dtnganghang2.Columns.Add("TienUSD", typeof(bool));
                dtnganghang2.Columns.Add("SoTaiKhoanCon", typeof(string));
                dtnganghang2.Columns.Add("SoTaiKhoanMe", typeof(string));
                dtnganghang2.Columns.Add("TenTaiKhoanCon", typeof(string));

                if (dtNganhang.Rows.Count > 0)
                {
                    for (int i = 3; i < dtNganhang.Rows.Count; i++)
                    {
                        double Co, No;
                        int ID_TaiKhoanKeToanCon, ID_TaiKhoanKeToanMe;
                        bool TienUSD;
                        string sSoTaiKhoanCon, sSoTaiKhoanMe, TenTaiKhoanCon;
                        sSoTaiKhoanCon = dtNganhang.Rows[i][1].ToString();
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.sSoTaiKhoanCon = sSoTaiKhoanCon;
                        DataTable dttkcon = clscon.select_one_W_SoTaiKhoanCon();
                        if(dttkcon.Rows.Count>0)
                        {
                            TenTaiKhoanCon = dttkcon.Rows[0]["TenTaiKhoanCon"].ToString();
                            ID_TaiKhoanKeToanCon = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                            ID_TaiKhoanKeToanMe = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanMe"].ToString());
                        }
                        else
                        {
                            TenTaiKhoanCon = "";
                            ID_TaiKhoanKeToanCon = 0;
                            ID_TaiKhoanKeToanMe = 0;
                        }
                        if (dtNganhang.Rows[i][4].ToString() != "")
                            Co = Convert.ToDouble(dtNganhang.Rows[i][4].ToString());
                        else Co = 0;
                        if (dtNganhang.Rows[i][3].ToString() != "")
                            No = Convert.ToDouble(dtNganhang.Rows[i][3].ToString());
                        else No = 0;
                     
                        clsNganHang_tbHeThongTaiKhoanKeToanMe clsme = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                        clsme.iID_TaiKhoanKeToanMe = ID_TaiKhoanKeToanMe;
                        DataTable dtme = clsme.SelectOne();
                        if (dtme.Rows.Count > 0)
                            sSoTaiKhoanMe = clsme.sSoTaiKhoanMe.Value;
                        else sSoTaiKhoanMe = "";
                        if (dtNganhang.Rows[i][5].ToString() == "USD")
                            TienUSD = true;
                        else TienUSD = false;
                        DataRow _ravi = dtnganghang2.NewRow();
                        _ravi["ID_TaiKhoanKeToanCon"] = ID_TaiKhoanKeToanCon;
                        _ravi["ID_TaiKhoanKeToanMe"] = ID_TaiKhoanKeToanMe;
                        _ravi["Co"] = Co;
                        _ravi["No"] = No;
                        _ravi["TienUSD"] = TienUSD;
                        _ravi["SoTaiKhoanCon"] = sSoTaiKhoanCon;
                        _ravi["SoTaiKhoanMe"] = sSoTaiKhoanMe;
                        _ravi["TenTaiKhoanCon"] = TenTaiKhoanCon;
                        dtnganghang2.Rows.Add(_ravi);
                    }
               
                    gridControl2.DataSource = dtnganghang2;
                }
                }
            }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

                OleDbConnection con = new OleDbConnection();
                string Tenfile_Execl;
                DataTable dt = new DataTable();
                DataTable dtNganhang = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();
                OleDbDataAdapter adapterNganHang = new OleDbDataAdapter();
                string str_adapterNganHang = "Select * from [Sheet1$]";
                adapterNganHang = new OleDbDataAdapter(str_adapterNganHang, con);
                adapterNganHang.Fill(dtNganhang);

                for (int i = 3; i < dtNganhang.Rows.Count; i++)
                {
                    string sSoTaiKhoanCon = dtNganhang.Rows[i][1].ToString();
                    string TenTaiKhoanCon = dtNganhang.Rows[i][2].ToString();
                    clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                    clscon.sSoTaiKhoanCon = sSoTaiKhoanCon;
                    DataTable dttkcon = clscon.select_one_W_SoTaiKhoanCon();
                    if (dttkcon.Rows.Count > 0)
                    {

                        int ID_TaiKhoanKeToanCon = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                        clscon.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                        clscon.sTenTaiKhoanCon = TenTaiKhoanCon;
                        clscon.Update_W_TenTaiKhoan_newwww();


                    }
                }
                MessageBox.Show("Đã xong");
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan clschitietbeindong = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            //clsNganHang_SoDuBanDau_TaiKhoanKeToan clstondauky = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();

            DataTable dtnganhang = (DataTable)gridControl2.DataSource;

            for (int i = 0; i < dtnganhang.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanCon = Convert.ToInt32(dtnganhang.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                int ID_TaiKhoanKeToanMe = Convert.ToInt32(dtnganhang.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                double Co = Convert.ToDouble(dtnganhang.Rows[i]["Co"].ToString());
                double No = Convert.ToDouble(dtnganhang.Rows[i]["No"].ToString());
                bool TienUSD = Convert.ToBoolean(dtnganhang.Rows[i]["TienUSD"].ToString());
                double TiGia = 0;
                clschitietbeindong.iID_ChungTu = 0;
                clschitietbeindong.sSoChungTu = "";
                clschitietbeindong.daNgayThang = DateTime.Today;
                clschitietbeindong.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                clschitietbeindong.iID_DoiTuong = 0;

                clschitietbeindong.fCo = Co;
                clschitietbeindong.fNo = No;
                clschitietbeindong.bTienUSD = TienUSD;
                clschitietbeindong.fTiGia = TiGia;


                clschitietbeindong.bTonTai = true;
                clschitietbeindong.bNgungTheoDoi = false;
                clschitietbeindong.bDaGhiSo = true;
                clschitietbeindong.bBBool_TonDauKy = true;
                clschitietbeindong.iTrangThai_MuaHang1_BanHang2_VAT3 = 0;
                clschitietbeindong.Insert();
                // ton đâu kỳ

            }

            MessageBox.Show("Đã xong ngân hàng");
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
               // clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

                OleDbConnection con = new OleDbConnection();
                string Tenfile_Execl;
                DataTable dt = new DataTable();
                DataTable dtNganhang = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();
                OleDbDataAdapter adapterNganHang = new OleDbDataAdapter();
                string str_adapterNganHang = "Select * from [Sheet2$]";
                adapterNganHang = new OleDbDataAdapter(str_adapterNganHang, con);
                adapterNganHang.Fill(dtNganhang);

                for (int i = 3; i < dtNganhang.Rows.Count; i++)
                {
                    string sSoTaiKhoanCon = dtNganhang.Rows[i][1].ToString();
                    string TenNCC = dtNganhang.Rows[i][2].ToString();
                    clsTbNhaCungCap cls = new clsTbNhaCungCap();
                    cls.sTenNhaCungCap = TenNCC;
                    DataTable dtkh = cls.SelectOne_W_TenNhaCungCap();
                    
                    if (dtkh.Rows.Count==0) // thêm mới
                    {
                        int ID_TaiKhoanKeToanCon = 0;
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.sSoTaiKhoanCon = sSoTaiKhoanCon;
                        DataTable dttkcon = clscon.select_one_W_SoTaiKhoanCon();
                        if (dttkcon.Rows.Count > 0)
                        {

                            ID_TaiKhoanKeToanCon = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                           
                        }
                        cls.sMaNhaCungCap = "NCC " + i.ToString() + "";
                        cls.sMaSoThue = "";
                        cls.sTenNhaCungCap = TenNCC;
                        cls.sDiaChi = "";
                        cls.sDienGiai = TenNCC;
                        cls.sSoDienThoai = "";
                        cls.sEmail = "";
                        cls.sSoTaiKhoan = sSoTaiKhoanCon;
                        cls.sTenNganHang = "";
                        cls.sTinh_ThanhPho = "";
                        cls.sChiNhanh = "";
                        cls.bNgungTheoDoi = false;
                        cls.bTonTai = true;
                        cls.sNguoiLienHe = "";
                        cls.iID_TaiKhoanKeToan = ID_TaiKhoanKeToanCon;
                        cls.Insert();
                    }
                    if (dtkh.Rows.Count > 0) // sửa
                    {
                        int xxID_NhaCungCap= Convert.ToInt32(dtkh.Rows[0]["ID_NhaCungCap"].ToString());
                        int ID_TaiKhoanKeToanCon = 0;
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.sSoTaiKhoanCon = sSoTaiKhoanCon;
                        DataTable dttkcon = clscon.select_one_W_SoTaiKhoanCon();
                        if (dttkcon.Rows.Count > 0)
                        {

                            ID_TaiKhoanKeToanCon = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());

                        }
                        cls.iID_NhaCungCap = xxID_NhaCungCap;
                        cls.sSoTaiKhoan = sSoTaiKhoanCon;
                        cls.iID_TaiKhoanKeToan = ID_TaiKhoanKeToanCon;
                        cls.Update_W_ID_TaiKhoanKeToan_SoTaiKhoan();
                    }

                }
                MessageBox.Show("Đã xong");
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new CtyTinLuong.clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            DataTable dt = cls.SelectAll_W_TenTaiKhoan_BienDong();
            dt.DefaultView.RowFilter = " bBool_TonDauKy=True";
            DataView dv = dt.DefaultView;         
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }

        private void gridView1_ValidateRow_1(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            int xxxID_TaiKhoanKeToanCon = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_ChiTietBienDongTaiKhoanxxxxxxxxxxxxx).ToString());
            double Co = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clCoxxxxxxxxxxxx).ToString());
            double No = Convert.ToDouble(gridView1.GetFocusedRowCellValue(clNoKhong).ToString());
            cls.iID_ChiTietBienDongTaiKhoan = xxxID_TaiKhoanKeToanCon;
            cls.fCo = Co;
            cls.fNo = No;
            cls.Update_Cokhong_no_Khong();
        }
    }
}
