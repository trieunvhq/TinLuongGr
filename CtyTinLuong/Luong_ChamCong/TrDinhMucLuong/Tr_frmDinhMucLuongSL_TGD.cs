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
    public partial class Tr_frmDinhMucLuongSL_TGD : Form
    {
        private int _ID_CongNhan = -1;
        private string _Type = "";
        public static bool _bThemMoi_DinhMucLuong;
        public static string sTenDinhMucLuong;
        public static int _iSua_DinhMucLuong;

        public void HienThi()
        {
            clsTr_DinhMucLuongSL_TGD cls = new clsTr_DinhMucLuongSL_TGD();
            DataTable dt = cls.Tr_DinhMucLuongSL_TGD_SelectAll();

            gridControl1.DataSource = dt;
        }

        public Tr_frmDinhMucLuongSL_TGD()
        {
            _ID_CongNhan = -1;
            _Type = "";
            InitializeComponent();
        }
        private object _frm;
        public Tr_frmDinhMucLuongSL_TGD(int id_nhanvien, string type, object frm)
        {
            _ID_CongNhan = id_nhanvien;
            _Type = type;
            _frm = frm;
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void Tr_frmDinhMucLuongSL_TGD_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _bThemMoi_DinhMucLuong = false;
            HienThi();
            Cursor.Current = Cursors.Default;
        }


        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (traloi == DialogResult.OK)
                {
                    clsHUU_DinhMucLuong_CongNhat cls1 = new clsHUU_DinhMucLuong_CongNhat();
                    cls1.iID_DinhMucLuong_CongNhat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_DinhMucLuong).ToString());
                    cls1.Delete_W_TonTai();
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
                if (_ID_CongNhan >= 0)
                {
                    switch (_Type)
                    {
                        case "frmChamCongToGapDan":
                            this.Close(); 
                            ((frmChamCongToGapDan)_frm).Load_DinhMuc
                                (Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_DinhMucLuong).ToString())
                                , gridView1.GetFocusedRowCellValue(MaDinhMucLuong).ToString(),
                                _ID_CongNhan);
                            break;
                        
                    } 
                }
                else
                {
                    if (Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_DinhMucLuong).ToString()) != 0)
                    {
                        _iSua_DinhMucLuong = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_DinhMucLuong).ToString());
                        sTenDinhMucLuong = gridView1.GetFocusedRowCellValue(MaDinhMucLuong).ToString();
                        _bThemMoi_DinhMucLuong = false;
                        //frmChiTietDinhMucLuongCongNhat_Newwwwww ff = new frmChiTietDinhMucLuongCongNhat_Newwwwww(this);
                        //ff.Show();
                    }
                    else
                    {
                        MessageBox.Show("Định mức 0\n không cho sửa");
                    }
                }
               
                   
            }
            catch (Exception ee)
            {

            }
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
            _bThemMoi_DinhMucLuong = true;
            //frmChiTietDinhMucLuongCongNhat_Newwwwww ff = new frmChiTietDinhMucLuongCongNhat_Newwwwww(this);
            //ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tr_frmDinhMucLuongSL_TGD_Load(sender, e);
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
    }
}
