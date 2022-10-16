using Microsoft.Extensions.Logging;
using WpfApplication.Commands;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class CartViewModelFactory : IViewModelFactory<CartViewModel>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomersRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<ConfirmOrderCommand> _logger;

        public CartViewModelFactory(ICartRepository cartRepository, ICustomersRepository customerRepository,
            ITransactionRepository transactionRepository, ILogger<ConfirmOrderCommand> logger)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public CartViewModel CreateViewModel()
        {
            return new CartViewModel(_cartRepository, _customerRepository,
                _transactionRepository, _logger);
        }
    }
}
