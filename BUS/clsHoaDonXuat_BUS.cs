using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class clsHoaDonXuat_BUS
    {
        public bool LuuHoaDon(clsHoaDonXuat_DTO hdx_DTO)
        {
            clsHoaDonXuat_DAO _hoadonDAO = new clsHoaDonXuat_DAO();
            return _hoadonDAO.LuuHoaDonXuat(hdx_DTO);
        }

        public List<clsHoaDonXuat_DTO> DanhSachHoaDon()
        {
            clsHoaDonXuat_DAO _hoadonDAO = new clsHoaDonXuat_DAO();
            return _hoadonDAO.DanhSachHoaDon();
        }

        public string LayMaTiepTheo()
        {
            clsHoaDonXuat_DAO hdxDAO = new clsHoaDonXuat_DAO();
            string maMax = hdxDAO.MaLonNhat();
            if (string.IsNullOrEmpty(maMax))
            {
                return "HDX00001";
            }
            int ChuyenSo = int.Parse(maMax.Replace("HDX", ""));
            return "HDX" + (ChuyenSo + 1).ToString("00000");
        }
    }
}
