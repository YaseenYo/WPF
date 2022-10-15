using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class CustomerRegistrationViewModel : ViewModelBase
    {
        public CustomerRegistrationViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            RegisterCommand = new RegisterCommand(this);
            Customer = new Customer();
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }

        public ICommand RegisterCommand { get; }
    }
}
