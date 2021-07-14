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
    public partial class frmPrint_TraLuong : Form
    {
        public frmPrint_TraLuong()
        {
            InitializeComponent();
        }

        private void frmPrint_TraLuong_Load(object sender, EventArgs e)
        {
            //Xtra_TraLuong xtr111 = new Xtra_TraLuong();
            //DataTable mdtTraLuong = new DataTable();
            //mdtTraLuong.Columns.Add("STT", typeof(string));
            //mdtTraLuong.Columns.Add("TenNhanVien", typeof(string));
            //mdtTraLuong.Columns.Add("LuongCoDinh", typeof(decimal));
            //mdtTraLuong.Columns.Add("LuongCongNhat", typeof(decimal));
            //mdtTraLuong.Columns.Add("LuongSanLuong", typeof(decimal));
            //mdtTraLuong.Columns.Add("LuongLonNhat", typeof(decimal));
            //mdtTraLuong.Columns.Add("PhuCapXangXe", typeof(decimal));
            //mdtTraLuong.Columns.Add("PhuCapDienthoai", typeof(decimal));
            //mdtTraLuong.Columns.Add("PhuCapVeSinhMay", typeof(decimal));
            //mdtTraLuong.Columns.Add("PhuCapTienAn", typeof(decimal));
            //mdtTraLuong.Columns.Add("TrachNhiem", typeof(decimal));
            //mdtTraLuong.Columns.Add("TruTienAn", typeof(decimal));
            //mdtTraLuong.Columns.Add("TamUng", typeof(decimal));
            //mdtTraLuong.Columns.Add("BaoHiem", typeof(decimal));
            //mdtTraLuong.Columns.Add("ThucNhan", typeof(decimal));          
          
            //DataTable dt3 = frmLuong_ChiTietTraLuong.mdttableDuLieuTraLuong;
            //DataSet_TinLuong ds = new DataSet_TinLuong();
            //ds.tbTraLuong.Clone();
            //ds.tbTraLuong.Clear();
            //for (int i = 0; i < dt3.Rows.Count; i++)
            //{
            //    DataRow _ravi = ds.tbTraLuong.NewRow();
            //    _ravi["STT"] = (i + 1).ToString();
            //    _ravi["TenNhanVien"] = dt3.Rows[i]["TenNhanVien"].ToString();
            //    _ravi["LuongCoDinh"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["LuongCoDinh"].ToString());
            //    _ravi["LuongCongNhat"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["LuongCongNhat"].ToString());
            //    _ravi["LuongSanLuong"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["LuongSanLuong"].ToString());
            //    _ravi["LuongLonNhat"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["LuongLonNhat"].ToString());
            //    _ravi["PhuCapXangXe"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["PhuCapXangXe"].ToString());
            //    _ravi["PhuCapDienthoai"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["PhuCapDienthoai"].ToString());
            //    _ravi["PhuCapVeSinhMay"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["PhuCapVeSinhMay"].ToString());
            //    _ravi["PhuCapTienAn"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["PhuCapTienAn"].ToString());
            //    _ravi["TrachNhiem"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["TrachNhiem"].ToString());
            //    _ravi["TruTienAn"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["TruTienAn"].ToString());
            //    _ravi["TamUng"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["TamUng"].ToString());
            //    _ravi["BaoHiem"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["BaoHiem"].ToString());
            //    _ravi["ThucNhan"] = CheckString.ConvertToDecimal_My(dt3.Rows[i]["ThucNhan"].ToString());
            //    ds.tbTraLuong.Rows.Add(_ravi);
            //}
            //xtr111.DataSource = null;
            //xtr111.DataSource = ds.tbTraLuong;
            //xtr111.DataMember = "tbTraLuong";
            //// xtr111.IntData(sgiamdoc);
            //xtr111.CreateDocument();
            //documentViewer1.DocumentSource = xtr111;
        }
    }
}
