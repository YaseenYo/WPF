using System;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;

namespace WpfApplication.ViewModels
{
    internal class CartViewModel : ViewModelBase
    {
        private readonly ICartRepository _cartRepository;

        public CartViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _cartRepository = new CartRepository();
            Cart = _cartRepository.GetCart();
            Cart.ProductsAmount = _cartRepository.GetProductsAmount();
            Cart.TotalAmount = Cart.ProductsAmount - Cart.CreditUsed;
            IsCreditUsed = Cart.CreditUsed != 0;
            CustomerExistCheckCommand = new CustomerExistCheckCommand(this);
            RemoveProductCommand = new RemoveProductCommand(this);
            UseCreditCommand = new UseCreditCommand(this);
            RemoveCreditCommand = new RemoveCreditCommand(this);
            ConfirmOrderCommand = new ConfirmOrderCommand(this, _cartRepository);
            CancelOrderCommand = new CancelOrderCommand(this,_cartRepository);
        }

        public ICommand CustomerExistCheckCommand { get; }
        public UseCreditCommand UseCreditCommand { get; }
        public RemoveCreditCommand RemoveCreditCommand { get; }
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
