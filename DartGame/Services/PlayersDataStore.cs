using DartGame.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartGame.Services
{
    public class PlayersDataStore : IPlayersDataStore
    {
        #region Private Fields

        private List<Player> _players;

        #endregion

        #region Public Methods

        public async Task<int> SaveOrUpdatePlayerAsync(Player player)
        {
            int result;
            if (player.PlayerId == 0)
            {
                var players = App.Database.GetPlayersAsync().Result;
                player.PlayerId = players.Count() + 1;
                result = await App.Database.InsertPlayerAsync(player);
            }
            else
            {
                result = await App.Database.UpdatePlayerAsync(player);
            }

            return result;
        }

        public Player GetPlayerAsync(int playerId)
        {
            var player = App.Database.GetPlayerAsync(playerId).Result;

            return player;
        }

        public async Task<IList<Player>> GetPlayersAsync()
        {
            _players = await App.Database.GetPlayersAsync();

            return _players;
        }

        public async Task<int> DeletePlayerAsync(int playerId)
        {
            var playerToDelete = await App.Database.GetPlayerAsync(playerId);
            var result = await App.Database.DeletePlayerAsync(playerToDelete);

            return result;
        }

        #endregion
    }
}

