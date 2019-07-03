using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsNhaCungCap_DAO
    {
        public List<clsNhaCungCap_DTO> DanhSachNhaCungCap()
        {
            List<clsNhaCungCap_DTO> lsResult = new List<clsNhaCungCap_DTO>();
            string strQuery = "Select * From NhaCungCap Where TrangThai = 1";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsNhaCungCap_DTO ncc_DTO = new clsNhaCungCap_DTO();
                ncc_DTO.MaNCC = sdr["MaNCC"].ToString();
                ncc_DTO.TenNCC = sdr["TenNCC"].ToString();
                ncc_DTO.SDT = sdr["SDT"].ToString();
                ncc_DTO.DiaChi = sdr["DiaChi"].ToString();
                ncc_DTO.Email = sdr["Email"].ToString();
                ncc_DTO.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(ncc_DTO);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public string MaNCCLonNhat()
        {
            string strResult = null;
            string strTruyVan = "Select Max(MaNCC) From NhaCungCap";
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

        public bool ThemNhaCungCap(clsNhaCungCap_DTO ncc_DTO)
        {
            string strQuery = "Insert into NhaCungCap ([MaNCC],[TenNCC],[SDT],[DiaChi],[Email],[TrangThai])" + " Values (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email, 1)";
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@MaNCC", ncc_DTO.MaNCC);
            para[1] = new SqlParameter("@TenNCC", ncc_DTO.TenNCC);
            para[2] = new SqlParameter("@SDT", ncc_DTO.SDT);
            para[3] = new SqlParameter("@DiaChi", ncc_DTO.DiaChi);
            para[4] = new SqlParameter("@Email", ncc_DTO.Email);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool CapNhatNCC(clsNhaCungCap_DTO ncc_DTO)
        {
            string strQuery = "Update NhaCungCap Set [TenNCC] = @TenNCC, [SDT] = @SDT, [DiaChi] = @DiaChi, [Email] = @Email Where [MaNCC] = @MaNCC";
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@MaNCC", ncc_DTO.MaNCC);
            para[1] = new SqlParameter("@TenNCC", ncc_DTO.TenNCC);
            para[2] = new SqlParameter("@SDT", ncc_DTO.SDT);
            para[3] = new SqlParameter("@DiaChi", ncc_DTO.DiaChi);
            para[4] = new SqlParameter("@Email", ncc_DTO.Email);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool XoaNhaCungCap(string mancc)
        {
            string strQuery = "Update NhaCungCap Set [TrangThai] = 0 Where [MaNCC] = @MaNCC";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MaNCC", mancc);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }
    }
}
