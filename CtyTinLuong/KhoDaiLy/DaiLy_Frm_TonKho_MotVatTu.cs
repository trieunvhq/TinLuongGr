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
        public static bool mbPrint = false;
        public static int miID_VTHH;
        public static DataTable mdtPrint;
        public static DateTime mdadenngay;
        private void Load_Lockup()
        {
            clsTbVatTuHangHoa cls = new CtyTinLuong.clsTbVatTuHangHoa();
            DataTable dt2 = cls.SelectAll();
            gridMaVT.Properties.DataSource = dt2;
            gridMaVT.Properties.ValueMember = "ID_VTHH";
            gridMaVT.Properties.DisplayMember = "MaVT";            
        }
        private void LoadDaTa(int xxID_VTHH, DateTime xxdenngaya)
        {
            gridControl1.DataSource = null;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Ton", typeof(double));
            dt2.Columns.Add("MaDaiLy", typeof(string));
            dt2.Columns.Add("TenDaiLy", typeof(string));
            dt2.Columns.Add("ID_DaiLy", typeof(int));

            DataTable dtnhap = new DataTable();
            DataTable dtXuat = new DataTable();
            clsDaiLy_tbChiTietNhapKho cls1 = new CtyTinLuong.clsDaiLy_tbChiTietNhapKho();
            clsDaiLy_tbChiTietXuatKho cls2 = new clsDaiLy_tbChiTietXuatKho();
            dtnhap = cls1.SA_TonKho_W_ID_VTHH(xxID_VTHH, xxdenngaya);
            dtXuat = cls2.SA_TonKho_W_ID_VTHH(xxID_VTHH, xxdenngaya);
            if (dtnhap.Rows.Count > 0)
            {
                for (int i = 0; i < dtnhap.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtnhap.Rows[i]["ID_DaiLy"].ToString());
                    double soluongnhap = Convert.ToDouble(dtnhap.Rows[i]["SoLuongNhap"].ToString());
                    double soluongxuat;
                    string expression = "ID_DaiLy='" + iiID_DaiLy + "'";
                    DataRow[] foundRows;
                    foundRows = dtXuat.Select(expression);
                    if (foundRows.Length > 0)
                        soluongxuat = Convert.ToDouble(foundRows[0]["SoLuongXuat"].ToString());
                    else
                        soluongxuat = 0;
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = soluongnhap - soluongxuat;
                    _ravi2["MaDaiLy"] = dtnhap.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtnhap.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            else if (dtXuat.Rows.Count > 0)
            {
                for (int i = 0; i < dtXuat.Rows.Count; i++)
                {
                    int iiID_DaiLy = Convert.ToInt32(dtXuat.Rows[i]["ID_DaiLy"].ToString());
                    double soluongxuat = Convert.ToDouble(dtXuat.Rows[i]["SoLuongXuat"].ToString());
                    DataRow _ravi2 = dt2.NewRow();
                    _ravi2["ID_DaiLy"] = iiID_DaiLy;
                    _ravi2["Ton"] = -soluongxuat;
                    _ravi2["MaDaiLy"] = dtXuat.Rows[i]["MaDaiLy"].ToString();
                    _ravi2["TenDaiLy"] = dtXuat.Rows[i]["TenDaiLy"].ToString();
                    dt2.Rows.Add(_ravi2);
                }
            }
            gridControl1.DataSource = dt2;
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
           
            mbPrint = true;
            miID_VTHH = Convert.ToInt32(gridMaVT.EditValue.ToString());
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();           
            mdadenngay = dteDenNgay.DateTime;        
            frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww ff = new frmPrint_Nhap_Xuat_Ton_ChiTiet_Mot_VatTu_newwwwwwwwwwwwww();
            ff.ShowDialog();
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
            int kkk = Convert.ToInt32(gridMaVT.EditValue.ToString());
            LoadDaTa(kkk, dteDenNgay.DateTime);
        }

        private void DaiLy_Frm_TonKho_MotVatTu_Load(object sender, EventArgs e)
        {
            Load_Lockup();          
            gridMaVT.EditValue = DaiLy_BaoCao_TonKho.miID_VTHHH;
            dteDenNgay.EditValue = DaiLy_BaoCao_TonKho.mdadenngay;
         
        }

        private void gridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            int kkk = Convert.ToInt32(gridMaVT.EditValue.ToString());
            clsTbVatTuHangHoa cls = new CtyTinLuong.clsTbVatTuHangHoa();
            cls.iID_VTHH = kkk;
            DataTable dt = cls.SelectOne();
            txtDVT.Text = cls.sDonViTinh.Value;
            txtTenVT.Text = cls.sTenVTHH.Value;
            if(dteDenNgay.EditValue!=null)
                LoadDaTa(kkk, dteDenNgay.DateTime);
        }
    }
}
