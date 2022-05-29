using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using DartGame.ViewModels;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class GameConfigPage : ContentPage
    {
        #region Public Properties

        public GameConfigViewModel GameConfigViewModel;

        #endregion

        #region Constructor

        public GameConfigPage()
        {
            InitializeComponent();

            GameConfigViewModel = new GameConfigViewModel();

            BindingContext = GameConfigViewModel;
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #endregion

        #region Event Handlers

        public async void Player_Clicked(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            var playerNo = button.ClassId;

            await Navigation.PushModalAsync(new NavigationPage(new PlayersConfigPage(playerNo)));
        }

        public async void GameStartPoint_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GamePointsConfigPage()));
        }

        public async void LegsToWin_Clicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushModalAsync(new NavigationPage(new LegConfigPage()));
        }

        public async void GameStart_Clicked(object sender, EventArgs eventArgs)
        {
            if (! await GameStartValidation())
            {
                return;
            }

            await GameConfigViewModel.SaveGameConfig();
            await Navigation.PushAsync(new GameOnPage(GameConfigViewModel));
        }

        #endregion

        #region Private Methods
        
        private async Task<bool> GameStartValidation()
        {
            if(GameConfigViewModel.PointsToWin == "Start Points")
            {
                await DisplayAlert("StartPoints", "Select Game Point before Start", "OK");
                
                return false;
            }

            if (GameConfigViewModel.LegsToWin == "Legs")
            {
                await DisplayAlert("GameLegs", "Select Game Legs before Start", "OK");

                return false;
            }

            return true;
        }

        #endregion
    }
}