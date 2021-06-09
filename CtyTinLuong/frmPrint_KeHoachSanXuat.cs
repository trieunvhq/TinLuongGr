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
    public partial class frmPrint_KeHoachSanXuat : Form
    {
        private void Print_N_X_T(DataTable dt3)
        {

            Xtra_keHoachSanXuat xtr111 = new Xtra_keHoachSanXuat();
            
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbKeHoachSanXuat.Clone();
            ds.tbKeHoachSanXuat.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbKeHoachSanXuat.NewRow();
              
                _ravi["MaKeHoach"] = dt3.Rows[i]["MaKeHoach"].ToString();
                if (dt3.Rows[i]["NgayDatHang"].ToString() != "")
                    _ravi["NgayDatHang"] = Convert.ToDateTime(dt3.Rows[i]["NgayDatHang"].ToString());
                _ravi["DienGiai"] = dt3.Rows[i]["DienGiai"].ToString();
                _ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();
                if (dt3.Rows[i]["SoLuong"].ToString() != "")
                    _ravi["SoLuong"] = Convert.ToDouble(dt3.Rows[i]["SoLuong"].ToString());
                _ravi["QuyCach"] = dt3.Rows[i]["QuyCach"].ToString();
                if (dt3.Rows[i]["NgayDuKienXuat"].ToString() != "")
                    _ravi["NgayDuKienXuat"] = Convert.ToDateTime(dt3.Rows[i]["NgayDuKienXuat"].ToString());
                if (dt3.Rows[i]["NgayXuatThucTe"].ToString() != "")
                    _ravi["NgayXuatThucTe"] = Convert.ToDateTime(dt3.Rows[i]["NgayXuatThucTe"].ToString());
                if (Convert.ToBoolean(dt3.Rows[i]["DaHoanThanh"].ToString()) == true)
                    _ravi["DaHoanThanh"] = "Xong";
                else _ravi["DaHoanThanh"] = "_";
                _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                _ravi["TenKH"] = dt3.Rows[i]["TenKH"].ToString();            

                ds.tbKeHoachSanXuat.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbKeHoachSanXuat;
            xtr111.DataMember = "tbKeHoachSanXuat";            
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        public frmPrint_KeHoachSanXuat()
        {
            InitializeComponent();
        }

        private void frmPrint_KeHoachSanXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmKeHoachSanXuat.mPrint = false;
        }

        private void frmPrint_KeHoachSanXuat_Load(object sender, EventArgs e)
        {
            if (frmKeHoachSanXuat.mPrint == true)
                Print_N_X_T(frmKeHoachSanXuat.mdtChiTiet_Print);
        }
    }
}
