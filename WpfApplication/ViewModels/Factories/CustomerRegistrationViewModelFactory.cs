using Microsoft.Extensions.Logging;
using WpfApplication.Commands;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class CustomerRegistrationViewModelFactory : IViewModelFactory<CustomerRegistrationViewModel>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<RegisterCommand> _logger;

        public CustomerRegistrationViewModelFactory(ICustomersRepository customersRepository, ILogger<RegisterCommand> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public CustomerRegistrationViewModel CreateViewModel()
        {
            return new CustomerRegistrationViewModel(_customersRepository,_logger);
        }
    }
}
