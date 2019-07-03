using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsKhachHang_DAO
    {
        public List<clsKhachHang_DTO> DanhSachKhachHang()
        {
            List<clsKhachHang_DTO> lsResult = new List<clsKhachHang_DTO>();
            string strQuery = "Select * From KhachHang Where TrangThai = 1";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsKhachHang_DTO kh_DTO = new clsKhachHang_DTO();
                kh_DTO.SDTKH = sdr["SDTKH"].ToString();
                kh_DTO.TenKH = sdr["TenKH"].ToString();
                kh_DTO.DiaChi = sdr["DiaChi"].ToString();
                kh_DTO.Email = sdr["Email"].ToString();
                kh_DTO.GioiTinh = bool.Parse(sdr["GioiTinh"].ToString());
                kh_DTO.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(kh_DTO);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public List<clsKhachHang_DTO> DanhSachKhachHangTheoSDT(string sdtkh)
        {
            List<clsKhachHang_DTO> lsResult = new List<clsKhachHang_DTO>();
            string strQuery = "Select * From KhachHang Where TrangThai = 1 and SDTKH = '"+sdtkh+"'";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsKhachHang_DTO kh_DTO = new clsKhachHang_DTO();
                kh_DTO.SDTKH = sdr["SDTKH"].ToString();
                kh_DTO.TenKH = sdr["TenKH"].ToString();
                kh_DTO.DiaChi = sdr["DiaChi"].ToString();
                kh_DTO.Email = sdr["Email"].ToString();
                kh_DTO.GioiTinh = bool.Parse(sdr["GioiTinh"].ToString());
                kh_DTO.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(kh_DTO);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public bool ThemKhachHang(clsKhachHang_DTO kh_DTO)
        {
            string strQuery = "Insert Into KhachHang([SDTKH], [TenKH], [DiaChi], [Email], [GioiTinh], [TrangThai]) " +
                "Values(@SDTKH, @TenKH, @DiaChi, @Email, @GioiTinh, 1)";
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SDTKH", kh_DTO.SDTKH);
            para[1] = new SqlParameter("@TenKH", kh_DTO.TenKH);
            para[2] = new SqlParameter("@DiaChi", kh_DTO.DiaChi);
            para[3] = new SqlParameter("@Email", kh_DTO.Email);
            para[4] = new SqlParameter("@GioiTinh", kh_DTO.GioiTinh);           
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool CapNhatNhanVien(clsKhachHang_DTO kh_DTO)
        {
            string strQuery = "Update KhachHang Set [TenKH] = @TenKH, [DiaChi] = @DiaChi, [Email] = @Email, [GioiTinh] = @GioiTinh Where [SDTKH] = @SDTKH";
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@SDTKH", kh_DTO.SDTKH);
            para[1] = new SqlParameter("@TenKH", kh_DTO.TenKH);
            para[2] = new SqlParameter("@DiaChi", kh_DTO.DiaChi);
            para[3] = new SqlParameter("@Email", kh_DTO.Email);
            para[4] = new SqlParameter("@GioiTinh", kh_DTO.GioiTinh);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool XoaNKhachHang(string sdtkh)
        {
            string strQuery = "Update KhachHang set [TrangThai] = 0 Where SDTKH = @SDTKH";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@SDTKH", sdtkh);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            return kq > 0;
        }        
    }
}
