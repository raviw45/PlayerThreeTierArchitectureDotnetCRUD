using DaoLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System.Data;

namespace ServiceLayer
{
    public class Operations : IOperation
    {
        public Player player=new Player();
         DbConnection db=new DbConnection();
        public  int deletePlayer(Player player)
        {
           MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from player where id='"+player.id+"' ";
            return db.ExecuteNonQuery(cmd) ;
        }

        public DataTable getAllPlayers()
        {
            MySqlCommand cmd=new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from player";
            return db.ExecuteReader(cmd) ;
        }

        public int insertPlayer(Player player)
        {
           MySqlCommand cmd=new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            string format= "yyyy-MM-dd HH:mm:ss";
            cmd.CommandText = "insert into player(name,gender,jDate,runs,wickets,dob,ranks,country) values('"+player.name+"','"+player.gender+"','"+player.jDate.ToString(format)+"','"+player.runs+"','"+player.wickets+"','"+player.dob.ToString(format)+"','"+player.rank+"','"+player.country+"')";
            return db.ExecuteNonQuery(cmd) ;
        }

         public  int updatePlayer(Player player)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.Text;
            string format = "yyyy-MM-dd HH:mm:ss";
            cmd.CommandText = "update player set name='"+player.name+"',gender='"+player.gender+"',jDate='"+player.jDate.ToString(format)+"',runs='"+player.runs+"',wickets='"+player.wickets+"',dob='"+player.dob.ToString(format)+"',ranks='"+player.rank+"',country='"+player.country+"' where id='"+player.id+"'";
            return db.ExecuteNonQuery(cmd) ;
        }
    }
}
