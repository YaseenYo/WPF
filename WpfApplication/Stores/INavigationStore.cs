using System;
using WpfApplication.ViewModels;

namespace WpfApplication.Stores
{
    internal interface INavigationStore
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}