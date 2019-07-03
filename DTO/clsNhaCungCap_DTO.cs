using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsNhaCungCap_DTO
    {
        private string maNCC;
        private string tenNCC;
        private string sDT;
        private string diaChi;
        private string email;
        private bool trangThai;

        public string MaNCC
        {
            get
            {
                return maNCC;
            }

            set
            {
                maNCC = value;
            }
        }

        public string TenNCC
        {
            get
            {
                return tenNCC;
            }

            set
            {
                tenNCC = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
    }
}
