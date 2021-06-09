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
    public partial class frmPrint_BanHang : Form
    {
        private void XuatKho_ThanhPham_BanHang(DataTable dt3)
        {


            Xtra_BanHang xtr111 = new Xtra_BanHang();

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
        public frmPrint_BanHang()
        {
            InitializeComponent();
        }

        private void frmPrint_BanHang_Load(object sender, EventArgs e)
        {
            if (BanHang_FrmChiTietBanHang_Newwwwwwww.mbPrint_HoaDon == true)
                XuatKho_ThanhPham_BanHang(BanHang_FrmChiTietBanHang_Newwwwwwww.mdtPrint);
            if (KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mbPrint_HoaDon == true)
                XuatKho_ThanhPham_BanHang(KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mdtPrint);
        }

        private void frmPrint_BanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            BanHang_FrmChiTietBanHang_Newwwwwwww.mbPrint_HoaDon = false;
            KhoThanhPham_ChiTietBanHang_Moiiiiiiiiiiiiiiiiii.mbPrint_HoaDon = false;
        }
    }
}
