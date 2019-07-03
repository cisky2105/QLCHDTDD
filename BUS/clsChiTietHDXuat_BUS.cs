using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsChiTietHDXuat_BUS
    {
        public bool LuuChiTietHoaDon(clsChiTietHDXuat_DTO cthdx_DTO)
        {
            clsChiTietHDXuat_DAO _cthdDAO = new clsChiTietHDXuat_DAO();
            return _cthdDAO.LuuChiTietHDXuat(cthdx_DTO);
        }
    }
}
