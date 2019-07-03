using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsLoaiDT_BUS
    {
        clsLoaiDT_DAO loaidt_DAO = new clsLoaiDT_DAO();
        public List<clsLoaiDT_DTO> DanhSachLoaiDT()
        {
            return loaidt_DAO.DanhSachLoaiDT();
        }
    }
}
