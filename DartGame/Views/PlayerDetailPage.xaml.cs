using DartGame.Models;
using DartGame.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DartGame.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDetailPage : ContentPage
    {
        #region Public Properties
                
        public PlayerDetailViewModel PlayerDetailViewModel;

        #endregion

        #region Constructors

        public PlayerDetailPage()
        {
            InitializeComponent();

            BindingContext = PlayerDetailViewModel = new PlayerDetailViewModel();

            PlayerDetailViewModel.IsNewPlayer = true;
        }

        public PlayerDetailPage(int playerId)
        {
            InitializeComponent();

            PlayerDetailViewModel = new PlayerDetailViewModel(playerId);

            BindingContext = PlayerDetailViewModel;
        }

        #endregion

        #region Event Handlers

        public async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            var result = await DisplayAlert("Cancel Changes", "Are you sure you want to cancel your changes?", "Yes", "No");
            if (result)
            {
                await Navigation.PopAsync();
            }
        }

        public async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            var result = await DisplayAlert("Save Changes", "Are you sure you want to save your changes?", "Yes", "No");
            if (result)
            {
                MessagingCenter.Send(this, "SavePlayer", PlayerDetailViewModel.Player);

                if (PlayerDetailViewModel.IsNewPlayer)
                {
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
        }

        #endregion
    }
}