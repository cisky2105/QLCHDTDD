using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public class clsSanPham_BUS
    {

        clsSanPham_DAO sp_DAO = new clsSanPham_DAO();
        public List<clsSanPham_DTO> DanhSachSanPham()
        {
            return sp_DAO.DanhSachSanPham();
        }
        public string LayMaSPTiepTheo()
        {            
            string maMax = sp_DAO.MaSPLonNhat();
            if (string.IsNullOrEmpty(maMax))
            {
                return "SP0001";
            }
            int ChuyenSo = int.Parse(maMax.Replace("SP", ""));
            return "SP" + (ChuyenSo + 1).ToString("00000");
        }

        public List<clsSanPham_DTO> DanhSachSanPhamTheoTen(string tensp)
        {
            return sp_DAO.DanhSachSanPhamTheoTen(tensp);
        }
        public bool XoaSanPham(string masp)
        {
            return sp_DAO.XoaSanPham(masp);
        }

        public bool ThemSanPham(clsSanPham_DTO sp_DTO)
        {
            return sp_DAO.ThemSanPham(sp_DTO);
        }

        public bool CapNhatSanPham(clsSanPham_DTO sp_DTO)
        {
            return sp_DAO.CapNhatSanPham(sp_DTO);
        }
    }

    
}
