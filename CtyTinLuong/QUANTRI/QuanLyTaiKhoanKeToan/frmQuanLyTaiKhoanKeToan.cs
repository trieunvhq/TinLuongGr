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
    public partial class frmQuanLyTaiKhoanKeToan : Form
    {

        public static bool mbTheMoi;
        public static int miID_TaiKhoan;

        private void Load_DaTa(bool bMe_True_COn_False)
        {
            DataTable data_ = new DataTable();
            DataTable dtMe = new DataTable();
            DataTable dtCon = new DataTable();
            DataTable dtChau = new DataTable();


            data_.Columns.Add("ID_TaiKhoanKeToan", typeof(int));
            data_.Columns.Add("NgungTheoDoi");
            data_.Columns.Add("SoTaiKhoan");
            data_.Columns.Add("TenTaiKhoan");
            data_.Columns.Add("Khoa", typeof(bool));


            clsNganHang_tbHeThongTaiKhoanKeToanMe clsm = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            dtMe = clsm.SA_new();

            using (clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon())
            {
                dtCon = cls.Tr_NganHang_SoTaiKhoanCon_S();
                dtChau = cls.Tr_NganHang_SoTaiKhoanChau_S();
            }

            //if (bMe_True_COn_False==true)
            //{
            //    clsNganHang_tbHeThongTaiKhoanKeToanMe cls = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            //    dtMe = cls.SA_new();
            //    gridControl1.DataSource = dtMe;
            //}
            //else
            //{
            //    clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            //    dtCon = cls.SA();              
            //    gridControl1.DataSource = dtCon;
            //}

            for (int i = 0; i < dtMe.Rows.Count; i++)
            {
                DataRow r = data_.NewRow();
                r["ID_TaiKhoanKeToan"] = dtMe.Rows[i]["ID_TaiKhoanKeToan"];
                //r["NgungTheoDoi"] = dtMe.Rows[i]["NgungTheoDoi"];
                r["SoTaiKhoan"] = dtMe.Rows[i]["SoTaiKhoan"];
                r["TenTaiKhoan"] = dtMe.Rows[i]["TenTaiKhoan"];
                r["Khoa"] = dtMe.Rows[i]["Khoa"];

                data_.Rows.Add(r);
                for (int k = 0; k< dtCon.Rows.Count; k ++)
                {
                    DataRow rcon = data_.NewRow();
                    rcon["ID_TaiKhoanKeToan"] = dtCon.Rows[i]["ID_TaiKhoanKeToan"];
                    //rcon["NgungTheoDoi"] = dtCon.Rows[i]["NgungTheoDoi"];
                    rcon["SoTaiKhoan"] = dtCon.Rows[i]["SoTaiKhoan"];
                    rcon["TenTaiKhoan"] = dtCon.Rows[i]["TenTaiKhoan"];
                    rcon["Khoa"] = dtCon.Rows[i]["Khoa"];
                    data_.Rows.Add(rcon);

                    for (int m = 0; m < dtChau.Rows.Count; m++)
                    {
                        DataRow rchau = data_.NewRow();
                        rchau["ID_TaiKhoanKeToan"] = dtChau.Rows[i]["ID_TaiKhoanKeToan"];
                        //rchau["NgungTheoDoi"] = dtChau.Rows[i]["NgungTheoDoi"];
                        rchau["SoTaiKhoan"] = dtChau.Rows[i]["SoTaiKhoan"];
                        rchau["TenTaiKhoan"] = dtChau.Rows[i]["TenTaiKhoan"];
                        rchau["Khoa"] = dtChau.Rows[i]["Khoa"];
                        data_.Rows.Add(rchau);
                    }
                }

            }

            gridControl1.DataSource = data_;
        }



        public frmQuanLyTaiKhoanKeToan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoanKeToan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbTheMoi = false;
            checkCon.Checked = true;
            Cursor.Current = Cursors.Default;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
                cls.iID_TaiKhoanKeToanCon = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                cls.bNgungTheoDoi = Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clNgungTheoDoi).ToString());
                cls.Update_NgungTheoDoi();
            }
            catch
            {

            }
        }

        private void btCHiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            DialogResult traloi;
            traloi = MessageBox.Show("Xóa dữ liệu này?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (traloi == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                bool bkhoa= Convert.ToBoolean(gridView1.GetFocusedRowCellValue(clKhoa).ToString());
                if (bkhoa == true)
                {
                    MessageBox.Show("Dữ liệu đã khoá, không thể xoá");
                    return;
                }
                else
                {
                    if (checkMe.Checked == true)
                    {
                        clsNganHang_tbHeThongTaiKhoanKeToanMe cls1 = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
                        cls1.iID_TaiKhoanKeToanMe = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                        cls1.Delete();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(true);
                    }
                    else
                    {
                        clsNganHang_TaiKhoanKeToanCon cls1 = new clsNganHang_TaiKhoanKeToanCon();
                        cls1.iID_TaiKhoanKeToanCon = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());
                        cls1.Delete();
                        MessageBox.Show("Đã xóa");
                        Load_DaTa(false);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                miID_TaiKhoan = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_TaiKhoanKeToan).ToString());             
                mbTheMoi = false;
                if(checkCon.Checked==true)
                {
                    frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
                    ff.Show();
                }
                else
                {
                    frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
                    ff.Show();
                }
               
                Cursor.Current = Cursors.Default;
            }
            catch
            {

            }
        }

        public void btRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frmQuanLyTaiKhoanKeToan_Load(sender, e);
            Cursor.Current = Cursors.Default;
        }

     

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkMe_CheckedChanged(object sender, EventArgs e)
        {
            if(checkMe.Checked==true)
            {
                checkCon.Checked = false;
                Load_DaTa(true);
            }
            
        }

        private void checkCon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCon.Checked == true)
            {
                checkMe.Checked = false;
                Load_DaTa(false);
            }
           
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbTheMoi = true;
            if (checkCon.Checked == true)
            {
                frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
                ff.Show();
            }
            else
            {
                frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
                ff.Show();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
