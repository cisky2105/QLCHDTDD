using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsNhanVien_DTO
    {
        private int _CMNDNV;
        private string _HoVaTen;
        private DateTime _NgaySinh;
        private bool _GioiTinh;
        private string _SDT;
        private string _DiaChi;
        private string _MatKhau;
        private string _Quyen;
        private bool _TrangThai;

        public int CMNDNV
        {
            get
            {
                return _CMNDNV;
            }

            set
            {
                _CMNDNV = value;
            }
        }

        public string HoVaTen
        {
            get
            {
                return _HoVaTen;
            }

            set
            {
                _HoVaTen = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
            }
        }

        public bool GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                _GioiTinh = value;
            }
        }

        public string SDT
        {
            get
            {
                return _SDT;
            }

            set
            {
                _SDT = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }

            set
            {
                _DiaChi = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return _MatKhau;
            }

            set
            {
                _MatKhau = value;
            }
        }

        public string Quyen
        {
            get
            {
                return _Quyen;
            }

            set
            {
                _Quyen = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return _TrangThai;
            }

            set
            {
                _TrangThai = value;
            }
        }
    }
}
