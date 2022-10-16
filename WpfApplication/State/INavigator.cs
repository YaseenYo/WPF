using System.Windows.Input;
using WpfApplication.ViewModels;

namespace WpfApplication.State
{
    public enum ViewType
    {
        Home,
        Cart,
        Transaction,
        SearchTransaction,
        Customer,
        RegisterCustomer,
        AddProduct
    }

    interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
