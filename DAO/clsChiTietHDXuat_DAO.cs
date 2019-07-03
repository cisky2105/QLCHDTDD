using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsChiTietHDXuat_DAO
    {
        public bool LuuChiTietHDXuat(clsChiTietHDXuat_DTO cthdx_DTO)
        {
            string strInsert = "Insert Into ChiTietHDXuat ([MaHDXuat],[MaSP],[SoLuong],[DonGia],[GiaKM]) Values (@MaHDXuat,@MaSP,@SoLuong,@DonGia,@GiaKM)";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@MaHDXuat", cthdx_DTO.MaHDXuat);
            pars[1] = new SqlParameter("@MaSP", cthdx_DTO.MaSP);
            pars[2] = new SqlParameter("@SoLuong", cthdx_DTO.SoLuong);
            pars[3] = new SqlParameter("@DonGia", cthdx_DTO.DonGia);
            pars[4] = new SqlParameter("@GiaKM", cthdx_DTO.GiaKM);
            int kq = DataProvider.ThucThiCauLenh(strInsert, pars, conn);
            conn.Close();
            return kq > 0;
        }
    }
}
