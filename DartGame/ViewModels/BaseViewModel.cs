﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DartGame.Services;

namespace DartGame.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IGameConfigDataStore GameConfigDataStore =>
            DependencyService.Get<IGameConfigDataStore>() ?? new GameConfigDataStore();
        public IPlayersDataStore PlayersDataStore =>
            DependencyService.Get<IPlayersDataStore>() ?? new PlayersDataStore();
        public IGameTurnDataStore GameTurnDataStore =>
            DependencyService.Get<IGameTurnDataStore>() ?? new GameTurnDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            { 
                return false; 
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}