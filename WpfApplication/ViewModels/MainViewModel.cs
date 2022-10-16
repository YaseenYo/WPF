using System;
using System.Collections.Generic;
using System.Linq;
using WpfApplication.Services;
using WpfApplication.State;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        //private readonly INavigationStore _navigationStore;
        //public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);

            //_navigationStore = navigationStore;
            //_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        //private void OnCurrentViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentViewModel));
        //}
    }
}
