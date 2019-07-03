using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsNhaSanXuat_DTO
    {
        private string _MaNSX;
        private string _TenNSX;
        private bool _TrangThai;

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

        public string TenNSX
        {
            get
            {
                return _TenNSX;
            }

            set
            {
                _TenNSX = value;
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
