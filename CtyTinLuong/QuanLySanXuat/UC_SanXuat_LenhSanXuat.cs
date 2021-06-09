using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace CtyTinLuong
{
    public partial class UC_SanXuat_LenhSanXuat : UserControl
    {
        private int _SoTrang = 1;
        private bool isload = false;
        public void LoadData(int sotrang, bool isLoadLanDau, DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            isload = true;
            _SoTrang = sotrang;
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            DataTable dt = cls.SelectAll_Load_DaTa_W_NgayThang(_SoTrang, xxtungay, xxdenngay);

            gridControl1.DataSource = dt;


            isload = false;
        }
        private void Load_PhieuSX(bool islandau)
        {
            int sotrang_ = 1;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
            }
            catch
            {
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
            LoadData(sotrang_, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
        }
        public void ResetSoTrang(DateTime xxtungay, DateTime xxdenngay)
        {
            btnTrangSau.Visible = true;
            btnTrangTiep.Visible = true;
            lbTongSoTrang.Visible = true;
            txtSoTrang.Visible = true;
            btnTrangSau.LinkColor = Color.Black;
            btnTrangTiep.LinkColor = Color.Blue;
            txtSoTrang.Text = "1";

            using (clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat())
            {
                DataTable dt_ = cls.SelectAll_Tinh_SoLenh_SX(xxtungay, xxdenngay);
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    lbTongSoTrang.Text = "/" + (Math.Ceiling(Convert.ToDouble(dt_.Rows[0]["tongso"].ToString()) / (double)20)).ToString();
                }
                else
                {
                    lbTongSoTrang.Text = "/1";
                }
            }
            if (lbTongSoTrang.Text == "0")
                lbTongSoTrang.Text = "/1";
            if (lbTongSoTrang.Text == "/1")
            {
                btnTrangSau.LinkColor = Color.Black;
                btnTrangTiep.LinkColor = Color.Black;
            }
        }

        public static int mID_iD_LenhSanXuat;
        private void HienThi_Gridcontrol_2(int iiiIDiD_LenhSanXuat)
        {
            gridControl2.DataSource = null;
            DataTable dt2 = new DataTable();
            clsHUU_LenhSanXuat_ChiTietLenhSanXuat cls2 = new CtyTinLuong.clsHUU_LenhSanXuat_ChiTietLenhSanXuat();
            cls2.iID_LenhSanXuat = iiiIDiD_LenhSanXuat;
            DataTable dtxxxx = cls2.SelectAll_w_iID_LenhSanXuat();

            dt2.Columns.Add("ID_ChiTietPhieu", typeof(int));
            dt2.Columns.Add("ID_SoPhieu", typeof(int));
            dt2.Columns.Add("MaPhieu", typeof(string));
            dt2.Columns.Add("ID_VTHH_Vao", typeof(int));
            dt2.Columns.Add("ID_VTHH_Ra", typeof(int));
            dt2.Columns.Add("MaVT_Vao", typeof(string));
            dt2.Columns.Add("MaVT_Ra", typeof(string));
            dt2.Columns.Add("DonViTinh_Vao", typeof(string));
            dt2.Columns.Add("DonViTinh_Ra", typeof(string));
            dt2.Columns.Add("TenVatTu_Vao", typeof(string));
            dt2.Columns.Add("TenVatTu_Ra", typeof(string));
            dt2.Columns.Add("SoLuong_Vao", typeof(float));
            dt2.Columns.Add("SanLuong_Thuong", typeof(float));
            dt2.Columns.Add("SanLuong_TangCa", typeof(float));
            dt2.Columns.Add("PhePham", typeof(float));
            dt2.Columns.Add("DonGia_Vao", typeof(float));
            dt2.Columns.Add("DonGia_Xuat", typeof(float));
            dt2.Columns.Add("HienThi", typeof(string));
            dt2.Columns.Add("LoaiMay", typeof(string));
            clsTbVatTuHangHoa clsVT_Vao = new clsTbVatTuHangHoa();
            clsTbVatTuHangHoa clsVT_Ra = new clsTbVatTuHangHoa();
            clsPhieu_tbPhieu clsphieu = new clsPhieu_tbPhieu();
            for (int i = 0; i < dtxxxx.Rows.Count; i++)
            {

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_ChiTietPhieu"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_ChiTietPhieu"].ToString());
                _ravi["ID_SoPhieu"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                clsphieu.iID_SoPhieu = Convert.ToInt32(dtxxxx.Rows[i]["ID_SoPhieu"].ToString());
                DataTable dtphieu = clsphieu.SelectOne();
                _ravi["MaPhieu"] = dtphieu.Rows[0]["MaPhieu"].ToString();
                _ravi["ID_VTHH_Vao"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                clsVT_Vao.iID_VTHH = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHVao"].ToString());
                DataTable dtVT_vao = clsVT_Vao.SelectOne();
                _ravi["MaVT_Vao"] = dtVT_vao.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Vao"] = dtVT_vao.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Vao"] = dtVT_vao.Rows[0]["TenVTHH"].ToString();

                _ravi["ID_VTHH_Ra"] = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                clsVT_Ra.iID_VTHH = Convert.ToInt32(dtxxxx.Rows[i]["ID_VTHHRa"].ToString());
                DataTable dtVT_Ra = clsVT_Ra.SelectOne();
                _ravi["MaVT_Ra"] = dtVT_Ra.Rows[0]["MaVT"].ToString();
                _ravi["DonViTinh_Ra"] = dtVT_Ra.Rows[0]["DonViTinh"].ToString();
                _ravi["TenVatTu_Ra"] = dtVT_Ra.Rows[0]["TenVTHH"].ToString();

                _ravi["SoLuong_Vao"] = Convert.ToDouble(dtxxxx.Rows[i]["SoLuongVao"].ToString());
                _ravi["SanLuong_Thuong"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongThuong"].ToString());
                _ravi["SanLuong_TangCa"] = Convert.ToDouble(dtxxxx.Rows[i]["SanLuongTangCa"].ToString());
                _ravi["PhePham"] = Convert.ToDouble(dtxxxx.Rows[i]["PhePham"].ToString());
                _ravi["DonGia_Vao"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaVao"].ToString());
                _ravi["DonGia_Xuat"] = Convert.ToDouble(dtxxxx.Rows[i]["DonGiaRa"].ToString());

                _ravi["HienThi"] = "1";
                dt2.Rows.Add(_ravi);

            }
            gridControl2.DataSource = dt2;


        }
        private void HienThi()
        {
            clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
            DataTable dt = cls.SelectAll_W_TenCoNhan();       
            DataView dv = dt.DefaultView;
            dv.Sort = "NgayThangSanXuat DESC, CaSanXuat DESC, ID_LenhSanXuat DESC";
            DataTable dxxxx = dv.ToTable();
            gridControl1.DataSource = dxxxx;
        }
        public UC_SanXuat_LenhSanXuat()
        {
            InitializeComponent();
        }
        
        private void UC_SanXuat_LenhSanXuat_Load(object sender, EventArgs e)
        {
            
         
            clCaSanXuat.Caption = "Ca\n SX";
            clNhomMay.Caption = "Nhóm\nmáy";

            dteTuNgay.EditValue = DateTime.Now.AddDays(-20);
            dteDenNgay.EditValue = DateTime.Now;
            LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);

            ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }      

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_SanXuat_LenhSanXuat_Load(sender, e);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Column == clNhomMay)
            {
                //gridView4.GetRowCellValue(e.RowHandle, e.Column)
                if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "1") 
                    e.DisplayText = "IN";
              else  if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "2") 
                e.DisplayText = "CẮT";
              else  if (gridView1.GetRowCellValue(e.RowHandle, "ID_LoaiMay").ToString() == "3") 
                e.DisplayText = "ĐỘT";
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
                {      
                                   
                    mID_iD_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());                 
                    SanXuat_frmChiTietLenhSanXuat ff = new SanXuat_frmChiTietLenhSanXuat();
                    ff.Show();
                }
            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (traloi == DialogResult.Yes)
            {
                if(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString()=="")
                {
                    MessageBox.Show("Vui lòng chọn lại");
                }
                else
                {
                    clsHUU_LenhSanXuat cls1 = new clsHUU_LenhSanXuat();
                    cls1.iID_LenhSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                    cls1.Delete_W_TonTai();
                    MessageBox.Show("Đã xóa");
                    HienThi();
                }
               
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                clsPhieu_tbPhieu cls = new clsPhieu_tbPhieu();
                cls.iID_SoPhieu = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }
     

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool category = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, View.Columns["GuiDuLieu"]));
                if (category == false)
                {
                    e.Appearance.BackColor = Color.Bisque;

                }
            }
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
            {
                int xxxmclID_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                clsHUU_LenhSanXuat cls = new clsHUU_LenhSanXuat();
                cls.iID_LenhSanXuat = xxxmclID_LenhSanXuat;
                cls.bGuiDuLieu = true;
                cls.Update_W_GuiDuLieu();
                MessageBox.Show("Đã gửi dữ liệu nhập xuất kho");
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString() != "")
            {
                int xxxmclID_LenhSanXuat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_LenhSanXuat).ToString());
                HienThi_Gridcontrol_2(xxxmclID_LenhSanXuat);
            }
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT2)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btLayDuLieu_Click(object sender, EventArgs e)
        {
            if (dteDenNgay.EditValue != null & dteTuNgay.EditValue != null)
            {
                ResetSoTrang(dteTuNgay.DateTime, dteDenNgay.DateTime);
                LoadData(1, true, dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
        }

        private void btnTrangTiep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                btnTrangSau.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                int max_ = Convert.ToInt32(lbTongSoTrang.Text.Replace(" ", "").Replace("/", ""));
                if (sotrang_ < max_)
                {
                    txtSoTrang.Text = (sotrang_ + 1).ToString();

                    Load_PhieuSX(false);
                }
                else
                {
                    txtSoTrang.Text = (max_).ToString();
                    btnTrangTiep.LinkColor = Color.Black;
                }
            }
            catch
            {
                btnTrangTiep.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void btnTrangSau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isload)
                return;
            if (btnTrangSau.LinkColor == Color.Black)
                return;
            if (btnTrangTiep.LinkColor == Color.Black)
                btnTrangTiep.LinkColor = Color.Blue;

            int sotrang_;
            try
            {
                sotrang_ = Convert.ToInt32(txtSoTrang.Text);
                if (sotrang_ <= 1)
                {
                    txtSoTrang.Text = "1";
                    btnTrangSau.LinkColor = Color.Black;

                }
                else
                {
                    txtSoTrang.Text = (sotrang_ - 1).ToString();
                    Load_PhieuSX(false);
                }
            }
            catch
            {
                btnTrangSau.LinkColor = Color.Black;
                sotrang_ = 1;
                txtSoTrang.Text = "1";
            }
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if(isload)
                return;
            Load_PhieuSX(false);
        }
    }
}
