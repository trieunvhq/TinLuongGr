using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class UCSanXuat_CaiDatMacDinh : UserControl
    {
        private void HienThi()
        {
            clsHUU_CaiMacDinh_DinhMuc_SanXuat cls = new clsHUU_CaiMacDinh_DinhMuc_SanXuat();
            DataTable dt3 = cls.SelectAll();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID_MacDinhSanXuat"); // ID của tbChi tiet don hàng
            dt2.Columns.Add("ID_DinhMucLuong_TheoSanLuong");           
            dt2.Columns.Add("MaDinhMuc");
            dt2.Columns.Add("NoiDung");// tb //  
            dt2.Columns.Add("DienGiai");// tb VTHH
            dt2.Columns.Add("DinhMuc_KhongTang", typeof(decimal));
            dt2.Columns.Add("DinhMuc_Tang", typeof(decimal));

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                int ID_DinhMucLuong_TheoSanLuong = Convert.ToInt32(dt3.Rows[i]["ID_DinhMucLuong_TheoSanLuong"].ToString());
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsxx = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsxx.iID_DinhMuc_Luong_SanLuong = ID_DinhMucLuong_TheoSanLuong;
                DataTable dtvt = clsxx.SelectOne();              
                DataRow _ravi = dt2.NewRow();
                _ravi["ID_MacDinhSanXuat"] = Convert.ToInt32(dt3.Rows[i]["ID_MacDinhSanXuat"].ToString());
                _ravi["ID_DinhMucLuong_TheoSanLuong"] = Convert.ToInt32(dt3.Rows[i]["ID_MacDinhSanXuat"].ToString());               
                _ravi["MaDinhMuc"] = clsxx.iID_DinhMuc_Luong_SanLuong.Value;
                _ravi["DienGiai"] = clsxx.sDienGiai.Value;
                _ravi["DinhMuc_KhongTang"] = clsxx.dcDinhMuc_KhongTang.Value;
                _ravi["DinhMuc_Tang"] = clsxx.dcDinhMuc_Tang.Value;
                _ravi["NoiDung"] = dt3.Rows[i]["NoiDung"].ToString();
                dt2.Rows.Add(_ravi);
            }
            gridControl1.DataSource = dt2;
        }
        public UCSanXuat_CaiDatMacDinh()
        {
            InitializeComponent();
        }

        private void UCSanXuat_CaiDatMacDinh_Load(object sender, EventArgs e)
        {
            clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsvthhh = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
            DataTable dtvthh = clsvthhh.SelectAll();
            dtvthh.DefaultView.RowFilter = "TonTai=True and NgungTheoDoi=False";
            DataView dvvthh = dtvthh.DefaultView;
            DataTable newdtvthh = dvvthh.ToTable();
            repositoryItemGridLookUpEdit1.DataSource = newdtvthh;
            repositoryItemGridLookUpEdit1.ValueMember = "ID_DinhMuc_Luong_SanLuong";
            repositoryItemGridLookUpEdit1.DisplayMember = "MaDinhMuc";
            HienThi();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UCSanXuat_CaiDatMacDinh_Load(sender, e);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == clMaDinhMuc)
            {
                clsDinhMuc_DinhMuc_Luong_TheoSanLuong clsxx = new clsDinhMuc_DinhMuc_Luong_TheoSanLuong();
                clsxx.iID_DinhMuc_Luong_SanLuong = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, e.Column));
                DataTable dtvt = clsxx.SelectOne();
                gridView1.SetRowCellValue(e.RowHandle, clDienGiai, clsxx.sDienGiai.Value);
                gridView1.SetRowCellValue(e.RowHandle, clDinhMuc_KhongTang, clsxx.dcDinhMuc_KhongTang.Value);
                gridView1.SetRowCellValue(e.RowHandle, clDinhMuc_Tang, clsxx.dcDinhMuc_Tang.Value);
              
            }
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
            clsHUU_CaiMacDinh_DinhMuc_SanXuat cls = new clsHUU_CaiMacDinh_DinhMuc_SanXuat();
            cls.iID_MacDinhSanXuat = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clID_MacDinhSanXuat).ToString());
            cls.iID_DinhMucLuong_TheoSanLuong = Convert.ToInt32(gridView1.GetFocusedRowCellValue(clMaDinhMuc).ToString());
            cls.sNoiDung = gridView1.GetFocusedRowCellValue(clNoiDung).ToString();
            cls.Update();

        }
    }
}
