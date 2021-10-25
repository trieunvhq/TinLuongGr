﻿

using CtyTinLuong.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtyTinLuong
{
    public partial class Tr_frmBTTL_ToDot : UserControl
    {
        public string _MaNhanVien = "";
        public int _nam, _thang, _id_bophan;
        private DataTable _data, _dtSL_Ca1, _dtSL_Ca2;
        private bool isload = true;

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        frmQuanLy_Luong_ChamCong _frmQLLCC;

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;
        public Tr_frmBTTL_ToDot(int id_bophan, frmQuanLy_Luong_ChamCong frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();

            emptyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            emptyEditor.Buttons.Clear();
            emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            gridControl1.RepositoryItems.Add(emptyEditor);

            _data = new DataTable();
            _data.Columns.Add("NgayThang", typeof(string));
            _data.Columns.Add("DonViTinh", typeof(string));
            _data.Columns.Add("Dot4_8_Bao", typeof(string));
            _data.Columns.Add("Dot4_8_Kg", typeof(string));
            _data.Columns.Add("Dot36_72_Bao", typeof(string));
            _data.Columns.Add("Dot36_72_Kg", typeof(string));
            _data.Columns.Add("Dot45_90_Bao", typeof(string));
            _data.Columns.Add("Dot45_90_Kg", typeof(string));
            _data.Columns.Add("Dot48_96_Bao", typeof(string));
            _data.Columns.Add("Dot48_96_Kg", typeof(string));
            _data.Columns.Add("Dot56_112_Bao", typeof(string));
            _data.Columns.Add("Dot56_112_Kg", typeof(string));
            _data.Columns.Add("Dot42_84_Bao", typeof(string));
            _data.Columns.Add("Dot42_84_Kg", typeof(string));
            _data.Columns.Add("Dot51_103_Bao", typeof(string));
            _data.Columns.Add("Dot51_103_Kg", typeof(string));
            _data.Columns.Add("Dot53_106tb_Bao", typeof(string));
            _data.Columns.Add("Dot53_106tb_Kg", typeof(string));
            _data.Columns.Add("Dot51_103tb_Bao", typeof(string));
            _data.Columns.Add("Dot51_103tb_Kg", typeof(string));
            _data.Columns.Add("Dot11_17tb_Bao", typeof(string));
            _data.Columns.Add("Dot11_17tb_Kg", typeof(string));
            _data.Columns.Add("Dot45_90tb_Bao", typeof(string));
            _data.Columns.Add("Dot45_90tb_Kg", typeof(string));
            _data.Columns.Add("Dot42_84tb_Bao", typeof(string));
            _data.Columns.Add("Dot42_84tb_Kg", typeof(string));
            _data.Columns.Add("TongBao", typeof(string));
            _data.Columns.Add("TongKg", typeof(string));
            _data.Columns.Add("DonGia_Tan", typeof(string));
            _data.Columns.Add("TongBaotb", typeof(string));
            _data.Columns.Add("TongKgtb", typeof(string));
            _data.Columns.Add("DonGiatb_Tan", typeof(string));
            _data.Columns.Add("ThanhTien", typeof(string));
        }
       
        public void LoadData(bool islandau)
        {
            isload = true;
            if (islandau)
            { 
                DateTime dtnow = DateTime.Now;
                _nam = dtnow.Year;
                _thang = dtnow.Month;
                txtNam.Text = dtnow.Year.ToString();
                txtThang.Text = dtnow.Month.ToString();
            }
            else
            {
            }

            using (clsThin clsThin_ = new clsThin())
            {
                _dtSL_Ca1 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 0, 1, "Ca 1", _id_bophan);
                _dtSL_Ca2 = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCatDotSelect(_nam, _thang, 0, 0, 1, "Ca 2", _id_bophan);

            }  

            isload = false;
        }

        private ModelBTTL_ToDot getSanLuong_Ngay(int Ngay, DataTable dt)
        {
            ModelBTTL_ToDot nv = new ModelBTTL_ToDot();
            int NgayThang;
            string DonViTinh;
            double Dot4_8_Bao;
            double Dot4_8_Kg;
            double Dot36_72_Bao;
            double Dot36_72_Kg;
            double Dot45_90_Bao;
            double Dot45_90_Kg;
            double Dot48_96_Bao;
            double Dot48_96_Kg;
            double Dot56_112_Bao;
            double Dot56_112_Kg;
            double Dot42_84_Bao;
            double Dot42_84_Kg;
            double Dot51_103_Bao;
            double Dot51_103_Kg;
            double Dot53_106tb_Bao;
            double Dot53_106tb_Kg;
            double Dot51_103tb_Bao;
            double Dot51_103tb_Kg;
            double Dot11_17tb_Bao;
            double Dot11_17tb_Kg;
            double Dot45_90tb_Bao;
            double Dot45_90tb_Kg;
            double Dot42_84tb_Bao;
            double Dot42_84tb_Kg;
            double TongBao;
            double TongKg;
            double DonGia_Tan;
            double TongBaotb;
            double TongKgtb;
            double DonGiatb_Tan;
            double ThanhTien;
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
                //nv.DsSLNgay[i] = 0;
                //nv.DsSLNgay_Tang[i] = 0;
                //nv.DsSLNgay_Tong[i] = 0;
                //nv.DsCong[i] = 0;
            }

            //foreach (DataRow item in dt.Rows)
            //{
            //    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;
            //    int idvthh = Convert.ToInt32(item["ID_VTHH_Ra"].ToString());
            //    string tenVTHH = CheckString.ChuanHoaHoTen(item["TenVTHH"].ToString());

            //    if (NgaySX == Ngay)
            //    {
            //        nv.DsIdVthh_DotTang.Add(idvthh);
            //        double SL_Tog_ = 0;
            //        double Cong_ = 0;

            //        hoTen = item["TenNhanVien"].ToString();
            //        tenVthhThuong = item["TenVTHH"].ToString();
            //        maVT = item["MaVT"].ToString();
            //        donGiaThuong = CheckString.ConvertToDouble_My(item["DinhMuc_KhongTang_Value"].ToString());
            //        donGiaTang = CheckString.ConvertToDouble_My(item["DinhMuc_Tang_Value"].ToString());
            //        phuCapBaoHiem = CheckString.ConvertToDouble_My(item["PhuCapBaoHiem_Value"].ToString());
            //        truBaoHiem = CheckString.ConvertToDouble_My(item["BaoHiem_Value"].ToString());
            //        soNgayCong = CheckString.ConvertToDouble_My(item["SoNgayCong"].ToString());

            //        int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

            //        Cong_ = CheckString.ConvertToDouble_My(item["Ngay" + NgaySX].ToString());

            //        SL_Tog_ = CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
            //        slTong += SL_Tog_;
            //        if (Cong_ > 0)
            //        {
            //            tenVthhThuong = "Đột";
            //            tenVthhTang = "Đột tăng ";
            //        }

            //        nv.DsSLNgay_Tong[NgaySX - 1] += SL_Tog_;

            //        for (int i = 0; i < 31; i++)
            //        {
            //            nv.DsCong[i] = CheckString.ConvertToDouble_My(item["Ngay" + (i + 1)].ToString());
            //        }
            //    }
            //}

            //for (int i = 0; i < 31; i++)
            //{
            //    if (nv.DsCong[i] > 0 && nv.DsSLNgay_Tong[i] > 10)
            //    {
            //        nv.DsSLNgay_Tang[i] = nv.DsSLNgay_Tong[i] - 10;
            //        slTang += nv.DsSLNgay_Tong[i] - 10;
            //        nv.DsSLNgay[i] = 10;
            //    }
            //    else
            //    {
            //        nv.DsSLNgay[i] = nv.DsSLNgay_Tong[i];
            //    }
            //}

            //slThuong = slTong - slTang;

            //nv.HoTen = hoTen;
            //nv.MaVT = maVT;
            //nv.TenVthhThuong = tenVthhThuong;
            //nv.TenVthhTang = tenVthhTang;
            //nv.SlTong = slTong;
            //nv.SlThuong = slThuong;
            //nv.SlTang = slTang;
            //nv.DonGiaThuong = donGiaThuong;
            //nv.DonGiaTang = donGiaTang;
            //nv.SoNgayCong = soNgayCong;
            //nv.ThanhTienThuong = slThuong * donGiaThuong;
            //nv.ThanhTienTang = slTang * donGiaTang;
            //nv.TienTong = slThuong * donGiaThuong + slTang * donGiaTang;
            //nv.PhuCapBaoHiem = phuCapBaoHiem;
            //nv.TruBaoHiem = truBaoHiem;

            //return nv;



            return nv;
        }
        private void Tr_frmBTTL_ToDot_Load(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //int index_ = e.RowHandle;
            //string name_ = e.Column.FieldName;
            //if (name_.Contains("Ngay"))
            //{
            //    _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
            //    _data.Rows[index_][name_] = String.Format("{0:0.##}", CheckString.ConvertToDouble_My(_data.Rows[index_][name_].ToString()));
            //    if (_data.Rows.Count > index_)
            //    {
            //        CongTong_Row(index_);
            //    }
            //    //SendKeys.Send("{DOWN}");
            //}
            //else if (name_.Contains("TenVTHH"))
            //{
            //    if (gridView1.GetFocusedRowCellValue(name_) == null)
            //    {
            //        _data.Rows[index_][name_] = "";
            //    }
            //    else
            //    {
            //        _data.Rows[index_][name_] = gridView1.GetFocusedRowCellValue(name_);
            //    }
            //}
            //CongTong();

            //if (!_data.Rows[index_]["TenNhanVien"].ToString().ToLower().Contains("tổng")) SaveOneCN_Datarow(_data.Rows[index_]);
        }

        //CongTong_Row(index_);
        private void CongTong_Row (int index)
        {
            double tong_row = 0;

            for (int j = 0; j < 31; ++j)
            {
                tong_row += CheckString.ConvertToDouble_My(_data.Rows[index]["Ngay" + (j + 1)].ToString());
            }

            _data.Rows[index]["Tong"] = String.Format("{0:0.##}", tong_row);
        }

        private void CongTong()
        {
            double[] _ds_ngay_tong_ = new double[31];
            double tong_tong_ = 0;
            for (int i = 0; i < _data.Rows.Count - 1; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    _ds_ngay_tong_[j] += CheckString.ConvertToDouble_My(_data.Rows[i]["Ngay" + (j + 1)].ToString());
                }
                tong_tong_ += CheckString.ConvertToDouble_My(_data.Rows[i]["Tong"].ToString());
            }
            for (int j = 0; j < 31; ++j)
            {
                _data.Rows[_data.Rows.Count - 1]["Ngay" + (j + 1)] = String.Format("{0:0.##}", _ds_ngay_tong_[j]);
            }
            _data.Rows[_data.Rows.Count - 1]["Tong"] = String.Format("{0:0.##}",tong_tong_);
            gridControl1.DataSource = _data;
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhThang();
            }
        }

        private void txtThang_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhThang();
        }
        private void HoanThanhThang()
        {
            try
            {
                _thang = Convert.ToInt32(txtThang.Text);

                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Tháng không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void HoanThanhNam()
        {
            try
            {
                _nam = Convert.ToInt32(txtNam.Text);

                LoadData(false);
            }
            catch
            {
                MessageBox.Show("Năm không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (isload)
                return;

            HoanThanhNam();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isload)
                return;
            if (e.KeyChar == (char)13)
            {
                HoanThanhNam();
            }
        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
            
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBangChamCong_TBX(_thang, _nam);
            ff.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "Tr_frmBTTL_ToDot", this);
            ff.Show();
        }
        

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Column ==  NgayThang)
            {
                
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ////int id_congnhan_ = Convert.ToInt16(gridView1.GetFocusedRowCellValue(clID_CongNhan).ToString());
                ////_MaNhanVien = gridView1.GetFocusedRowCellValue(MaNhanVien).ToString();
                ////Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "Tr_frmBTTL_ToDot", this);
                ////ff.Show();

            }
            catch (Exception ea)
            {
                MessageBox.Show("Lỗi: ... " + ea.Message.ToString(), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{DOWN}");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error xóa công nhân khỏi bảng..." +ee.ToString(), "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle == _data.Rows.Count - 1)
            {
                if (e.Column.FieldName == "Xoa")
                {
                    e.RepositoryItem = emptyEditor;
                }
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}

