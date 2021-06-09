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
    public partial class frmPrintMuaHang : Form
    {
        public frmPrintMuaHang()
        {
            InitializeComponent();
        }
       private void PrintMuaHang(DataTable dt3)
        {
            XtraMuaHang xtr111 = new XtraMuaHang();
            DataTable mdt_ChiTietNhapKho = new DataTable();
            mdt_ChiTietNhapKho.Columns.Add("STT");
            mdt_ChiTietNhapKho.Columns.Add("SoLuong", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("DonGia", typeof(double));
            mdt_ChiTietNhapKho.Columns.Add("MaVT");// tb VTHH
            mdt_ChiTietNhapKho.Columns.Add("TenVTHH");
            mdt_ChiTietNhapKho.Columns.Add("DonViTinh");
            mdt_ChiTietNhapKho.Columns.Add("ThanhTien", typeof(double));
            
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietMuaHang.Clone();
            ds.tbChiTietMuaHang.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbChiTietMuaHang.NewRow();
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
                ds.tbChiTietMuaHang.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietMuaHang;
            xtr111.DataMember = "tbChiTietMuaHang";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;

        }
        private void frmPrintMuaHang_Load(object sender, EventArgs e)
        {
            if (frmChiTietMuaHang3333333333.mbPrint == true)
                PrintMuaHang(frmChiTietMuaHang3333333333.mdtPrint);
        }

        private void frmPrintMuaHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChiTietMuaHang3333333333.mbPrint = false;
        }
    }
}
