using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsNhaSanXuat_DAO
    {
        public List<clsNhaSanXuat_DTO> DanhSachNhaSanXuat()
        {
            List<clsNhaSanXuat_DTO> lsResult = new List<clsNhaSanXuat_DTO>();
            string strQuery = "Select * From NhaSanXuat Where TrangThai = 1";            
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsNhaSanXuat_DTO _nsxdto = new clsNhaSanXuat_DTO();
                _nsxdto.MaNSX = sdr["MaNSX"].ToString();
                _nsxdto.TenNSX = sdr["TenNSX"].ToString();
                _nsxdto.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(_nsxdto);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }
        public bool ThemNhaSanXuat(clsNhaSanXuat_DTO nsx_DTO)
        {
            string strQuery = "Insert into NhaSanXuat ([MaNSX],[TenNSX],[TrangThai])" + " Values (@MaNSX, @TenNSX, 1)";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@MaNSX", nsx_DTO.MaNSX);
            para[1] = new SqlParameter("@TenNSX", nsx_DTO.TenNSX);            
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool CapNhatNhaSanXuat(clsNhaSanXuat_DTO nsx_DTO)
        {
            string strQuery = "Update NhaSanXuat Set [TenNSX] = @TenNSX Where [MaNSX] = @MaNSX";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@MaNSX", nsx_DTO.MaNSX);
            para[1] = new SqlParameter("@TenNSX", nsx_DTO.TenNSX);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool XoaNhaSanXuat(string mansx)
        {
            string strQuery = "Update NhaSanXuat Set [TrangThai] = 0 Where [MaNSX] = @MaNSX";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MaNSX", mansx);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public string MaNSXLonNhat()
        {
            string strResult = null;
            string strTruyVan = "Select Max(MaNSX) From NhaSanXuat";
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
