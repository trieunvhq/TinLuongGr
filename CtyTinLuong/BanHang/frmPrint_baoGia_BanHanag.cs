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
    public partial class frmPrint_baoGia_BanHanag : Form
    {
        //Xtra_SoTongHop_banHang_TheoKhachHang
        private void Print_BaoGia(DataTable dt3)
        {
            try
            {
                Xtra_baoGia_BanHang xtr111 = new Xtra_baoGia_BanHang();

                DataSet_TinLuong ds = new DataSet_TinLuong();
                ds.tbNhapKho_XuatKho.Clone();
                ds.tbNhapKho_XuatKho.Clear();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    int ID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                    clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                    cls.iID_VTHH = ID_VTHH;
                    DataTable dt = cls.SelectOne();

                    DataRow _ravi = ds.tbNhapKho_XuatKho.NewRow();
                    _ravi["STT"] = (i + 1).ToString();
                    _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                    _ravi["MaVT"] = cls.sMaVT.Value;
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                    ds.tbNhapKho_XuatKho.Rows.Add(_ravi);
                }

                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbNhapKho_XuatKho;
                xtr111.DataMember = "tbNhapKho_XuatKho";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print_BanHang_frmBangKeHoaDonBanHang(DataTable dt3)
        {
            try
            {
                Xtra_banKeHoaDonBanHang xtr111 = new Xtra_banKeHoaDonBanHang();

                DataSet_TinLuong ds = new DataSet_TinLuong();
                ds.tbBan_MuaHang.Clone();
                ds.tbBan_MuaHang.Clear();

                for (int i = 0; i < dt3.Rows.Count; i++)
                {


                    DataRow _ravi = ds.tbBan_MuaHang.NewRow();
                    _ravi["STT"] = (i + 1).ToString();
                    _ravi["SoLuong"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoLuong"].ToString());
                    _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                    _ravi["ThanhTien"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["ThanhTien"].ToString());
                    _ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["TienVAT"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TienVAT"].ToString());
                    _ravi["NgayChungTu"] = dt3.Rows[i]["NgayChungTu"].ToString();
                    _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                    _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                    _ravi["TongTien_CoVAT"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongTien_CoVAT"].ToString());
                    _ravi["TongTien_ChuaVAT"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongTien_ChuaVAT"].ToString());
                    _ravi["QuyDoiVND"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["QuyDoiVND"].ToString());
                    ds.tbBan_MuaHang.Rows.Add(_ravi);
                }
                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbBan_MuaHang;
                xtr111.DataMember = "tbBan_MuaHang";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print_BanHang_SoTongHopbanHang_TheoKhachHang(DataTable dt3)
        {
            try
            {
                Xtra_SoTongHop_banHang_TheoKhachHang xtr111 = new Xtra_SoTongHop_banHang_TheoKhachHang();

                DataSet_TinLuong ds = new DataSet_TinLuong();
                ds.tbBan_MuaHang.Clone();
                ds.tbBan_MuaHang.Clear();

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = ds.tbBan_MuaHang.NewRow();
                    _ravi["STT"] = dt3.Rows[i]["STT"].ToString();
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();
                    _ravi["MaKH"] = dt3.Rows[i]["MaKH"].ToString();
                    _ravi["SoLuong"] = dt3.Rows[i]["SoLuong"].ToString();
                    _ravi["TongTienUSD"] = dt3.Rows[i]["TongTienUSD"].ToString();
                    ds.tbBan_MuaHang.Rows.Add(_ravi);
                }
                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbBan_MuaHang;
                xtr111.DataMember = "tbBan_MuaHang";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print_BanHang_SoTongHopbanHang_ALL(DataTable dt3)
        {
            try
            {
                Xtra_SoTongHop_banHang xtr111 = new Xtra_SoTongHop_banHang();

                DataSet_TinLuong ds = new DataSet_TinLuong();
                ds.tbBan_MuaHang.Clone();
                ds.tbBan_MuaHang.Clear();

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = ds.tbBan_MuaHang.NewRow();

                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();
                    _ravi["SoLuong"] = dt3.Rows[i]["SoLuong"].ToString();
                    _ravi["DonGia"] = dt3.Rows[i]["DonGia"].ToString();
                    _ravi["ThanhTien"] = dt3.Rows[i]["ThanhTien"].ToString();
                    _ravi["TiGia"] = dt3.Rows[i]["TiGia"].ToString();
                    _ravi["TongTienUSD"] = dt3.Rows[i]["TongTienUSD"].ToString();
                    _ravi["TongTienVND"] = dt3.Rows[i]["TongTienVND"].ToString();
                    _ravi["QuyDoiVND"] = dt3.Rows[i]["QuyDoiVND"].ToString();
                    _ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                    _ravi["NgayChungTu"] = dt3.Rows[i]["NgayChungTu"].ToString();

                    ds.tbBan_MuaHang.Rows.Add(_ravi);
                }
                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbBan_MuaHang;
                xtr111.DataMember = "tbBan_MuaHang";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Print_BanHang_SoTongHopbanHang_RutGon(DataTable dt3)
        {
            try
            {
                Xtra_SoTongHop_banHang_RutGon xtr111 = new Xtra_SoTongHop_banHang_RutGon();

                DataSet_TinLuong ds = new DataSet_TinLuong();
                ds.tbBan_MuaHang.Clone();
                ds.tbBan_MuaHang.Clear();

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DataRow _ravi = ds.tbBan_MuaHang.NewRow();
                    _ravi["STT"] = (i + 1).ToString();
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    //_ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();
                    _ravi["SoLuong"] = dt3.Rows[i]["SoLuong_Tong"].ToString();
                    //_ravi["DonGia"] = dt3.Rows[i]["DonGia"].ToString();
                    //_ravi["ThanhTien"] = dt3.Rows[i]["ThanhTien"].ToString();
                    //_ravi["TiGia"] = dt3.Rows[i]["TiGia"].ToString();
                    //_ravi["TongTienUSD"] = dt3.Rows[i]["TongTienUSD"].ToString();
                    //_ravi["TongTienVND"] = dt3.Rows[i]["TongTienVND"].ToString();
                    //_ravi["QuyDoiVND"] = dt3.Rows[i]["QuyDoiVND"].ToString();
                    //_ravi["SoChungTu"] = dt3.Rows[i]["SoChungTu"].ToString();
                    //_ravi["NgayChungTu"] = dt3.Rows[i]["NgayChungTu"].ToString();

                    ds.tbBan_MuaHang.Rows.Add(_ravi);
                }
                xtr111.DataSource = null;
                xtr111.DataSource = ds.tbBan_MuaHang;
                xtr111.DataMember = "tbBan_MuaHang";
                xtr111.CreateDocument();
                documentViewer1.DocumentSource = xtr111;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public frmPrint_baoGia_BanHanag()
        {
            InitializeComponent();
        }

        private void frmPrint_baoGia_BanHanag_Load(object sender, EventArgs e)
        {
            try
            {
                if (frmCaiDatBangGia_BanHang.mbPrint == true)
                    Print_BaoGia(frmCaiDatBangGia_BanHang.mdtPrint);
                if (BanHang_frmBangKeHoaDonBanHang.mbPrint == true)
                    Print_BanHang_frmBangKeHoaDonBanHang(BanHang_frmBangKeHoaDonBanHang.mdtPrint);
                if (BanHang_SoTongHopbanHang.mbPrint_ALL == true)
                    Print_BanHang_SoTongHopbanHang_ALL(BanHang_SoTongHopbanHang.mdtPrint);
                if (BanHang_SoTongHopbanHang.mbPrint_RutGon == true)
                    Print_BanHang_SoTongHopbanHang_RutGon(BanHang_SoTongHopbanHang.mdtPrint);
                if (BanHang_SoTongHopbanHang.mbPrint_KhachHang == true)
                    Print_BanHang_SoTongHopbanHang_TheoKhachHang(BanHang_SoTongHopbanHang.mdtPrint);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPrint_baoGia_BanHanag_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmCaiDatBangGia_BanHang.mbPrint = false;
                BanHang_frmBangKeHoaDonBanHang.mbPrint = false;
                BanHang_SoTongHopbanHang.mbPrint_ALL = false;
                BanHang_SoTongHopbanHang.mbPrint_RutGon = false;
                BanHang_SoTongHopbanHang.mbPrint_KhachHang = false;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
