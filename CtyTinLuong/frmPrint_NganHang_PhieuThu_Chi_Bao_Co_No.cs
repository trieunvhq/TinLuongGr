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
    public partial class frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No : Form
    {
        //Quy_nganHang_ChiTiet_thuChi_Newwwwwwwwwwwwwwww
    
        private void Print_NganHang_PhieuThu_Chi_Bao_Co_No(DataTable dt3)
        {

            Xtra_NganHang_PhieuThu_Chi_Bao_Co_No xtr111 = new Xtra_NganHang_PhieuThu_Chi_Bao_Co_No();
          
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("SoTaiKhoanCon", typeof(string));
            //dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            //dt2.Columns.Add("GhiChu", typeof(string));
            //dt2.Columns.Add("No", typeof(double));
            //dt2.Columns.Add("Co", typeof(double));
            //dt2.Columns.Add("TienUSD", typeof(bool));
            //dt2.Columns.Add("TiGia", typeof(double));

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNganHang_PhieuThu_Chi_Bao_Co_No.Clone();
            ds.tbNganHang_PhieuThu_Chi_Bao_Co_No.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNganHang_PhieuThu_Chi_Bao_Co_No.NewRow();
                _ravi["SoTaiKhoanCon"] = dt3.Rows[i]["SoTaiKhoanCon"].ToString();
                _ravi["TenTaiKhoanCon"] = dt3.Rows[i]["TenTaiKhoanCon"].ToString();
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                _ravi["No"] = Convert.ToDouble(dt3.Rows[i]["No"].ToString());
                _ravi["Co"] = Convert.ToDouble(dt3.Rows[i]["Co"].ToString());
                _ravi["TienUSD"] = Convert.ToBoolean(dt3.Rows[i]["TienUSD"].ToString());
                _ravi["TiGia"] = Convert.ToDouble(dt3.Rows[i]["TiGia"].ToString());
                ds.tbNganHang_PhieuThu_Chi_Bao_Co_No.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNganHang_PhieuThu_Chi_Bao_Co_No;
            xtr111.DataMember = "tbNganHang_PhieuThu_Chi_Bao_Co_No";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
       
        public frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No()
        {
            InitializeComponent();
        }

        private void frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No_Load(object sender, EventArgs e)
        {
           
            if (Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mbPrint == true)
                Print_NganHang_PhieuThu_Chi_Bao_Co_No(Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mdtCHiTietTaKhoan_print);
        }

        private void frmPrint_NganHang_PhieuThu_Chi_Bao_Co_No_FormClosed(object sender, FormClosedEventArgs e)
        {

            Quy_nganHang_frmThemMoi_ThuChi_CoNo_Newwwwww.mbPrint = false;
        }
    }
}
