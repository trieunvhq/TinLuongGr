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
    public partial class frmPrint_BaoCao_TonKho : Form
    {
    
        private void TonKho_DaiLy_ALL(DataTable dt3)
        {
            Xtra_BaoCao_TonKho xtr111 = new Xtra_BaoCao_TonKho();
            DataTable dt2 = new DataTable();
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

                ds.tbNhap_Xuat_Ton.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbNhap_Xuat_Ton;
            xtr111.DataMember = "tbNhap_Xuat_Ton";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
       
        public frmPrint_BaoCao_TonKho()
        {
            InitializeComponent();
        }

        private void frmPrint_BaoCao_TonKho_Load(object sender, EventArgs e)
        {
            if (DaiLy_BaoCao_TonKho.mbPrint_ALL == true)
                TonKho_DaiLy_ALL(DaiLy_BaoCao_TonKho.mdtPrint_ALL);
          
        }

        private void frmPrint_BaoCao_TonKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            DaiLy_BaoCao_TonKho.mbPrint_ALL = false;
            DaiLy_BaoCao_TonKho.mbPrint_One = false;
            
        }
    }
}
