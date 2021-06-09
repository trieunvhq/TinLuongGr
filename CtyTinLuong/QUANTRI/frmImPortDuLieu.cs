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
    public partial class frmImPortDuLieu : Form
    {
        public frmImPortDuLieu()
        {
            InitializeComponent();
        }

        private void btDinhMucNPL_Click(object sender, EventArgs e)
        {

            //OpenFileDialog f = new OpenFileDialog();
            //f.Filter = "File (*.xls)|*.xls";
            //f.Multiselect = false;
            //f.Title = "Chon CSDL";
            //// f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            //if (f.ShowDialog() == DialogResult.OK)
            //{
            //    OleDbConnection con33;
            //    string Tenfile_Execl;
            //    DataTable daa = new DataTable();
            //    Tenfile_Execl = f.FileName;
            //    string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
            //    con33 = new OleDbConnection(str_con3);
            //    con33.Open();
            //    OleDbDataAdapter adada = new OleDbDataAdapter();
            //    string str555 = "Select * from [Sheet1$]";
            //    adada = new OleDbDataAdapter(str555, con33);
            //    adada.Fill(daa);
            //    clsTbNhaCungCap cls = new clsTbNhaCungCap();
            //    for (int i = 6; i < daa.Rows.Count; i++)
            //    {
            //        cls.sMaNCC = daa.Rows[i][0].ToString();
            //        cls.sTen = daa.Rows[i][1].ToString();
            //        cls.sDiaChi = daa.Rows[i][2].ToString();
            //        cls.sSoDienThoai = daa.Rows[i][6].ToString();
            //        cls.iID_MaNhomNCC = 1;
            //        cls.Insert();
            //        //cls.SQL_tbNhanSu_Insert_Excel();
            //    }
            //    MessageBox.Show("Đaxong");


            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection con33;
                string Tenfile_Execl;
                DataTable daa = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con33 = new OleDbConnection(str_con3);
                con33.Open();
                OleDbDataAdapter adada = new OleDbDataAdapter();
                string str555 = "Select * from [Sheet1$]";
                adada = new OleDbDataAdapter(str555, con33);
                adada.Fill(daa);
                clsDinhMuc_tbDM_NguyenPhuLieu cls = new clsDinhMuc_tbDM_NguyenPhuLieu();
                for (int i = 3; i < daa.Rows.Count; i++)
                {
                    //cls.sMaNCC = daa.Rows[i][0].ToString();
                    cls.sMaDinhMuc = daa.Rows[i][1].ToString();
                 
                    cls.sDienGiai = daa.Rows[i][3].ToString();
                    cls.daNgayLap = DateTime.Today;
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.Insert();
                    //cls.SQL_tbNhanSu_Insert_Excel();
                }
                MessageBox.Show("Đaxong");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection con33;
                string Tenfile_Execl;
                DataTable daa = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con33 = new OleDbConnection(str_con3);
                con33.Open();
                OleDbDataAdapter adada = new OleDbDataAdapter();
                string str555 = "Select * from [Sheet2$]";
                adada = new OleDbDataAdapter(str555, con33);
                adada.Fill(daa);
                clsDinhMuc_ChiTiet_DM_NPL cls = new clsDinhMuc_ChiTiet_DM_NPL();
                for (int i = 1; i < daa.Rows.Count; i++)
                {
                    //cls.sMaNCC = daa.Rows[i][0].ToString();
                    cls.iID_DinhMuc_NPL =Convert.ToInt16(daa.Rows[i][1].ToString());
                    cls.iID_VTHH = Convert.ToInt16(daa.Rows[i][2].ToString());
                    cls.fSoLuong = Convert.ToDouble(daa.Rows[i][6].ToString());
                    
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.Insert();
                    //cls.SQL_tbNhanSu_Insert_Excel();
                }
                MessageBox.Show("Đaxong");
            }
        }

        private void btDaiLy_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection con33;
                string Tenfile_Execl;
                DataTable daa = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con33 = new OleDbConnection(str_con3);
                con33.Open();
                OleDbDataAdapter adada = new OleDbDataAdapter();
                string str555 = "Select * from [Sheet1$]";
                adada = new OleDbDataAdapter(str555, con33);
                adada.Fill(daa);
                clsTbDanhMuc_DaiLy cls = new clsTbDanhMuc_DaiLy();
                for (int i = 6; i < daa.Rows.Count; i++)
                {
                    //cls.sMaNCC = daa.Rows[i][0].ToString();
                    //cls.iID_VTHH = Convert.ToInt16(daa.Rows[i][2].ToString());
                    cls.sMaDaiLy = daa.Rows[i][0].ToString();
                    cls.sTenDaiLy= daa.Rows[i][1].ToString();
                    cls.sDiaChi = daa.Rows[i][2].ToString();
                    cls.sSoDienThoai= daa.Rows[i][6].ToString();
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    cls.Insert();
                    //cls.SQL_tbNhanSu_Insert_Excel();
                }
                MessageBox.Show("Đaxong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
           
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection con33;
                string Tenfile_Execl;
                DataTable daa = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con33 = new OleDbConnection(str_con3);
                con33.Open();
                OleDbDataAdapter adada = new OleDbDataAdapter();
                string str555 = "Select * from [Sheet2$]";
                adada = new OleDbDataAdapter(str555, con33);
                adada.Fill(daa);
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                for (int i = 1; i < daa.Rows.Count; i++)
                {

                    cls.iID_TaiKhoanKeToanMe =Convert.ToInt16(daa.Rows[i][0].ToString());
                    cls.sSoTaiKhoanCon = daa.Rows[i][1].ToString();
                    cls.sTenTaiKhoanCon = daa.Rows[i][2].ToString();
                    cls.sDienGiaiCon = "";
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                   
                    cls.sGhiChuCon = "";
                    cls.Insert();
                    
                }
                MessageBox.Show("Đaxong");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection con33;
                string Tenfile_Execl;
                DataTable daa = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con3 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con33 = new OleDbConnection(str_con3);
                con33.Open();
                OleDbDataAdapter adada = new OleDbDataAdapter();
                string str555 = "Select * from [Sheet1$]";
                adada = new OleDbDataAdapter(str555, con33);
                adada.Fill(daa);
                clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                for (int i = 0; i < 50; i++)
                {
                    
                    cls.sSoTaiKhoanMe = daa.Rows[i][0].ToString();
                    cls.sTenTaiKhoanMe = daa.Rows[i][1].ToString();
                    cls.sDienGiaiMe = "";                    
                    cls.bTonTai = true;
                    cls.bNgungTheoDoi = false;
                    
                    cls.Insert();
                    //cls.SQL_tbNhanSu_Insert_Excel();
                }
                MessageBox.Show("Đaxong");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clsTbNhaCungCap cls = new CtyTinLuong.clsTbNhaCungCap();
            DataTable dt = cls.SelectAll();
            for(int i=0; i<dt.Rows.Count;i++)
            {
                cls.iID_NhaCungCap =Convert.ToInt16(dt.Rows[i]["ID_NhaCungCap"].ToString());
                string ss = "";
                ss = dt.Rows[i]["MaNhaCungCap"].ToString().Trim();
                cls.sMaNhaCungCap = ss;
                cls.HUU_Sua_Loi_nvachar_NhaCungCap();
            }
            MessageBox.Show("Đaxong");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clsTbNhaCungCap cls2 = new clsTbNhaCungCap();
            DataTable dt = cls2.SelectAll();
            clsNganHang_TaiKhoanKeToanCon cls = new CtyTinLuong.clsNganHang_TaiKhoanKeToanCon();
            for (int i = 2; i < dt.Rows.Count; i++)
            {
                cls.iID_TaiKhoanKeToanMe = 287;
                cls.bNgungTheoDoi = false;
                cls.bTonTai = true;
                cls.sSoTaiKhoanCon = "331." + (i +2).ToString() + "";
                cls.sTenTaiKhoanCon = "";
                cls.sDienGiaiCon = "";
                cls.sGhiChuCon = "";
                cls.Insert();
                int iiiIDTakhoan = cls.iID_TaiKhoanKeToanCon.Value;

                cls2.iID_NhaCungCap = Convert.ToInt16(dt.Rows[i]["ID_NhaCungCap"].ToString());
                cls2.iID_TaiKhoanKeToan = iiiIDTakhoan;
                cls2.HUU_UPDATE_TaiKhoanKeToanb();


            }
            MessageBox.Show("Đã xong");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clsNhanSu_tbNhanSu cls = new CtyTinLuong.clsNhanSu_tbNhanSu();
            DataTable dt = cls.SelectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cls.iID_NhanSu = Convert.ToInt16(dt.Rows[i]["ID_NhanSu"].ToString());
                string ss = "";
                ss = dt.Rows[i]["MaNhanVien"].ToString().Trim();
                cls.sMaNhanVien = ss;
                cls.HUU_Sua_Loi_nvachar_NhanSu();
            }
            MessageBox.Show("Đaxong");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
            DataTable dt = cls.SelectAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

            }
        }
    }
}
