using DartGame.Extensions;
using DartGame.Models;
using DartGame.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DartGame.ViewModels
{
    public class GameConfigViewModel : BaseViewModel
    {
        #region Constructor

        public GameConfigViewModel()
        {
            GameConfig = App.Database.GetGameConfigAsync(0).Result;
            if (GameConfig == null)
            {
                GameConfig = new GameConfig();
            }            

            InitializeData();
            MessageSubscriptions();
        }

        #endregion

        #region Private Fields

        private int _pointsToWinFontSize;
        private int _legsToWinFontSize;

        #endregion

        #region Public Properties

        public GameConfig GameConfig { get; set; }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }

        private string _playerOneName;
        public string PlayerOneName
        {
            get { return _playerOneName; }
            set
            {
                _playerOneName = value;
                OnPropertyChanged();
            }
        }

        private string _playerTwoName;
        public string PlayerTwoName
        {
            get { return _playerTwoName; }
            set
            {
                _playerTwoName = value;
                OnPropertyChanged();
            }
        }        
        
        public string PointsToWin
        {
            get { return GameConfig.GameStartPoints; }
            set
            {
                GameConfig.GameStartPoints = value;
                OnPropertyChanged();
            }
        }

        public string LegsToWin 
        {
            get { return GameConfig.GameLegs; }
            set
            {
                GameConfig.GameLegs = value;
                OnPropertyChanged();
            }
        }

        public int PointsToWinFontSize
        {
            get { return _pointsToWinFontSize; }
            set
            {
                _pointsToWinFontSize = value;
                OnPropertyChanged();
            }
        }

        public int LegsToWinFontSize
        {
            get { return _legsToWinFontSize; }
            set
            {
                _legsToWinFontSize = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods

        public async Task SaveGameConfig()
        {
            await App.Database.SaveGameConfigAsync(GameConfig);
        }

        #endregion

        #region Private Methods

        private void InitializeData()
        {
            Title = "Game Config";

            var playerOne = App.Database.GetPlayerAsync(GameConfig.PlayerOneId).Result;
            if (playerOne == null)
            {
                PlayerOne = new Player();
            }
            else
            {
                PlayerOne = playerOne;
            }

            var playerTwo = App.Database.GetPlayerAsync(GameConfig.PlayerTwoId).Result;
            if (playerTwo == null)
            { 
                PlayerTwo = new Player(); 
            }
            else
            {
                PlayerTwo = playerTwo;
            }

            PlayerOneName = PlayerOne.PlayerName == null || PlayerOne.PlayerName == ""
                ? "Player 1" 
                : $"{PlayerOne.PlayerName}\n{PlayerOne.PlayerScore}";
            PlayerTwoName = PlayerTwo.PlayerName == null || PlayerTwo.PlayerName == "" 
                ? "Player 2"
                : $"{PlayerTwo.PlayerName}\n{PlayerTwo.PlayerScore}";
            PointsToWinFontSize = GameConfig?.GameStartPoints == ""
                ? 15
                : 45;
            PointsToWin = GameConfig?.GameStartPoints == ""
                ? "Start Points"
                : GameConfig.GameStartPoints;
            LegsToWinFontSize = GameConfig?.GameLegs == ""
                ? 15 
                : 45;   
            LegsToWin = GameConfig?.GameLegs == ""
                ? "Legs"
                : GameConfig.GameLegs;         
        }

        private void MessageSubscriptions()
        {
            MessagingCenter.Subscribe<PlayersConfigPage, Player>(this, "SelectedPlayerOne",
            (sender, player) =>
            {
                PlayerOne = player;
                GameConfig.PlayerOneId = player.PlayerId;
                PlayerOneName = $"{player.PlayerName}\n{ player.PlayerScore}";
            });

            MessagingCenter.Subscribe<PlayersConfigPage, Player>(this, "SelectedPlayerTwo",
            (sender, player) =>
            {
                PlayerTwo = player;
                GameConfig.PlayerTwoId = player.PlayerId;
                PlayerTwoName = $"{player.PlayerName}\n{ player.PlayerScore}";
            });

            MessagingCenter.Subscribe<GamePointsConfigPage, string>(this, "SelectedPoints",
            (sender, points) =>
            {
                PointsToWin = points;
                PointsToWinFontSize = 45;
            });

            MessagingCenter.Subscribe<LegConfigPage, string>(this, "LegsToWin",
            (sender, numberOfLegs) =>
            {
                LegsToWin = numberOfLegs;
                LegsToWinFontSize = 45;
            });
        }

        #endregion
    }
}
