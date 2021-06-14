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
    public partial class Tr_frmPrintSanLuong_CT_Luong : Form
    {
        private int _thang, _nam, _iiID_CongNhan;
        private string _hoTenNhanVien;
        private DataTable dt2;

        public Tr_frmPrintSanLuong_CT_Luong(int thang, int nam, int iiID_CongNhan, string hoTenNhanVien)
        {
            _thang = thang;
            _nam = nam;
            _iiID_CongNhan = iiID_CongNhan;
            _hoTenNhanVien = hoTenNhanVien;

            InitializeComponent();
        }

        private void Tr_frmPrintSanLuong_CT_Luong_Load(object sender, EventArgs e)
        {
            Tr_PrintSanLuong_CT_Luong xtr111 = new Tr_PrintSanLuong_CT_Luong(_thang, _nam, _iiID_CongNhan, _hoTenNhanVien);

            DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbChiTiet_LuongSL.Clone();
            //ds.tbChiTiet_LuongSL.Clear();
            //clsThin cls1 = new clsThin();

            //DataTable dt3 = cls1.T_Huu_CongNhat_ChiTiet_ChamCong_ToGapDan_CaTruong_SO(_nam, _thang, 18, 0, "");

            //dt2 = new DataTable();

            clsTbVatTuHangHoa clsvt = new clsTbVatTuHangHoa();
            clsPhieu_ChiTietPhieu_New cls = new clsPhieu_ChiTietPhieu_New();
            DataTable dtxxxx = new DataTable();
            dtxxxx = cls.SelectAll_distinct_ID_VTHH_Ra_W_NgayThang_CongNhan(_iiID_CongNhan, GetFistDayInMonth(_nam, _thang), GetLastDayInMonth(_nam, _thang));
            int days = DateTime.DaysInMonth(_nam, _thang);

            DataRow _ravi_1 = ds.tbChiTiet_LuongSL.NewRow();
            DataRow _ravi_2 = ds.tbChiTiet_LuongSL.NewRow();

            int id_vthh_cu_ = 0;
            double tong1 = 0, tong2 = 0;
            for (int k = 0; k < dtxxxx.Rows.Count; k++)
            {


                double snluong_thuong = Convert.ToDouble(dtxxxx.Rows[k]["SanLuong_Thuong"].ToString());
                double snluong_tangca = Convert.ToDouble(dtxxxx.Rows[k]["SanLuong_TangCa"].ToString());

                int ngay_ = (Convert.ToDateTime(dtxxxx.Rows[k]["NgaySanXuat"].ToString()).Day);
                _ravi_1["TenNhanVien"] = _hoTenNhanVien;
                _ravi_2["TenNhanVien"] = _hoTenNhanVien;

                _ravi_1["Ngay" + (ngay_)] = snluong_thuong;
                _ravi_2["Ngay" + (ngay_)] = snluong_tangca;
                tong1 += snluong_thuong;
                tong2 += snluong_tangca;
                _ravi_1["Tong"] = tong1;
                _ravi_2["Tong"] = tong2;
                //
                int id_vthh_ = 0;
                if (k < dtxxxx.Rows.Count - 1)
                {
                    id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString());

                    if (dtxxxx.Rows[k]["ID_VTHH_Ra"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH_Ra"].ToString())
                    {
                        _ravi_1["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_2["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["NoiDung"] = "Thường";
                        _ravi_2["NoiDung"] = "Tăng ca";

                        ds.tbChiTiet_LuongSL.Rows.Add(_ravi_1);
                        ds.tbChiTiet_LuongSL.Rows.Add(_ravi_2);

                        tong1 = 0;
                        tong2 = 0;

                        _ravi_1 = ds.tbChiTiet_LuongSL.NewRow();
                        _ravi_2 = ds.tbChiTiet_LuongSL.NewRow();

                        id_vthh_cu_ = id_vthh_;
                    }
                    else
                    { }
                }
                else
                {
                    _ravi_1["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                    _ravi_2["TenHang"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                    _ravi_1["NoiDung"] = "Thường";
                    _ravi_2["NoiDung"] = "Tăng ca";

                    ds.tbChiTiet_LuongSL.Rows.Add(_ravi_1);
                    ds.tbChiTiet_LuongSL.Rows.Add(_ravi_2);

                    tong1 = 0;
                    tong2 = 0;

                    _ravi_1 = ds.tbChiTiet_LuongSL.NewRow();
                    _ravi_2 = ds.tbChiTiet_LuongSL.NewRow();
                }
            }

            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbChiTiet_LuongSL;
            xtr111.DataMember = "tbChiTiet_LuongSL";


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
