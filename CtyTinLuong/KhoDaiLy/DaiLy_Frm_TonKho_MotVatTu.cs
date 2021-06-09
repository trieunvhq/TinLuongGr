using DevExpress.Data.Filtering;
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
    public partial class DaiLy_Frm_TonKho_MotVatTu : Form
    {
        public static bool mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = false;
        public static int miID_VTHH;
        public static string msNguoiLap_Prtint;
        public static DataTable mdt_ChiTiet_MotVatTu_N_X_T_Print;
        public static DateTime mdadenngay;
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
      

        public void HienThi(DateTime denngayxxx)
        {
            int ID_VTHH = UCDaiLy_TongHopTonKho.miID_VTHH;
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new CtyTinLuong.clsDaiLy_tbChiTietXuatKho();
            DataTable dtDISTINCT = cls1.SelectAll_distinct_W_DaiLy();
            DataTable dtnpl = new DataTable();
            dtnpl.Columns.Add("Ton", typeof(double));
            dtnpl.Columns.Add("MaDaiLy", typeof(string));
            dtnpl.Columns.Add("TenDaiLy", typeof(string));
            dtnpl.Columns.Add("ID_DaiLy", typeof(int));

            if (dtDISTINCT.Rows.Count > 0)
            {
                for (int i = 0; i < dtDISTINCT.Rows.Count; i++)
                {
                    double deSoluong_tonDauKy, deSoLuongNhap_TrongKy, deSoLuongXuat_TrongKy;

                    DataTable adt1 = new DataTable();
                    adt1.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
                    adt1.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
                    adt1.Columns.Add("ID_DaiLy", typeof(int));

                    DataTable bdt1 = new DataTable();
                    bdt1.Columns.Add("SoLuongNhap_TrongKy", typeof(double));
                    bdt1.Columns.Add("SoLuongXuat_TrongKy", typeof(double));
                    bdt1.Columns.Add("ID_DaiLy", typeof(int));

                    int ID_DaiLy = Convert.ToInt16(dtDISTINCT.Rows[i]["ID_DaiLy"].ToString());

                    cls1.iID_DaiLy = ID_DaiLy;
                    cls1.iID_VTHH = ID_VTHH;
                    DataTable dxxxx3333 = cls1.SelectOne_w_ID_VTHH_W_ID_DaiLy();
                    dxxxx3333.DefaultView.RowFilter = " DaNhapKho= True and boolTonDauKy = True";
                    DataView dv33333 = dxxxx3333.DefaultView;
                    DataTable dttondauky = dv33333.ToTable();


                    DataTable dxxxx = cls1.Select_One_NXT_TinhToan_W_DaiLy_newwwww();
                    dxxxx.DefaultView.RowFilter = " DaNhapKho= True and boolTonDauKy = False and NgayChungTu<='" + denngayxxx + "'";
                    DataView dv = dxxxx.DefaultView;
                    DataTable dtnhap = dv.ToTable();

                    cls2.iID_DaiLy = ID_DaiLy;
                    cls2.iID_VTHH = ID_VTHH;
                    DataTable dxxxx22222 = cls2.Select_One_NXT_TinhToan_W_DaiLy_newwwww();
                    dxxxx22222.DefaultView.RowFilter = " DaXuatKho= True and NgayChungTu<='" + denngayxxx + "'";
                    DataView dv222222 = dxxxx22222.DefaultView;
                    DataTable dtxuat = dv222222.ToTable();

                    if (dtnhap.Rows.Count > 0) // có nhập
                    {
                        for (int j = 0; j < dtnhap.Rows.Count; j++)
                        {
                            double SoLuongNhap_TrongKy = Convert.ToDouble(dtnhap.Rows[j]["SoLuongNhap"].ToString());
                            DataRow _ravinhap = adt1.NewRow();
                            _ravinhap["ID_DaiLy"] = ID_DaiLy;
                            _ravinhap["SoLuongNhap_TrongKy"] = SoLuongNhap_TrongKy;
                            adt1.Rows.Add(_ravinhap);
                        }
                        object xxdeSoLuongNhap_TrongKy = adt1.Compute("sum(SoLuongNhap_TrongKy)", "ID_DaiLy=" + ID_DaiLy + "");
                        deSoLuongNhap_TrongKy = Convert.ToDouble(xxdeSoLuongNhap_TrongKy);
                    }
                    else // không có nhập
                    {
                        deSoLuongNhap_TrongKy = 0;
                    }
                    if (dttondauky.Rows.Count > 0)
                    {
                        deSoluong_tonDauKy = Convert.ToDouble(dttondauky.Rows[0]["SoLuongNhap"].ToString());
                    }
                    else // không có tồn
                    {
                        deSoluong_tonDauKy = 0;
                    }

                    if (dtxuat.Rows.Count > 0) // có xuất
                    {
                        for (int k = 0; k < dtxuat.Rows.Count; k++)
                        {
                            double SoLuongXuat_TrongKy;
                            SoLuongXuat_TrongKy = Convert.ToDouble(dtxuat.Rows[k]["SoLuongXuat"].ToString());
                            DataRow _ravixuat = bdt1.NewRow();
                            _ravixuat["ID_DaiLy"] = ID_DaiLy;
                            _ravixuat["SoLuongXuat_TrongKy"] = SoLuongXuat_TrongKy;
                            bdt1.Rows.Add(_ravixuat);
                        }
                        object xxdeSoLuongXuat_TrongKy = bdt1.Compute("sum(SoLuongXuat_TrongKy)", "ID_DaiLy=" + ID_DaiLy + "");
                        deSoLuongXuat_TrongKy = Convert.ToDouble(xxdeSoLuongXuat_TrongKy);
                    }
                    else // khong có xuất
                    {
                        deSoLuongXuat_TrongKy = 0;
                    }
                    if (deSoLuongXuat_TrongKy > 0 || deSoluong_tonDauKy>0 || deSoLuongNhap_TrongKy>0)
                    {
                        DataRow _ravi2 = dtnpl.NewRow();
                        _ravi2["ID_DaiLy"] = ID_DaiLy;
                        clsTbDanhMuc_DaiLy clsdly = new clsTbDanhMuc_DaiLy();
                        clsdly.iID_DaiLy = ID_DaiLy;
                        DataTable dt = clsdly.SelectOne();
                        _ravi2["Ton"] = deSoluong_tonDauKy + deSoLuongNhap_TrongKy - deSoLuongXuat_TrongKy;
                        _ravi2["MaDaiLy"] = clsdly.sMaDaiLy.Value;
                        _ravi2["TenDaiLy"] = clsdly.sTenDaiLy.Value;
                        dtnpl.Rows.Add(_ravi2);
                    }                       
                }
                gridControl1.DataSource = dtnpl;
            }
            
        }


        public DaiLy_Frm_TonKho_MotVatTu()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void btPrint_Click(object sender, EventArgs e)
        {
            miID_VTHH = UCDaiLy_TongHopTonKho.miID_VTHH;
            mbPrint_NXT_Kho_NPL_ChiTiet_MotVatTu = true;
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdt_ChiTiet_MotVatTu_N_X_T_Print = dv1212.ToTable();
           
            mdadenngay = UCDaiLy_TongHopTonKho.mdadenngay;
            msNguoiLap_Prtint = "";
            frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww();
            ff.Show();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            HienThi(dteDenNgay.DateTime);
        }

        private void DaiLy_Frm_TonKho_MotVatTu_Load(object sender, EventArgs e)
        {
                 
            dteDenNgay.EditValue = UCDaiLy_TongHopTonKho.mdadenngay; 

            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            cls.iID_VTHH = UCDaiLy_TongHopTonKho.miID_VTHH;
            DataTable dt = cls.SelectOne();
            txtMaVT.Text = cls.sMaVT.Value;
            txtTenVT.Text = cls.sTenVTHH.Value;
            txtDVT.Text = cls.sDonViTinh.Value;

            HienThi(dteDenNgay.DateTime);
        }
    }
}
