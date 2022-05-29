using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DartGame.Services;
using DartGame.Views;
using DartGame.Database;

namespace DartGame
{
    public partial class App : Application
    {
        private static MyDartGameDatabase _database;
        public static MyDartGameDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new MyDartGameDatabase();
                }

                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
