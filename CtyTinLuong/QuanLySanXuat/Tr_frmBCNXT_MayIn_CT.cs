﻿using DevExpress.XtraGrid.Columns;
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
    public partial class Tr_frmBCNXT_MayIn_CT : Form
    {
        private DataTable _data;
        private List<GridColumn> ds_grid = new List<GridColumn>();
        private int _id_bophan, _idvthh;
        private DateTime _NgayBatDau, _NgayKetThuc;
        private bool isload = true;
        public string _MaNhanVien = "";

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;

        public Tr_frmBCNXT_MayIn_CT(DateTime dateStart, DateTime dateEnd, int Idvthh, string MaHang, string TenHang)
        {
            _NgayBatDau = dateStart;
            _NgayKetThuc = dateEnd;
            _idvthh = Idvthh;
            _id_bophan = KiemTraTenBoPhan("Máy in");
            if (_id_bophan == 0) return;

            InitializeComponent();

            txtMaVT.Text = MaHang;
            lbTenVthh.Text = TenHang;

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("NgaySanXuat", typeof(string));
            _data.Columns.Add("DienGiai", typeof(string));
            _data.Columns.Add("Nhap", typeof(string)); 
            _data.Columns.Add("Xuat", typeof(string));
            _data.Columns.Add("TonCuoi", typeof(string));

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl2.RepositoryItems.Add(emptyEditor);
        }

        private void Tr_frmBCNXT_MayIn_CT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(true);
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            double[] DsTongNgay = new double[31];
            for (int i = 0; i < 31; i++) DsTongNgay[i] = 0;
            List<DateTime> DsNgaySX = new List<DateTime>();
            
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _NgayBatDau = new DateTime(dtnow.Year, dtnow.Month, 1);
                _NgayKetThuc = dtnow;
                dateBatDau.DateTime = _NgayBatDau;
                dateKetThuc.DateTime = _NgayKetThuc;
            }


            try
            {
                using (clsThin clsThin_ = new clsThin())
                {
                    DataTable dtMayIn = clsThin_.Tr_Phieu_ChiTietPhieu_New_MayIn_NXT_ChiTiet(_NgayBatDau, _NgayKetThuc, _id_bophan, _idvthh);
                    DataTable dtMayCat = clsThin_.Tr_Phieu_ChiTietPhieu_New_MayCat_NXT_ChiTiet(_NgayBatDau, _NgayKetThuc, _id_bophan, _idvthh);
                    int ID_congNhanRoot = -1;
                    int SttCa1 = 0;

                    foreach (DataRow item in dtMayIn.Rows)
                    {
                        DateTime NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString());
                        if (!DsNgaySX.Contains(NgaySX))
                        {
                            DsNgaySX.Add(NgaySX);
                        }
                    }

                    foreach (DataRow item in dtMayCat.Rows)
                    {
                        DateTime NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString());
                        if (!DsNgaySX.Contains(NgaySX))
                        {
                            DsNgaySX.Add(NgaySX);
                        }
                    }

                    if (DsNgaySX.Count > 0)
                    {

                    }

                    foreach (DateTime item in DsNgaySX)
                    {
                        string MaNV_ = dt.Rows[i]["MaNhanVien"].ToString();

                        ModelShowSanLuongToIn nvSL_tb = getNV_SanLuong(ID_congNhan, "in trúc bách", dt);

                        //
                        if (ID_congNhanRoot != ID_congNhan && !DsID_CongNhan_.Contains(ID_congNhan))
                        {
                            ID_congNhanRoot = ID_congNhan;
                            DsID_CongNhan_.Add(ID_congNhan);
                            SttCa1++;
                            DataRow ravi_ = _data.NewRow();
                            ravi_["ID_CongNhan"] = 0;
                            ravi_["MaNhanVien"] = "";
                            ravi_["TenNhanVien"] = "";
                            ravi_["HinhThuc"] = "Sản lượng tổng";

                            _data.Rows.Add(ravi_);
                        }
                    }
                }

                gridControl2.DataSource = _data;
            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            isload = false;
        }

        private ModelNXT_InCat_ChiTiet getNXT(DateTime NgaySX, DataTable dtMI, DataTable dtMC)
        {
            ModelNXT_InCat_ChiTiet nv = new ModelNXT_InCat_ChiTiet();
            string DonViTinh = "";
            string MaHang = "";
            string TenHang = "";
            string dienGiai = "";
            double TonDau = 0;
            double TonCuoi = 0;
            double Nhap = 0;
            double Xuat = 0;

            for (int i = 0; i < 31; i++)
            {
            }

            foreach (DataRow item in dtMI.Rows)
            {
                if (NgaySX == Convert.ToDateTime(item["NgaySanXuat"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();
                    TenHang = item["TenVTHH"].ToString();
                    dienGiai = item["DienGiai"].ToString();
                    Nhap += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                    TonDau = CheckString.ConvertToDouble_My(item["TonDau"].ToString());
                }
            }

            foreach (DataRow item in dtMC.Rows)
            {
                if (NgaySX == Convert.ToDateTime(item["NgaySanXuat"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();
                    TenHang = item["TenVTHH"].ToString();
                    dienGiai = item["DienGiai"].ToString();
                    Xuat += CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString());
                    TonCuoi = CheckString.ConvertToDouble_My(item["TonCuoi"].ToString());
                }
            }

            //TonCuoi = Nhap + TonDau - Xuat;

            if (dienGiai == "")
                nv.DienGiai = TenHang;
            else
                nv.DienGiai = dienGiai;

            nv.DonViTinh = DonViTinh;
            nv.MaHang = MaHang;
            nv.TenVTHH = TenHang;
            nv.TonDau = TonDau;
            nv.TonCuoi = TonCuoi;
            nv.Nhap = Nhap;
            nv.Xuat = Xuat;
            nv.Let = TonCuoi / 5;

            return nv;
        }



        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.RowHandle == _data.Rows.Count - 1)
            //{
            //    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //}
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _NgayBatDau = dateBatDau.DateTime;
                _NgayKetThuc = dateKetThuc.DateTime;

                LoadData(false);
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                _NgayBatDau = dateBatDau.DateTime;
                _NgayKetThuc = dateKetThuc.DateTime;

                LoadData(false);
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            _NgayBatDau = dateBatDau.DateTime;
            _NgayKetThuc = dateKetThuc.DateTime;

            LoadData(false);
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;
            _NgayBatDau = dateBatDau.DateTime;
            _NgayKetThuc = dateKetThuc.DateTime;

            LoadData(false);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            //CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangSanLuongToIN ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangSanLuongToIN(_NgayBatDau, _NgayKetThuc, _data);
            //ff.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "Tr_frmBCNXT_MayIn_CT", this);
            ff.Show();
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    int id_congnhan_ = Convert.ToInt16(gridView3.GetFocusedRowCellValue(ID_CongNhan).ToString());
            //    _MaNhanVien = gridView3.GetFocusedRowCellValue(MaNhanVien).ToString();

            //    if(_MaNhanVien != "")
            //    {
            //        Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "Tr_frmBCNXT_MayIn_CT", this);
            //        ff.Show();
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        private int KiemTraTenBoPhan(string tenbophan)
        {
            int _id_bophan = 0;
            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt_ = clsThin_.T_NhanSu_tbBoPhan_SO(tenbophan);
                if (dt_ != null && dt_.Rows.Count == 1)
                {
                    _id_bophan = Convert.ToInt32(dt_.Rows[0]["ID_BoPhan"].ToString());
                }
                else
                {
                    MessageBox.Show("Bộ phận " + tenbophan + " chưa được tạo. Hãy tạo bộ phận ở mục quản trị!");

                }
            }
            return _id_bophan;
        }
    }
}
