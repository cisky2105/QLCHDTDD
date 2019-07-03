using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsNhanVien_BUS
    {
        clsNhanVien_DAO nv_DAO = new clsNhanVien_DAO();
        public List<clsNhanVien_DTO> DanhSachNhanVien()
        {
            return nv_DAO.DanhSachNhanVien();
        }

        public bool ThemNhanVien(clsNhanVien_DTO nv_DTO)
        {
            return nv_DAO.ThemNhanVien(nv_DTO);
        }

        public bool CapNhatNhanVien(clsNhanVien_DTO nv_DTO)
        {
            return nv_DAO.CapNhatNhanVien(nv_DTO);
        }

        public bool XoaNhanVien(int manv)
        {
            return nv_DAO.XoaNhanVien(manv);
        }

        public bool DoiMatKhauNV(int manv, string pass)
        {
            return nv_DAO.DoiMatKhauNV(manv,pass);
        }
    }
}
