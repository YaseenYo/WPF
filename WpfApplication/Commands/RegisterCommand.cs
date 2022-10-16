using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.ViewModels;

namespace WpfApplication.Commands
{
    internal class RegisterCommand : CommandBase
    {
        private readonly CustomerRegistrationViewModel _viewModel;
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<RegisterCommand> _logger;

        public RegisterCommand(CustomerRegistrationViewModel viewModel, 
            ICustomersRepository customersRepository, ILogger<RegisterCommand> logger)
        {
            _viewModel = viewModel;
            _customersRepository = customersRepository;
            _logger = logger;
        }

        public override void Execute(object parameter)
        {
            Customer customer = (Customer) parameter;
            if(string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.AccountNumber) ||
                string.IsNullOrWhiteSpace(customer.Address) || string.IsNullOrWhiteSpace(customer.Bank)
                    || customer.Phone == 0)
            {
                MessageBox.Show("Fill all the fields");
                return;
            }
            Customer customerExist = _customersRepository.Search(customer.Phone);
            if(customerExist != null)
            {
                MessageBox.Show($"Customer Already Exist With Mobile Number {customer.Phone}");
                return; 
            }
            customer.Id= Guid.NewGuid();
            _customersRepository.Add(customer);
            _logger.LogInformation($"Customer {customer.Name} have been Registered");
            MessageBox.Show("Customer Registered Successfully");
            _viewModel.Customer = new Customer();
        }
    }
}
