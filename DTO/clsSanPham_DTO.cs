using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsSanPham_DTO
    {
        private string _MaSP;
        private string _MaNSX;
        private string _MaLoaiDT;
        private string _TenSP;
        private int _GiaBan;
        private int? _GiaKM;
        private int? _SLTonKho;
        private string _HinhAnh;
        private bool _TrangThai;

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

        public string MaNSX
        {
            get
            {
                return _MaNSX;
            }

            set
            {
                _MaNSX = value;
            }
        }

        public string MaLoaiDT
        {
            get
            {
                return _MaLoaiDT;
            }

            set
            {
                _MaLoaiDT = value;
            }
        }

        public string TenSP
        {
            get
            {
                return _TenSP;
            }

            set
            {
                _TenSP = value;
            }
        }

        public int GiaBan
        {
            get
            {
                return _GiaBan;
            }

            set
            {
                _GiaBan = value;
            }
        }

        public int? GiaKM
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

        public int? SLTonKho
        {
            get
            {
                return _SLTonKho;
            }

            set
            {
                _SLTonKho = value;
            }
        }

        public string HinhAnh
        {
            get
            {
                return _HinhAnh;
            }

            set
            {
                _HinhAnh = value;
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
