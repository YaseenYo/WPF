using System.Windows;
using System;
using WpfApplication.Models;
using WpfApplication.ViewModels;
using System.Linq;
using WpfApplication.Services;
using Microsoft.Extensions.Logging;

namespace WpfApplication.Commands
{
    internal class ConfirmOrderCommand : CommandBase
    {
        private readonly CartViewModel _viewModel;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomersRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<ConfirmOrderCommand> _logger;

        public ConfirmOrderCommand(CartViewModel viewModel, ITransactionRepository transactionRepository,
            ICustomersRepository customerRepository, ICartRepository cartRepository, ILogger<ConfirmOrderCommand> logger)
        {
            _viewModel = viewModel;
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
            _cartRepository = cartRepository;
            _logger = logger;
        }

        public override void Execute(object parameter)
        {
            Transaction transaction = new Transaction();
            transaction.Id = Guid.NewGuid();
            transaction.Customer = _viewModel.Cart.Customer;
            transaction.CreditUsed = _viewModel.Cart.CreditUsed;
            transaction.Products = _viewModel.Cart.Products.ToList();
            _transactionRepository.Add(transaction);
            float percentageAmount = _viewModel.Cart.TotalAmount / 100;
            Customer customer = new Customer()
            {
                Id = _viewModel.Cart.Customer.Id,
                Name = _viewModel.Cart.Customer.Name,
                Phone = _viewModel.Cart.Customer.Phone,
                Credit = _viewModel.Cart.Customer.Credit - _viewModel.Cart.CreditUsed + percentageAmount,
                AccountNumber = _viewModel.Cart.Customer.AccountNumber,
                Bank = _viewModel.Cart.Customer.Bank,
                Address = _viewModel.Cart.Customer.Address,
            };
            _customerRepository.Update(customer);
            _logger.LogInformation($"Order Successfull And Customer {_viewModel.Cart.Customer.Name} have been Credited with rs {percentageAmount}");
            MessageBox.Show($"Order Successfull And Customer {_viewModel.Cart.Customer.Name} have been Credited with rs {percentageAmount}");
            _cartRepository.ClearCart();
            _viewModel.Cart = _cartRepository.GetCart();
        }
    }
}
