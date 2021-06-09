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
    public partial class SanLuong_ChiTiet_SanLuong_Dot_Dap : Form
    {
        public static DataTable mdtPrint;
        public static DateTime mdatungay, mdadenngay;
        public static bool mbPrint;
        public static string msMaVT, msTenVT, msDVT;      
        public static int miID_VThh = 0;
    //    public static double sanluongthuowng, sanluongtangca, sanluongtong, phepham;
        private void Load_lockup()
        {
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataTable dt = cls.SelectAll_distinct_W_ID_VTHH_Ra_May_DOT();
            DataTable dt2xx = new DataTable();
            dt2xx.Columns.Add("ID_VTHH", typeof(int));
            dt2xx.Columns.Add("MaVT", typeof(string));
            dt2xx.Columns.Add("TenVTHH", typeof(string));
            if (dt.Rows.Count > 0)
            {
                clsTbVatTuHangHoa clsxx = new clsTbVatTuHangHoa();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int xxID = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Ra"].ToString());
                    clsxx.iID_VTHH = xxID;
                    DataTable xxdt = clsxx.SelectOne();
                    DataRow _ravi = dt2xx.NewRow();
                    _ravi["ID_VTHH"] = xxID;
                    _ravi["MaVT"] = clsxx.sMaVT.Value;
                    _ravi["TenVTHH"] = clsxx.sTenVTHH.Value;
                    dt2xx.Rows.Add(_ravi);
                }
            }

            GridMaVT.Properties.DataSource = dt2xx;
            GridMaVT.Properties.ValueMember = "ID_VTHH";
            GridMaVT.Properties.DisplayMember = "MaVT";

        }
        private void LoadData(int ID_VTHHxx, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            DataTable dt = new DataTable();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            dt = cls.SelectAll_W_ID_VTHH_Ra_TenCN_NgayThang_DOT(ID_VTHHxx, xxtungay, xxdenngay);
            if (dt.Rows.Count > 0)
                gridControl1.DataSource = dt;

        }
        public SanLuong_ChiTiet_SanLuong_Dot_Dap()
        {
            InitializeComponent();
        }

        private void SanLuong_ChiTiet_SanLuong_Dot_Dap_Load(object sender, EventArgs e)
        {
            clSoKG_MotBao_May_Dot.Caption = "Số KG/\nBao_Sọt";
            clQuyRaKG.Caption = "Tổng số\nKg";
            Load_lockup();
            dteTuNgay.EditValue = SanLuong_To_DOT_DAP.mdatungay;
            dteDenNgay.EditValue = SanLuong_To_DOT_DAP.mdadenngay;
            GridMaVT.EditValue = SanLuong_To_DOT_DAP.miID_VTHH_Ra;
           
            LoadData(SanLuong_To_DOT_DAP.miID_VTHH_Ra, SanLuong_To_DOT_DAP.mdatungay, SanLuong_To_DOT_DAP.mdadenngay);
        }

        private void GridMaVT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa clsncc = new clsTbVatTuHangHoa();
                int kk = Convert.ToInt32(GridMaVT.EditValue.ToString());
                clsncc.iID_VTHH = kk;
                DataTable dt = clsncc.SelectOne();

                txtTenVTHH.Text = clsncc.sTenVTHH.Value;
                txtDVT.Text = clsncc.sDonViTinh.Value;
                if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
                {
                    int xxID = Convert.ToInt32(GridMaVT.EditValue.ToString());
                    LoadData(xxID, dteTuNgay.DateTime, dteDenNgay.DateTime);

                }
            }
            catch
            {

            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                int xxID = Convert.ToInt32(GridMaVT.EditValue.ToString());
                LoadData(xxID, dteTuNgay.DateTime, dteDenNgay.DateTime);

            }
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            CriteriaOperator op = gridView2.ActiveFilterCriteria; // filterControl1.FilterCriteria
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            DataView dv1212 = new DataView(DatatableABC);
            dv1212.RowFilter = filterString;
            mdtPrint = dv1212.ToTable();

            if (mdtPrint.Rows.Count > 0)
            {
                mbPrint = true;
                mdatungay = dteTuNgay.DateTime;
                mdadenngay = dteDenNgay.DateTime;
                miID_VThh = Convert.ToInt32(GridMaVT.EditValue.ToString());
                msMaVT = GridMaVT.Text.ToString();
                msTenVT = txtTenVTHH.Text;
                msDVT = txtDVT.Text;
                clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
                DataTable dt3 = new DataTable();
                //if (xxximay_in_1_Cat_2_dot_3 == 1)
                //    dt3 = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_IN(miID_VThh, mdatungay, mdadenngay);
                //else if (xxximay_in_1_Cat_2_dot_3 == 2)
                //    dt3 = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_CAT(miID_VThh, mdatungay, mdadenngay);

                //sanluongthuowng = Convert.ToDouble(dt3.Rows[0]["SanLuong_Thuong"].ToString());
                //sanluongtangca = Convert.ToDouble(dt3.Rows[0]["SanLuong_TangCa"].ToString());
                //sanluongtong = Convert.ToDouble(dt3.Rows[0]["SanLuong_Tong"].ToString());
                //phepham = Convert.ToDouble(dt3.Rows[0]["PhePham"].ToString());
                frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                ff.Show();

            }
        }
    }
}
