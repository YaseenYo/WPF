using Microsoft.Extensions.Logging;
using WpfApplication.Commands;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class AddProductViewModelFactory : IViewModelFactory<AddProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AddProductCommand> _logger;

        public AddProductViewModelFactory(IProductRepository productRepository, ILogger<AddProductCommand> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public AddProductViewModel CreateViewModel()
        {
            return new AddProductViewModel(_productRepository, _logger);
        }
    }
}
