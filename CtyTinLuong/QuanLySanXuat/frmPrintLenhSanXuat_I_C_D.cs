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
    public partial class frmPrintLenhSanXuat_I_C_D : Form
    {
        public frmPrintLenhSanXuat_I_C_D()
        {
            InitializeComponent();
        }

        private void frmPrintLenhSanXuat_I_C_D_Load(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
           
            dt3 = SanXuat_frmChiTietLenhSanXuat.mdtLenhSanXuat;
            Xtra_LenhSanXuat_I_C_D xtr111 = new Xtra_LenhSanXuat_I_C_D();
            DataTable mdtLenhSanXuatxxx = new DataTable();
            mdtLenhSanXuatxxx.Columns.Add("STT");          
            mdtLenhSanXuatxxx.Columns.Add("MaPhieu", typeof(string));          
            mdtLenhSanXuatxxx.Columns.Add("MaVT_Vao", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("MaVT_Ra", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("DonViTinh_Vao", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("DonViTinh_Ra", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("TenVatTu_Vao", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("TenVatTu_Ra", typeof(string));
            mdtLenhSanXuatxxx.Columns.Add("SoLuong_Vao", typeof(float));
            mdtLenhSanXuatxxx.Columns.Add("SanLuong_Thuong", typeof(float));
            mdtLenhSanXuatxxx.Columns.Add("SanLuong_TangCa", typeof(float));
            mdtLenhSanXuatxxx.Columns.Add("PhePham", typeof(float));         
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLenhSanXuat_I_C_D.Clone();
            ds.tbLenhSanXuat_I_C_D.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbLenhSanXuat_I_C_D.NewRow();
                _ravi["STT"] = (i + 1).ToString();
                _ravi["MaPhieu"] = dt3.Rows[i]["MaPhieu"].ToString();
                _ravi["MaVT_Vao"] = dt3.Rows[i]["MaVT_Vao"].ToString();
                _ravi["MaVT_Ra"] = dt3.Rows[i]["MaVT_Ra"].ToString();
                _ravi["DonViTinh_Vao"] = dt3.Rows[i]["DonViTinh_Vao"].ToString();
                _ravi["DonViTinh_Ra"] = dt3.Rows[i]["DonViTinh_Ra"].ToString();
                _ravi["TenVatTu_Vao"] = dt3.Rows[i]["TenVatTu_Vao"].ToString();
                _ravi["TenVatTu_Ra"] = dt3.Rows[i]["TenVatTu_Ra"].ToString();

                _ravi["SoLuong_Vao"] = Convert.ToDouble(dt3.Rows[i]["SoLuong_Vao"].ToString());
                _ravi["SanLuong_Thuong"] = Convert.ToDouble(dt3.Rows[i]["SanLuong_Thuong"].ToString());
                _ravi["SanLuong_TangCa"] = Convert.ToDouble(dt3.Rows[i]["SanLuong_TangCa"].ToString());
                _ravi["PhePham"] = Convert.ToDouble(dt3.Rows[i]["PhePham"].ToString());     
                ds.tbLenhSanXuat_I_C_D.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLenhSanXuat_I_C_D;
            xtr111.DataMember = "tbLenhSanXuat_I_C_D";           
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;

        }
    }
}
