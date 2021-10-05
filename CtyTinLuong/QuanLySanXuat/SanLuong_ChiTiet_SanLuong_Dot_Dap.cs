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
        public static double tongsobao_sot, tongsokg, tongsothanh;
        private void Load_lockup()
        {
            try
            {
                using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
                {
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
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadData(int ID_VTHHxx, DateTime xxtungay, DateTime xxdenngay)
        {
            try
            {
                using (clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New())
                {
                    gridControl1.DataSource = null;
                    DataTable dt = new DataTable();

                    dt = cls.SelectAll_W_ID_VTHH_Ra_TenCN_NgayThang_DOT(ID_VTHHxx, xxtungay, xxdenngay);
                    if (dt.Rows.Count > 0)
                        gridControl1.DataSource = dt;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        SanLuong_To_DOT_DAP _frmSLTDD;
        public SanLuong_ChiTiet_SanLuong_Dot_Dap(SanLuong_To_DOT_DAP frmSLTDD)
        {
            _frmSLTDD = frmSLTDD;
            InitializeComponent();
        }

        private void SanLuong_ChiTiet_SanLuong_Dot_Dap_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                clSoKG_MotBao_May_Dot.Caption = "Số KG/\nBao_Sọt";
                clQuyRaKG.Caption = "Tổng số\nKg";
                Load_lockup();
                dteTuNgay.EditValue = SanLuong_To_DOT_DAP.mdatungay;
                dteDenNgay.EditValue = SanLuong_To_DOT_DAP.mdadenngay;
                GridMaVT.EditValue = SanLuong_To_DOT_DAP.miID_VTHH_Ra;

                LoadData(SanLuong_To_DOT_DAP.miID_VTHH_Ra, SanLuong_To_DOT_DAP.mdatungay, SanLuong_To_DOT_DAP.mdadenngay);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridMaVT_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridMaVT.Properties.View.Columns[0].Visible = false; 
        }

        private void dteDenNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dteTuNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void GridMaVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTenVTHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
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
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
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

                    dt3 = cls.Select_SUM_SanLuong_W_IDVTHH_NgayThang_DOT(miID_VThh, mdatungay, mdadenngay);

                    tongsobao_sot = CheckString.ConvertToDouble_My(dt3.Rows[0]["TongSoBao_Sot"].ToString());
                    tongsokg = CheckString.ConvertToDouble_My(dt3.Rows[0]["TongSoKg"].ToString());
                    tongsothanh = CheckString.ConvertToDouble_My(dt3.Rows[0]["TongSoThanh"].ToString());

                    frmPrint_SanLuongToMayIn ff = new frmPrint_SanLuongToMayIn();
                    ff.Show();

                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
