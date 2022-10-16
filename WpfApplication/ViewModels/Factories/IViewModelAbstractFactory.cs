using WpfApplication.State;

namespace WpfApplication.ViewModels.Factories
{
    interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
