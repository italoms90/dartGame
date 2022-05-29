using DartGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartGame.Services
{
    public class GameTurnDataStore : IGameTurnDataStore
    {
        #region Private Fields

        private static readonly List<GameTurn> _gameTurns = new List<GameTurn>();
        private static int _nextGameTurnId;

        #endregion

        #region Public Methods

        public async Task<int> AddGameTurnAsync(GameTurn gameTurn)
        {
            lock (this)
            {
                gameTurn.TurnId = _nextGameTurnId;
                _gameTurns.Add(gameTurn);

                _nextGameTurnId++;
            }

            return await Task.FromResult(gameTurn.TurnId);
        }

        public IList<GameTurn> GetTurnsAsync()
        {
            // Make a copy of the notes to simulate reading from an external datastore
            var returnTurns = new List<GameTurn>();
            foreach (var turn in _gameTurns)
            {
                returnTurns.Add(CopyTurn(turn));
            }

            return returnTurns;
        }  

        public void ClearTurnsAsync()
        {
            _gameTurns.Clear();
        }

        #endregion

        #region Private Methods

        private static GameTurn CopyTurn(GameTurn gameTurn)
        {
            return new GameTurn
            {
                TurnId = gameTurn.TurnId,
                PlayerName = gameTurn.PlayerName,
                TurnScore = gameTurn.TurnScore
            };
        }

        #endregion
    }
}
