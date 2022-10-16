using WpfApplication.State;
using WpfApplication.ViewModels.Factories;

namespace WpfApplication.Commands
{
    internal class UpdateCurrentViewModelCommand : CommandBase
    {
        private readonly INavigator _navigator;
        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, 
            IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public override void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }
    }
}
