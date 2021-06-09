using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmChiTietDinhMucNPL : Form
    {
        int  iID_VTHH;
        string sMaVT, sTenVTHH, sDonViTinh;   
      //  Double fSoLuong;
        private void Luu_ThemMoi_DM_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();
                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;
                    cls1.iID_VTHH_ThanhPham = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls1.iID_VTHH_Chinh= Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());                   
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls1.Insert();


                    int iID_DinhMuc_NPLxxxx = cls1.iID_DinhMuc_NPL.Value;
                    clsDinhMuc_ChiTiet_DM_NPL cls2 = new clsDinhMuc_ChiTiet_DM_NPL();
                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_NPL = iID_DinhMuc_NPLxxxx;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["SoLuong"].ToString() != "")
                            cls2.fSoLuong = Convert.ToDouble(dv3.Rows[i]["SoLuong"].ToString());
                        else cls2.fSoLuong = 0;                   
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.Insert();
                    }
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                catch
                {

                }

            }
        }

        private void Luu_Sua__DM_NPL()
        {
            if (!KiemTraLuu()) return;
            else
            {
                try
                {
                    clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
                    cls1.sMaDinhMuc = txtMaDinhMucNPL.Text.ToString().Trim();
                    cls1.sDienGiai = txtDienGiai.Text.ToString().Trim();

                    if (dteNgayLap.Text.ToString() != "")
                        cls1.daNgayLap = dteNgayLap.DateTime;
                    else cls1.daNgayLap = DateTime.Today;
                    cls1.iID_VTHH_ThanhPham = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                    cls1.iID_VTHH_Chinh = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());                    
                    cls1.bTonTai = true;
                    cls1.bNgungTheoDoi = checkNgungTheoDoi.Checked;
                    cls1.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                    cls1.Update();


                    clsDinhMuc_ChiTiet_DM_NPL cls2 = new clsDinhMuc_ChiTiet_DM_NPL();
                    cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                    cls2.Delete_W_ID_DinhMuc_NPL();
                    string shienthi = "1";
                    DataTable dttttt2 = (DataTable)gridControl1.DataSource;
                    dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
                    DataView dv = dttttt2.DefaultView;
                    DataTable dv3 = dv.ToTable();

                    for (int i = 0; i < dv3.Rows.Count; i++)
                    {
                        cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
                        cls2.iID_VTHH = Convert.ToInt16(dv3.Rows[i]["ID_VTHH"].ToString());
                        if (dv3.Rows[i]["SoLuong"].ToString() != "")
                            cls2.fSoLuong = Convert.ToDouble(dv3.Rows[i]["SoLuong"].ToString());
                        else cls2.fSoLuong = 0;
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
                        cls2.Insert();
                    }
                    MessageBox.Show("Đã lưu");
                    this.Close();
                }
                catch
                {

                }
            }
        }
        private void HienThi_ThemMoi_DinhMuc_NPL()
        {
            dteNgayLap.EditValue = DateTime.Today;
           
        }

        private void HienThi_Sua_DinhMuc_NPL()
        {
            clsDinhMuc_tbDM_NguyenPhuLieu cls1 = new clsDinhMuc_tbDM_NguyenPhuLieu();
            cls1.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
            DataTable dt = cls1.SelectOne();
            gridMaTPQuyDoi.EditValue = cls1.iID_VTHH_ThanhPham.Value;
            gridMaVTchinh1.EditValue = cls1.iID_VTHH_Chinh.Value;          

            txtMaDinhMucNPL.Text = cls1.sMaDinhMuc.Value.ToString();
            dteNgayLap.EditValue = cls1.daNgayLap.Value;
            txtDienGiai.Text = cls1.sDienGiai.Value.ToString();
            checkNgungTheoDoi.Checked = Convert.ToBoolean(cls1.bNgungTheoDoi.Value.ToString());

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietDinhMucNPL", typeof(int));
            dt2.Columns.Add("ID_DinhMuc_NPL", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("MaVT");// 
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));
           

            clsDinhMuc_ChiTiet_DM_NPL cls2 = new CtyTinLuong.clsDinhMuc_ChiTiet_DM_NPL();
            cls2.iID_DinhMuc_NPL = ucDinhMucNGuyenPhuLieu.miID_DinhMuc_NPL;
            DataTable dtxxx = cls2.SelectAll_HienThi_LookUp();
            Double ddsoluong;
            dtxxx.DefaultView.RowFilter = "TonTai=True";
            DataView dv = dtxxx.DefaultView;
            DataTable dt3 = dv.ToTable();
            
            for (int i = 0; i < dt3.Rows.Count; i++)
            {                
                if (dt3.Rows[i]["SoLuong"].ToString() == "")
                    ddsoluong = 0;
                else ddsoluong = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());                                
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietDinhMucNPL"] = Convert.ToInt16(dt3.Rows[i]["ID_ChiTietDinhMucNPL"].ToString());
                _ravi["ID_DinhMuc_NPL"] = Convert.ToInt16(dt3.Rows[i]["ID_DinhMuc_NPL"].ToString());
                _ravi["ID_VTHH"] = Convert.ToInt16(dt3.Rows[i]["ID_VTHH"].ToString());                
                _ravi["SoLuong"] = ddsoluong;
                _ravi["MaVT"] = dt3.Rows[i]["ID_VTHH"].ToString();               
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();             
                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;

        }
        private bool KiemTraLuu()
        {
            string shienthi = "1";
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();

            if (txtMaDinhMucNPL.ToString() == "")
            {
                MessageBox.Show("Chưa có mã Thành phẩm quy đổi");
                return false;
            }
            else if (gridMaTPQuyDoi.EditValue == null)
            {
                MessageBox.Show("Chưa chọn Bán thành phẩm quy đổi ");
                return false;
            }
            else if (dv3.Rows.Count == 0)
            {
                MessageBox.Show("Chưa chọn hàng hóa ");
                return false;
            }
            else return true;

        }


        public frmChiTietDinhMucNPL()
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

        private void gridLook_MaTPQuyDoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridMaTPQuyDoi.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenThanhPhamQuyDoi.Text = dt.Rows[0]["TenVTHH"].ToString();
                    txtMaDinhMucNPL.Text = dt.Rows[0]["MaVT"].ToString();
                    txtDVTMaTP.Text = dt.Rows[0]["DonViTinh"].ToString();

                }
            }
            catch
            {

            }
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoa2_Click(object sender, EventArgs e)
        {
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clHienThi, "0");
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, clSoLuong, 0);
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (ucDinhMucNGuyenPhuLieu.mb_TheMoi_DinhMuc_NPL == true)
                Luu_ThemMoi_DM_NPL();
            else Luu_Sua__DM_NPL();
        }

        private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if (dv[e.ListSourceRow]["HienThi"].ToString().Trim() == "0")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }

        private void frmChiTietDinhMucNPL_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_ChiTietDinhMucNPL", typeof(int));
            dt2.Columns.Add("ID_DinhMuc_NPL", typeof(int));
            dt2.Columns.Add("ID_VTHH", typeof(int));         
            dt2.Columns.Add("SoLuong", typeof(float));
            dt2.Columns.Add("MaVT");// 
            dt2.Columns.Add("TenVTHH");
            dt2.Columns.Add("DonViTinh");
            dt2.Columns.Add("HienThi", typeof(string));               
            gridControl1.DataSource = dt2;

            



            clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
            DataTable dt = cls.SelectAll();
            dt.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv2 = dt.DefaultView;
            DataTable dtxx2 = dv2.ToTable();

            gridMaTPQuyDoi.Properties.DataSource = dtxx2;
            gridMaTPQuyDoi.Properties.ValueMember = "ID_VTHH";
            gridMaTPQuyDoi.Properties.DisplayMember = "MaVT";
            //
            gridMaVTchinh1.Properties.DataSource = dtxx2;
            gridMaVTchinh1.Properties.ValueMember = "ID_VTHH";
            gridMaVTchinh1.Properties.DisplayMember = "MaVT";

            repositoryItemLookUpEdit2.DataSource = dtxx2;
            repositoryItemLookUpEdit2.ValueMember = "ID_VTHH";
            repositoryItemLookUpEdit2.DisplayMember = "MaVT";

            if (ucDinhMucNGuyenPhuLieu.mb_TheMoi_DinhMuc_NPL == true)
                HienThi_ThemMoi_DinhMuc_NPL();
            else HienThi_Sua_DinhMuc_NPL();
        }

        private void gridMaVTchinh1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                clsTbVatTuHangHoa cls = new clsTbVatTuHangHoa();
                cls.iID_VTHH = Convert.ToInt16(gridMaVTchinh1.EditValue.ToString());
                DataTable dt = cls.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    txtTenVTchinh1.Text = dt.Rows[0]["TenVTHH"].ToString();                  
                    txtDVT_VTchinh1.Text = dt.Rows[0]["DonViTinh"].ToString();

                }
            }
            catch
            {

            }
            
        }

       

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaVT)
            {
                gridView1.SetRowCellValue(e.RowHandle, clID_VTHH, iID_VTHH);
                gridView1.SetRowCellValue(e.RowHandle, clTenVTHH, sTenVTHH);
                gridView1.SetRowCellValue(e.RowHandle, clDonViTinh, sDonViTinh);                
             
                gridView1.SetRowCellValue(e.RowHandle, clSoLuong, 0);                
                string shienthixx = "1";
                gridView1.SetRowCellValue(e.RowHandle, clHienThi, shienthixx);

            }
           
        }

        private void repositoryItemLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit editor = sender as DevExpress.XtraEditors.LookUpEdit;
            //iID_ChiTietDinhMucNPL = Convert.ToInt16(editor.GetColumnValue("ID_ChiTietDinhMucNPL"));
            //iID_DinhMuc_NPL = Convert.ToInt16(editor.GetColumnValue("ID_DinhMuc_NPL"));
            iID_VTHH = Convert.ToInt16(editor.GetColumnValue("ID_VTHH"));
            sMaVT = editor.GetColumnValue("MaVT").ToString();
            sTenVTHH = editor.GetColumnValue("TenVTHH").ToString();
            sDonViTinh = editor.GetColumnValue("DonViTinh").ToString();            
            //fSoLuong = Convert.ToDouble(editor.GetColumnValue("SoLuong").ToString());
           
        }
    }
}
