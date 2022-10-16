using Microsoft.Extensions.Logging;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    internal class CustomerRegistrationViewModel : ViewModelBase
    {
        public CustomerRegistrationViewModel(ICustomersRepository customersRepository,
            ILogger<RegisterCommand> logger)
        {
            RegisterCommand = new RegisterCommand(this,customersRepository,logger);
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
