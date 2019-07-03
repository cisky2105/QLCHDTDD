using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsKhachHang_BUS
    {
        clsKhachHang_DAO kh_DAO = new clsKhachHang_DAO();
        public List<clsKhachHang_DTO> DanhSachKhachHang()
        {
            return kh_DAO.DanhSachKhachHang();
        }
        public List<clsKhachHang_DTO> DanhSachKhachHangTheoSDT(string sdtkh)
        {
            return kh_DAO.DanhSachKhachHangTheoSDT(sdtkh);
        }
        public bool ThemKhachHang(clsKhachHang_DTO kh_DTO)
        {
            return kh_DAO.ThemKhachHang(kh_DTO);
        }

        public bool CapNhatKhachHang(clsKhachHang_DTO kh_DTO)
        {
            return kh_DAO.CapNhatNhanVien(kh_DTO);
        }

        public bool XoaKhachHang(string sdtkh)
        {
            return kh_DAO.XoaNKhachHang(sdtkh);
        }
    }
}
