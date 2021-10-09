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
    public partial class Tr_frmQuanLyDML_CongNhat : Form
    {
        private int _ID_CongNhan = -1;
        private string _Type = "";
        public static bool mb_TheMoi_DinhMucLuongCongNhat;
        public static string _sMaNhanVien;
        public static int miID_Sua_DinhMucLuongCongNhat;

        public void HienThi()
        {
            try
            {
                using (clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong())
                {
                    DataTable dt = cls.Tr_DinhMuc_Luong_SelectAll(txtTimKiem.Text.Trim());

                    if (checked_ALL.Checked == true)
                    {
                        dt.DefaultView.RowFilter = " TonTai= True";
                    }
                    else
                    {
                        if (checkTheoDoi.Checked == true)
                        {
                            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
                        }
                        else
                        {
                            dt.DefaultView.RowFilter = "TonTai= True and NgungTheoDoi=true";
                        }
                    }
                    DataView dv = dt.DefaultView;
                    DataTable dxxxx = dv.ToTable();
                    gridControl1.DataSource = dxxxx;
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public Tr_frmQuanLyDML_CongNhat()
        {
            _ID_CongNhan = -1;
            _Type = "";
            InitializeComponent();
            PhuCapBaoHiem.Caption = "Phụ cấp\nbảo hiểm";
        }
        private object _frm;
        public Tr_frmQuanLyDML_CongNhat(int id_nhanvien, string type, object frm)
        {
            _ID_CongNhan = id_nhanvien;
            _Type = type;
            _frm = frm;
            InitializeComponent();
            PhuCapBaoHiem.Caption = "Phụ cấp\nbảo hiểm";

            try
            {
                if (_ID_CongNhan >= 0)
                {
                    switch (_Type)
                    {
                        case "frmChamCong_TBX":
                            txtTimKiem.Text = ((frmChamCong_TBX)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_TrgCa":
                            txtTimKiem.Text = ((frmChamCong_TrgCa)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_PTH":
                            txtTimKiem.Text = ((frmChamCong_PTH)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_PKT":
                            txtTimKiem.Text = ((frmChamCong_PKT)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_PMC":
                            txtTimKiem.Text = ((frmChamCong_PMC)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_TDK":
                            txtTimKiem.Text = ((frmChamCong_TDK)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_TDB":
                            txtTimKiem.Text = ((frmChamCong_TDB)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_TMC":
                            txtTimKiem.Text = ((frmChamCong_TMC)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_ToDot":
                            txtTimKiem.Text = ((frmChamCong_ToDot)_frm)._MaNhanVien;
                            break;
                        case "frmChamCong_ToIn":
                            txtTimKiem.Text = ((frmChamCong_ToIn)_frm)._MaNhanVien;
                            break;
                    }
                }
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checked_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_ALL.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checkTheoDoi.Checked = false;
            }
            HienThi();
        }

        private void checkTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTheoDoi.Checked == true)
            {
                checkNgungTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }

        private void checkNgungTheoDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNgungTheoDoi.Checked == true)
            {
                checkTheoDoi.Checked = false;
                checked_ALL.Checked = false;
            }
            HienThi();
        }
        
        private void Tr_frmQuanLyDML_CongNhat_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            checkTheoDoi.Checked = true;
            clNgungTheoDoi.Caption = "Bỏ\n theo dõi";
            mb_TheMoi_DinhMucLuongCongNhat = false;
            HienThi();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString()) != 7)
                {
                    clsTr_DinhMuc_Luong cls = new clsTr_DinhMuc_Luong();
                    cls.iId = Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString());
                    cls.bNgungtheodoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                    //cls.Update_NgungTheoDoi();
                }

            }
            catch
            {

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    clsTr_DinhMuc_Luong cls1 = new clsTr_DinhMuc_Luong();
                    cls1.iId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(id).ToString());
                    //cls1.Delete_W_TonTai();
                    MessageBox.Show("Đã xóa");
                    HienThi();
                }
            }
            catch
            {

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (Convert.ToInt32(gridView1.GetFocusedRowCellValue(id).ToString()) != 0)
                {
                    miID_Sua_DinhMucLuongCongNhat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString());
                    _sMaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
                    mb_TheMoi_DinhMucLuongCongNhat = false;
                    Tr_frmChiTietDML_CongNhat ff = new Tr_frmChiTietDML_CongNhat(this);
                    ff.Show();
                }
                else
                {
                    MessageBox.Show("Định mức 0\n không cho sửa");
                }
            }
            catch(Exception ea)
            {

            }
            //try
            //{ 
            //    if (_ID_CongNhan >= 0)
            //    {
            //        switch (_Type)
            //        {
            //            case "frmChamCong_TBX":
            //                this.Close(); 
            //                ((frmChamCong_TBX)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_TrgCa":
            //                this.Close(); 
            //                ((frmChamCong_TrgCa)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_PTH":
            //                this.Close();
            //                ((frmChamCong_PTH)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_PKT":
            //                this.Close();
            //                ((frmChamCong_PKT)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_PMC":
            //                this.Close();
            //                ((frmChamCong_PMC)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_TDK":
            //                this.Close();
            //                ((frmChamCong_TDK)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_TDB":
            //                this.Close();
            //                ((frmChamCong_TDB)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_TMC":
            //                this.Close();
            //                ((frmChamCong_TMC)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_ToDot":
            //                this.Close();
            //                ((frmChamCong_ToDot)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //            case "frmChamCong_ToIn":
            //                this.Close();
            //                ((frmChamCong_ToIn)_frm).Load_DinhMuc
            //                    (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString())
            //                    , gridView1.GetFocusedRowCellValue(MaNhanVien).ToString(),
            //                    _ID_CongNhan);
            //                break;
            //        } 
            //    }
            //    else
            //    {
            //        if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString()) != 0)
            //        {
            //            miID_Sua_DinhMucLuongCongNhat = Convert.ToInt16(gridView1.GetFocusedRowCellValue(id).ToString());
            //            _sMaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
            //            mb_TheMoi_DinhMucLuongCongNhat = false;
            //            Tr_frmChiTietDML_CongNhat ff = new Tr_frmChiTietDML_CongNhat(this);
            //            ff.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Định mức 0\n không cho sửa");
            //        }
            //    }
               
                   
            //}
            //catch (Exception ee)
            //{

            //}
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mb_TheMoi_DinhMucLuongCongNhat = true;
            Tr_frmChiTietDML_CongNhat ff = new Tr_frmChiTietDML_CongNhat(this);
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmQuanLyDML_CongNhat_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    decimal category = CheckString.ConvertToDecimal_My(View.GetRowCellValue(e.RowHandle, View.Columns["LuongCoDinh"]));
            //    if (category != 0)
            //    {
            //        e.Appearance.BackColor = Color.Orange;
            //        //e.Appearance.BackColor = Color.Salmon;
            //        //e.Appearance.BackColor2 = Color.SeaShell;

            //    }
            //}
        }

        private void nghichngu()
        {
            using (clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu())
            {
                string s = "TL000000";
                clsThin cls = new clsThin();
                DataTable dt = clsNguoi.T_SelectAll(8);

                dt = clsNguoi.T_SelectAll(0);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string idcn = s.Substring(0, 8 - (i+1).ToString().Length) + (i+1).ToString();
                    cls.Tr_Replace_All(Convert.ToInt32(dt.Rows[i]["ID_NhanSu"].ToString()),
                        idcn,
                        CheckString.ChuanHoaHoTen(dt.Rows[i]["TenNhanVien"].ToString()));
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
