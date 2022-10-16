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
