using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsHoaDonNhap_DAO
    {
        public bool LuuHoaDonNhap(clsHoaDonNhap_DTO hdn_DTO)
        {
            string strQuery = "Insert Into HoaDonNhap ([MaHDNhap],[MaNCC],[CMNDNV],[NgayNhap],[TongTien],[TrangThai]) " +
                "Values (@MaHDNhap, @MaNCC, @CMNDNV, @NgayNhap, @TongTien, 1)";
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@MaHDNhap", hdn_DTO.MaHDNhap);
            para[1] = new SqlParameter("@MaNCC", hdn_DTO.MaNCC);
            para[2] = new SqlParameter("@CMNDNV", hdn_DTO.CMNDNV);
            para[3] = new SqlParameter("@NgayNhap", hdn_DTO.NgayNhap);
            para[4] = new SqlParameter("@TongTien", hdn_DTO.TongTien);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public string MaLonNhat()
        {
            string strResult = null;
            string strTruyVan = "Select Max(MaHDNhap) From HoaDonNhap";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strTruyVan, conn);
            if (sdr.Read())
            {
                strResult = sdr[0].ToString();
            }
            sdr.Close();
            conn.Close();
            return strResult;
        }
    }
}
