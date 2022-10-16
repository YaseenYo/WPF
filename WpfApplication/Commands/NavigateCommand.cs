using System;
using WpfApplication.Stores;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase 
    {
        private readonly INavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(INavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel; 
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
