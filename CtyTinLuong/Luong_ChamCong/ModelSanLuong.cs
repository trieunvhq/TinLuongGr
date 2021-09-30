using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtyTinLuong
{
    class ModelSanLuong
    {
        private string hoTen;
        private double slThuong;
        private double slTong;

        private double slTang;
        private double donGia;
        private double thanhTien;

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

        public double DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public double ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
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
    }
}
