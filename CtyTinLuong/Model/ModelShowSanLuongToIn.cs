using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong
{
    class ModelShowSanLuongToIn
    {
        public double[] DsSLNgay_Tong = new double[31];
        public double[] DsSLNgay = new double[31];
        public double[] DsSLNgay_Tang = new double[31];
        public double[] DsCong = new double[31];
        public string MaVT { get; set; }


        private string hoTen;
        private string tenVthhThuong;
        private string tenVthhTang;
        private double slTong;
        private double slThuong;
        private double slTang;
        private double donGiaThuong;
        private double donGiaTang;
        private double soNgayCong;
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

        public double SoNgayCong
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
