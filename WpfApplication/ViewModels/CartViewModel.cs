using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;
using WpfApplication.Services;
using WpfApplication.Stores;
using WpfApplication.Views;

namespace WpfApplication.ViewModels
{
    internal class CartViewModel : ViewModelBase
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ITransactionRepository _transactionRepository;
        private bool _isCreditUsed; 

        public CartViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _customerRepository = new CustomersRepository();
            _cartRepository = new CartRepository();
            _transactionRepository = new TransactionRepository();
            Cart = _cartRepository.GetCart();
            Cart.ProductsAmount = _cartRepository.GetProductsAmount();
            Cart.TotalAmount = Cart.ProductsAmount - Cart.CreditUsed;
            _isCreditUsed = Cart.CreditUsed != 0;
            CustomerExistCheckCommand = new CustomerExistCheckCommand(_customerRepository,OnCustomerExistCheckCommand);
            RemoveProductCommand = new RemoveProductCommand(OnProductRemoved);
            UseCreditCommand = new UseCreditCommand(OnUseCreditCommand,UseCreditCanExecute);
            RemoveCreditCommand = new RemoveCreditCommand(OnRemoveCreditCommand,RemoveCreditCanExecute);
            ConfirmOrderCommand = new ConfirmOrderCommand(OnOrderConfirmed);
            CancelOrderCommand = new CancelOrderCommand(OnOrderCancelled);
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

        private void OnCustomerExistCheckCommand()
        {
            Customer customer = _customerRepository.Search(PhoneNumber);
            _isCreditUsed = false;
            UseCreditCommand.OnCanExecuteChanged();
            RemoveCreditCommand.OnCanExecuteChanged();
            if (customer == null)
            {
                Message = "No Customer found";
                Cart.Customer = new Customer();
                Cart.CreditUsed = 0;
                Cart.TotalAmount = Cart.ProductsAmount;
                return;
            }
            Cart.Customer = customer;
            Cart.CreditUsed = 0;
            Cart.TotalAmount = Cart.ProductsAmount;
            Message = "";
        }

        private bool UseCreditCanExecute() => !_isCreditUsed;

        private bool RemoveCreditCanExecute() => _isCreditUsed;

        private void OnProductRemoved()
        {
            Cart.Products = new ObservableCollection<Product>(_cartRepository.GetProducts());
            Cart.ProductsAmount = _cartRepository.GetProductsAmount();
            if(Cart.Products.Count == 0)
            {
                Cart.TotalAmount = Cart.ProductsAmount;
                Cart.CreditUsed = 0;
                _isCreditUsed = false;
                UseCreditCommand.OnCanExecuteChanged();
                RemoveCreditCommand.OnCanExecuteChanged();
            }
            else
            {
                Cart.TotalAmount = Cart.ProductsAmount - Cart.CreditUsed;
            }
        }

        private void OnOrderConfirmed()
        {
            Transaction transaction = new Transaction();
            transaction.Id = Guid.NewGuid();
            transaction.Customer = Cart.Customer;
            transaction.CreditUsed = Cart.CreditUsed;
            transaction.Products = Cart.Products.ToList();
            _transactionRepository.Add(transaction);
            float percentageAmount = Cart.TotalAmount / 100;
            Customer customer = new Customer()
            {
                Id = Cart.Customer.Id,
                Name = Cart.Customer.Name,
                Phone = Cart.Customer.Phone,
                Credit = Cart.Customer.Credit - Cart.CreditUsed + percentageAmount,
                AccountNumber = Cart.Customer.AccountNumber,
                Bank = Cart.Customer.Bank,
                Address = Cart.Customer.Address,
            };
            _customerRepository.Update(customer);
            MessageBox.Show($"Order Successfull And Customer {Cart.Customer.Name} have been Credited with rs {percentageAmount}");
            OnOrderCancelled();
        }

        private void OnOrderCancelled()
        {
            _cartRepository.ClearCart();
            Cart = _cartRepository.GetCart();
        }

        private void OnUseCreditCommand()
        {
            Cart.CreditUsed = Cart.Customer.Credit;
            Cart.TotalAmount -= Cart.CreditUsed;
            _isCreditUsed = true;
            UseCreditCommand.OnCanExecuteChanged();
            RemoveCreditCommand.OnCanExecuteChanged();
        }

        private void OnRemoveCreditCommand()
        {
            Cart.TotalAmount += Cart.CreditUsed;
            Cart.CreditUsed = 0;
            _isCreditUsed = false;
            RemoveCreditCommand.OnCanExecuteChanged();
            UseCreditCommand.OnCanExecuteChanged();
        }
    }
}
