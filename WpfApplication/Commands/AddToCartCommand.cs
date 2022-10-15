using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class AddToCartCommand : CommandBase
    {
        private readonly ICartRepository _cartRepository;

        public AddToCartCommand()
        {
            _cartRepository = new CartRepository(); 
        }

        public override void Execute(object parameter)
        {
            Product product = parameter as Product;
            if (_cartRepository.GetProducts().Contains(product))
            {
                MessageBox.Show("Product already added to cart");
                return;
            }
            _cartRepository.AddProductToCart(product);
        }
    }
}
