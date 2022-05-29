using System.ComponentModel;
using Xamarin.Forms;
using DartGame.ViewModels;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class PlayerTurnPage : ContentPage
    {
        #region Public Properties

        public PlayerTurnViewModel PlayerTurnViewModel;

        #endregion

        #region Constructor

        public PlayerTurnPage(string playerName)
        {
            InitializeComponent();

            BindingContext = PlayerTurnViewModel = new PlayerTurnViewModel(playerName);
        }

        #endregion

        #region Overrides

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (PlayerTurnViewModel.GameTurns.Count == 0)
            {
                PlayerTurnViewModel.LoadPlayerTurnsCommand.Execute(null);
            }
        }

        #endregion
    }
}