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
    public partial class Tr_frmPrint_LuongDaiLy_TrongThang : Form
    {
        public Tr_frmPrint_LuongDaiLy_TrongThang()
        {
            InitializeComponent();
        }
        private void Print_DaiLy_BangLuong_ALL(DataTable dt3)
        {
            List<string> tenDaiLy = new List<string>();
            TrXtraDaiLy_ChiTietLuong_Everyone xtr111 = new TrXtraDaiLy_ChiTietLuong_Everyone();           
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLuongDaiLy.Clone();
            ds.tbLuongDaiLy.Clear();
            int n = dt3.Rows.Count;

            //
            tenDaiLy.Add(dt3.Rows[0]["TenDaiLy"].ToString());

            //
            for (int i = 0; i < n; i++)
            {
                if (!tenDaiLy.Contains(dt3.Rows[i]["TenDaiLy"].ToString()))
                {
                    tenDaiLy.Add(dt3.Rows[i]["TenDaiLy"].ToString());
                }
            }

            //
            for (int i = 0; i < n; i++)
            {
                if (dt3.Rows[i]["TenDaiLy"].ToString() == tenDaiLy[0])
                {
                    DataRow _ravi = ds.tbLuongDaiLy.NewRow();
                    _ravi["STT"] = (i + 1).ToString();
                    //_ravi["NgayChungTu"] = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                    //_ravi["SoChungTu"] = Convert.ToDateTime(dt3.Rows[i]["SoChungTu"].ToString());
                    _ravi["TongLuong"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongLuong"].ToString());
                    _ravi["TamUng"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                    _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongLuong"].ToString()) - CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                    _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                    _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                    _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                    _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                    _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                    _ravi["SoLuongXuat"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoLuongNhap"].ToString());
                    _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                    _ravi["TongTienHang"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongTienHang"].ToString());
                    ds.tbLuongDaiLy.Rows.Add(_ravi);
                }

            }

            //
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLuongDaiLy;
            xtr111.DataMember = "tbLuongDaiLy";
            xtr111.CreateDocument();

            //
            for (int j = 1; j < tenDaiLy.Count; j++)
            {
                ds.tbLuongDaiLy.Clone();
                ds.tbLuongDaiLy.Clear();
                int stt = 1;
                for (int i = 0; i < n; i++)
                {
                    if (dt3.Rows[i]["TenDaiLy"].ToString() == tenDaiLy[j])
                    {
                        DataRow _ravi = ds.tbLuongDaiLy.NewRow();
                        _ravi["STT"] = stt.ToString(); stt++;
                        //_ravi["NgayChungTu"] = Convert.ToDateTime(dt3.Rows[i]["NgayChungTu"].ToString());
                        //_ravi["SoChungTu"] = Convert.ToDateTime(dt3.Rows[i]["SoChungTu"].ToString());
                        _ravi["TongLuong"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongLuong"].ToString());
                        _ravi["TamUng"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                        _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongLuong"].ToString()) - CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                        _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();
                        _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                        _ravi["MaVT"] = dt3.Rows[i]["MaVT"].ToString();
                        _ravi["TenVTHH"] = dt3.Rows[i]["TenVTHH"].ToString();
                        _ravi["DonViTinh"] = dt3.Rows[i]["DonViTinh"].ToString();
                        _ravi["SoLuongXuat"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoLuongNhap"].ToString());
                        _ravi["DonGia"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["DonGia"].ToString());
                        _ravi["TongTienHang"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongTienHang"].ToString());
                        ds.tbLuongDaiLy.Rows.Add(_ravi);
                    }
                }

                TrXtraDaiLy_ChiTietLuong_Everyone xtr222= new TrXtraDaiLy_ChiTietLuong_Everyone();
                xtr222.DataSource = null;
                xtr222.DataSource = ds.tbLuongDaiLy;
                xtr222.DataMember = "tbLuongDaiLy";
                xtr222.CreateDocument();

                //
                xtr111.Pages.AddRange(xtr222.Pages);
            }

            //xtr111.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = xtr111;
        }


        private void Print_DaiLy_BangLuong_RutGon(DataTable dt3)
        {
            XtraDaiLy_Luong_RutGon xtr111 = new XtraDaiLy_Luong_RutGon();
            DataSet_TinLuong ds = new DataSet_TinLuong();
            ds.tbLuongDaiLy.Clone();
            ds.tbLuongDaiLy.Clear();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow _ravi = ds.tbLuongDaiLy.NewRow();
                _ravi["STT"] = (i+1).ToString();
                _ravi["MaDaiLy"] = dt3.Rows[i]["MaDaiLy"].ToString();                
                _ravi["TenDaiLy"] = dt3.Rows[i]["TenDaiLy"].ToString();
                _ravi["TongLuong"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["TongTien"].ToString());
                _ravi["TamUng"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["SoTien_TamUng"].ToString());
                _ravi["ThucNhan"] = CheckString.ConvertToDouble_My(dt3.Rows[i]["ThucNhan"].ToString());
                ds.tbLuongDaiLy.Rows.Add(_ravi);
            }
            xtr111.DataSource = null;
            xtr111.DataSource = ds.tbLuongDaiLy;
            xtr111.DataMember = "tbLuongDaiLy";          
            xtr111.CreateDocument();
            documentViewer1.DocumentSource = xtr111;
        }
        private void Tr_frmPrint_LuongDaiLy_TrongThang_Load(object sender, EventArgs e)
        {
            if (DaiLy_BangLuong.mbPrint_ALL == true)
                Print_DaiLy_BangLuong_ALL(DaiLy_BangLuong.mdtPrint);
            if (DaiLy_BangLuong.mbPrint_RutGon == true)
                Print_DaiLy_BangLuong_RutGon(DaiLy_BangLuong.mdtPrint);
        }

        private void Tr_frmPrint_LuongDaiLy_TrongThang_FormClosed(object sender, FormClosedEventArgs e)
        {
            DaiLy_BangLuong.mbPrint_ALL = false;
            DaiLy_BangLuong.mbPrint_RutGon = false;
        }
    }
}
