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
    public partial class Tr_frmPrintBB_Ktra_DM_HHSX : Form
    {
        private DateTime _tuNgay, _denNgay;
        private DataTable dt2;

        public Tr_frmPrintBB_Ktra_DM_HHSX(DateTime tuNgay, DateTime denNgay)
        {
            _tuNgay = tuNgay;
            _denNgay = denNgay;

            InitializeComponent();
        }

        private void Tr_frmPrintBB_Ktra_DM_HHSX_Load(object sender, EventArgs e)
        {
            Tr_PrintBB_Ktra_DM_HHSX xtr111 = new Tr_PrintBB_Ktra_DM_HHSX(_tuNgay, _denNgay);

            DataSet_TinLuong ds = new DataSet_TinLuong();

            clsTr_BB_KtraDinhMuc_HHSX cls = new clsTr_BB_KtraDinhMuc_HHSX();
            DataTable dt = new DataTable();
            dt = cls.SelectAll_BB_Ktra_DMHHSX_date(_tuNgay, _denNgay, "");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbBB_Ktra_DMHHSX.NewRow();

                _ravi["NgayThang"] = Convert.ToDateTime(dt.Rows[i]["NgayThang"].ToString());
                _ravi["SoHieu"] = dt.Rows[i]["SoHieu"].ToString();
                _ravi["Ca"] = Convert.ToInt32(dt.Rows[i]["Ca"].ToString());
                _ravi["LoaiHang"] = dt.Rows[i]["LoaiHang"].ToString().Trim();
                _ravi["LoaiGiay"] = dt.Rows[i]["LoaiGiay"].ToString().Trim();
                _ravi["SoLuongKtra"] = Convert.ToDouble(dt.Rows[i]["SoLuongKtra"].ToString());
                _ravi["DonVi_first"] = dt.Rows[i]["DonVi_first"].ToString();
                _ravi["TrongLuong"] = Convert.ToDouble(dt.Rows[i]["TrongLuong"].ToString());
                _ravi["SoLuong"] = Convert.ToDouble(dt.Rows[i]["SoLuong"].ToString());
                _ravi["DonVi_Second"] = dt.Rows[i]["DonVi_Second"].ToString();
                _ravi["QuyRaKien"] = Convert.ToDouble(dt.Rows[i]["QuyRaKien"].ToString());
                _ravi["PhePham"] = Convert.ToDouble(dt.Rows[i]["PhePham"].ToString());
                _ravi["DoCao"] = Convert.ToDouble(dt.Rows[i]["DoCao"].ToString());
                _ravi["MotBao_kg"] = Convert.ToDouble(dt.Rows[i]["MotBao_kg"].ToString());
                _ravi["MotBao_SoKien"] = Convert.ToDouble(dt.Rows[i]["MotBao_SoKien"].ToString());
                _ravi["SauMuoi_BaoKien"] = Convert.ToDouble(dt.Rows[i]["SauMuoi_BaoKien"].ToString());
                _ravi["GhiChu"] = dt.Rows[i]["GhiChu"].ToString();

                ds.tbBB_Ktra_DMHHSX.Rows.Add(_ravi);
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbBB_Ktra_DMHHSX;
            xtr111.DataMember = "tbBB_Ktra_DMHHSX";


            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
    }
}
