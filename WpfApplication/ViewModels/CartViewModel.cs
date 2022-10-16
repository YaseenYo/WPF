using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;

namespace WpfApplication.ViewModels
{
    internal class CartViewModel : ViewModelBase
    {
        private readonly ICartRepository _cartRepository;

        public CartViewModel(ICartRepository cartRepository, ICustomersRepository customerRepository, 
            ITransactionRepository transactionRepository, ILogger<ConfirmOrderCommand> logger)
        {
            _cartRepository = cartRepository;
            Cart = _cartRepository.GetCart();
            Cart.ProductsAmount = _cartRepository.GetProductsAmount();
            Cart.TotalAmount = Cart.ProductsAmount - Cart.CreditUsed;
            IsCreditUsed = Cart.CreditUsed != 0;
            CustomerExistCheckCommand = new CustomerExistCheckCommand(this, customerRepository);
            RemoveProductCommand = new RemoveProductCommand(this, cartRepository);
            UseCreditCommand = new UseCreditCommand(this);
            RemoveCreditCommand = new RemoveCreditCommand(this);
            ConfirmOrderCommand = new ConfirmOrderCommand(this, transactionRepository,
                customerRepository, _cartRepository, logger);
            CancelOrderCommand = new CancelOrderCommand(this, _cartRepository);
        }

        public ICommand CustomerExistCheckCommand { get; }
        public ICommand UseCreditCommand { get; }
        public ICommand RemoveCreditCommand { get; }
        public ICommand ConfirmOrderCommand { get; }
        public ICommand CancelOrderCommand { get; }
        public ICommand RemoveProductCommand { get; }

        private Cart _cart;

        public Cart Cart
        {
            get { return _cart; }
            set { _cart = value; OnPropertyChanged(nameof(Cart)); }
        }

        private Int64 _phoneNumber;

        public Int64 PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(nameof(Message)); }
        }

        private bool _isCreditUsed;

        public bool IsCreditUsed
        {
            get { return _isCreditUsed; }
            set { _isCreditUsed = value; OnPropertyChanged(nameof(IsCreditUsed)); }
        }
    }
}
