using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsNhanVien_DAO
    {
        public List<clsNhanVien_DTO> DanhSachNhanVien()
        {
            List<clsNhanVien_DTO> lsResult = new List<clsNhanVien_DTO>();
            string strQuery = "Select * From NhanVien Where TrangThai = 1";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsNhanVien_DTO nv_dto = new clsNhanVien_DTO();
                nv_dto.CMNDNV = int.Parse(sdr["CMNDNV"].ToString());
                nv_dto.HoVaTen = sdr["HoVaTen"].ToString();
                nv_dto.NgaySinh = DateTime.Parse(sdr["NgaySinh"].ToString());
                nv_dto.GioiTinh = bool.Parse(sdr["GioiTInh"].ToString());
                nv_dto.SDT = sdr["SDT"].ToString();
                nv_dto.DiaChi = sdr["DiaChi"].ToString();
                nv_dto.Quyen = sdr["Quyen"].ToString();
                nv_dto.MatKhau = sdr["MatKhau"].ToString();
                nv_dto.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(nv_dto);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public bool ThemNhanVien(clsNhanVien_DTO nv_DTO)
        {
            string strQuery = "Insert Into NhanVien( [CMNDNV],[HoVaTen],[NgaySinh] ,[GioiTinh],[SDT],[DiaChi],[MatKhau],[Quyen],[TrangThai]) " +
                "Values(@CMNDNV, @HoVaTen, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @MatKhau, @Quyen, 1)";            
            SqlParameter[] para = new SqlParameter[8];
            para[0] = new SqlParameter("@CMNDNV", nv_DTO.CMNDNV);
            para[1] = new SqlParameter("@HoVaTen", nv_DTO.HoVaTen);
            para[2] = new SqlParameter("@NgaySinh", nv_DTO.NgaySinh);
            para[3] = new SqlParameter("@GioiTinh", nv_DTO.GioiTinh);
            para[4] = new SqlParameter("@SDT", nv_DTO.SDT);
            para[5] = new SqlParameter("@DiaChi", nv_DTO.DiaChi);
            para[6] = new SqlParameter("@MatKhau", nv_DTO.MatKhau);
            para[7] = new SqlParameter("@Quyen", nv_DTO.Quyen);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool CapNhatNhanVien(clsNhanVien_DTO nv_DTO)
        {
            string strQuery = "Update NhanVien Set [NgaySinh] = @NgaySinh ,[GioiTinh] = @GioiTinh, [SDT] = @SDT, [DiaChi] = @DiaChi, [MatKhau] = @MatKhau, [Quyen] = @Quyen Where [CMNDNV] = @CMNDNV";
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@CMNDNV", nv_DTO.CMNDNV);
            para[1] = new SqlParameter("@NgaySinh", nv_DTO.NgaySinh);
            para[2] = new SqlParameter("@GioiTinh", nv_DTO.GioiTinh);
            para[3] = new SqlParameter("@SDT", nv_DTO.SDT);
            para[4] = new SqlParameter("@DiaChi", nv_DTO.DiaChi);
            para[5] = new SqlParameter("@MatKhau", nv_DTO.MatKhau);
            para[6] = new SqlParameter("@Quyen", nv_DTO.Quyen);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool XoaNhanVien(int manv)
        {
            string strQuery = "Update NhanVien set [TrangThai] = 0 Where CMNDNV = @manv";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@manv", manv);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            return kq > 0;
        }
        public bool DoiMatKhauNV(int manv, string pass)
        {
            string strQuery = "Update NhanVien set [MatKhau] = @matkhau Where CMNDNV = @manv";
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@manv", manv);
            para[1] = new SqlParameter("@matkhau", pass);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            return kq > 0;
        }
    }
}
