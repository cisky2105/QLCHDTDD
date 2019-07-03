using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DAO
{
    public class clsSanPham_DAO
    {        

        public List<clsSanPham_DTO> DanhSachSanPham()
        {
            List<clsSanPham_DTO> lsResult = new List<clsSanPham_DTO>();

            string strQuery = "Select * From SanPham Where TrangThai = 1";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsSanPham_DTO _spdto = new clsSanPham_DTO();
                _spdto.MaSP = sdr["MaSP"].ToString();
                _spdto.TenSP = sdr["TenSP"].ToString();
                _spdto.GiaBan = int.Parse(sdr["GiaBan"].ToString());
                _spdto.GiaKM = int.Parse(sdr["GiaKM"].ToString());
                _spdto.MaNSX = sdr["MaNSX"].ToString();
                _spdto.SLTonKho = int.Parse(sdr["SLTonKho"].ToString());
                _spdto.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                _spdto.MaLoaiDT = sdr["MaLoaiDT"].ToString();
                _spdto.HinhAnh = sdr["HinhAnh"].ToString();
                lsResult.Add(_spdto);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }
        public List<clsSanPham_DTO> DanhSachSanPhamTheoTen(string tensp)
        {
            List<clsSanPham_DTO> lsResult = new List<clsSanPham_DTO>();
            string strQuery = "Select * From SanPham Where TrangThai = 1 and TenSP like '%"+tensp+"%'";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsSanPham_DTO _spdto = new clsSanPham_DTO();
                _spdto.MaSP = sdr["MaSP"].ToString();
                _spdto.TenSP = sdr["TenSP"].ToString();
                _spdto.GiaBan = int.Parse(sdr["GiaBan"].ToString());
                _spdto.GiaKM = int.Parse(sdr["GiaKM"].ToString());
                _spdto.MaNSX = sdr["MaNSX"].ToString();
                _spdto.SLTonKho = int.Parse(sdr["SLTonKho"].ToString());
                _spdto.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                _spdto.MaLoaiDT = sdr["MaLoaiDT"].ToString();
                _spdto.HinhAnh = sdr["HinhAnh"].ToString();
                lsResult.Add(_spdto);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }
        public string MaSPLonNhat()
        {
            string strResult = null;
            string strTruyVan = "Select Max(MaSP) From SanPham";
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

        public bool CapNhatSanPham(clsSanPham_DTO sp_DTO)
        {
            string strQuery = "Update SanPham Set [TenSP] = @TenSP, [GiaBan] = @GiaBan, [GiaKM] = @GiaKM, [MaNSX] = @MaNSX, [MaLoaiDT] = @MaLoaiDT, [HinhAnh] = @HinhAnh  Where MaSP = @MaSP";
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@MaSp", sp_DTO.MaSP);
            para[1] = new SqlParameter("@TenSP", sp_DTO.TenSP);
            para[2] = new SqlParameter("@GiaBan", sp_DTO.GiaBan);
            para[3] = new SqlParameter("@GiaKM", sp_DTO.GiaKM);
            para[4] = new SqlParameter("@MaNSX", sp_DTO.MaNSX);
            para[5] = new SqlParameter("@MaLoaiDT", sp_DTO.MaLoaiDT);
            para[6] = new SqlParameter("@HinhAnh", sp_DTO.HinhAnh);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool ThemSanPham(clsSanPham_DTO sp_DTO)
        {
            string strQuery = "Insert Into SanPham([MaSP], [TenSP], [GiaBan], [GiaKM], [MaNSX], [MaLoaiDT], [TrangThai], [SLTonKho], [HinhAnh])"
                + " Values(@MaSP, @TenSP, @GiaBan, @GiaKM, @MaNSX, @MaLoaiDT, 1, 0, @HinhAnh)";
            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@MaSp", sp_DTO.MaSP);
            para[1] = new SqlParameter("@TenSP", sp_DTO.TenSP);
            para[2] = new SqlParameter("@GiaBan", sp_DTO.GiaBan);
            para[3] = new SqlParameter("@GiaKM", sp_DTO.GiaKM);
            para[4] = new SqlParameter("@MaNSX", sp_DTO.MaNSX);
            para[5] = new SqlParameter("@MaLoaiDT", sp_DTO.MaLoaiDT);
            para[6] = new SqlParameter("@HinhAnh", sp_DTO.HinhAnh);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            conn.Close();
            return kq > 0;
        }

        public bool XoaSanPham(string masp)
        {
            string strQuery = "Update SanPham set [TrangThai] = 0 Where MaSP = @MaSP";
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@MaSP", masp);
            SqlConnection conn = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(strQuery, para, conn);
            return kq > 0;
        }
    }
}
