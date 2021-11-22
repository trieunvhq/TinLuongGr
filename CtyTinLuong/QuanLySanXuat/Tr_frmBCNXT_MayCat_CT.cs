using DevExpress.XtraGrid.Columns;
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
    public partial class Tr_frmBCNXT_MayCat_CT : Form
    {
        private DataTable _data;
        private List<GridColumn> ds_grid = new List<GridColumn>();
        private int _id_bophan, _idvthh;
        private DateTime _NgayBatDau, _NgayKetThuc;
        private bool isload = true;
        public string _MaNhanVien = "";

        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyEditor;

        public Tr_frmBCNXT_MayCat_CT(DateTime dateStart, DateTime dateEnd, int Idvthh, string MaHang, string TenHang)
        {
            _NgayBatDau = dateStart;
            _NgayKetThuc = dateEnd;
            _idvthh = Idvthh;
            _id_bophan = KiemTraTenBoPhan("Máy in");
            if (_id_bophan == 0) return;

            InitializeComponent();

            txtMaVT.Text = MaHang;
            lbTenVthh.Text = TenHang;
            dateBatDau.DateTime = dateStart;
            dateKetThuc.DateTime = dateEnd;

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

        private void Tr_frmBCNXT_MayCat_CT_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(false);
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
                    DataTable dtNhap = clsThin_.Tr_Phieu_ChiTietPhieu_New_NhapGiayCat_NXT_ChiTiet(_NgayBatDau, _NgayKetThuc, _idvthh);
                    DataTable dtXuat = clsThin_.Tr_Phieu_ChiTietPhieu_New_XuatGiayCat_NXT_ChiTiet(_NgayBatDau, _NgayKetThuc, _idvthh);
                    int SttCa1 = 0;

                    foreach (DataRow item in dtNhap.Rows)
                    {
                        DateTime NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString());
                        if (!DsNgaySX.Contains(NgaySX))
                        {
                            DsNgaySX.Add(NgaySX);
                        }
                    }

                    foreach (DataRow item in dtXuat.Rows)
                    {
                        DateTime NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString());
                        if (!DsNgaySX.Contains(NgaySX))
                        {
                            DsNgaySX.Add(NgaySX);
                        }
                    }

                    DsNgaySX.Sort();

                    if (DsNgaySX.Count > 0)
                    {
                        //Row tồn đầu:
                        ModelNXT_InCat_ChiTiet tondau = getNXT(DsNgaySX[0], dtNhap, dtXuat);
                        DataRow ravi_ = _data.NewRow();
                        ravi_["STT"] = "";
                        ravi_["NgaySanXuat"] = "";
                        ravi_["DienGiai"] = "Số dư đầu kỳ (" + tondau.MaHang + ")";
                        ravi_["Nhap"] = "";
                        ravi_["Xuat"] = "";
                        ravi_["TonCuoi"] = tondau.TonDau.ToString("N0");
                        _data.Rows.Add(ravi_);

                        double nhaptrongky = 0, xuattrongky = 0, tonTheoNgay = tondau.TonDau;
                        //Row tồn theo ngày sx:
                        foreach (DateTime item in DsNgaySX)
                        {
                            ModelNXT_InCat_ChiTiet ng = getNXT(item, dtNhap, dtXuat);
                            SttCa1++;

                            tonTheoNgay += (ng.Nhap - ng.Xuat);
                            DataRow ravi_1 = _data.NewRow();
                            ravi_1["STT"] = SttCa1;
                            ravi_1["NgaySanXuat"] = item.ToString("dd/MM/yyyy");
                            ravi_1["DienGiai"] = ng.DienGiai;
                            ravi_1["Nhap"] = ng.Nhap.ToString("N0");
                            ravi_1["Xuat"] = ng.Xuat.ToString("N0");
                            ravi_1["TonCuoi"] = tonTheoNgay.ToString("N0");
                            _data.Rows.Add(ravi_1);

                            nhaptrongky += ng.Nhap;
                            xuattrongky += ng.Xuat;
                        }

                        //Row nhập xuất trong kỳ:
                        DataRow ravi_2 = _data.NewRow();
                        ravi_2["STT"] = "";
                        ravi_2["NgaySanXuat"] = "";
                        ravi_2["DienGiai"] = "Nhập xuất trong kỳ";
                        ravi_2["Nhap"] = nhaptrongky.ToString("N0");
                        ravi_2["Xuat"] = xuattrongky.ToString("N0");
                        ravi_2["TonCuoi"] = "";
                        _data.Rows.Add(ravi_2);

                        //Row tồn cuối:
                        DataRow ravi_3 = _data.NewRow();
                        ravi_3["STT"] = "";
                        ravi_3["NgaySanXuat"] = "";
                        ravi_3["DienGiai"] = "Số dư cuối kỳ (" + tondau.MaHang + ")";
                        ravi_3["Nhap"] = "";
                        ravi_3["Xuat"] = "";
                        ravi_3["TonCuoi"] = tonTheoNgay.ToString("N0");
                        _data.Rows.Add(ravi_3);
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

        private ModelNXT_InCat_ChiTiet getNXT(DateTime NgaySX, DataTable dtNhap, DataTable dtXuat)
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
            double NhapRa = 0;
            double XuatRa = 0;

            for (int i = 0; i < 31; i++)
            {
            }

            foreach (DataRow item in dtNhap.Rows)
            {
                if (NgaySX == Convert.ToDateTime(item["NgaySanXuat"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();
                    TenHang = item["TenVTHH"].ToString();
                    dienGiai = item["DienGiai"].ToString();
                    Nhap += CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString());
                    NhapRa += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());

                    TonDau = CheckString.ConvertToDouble_My(item["TonDauKy"].ToString());
                }
            }

            foreach (DataRow item in dtXuat.Rows)
            {
                if (NgaySX == Convert.ToDateTime(item["NgaySanXuat"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();
                    TenHang = item["TenVTHH"].ToString();
                    dienGiai = item["DienGiai"].ToString();
                    XuatRa += CheckString.ConvertToDouble_My(item["SoLuong_Vao"].ToString());

                    if (TonDau == 0)
                        TonDau = CheckString.ConvertToDouble_My(item["TonDauKy"].ToString());
                }
            }

            if (NhapRa > 0)
                Xuat = (XuatRa * Nhap) / NhapRa;

            TonCuoi = Nhap + TonDau - Xuat;

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
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string dieGiai = View.GetRowCellValue(e.RowHandle, View.Columns["DienGiai"]).ToString();
                if (dieGiai.Contains("Số dư đầu kỳ") || dieGiai.Contains("Nhập xuất trong kỳ") || dieGiai.Contains("Số dư cuối kỳ"))
                {
                    e.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
                    //e.Appearance.BackColor = Color.Bisque;
                }
            }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(0, "Tr_frmBCNXT_MayCat_CT", this);
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
            //        Tr_frmQuanLyDML_CongNhat ff = new Tr_frmQuanLyDML_CongNhat(id_congnhan_, "Tr_frmBCNXT_MayCat_CT", this);
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
