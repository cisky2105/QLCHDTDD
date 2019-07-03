using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHoaDonXuat_DTO
    {
        private string _MaHDXuat;
        private string _SDTKH;
        private int _CMNDNV;
        private DateTime _NgayXuat;
        private int _TongTien;
        private bool _TrangThai;

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

        public DateTime NgayXuat
        {
            get
            {
                return _NgayXuat;
            }

            set
            {
                _NgayXuat = value;
            }
        }

        public int TongTien
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
