using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsLoaiDT_DTO
    {
        private string _MaLoaiDT;
        private string _TenLoaiDT;
        private bool _TrangThai;

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

        public string TenLoaiDT
        {
            get
            {
                return _TenLoaiDT;
            }

            set
            {
                _TenLoaiDT = value;
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
