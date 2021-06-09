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
    public partial class frmPrint_SanLuongToMayIn : Form
    {
        private void Print_SanLuong_To_DOT_DAP_RutGon(DataTable dt3, DateTime xxtungay, DateTime xxdenngay)
        {
            Xtra_SanLuong_DOT_DAP_RutGon xtr111 = new Xtra_SanLuong_DOT_DAP_RutGon();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH_Ra"].ToString());

                double TongSoThanh = Convert.ToDouble(dt3.Rows[i]["TongSoThanh"].ToString()); // so thanh
                double TongSoBao_Sot = Convert.ToDouble(dt3.Rows[i]["TongSoBao_Sot"].ToString()); // số bao
                double TongSoKg = Convert.ToDouble(dt3.Rows[i]["TongSoKg"].ToString()); // tong so kg
              //  double DoCao_Dot = Convert.ToDouble(dt3.Rows[i]["DoCao_Dot"].ToString());// độ cao


                DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();
                _ravi["MaVT_Ra_IN"] = dt3.Rows[i]["MaVT_Ra"].ToString();
                _ravi["DonViTinh_Ra_IN"] = dt3.Rows[i]["DonViTinh_Ra"].ToString();
                _ravi["TenVatTu_Ra_IN"] = dt3.Rows[i]["TenVatTu_Ra"].ToString();
                _ravi["STT"] = (i + 1).ToString();

                _ravi["SanLuong_Thuong_IN"] = TongSoThanh;
                _ravi["SanLuong_TangCa_IN"] = TongSoBao_Sot;
                _ravi["SoLuong_Ra_IN"] = TongSoKg;
             //   _ravi["PhePham_IN"] = DoCao_Dot;


                ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);

            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_SanLuong_To_DOT_DAP_ALL(DataTable dt3, DateTime xxtungay, DateTime xxdenngay)
        {
            Xtra_SanLuong_DOT_DAP xtr111 = new Xtra_SanLuong_DOT_DAP();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH_Ra"].ToString());               
                string xxmavt, xxtenvt, xxdvt;
                xxmavt = dt3.Rows[i]["MaVT_Ra"].ToString();
                xxtenvt = dt3.Rows[i]["TenVatTu_Ra"].ToString();
                xxdvt = dt3.Rows[i]["DonViTinh_Ra"].ToString();
                double TongSoThanh = Convert.ToDouble(dt3.Rows[i]["TongSoThanh"].ToString());
                double TongSoBao_Sot = Convert.ToDouble(dt3.Rows[i]["TongSoBao_Sot"].ToString());
                double TongSoKg = Convert.ToDouble(dt3.Rows[i]["TongSoKg"].ToString());

                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                DataTable dtchitiet = new DataTable();

                dtchitiet = cls.SelectAll_W_ID_VTHH_Ra_TenCN_NgayThang_DOT(ID_VTHHxx, xxtungay, xxdenngay);

                for (int k = 0; k < dtchitiet.Rows.Count; k++)
                {
                    DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();
                    
                    _ravi["TenVatTu_Ra_IN"] = xxtenvt;
                    _ravi["STT"] = (k + 1).ToString();
                    _ravi["SoLuong_Vao_CAT"] = TongSoThanh;
                    _ravi["SoLuong_Ra_CAT"] = TongSoBao_Sot;
                    _ravi["PhePham_CAT"] = TongSoKg;                   
                    DateTime ngaysanxuat = Convert.ToDateTime(dtchitiet.Rows[k]["NgaySanXuat"].ToString());
                    _ravi["MaPhieu"] = dtchitiet.Rows[k]["MaPhieu"].ToString();
                    _ravi["SoLuong_Vao_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["SoLuong_Vao"].ToString());
                    
                    _ravi["SanLuong_TangCa_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["SoKG_MotBao_May_Dot"].ToString());
                    _ravi["DoCao_DOT"] = Convert.ToDouble(dtchitiet.Rows[k]["DoCao_Dot"].ToString());
                    _ravi["TongSoKG_DOT"] = Convert.ToDouble(dtchitiet.Rows[k]["QuyRaKG"].ToString());
                    _ravi["NgaySanXuat_IN"] = ngaysanxuat.ToString("dd/MM/yyyy");
                    _ravi["CaSanXuat_IN"] = dtchitiet.Rows[k]["CaSanXuat"].ToString();
                    //_ravi["CongNhan_IN"] = dtchitiet.Rows[k]["TenNhanVien"].ToString();
                    //_ravi["MaMay_IN"] = dtchitiet.Rows[k]["MaMay"].ToString();
                    ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);
                }

            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_SanLuong_ToMay_ChiTiet(DataTable dt3, DateTime xxtungay, DateTime xxdenngay)
        {
            Xtra_SanLuongToMay_IN xtr111 = new Xtra_SanLuongToMay_IN();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();


            int ID_VTHHxx = SanLuong_ToMay_ChiTiet.miID_VThh;
            string xxmavt, xxtenvt, xxdvt;
            xxmavt = SanLuong_ToMay_ChiTiet.msMaVT;
            xxtenvt = SanLuong_ToMay_ChiTiet.msTenVT;
            xxdvt = SanLuong_ToMay_ChiTiet.msDVT;
            double sanluongthuowng = SanLuong_ToMay_ChiTiet.sanluongthuowng;
            double sanluongtangca = SanLuong_ToMay_ChiTiet.sanluongtangca;
            double sanluongtong = SanLuong_ToMay_ChiTiet.sanluongtong;
            double phepham = SanLuong_ToMay_ChiTiet.phepham;

            for (int k = 0; k < dt3.Rows.Count; k++)
            {
                DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();
                _ravi["MaVT_Ra_IN"] = xxmavt;
                _ravi["DonViTinh_Ra_IN"] = xxdvt;
                _ravi["TenVatTu_Ra_IN"] = xxtenvt;
                _ravi["STT"] = (k + 1).ToString();
                _ravi["SanLuong_Thuong_CAT"] = sanluongthuowng;
                _ravi["SanLuong_TangCa_CAT"] = sanluongtangca;
                _ravi["SoLuong_Ra_CAT"] = sanluongtong;
                _ravi["PhePham_CAT"] = phepham;
                DateTime ngaysanxuat = Convert.ToDateTime(dt3.Rows[k]["NgaySanXuat"].ToString());
                _ravi["MaPhieu"] = dt3.Rows[k]["MaPhieu"].ToString();
                _ravi["SanLuong_Thuong_IN"] = Convert.ToDouble(dt3.Rows[k]["SanLuong_Thuong"].ToString());
                _ravi["SanLuong_TangCa_IN"] = Convert.ToDouble(dt3.Rows[k]["SanLuong_TangCa"].ToString());
                _ravi["SoLuong_Ra_IN"] = Convert.ToDouble(dt3.Rows[k]["SanLuong_Tong"].ToString());
                _ravi["PhePham_IN"] = Convert.ToDouble(dt3.Rows[k]["PhePham"].ToString());
                _ravi["NgaySanXuat_IN"] = ngaysanxuat.ToString("dd/MM/yyyy");
                _ravi["CaSanXuat_IN"] = dt3.Rows[k]["CaSanXuat"].ToString();
                _ravi["CongNhan_IN"] = dt3.Rows[k]["TenNhanVien"].ToString();
                _ravi["MaMay_IN"] = dt3.Rows[k]["MaMay"].ToString();
                ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);

            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Print_SanLuong_To_May_IN_ALL(DataTable dt3, DateTime xxtungay, DateTime xxdenngay)
        {
            Xtra_SanLuongToMay_IN xtr111 = new Xtra_SanLuongToMay_IN();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH_Ra"].ToString());
                //clsTbVatTuHangHoa clsxx = new clsTbVatTuHangHoa();
                //clsxx.iID_VTHH = ID_VTHHxx;
                //DataTable dtxx = clsxx.SelectOne();
                string xxmavt, xxtenvt, xxdvt;
                xxmavt = dt3.Rows[i]["MaVT_Ra"].ToString();
                xxtenvt = dt3.Rows[i]["TenVatTu_Ra"].ToString();
                xxdvt = dt3.Rows[i]["DonViTinh_Ra"].ToString();
                double sanluongthuowng = Convert.ToDouble(dt3.Rows[i]["SanLuong_Thuong"].ToString());
                double sanluongtangca = Convert.ToDouble(dt3.Rows[i]["SanLuong_TangCa"].ToString());
                double sanluongtong = Convert.ToDouble(dt3.Rows[i]["SanLuong_Tong"].ToString());
                double phepham = Convert.ToDouble(dt3.Rows[i]["PhePham"].ToString());
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                DataTable dtchitiet = new DataTable();
                if(SanLuong_To_May_IN.xxximay_in_1_Cat_2_dot_3==1)
                dtchitiet = cls.SelectAll_W_ID_VTHH_Ra_TenCN_NgayThang_IN(ID_VTHHxx, xxtungay, xxdenngay);
               else if (SanLuong_To_May_IN.xxximay_in_1_Cat_2_dot_3 == 2)
                    dtchitiet = cls.SelectAll_W_ID_VTHH_Ra_TenCN_NgayThang_CAT(ID_VTHHxx, xxtungay, xxdenngay);

                for (int k = 0; k < dtchitiet.Rows.Count; k++)
                {
                    DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();
                    _ravi["MaVT_Ra_IN"] = xxmavt;
                    _ravi["DonViTinh_Ra_IN"] = xxdvt;
                    _ravi["TenVatTu_Ra_IN"] = xxtenvt;
                    _ravi["STT"] = (k + 1).ToString();
                    _ravi["SanLuong_Thuong_CAT"] = sanluongthuowng;
                    _ravi["SanLuong_TangCa_CAT"] = sanluongtangca;
                    _ravi["SoLuong_Ra_CAT"] = sanluongtong;
                    _ravi["PhePham_CAT"] = phepham;
                    DateTime ngaysanxuat = Convert.ToDateTime(dtchitiet.Rows[k]["NgaySanXuat"].ToString());
                    _ravi["MaPhieu"] = dtchitiet.Rows[k]["MaPhieu"].ToString();
                    _ravi["SanLuong_Thuong_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["SanLuong_Thuong"].ToString());
                    _ravi["SanLuong_TangCa_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["SanLuong_TangCa"].ToString());
                    _ravi["SoLuong_Ra_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["SanLuong_Tong"].ToString());
                    _ravi["PhePham_IN"] = Convert.ToDouble(dtchitiet.Rows[k]["PhePham"].ToString());
                    _ravi["NgaySanXuat_IN"] = ngaysanxuat.ToString("dd/MM/yyyy");
                    _ravi["CaSanXuat_IN"] = dtchitiet.Rows[k]["CaSanXuat"].ToString();
                    _ravi["CongNhan_IN"] = dtchitiet.Rows[k]["TenNhanVien"].ToString();
                    _ravi["MaMay_IN"] = dtchitiet.Rows[k]["MaMay"].ToString();
                    ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);
                }

            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        private void Print_SanLuong_To_May_IN_RutGon(DataTable dt3, DateTime xxtungay, DateTime xxdenngay)
        {
            Xtra_SanLuongToMay_IN_RutGon xtr111 = new Xtra_SanLuongToMay_IN_RutGon();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbChiTietPhieuSanXuat.Clone();
            ds.tbChiTietPhieuSanXuat.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                int ID_VTHHxx = Convert.ToInt32(dt3.Rows[i]["ID_VTHH_Ra"].ToString());
               
                double sanluongthuowng = Convert.ToDouble(dt3.Rows[i]["SanLuong_Thuong"].ToString());
                double sanluongtangca = Convert.ToDouble(dt3.Rows[i]["SanLuong_TangCa"].ToString());
                double sanluongtong = Convert.ToDouble(dt3.Rows[i]["SanLuong_Tong"].ToString());
                double phepham = Convert.ToDouble(dt3.Rows[i]["PhePham"].ToString());
               

                DataRow _ravi = ds.tbChiTietPhieuSanXuat.NewRow();
                _ravi["MaVT_Ra_IN"] = dt3.Rows[i]["MaVT_Ra"].ToString();
                _ravi["DonViTinh_Ra_IN"] = dt3.Rows[i]["DonViTinh_Ra"].ToString();
                _ravi["TenVatTu_Ra_IN"] = dt3.Rows[i]["TenVatTu_Ra"].ToString();
                _ravi["STT"] = (i + 1).ToString();             
               
                _ravi["SanLuong_Thuong_IN"] = sanluongthuowng;
                _ravi["SanLuong_TangCa_IN"] = sanluongtangca;
                _ravi["SoLuong_Ra_IN"] = sanluongtong;
                _ravi["PhePham_IN"] = phepham;


                ds.tbChiTietPhieuSanXuat.Rows.Add(_ravi);

            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTietPhieuSanXuat;
            xtr111.DataMember = "tbChiTietPhieuSanXuat";
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_SanLuongToMayIn()
        {
            InitializeComponent();
        }

        private void frmPrint_SanLuongToMayIn_Load(object sender, EventArgs e)
        {
            if (SanLuong_To_May_IN.mbPrint_ALL == true)
                Print_SanLuong_To_May_IN_ALL(SanLuong_To_May_IN.mdtPrint, SanLuong_To_May_IN.mdatungay, SanLuong_To_May_IN.mdadenngay);
            if (SanLuong_To_May_IN.mbPrint_RutGon == true)
                Print_SanLuong_To_May_IN_RutGon(SanLuong_To_May_IN.mdtPrint, SanLuong_To_May_IN.mdatungay, SanLuong_To_May_IN.mdadenngay);
            if (SanLuong_ToMay_ChiTiet.mbPrint == true)
                Print_SanLuong_ToMay_ChiTiet(SanLuong_ToMay_ChiTiet.mdtPrint, SanLuong_ToMay_ChiTiet.mdatungay, SanLuong_ToMay_ChiTiet.mdadenngay);
            if (SanLuong_To_DOT_DAP.mbPrint_ALL == true)
                Print_SanLuong_To_DOT_DAP_ALL(SanLuong_To_DOT_DAP.mdtPrint, SanLuong_To_DOT_DAP.mdatungay, SanLuong_To_DOT_DAP.mdadenngay);
            //Print_SanLuong_To_DOT_DAP_RutGon
            if (SanLuong_To_DOT_DAP.mbPrint_RutGon == true)
                Print_SanLuong_To_DOT_DAP_RutGon(SanLuong_To_DOT_DAP.mdtPrint, SanLuong_To_DOT_DAP.mdatungay, SanLuong_To_DOT_DAP.mdadenngay);
        }

        private void frmPrint_SanLuongToMayIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            SanLuong_To_May_IN.mbPrint_ALL = false;
            SanLuong_To_May_IN.mbPrint_RutGon = false;
            SanLuong_ToMay_ChiTiet.mbPrint = false;
            SanLuong_To_DOT_DAP.mbPrint_ALL = false;
            SanLuong_To_DOT_DAP.mbPrint_RutGon = false;
        }
    }
}
