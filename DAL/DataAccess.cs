using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DataAccess
    {
        public static SqlConnection Openconnect()
        {
            string sChuoiKetNoi = "Data Source=LAPTOP-3RHO7SBV;Initial Catalog=PBL333333;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();
            return con;
        }
        public static void Disconnect(SqlConnection con)
        {
            con.Close();
        }
        public static int JustExcuteNoParameter(string sql)
        {
            SqlConnection con = Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rows = cmd.ExecuteNonQuery();
            Disconnect(con);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return -1;
            }
        }
        public static DataTable GetTable(string sql)
        {
            SqlConnection con = Openconnect();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Disconnect(con);
            return dt;
        }
    }
}
