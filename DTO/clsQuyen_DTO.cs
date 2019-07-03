using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsQuyen_DTO
    {
        private string _MaQuyen;
        private string _TenQuyen;
        private bool _TrangThai;

        public string MaQuyen
        {
            get
            {
                return _MaQuyen;
            }

            set
            {
                _MaQuyen = value;
            }
        }

        public string TenQuyen
        {
            get
            {
                return _TenQuyen;
            }

            set
            {
                _TenQuyen = value;
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
