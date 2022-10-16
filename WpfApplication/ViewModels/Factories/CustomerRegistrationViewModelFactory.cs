using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class CustomerRegistrationViewModelFactory : IViewModelFactory<CustomerRegistrationViewModel>
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerRegistrationViewModelFactory(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public CustomerRegistrationViewModel CreateViewModel()
        {
            return new CustomerRegistrationViewModel(_customersRepository);
        }
    }
}
