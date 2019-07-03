using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsNhaSanXuat_BUS
    {
        clsNhaSanXuat_DAO nsx_DAO = new clsNhaSanXuat_DAO();
        public List<clsNhaSanXuat_DTO> DanhSachNhaSanXuat()
        {
            return nsx_DAO.DanhSachNhaSanXuat();
        }

        public string LayMaTiepTheo()
        {
            string maMax = nsx_DAO.MaNSXLonNhat();
            if (string.IsNullOrEmpty(maMax))
            {
                return "NSX00001";
            }
            int ChuyenSo = int.Parse(maMax.Replace("NSX", ""));
            return "NSX" + (ChuyenSo + 1).ToString("00000");
        }

        public bool ThemNhaSanXuat(clsNhaSanXuat_DTO nsx_DTO)
        {
            return nsx_DAO.ThemNhaSanXuat(nsx_DTO);
        }

        public bool CapNhatNhaSanXuat(clsNhaSanXuat_DTO nsx_DTO)
        {
            return nsx_DAO.CapNhatNhaSanXuat(nsx_DTO);
        }

        public bool XoaNhaSanXuat(string mansx)
        {
            return nsx_DAO.XoaNhaSanXuat(mansx);
        }
    }
}
