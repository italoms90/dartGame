using DartGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DartGame.Services
{
    public interface IGameTurnDataStore
    {
        Task<int> AddGameTurnAsync(GameTurn gameTurn);
        IList<GameTurn> GetTurnsAsync();
        void ClearTurnsAsync();
    }
}
