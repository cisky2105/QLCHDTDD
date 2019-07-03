using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsQuyen_BUS
    {
        clsQuyen_DAO quyen_DAO = new clsQuyen_DAO();
        public List<clsQuyen_DTO> DanhSachQuyenNV()
        {
            return quyen_DAO.DanhSachQuyenNV();
        }
    }
}
