using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class CancelOrderCommand : CommandBase
    {
        private readonly CartViewModel _viewModel;
        private readonly ICartRepository _cartRepository;

        public CancelOrderCommand(CartViewModel viewModel,ICartRepository cartRepository)
        {
            _viewModel = viewModel; 
            _cartRepository = cartRepository;
        }

        public override void Execute(object parameter)
        {
            _cartRepository.ClearCart();
            _viewModel.Cart = _cartRepository.GetCart();
        }
    }
}
