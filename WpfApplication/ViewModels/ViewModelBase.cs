using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand NavigateCustomersListCommand { get; }
        public ICommand NavigateProductsListCommand { get; }
        public ICommand NavigateCartCommand { get; }
        public ICommand NavigateCustomerRegistrationCommand { get; }
        public ICommand NavigateTransactionsListCommand { get; }
        public ICommand NavigateSearchTransactionCommand { get; }
        public ICommand NavigateAddProductCommand { get; }

        public ViewModelBase(NavigationStore navigationStore)
        {
            NavigateCustomersListCommand = new NavigateCommand<CustomerListViewModel>(navigationStore, () => new CustomerListViewModel(navigationStore));
            NavigateProductsListCommand = new NavigateCommand<ProductListViewModel>(navigationStore, () => new ProductListViewModel(navigationStore));
            NavigateTransactionsListCommand = new NavigateCommand<TransactionViewModel>(navigationStore, () => new TransactionViewModel(navigationStore));
            NavigateCustomerRegistrationCommand = new NavigateCommand<CustomerRegistrationViewModel>(navigationStore, () => new CustomerRegistrationViewModel(navigationStore));
            NavigateCartCommand = new NavigateCommand<CartViewModel>(navigationStore, () => new CartViewModel(navigationStore));
            NavigateSearchTransactionCommand = new NavigateCommand<SearchTransactionViewModel>(navigationStore, () => new SearchTransactionViewModel(navigationStore));
            NavigateAddProductCommand = new NavigateCommand<AddProductViewModel>(navigationStore, () => new AddProductViewModel(navigationStore));
        }

        public ViewModelBase() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
