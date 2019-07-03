using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsNhaCungCap_BUS
    {
        clsNhaCungCap_DAO ncc_DAO = new clsNhaCungCap_DAO();

        public List<clsNhaCungCap_DTO> DanhSachNhaCungCap()
        {
            return ncc_DAO.DanhSachNhaCungCap();
        }

        public string LayMaNCCTiepTheo()
        {
            string maMax = ncc_DAO.MaNCCLonNhat();
            if (string.IsNullOrEmpty(maMax))
            {
                return "NCC00001";
            }
            int ChuyenSo = int.Parse(maMax.Replace("NCC", ""));
            return "NCC" + (ChuyenSo + 1).ToString("00000");
        }

        public bool ThemNhaCungCap(clsNhaCungCap_DTO ncc_DTO)
        {
            return ncc_DAO.ThemNhaCungCap(ncc_DTO);
        }

        public bool CapNhatNhaCungCap(clsNhaCungCap_DTO ncc_DTO)
        {
            return ncc_DAO.CapNhatNCC(ncc_DTO);
        }

        public bool XoaNhaCungCap(string mancc)
        {
            return ncc_DAO.XoaNhaCungCap(mancc);
        }
    }
}
