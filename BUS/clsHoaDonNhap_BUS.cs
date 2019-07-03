using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsHoaDonNhap_BUS
    {
        clsHoaDonNhap_DAO hdn_DAO = new clsHoaDonNhap_DAO();

        public bool LuuHoaDonNhap(clsHoaDonNhap_DTO hdn_DTO)
        {
            return hdn_DAO.LuuHoaDonNhap(hdn_DTO);
        }

        public string LayMaTiepTheo()
        {
            string maMax = hdn_DAO.MaLonNhat();
            if (string.IsNullOrEmpty(maMax))
            {
                return "HDN00001";
            }
            int ChuyenSo = int.Parse(maMax.Replace("HDN", ""));
            return "HDN" + (ChuyenSo + 1).ToString("00000");
        }
    }
}
