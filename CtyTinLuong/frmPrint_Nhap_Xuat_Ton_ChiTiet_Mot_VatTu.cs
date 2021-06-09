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
    public partial class frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu : Form
    {
        private void Print_N_X_T_ChiTiet_Mot_Vat_Tu(DataTable dt3)
        {
            
            Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu xtr111 = new Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu();
          
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.NXT_Mot_VatTu_Neww.Clone();
            ds.NXT_Mot_VatTu_Neww.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.NXT_Mot_VatTu_Neww.NewRow();
                if (dt3.Rows[i]["NgayChungTu"].ToString() != "")
                {
                    DateTime ngay = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");
                }
                if (dt3.Rows[i]["Nhap"].ToString() != "")
                    _ravi["Nhap"] = Convert.ToDouble(dt3.Rows[i]["Nhap"].ToString());
                if (dt3.Rows[i]["Xuat"].ToString() != "")
                    _ravi["Xuat"] = Convert.ToDouble(dt3.Rows[i]["Xuat"].ToString());
                if (dt3.Rows[i]["Ton"].ToString() != "")
                    _ravi["Ton"] = Convert.ToDouble(dt3.Rows[i]["Ton"].ToString());
                _ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
                _ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
                //_ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                //_ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                ds.NXT_Mot_VatTu_Neww.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.NXT_Mot_VatTu_Neww;
            xtr111.DataMember = "NXT_Mot_VatTu_Neww";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        //private void Print_N_X_T_ChiTiet_Mot_Vat_Tu_DaiLy(DataTable dt3)
        //{

        //    Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy xtr111 = new Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy();

        //    DataSet_TinLuong ds = new DataSet_TinLuong();
        //    ds.tbNhap_Xuat_ton_ChiTiet_Mot_VatTu.Clone();
        //    ds.tbNhap_Xuat_ton_ChiTiet_Mot_VatTu.Clear();
        //    for (int i = 0; i < dt3.Rows.Count; i++)
        //    {
        //        DataRow _ravi = ds.tbNhap_Xuat_ton_ChiTiet_Mot_VatTu.NewRow();
        //        if(dt3.Rows[i]["NgayChungTu"].ToString()!="")
        //            _ravi["NgayChungTu"] = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
        //        _ravi["Nhap"] = Convert.ToDouble(dt3.Rows[i]["Nhap"].ToString());
        //        _ravi["DonGiaNhap"] = Convert.ToDouble(dt3.Rows[i]["DonGiaNhap"].ToString());
        //        _ravi["GiaTriNhap"] = Convert.ToDouble(dt3.Rows[i]["GiaTriNhap"].ToString());
        //        _ravi["Xuat"] = Convert.ToDouble(dt3.Rows[i]["Xuat"].ToString());
        //        _ravi["DonGiaXuat"] = Convert.ToDouble(dt3.Rows[i]["DonGiaXuat"].ToString());
        //        _ravi["GiaTriXuat"] = Convert.ToDouble(dt3.Rows[i]["GiaTriXuat"].ToString());
        //        _ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
        //        _ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
        //        _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
        //        ds.tbNhap_Xuat_ton_ChiTiet_Mot_VatTu.Rows.Add(_ravi);
        //    }

        //    xtr111.DataSource = null;
        //    xtr111.DataSource = ds.tbNhap_Xuat_ton_ChiTiet_Mot_VatTu;
        //    xtr111.DataMember = "tbNhap_Xuat_ton_ChiTiet_Mot_VatTu";
        //    // xtr111.IntData(sgiamdoc);
        //    xtr111.CreateDocument();
        //    documentViewer1.DocumentSource = xtr111;
        //}
        public frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu()
        {
            InitializeComponent();
        }

        private void frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChiTietNhapXuatTon_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
            frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
        }

        private void frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_Load(object sender, EventArgs e)
        {
           
            if (frmChiTietNhapXuatTon_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                Print_N_X_T_ChiTiet_Mot_Vat_Tu(frmChiTietNhapXuatTon_MotVatTu.mdt_ChiTiet_MotVatTu_N_X_T_Print);
            if (frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                Print_N_X_T_ChiTiet_Mot_Vat_Tu(frmChiTietNhapXuatTon_MotVatTu_khoBanThanhPham.mdt_ChiTiet_MotVatTu_N_X_T_Print);
            if (frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                Print_N_X_T_ChiTiet_Mot_Vat_Tu(frmChiTietNhapXuatTon_MotVatTu_KhoThanhPham.mdt_ChiTiet_MotVatTu_N_X_T_Print);          
            if (GapDan_frmChiTietNhapXuatTon_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
                Print_N_X_T_ChiTiet_Mot_Vat_Tu(GapDan_frmChiTietNhapXuatTon_MotVatTu.mdt_ChiTiet_MotVatTu_N_X_T_Print);

            //if (DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu == true)
            //    Print_N_X_T_ChiTiet_Mot_Vat_Tu_DaiLy(DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdt_ChiTiet_MotVatTu_N_X_T_Print);
        }
    }
}
