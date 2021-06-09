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
    public partial class SanXuat_frmDanhSachChamCong : Form
    {
        public SanXuat_frmDanhSachChamCong()
        {
            InitializeComponent();
        }
        private void LuuDuLieuThemMoi()
        {
            int iiixxthang = Convert.ToInt32(txtThang.Text.ToString());
            int iiixxnam = Convert.ToInt32(txtNam.Text.ToString());

            clsHuu_CongNhat cls1 = new clsHuu_CongNhat();
            cls1.iThang = iiixxthang;
            cls1.iNam = iiixxnam;
            cls1.dcTongLuong = 0;
            cls1.dcPhuCapDienthoai = 0;
            cls1.dcPhuCapTienAn = 0;
            cls1.dcPhuCapVeSinhMay = 0;
            cls1.dcPhuCapXangXe = 0;
            cls1.dcTrachNhiem = 0;
            cls1.dcTruTienAn = 0;
            cls1.dcTamUng = 0;
            cls1.dcBaoHiem = 0;
            cls1.dcSoTienDaTraLuong = 0;
            cls1.dcThucNhan = 0;            
            cls1.bGuiDuLieu = false;
            cls1.bTonTai = true;
            cls1.bNgungTheoDoi = false;
            cls1.sGhiChu = "";
            cls1.Insert();

            int ixID_ChamCong = cls1.iID_ChamCong.Value;

           
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "ChamCong = True";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();

            if (dv3.Rows.Count > 0)
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls2 = new clsHUU_CongNhat_ChiTiet_ChamCong();
                //clsHUU_BangLuong clsxx = new clsHUU_BangLuong();
                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    clsHUU_DinhMucLuong_CongNhat clsdm = new clsHUU_DinhMucLuong_CongNhat();

                    cls2.iID_CongNhan = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
                    cls2.iID_ChamCong = ixID_ChamCong;
                    cls2.iID_DinhMucLuong_CongNhat = Convert.ToInt32(dv3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                    cls2.iThang = iiixxthang;
                    cls2.iNam = iiixxnam;
                    cls2.fSLTangCa = 0;
                    cls2.fSLThuong = 0;                   
                    cls2.fNgay1 = cls2.fNgay2 = cls2.fNgay3 = cls2.fNgay4 = cls2.fNgay5 = cls2.fNgay6 = cls2.fNgay7 = cls2.fNgay8 = cls2.fNgay9 = cls2.fNgay10
                        = cls2.fNgay11 = cls2.fNgay12 = cls2.fNgay13 = cls2.fNgay14 = cls2.fNgay15 = cls2.fNgay16 = cls2.fNgay17 = cls2.fNgay18 = cls2.fNgay19 = cls2.fNgay20
                        = cls2.fNgay21 = cls2.fNgay22 = cls2.fNgay23 = cls2.fNgay24 = cls2.fNgay25 = cls2.fNgay26 = cls2.fNgay27 = cls2.fNgay28 = cls2.fNgay29 = cls2.fNgay30 = cls2.fNgay31 = 0;

                    cls2.fTCNgay1 = cls2.fTCNgay2 = cls2.fTCNgay3 = cls2.fTCNgay4 = cls2.fTCNgay5 = cls2.fTCNgay6 = cls2.fTCNgay7 = cls2.fTCNgay8 = cls2.fTCNgay9 = cls2.fTCNgay10
                       = cls2.fTCNgay11 = cls2.fTCNgay12 = cls2.fTCNgay13 = cls2.fTCNgay14 = cls2.fTCNgay15 = cls2.fTCNgay16 = cls2.fTCNgay17 = cls2.fTCNgay18 = cls2.fTCNgay19 = cls2.fTCNgay20
                       = cls2.fTCNgay21 = cls2.fTCNgay22 = cls2.fTCNgay23 = cls2.fTCNgay24 = cls2.fTCNgay25 = cls2.fTCNgay26 = cls2.fTCNgay27 = cls2.fTCNgay28 = cls2.fTCNgay29 = cls2.fTCNgay30 = cls2.fTCNgay31 = 0;
                    cls2.bGuiDuLieu = false;

                    clsdm.iID_DinhMucLuong_CongNhat = Convert.ToInt32(dv3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                    DataTable dtdmluong = clsdm.SelectOne();
                    cls2.dcLuongCoDinh = clsdm.dcLuongCoDinh.Value;
                    cls2.dcLuongCongNhat = 0;
                    cls2.dcLuongSanLuong = 0;
                    cls2.dcLuongLonNhat = 0;
                    cls2.dcPhuCapXangXe = clsdm.dcPhuCapXangXe.Value;
                    cls2.dcPhuCapDienthoai = clsdm.dcPhuCapDienthoai.Value;
                    cls2.dcPhuCapTienAn = clsdm.dcPhuCapTienAn.Value;
                    cls2.dcPhuCapVeSinhMay = clsdm.dcPhuCapVeSinhMay.Value;
                    cls2.dcTrachNhiem = clsdm.dcTrachNhiem.Value;
                    cls2.dcTruTienAn = 0;
                    cls2.dcTamUng = 0;
                    cls2.dcBaoHiem = clsdm.dcBaoHiem.Value;
                    cls2.dcSoTienDaTraLuong = 0;
                    cls2.dcThucNhan = 0;
                    cls2.bDaTraLuong = false;
                    cls2.dcTrachNhiem = clsdm.dcTrachNhiem.Value;
                    cls2.bCheck_ChamCongGapDan= Convert.ToBoolean(dv3.Rows[i]["GapDan"].ToString());
                    cls2.Insert();                  
                }
            }
            //DataTable dt3333 = (DataTable)gridControl1.DataSource;
            //dt3333.DefaultView.RowFilter = "GapDan = True";
            //DataView dv3333 = dt3333.DefaultView;
            //DataTable dtmoi = dv3333.ToTable();
            //if (dtmoi.Rows.Count > 0)
            //{
            //    clsHuu_CongNhat_ChiTiet_ChamCong_ToGapDan cls_GD = new clsHuu_CongNhat_ChiTiet_ChamCong_ToGapDan();
            //    clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh clsmacdinh = new clsHuu_CongNhat_MaHang_ToGapDan_CaiMacDinh();
            //    clsmacdinh.iThang = iiixxthang;
            //    clsmacdinh.iNam = iiixxnam;
            //    DataTable dtmacdinh = clsmacdinh.SelectAll_WW_Thang_WW_Nam();

            //    for (int i = 0; i < dtmoi.Rows.Count; i++)
            //    {
            //        cls_GD.iID_CongNhan = Convert.ToInt32(dtmoi.Rows[i]["ID_CongNhan"].ToString());
            //        cls_GD.iThang = iiixxthang;
            //        cls_GD.iNam = iiixxnam;
            //        if (dtmacdinh.Rows.Count == 0)
            //            for (int j = 0; j < dtmacdinh.Rows.Count; j++)
            //            {
            //                cls_GD.iID_VTHH = Convert.ToInt32(dtmacdinh.Rows[j]["ID_VTHH"].ToString());
            //                cls_GD.bDaCaiDat = false;
            //                cls_GD.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(dtmacdinh.Rows[j]["ID_DinhMuc_Luong_SanLuong"].ToString());
            //                cls_GD.Insert();
            //            }
            //    }
                
            //}
            MessageBox.Show("Đã lưu");
            this.Close();            
        }
        private void Luu_BoSungCOngNhanTrongThang()
        {
            int iiixxthang = Convert.ToInt32(txtThang.Text.ToString());
            int iiixxnam = Convert.ToInt32(txtNam.Text.ToString());
           

            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "ChamCong = True";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();            
            if (dv3.Rows.Count > 0)
            {
                clsHUU_CongNhat_ChiTiet_ChamCong cls2 = new clsHUU_CongNhat_ChiTiet_ChamCong();
                //clsHUU_BangLuong clsxx = new clsHUU_BangLuong();
                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    clsHUU_DinhMucLuong_CongNhat clsdm = new clsHUU_DinhMucLuong_CongNhat();
                    string tencongnhan = dv3.Rows[i]["TenNhanVien"].ToString();
                    string filterExpression = "TenNhanVien='"+tencongnhan+"'"; 
                    DataRow[] rows = frmBangChamCongTrongThang.mdataatbaleDanhSachChamCOng.Select(filterExpression);                  
                    if (rows.Length == 0)
                    {
                        cls2.iID_CongNhan = Convert.ToInt32(dv3.Rows[i]["ID_CongNhan"].ToString());
                        cls2.iID_ChamCong = frmBangChamCongTrongThang.miiID_ChamCong;
                        cls2.iID_DinhMucLuong_CongNhat = Convert.ToInt32(dv3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                        cls2.iThang = iiixxthang;
                        cls2.iNam = iiixxnam;
                        cls2.fSLTangCa = 0;
                        cls2.fSLThuong = 0;
                        cls2.fNgay1 = cls2.fNgay2 = cls2.fNgay3 = cls2.fNgay4 = cls2.fNgay5 = cls2.fNgay6 = cls2.fNgay7 = cls2.fNgay8 = cls2.fNgay9 = cls2.fNgay10
                            = cls2.fNgay11 = cls2.fNgay12 = cls2.fNgay13 = cls2.fNgay14 = cls2.fNgay15 = cls2.fNgay16 = cls2.fNgay17 = cls2.fNgay18 = cls2.fNgay19 = cls2.fNgay20
                            = cls2.fNgay21 = cls2.fNgay22 = cls2.fNgay23 = cls2.fNgay24 = cls2.fNgay25 = cls2.fNgay26 = cls2.fNgay27 = cls2.fNgay28 = cls2.fNgay29 = cls2.fNgay30 = cls2.fNgay31 = 0;

                        cls2.fTCNgay1 = cls2.fTCNgay2 = cls2.fTCNgay3 = cls2.fTCNgay4 = cls2.fTCNgay5 = cls2.fTCNgay6 = cls2.fTCNgay7 = cls2.fTCNgay8 = cls2.fTCNgay9 = cls2.fTCNgay10
                           = cls2.fTCNgay11 = cls2.fTCNgay12 = cls2.fTCNgay13 = cls2.fTCNgay14 = cls2.fTCNgay15 = cls2.fTCNgay16 = cls2.fTCNgay17 = cls2.fTCNgay18 = cls2.fTCNgay19 = cls2.fTCNgay20
                           = cls2.fTCNgay21 = cls2.fTCNgay22 = cls2.fTCNgay23 = cls2.fTCNgay24 = cls2.fTCNgay25 = cls2.fTCNgay26 = cls2.fTCNgay27 = cls2.fTCNgay28 = cls2.fTCNgay29 = cls2.fTCNgay30 = cls2.fTCNgay31 = 0;
                        cls2.bGuiDuLieu = false;

                        clsdm.iID_DinhMucLuong_CongNhat = Convert.ToInt32(dv3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString());
                        DataTable dtdmluong = clsdm.SelectOne();
                        cls2.dcLuongCoDinh = clsdm.dcLuongCoDinh.Value;
                        cls2.dcLuongCongNhat = 0;
                        cls2.dcLuongSanLuong = 0;
                        cls2.dcLuongLonNhat = 0;
                        cls2.dcPhuCapXangXe = clsdm.dcPhuCapXangXe.Value;
                        cls2.dcPhuCapDienthoai = clsdm.dcPhuCapDienthoai.Value;
                        cls2.dcPhuCapTienAn = clsdm.dcPhuCapTienAn.Value;
                        cls2.dcPhuCapVeSinhMay = clsdm.dcPhuCapVeSinhMay.Value;
                        cls2.dcTrachNhiem = clsdm.dcTrachNhiem.Value;
                        cls2.dcTruTienAn = 0;
                        cls2.dcTamUng = 0;
                        cls2.dcBaoHiem = clsdm.dcBaoHiem.Value;
                        cls2.dcSoTienDaTraLuong = 0;
                        cls2.dcThucNhan = 0;
                        cls2.bDaTraLuong = false;
                        cls2.dcTrachNhiem = clsdm.dcTrachNhiem.Value;
                        cls2.bCheck_ChamCongGapDan= Convert.ToBoolean(dv3.Rows[i]["GapDan"].ToString());
                        cls2.Insert();   
                    }
                    else
                    {
                    }                    
                }
            }
            MessageBox.Show("Đã thêm mới");
            this.Close();
        }
        private void HienThi()
        {
            clsHUU_DinhMucLuong_CongNhat clsluong = new clsHUU_DinhMucLuong_CongNhat();
            DataTable dtcongnhat = clsluong.SelectAll();
            dtcongnhat.DefaultView.RowFilter = " TonTai=True and NgungTheoDoi=false";
            DataView dvcongnhat = dtcongnhat.DefaultView;
            DataTable dxcongnhat = dvcongnhat.ToTable();
            
            if(dxcongnhat.Rows.Count>0)
            {
                repositoryItemGridLookUpEdit1.DataSource = dxcongnhat;
                repositoryItemGridLookUpEdit1.ValueMember = "ID_DinhMucLuong_CongNhat";
                repositoryItemGridLookUpEdit1.DisplayMember = "MaDinhMucLuongCongNhat";
            }

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_CongNhan", typeof(int));
            dt2.Columns.Add("MaNhanVien", typeof(string));
            dt2.Columns.Add("TenNhanVien", typeof(string));
            dt2.Columns.Add("TenChucVu", typeof(string));
            dt2.Columns.Add("TenBoPhan", typeof(string));
            dt2.Columns.Add("MaDinhMucLuongCongNhat", typeof(string));

            dt2.Columns.Add("DienGiai", typeof(string));
            dt2.Columns.Add("ChamCong", typeof(bool));
            dt2.Columns.Add("ID_DinhMucLuong_CongNhat", typeof(string));
            dt2.Columns.Add("BaoHiem", typeof(string));
            dt2.Columns.Add("GapDan", typeof(bool));
            //BaoHiem



            DataTable dt = clsluong.SelectAll_W_tbNhanSu_HienThi_ChonChamCongNhat();
            dt.DefaultView.RowFilter = " TonTai=True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dt3 = dv.ToTable();            
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_CongNhan"] = Convert.ToInt32(dt3.Rows[i]["ID_NhanSu"].ToString());
                _ravi["MaNhanVien"] = dt3.Rows[i]["MaNhanVien"].ToString();
                _ravi["TenNhanVien"] = dt3.Rows[i]["TenNhanVien"].ToString();
                _ravi["TenChucVu"] = dt3.Rows[i]["TenChucVu"].ToString();
                _ravi["TenBoPhan"] = dt3.Rows[i]["TenBoPhan"].ToString();
                _ravi["MaDinhMucLuongCongNhat"] = dt3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString();
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                _ravi["ChamCong"] = false;
                _ravi["GapDan"] = false;
                _ravi["ID_DinhMucLuong_CongNhat"] = dt3.Rows[i]["ID_DinhMucLuong_CongNhat"].ToString();
                _ravi["BaoHiem"] = dt3.Rows[i]["BaoHiem"].ToString();       
                dt2.Rows.Add(_ravi);
            }

            gridControl1.DataSource = dt2;
         
        }
        private void SanXuat_frmDanhSachChamCong_Load(object sender, EventArgs e)
        {
            DateTime ngayhomnay = DateTime.Today;
            txtThang.Text = ngayhomnay.ToString("MM");
            txtNam.Text = ngayhomnay.ToString("yyyy");
            clChamCong.Caption = "Chấm\n công";
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                cls.iID_NhanSu = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                cls.bLuongCongNhat = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clChamCong).ToString());
                cls.Update_ChamCongNhat();
            }
            catch
            {

            }
        }
       

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.ToString() != "" & txtNam.Text.ToString() != "")
            {
                clsHuu_CongNhat cls = new clsHuu_CongNhat();
                string ssxxthang = txtThang.Text.ToString();
                string ssxxnam = txtNam.Text.ToString();
                cls.iThang = Convert.ToInt32(txtThang.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                DataTable dt = cls.SelectOne_Thang_W_Nam();
                dt.DefaultView.RowFilter = " TonTai=True";
                DataView dv = dt.DefaultView;
                DataTable dxxxx = dv.ToTable();
                if (dxxxx.Rows.Count > 0)
                {
                    MessageBox.Show("Đã có dữ liệu lương tháng " + ssxxthang + "    năm " + ssxxnam + "\n Vui lòng chọn lại");
                    return;
                }

            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (frmBangChamCongTrongThang.mbBosungCongNhantrongthang == true)
                Luu_BoSungCOngNhanTrongThang();
            else
            {
                clsHuu_CongNhat cls = new clsHuu_CongNhat();
                string ssxxthang = txtThang.Text.ToString();
                string ssxxnam = txtNam.Text.ToString();
                cls.iThang = Convert.ToInt32(txtThang.Text.ToString());
                cls.iNam = Convert.ToInt32(txtNam.Text.ToString());
                DataTable dt = cls.SelectOne_Thang_W_Nam();
                dt.DefaultView.RowFilter = " TonTai=True";
                DataView dv = dt.DefaultView;
                DataTable dxxxx = dv.ToTable();
                if (dxxxx.Rows.Count > 0)
                {
                    MessageBox.Show("Đã có dữ liệu lương tháng " + ssxxthang + "    năm " + ssxxnam + "\n Vui lòng chọn lại");
                    return;
                }
                else
                {
                    LuuDuLieuThemMoi();
                }
            }
           
           
               
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            //CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            //string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            //DataView dv1212 = new DataView(DatatableABC);
            //dv1212.RowFilter = filterString;
            //DataTable dttttt2 = dv1212.ToTable();
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;

            if (checkBox1.Checked==true)
            {
                
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    dttttt2.Rows[i]["ChamCong"] = true;
                }
                gridControl1.DataSource = dttttt2;   
                         
            }
            if (checkBox1.Checked == false)
            {
             
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    dttttt2.Rows[i]["ChamCong"] = false;
                }
                gridControl1.DataSource = dttttt2;   
                         
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaDinhMucLuongCongNhat)
            {
                clsHUU_DinhMucLuong_CongNhat cls = new clsHUU_DinhMucLuong_CongNhat();
                cls.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                if (dt != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, clID_DinhMucLuong_CongNhat, kk);
                  
                }
            }
            if (e.Column == clGapDan)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, e.Column)) == true)
                   
                    gridView1.SetRowCellValue(e.RowHandle, clChamCong, true);

                
            }
        }

        private void SanXuat_frmDanhSachChamCong_FormClosed(object sender, FormClosedEventArgs e)
        {
            //clsHUU_CongNhat_ChiTiet_ChamCong cls = new CtyTinLuong.clsHUU_CongNhat_ChiTiet_ChamCong();
          
            //cls.iID_ChamCong = UCBangLuong.mID_iD_ChamCong;
            //cls.iThang = UCBangLuong.miiThang;
            //cls.iNam = UCBangLuong.miiNam;
            //DataTable dt = cls.Select_ALL_Thang_W_Nam();

            //clsHuu_CongNhat clsxx = new clsHuu_CongNhat();

            //decimal detongluong;
            //object tongluongxx = dt.Compute("sum(TongLuong)", "GuiDuLieu= False");
            //detongluong = Convert.ToDecimal(tongluongxx);

            //clsxx.iID_ChamCong = UCBangLuong.mID_iD_ChamCong;
            //clsxx.dcTongLuong = detongluong;
            //clsxx.Update_TongLuong();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //DataTable DatatableABC = (DataTable)gridControl1.DataSource;
            //CriteriaOperator op = gridView1.ActiveFilterCriteria; // filterControl1.FilterCriteria
            //string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(op);
            //DataView dv1212 = new DataView(DatatableABC);
            //dv1212.RowFilter = filterString;
            //DataTable dttttt2 = dv1212.ToTable();
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            if (checkBox2.Checked == true)
            {
               
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    dttttt2.Rows[i]["GapDan"] = true;
                }
                gridControl1.DataSource = dttttt2;

            }
            if (checkBox2.Checked == false)
            {
              
                for (int i = 0; i < dttttt2.Rows.Count; i++)
                {
                    dttttt2.Rows[i]["GapDan"] = false;
                }
                gridControl1.DataSource = dttttt2;

            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
