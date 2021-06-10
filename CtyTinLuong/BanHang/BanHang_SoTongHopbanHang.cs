﻿using System;
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
    public partial class BanHang_SoTongHopbanHang : Form
    {
        public static DateTime mdatungay, mdadenngay;
        public static DataTable mdtPrint;
        public static bool mbPrint;
       
        public void LoadData( DateTime xxtungay, DateTime xxdenngay)
        {
            gridControl1.DataSource = null;
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("MaVT", typeof(string));
            dt2.Columns.Add("TenVTHH", typeof(string));
            dt2.Columns.Add("TenKH", typeof(string));
            dt2.Columns.Add("MaKH", typeof(string));
            dt2.Columns.Add("SoLuong_Tong", typeof(double));
         

            clsBanHang_tbBanHang cls = new clsBanHang_tbBanHang();
            DataTable dtxxxx = cls.SelectAll_distinct_ID_VTHH_HUU(xxtungay, xxdenngay);
            

            int id_vthh_cu_ = 0;
        
            for (int k = 0; k < dtxxxx.Rows.Count; k++)
            {
                double SoLuong_Tong = Convert.ToDouble(dtxxxx.Rows[k]["SoLuong_Tong"].ToString());
               
                int id_vthh_ = 0;
                if (k < dtxxxx.Rows.Count - 1)
                {
                    id_vthh_ = Convert.ToInt32(dtxxxx.Rows[k + 1]["ID_VTHH"].ToString());

                    if (dtxxxx.Rows[k]["ID_VTHH"].ToString() != dtxxxx.Rows[k + 1]["ID_VTHH"].ToString())
                    {
                        DataRow _ravi_1 = dt2.NewRow();
                        //DataRow _ravi_2 = dt2.NewRow();
                        //DataRow _ravi_3 = dt2.NewRow();
                        _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
                        _ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
                        _ravi_1["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();
                        dt2.Rows.Add(_ravi_1);                                           
                                        
                        id_vthh_cu_ = id_vthh_;
                    }
                    else
                    {
                        DataRow _ravi_1 = dt2.NewRow();
                        DataRow _ravi_2 = dt2.NewRow();
                        DataRow _ravi_3 = dt2.NewRow();
                        _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        //_ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
                        //_ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
                        _ravi_1["SoLuong_Tong"] = Convert.ToDouble(dtxxxx.Rows[k]["SoLuong_Tong"].ToString()) + Convert.ToDouble(dtxxxx.Rows[k + 1]["SoLuong_Tong"].ToString());
                        dt2.Rows.Add(_ravi_1);
                        //_ravi_2["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        //_ravi_2["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_2["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
                        _ravi_2["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
                        _ravi_2["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();
                        dt2.Rows.Add(_ravi_2);
                        _ravi_3["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                        _ravi_3["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                        _ravi_3["TenKH"] = dtxxxx.Rows[k + 1]["TenKH"].ToString();
                        _ravi_3["MaKH"] = dtxxxx.Rows[k + 1]["MaKH"].ToString();
                        _ravi_3["SoLuong_Tong"] = dtxxxx.Rows[k + 1]["SoLuong_Tong"].ToString();
                        dt2.Rows.Add(_ravi_3);
                        _ravi_3 = dt2.NewRow();
                        id_vthh_cu_ = id_vthh_;
                   
                    }
                }
                else
                {
                    DataRow _ravi_1 = dt2.NewRow();
                    _ravi_1["MaVT"] = dtxxxx.Rows[k]["MaVT"].ToString();
                    _ravi_1["TenVTHH"] = dtxxxx.Rows[k]["TenVTHH"].ToString();
                    _ravi_1["TenKH"] = dtxxxx.Rows[k]["TenKH"].ToString();
                    _ravi_1["MaKH"] = dtxxxx.Rows[k]["MaKH"].ToString();
                    _ravi_1["SoLuong_Tong"] = dtxxxx.Rows[k]["SoLuong_Tong"].ToString();

                    dt2.Rows.Add(_ravi_1);
                    _ravi_1 = dt2.NewRow();

                }
            }

            gridControl1.DataSource = dt2;

        }

        public BanHang_SoTongHopbanHang()
        {
            InitializeComponent();
        }
        

        private void btRefresh_Click(object sender, EventArgs e)
        {
            BanHang_SoTongHopbanHang_Load( sender,  e);
        }

        private void BanHang_SoTongHopbanHang_Load(object sender, EventArgs e)
        {
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dteDenNgay.EditValue = DateTime.Now;
            LoadData( dteTuNgay.DateTime, dteDenNgay.DateTime);

        }
    }
}
