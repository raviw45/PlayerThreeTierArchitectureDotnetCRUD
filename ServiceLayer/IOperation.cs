using ModelLayer;
using System.Data;

namespace ServiceLayer
{
    internal interface IOperation
    {
        int insertPlayer(Player player);
        int updatePlayer(Player player);    
        int deletePlayer(Player player);
        DataTable getAllPlayers();
    }
}
