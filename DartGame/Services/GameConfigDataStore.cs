using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DartGame.Extensions;
using DartGame.Models;

namespace DartGame.Services
{
    public class GameConfigDataStore : IGameConfigDataStore
    {
        readonly GameConfig GameConfig;

        public GameConfigDataStore()
        {            
            GameConfig = App.Database.GetGameConfigAsync(0).Result;
        }

        public async Task<GameConfig> GetLastUsedGameConfigAsync()
        {
            var gameConfig = new GameConfig();

            return await Task.FromResult(gameConfig);
        }

        public async Task<bool> UpdateGameConfigAsync(GameConfig gameConfig)
        {
            return await Task.FromResult(true);
        }
    }
}