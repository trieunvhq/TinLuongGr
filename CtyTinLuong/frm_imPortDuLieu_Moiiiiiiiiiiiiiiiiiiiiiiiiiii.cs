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
    public partial class frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii : Form
    {
        frmMain _frmMain;
        public frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii(frmMain frm)
        {
            _frmMain = frm;
            InitializeComponent();
           
        }
       private void NhapKho_NPL(DataTable dt_NPL)
        {
            clsKhoNPL_tbChiTietNhapKho clschitietnhapkho_NPL = new clsKhoNPL_tbChiTietNhapKho();
            clsKhoNPL_tbChiTiet_TonDauKy clstondauky = new clsKhoNPL_tbChiTiet_TonDauKy();
            for (int i = 0; i < dt_NPL.Rows.Count; i++)
            {
                int ID_VTHH = Convert.ToInt32(dt_NPL.Rows[i]["ID_VTHH"].ToString());
                double SoLuong = Convert.ToDouble(dt_NPL.Rows[i]["SoLuong"].ToString());
                double DonGia = Convert.ToDouble(dt_NPL.Rows[i]["DonGia"].ToString());

                clschitietnhapkho_NPL.iID_NhapKho = 0;
                clschitietnhapkho_NPL.iID_VTHH = ID_VTHH;
                clschitietnhapkho_NPL.fSoLuongNhap = SoLuong;
                clschitietnhapkho_NPL.fSoLuongTon = SoLuong;
                clschitietnhapkho_NPL.fDonGia = DonGia;
                clschitietnhapkho_NPL.bTonTai = true;
                clschitietnhapkho_NPL.bNgungTheoDoi = false;
                clschitietnhapkho_NPL.sGhiChu = "";
                clschitietnhapkho_NPL.bBoolTonDauKy = true;
                clschitietnhapkho_NPL.bDaNhapKho = true;
                clschitietnhapkho_NPL.Insert();
                // ton đâu kỳ
                clstondauky.iID_VTHH = ID_VTHH;
                clstondauky.fSoLuong = SoLuong;
                clstondauky.fDonGia = DonGia;
                clstondauky.bTonTai = true;
                clstondauky.bNgungTheoDoi = false;
                clstondauky.Insert();
            }

            MessageBox.Show("Đã xong kho NPL");
        }

        private void NhapKho_BanThanhPham(DataTable dt_BTP)
        {
          
            clsKhoBTP_tbChiTietNhapKho clschitietnhapkho_BTP = new clsKhoBTP_tbChiTietNhapKho();
            clsKhoBTP_tbChiTiet_tonDauKy clstondauky = new clsKhoBTP_tbChiTiet_tonDauKy();
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            
               
                for (int i = 0; i < dt_BTP.Rows.Count; i++)                
                {

                    int ID_VTHH = Convert.ToInt32(dt_BTP.Rows[i]["ID_VTHH"].ToString());
                    double SoLuong = Convert.ToDouble(dt_BTP.Rows[i]["SoLuong"].ToString());
                    double DonGia = Convert.ToDouble(dt_BTP.Rows[i]["DonGia"].ToString());

                    clschitietnhapkho_BTP.iID_NhapKho = 0;
                    clschitietnhapkho_BTP.iID_VTHH = ID_VTHH;
                    clschitietnhapkho_BTP.fSoLuongNhap = SoLuong;
                    clschitietnhapkho_BTP.fSoLuongTon = SoLuong;
                    clschitietnhapkho_BTP.fDonGia = DonGia;
                    clschitietnhapkho_BTP.bTonTai = true;
                    clschitietnhapkho_BTP.bNgungTheoDoi = false;
                    clschitietnhapkho_BTP.sGhiChu = "";
                    clschitietnhapkho_BTP.bBoolTonDauKy = true;
                    clschitietnhapkho_BTP.bDaNhapKho = true;
                    clschitietnhapkho_BTP.Insert();
                    // ton đâu kỳ
                    clstondauky.iID_VTHH = ID_VTHH;
                    clstondauky.fSoLuong = SoLuong;
                    clstondauky.fDonGia = DonGia;
                    clstondauky.bTonTai = true;
                    clstondauky.bNgungTheoDoi = false;
                    clstondauky.Insert();
                }
            
            MessageBox.Show("Đã xong kho bán thành phẩm");
        }
        private void NhapKho_DAILY(DataTable dt_DAILY)
        {
           
           
            clsDaiLy_tbChiTietNhapKho clschitietnhapkho_DAILY = new clsDaiLy_tbChiTietNhapKho();
          
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            
            if (dt_DAILY.Rows.Count > 0)
            {
                for (int i = 0; i < dt_DAILY.Rows.Count; i++)
                {
                    int ID_DaiLy = Convert.ToInt32(dt_DAILY.Rows[i]["ID_DaiLy"].ToString());
                    int ID_VTHH = Convert.ToInt32(dt_DAILY.Rows[i]["ID_VTHH"].ToString());
                    double SoLuong = Convert.ToDouble(dt_DAILY.Rows[i]["SoLuong"].ToString());
                    double DonGia = Convert.ToDouble(dt_DAILY.Rows[i]["DonGia"].ToString());

                    clschitietnhapkho_DAILY.iID_NhapKhoDaiLy = 0;
                    clschitietnhapkho_DAILY.iID_VTHH = ID_VTHH;
                    clschitietnhapkho_DAILY.fSoLuongNhap = SoLuong;
                    clschitietnhapkho_DAILY.fSoLuongTon = SoLuong;
                    clschitietnhapkho_DAILY.fDonGia = DonGia;
                    clschitietnhapkho_DAILY.bTonTai = true;
                    clschitietnhapkho_DAILY.bNgungTheoDoi = false;
                    clschitietnhapkho_DAILY.sGhiChu = "";
                    clschitietnhapkho_DAILY.bBoolTonDauKy = true;
                    clschitietnhapkho_DAILY.bDaNhapKho = true;
                    clschitietnhapkho_DAILY.iID_DaiLy = ID_DaiLy;
                    clschitietnhapkho_DAILY.Insert();

                }
            }
            MessageBox.Show("Đã xong kho ĐẠI LÝ");
        }
        
        private void NhapKho_ThanhPham(DataTable dt_THANHPHAM)
        {

            clsKhoThanhPham_tbChiTietNhapKho clschitietnhapkho_THANHPHAM = new clsKhoThanhPham_tbChiTietNhapKho();
            
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();


            for (int i = 0; i < dt_THANHPHAM.Rows.Count; i++)
            {
                int ID_VTHH = Convert.ToInt32(dt_THANHPHAM.Rows[i]["ID_VTHH"].ToString());
                double SoLuong = Convert.ToDouble(dt_THANHPHAM.Rows[i]["SoLuong"].ToString());
                double DonGia = Convert.ToDouble(dt_THANHPHAM.Rows[i]["DonGia"].ToString());

                clschitietnhapkho_THANHPHAM.iID_NhapKho_ThanhPham = 0;
                clschitietnhapkho_THANHPHAM.iID_VTHH = ID_VTHH;
                clschitietnhapkho_THANHPHAM.fSoLuongNhap = SoLuong;
                clschitietnhapkho_THANHPHAM.fSoLuongTon = SoLuong;
                clschitietnhapkho_THANHPHAM.fDonGia = DonGia;
                clschitietnhapkho_THANHPHAM.bTonTai = true;
                clschitietnhapkho_THANHPHAM.bNgungTheoDoi = false;
                clschitietnhapkho_THANHPHAM.sGhiChu = "";
                clschitietnhapkho_THANHPHAM.bBool_TonDauKy = true;
                clschitietnhapkho_THANHPHAM.bDaNhapKho = true;
                clschitietnhapkho_THANHPHAM.Insert();
                
             
            }

            MessageBox.Show("Đã xong kho thành phẩm");
        }

        private void NhapKho_GapDam(DataTable dt_GapDan)
        {

            clsGapDan_ChiTiet_NhapKho clsgapdan = new clsGapDan_ChiTiet_NhapKho();
           
            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();


            for (int i = 0; i < dt_GapDan.Rows.Count; i++)
            {
                int ID_VTHH = Convert.ToInt32(dt_GapDan.Rows[i]["ID_VTHH"].ToString());
                double SoLuong = Convert.ToDouble(dt_GapDan.Rows[i]["SoLuong"].ToString());
                double DonGia = Convert.ToDouble(dt_GapDan.Rows[i]["DonGia"].ToString());

                clsgapdan.iID_NhapKho = 0;
                clsgapdan.iID_VTHH = ID_VTHH;
                clsgapdan.fSoLuongNhap = SoLuong;
                clsgapdan.fSoLuongTon = SoLuong;
                clsgapdan.fDonGia = DonGia;
                clsgapdan.bTonTai = true;
                clsgapdan.bNgungTheoDoi = false;
                clsgapdan.sGhiChu = "";
                clsgapdan.bBoolTonDauKy = true;
                clsgapdan.bDaNhapKho = true;
                clsgapdan.Insert();
                // ton đâu kỳ
               
            }

            MessageBox.Show("Đã xong kho thành phẩm");
        }
        private void Nhap_SoDuBanDau_TKNganHang(DataTable dtnganhang)
        {

            clsNganHang_ChiTietBienDongTaiKhoanKeToan clschitietbeindong = new clsNganHang_ChiTietBienDongTaiKhoanKeToan();
            //clsNganHang_SoDuBanDau_TaiKhoanKeToan clstondauky = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();
          

            for (int i = 0; i < dtnganhang.Rows.Count; i++)
            {
                int ID_TaiKhoanKeToanCon = Convert.ToInt32(dtnganhang.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                int ID_TaiKhoanKeToanMe = Convert.ToInt32(dtnganhang.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                double Co = Convert.ToDouble(dtnganhang.Rows[i]["Co"].ToString());
                double No = Convert.ToDouble(dtnganhang.Rows[i]["No"].ToString());
                bool TienUSD = Convert.ToBoolean(dtnganhang.Rows[i]["TienUSD"].ToString());
                double TiGia = 0;
                clschitietbeindong.iID_ChungTu = 0;
                clschitietbeindong.sSoChungTu = "";
                clschitietbeindong.daNgayThang = DateTime.Today;
                clschitietbeindong.iID_TaiKhoanKeToanCon = ID_TaiKhoanKeToanCon;
                
                clschitietbeindong.fCo = Co;
                clschitietbeindong.fNo = No;
                clschitietbeindong.bTienUSD = TienUSD;
                clschitietbeindong.fTiGia = TiGia;           

             
                clschitietbeindong.bTonTai = true;
                clschitietbeindong.bNgungTheoDoi = false;
                clschitietbeindong.bDaGhiSo = true;
                clschitietbeindong.bBBool_TonDauKy = true;
                clschitietbeindong.Insert();
                // ton đâu kỳ
           
            }

            MessageBox.Show("Đã xong ngân hàng");
        }
        private void btChonFile_Click(object sender, EventArgs e)
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
                
                OleDbConnection con = new OleDbConnection() ;
                string Tenfile_Execl;
                DataTable dt = new DataTable();
                DataTable dtNganhang = new DataTable(); 
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();

               
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string str_adapter = "Select * from [Sheet1$]";
                adapter = new OleDbDataAdapter(str_adapter, con);
                adapter.Fill(dt);

                DataTable dt2 = new DataTable();

                dt2.Columns.Add("ID_VTHH", typeof(int));
                dt2.Columns.Add("MaKho", typeof(int));
                dt2.Columns.Add("SoLuong", typeof(double));               
                dt2.Columns.Add("DonGia", typeof(double));
                dt2.Columns.Add("MaVT", typeof(string));
                dt2.Columns.Add("TenVTHH", typeof(string));
                dt2.Columns.Add("DonViTinh", typeof(string));
                dt2.Columns.Add("ThanhTien", typeof(double));
                dt2.Columns.Add("TenKho", typeof(string));
                dt2.Columns.Add("ID_DaiLy", typeof(string));
                dt2.Columns.Add("TenDaiLy", typeof(string));
                
                for (int i = 3; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() != "")
                    {
                        DataRow _ravi = dt2.NewRow();

                        double SoLuong, DonGia, ThanhTien;
                        string MaVT, TenVTHH, DonViTinh, sTenKho,sID_DaiLy, sTenDaiLy;
                        sTenKho = "";
                        int ID_VTHH, MaKho;
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            SoLuong = 1;                            
                        }
                        else
                        {
                            SoLuong = Convert.ToDouble(dt.Rows[i][2].ToString());                            
                        }

                        if (dt.Rows[i][3].ToString() == "")
                        {
                            DonGia = 0;
                        }
                        else
                        {
                            DonGia = Convert.ToDouble(dt.Rows[i][3].ToString());
                        }
                        ThanhTien = SoLuong * DonGia;

                        MaKho = Convert.ToInt32(dt.Rows[i][0].ToString());
                        if (MaKho == 1)
                            sTenKho = "Kho Nguyên Phụ liệu";
                        if (MaKho == 2)
                            sTenKho = "Kho Bán Thành phẩm";
                        if (MaKho == 3)
                        {
                            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
                            string MaDaiLy = dt.Rows[i][4].ToString();
                            clsdaily.sMaDaiLy = MaDaiLy;
                            DataTable dtdaily = clsdaily.SelectOne_W_MaDaiLy();
                            sID_DaiLy = dtdaily.Rows[0]["ID_DaiLy"].ToString();
                            sTenKho = "Đại lý";
                            sTenDaiLy = dtdaily.Rows[0]["TenDaiLy"].ToString();
                        }
                        else
                        {
                            sID_DaiLy = "";
                            sTenDaiLy = "";
                        }
                        if (MaKho == 4)
                            sTenKho = "Kho Thành phẩm";
                        if (MaKho == 5)
                            sTenKho = "Gấp dán";
                        MaVT = dt.Rows[i][1].ToString(); ;
                        clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                        clsvt.sMaVT = MaVT;
                        DataTable dtvt = clsvt.SelectOne_W_MaVT();
                        ID_VTHH=Convert.ToInt32(dtvt.Rows[0]["ID_VTHH"].ToString());
                        clsvt.iID_VTHH = ID_VTHH;
                        DataTable dtvt_new = clsvt.SelectOne();
                        if(dtvt_new.Rows.Count>0)
                        {
                            TenVTHH = clsvt.sTenVTHH.Value;
                            DonViTinh = clsvt.sDonViTinh.Value;

                            _ravi["ID_VTHH"] = ID_VTHH;
                            _ravi["MaKho"] = MaKho;
                            _ravi["SoLuong"] = SoLuong;
                            _ravi["DonGia"] = DonGia;
                            _ravi["MaVT"] = MaVT;
                            _ravi["TenVTHH"] = TenVTHH;
                            _ravi["DonViTinh"] = DonViTinh;
                            _ravi["ThanhTien"] = ThanhTien;
                            _ravi["TenKho"] = sTenKho;
                            _ravi["ID_DaiLy"] = sID_DaiLy;
                            _ravi["TenDaiLy"] = sTenDaiLy;
                        }
                                             
                        dt2.Rows.Add(_ravi);
                    }

                  
                }
               
               
                gridControl1.DataSource = dt2;
              



                OleDbDataAdapter adapterNganHang = new OleDbDataAdapter();
                string str_adapterNganHang = "Select * from [NganHang$]";
                adapterNganHang = new OleDbDataAdapter(str_adapterNganHang, con);
                adapterNganHang.Fill(dtNganhang);

                DataTable dtnganghang2 = new DataTable();

                dtnganghang2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
                dtnganghang2.Columns.Add("ID_TaiKhoanKeToanMe", typeof(int));
                dtnganghang2.Columns.Add("Co", typeof(double));
                dtnganghang2.Columns.Add("No", typeof(double));
                dtnganghang2.Columns.Add("TienUSD", typeof(bool));
                dtnganghang2.Columns.Add("SoTaiKhoanCon", typeof(string));
                dtnganghang2.Columns.Add("SoTaiKhoanMe", typeof(string));
                dtnganghang2.Columns.Add("TenTaiKhoanCon", typeof(string));
                
                if (dtNganhang.Rows.Count > 0)
                {
                    for (int i = 3; i < dtNganhang.Rows.Count; i++)
                    {
                        double Co, No;
                        int ID_TaiKhoanKeToanCon, ID_TaiKhoanKeToanMe;
                        bool TienUSD;
                        string sSoTaiKhoanCon, sSoTaiKhoanMe,TenTaiKhoanCon;
                        sSoTaiKhoanCon = dtNganhang.Rows[i][1].ToString();
                        clsNganHang_TaiKhoanKeToanCon clscon = new clsNganHang_TaiKhoanKeToanCon();
                        clscon.sSoTaiKhoanCon = sSoTaiKhoanCon;
                        DataTable dttkcon = clscon.select_one_W_SoTaiKhoanCon();

                        ID_TaiKhoanKeToanCon = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanCon"].ToString());
                        ID_TaiKhoanKeToanMe = Convert.ToInt32(dttkcon.Rows[0]["ID_TaiKhoanKeToanMe"].ToString());
                        Co = Convert.ToDouble(dtNganhang.Rows[i][2].ToString());
                        No = Convert.ToDouble(dtNganhang.Rows[i][3].ToString());                     
                        TenTaiKhoanCon=dttkcon.Rows[0]["TenTaiKhoanCon"].ToString();
                        clsNganHang_tbHeThongTaiKhoanKeToanMe clsme = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                        clsme.iID_TaiKhoanKeToanMe = ID_TaiKhoanKeToanMe;
                        DataTable dtme = clsme.SelectOne();
                        sSoTaiKhoanMe = clsme.sSoTaiKhoanMe.Value;
                        if (dtNganhang.Rows[i][4].ToString() == "1")
                            TienUSD = true;
                        else TienUSD = false;
                        DataRow _ravi = dtnganghang2.NewRow();
                        _ravi["ID_TaiKhoanKeToanCon"] = ID_TaiKhoanKeToanCon;
                        _ravi["ID_TaiKhoanKeToanMe"] = ID_TaiKhoanKeToanMe;
                        _ravi["Co"] = Co;
                        _ravi["No"] = No;
                        _ravi["TienUSD"] = TienUSD;
                        _ravi["SoTaiKhoanCon"] = sSoTaiKhoanCon;
                        _ravi["SoTaiKhoanMe"] = sSoTaiKhoanMe;
                        _ravi["TenTaiKhoanCon"] = TenTaiKhoanCon;
                        dtnganghang2.Rows.Add(_ravi);
                    }

                    gridControl2.DataSource = dtnganghang2;

                }
            }
        }

        private void frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii_Load(object sender, EventArgs e)
        {
            clsTbDangNhap cls = new CtyTinLuong.clsTbDangNhap();
          
            DataTable dt = cls.SelectAll();
            if (Convert.ToBoolean(dt.Rows[0]["bThietLapBanDau"].ToString()) == true)
            {
                btLuu.Enabled = false;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmMain.Show();
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            clsDelete_ALL_newwww cls = new clsDelete_ALL_newwww();

            cls.HUU_Delete_ALL();
            
            clsTbDangNhap clsxx = new CtyTinLuong.clsTbDangNhap();
            clsxx.Update_W_ThietLapBanDau();
            //MessageBox.Show("Đã xong");
            DataTable dtNPL = new DataTable();
            DataTable dtBTP = new DataTable();
            DataTable dtDL = new DataTable();
            DataTable dtTP = new DataTable();
            DataTable dtGapDan = new DataTable();
            DataTable dt2 = (DataTable)gridControl1.DataSource;
            DataTable dtxx = dt2.Copy();
            gridControl1.DataSource = dtxx;
            dt2.DefaultView.RowFilter = "MaKho = 1";
            DataView dvNPL = dt2.DefaultView;
            dtNPL = dvNPL.ToTable();
            if (dtNPL.Rows.Count > 0)
                NhapKho_NPL(dtNPL);

            dt2.DefaultView.RowFilter = "MaKho = 2";
            DataView dvBTP = dt2.DefaultView;
            dtBTP = dvBTP.ToTable();
            if (dtBTP.Rows.Count > 0)
                NhapKho_BanThanhPham(dtBTP);

            dt2.DefaultView.RowFilter = "MaKho = 3";
            DataView dvDL = dt2.DefaultView;
            dtDL = dvDL.ToTable();
            if (dtDL.Rows.Count > 0)
                NhapKho_DAILY(dtDL);

            dt2.DefaultView.RowFilter = "MaKho = 4";
            DataView dvTP = dt2.DefaultView;
            dtTP = dvTP.ToTable();
            if (dtTP.Rows.Count > 0)
                NhapKho_ThanhPham(dtTP);

            dt2.DefaultView.RowFilter = "MaKho = 5";
            DataView dvgapdan = dt2.DefaultView;
            dtGapDan = dvgapdan.ToTable();
            if (dtGapDan.Rows.Count > 0)
                NhapKho_GapDam(dtGapDan);

            DataTable dt23 = (DataTable)gridControl2.DataSource;

            if (dt23.Rows.Count > 0)
                Nhap_SoDuBanDau_TKNganHang(dt23);

            frm_imPortDuLieu_Moiiiiiiiiiiiiiiiiiiiiiiiiiii_Load(sender, e);
        }

        private void gridView4_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == STT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
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
                DataTable dt = new DataTable();
                DataTable dtNganhang = new DataTable();
                Tenfile_Execl = f.FileName;
                string str_con = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Tenfile_Execl + ";Extended Properties=Excel 8.0";
                con = new OleDbConnection(str_con);
                con.Open();


                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string str_adapter = "Select * from [Sheet1$]";
                adapter = new OleDbDataAdapter(str_adapter, con);
                adapter.Fill(dt);

                DataTable dt2 = new DataTable();

                dt2.Columns.Add("ID_VTHH", typeof(int));
                dt2.Columns.Add("MaKho", typeof(int));
                dt2.Columns.Add("SoLuong", typeof(double));
                dt2.Columns.Add("DonGia", typeof(double));
                dt2.Columns.Add("MaVT", typeof(string));
                dt2.Columns.Add("TenVTHH", typeof(string));
                dt2.Columns.Add("DonViTinh", typeof(string));
                dt2.Columns.Add("ThanhTien", typeof(double));
                dt2.Columns.Add("TenKho", typeof(string));
                dt2.Columns.Add("ID_DaiLy", typeof(string));
                dt2.Columns.Add("TenDaiLy", typeof(string));

                for (int i = 3; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() != "")
                    {
                        DataRow _ravi = dt2.NewRow();

                        double SoLuong, DonGia, ThanhTien;
                        string MaVT, TenVTHH, DonViTinh, sTenKho, sID_DaiLy, sTenDaiLy;
                        sTenKho = "";
                        int ID_VTHH, MaKho;
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            SoLuong = 1;
                        }
                        else
                        {
                            SoLuong = Convert.ToDouble(dt.Rows[i][2].ToString());
                        }

                        if (dt.Rows[i][3].ToString() == "")
                        {
                            DonGia = 0;
                        }
                        else
                        {
                            DonGia = Convert.ToDouble(dt.Rows[i][3].ToString());
                        }
                        ThanhTien = SoLuong * DonGia;

                        MaKho = Convert.ToInt32(dt.Rows[i][0].ToString());
                        if (MaKho == 1)
                            sTenKho = "Kho Nguyên Phụ liệu";
                        if (MaKho == 2)
                            sTenKho = "Kho Bán Thành phẩm";
                        if (MaKho == 3)
                        {
                            clsTbDanhMuc_DaiLy clsdaily = new clsTbDanhMuc_DaiLy();
                            string MaDaiLy = dt.Rows[i][4].ToString();
                            clsdaily.sMaDaiLy = MaDaiLy;
                            DataTable dtdaily = clsdaily.SelectOne_W_MaDaiLy();
                            sID_DaiLy = dtdaily.Rows[0]["ID_DaiLy"].ToString();
                            sTenKho = "Đại lý";
                            sTenDaiLy = dtdaily.Rows[0]["TenDaiLy"].ToString();
                        }
                        else
                        {
                            sID_DaiLy = "";
                            sTenDaiLy = "";
                        }
                        if (MaKho == 4)
                            sTenKho = "Kho Thành phẩm";
                        if (MaKho == 5)
                            sTenKho = "Gấp dán";
                        MaVT = dt.Rows[i][1].ToString(); ;
                        clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                        clsvt.sMaVT = MaVT;
                        DataTable dtvt = clsvt.SelectOne_W_MaVT();
                        ID_VTHH = Convert.ToInt32(dtvt.Rows[0]["ID_VTHH"].ToString());
                        clsvt.iID_VTHH = ID_VTHH;
                        DataTable dtvt_new = clsvt.SelectOne();
                        if (dtvt_new.Rows.Count > 0)
                        {
                            TenVTHH = clsvt.sTenVTHH.Value;
                            DonViTinh = clsvt.sDonViTinh.Value;

                            _ravi["ID_VTHH"] = ID_VTHH;
                            _ravi["MaKho"] = MaKho;
                            _ravi["SoLuong"] = SoLuong;
                            _ravi["DonGia"] = DonGia;
                            _ravi["MaVT"] = MaVT;
                            _ravi["TenVTHH"] = TenVTHH;
                            _ravi["DonViTinh"] = DonViTinh;
                            _ravi["ThanhTien"] = ThanhTien;
                            _ravi["TenKho"] = sTenKho;
                            _ravi["ID_DaiLy"] = sID_DaiLy;
                            _ravi["TenDaiLy"] = sTenDaiLy;
                        }

                        dt2.Rows.Add(_ravi);
                    }


                }


                

            }
            }

        private void btGuiDuLieuPhieu_Click(object sender, EventArgs e)
        {

        }
    }
}
