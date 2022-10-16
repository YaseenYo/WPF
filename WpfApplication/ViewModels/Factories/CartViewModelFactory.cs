using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Services;

namespace WpfApplication.ViewModels.Factories
{
    internal class CartViewModelFactory : IViewModelFactory<CartViewModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomersRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CartViewModelFactory(IProductRepository productRepository, ICartRepository cartRepository, 
            ICustomersRepository customerRepository, ITransactionRepository transactionRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }

        public CartViewModel CreateViewModel()
        {
            return new CartViewModel(_cartRepository, _productRepository, 
                _customerRepository, _transactionRepository);
        }
    }
}
