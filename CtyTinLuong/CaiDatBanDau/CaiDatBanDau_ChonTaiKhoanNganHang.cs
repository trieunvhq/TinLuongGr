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
    public partial class CaiDatBanDau_ChonTaiKhoanNganHang : Form
    {
        private void Luu_BoSungCaiDatBanDau_TaiKhoanKeToan()
        {
            DataTable dttttt2 = (DataTable)gridControl1.DataSource;
            dttttt2.DefaultView.RowFilter = "Chon = True";
            DataView dv = dttttt2.DefaultView;
            DataTable dv3 = dv.ToTable();          
            if (dv3.Rows.Count > 0)
            {
                clsNganHang_SoDuBanDau_TaiKhoanKeToan cls2 = new clsNganHang_SoDuBanDau_TaiKhoanKeToan();             
                for (int i = 0; i < dv3.Rows.Count; i++)
                {
                    string TenTaiKhoanCon = dv3.Rows[i]["TenTaiKhoanCon"].ToString();
                    string filterExpression = "TenTaiKhoanCon='" + TenTaiKhoanCon + "'";
                    DataRow[] rows = UCThietLap_TaiKhoanNganHang.mdatatabletbTaiKhoanKeToan.Select(filterExpression);
                    if (rows.Length == 0)
                    {
                        cls2.iID_TaiKhoanKeToanCon = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                        cls2.iID_TaiKhoanKeToanMe = Convert.ToInt16(dv3.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                        cls2.fCoKhong = 0;
                        cls2.fNoKhong = 0;
                        cls2.bTonTai = true;
                        cls2.bNgungTheoDoi = false;
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
            clsNganHang_TaiKhoanKeToanCon cls = new clsNganHang_TaiKhoanKeToanCon();
            DataTable dt = cls.SelectAll_HienThiGridcontrol();
            dt.DefaultView.RowFilter = " TonTai= True and NgungTheoDoi=false";
            DataView dv = dt.DefaultView;
            DataTable dt3 = dv.ToTable();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_TaiKhoanKeToanCon", typeof(int));
            dt2.Columns.Add("ID_TaiKhoanKeToanMe", typeof(int));
            dt2.Columns.Add("SoTaiKhoanCon", typeof(string));
            dt2.Columns.Add("TenTaiKhoanCon", typeof(string));
            dt2.Columns.Add("SoTaiKhoanMe", typeof(string));
            dt2.Columns.Add("TenTaiKhoanMe", typeof(string));
            dt2.Columns.Add("Chon", typeof(bool));
            for (int i = 0; i < dt3.Rows.Count; i++)
            {

                DataRow _ravi = dt2.NewRow();
                _ravi["ID_TaiKhoanKeToanCon"] = Convert.ToInt16(dt3.Rows[i]["ID_TaiKhoanKeToanCon"].ToString());
                _ravi["ID_TaiKhoanKeToanMe"] = Convert.ToInt16(dt3.Rows[i]["ID_TaiKhoanKeToanMe"].ToString());
                _ravi["SoTaiKhoanCon"] = dt3.Rows[i]["SoTaiKhoanCon"].ToString();
                _ravi["TenTaiKhoanCon"] = dt3.Rows[i]["TenTaiKhoanCon"].ToString();
                _ravi["SoTaiKhoanMe"] = dt3.Rows[i]["SoTaiKhoanMe"].ToString();
                _ravi["TenTaiKhoanMe"] = dt3.Rows[i]["TenTaiKhoanMe"].ToString();
                _ravi["Chon"] = false;               
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;
          
        }

        public CaiDatBanDau_ChonTaiKhoanNganHang()
        {
            InitializeComponent();
        }

        private void checkChon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkChon.Checked == true)
            {
                DataTable dt3 = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    dt3.Rows[i]["Chon"] = true;
                }
                gridControl1.DataSource = dt3;

            }
            if (checkChon.Checked == false)
            {
                DataTable dt3 = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    dt3.Rows[i]["Chon"] = false;
                }
                gridControl1.DataSource = dt3;

            }
        }

        private void CaiDatBanDau_ChonTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDongY_Click(object sender, EventArgs e)
        {
            Luu_BoSungCaiDatBanDau_TaiKhoanKeToan();
         
        }
    }
}
