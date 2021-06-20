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
    public partial class frmPrintCongNoNganHang : Form
    {
        //MuaHang_frmChiTietCongNo_MuaHang
       

        private void Print_frmChiTietBienDongTaiKhoan(DataTable dt3)
        {

            Xtra_CongNo_NganHang xtr111 = new Xtra_CongNo_NganHang();
            
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbCongNo_NganHang.Clone();
            ds.tbCongNo_NganHang.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbCongNo_NganHang.NewRow();

                _ravi["SoTaiKhoanCon"] = dt3.Rows[i]["SoTaiKhoanCon"].ToString();
                _ravi["TenTaiKhoanCon"] = dt3.Rows[i]["TenTaiKhoanCon"].ToString();
               
                _ravi["NoDauKy"] = Convert.ToDouble(dt3.Rows[i]["NoDauKy"].ToString());
                _ravi["CoDauKy"] = Convert.ToDouble(dt3.Rows[i]["CoDauKy"].ToString());

                _ravi["NoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["NoTrongKy"].ToString());
                _ravi["CoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["CoTrongKy"].ToString());


                _ravi["NoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["NoCuoiKy"].ToString());
                _ravi["CoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["CoCuoiKy"].ToString());

              

                ds.tbCongNo_NganHang.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNo_NganHang;
            xtr111.DataMember = "tbCongNo_NganHang";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        private void Print_MuaHang_frmCongNo(DataTable dt3)
        {

            Xtra_DoiChieuCongNo xtr111 = new Xtra_DoiChieuCongNo();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbCongNo_NganHang.Clone();
            ds.tbCongNo_NganHang.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbCongNo_NganHang.NewRow();

                _ravi["SoTaiKhoanCon"] = dt3.Rows[i]["SoTaiKhoanCon"].ToString();
                _ravi["TenTaiKhoanCon"] = dt3.Rows[i]["TenTaiKhoanCon"].ToString();

                _ravi["NoDauKy"] = Convert.ToDouble(dt3.Rows[i]["NoDauKy"].ToString());
                _ravi["CoDauKy"] = Convert.ToDouble(dt3.Rows[i]["CoDauKy"].ToString());

                _ravi["NoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["NoTrongKy"].ToString());
                _ravi["CoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["CoTrongKy"].ToString());


                _ravi["NoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["NoCuoiKy"].ToString());
                _ravi["CoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["CoCuoiKy"].ToString());



                ds.tbCongNo_NganHang.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNo_NganHang;
            xtr111.DataMember = "tbCongNo_NganHang";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_MuaHang_frmChiTietCongNo_MuaHang(DataTable dt3)
        {

            Xtra_DoiChieuCongNo xtr111 = new Xtra_DoiChieuCongNo();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietBienDongTaiKhoan.Clone();
            ds.tbChiTietBienDongTaiKhoan.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbChiTietBienDongTaiKhoan.NewRow();

                _ravi["SoDuDauKy_No"] = Convert.ToDouble(dt3.Rows[i]["SoDuDauKy_No"].ToString());
                _ravi["SoDuDauKy_Co"] = Convert.ToDouble(dt3.Rows[i]["SoDuDauKy_Co"].ToString());
                _ravi["TenNhaCungCap"] = dt3.Rows[i]["TenNhaCungCap"].ToString();
                if(dt3.Rows[i]["NgayThang"].ToString()!="")
                {
                    DateTime ngay= Convert.ToDateTime(dt3.Rows[i]["NgayThang"].ToString());
                    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");
                }
               
                _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] =dt3.Rows[i]["DienGiai"].ToString();
                _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["ThanhTien"].ToString());
                ds.tbChiTietBienDongTaiKhoan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietBienDongTaiKhoan;
            xtr111.DataMember = "tbChiTietBienDongTaiKhoan";         
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_ChiTiet_TAIkHOAN(DataTable dt3)
        {

            Xtra_CongNo_ChiTiet_Mot_taiKhoan xtr111 = new Xtra_CongNo_ChiTiet_Mot_taiKhoan();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietBienDongTaiKhoan.Clone();
            ds.tbChiTietBienDongTaiKhoan.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbChiTietBienDongTaiKhoan.NewRow();

                if (dt3.Rows[i]["NgayThang"].ToString() != "")
                    _ravi["NgayThang"] = Convert.ToDateTime(dt3.Rows[i]["NgayThang"].ToString());
                _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();

                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
               
                if(dt3.Rows[i]["NoTrongKy"].ToString()!="")
                _ravi["NoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["NoTrongKy"].ToString());
                if (dt3.Rows[i]["CoTrongKy"].ToString() != "")
                    _ravi["CoTrongKy"] = Convert.ToDouble(dt3.Rows[i]["CoTrongKy"].ToString());

                if (dt3.Rows[i]["NoCuoiKy"].ToString() != "")
                    _ravi["NoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["NoCuoiKy"].ToString());
                if (dt3.Rows[i]["CoCuoiKy"].ToString() != "")
                    _ravi["CoCuoiKy"] = Convert.ToDouble(dt3.Rows[i]["CoCuoiKy"].ToString());



                ds.tbChiTietBienDongTaiKhoan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietBienDongTaiKhoan;
            xtr111.DataMember = "tbChiTietBienDongTaiKhoan";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrintCongNoNganHang()
        {
            InitializeComponent();
        }

        private void frmPrintCongNoNganHang_Load(object sender, EventArgs e)
        {
          
            if (frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mbPrint == true)
                Print_ChiTiet_TAIkHOAN(frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mdt_ChiTiet_Print);
            if (frmChiTietBienDongTaiKhoan.mbPrint == true)
                Print_frmChiTietBienDongTaiKhoan(frmChiTietBienDongTaiKhoan.mdt_ChiTiet_Print);
            if (MuaHang_frmCongNo.mbPrint == true)
                Print_MuaHang_frmCongNo(MuaHang_frmCongNo.mdt_ChiTiet_Print);
            if (MuaHang_frmChiTietCongNo_MuaHang.mbPrint == true)
                Print_MuaHang_frmChiTietCongNo_MuaHang(MuaHang_frmChiTietCongNo_MuaHang.mdt_ChiTiet_Print);
            
        }

        private void frmPrintCongNoNganHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChiTietBienDongTaiKhoan.mbPrint = false;
            frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mbPrint = false;
            MuaHang_frmCongNo.mbPrint = false;
            MuaHang_frmChiTietCongNo_MuaHang.mbPrint = false;
        }
    }
}
