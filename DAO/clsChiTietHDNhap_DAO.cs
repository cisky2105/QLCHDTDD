using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsChiTietHDNhap_DAO
    {
        public bool LuuChiTietHoaDon(clsChiTietHDNhap_DTO cthd_DTO)
        {
            string strQuery = "Insert Into ChiTietHDNhap ([MaHDNhap],[MaSP],[SoLuong],[DonGia]) Values ( @MaHDNhap, @MaSP, @SoLuong, @DonGia )";
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@MaHDNhap", cthd_DTO.MaHDNhap);
            para[1] = new SqlParameter("@MaSP", cthd_DTO.MaSP);
            para[2] = new SqlParameter("@SoLuong", cthd_DTO.SoLuong);
            para[3] = new SqlParameter("@DonGia", cthd_DTO.DonGia);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }
    }
}
