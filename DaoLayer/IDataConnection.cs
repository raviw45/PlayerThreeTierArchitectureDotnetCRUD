using MySql.Data.MySqlClient;
using System.Data;
namespace DaoLayer
{
    public  interface IDataConnection
    {
         MySqlConnection getcon();
        int ExecuteNonQuery(MySqlCommand cmd);
        DataTable ExecuteReader(MySqlCommand cmd);
    }
}
