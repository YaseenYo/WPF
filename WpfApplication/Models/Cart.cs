using System.Collections.ObjectModel;
using System.ComponentModel;


namespace WpfApplication.Models
{
    internal class Cart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Cart()
        {
            Products = new ObservableCollection<Product>();
            Customer = new Customer();
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set 
            { 
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private float _productsAmount;

        public float ProductsAmount
        {
            get { return _productsAmount; }
            set { _productsAmount = value;  OnPropertyChanged(nameof(ProductsAmount)); }
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }

        private float _totalAmount;

        public float TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private float _creditUsed;

        public float CreditUsed
        {
            get { return _creditUsed; }
            set
            {
                _creditUsed = value;
                OnPropertyChanged(nameof(CreditUsed));
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
