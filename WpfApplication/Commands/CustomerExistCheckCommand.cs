using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class CustomerExistCheckCommand : CommandBase
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly CartViewModel _viewModel;

        public CustomerExistCheckCommand(CartViewModel viewModel, ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            Customer customer = _customerRepository.Search(_viewModel.PhoneNumber);
            _viewModel.IsCreditUsed = false;
            //UseCreditCommand.OnCanExecuteChanged();
            //RemoveCreditCommand.OnCanExecuteChanged();
            
            if (customer == null)
            {
                _viewModel.Message = "No Customer found";
                _viewModel.Cart.Customer = new Customer();
            }
            else
            {
                _viewModel.Cart.Customer = customer;
                _viewModel.Message = "";
            }
            _viewModel.Cart.CreditUsed = 0;
            _viewModel.Cart.TotalAmount = _viewModel.Cart.ProductsAmount;
        }
    }
}
