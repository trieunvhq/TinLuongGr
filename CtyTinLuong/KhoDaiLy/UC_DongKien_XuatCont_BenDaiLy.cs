﻿using System;
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
    public partial class UC_DongKien_XuatCont_BenDaiLy : UserControl
    {
        public UC_DongKien_XuatCont_BenDaiLy()
        {
            InitializeComponent();
        }

        private void Load_DaTa(DateTime xxtungay, DateTime xxdenngay)
        {
            clsDongKien_TbXuatKho cls = new clsDongKien_TbXuatKho();
            DataTable dt = cls.Tr_DongKien_XuatCont_NgayThang_S(xxtungay, xxdenngay);
            gridControl1.DataSource = dt;
        }
       
        private void UC_DongKien_XuatCont_BenDaiLy_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = DateTime.Today;
            clsNgayThang cls = new clsNgayThang();
            dteTuNgay.EditValue = cls.GetFistDayInMonth(DateTime.Today.Year, DateTime.Today.Month);
            Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UC_DongKien_XuatCont_BenDaiLy_Load( sender,  e);
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            //if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() != "")
            //{

            //}
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == clSTT)
                e.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString() != "")
            //{
            //    int iiidnhapkho = Convert.ToInt32(gridView1.GetFocusedRowCellValue(ID_XuatContDongKien).ToString());
            //    clsDongKien_TbXuatKho cls1 = new clsDongKien_TbXuatKho();
            //    cls1.iID_XuatKhoDongKien = iiidnhapkho;
            //    cls1.Delete();

            //    clsDongKien_TbXuatKho_ChiTietXuatKho cls2 = new clsDongKien_TbXuatKho_ChiTietXuatKho();
            //    cls2.H_DongKien_XK_Delete_ID_XK(iiidnhapkho);
            //    MessageBox.Show("Đã xoá");
            //    Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            //}
        }

        private void dteTuNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }

        private void dteDenNgay_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dteTuNgay.DateTime.Year < 1900)
                    dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                if (dteDenNgay.DateTime.Year < 1900)
                    dteDenNgay.DateTime = DateTime.Now;

                Load_DaTa(dteTuNgay.DateTime, dteDenNgay.DateTime);
            }
            catch
            {

            }
        }
    }
}
