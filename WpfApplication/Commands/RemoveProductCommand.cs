using System.Collections.ObjectModel;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class RemoveProductCommand : CommandBase
    {
        private readonly CartViewModel _viewModel;
        private readonly ICartRepository _cartRepository;

        public RemoveProductCommand(CartViewModel viewModel, ICartRepository cartRepository)
        {
            _viewModel = viewModel;
            _cartRepository = cartRepository;
        }

        public override void Execute(object parameter)
        {
            Product product = parameter as Product;
            _cartRepository.RemoveProduct(product);
            _viewModel.Cart.Products = new ObservableCollection<Product>(_cartRepository.GetProducts());
            _viewModel.Cart.ProductsAmount = _cartRepository.GetProductsAmount();
            if (_viewModel.Cart.Products.Count == 0)
            {
                _viewModel.Cart.TotalAmount = _viewModel.Cart.ProductsAmount;
                _viewModel.Cart.CreditUsed = 0;
                _viewModel.IsCreditUsed = false;
            }
            else
            {
                _viewModel.Cart.TotalAmount = _viewModel.Cart.ProductsAmount - _viewModel.Cart.CreditUsed;
            }
        }
    }
}
