

using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmBTTL_ToDot : UserControl
    {
        public string _MaNhanVien = "", _CaLamViec = "Ca 1";
        public int _nam, _thang, _id_bophan;
        private DataTable _data, _dtSL_Ca1;
        private bool isload = true;
        private int[] _colDelete = new int[32];

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public Tr_frmBTTL_ToDot(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);

            _data = new DataTable();
            _data.Columns.Add("NgayThang", typeof(string));
            _data.Columns.Add("DonViTinh", typeof(string));
            _data.Columns.Add("Dot4_8_Bao", typeof(string));
            _data.Columns.Add("Dot4_8_Kg", typeof(string));
            _data.Columns.Add("Dot36_72_Bao", typeof(string));
            _data.Columns.Add("Dot36_72_Kg", typeof(string));
            _data.Columns.Add("Dot45_90_Bao", typeof(string));
            _data.Columns.Add("Dot45_90_Kg", typeof(string));
            _data.Columns.Add("Dot48_96_Bao", typeof(string));
            _data.Columns.Add("Dot48_96_Kg", typeof(string));
            _data.Columns.Add("Dot56_112_Bao", typeof(string));
            _data.Columns.Add("Dot56_112_Kg", typeof(string));
            _data.Columns.Add("Dot42_84_Bao", typeof(string));
            _data.Columns.Add("Dot42_84_Kg", typeof(string));
            _data.Columns.Add("Dot51_103_Bao", typeof(string));
            _data.Columns.Add("Dot51_103_Kg", typeof(string));
            _data.Columns.Add("Dot51_103tb_Bao", typeof(string));
            _data.Columns.Add("Dot51_103tb_Kg", typeof(string));
            _data.Columns.Add("Dot53_106tb_Bao", typeof(string));
            _data.Columns.Add("Dot53_106tb_Kg", typeof(string));
            _data.Columns.Add("Dot50_100tb_Bao", typeof(string));
            _data.Columns.Add("Dot50_100tb_Kg", typeof(string));
            _data.Columns.Add("Dot11_17tb_Bao", typeof(string));
            _data.Columns.Add("Dot11_17tb_Kg", typeof(string));
            _data.Columns.Add("Dot45_90tb_Bao", typeof(string));
            _data.Columns.Add("Dot45_90tb_Kg", typeof(string));
            _data.Columns.Add("Dot42_84tb_Bao", typeof(string));
            _data.Columns.Add("Dot42_84tb_Kg", typeof(string));
            _data.Columns.Add("TongBao", typeof(string));
            _data.Columns.Add("TongKg", typeof(string));
            _data.Columns.Add("DonGia_Tan", typeof(string));
            _data.Columns.Add("TongBaotb", typeof(string));
            _data.Columns.Add("TongKgtb", typeof(string));
            _data.Columns.Add("DonGiatb_Tan", typeof(string));
            _data.Columns.Add("ThanhTien", typeof(string));

            radioTo1.Checked = true;
            Dot4_8_Bao.Caption = "Đột\n4*8";
            Dot4_8_Kg.Caption = "Đột\n4*8";
            Dot36_72_Bao.Caption = "Đột\n36*72";
            Dot36_72_Kg.Caption = "Đột\n36*72";
            Dot45_90_Bao.Caption = "Đột\n45*90";
            Dot45_90_Kg.Caption = "Đột\n45*90";
            Dot48_96_Bao.Caption = "Đột\n48*96";
            Dot48_96_Kg.Caption = "Đột\n48*96";
            Dot56_112_Bao.Caption = "Đột\n56*112";
            Dot56_112_Kg.Caption = "Đột\n56*112";
            Dot42_84_Bao.Caption = "Đột\n42*84";
            Dot42_84_Kg.Caption = "Đột\n42*84";
            Dot51_103_Bao.Caption = "Đột\n51*103";
            Dot51_103_Kg.Caption = "Đột\n51*103";
            Dot51_103tb_Bao.Caption = "Đột\n51*103tb";
            Dot51_103tb_Kg.Caption = "Đột\n51*103tb";
            Dot53_106tb_Bao.Caption = "Đột\n53*106tb";
            Dot53_106tb_Kg.Caption = "Đột\n53*106tb";
            Dot50_100tb_Bao.Caption = "Đột\n50*100tb";
            Dot50_100tb_Kg.Caption = "Đột\n50*100tb";
            Dot11_17tb_Bao.Caption = "Đột\n11*17tb";
            Dot11_17tb_Kg.Caption = "Đột\n11*17tb";
            Dot45_90tb_Bao.Caption = "Đột\n45*90tb";
            Dot45_90tb_Kg.Caption = "Đột\n45*90tb";
            Dot42_84tb_Bao.Caption = "Đột\n42*84tb";
            Dot42_84tb_Kg.Caption = "Đột\n42*84tb";
            TongBao.Caption = "Tổng\n(Bao)";
            TongKg.Caption = "Tổng\n(Kg)";
            DonGia_Tan.Caption = "Đơn giá\n/tấn";
            TongBaotb.Caption = "Tổng tb\n(Bao)";
            TongKgtb.Caption = "Tổng tb\n(Kg)";
            DonGiatb_Tan.Caption = "Đơn giá tb\n/tấn";
            ThanhTien.Caption = "Thành\ntiền";
        }
       
        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            if (islandau)
            { 
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }
            else
            {
            }
            double Dot4_8_Bao_Tong = 0;
            double Dot4_8_Kg_Tong = 0;
            double Dot36_72_Bao_Tong = 0;
            double Dot36_72_Kg_Tong = 0;
            double Dot45_90_Bao_Tong = 0;
            double Dot45_90_Kg_Tong = 0;
            double Dot48_96_Bao_Tong = 0;
            double Dot48_96_Kg_Tong = 0;
            double Dot56_112_Bao_Tong = 0;
            double Dot56_112_Kg_Tong = 0;
            double Dot42_84_Bao_Tong = 0;
            double Dot42_84_Kg_Tong = 0;
            double Dot51_103_Bao_Tong = 0;
            double Dot51_103_Kg_Tong = 0;
            double Dot51_103tb_Bao_Tong = 0;
            double Dot51_103tb_Kg_Tong = 0;
            double Dot53_106tb_Bao_Tong = 0;
            double Dot53_106tb_Kg_Tong = 0;
            double Dot50_100tb_Bao_Tong = 0;
            double Dot50_100tb_Kg_Tong = 0;
            double Dot11_17tb_Bao_Tong = 0;
            double Dot11_17tb_Kg_Tong = 0;
            double Dot45_90tb_Bao_Tong = 0;
            double Dot45_90tb_Kg_Tong = 0;
            double Dot42_84tb_Bao_Tong = 0;
            double Dot42_84tb_Kg_Tong = 0;
            double TongBao_Tong = 0;
            double TongKg_Tong = 0;
            double TongBaotb_Tong = 0;
            double TongKgtb_Tong = 0;
            double ThanhTien_Tong = 0;

            using (clsThin clsThin_ = new clsThin())
            {
                _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDot_DongBao(_nam, _thang, 0, 0, 1, _id_bophan, radioTo1.Checked, radioTo2.Checked);
                //Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 0, 1, CaLamViec, _id_bophan);

                int ngaycuathang_ = (((new DateTime(_nam, _thang, 1)).AddMonths(1)).AddDays(-1)).Day;
                for (int i = 1; i <= ngaycuathang_; i++)
                {
                    ModelBTTL_ToDot ng = getSanLuong_Ngay(i, _dtSL_Ca1);
                    DataRow row = _data.NewRow();
                    row["NgayThang"] = ng.NgayThang;
                    row["DonViTinh"] = ng.DonViTinh;
                    row["Dot4_8_Bao"] = ng.Dot4_8_Bao.ToString("N1");
                    row["Dot4_8_Kg"] = ng.Dot4_8_Kg.ToString("N1");
                    row["Dot36_72_Bao"] = ng.Dot36_72_Bao.ToString("N1");
                    row["Dot36_72_Kg"] = ng.Dot36_72_Kg.ToString("N1");
                    row["Dot45_90_Bao"] = ng.Dot45_90_Bao.ToString("N1");
                    row["Dot45_90_Kg"] = ng.Dot45_90_Kg.ToString("N1");
                    row["Dot48_96_Bao"] = ng.Dot48_96_Bao.ToString("N1");
                    row["Dot48_96_Kg"] = ng.Dot48_96_Kg.ToString("N1");
                    row["Dot56_112_Bao"] = ng.Dot56_112_Bao.ToString("N1");
                    row["Dot56_112_Kg"] = ng.Dot56_112_Kg.ToString("N1");
                    row["Dot42_84_Bao"] = ng.Dot42_84_Bao.ToString("N1");
                    row["Dot42_84_Kg"] = ng.Dot42_84_Kg.ToString("N1");
                    row["Dot51_103_Bao"] = ng.Dot51_103_Bao.ToString("N1");
                    row["Dot51_103_Kg"] = ng.Dot51_103_Kg.ToString("N1");
                    row["Dot51_103tb_Bao"] = ng.Dot51_103tb_Bao.ToString("N1");
                    row["Dot51_103tb_Kg"] = ng.Dot51_103tb_Kg.ToString("N1");
                    row["Dot53_106tb_Bao"] = ng.Dot53_106tb_Bao.ToString("N1");
                    row["Dot53_106tb_Kg"] = ng.Dot53_106tb_Kg.ToString("N1");
                    row["Dot50_100tb_Bao"] = ng.Dot50_100tb_Bao.ToString("N1");
                    row["Dot50_100tb_Kg"] = ng.Dot50_100tb_Kg.ToString("N1");
                    row["Dot11_17tb_Bao"] = ng.Dot11_17tb_Bao.ToString("N1");
                    row["Dot11_17tb_Kg"] = ng.Dot11_17tb_Kg.ToString("N1");
                    row["Dot45_90tb_Bao"] = ng.Dot45_90tb_Bao.ToString("N1");
                    row["Dot45_90tb_Kg"] = ng.Dot45_90tb_Kg.ToString("N1");
                    row["Dot42_84tb_Bao"] = ng.Dot42_84tb_Bao.ToString("N1");
                    row["Dot42_84tb_Kg"] = ng.Dot42_84tb_Kg.ToString("N1");
                    row["TongBao"] = ng.TongBao.ToString("N1");
                    row["TongKg"] = ng.TongKg.ToString("N1");
                    row["DonGia_Tan"] = ng.DonGia_Tan.ToString("N1");
                    row["TongBaotb"] = ng.TongBaotb.ToString("N1");
                    row["TongKgtb"] = ng.TongKgtb.ToString("N1");
                    row["DonGiatb_Tan"] = ng.DonGiatb_Tan.ToString("N1");
                    row["ThanhTien"] = ng.ThanhTien.ToString("N1");
                    if (ng.TongBaotb > 0 || ng.TongBao > 0)
                        _data.Rows.Add(row);

                    //Cộng tổng:
                    Dot4_8_Bao_Tong  += ng.Dot4_8_Bao;
                    Dot4_8_Kg_Tong  += ng.Dot4_8_Kg;
                    Dot36_72_Bao_Tong  += ng.Dot36_72_Bao;
                    Dot36_72_Kg_Tong  += ng.Dot36_72_Kg;
                    Dot45_90_Bao_Tong  += ng.Dot45_90_Bao;
                    Dot45_90_Kg_Tong  += ng.Dot45_90_Kg;
                    Dot48_96_Bao_Tong  += ng.Dot48_96_Bao;
                    Dot48_96_Kg_Tong  += ng.Dot48_96_Kg;
                    Dot56_112_Bao_Tong  += ng.Dot56_112_Bao;
                    Dot56_112_Kg_Tong  += ng.Dot56_112_Kg;
                    Dot42_84_Bao_Tong  += ng.Dot42_84_Bao;
                    Dot42_84_Kg_Tong  += ng.Dot42_84_Kg;
                    Dot51_103_Bao_Tong  += ng.Dot51_103_Bao;
                    Dot51_103_Kg_Tong  += ng.Dot51_103_Kg;
                    Dot51_103tb_Bao_Tong += ng.Dot51_103tb_Bao;
                    Dot51_103tb_Kg_Tong += ng.Dot51_103tb_Kg;
                    Dot53_106tb_Bao_Tong  += ng.Dot53_106tb_Bao;
                    Dot53_106tb_Kg_Tong  += ng.Dot53_106tb_Kg;
                    Dot50_100tb_Bao_Tong += ng.Dot50_100tb_Bao;
                    Dot50_100tb_Kg_Tong += ng.Dot50_100tb_Kg;
                    Dot11_17tb_Bao_Tong  += ng.Dot11_17tb_Bao;
                    Dot11_17tb_Kg_Tong  += ng.Dot11_17tb_Kg;
                    Dot45_90tb_Bao_Tong  += ng.Dot45_90tb_Bao;
                    Dot45_90tb_Kg_Tong  += ng.Dot45_90tb_Kg;
                    Dot42_84tb_Bao_Tong  += ng.Dot42_84tb_Bao;
                    Dot42_84tb_Kg_Tong  += ng.Dot42_84tb_Kg;
                    TongBao_Tong  += ng.TongBao;
                    TongKg_Tong  += ng.TongKg;
                    TongBaotb_Tong  += ng.TongBaotb;
                    TongKgtb_Tong  += ng.TongKgtb;
                    ThanhTien_Tong  += ng.ThanhTien;
                }

                //
                DataRow row_tong = _data.NewRow();
                row_tong["NgayThang"] = "Tổng";
                row_tong["DonViTinh"] = "";
                row_tong["Dot4_8_Bao"] = Dot4_8_Bao_Tong.ToString("N1");
                row_tong["Dot4_8_Kg"] = Dot4_8_Kg_Tong.ToString("N1");
                row_tong["Dot36_72_Bao"] = Dot36_72_Bao_Tong.ToString("N1");
                row_tong["Dot36_72_Kg"] = Dot36_72_Kg_Tong.ToString("N1");
                row_tong["Dot45_90_Bao"] = Dot45_90_Bao_Tong.ToString("N1");
                row_tong["Dot45_90_Kg"] = Dot45_90_Kg_Tong.ToString("N1");
                row_tong["Dot48_96_Bao"] = Dot48_96_Bao_Tong.ToString("N1");
                row_tong["Dot48_96_Kg"] = Dot48_96_Kg_Tong.ToString("N1");
                row_tong["Dot56_112_Bao"] = Dot56_112_Bao_Tong.ToString("N1");
                row_tong["Dot56_112_Kg"] = Dot56_112_Kg_Tong.ToString("N1");
                row_tong["Dot42_84_Bao"] = Dot42_84_Bao_Tong.ToString("N1");
                row_tong["Dot42_84_Kg"] = Dot42_84_Kg_Tong.ToString("N1");
                row_tong["Dot51_103_Bao"] = Dot51_103_Bao_Tong.ToString("N1");
                row_tong["Dot51_103_Kg"] = Dot51_103_Kg_Tong.ToString("N1");
                row_tong["Dot51_103tb_Bao"] = Dot51_103tb_Bao_Tong.ToString("N1");
                row_tong["Dot51_103tb_Kg"] = Dot51_103tb_Kg_Tong.ToString("N1");
                row_tong["Dot53_106tb_Bao"] = Dot53_106tb_Bao_Tong.ToString("N1");
                row_tong["Dot53_106tb_Kg"] = Dot53_106tb_Kg_Tong.ToString("N1");
                row_tong["Dot50_100tb_Bao"] = Dot50_100tb_Bao_Tong.ToString("N1");
                row_tong["Dot50_100tb_Kg"] = Dot50_100tb_Kg_Tong.ToString("N1");
                row_tong["Dot11_17tb_Bao"] = Dot11_17tb_Bao_Tong.ToString("N1");
                row_tong["Dot11_17tb_Kg"] = Dot11_17tb_Kg_Tong.ToString("N1");
                row_tong["Dot45_90tb_Bao"] = Dot45_90tb_Bao_Tong.ToString("N1");
                row_tong["Dot45_90tb_Kg"] = Dot45_90tb_Kg_Tong.ToString("N1");
                row_tong["Dot42_84tb_Bao"] = Dot42_84tb_Bao_Tong.ToString("N1");
                row_tong["Dot42_84tb_Kg"] = Dot42_84tb_Kg_Tong.ToString("N1");
                row_tong["TongBao"] = TongBao_Tong.ToString("N1");
                row_tong["TongKg"] = TongKg_Tong.ToString("N1");
                row_tong["DonGia_Tan"] = "";
                row_tong["TongBaotb"] = TongBaotb_Tong.ToString("N1");
                row_tong["TongKgtb"] = TongKgtb_Tong.ToString("N1");
                row_tong["DonGiatb_Tan"] = "";
                row_tong["ThanhTien"] = ThanhTien_Tong.ToString("N1");
                _data.Rows.Add(row_tong);
            }

            gridControl1.DataSource = _data;
            isload = false;
        }

        private ModelBTTL_ToDot getSanLuong_Ngay(int Ngay, DataTable dt)
        {
            ModelBTTL_ToDot nv = new ModelBTTL_ToDot();
            string DonViTinh = "";
            double Dot4_8_Bao = 0;
            double Dot4_8_Kg = 0;
            double Dot36_72_Bao = 0;
            double Dot36_72_Kg = 0;
            double Dot45_90_Bao = 0;
            double Dot45_90_Kg = 0;
            double Dot48_96_Bao = 0;
            double Dot48_96_Kg = 0;
            double Dot56_112_Bao = 0;
            double Dot56_112_Kg = 0;
            double Dot42_84_Bao = 0;
            double Dot42_84_Kg = 0;
            double Dot51_103_Bao = 0;
            double Dot51_103_Kg = 0;
            double Dot51_103tb_Bao = 0;
            double Dot51_103tb_Kg = 0;
            double Dot53_106tb_Bao = 0;
            double Dot53_106tb_Kg = 0;
            double Dot50_100tb_Bao = 0;
            double Dot50_100tb_Kg = 0;
            double Dot11_17tb_Bao = 0;
            double Dot11_17tb_Kg = 0;
            double Dot45_90tb_Bao = 0;
            double Dot45_90tb_Kg = 0;
            double Dot42_84tb_Bao = 0;
            double Dot42_84tb_Kg = 0;
            double TongBao = 0;
            double TongKg = 0;
            double DonGia_Tan = 0;
            double TongBaotb = 0;
            double TongKgtb = 0;
            double DonGiatb_Tan = 0;
            List<int> dsNgayCong = new List<int>();

            foreach (DataRow item in dt.Rows)
            {
                int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;
                

                if (NgaySX == Ngay)
                {
                    double SoKG_MotBao_May_Dot = CheckString.ConvertToDouble_My(item["SoKG_MotBao_May_Dot"].ToString());
                    double SanLuong_Tong = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                    int idvthh = Convert.ToInt32(item["ID_VTHH_Ra"].ToString());
                    string tenVTHH = (CheckString.ChuanHoaHoTen(item["TenVTHH"].ToString())).ToLower().Replace(" ", "");
                    string loaiVthh = getLoaiVthh(tenVTHH);
                    DonViTinh = item["DonViTinh"].ToString();

                    switch (loaiVthh)
                    {
                        case "Dot53_106tb":
                            Dot53_106tb_Bao += SanLuong_Tong;
                            Dot53_106tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot50_100tb":
                            Dot50_100tb_Bao += SanLuong_Tong;
                            Dot50_100tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot51_103tb":
                            Dot51_103tb_Bao += SanLuong_Tong;
                            Dot51_103tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot11_17tb":
                            Dot11_17tb_Bao += SanLuong_Tong;
                            Dot11_17tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot45_90tb":
                            Dot45_90tb_Bao += SanLuong_Tong;
                            Dot45_90tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot42_84tb":
                            Dot42_84tb_Bao += SanLuong_Tong;
                            Dot42_84tb_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGiatb_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBaotb += SanLuong_Tong;
                            TongKgtb += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot51_103":
                            Dot51_103_Bao += SanLuong_Tong;
                            Dot51_103_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot56_112":
                            Dot56_112_Bao += SanLuong_Tong;
                            Dot56_112_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot42_84":
                            Dot42_84_Bao += SanLuong_Tong;
                            Dot42_84_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot48_96":
                            Dot48_96_Bao += SanLuong_Tong;
                            Dot48_96_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot45_90":
                            Dot45_90_Bao += SanLuong_Tong;
                            Dot45_90_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot36_72":
                            Dot36_72_Bao += SanLuong_Tong;
                            Dot36_72_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;

                        case "Dot4_8":
                            Dot4_8_Bao += SanLuong_Tong;
                            Dot4_8_Kg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            DonGia_Tan = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
                            TongBao += SanLuong_Tong;
                            TongKg += (SanLuong_Tong * SoKG_MotBao_May_Dot);
                            break;
                    }
                }
            }

            nv.NgayThang = Ngay;
            nv.DonViTinh = DonViTinh;
            nv.Dot4_8_Bao = Dot4_8_Bao;
            nv.Dot4_8_Kg = Dot4_8_Kg;
            nv.Dot36_72_Bao = Dot36_72_Bao;
            nv.Dot36_72_Kg = Dot36_72_Kg;
            nv.Dot45_90_Bao = Dot45_90_Bao;
            nv.Dot45_90_Kg = Dot45_90_Kg;
            nv.Dot48_96_Bao = Dot48_96_Bao;
            nv.Dot48_96_Kg = Dot48_96_Kg;
            nv.Dot56_112_Bao = Dot56_112_Bao;
            nv.Dot56_112_Kg = Dot56_112_Kg;
            nv.Dot42_84_Bao = Dot42_84_Bao;
            nv.Dot42_84_Kg = Dot42_84_Kg;
            nv.Dot51_103_Bao = Dot51_103_Bao;
            nv.Dot51_103_Kg = Dot51_103_Kg;
            nv.Dot51_103tb_Bao = Dot51_103tb_Bao;
            nv.Dot51_103tb_Kg = Dot51_103tb_Kg;
            nv.Dot53_106tb_Bao = Dot53_106tb_Bao;
            nv.Dot53_106tb_Kg = Dot53_106tb_Kg;
            nv.Dot50_100tb_Bao = Dot50_100tb_Bao;
            nv.Dot50_100tb_Kg = Dot50_100tb_Kg;
            nv.Dot11_17tb_Bao = Dot11_17tb_Bao;
            nv.Dot11_17tb_Kg = Dot11_17tb_Kg;
            nv.Dot45_90tb_Bao = Dot45_90tb_Bao;
            nv.Dot45_90tb_Kg = Dot45_90tb_Kg;
            nv.Dot42_84tb_Bao = Dot42_84tb_Bao;
            nv.Dot42_84tb_Kg = Dot42_84tb_Kg;
            nv.TongBao = TongBao;
            nv.TongKg = TongKg;
            nv.DonGia_Tan = DonGia_Tan * 1000;
            nv.TongBaotb = TongBaotb;
            nv.TongKgtb = TongKgtb;
            nv.DonGiatb_Tan = DonGiatb_Tan * 1000;
            nv.ThanhTien = (TongKg * DonGia_Tan) + (TongKgtb * DonGiatb_Tan);

            return nv;
        }

        private string getLoaiVthh(string tenVthh)
        {
            string result = "";
            if (tenVthh.Contains("53*106tb") || tenVthh.Contains("53x106tb") || tenVthh.Contains("53-106tb")
                || (tenVthh.Contains("53*106") && tenVthh.Contains("gtb")) || (tenVthh.Contains("53*106") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("53x106") && tenVthh.Contains("gtb")) || (tenVthh.Contains("53x106") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot53_106tb";
            }
            if (tenVthh.Contains("50*100tb") || tenVthh.Contains("50x100tb") || tenVthh.Contains("50-100tb")
                || (tenVthh.Contains("50*100") && tenVthh.Contains("gtb")) || (tenVthh.Contains("50*100") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("50x100") && tenVthh.Contains("gtb")) || (tenVthh.Contains("50x100") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot50_100tb";
            }
            else if (tenVthh.Contains("51*103tb") || tenVthh.Contains("51x103tb") || tenVthh.Contains("51-103tb")
                || (tenVthh.Contains("51*103") && tenVthh.Contains("gtb")) || (tenVthh.Contains("51*103") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("51x103") && tenVthh.Contains("gtb")) || (tenVthh.Contains("51x103") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot51_103tb";
            }
            else if (tenVthh.Contains("11*17tb") || tenVthh.Contains("11x17tb") || tenVthh.Contains("11-17tb")
                || (tenVthh.Contains("11*17") && tenVthh.Contains("gtb")) || (tenVthh.Contains("11*17") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("11x17") && tenVthh.Contains("gtb")) || (tenVthh.Contains("11x17") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot11_17tb";
            }
            else if (tenVthh.Contains("45*90tb") || tenVthh.Contains("45x90tb") || tenVthh.Contains("45-90tb")
                || (tenVthh.Contains("45*90") && tenVthh.Contains("gtb")) || (tenVthh.Contains("45*90") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("45x90") && tenVthh.Contains("gtb")) || (tenVthh.Contains("45x90") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot45_90tb";
            }
            else if (tenVthh.Contains("42*84tb") || tenVthh.Contains("42x84tb") || tenVthh.Contains("42-84tb")
                || (tenVthh.Contains("42*84") && tenVthh.Contains("gtb")) || (tenVthh.Contains("42*84") && tenVthh.Contains("trúcbách"))
                || (tenVthh.Contains("42x84") && tenVthh.Contains("gtb")) || (tenVthh.Contains("42x84") && tenVthh.Contains("trúcbách")))
            {
                result = "Dot42_84tb";
            }
            else if (tenVthh.Contains("51*103") || tenVthh.Contains("51x103") || tenVthh.Contains("51-103"))
            {
                result = "Dot51_103";
            }
            else if (tenVthh.Contains("56*112") || tenVthh.Contains("56x112") || tenVthh.Contains("56-112"))
            {
                result = "Dot56_112";
            }
            else if (tenVthh.Contains("42*84") || tenVthh.Contains("42x84") || tenVthh.Contains("42-84"))
            {
                result = "Dot42_84";
            }
            else if (tenVthh.Contains("48*96") || tenVthh.Contains("48x96") || tenVthh.Contains("48-96"))
            {
                result = "Dot48_96";
            }
            else if (tenVthh.Contains("45*90") || tenVthh.Contains("45x90") || tenVthh.Contains("45-90"))
            {
                result = "Dot45_90";
            }
            else if (tenVthh.Contains("36*72") || tenVthh.Contains("36x72") || tenVthh.Contains("36-72"))
            {
                result = "Dot36_72";
            }
            else if (tenVthh.Contains("4*8") || tenVthh.Contains("4x8") || tenVthh.Contains("4-8"))
            {
                result = "Dot4_8";
            }
            return result;
        }


        private void Tr_frmBTTL_ToDot_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //int index_ = e.RowHandle;
            //string name_ = e.Column.FieldName;
            //if (name_.Contains("Ngay"))
            //{
            //    _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
            //    _data.Rows[index_][name_] = String.Format("{0:0.##}", CheckString.ConvertToDouble_My(_data.Rows[index_][name_].ToString()));
            //    if (_data.Rows.Count > index_)
            //    {
            //        CongTong_Row(index_);
            //    }
            //    //SendKeys.Send("{DOWN}");
            //}
            //else if (name_.Contains("TenVTHH"))
            //{
            //    if (gridView1.GetFocusedRowCellValue(name_) == null)
            //    {
            //        _data.Rows[index_][name_] = "";
            //    }
            //    else
            //    {
            //        _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
            //    }
            //}
            //CongTong();

            //if (!_data.Rows[index_]["TenNhanVien"].ToString().ToLower().Contains("tổng")) SaveOneCN_Datarow(_data.Rows[index_]);
        }

        //CongTong_Row(index_);
        private void CongTong_Row (int index)
        {
            double tong_row = 0;

            for (int j = 0; j < 31; ++j)
            {
                tong_row += CheckString.ConvertToDouble_My(_data.Rows[index]["Ngay" + (j + 1)].ToString());
            }

            _data.Rows[index]["Tong"] = String.Format("{0:0.##}", tong_row);
        }

        private void CongTong()
        {
            double[] _ds_ngay_tong_ = new double[31];
            double tong_tong_ = 0;
            for (int i = 0; i < _data.Rows.Count - 1; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    _ds_ngay_tong_[j] += CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay" + (j + 1)].ToString());
                }
                tong_tong_ += CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString());
            }
            for (int j = 0; j < 31; ++j)
            {
                _data.Rows[_data.Rows.Count - 1]["Ngay" + (j + 1)] = String.Format("{0:0.##}", _ds_ngay_tong_[j]);
            }
            _data.Rows[_data.Rows.Count - 1]["Tong"] = String.Format("{0:0.##}",tong_tong_);
            gridControl1.DataSource = _data;
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhThang();
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhThang();
        }
        private void HoanThanhThang()
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);

                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HoanThanhNam()
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);

                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Năm không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            int count_ = _data.Rows.Count;
            if (count_ > 1)
            {
                for(int i = 2; i < 34; i++)
                {
                    if(CheckString.ConvertToDouble_My(_data.Rows[count_ - 1][i].ToString()) > 0)
                    {
                        _colDelete[i - 2] = 0; //Không xóa
                    }
                    else _colDelete[i - 2] = 1; //Xóa
                }
                _colDelete[28] = 0; //col Đơn giá Bao
                _colDelete[31] = 0; //col Đơn giá tb

                CtyTinLuong.Tr_frmPrintBTTL_ToDot ff = new CtyTinLuong.Tr_frmPrintBTTL_ToDot(_thang, _nam, _data, _colDelete, radioTo1.Checked);
                ff.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "Tr_frmBTTL_ToDot", this);
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  NgayThang)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ////int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                ////_MaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
                ////Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "Tr_frmBTTL_ToDot", this);
                ////ff.Show();
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioTo1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTo1.Checked)
                _CaLamViec = "Ca 1";
            else
                _CaLamViec = "Ca 2";

            if (isload)
                return;
            LoadData(false);
        }

        private void radioTo2_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioTo2.Checked)
            //    _CaLamViec = "Ca 2";
            //else
            //    _CaLamViec = "Ca 1";

            //if (isload)
            //    return;
            //LoadData(false);
        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa công nhân khỏi bảng..." +ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                if (e.Column.FieldName == "Xoa")
                {
                    e.RepositoryItem = emptyEditor;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}

