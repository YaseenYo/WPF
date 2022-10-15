using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class RemoveProductCommand : CommandBase
    {
        private Action _onProductRemoved;
        private ICartRepository _cartRepository;

        public RemoveProductCommand(Action onProductRemoved)
        {
            _onProductRemoved = onProductRemoved;
            _cartRepository = new CartRepository();
        }

        public override void Execute(object parameter)
        {
            Product product = parameter as Product;
            _cartRepository.RemoveProduct(product);
            _onProductRemoved();
        }
    }
}
