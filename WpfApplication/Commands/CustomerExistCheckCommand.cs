using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.Commands
{
    internal class CustomerExistCheckCommand : CommandBase
    {
        private readonly ICustomersRepository _customerRepository;
        private Action OnCustomerExistCheck;

        public CustomerExistCheckCommand(ICustomersRepository customerRepository, Action onCustomerExistCheck)
        {
            _customerRepository = customerRepository;
            OnCustomerExistCheck = onCustomerExistCheck;
        }

        public override void Execute(object parameter)
        {
            OnCustomerExistCheck();
        }
    }
}
