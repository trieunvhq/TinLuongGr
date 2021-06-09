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
    public partial class frmPrint_Nhap_Xuat_Ton_TongHop : Form
    {
        private void Print_N_X_T( DataTable dt3)
        {
           
            Xtra_Nhap_Xuat_Ton xtr111 = new Xtra_Nhap_Xuat_Ton();
          
            DataTable dt2 = new DataTable();
          
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));

            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));

            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriNhap_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("GiaTriXuat_TrongKy", typeof(double));

            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            dt2.Columns.Add("GiaTriTon_CuoiKy", typeof(double));

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhap_Xuat_Ton.Clone();
            ds.tbNhap_Xuat_Ton.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhap_Xuat_Ton.NewRow();

                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] =dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuong_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuong_TonDauKy"].ToString());
                _ravi["GiaTri_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTri_TonDauKy"].ToString());

                _ravi["SoLuongNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                _ravi["GiaTriNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriNhap_TrongKy"].ToString());


                _ravi["SoLuongXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                _ravi["GiaTriXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriXuat_TrongKy"].ToString());

                _ravi["SoLuongTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongTon_CuoiKy"].ToString());
                _ravi["GiaTriTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriTon_CuoiKy"].ToString());

                ds.tbNhap_Xuat_Ton.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhap_Xuat_Ton;
            xtr111.DataMember = "tbNhap_Xuat_Ton";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_UCDaiLy_NhapXuatTon_theoDaiLy(DataTable dt3)
        {

            Xtra_N_X_T_DaiLy_TheoTung_DaiLy xtr111 = new Xtra_N_X_T_DaiLy_TheoTung_DaiLy();


            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhap_Xuat_Ton.Clone();
            ds.tbNhap_Xuat_Ton.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhap_Xuat_Ton.NewRow();

                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();

                _ravi["MaDaily"] = dt3.Rows[i]["MaDaily"].ToString();
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();

                _ravi["SoLuong_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuong_TonDauKy"].ToString());
                _ravi["GiaTri_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTri_TonDauKy"].ToString());

                _ravi["SoLuongNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                _ravi["GiaTriNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriNhap_TrongKy"].ToString());


                _ravi["SoLuongXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                _ravi["GiaTriXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriXuat_TrongKy"].ToString());

                _ravi["SoLuongTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongTon_CuoiKy"].ToString());
                _ravi["GiaTriTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriTon_CuoiKy"].ToString());
                
                ds.tbNhap_Xuat_Ton.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhap_Xuat_Ton;
            xtr111.DataMember = "tbNhap_Xuat_Ton";            
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_N_X_T_DaiLy(DataTable dt3)
        {

            Xtra_Nhap_Xuat_Ton_DaiLy xtr111 = new Xtra_Nhap_Xuat_Ton_DaiLy();
          

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhap_Xuat_Ton.Clone();
            ds.tbNhap_Xuat_Ton.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhap_Xuat_Ton.NewRow();

                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();

                _ravi["SoLuong_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuong_TonDauKy"].ToString());
                _ravi["GiaTri_TonDauKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTri_TonDauKy"].ToString());

                _ravi["SoLuongNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                _ravi["GiaTriNhap_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriNhap_TrongKy"].ToString());


                _ravi["SoLuongXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                _ravi["GiaTriXuat_TrongKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriXuat_TrongKy"].ToString());

                _ravi["SoLuongTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["SoLuongTon_CuoiKy"].ToString());
                _ravi["GiaTriTon_CuoiKy"] = Convert.ToDouble(dt3.Rows[i]["GiaTriTon_CuoiKy"].ToString());
             //   _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                ds.tbNhap_Xuat_Ton.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhap_Xuat_Ton;
            xtr111.DataMember = "tbNhap_Xuat_Ton";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_Nhap_Xuat_Ton_TongHop()
        {
            InitializeComponent();
        }

        private void frmPrint_Nhap_Xuat_Ton_TongHop_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBaoCaoNXT.mbPrint_NXT_Kho_NPL = false;
            frmBaoCaoNhapXuatTon_BanThanhPham.mbPrint_NXT_Kho_BTP = false;
            UCDaiLy_BaoCao_NhapXuatTon.mbPrint_NXT_Kho = false;
            UCDaiLy_GapDan_baocao_NXT.mbPrint_NXT_Kho = false;
            frmBaoCaoNXT_KhoThanhPham.mbPrint_NXT_Kho_NPL = false;
            UCDaiLy_NhapXuatTon_theoDaiLy.mbPrint_NXT_Kho = false;
        }

        private void frmPrint_Nhap_Xuat_Ton_TongHop_Load(object sender, EventArgs e)
        {
            if (frmBaoCaoNXT.mbPrint_NXT_Kho_NPL == true)
                Print_N_X_T(frmBaoCaoNXT.mdt_ChiTiet_Print);
            if (frmBaoCaoNhapXuatTon_BanThanhPham.mbPrint_NXT_Kho_BTP == true)
                Print_N_X_T(frmBaoCaoNhapXuatTon_BanThanhPham.mdt_ChiTiet_Print);         
            if (UCDaiLy_GapDan_baocao_NXT.mbPrint_NXT_Kho == true)
                Print_N_X_T(UCDaiLy_GapDan_baocao_NXT.mdt_ChiTiet_Print);
            if (frmBaoCaoNXT_KhoThanhPham.mbPrint_NXT_Kho_NPL == true)
                Print_N_X_T(frmBaoCaoNXT_KhoThanhPham.mdt_ChiTiet_Print);

            if (UCDaiLy_BaoCao_NhapXuatTon.mbPrint_NXT_Kho == true)
                Print_N_X_T_DaiLy(UCDaiLy_BaoCao_NhapXuatTon.mdt_ChiTiet_Print);

            if (UCDaiLy_NhapXuatTon_theoDaiLy.mbPrint_NXT_Kho == true)
                Print_UCDaiLy_NhapXuatTon_theoDaiLy(UCDaiLy_NhapXuatTon_theoDaiLy.mdt_ChiTiet_Print);
        }
    }
}
