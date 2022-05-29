using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DartGame.Models;
using DartGame.Views;
using Xamarin.Forms;

namespace DartGame.ViewModels
{
    public class PlayersViewModel : BaseViewModel
    {
        #region Constructor

        public PlayersViewModel()
        {
            InitializeData();
            MessageSubscriptions();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<Player> Players { get; set; }
        public Command LoadPlayersCommand { get; set; }

        #endregion

        #region Public methods

        public async Task ExecuteLoadPlayersCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Players.Clear();
                var players = await PlayersDataStore.GetPlayersAsync();
                foreach (var player in players)
                {
                    Players.Add(player);
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

        #region Private Methods

        private void InitializeData()
        {
            Title = "SELECT PLAYER";

            Players = new ObservableCollection<Player>();

            LoadPlayersCommand = new Command(async () => await ExecuteLoadPlayersCommand());
        }

        private void MessageSubscriptions()
        {
            MessagingCenter.Subscribe<PlayerDetailPage, Player>(this, "SavePlayer",
                async (sender, player) =>
                {
                    await PlayersDataStore.SaveOrUpdatePlayerAsync(player);
                    await ExecuteLoadPlayersCommand();
                });

            MessagingCenter.Subscribe<PlayersConfigPage, int>(this, "DeletePlayer",
                async (sender, playerId) =>
                {
                    await PlayersDataStore.DeletePlayerAsync(playerId);
                    await ExecuteLoadPlayersCommand();
                });
        }

        #endregion
    }
}
