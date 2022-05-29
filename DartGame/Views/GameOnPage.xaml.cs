using System;
using System.ComponentModel;
using Xamarin.Forms;
using DartGame.Models;
using DartGame.ViewModels;
using Xamarin.Essentials;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class GameOnPage : ContentPage
    {
        #region Public Properties

        public GameOnViewModel GameOnViewModel;

        #endregion

        #region Private Fields

        private int _boardDartCount;

        #endregion

        #region Constructor

        public GameOnPage(GameConfigViewModel gameConfig)
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
            DeviceDisplay.KeepScreenOn = true;
            
            BindingContext = GameOnViewModel = new GameOnViewModel(gameConfig);
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }        

        protected override bool OnBackButtonPressed()
        {
            // Begin an asyncronous task on the UI thread because we intend to ask the users permission.
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (await DisplayAlert("Exit Game?", "Are you sure you want to exit the game?", "Yes", "No"))
                {
                    base.OnBackButtonPressed();

                    await Navigation.PopAsync();
                }
            });

            // Always return true because this method is not asynchronous.
            // We must handle the action ourselves: see above.
            return true;
        }

        #endregion

        #region Event Handlers

        public async void PlayerOne_Tapped(object sender, EventArgs eventArgs)
        {            
            await Navigation.PushAsync(new PlayerTurnPage(GameOnViewModel.PlayerOneName));
        }

        public async void PlayerTwo_Tapped(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PlayerTurnPage(GameOnViewModel.PlayerTwoName));
        }

        public void Number_Clicked(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            var number = button.ClassId;
            if(GameOnViewModel.CurrentScore > 0)
            {
                var numOfDigits = Math.Floor(Math.Log10(GameOnViewModel.CurrentScore) + 1);
                if (numOfDigits <= 2)
                {
                    GameOnViewModel.CurrentScore = int.Parse($"{GameOnViewModel.CurrentScore}{number}");
                }
                else
                {
                    return;
                }
            }
            else
            {
                GameOnViewModel.CurrentScore = int.Parse(number);
            }
        }

        public void BoardNumber_Clicked(object sender, EventArgs eventArgs)
        {
            if (_boardDartCount == 3)
            {
                return;
            }

            var button = (Button)sender;
            var number = button.ClassId;
            if (GameOnViewModel.DoublePressed)
            {
                var doubleScored = int.Parse(number) * 2;
                GameOnViewModel.CurrentScore += doubleScored;
                GameOnViewModel.DoublePressed = false;

                UpdateBoardDartPlayed($"D{number}");
            }
            else if (GameOnViewModel.TriplePressed)
            {
                int tripleScored;
                if (number == "25") 
                {
                    tripleScored = int.Parse(number) * 2;
                }
                else
                {
                    tripleScored = int.Parse(number) * 3;
                }

                GameOnViewModel.CurrentScore += tripleScored;
                GameOnViewModel.TriplePressed = false;

                UpdateBoardDartPlayed($"T{number}");
            }
            else
            {
                var noScored = int.Parse(number);
                GameOnViewModel.CurrentScore += noScored;

                UpdateBoardDartPlayed(number);
            }
        }

        public void Back_Clicked(object sender, EventArgs eventArgs)
        {
            if (GameOnViewModel.CurrentScore > 0)
            {
                var newNumber = GameOnViewModel.CurrentScore/10;
                GameOnViewModel.CurrentScore = newNumber;
            }
        }

        public void Clear_Clicked(object sender, EventArgs eventArgs)
        {
            _boardDartCount = 0;

            GameOnViewModel.DoublePressed = false;
            GameOnViewModel.TriplePressed = false;

            GameOnViewModel.Dart1ValueEntered = false;
            GameOnViewModel.Dart2ValueEntered = false;
            GameOnViewModel.Dart3ValueEntered = false;

            GameOnViewModel.CurrentScore = 0;
        }

        public async void End_Score(object sender, EventArgs eventArgs)
        {
            if(GameOnViewModel.CurrentScore > 180)
            {
                await DisplayAlert("WRONG!", "Score can't be greater than 180?", "Ok");
                return;
            }

            OnEndScore();            
        }

        public void Bust_Clicked(object sender, EventArgs eventArgs)
        {
            GameOnViewModel.CurrentScore = 0;

            OnEndScore();
        }

        public void BoardSwitch_Clicked(object sender, EventArgs eventArgs)
        {
            GameOnViewModel.IsBoardVisible = !GameOnViewModel.IsBoardVisible;
            GameOnViewModel.IsNumPadVisible = !GameOnViewModel.IsNumPadVisible;
        }

        public void Double_Pressed(object sender, EventArgs eventArgs)
        {
            if (GameOnViewModel.TriplePressed)
            {
                GameOnViewModel.TriplePressed = false;
            }

            GameOnViewModel.DoublePressed = !GameOnViewModel.DoublePressed;
        }

        public void Triple_Pressed(object sender, EventArgs eventArgs)
        {
            if (GameOnViewModel.DoublePressed)
            {
                GameOnViewModel.DoublePressed = false;
            }

            GameOnViewModel.TriplePressed = !GameOnViewModel.TriplePressed;
        }

        #endregion

        #region Private Methods

        private async void OnEndScore()
        {
            _boardDartCount = 0;

            GameOnViewModel.Dart1ValueEntered = false;
            GameOnViewModel.Dart2ValueEntered = false;
            GameOnViewModel.Dart3ValueEntered = false;

            if (GameOnViewModel.PlayerOneTurn)
            {
                GameOnViewModel.UpdatePlayerHighestScore(true);
                var remainingPoints = GameOnViewModel.PlayerOneGameScore - GameOnViewModel.CurrentScore;
                if (remainingPoints < 0)
                {
                    bool answer = await DisplayAlert("BUST",
                        "That's a Bust!! Are you sure you want to end your turn as a BUST?", "Ok", "Cancel");
                    if (!answer)
                    {
                        return;
                    }
                    
                    GameOnViewModel.CurrentScore = 0;
                    FinishTurn();

                    return;
                }

                if (remainingPoints == 0)
                {
                    GameOnViewModel.GameConfig.P1LegsWon += 1;
                    FinishLeg(true);           
                    
                    return;
                }

                GameOnViewModel.PlayerOneGameScore = remainingPoints;

                FinishTurn();                
            }
            else
            {
                GameOnViewModel.UpdatePlayerHighestScore(false);
                var remainingPoints = GameOnViewModel.PlayerTwoGameScore - GameOnViewModel.CurrentScore;
                if (remainingPoints < 0)
                {
                    bool answer = await DisplayAlert("BUST",
                        "That's a Bust!! Are you sure you want to end your turn as a BUST?", "Ok", "Cancel");
                    if (!answer)
                    {
                        return;
                    }

                    GameOnViewModel.CurrentScore = 0;
                    FinishTurn();

                    return;
                }

                if (remainingPoints == 0)
                {
                    GameOnViewModel.GameConfig.P2LegsWon += 1;
                    FinishLeg(false);           

                    return;
                }

                GameOnViewModel.PlayerTwoGameScore = remainingPoints;  

                FinishTurn();                            
            }
        }

        private void FinishTurn()
        {            
            if (GameOnViewModel.PlayerOneTurn)
            {
                var gameTurn = new GameTurn
                {
                    PlayerName = GameOnViewModel.PlayerOneName,
                    TurnScore = GameOnViewModel.CurrentScore
                };

                GameOnViewModel.GameTurnDataStore.AddGameTurnAsync(gameTurn);

                var avgScore = GameOnViewModel.CalculateAvgScore();            
                GameOnViewModel.PlayerOneAvgScore = avgScore;

                GameOnViewModel.PopulatePlayerDartFinishes(true, false);               
            }
            else
            {
                var gameTurn = new GameTurn
                {
                    PlayerName = GameOnViewModel.PlayerTwoName,
                    TurnScore = GameOnViewModel.CurrentScore
                };

                GameOnViewModel.GameTurnDataStore.AddGameTurnAsync(gameTurn);

                var avgScore = GameOnViewModel.CalculateAvgScore();
                GameOnViewModel.PlayerTwoAvgScore = avgScore;

                GameOnViewModel.PopulatePlayerDartFinishes(false, false);
            }            

            GameOnViewModel.PlayerOneTurn = !GameOnViewModel.PlayerOneTurn;

            GameOnViewModel.CurrentScore = 0;
        }

        private async void FinishLeg(bool isPlayerOne)
        {
            GameOnViewModel.UpdatePlayersBestAverage();
            GameOnViewModel.UpdatePlayerDartsUsedToFinish(true, 3);
            GameOnViewModel.UpdatePlayerDartsUsedToFinish(false, 3);

            string message;
            if (isPlayerOne)
            {
                if (int.Parse(GameOnViewModel.GameConfig.GameLegs) == GameOnViewModel.GameConfig.P1LegsWon)
                {
                    message = $"{GameOnViewModel.PlayerOneName} won this Game!! Well Done!!!";
                    FinishGame(isPlayerOne);
                }
                else
                {
                    message = $"{GameOnViewModel.PlayerOneName} won this LEG!! Well Done!!!";               
                    
                    GameOnViewModel.ClearForNextLeg();
                }
            }
            else
            {
                if (int.Parse(GameOnViewModel.GameConfig.GameLegs) == GameOnViewModel.GameConfig.P2LegsWon)
                {
                    message = $"{GameOnViewModel.PlayerTwoName} won this Game!! Well Done!!!";
                    FinishGame(isPlayerOne);
                }
                else
                {
                    message = $"{GameOnViewModel.PlayerTwoName} won this LEG!! Well Done!!!";
                    
                    GameOnViewModel.ClearForNextLeg();
                }
            }

            await DisplayAlert("WINNER", message, "Ok");
        }

        private void FinishGame(bool isPlayerOne)
        {
            if (isPlayerOne)
            {
                GameOnViewModel.PlayerOne.GamesWon += 1;
                GameOnViewModel.PlayerTwo.GamesLost += 1;
            }
            else
            {
                GameOnViewModel.PlayerTwo.GamesWon += 1;
                GameOnViewModel.PlayerOne.GamesLost += 1;
            }
               
            MessagingCenter.Send(this, "PlayerOne",
                    GameOnViewModel.PlayerOne);                
            MessagingCenter.Send(this, "PlayerTwo",
                    GameOnViewModel.PlayerTwo);

            GameOnViewModel.ClearForNextGame();
        }

        private void UpdateBoardDartPlayed(string noScored)
        {
            _boardDartCount++;

            if (_boardDartCount == 1)
            {
                GameOnViewModel.Dart1ValueEntered = true;
                GameOnViewModel.Dart1Value = noScored;
            }

            if (_boardDartCount == 2)
            {
                GameOnViewModel.Dart2ValueEntered = true;
                GameOnViewModel.Dart2Value = noScored;
            }

            if (_boardDartCount == 3)
            {
                GameOnViewModel.Dart3ValueEntered = true;
                GameOnViewModel.Dart3Value = noScored;
            }
        }

        #endregion
    }
}