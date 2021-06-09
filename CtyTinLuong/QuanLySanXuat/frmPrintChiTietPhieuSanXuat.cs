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
    public partial class frmPrintChiTietPhieuSanXuat : Form
    {
        public frmPrintChiTietPhieuSanXuat()
        {
            InitializeComponent();
        }

        private void frmPrintChiTietPhieuSanXuat_Load(object sender, EventArgs e)
        {

            Xtra_ChiTiet_Phieu_I_C_D xtr111 = new Xtra_ChiTiet_Phieu_I_C_D();
            DataTable dt3 = new DataTable();
            dt3 = SanXuat_frmChiTietSoPhieu_RutGon.mdtPrint_tbChiTietPhieu;

            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();          
          
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                double SoLuong_Vao_IN, SoLuong_Ra_IN, PhePham_IN;
              
                if (dt3.Rows[i]["SoLuong_Vao_IN"].ToString() == "")
                    SoLuong_Vao_IN = 0;
                else SoLuong_Vao_IN = Convert.ToDouble(dt3.Rows[i]["SoLuong_Vao_IN"].ToString());

                if (dt3.Rows[i]["SoLuong_Ra_IN"].ToString() == "")
                    SoLuong_Ra_IN = 0;
                else SoLuong_Ra_IN = Convert.ToDouble(dt3.Rows[i]["SoLuong_Ra_IN"].ToString());

                if (dt3.Rows[i]["PhePham_IN"].ToString() == "")
                    PhePham_IN = 0;
                else PhePham_IN = Convert.ToDouble(dt3.Rows[i]["PhePham_IN"].ToString());

                double SoLuong_Vao_CAT, SoLuong_Ra_CAT, PhePham_CAT;

                if (dt3.Rows[i]["SoLuong_Vao_CAT"].ToString() == "")
                    SoLuong_Vao_CAT = 0;
                else SoLuong_Vao_CAT = Convert.ToDouble(dt3.Rows[i]["SoLuong_Vao_CAT"].ToString());

                if (dt3.Rows[i]["SoLuong_Ra_CAT"].ToString() == "")
                    SoLuong_Ra_CAT = 0;
                else SoLuong_Ra_CAT = Convert.ToDouble(dt3.Rows[i]["SoLuong_Ra_CAT"].ToString());

                if (dt3.Rows[i]["PhePham_CAT"].ToString() == "")
                    PhePham_CAT = 0;
                else PhePham_CAT = Convert.ToDouble(dt3.Rows[i]["PhePham_CAT"].ToString());


                double SoLuong_Vao_DOT, SoLuong_Ra_DOT, PhePham_DOT;

                if (dt3.Rows[i]["SoLuong_Vao_DOT"].ToString() == "")
                    SoLuong_Vao_DOT = 0;
                else SoLuong_Vao_DOT = Convert.ToDouble(dt3.Rows[i]["SoLuong_Vao_DOT"].ToString());

                if (dt3.Rows[i]["SoLuong_Ra_DOT"].ToString() == "")
                    SoLuong_Ra_DOT = 0;
                else SoLuong_Ra_DOT = Convert.ToDouble(dt3.Rows[i]["SoLuong_Ra_DOT"].ToString());

                if (dt3.Rows[i]["PhePham_DOT"].ToString() == "")
                    PhePham_DOT = 0;
                else PhePham_DOT = Convert.ToDouble(dt3.Rows[i]["PhePham_DOT"].ToString());


                DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();

                _ravi["STT"] = (i + 1).ToString();
                _ravi["MaPhieu"] = dt3.Rows[i]["MaPhieu"].ToString();

                _ravi["MaVT_Vao_IN"] = dt3.Rows[i]["MaVT_Vao_IN"].ToString();
                _ravi["MaVT_Ra_IN"] = dt3.Rows[i]["MaVT_Ra_IN"].ToString();
                _ravi["DonViTinh_Vao_IN"] = dt3.Rows[i]["DonViTinh_Vao_IN"].ToString();
                _ravi["DonViTinh_Ra_IN"] = dt3.Rows[i]["DonViTinh_Ra_IN"].ToString();
                _ravi["TenVatTu_Vao_IN"] = dt3.Rows[i]["TenVatTu_Vao_IN"].ToString();
                _ravi["TenVatTu_Ra_IN"] = dt3.Rows[i]["TenVatTu_Ra_IN"].ToString();
                _ravi["SoLuong_Vao_IN"] = SoLuong_Vao_IN;
                _ravi["SoLuong_Ra_IN"] = SoLuong_Ra_IN;
                _ravi["PhePham_IN"] = PhePham_IN;
                _ravi["NgaySanXuat_IN"] = dt3.Rows[i]["NgaySanXuat_IN"].ToString();
                _ravi["CaSanXuat_IN"] = dt3.Rows[i]["CaSanXuat_IN"].ToString();
                _ravi["CongNhan_IN"] = dt3.Rows[i]["CongNhan_IN"].ToString();
                _ravi["MaMay_IN"] = dt3.Rows[i]["MaMay_IN"].ToString();

                _ravi["MaVT_Vao_CAT"] = dt3.Rows[i]["MaVT_Vao_CAT"].ToString();
                _ravi["MaVT_Ra_CAT"] = dt3.Rows[i]["MaVT_Ra_CAT"].ToString();
                _ravi["DonViTinh_Vao_CAT"] = dt3.Rows[i]["DonViTinh_Vao_CAT"].ToString();
                _ravi["DonViTinh_Ra_CAT"] = dt3.Rows[i]["DonViTinh_Ra_CAT"].ToString();
                _ravi["TenVatTu_Vao_CAT"] = dt3.Rows[i]["TenVatTu_Vao_CAT"].ToString();
                _ravi["TenVatTu_Ra_CAT"] = dt3.Rows[i]["TenVatTu_Ra_CAT"].ToString();
                _ravi["SoLuong_Vao_CAT"] = SoLuong_Vao_CAT;
                _ravi["SoLuong_Ra_CAT"] = SoLuong_Ra_CAT;
                _ravi["PhePham_CAT"] = PhePham_CAT;
                _ravi["NgaySanXuat_CAT"] = dt3.Rows[i]["NgaySanXuat_CAT"].ToString();
                _ravi["CaSanXuat_CAT"] = dt3.Rows[i]["CaSanXuat_CAT"].ToString();
                _ravi["CongNhan_CAT"] = dt3.Rows[i]["CongNhan_CAT"].ToString();
                _ravi["MaMay_CAT"] = dt3.Rows[i]["MaMay_CAT"].ToString();

                _ravi["MaVT_Vao_DOT"] = dt3.Rows[i]["MaVT_Vao_DOT"].ToString();
                _ravi["MaVT_Ra_DOT"] = dt3.Rows[i]["MaVT_Ra_DOT"].ToString();
                _ravi["DonViTinh_Vao_DOT"] = dt3.Rows[i]["DonViTinh_Vao_DOT"].ToString();
                _ravi["DonViTinh_Ra_DOT"] = dt3.Rows[i]["DonViTinh_Ra_DOT"].ToString();
                _ravi["TenVatTu_Vao_DOT"] = dt3.Rows[i]["TenVatTu_Vao_DOT"].ToString();
                _ravi["TenVatTu_Ra_DOT"] = dt3.Rows[i]["TenVatTu_Ra_DOT"].ToString();
                _ravi["SoLuong_Vao_DOT"] = SoLuong_Vao_DOT;
                _ravi["SoLuong_Ra_DOT"] = SoLuong_Ra_DOT;
                _ravi["PhePham_DOT"] = PhePham_DOT;
                _ravi["NgaySanXuat_DOT"] = dt3.Rows[i]["NgaySanXuat_DOT"].ToString();
                _ravi["CaSanXuat_DOT"] = dt3.Rows[i]["CaSanXuat_DOT"].ToString();
                _ravi["CongNhan_DOT"] = dt3.Rows[i]["CongNhan_DOT"].ToString();
                _ravi["MaMay_DOT"] = dt3.Rows[i]["MaMay_DOT"].ToString();

                ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            // xtr111.IntData(sgiamdoc);
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
    }
}
