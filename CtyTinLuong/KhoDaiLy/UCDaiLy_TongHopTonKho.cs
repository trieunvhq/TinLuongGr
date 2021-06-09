using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCDaiLy_TongHopTonKho : UserControl
    {


        public static int miID_VTHH;
        public static DateTime mdadenngay;
       public DataTable TinhToanSoLuong_Nhap_Xuat_TrongKy(DateTime denngayxxx)
        {

            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new CtyTinLuong.clsDaiLy_tbChiTietXuatKho();
            DataTable dtDISTINCT = cls1.SelectAll_distinct();
            DataTable dtnpl = new DataTable();
            dtnpl.Columns.Add("ID_VTHH", typeof(int));        
            dtnpl.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dtnpl.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    DataTable adt1 = new DataTable();
                    adt1.Columns.Add("ID_VTHH", typeof(int));
                    adt1.Columns.Add("SoLuongNhap_TrongKy", typeof(double));                

                    DataTable bdt1 = new DataTable();
                    bdt1.Columns.Add("ID_VTHH", typeof(int));                   
                    bdt1.Columns.Add("SoLuongXuat_TrongKy", typeof(double));

                    int ID_VTHH = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_VTHH"].ToString());

                    cls1.iID_VTHH = ID_VTHH;
                    DataTable dxxxx = cls1.Select_One_NXT_TinhToan_newwwwww();
                    dxxxx.DefaultView.RowFilter = " DaNhapKho= True and boolTonDauKy = False and NgayChungTu<='" + denngayxxx + "'";
                    DataView dv = dxxxx.DefaultView;
                    DataTable dtnhap = dv.ToTable();

                    cls2.iID_VTHH = ID_VTHH;
                    DataTable dxxxx22222 = cls2.Select_One_NXT_TinhToan_newwwwww();
                    dxxxx22222.DefaultView.RowFilter = " DaXuatKho= True and NgayChungTu<='" + denngayxxx + "'";
                    DataView dv222222 = dxxxx22222.DefaultView;
                    DataTable dtxuat = dv222222.ToTable();
                    if (dtnhap.Rows.Count>0) 
                    {
                        for (int j = 0; j < dtnhap.Rows.Count; j++)
                        {
                            double SoLuongNhap_TrongKy;                         
                            SoLuongNhap_TrongKy = Convert.ToDouble(dtnhap.Rows[j]["SoLuongNhap"].ToString());                         
                            DataRow _ravinhap = adt1.NewRow();
                            _ravinhap["ID_VTHH"] = ID_VTHH;
                            _ravinhap["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;                          
                            adt1.Rows.Add(_ravinhap);
                        }
                        double deSoLuongNhap_TrongKy;
                        object xxdeSoLuongNhap_TrongKy = adt1.Compute("sum(SoLuongNhap_TrongKy)", "ID_VTHH=" + ID_VTHH + "");
                        deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);

                        if (dtxuat.Rows.Count > 0) // có xuất
                        {
                            for (int k = 0; k < dtxuat.Rows.Count; k++)
                            {
                                double SoLuongXuat_TrongKy;
                                SoLuongXuat_TrongKy = Convert.ToDouble(dtxuat.Rows[k]["SoLuongXuat"].ToString());
                                DataRow _ravixuat = bdt1.NewRow();
                                _ravixuat["ID_VTHH"] = ID_VTHH;
                                _ravixuat["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                                bdt1.Rows.Add(_ravixuat);
                            }

                            double deSoLuongXuat_TrongKy;
                            object xxdeSoLuongXuat_TrongKy = bdt1.Compute("sum(SoLuongXuat_TrongKy)", "ID_VTHH=" + ID_VTHH + "");
                            deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);

                            DataRow _ravi2 = dtnpl.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHH;
                            _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
                            _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
                            dtnpl.Rows.Add(_ravi2);
                        }
                        else // khong có xuất
                        {
                            DataRow _ravi2 = dtnpl.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHH;
                            _ravi2["SoLuongNhap_TrongKy"] = deSoLuongNhap_TrongKy;
                            _ravi2["SoLuongXuat_TrongKy"] = 0;
                            dtnpl.Rows.Add(_ravi2);
                        }
                        
                    }
                    else // không có nhập
                    {
                        if (dtxuat.Rows.Count > 0) // có xuất
                        {
                            for (int k = 0; k < dtxuat.Rows.Count; k++)
                            {
                                double SoLuongXuat_TrongKy;
                                SoLuongXuat_TrongKy = Convert.ToDouble(dtxuat.Rows[k]["SoLuongXuat"].ToString());
                                DataRow _ravixuat = bdt1.NewRow();
                                _ravixuat["ID_VTHH"] = ID_VTHH;
                                _ravixuat["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                                bdt1.Rows.Add(_ravixuat);
                            }

                            double deSoLuongXuat_TrongKy;
                            object xxdeSoLuongXuat_TrongKy = bdt1.Compute("sum(SoLuongXuat_TrongKy)", "ID_VTHH=" + ID_VTHH + "");
                            deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
                                                        
                            DataRow _ravi2 = dtnpl.NewRow();
                            _ravi2["ID_VTHH"] = ID_VTHH;
                            _ravi2["SoLuongNhap_TrongKy"] = 0;
                            _ravi2["SoLuongXuat_TrongKy"] = deSoLuongXuat_TrongKy;
                            dtnpl.Rows.Add(_ravi2);
                        }
                            
                    }
                   
                }
            }
        
            return dtnpl;
        }
        
        public DataTable tinhtoanNXT_Ton_DauKy()
        {
            clsDaiLy_tbChiTietNhapKho cls = new clsDaiLy_tbChiTietNhapKho();
            DataTable dxxxx = cls.SelectAll();
            dxxxx.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false and boolTonDauKy = True";
            DataView dv = dxxxx.DefaultView;

            DataTable dt = dv.ToTable();

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("GiaTri_TonDauKy", typeof(double));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    double SoLuong_TonDauKy;
                    double DonGia_TonDauKy;
                    double GiaTri_TonDauKy;
                    SoLuong_TonDauKy = Convert.ToDouble(dt.Rows[i]["SoLuongNhap"].ToString());
                    DonGia_TonDauKy = Convert.ToDouble(dt.Rows[i]["DonGia"].ToString());
                    GiaTri_TonDauKy = DonGia_TonDauKy * SoLuong_TonDauKy;
                    int ID_VTHHxx = Convert.ToInt32(dt.Rows[i]["ID_VTHH"].ToString());
                    clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                    clsvt.iID_VTHH = ID_VTHHxx;
                    DataTable dtvt = clsvt.SelectOne();
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = Convert.ToDouble(dt.Rows[i]["ID_VTHH"].ToString());
                    _ravi["MaVT"] = clsvt.sMaVT.Value;
                    _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                    _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["GiaTri_TonDauKy"] = GiaTri_TonDauKy;
                    dt2.Rows.Add(_ravi);
                }
            }

            return dt2;


        }
        private void HienThixxxxxxxxxxxxxxxxxxxx()
        {
            DateTime denngay = dteDenNgay.DateTime;
            DataTable dtrongky = TinhToanSoLuong_Nhap_Xuat_TrongKy(denngay);
            DataTable dtTonDauKy = tinhtoanNXT_Ton_DauKy();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            for (int i = 0; i < dtrongky.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy;
                double SoLuongNhap_TrongKy;
                double SoLuongXuat_TrongKy;
                double SoLuongTon_CuoiKy;
                SoLuongNhap_TrongKy = Convert.ToDouble(dtrongky.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                SoLuongXuat_TrongKy = Convert.ToDouble(dtrongky.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                iiiiiID_VTHH = Convert.ToInt16(dtrongky.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dtTonDauKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = 0;
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                    clsvt.iID_VTHH = iiiiiID_VTHH;
                    DataTable dtvt = clsvt.SelectOne();
                    _ravi["MaVT"] = clsvt.sMaVT.Value;
                    _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                    _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    dt2.Rows.Add(_ravi);
                }
                else
                {
                    //clsDaiLy_tbChiTiet_TonDauKy cls = new clsDaiLy_tbChiTiet_TonDauKy();
                    //cls.iID_VTHH = iiiiiID_VTHH;
                    //DataTable dt = cls.SelectOne_SelectOne_W_ID_VTHH();
                    //SoLuong_TonDauKy = Convert.ToDouble(dt.Rows[0]["SoLuong"].ToString());
                    //double dongiatondauky = Convert.ToDouble(dt.Rows[0]["DonGia"].ToString());
                    //SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;

                    //DataRow _ravi = dt2.NewRow();
                    //_ravi["ID_VTHH"] = iiiiiID_VTHH;
                    //clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                    //clsvt.iID_VTHH = iiiiiID_VTHH;
                    //DataTable dtvt = clsvt.SelectOne();
                    //_ravi["MaVT"] = clsvt.sMaVT.Value;
                    //_ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                    //_ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                    //_ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    //_ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                    //_ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    //_ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    //dt2.Rows.Add(_ravi);
                }
            }
            for (int i = 0; i < dtTonDauKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy;
                double SoLuongNhap_TrongKy;
                double SoLuongXuat_TrongKy;
                double SoLuongTon_CuoiKy;
                SoLuongNhap_TrongKy = 0;
                SoLuongXuat_TrongKy = 0;
                iiiiiID_VTHH = Convert.ToInt16(dtTonDauKy.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dtrongky.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["SoLuong_TonDauKy"].ToString());
                    SoLuongNhap_TrongKy = 0;
                    SoLuongXuat_TrongKy = 0;
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                    clsvt.iID_VTHH = iiiiiID_VTHH;
                    DataTable dtvt = clsvt.SelectOne();
                    _ravi["MaVT"] = clsvt.sMaVT.Value;
                    _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                    _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    dt2.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = dt2;

        }
        private void HienThi()
        {
            DateTime denngay = dteDenNgay.DateTime;
            DataTable dtrongky = TinhToanSoLuong_Nhap_Xuat_TrongKy(denngay);            
            DataTable dtTonDauKy = tinhtoanNXT_Ton_DauKy();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("DonViTinh", typeof(string));
            dt2.Columns.Add("SoLuong_TonDauKy", typeof(double));         
            dt2.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
            dt2.Columns.Add("SoLuongTon_CuoiKy", typeof(double));
            for (int i = 0; i < dtrongky.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy;
                double SoLuongNhap_TrongKy;
                double SoLuongXuat_TrongKy;
                double SoLuongTon_CuoiKy;
                SoLuong_TonDauKy = SoLuongNhap_TrongKy = SoLuongXuat_TrongKy = SoLuongTon_CuoiKy = 0;

                SoLuongNhap_TrongKy = Convert.ToDouble(dtrongky.Rows[i]["SoLuongNhap_TrongKy"].ToString());
                SoLuongXuat_TrongKy = Convert.ToDouble(dtrongky.Rows[i]["SoLuongXuat_TrongKy"].ToString());
                iiiiiID_VTHH = Convert.ToInt16(dtrongky.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dtTonDauKy.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = 0;                 
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;              
                 
                }
                else
                {
                    SoLuong_TonDauKy= Convert.ToDouble(rows[0]["SoLuong_TonDauKy"].ToString());  
                    //SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[0]["SoLuong"].ToString());                        
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;               
                }

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_VTHH"] = iiiiiID_VTHH;
                clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                clsvt.iID_VTHH = iiiiiID_VTHH;
                DataTable dtvt = clsvt.SelectOne();
                _ravi["MaVT"] = clsvt.sMaVT.Value;
                _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                dt2.Rows.Add(_ravi);
            }
            for (int i = 0; i < dtTonDauKy.Rows.Count; i++)
            {
                int iiiiiID_VTHH;
                double SoLuong_TonDauKy;              
                double SoLuongNhap_TrongKy;
                double SoLuongXuat_TrongKy;
                double SoLuongTon_CuoiKy;
                SoLuongNhap_TrongKy = 0;
                SoLuongXuat_TrongKy = 0;
                iiiiiID_VTHH = Convert.ToInt16(dtTonDauKy.Rows[i]["ID_VTHH"].ToString());
                string filterExpression = "ID_VTHH=" + iiiiiID_VTHH + "";
                DataRow[] rows = dtrongky.Select(filterExpression);
                if (rows.Length == 0)
                {
                    SoLuong_TonDauKy = Convert.ToDouble(dtTonDauKy.Rows[i]["SoLuong_TonDauKy"].ToString());
                    SoLuongNhap_TrongKy = 0;
                    SoLuongXuat_TrongKy = 0;
                    SoLuongTon_CuoiKy = SoLuong_TonDauKy + SoLuongNhap_TrongKy - SoLuongXuat_TrongKy;
                    DataRow _ravi = dt2.NewRow();
                    _ravi["ID_VTHH"] = iiiiiID_VTHH;
                    clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
                    clsvt.iID_VTHH = iiiiiID_VTHH;
                    DataTable dtvt = clsvt.SelectOne();
                    _ravi["MaVT"] = clsvt.sMaVT.Value;
                    _ravi["TenVTHH"] = clsvt.sTenVTHH.Value;
                    _ravi["DonViTinh"] = clsvt.sDonViTinh.Value;
                    _ravi["SoLuong_TonDauKy"] = SoLuong_TonDauKy;
                    _ravi["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                    _ravi["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                    _ravi["SoLuongTon_CuoiKy"] = SoLuongTon_CuoiKy;
                    dt2.Rows.Add(_ravi);
                }
            }

            gridControl1.DataSource = dt2;

        }
        public UCDaiLy_TongHopTonKho()
        {
            InitializeComponent();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void UCDaiLy_TongHopTonKho_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            HienThi();
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            HienThi();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString()!="")
            {
                mdadenngay = dteDenNgay.DateTime;
                miID_VTHH = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_VTHH).ToString());
                DaiLy_Frm_TonKho_MotVatTu ff = new CtyTinLuong.DaiLy_Frm_TonKho_MotVatTu();
                ff.Show();
            }
        }
    }
}
