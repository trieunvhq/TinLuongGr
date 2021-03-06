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
               
                _ravi["NoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoDauKy"].ToString());
                _ravi["CoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoDauKy"].ToString());

                _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());


                _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());

              

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

            Xtra_CongNo_NganHang xtr111 = new Xtra_CongNo_NganHang();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbCongNo_NganHang.Clone();
            ds.tbCongNo_NganHang.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbCongNo_NganHang.NewRow();

                _ravi["SoTaiKhoanCon"] = dt3.Rows[i]["SoTaiKhoanCon"].ToString();
                _ravi["TenTaiKhoanCon"] = dt3.Rows[i]["TenTaiKhoanCon"].ToString();

                _ravi["NoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoDauKy"].ToString());
                _ravi["CoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoDauKy"].ToString());

                _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());


                _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());



                ds.tbCongNo_NganHang.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbCongNo_NganHang;
            xtr111.DataMember = "tbCongNo_NganHang";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        private void Print_BanHang_CongNo(DataTable dt3)
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

                _ravi["NoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoDauKy"].ToString());
                _ravi["CoDauKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoDauKy"].ToString());

                _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());


                _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());



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
            //Xtra_DoiChieuCongNo_test xtr111 = new Xtra_DoiChieuCongNo_test();


            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietBienDongTaiKhoan.Clone();
            ds.tbChiTietBienDongTaiKhoan.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbChiTietBienDongTaiKhoan.NewRow();

              
                if (dt3.Rows[i]["NoTrongKy"].ToString() != "")
                    _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                else
                    _ravi["NoTrongKy"] = 0;
                if (dt3.Rows[i]["CoTrongKy"].ToString() != "")
                    _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());
                else
                    _ravi["CoTrongKy"] = 0;
                if (dt3.Rows[i]["NoCuoiKy"].ToString() != "")
                    _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                else
                    _ravi["NoCuoiKy"] = 0;
                if (dt3.Rows[i]["CoCuoiKy"].ToString() != "")
                    _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());
                else
                    _ravi["CoCuoiKy"] = 0;
                if (dt3.Rows[i]["NgayThang"].ToString()!="")
                {                  
                    _ravi["NgayThang"] = Convert.ToDateTime(dt3.Rows[i]["NgayThang"].ToString());
                }
                if (dt3.Rows[i]["MaVT"].ToString() != "")
                {
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["SoLuong"] = dt3.Rows[i]["SoLuong"].ToString();
                    _ravi["ThanhTien"] = dt3.Rows[i]["ThanhTien"].ToString();
                }
                  
                _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] =dt3.Rows[i]["DienGiai"].ToString();
                _ravi["STT"] = dt3.Rows[i]["STT"].ToString();
                ds.tbChiTietBienDongTaiKhoan.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietBienDongTaiKhoan;
            xtr111.DataMember = "tbChiTietBienDongTaiKhoan";         
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        private void Print_BanHang_ChiTietCongNo(DataTable dt3)
        {

            Xtra_DoiChieuCongNo xtr111 = new Xtra_DoiChieuCongNo();
            //Xtra_DoiChieuCongNo_test xtr111 = new Xtra_DoiChieuCongNo_test();


            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietBienDongTaiKhoan.Clone();
            ds.tbChiTietBienDongTaiKhoan.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbChiTietBienDongTaiKhoan.NewRow();


                if (dt3.Rows[i]["NoTrongKy"].ToString() != "")
                    _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                else
                    _ravi["NoTrongKy"] = 0;
                if (dt3.Rows[i]["CoTrongKy"].ToString() != "")
                    _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());
                else
                    _ravi["CoTrongKy"] = 0;
                if (dt3.Rows[i]["NoCuoiKy"].ToString() != "")
                    _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                else
                    _ravi["NoCuoiKy"] = 0;
                if (dt3.Rows[i]["CoCuoiKy"].ToString() != "")
                    _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());
                else
                    _ravi["CoCuoiKy"] = 0;
                if (dt3.Rows[i]["NgayThang"].ToString() != "")
                {
                    _ravi["NgayThang"] = Convert.ToDateTime(dt3.Rows[i]["NgayThang"].ToString());
                }
                if (dt3.Rows[i]["MaVT"].ToString() != "")
                {
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["SoLuong"] = dt3.Rows[i]["SoLuong"].ToString();
                    _ravi["ThanhTien"] = dt3.Rows[i]["ThanhTien"].ToString();
                }

                _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                _ravi["STT"] = dt3.Rows[i]["STT"].ToString();
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
                _ravi["NoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoTrongKy"].ToString());
                if (dt3.Rows[i]["CoTrongKy"].ToString() != "")
                    _ravi["CoTrongKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoTrongKy"].ToString());

                if (dt3.Rows[i]["NoCuoiKy"].ToString() != "")
                    _ravi["NoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["NoCuoiKy"].ToString());
                if (dt3.Rows[i]["CoCuoiKy"].ToString() != "")
                    _ravi["CoCuoiKy"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["CoCuoiKy"].ToString());



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
                Print_MuaHang_frmChiTietCongNo_MuaHang(MuaHang_frmChiTietCongNo_MuaHang.mdtPrint);
            if(BanHang_CongNo.mbPrint==true)
                Print_BanHang_CongNo(BanHang_CongNo.mdt_ChiTiet_Print);
            if (BanHang_ChiTietCongNo.mbPrint)
                Print_BanHang_ChiTietCongNo(BanHang_ChiTietCongNo.mdtPrint);
        }

        private void frmPrintCongNoNganHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChiTietBienDongTaiKhoan.mbPrint = false;
            frmChiTietBienDongTaiKhoan_Mot_TaiKhoan.mbPrint = false;
            MuaHang_frmCongNo.mbPrint = false;
            MuaHang_frmChiTietCongNo_MuaHang.mbPrint = false;
            BanHang_CongNo.mbPrint = false;
            BanHang_ChiTietCongNo.mbPrint = false;
        }
    }
}
