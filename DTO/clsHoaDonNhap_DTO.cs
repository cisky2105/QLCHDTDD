using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHoaDonNhap_DTO
    {
        private string _MaHDNhap;
        private string _MaNCC;
        private int _CMNDNV;
        private DateTime _NgayNhap;
        private long _TongTien;
        private bool _TrangThai;

        public string MaHDNhap
        {
            get
            {
                return _MaHDNhap;
            }

            set
            {
                _MaHDNhap = value;
            }
        }

        public string MaNCC
        {
            get
            {
                return _MaNCC;
            }

            set
            {
                _MaNCC = value;
            }
        }

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

        public DateTime NgayNhap
        {
            get
            {
                return _NgayNhap;
            }

            set
            {
                _NgayNhap = value;
            }
        }

        public long TongTien
        {
            get
            {
                return _TongTien;
            }

            set
            {
                _TongTien = value;
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
