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
    public partial class frmPrint_nhapKho_DaiLy : Form
    {
        public frmPrint_nhapKho_DaiLy()
        {
            InitializeComponent();
        }
        private void XuatKho_NPL_RaDaiLy_ThemMoi()
        {
            DataTable dt3 = new DataTable();
            dt3 = NPLChiTietNhapKho_DaiLy_ThemMoi.mdt_ChiTietXuatKho;
            Xtra_NhapKho_DaiLy xtr111 = new Xtra_NhapKho_DaiLy();
            DataTable mdt_ChiTietNhapKho = new DataTable();
            mdt_ChiTietNhapKho.Columns.Add("STT");
            mdt_ChiTietNhapKho.Columns.Add("SoLuong", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("DonGia", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("MaVT");// tb VTHH
            mdt_ChiTietNhapKho.Columns.Add("TenVTHH");
            mdt_ChiTietNhapKho.Columns.Add("DonViTinh");
            mdt_ChiTietNhapKho.Columns.Add("ThanhTien", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("GhiChu", typeof(string));

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhapKho_XuatKho.Clone();
            ds.tbNhapKho_XuatKho.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhapKho_XuatKho.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                int ID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHH;
                DataTable dt = cls.SelectOne();
                _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["MaVT"] = cls.sMaVT.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString()) * Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                ds.tbNhapKho_XuatKho.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhapKho_XuatKho;
            xtr111.DataMember = "tbNhapKho_XuatKho";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        private void NhapKho_Tu_DaiLy_Ve_GiaCongXong( DataTable dt3)
        {
          
        
            Xtra_XuatKho_DaiLy xtr111 = new Xtra_XuatKho_DaiLy();           

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhapKho_XuatKho.Clone();
            ds.tbNhapKho_XuatKho.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhapKho_XuatKho.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                int ID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHH;
                DataTable dt = cls.SelectOne();
                _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuongNhap"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["MaVT"] = cls.sMaVT.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["SoLuongNhap"].ToString()) * Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
               // _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                ds.tbNhapKho_XuatKho.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhapKho_XuatKho;
            xtr111.DataMember = "tbNhapKho_XuatKho";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
  
        private void XuatKho_RaDaiLy_()
        {
            DataTable dt3 = new DataTable();
            dt3 = DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mdt_ChiTietXuatKho;
            Xtra_NhapKho_DaiLy xtr111 = new Xtra_NhapKho_DaiLy();
            DataTable mdt_ChiTietNhapKho = new DataTable();
            mdt_ChiTietNhapKho.Columns.Add("STT");
            mdt_ChiTietNhapKho.Columns.Add("SoLuong", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("DonGia", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("MaVT");// tb VTHH
            mdt_ChiTietNhapKho.Columns.Add("TenVTHH");
            mdt_ChiTietNhapKho.Columns.Add("DonViTinh");
            mdt_ChiTietNhapKho.Columns.Add("ThanhTien", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("GhiChu", typeof(string));

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhapKho_XuatKho.Clone();
            ds.tbNhapKho_XuatKho.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhapKho_XuatKho.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                int ID_VTHH = Convert.ToInt32(dt3.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHH;
                DataTable dt = cls.SelectOne();
                _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["MaVT"] = cls.sMaVT.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString()) * Convert.ToDouble(dt3.Rows[i]["DonGia"].ToString());
                _ravi["GhiChu"] = dt3.Rows[i]["GhiChu"].ToString();
                ds.tbNhapKho_XuatKho.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhapKho_XuatKho;
            xtr111.DataMember = "tbNhapKho_XuatKho";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void frmPrint_nhapKho_DaiLy_Load(object sender, EventArgs e)
        {
            if (NPLChiTietNhapKho_DaiLy_ThemMoi.mbPrint_Chitiet_XuatKho_DaiLyGiaCong == true)
                XuatKho_NPL_RaDaiLy_ThemMoi();
            if (DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mbPrint_Chitiet_XuatKho_DaiLyGiaCong == true)
                XuatKho_RaDaiLy_();
            if (KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint == true)
                NhapKho_Tu_DaiLy_Ve_GiaCongXong(KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mdtPrint);
            if (frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint == true)
                NhapKho_Tu_DaiLy_Ve_GiaCongXong(frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mdtPrint);
        }

        private void frmPrint_nhapKho_DaiLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            NPLChiTietNhapKho_DaiLy_ThemMoi.mbPrint_Chitiet_XuatKho_DaiLyGiaCong = false;
            DaiLy_FrmChiTietNhapKho_Newwwwwwwwwwwwwww.mbPrint_Chitiet_XuatKho_DaiLyGiaCong = false;
            KhoThanhPham_NhapKho_Tu_DaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint = false;
            frmChiTietXuatKhoDaiLy_MOIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII.mbPrint = false;
        }
    }
}
