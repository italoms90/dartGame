using System;
using System.ComponentModel;
using Xamarin.Forms;
using DartGame.ViewModels;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class GamePointsConfigPage : ContentPage
    {
        #region Constructor

        public GamePointsConfigPage()
        {
            InitializeComponent();

            BindingContext = new GameConfigViewModel();
        }

        #endregion

        #region Event Handlers

        public async void GamePoints_Clicked(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;

            var gamePoints = button.Text;

            MessagingCenter.Send(this, "SelectedPoints", gamePoints);

            await Navigation.PopModalAsync();
        }

        #endregion
    }
}