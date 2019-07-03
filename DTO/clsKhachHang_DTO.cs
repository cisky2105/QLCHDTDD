using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsKhachHang_DTO
    {
        private string _SDTKH;
        private string _TenKH;
        private string _DiaChi;
        private string _Email;
        private bool _GioiTinh;
        private bool _TrangThai;

        public string SDTKH
        {
            get
            {
                return _SDTKH;
            }

            set
            {
                _SDTKH = value;
            }
        }

        public string TenKH
        {
            get
            {
                return _TenKH;
            }

            set
            {
                _TenKH = value;
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

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
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
