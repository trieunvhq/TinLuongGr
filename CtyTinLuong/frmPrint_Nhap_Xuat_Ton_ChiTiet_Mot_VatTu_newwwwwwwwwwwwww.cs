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
    public partial class frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww : Form
    {
        private void Print_DaiLy_BaoCao_TonKho_One(DataTable dt3)
        {

            Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy xtr111 = new Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.NXT_Mot_VatTu_Neww.Clone();
            ds.NXT_Mot_VatTu_Neww.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.NXT_Mot_VatTu_Neww.NewRow();
                //if (dt3.Rows[i]["NgayChungTu"].ToString() != "")
                //{
                //    DateTime ngay = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                //    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");
                //}

                if (dt3.Rows[i]["Ton"].ToString() != "")
                    _ravi["Ton"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Ton"].ToString());
                //_ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
                //_ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                //_ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                ds.NXT_Mot_VatTu_Neww.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.NXT_Mot_VatTu_Neww;
            xtr111.DataMember = "NXT_Mot_VatTu_Neww";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_DaiLy_Frm_TonKho_MotVatTu(DataTable dt3)
        {

            Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy xtr111 = new Xtra_BaoCao_TonKho_Mot_VatTu_DaiLy();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.NXT_Mot_VatTu_Neww.Clone();
            ds.NXT_Mot_VatTu_Neww.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.NXT_Mot_VatTu_Neww.NewRow();
                //if (dt3.Rows[i]["NgayChungTu"].ToString() != "")
                //{
                //    DateTime ngay = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                //    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");
                //}
              
                if (dt3.Rows[i]["Ton"].ToString() != "")
                    _ravi["Ton"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Ton"].ToString());
                //_ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
                //_ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                //_ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                ds.NXT_Mot_VatTu_Neww.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.NXT_Mot_VatTu_Neww;
            xtr111.DataMember = "NXT_Mot_VatTu_Neww";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_DaiLy_frmChiTietNhapXuatTon_MotVatTu_Print_ALLL(DataTable dt3)
        {

            Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy xtr111 = new Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.NXT_Mot_VatTu_Neww.Clone();
            ds.NXT_Mot_VatTu_Neww.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.NXT_Mot_VatTu_Neww.NewRow();
                if (dt3.Rows[i]["NgayChungTu"].ToString() != "")                {
                    DateTime ngay= Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                    _ravi["NgayThang"] = ngay.ToString("dd/MM/yyyy");                }
                if (dt3.Rows[i]["Nhap"].ToString() != "")
                    _ravi["Nhap"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Nhap"].ToString());
                if (dt3.Rows[i]["Xuat"].ToString() != "")
                    _ravi["Xuat"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Xuat"].ToString());
                if (dt3.Rows[i]["Ton"].ToString() != "")
                    _ravi["Ton"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Ton"].ToString());
                _ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
                _ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                ds.NXT_Mot_VatTu_Neww.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.NXT_Mot_VatTu_Neww;
            xtr111.DataMember = "NXT_Mot_VatTu_Neww";           
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_DaiLy_frmChiTietNhapXuatTon_MotVatTu_Print_One(DataTable dt3)
        {

            Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy xtr111 = new Xtra_BaoCao_N_X_T_ChiTiet_Mot_VatTu_DaiLy();

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
                    _ravi["Nhap"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Nhap"].ToString());
                if (dt3.Rows[i]["Xuat"].ToString() != "")
                    _ravi["Xuat"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Xuat"].ToString());
                if (dt3.Rows[i]["Ton"].ToString() != "")
                    _ravi["Ton"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["Ton"].ToString());
                _ravi["SoChungTu_NhapKho"] = dt3.Rows[i]["SoChungTu_NhapKho"].ToString();
                _ravi["SoChungTu_XuatKho"] = dt3.Rows[i]["SoChungTu_XuatKho"].ToString();
                //_ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                _ravi["TenDaiLy"] = DaiLy_frmChiTietNhapXuatTon_MotVatTu.msTenDaiLy;
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                ds.NXT_Mot_VatTu_Neww.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.NXT_Mot_VatTu_Neww;
            xtr111.DataMember = "NXT_Mot_VatTu_Neww";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww()
        {
            InitializeComponent();
        }

        private void frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww_Load(object sender, EventArgs e)
        {
            if (DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_ALL == true)
                Print_DaiLy_frmChiTietNhapXuatTon_MotVatTu_Print_ALLL(DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdtPrint);
            if (DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_one == true)
                Print_DaiLy_frmChiTietNhapXuatTon_MotVatTu_Print_One(DaiLy_frmChiTietNhapXuatTon_MotVatTu.mdtPrint);
            if (DaiLy_Frm_TonKho_MotVatTu.mbPrint == true)
                Print_DaiLy_Frm_TonKho_MotVatTu(DaiLy_Frm_TonKho_MotVatTu.mdtPrint);
            if (DaiLy_BaoCao_TonKho.mbPrint_One == true)
                Print_DaiLy_BaoCao_TonKho_One(DaiLy_BaoCao_TonKho.mdtPrint_One);
        }

        private void frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww_FormClosed(object sender, FormClosedEventArgs e)
        {
            DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_ALL = false;
            DaiLy_frmChiTietNhapXuatTon_MotVatTu.mbPrint_one = false;
            DaiLy_Frm_TonKho_MotVatTu.mbPrint = false;
            DaiLy_BaoCao_TonKho.mbPrint_One = false;
        }
    }
}
