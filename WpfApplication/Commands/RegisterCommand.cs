using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class RegisterCommand : CommandBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly Action _onRegister;

        public RegisterCommand(ICustomersRepository customersRepository,Action onRegister)
        {
            _customersRepository = customersRepository;
            _onRegister = onRegister;
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
                MessageBox.Show("Customer Already Exist");
                return; 
            }
            customer.Id= Guid.NewGuid();
            _customersRepository.Add(customer);
            MessageBox.Show("Customer Registered Successfully");
            _onRegister();
        }
    }
}
