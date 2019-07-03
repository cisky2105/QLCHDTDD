using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsChiTietHDXuat_DTO
    {
        private string _MaHDXuat;
        private string _MaSP;
        private int _SoLuong;
        private int _DonGia;
        private int _GiaKM;

       
       

        public string MaHDXuat
        {
            get
            {
                return _MaHDXuat;
            }

            set
            {
                _MaHDXuat = value;
            }
        }

        public string MaSP
        {
            get
            {
                return _MaSP;
            }

            set
            {
                _MaSP = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }

            set
            {
                _SoLuong = value;
            }
        }

        public int DonGia
        {
            get
            {
                return _DonGia;
            }

            set
            {
                _DonGia = value;
            }
        }

        public int GiaKM
        {
            get
            {
                return _GiaKM;
            }

            set
            {
                _GiaKM = value;
            }
        }
        public int ThanhTien
        {
            get
            {
                return ((SoLuong * DonGia) - (SoLuong * GiaKM));
            }
        }
    }
}
