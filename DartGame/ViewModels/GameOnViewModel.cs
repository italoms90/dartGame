using DartGame.Models;
using DartGame.Views;
using System;
using System.Linq;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace DartGame.ViewModels
{
    public class GameOnViewModel : BaseViewModel
    {
        #region Constructor 

        public GameOnViewModel(GameConfigViewModel gameConfig) 
        {
            InitializeData(gameConfig);

            MessagingCenter.Subscribe<GameOnPage, Player>(this, "PlayerOne",
            (sender, player) =>
            {
                PlayersDataStore.SaveOrUpdatePlayerAsync(player);
            });

            MessagingCenter.Subscribe<GameOnPage, Player>(this, "PlayerTwo",
            (sender, player) =>
            {
                PlayersDataStore.SaveOrUpdatePlayerAsync(player);
            });
        }

        #endregion

        #region Private Members 

        private bool _playerOneTurn;
        private bool _isBoardVisible;
        private bool _isNumPadVisible;

        private Color _playerOneColor;
        private string _playerOneName;
        private int _playerOneGameScore;
        private int _playerOneLegsWon;
        private double _playerOneAvgScore;
        private string _playerOneDart1ToWin;
        private string _playerOneDart2ToWin;
        private string _playerOneDart3ToWin;

        private Color _playerTwoColor;
        private string _playerTwoName;
        private int _playerTwoGameScore;
        private int _playerTwoLegsWon;
        private double _playerTwoAvgScore;
        private string _playerTwoDart1ToWin;
        private string _playerTwoDart2ToWin;
        private string _playerTwoDart3ToWin;

        private Color _doublePressedColor;
        private Color _triplePressedColor;

        private bool _doublePressed;
        private bool _triplePressed;

        private bool _dart1ValueEntered;
        private bool _dart2ValueEntered;
        private bool _dart3ValueEntered;

        private int _currentScore;

        #endregion

        #region Public  Properties 

        #region Game Properties

        public GameConfig GameConfig { get; set; }    
               
        public bool PlayerOneTurn
        {
            get { return _playerOneTurn; }
            set
            {
                _playerOneTurn = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayerOneColor));
                OnPropertyChanged(nameof(PlayerTwoColor));
            }
        }

        public int CurrentScore
        {
            get { return _currentScore; }
            set
            {
                _currentScore = value;
                OnPropertyChanged();
            }
        }

        public bool IsNumPadVisible
        {
            get { return _isNumPadVisible; }
            set
            {
                _isNumPadVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsBoardVisible
        {
            get { return _isBoardVisible; }
            set
            {
                _isBoardVisible = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Player One Properties

        public Player PlayerOne { get; set; }

        public Color PlayerOneColor
        {
            get 
            { 
                return _playerOneColor = _playerOneTurn
                    ? Color.FromArgb(0, 204, 153) 
                    : Color.FromArgb(44, 62, 80); 
            }
            set 
            {
                _playerOneColor = value;
                OnPropertyChanged();
            }
        }

        public string PlayerOneName 
        { 
            get { return _playerOneName; }
            set 
            {
                _playerOneName = value;
                OnPropertyChanged();
            } 
        }

        public int PlayerOneGameScore
        {
            get { return _playerOneGameScore; }
            set
            {
                _playerOneGameScore = value;
                OnPropertyChanged();
            }
        }

        public int PlayerOneLegsWon 
        {
            get { return _playerOneLegsWon; }
            set 
            {
                _playerOneLegsWon = value;
                OnPropertyChanged();
            } 
        }

        public double PlayerOneAvgScore 
        {
            get { return _playerOneAvgScore; }
            set 
            {
                _playerOneAvgScore = value;
                OnPropertyChanged();
            } 
        }

        public string PlayerOneDart1ToWin 
        {
            get { return _playerOneDart1ToWin; } 
            set
            {
                _playerOneDart1ToWin = value;
                OnPropertyChanged();
            }
        }

        public string PlayerOneDart2ToWin 
        {
            get { return _playerOneDart2ToWin; } 
            set
            {
                _playerOneDart2ToWin = value;
                OnPropertyChanged();
            }
        }

        public string PlayerOneDart3ToWin 
        {
            get { return _playerOneDart3ToWin; }
            set
            {
                _playerOneDart3ToWin = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Player Two Properties

        public Player PlayerTwo { get; set; }

        public Color PlayerTwoColor
        {
            get
            {
                return _playerTwoColor = _playerOneTurn
                    ? Color.FromArgb(44, 62, 80)
                    : Color.FromArgb(0, 204, 153);
            }
            set
            {
                _playerTwoColor = value;
                OnPropertyChanged();
            }
        }

        public string PlayerTwoName 
        {
            get { return _playerTwoName; } 
            set
            {
                _playerTwoName = value;
                OnPropertyChanged();
            }
        }

        public int PlayerTwoGameScore
        {
            get { return _playerTwoGameScore; }
            set
            {
                _playerTwoGameScore = value;
                OnPropertyChanged();
            }
        }

        public int PlayerTwoLegsWon 
        {
            get { return _playerTwoLegsWon; } 
            set
            {
                _playerTwoLegsWon = value;
                OnPropertyChanged();
            }
        }

        public double PlayerTwoAvgScore 
        {
            get { return _playerTwoAvgScore; }
            set
            {
                _playerTwoAvgScore = value;
                OnPropertyChanged();
            }
        }

        public string PlayerTwoDart1ToWin 
        {
            get { return _playerTwoDart1ToWin; } 
            set
            {
                _playerTwoDart1ToWin = value;
                OnPropertyChanged();
            }
        }

        public string PlayerTwoDart2ToWin 
        {
            get { return _playerTwoDart2ToWin; }
            set
            {
                _playerTwoDart2ToWin = value;
                OnPropertyChanged();
            }
        }

        public string PlayerTwoDart3ToWin 
        {
            get { return _playerTwoDart3ToWin; }
            set
            {
                _playerTwoDart3ToWin = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region BoardGrid Properties

        public Color DoublePressedColor
        {
            get
            {
                return _doublePressedColor = _doublePressed
                    ? Color.FromArgb(0, 153, 153)
                    : Color.FromArgb(44, 62, 80);
            }
            set
            {
                _doublePressedColor = value;
                OnPropertyChanged();
            }
        }

        public Color TriplePressedColor
        {
            get
            {
                return _triplePressedColor = _triplePressed
                    ? Color.FromArgb(51, 153, 102)
                    : Color.FromArgb(44, 62, 80);
            }
            set
            {
                _triplePressedColor = value;
                OnPropertyChanged();
            }
        }

        public bool DoublePressed
        {
            get { return _doublePressed; }
            set
            {
                _doublePressed = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DoublePressedColor));
            }
        }

        public bool TriplePressed
        {
            get { return _triplePressed; }
            set
            {
                _triplePressed = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TriplePressedColor));
            }
        }

        public bool Dart1ValueEntered
        {
            get { return _dart1ValueEntered; }
            set
            {
                _dart1ValueEntered = value;
                OnPropertyChanged();
            }
        }

        public bool Dart2ValueEntered
        {
            get { return _dart2ValueEntered; }
            set
            {
                _dart2ValueEntered = value;
                OnPropertyChanged();
            }
        }

        public bool Dart3ValueEntered
        {
            get { return _dart3ValueEntered; }
            set
            {
                _dart3ValueEntered = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public void PopulatePlayerDartFinishes(bool isPlayerOne, bool resetGamePoints)
        {
            if (isPlayerOne)
            {
                var playerOneGameScore = resetGamePoints 
                    ? int.Parse( GameConfig.GameStartPoints) 
                    : PlayerOneGameScore;
                PlayerOneDart1ToWin = CalculatePlayerDartFinishes(playerOneGameScore, 1);
                PlayerOneDart2ToWin = CalculatePlayerDartFinishes(playerOneGameScore, 2);
                PlayerOneDart3ToWin = CalculatePlayerDartFinishes(playerOneGameScore, 3);
            }
            else
            {
                var playerTwoGameScore = resetGamePoints 
                    ? int.Parse(GameConfig.GameStartPoints) 
                    : PlayerTwoGameScore;
                PlayerTwoDart1ToWin = CalculatePlayerDartFinishes(playerTwoGameScore, 1);
                PlayerTwoDart2ToWin = CalculatePlayerDartFinishes(playerTwoGameScore, 2);
                PlayerTwoDart3ToWin = CalculatePlayerDartFinishes(playerTwoGameScore, 3);
            }
        }

        public double CalculateAvgScore()
        {
            if (PlayerOneTurn)
            {
                var gameTurns = GameTurnDataStore.GetTurnsAsync();
                var avgScore = gameTurns.Where(x => x.PlayerName == PlayerOneName)
                    .Average(s => s.TurnScore);

                var result = string.Format("{0:0.0}", Math.Truncate(avgScore * 10) / 10);
                return double.Parse(result);
            }
            else
            {
                var gameTurns = GameTurnDataStore.GetTurnsAsync();
                var avgScore = gameTurns.Where(x => x.PlayerName == PlayerTwoName)
                    .Average(s => s.TurnScore);

                var result = string.Format("{0:0.0}", Math.Truncate(avgScore * 10) / 10);
                return double.Parse(result);
            }
        }

        public void UpdatePlayerHighestScore(bool isPlayerOne)
        {
            if (isPlayerOne)
            {
                if(CurrentScore > PlayerOne.HighestScore)
                {
                    PlayerOne.HighestScore = CurrentScore;
                    _ = App.Database.UpdatePlayerAsync(PlayerOne).Result;
                }
            }
            else
            {
                if (CurrentScore > PlayerTwo.HighestScore)
                {
                    PlayerTwo.HighestScore = CurrentScore;
                    _ = App.Database.UpdatePlayerAsync(PlayerTwo).Result;
                }
            }
        }

        public void UpdatePlayersBestAverage()
        {
            if (PlayerOneAvgScore > PlayerOne.BestAvgScore)
            {
                PlayerOne.BestAvgScore = PlayerOneAvgScore;
                _ = App.Database.UpdatePlayerAsync(PlayerOne).Result;
            }

            if (PlayerTwoAvgScore > PlayerTwo.BestAvgScore)
            {
                PlayerTwo.BestAvgScore = PlayerTwoAvgScore;
                _ = App.Database.UpdatePlayerAsync(PlayerTwo).Result;
            }            
        }

        public void UpdatePlayerDartsUsedToFinish(bool isPlayerOne, int dartsUsed)
        {
            var gameTurns = GameTurnDataStore.GetTurnsAsync();
            if (isPlayerOne)
            {                
                if (dartsUsed > PlayerOne.MinimumDartsUsed)
                {
                    PlayerOne.MinimumDartsUsed = ((gameTurns.Count() / 2) * 3) + dartsUsed;
                    _ = App.Database.UpdatePlayerAsync(PlayerOne).Result;
                }
            }
            else
            {
                if (dartsUsed > PlayerTwo.MinimumDartsUsed)
                {
                    PlayerTwo.MinimumDartsUsed = ((gameTurns.Count() / 2) * 3) + dartsUsed;
                    _ = App.Database.UpdatePlayerAsync(PlayerTwo).Result;
                }
            }
        }

        public void ClearForNextLeg()
        {
            var gameTotalLegs = GameConfig.P1LegsWon + GameConfig.P2LegsWon;
            PlayerOneTurn = gameTotalLegs % 2 == 0;

            PlayerOneLegsWon = GameConfig.P1LegsWon;
            PlayerOneAvgScore = 0;
            PlayerOneGameScore = int.Parse(GameConfig.GameStartPoints);

            PopulatePlayerDartFinishes(true, true);

            PlayerTwoLegsWon = GameConfig.P2LegsWon;
            PlayerTwoAvgScore = 0;
            PlayerTwoGameScore = int.Parse(GameConfig.GameStartPoints);

            PopulatePlayerDartFinishes(false, true);

            CurrentScore = 0;
            GameTurnDataStore.ClearTurnsAsync();
        }

        public void ClearForNextGame()
        {
           PlayerOneTurn = true;

           PlayerOneLegsWon = 0;
           PlayerOneAvgScore = 0;
           PlayerOneGameScore = int.Parse(GameConfig.GameStartPoints);
           PopulatePlayerDartFinishes(true, true);

           PlayerTwoLegsWon = 0;
           PlayerTwoAvgScore = 0;
           PlayerTwoGameScore = int.Parse(GameConfig.GameStartPoints);
           PopulatePlayerDartFinishes(false, true);

           CurrentScore = 0;
           GameTurnDataStore.ClearTurnsAsync();
        }

        #endregion

        #region Private Methods

        private void InitializeData(GameConfigViewModel gameConfig)
        {
            PlayerOne = gameConfig.PlayerOne;
            PlayerTwo = gameConfig.PlayerTwo;

            GameConfig = new GameConfig
            {
                GameLegs = gameConfig.LegsToWin,
                GameStartPoints = gameConfig.PointsToWin
            };

            PlayerOneTurn = true;
            IsBoardVisible = false;
            IsNumPadVisible = true;

            PlayerOneName = gameConfig.PlayerOne.PlayerName;
            PlayerOneLegsWon = 0;
            PlayerOneAvgScore = 0;
            PlayerOneGameScore = int.Parse(gameConfig.PointsToWin);
            PopulatePlayerDartFinishes(true, true);

            PlayerTwoName = gameConfig.PlayerTwo.PlayerName;
            PlayerTwoLegsWon = 0;
            PlayerTwoAvgScore = 0;
            PlayerTwoGameScore = int.Parse(gameConfig.PointsToWin);
            PopulatePlayerDartFinishes(false, true);

            CurrentScore = 0;
        }

        private string CalculatePlayerDartFinishes(int playerScore, int dartNo)
        {
            var dartFinishes = new DartFinishes();
            if (!dartFinishes.DartFinishesList.TryGetValue(playerScore, out var dartFinishValues))
            {
                return "";
            }

            if (dartNo == 1)
            {
                return dartFinishValues.Dart1;
            }
            else if (dartNo == 2)
            {
                return dartFinishValues.Dart2;
            }
            else
            {
                return dartFinishValues.Dart3;
            }
        }

        #endregion
    }
}
