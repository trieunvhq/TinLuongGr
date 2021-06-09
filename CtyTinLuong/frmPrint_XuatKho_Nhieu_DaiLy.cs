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
    public partial class frmPrint_XuatKho_Nhieu_DaiLy : Form
    {
        private void XuatKhoNhieuDaiLy( DataTable dt3)
        {
          
            Xtra_XuatKho_DaiLy_NhieuKho xtr111 = new Xtra_XuatKho_DaiLy_NhieuKho();

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLuongDaiLy.Clone();
            ds.tbLuongDaiLy.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbLuongDaiLy.NewRow();

                _ravi["SoLuongXuat"] = Convert.ToDouble(dt3.Rows[i]["SoLuongThanhPhamQuyDoi"].ToString());
                _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                _ravi["DonGia"] = dt3.Rows[i]["DonGia"].ToString();
                _ravi["TongTienHang"] = dt3.Rows[i]["TongTienHang"].ToString();
                ds.tbLuongDaiLy.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLuongDaiLy;
            xtr111.DataMember = "tbLuongDaiLy";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_XuatKho_Nhieu_DaiLy()
        {
            InitializeComponent();
        }

        private void frmPrint_XuatKho_Nhieu_DaiLy_Load(object sender, EventArgs e)
        {
            if(UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbPrint==true)
            {
                XuatKhoNhieuDaiLy(UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mdtPrint);
            }
        }

        private void frmPrint_XuatKho_Nhieu_DaiLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            UCThanhPham_NhapKhoTuDaiLy_Newwwwwwwwwwwwwww.mbPrint = false;
        }
    }
}
