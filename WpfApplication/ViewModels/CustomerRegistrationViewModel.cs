using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class CustomerRegistrationViewModel : ViewModelBase
    {
		private readonly ICustomersRepository _repository;

        public CustomerRegistrationViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _repository = new CustomersRepository();
            RegisterCommand = new RegisterCommand(_repository,OnRegister);
            Customer = new Customer();
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }

        public ICommand RegisterCommand { get; }

        private void OnRegister()
        {
            Customer = new Customer();
        }

    }
}
