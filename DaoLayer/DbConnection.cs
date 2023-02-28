using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DaoLayer
{
    public class DbConnection : IDataConnection
    {
        MySqlConnection conn=new MySqlConnection("server=127.0.0.1;database=dotnet;uid=root;pwd=Ravi@265482");
        DataTable dt = new DataTable();
        public int  ExecuteNonQuery(MySqlCommand cmd)
        {
            conn.Open();
            cmd.Connection = conn;
            int rowsaffected ;
            try
            {
            rowsaffected=cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            conn.Close();
            return rowsaffected;
        }

       public DataTable ExecuteReader(MySqlCommand cmd)
        {
            conn.Open();
            cmd.Connection = conn;
            MySqlDataReader sdr;
            sdr=cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();
            return dt;
        }

        public MySqlConnection getcon()
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
