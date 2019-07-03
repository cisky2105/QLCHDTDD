using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsQuyen_DAO
    {
        public List<clsQuyen_DTO> DanhSachQuyenNV()
        {
            List<clsQuyen_DTO> lsResult = new List<clsQuyen_DTO>();
            string strQuery = "Select * From Quyen Where TrangThai = 1";
            SqlConnection conn = DataProvider.TaoKetNoi();
            SqlDataReader sdr = DataProvider.TruyVanDuLieu(strQuery, conn);
            while (sdr.Read())
            {
                clsQuyen_DTO quyuen_DTO = new clsQuyen_DTO();
                quyuen_DTO.MaQuyen = sdr["MaQuyen"].ToString();
                quyuen_DTO.TenQuyen = sdr["TenQuyen"].ToString();
                quyuen_DTO.TrangThai = bool.Parse(sdr["TrangThai"].ToString());
                lsResult.Add(quyuen_DTO);
            }
            sdr.Close();
            conn.Close();
            return lsResult;
        }
    }
}
