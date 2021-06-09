using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class frmImPortPhieuSanXuat_banDau : Form
    {
        DataTable dtphieu;
        private void HienThi()
        {
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("MaPhieu", typeof(string));
            //ID_CaTruong
            dt2.Columns.Add("ID_CongNhan_IN", typeof(string));
            dt2.Columns.Add("ID_CaTruong_IN", typeof(string));
            dt2.Columns.Add("ID_May_IN", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao_IN", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra_IN", typeof(string));
            dt2.Columns.Add("ID_VTHH_Vao_IN", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra_IN", typeof(string));
            dt2.Columns.Add("MaVT_Vao_IN", typeof(string));
            dt2.Columns.Add("MaVT_Ra_IN", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao_IN", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra_IN", typeof(string));
            dt2.Columns.Add("SoLuong_Vao_IN", typeof(string));
            dt2.Columns.Add("SoLuong_Ra_IN", typeof(string));
            dt2.Columns.Add("PhePham_IN", typeof(string));
            dt2.Columns.Add("NgaySanXuat_IN", typeof(string));
            dt2.Columns.Add("CaSanXuat_IN", typeof(string));
            dt2.Columns.Add("CongNhan_IN", typeof(string));
            dt2.Columns.Add("MaMay_IN", typeof(string));
            string MaPhieu, ID_CongNhan_IN, DonViTinh_Vao_IN, DonViTinh_Ra_IN,ID_CaTruong_IN, ID_May_IN, ID_VTHH_Vao_IN, ID_VTHH_Ra_IN, MaVT_Vao_IN, MaVT_Ra_IN, TenVatTu_Vao_IN,
                TenVatTu_Ra_IN, SoLuong_Vao_IN, SoLuong_Ra_IN,
                PhePham_IN, NgaySanXuat_IN, CaSanXuat_IN, CongNhan_IN, MaMay_IN;



            dt2.Columns.Add("ID_CongNhan_CAT", typeof(string));
            dt2.Columns.Add("ID_CaTruong_CAT", typeof(string));
            dt2.Columns.Add("ID_May_CAT", typeof(string));
            
            dt2.Columns.Add("ID_VTHH_Vao_CAT", typeof(string));
            dt2.Columns.Add("ID_VTHH_Ra_CAT", typeof(string));
            dt2.Columns.Add("MaVT_Vao_CAT", typeof(string));
            dt2.Columns.Add("MaVT_Ra_CAT", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao_CAT", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra_CAT", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao_CAT", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra_CAT", typeof(string));
            dt2.Columns.Add("SoLuong_Vao_CAT", typeof(string));
            dt2.Columns.Add("SoLuong_Ra_CAT", typeof(string));
            dt2.Columns.Add("PhePham_CAT", typeof(string));
            dt2.Columns.Add("NgaySanXuat_CAT", typeof(string));
            dt2.Columns.Add("CaSanXuat_CAT", typeof(string));
            dt2.Columns.Add("CongNhan_CAT", typeof(string));
            dt2.Columns.Add("MaMay_CAT", typeof(string));
            string ID_CongNhan_CAT, DonViTinh_Vao_CAT, DonViTinh_Ra_CAT, ID_CaTruong_CAT, ID_May_CAT, ID_VTHH_Vao_CAT, ID_VTHH_Ra_CAT, MaVT_Vao_CAT, MaVT_Ra_CAT, TenVatTu_Vao_CAT,
           TenVatTu_Ra_CAT, SoLuong_Vao_CAT, SoLuong_Ra_CAT,
           PhePham_CAT, NgaySanXuat_CAT, CaSanXuat_CAT, CongNhan_CAT, MaMay_CAT;


         
            clsTbVatTuHangHoa clsVT = new clsTbVatTuHangHoa();       
            clsNhanSu_tbNhanSu clsnhansu = new clsNhanSu_tbNhanSu();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            clsPhieu_tbPhieu clsphieu = new clsPhieu_tbPhieu();
            clsT_MayMoc clsmaymoc = new clsT_MayMoc();

            for (int i = 4; i < dtphieu.Rows.Count; i++)
            {
                MaPhieu = ID_CongNhan_IN = ID_CaTruong_IN = ID_May_IN = ID_VTHH_Vao_IN = ID_VTHH_Ra_IN = MaVT_Vao_IN = MaVT_Ra_IN = TenVatTu_Vao_IN =
                TenVatTu_Ra_IN = SoLuong_Vao_IN = SoLuong_Ra_IN = DonViTinh_Vao_IN = DonViTinh_Ra_IN =
                PhePham_IN = NgaySanXuat_IN = CaSanXuat_IN = CongNhan_IN = MaMay_IN = "";

                ID_CongNhan_CAT = ID_CaTruong_CAT = ID_May_CAT = ID_VTHH_Vao_CAT = ID_VTHH_Ra_CAT = MaVT_Vao_CAT = MaVT_Ra_CAT = TenVatTu_Vao_CAT =
           TenVatTu_Ra_CAT = SoLuong_Vao_CAT = SoLuong_Ra_CAT = DonViTinh_Vao_CAT = DonViTinh_Ra_CAT =
           PhePham_CAT = NgaySanXuat_CAT = CaSanXuat_CAT = CongNhan_CAT = MaMay_CAT = "";

                DataRow _ravi = dt2.NewRow();
                MaPhieu = dtphieu.Rows[i][1].ToString();
                if (dtphieu.Rows[i][14].ToString() == "1")
                {
                    CaSanXuat_IN = "Ca 1";
                    ID_CaTruong_IN = "8";
                }
                else
                {
                    CaSanXuat_IN = "Ca 2";
                    ID_CaTruong_IN = "9";
                }
                MaMay_IN= dtphieu.Rows[i][4].ToString();
                clsmaymoc.sMaMay = MaMay_IN;
                DataTable dtmay_IN = clsmaymoc.SelectOne_W_MaMay();
                if(dtmay_IN.Rows.Count>0)
                {
                    ID_May_IN = dtmay_IN.Rows[0]["id"].ToString();
                }
                MaVT_Vao_IN= dtphieu.Rows[i][2].ToString();
                clsVT.sMaVT = MaVT_Vao_IN;
                DataTable dtvat_vao_IN = clsVT.SelectOne_W_MaVT();
                if(dtvat_vao_IN.Rows.Count>0)
                {
                    ID_VTHH_Vao_IN = dtvat_vao_IN.Rows[0]["ID_VTHH"].ToString();
                    DonViTinh_Vao_IN = dtvat_vao_IN.Rows[0]["DonViTinh"].ToString();
                    TenVatTu_Vao_IN = dtvat_vao_IN.Rows[0]["TenVTHH"].ToString();
                }

                MaVT_Ra_IN = dtphieu.Rows[i][7].ToString();
                clsVT.sMaVT = MaVT_Ra_IN;
                DataTable dtvat_ra_IN = clsVT.SelectOne_W_MaVT();
                if (dtvat_ra_IN.Rows.Count > 0)
                {
                    ID_VTHH_Ra_IN = dtvat_ra_IN.Rows[0]["ID_VTHH"].ToString();
                    DonViTinh_Ra_IN = dtvat_ra_IN.Rows[0]["DonViTinh"].ToString();
                    TenVatTu_Ra_IN = dtvat_ra_IN.Rows[0]["TenVTHH"].ToString();
                }
                SoLuong_Vao_IN= dtphieu.Rows[i][6].ToString();
                SoLuong_Ra_IN = dtphieu.Rows[i][10].ToString();
                PhePham_IN = dtphieu.Rows[i][11].ToString();
                NgaySanXuat_IN = dtphieu.Rows[i][15].ToString();

                CongNhan_IN = dtphieu.Rows[i][13].ToString();
                clsnhansu.sTenNhanVien = CongNhan_IN;
                DataTable dtnhansu_IN = clsnhansu.SelectOne_W_TenNhanVien();
                if (dtnhansu_IN.Rows.Count > 0)
                {
                    ID_CongNhan_IN = dtnhansu_IN.Rows[0]["ID_NhanSu"].ToString();
                    
                }
                _ravi["MaPhieu"] = MaPhieu;
                _ravi["ID_CongNhan_IN"] = ID_CongNhan_IN;
                _ravi["ID_CaTruong_IN"] = ID_CaTruong_IN;
                _ravi["ID_May_IN"] = ID_May_IN;
                _ravi["ID_VTHH_Vao_IN"] = ID_VTHH_Vao_IN;
                _ravi["ID_VTHH_Ra_IN"] = ID_VTHH_Ra_IN;
                _ravi["MaVT_Vao_IN"] = MaVT_Vao_IN;
                _ravi["MaVT_Ra_IN"] = MaVT_Ra_IN;
                _ravi["DonViTinh_Vao_IN"] = DonViTinh_Vao_IN;
                _ravi["DonViTinh_Ra_IN"] = DonViTinh_Ra_IN;
                _ravi["TenVatTu_Vao_IN"] = TenVatTu_Vao_IN;
                _ravi["TenVatTu_Ra_IN"] = TenVatTu_Ra_IN;
                _ravi["SoLuong_Vao_IN"] = SoLuong_Vao_IN.ToString();
                _ravi["SoLuong_Ra_IN"] = SoLuong_Ra_IN.ToString();
                _ravi["PhePham_IN"] = PhePham_IN;
                _ravi["NgaySanXuat_IN"] = NgaySanXuat_IN;
                _ravi["CaSanXuat_IN"] = CaSanXuat_IN;
                _ravi["CongNhan_IN"] = CongNhan_IN;
                _ravi["MaMay_IN"] = MaMay_IN;

                if (dtphieu.Rows[i][28].ToString() == "1")
                {
                    CaSanXuat_CAT = "Ca 1";
                    ID_CaTruong_CAT = "8";
                }
                else
                {
                    CaSanXuat_CAT = "Ca 2";
                    ID_CaTruong_CAT = "9";
                }
                MaMay_CAT = dtphieu.Rows[i][18].ToString();
                clsmaymoc.sMaMay = MaMay_CAT;
                DataTable dtmay_CAT = clsmaymoc.SelectOne_W_MaMay();
                if (dtmay_CAT.Rows.Count > 0)
                {
                    ID_May_CAT = dtmay_CAT.Rows[0]["id"].ToString();
                }
                MaVT_Vao_CAT = dtphieu.Rows[i][16].ToString();
                clsVT.sMaVT = MaVT_Vao_CAT;
                DataTable dtvat_vao_CAT = clsVT.SelectOne_W_MaVT();
                if (dtvat_vao_CAT.Rows.Count > 0)
                {
                    ID_VTHH_Vao_CAT = dtvat_vao_CAT.Rows[0]["ID_VTHH"].ToString();
                    DonViTinh_Vao_CAT = dtvat_vao_CAT.Rows[0]["DonViTinh"].ToString();
                    TenVatTu_Vao_CAT = dtvat_vao_CAT.Rows[0]["TenVTHH"].ToString();
                }

                MaVT_Ra_CAT = dtphieu.Rows[i][21].ToString();
                clsVT.sMaVT = MaVT_Ra_CAT;
                DataTable dtvat_ra_CAT = clsVT.SelectOne_W_MaVT();
                if (dtvat_ra_CAT.Rows.Count > 0)
                {
                    ID_VTHH_Ra_CAT = dtvat_ra_CAT.Rows[0]["ID_VTHH"].ToString();
                    DonViTinh_Ra_CAT = dtvat_ra_CAT.Rows[0]["DonViTinh"].ToString();
                    TenVatTu_Ra_CAT = dtvat_ra_CAT.Rows[0]["TenVTHH"].ToString();
                }
                SoLuong_Vao_CAT = dtphieu.Rows[i][20].ToString();
                SoLuong_Ra_CAT = dtphieu.Rows[i][24].ToString();
                PhePham_CAT = dtphieu.Rows[i][25].ToString();
                NgaySanXuat_CAT = dtphieu.Rows[i][29].ToString();
                CongNhan_CAT = dtphieu.Rows[i][27].ToString();
                clsnhansu.sTenNhanVien = CongNhan_CAT;
                DataTable dtnhansu_CAT = clsnhansu.SelectOne_W_TenNhanVien();
                if (dtnhansu_CAT.Rows.Count > 0)
                {
                    ID_CongNhan_CAT = dtnhansu_CAT.Rows[0]["ID_NhanSu"].ToString();

                }

                _ravi["ID_CongNhan_CAT"] = ID_CongNhan_CAT;
                _ravi["ID_CaTruong_CAT"] = ID_CaTruong_CAT;
                _ravi["ID_May_CAT"] = ID_May_CAT;
                _ravi["ID_VTHH_Vao_CAT"] = ID_VTHH_Vao_CAT;
                _ravi["ID_VTHH_Ra_CAT"] = ID_VTHH_Ra_CAT;
                _ravi["MaVT_Vao_CAT"] = MaVT_Vao_CAT;
                _ravi["MaVT_Ra_CAT"] = MaVT_Ra_CAT;
                _ravi["DonViTinh_Vao_CAT"] = DonViTinh_Vao_CAT;
                _ravi["DonViTinh_Ra_CAT"] = DonViTinh_Ra_CAT;
                _ravi["TenVatTu_Vao_CAT"] = TenVatTu_Vao_CAT;
                _ravi["TenVatTu_Ra_CAT"] = TenVatTu_Ra_CAT;
                _ravi["SoLuong_Vao_CAT"] = SoLuong_Vao_CAT.ToString();
                _ravi["SoLuong_Ra_CAT"] = SoLuong_Ra_CAT.ToString();
                _ravi["PhePham_CAT"] = PhePham_CAT;
                _ravi["NgaySanXuat_CAT"] = NgaySanXuat_CAT;
                _ravi["CaSanXuat_CAT"] = CaSanXuat_CAT;
                _ravi["CongNhan_CAT"] = CongNhan_CAT;
                _ravi["MaMay_CAT"] = MaMay_CAT;


                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;
          
        }


        private void lUUDULIEU(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clsPhieu_tbPhieu cls1 = new CtyTinLuong.clsPhieu_tbPhieu();
                cls1.sMaPhieu = dt.Rows[i]["MaPhieu"].ToString();
                cls1.daNgayLapPhieu = Convert.ToDateTime(dt.Rows[i]["NgaySanXuat_IN"].ToString());
                cls1.sCaSanXuat = dt.Rows[i]["CaSanXuat_IN"].ToString();
                cls1.iID_CaTruong = Convert.ToInt32(dt.Rows[i]["ID_CaTruong_IN"].ToString());
                cls1.sGhiChu = "";
                cls1.bTonTai = true;
                cls1.bNgungTheoDoi = false;
                cls1.bGuiDuLieu = false;
                cls1.bCheck_In = false;
                cls1.bCheck_Cat = false;
                cls1.bCheck_Dot = false;
                cls1.iBienTrangThai = 0;
                cls1.bDaKetThuc = false;
                cls1.Insert();
                int iiiiID_SoPhieu = cls1.iID_SoPhieu.Value;

                clsPhieu_ChiTietPhieu_New cls2 = new clsPhieu_ChiTietPhieu_New();
                int ID_May = Convert.ToInt32(dt.Rows[i]["ID_May_IN"].ToString());
                int ID_CongNhan = Convert.ToInt32(dt.Rows[i]["ID_CongNhan_IN"].ToString());
                int ID_CaTruong = Convert.ToInt32(dt.Rows[i]["ID_CaTruong_IN"].ToString());
                DateTime NgaySanXuat = Convert.ToDateTime(dt.Rows[i]["NgaySanXuat_IN"].ToString());
                string GhiChu = "";
                string CaSanXuat = dt.Rows[i]["CaSanXuat_IN"].ToString();
                int ID_DinhMuc_Luong =8;
                int ID_VTHH_Vao = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Vao_IN"].ToString());
                double SoLuong_Vao = Convert.ToDouble(dt.Rows[i]["SoLuong_Vao_IN"].ToString());
                double DonGia_Vao = 0;
                int ID_VTHH_Ra = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Ra_IN"].ToString());
                double SanLuong_Thuong = Convert.ToDouble(dt.Rows[i]["SoLuong_Ra_IN"].ToString());
                double SanLuong_TangCa = 0;
                double SanLuong_Tong = SanLuong_Thuong;
                double DonGia_Xuat = 0;
                double PhePham;
                if (dt.Rows[i]["PhePham_IN"].ToString() == "")
                    PhePham = 0;
                else  PhePham = Convert.ToDouble(dt.Rows[i]["PhePham_IN"].ToString());

                cls2.iID_SoPhieu = iiiiID_SoPhieu;
                cls2.iID_May = ID_May;
                cls2.iID_CongNhan = ID_CongNhan;
                cls2.iID_CaTruong = ID_CaTruong;
                cls2.daNgaySanXuat = NgaySanXuat;
                cls2.sGhiChu = GhiChu;
                cls2.sCaSanXuat = CaSanXuat;
                cls2.iID_DinhMuc_Luong = ID_DinhMuc_Luong;
                cls2.iID_VTHH_Vao = ID_VTHH_Vao;
                cls2.fSoLuong_Vao = SoLuong_Vao;
                cls2.fDonGia_Vao = DonGia_Vao;
                cls2.iID_VTHH_Ra = ID_VTHH_Ra;
                cls2.fSanLuong_Thuong = SanLuong_Thuong;
                cls2.fSanLuong_TangCa = SanLuong_TangCa;
                cls2.fSanLuong_Tong = SanLuong_Tong;
                cls2.fDonGia_Xuat = DonGia_Xuat;
                cls2.fPhePham = PhePham;
                cls2.bBMay_IN = true;
                cls2.bBMay_CAT = false;
                cls2.bBMay_DOT = false;
                cls2.bTrangThaiXuatNhap = false;
                cls2.bGuiDuLieu = false;
                cls2.bTrangThaiTaoLenhSanXuat = false;
                cls2.fSoKG_MotBao_May_Dot = 0;
                cls2.Insert();

                if(dt.Rows[i]["ID_CongNhan_CAT"].ToString()!="")
                {
                    cls2 = new clsPhieu_ChiTietPhieu_New();
                 

                    cls2.iID_SoPhieu = iiiiID_SoPhieu;
                    cls2.iID_May = Convert.ToInt32(dt.Rows[i]["ID_May_CAT"].ToString());
                    cls2.iID_CongNhan = Convert.ToInt32(dt.Rows[i]["ID_CongNhan_CAT"].ToString());
                    cls2.iID_CaTruong = Convert.ToInt32(dt.Rows[i]["ID_CaTruong_CAT"].ToString());
                    cls2.daNgaySanXuat = Convert.ToDateTime(dt.Rows[i]["NgaySanXuat_CAT"].ToString());
                    cls2.sGhiChu = "";
                    cls2.sCaSanXuat = dt.Rows[i]["CaSanXuat_CAT"].ToString();
                    cls2.iID_DinhMuc_Luong = 3;
                    cls2.iID_VTHH_Vao = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Vao_CAT"].ToString());
                    cls2.fSoLuong_Vao = Convert.ToDouble(dt.Rows[i]["SoLuong_Vao_CAT"].ToString());
                    cls2.fDonGia_Vao =0;
                    cls2.iID_VTHH_Ra = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Ra_CAT"].ToString());
                    cls2.fSanLuong_Thuong = Convert.ToDouble(dt.Rows[i]["SoLuong_Ra_CAT"].ToString());
                    cls2.fSanLuong_TangCa = 0;
                    cls2.fSanLuong_Tong = Convert.ToDouble(dt.Rows[i]["SoLuong_Ra_CAT"].ToString());
                    cls2.fDonGia_Xuat = 0;
                    if (dt.Rows[i]["PhePham_CAT"].ToString() == "")
                        cls2.fPhePham = 0;
                  else  cls2.fPhePham = Convert.ToDouble(dt.Rows[i]["PhePham_CAT"].ToString());
                    cls2.bBMay_IN = false;
                    cls2.bBMay_CAT = true;
                    cls2.bBMay_DOT = false;
                    cls2.bTrangThaiXuatNhap = false;
                    cls2.bGuiDuLieu = false;
                    cls2.fSoKG_MotBao_May_Dot = 0;
                    cls2.bTrangThaiTaoLenhSanXuat = false;
                    cls2.Insert();
                                      
                }
            }
            

            MessageBox.Show("đã xong");
        }



        public frmImPortPhieuSanXuat_banDau()
        {
            InitializeComponent();
        }

        private void btChonfilePhieu_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "File (*.xls)|*.xls";
            f.Multiselect = false;
            f.Title = "Chon CSDL";
            // f.InitialDirectory = @"Local\Libraries\Documents\QLKH:";
            if (f.ShowDialog() == DialogResult.OK)
            {
                clsNganHang_ChiTietBienDongTaiKhoanKeToan cls = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();

                OleDbConnection con = new OleDbConnection();
                string Tenfile_Execl;
                 dtphieu = new DataTable();
                DataTable dtNganhang = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();


                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string str_adapter = "Select * from [Sheet1$]";
                adapter = new OleDbDataAdapter(str_adapter, con);
                adapter.Fill(dtphieu);

                //gridControl2.DataSource = dt;
                HienThi();
            }
        }

        private void btGuiDuLieuPhieu_Click(object sender, EventArgs e)
        {
          
           
            DataTable dtPhieuxxxxx = new DataTable();          
            DataTable dt2 = (DataTable)gridControl1.DataSource;
            DataTable dtxx = dt2.Copy();
            gridControl1.DataSource = dtxx;
           
            DataView dvNPL = dt2.DefaultView;
            dtPhieuxxxxx = dvNPL.ToTable();
            lUUDULIEU(dtPhieuxxxxx);
           // frmImPortPhieuSanXuat_banDau_Load(sender, e);
        }

        private void frmImPortPhieuSanXuat_banDau_Load(object sender, EventArgs e)
        {

        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
