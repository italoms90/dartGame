using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DartGame.Views
{
    [DesignTimeVisible(false)]
    public partial class LegConfigPage : ContentPage
    {
        #region Constructor

        public LegConfigPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        public async void LegNum_Clicked(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;

            var numberOfLegs = button.Text;

            MessagingCenter.Send(this, "LegsToWin", numberOfLegs);

            await Navigation.PopModalAsync();
        }

        #endregion
    }
}