using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        private static SqlDataAdapter adapter = new SqlDataAdapter();
        //private static SqlConnection conn = new SqlConnection(@"Data Source=CISKY\SQLEXPRESS;Initial Catalog=QL_CuaHangDTDD;Integrated Security=True");
        private static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T6BE0A0\SQLEXPRESS;Initial Catalog=QL_CuaHangDTDD;Integrated Security=True");

        public static SqlConnection TaoKetNoi()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public static SqlDataReader TruyVanDuLieu(string strTruyVan, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strTruyVan, conn);
            return com.ExecuteReader();
        }

        public static SqlDataReader TruyVanDuLieu(string strTruyVan, SqlParameter[] param, SqlConnection conn) //trường hợp có parammeter
        {
            SqlCommand com = new SqlCommand(strTruyVan, conn);
            com.Parameters.AddRange(param);
            return com.ExecuteReader();
        }

        public static int ThucThiCauLenh(string strCauLenh, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCauLenh, conn);
            int ketqua = com.ExecuteNonQuery();
            return ketqua;
        }

        public static int ThucThiCauLenh(string strCauLenh, SqlParameter[] param, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCauLenh, conn);
            com.Parameters.AddRange(param);
            int ketqua = com.ExecuteNonQuery();
            return ketqua;
        }

    }
}
