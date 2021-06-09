using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong.Model
{
    public class VTHH_DinhMuc_Model
    { 
        public int ID_VTHH { get; set; }
        public string TenVTHH { get; set; }
        public string MaVT { get; set; }
        public int ID_DinhMuc_Luong_SanLuong { get; set; }
        public string MaDinhMuc { get; set; }
        public string DienGiai { get; set; }
        public float DinhMuc_KhongTang { get; set; }
        public float DinhMuc_Tang { get; set; }
        public float MaxSanLuongThuong { get; set; } 

        //   ,[]
        //,[]
        //,[ID_VTHH]
        //,[]
        //,[]
        //,[TonTai]
        //,[NgungTheoDoi]
        //,[]
    }
}
