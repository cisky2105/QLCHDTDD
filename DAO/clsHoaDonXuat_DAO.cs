using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsHoaDonXuat_DAO
    {
        public bool LuuHoaDonXuat(clsHoaDonXuat_DTO hdx_DTO)
        {
            string strInsert = "Insert Into HoaDonXuat ([MaHDXuat],[SDTKH],[CMNDNV],[NgayXuat],[TongTien],[TrangThai]) Values (@MaHDXuat,@SDTKH,@CMNDNV,@NgayXuat,@TongTien,1); Select cast(Scope_identity() as int);";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@MaHDXuat", hdx_DTO.MaHDXuat);
            pars[1] = new SqlParameter("@SDTKH", hdx_DTO.SDTKH);
            pars[2] = new SqlParameter("@CMNDNV", hdx_DTO.CMNDNV);
            pars[3] = new SqlParameter("@NgayXuat", hdx_DTO.NgayXuat);
            pars[4] = new SqlParameter("@TongTien", hdx_DTO.TongTien);
            int kq = DataProvider.ThucThiCauLenh(strInsert, pars, conn);
            return kq > 0;
        }

        public List<clsHoaDonXuat_DTO> DanhSachHoaDon()
        {
            string strSelect = "Select * From HoaDonXuat Where TrangThai = 1";
            List<clsHoaDonXuat_DTO> lsResult = new List<clsHoaDonXuat_DTO>();
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strSelect, conn);
            while (sdr.Read())
            {
                clsHoaDonXuat_DTO _hdx = new clsHoaDonXuat_DTO();
                _hdx.MaHDXuat = sdr["MaHDXuat"].ToString();
                _hdx.SDTKH = sdr["SDTKH"].ToString();
                _hdx.CMNDNV = int.Parse(sdr["CMNDNV"].ToString());
                _hdx.NgayXuat = DateTime.Parse(sdr["NgayXuat"].ToString());
                _hdx.TongTien = int.Parse(sdr["TongTien"].ToString());
                lsResult.Add(_hdx);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }

        public string MaLonNhat()
        {
            string strResult = null;
            string strTruyVan = "Select Max(MaHDXuat) From HoaDonXuat";
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
