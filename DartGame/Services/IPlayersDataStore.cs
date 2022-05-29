using DartGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DartGame.Services
{
    public interface IPlayersDataStore
    {
        Task<int> SaveOrUpdatePlayerAsync(Player player);
        Player GetPlayerAsync(int playerId);
        Task<IList<Player>> GetPlayersAsync();
        Task<int> DeletePlayerAsync(int playerId);
    }
}
