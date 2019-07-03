using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsChiTietHDNhap_BUS
    {
        clsChiTietHDNhap_DAO cthd_DAO = new clsChiTietHDNhap_DAO();

        public bool LuuChiTietHoaDon(clsChiTietHDNhap_DTO cthd_DTO)
        {
            return cthd_DAO.LuuChiTietHoaDon(cthd_DTO);
        }
    }
}
