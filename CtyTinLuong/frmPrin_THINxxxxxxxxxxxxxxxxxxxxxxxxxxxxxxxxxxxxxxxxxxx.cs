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
    public partial class frmPrin_THINxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx : Form
    {
        public frmPrin_THINxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx()
        {
            InitializeComponent();
        }

        private void frmPrin_THINxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx_Load(object sender, EventArgs e)
        {
            XtraReport1 xtr111 = new XtraReport1();
           
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbNhapKho_XuatKho.Clone();
            ds.tbNhapKho_XuatKho.Clear();
            for (int i = 0; i < KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbNhapKho_XuatKho.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                int ID_VTHH = Convert.ToInt32(KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["ID_VTHH"].ToString());
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = ID_VTHH;
                DataTable dt = cls.SelectOne();
                _ravi["SoLuong"] = Convert.ToDouble(KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["SoLuongXuat"].ToString());
                _ravi["DonGia"] = Convert.ToDouble(KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["DonGia"].ToString());
                _ravi["MaVT"] = cls.sMaVT.Value;
                _ravi["TenVTHH"] = cls.sTenVTHH.Value;
                _ravi["DonViTinh"] = cls.sDonViTinh.Value;
                _ravi["ThanhTien"] = Convert.ToDouble(KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["SoLuongXuat"].ToString()) * Convert.ToDouble(KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["DonGia"].ToString());
                //_ravi["GhiChu"] = KhoBTP_ChiTietDaXuatKho.mdtPrint.Rows[i]["GhiChu"].ToString();
                ds.tbNhapKho_XuatKho.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhapKho_XuatKho;
            xtr111.DataMember = "tbNhapKho_XuatKho";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
