using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class CustomerRegistrationViewModel : ViewModelBase
    {
        public CustomerRegistrationViewModel(ICustomersRepository customersRepository)// : base(store,navigator)
        {
            RegisterCommand = new RegisterCommand(this,customersRepository);
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
