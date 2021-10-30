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
    public partial class frmQuanLyTaiKhoanKeToan : Form
    {

        public static bool mbTheMoi;
        public static int miID_TaiKhoan;
        DataTable _data;

        private void Load_DaTa(bool bMe_True_COn_False)
        {
            _data = new DataTable();
            DataTable dtMe = new DataTable();
            DataTable dtCon = new DataTable();
            DataTable dtChau = new DataTable();


            _data.Columns.Add("ID_TaiKhoanKeToan", typeof(int));
            _data.Columns.Add("NgungTheoDoi");
            _data.Columns.Add("SoTaiKhoan");
            _data.Columns.Add("TenTaiKhoan");
            _data.Columns.Add("LoaiTK");
            _data.Columns.Add("Khoa", typeof(bool));


            clsNganHang_tbHeThongTaiKhoanKeToanMe clsm = new clsNganHang_tbHeThongTaiKhoanKeToanMe();
            dtMe = clsm.SA_new();

            using (clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon())
            {
                dtCon = cls.Tr_NganHang_SoTaiKhoanCon_S();
                dtChau = cls.Tr_NganHang_SoTaiKhoanChau_S();
            }

           

            for (int i = 0; i < dtMe.Rows.Count; i++)
            {
                DataRow r = _data.NewRow();
                int idme = Convert.ToInt32(dtMe.Rows[i]["ID_TaiKhoanKeToan"].ToString());
                r["ID_TaiKhoanKeToan"] = dtMe.Rows[i]["ID_TaiKhoanKeToan"];
                //r["NgungTheoDoi"] = dtMe.Rows[i]["NgungTheoDoi"];
                r["SoTaiKhoan"] = dtMe.Rows[i]["SoTaiKhoan"];
                r["TenTaiKhoan"] = dtMe.Rows[i]["TenTaiKhoan"];
                r["Khoa"] = dtMe.Rows[i]["Khoa"];
                r["LoaiTK"] = "LaMe";


                _data.Rows.Add(r);
                for (int k = 0; k< dtCon.Rows.Count; k ++)
                {
                    int idcon = Convert.ToInt32(dtCon.Rows[k]["ID_TaiKhoanKeToan"].ToString());

                    if (idme == Convert.ToInt32(dtCon.Rows[k]["ID_TaiKhoanKeToanMe"].ToString()))
                    {
                        DataRow rcon = _data.NewRow();
                        rcon["ID_TaiKhoanKeToan"] = dtCon.Rows[k]["ID_TaiKhoanKeToan"];
                        //rcon["NgungTheoDoi"] = dtCon.Rows[k]["NgungTheoDoi"];
                        rcon["SoTaiKhoan"] = dtCon.Rows[k]["SoTaiKhoan"];
                        rcon["TenTaiKhoan"] = "        " + dtCon.Rows[k]["TenTaiKhoan"].ToString();
                        rcon["Khoa"] = dtCon.Rows[k]["Khoa"];
                        rcon["LoaiTK"] = "LaCon";
                        _data.Rows.Add(rcon);
                        dtCon.Rows.RemoveAt(k);

                        for (int m = 0; m < dtChau.Rows.Count; m++)
                        {
                            if (idme == Convert.ToInt32(dtChau.Rows[m]["ID_TaiKhoanKeToanMe"].ToString()))
                            {
                                DataRow rchau = _data.NewRow();
                                rchau["ID_TaiKhoanKeToan"] = dtChau.Rows[m]["ID_TaiKhoanKeToan"];
                                //rchau["NgungTheoDoi"] = dtChau.Rows[m]["NgungTheoDoi"];
                                rchau["SoTaiKhoan"] = dtChau.Rows[m]["SoTaiKhoan"];
                                rchau["TenTaiKhoan"] = "                " + dtChau.Rows[m]["TenTaiKhoan"].ToString();
                                rchau["Khoa"] = dtChau.Rows[m]["Khoa"];
                                rchau["LoaiTK"] = "LaChau";
                                _data.Rows.Add(rchau);
                                dtChau.Rows.RemoveAt(m);
                            }
                        }
                    }
                }
            }

            gridControl1.DataSource = _data;
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
                    if (gridView1.GetFocusedRowCellValue(LoaiTK).ToString() == "LaMe")//(checkMe.Checked == true)
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

                string loaiTK = gridView1.GetFocusedRowCellValue(LoaiTK).ToString();
                if (loaiTK == "LaMe")
                {
                    frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
                    ff.Show();
                }
                else
                {
                    frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
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
            frmChiTietTaiKhoanKeToanCon ff = new frmChiTietTaiKhoanKeToanCon(this, null, null);
            ff.Show();
            Cursor.Current = Cursors.Default;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string loaiTK = View.GetRowCellValue(e.RowHandle, View.Columns["LoaiTK"]).ToString();
                if (loaiTK == "LaMe")
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
                    //e.Appearance.BackColor = Color.Bisque;
                }
                else if (loaiTK == "LaCon")
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold| System.Drawing.FontStyle.Italic);
                    //e.Appearance.BackColor = Color.Bisque;
                }
                else
                {
                    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
                }
            }

            //GridView view = sender as GridView;
            //if (e. == _data.Rows.Count - 1)
            //{
            //    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //}
        }

        private void btnThemMoiTKme_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            mbTheMoi = true;
            frmChiTietTaiKhoanKeToan ff = new CtyTinLuong.frmChiTietTaiKhoanKeToan();
            ff.Show();
            Cursor.Current = Cursors.Default;
        }
    }
}
