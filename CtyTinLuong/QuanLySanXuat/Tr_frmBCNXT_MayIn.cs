
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
    public partial class Tr_frmBCNXT_MayIn : UserControl
    { 
        public int miiID_chiTietChamCong, miiD_DinhMuc_Luong, miID_congNhan;
        public int miiID_ChamCong;
        public string msTenNhanVien;

        public int _id_bophan;
        private DateTime _NgayBatDau, _NgayKetThuc;
        public string _ten_vthh;
        private DataTable _data;
        private bool isload = true; 

        private ObservableCollection<VTHH_DinhMuc_Model> _VTHH_DinhMuc_Models = new ObservableCollection<VTHH_DinhMuc_Model>();

        SanXuat_frmQuanLySanXuat _frmQLLCC;

        public Tr_frmBCNXT_MayIn(int id_bophan, SanXuat_frmQuanLySanXuat frmQLLCC)
        {
            _frmQLLCC = frmQLLCC;
            _id_bophan = id_bophan;
            InitializeComponent();

            _data = new DataTable();
            _data.Columns.Add("STT", typeof(string));
            _data.Columns.Add("MaVT", typeof(string));
            _data.Columns.Add("TenVTHH", typeof(string));
            _data.Columns.Add("DonViTinh", typeof(string));
            _data.Columns.Add("TonDau", typeof(string));
            _data.Columns.Add("TonCuoi", typeof(string));
            _data.Columns.Add("Nhap", typeof(string));
            _data.Columns.Add("Xuat", typeof(string));
            _data.Columns.Add("Let", typeof(string)); 
            _data.Columns.Add("ID_VTHH", typeof(string)); 
        }

        public void LoadData(bool islandau)
        {
            _data.Clear();
            isload = true;
            if (islandau)
            {
                DateTime dtnow = DateTime.Now;
                _NgayBatDau = new DateTime(dtnow.Year, dtnow.Month, 1);
                _NgayKetThuc = dtnow;
                dateBatDau.DateTime = _NgayBatDau;
                dateKetThuc.DateTime = _NgayKetThuc;
            }

            
            List<int> dsIDVTHH = new List<int>();

            using (clsThin clsThin_ = new clsThin())
            {
                DataTable dt = clsThin_.Tr_Phieu_ChiTietPhieu_New_ToInCat_NXT(_NgayBatDau, _NgayKetThuc, _id_bophan);

                int ID_Vthh_Root = -1;
                int stt = 0;

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    int ID_Vthh = Convert.ToInt32(dt.Rows[i]["ID_VTHH_Ra"].ToString());

                    //
                    if (ID_Vthh_Root != ID_Vthh && !dsIDVTHH.Contains(ID_Vthh))
                    {
                        ModelNXT_MayInCat nxt = getNXT(ID_Vthh, dt);
                        //
                        ID_Vthh_Root = ID_Vthh;
                        dsIDVTHH.Add(ID_Vthh);
                        stt++;

                        DataRow _ravi = _data.NewRow();
                        _ravi["STT"] = stt;
                        _ravi["MaVT"] = nxt.MaHang;
                        _ravi["TenVTHH"] = nxt.TenVTHH;
                        _ravi["DonViTinh"] = nxt.DonViTinh;
                        _ravi["TonDau"] = nxt.TonDau.ToString("N0");
                        _ravi["TonCuoi"] = nxt.TonCuoi.ToString("N0");
                        _ravi["Nhap"] = nxt.Nhap.ToString("N0");
                        _ravi["Xuat"] = nxt.Xuat.ToString("N0");
                        _ravi["Let"] = nxt.Let.ToString("N0"); 
                        _ravi["ID_VTHH"] = ID_Vthh; 

                        _data.Rows.Add(_ravi);
                    }
                }
            }

            gridControl1.DataSource = _data;
            //  
            isload = false;
        }

        private ModelNXT_MayInCat getNXT(int idVthh, DataTable dt)
        {
            ModelNXT_MayInCat nv = new ModelNXT_MayInCat();
            string DonViTinh = "";
            string MaHang = "";
            string TenHang = "";
            double TonDau = 0;
            double TonCuoi = 0;
            double Nhap = 0;
            double Xuat = 0;
            List<int> dsNgayCong = new List<int>();

            for (int i = 0; i < 31; i++)
            {
            }

            foreach (DataRow item in dt.Rows)
            {
                if (idVthh == Convert.ToInt32(item["ID_VTHH_Ra"].ToString()))
                {
                    DonViTinh = item["DonViTinh"].ToString();
                    MaHang = item["MaVT"].ToString();
                    TenHang = item["TenVTHH"].ToString();

                    Nhap += CheckString.ConvertToDouble_My(item["SanLuong_Tong_Value"].ToString());
                    Xuat = CheckString.ConvertToDouble_My(item["Xuat"].ToString());
                    TonDau = CheckString.ConvertToDouble_My(item["TonDau"].ToString());

                    int NgaySX = Convert.ToDateTime(item["NgaySanXuat"].ToString()).Day;

                    if (!dsNgayCong.Contains(NgaySX))
                    {
                        dsNgayCong.Add(NgaySX);
                    }
                }
            }

            TonCuoi = Nhap + TonDau - Xuat;

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

        private void Tr_frmBCNXT_MayIn_Load(object sender, EventArgs e)
        {
        }

       

        private void linkQuanLyMaHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_CT(_NgayKetThuc.Month, _NgayKetThuc.Year, _data);
            ff.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.RowHandle == _data.Rows.Count - 1)
            //{
            //    e.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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

        private void btnPrintTQ_Click(object sender, EventArgs e)
        {
            CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_TQ ff = new CtyTinLuong.Luong_ChamCong.Tr_frmPrintBTTL_TBX_TQ(_NgayKetThuc.Month, _NgayKetThuc.Year, _data);
            ff.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue(ID_VTHH) != null)
                {
                    int idvthh = Convert.ToInt16(gridView1.GetFocusedRowCellValue(ID_VTHH).ToString());
                    string maHang = gridView1.GetFocusedRowCellValue(MaVT).ToString();
                    string tenHang = gridView1.GetFocusedRowCellValue(TenVTHH).ToString();

                    Tr_frmBCNXT_MayIn_CT ff = new Tr_frmBCNXT_MayIn_CT(dateBatDau.DateTime, dateKetThuc.DateTime, idvthh, maHang, tenHang);
                    ff.Show();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lbChinhSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btGuiDuLieu_Click(object sender, EventArgs e)
        {
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            _frmQLLCC.Close();
        }
    }
}


