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
        private void Print_BaoGia(DataTable dt3)
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
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
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

        private void Print_BanHang_frmBangKeHoaDonBanHang(DataTable dt3)
        {


            Xtra_banKeHoaDonBanHang xtr111 = new Xtra_banKeHoaDonBanHang();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbBan_MuaHang.Clone();
            ds.tbBan_MuaHang.Clear();
            
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
              
              
                DataRow _ravi = ds.tbBan_MuaHang.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["ThanhTien"].ToString());
                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["TienVAT"] = Convert.ToDouble(dt3.Rows[i]["TienVAT"].ToString());
                _ravi["NgayChungTu"] =dt3.Rows[i]["NgayChungTu"].ToString();
                _ravi["SoChungTu"] =dt3.Rows[i]["SoChungTu"].ToString();
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                _ravi["TongTien_CoVAT"] = Convert.ToDouble(dt3.Rows[i]["TongTien_CoVAT"].ToString());
                _ravi["TongTien_ChuaVAT"] = Convert.ToDouble(dt3.Rows[i]["TongTien_ChuaVAT"].ToString());
                _ravi["QuyDoiVND"] = Convert.ToDouble(dt3.Rows[i]["QuyDoiVND"].ToString());
                ds.tbBan_MuaHang.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBan_MuaHang;
            xtr111.DataMember = "tbBan_MuaHang";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_baoGia_BanHanag()
        {
            InitializeComponent();
        }

        private void frmPrint_baoGia_BanHanag_Load(object sender, EventArgs e)
        {
            if (frmCaiDatBangGia_BanHang.mbPrint == true)
                Print_BaoGia(frmCaiDatBangGia_BanHang.mdtPrint);
            if (BanHang_frmBangKeHoaDonBanHang.mbPrint == true)
                Print_BanHang_frmBangKeHoaDonBanHang(BanHang_frmBangKeHoaDonBanHang.mdtPrint);
        }

        private void frmPrint_baoGia_BanHanag_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCaiDatBangGia_BanHang.mbPrint = false;
            BanHang_frmBangKeHoaDonBanHang.mbPrint = false;
        }
    }
}
