using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DartGame.Models;
using Xamarin.Forms;

namespace DartGame.ViewModels
{    
    public class PlayerDetailViewModel : BaseViewModel
    {
        #region Constructor

        public PlayerDetailViewModel()
        {
            InitializeData();
        }

        public PlayerDetailViewModel(int playerId)
        {
            var player = App.Database.GetPlayerAsync(playerId).Result;

            InitializeData(player);
        }

        #endregion

        #region Public Properties

        public bool IsNewPlayer { get; set; }
        public Player Player { get; set; }

        public int PlayerId
        {
            get { return Player.PlayerId; }
            set
            {
                Player.PlayerId = value;
                OnPropertyChanged();
            }
        }

        public string PlayerName
        {
            get { return Player.PlayerName; }
            set
            {
                Player.PlayerName = value;
                OnPropertyChanged();
            }
        }

        public int GamesWon
        {
            get { return Player.GamesWon; }
            set
            {
                Player.GamesWon = value;
                OnPropertyChanged();
            }
        }

        public int GamesLost
        {
            get { return Player.GamesLost; }
            set
            {
                Player.GamesLost = value;
                OnPropertyChanged();
            }
        }

        #endregion        

        #region Private methods

        private void InitializeData(Player player = null)
        {
            Player = new Player();

            if (player == null)
            {
                return;
            }

            PlayerId = player.PlayerId;
            PlayerName = player.PlayerName;
            GamesWon = player.GamesWon;
            GamesLost = player.GamesLost;
        }

        #endregion
    }
}
