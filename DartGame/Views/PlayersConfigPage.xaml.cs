using System;
using System.ComponentModel;
using Xamarin.Forms;
using DartGame.Models;
using DartGame.ViewModels;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class PlayersConfigPage : ContentPage
    {
        #region Public Properties

        public PlayersViewModel PlayersViewModel;

        #endregion

        #region Private Fields

        private string _playerNo;

        #endregion

        #region Constructor

        public PlayersConfigPage(string playerNo)
        {
            InitializeComponent();

            _playerNo = playerNo;

            BindingContext = PlayersViewModel = new PlayersViewModel();
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (PlayersViewModel.Players.Count == 0)
            {
                PlayersViewModel.LoadPlayersCommand.Execute(null);
            }
        }

        #endregion

        #region Event Handlers

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var player = args.SelectedItem as Player;
            if (player == null)
            {
                return;
            }

            var message = _playerNo == "PlayerOne"
                ? "SelectedPlayerOne" 
                : "SelectedPlayerTwo";

            MessagingCenter.Send(this, message, player);
        
            await Navigation.PopModalAsync();          

            PlayersListView.SelectedItem = null;
        }

        public async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PlayerDetailPage()));
        }

        public void DeleteOption_Clicked(object sender, EventArgs e)
        {
            int idToDelete = (int)((MenuItem)sender).CommandParameter;

            MessagingCenter.Send(this, "DeletePlayer", idToDelete);
        }

        public async void EditOption_Clicked(object sender, EventArgs e)
        {
            int playerId = (int)((MenuItem)sender).CommandParameter;

            await Navigation.PushAsync(new PlayerDetailPage(playerId));
        }

        #endregion
    }
}