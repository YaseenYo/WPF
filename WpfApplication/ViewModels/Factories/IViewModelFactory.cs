namespace WpfApplication.ViewModels.Factories
{
    interface IViewModelFactory<T> where T : ViewModelBase 
    {
        T CreateViewModel();
    }
}
