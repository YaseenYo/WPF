using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
