using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DartGame.Models;
using Xamarin.Forms;

namespace DartGame.ViewModels
{
    public class PlayerTurnViewModel : BaseViewModel
    {
        #region Private Fields

        private string _playerName;

        #endregion

        #region Constructor

        public PlayerTurnViewModel(string playerName)
        {
            Title = "PLAYER TURNS";

            _playerName = playerName;

            GameTurns = new ObservableCollection<GameTurn>();
            LoadPlayerTurnsCommand = new Command(async () => await ExecuteLoadTurnsCommand());
        }

        #endregion

        #region Public Properties

        public ObservableCollection<GameTurn> GameTurns { get; set; }
        public Command LoadPlayerTurnsCommand { get; set; }

        #endregion

        #region Public Methods

        public async Task ExecuteLoadTurnsCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                GameTurns.Clear();

                var gameTurns = GameTurnDataStore.GetTurnsAsync().Where(s => s.PlayerName == _playerName);
                var counter = 1;
                foreach (var turn in gameTurns)
                {                    
                    turn.TurnLineNo = counter; 

                    GameTurns.Add(turn);

                    counter++;
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
