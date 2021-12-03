using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong.Model
{
    class ModelDongKien
    {
        public double[] DsSLNgay = new double[31];
        public string MaVT { get; set; }
        public string DonViTinh { get; set; }
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
        public double ThanhTienTong { get; set; }
        public double SanLuongTong { get; set; }
        public int ID_VTHH { get; set; }
    }
}
