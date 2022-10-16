using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class CustomerListViewModelFactory : IViewModelFactory<CustomerListViewModel>
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerListViewModelFactory(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public CustomerListViewModel CreateViewModel()
        {
            return new CustomerListViewModel(_customersRepository);
        }
    }
}
