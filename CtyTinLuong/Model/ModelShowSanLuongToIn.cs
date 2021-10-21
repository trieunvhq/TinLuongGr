using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong
{
    class ModelShowSanLuongToIn
    {
        public List<double> DsSLNgay = new List<double>(31);
        public double Ngay1 { get; set; }
        public double Ngay2 { get; set; }
        public double Ngay3 { get; set; }
        public double Ngay4 { get; set; }
        public double Ngay5 { get; set; }
        public double Ngay6 { get; set; }
        public double Ngay7 { get; set; }
        public double Ngay8 { get; set; }
        public double Ngay9 { get; set; }
        public double Ngay10 { get; set; }
        public double Ngay11 { get; set; }
        public double Ngay12 { get; set; }
        public double Ngay13 { get; set; }
        public double Ngay14 { get; set; }
        public double Ngay15 { get; set; }
        public double Ngay18 { get; set; }
        public double Ngay19 { get; set; }
        public double Ngay20 { get; set; }
        public double Ngay21 { get; set; }
        public double Ngay22 { get; set; }
        public double Ngay23 { get; set; }
        public double Ngay24 { get; set; }
        public double Ngay25 { get; set; }
        public double Ngay26 { get; set; }
        public double Ngay27 { get; set; }
        public double Ngay28 { get; set; }
        public double Ngay29 { get; set; }
        public double Ngay30 { get; set; }
        public double Ngay31 { get; set; }

        private string hoTen;
        private string tenVthhThuong;
        private string tenVthhTang;
        private double slTong;
        private double slThuong;
        private double slTang;
        private double donGiaThuong;
        private double donGiaTang;
        private int soNgayCong;
        private double thanhTienThuong;
        private double thanhTienTang;
        private double tienTong;
        private double phuCapBaoHiem;
        private double truBaoHiem;

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public double SlTong
        {
            get
            {
                return slTong;
            }

            set
            {
                slTong = value;
            }
        }

        public double SlThuong
        {
            get
            {
                return slThuong;
            }

            set
            {
                slThuong = value;
            }
        }

        public double SlTang
        {
            get
            {
                return slTang;
            }

            set
            {
                slTang = value;
            }
        }

        public double DonGiaThuong
        {
            get
            {
                return donGiaThuong;
            }

            set
            {
                donGiaThuong = value;
            }
        }

        public double DonGiaTang
        {
            get
            {
                return donGiaTang;
            }

            set
            {
                donGiaTang = value;
            }
        }

        public int SoNgayCong
        {
            get
            {
                return soNgayCong;
            }

            set
            {
                soNgayCong = value;
            }
        }

        public double ThanhTienThuong
        {
            get
            {
                return thanhTienThuong;
            }

            set
            {
                thanhTienThuong = value;
            }
        }

        public double ThanhTienTang
        {
            get
            {
                return thanhTienTang;
            }

            set
            {
                thanhTienTang = value;
            }
        }

        public double PhuCapBaoHiem
        {
            get
            {
                return phuCapBaoHiem;
            }

            set
            {
                phuCapBaoHiem = value;
            }
        }

        public double TruBaoHiem
        {
            get
            {
                return truBaoHiem;
            }

            set
            {
                truBaoHiem = value;
            }
        }

        public string TenVthhThuong
        {
            get
            {
                return tenVthhThuong;
            }

            set
            {
                tenVthhThuong = value;
            }
        }

        public string TenVthhTang
        {
            get
            {
                return tenVthhTang;
            }

            set
            {
                tenVthhTang = value;
            }
        }

        public double TienTong
        {
            get
            {
                return tienTong;
            }

            set
            {
                tienTong = value;
            }
        }
    }
}
