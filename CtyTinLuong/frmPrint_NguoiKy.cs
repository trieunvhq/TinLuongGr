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
    public partial class frmPrint_NguoiKy : Form
    {
          public static string sNguoiLap, sNguoiNhan, sThuKho, sKeToanTruong, 
            sGiamDoc, sCaTruong, sCongNhan, ssochungtu, ssohoadon, sngaythang;

        private void gridView13_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView13_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaNhanVien)
            {
                clsNhanSu_tbNhanSu cls = new clsNhanSu_tbNhanSu();
                cls.iID_NhanSu = Convert.ToInt32(gridView13.GetRowCellValue(e.RowHandle, e.Column));
                int kk = Convert.ToInt32(gridView13.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dt = cls.SelectOne();
                gridView13.SetRowCellValue(e.RowHandle, clID_NhanSu, kk);
                gridView13.SetRowCellValue(e.RowHandle, clHoTen, cls.sTenNhanVien.Value);
                gridView13.SetRowCellValue(e.RowHandle, clHienThi, "1");


            }
        }

        private void LuuDuLieu()
        {
            
            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
         
           
            string shienthi = "1";
            DataTable dtkkk = (DataTable)gridControl1.DataSource;
            dtkkk.DefaultView.RowFilter = "HienThi=" + shienthi + "";
            DataView dvmoi = dtkkk.DefaultView;
            DataTable dtmoi = dvmoi.ToTable();
            for(int i=0; i<dtmoi.Rows.Count; i++)
            {
                cls.iID_DangNhap= frmDangNhap.miID_DangNhap;
                cls.iID_NhanSu= Convert.ToInt32(dtmoi.Rows[i]["ID_NhanSu"].ToString());
                cls.sMaNhanVien = dtmoi.Rows[i]["MaNhanVien"].ToString();
                cls.sHoTen = dtmoi.Rows[i]["HoTen"].ToString();
                cls.sChucVu = dtmoi.Rows[i]["ChucVu"].ToString();
                cls.bTonTai = true;
                if (dtmoi.Rows[i]["ID"].ToString() != "")
                {
                    int iiiID = Convert.ToInt32(dtmoi.Rows[i]["ID"].ToString());
                    cls.iID = iiiID;
                    cls.Update();
                }
                else
                    cls.Insert();
            }
            
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            LuuDuLieu();
            MessageBox.Show("Đã lưu");
            this.Close();
        }

        private void HienThi()
        {

            clsAaatbMacDinhNguoiKy cls = new CtyTinLuong.clsAaatbMacDinhNguoiKy();
            cls.iID_DangNhap = frmDangNhap.miID_DangNhap;
            DataTable dt = cls.SelectAll_ID_DangNhap();
            if (dt.Rows.Count > 0)
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                dt2.Columns.Add("ID_DangNhap", typeof(string));
                dt2.Columns.Add("ID_NhanSu", typeof(string));
                dt2.Columns.Add("MaNhanVien", typeof(string));
                dt2.Columns.Add("ChucVu", typeof(string));
                dt2.Columns.Add("HoTen", typeof(string));
                dt2.Columns.Add("HienThi", typeof(string));

                for(int i=0; i<dt.Rows.Count; i++)
                {
                    DataRow _ravi1 = dt2.NewRow();
                    _ravi1["ID"] = dt.Rows[i]["ID"].ToString();
                    _ravi1["ID_DangNhap"] = dt.Rows[i]["ID_DangNhap"].ToString();
                    _ravi1["ID_NhanSu"] = dt.Rows[i]["ID_NhanSu"].ToString();
                    _ravi1["MaNhanVien"] = dt.Rows[i]["ID_NhanSu"].ToString();
                    _ravi1["ChucVu"] = dt.Rows[i]["ChucVu"].ToString();
                    _ravi1["HoTen"] = dt.Rows[i]["HoTen"].ToString();
                    _ravi1["HienThi"] = "1";
                    dt2.Rows.Add(_ravi1);
                }
                gridControl1.DataSource = dt2;
            }
            else
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                dt2.Columns.Add("ID_DangNhap", typeof(string));
                dt2.Columns.Add("ID_NhanSu", typeof(string));
                dt2.Columns.Add("MaNhanVien", typeof(string));
                dt2.Columns.Add("ChucVu", typeof(string));
                dt2.Columns.Add("HoTen", typeof(string));
                dt2.Columns.Add("HienThi", typeof(string));
                DataRow _ravi1 = dt2.NewRow();
                _ravi1["ID"] = "";
                _ravi1["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi1["ID_NhanSu"] = "0";
                _ravi1["MaNhanVien"] = "0";
                _ravi1["ChucVu"] = "Người giao";
                _ravi1["HoTen"] = "";
                _ravi1["HienThi"] = "1";
                dt2.Rows.Add(_ravi1);

                DataRow _ravi2 = dt2.NewRow();
                _ravi2["ID"] = "";
                _ravi2["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi2["ID_NhanSu"] = "0";
                _ravi2["MaNhanVien"] = "0";
                _ravi2["ChucVu"] = "Người lập";
                _ravi2["HoTen"] = "";
                _ravi2["HienThi"] = "1";
                dt2.Rows.Add(_ravi2);

                DataRow _ravi3 = dt2.NewRow();
                _ravi3["ID"] = "";
                _ravi3["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi3["ID_NhanSu"] = "0";
                _ravi3["MaNhanVien"] = "0";
                _ravi3["ChucVu"] = "Người nhận";
                _ravi3["HoTen"] = "";
                _ravi3["HienThi"] = "1";
                dt2.Rows.Add(_ravi3);

                DataRow _ravi4 = dt2.NewRow();
                _ravi4["ID"] = "";
                _ravi4["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi4["ID_NhanSu"] = "0";
                _ravi4["MaNhanVien"] = "0";
                _ravi4["ChucVu"] = "Thủ kho";
                _ravi4["HoTen"] = "";
                _ravi4["HienThi"] = "1";
                dt2.Rows.Add(_ravi4);

                DataRow _ravi5 = dt2.NewRow();
                _ravi5["ID"] = "";
                _ravi5["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi5["ID_NhanSu"] = "0";
                _ravi5["MaNhanVien"] = "0";
                _ravi5["ChucVu"] = "Trưởng phòng KH";
                _ravi5["HoTen"] = "";
                _ravi5["HienThi"] = "1";
                dt2.Rows.Add(_ravi5);

                DataRow _ravi6 = dt2.NewRow();
                _ravi6["ID"] = "";
                _ravi6["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi6["ID_NhanSu"] = "0";
                _ravi6["MaNhanVien"] = "0";
                _ravi6["ChucVu"] = "Kế toán trưởng";
                _ravi6["HoTen"] = "";
                _ravi6["HienThi"] = "1";
                dt2.Rows.Add(_ravi6);

               

                DataRow _ravi8 = dt2.NewRow();
                _ravi8["ID"] = "";
                _ravi8["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi8["ID_NhanSu"] = "0";
                _ravi8["MaNhanVien"] = "0";
                _ravi8["ChucVu"] = "Giám đốc";
                _ravi8["HoTen"] = "";
                _ravi8["HienThi"] = "1";
                dt2.Rows.Add(_ravi8);


                DataRow _ravi10 = dt2.NewRow();
                _ravi10["ID"] = "";
                _ravi10["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi10["ID_NhanSu"] = "0";
                _ravi10["MaNhanVien"] = "0";
                _ravi10["ChucVu"] = "Ca trưởng";
                _ravi10["HoTen"] = "";
                _ravi10["HienThi"] = "1";
                dt2.Rows.Add(_ravi10);

                DataRow _ravi11 = dt2.NewRow();
                _ravi11["ID"] = "";
                _ravi11["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi11["ID_NhanSu"] = "0";
                _ravi11["MaNhanVien"] = "0";
                _ravi11["ChucVu"] = "Thủ quỹ";
                _ravi11["HoTen"] = "";
                _ravi11["HienThi"] = "1";
                dt2.Rows.Add(_ravi11);

                DataRow _ravi12 = dt2.NewRow();
                _ravi12["ID"] = "";
                _ravi12["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi12["ID_NhanSu"] = "0";
                _ravi12["MaNhanVien"] = "0";
                _ravi12["ChucVu"] = "Người nộp tiền";
                _ravi12["HoTen"] = "";
                _ravi12["HienThi"] = "1";
                dt2.Rows.Add(_ravi12);

                DataRow _ravi13 = dt2.NewRow();
                _ravi13["ID"] = "";
                _ravi13["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi13["ID_NhanSu"] = "0";
                _ravi13["MaNhanVien"] = "0";
                _ravi13["ChucVu"] = "Bảo vệ";
                _ravi13["HoTen"] = "";
                _ravi13["HienThi"] = "1";
                dt2.Rows.Add(_ravi13);
             

                DataRow _ravi7 = dt2.NewRow();
                _ravi7["ID"] = "";
                _ravi7["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi7["ID_NhanSu"] = "0";
                _ravi7["MaNhanVien"] = "0";
                _ravi7["ChucVu"] = "Kế toán";
                _ravi7["HoTen"] = "";
                _ravi7["HienThi"] = "1";
                dt2.Rows.Add(_ravi7);


                DataRow _ravi9 = dt2.NewRow();
                _ravi9["ID"] = "";
                _ravi9["ID_DangNhap"] = frmDangNhap.miID_DangNhap.ToString();
                _ravi9["ID_NhanSu"] = "0";
                _ravi9["MaNhanVien"] = "0";
                _ravi9["ChucVu"] = "Phó Giám đốc";
                _ravi9["HoTen"] = "";
                _ravi9["HienThi"] = "1";
                dt2.Rows.Add(_ravi9);

                gridControl1.DataSource = dt2;
            }
           

        }
        public void Load_LockUp()
        {
            clsNhanSu_tbNhanSu clsNguoi = new clsNhanSu_tbNhanSu();
            DataTable dtNguoi = clsNguoi.SelectAll();
            dtNguoi.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dv = dtNguoi.DefaultView;
            DataTable dt = dv.ToTable();
            gridMaNhanVien.DataSource = dt;
            gridMaNhanVien.ValueMember = "ID_NhanSu";
            gridMaNhanVien.DisplayMember = "MaNhanVien";
        }
       
        public frmPrint_NguoiKy()
        {
            InitializeComponent();
        }

        private void frmPrint_NguoiKy_Load(object sender, EventArgs e)
        {
            Load_LockUp();           
            HienThi();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

      

        private void frmPrint_NguoiKy_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

    }
}
